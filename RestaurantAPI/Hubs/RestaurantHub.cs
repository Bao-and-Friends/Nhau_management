using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace RestaurantAPI.Hubs
{
    [Authorize]
    public class RestaurantHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            // Lấy tất cả Roles từ JWT Claims của user đang kết nối
            var roles = Context.User?.FindAll(ClaimTypes.Role).Select(c => c.Value);

            if (roles != null)
            {
                foreach (var role in roles)
                {
                    if (!string.IsNullOrWhiteSpace(role))
                    {
                        // Thêm client vào Group tương ứng với từng Role (ví dụ: "Quản lý", "Nhân viên", ...)
                        await Groups.AddToGroupAsync(Context.ConnectionId, role);
                    }
                }
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            // SignalR tự động dọn dẹp Groups khi connection ngắt kết nối
            await base.OnDisconnectedAsync(exception);
        }
    }
}
