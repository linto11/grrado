using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using FluentValidation;
using Application.Services.Users;
using Application.Services.Vehicles;
using Application.Services.Garages;
using Application.Services.Services;
using Application.Services.ServiceHistories;
using Application.Services.VehicleIssues;
using Application.Services.DiagnosticRules;
using Application.Services.ImageDiagnostics;
using Application.Services.ChatbotConversations;
using Application.Services.ChatbotMessages;
using Application.Services.ChatbotKnowledgeBases;
using Application.Services.AiImageAnalyses;
using Application.Services.AiUsageLogs;

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
