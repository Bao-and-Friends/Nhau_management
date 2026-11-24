using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.DAO.Interface
{
    public interface IBillRepository
    {
        Task<IEnumerable<BillDATA>> GetAllBillAsync();

    }
}
