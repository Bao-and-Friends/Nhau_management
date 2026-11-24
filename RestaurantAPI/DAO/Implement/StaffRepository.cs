using Dapper;
using RestaurantAPI.DAO.Interface;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.DAO.Implement
{
    public class StaffRepository(DbSession session): IStaffRepository
    {
        public async Task<IEnumerable<StaffDATA>> GetAllStaffAsync()
        {
            string query = @"
                SELECT
                    NV.MaNV, 
                    NV.HoTen, 
                    NV.SoDienThoai, 
                    TK.Email
                FROM NHANVIEN NV
                LEFT JOIN TAIKHOAN TK ON TK.NVId = NV.Id";
            return await session.Connect.QueryAsync<StaffDATA>(query);
        }

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

        private record InsertStaffResult(int Id, string MaNV);

        public async Task<(int Id, string MaNV)> InsertAsync(string hoTen, string gioiTinh, string vaiTro,
            DateTimeOffset? ngaySinh, string? sdt, string? diaChi)
        {
            string query = @"
        DECLARE @NewMaNV VARCHAR(20) = 'NV' + FORMAT(NEXT VALUE FOR seq_MaNV, '0000');

        INSERT INTO NHANVIEN (MaNV, HoTen, GioiTinh, VaiTro, NgaySinh, SoDienThoai, DiaChi)
        OUTPUT INSERTED.Id, INSERTED.MaNV
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

            var result = await session.Connect.QuerySingleAsync<InsertStaffResult>(query, param, session.Transaction);
            return (result.Id, result.MaNV);
        }
    }
}
