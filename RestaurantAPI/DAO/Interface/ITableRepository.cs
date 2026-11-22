using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.DAO.Interface
{
    public interface ITableRepository
    {
        Task<IEnumerable<TableDATA>> GetAllTablesAsync();
    }
}
