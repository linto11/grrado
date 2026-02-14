using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace GarageService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddGarageApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
