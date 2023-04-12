using AutoMapper;
using AutoMapper.QueryableExtensions;
using clone1.Data;
using clone1.DTOs;
using clone1.Entities;
using clone1.Helpers.Pagination;
using clone1.Helpers.Pagination.Params;
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

    public async Task<AppUser> GetUserByUsernameAsync(string username)
    {
        return await _context.Users
            .Include(user => user.Photos)
            .SingleOrDefaultAsync(user => user.UserName == username);
    }

    public async Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams)
    {
        var query = _context.Users.AsQueryable();
        // Get all users except the current one
        query = query.Where(user => user.UserName != userParams.CurrentUserName);
        // Get all users whose gender is included in the userParams
        query = query.Where(user => user.Gender == userParams.Gender);

        // Age filters
        var minDob = DateOnly.FromDateTime(DateTime.Today.AddYears(-userParams.MaxAge - 1));
        var maxDob = DateOnly.FromDateTime(DateTime.Today.AddYears(-userParams.MinAge));
        
        // Get users who met the age filters
        query = query.Where(user => user.DateOfBirth >= minDob && user.DateOfBirth <= maxDob);

        // Order users
        query = userParams.OrderBy switch
        {
            "Created" => query.OrderByDescending(user => user.Created),
            _ => query.OrderByDescending(user => user.LastActive)
        };
        // Create pagination and return it
        return await PagedList<MemberDto>.CreateAsync(
            query.AsNoTracking().ProjectTo<MemberDto>(_mapper.ConfigurationProvider), 
            userParams.PageNumber, 
            userParams.PageSize);
    }

    public async Task<string> GetUserGenderAsync(string username)
    {
        return await _context.Users
            .Where(user => user.UserName == username)
            .Select(user => user.Gender).FirstOrDefaultAsync();
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