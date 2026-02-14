using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using MediatR;

namespace ChatbotService.Application.UseCases.AiImageAnalyses.GetAiImageAnalysisById;

public class GetAiImageAnalysisByIdHandler : IRequestHandler<GetAiImageAnalysisByIdQuery, Result<AiImageAnalysisDto>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAiImageAnalysisByIdHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<AiImageAnalysisDto>> Handle(GetAiImageAnalysisByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.AiImageAnalyses.GetByIdAsync(request.Id);
            if (entity == null) return Result<AiImageAnalysisDto>.Failure($"AiImageAnalysis with id {request.Id} not found");
            return Result<AiImageAnalysisDto>.Success(_mapper.Map<AiImageAnalysisDto>(entity));
        }
        catch (Exception ex) { return Result<AiImageAnalysisDto>.Failure($"Failed to get ai image analysis: {ex.Message}"); }
    }
}
