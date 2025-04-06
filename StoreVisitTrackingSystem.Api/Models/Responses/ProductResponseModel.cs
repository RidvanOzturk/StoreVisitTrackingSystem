namespace StoreVisitTrackingSystem.Api.Models.Responses;

public class ProductResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public DateTime CreatedAt { get; set; }
}