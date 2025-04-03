using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data;
using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.Contracts;

namespace StoreVisitTrackingSystem.Service.Implementations;

public class UserService(TrackingContext trackingContext) : IUserService
{
    public async Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        return await trackingContext.Users
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

}
