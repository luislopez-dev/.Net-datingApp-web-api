﻿namespace clone1.Core.Helpers.Pagination.Params;


/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public class UserParams  : PaginationParams
{
    public string OrderBy { get; set; } = "lastActive";
    public int MinAge { get; set; } = 18;
    public int MaxAge { get; set; } = 50;
    public string CurrentUserName { get; set; }
    public string Gender { get; set; }
}