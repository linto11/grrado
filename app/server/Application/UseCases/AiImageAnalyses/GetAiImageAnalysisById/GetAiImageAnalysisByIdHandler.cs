using Abstractions.DTOs.AiImageAnalysis;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.AiImageAnalyses.GetAiImageAnalysisById;

public class GetAiImageAnalysisByIdHandler : IRequestHandler<GetAiImageAnalysisByIdRequest, Result<AiImageAnalysisDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAiImageAnalysisByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<AiImageAnalysisDto>> Handle(GetAiImageAnalysisByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.AiImageAnalyses.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<AiImageAnalysisDto>.Failure($"AiImageAnalysis with ID {request.Id} not found");
            }
            var dto = _mapper.Map<AiImageAnalysisDto>(entity);
            return Result<AiImageAnalysisDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<AiImageAnalysisDto>.Failure($"Failed to retrieve aiImageAnalysis: {ex.Message}");
        }
    }
}
