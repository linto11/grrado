using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoggingService.Application.UseCases.ErrorMessages.GetAllErrorMessages;

public class GetAllErrorMessagesHandler : IRequestHandler<GetAllErrorMessagesQuery, Result<List<ErrorMessageDto>>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllErrorMessagesHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<List<ErrorMessageDto>>> Handle(GetAllErrorMessagesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await _unitOfWork.ErrorMessages.GetAll()
                .Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
            return Result<List<ErrorMessageDto>>.Success(_mapper.Map<List<ErrorMessageDto>>(entities));
        }
        catch (Exception ex) { return Result<List<ErrorMessageDto>>.Failure($"Failed to retrieve error messages: {ex.Message}"); }
    }
}
