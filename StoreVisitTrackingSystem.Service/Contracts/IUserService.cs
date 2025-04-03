using StoreVisitTrackingSystem.Data.Entities;

namespace StoreVisitTrackingSystem.Service.Contracts;

public interface IUserService
{
    Task<List<User>> GetAllUsersAsync();
}
