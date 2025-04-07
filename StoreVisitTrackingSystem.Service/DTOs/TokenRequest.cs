namespace StoreVisitTrackingSystem.Service.DTOs;

public class TokenRequest
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
}
