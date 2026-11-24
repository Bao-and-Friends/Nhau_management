using Dapper;
using RestaurantAPI.DAO.Interface;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.DAO.Implement
{
    public class OrderRepository(DbSession _session) :IOrderRepository
    {
        private readonly DbSession session= _session;
        
       public async Task<IEnumerable<OrderDATA>> GetAllOrdersAsync()
        {
            string query = @"SELECT TenMon,DonGia,DonViTinh,MoTa from MONAN";
            return await session.Connect.QueryAsync<OrderDATA>(query);
        }
    }
}
