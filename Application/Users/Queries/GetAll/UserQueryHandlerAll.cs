using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetAll
{
    public class UserQueryHandlerAll : IRequestHandler<UserQueryAll, List<Domain.Entity.User>>
    {
        private readonly AppDbContext _db;
        public UserQueryHandlerAll(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<Domain.Entity.User>> Handle(UserQueryAll request, CancellationToken cancellationToken)
        {
            return await _db.Users
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
