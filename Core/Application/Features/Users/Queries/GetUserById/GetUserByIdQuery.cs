using MediatR;

namespace Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<GetUserByIdResponse>
{
    public long Id { get; set; }
}