using AutoMapper;
using ChatbotService.Application.DTOs;
using ChatbotService.Application.UseCases.ChatbotConversations.CreateChatbotConversation;
using ChatbotService.Application.UseCases.ChatbotConversations.UpdateChatbotConversation;
using ChatbotService.Application.UseCases.ChatbotMessages.CreateChatbotMessage;
using ChatbotService.Application.UseCases.ChatbotMessages.UpdateChatbotMessage;
using ChatbotService.Application.UseCases.AiImageAnalyses.CreateAiImageAnalysis;
using ChatbotService.Application.UseCases.AiImageAnalyses.UpdateAiImageAnalysis;
using ChatbotService.Application.UseCases.ChatbotKnowledgeBases.CreateChatbotKnowledgeBase;
using ChatbotService.Application.UseCases.ChatbotKnowledgeBases.UpdateChatbotKnowledgeBase;
using ChatbotService.Application.UseCases.AiUsageLogs.CreateAiUsageLog;
using ChatbotService.Application.UseCases.AiUsageLogs.UpdateAiUsageLog;
using ChatbotService.Domain.Entities;

namespace ChatbotService.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ChatbotConversation, ChatbotConversationDto>();
        CreateMap<CreateChatbotConversationCommand, ChatbotConversation>();
        CreateMap<UpdateChatbotConversationCommand, ChatbotConversation>();

        CreateMap<ChatbotMessage, ChatbotMessageDto>();
        CreateMap<CreateChatbotMessageCommand, ChatbotMessage>();
        CreateMap<UpdateChatbotMessageCommand, ChatbotMessage>();

        CreateMap<AiImageAnalysis, AiImageAnalysisDto>();
        CreateMap<CreateAiImageAnalysisCommand, AiImageAnalysis>();
        CreateMap<UpdateAiImageAnalysisCommand, AiImageAnalysis>();

        CreateMap<ChatbotKnowledgeBase, ChatbotKnowledgeBaseDto>();
        CreateMap<CreateChatbotKnowledgeBaseCommand, ChatbotKnowledgeBase>();
        CreateMap<UpdateChatbotKnowledgeBaseCommand, ChatbotKnowledgeBase>();

        CreateMap<AiUsageLog, AiUsageLogDto>();
        CreateMap<CreateAiUsageLogCommand, AiUsageLog>();
        CreateMap<UpdateAiUsageLogCommand, AiUsageLog>();
    }
}
