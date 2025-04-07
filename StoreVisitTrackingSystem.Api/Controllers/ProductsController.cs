using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreVisitTrackingSystem.Api.Extensions;
using StoreVisitTrackingSystem.Api.Models.Requests;
using StoreVisitTrackingSystem.Service.Contracts;

namespace StoreVisitTrackingSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductRequestModel productRequestModel, CancellationToken cancellationToken)
    {
        var product = productRequestModel.Map();
        await productService.CreateProductAsync(product, cancellationToken);
        return Ok();
    }
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllProducts([FromQuery] int page = 1, [FromQuery] int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var pagination = await productService.GetAllProductsAsync(page, pageSize, cancellationToken);
        var response = pagination.Map();
        return Ok(response);
    }
}
