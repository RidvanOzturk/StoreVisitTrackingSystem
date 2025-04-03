using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.DTOs;
using System.Threading;

namespace StoreVisitTrackingSystem.Service.Contracts;

public interface IUserService
{
    Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    Task<UserResponseModel> LoginUserAsync(LoginRequestDTO loginRequestDTO, CancellationToken cancellationToken = default);
}
