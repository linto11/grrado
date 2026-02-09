using Abstractions.DTOs.ChatbotConversation;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.ChatbotConversations.UpdateChatbotConversation;

public class UpdateChatbotConversationHandler : IRequestHandler<UpdateChatbotConversationRequest, Result<ChatbotConversationDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateChatbotConversationHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ChatbotConversationDto>> Handle(UpdateChatbotConversationRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ChatbotConversations.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<ChatbotConversationDto>.Failure($"ChatbotConversation with ID {request.Id} not found");
            }
            _mapper.Map(request, entity);
            await _unitOfWork.ChatbotConversations.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<ChatbotConversationDto>(entity);
            return Result<ChatbotConversationDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<ChatbotConversationDto>.Failure($"Failed to update chatbotConversation: {ex.Message}");
        }
    }
}
