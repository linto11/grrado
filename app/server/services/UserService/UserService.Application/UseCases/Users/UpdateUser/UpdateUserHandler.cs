using AutoMapper;
using GRRADO.Shared.Application.Common;
using UserService.Application.Abstractions;
using UserService.Application.DTOs;
using MediatR;

namespace UserService.Application.UseCases.Users.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Result<UserDto>>
{
    private readonly IUserUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateUserHandler(IUserUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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
            return Result<UserDto>.Success(_mapper.Map<UserDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<UserDto>.Failure($"Failed to update user: {ex.Message}");
        }
    }
}
