using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChatbotService.Application.UseCases.AiUsageLogs.GetAllAiUsageLogs;

public class GetAllAiUsageLogsHandler : IRequestHandler<GetAllAiUsageLogsQuery, Result<List<AiUsageLogDto>>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllAiUsageLogsHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<List<AiUsageLogDto>>> Handle(GetAllAiUsageLogsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await _unitOfWork.AiUsageLogs.GetAll()
                .Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
            return Result<List<AiUsageLogDto>>.Success(_mapper.Map<List<AiUsageLogDto>>(entities));
        }
        catch (Exception ex) { return Result<List<AiUsageLogDto>>.Failure($"Failed to retrieve AI usage logs: {ex.Message}"); }
    }
}
