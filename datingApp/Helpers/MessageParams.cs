﻿/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */
namespace datingApp.Helpers;

public class MessageParams : PaginationParams
{
    public string Username { get; set; }
    public string Container { get; set; } = "unread";
}