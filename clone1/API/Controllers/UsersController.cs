﻿using AutoMapper;
using clone1.API.Extensions;
using clone1.Core.DTOs;
using clone1.Core.Helpers.Pagination;
using clone1.Core.Helpers.Pagination.Params;
using clone1.Core.Interfaces;
using clone1.Data;
using clone1.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clone1.API.Controllers;


/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public class UsersController : BaseApiController
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UsersController(DataContext context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    [Authorize(Roles = "Member")]
    [HttpGet]
    public async Task<ActionResult<PagedList<MemberDto>>> GetUsers([FromQuery] UserParams userParams)
    {
        var gender = await _unitOfWork.UserRepository.GetUserGenderAsync(User.GetUserName());

        if (string.IsNullOrEmpty(userParams.Gender))
        {
            userParams.Gender = gender == "male" ? "female" : "male";
        }
        
        userParams.CurrentUserName = User.GetUserName();
        
        var users = await _unitOfWork.UserRepository.GetMembersAsync(userParams);
        
        Response.AddPaginationHeader(new PaginationHeader(
            users.TotalPages, users.CurrentPage,
            users.PageSize, users.TotalItems
            ));
        
        return Ok(users);
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        return await _unitOfWork.UserRepository.GetMemberAsync(username);
    }
    
    [HttpPut]
    public async Task<ActionResult> UpdateUser(UpdateMemberDto updateMemberDto)
    {
        var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUserName());
        if (user == null)
        {
            return NotFound();
        }
        _mapper.Map(updateMemberDto, user);
        if (await _unitOfWork.CompleteAsync())
        {
            return NoContent();
        }
        return BadRequest("Failed to update user");
    }
}