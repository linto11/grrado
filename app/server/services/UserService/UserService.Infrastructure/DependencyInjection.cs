using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using UserService.Application.Abstractions;
using UserService.Infrastructure.Persistence;

namespace UserService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddUserInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            connectionString = "Host=localhost;Port=5433;Database=grrado_user_db;Username=postgres;Password=postgres;";
            Log.Warning("DefaultConnection missing; using fallback.");
        }
        services.AddDbContext<UserDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
        return services;
    }
}
