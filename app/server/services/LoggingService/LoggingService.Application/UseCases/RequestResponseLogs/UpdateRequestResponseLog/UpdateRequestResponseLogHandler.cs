using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using LoggingService.Domain.Entities;
using MediatR;

namespace LoggingService.Application.UseCases.RequestResponseLogs.UpdateRequestResponseLog;

public class UpdateRequestResponseLogHandler : IRequestHandler<UpdateRequestResponseLogCommand, Result<RequestResponseLogDto>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateRequestResponseLogHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<RequestResponseLogDto>> Handle(UpdateRequestResponseLogCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.RequestResponseLogs.GetByIdAsync(request.Id);
            if (entity == null) return Result<RequestResponseLogDto>.Failure($"RequestResponseLog with id {request.Id} not found");

            entity.RequestId = request.RequestId;
            entity.HttpMethod = request.HttpMethod;
            entity.Endpoint = request.Endpoint;
            entity.QueryString = request.QueryString;
            entity.RequestBody = request.RequestBody;
            entity.ResponseStatusCode = request.ResponseStatusCode;
            entity.ResponseBody = request.ResponseBody;
            entity.ResponseTimeMs = request.ResponseTimeMs;
            entity.UserId = request.UserId;
            entity.IpAddress = request.IpAddress;
            entity.UserAgent = request.UserAgent;
            entity.Metadata = request.Metadata;
            entity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.RequestResponseLogs.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<RequestResponseLogDto>.Success(_mapper.Map<RequestResponseLogDto>(entity));
        }
        catch (Exception ex) { return Result<RequestResponseLogDto>.Failure($"Failed to update request response log: {ex.Message}"); }
    }
}
