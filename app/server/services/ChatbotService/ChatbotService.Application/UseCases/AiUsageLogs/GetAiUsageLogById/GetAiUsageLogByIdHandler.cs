using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using MediatR;

namespace ChatbotService.Application.UseCases.AiUsageLogs.GetAiUsageLogById;

public class GetAiUsageLogByIdHandler : IRequestHandler<GetAiUsageLogByIdQuery, Result<AiUsageLogDto>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAiUsageLogByIdHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<AiUsageLogDto>> Handle(GetAiUsageLogByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.AiUsageLogs.GetByIdAsync(request.Id);
            if (entity == null) return Result<AiUsageLogDto>.Failure($"AiUsageLog with id {request.Id} not found");
            return Result<AiUsageLogDto>.Success(_mapper.Map<AiUsageLogDto>(entity));
        }
        catch (Exception ex) { return Result<AiUsageLogDto>.Failure($"Failed to retrieve AI usage log: {ex.Message}"); }
    }
}
