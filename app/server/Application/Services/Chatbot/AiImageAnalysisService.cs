using Abstractions.DTOs.AiImageAnalysis;
using Abstractions.Persistence;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Chatbot;

public interface IAiImageAnalysisService : IBaseService<AiImageAnalysis, AiImageAnalysisDto, CreateAiImageAnalysisRequest, UpdateAiImageAnalysisRequest>
{
}

public class AiImageAnalysisService : BaseService<AiImageAnalysis, AiImageAnalysisDto, CreateAiImageAnalysisRequest, UpdateAiImageAnalysisRequest>, IAiImageAnalysisService
{
    public AiImageAnalysisService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    protected override IRepository<AiImageAnalysis> GetRepository() => _unitOfWork.AiImageAnalyses;}
