﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace datingApp.Entities;

/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
[Table("photos")]
public class Photo
{
    public int Id { get; set; }
    public string Url { get; set; }
    public bool IsMain { get; set; }
    public string? PublicId { get; set; }
    public AppUser AppUser { get; set; }
    public int AppUserId { get; set; }
}