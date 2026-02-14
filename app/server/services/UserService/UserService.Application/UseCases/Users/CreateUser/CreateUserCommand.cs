using GRRADO.Shared.Application.Common;
using UserService.Application.DTOs;
using MediatR;

namespace UserService.Application.UseCases.Users.CreateUser;

public class CreateUserCommand : IRequest<Result<UserDto>>
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string FamilyType { get; set; } = string.Empty;
    public string ExperienceLevel { get; set; } = string.Empty;
}
