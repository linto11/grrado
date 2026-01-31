using Abstractions.DTOs.ChatbotMessage;
using Abstractions.Persistence;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Chatbot;

public interface IChatbotMessageService : IBaseService<ChatbotMessage, ChatbotMessageDto, CreateChatbotMessageRequest, UpdateChatbotMessageRequest>
{
}

public class ChatbotMessageService : BaseService<ChatbotMessage, ChatbotMessageDto, CreateChatbotMessageRequest, UpdateChatbotMessageRequest>, IChatbotMessageService
{
    public ChatbotMessageService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    protected override IRepository<ChatbotMessage> GetRepository() => _unitOfWork.ChatbotMessages;}
