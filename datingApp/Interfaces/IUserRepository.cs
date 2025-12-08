﻿
using datingApp.DTOs;
using datingApp.Entities;
using datingApp.Helpers;

namespace datingApp.Interfaces;

/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public interface IUserRepository
{
    public void Update(AppUser user);
    public Task<IEnumerable<AppUser>> GetUsersAsync();
    public Task<AppUser> GetUserByIdAsync(int id);
    public Task<AppUser> GetUserByUserNameAsync(string username);
    public Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
    public Task<MemberDto> GetMemberAsync(string username);
    public Task<string> GetUserGender(string username);
}