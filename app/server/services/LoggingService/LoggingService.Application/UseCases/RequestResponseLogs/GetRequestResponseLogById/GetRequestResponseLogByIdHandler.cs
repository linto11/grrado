using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.RequestResponseLogs.GetRequestResponseLogById;

public class GetRequestResponseLogByIdHandler : IRequestHandler<GetRequestResponseLogByIdQuery, Result<RequestResponseLogDto>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetRequestResponseLogByIdHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<RequestResponseLogDto>> Handle(GetRequestResponseLogByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.RequestResponseLogs.GetByIdAsync(request.Id);
            if (entity == null) return Result<RequestResponseLogDto>.Failure($"RequestResponseLog with id {request.Id} not found");
            return Result<RequestResponseLogDto>.Success(_mapper.Map<RequestResponseLogDto>(entity));
        }
        catch (Exception ex) { return Result<RequestResponseLogDto>.Failure($"Failed to retrieve request response log: {ex.Message}"); }
    }
}
