using Abstractions.DTOs.ImageDiagnostic;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Core.ImageDiagnostics.UpdateImageDiagnostic;

public class UpdateImageDiagnosticHandler : IRequestHandler<UpdateImageDiagnosticRequest, Result<ImageDiagnosticDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateImageDiagnosticHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ImageDiagnosticDto>> Handle(UpdateImageDiagnosticRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ImageDiagnostics.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<ImageDiagnosticDto>.Failure($"ImageDiagnostic with ID {request.Id} not found");
            }
            _mapper.Map(request, entity);
            await _unitOfWork.ImageDiagnostics.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<ImageDiagnosticDto>(entity);
            return Result<ImageDiagnosticDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<ImageDiagnosticDto>.Failure($"Failed to update imageDiagnostic: {ex.Message}");
        }
    }
}
