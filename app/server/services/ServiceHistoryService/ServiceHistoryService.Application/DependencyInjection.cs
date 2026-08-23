using System.Reflection;
using FluentValidation;
using GRRADO.Shared.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceHistoryService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddServiceHistoryApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });
        services.AddAutoMapper(assembly);
        services.AddValidatorsFromAssembly(assembly);
        return services;
    }
}
