using Abstractions.DTOs.ChatbotKnowledgeBase;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.ChatbotKnowledgeBases.UpdateChatbotKnowledgeBase;

public class UpdateChatbotKnowledgeBaseHandler : IRequestHandler<UpdateChatbotKnowledgeBaseRequest, Result<ChatbotKnowledgeBaseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateChatbotKnowledgeBaseHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ChatbotKnowledgeBaseDto>> Handle(UpdateChatbotKnowledgeBaseRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ChatbotKnowledgeBases.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<ChatbotKnowledgeBaseDto>.Failure($"ChatbotKnowledgeBase with ID {request.Id} not found");
            }
            _mapper.Map(request, entity);
            await _unitOfWork.ChatbotKnowledgeBases.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<ChatbotKnowledgeBaseDto>(entity);
            return Result<ChatbotKnowledgeBaseDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<ChatbotKnowledgeBaseDto>.Failure($"Failed to update chatbotKnowledgeBase: {ex.Message}");
        }
    }
}
