using Dapper;
using RestaurantAPI.DAO.Interface;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.DAO.Implement
{
    public class Billrepository(DbSession session):IBillRepository
    {
       public async Task<IEnumerable<BillDATA>> GetAllBillAsync()
        {
            string query = @"";//bổ sung query sau
            return await session.Connect.QueryAsync<BillDATA>(query);
        }

    }
}
