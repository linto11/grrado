using ChatbotService.Application.Abstractions;
using ChatbotService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatbotService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddChatbotInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ChatbotDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IChatbotUnitOfWork, ChatbotUnitOfWork>();

        return services;
    }
}
