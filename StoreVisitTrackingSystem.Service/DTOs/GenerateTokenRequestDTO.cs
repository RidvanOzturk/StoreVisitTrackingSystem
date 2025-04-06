namespace StoreVisitTrackingSystem.Service.DTOs;

public class GenerateTokenRequestDTO
{
    public int UserId { get; set; }
    public required string Username { get; set; }
    public required string Role { get; set; }
}
