using AutoMapper;
using GRRADO.Shared.Application.Common;
using UserService.Application.Abstractions;
using UserService.Application.DTOs;
using UserService.Domain.Entities;
using MediatR;

namespace UserService.Application.UseCases.Users.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<UserDto>>
{
    private readonly IUserUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserHandler(IUserUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<User>(request);
            await _unitOfWork.Users.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<UserDto>.Success(_mapper.Map<UserDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<UserDto>.Failure($"Failed to create user: {ex.Message}");
        }
    }
}
