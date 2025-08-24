using Domain.Entity;
using Infrastructure;
using MediatR;

namespace Application.Teams.Commands.CreateTeam
{
    public class CreateTeamCommandHandler : IRequestHandler<CreareTeamCommand, Guid>
    {
        private readonly AppDbContext _db;
        public CreateTeamCommandHandler(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Guid> Handle(CreareTeamCommand request, CancellationToken cancellationToken)
        {
            var Team = new Team
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description
            };

            _db.Teams.Add(Team);
            await _db.SaveChangesAsync(cancellationToken);

            return Team.Id;
        }
    }
}
