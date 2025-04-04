using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StoreVisitTrackingSystem.Service.Contracts;
using StoreVisitTrackingSystem.Service.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace StoreVisitTrackingSystem.Service.Implementations;

public class TokenService(IConfiguration configuration) : ITokenService
{
    public async Task<GenerateTokenResponseDTO> GenerateTokenAsync(GenerateTokenRequestDTO request, CancellationToken cancellationToken = default)
    {
        var secretKey = configuration["AppSettings:Secret"];
        if (string.IsNullOrEmpty(secretKey))
        {
            throw new Exception("JWT Secret Key not found.");
        }
        int tokenExpiryMinutes = configuration.GetValue<int>("TokenSettings:ExpiresInMinutes");
        string issuer = configuration["TokenSettings:Issuer"];
        string audience = configuration["TokenSettings:Audience"];

        SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
        var dateTimeNow = DateTime.UtcNow;
        var claims = new List<Claim>
        {
            new Claim("UserId", request.UserId.ToString()),
            new Claim("Username", request.Username),
            new Claim(ClaimTypes.Role, request.Role)
        };

        JwtSecurityToken jwt = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            notBefore: dateTimeNow,
            expires: dateTimeNow.AddMinutes(tokenExpiryMinutes),
            signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
        );
        string token = new JwtSecurityTokenHandler().WriteToken(jwt);
        if (string.IsNullOrEmpty(token))
        {
            throw new Exception("JWT Token cannot be created.");
        }

        return new GenerateTokenResponseDTO
        {
            Token = token,
            TokenExpireDate = dateTimeNow.AddMinutes(tokenExpiryMinutes)
        };
    }

    public string GenerateRefreshToken(CancellationToken cancellationToken = default)
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }
}
