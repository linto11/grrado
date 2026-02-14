using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GarageService.Application.Abstractions;
using GarageService.Infrastructure.Persistence;

namespace GarageService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddGarageInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GarageDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IGarageUnitOfWork, GarageUnitOfWork>();
        return services;
    }
}
