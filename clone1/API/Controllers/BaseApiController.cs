﻿using clone1.Core.Helpers;

using Microsoft.AspNetCore.Mvc;

namespace clone1.API.Controllers;


/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
[ServiceFilter(typeof(LogUserActivity))]
[Route("api/[controller]")]
[ApiController]
public class BaseApiController : Controller
{
    
}