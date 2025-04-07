using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Contracts;

public interface ITokenService
{
    string GenerateToken(TokenRequest request);
}
