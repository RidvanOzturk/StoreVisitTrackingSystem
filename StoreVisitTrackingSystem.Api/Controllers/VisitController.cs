using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreVisitTrackingSystem.Api.Models;
using StoreVisitTrackingSystem.Service.Contracts;

namespace StoreVisitTrackingSystem.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class VisitController(IVisitService visitService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateVisit([FromBody] VisitRequestModel visitRequestModel, CancellationToken cancellationToken = default)
    {
        //var visitDTO = visitRequestModel.Map();
        //var result = await visitService.CreateVisitAsync(visitDTO);
        return Ok();
    }
}
