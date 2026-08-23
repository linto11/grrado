using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VehicleService.Application.Abstractions;
using VehicleService.Infrastructure.Messaging;
using VehicleService.Infrastructure.Persistence;

namespace VehicleService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddVehicleInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<VehicleDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IVehicleUnitOfWork, VehicleUnitOfWork>();
        services.AddHostedService<VehicleEventConsumer>();
        return services;
    }
}
