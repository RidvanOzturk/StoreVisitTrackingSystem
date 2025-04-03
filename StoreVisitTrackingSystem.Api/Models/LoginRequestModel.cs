using StoreVisitTrackingSystem.Data.Entities;

namespace StoreVisitTrackingSystem.Api.Models;

public class LoginRequestModel
{
    public string Username { get; set; }
    public UserRole Role { get; set; }
    public DateTime CreatedAt { get; set; }

}
