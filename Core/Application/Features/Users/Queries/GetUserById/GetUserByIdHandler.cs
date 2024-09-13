using Application.Contracts.Persistence;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Queries.GetUserById;

public class GetUserByIdHandler(IRepository<User> repository) : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
{
    private readonly IRepository<User> _repository = repository;
    public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        GetUserByIdResponse response = new();

        User? result = await _repository.GetByIdAsync(request.Id);

        response.User = result;

        return response;
    }
}