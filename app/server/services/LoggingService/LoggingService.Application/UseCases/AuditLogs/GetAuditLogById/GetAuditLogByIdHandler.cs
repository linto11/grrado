using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.AuditLogs.GetAuditLogById;

public class GetAuditLogByIdHandler : IRequestHandler<GetAuditLogByIdQuery, Result<AuditLogDto>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAuditLogByIdHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<AuditLogDto>> Handle(GetAuditLogByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.AuditLogs.GetByIdAsync(request.Id);
            if (entity == null) return Result<AuditLogDto>.Failure($"AuditLog with id {request.Id} not found");
            return Result<AuditLogDto>.Success(_mapper.Map<AuditLogDto>(entity));
        }
        catch (Exception ex) { return Result<AuditLogDto>.Failure($"Failed to retrieve audit log: {ex.Message}"); }
    }
}
