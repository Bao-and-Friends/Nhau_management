using RestaurantShared.DTOs;

namespace RestaurantAPI.Services.Interface
{
    public interface IAccountService
    {
        Task<(bool IsSuccess, string Message)> RegisterStaffAccountAsync(RegisterAccountRequest request);
        Task<(bool IsSuccess, string Message)> ChangePasswordAsync(string username, string newPassword);
    }
}
