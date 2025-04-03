namespace StoreVisitTrackingSystem.Data.Entities;

public class RefreshToken
{
    public int Id { get; set; }
    public string Token { get; set; }
    public DateTime ExpiryDate { get; set; }
    public int UserId { get; set; }

    public User User { get; set; }
    public DateTime CreatedAt { get; set; }
}
