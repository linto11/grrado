using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using ChatbotService.Domain.Entities;
using MediatR;

namespace ChatbotService.Application.UseCases.ChatbotMessages.CreateChatbotMessage;

public class CreateChatbotMessageHandler : IRequestHandler<CreateChatbotMessageCommand, Result<ChatbotMessageDto>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateChatbotMessageHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<ChatbotMessageDto>> Handle(CreateChatbotMessageCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<ChatbotMessage>(request);
            await _unitOfWork.ChatbotMessages.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<ChatbotMessageDto>.Success(_mapper.Map<ChatbotMessageDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<ChatbotMessageDto>.Failure($"Failed to create chatbot message: {ex.Message}");
        }
    }
}
