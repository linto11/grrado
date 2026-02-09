using Abstractions.DTOs.ChatbotConversation;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Chatbot.ChatbotConversations.GetAllChatbotConversations;

public class GetAllChatbotConversationsHandler : IRequestHandler<GetAllChatbotConversationsRequest, Result<PaginatedResult<ChatbotConversationDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllChatbotConversationsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<PaginatedResult<ChatbotConversationDto>>> Handle(GetAllChatbotConversationsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var pagedResult = await _unitOfWork.ChatbotConversations.GetPagedAsync(request.PageNumber, request.PageSize);
            var dtos = _mapper.Map<List<ChatbotConversationDto>>(pagedResult.Items);
            var paginatedResult = new PaginatedResult<ChatbotConversationDto>
            {
                Items = dtos,
                TotalCount = pagedResult.TotalCount,
                Skip = pagedResult.Skip,
                Take = pagedResult.Take
            };
            return Result<PaginatedResult<ChatbotConversationDto>>.Success(paginatedResult);
        }
        catch (Exception ex)
        {
            return Result<PaginatedResult<ChatbotConversationDto>>.Failure($"Failed to retrieve chatbotConversation list: {ex.Message}");
        }
    }
}
