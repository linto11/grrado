using Abstractions.DTOs.ChatbotKnowledgeBase;
using Abstractions.Persistence;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Chatbot;

public interface IChatbotKnowledgeBaseService : IBaseService<ChatbotKnowledgeBase, ChatbotKnowledgeBaseDto, CreateChatbotKnowledgeBaseRequest, UpdateChatbotKnowledgeBaseRequest>
{
}

public class ChatbotKnowledgeBaseService : BaseService<ChatbotKnowledgeBase, ChatbotKnowledgeBaseDto, CreateChatbotKnowledgeBaseRequest, UpdateChatbotKnowledgeBaseRequest>, IChatbotKnowledgeBaseService
{
    public ChatbotKnowledgeBaseService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    protected override IRepository<ChatbotKnowledgeBase> GetRepository() => _unitOfWork.ChatbotKnowledgeBases;}
