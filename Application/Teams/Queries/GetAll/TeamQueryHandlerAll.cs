using Domain.Entity;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Teams.Queries.GetAll
{
    public class TeamQueryHandlerAll : IRequestHandler<TeamQueryAll, List<Team>>
    {
        private readonly AppDbContext _db;
        public TeamQueryHandlerAll(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<Team>> Handle(TeamQueryAll request, CancellationToken cancellationToken)
        {
            return await _db.Teams
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
