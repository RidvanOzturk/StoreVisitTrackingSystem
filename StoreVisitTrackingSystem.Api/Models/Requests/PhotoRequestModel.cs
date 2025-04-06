namespace StoreVisitTrackingSystem.Api.Models.Requests;

public class PhotoRequestModel
{
    public int ProductId { get; set; }
    public string? Base64Image { get; set; }
    public int UserId { get; set; }
}
