using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoggingService.Application.UseCases.ErrorLogs.GetAllErrorLogs;

public class GetAllErrorLogsHandler : IRequestHandler<GetAllErrorLogsQuery, Result<List<ErrorLogDto>>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllErrorLogsHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<List<ErrorLogDto>>> Handle(GetAllErrorLogsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await _unitOfWork.ErrorLogs.GetAll()
                .Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
            return Result<List<ErrorLogDto>>.Success(_mapper.Map<List<ErrorLogDto>>(entities));
        }
        catch (Exception ex) { return Result<List<ErrorLogDto>>.Failure($"Failed to retrieve error logs: {ex.Message}"); }
    }
}
