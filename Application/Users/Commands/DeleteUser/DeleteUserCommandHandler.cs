using Infrastructure;
using MediatR;

namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Guid>
    {
        private readonly AppDbContext _db;
        public DeleteUserCommandHandler(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Guid> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _db.Users.FindAsync(new object[] { request.Id }, cancellationToken);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with Id {request.Id} not found.");
            }

            _db.Users.Remove(user);

            await _db.SaveChangesAsync(cancellationToken);

            return user.Id;
        }


    }
}
