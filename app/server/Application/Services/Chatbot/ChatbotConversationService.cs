using Abstractions.DTOs.ChatbotConversation;
using Abstractions.Persistence;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Chatbot;

public interface IChatbotConversationService : IBaseService<ChatbotConversation, ChatbotConversationDto, CreateChatbotConversationRequest, UpdateChatbotConversationRequest>
{
}

public class ChatbotConversationService : BaseService<ChatbotConversation, ChatbotConversationDto, CreateChatbotConversationRequest, UpdateChatbotConversationRequest>, IChatbotConversationService
{
    public ChatbotConversationService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    protected override IRepository<ChatbotConversation> GetRepository() => _unitOfWork.ChatbotConversations;}
