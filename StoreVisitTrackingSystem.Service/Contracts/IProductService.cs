using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.DTOs;
using System.Threading.Tasks;

namespace StoreVisitTrackingSystem.Service.Contracts;

public interface IProductService
{
    Task CreateProductAsync(ProductRequestDTO productRequestDTO, CancellationToken cancellationToken = default);
    Task<(List<Product> Products, int TotalCount)> GetAllProductsAsync(int page, int pageSize, CancellationToken cancellationToken = default);
}
