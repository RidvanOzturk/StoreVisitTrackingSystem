using Microsoft.AspNetCore.Mvc;
using StoreVisitTrackingSystem.Service.Contracts;

namespace StoreVisitTrackingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserService userService) : ControllerBase
    {
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken = default)
        {
            var users = await userService.GetAllUsersAsync(cancellationToken);
            return Ok(users);
        }
    }
}
