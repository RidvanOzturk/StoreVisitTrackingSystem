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
    public async Task<IActionResult> CreateVisit([FromBody] VisitRequestModel visitRequestModel, CancellationToken cancellationToken)
    {
        var visit = visitRequestModel.Map();
        await visitService.CreateVisitAsync(visit, cancellationToken);
        return Ok();
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllVisits(CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        var isAdmin = User.IsAdmin();
        var visits = await visitService.GetAllVisitsAsync(userId, isAdmin, cancellationToken);
        return Ok(visits);
    }

    [Authorize]
    [HttpGet("{visitId}")]
    public async Task<IActionResult> GetVisitById([FromRoute] int visitId, CancellationToken cancellationToken)
    {
        var visit = await visitService.GetVisitByIdAsync(visitId, cancellationToken);
        return Ok(visit);
    }

    [Authorize]
    [HttpPost("{visitId}/photos")]
    public async Task<IActionResult> UploadVisitPhotos([FromRoute] int visitId, [FromBody] PhotoRequestModel photoRequestModel, CancellationToken cancellationToken)
    {
        photoRequestModel.UserId = User.GetUserId();
        var photoEntity = photoRequestModel.Map();

        await visitService.AddPhotoToVisitAsync(photoEntity, visitId, cancellationToken);

        return Ok(new { Message = "Photo uploaded successfully." });
    }

    [HttpPut("{visitId}/complete")]
    public async Task<IActionResult> CompleteVisit([FromRoute] int visitId, CancellationToken cancellationToken)
    {
        await visitService.CompleteVisitAsync(visitId, cancellationToken);
        return Ok();
    }
}
