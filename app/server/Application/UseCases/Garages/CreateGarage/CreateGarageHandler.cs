using Abstractions.DTOs.Garage;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Garages.CreateGarage;

public class CreateGarageHandler : IRequestHandler<CreateGarageRequest, Result<GarageDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateGarageHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<GarageDto>> Handle(CreateGarageRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Garage>(request);
            await _unitOfWork.Garages.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<GarageDto>(entity);
            return Result<GarageDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<GarageDto>.Failure($"Failed to create garage: {ex.Message}");
        }
    }
}
