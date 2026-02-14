using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChatbotService.Application.UseCases.ChatbotConversations.GetAllChatbotConversations;

public class GetAllChatbotConversationsHandler : IRequestHandler<GetAllChatbotConversationsQuery, Result<List<ChatbotConversationDto>>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllChatbotConversationsHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<ChatbotConversationDto>>> Handle(GetAllChatbotConversationsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await _unitOfWork.ChatbotConversations.GetAll()
                .Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
            return Result<List<ChatbotConversationDto>>.Success(_mapper.Map<List<ChatbotConversationDto>>(entities));
        }
        catch (Exception ex)
        {
            return Result<List<ChatbotConversationDto>>.Failure($"Failed to get chatbot conversations: {ex.Message}");
        }
    }
}
