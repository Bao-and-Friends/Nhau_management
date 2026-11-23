using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Services;
using RestaurantAPI.Services.Interface;

namespace RestaurantAPI.Controllers
{
    [Authorize(Roles ="Quản lý")]
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController(IStaffService staffService): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Staffs = await staffService.GetListStaff();
            return Ok(Staffs);
        }
    }
}
