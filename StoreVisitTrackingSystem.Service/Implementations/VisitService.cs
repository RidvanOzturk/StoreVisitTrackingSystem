using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data;
using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Data.Entities.Enums;
using StoreVisitTrackingSystem.Service.Contracts;
using StoreVisitTrackingSystem.Service.DTOs;
using StoreVisitTrackingSystem.Service.Extensions.Mappers;

namespace StoreVisitTrackingSystem.Service.Implementations;

public class VisitService(TrackingContext trackingContext) : IVisitService
{
    public async Task CreateVisitAsync(VisitRequestDTO visitRequestDTO, CancellationToken cancellationToken = default)
    {
        var visitEntity = visitRequestDTO.Map();
        trackingContext.Visits.Add(visitEntity);
        await trackingContext.SaveChangesAsync(cancellationToken);
    }
    public async Task<PaginationDTO<VisitDTO>> GetAllVisitsAsync(int userId, bool isAdmin, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var query = trackingContext.Visits
            .Where(v => isAdmin || v.UserId == userId)
            .AsNoTracking()
            .Include(v => v.Photos)
                .ThenInclude(p => p.Product);

        var totalCount = await query.CountAsync(cancellationToken);

        var visitDtos = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(v => new VisitDTO(
                v.Id,
                v.UserId,
                v.StoreId,
                v.VisitDate,
                v.Status.ToString(),
                v.Store == null
                    ? null
                    : new StoreDTO(v.Store.Id, v.Store.Name, v.Store.Location),
                v.Photos.Select(p => new PhotoDTO(
                    p.Id,
                    p.Base64Image,
                    p.UploadedAt,
                    p.Product == null
                        ? null
                        : new ProductDTO(p.Product.Id, p.Product.Name, p.Product.Category)
                )).ToList()
            ))
            .ToListAsync(cancellationToken);

        return new PaginationDTO<VisitDTO>(visitDtos, totalCount);
    }



    public async Task<bool> AddPhotoToVisitAsync(PhotoRequestDTO photoRequestDTO, int visitId, CancellationToken cancellationToken = default)
    {
        var isVisitExists = await trackingContext.Visits
            .AnyAsync(v => v.Id == visitId && v.UserId == photoRequestDTO.UserId, cancellationToken);

        if (!isVisitExists)
        {
            return false;
        }

        var photoEntity = photoRequestDTO.Map(visitId);

        trackingContext.Photos.Add(photoEntity);
        await trackingContext.SaveChangesAsync(cancellationToken);
        return true;
    }


    public async Task<Visit?> GetVisitByIdAsync(int visitId, int userId, bool isAdmin, CancellationToken cancellationToken = default)
    {
        var visit = await trackingContext.Visits
            .Include(v => v.Store)
            .Include(v => v.Photos)
                .ThenInclude(p => p.Product)
            .AsNoTracking()
            .FirstOrDefaultAsync(v => v.Id == visitId, cancellationToken);

        if (visit == null || (!isAdmin && visit.UserId != userId))
        {
            return null;
        }

        return visit;
    }

    public async Task<bool> CompleteVisitAsync(int visitId, CancellationToken cancellationToken = default)
    {
        var visit = await trackingContext.Visits
            .FirstOrDefaultAsync(x => x.Id == visitId, cancellationToken);

        if (visit == null)
        {
            return false;
        }

        visit.Status = VisitStatus.Completed;
        await trackingContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}
