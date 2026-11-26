using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Common;
using RestaurantAPI.Services.Interface;
using RestaurantShared.DTOs;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(IAccountService accountService): ControllerBase
    {
        //[Authorize(Roles ="Quản lý")]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterAccountRequest request)
        {
            var result = await accountService.RegisterStaffAccountAsync(request);
            return result.Match(
                _ => Ok(new ApiResponse(true, "Tạo nhân viên thành công!")),
                errors => this.Problem(errors)
            );
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var result = await accountService.ChangePasswordAsync(request.Username, request.NewPassword);
            return result.Match(
                _ => Ok(new ApiResponse(true, "Đổi mật khẩu thành công!")),
                errors => this.Problem(errors)
            );
        }
    }
}
