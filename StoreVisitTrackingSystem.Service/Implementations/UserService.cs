using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data;
using StoreVisitTrackingSystem.Service.Contracts;
using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Implementations;

public class UserService(TrackingContext trackingContext, ITokenService tokenService) : IUserService
{
    public async Task<UserResponseModel> LoginUserAsync(LoginRequestDTO loginRequestDTO, CancellationToken cancellationToken = default)
    {
        var user = await trackingContext.Users.AsNoTracking().FirstOrDefaultAsync(x=>x.Username == loginRequestDTO.Username, cancellationToken);
        if (user == null)
        {
            throw new UnauthorizedAccessException("User not found.");
        }
        var generatedToken = tokenService.GenerateToken(new GenerateTokenRequestDTO
        { 
            UserId = user.Id,
            Username = user.Username,
            Role = user.Role.ToString() 
        });
        return new UserResponseModel
        {
            AccessTokenExpireDate = generatedToken.TokenExpireDate,
            isAuthenticated = true,
            AuthToken = generatedToken.Token,
        };
    }
}
