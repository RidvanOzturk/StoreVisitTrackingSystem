using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Data.Entities.Enums;
using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Extensions.Mappers;

public static class VisitMapperExtensions
{
    public static Visit Map(this VisitRequestDTO visitRequestDTO)
    {
        return new Visit
        {
            UserId = visitRequestDTO.UserId,
            StoreId = visitRequestDTO.StoreId,
            VisitDate = visitRequestDTO.VisitDate,
            Status = VisitStatus.InProgress
        };
    }

    public static VisitDTO Map(this Visit visit)
    {
        return new VisitDTO(visit.Id,
                            visit.UserId,
                            visit.StoreId,
                            visit.VisitDate,
                            visit.Status.ToString());
    }
}
