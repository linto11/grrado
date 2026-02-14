using Microsoft.Extensions.DependencyInjection;

namespace UserService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddUserApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        return services;
    }
}
