using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.DAO.Interface
{
    public interface IStaffRepository
    {
        Task<StaffDATA?> GetByIdAsync(int id);
        Task<StaffDATA?> GetByMaNVAsync(string maNV);
        Task<int> InsertAsync(string hoTen, string gioiTinh, string vaiTro,
            DateTimeOffset? ngaySinh, string? sdt, string? diaChi);
    }
}
