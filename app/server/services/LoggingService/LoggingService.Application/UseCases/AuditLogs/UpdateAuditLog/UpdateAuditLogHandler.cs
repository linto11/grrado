using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using LoggingService.Domain.Entities;
using MediatR;

namespace LoggingService.Application.UseCases.AuditLogs.UpdateAuditLog;

public class UpdateAuditLogHandler : IRequestHandler<UpdateAuditLogCommand, Result<AuditLogDto>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateAuditLogHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<AuditLogDto>> Handle(UpdateAuditLogCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.AuditLogs.GetByIdAsync(request.Id);
            if (entity == null) return Result<AuditLogDto>.Failure($"AuditLog with id {request.Id} not found");

            entity.EntityType = request.EntityType;
            entity.EntityId = request.EntityId;
            entity.Action = request.Action;
            entity.OldValues = request.OldValues;
            entity.NewValues = request.NewValues;
            entity.ChangedFields = request.ChangedFields;
            entity.UserId = request.UserId;
            entity.PerformedBy = request.PerformedBy;
            entity.IpAddress = request.IpAddress;
            entity.UserAgent = request.UserAgent;
            entity.Metadata = request.Metadata;
            entity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.AuditLogs.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<AuditLogDto>.Success(_mapper.Map<AuditLogDto>(entity));
        }
        catch (Exception ex) { return Result<AuditLogDto>.Failure($"Failed to update audit log: {ex.Message}"); }
    }
}
