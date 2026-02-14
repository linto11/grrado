using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using LoggingService.Domain.Entities;
using MediatR;

namespace LoggingService.Application.UseCases.ErrorLogs.CreateErrorLog;

public class CreateErrorLogHandler : IRequestHandler<CreateErrorLogCommand, Result<ErrorLogDto>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateErrorLogHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<ErrorLogDto>> Handle(CreateErrorLogCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<ErrorLog>(request);
            await _unitOfWork.ErrorLogs.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<ErrorLogDto>.Success(_mapper.Map<ErrorLogDto>(entity));
        }
        catch (Exception ex) { return Result<ErrorLogDto>.Failure($"Failed to create error log: {ex.Message}"); }
    }
}
