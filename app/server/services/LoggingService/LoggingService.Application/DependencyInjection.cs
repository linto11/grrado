using Microsoft.Extensions.DependencyInjection;

namespace LoggingService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddLoggingApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        return services;
    }
}
