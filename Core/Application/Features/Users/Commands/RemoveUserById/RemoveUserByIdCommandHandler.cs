using Application.Contracts.Persistence;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.RemoveUserById;

public class RemoveUserByIdCommandHandler(IRepository<User> repository) : IRequestHandler<RemoveUserByIdCommand, RemoveUserByIdCommandResponse>
{
    private readonly IRepository<User> _repository = repository;

    public async Task<RemoveUserByIdCommandResponse> Handle(RemoveUserByIdCommand request, CancellationToken cancellationToken)
    {
        RemoveUserByIdCommandResponse response = new();

        User? userToDelete = await _repository.GetByIdAsync(request.Id);
        if (userToDelete is not null) await _repository.DeleteAsync(userToDelete);

        return response;
    }
}