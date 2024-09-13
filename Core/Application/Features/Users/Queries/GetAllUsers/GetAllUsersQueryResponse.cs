using Domain.Entities;

namespace Application.Features.Users.Queries.GetAllUsers;

public class GetAllUsersQueryResponse
{
    public IReadOnlyCollection<User> Users { get; set; } = [];
}