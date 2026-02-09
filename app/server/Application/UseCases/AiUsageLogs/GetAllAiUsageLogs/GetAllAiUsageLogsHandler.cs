using Abstractions.DTOs.AiUsageLog;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.AiUsageLogs.GetAllAiUsageLogs;

public class GetAllAiUsageLogsHandler : IRequestHandler<GetAllAiUsageLogsRequest, Result<PaginatedResult<AiUsageLogDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllAiUsageLogsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<PaginatedResult<AiUsageLogDto>>> Handle(GetAllAiUsageLogsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var pagedResult = await _unitOfWork.AiUsageLogs.GetPagedAsync(request.PageNumber, request.PageSize);
            var dtos = _mapper.Map<List<AiUsageLogDto>>(pagedResult.Items);
            var paginatedResult = new PaginatedResult<AiUsageLogDto>
            {
                Items = dtos,
                TotalCount = pagedResult.TotalCount,
                Skip = pagedResult.Skip,
                Take = pagedResult.Take
            };
            return Result<PaginatedResult<AiUsageLogDto>>.Success(paginatedResult);
        }
        catch (Exception ex)
        {
            return Result<PaginatedResult<AiUsageLogDto>>.Failure($"Failed to retrieve aiUsageLog list: {ex.Message}");
        }
    }
}
