using Dapper; // 👈 Nhớ thêm using Dapper
using Microsoft.Data.SqlClient;
using RestaurantAPI.DAO;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.Data
{
    public class StaffDAO(DapperContext context)
    {
        public async Task<StaffDATA?> GetByIdAsync(string maNV)
        {
            string query = "SELECT * FROM NHANVIEN WHERE MaNV = @MaNV";
            return await context.QueryFirstOrDefaultAsync<StaffDATA>(query, new { MaNV = maNV });
        }

        public async Task<string> GenerateNextMaNVAsync()
        {
            string query = "SELECT TOP 1 MaNV FROM NHANVIEN ORDER BY LEN(MaNV) DESC, MaNV DESC";
            string? lastMaNV = await context.ExecuteScalarAsync<string>(query);
            if (!string.IsNullOrEmpty(lastMaNV) && lastMaNV.StartsWith("NV") && int.TryParse(lastMaNV.Substring(2), out int lastNum))
            {
                return $"NV{(lastNum + 1):D2}";
            }
            return "NV01";
        }

        // 👉 CẬP NHẬT HÀM NÀY: Nhận thêm conn và trans tùy chọn
        public async Task<bool> InsertAsync(
            string maNV, string hoTen, string gioiTinh, string vaiTro,
            DateTimeOffset? ngaySinh, string? sdt, string? email, string? diaChi,
            SqlConnection? conn = null, SqlTransaction? trans = null)
        {
            string query = @"INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh, VaiTro, NgaySinh, SoDienThoai, Email, DiaChi)
                             VALUES (@MaNV, @HoTen, @GioiTinh, @VaiTro, @NgaySinh, @SDT, @Email, @DiaChi)";

            var param = new
            {
                MaNV = maNV,
                HoTen = hoTen,
                GioiTinh = gioiTinh,
                VaiTro = vaiTro,
                NgaySinh = ngaySinh,
                SDT = sdt,
                Email = email,
                DiaChi = diaChi
            };

            // Nếu được truyền Connection & Transaction từ Unit of Work:
            if (conn != null)
            {
                int rows = await conn.ExecuteAsync(query, param, trans);
                return rows > 0;
            }

            // Nếu chạy độc lập:
            return (await context.ExecuteAsync(query, param)) > 0;
        }
    }
}