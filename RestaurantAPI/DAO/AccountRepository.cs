using Dapper; 
using RestaurantAPI.DAO.Interface;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.DAO
{
    public class AccountRepository(DbSession session): IAccountRepository
    {
        public async Task<bool> CheckUsernameExistsAsync(string username)
        {
            string query = "SELECT COUNT(1) FROM TAIKHOAN WHERE TenDangNhap = @Username";
            int count = await session.Connect.ExecuteScalarAsync<int>(query, new { Username = username.Trim() }, session.Transaction);
            return count > 0;
        }

        public async Task<(bool IsSuccess, int NVId, string Message)> ValidateLoginAsync(string username, string password)
        {
            string query = "SELECT MatKhau, NVId, TrangThai FROM TAIKHOAN WHERE TenDangNhap = @Username";
            var account = await session.Connect.QueryFirstOrDefaultAsync<AccountDATA>(query, new { Username = username.Trim() }, session.Transaction);
            if (account == null)
                return (false, 0, "Tài khoản không tồn tại!");

            string trangThai = account.TrangThai?.ToString()?.Trim() ?? string.Empty;
            if (trangThai.Equals("Khóa", StringComparison.OrdinalIgnoreCase) || trangThai == "0")
                return (false, 0, "Tài khoản đã bị khóa!");

            string hashPwd = account.MatKhau?.ToString()?.Trim() ?? string.Empty;
            if (hashPwd.StartsWith("$2a$") || hashPwd.StartsWith("$2b$") || hashPwd.StartsWith("$2y$"))
            {
                if (BCrypt.Net.BCrypt.Verify(password, hashPwd))
                {
                    return (true, account.NVId, "Đăng nhập thành công!");
                }
            }
            return (false, 0, "Mật khẩu không chính xác!");
        }

        public async Task<string?> GetEmailByUsernameAsync(string username)
        {
            string query = "SELECT Email FROM TAIKHOAN WHERE TenDangNhap = @Username";
            return await session.Connect.ExecuteScalarAsync<string>(query, new { Username = username.Trim() }, session.Transaction);
        }

        public async Task<bool> ChangePasswordAsync(string username, string newPassword)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            string query = "UPDATE TAIKHOAN SET MatKhau = @MatKhau WHERE TenDangNhap = @Username";
            int rows = await session.Connect.ExecuteAsync(query, new { MatKhau = hash, Username = username.Trim() }, session.Transaction);
            return rows > 0;
        }

        public async Task<bool> InsertAccountAsync(int nvId, string username, string passwordHash, string? email)
        {
            string query = @"
        INSERT INTO TAIKHOAN (NVId, TenDangNhap, MatKhau, Email, TrangThai)
        VALUES (@NVId, @Username, @MatKhau, @Email, N'Hoạt động')";

            var param = new
            {
                NVId = nvId,
                Username = username.Trim(),
                MatKhau = passwordHash,
                Email = email?.Trim()
            };
            return (await session.Connect.ExecuteAsync(query, param, session.Transaction)) > 0;
        }
    }
}
