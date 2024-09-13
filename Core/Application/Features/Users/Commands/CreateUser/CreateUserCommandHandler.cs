using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IRepository<User> repository, IMapper mapper) : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
{
    private readonly IRepository<User> _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        CreateUserCommandResponse response = new();

        User user = _mapper.Map<User>(request);
        User result = await _repository.AddAsync(user);
        CreateUserDto resultDto = _mapper.Map<CreateUserDto>(result);
        response.User = resultDto;

        return response;
    }
}