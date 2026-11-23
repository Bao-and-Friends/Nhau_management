using RestaurantShared.DTOs;

namespace RestaurantAPI.Services.Interface.IHubs
{
    public interface IAccountNotifier
    {
        Task NotifyAccountCreatedAsync(NewAccountNotification newAccount);
    }
}
