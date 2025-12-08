﻿using clone1.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace clone1.API.Controllers;


/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public class AdminController : BaseApiController
{
    private readonly UserManager<AppUser> _userManager;

    public AdminController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [Authorize(Policy = "RequireAdminRole")]
    [HttpGet("users-with-roles")]
    public async Task<ActionResult> GetUserWithRoles()
    {
        var users = await _userManager.Users.OrderBy(user => user.UserName).Select(user => new
        {
            user.Id,
            Username = user.UserName,
            Roles = user.UserRoles.Select(role => role.Role.Name).ToList()
        }).ToListAsync();

        return Ok(users);
    }

    [Authorize(Policy = "RequireAdminRole")]
    [HttpPost("edit-roles/{username}")]
    public async Task<ActionResult> EditRoles(string username, [FromQuery] string roles)
    {
        if (roles.IsNullOrEmpty()) return BadRequest("You must select at least one role");
        
        var selectedRoles = roles.Split(",").ToArray();
        
        var user = await _userManager.FindByNameAsync(username);
        if (user == null) return NotFound();

        var userRoles = await _userManager.GetRolesAsync(user);

        var addingResult = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

        if (!addingResult.Succeeded) return BadRequest("Roles could not be added");

        var removingResult = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));

        if (!removingResult.Succeeded) return BadRequest("Roles could not be removed");

        return Ok(await _userManager.GetRolesAsync(user));
    }

    [Authorize(Policy = "ModeratePhotoRole")]
    [HttpGet("photos-to-moderate")]
    public ActionResult GetPhotosForModeration()
    {
        return Ok("Only admins and moderators can see this");
    }

}