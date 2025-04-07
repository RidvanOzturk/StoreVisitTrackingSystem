using Microsoft.AspNetCore.Mvc;
using StoreVisitTrackingSystem.Api.Extensions;
using StoreVisitTrackingSystem.Api.Models.Requests;
using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.Contracts;

namespace StoreVisitTrackingSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> LoginUser(LoginRequestModel loginRequestModel, CancellationToken cancellationToken)
    {
        var userEntity = loginRequestModel.Map();
        var token = await userService.LoginUserAsync(userEntity, cancellationToken);

        if (token == null)
        {
            return BadRequest();
        }

        return Ok(new { token });
    }
}
