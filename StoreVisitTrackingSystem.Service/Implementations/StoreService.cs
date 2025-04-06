using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data;
using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.Contracts;
using StoreVisitTrackingSystem.Service.DTOs;
using StoreVisitTrackingSystem.Service.Extensions;

namespace StoreVisitTrackingSystem.Service.Implementations;

public class StoreService(TrackingContext trackingContext) : IStoreService
{
    public async Task<(List<Store> Stores, int TotalCount)> GetAllStoresAsync(int page, int pageSize, CancellationToken cancellationToken)
    {
        var query = trackingContext.Stores.AsNoTracking();

        var totalCount = await query.CountAsync(cancellationToken);

        var stores = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (stores, totalCount);
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
        if (updateStore is null)
        {
            throw new Exception("Store not found.");
        }
        storeRequestDTO.Map(updateStore);
        await trackingContext.SaveChangesAsync(cancellationToken);
    }
    public async Task DeleteStoreAsync(int storeId, CancellationToken cancellationToken = default)
    {
        var store = await trackingContext.Stores.FirstOrDefaultAsync(x => x.Id == storeId, cancellationToken);
        if (store is null)
        {
            throw new InvalidOperationException("Store not found.");
        }
        trackingContext.Remove(store);
        await trackingContext.SaveChangesAsync(cancellationToken);
    }
    public async Task<bool> IsStoreExistAsync(int storeId, CancellationToken cancellationToken = default)
    {
        return await trackingContext.Stores.AnyAsync(x => x.Id == storeId, cancellationToken);
    }
}
