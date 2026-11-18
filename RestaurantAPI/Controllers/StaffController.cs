using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Services.Interface;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController(IStaffService staffService): ControllerBase
    {
    }
}
