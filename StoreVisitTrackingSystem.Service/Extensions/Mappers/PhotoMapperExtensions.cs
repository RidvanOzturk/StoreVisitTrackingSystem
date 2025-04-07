using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Extensions.Mappers;

public static class PhotoMapperExtensions
{
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
}
