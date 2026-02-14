using AutoMapper;
using UserService.Application.DTOs;
using UserService.Application.UseCases.Users.CreateUser;
using UserService.Application.UseCases.Users.UpdateUser;
using UserService.Domain.Entities;

namespace UserService.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<CreateUserCommand, User>();
        CreateMap<UpdateUserCommand, User>();
    }
}
