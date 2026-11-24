using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.Services.Interface
{
    public interface IStaffService
    {
        Task<IEnumerable<StaffDATA>> GetAllStaffAsync();
       
    }
}
