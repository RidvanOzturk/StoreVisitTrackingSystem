using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data;
using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.Contracts;
using StoreVisitTrackingSystem.Service.DTOs;
using StoreVisitTrackingSystem.Service.Extensions;

namespace StoreVisitTrackingSystem.Service.Implementations;

public class ProductService(TrackingContext trackingContext) : IProductService
{
    public async Task CreateProductAsync(ProductRequestDTO productRequestDTO, CancellationToken cancellationToken = default)
    {
        var product = productRequestDTO.Map();
        await trackingContext.Products.AddAsync(product, cancellationToken);
        await trackingContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<(List<Product> Products, int TotalCount)> GetAllProductsAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var query = trackingContext.Products.AsNoTracking();

        var totalCount = await query.CountAsync(cancellationToken);

        var products = await query
            .OrderByDescending(p => p.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (products, totalCount);
    }
}
