namespace StoreVisitTrackingSystem.Service.DTOs;

public class GenerateTokenRequestDTO
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Mail { get; set; }
}
