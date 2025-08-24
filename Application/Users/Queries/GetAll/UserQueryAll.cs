using MediatR;

namespace Application.Users.Queries.GetAll
{
    public record UserQueryAll : IRequest<List<Domain.Entity.User>>;
}
