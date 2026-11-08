using Dapper;
using RestaurantAPI.Models.SQLData;

namespace RestaurantAPI.Data
{
    public class TableDAO(DapperContext context)
    {
        public async Task<IEnumerable<TableDATA>> GetAllTablesAsync()
        {
            return await context.QueryAsync<TableDATA>("SELECT * FROM BAN");
        }
    }
}
