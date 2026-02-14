using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.ErrorLogs.GetErrorLogById;

public class GetErrorLogByIdHandler : IRequestHandler<GetErrorLogByIdQuery, Result<ErrorLogDto>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetErrorLogByIdHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<ErrorLogDto>> Handle(GetErrorLogByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ErrorLogs.GetByIdAsync(request.Id);
            if (entity == null) return Result<ErrorLogDto>.Failure($"ErrorLog with id {request.Id} not found");
            return Result<ErrorLogDto>.Success(_mapper.Map<ErrorLogDto>(entity));
        }
        catch (Exception ex) { return Result<ErrorLogDto>.Failure($"Failed to retrieve error log: {ex.Message}"); }
    }
}
