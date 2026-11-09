using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.DAO
{
    public class TableDAO(DapperContext context)
    {
        public async Task<IEnumerable<TableDATA>> GetAllTablesAsync()
        {
            return await context.QueryAsync<TableDATA>("SELECT * FROM BAN");
        }
    }
}
