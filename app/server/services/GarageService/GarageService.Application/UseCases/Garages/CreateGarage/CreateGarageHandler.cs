using AutoMapper;
using GarageService.Application.Abstractions;
using GarageService.Application.DTOs;
using GarageService.Domain.Entities;
using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Garages.CreateGarage;

public class CreateGarageHandler : IRequestHandler<CreateGarageCommand, Result<GarageDto>>
{
    private readonly IGarageUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateGarageHandler(IGarageUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<GarageDto>> Handle(CreateGarageCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Garage>(request.Request);
        entity.CreatedAt = DateTime.UtcNow;

        await _unitOfWork.Garages.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        var dto = _mapper.Map<GarageDto>(entity);
        return Result<GarageDto>.Success(dto);
    }
}
