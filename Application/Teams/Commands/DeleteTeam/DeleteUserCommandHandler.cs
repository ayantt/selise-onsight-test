using Infrastructure;
using MediatR;

namespace Application.Teams.Commands.DeleteTeam
{
    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, Guid>
    {
        private readonly AppDbContext _db;
        public DeleteTeamCommandHandler(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Guid> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var Team = await _db.Teams.FindAsync(new object[] { request.Id }, cancellationToken);

            if (Team == null)
            {
                throw new KeyNotFoundException($"Team with Id {request.Id} not found.");
            }

            _db.Teams.Remove(Team);

            await _db.SaveChangesAsync(cancellationToken);

            return Team.Id;
        }


    }
}
