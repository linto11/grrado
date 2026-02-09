using Abstractions.DTOs.ImageDiagnostic;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.ImageDiagnostics.GetAllImageDiagnostics;

public class GetAllImageDiagnosticsHandler : IRequestHandler<GetAllImageDiagnosticsRequest, Result<PaginatedResult<ImageDiagnosticDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllImageDiagnosticsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<PaginatedResult<ImageDiagnosticDto>>> Handle(GetAllImageDiagnosticsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var pagedResult = await _unitOfWork.ImageDiagnostics.GetPagedAsync(request.PageNumber, request.PageSize);
            var dtos = _mapper.Map<List<ImageDiagnosticDto>>(pagedResult.Items);
            var paginatedResult = new PaginatedResult<ImageDiagnosticDto>
            {
                Items = dtos,
                TotalCount = pagedResult.TotalCount,
                Skip = pagedResult.Skip,
                Take = pagedResult.Take
            };
            return Result<PaginatedResult<ImageDiagnosticDto>>.Success(paginatedResult);
        }
        catch (Exception ex)
        {
            return Result<PaginatedResult<ImageDiagnosticDto>>.Failure($"Failed to retrieve imageDiagnostic list: {ex.Message}");
        }
    }
}
