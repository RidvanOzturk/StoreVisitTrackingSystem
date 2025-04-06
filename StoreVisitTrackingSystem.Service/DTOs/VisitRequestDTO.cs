using StoreVisitTrackingSystem.Data.Entities.Enums;

namespace StoreVisitTrackingSystem.Service.DTOs;

public record VisitRequestDTO
(
    int UserId, 
    int StoreId,
    DateTime VisitDate
);
