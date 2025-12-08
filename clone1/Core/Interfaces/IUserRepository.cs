﻿using clone1.Core.DTOs;
using clone1.Core.Entities;
using clone1.Core.Helpers.Pagination;
using clone1.Core.Helpers.Pagination.Params;

namespace clone1.Core.Interfaces;


/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public interface IUserRepository
{
    public Task<AppUser> GetUserByIdAsync(int id);
    public Task<AppUser> GetUserByUsernameAsync(string username);
    public Task<MemberDto> GetMemberAsync(string username);
    public Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
    public Task<string> GetUserGenderAsync(string username);
    public void Update(AppUser user);
}