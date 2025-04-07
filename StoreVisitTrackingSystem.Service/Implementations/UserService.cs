using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data;
using StoreVisitTrackingSystem.Service.Contracts;
using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Implementations;

public class UserService(TrackingContext trackingContext, ITokenService tokenService) : IUserService
{
    public async Task<string?> LoginUserAsync(LoginRequestDTO loginRequestDTO, CancellationToken cancellationToken = default)
    {
        var user = await trackingContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Username == loginRequestDTO.Username, cancellationToken);

        if (user == null)
        {
            return null;
        }

        var tokenRequest = new TokenRequest
        {
            UserId = user.Id,
            Username = user.Username,
            Role = user.Role.ToString()
        };

        var generatedToken = tokenService.GenerateToken(tokenRequest);

        return generatedToken;
    }
}
