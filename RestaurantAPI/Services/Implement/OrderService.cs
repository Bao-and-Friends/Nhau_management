using RestaurantAPI.DAO.Interface;
using RestaurantAPI.Services.Interface;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.Services.Implement
{
    public class OrderService(IOrderRepository orderRepo) : IOrderService
    {
        public async Task<IEnumerable<OrderDATA>> GetAllOrdersAsync()
        {
            return await orderRepo.GetAllOrdersAsync();
        }
    }
}
