using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using ChatbotService.Domain.Entities;
using MediatR;

namespace ChatbotService.Application.UseCases.AiImageAnalyses.CreateAiImageAnalysis;

public class CreateAiImageAnalysisHandler : IRequestHandler<CreateAiImageAnalysisCommand, Result<AiImageAnalysisDto>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateAiImageAnalysisHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<AiImageAnalysisDto>> Handle(CreateAiImageAnalysisCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<AiImageAnalysis>(request);
            await _unitOfWork.AiImageAnalyses.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<AiImageAnalysisDto>.Success(_mapper.Map<AiImageAnalysisDto>(entity));
        }
        catch (Exception ex) { return Result<AiImageAnalysisDto>.Failure($"Failed to create ai image analysis: {ex.Message}"); }
    }
}
