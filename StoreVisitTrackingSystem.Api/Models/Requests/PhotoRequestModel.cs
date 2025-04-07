namespace StoreVisitTrackingSystem.Api.Models.Requests;

public record PhotoRequestModel
(
    int ProductId,
    string Base64Image
);
