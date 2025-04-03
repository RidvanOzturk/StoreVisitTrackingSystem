using Microsoft.AspNetCore.Mvc;
using StoreVisitTrackingSystem.Service.Contracts;

namespace StoreVisitTrackingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserService userService) : ControllerBase
    {
        [HttpGet("login")]
        public async Task<IActionResult> GetUsers()
        {
            //var users = await userService.GetUsers();
           // return Ok(users);
           return Ok();
        }
    }
}
