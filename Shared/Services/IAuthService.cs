﻿using Shared.Models;

namespace Shared.Services;

public interface IAuthService
{
    Task<User> GetUser(string username, string password);
    Task RegisterUser(User user);
    Task<User> ValidateUser(string username, string password);
}