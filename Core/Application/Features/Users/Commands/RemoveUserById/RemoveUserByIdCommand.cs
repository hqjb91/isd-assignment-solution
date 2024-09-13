using MediatR;

namespace Application.Features.Users.Commands.RemoveUserById;

public class RemoveUserByIdCommand : IRequest<RemoveUserByIdCommandResponse>
{
    public long Id { get; set; }
}