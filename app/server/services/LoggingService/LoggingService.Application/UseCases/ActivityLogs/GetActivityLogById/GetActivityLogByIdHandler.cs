using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.ActivityLogs.GetActivityLogById;

public class GetActivityLogByIdHandler : IRequestHandler<GetActivityLogByIdQuery, Result<ActivityLogDto>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetActivityLogByIdHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<ActivityLogDto>> Handle(GetActivityLogByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ActivityLogs.GetByIdAsync(request.Id);
            if (entity == null) return Result<ActivityLogDto>.Failure($"ActivityLog with id {request.Id} not found");
            return Result<ActivityLogDto>.Success(_mapper.Map<ActivityLogDto>(entity));
        }
        catch (Exception ex) { return Result<ActivityLogDto>.Failure($"Failed to retrieve activity log: {ex.Message}"); }
    }
}
