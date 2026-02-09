using Abstractions.DTOs.AiUsageLog;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.AiUsageLogs.CreateAiUsageLog;

public class CreateAiUsageLogHandler : IRequestHandler<CreateAiUsageLogRequest, Result<AiUsageLogDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateAiUsageLogHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<AiUsageLogDto>> Handle(CreateAiUsageLogRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<AiUsageLog>(request);
            await _unitOfWork.AiUsageLogs.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<AiUsageLogDto>(entity);
            return Result<AiUsageLogDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<AiUsageLogDto>.Failure($"Failed to create aiUsageLog: {ex.Message}");
        }
    }
}
