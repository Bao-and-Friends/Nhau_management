using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.Services.Interface
{
    public interface IBillService
    {
        Task<IEnumerable<BillDATA>> GetAllBillsAsync();
    }
}
