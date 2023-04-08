using AutoMapper;
using AutoMapper.QueryableExtensions;
using clone1.Data;
using clone1.DTOs;
using clone1.Entities;
using clone1.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clone1.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public UserRepository(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<AppUser> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public Task<AppUser> GetUserByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<MemberDto> GetMemberAsync(string username)
    {
        return await _context.Users
            .Where(user => user.UserName == username)
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
    }

    public void Update(AppUser user)
    {
        _context.Entry(user).State = EntityState.Modified;
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}