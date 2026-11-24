using RestaurantAPI.DAO.Interface;
using RestaurantAPI.Services.Interface;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.Services.Implement
{
    public class BillService(IBillRepository BillRepo):IBillService
    {
        public async  Task<IEnumerable<BillDATA>> GetAllBillsAsync()
        {
            return await BillRepo.GetAllBillAsync();
        }

    }
}
