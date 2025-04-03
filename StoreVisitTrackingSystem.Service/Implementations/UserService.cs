﻿using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data;
using StoreVisitTrackingSystem.Data.Entities;
using StoreVisitTrackingSystem.Service.Contracts;

namespace StoreVisitTrackingSystem.Service.Implementations;

public class UserService(TrackingContext trackingContext) : IUserService
{
    //Passwordhash dönmemem lazım DTO model dönücem.
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await trackingContext.Users
            .AsNoTracking()
            .ToListAsync();
    }
}
