﻿namespace clone1.Core.Entities;


/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public class UserLike
{
    public AppUser SourceUser { get; set; }
    public int SourceUserId { get; set; }
    
    public AppUser TargetUser { get; set; }
    public int TargetUserId { get; set; }
}