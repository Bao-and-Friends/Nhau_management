using ErrorOr;
using RestaurantShared.DTOs;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.Services.Interface
{
    public interface IAuthService
    {
        Task<ErrorOr<LoginResponse>> LoginAsync(string username, string password);
        Task<ErrorOr<Success>> SendForgotPasswordOtpAsync(string username);
        ErrorOr<Success> VerifyOtp(string username, string otp);
    }
}
