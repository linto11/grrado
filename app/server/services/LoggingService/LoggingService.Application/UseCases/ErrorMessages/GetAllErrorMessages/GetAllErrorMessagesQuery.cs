using GRRADO.Shared.Application.Common;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.ErrorMessages.GetAllErrorMessages;

public class GetAllErrorMessagesQuery : IRequest<Result<List<ErrorMessageDto>>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}
