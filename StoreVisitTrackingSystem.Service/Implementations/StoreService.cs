using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data;
using StoreVisitTrackingSystem.Service.Contracts;
using StoreVisitTrackingSystem.Service.DTOs;
using StoreVisitTrackingSystem.Service.Extensions.Mappers;

namespace StoreVisitTrackingSystem.Service.Implementations;

public class StoreService(TrackingContext trackingContext) : IStoreService
{
    public async Task<PaginationDTO<StoreDTO>> GetAllStoresAsync(int page, int pageSize, CancellationToken cancellationToken)
    {
        var query = trackingContext.Stores.AsNoTracking();

        var totalCount = await query.CountAsync(cancellationToken);

        var stores = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(x => new StoreDTO(
                x.Id,
                x.Name,
                x.Location
                ))
            .ToListAsync(cancellationToken);

        return new PaginationDTO<StoreDTO>(stores, totalCount);
    }

    public async Task<int> CreateStoreAsync(StoreRequestDTO storeRequestDTO, CancellationToken cancellationToken = default)
    {
        var storeEntity = storeRequestDTO.Map();
        trackingContext.Stores.Add(storeEntity);
        await trackingContext.SaveChangesAsync(cancellationToken);
        return storeEntity.Id;
    }

    public async Task<bool> UpdateStoreAsync(int storeId, StoreRequestDTO storeRequestDTO, CancellationToken cancellationToken = default)
    {
        var updateStore = await trackingContext.Stores.FirstOrDefaultAsync(x => x.Id == storeId, cancellationToken);

        if (updateStore is null)
        {
            return false;
        }

        storeRequestDTO.Update(updateStore);
        await trackingContext.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> DeleteStoreAsync(int storeId, CancellationToken cancellationToken = default)
    {
        var store = await trackingContext.Stores.FirstOrDefaultAsync(x => x.Id == storeId, cancellationToken);

        if (store is null)
        {
            return false;
        }

        trackingContext.Remove(store);
        await trackingContext.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> IsStoreExistAsync(int storeId, CancellationToken cancellationToken = default)
    {
        return await trackingContext.Stores.AnyAsync(x => x.Id == storeId, cancellationToken);
    }
}
