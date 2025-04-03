using StoreVisitTrackingSystem.Data.Entities;
using System.Threading;

namespace StoreVisitTrackingSystem.Service.Contracts;

public interface IUserService
{
    Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken = default);
}
