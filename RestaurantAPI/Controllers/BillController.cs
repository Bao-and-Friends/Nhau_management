using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Services.Implement;
using RestaurantAPI.Services.Interface;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillController(IBillService billService) : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bills = await billService.GetAllBillsAsync();
            return Ok(bills);
        }
    }
}
