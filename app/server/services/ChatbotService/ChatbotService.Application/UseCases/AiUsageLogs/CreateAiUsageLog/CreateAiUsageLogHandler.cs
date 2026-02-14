using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using ChatbotService.Domain.Entities;
using MediatR;

namespace ChatbotService.Application.UseCases.AiUsageLogs.CreateAiUsageLog;

public class CreateAiUsageLogHandler : IRequestHandler<CreateAiUsageLogCommand, Result<AiUsageLogDto>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateAiUsageLogHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<AiUsageLogDto>> Handle(CreateAiUsageLogCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<AiUsageLog>(request);
            await _unitOfWork.AiUsageLogs.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<AiUsageLogDto>.Success(_mapper.Map<AiUsageLogDto>(entity));
        }
        catch (Exception ex) { return Result<AiUsageLogDto>.Failure($"Failed to create AI usage log: {ex.Message}"); }
    }
}
