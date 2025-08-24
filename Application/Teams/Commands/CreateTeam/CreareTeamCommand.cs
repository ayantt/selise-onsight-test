using MediatR;

namespace Application.Teams.Commands.CreateTeam
{
    public record CreareTeamCommand(string Name, string Description) : IRequest<Guid>;
}
