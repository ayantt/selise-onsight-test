using MediatR;

namespace Application.Teams.Commands.UpdateTeam
{
    public record UpdateTeamCommand(Guid Id, string Name, string Description) : IRequest<Guid>;
}
