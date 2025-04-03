using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreVisitTrackingSystem.Api.Extensions;
using StoreVisitTrackingSystem.Api.Models;
using StoreVisitTrackingSystem.Service.Contracts;

namespace StoreVisitTrackingSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VisitController(IVisitService visitService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateVisit([FromBody] VisitRequestModel visitRequestModel, CancellationToken cancellationToken = default)
    {
        var visit = visitRequestModel.Map();
        await visitService.CreateVisitAsync(visit, cancellationToken);
        return Ok();
    }

    //[Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllVisits(CancellationToken cancellationToken = default)
    {
        var visits = await visitService.GetAllVisitsAsync(cancellationToken);
        return Ok(visits);
    }

    //[Authorize]
    [HttpGet("{visitId}")]
    public async Task<IActionResult> GetVisitById([FromRoute] int visitId, CancellationToken cancellationToken = default)
    {
        var visit = await visitService.GetVisitByIdAsync(visitId, cancellationToken);
        return Ok(visit);
    }

}
