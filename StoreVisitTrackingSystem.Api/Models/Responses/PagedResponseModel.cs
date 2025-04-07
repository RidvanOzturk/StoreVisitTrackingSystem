namespace StoreVisitTrackingSystem.Api.Models.Responses;

public record PagedResponseModel<T>
(
    List<T> Data,
    int TotalCount
);
