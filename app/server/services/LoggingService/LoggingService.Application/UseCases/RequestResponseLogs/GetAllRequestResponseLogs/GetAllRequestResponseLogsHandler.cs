using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoggingService.Application.UseCases.RequestResponseLogs.GetAllRequestResponseLogs;

public class GetAllRequestResponseLogsHandler : IRequestHandler<GetAllRequestResponseLogsQuery, Result<List<RequestResponseLogDto>>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllRequestResponseLogsHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<List<RequestResponseLogDto>>> Handle(GetAllRequestResponseLogsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await _unitOfWork.RequestResponseLogs.GetAll()
                .Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
            return Result<List<RequestResponseLogDto>>.Success(_mapper.Map<List<RequestResponseLogDto>>(entities));
        }
        catch (Exception ex) { return Result<List<RequestResponseLogDto>>.Failure($"Failed to retrieve request response logs: {ex.Message}"); }
    }
}
