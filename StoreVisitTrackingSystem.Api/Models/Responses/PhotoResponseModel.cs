using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Api.Models.Responses;

public record PhotoResponseModel
(
    int Id,
    string? Base64Image,
    DateTime UploadedAt,
    ProductDTO? Product
);
