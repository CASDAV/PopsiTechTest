using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Popsi.Infrastructure.Persistance;

namespace Popsi.Infrastructure;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connetion String not found");

        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        );

        return services;
    }
}
