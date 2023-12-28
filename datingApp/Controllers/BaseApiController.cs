﻿/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */
using datingApp.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace datingApp.Controllers;

[ServiceFilter(typeof(LogUserActivity))]
[Route("api/[controller]")]
[ApiController]
public class BaseApiController : Controller
{
}