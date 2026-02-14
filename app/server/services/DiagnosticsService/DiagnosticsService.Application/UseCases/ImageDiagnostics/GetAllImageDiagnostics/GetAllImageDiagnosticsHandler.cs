using AutoMapper;
using GRRADO.Shared.Application.Common;
using DiagnosticsService.Application.Abstractions;
using DiagnosticsService.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiagnosticsService.Application.UseCases.ImageDiagnostics.GetAllImageDiagnostics;

public class GetAllImageDiagnosticsHandler : IRequestHandler<GetAllImageDiagnosticsQuery, Result<List<ImageDiagnosticDto>>>
{
    private readonly IDiagnosticsUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllImageDiagnosticsHandler(IDiagnosticsUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<ImageDiagnosticDto>>> Handle(GetAllImageDiagnosticsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await _unitOfWork.ImageDiagnostics.GetAll()
                .Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
            var dtos = _mapper.Map<List<ImageDiagnosticDto>>(entities);
            return Result<List<ImageDiagnosticDto>>.Success(dtos);
        }
        catch (Exception ex)
        {
            return Result<List<ImageDiagnosticDto>>.Failure($"Failed to get image diagnostics: {ex.Message}");
        }
    }
}
