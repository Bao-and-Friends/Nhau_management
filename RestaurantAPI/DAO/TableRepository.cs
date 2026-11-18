using Dapper;
using RestaurantAPI.DAO.Interface;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.DAO
{
    public class TableRepository(DbSession session): ITableRepository
    {
        public async Task<IEnumerable<TableDATA>> GetAllTablesAsync()
        {
            string query = @"
        SELECT MaBan, TenBan, SucChua, TrangThai, CheckIn, CheckOut 
        FROM BAN";

            return await session.Connect.QueryAsync<TableDATA>(query, null, session.Transaction);
        }
    }
}
