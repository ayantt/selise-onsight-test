using Domain.Entity;
using MediatR;

namespace Application.Teams.Queries.GetAll
{
    public record TeamQueryAll : IRequest<List<Team>>;
}
