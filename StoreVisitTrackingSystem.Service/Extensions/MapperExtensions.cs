using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Extensions;

public static class MapperExtensions
{
    public static User Map(this LoginRequestDTO loginRequestDTO)
    {
        return new User
        {
            Username = loginRequestDTO.Username,
            Role = UserRole.Standard,
            CreatedAt = DateTime.UtcNow,
        };
    }

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
