using Domain.Common;
using MediatR;

namespace Application.Tasks.Queries.GetAll
{
    public record TaskQueryAll(FilterOption? Filter = null) : IRequest<List<Domain.Entity.Task>>;
}
