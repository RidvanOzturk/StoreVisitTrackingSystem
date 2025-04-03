using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data;
using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.Contracts;
using StoreVisitTrackingSystem.Service.DTOs;
using StoreVisitTrackingSystem.Service.Extensions;

namespace StoreVisitTrackingSystem.Service.Implementations;

public class VisitService(TrackingContext trackingContext) : IVisitService
{
    public async Task CreateVisitAsync(VisitRequestDTO visitRequestDTO, CancellationToken cancellationToken)
    {
        var visitEntity =  visitRequestDTO.Map();
        await trackingContext.Visits.AddAsync(visitEntity, cancellationToken);
        await trackingContext.SaveChangesAsync(cancellationToken);
    }
    public async Task<List<Visit>> GetAllVisitsAsync(CancellationToken cancellationToken)
    {
        return await trackingContext.Visits
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
    public async Task<Visit> GetVisitByIdAsync(int visitId, CancellationToken cancellationToken)
    {
        return await trackingContext.Visits
            .AsNoTracking()
            .FirstOrDefaultAsync(x=>x.Id == visitId, cancellationToken);
    }
}
