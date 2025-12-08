﻿
using System.Text.Json;
using datingApp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace datingApp.Data;

/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>   
public class Seed
{
    public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        if (await userManager.Users.AnyAsync()) return;

        var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

        var roles = new List<AppRole>
        {
            new AppRole { Name = "Member" },
            new AppRole { Name = "Admin" },
            new AppRole { Name = "Moderator" }
        };
        foreach (var role in roles)
        {
            await roleManager.CreateAsync(role);
        }
        foreach (var user in users)
        {
            user.UserName = user.UserName.ToLower();
            await userManager.CreateAsync(user, "Pa$$w0rd");
            await userManager.AddToRoleAsync(user, "Member");
        }
        var admin = new AppUser
        {
            UserName = "admin"
        };
        await userManager.CreateAsync(admin, "Pa$$w0rd");
        await userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator" });
    }
}