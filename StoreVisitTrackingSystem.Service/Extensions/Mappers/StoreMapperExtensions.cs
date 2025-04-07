using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Extensions.Mappers;

public static class StoreMapperExtensions
{
    public static Store Map(this StoreRequestDTO storeRequestDTO)
    {
        return new Store
        {
            Name = storeRequestDTO.Name,
            Location = storeRequestDTO.Location,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void Update(this StoreRequestDTO storeRequestDTO, Store targetStore)
    {
        targetStore.Name = storeRequestDTO.Name;
        targetStore.Location = storeRequestDTO.Location;
        targetStore.CreatedAt = DateTime.UtcNow;
    }
}
