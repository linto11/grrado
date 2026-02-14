using AutoMapper;
using GarageService.Application.Abstractions;
using GarageService.Application.DTOs;
using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Garages.GetGarageById;

public class GetGarageByIdHandler : IRequestHandler<GetGarageByIdQuery, Result<GarageDto>>
{
    private readonly IGarageUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetGarageByIdHandler(IGarageUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<GarageDto>> Handle(GetGarageByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Garages.GetByIdAsync(request.Id);

        if (entity is null)
            return Result<GarageDto>.Failure("Garage not found.");

        var dto = _mapper.Map<GarageDto>(entity);
        return Result<GarageDto>.Success(dto);
    }
}
