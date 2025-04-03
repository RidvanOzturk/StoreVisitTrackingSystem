using StoreVisitTrackingSystem.Api.Models;
using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Api.Extensions;

public static class MapperExtensions
{
    public static StoreRequestDTO Map(this StoreRequestModel model)
    {
        return new StoreRequestDTO
        {
            Name = model.Name,
            Location = model.Location,
            CreatedAt = model.CreatedAt
        };
    }
}
