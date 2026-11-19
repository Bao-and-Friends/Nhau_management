using ErrorOr;
using RestaurantShared.DTOs;

namespace RestaurantAPI.Services.Interface
{
    public interface IAccountService
    {
        Task<ErrorOr<Success>> RegisterStaffAccountAsync(RegisterAccountRequest request);
        Task<ErrorOr<Success>> ChangePasswordAsync(string username, string newPassword);
    }
}
