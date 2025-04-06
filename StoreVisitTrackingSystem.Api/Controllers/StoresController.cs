using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreVisitTrackingSystem.Api.Extensions;
using StoreVisitTrackingSystem.Api.Models.Requests;
using StoreVisitTrackingSystem.Service.Contracts;

namespace StoreVisitTrackingSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StoresController(IStoreService storeService) : ControllerBase
{
    //ADMIN ONLY WILL BE CHECKED
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllStores([FromQuery] int page = 1, [FromQuery] int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var (stores, totalCount) = await storeService.GetAllStoresAsync(page, pageSize, cancellationToken);

        var response = new
        {
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize,
            Data = stores
        };

        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateStore([FromBody] StoreRequestModel storeRequestModel, CancellationToken cancellationToken)
    {
        var store = storeRequestModel.Map();
        await storeService.CreateStoreAsync(store, cancellationToken);
        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{storeId}")]
    public async Task <IActionResult> UpdateStore([FromRoute] int storeId, StoreRequestModel storeRequestModel, CancellationToken cancellationToken)
    {
        var isStoreExist = await storeService.IsStoreExistAsync(storeId, cancellationToken);
        if (!isStoreExist)
        {
            return NotFound();
        }
        var store = storeRequestModel.Map();
        await storeService.UpdateStoreAsync(storeId, store, cancellationToken);
        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{storeId}")]
    public async Task<IActionResult> DeleteStore([FromRoute] int storeId, CancellationToken cancellationToken)
    {
        var isStoreExist = await storeService.IsStoreExistAsync(storeId, cancellationToken);
        if (!isStoreExist)
        {
            return NotFound();
        }
        await storeService.DeleteStoreAsync(storeId, cancellationToken);
        return Ok();
    }

}
