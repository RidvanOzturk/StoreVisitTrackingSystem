namespace StoreVisitTrackingSystem.Api.Models.Responses;

public record VisitResponseModel
(
    int Id,
    DateTime VisitDate,
    string? Status,
    StoreResponseModel? Store,
    List<PhotoResponseModel>? Photos
);
