using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data;
using StoreVisitTrackingSystem.Service.Contracts;
using StoreVisitTrackingSystem.Service.DTOs;
using StoreVisitTrackingSystem.Service.Extensions.Mappers;

namespace StoreVisitTrackingSystem.Service.Implementations;

public class ProductService(TrackingContext trackingContext) : IProductService
{
    public async Task<int> CreateProductAsync(ProductRequestDTO productRequestDTO, CancellationToken cancellationToken = default)
    {
        var product = productRequestDTO.Map();
        trackingContext.Products.Add(product);
        await trackingContext.SaveChangesAsync(cancellationToken);
        return product.Id;
    }

    public async Task<PaginationDTO<ProductDTO>> GetAllProductsAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var query = trackingContext.Products.Include(x => x.Photos).AsNoTracking();

        var totalCount = await query.CountAsync(cancellationToken);
        
        var products = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(x => new ProductDTO(
                x.Id,
                x.Name,
                x.Category))
            .ToListAsync(cancellationToken);

        return new PaginationDTO<ProductDTO>(products, totalCount);
    }
}
