namespace StoreVisitTrackingSystem.Api.Models.Responses;

public class PhotoResponseModel
{
    public int Id { get; set; }
    public string Base64Image { get; set; }
    public DateTime UploadedAt { get; set; }
    public ProductResponseModel Product { get; set; }
}
