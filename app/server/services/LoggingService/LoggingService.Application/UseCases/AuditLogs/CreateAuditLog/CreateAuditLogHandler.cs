using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using LoggingService.Domain.Entities;
using MediatR;

namespace LoggingService.Application.UseCases.AuditLogs.CreateAuditLog;

public class CreateAuditLogHandler : IRequestHandler<CreateAuditLogCommand, Result<AuditLogDto>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateAuditLogHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<AuditLogDto>> Handle(CreateAuditLogCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<AuditLog>(request);
            await _unitOfWork.AuditLogs.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<AuditLogDto>.Success(_mapper.Map<AuditLogDto>(entity));
        }
        catch (Exception ex) { return Result<AuditLogDto>.Failure($"Failed to create audit log: {ex.Message}"); }
    }
}
