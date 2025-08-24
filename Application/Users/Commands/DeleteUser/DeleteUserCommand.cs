﻿using MediatR;

namespace Application.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(Guid Id) : IRequest<Guid>;
}
