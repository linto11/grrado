using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DiagnosticsService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddDiagnosticsApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
