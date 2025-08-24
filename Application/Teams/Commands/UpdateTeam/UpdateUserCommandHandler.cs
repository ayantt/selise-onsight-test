using Infrastructure;
using MediatR;

namespace Application.Teams.Commands.UpdateTeam
{
    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, Guid>
    {
        private readonly AppDbContext _db;
        public UpdateTeamCommandHandler(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Guid> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var Team = await _db.Teams.FindAsync(new object[] { request.Id }, cancellationToken);

            if (Team == null)
            {
                throw new KeyNotFoundException($"Team with Id {request.Id} not found.");
            }

            Team.Name = request.Name;
            Team.Description = request.Description;

            _db.Teams.Update(Team);

            await _db.SaveChangesAsync(cancellationToken);

            return Team.Id;
        }

    }
}
