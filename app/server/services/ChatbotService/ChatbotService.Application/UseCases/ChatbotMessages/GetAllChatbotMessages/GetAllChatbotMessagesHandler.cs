using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChatbotService.Application.UseCases.ChatbotMessages.GetAllChatbotMessages;

public class GetAllChatbotMessagesHandler : IRequestHandler<GetAllChatbotMessagesQuery, Result<List<ChatbotMessageDto>>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllChatbotMessagesHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<List<ChatbotMessageDto>>> Handle(GetAllChatbotMessagesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await _unitOfWork.ChatbotMessages.GetAll()
                .Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
            return Result<List<ChatbotMessageDto>>.Success(_mapper.Map<List<ChatbotMessageDto>>(entities));
        }
        catch (Exception ex)
        {
            return Result<List<ChatbotMessageDto>>.Failure($"Failed to get chatbot messages: {ex.Message}");
        }
    }
}
