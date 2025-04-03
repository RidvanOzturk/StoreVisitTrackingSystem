using StoreVisitTrackingSystem.Data.Entities;

namespace StoreVisitTrackingSystem.Service.DTOs;

public record VisitRequestDTO
(
    int UserId, 
    int StoreId,
    DateTime VisitDate,
    VisitStatus VisitStatus
);
