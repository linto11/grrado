using Abstractions.DTOs.AiImageAnalysis;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Chatbot.AiImageAnalyses.UpdateAiImageAnalysis;

public class UpdateAiImageAnalysisHandler : IRequestHandler<UpdateAiImageAnalysisRequest, Result<AiImageAnalysisDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateAiImageAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<AiImageAnalysisDto>> Handle(UpdateAiImageAnalysisRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.AiImageAnalyses.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<AiImageAnalysisDto>.Failure($"AiImageAnalysis with ID {request.Id} not found");
            }
            _mapper.Map(request, entity);
            await _unitOfWork.AiImageAnalyses.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<AiImageAnalysisDto>(entity);
            return Result<AiImageAnalysisDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<AiImageAnalysisDto>.Failure($"Failed to update aiImageAnalysis: {ex.Message}");
        }
    }
}
