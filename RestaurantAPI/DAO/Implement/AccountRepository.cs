using Dapper;
using RestaurantAPI.DAO.Interface;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.DAO.Implement
{
    public class AccountRepository(DbSession session): IAccountRepository
    {
        public async Task<bool> CheckUsernameExistsAsync(string username)
        {
            string query = "SELECT COUNT(1) FROM TAIKHOAN WHERE TenDangNhap = @Username";
            int count = await session.Connect.ExecuteScalarAsync<int>(query, new { Username = username.Trim() }, session.Transaction);
            return count > 0;
        }

        public async Task<AccountDATA?> GetByUsernameAsync(string username)
        {
            string query = "SELECT TaiKhoanID, NhanVienID, TenDangNhap, MatKhau,Email, TrangThai, NgayTao FROM TAIKHOAN WHERE TenDangNhap = @Username";
            return await session.Connect.QueryFirstOrDefaultAsync<AccountDATA>(query, new { Username = username.Trim() }, session.Transaction);
        }

        public async Task<string?> GetEmailByUsernameAsync(string username)
        {
            string query = "SELECT Email FROM TAIKHOAN WHERE TenDangNhap = @Username";
            return await session.Connect.ExecuteScalarAsync<string>(query, new { Username = username.Trim() }, session.Transaction);
        }

        public async Task<bool> UpdatePasswordHashAsync(string username, string passwordHash)
        {
            string query = "UPDATE TAIKHOAN SET MatKhau = @MatKhau WHERE TenDangNhap = @Username";
            int rows = await session.Connect.ExecuteAsync(query, new { MatKhau = passwordHash, Username = username.Trim() }, session.Transaction);
            return rows > 0;
        }

        public async Task<bool> InsertAccountAsync(int nvId, string username, string passwordHash, string? email)
        {
            string query = @"
        INSERT INTO TAIKHOAN (NhanVienID, TenDangNhap, MatKhau, Email, TrangThai)
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
