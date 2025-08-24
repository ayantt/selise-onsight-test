using FluentValidation;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(command => command.FullName)
                .MaximumLength(100).WithMessage("User name cannot exceed 100 characters.");
            RuleFor(command => command.Email)
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(50).WithMessage("Email cannot exceed 50 characters.");
            RuleFor(command => command.Role);
            RuleFor(command => command.LoginId)
                .MaximumLength(20).WithMessage("User login Id cannot exceed 20 characters.");
        }
    }
}
