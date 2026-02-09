using Abstractions.DTOs.AiImageAnalysis;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Chatbot.AiImageAnalyses.CreateAiImageAnalysis;

public class CreateAiImageAnalysisHandler : IRequestHandler<CreateAiImageAnalysisRequest, Result<AiImageAnalysisDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateAiImageAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<AiImageAnalysisDto>> Handle(CreateAiImageAnalysisRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<AiImageAnalysis>(request);
            await _unitOfWork.AiImageAnalyses.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<AiImageAnalysisDto>(entity);
            return Result<AiImageAnalysisDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<AiImageAnalysisDto>.Failure($"Failed to create aiImageAnalysis: {ex.Message}");
        }
    }
}
