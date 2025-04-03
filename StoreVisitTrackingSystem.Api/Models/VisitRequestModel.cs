using StoreVisitTrackingSystem.Data.Entities;

namespace StoreVisitTrackingSystem.Api.Models;

public class VisitRequestModel
{
    public int UserId { get; set; }
    public int StoreId { get; set; }
    public DateTime VisitDate { get; set; }
    public VisitStatus VisitStatus { get; set; }
}
