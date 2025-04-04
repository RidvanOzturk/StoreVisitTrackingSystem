using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Contracts;

public interface ITokenService
{
    Task<GenerateTokenResponseDTO> GenerateTokenAsync(GenerateTokenRequestDTO request, CancellationToken cancellationToken = default);
    string GenerateRefreshToken(CancellationToken cancellationToken = default);
}
