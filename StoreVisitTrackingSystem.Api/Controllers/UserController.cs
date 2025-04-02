using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreVisitTrackingSystem.Service.Contracts;

namespace StoreVisitTrackingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        public async Task<IActionResult> GetUsers()
        {
            //var users = await userService.GetUsers();
           // return Ok(users);
           return Ok();
        }
    }
}
