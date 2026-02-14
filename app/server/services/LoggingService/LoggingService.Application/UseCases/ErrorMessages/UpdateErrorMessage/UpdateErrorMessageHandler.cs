using AutoMapper;
using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using LoggingService.Application.DTOs;
using LoggingService.Domain.Entities;
using MediatR;

namespace LoggingService.Application.UseCases.ErrorMessages.UpdateErrorMessage;

public class UpdateErrorMessageHandler : IRequestHandler<UpdateErrorMessageCommand, Result<ErrorMessageDto>>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateErrorMessageHandler(ILoggingUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<ErrorMessageDto>> Handle(UpdateErrorMessageCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ErrorMessages.GetByIdAsync(request.Id);
            if (entity == null) return Result<ErrorMessageDto>.Failure($"ErrorMessage with id {request.Id} not found");

            entity.Code = request.Code;
            entity.Message = request.Message;
            entity.Category = request.Category;
            entity.UseCase = request.UseCase;
            entity.LocaleCode = request.LocaleCode;
            entity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.ErrorMessages.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<ErrorMessageDto>.Success(_mapper.Map<ErrorMessageDto>(entity));
        }
        catch (Exception ex) { return Result<ErrorMessageDto>.Failure($"Failed to update error message: {ex.Message}"); }
    }
}
