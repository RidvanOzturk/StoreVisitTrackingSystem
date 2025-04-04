using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data;
using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.Contracts;
using StoreVisitTrackingSystem.Service.DTOs;
using StoreVisitTrackingSystem.Service.Extensions;

namespace StoreVisitTrackingSystem.Service.Implementations;

public class VisitService(TrackingContext trackingContext) : IVisitService
{
    public async Task CreateVisitAsync(VisitRequestDTO visitRequestDTO, CancellationToken cancellationToken = default)
    {
        var visitEntity = visitRequestDTO.Map();
        await trackingContext.Visits.AddAsync(visitEntity, cancellationToken);
        await trackingContext.SaveChangesAsync(cancellationToken);
    }
    public async Task<List<Visit>> GetAllVisitsAsync(int userId, bool isAdmin, CancellationToken cancellationToken = default)
    {
        var query = trackingContext.Visits
        .Include(v => v.Store)
        .Include(v => v.Photos)
        .ThenInclude(p => p.Product)
        .AsNoTracking();

        if (!isAdmin)
        {
            query = query.Where(v => v.UserId == userId);
        }

        return await query.ToListAsync(cancellationToken);
    }

    public async Task AddPhotoToVisitAsync(PhotoRequestDTO photoRequestDTO, int visitId, CancellationToken cancellationToken = default)
    {
        var visit = await trackingContext.Visits
            .FirstOrDefaultAsync(v => v.Id == visitId, cancellationToken);
        if (visit == null || visit.UserId != photoRequestDTO.UserId)
        {
            throw new UnauthorizedAccessException("Visit not found or not yours.");
        }
        var photoEntity = photoRequestDTO.Map(visitId); 
        await trackingContext.Photos.AddAsync(photoEntity, cancellationToken);
        await trackingContext.SaveChangesAsync(cancellationToken);
    }


    public async Task<Visit> GetVisitByIdAsync(int visitId, CancellationToken cancellationToken = default)
    {
        return await trackingContext.Visits
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == visitId, cancellationToken);
    }
    public async Task CompleteVisitAsync(int visitId, CancellationToken cancellationToken = default)
    {
        var visit = await trackingContext.Visits
            .FirstOrDefaultAsync(x => x.Id == visitId, cancellationToken);
        if (visit != null)
        {
            visit.Status = VisitStatus.Completed;
            await trackingContext.SaveChangesAsync(cancellationToken);
        }
    }
}
