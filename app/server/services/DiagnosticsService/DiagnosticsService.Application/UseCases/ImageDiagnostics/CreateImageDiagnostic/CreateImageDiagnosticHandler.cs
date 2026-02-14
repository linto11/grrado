using AutoMapper;
using GRRADO.Shared.Application.Common;
using DiagnosticsService.Application.Abstractions;
using DiagnosticsService.Application.DTOs;
using DiagnosticsService.Domain.Entities;
using MediatR;

namespace DiagnosticsService.Application.UseCases.ImageDiagnostics.CreateImageDiagnostic;

public class CreateImageDiagnosticHandler : IRequestHandler<CreateImageDiagnosticCommand, Result<ImageDiagnosticDto>>
{
    private readonly IDiagnosticsUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateImageDiagnosticHandler(IDiagnosticsUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ImageDiagnosticDto>> Handle(CreateImageDiagnosticCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<ImageDiagnostic>(request);
            await _unitOfWork.ImageDiagnostics.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<ImageDiagnosticDto>.Success(_mapper.Map<ImageDiagnosticDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<ImageDiagnosticDto>.Failure($"Failed to create image diagnostic: {ex.Message}");
        }
    }
}
