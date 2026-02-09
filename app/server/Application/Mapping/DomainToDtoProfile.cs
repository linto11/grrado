using AutoMapper;
using Domain.Entities;
using Abstractions.DTOs.User;
using Abstractions.DTOs.Vehicle;
using Abstractions.DTOs.Garage;
using Abstractions.DTOs.Service;
using Abstractions.DTOs.ServiceHistory;
using Abstractions.DTOs.VehicleIssue;
using Abstractions.DTOs.DiagnosticRule;
using Abstractions.DTOs.ImageDiagnostic;
using Abstractions.DTOs.ChatbotConversation;
using Abstractions.DTOs.ChatbotMessage;
using Abstractions.DTOs.ChatbotKnowledgeBase;
using Abstractions.DTOs.AiImageAnalysis;
using Abstractions.DTOs.AiUsageLog;
using Application.UseCases.Core.Users.CreateUser;
using Application.UseCases.Core.Users.UpdateUser;

namespace Application.Mapping;

/// <summary>
/// Maps domain entities to DTOs and vice versa
/// </summary>
public class DomainToDtoProfile : Profile
{
    public DomainToDtoProfile()
    {
        // User mappings
        CreateMap<User, UserDto>();
        CreateMap<Abstractions.DTOs.User.CreateUserRequest, User>();
        CreateMap<Abstractions.DTOs.User.UpdateUserRequest, User>();
        CreateMap<Application.UseCases.Core.Users.CreateUser.CreateUserRequest, User>();
        CreateMap<Application.UseCases.Core.Users.UpdateUser.UpdateUserRequest, User>();

        // Vehicle mappings
        CreateMap<Vehicle, VehicleDto>();
        CreateMap<CreateVehicleRequest, Vehicle>();
        CreateMap<UpdateVehicleRequest, Vehicle>();
        CreateMap<Application.UseCases.Core.Vehicles.CreateVehicle.CreateVehicleRequest, Vehicle>();
        CreateMap<Application.UseCases.Core.Vehicles.UpdateVehicle.UpdateVehicleRequest, Vehicle>();

        // Garage mappings
        CreateMap<Garage, GarageDto>();
        CreateMap<CreateGarageRequest, Garage>();
        CreateMap<UpdateGarageRequest, Garage>();
        CreateMap<Application.UseCases.Core.Garages.CreateGarage.CreateGarageRequest, Garage>();
        CreateMap<Application.UseCases.Core.Garages.UpdateGarage.UpdateGarageRequest, Garage>();

        // Service mappings
        CreateMap<Domain.Entities.Service, ServiceDto>();
        CreateMap<CreateServiceRequest, Domain.Entities.Service>();
        CreateMap<UpdateServiceRequest, Domain.Entities.Service>();
        CreateMap<Application.UseCases.Core.Services.CreateService.CreateServiceRequest, Domain.Entities.Service>();
        CreateMap<Application.UseCases.Core.Services.UpdateService.UpdateServiceRequest, Domain.Entities.Service>();

        // ServiceHistory mappings
        CreateMap<Domain.Entities.ServiceHistory, ServiceHistoryDto>();
        CreateMap<CreateServiceHistoryRequest, Domain.Entities.ServiceHistory>();
        CreateMap<UpdateServiceHistoryRequest, Domain.Entities.ServiceHistory>();
        CreateMap<Application.UseCases.Core.ServiceHistories.CreateServiceHistory.CreateServiceHistoryRequest, Domain.Entities.ServiceHistory>();
        CreateMap<Application.UseCases.Core.ServiceHistories.UpdateServiceHistory.UpdateServiceHistoryRequest, Domain.Entities.ServiceHistory>();

        // VehicleIssue mappings
        CreateMap<VehicleIssue, VehicleIssueDto>();
        CreateMap<CreateVehicleIssueRequest, VehicleIssue>();
        CreateMap<UpdateVehicleIssueRequest, VehicleIssue>();
        CreateMap<Application.UseCases.Core.VehicleIssues.CreateVehicleIssue.CreateVehicleIssueRequest, VehicleIssue>();
        CreateMap<Application.UseCases.Core.VehicleIssues.UpdateVehicleIssue.UpdateVehicleIssueRequest, VehicleIssue>();

        // DiagnosticRule mappings
        CreateMap<Domain.Entities.DiagnosticRule, DiagnosticRuleDto>();
        CreateMap<CreateDiagnosticRuleRequest, Domain.Entities.DiagnosticRule>();
        CreateMap<UpdateDiagnosticRuleRequest, Domain.Entities.DiagnosticRule>();
        CreateMap<Application.UseCases.Core.DiagnosticRules.CreateDiagnosticRule.CreateDiagnosticRuleRequest, Domain.Entities.DiagnosticRule>();
        CreateMap<Application.UseCases.Core.DiagnosticRules.UpdateDiagnosticRule.UpdateDiagnosticRuleRequest, Domain.Entities.DiagnosticRule>();

        // ImageDiagnostic mappings
        CreateMap<Domain.Entities.ImageDiagnostic, ImageDiagnosticDto>();
        CreateMap<CreateImageDiagnosticRequest, Domain.Entities.ImageDiagnostic>();
        CreateMap<UpdateImageDiagnosticRequest, Domain.Entities.ImageDiagnostic>();
        CreateMap<Application.UseCases.Core.ImageDiagnostics.CreateImageDiagnostic.CreateImageDiagnosticRequest, Domain.Entities.ImageDiagnostic>();
        CreateMap<Application.UseCases.Core.ImageDiagnostics.UpdateImageDiagnostic.UpdateImageDiagnosticRequest, Domain.Entities.ImageDiagnostic>();

        // Chatbot mappings
        CreateMap<ChatbotConversation, ChatbotConversationDto>();
        CreateMap<CreateChatbotConversationRequest, ChatbotConversation>();
        CreateMap<UpdateChatbotConversationRequest, ChatbotConversation>();
        CreateMap<Application.UseCases.Chatbot.ChatbotConversations.CreateChatbotConversation.CreateChatbotConversationRequest, ChatbotConversation>();
        CreateMap<Application.UseCases.Chatbot.ChatbotConversations.UpdateChatbotConversation.UpdateChatbotConversationRequest, ChatbotConversation>();

        CreateMap<ChatbotMessage, ChatbotMessageDto>();
        CreateMap<CreateChatbotMessageRequest, ChatbotMessage>();
        CreateMap<UpdateChatbotMessageRequest, ChatbotMessage>();
        CreateMap<Application.UseCases.Chatbot.ChatbotMessages.CreateChatbotMessage.CreateChatbotMessageRequest, ChatbotMessage>();
        CreateMap<Application.UseCases.Chatbot.ChatbotMessages.UpdateChatbotMessage.UpdateChatbotMessageRequest, ChatbotMessage>();

        CreateMap<ChatbotKnowledgeBase, ChatbotKnowledgeBaseDto>();
        CreateMap<CreateChatbotKnowledgeBaseRequest, ChatbotKnowledgeBase>();
        CreateMap<UpdateChatbotKnowledgeBaseRequest, ChatbotKnowledgeBase>();
        CreateMap<Application.UseCases.Chatbot.ChatbotKnowledgeBases.CreateChatbotKnowledgeBase.CreateChatbotKnowledgeBaseRequest, ChatbotKnowledgeBase>();
        CreateMap<Application.UseCases.Chatbot.ChatbotKnowledgeBases.UpdateChatbotKnowledgeBase.UpdateChatbotKnowledgeBaseRequest, ChatbotKnowledgeBase>();

        CreateMap<AiImageAnalysis, AiImageAnalysisDto>();
        CreateMap<CreateAiImageAnalysisRequest, AiImageAnalysis>();
        CreateMap<UpdateAiImageAnalysisRequest, AiImageAnalysis>();
        CreateMap<Application.UseCases.Chatbot.AiImageAnalyses.CreateAiImageAnalysis.CreateAiImageAnalysisRequest, AiImageAnalysis>();
        CreateMap<Application.UseCases.Chatbot.AiImageAnalyses.UpdateAiImageAnalysis.UpdateAiImageAnalysisRequest, AiImageAnalysis>();

        CreateMap<AiUsageLog, AiUsageLogDto>();
        CreateMap<CreateAiUsageLogRequest, AiUsageLog>();
        CreateMap<UpdateAiUsageLogRequest, AiUsageLog>();
        CreateMap<Application.UseCases.Chatbot.AiUsageLogs.CreateAiUsageLog.CreateAiUsageLogRequest, AiUsageLog>();
        CreateMap<Application.UseCases.Chatbot.AiUsageLogs.UpdateAiUsageLog.UpdateAiUsageLogRequest, AiUsageLog>();
    }
}
