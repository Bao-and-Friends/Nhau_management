using Dapper; // 👈 Nhớ thêm using Dapper
using Microsoft.Data.SqlClient;
using RestaurantAPI.DAO;

namespace RestaurantAPI.Data
{
    public class AccountDAO(DapperContext context)
    {
        public async Task<bool> CheckUsernameExistsAsync(string username)
        {
            string query = "SELECT COUNT(1) FROM TAIKHOAN WHERE TenDangNhap = @Username";
            int count = await context.ExecuteScalarAsync<int>(query, new { Username = username.Trim() });
            return count > 0;
        }

        public async Task<(bool IsSuccess, string MaNV, string Message)> ValidateLoginAsync(string username, string password)
        {
            string query = "SELECT MatKhau, MaNV, TrangThai FROM TAIKHOAN WHERE TenDangNhap = @Username";
            var account = await context.QueryFirstOrDefaultAsync<dynamic>(query, new { Username = username.Trim() });
            if (account == null)
                return (false, string.Empty, "Tài khoản không tồn tại!");
            string trangThai = account.TrangThai?.ToString()?.Trim() ?? string.Empty;
            if (trangThai.Equals("Khóa", StringComparison.OrdinalIgnoreCase) || trangThai == "0")
                return (false, string.Empty, "Tài khoản đã bị khóa!");
            string hashPwd = account.MatKhau?.ToString()?.Trim() ?? string.Empty;
            if (hashPwd.StartsWith("$2a$") || hashPwd.StartsWith("$2b$") || hashPwd.StartsWith("$2y$"))
            {
                if (BCrypt.Net.BCrypt.Verify(password, hashPwd))
                {
                    return (true, account.MaNV?.ToString()?.Trim() ?? string.Empty, "Đăng nhập thành công!");
                }
            }
            return (false, string.Empty, "Mật khẩu không chính xác!");
        }

        public async Task<string?> GetEmailByUsernameAsync(string username)
        {
            string query = "SELECT Email FROM TAIKHOAN WHERE TenDangNhap = @Username";
            return await context.ExecuteScalarAsync<string>(query, new { Username = username.Trim() });
        }

        public async Task<bool> ChangePasswordAsync(string username, string newPassword)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            string query = "UPDATE TAIKHOAN SET MatKhau = @MatKhau WHERE TenDangNhap = @Username";
            int rows = await context.ExecuteAsync(query, new { MatKhau = hash, Username = username.Trim() });
            return rows > 0;
        }

        // 👉 CẬP NHẬT HÀM NÀY: Nhận thêm conn và trans tùy chọn
        public async Task<bool> InsertAccountAsync(
            string maNV, string username, string passwordHash,
            SqlConnection? conn = null, SqlTransaction? trans = null)
        {
            string query = @"INSERT INTO TAIKHOAN (MaNV, TenDangNhap, MatKhau, TrangThai, NgayTao)
                             VALUES (@MaNV, @Username, @MatKhau, N'Hoạt động', GETDATE())";

            var param = new { MaNV = maNV, Username = username, MatKhau = passwordHash };

            if (conn != null)
            {
                int rows = await conn.ExecuteAsync(query, param, trans);
                return rows > 0;
            }

            return (await context.ExecuteAsync(query, param)) > 0;
        }
    }
}