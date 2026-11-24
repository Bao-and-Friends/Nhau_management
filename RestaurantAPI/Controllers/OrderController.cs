using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Services.Implement;
using RestaurantAPI.Services.Interface;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [Authorize(Roles ="Quản lý,Phục vụ")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await orderService.GetAllOrdersAsync();
            return Ok(orders);
        }
    }
}
