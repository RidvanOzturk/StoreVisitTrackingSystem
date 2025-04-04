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

    public async Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        return await trackingContext.Products
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
