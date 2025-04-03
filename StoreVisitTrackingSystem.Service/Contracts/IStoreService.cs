using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Contracts;

public interface IStoreService
{
    Task<List<Store>> GetAllStoresAsync(CancellationToken cancellationToken = default);
    Task<Store> GetStoreByIdAsync(int storeId, CancellationToken cancellationToken = default);
    Task CreateStoreAsync(StoreRequestDTO storeRequestDTO, CancellationToken cancellationToken = default);
    Task UpdateStoreAsync(int storeId, StoreRequestDTO storeRequestDTO, CancellationToken cancellationToken = default);
    Task DeleteStoreAsync(int storeId, CancellationToken cancellationToken = default);
    Task<bool> IsStoreExistAsync(int storeId, CancellationToken cancellationToken = default);
}
