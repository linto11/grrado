using AutoMapper;
using GarageService.Application.Abstractions;
using GarageService.Application.DTOs;
using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Services.GetServiceById;

public class GetServiceByIdHandler : IRequestHandler<GetServiceByIdQuery, Result<ServiceDto>>
{
    private readonly IGarageUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetServiceByIdHandler(IGarageUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ServiceDto>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Services.GetByIdAsync(request.Id);

        if (entity is null)
            return Result<ServiceDto>.Failure("Service not found.");

        var dto = _mapper.Map<ServiceDto>(entity);
        return Result<ServiceDto>.Success(dto);
    }
}
