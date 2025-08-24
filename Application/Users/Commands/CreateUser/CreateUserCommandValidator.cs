using FluentValidation;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreareUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(command => command.FullName)
                .NotEmpty().WithMessage("User name is required.")
                .MaximumLength(100).WithMessage("User name cannot exceed 100 characters.");
            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(50).WithMessage("Email cannot exceed 50 characters.");
            RuleFor(command => command.Role)
                .NotEmpty().WithMessage("Role is required.");
            RuleFor(command => command.LoginId)
                .NotEmpty().WithMessage("Role is required.")
                .MaximumLength(20).WithMessage("User login Id cannot exceed 20 characters.");
        }
    }
}
