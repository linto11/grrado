using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoggingService.Application.UseCases.ActivityLogs.GetAllActivityLogs;

public class GetAllActivityLogsHandler : IRequestHandler<GetAllActivityLogsQuery, Result<List<ActivityLogDto>>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllActivityLogsHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<List<ActivityLogDto>>> Handle(GetAllActivityLogsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await _unitOfWork.ActivityLogs.GetAll()
                .Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
            return Result<List<ActivityLogDto>>.Success(_mapper.Map<List<ActivityLogDto>>(entities));
        }
        catch (Exception ex) { return Result<List<ActivityLogDto>>.Failure($"Failed to retrieve activity logs: {ex.Message}"); }
    }
}
