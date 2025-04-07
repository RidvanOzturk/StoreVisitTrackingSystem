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
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllStores([FromQuery] int page = 1, [FromQuery] int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var pagination = await storeService.GetAllStoresAsync(page, pageSize, cancellationToken);
        var response = pagination.Map();
        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateStore(StoreRequestModel storeRequestModel, CancellationToken cancellationToken)
    {
        var store = storeRequestModel.Map();
        var storeId = await storeService.CreateStoreAsync(store, cancellationToken);
        return Ok(new { storeId });
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{storeId}")]
    public async Task<IActionResult> UpdateStore(int storeId, StoreRequestModel storeRequestModel, CancellationToken cancellationToken)
    {
        var isStoreExist = await storeService.IsStoreExistAsync(storeId, cancellationToken);

        if (!isStoreExist)
        {
            return NotFound();
        }

        var store = storeRequestModel.Map();
        var isFound = await storeService.UpdateStoreAsync(storeId, store, cancellationToken);

        if (!isFound)
        {
            return NotFound();
        }

        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{storeId}")]
    public async Task<IActionResult> DeleteStore(int storeId, CancellationToken cancellationToken)
    {
        var isStoreExist = await storeService.IsStoreExistAsync(storeId, cancellationToken);

        if (!isStoreExist)
        {
            return NotFound();
        }

        var isFound = await storeService.DeleteStoreAsync(storeId, cancellationToken);

        if (!isFound)
        {
            return NotFound();
        }

        return Ok();
    }

}
