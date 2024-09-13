using Domain.Entities;

namespace Application.Features.Users.Queries.GetUserById;

public class GetUserByIdResponse
{
    public User? User { get; set; }
}