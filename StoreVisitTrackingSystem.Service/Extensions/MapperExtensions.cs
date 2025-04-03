using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Extensions;

public static class MapperExtensions
{
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
}
