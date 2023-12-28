﻿/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */
using clone1.Infrastructure.Repositories;

namespace clone1.Core.Interfaces;

public interface IUnitOfWork
{
    UserRepository UserRepository { get; }
    Task<bool> CompleteAsync();
    bool HasChanges();
}