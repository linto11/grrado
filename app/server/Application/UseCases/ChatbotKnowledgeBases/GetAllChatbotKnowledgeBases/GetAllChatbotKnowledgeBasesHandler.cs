using Abstractions.DTOs.ChatbotKnowledgeBase;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.ChatbotKnowledgeBases.GetAllChatbotKnowledgeBases;

public class GetAllChatbotKnowledgeBasesHandler : IRequestHandler<GetAllChatbotKnowledgeBasesRequest, Result<PaginatedResult<ChatbotKnowledgeBaseDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllChatbotKnowledgeBasesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<PaginatedResult<ChatbotKnowledgeBaseDto>>> Handle(GetAllChatbotKnowledgeBasesRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var pagedResult = await _unitOfWork.ChatbotKnowledgeBases.GetPagedAsync(request.PageNumber, request.PageSize);
            var dtos = _mapper.Map<List<ChatbotKnowledgeBaseDto>>(pagedResult.Items);
            var paginatedResult = new PaginatedResult<ChatbotKnowledgeBaseDto>
            {
                Items = dtos,
                TotalCount = pagedResult.TotalCount,
                Skip = pagedResult.Skip,
                Take = pagedResult.Take
            };
            return Result<PaginatedResult<ChatbotKnowledgeBaseDto>>.Success(paginatedResult);
        }
        catch (Exception ex)
        {
            return Result<PaginatedResult<ChatbotKnowledgeBaseDto>>.Failure($"Failed to retrieve chatbotKnowledgeBase list: {ex.Message}");
        }
    }
}
