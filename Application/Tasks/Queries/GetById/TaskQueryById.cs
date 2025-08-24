using MediatR;

namespace Application.Tasks.Queries.GetById
{
    public record TaskQueryById(Guid id) : IRequest<Domain.Entity.Task>;
}
