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
            loginRequestModel.Username,
            loginRequestModel.CreatedAt
        );
    }

    public static VisitRequestDTO Map(this VisitRequestModel visitRequestModel, int userId)
    {
        return new VisitRequestDTO
        (
            userId,
            visitRequestModel.StoreId,
            visitRequestModel.VisitDate,
            visitRequestModel.VisitStatus
        );
    }

    public static PhotoRequestDTO Map(this PhotoRequestModel photoRequestModel)
    {
        return new PhotoRequestDTO
        (
            photoRequestModel.ProductId,
            photoRequestModel.Base64Image,
            photoRequestModel.UserId
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

    public static VisitResponseModel ToResponseModel(this Visit visit)
    {
        return new VisitResponseModel
        {
            Id = visit.Id,
            VisitDate = visit.VisitDate,
            Status = visit.Status.ToString(),
            Store = visit.Store?.ToResponseModel(),
            Photos = visit.Photos?.Select(p => p.ToResponseModel()).ToList() ?? []
        };
    }

    public static StoreResponseModel ToResponseModel(this Store store)
    {
        return new StoreResponseModel
        {
            Id = store.Id,
            Name = store.Name,
            Location = store.Location
        };
    }

    public static PhotoResponseModel ToResponseModel(this Photo photo)
    {
        return new PhotoResponseModel
        {
            Id = photo.Id,
            Base64Image = photo.Base64Image,
            UploadedAt = photo.UploadedAt,
            Product = photo.Product?.ToResponseModel()
        };
    }

    public static ProductResponseModel ToResponseModel(this Product product)
    {
        return new ProductResponseModel
        {
            Id = product.Id,
            Name = product.Name,
            Category = product.Category,
            CreatedAt = product.CreatedAt,
        };
    }

    public static PagedResponseModel<T> ToPagedResponseModel<T>(this List<T> data, int totalCount, int page, int pageSize)
    {
        return new PagedResponseModel<T>
        {
            Data = data,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };
    }
}
