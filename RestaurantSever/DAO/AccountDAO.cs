using Microsoft.Data.SqlClient;
using System;
using System.Data;
using RestaurantShared;

namespace RestaurantSever.DAO // Gợi ý: Nên chuyển sang namespace của riêng Project Server
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
            string query = "SELECT MatKhau, MaNV, TrangThai FROM TAIKHOAN WHERE TenDangNhap = @username";

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

                // 4. Bọc try-catch hoặc kiểm tra định dạng BCrypt để tránh crash Server nếu DB có dữ liệu rác
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
    }
}