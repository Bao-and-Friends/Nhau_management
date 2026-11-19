using Dapper;
using RestaurantAPI.DAO.Interface;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.DAO
{
    public class StaffRepository(DbSession session): IStaffRepository
    {
        public async Task<StaffDATA?> GetByIdAsync(int id)
        {
            string query = @"
        SELECT MaNV, HoTen, GioiTinh, VaiTro, NgaySinh, SoDienThoai, DiaChi 
        FROM NHANVIEN 
        WHERE Id = @Id";
            return await session.Connect.QueryFirstOrDefaultAsync<StaffDATA>(query, new { Id = id }, session.Transaction);
        }

        public async Task<StaffDATA?> GetByMaNVAsync(string maNV)
        {
            string query = @"
        SELECT MaNV, HoTen, GioiTinh, VaiTro, NgaySinh, SoDienThoai, DiaChi 
        FROM NHANVIEN 
        WHERE MaNV = @MaNV";
            return await session.Connect.QueryFirstOrDefaultAsync<StaffDATA>(query, new { MaNV = maNV.Trim() }, session.Transaction);
        }

        public async Task<int> InsertAsync(string hoTen, string gioiTinh, string vaiTro,
            DateTimeOffset? ngaySinh, string? sdt, string? diaChi)
        {
            string query = @"
        DECLARE @NewMaNV VARCHAR(20) = 'NV' + FORMAT(NEXT VALUE FOR seq_MaNV, '0000');

        INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh, VaiTro, NgaySinh, SoDienThoai, DiaChi)
        OUTPUT INSERTED.Id
        VALUES (@NewMaNV, @HoTen, @GioiTinh, @VaiTro, @NgaySinh, @SoDienThoai, @DiaChi);";

            var param = new
            {
                HoTen = hoTen.Trim(),
                GioiTinh = gioiTinh?.Trim(),
                VaiTro = vaiTro?.Trim(),
                NgaySinh = ngaySinh?.DateTime, 
                SoDienThoai = sdt?.Trim(),
                DiaChi = diaChi?.Trim()
            };

            return await session.Connect.ExecuteScalarAsync<int>(query, param, session.Transaction);
        }
    }
}
