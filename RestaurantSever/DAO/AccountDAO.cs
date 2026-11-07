using Microsoft.Data.SqlClient;
using RestaurantShared;
using RestaurantShared.DTO;
using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Transactions;

namespace RestaurantSever.DAO 
{
    public class AccountDAO
    {
        private static readonly Lazy<AccountDAO> AcDAO = new(() => new AccountDAO());
        public static AccountDAO Instance => AcDAO.Value;
        private AccountDAO() { }

        public string Login(string username, string password)
        {
            // 1. Kiểm tra đầu vào rỗng
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
                return string.Empty;

            // Chuẩn hóa username (cắt khoảng trắng thừa)
            string cleanUsername = username.Trim();

            // 2. Lấy thêm cột TrangThai (nếu bảng TAIKHOAN của bạn có cột này)
            string query = "SELECT MatKhau, MaNV, TrangThai, Email FROM TAIKHOAN WHERE TenDangNhap = @username";

            DataTable data = DataProvider.Instance.ExecuteQuery(
                query,
                new SqlParameter("@username", cleanUsername)
            );

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];

                // 3. Kiểm tra tài khoản có đang bị khóa không (tùy chỉnh theo giá trị cột TrangThai của bạn)
                string trangThai = row["TrangThai"]?.ToString()?.Trim() ?? string.Empty;
                if (trangThai.Equals("Khóa", StringComparison.OrdinalIgnoreCase) || trangThai == "0")
                {
                    return "LOCKED"; // Trả về mã đặc biệt để Server biết và báo "Tài khoản đã bị khóa!"
                }

                string hashPwd = row["MatKhau"]?.ToString()?.Trim() ?? string.Empty;

                // 4.kiểm tra định dạng BCrypt để tránh crash Server nếu DB có dữ liệu rác
                if (hashPwd.StartsWith("$2a$") || hashPwd.StartsWith("$2b$") || hashPwd.StartsWith("$2y$"))
                {
                    bool isCorrect = BCrypt.Net.BCrypt.Verify(password, hashPwd);
                    if (isCorrect)
                    {
                        return row["MaNV"]?.ToString()?.Trim() ?? string.Empty;
                    }
                }
            }

            return string.Empty;
        }
        // 1. Hàm kiểm tra trùng Tên đăng nhập
        public bool CheckUsernameExists(string username)
        {
            string query = "SELECT COUNT(1) FROM TAIKHOAN WHERE TenDangNhap = @user";
            SqlParameter[] parameters = { new SqlParameter("@user", username.Trim()) };

            object? result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }
        public string GetEmailByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return string.Empty;
            string query = "SELECT Email FROM TAIKHOAN WHERE TenDangNhap = @username";

            object data = DataProvider.Instance.ExecuteScalar(
                query,
                new SqlParameter("@username", username.Trim())
            );
            if (data == null || data == DBNull.Value) return string.Empty;
            return data.ToString()!;
        }

        // 2. Hàm thêm Tài Khoản (Khớp 100% với 5 cột trong bảng TAIKHOAN của bạn)
        public bool InsertAccount(string maNV, string username, string password)
        {
            if (string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            string query = "INSERT INTO TAIKHOAN(MaNV, TenDangNhap, MatKhau, TrangThai, NgayTao) " +
                           "VALUES(@manv, @user, @pass, N'Hoạt động', GETDATE())";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@manv", maNV.Trim()),
            new SqlParameter("@user", username.Trim()),
            new SqlParameter("@pass", hashedPassword)
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool ChangePassword(string username, string password)
        {

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            string query = @"UPDATE TAIKHOAN
                             SET MatKhau = @pass
                             WHERE TenDangNhap = @user";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@user", username.Trim()),
            new SqlParameter("@pass", hashedPassword)
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // 3. Hàm điều phối Transaction Đăng ký (Trả về Tuple gồm cờ bool và thông báo)
        public (bool IsSuccess, string Message) RegisterAccount(RegisterRequest req)
        {
            try
            {
                // Kiểm tra trùng tên đăng nhập trước khi mở Transaction
                if (CheckUsernameExists(req.Username))
                {
                    return (false, $"Tên đăng nhập '{req.Username}' đã tồn tại! Vui lòng chọn tên khác.");
                }

                using (var scope = new TransactionScope())
                {
                    // Tự động lấy mã NV mới nhất (VD: NV03)
                    string newMaNV = NhanVienDAO.Instance.GenerateNextMaNV();

                    // Thêm vào bảng NHANVIEN trước để có khóa chính
                    bool nvAdded = NhanVienDAO.Instance.InsertNhanVien(
                        newMaNV, req.HoTen, req.GioiTinh, req.VaiTro,
                        req.NgaySinh, req.SDT, req.Email, req.DiaChi
                    );

                    if (!nvAdded)
                        return (false, "Dữ liệu thông tin nhân viên không hợp lệ!");

                    // Thêm vào bảng TAIKHOAN với mã newMaNV vừa tạo
                    bool tkAdded = InsertAccount(newMaNV, req.Username, req.Password);

                    if (!tkAdded)
                        return (false, "Không thể tạo tài khoản lúc này.");

                    // Chốt lưu cả 2 bảng
                    scope.Complete();
                    return (true, $"Đăng ký thành công! Mã nhân viên mới là: {newMaNV}");
                }
            }
            catch (SqlException sqlEx)
            {
                // Mã lỗi 2627 hoặc 2601 của SQL Server là lỗi trùng lặp khóa (Unique/Primary Key)
                if (sqlEx.Number == 2627 || sqlEx.Number == 2601)
                    return (false, "Tên đăng nhập hoặc Mã nhân viên đã bị trùng trong hệ thống!");

                return (false, $"Lỗi cơ sở dữ liệu: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi hệ thống: {ex.Message}");
            }
        }
    }
}