namespace StoreVisitTrackingSystem.Service.DTOs;

public record LoginRequestDTO
(
     string Username,
     string Role,
     DateTime CreatedAt
);
