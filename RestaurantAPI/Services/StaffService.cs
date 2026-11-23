using RestaurantAPI.DAO.Interface;
using RestaurantAPI.Services.Interface;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.Services
{
    public class StaffService(IStaffRepository StaffRepo) : IStaffService
    {
        public async Task<IEnumerable<StaffDATA>> GetListStaff()
        {
            return await StaffRepo.GetListNVAsync();
        }

    }
}
