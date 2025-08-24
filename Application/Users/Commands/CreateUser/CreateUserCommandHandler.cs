using Domain.Entity;
using Infrastructure;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreareUserCommand, Guid>
    {
        private readonly AppDbContext _db;
        public CreateUserCommandHandler(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Guid> Handle(CreareUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                FullName = request.FullName,
                Email = request.Email,
                Role = request.Role,
                LoginId = request.LoginId
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
