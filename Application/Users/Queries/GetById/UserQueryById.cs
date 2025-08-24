using Domain.Entity;
using MediatR;

namespace Application.Users.Queries.GetById
{
    public record UserQueryById(Guid id) : IRequest<User>;
}
