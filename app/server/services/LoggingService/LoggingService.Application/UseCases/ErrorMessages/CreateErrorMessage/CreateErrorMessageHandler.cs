using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using LoggingService.Domain.Entities;
using MediatR;

namespace LoggingService.Application.UseCases.ErrorMessages.CreateErrorMessage;

public class CreateErrorMessageHandler : IRequestHandler<CreateErrorMessageCommand, Result<ErrorMessageDto>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateErrorMessageHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<ErrorMessageDto>> Handle(CreateErrorMessageCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<ErrorMessage>(request);
            await _unitOfWork.ErrorMessages.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<ErrorMessageDto>.Success(_mapper.Map<ErrorMessageDto>(entity));
        }
        catch (Exception ex) { return Result<ErrorMessageDto>.Failure($"Failed to create error message: {ex.Message}"); }
    }
}
