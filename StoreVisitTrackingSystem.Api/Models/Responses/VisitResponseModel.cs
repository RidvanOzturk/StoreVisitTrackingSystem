namespace StoreVisitTrackingSystem.Api.Models.Responses;

public class VisitResponseModel
{
    public int Id { get; set; }
    public DateTime VisitDate { get; set; }
    public string Status { get; set; }
    public StoreResponseModel Store { get; set; }
    public List<PhotoResponseModel> Photos { get; set; }
}
