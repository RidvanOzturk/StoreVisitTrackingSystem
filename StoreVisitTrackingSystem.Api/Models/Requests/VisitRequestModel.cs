using StoreVisitTrackingSystem.Data.Entities.Enums;

namespace StoreVisitTrackingSystem.Api.Models.Requests;

public class VisitRequestModel
{
    public int StoreId { get; set; }
    public DateTime VisitDate { get; set; }
    public VisitStatus VisitStatus { get; set; }
}
