using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreVisitTrackingSystem.Api.Extensions;
using StoreVisitTrackingSystem.Api.Models.Requests;
using StoreVisitTrackingSystem.Service.Contracts;

namespace StoreVisitTrackingSystem.Api.Controllers;
//[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductRequestModel productRequestModel, CancellationToken cancellationToken)
    {
        var product = productRequestModel.Map();
        await productService.CreateProductAsync(product, cancellationToken);
        return Ok();
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllProducts([FromQuery] int page = 1, [FromQuery] int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var (products, totalCount) = await productService.GetAllProductsAsync(page, pageSize, cancellationToken);

        var responseModels = products.Select(p => p.ToResponseModel()).ToList();

        var pagedResponse = responseModels.ToPagedResponseModel(totalCount, page, pageSize);

        return Ok(pagedResponse);
    }
}
