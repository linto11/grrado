using Abstractions.DTOs.ChatbotMessage;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.ChatbotMessages.GetChatbotMessageById;

public class GetChatbotMessageByIdHandler : IRequestHandler<GetChatbotMessageByIdRequest, Result<ChatbotMessageDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetChatbotMessageByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ChatbotMessageDto>> Handle(GetChatbotMessageByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ChatbotMessages.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<ChatbotMessageDto>.Failure($"ChatbotMessage with ID {request.Id} not found");
            }
            var dto = _mapper.Map<ChatbotMessageDto>(entity);
            return Result<ChatbotMessageDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<ChatbotMessageDto>.Failure($"Failed to retrieve chatbotMessage: {ex.Message}");
        }
    }
}
