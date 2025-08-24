using MediatR;

namespace Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(Guid Id, string FullName, string Email, string Role, string LoginId) : IRequest<Guid>;
}
