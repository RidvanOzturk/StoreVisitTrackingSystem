namespace StoreVisitTrackingSystem.Service.DTOs;

public record StoreRequestDTO
(
    string Name,
    string Location,
    DateTime CreatedAt 
);
