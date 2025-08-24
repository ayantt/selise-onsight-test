using MediatR;

namespace Application.Tasks.Commands.CreateTask
{
    public record CreareTaskCommand(string Title, string Description, string Status, Guid AssignedToUserId, Guid TeamId, Guid CreatedByUserId, DateTime DueDate
        ) : IRequest<Guid>;
}
