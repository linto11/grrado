using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DiagnosticsService.Application.Abstractions;
using DiagnosticsService.Infrastructure.Persistence;

namespace DiagnosticsService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddDiagnosticsInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DiagnosticsDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IDiagnosticsUnitOfWork, DiagnosticsUnitOfWork>();
        return services;
    }
}
