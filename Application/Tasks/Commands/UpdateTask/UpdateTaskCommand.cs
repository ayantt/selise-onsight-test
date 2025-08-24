using MediatR;

namespace Application.Tasks.Commands.UpdateTask
{
    public record UpdateTaskCommand(Guid Id, string Title, string Description, string Status, Guid AssignedToUserId, Guid TeamId, Guid CreatedByUserId, DateTime DueDate
        ) : IRequest<Guid>;
}
