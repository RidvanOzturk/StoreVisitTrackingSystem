using StoreVisitTrackingSystem.Api.Models;
using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Api.Extensions;

public static class MapperExtensions
{
    public static LoginRequestDTO Map(this LoginRequestModel loginRequestModel)
    {
        return new LoginRequestDTO
        (
            loginRequestModel.Username,
            loginRequestModel.Role.ToString(),
            loginRequestModel.CreatedAt
        );
    }
    public static StoreRequestDTO Map(this StoreRequestModel storeRequestModel)
    {
        return new StoreRequestDTO
        (
            storeRequestModel.Name,
            storeRequestModel.Location,
            storeRequestModel.CreatedAt
        );
    }
    public static ProductRequestDTO Map(this ProductRequestModel productRequestModel)
    {
        return new ProductRequestDTO
        (
            productRequestModel.Name,
            productRequestModel.Category,
            productRequestModel.CreatedAt
        );
    }
}
