﻿using datingApp.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace datingApp.Controllers;

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