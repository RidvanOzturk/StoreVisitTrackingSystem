namespace StoreVisitTrackingSystem.Api.Models.Requests;

public class ProductRequestModel
{
    public string? Name { get; set; }
    public string? Category { get; set; }
    public DateTime CreatedAt { get; set; }
}
