using Microsoft.AspNetCore.Mvc;
using StoreVisitTrackingSystem.Api.Extensions;
using StoreVisitTrackingSystem.Api.Models;
using StoreVisitTrackingSystem.Service.Contracts;

namespace StoreVisitTrackingSystem.Api.Controllers;

//[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class StoreController(IStoreService storeService) : ControllerBase
{
    //ADMIN ONLY WILL BE CHECKED

    [HttpGet("all")] 
    public async Task<IActionResult> GetAllStores(CancellationToken cancellationToken)
    {
        var stores = await storeService.GetAllStoresAsync(cancellationToken);
        return Ok(stores);
    }

    [HttpGet("{storeId}")]
    public async Task<IActionResult> GetStoreById([FromRoute] int storeId, CancellationToken cancellationToken)
    {
        var store = await storeService.GetStoreByIdAsync(storeId, cancellationToken);
        return Ok(store);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateStore([FromBody] StoreRequestModel storeRequestModel, CancellationToken cancellationToken)
    {
        var store = storeRequestModel.Map();
        await storeService.CreateStoreAsync(store, cancellationToken);
        return Ok();
    }

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
