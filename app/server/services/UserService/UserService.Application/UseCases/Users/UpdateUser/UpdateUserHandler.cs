using AutoMapper;
using GRRADO.Shared.Abstractions.Caching;
using GRRADO.Shared.Application.Common;
using UserService.Application.Abstractions;
using UserService.Application.DTOs;
using MediatR;

namespace UserService.Application.UseCases.Users.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Result<UserDto>>
{
    private readonly IUserUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheService _cache;

    public UpdateUserHandler(IUserUnitOfWork unitOfWork, IMapper mapper, ICacheService cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cache;
    }

    public async Task<Result<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.Users.GetByIdAsync(request.Id);
            if (entity == null)
                return Result<UserDto>.Failure("User not found");

            entity.Name = request.Name;
            entity.Email = request.Email;
            entity.PhoneNumber = request.PhoneNumber;
            entity.City = request.City;
            entity.FamilyType = request.FamilyType;
            entity.ExperienceLevel = request.ExperienceLevel;

            await _unitOfWork.Users.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            await _cache.RemoveAsync($"user:{request.Id}", cancellationToken);

            return Result<UserDto>.Success(_mapper.Map<UserDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<UserDto>.Failure($"Failed to update user: {ex.Message}");
        }
    }
}
