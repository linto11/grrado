using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using LoggingService.Domain.Entities;
using MediatR;

namespace LoggingService.Application.UseCases.ActivityLogs.CreateActivityLog;

public class CreateActivityLogHandler : IRequestHandler<CreateActivityLogCommand, Result<ActivityLogDto>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateActivityLogHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<ActivityLogDto>> Handle(CreateActivityLogCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<ActivityLog>(request);
            await _unitOfWork.ActivityLogs.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<ActivityLogDto>.Success(_mapper.Map<ActivityLogDto>(entity));
        }
        catch (Exception ex) { return Result<ActivityLogDto>.Failure($"Failed to create activity log: {ex.Message}"); }
    }
}
