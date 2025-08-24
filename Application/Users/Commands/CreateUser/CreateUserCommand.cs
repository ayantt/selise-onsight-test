using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public record CreareUserCommand(string FullName, string Email, string Role, string LoginId) : IRequest<Guid>;
}
