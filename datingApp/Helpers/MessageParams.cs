﻿
namespace datingApp.Helpers;

/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public class MessageParams : PaginationParams
{
    public string Username { get; set; }
    public string Container { get; set; } = "unread";
}