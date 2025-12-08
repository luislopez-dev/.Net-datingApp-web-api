﻿using clone1.Infrastructure.Repositories;

namespace clone1.Core.Interfaces;


/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public interface IUnitOfWork
{
    UserRepository UserRepository { get; }
    Task<bool> CompleteAsync();
    bool HasChanges();
}