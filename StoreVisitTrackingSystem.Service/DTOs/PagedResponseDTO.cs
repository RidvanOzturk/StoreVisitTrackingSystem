namespace StoreVisitTrackingSystem.Service.DTOs;

public record PagedResponseDTO<T>(
int TotalCount,
int Page,
int PageSize,
List<T> Data
);
