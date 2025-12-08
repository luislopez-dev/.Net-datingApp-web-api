﻿namespace datingApp.Interfaces;

/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public interface IUnitOfWork 
{
    IUserRepository UserRepository { get; }
    IMessageRepository MessageRepository { get; }
    ILikesRepository LikesRepository { get; }
    Task<bool> Complete();
    bool HasChanges();
}