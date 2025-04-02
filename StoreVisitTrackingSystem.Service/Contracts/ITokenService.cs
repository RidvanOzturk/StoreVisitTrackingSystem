using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Contracts;

public interface ITokenService
{
    Task<GenerateTokenResponseDTO> GenerateToken(GenerateTokenRequestDTO request);
    Task<string> GenerateRefreshTokenAsync();
}
