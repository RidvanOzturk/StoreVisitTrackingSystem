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
    public GenerateTokenResponseDTO GenerateToken(GenerateTokenRequestDTO request)
    {
        var secretKey = configuration["AppSettings:Secret"];
        if (string.IsNullOrEmpty(secretKey))
            throw new Exception("JWT Secret Key not found.");

        int tokenExpiryMinutes = configuration.GetValue<int>("TokenSettings:ExpiresInMinutes");

        string issuer = configuration["TokenSettings:Issuer"] ?? throw new Exception("Issuer is missing");
        string audience = configuration["TokenSettings:Audience"] ?? throw new Exception("Audience is missing");

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
        var now = DateTime.UtcNow;

        var claims = new List<Claim>
    {
        new Claim("UserId", request.UserId.ToString()),
        new Claim("Username", request.Username),
        new Claim(ClaimTypes.Role, request.Role)
    };

        var jwt = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            notBefore: now,
            expires: now.AddMinutes(tokenExpiryMinutes),
            signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
        );

        string token = new JwtSecurityTokenHandler().WriteToken(jwt);
        if (string.IsNullOrEmpty(token))
            throw new Exception("JWT Token cannot be created.");

        return new GenerateTokenResponseDTO
        {
            Token = token,
            TokenExpireDate = now.AddMinutes(tokenExpiryMinutes)
        };
    }

}
