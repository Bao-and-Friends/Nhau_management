using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Services;
using RestaurantShared.DTOs;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(AccountService accountService): ControllerBase
    {
        [Authorize(Roles ="Quản Lý")]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterAccountRequest request)
        {
            var (isSuccess, message) = await accountService.RegisterStaffAccountAsync(request);
            return isSuccess 
                ? Ok(new ApiResponse(true, message)) 
                : BadRequest(new ApiResponse(false, message));
        }
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var (isSuccess, message) = await accountService.ChangePasswordAsync(request.Username, request.NewPassword);
            return isSuccess
                ? Ok(new ApiResponse(true, message))
                : BadRequest(new ApiResponse(false, message));
        }
    }
}
