using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using FluentValidation;
using Application.Services.Core;
using Application.Services.Chatbot;

namespace Application;

/// <summary>
/// Extension methods for Application layer dependency injection
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDI(this IServiceCollection services)
    {
        // AutoMapper for domain <-> DTO mappings
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);

        // MediatR for CQRS pattern
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        // FluentValidation - registers all validators in this assembly
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        // Register Core Services (8 entities)
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IVehicleService, VehicleService>();
        services.AddScoped<IGarageService, GarageService>();
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<IServiceHistoryService, ServiceHistoryService>();
        services.AddScoped<IVehicleIssueService, VehicleIssueService>();
        services.AddScoped<IDiagnosticRuleService, DiagnosticRuleService>();
        services.AddScoped<IImageDiagnosticService, ImageDiagnosticService>();

        // Register Chatbot Services (5 entities)
        services.AddScoped<IChatbotConversationService, ChatbotConversationService>();
        services.AddScoped<IChatbotMessageService, ChatbotMessageService>();
        services.AddScoped<IChatbotKnowledgeBaseService, ChatbotKnowledgeBaseService>();
        services.AddScoped<IAiImageAnalysisService, AiImageAnalysisService>();
        services.AddScoped<IAiUsageLogService, AiUsageLogService>();

        return services;
    }
}
