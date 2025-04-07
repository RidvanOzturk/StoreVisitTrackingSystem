using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Contracts;

public interface IVisitService
{
    Task CreateVisitAsync(VisitRequestDTO visitRequestDTO, CancellationToken cancellationToken = default);
    Task<PaginationDTO<VisitDTO>> GetAllVisitsAsync(int userId, bool isAdmin, int page, int pageSize, CancellationToken cancellationToken = default);
    Task<Visit?> GetVisitByIdAsync(int visitId, int userId, bool isAdmin, CancellationToken cancellationToken = default);
    Task<bool> AddPhotoToVisitAsync(PhotoRequestDTO photoRequestDTO, int visitId, CancellationToken cancellationToken = default);
    Task<bool> CompleteVisitAsync(int visitId, CancellationToken cancellationToken = default);
}
