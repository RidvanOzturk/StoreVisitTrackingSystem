using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreVisitTrackingSystem.Api.Extensions;
using StoreVisitTrackingSystem.Api.Models.Requests;
using StoreVisitTrackingSystem.Service.Contracts;

namespace StoreVisitTrackingSystem.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class VisitsController(IVisitService visitService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateVisit([FromBody] VisitRequestModel visitRequestModel, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        var visit = visitRequestModel.Map(userId);
        await visitService.CreateVisitAsync(visit, cancellationToken);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVisits([FromQuery] int page = 1, [FromQuery] int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var userId = User.GetUserId();
        var isAdmin = User.IsAdmin();
        var (visits, totalCount) = await visitService.GetAllVisitsAsync(userId, isAdmin, page, pageSize, cancellationToken);
        var responseModels = visits.Select(x => x.ToResponseModel()).ToList();
        var pagedResponse = responseModels.ToPagedResponseModel(totalCount, page, pageSize);
        return Ok(pagedResponse);
    }

    [HttpGet("{visitId}")]
    public async Task<IActionResult> GetVisitById([FromRoute] int visitId, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        var isAdmin = User.IsAdmin();
        var visit = await visitService.GetVisitByIdAsync(visitId, userId, isAdmin, cancellationToken);
        if (visit == null)
        {
            return NotFound();
        }
        var responseModel = visit.ToResponseModel();
        return Ok(responseModel);
    }

    [HttpPost("{visitId}/photos")]
    public async Task<IActionResult> UploadVisitPhotos([FromRoute] int visitId, [FromBody] PhotoRequestModel photoRequestModel, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        var photoEntity = photoRequestModel.Map(userId);
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
