namespace StoreVisitTrackingSystem.Service.DTOs;

public record ProductRequestDTO
(
   string Name, 
   string Category,
   DateTime CreatedAt 
);
