using clone1.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace clone1.Controllers;

[ServiceFilter(typeof(LogUserActivity))]
[Route("api/[controller]")]
[ApiController]
public class BaseApiController : Controller
{
    
}