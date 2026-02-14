using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceHistoryService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddServiceHistoryApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
