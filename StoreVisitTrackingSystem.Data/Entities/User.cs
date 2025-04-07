using StoreVisitTrackingSystem.Data.Entities.Enums;

namespace StoreVisitTrackingSystem.Data.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public UserRole Role { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual List<Visit> Visits { get; set; } = [];
}

