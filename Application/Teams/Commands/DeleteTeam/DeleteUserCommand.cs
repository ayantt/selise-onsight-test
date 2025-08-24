using MediatR;

namespace Application.Teams.Commands.DeleteTeam
{
    public record DeleteTeamCommand(Guid Id) : IRequest<Guid>;
}
