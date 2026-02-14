using AutoMapper;
using GarageService.Application.Abstractions;
using GarageService.Application.DTOs;
using GarageService.Domain.Entities;
using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Services.CreateService;

public class CreateServiceHandler : IRequestHandler<CreateServiceCommand, Result<ServiceDto>>
{
    private readonly IGarageUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateServiceHandler(IGarageUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ServiceDto>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Service>(request.Request);
        entity.CreatedAt = DateTime.UtcNow;

        await _unitOfWork.Services.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        var dto = _mapper.Map<ServiceDto>(entity);
        return Result<ServiceDto>.Success(dto);
    }
}
