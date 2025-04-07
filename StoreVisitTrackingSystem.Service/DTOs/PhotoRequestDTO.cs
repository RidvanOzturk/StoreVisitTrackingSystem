namespace StoreVisitTrackingSystem.Service.DTOs;

public record PhotoRequestDTO
(
    int UserId,
    int ProductId,
    string Base64Image
);
