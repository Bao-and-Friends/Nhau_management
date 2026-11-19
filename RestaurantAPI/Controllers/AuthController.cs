using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Common;
using RestaurantAPI.Services.Interface;
using RestaurantShared.DTOs;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await authService.LoginAsync(request.Username, request.Password);
            return result.Match(
                loginResponse => Ok(loginResponse),
                errors => this.Problem(errors)
            );
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var result = await authService.SendForgotPasswordOtpAsync(request.Username);
            return result.Match(
                _ => Ok(new ApiResponse(true, "Mã OTP đã được gửi về email của bạn.")),
                errors => this.Problem(errors)
            );
        }

        [HttpPost("verify-otp")]
        public IActionResult VerifyOtp([FromBody] VerifyOtpRequest request)
        {
            var result = authService.VerifyOtp(request.Username, request.Otp);
            return result.Match(
                _ => Ok(new ApiResponse(true, "Xác thực OTP thành công!")),
                errors => this.Problem(errors)
            );
        }
    }
}
