using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using MediatR;

namespace ChatbotService.Application.UseCases.ChatbotMessages.GetChatbotMessageById;

public class GetChatbotMessageByIdHandler : IRequestHandler<GetChatbotMessageByIdQuery, Result<ChatbotMessageDto>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetChatbotMessageByIdHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<ChatbotMessageDto>> Handle(GetChatbotMessageByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ChatbotMessages.GetByIdAsync(request.Id);
            if (entity == null) return Result<ChatbotMessageDto>.Failure($"ChatbotMessage with id {request.Id} not found");
            return Result<ChatbotMessageDto>.Success(_mapper.Map<ChatbotMessageDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<ChatbotMessageDto>.Failure($"Failed to get chatbot message: {ex.Message}");
        }
    }
}
