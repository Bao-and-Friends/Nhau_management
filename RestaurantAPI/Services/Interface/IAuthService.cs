using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.Services.Interface
{
    public interface IAuthService
    {
        Task<(bool IsSuccess, string? Token, StaffDATA? Staff, string Message)> LoginAsync(string username, string password);
        Task<(bool IsSuccess, string Message)> SendForgotPasswordOtpAsync(string username);
        (bool IsSuccess, string Message) VerifyOtp(string username, string otp);
    }
}
