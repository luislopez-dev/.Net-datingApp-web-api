using clone1.Data;
using clone1.Helpers;
using clone1.Interfaces;
using clone1.Repositories;
using clone1.Services;
using Microsoft.EntityFrameworkCore;

namespace clone1.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlServer(config.GetConnectionString("datingApp"));
        });
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<LogUserActivity>();
        return services;
    }
}