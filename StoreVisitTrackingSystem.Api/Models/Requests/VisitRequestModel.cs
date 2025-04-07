namespace StoreVisitTrackingSystem.Api.Models.Requests;

public record VisitRequestModel
(
    int StoreId,
    DateTime VisitDate
);
