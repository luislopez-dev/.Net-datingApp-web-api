using clone1.Extensions;
using clone1.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace clone1.Helpers;

public class LogUserActivity : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var resultContext = await next();
        
        if (!resultContext.HttpContext.User.Identity.IsAuthenticated) return;

        var userId = resultContext.HttpContext.User.GetUserId();

        var repo = resultContext.HttpContext.RequestServices.GetRequiredService<IUnitOfWork>().UserRepository;

        var user = await repo.GetUserByIdAsync(userId);
        
        user.LastActive = DateTime.UtcNow;

        await repo.SaveAllAsync();
    }
}