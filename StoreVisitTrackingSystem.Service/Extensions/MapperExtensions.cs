using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.DTOs;
using StoreVisitTrackingSystem.Data.Entities.Enums;

namespace StoreVisitTrackingSystem.Service.Extensions;

public static class MapperExtensions
{
    public static Visit Map(this VisitRequestDTO visitRequestDTO)
    {
        return new Visit
        {
            UserId = visitRequestDTO.UserId,
            StoreId = visitRequestDTO.StoreId,
            VisitDate = visitRequestDTO.VisitDate,
            Status = visitRequestDTO.VisitStatus
        };
    }

    public static Photo Map(this PhotoRequestDTO photoRequestDTO, int visitId)
    {
        return new Photo
        {
            ProductId = photoRequestDTO.ProductId,
            Base64Image = photoRequestDTO.Base64Image,
            UploadedAt = DateTime.UtcNow,
            VisitId = visitId
        };
    }


    public static Store Map(this StoreRequestDTO storeRequestDTO)
    {
        return new Store
        {
            Name = storeRequestDTO.Name,
            Location = storeRequestDTO.Location,
            CreatedAt = storeRequestDTO.CreatedAt,
        };
    }

    public static void Map(this StoreRequestDTO storeRequestDTO, Store targetStore)
    {
        targetStore.Name = storeRequestDTO.Name;
        targetStore.Location = storeRequestDTO.Location;
        targetStore.CreatedAt = storeRequestDTO.CreatedAt;
    }
    public static Product Map(this ProductRequestDTO productRequestDTO)
    {
        return new Product
        {
            Name = productRequestDTO.Name,
            Category = productRequestDTO.Category,
            CreatedAt = productRequestDTO.CreatedAt,
        };
    }
 
}
