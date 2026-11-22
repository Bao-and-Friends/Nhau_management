using RestaurantAPI.DAO;
using RestaurantAPI.DAO.Interface;
using RestaurantAPI.Services.Interface;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.Services
{
    public class TableService(ITableRepository TableRepo):ITableService
    {

        public async Task<IEnumerable<TableDATA>> GetAllTablesAsync()
        {
            return await TableRepo.GetAllTablesAsync();
        }
    }
}
