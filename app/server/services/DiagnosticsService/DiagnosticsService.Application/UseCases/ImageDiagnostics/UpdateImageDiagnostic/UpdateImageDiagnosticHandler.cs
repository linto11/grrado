using AutoMapper;
using GRRADO.Shared.Application.Common;
using DiagnosticsService.Application.Abstractions;
using DiagnosticsService.Application.DTOs;
using DiagnosticsService.Domain.Entities;
using MediatR;

namespace DiagnosticsService.Application.UseCases.ImageDiagnostics.UpdateImageDiagnostic;

public class UpdateImageDiagnosticHandler : IRequestHandler<UpdateImageDiagnosticCommand, Result<ImageDiagnosticDto>>
{
    private readonly IDiagnosticsUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateImageDiagnosticHandler(IDiagnosticsUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ImageDiagnosticDto>> Handle(UpdateImageDiagnosticCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ImageDiagnostics.GetByIdAsync(request.Id);
            if (entity == null)
                return Result<ImageDiagnosticDto>.Failure($"ImageDiagnostic with id {request.Id} not found");

            entity.VisualFeature = request.VisualFeature;
            entity.Confidence = request.Confidence;
            entity.LikelyIssue = request.LikelyIssue;
            entity.Urgency = request.Urgency;
            entity.FilePath = request.FilePath;
            entity.ImageType = request.ImageType;
            entity.Description = request.Description;
            entity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.ImageDiagnostics.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<ImageDiagnosticDto>.Success(_mapper.Map<ImageDiagnosticDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<ImageDiagnosticDto>.Failure($"Failed to update image diagnostic: {ex.Message}");
        }
    }
}
