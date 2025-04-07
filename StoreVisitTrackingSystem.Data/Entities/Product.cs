namespace StoreVisitTrackingSystem.Data.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual List<Photo> Photos { get; set; } = [];
}