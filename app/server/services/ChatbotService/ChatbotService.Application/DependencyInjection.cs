using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ChatbotService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddChatbotApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
