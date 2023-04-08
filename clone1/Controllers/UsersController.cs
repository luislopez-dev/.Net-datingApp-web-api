using AutoMapper;
using AutoMapper.QueryableExtensions;
using clone1.Data;
using clone1.DTOs;
using clone1.Entities;
using clone1.Extensions;
using clone1.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clone1.Controllers;

public class UsersController : BaseApiController
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UsersController(DataContext context, IMapper mapper, IUserRepository userRepository)
    {
        _context = context;
        _mapper = mapper;
        _userRepository = userRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        /*
        var users = await _context.Users.ToListAsync();
        var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
        return Ok(usersToReturn);
        */

        var users= await _context.Users
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        return users;
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        return await _userRepository.GetMemberAsync(username);
    }
    
    [HttpPut]
    public async Task<ActionResult> UpdateUser(UpdateMemberDto updateMemberDto)
    {
        var user = await _userRepository.GetUserByUsernameAsync(User.GetUserName());
        if (user == null)
        {
            return NotFound();
        }
        _mapper.Map(updateMemberDto, user);
        if (await _userRepository.SaveAllAsync())
        {
            return NoContent();
        }
        return BadRequest("Failed to update user");
    }
}