using Application.Responses;

namespace Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandResponse : BaseResponse
{
    public CreateUserDto? User { get; set; }
}