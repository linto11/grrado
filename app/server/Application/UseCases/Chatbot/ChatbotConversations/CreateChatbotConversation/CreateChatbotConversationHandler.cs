using Abstractions.DTOs.ChatbotConversation;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Chatbot.ChatbotConversations.CreateChatbotConversation;

public class CreateChatbotConversationHandler : IRequestHandler<CreateChatbotConversationRequest, Result<ChatbotConversationDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateChatbotConversationHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ChatbotConversationDto>> Handle(CreateChatbotConversationRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<ChatbotConversation>(request);
            await _unitOfWork.ChatbotConversations.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<ChatbotConversationDto>(entity);
            return Result<ChatbotConversationDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<ChatbotConversationDto>.Failure($"Failed to create chatbotConversation: {ex.Message}");
        }
    }
}
