﻿/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */
using AutoMapper;
using clone1.Core.DTOs;
using clone1.Core.Entities;
using clone1.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clone1.API.Controllers;

public class AccountController : BaseApiController
{
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;

    public AccountController(ITokenService tokenService, IMapper mapper, UserManager<AppUser> userManager)
    {
        _tokenService = tokenService;
        _mapper = mapper;
        _userManager = userManager;
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(user => user.UserName == loginDto.Username);
        if (user == null) return NotFound();

        var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
        if (result == false) return Unauthorized("Invalid Password");

        return new UserDto
        {
            Username = user.UserName,
            Token = await _tokenService.CreateToken(user)
        };
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if (await UserExits(registerDto.Username))
        {
            return BadRequest("User already taken");
        }
        var user = _mapper.Map<AppUser>(registerDto);
        user.UserName = registerDto.Username.ToLower();

        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded) return BadRequest(result.Errors);
        var roleResult = await _userManager.AddToRoleAsync(user, "Member");
        if (!roleResult.Succeeded) return BadRequest(roleResult.Errors);

        return new UserDto
        {
            Username = user.UserName,
            KnownAs = user.KnownAs,
            PhotoUrl = user.Photos.FirstOrDefault(photo => photo.IsMain)?.Url,
            Token = await _tokenService.CreateToken(user)
        };
    }
    private async Task<bool> UserExits(string username)
    {
        return await _userManager.Users.AnyAsync(user => user.UserName == username.ToLower());
    }
}