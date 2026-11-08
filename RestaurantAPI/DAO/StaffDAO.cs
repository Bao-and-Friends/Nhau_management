using Microsoft.Data.SqlClient;
using RestaurantAPI.Models.SQLData;

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
        public async Task<bool> InsertAsync(string maNV, string hoTen, string gioiTinh, string vaiTro,
                                           DateTimeOffset? ngaySinh, string? sdt, string? email, string? diaChi)
        {
            string query = @"INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh, VaiTro, NgaySinh, SoDienThoai, Email, DiaChi)
                             VALUES (@MaNV, @HoTen, @GioiTinh, @VaiTro, @NgaySinh, @SDT, @Email, @DiaChi)";
            int rows = await context.ExecuteAsync(query, new
            {
                MaNV = maNV,
                HoTen = hoTen,
                GioiTinh = gioiTinh,
                VaiTro = vaiTro,
                NgaySinh = ngaySinh,
                SDT = sdt,
                Email = email,
                DiaChi = diaChi
            });
            return rows > 0;
        }

    }
}
