using Abstractions.DTOs.ChatbotMessage;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.ChatbotMessages.GetAllChatbotMessages;

public class GetAllChatbotMessagesHandler : IRequestHandler<GetAllChatbotMessagesRequest, Result<PaginatedResult<ChatbotMessageDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllChatbotMessagesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<PaginatedResult<ChatbotMessageDto>>> Handle(GetAllChatbotMessagesRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var pagedResult = await _unitOfWork.ChatbotMessages.GetPagedAsync(request.PageNumber, request.PageSize);
            var dtos = _mapper.Map<List<ChatbotMessageDto>>(pagedResult.Items);
            var paginatedResult = new PaginatedResult<ChatbotMessageDto>
            {
                Items = dtos,
                TotalCount = pagedResult.TotalCount,
                Skip = pagedResult.Skip,
                Take = pagedResult.Take
            };
            return Result<PaginatedResult<ChatbotMessageDto>>.Success(paginatedResult);
        }
        catch (Exception ex)
        {
            return Result<PaginatedResult<ChatbotMessageDto>>.Failure($"Failed to retrieve chatbotMessage list: {ex.Message}");
        }
    }
}
