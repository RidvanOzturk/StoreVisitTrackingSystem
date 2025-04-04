using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data;
using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.Contracts;
using StoreVisitTrackingSystem.Service.DTOs;
using StoreVisitTrackingSystem.Service.Extensions;

namespace StoreVisitTrackingSystem.Service.Implementations;

public class StoreService(TrackingContext trackingContext) : IStoreService
{
    public async Task<List<Store>> GetAllStoresAsync(CancellationToken cancellationToken = default)
    {
        return await trackingContext.Stores
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
    public async Task<Store?> GetStoreByIdAsync(int storeId, CancellationToken cancellationToken = default)
    {
        return await trackingContext.Stores
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == storeId, cancellationToken);
    }
    public async Task CreateStoreAsync(StoreRequestDTO storeRequestDTO, CancellationToken cancellationToken = default)
    {
        var storeEntity = storeRequestDTO.Map();
        await trackingContext.Stores.AddAsync(storeEntity, cancellationToken);
        await trackingContext.SaveChangesAsync(cancellationToken);
    }
    public async Task UpdateStoreAsync(int storeId, StoreRequestDTO storeRequestDTO, CancellationToken cancellationToken = default)
    {
        var updateStore = await trackingContext.Stores.FirstOrDefaultAsync(x => x.Id == storeId, cancellationToken);

        storeRequestDTO.Map(updateStore);
        await trackingContext.SaveChangesAsync(cancellationToken);
    }
    public async Task DeleteStoreAsync(int storeId, CancellationToken cancellationToken = default)
    {
        var store = await trackingContext.Stores.FirstOrDefaultAsync(x => x.Id == storeId, cancellationToken);
        trackingContext.Remove(store);
        await trackingContext.SaveChangesAsync(cancellationToken);
    }
    public async Task<bool> IsStoreExistAsync(int storeId, CancellationToken cancellationToken = default)
    {
        return await trackingContext.Stores.AnyAsync(x => x.Id == storeId, cancellationToken);
    }
}
