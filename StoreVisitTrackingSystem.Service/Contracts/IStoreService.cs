using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Contracts;

public interface IStoreService
{
    Task<PaginationDTO<StoreDTO>> GetAllStoresAsync(int page, int pageSize, CancellationToken cancellationToken);
    Task CreateStoreAsync(StoreRequestDTO storeRequestDTO, CancellationToken cancellationToken = default);
    Task<bool> UpdateStoreAsync(int storeId, StoreRequestDTO storeRequestDTO, CancellationToken cancellationToken = default);
    Task<bool> DeleteStoreAsync(int storeId, CancellationToken cancellationToken = default);
    Task<bool> IsStoreExistAsync(int storeId, CancellationToken cancellationToken = default);
}
