﻿/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */
using datingApp.Entities;

namespace datingApp.Interfaces;

public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
}