﻿using clone1.Core.Entities;
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
public class BuggyController : BaseApiController
{
    private readonly DataContext _dataContext;

    public BuggyController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [Authorize]
    [HttpGet("not-found")]
    public ActionResult<AppUser> GetNotFound()
    {
        var user = _dataContext.Users.Find(-1);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }
    
    [HttpGet("server-error")]
    public ActionResult<string> GetServerError()
    {
        var user = _dataContext.Users.Find(-1);
        var userToReturn = user.ToString();
        return userToReturn;
    }
    
    [HttpGet("bad-request")]
    public ActionResult<string> GetBadRequest()
    {
        return BadRequest("This was not a good request");
    }
}