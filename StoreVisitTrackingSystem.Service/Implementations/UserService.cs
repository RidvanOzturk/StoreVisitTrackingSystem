using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data;
using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.Contracts;
using StoreVisitTrackingSystem.Service.DTOs;
using StoreVisitTrackingSystem.Service.Extensions;

namespace StoreVisitTrackingSystem.Service.Implementations;

public class UserService(TrackingContext trackingContext, ITokenService tokenService) : IUserService
{
    public async Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken = default)
    {
        return await trackingContext.Users
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
    public async Task<UserResponseModel> LoginUserAsync(LoginRequestDTO loginRequestDTO, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(loginRequestDTO.Username))
        {
            return new UserResponseModel
            {
                AccessTokenExpireDate = null,
                isAuthenticated = false,
                AuthToken = null,
                RefreshToken = null
            };
        }
        var user = await trackingContext.Users.AsNoTracking().FirstOrDefaultAsync(x=>x.Username == loginRequestDTO.Username, cancellationToken);
        if (user == null)
        {
            return new UserResponseModel
            {
                AccessTokenExpireDate = null,
                isAuthenticated = false,
                AuthToken = null,
                RefreshToken = null
            };
        }
        var generatedToken = await tokenService.GenerateTokenAsync(new GenerateTokenRequestDTO { UserId = user.Id, Username = user.Username, Role = user.Role.ToString() });
        var refreshTokenString = tokenService.GenerateRefreshToken();
        var refreshTokenEntity = new RefreshToken
        {
            Token = refreshTokenString,
            ExpiryDate = DateTime.UtcNow.AddDays(7),
            UserId = user.Id,
            CreatedAt = DateTime.UtcNow
        };
        await trackingContext.RefreshTokens.AddAsync(refreshTokenEntity, cancellationToken);
        await trackingContext.SaveChangesAsync(cancellationToken);
        return new UserResponseModel
        {
            AccessTokenExpireDate = generatedToken.TokenExpireDate,
            isAuthenticated = true,
            AuthToken = generatedToken.Token,
            RefreshToken = refreshTokenString
        };
    }
}
