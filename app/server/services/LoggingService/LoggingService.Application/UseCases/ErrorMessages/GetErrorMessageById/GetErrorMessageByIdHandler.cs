using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.ErrorMessages.GetErrorMessageById;

public class GetErrorMessageByIdHandler : IRequestHandler<GetErrorMessageByIdQuery, Result<ErrorMessageDto>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetErrorMessageByIdHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<ErrorMessageDto>> Handle(GetErrorMessageByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ErrorMessages.GetByIdAsync(request.Id);
            if (entity == null) return Result<ErrorMessageDto>.Failure($"ErrorMessage with id {request.Id} not found");
            return Result<ErrorMessageDto>.Success(_mapper.Map<ErrorMessageDto>(entity));
        }
        catch (Exception ex) { return Result<ErrorMessageDto>.Failure($"Failed to retrieve error message: {ex.Message}"); }
    }
}
