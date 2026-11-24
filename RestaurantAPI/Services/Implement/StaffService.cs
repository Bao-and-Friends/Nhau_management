using RestaurantAPI.DAO.Interface;
using RestaurantAPI.Services.Interface;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.Services.Implement
{
    public class StaffService(IStaffRepository staffRepo) : IStaffService
    {
        public async Task<IEnumerable<StaffDATA>> GetAllStaffAsync()
        {
            return await staffRepo.GetAllStaffAsync();
        }
    }
}
