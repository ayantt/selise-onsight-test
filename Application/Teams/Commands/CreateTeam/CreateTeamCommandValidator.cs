using FluentValidation;

namespace Application.Teams.Commands.CreateTeam
{
    public class CreateTeamCommandValidator : AbstractValidator<CreareTeamCommand>
    {
        public CreateTeamCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Team name is required.")
                .MaximumLength(50).WithMessage("Team name cannot exceed 50 characters.");
            RuleFor(command => command.Description)
                .MaximumLength(200).WithMessage("Description cannot exceed 200 characters.");
        }
    }
}
