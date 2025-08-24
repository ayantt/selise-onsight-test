using Infrastructure;
using MediatR;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
    {
        private readonly AppDbContext _db;
        public UpdateUserCommandHandler(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _db.Users.FindAsync(new object[] { request.Id }, cancellationToken);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with Id {request.Id} not found.");
            }

            user.FullName = request.FullName;
            user.Email = request.Email;
            user.Role = request.Role;
            user.LoginId = request.LoginId;

            _db.Users.Update(user);

            await _db.SaveChangesAsync(cancellationToken);

            return user.Id;
        }

    }
}
