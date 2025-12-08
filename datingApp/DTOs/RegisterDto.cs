﻿using System.ComponentModel.DataAnnotations;
using datingApp.Extensions;
using Newtonsoft.Json;

namespace datingApp.DTOs;

/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public class RegisterDto
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string KnownAs { get; set; }
    
    [Required]
    public string Gender { get; set; }
        
    [Required]
    public DateOnly DateOfBirth { get; set; }
    
    [Required]
    public string City { get; set; }
        
    [Required]
    public string Country { get; set; }
        
    [Required]
    [StringLength(8, MinimumLength = 4)]
    public string Password { get; set; }
}