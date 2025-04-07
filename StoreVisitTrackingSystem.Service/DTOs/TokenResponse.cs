namespace StoreVisitTrackingSystem.Service.DTOs;

public class TokenResponse
{
    public string? Token { get; set; }
    public DateTime TokenExpireDate { get; set; }
};
