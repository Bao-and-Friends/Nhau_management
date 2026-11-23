using Microsoft.AspNetCore.SignalR;
using RestaurantAPI.Hubs;
using RestaurantAPI.Services.Interface.IHubs;
using RestaurantShared.DTOs;

namespace RestaurantAPI.Services.Hubs
{
    public class AccountNotifier(IHubContext<RestaurantHub> hubContext, ILogger<AccountNotifier> logger) : IAccountNotifier
    {
        public async Task NotifyAccountCreatedAsync(NewAccountNotification newAccount)
        {
            try
            {
                // Gửi thông báo tới các client thuộc group "Quản lý"
                await hubContext.Clients.Group("Quản lý").SendAsync("NewAccCreated", newAccount);
            }
            catch (Exception ex)
            {
                // Log lỗi nếu SignalR gặp sự cố, không để lỗi này làm sập nghiệp vụ chính
                logger.LogError(ex, "Lỗi khi gửi thông báo SignalR tài khoản mới cho nhân viên {MaNV}", newAccount.MaNV);
            }
        }
    }
}
