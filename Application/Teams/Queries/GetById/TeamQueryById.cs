using Domain.Entity;
using MediatR;

namespace Application.Teams.Queries.GetById
{
    public record TeamQueryById(Guid id) : IRequest<Team>;
}
