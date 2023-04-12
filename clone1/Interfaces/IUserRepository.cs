using clone1.DTOs;
using clone1.Entities;
using clone1.Helpers.Pagination;
using clone1.Helpers.Pagination.Params;

namespace clone1.Interfaces;

public interface IUserRepository
{
    public Task<AppUser> GetUserByIdAsync(int id);
    public Task<AppUser> GetUserByUsernameAsync(string username);
    public Task<MemberDto> GetMemberAsync(string username);
    public Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
    public Task<string> GetUserGenderAsync(string username);
    public void Update(AppUser user);
    public Task<bool> SaveAllAsync();
}