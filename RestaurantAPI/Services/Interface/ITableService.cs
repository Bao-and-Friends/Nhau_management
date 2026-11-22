using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.Services.Interface
{
    public interface ITableService
    {
        Task<IEnumerable<TableDATA>> GetAllTablesAsync();
    }
}
