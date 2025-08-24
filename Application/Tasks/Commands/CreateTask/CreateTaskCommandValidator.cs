using FluentValidation;

namespace Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandValidator : AbstractValidator<CreareTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(command => command.Title)
                .NotEmpty().WithMessage("Task title is required.")
                .MaximumLength(100).WithMessage("Task title cannot exceed 100 characters.");
            RuleFor(command => command.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
            RuleFor(command => command.Status)
                .NotEmpty().WithMessage("Status is required.");
            RuleFor(command => command.AssignedToUserId)
                .NotEmpty().WithMessage("AssignedToUserId is required.");
            RuleFor(command => command.TeamId)
                .NotEmpty().WithMessage("TeamId is required.");
            RuleFor(command => command.CreatedByUserId)
                .NotEmpty().WithMessage("CreatedByUserId is required.");
            RuleFor(command => command.DueDate)
                .NotEmpty().WithMessage("DueDate is required.");
        }
    }
}
