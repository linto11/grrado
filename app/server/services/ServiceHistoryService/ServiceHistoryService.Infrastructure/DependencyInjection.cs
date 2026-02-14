using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using ServiceHistoryService.Application.Abstractions;
using ServiceHistoryService.Infrastructure.Persistence;

namespace ServiceHistoryService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddServiceHistoryInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            connectionString = "Host=localhost;Port=5433;Database=grrado_servicehistory_db;Username=postgres;Password=postgres;";
            Log.Warning("DefaultConnection missing; using fallback.");
        }
        services.AddDbContext<ServiceHistoryDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IServiceHistoryUnitOfWork, ServiceHistoryUnitOfWork>();
        return services;
    }
}
