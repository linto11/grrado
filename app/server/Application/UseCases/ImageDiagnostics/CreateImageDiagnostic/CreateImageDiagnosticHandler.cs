using Abstractions.DTOs.ImageDiagnostic;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.ImageDiagnostics.CreateImageDiagnostic;

public class CreateImageDiagnosticHandler : IRequestHandler<CreateImageDiagnosticRequest, Result<ImageDiagnosticDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateImageDiagnosticHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ImageDiagnosticDto>> Handle(CreateImageDiagnosticRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Domain.Entities.ImageDiagnostic>(request);
            await _unitOfWork.ImageDiagnostics.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<ImageDiagnosticDto>(entity);
            return Result<ImageDiagnosticDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<ImageDiagnosticDto>.Failure($"Failed to create imageDiagnostic: {ex.Message}");
        }
    }
}
