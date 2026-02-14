using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using LoggingService.Domain.Entities;
using MediatR;

namespace LoggingService.Application.UseCases.ErrorLogs.UpdateErrorLog;

public class UpdateErrorLogHandler : IRequestHandler<UpdateErrorLogCommand, Result<ErrorLogDto>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateErrorLogHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<ErrorLogDto>> Handle(UpdateErrorLogCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ErrorLogs.GetByIdAsync(request.Id);
            if (entity == null) return Result<ErrorLogDto>.Failure($"ErrorLog with id {request.Id} not found");

            entity.ErrorCode = request.ErrorCode;
            entity.ErrorMessage = request.ErrorMessage;
            entity.StackTrace = request.StackTrace;
            entity.InnerException = request.InnerException;
            entity.Source = request.Source;
            entity.Severity = request.Severity;
            entity.UserId = request.UserId;
            entity.RequestId = request.RequestId;
            entity.IpAddress = request.IpAddress;
            entity.UserAgent = request.UserAgent;
            entity.Metadata = request.Metadata;
            entity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.ErrorLogs.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<ErrorLogDto>.Success(_mapper.Map<ErrorLogDto>(entity));
        }
        catch (Exception ex) { return Result<ErrorLogDto>.Failure($"Failed to update error log: {ex.Message}"); }
    }
}
