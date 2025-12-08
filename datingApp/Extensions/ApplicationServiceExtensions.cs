﻿
using datingApp.Config;
using datingApp.Data;
using datingApp.Helpers;
using datingApp.Interfaces;
using datingApp.Services;
using Microsoft.EntityFrameworkCore;
namespace datingApp.Extensions;

/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlServer((config.GetConnectionString("datingApp")));
        });
        services.AddScoped<ITokenService, TokenService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
        services.AddScoped<IPhotoService, PhotoService>();
        services.AddScoped<LogUserActivity>();
        services.AddSignalR();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}