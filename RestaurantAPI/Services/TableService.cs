using RestaurantAPI.DAO;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.Services
{
    public class TableService(TableDAO tableDAO)
    {

        public async Task<IEnumerable<TableDATA>> GetAllTablesAsync()
        {
            return await tableDAO.GetAllTablesAsync();
        }
    }
}
