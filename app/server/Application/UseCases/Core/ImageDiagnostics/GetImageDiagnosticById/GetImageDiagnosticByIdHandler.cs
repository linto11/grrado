using Abstractions.DTOs.ImageDiagnostic;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Core.ImageDiagnostics.GetImageDiagnosticById;

public class GetImageDiagnosticByIdHandler : IRequestHandler<GetImageDiagnosticByIdRequest, Result<ImageDiagnosticDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetImageDiagnosticByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ImageDiagnosticDto>> Handle(GetImageDiagnosticByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ImageDiagnostics.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<ImageDiagnosticDto>.Failure($"ImageDiagnostic with ID {request.Id} not found");
            }
            var dto = _mapper.Map<ImageDiagnosticDto>(entity);
            return Result<ImageDiagnosticDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<ImageDiagnosticDto>.Failure($"Failed to retrieve imageDiagnostic: {ex.Message}");
        }
    }
}
