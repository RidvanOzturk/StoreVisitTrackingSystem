using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Contracts;

public interface IProductService
{
    Task CreateProductAsync(ProductRequestDTO productRequestDTO, CancellationToken cancellationToken = default);
    Task<(List<Product> Products, int TotalCount)> GetAllProductsAsync(int page, int pageSize, CancellationToken cancellationToken = default);
}
