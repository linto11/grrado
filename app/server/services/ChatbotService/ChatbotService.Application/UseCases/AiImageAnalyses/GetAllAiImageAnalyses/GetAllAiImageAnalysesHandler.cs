using AutoMapper;
using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using ChatbotService.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChatbotService.Application.UseCases.AiImageAnalyses.GetAllAiImageAnalyses;

public class GetAllAiImageAnalysesHandler : IRequestHandler<GetAllAiImageAnalysesQuery, Result<List<AiImageAnalysisDto>>>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllAiImageAnalysesHandler(IChatbotUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

    public async Task<Result<List<AiImageAnalysisDto>>> Handle(GetAllAiImageAnalysesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await _unitOfWork.AiImageAnalyses.GetAll()
                .Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
            return Result<List<AiImageAnalysisDto>>.Success(_mapper.Map<List<AiImageAnalysisDto>>(entities));
        }
        catch (Exception ex) { return Result<List<AiImageAnalysisDto>>.Failure($"Failed to get ai image analyses: {ex.Message}"); }
    }
}
