using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.DAO;
using RestaurantAPI.Data;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController(IUnitOfWork uow): ControllerBase
    {
    }
}
