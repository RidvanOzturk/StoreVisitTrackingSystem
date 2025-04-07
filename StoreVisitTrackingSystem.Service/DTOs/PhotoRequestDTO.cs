namespace StoreVisitTrackingSystem.Service.DTOs;

public record PhotoRequestDTO
(
    int ProductId,
    string Base64Image,
    int UserId
);
