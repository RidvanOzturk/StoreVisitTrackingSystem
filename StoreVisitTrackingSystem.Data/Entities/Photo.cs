namespace StoreVisitTrackingSystem.Data.Entities;

public class Photo
{
    public int Id { get; set; }
    public int VisitId { get; set; }
    public int ProductId { get; set; }
    public string? Base64Image { get; set; }
    public DateTime UploadedAt { get; set; }

    public Visit? Visit { get; set; }
    public Product? Product { get; set; }
}