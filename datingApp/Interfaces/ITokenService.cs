﻿
using datingApp.Entities;

namespace datingApp.Interfaces;

/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
}