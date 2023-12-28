﻿/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */
using System.ComponentModel.DataAnnotations.Schema;

namespace clone1.Core.Entities;

[Table("Photos")]
public class Photo
{
    public int Id { get; set; }
    public string Url { get; set; }
    public bool IsMain { get; set; }
    public string? PublicId { get; set; }
    public AppUser AppUser { get; set; }
    public int AppUserId { get; set; }
}