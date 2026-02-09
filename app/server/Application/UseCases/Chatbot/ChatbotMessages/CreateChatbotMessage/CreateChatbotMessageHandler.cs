using Abstractions.DTOs.ChatbotMessage;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Chatbot.ChatbotMessages.CreateChatbotMessage;

public class CreateChatbotMessageHandler : IRequestHandler<CreateChatbotMessageRequest, Result<ChatbotMessageDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateChatbotMessageHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ChatbotMessageDto>> Handle(CreateChatbotMessageRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<ChatbotMessage>(request);
            await _unitOfWork.ChatbotMessages.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<ChatbotMessageDto>(entity);
            return Result<ChatbotMessageDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<ChatbotMessageDto>.Failure($"Failed to create chatbotMessage: {ex.Message}");
        }
    }
}
