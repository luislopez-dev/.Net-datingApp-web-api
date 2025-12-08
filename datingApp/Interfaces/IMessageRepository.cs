﻿using datingApp.Data;
using datingApp.DTOs;
using datingApp.Helpers;

namespace datingApp.Interfaces;

/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public interface IMessageRepository
{
    public void AddMessage(Message message);
    public void DeleteMessage(Message message);
    public Task<Message> GetMessage(int id);
    public Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams);
    public Task<IEnumerable<MessageDto>> GetMessageThread(string currentUserName, string recipientUserName);
}