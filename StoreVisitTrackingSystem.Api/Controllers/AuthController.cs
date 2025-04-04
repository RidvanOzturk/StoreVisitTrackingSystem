using Microsoft.AspNetCore.Mvc;
using StoreVisitTrackingSystem.Api.Extensions;
using StoreVisitTrackingSystem.Api.Models;
using StoreVisitTrackingSystem.Service.Contracts;

namespace StoreVisitTrackingSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IUserService userService) : ControllerBase
{
    [HttpGet("users")]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        var users = await userService.GetAllUsersAsync(cancellationToken);
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> LoginUser([FromBody] LoginRequestModel loginRequestModel, CancellationToken cancellationToken)
    {
        var userEntity = loginRequestModel.Map();
        var user = await userService.LoginUserAsync(userEntity, cancellationToken);
        if (!user.AuthenticateResult)
        {
            return BadRequest();
        }
        return Ok(user);
    }
}
