using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Data;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableController(TableDAO tableDao) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tables = await tableDao.GetAllTablesAsync();
            return Ok(tables);
        }
    }
}
