using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StoreVisitTrackingSystem.Service.Contracts;
using StoreVisitTrackingSystem.Service.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StoreVisitTrackingSystem.Service.Implementations;

public class TokenService(IConfiguration configuration) : ITokenService
{
    public string GenerateToken(TokenRequest request)
    {
        var secretKey = configuration.GetValue<string>("TokenSettings:Secret");
        int tokenExpiryMinutes = configuration.GetValue<int>("TokenSettings:ExpiresInMinutes");
        var issuer = configuration.GetValue<string>("TokenSettings:Issuer");
        var audience = configuration.GetValue<string>("TokenSettings:Audience");

        ArgumentException.ThrowIfNullOrWhiteSpace(secretKey);
        ArgumentException.ThrowIfNullOrWhiteSpace(issuer);
        ArgumentException.ThrowIfNullOrWhiteSpace(audience);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(tokenExpiryMinutes);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

        var claims = new List<Claim>
        {
            new Claim(nameof(request.UserId), request.UserId.ToString()),
            new Claim(nameof(request.Username), request.Username),
            new Claim(ClaimTypes.Role, request.Role)
        };

        var jwt = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(tokenExpiryMinutes),
            signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
        );

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        ArgumentException.ThrowIfNullOrWhiteSpace(token);

        return token;
    }
}
