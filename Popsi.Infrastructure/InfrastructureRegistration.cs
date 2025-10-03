using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Popsi.Domain.Interfaces;
using Popsi.Infrastructure.Persistance;
using Popsi.Infrastructure.Persistance.Repositories;

namespace Popsi.Infrastructure;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connetion String not found");

        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        );

        services.AddScoped<ILabourRepository, LabourRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}
