using Domain.Entity;
using Infrastructure;
using MediatR;

namespace Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreareTaskCommand, Guid>
    {
        private readonly AppDbContext _db;
        public CreateTaskCommandHandler(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Guid> Handle(CreareTaskCommand request, CancellationToken cancellationToken)
        {
            var Task = new Domain.Entity.Task
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Status = request.Status,
                AssignedToUserId = request.AssignedToUserId,
                TeamId = request.TeamId,
                CreatedByUserId = request.CreatedByUserId,
                DueDate = request.DueDate
            };

            _db.Tasks.Add(Task);
            await _db.SaveChangesAsync(cancellationToken);

            return Task.Id;
        }
    }
}
