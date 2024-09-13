using Application.Contracts.Persistence;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Queries.GetAllUsers;

public class GetAllUsersQueryHandler(IRepository<User> repository) : IRequestHandler<GetAllUsersQuery, GetAllUsersQueryResponse>
{
    private readonly IRepository<User> _repository = repository;
    public async Task<GetAllUsersQueryResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        GetAllUsersQueryResponse response = new();

        IReadOnlyCollection<User> result = await _repository.ListAllAsync();

        response.Users = result;

        return response;
    }
}