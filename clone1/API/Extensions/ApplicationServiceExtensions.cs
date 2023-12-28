﻿/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */
using clone1.Core.Helpers;
using clone1.Core.Interfaces;
using clone1.Data;
using clone1.Infrastructure.Data;
using clone1.Infrastructure.Repositories;
using clone1.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace clone1.API.Extensions;

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