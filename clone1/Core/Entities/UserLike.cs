﻿/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */
namespace clone1.Core.Entities;

public class UserLike
{
    public AppUser SourceUser { get; set; }
    public int SourceUserId { get; set; }
    
    public AppUser TargetUser { get; set; }
    public int TargetUserId { get; set; }
}