using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using LoggingService.Domain.Entities;
using MediatR;

namespace LoggingService.Application.UseCases.RequestResponseLogs.CreateRequestResponseLog;

public class CreateRequestResponseLogHandler : IRequestHandler<CreateRequestResponseLogCommand, Result<RequestResponseLogDto>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateRequestResponseLogHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<RequestResponseLogDto>> Handle(CreateRequestResponseLogCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<RequestResponseLog>(request);
            await _unitOfWork.RequestResponseLogs.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<RequestResponseLogDto>.Success(_mapper.Map<RequestResponseLogDto>(entity));
        }
        catch (Exception ex) { return Result<RequestResponseLogDto>.Failure($"Failed to create request response log: {ex.Message}"); }
    }
}
