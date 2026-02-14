using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using ChatbotService.Domain.Entities;
using MediatR;

namespace ChatbotService.Application.UseCases.ChatbotConversations.CreateChatbotConversation;

public class CreateChatbotConversationHandler : IRequestHandler<CreateChatbotConversationCommand, Result<ChatbotConversationDto>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateChatbotConversationHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ChatbotConversationDto>> Handle(CreateChatbotConversationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<ChatbotConversation>(request);
            await _unitOfWork.ChatbotConversations.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<ChatbotConversationDto>.Success(_mapper.Map<ChatbotConversationDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<ChatbotConversationDto>.Failure($"Failed to create chatbot conversation: {ex.Message}");
        }
    }
}
