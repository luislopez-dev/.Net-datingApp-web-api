using clone1.Core.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace clone1.API.Controllers;

[ServiceFilter(typeof(LogUserActivity))]
[Route("api/[controller]")]
[ApiController]
public class BaseApiController : Controller
{
    
}