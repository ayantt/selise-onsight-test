using FluentValidation;

namespace Application.Teams.Commands.UpdateTeam
{
    public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
    {
        public UpdateTeamCommandValidator()
        {
            RuleFor(command => command.Name)
                .MaximumLength(50).WithMessage("Team name cannot exceed 50 characters.");
            RuleFor(command => command.Description)
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(200).WithMessage("Email cannot exceed 200 characters.");
        }
    }
}
