using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Contracts;

public interface ITokenService
{
    GenerateTokenResponseDTO GenerateToken(GenerateTokenRequestDTO request);
}
