using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Contracts;

public interface IVisitService
{
    Task CreateVisitAsync(VisitRequestDTO visitRequestDTO, CancellationToken cancellationToken = default);
    Task<List<Visit>> GetAllVisitsAsync(int userId, bool isAdmin, CancellationToken cancellationToken = default);
    Task<Visit> GetVisitByIdAsync(int visitId, CancellationToken cancellationToken = default);

    Task CompleteVisitAsync(int visitId, CancellationToken cancellationToken = default);
}
