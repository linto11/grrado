using Abstractions.DTOs.ChatbotKnowledgeBase;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.ChatbotKnowledgeBases.CreateChatbotKnowledgeBase;

public class CreateChatbotKnowledgeBaseHandler : IRequestHandler<CreateChatbotKnowledgeBaseRequest, Result<ChatbotKnowledgeBaseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateChatbotKnowledgeBaseHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ChatbotKnowledgeBaseDto>> Handle(CreateChatbotKnowledgeBaseRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<ChatbotKnowledgeBase>(request);
            await _unitOfWork.ChatbotKnowledgeBases.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<ChatbotKnowledgeBaseDto>(entity);
            return Result<ChatbotKnowledgeBaseDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<ChatbotKnowledgeBaseDto>.Failure($"Failed to create chatbotKnowledgeBase: {ex.Message}");
        }
    }
}
