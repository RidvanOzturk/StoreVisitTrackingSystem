using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data;
using StoreVisitTrackingSystem.Service.Contracts;
using StoreVisitTrackingSystem.Service.DTOs;
using StoreVisitTrackingSystem.Service.Extensions.Mappers;

namespace StoreVisitTrackingSystem.Service.Implementations;

public class ProductService(TrackingContext trackingContext) : IProductService
{
    public async Task CreateProductAsync(ProductRequestDTO productRequestDTO, CancellationToken cancellationToken = default)
    {
        var product = productRequestDTO.Map();
        trackingContext.Products.Add(product);
        await trackingContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationDTO<ProductDTO>> GetAllProductsAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var query = trackingContext.Products.AsNoTracking();

        var totalCount = await query.CountAsync(cancellationToken);

        var products = await query
            .OrderByDescending(p => p.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var productDtos = products
            .Select(x => x.Map())
            .ToList();

        return new PaginationDTO<ProductDTO>(productDtos, totalCount);
    }
}
