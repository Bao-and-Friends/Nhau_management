using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.Services.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDATA>> GetAllOrdersAsync();
    }
}
