using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using LoggingService.Domain.Entities;
using MediatR;

namespace LoggingService.Application.UseCases.ActivityLogs.UpdateActivityLog;

public class UpdateActivityLogHandler : IRequestHandler<UpdateActivityLogCommand, Result<ActivityLogDto>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateActivityLogHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<ActivityLogDto>> Handle(UpdateActivityLogCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ActivityLogs.GetByIdAsync(request.Id);
            if (entity == null) return Result<ActivityLogDto>.Failure($"ActivityLog with id {request.Id} not found");

            entity.UserId = request.UserId;
            entity.ActivityType = request.ActivityType;
            entity.Description = request.Description;
            entity.ResourceType = request.ResourceType;
            entity.ResourceId = request.ResourceId;
            entity.IpAddress = request.IpAddress;
            entity.UserAgent = request.UserAgent;
            entity.Metadata = request.Metadata;
            entity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.ActivityLogs.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<ActivityLogDto>.Success(_mapper.Map<ActivityLogDto>(entity));
        }
        catch (Exception ex) { return Result<ActivityLogDto>.Failure($"Failed to update activity log: {ex.Message}"); }
    }
}
