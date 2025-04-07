using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Extensions.Mappers;

public static class ProductMapperExtensions
{
    public static Product Map(this ProductRequestDTO productRequestDTO)
    {
        return new Product
        {
            Name = productRequestDTO.Name,
            Category = productRequestDTO.Category,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static ProductDTO Map(this Product product)
    {
        return new ProductDTO(product.Id,
                              product.Name,
                              product.Category);
    }
}
