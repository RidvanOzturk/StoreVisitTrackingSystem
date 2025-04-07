using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Contracts;

public interface IUserService
{
    Task<string?> LoginUserAsync(LoginRequestDTO loginRequestDTO, CancellationToken cancellationToken = default);
}
