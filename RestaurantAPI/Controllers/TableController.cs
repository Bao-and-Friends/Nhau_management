using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Services;
using RestaurantAPI.Services.Interface;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableController(ITableService tableService) : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tables = await tableService.GetAllTablesAsync();
            return Ok(tables);
        }
    }
}
