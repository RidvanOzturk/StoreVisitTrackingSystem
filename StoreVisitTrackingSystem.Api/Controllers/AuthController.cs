using Microsoft.AspNetCore.Mvc;
using StoreVisitTrackingSystem.Api.Extensions;
using StoreVisitTrackingSystem.Api.Models.Requests;
using StoreVisitTrackingSystem.Service.Contracts;

namespace StoreVisitTrackingSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> LoginUser([FromBody] LoginRequestModel loginRequestModel, CancellationToken cancellationToken)
    {
        var userEntity = loginRequestModel.Map();
        var user = await userService.LoginUserAsync(userEntity, cancellationToken);
        return Ok(user);
    }
}
