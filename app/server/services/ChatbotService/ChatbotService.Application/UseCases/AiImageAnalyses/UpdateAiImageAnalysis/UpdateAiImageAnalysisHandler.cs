using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using ChatbotService.Domain.Entities;
using MediatR;

namespace ChatbotService.Application.UseCases.AiImageAnalyses.UpdateAiImageAnalysis;

public class UpdateAiImageAnalysisHandler : IRequestHandler<UpdateAiImageAnalysisCommand, Result<AiImageAnalysisDto>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateAiImageAnalysisHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<AiImageAnalysisDto>> Handle(UpdateAiImageAnalysisCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.AiImageAnalyses.GetByIdAsync(request.Id);
            if (entity == null) return Result<AiImageAnalysisDto>.Failure($"AiImageAnalysis with id {request.Id} not found");

            entity.ChatbotMessageId = request.ChatbotMessageId;
            entity.UserId = request.UserId;
            entity.OriginalImageFileName = request.OriginalImageFileName;
            entity.OriginalImagePath = request.OriginalImagePath;
            entity.AnnotatedImagePath = request.AnnotatedImagePath;
            entity.ThumbnailPath = request.ThumbnailPath;
            entity.FileSizeBytes = request.FileSizeBytes;
            entity.ImageMimeType = request.ImageMimeType;
            entity.AnalysisType = request.AnalysisType;
            entity.DetectedObjects = request.DetectedObjects;
            entity.SeverityLevel = request.SeverityLevel;
            entity.DamageType = request.DamageType;
            entity.PartsIdentified = request.PartsIdentified;
            entity.ConfidenceScore = request.ConfidenceScore;
            entity.Recommendations = request.Recommendations;
            entity.VehiclePartLocation = request.VehiclePartLocation;
            entity.EstimatedRepairCostRange = request.EstimatedRepairCostRange;
            entity.RequiresExpertReview = request.RequiresExpertReview;
            entity.ResponseTimeMs = request.ResponseTimeMs;
            entity.TokensUsed = request.TokensUsed;
            entity.CostUsd = request.CostUsd;
            entity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.AiImageAnalyses.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<AiImageAnalysisDto>.Success(_mapper.Map<AiImageAnalysisDto>(entity));
        }
        catch (Exception ex) { return Result<AiImageAnalysisDto>.Failure($"Failed to update ai image analysis: {ex.Message}"); }
    }
}
