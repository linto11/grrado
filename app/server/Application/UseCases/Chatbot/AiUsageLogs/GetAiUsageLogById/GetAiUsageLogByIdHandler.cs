using Abstractions.DTOs.AiUsageLog;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Chatbot.AiUsageLogs.GetAiUsageLogById;

public class GetAiUsageLogByIdHandler : IRequestHandler<GetAiUsageLogByIdRequest, Result<AiUsageLogDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAiUsageLogByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<AiUsageLogDto>> Handle(GetAiUsageLogByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.AiUsageLogs.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<AiUsageLogDto>.Failure($"AiUsageLog with ID {request.Id} not found");
            }
            var dto = _mapper.Map<AiUsageLogDto>(entity);
            return Result<AiUsageLogDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<AiUsageLogDto>.Failure($"Failed to retrieve aiUsageLog: {ex.Message}");
        }
    }
}
