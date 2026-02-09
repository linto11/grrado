using Abstractions.DTOs.ChatbotMessage;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.ChatbotMessages.UpdateChatbotMessage;

public class UpdateChatbotMessageHandler : IRequestHandler<UpdateChatbotMessageRequest, Result<ChatbotMessageDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateChatbotMessageHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ChatbotMessageDto>> Handle(UpdateChatbotMessageRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ChatbotMessages.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<ChatbotMessageDto>.Failure($"ChatbotMessage with ID {request.Id} not found");
            }
            _mapper.Map(request, entity);
            await _unitOfWork.ChatbotMessages.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<ChatbotMessageDto>(entity);
            return Result<ChatbotMessageDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<ChatbotMessageDto>.Failure($"Failed to update chatbotMessage: {ex.Message}");
        }
    }
}
