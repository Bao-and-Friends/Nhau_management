using Dapper;
using RestaurantAPI.DAO.Interface;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.DAO.Implement
{
    public class OrderRepository(DbSession _session) : IOrderRepository
    {
        private readonly DbSession session = _session;

        public async Task<IEnumerable<OrderDATA>> GetAllOrdersAsync()
        {
            string query = @"
                SELECT 
                    m.MonID, 
                    m.MaMon, 
                    m.TenMon, 
                    m.DonGia, 
                    m.DonViTinh, 
                    d.TenDanhMuc, 
                    m.MoTa,
                    m.TrangThai
                FROM MONAN m
                JOIN DANHMUCMON d ON m.DanhMucID = d.DanhMucID";
            return await session.Connect.QueryAsync<OrderDATA>(query, transaction: session.Transaction);
        }
    }
}
