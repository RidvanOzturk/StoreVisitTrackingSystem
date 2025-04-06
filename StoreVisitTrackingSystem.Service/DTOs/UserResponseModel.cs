namespace StoreVisitTrackingSystem.Service.DTOs;

public class UserResponseModel
{
    public bool isAuthenticated { get; set; }
    public string? AuthToken { get; set; }
    public DateTime? AccessTokenExpireDate { get; set; }
}
