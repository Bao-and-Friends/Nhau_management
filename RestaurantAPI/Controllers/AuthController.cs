using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Services;
using RestaurantShared.DTOs;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(AuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var (isSuccess, token, staff, message) = await authService.LoginAsync(request.Username, request.Password);
            if (!isSuccess)
                return Unauthorized(new LoginResponse(false, null, null, message));

            return Ok(new LoginResponse(true, token, staff, "Đăng nhập thành công!"));
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var (isSuccess, message) = await authService.SendForgotPasswordOtpAsync(request.Username);
            return isSuccess 
                ? Ok(new ApiResponse(true, message)) 
                : BadRequest(new ApiResponse(false, message));
        }

        [HttpPost("verify-otp")]
        public IActionResult VerifyOtp([FromBody] VerifyOtpRequest request)
        {
            var (isSuccess, message) = authService.VerifyOtp(request.Username, request.Otp);
            return isSuccess 
                ? Ok(new ApiResponse(true, message)) 
                : BadRequest(new ApiResponse(false, message));
        }

       
    }
}
