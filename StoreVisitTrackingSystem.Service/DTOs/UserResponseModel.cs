﻿namespace StoreVisitTrackingSystem.Service.DTOs;

public class UserResponseModel
{
    public bool AuthenticateResult { get; set; }
    public string AuthToken { get; set; }
    public DateTime? AccessTokenExpireDate { get; set; }
    public string RefreshToken { get; set; }
}
