using Abstractions.DTOs.AiImageAnalysis;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.AiImageAnalyses.GetAllAiImageAnalyses;

public class GetAllAiImageAnalysesHandler : IRequestHandler<GetAllAiImageAnalysesRequest, Result<PaginatedResult<AiImageAnalysisDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllAiImageAnalysesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<PaginatedResult<AiImageAnalysisDto>>> Handle(GetAllAiImageAnalysesRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var pagedResult = await _unitOfWork.AiImageAnalyses.GetPagedAsync(request.PageNumber, request.PageSize);
            var dtos = _mapper.Map<List<AiImageAnalysisDto>>(pagedResult.Items);
            var paginatedResult = new PaginatedResult<AiImageAnalysisDto>
            {
                Items = dtos,
                TotalCount = pagedResult.TotalCount,
                Skip = pagedResult.Skip,
                Take = pagedResult.Take
            };
            return Result<PaginatedResult<AiImageAnalysisDto>>.Success(paginatedResult);
        }
        catch (Exception ex)
        {
            return Result<PaginatedResult<AiImageAnalysisDto>>.Failure($"Failed to retrieve aiImageAnalysis list: {ex.Message}");
        }
    }
}
