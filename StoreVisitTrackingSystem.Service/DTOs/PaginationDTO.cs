using StoreVisitTrackingSystem.Data.Entities;

namespace StoreVisitTrackingSystem.Service.DTOs;

public record PaginationDTO<T>
(
   List<T> Data,
   int TotalCount
);
