using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChatbotService.Application.UseCases.ChatbotKnowledgeBases.GetAllChatbotKnowledgeBases;

public class GetAllChatbotKnowledgeBasesHandler : IRequestHandler<GetAllChatbotKnowledgeBasesQuery, Result<List<ChatbotKnowledgeBaseDto>>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllChatbotKnowledgeBasesHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<List<ChatbotKnowledgeBaseDto>>> Handle(GetAllChatbotKnowledgeBasesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await _unitOfWork.ChatbotKnowledgeBases.GetAll()
                .Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
            return Result<List<ChatbotKnowledgeBaseDto>>.Success(_mapper.Map<List<ChatbotKnowledgeBaseDto>>(entities));
        }
        catch (Exception ex) { return Result<List<ChatbotKnowledgeBaseDto>>.Failure($"Failed to get knowledge base entries: {ex.Message}"); }
    }
}
