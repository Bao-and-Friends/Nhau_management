using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.DAO.Interface
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDATA>> GetAllOrdersAsync();
    }
}
