using StoreVisitTrackingSystem.Api.Models.Requests;
using StoreVisitTrackingSystem.Api.Models.Responses;
using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Api.Extensions;

public static class MapperExtensions
{
    public static LoginRequestDTO Map(this LoginRequestModel loginRequestModel)
    {
        return new LoginRequestDTO
        (
            loginRequestModel.Username
        );
    }

    public static VisitRequestDTO Map(this VisitRequestModel visitRequestModel, int userId)
    {
        return new VisitRequestDTO
        (
            userId,
            visitRequestModel.StoreId,
            visitRequestModel.VisitDate
        );
    }

    public static PhotoRequestDTO Map(this PhotoRequestModel photoRequestModel, int userId)
    {
        return new PhotoRequestDTO
        (
            photoRequestModel.ProductId,
            photoRequestModel.Base64Image,
            userId
        );
    }

    public static StoreRequestDTO Map(this StoreRequestModel storeRequestModel)
    {
        return new StoreRequestDTO
        (
            storeRequestModel.Name,
            storeRequestModel.Location
        );
    }

    public static ProductRequestDTO Map(this ProductRequestModel productRequestModel)
    {
        return new ProductRequestDTO
        (
            productRequestModel.Name,
            productRequestModel.Category
        );
    }

    public static VisitResponseModel Map(this Visit visit)
    {
        return new VisitResponseModel
        (
            visit.Id,
            visit.VisitDate,
            visit.Status.ToString(),
            visit.Store?.Map(),
            visit.Photos?.Select(p => p.Map()).ToList() ?? []
        );
    }

    public static StoreResponseModel Map(this Store store)
    {
        return new StoreResponseModel
        (
            store.Id,
            store.Name,
            store.Location
        );
    }

    public static PhotoResponseModel Map(this Photo photo)
    {
        return new PhotoResponseModel
        (
            photo.Id,
            photo.Base64Image,
            photo.UploadedAt,
            null
        ); // TODO
    }

    public static PagedResponseModel<T> Map<T>(this PaginationDTO<T> pagination)
    {
        return new PagedResponseModel<T>
        (
            pagination.Data,
            pagination.TotalCount
        );
    }
}
