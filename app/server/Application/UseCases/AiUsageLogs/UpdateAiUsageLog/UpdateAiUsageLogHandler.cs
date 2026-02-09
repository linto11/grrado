using Abstractions.DTOs.AiUsageLog;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.AiUsageLogs.UpdateAiUsageLog;

public class UpdateAiUsageLogHandler : IRequestHandler<UpdateAiUsageLogRequest, Result<AiUsageLogDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateAiUsageLogHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<AiUsageLogDto>> Handle(UpdateAiUsageLogRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.AiUsageLogs.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<AiUsageLogDto>.Failure($"AiUsageLog with ID {request.Id} not found");
            }
            _mapper.Map(request, entity);
            await _unitOfWork.AiUsageLogs.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<AiUsageLogDto>(entity);
            return Result<AiUsageLogDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<AiUsageLogDto>.Failure($"Failed to update aiUsageLog: {ex.Message}");
        }
    }
}
