using System.Security.Claims;

namespace StoreVisitTrackingSystem.Api.Extensions;

public static class ClaimExtensions
{
    public static int GetUserId(this ClaimsPrincipal user)
    {
        var userId = user.FindFirst("UserId")?.Value;
        return int.TryParse(userId, out var id) ? id : 0;
    }

    public static bool IsAdmin(this ClaimsPrincipal user)
    {
        return user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value == "Admin";
    }
}
