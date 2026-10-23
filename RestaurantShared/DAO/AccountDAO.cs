using Microsoft.Data.SqlClient;
using RestaurantShared.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RestaurantShared.DAO
{
    public class AccountDAO
    {
        private static readonly Lazy<AccountDAO> AcDAO = new(() => new AccountDAO());
        public static AccountDAO Instance => AcDAO.Value;
        private AccountDAO() { }

        public string Login(string username, string password)
        {
            string query = "select * from TAIKHOAN where TenDangNhap = @username and MatKhau = @password";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new SqlParameter("@username", username), new SqlParameter("@password", password));
            if (data.Rows.Count > 0)
            {
                string IDNhanVien = data.Rows[0]["MaNV"]?.ToString() ?? "";
                return IDNhanVien;
            }
            return "";
        }

        // Tìm tài khoản theo số điện thoại (dùng cho Quên mật khẩu)
        public DataRow? FindAccountByPhone(string phone)
        {
            string query = @"SELECT N.MaNV, N.HoTen, N.SoDienThoai, T.TenDangNhap 
                             FROM NHANVIEN N 
                             INNER JOIN TAIKHOAN T ON N.MaNV = T.MaNV 
                             WHERE REPLACE(REPLACE(N.SoDienThoai, ' ', ''), '.', '') = @phone";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new SqlParameter("@phone", phone.Trim()));
            if (data.Rows.Count > 0)
            {
                return data.Rows[0];
            }
            return null;
        }

        // Cập nhật mật khẩu mới theo tên đăng nhập
        public bool UpdatePassword(string username, string newPassword)
        {
            string query = "UPDATE TAIKHOAN SET MatKhau = @newPassword WHERE TenDangNhap = @username";
            int rows = DataProvider.Instance.ExecuteNonQuery(query,
                new SqlParameter("@newPassword", newPassword),
                new SqlParameter("@username", username));
            return rows > 0;
        }

        // Đăng ký nhân viên và tài khoản mới (Chỉ dành cho Quản lý)
        public bool CreateStaffAndAccount(NhanVienDATA nv, string username, string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            // 1. Kiểm tra trùng tên đăng nhập
            string checkUserQuery = "SELECT COUNT(*) FROM TAIKHOAN WHERE TenDangNhap = @username";
            object? userCountObj = DataProvider.Instance.ExecuteScalar(checkUserQuery, new SqlParameter("@username", username));
            if (userCountObj != null && Convert.ToInt32(userCountObj) > 0)
            {
                errorMessage = "Tên đăng nhập này đã được sử dụng!";
                return false;
            }

            // 2. Kiểm tra trùng mã nhân viên
            string checkNvQuery = "SELECT COUNT(*) FROM NHANVIEN WHERE MaNV = @manv";
            object? nvCountObj = DataProvider.Instance.ExecuteScalar(checkNvQuery, new SqlParameter("@manv", nv.MaNV));
            if (nvCountObj != null && Convert.ToInt32(nvCountObj) > 0)
            {
                errorMessage = "Mã nhân viên này đã tồn tại trong hệ thống!";
                return false;
            }

            // 3. Thêm vào bảng NHANVIEN
            string insertNvQuery = @"INSERT INTO NHANVIEN (MaNV, HoTen, NgaySinh, GioiTinh, SoDienThoai, DiaChi, VaiTro, TrangThai)
                                    VALUES (@manv, @hoten, @ngaysinh, @gioitinh, @sdt, @diachi, @vaitro, @trangthai)";

            int nvRows = DataProvider.Instance.ExecuteNonQuery(insertNvQuery,
                new SqlParameter("@manv", nv.MaNV),
                new SqlParameter("@hoten", nv.HoTen),
                new SqlParameter("@ngaysinh", nv.NgaySinh),
                new SqlParameter("@gioitinh", nv.GioiTinh),
                new SqlParameter("@sdt", nv.SoDienThoai),
                new SqlParameter("@diachi", nv.DiaChi),
                new SqlParameter("@vaitro", nv.VaiTro),
                new SqlParameter("@trangthai", string.IsNullOrWhiteSpace(nv.TrangThai) ? "Đang làm" : nv.TrangThai));

            if (nvRows <= 0)
            {
                errorMessage = "Lỗi khi thêm hồ sơ nhân viên!";
                return false;
            }

            // 4. Sinh mã tài khoản tự động (TK + 3 số ngẫu nhiên hoặc sequence)
            string maTaiKhoan = "TK" + (DateTime.Now.Ticks % 10000).ToString("D4");
            string insertAccountQuery = @"INSERT INTO TAIKHOAN (MaTaiKhoan, MaNV, TenDangNhap, MatKhau, TrangThai, NgayTao)
                                          VALUES (@matk, @manv, @username, @password, N'Hoạt động', GETDATE())";

            int accRows = DataProvider.Instance.ExecuteNonQuery(insertAccountQuery,
                new SqlParameter("@matk", maTaiKhoan),
                new SqlParameter("@manv", nv.MaNV),
                new SqlParameter("@username", username),
                new SqlParameter("@password", password));

            if (accRows <= 0)
            {
                errorMessage = "Lỗi khi tạo tài khoản đăng nhập!";
                return false;
            }

            return true;
        }
    }
}
