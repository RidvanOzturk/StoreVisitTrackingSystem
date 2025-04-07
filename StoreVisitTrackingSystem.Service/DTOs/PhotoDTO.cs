namespace StoreVisitTrackingSystem.Service.DTOs;

public record PhotoDTO
(
   int Id,
   string Base64Image,
   DateTime UploadedAt,
   ProductDTO? ProductDetails
);
