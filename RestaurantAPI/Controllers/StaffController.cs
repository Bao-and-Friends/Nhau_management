using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Services.Interface;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.Controllers
{
    [Authorize(Roles = "Quản lý")]
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController(IStaffService staffService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var staffs = await staffService.GetAllStaffAsync();
            return Ok(staffs);
        }
    }
}
