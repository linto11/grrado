using AutoMapper;
using GRRADO.Shared.Application.Common;
using DiagnosticsService.Application.Abstractions;
using DiagnosticsService.Application.DTOs;
using MediatR;

namespace DiagnosticsService.Application.UseCases.ImageDiagnostics.GetImageDiagnosticById;

public class GetImageDiagnosticByIdHandler : IRequestHandler<GetImageDiagnosticByIdQuery, Result<ImageDiagnosticDto>>
{
    private readonly IDiagnosticsUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetImageDiagnosticByIdHandler(IDiagnosticsUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ImageDiagnosticDto>> Handle(GetImageDiagnosticByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ImageDiagnostics.GetByIdAsync(request.Id);
            if (entity == null)
                return Result<ImageDiagnosticDto>.Failure($"ImageDiagnostic with id {request.Id} not found");
            return Result<ImageDiagnosticDto>.Success(_mapper.Map<ImageDiagnosticDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<ImageDiagnosticDto>.Failure($"Failed to get image diagnostic: {ex.Message}");
        }
    }
}
