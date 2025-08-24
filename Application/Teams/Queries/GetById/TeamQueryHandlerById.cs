using Application.Teams.Queries.GetById;
using Domain.Entity;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Teams.Queries.GetAll
{
    public class TeamQueryHandlerById : IRequestHandler<TeamQueryById, Team>
    {
        private readonly AppDbContext _db;
        public TeamQueryHandlerById(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Team?> Handle(TeamQueryById request, CancellationToken cancellationToken)
        {
            var Team = _db.Teams
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == request.id, cancellationToken);

            return await Team;
        }
    }
}
