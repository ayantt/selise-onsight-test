using Application.Users.Queries.GetById;
using Domain.Entity;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetAll
{
    public class UserQueryHandlerById : IRequestHandler<UserQueryById, User>
    {
        private readonly AppDbContext _db;
        public UserQueryHandlerById(AppDbContext db)
        {
            _db = db;
        }

        public async Task<User?> Handle(UserQueryById request, CancellationToken cancellationToken)
        {
            var user = _db.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == request.id, cancellationToken);

            return await user;
        }
    }
}
