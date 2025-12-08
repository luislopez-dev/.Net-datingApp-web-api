﻿using clone1.Core.Entities;

namespace clone1.Core.Interfaces;


/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public interface ITokenService
{
    public Task<string> CreateToken(AppUser user);
}