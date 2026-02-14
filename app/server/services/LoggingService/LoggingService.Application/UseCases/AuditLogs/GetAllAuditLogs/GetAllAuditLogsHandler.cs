using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoggingService.Application.UseCases.AuditLogs.GetAllAuditLogs;

public class GetAllAuditLogsHandler : IRequestHandler<GetAllAuditLogsQuery, Result<List<AuditLogDto>>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllAuditLogsHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<List<AuditLogDto>>> Handle(GetAllAuditLogsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await _unitOfWork.AuditLogs.GetAll()
                .Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
            return Result<List<AuditLogDto>>.Success(_mapper.Map<List<AuditLogDto>>(entities));
        }
        catch (Exception ex) { return Result<List<AuditLogDto>>.Failure($"Failed to retrieve audit logs: {ex.Message}"); }
    }
}
