namespace StoreVisitTrackingSystem.Service.DTOs;

public class GenerateTokenRequestDTO
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
}
