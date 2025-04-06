using StoreVisitTrackingSystem.Service.DTOs;

namespace StoreVisitTrackingSystem.Service.Contracts;

public interface IUserService
{
    Task<UserResponseModel> LoginUserAsync(LoginRequestDTO loginRequestDTO, CancellationToken cancellationToken = default);
}
