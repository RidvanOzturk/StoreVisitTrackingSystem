namespace StoreVisitTrackingSystem.Service.DTOs;

public record VisitDTO
(
   int Id,
   int UserId,
   int StoreId, 
   DateTime VisitDate,
   string Status,
   StoreDTO? StoreDetail,
   List<PhotoDTO> PhotoDetails
);