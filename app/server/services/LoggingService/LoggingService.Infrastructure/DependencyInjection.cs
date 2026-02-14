using LoggingService.Application.Abstractions;
using LoggingService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoggingService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddLoggingInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LoggingDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ILoggingUnitOfWork, LoggingUnitOfWork>();

        return services;
    }
}
