﻿using Microsoft.Extensions.Configuration;
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
    public Task<GenerateTokenResponseDTO> GenerateToken(GenerateTokenRequestDTO request)
    {
        var secretKey = Environment.GetEnvironmentVariable("AppSettings__Secret");
        if (string.IsNullOrEmpty(secretKey))
        {
            throw new Exception("JWT Secret Key not found.");
        }
        int tokenExpiryMinutes = configuration.GetValue<int>("TokenSettings:ExpiresInMinutes");
        SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
        var dateTimeNow = DateTime.UtcNow;
        JwtSecurityToken jwt = new JwtSecurityToken(
            claims: new List<Claim>
            {
                    new Claim("UserId", request.UserId.ToString()),
                    new Claim("Name", request.Name),
                    new Claim("Mail", request.Mail),
            },
            notBefore: dateTimeNow,
            expires: dateTimeNow.AddMinutes(tokenExpiryMinutes),
            signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
        );
        string token = new JwtSecurityTokenHandler().WriteToken(jwt);
        if (string.IsNullOrEmpty(token))
        {
            throw new Exception("JWT Token cannot be created.");
        }
        return Task.FromResult(new GenerateTokenResponseDTO
        {
            Token = token,
            TokenExpireDate = dateTimeNow.AddMinutes(tokenExpiryMinutes)
        });
    }
    public Task<string> GenerateRefreshTokenAsync()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Task.FromResult(Convert.ToBase64String(randomNumber));
        }
    }
}
