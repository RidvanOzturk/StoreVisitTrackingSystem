using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreVisitTrackingSystem.Api.Extensions;
using StoreVisitTrackingSystem.Api.Models.Requests;
using StoreVisitTrackingSystem.Service.Contracts;
using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class VisitsController(IVisitService visitService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllVisits([FromQuery] int page = 1, [FromQuery] int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var userId = User.GetUserId();
        var isAdmin = User.IsAdmin();

        var pagination = await visitService.GetAllVisitsAsync(userId, isAdmin, page, pageSize, cancellationToken);
        var response = pagination.Map();
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVisit(VisitRequestModel visitRequestModel, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();

        var visit = visitRequestModel.Map(userId);
        var visitId = await visitService.CreateVisitAsync(visit, cancellationToken);
        return Ok(new { visitId });
    }

    [HttpGet("{visitId}")]
    public async Task<IActionResult> GetVisitById(int visitId, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        var isAdmin = User.IsAdmin();

        var visit = await visitService.GetVisitByIdAsync(visitId, userId, isAdmin, cancellationToken);

        if (visit == null)
        {
            return NotFound();
        }

        var responseModel = visit.Map();
        return Ok(responseModel);
    }

    [HttpPost("{visitId}/photos")]
    public async Task<IActionResult> UploadVisitPhotos(int visitId, PhotoRequestModel photoRequestModel, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();

        var photoEntity = photoRequestModel.Map(userId);
        var isFound = await visitService.AddPhotoToVisitAsync(photoEntity, visitId, cancellationToken);

        if (!isFound)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpPut("{visitId}/complete")]
    public async Task<IActionResult> CompleteVisit(int visitId, CancellationToken cancellationToken)
    {
        await visitService.CompleteVisitAsync(visitId, cancellationToken);
        return Ok();
    }
}
