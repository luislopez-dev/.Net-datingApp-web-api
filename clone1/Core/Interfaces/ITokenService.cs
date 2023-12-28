﻿/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */
using clone1.Core.Entities;

namespace clone1.Core.Interfaces;

public interface ITokenService
{
    public Task<string> CreateToken(AppUser user);
}