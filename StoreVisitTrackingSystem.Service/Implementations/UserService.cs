using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data;
using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.Contracts;
using StoreVisitTrackingSystem.Service.DTOs;
using StoreVisitTrackingSystem.Service.Extensions;

namespace StoreVisitTrackingSystem.Service.Implementations;

public class UserService(TrackingContext trackingContext, ITokenService tokenService) : IUserService
{
    public async Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        return await trackingContext.Users
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<UserResponseModel> LoginUserAsync(LoginRequestDTO loginRequestDTO, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(loginRequestDTO.Username))
        {
            return new UserResponseModel
            {
                AccessTokenExpireDate = null,
                AuthenticateResult = false,
                AuthToken = null,
                RefreshToken = null
            };
        }
        var user = await trackingContext.Users
            .FirstOrDefaultAsync(x=>x.Username == loginRequestDTO.Username, cancellationToken);
        if (user == null)
        {
            return new UserResponseModel
            {
                AccessTokenExpireDate = null,
                AuthenticateResult = false,
                AuthToken = null,
                RefreshToken = null
            };
        }

        var generatedToken = await tokenService.GenerateToken(new GenerateTokenRequestDTO { UserId = user.Id, Username = user.Username });
        var refreshTokenString = await tokenService.GenerateRefreshTokenAsync();
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
            AuthenticateResult = true,
            AuthToken = generatedToken.Token,
            RefreshToken = refreshTokenString
        };
    }

}
