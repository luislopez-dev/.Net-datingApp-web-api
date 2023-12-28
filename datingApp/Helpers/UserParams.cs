﻿/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */
namespace datingApp.Helpers;

public class UserParams : PaginationParams
{
    public string? CurrentUsername { get; set; }
    public string? Gender { get; set; }
    public int MinAge { get; set; } = 18;
    public int MaxAge { get; set; } = 100;
    public string OrderBy { get; set; } = "lastActive";
}