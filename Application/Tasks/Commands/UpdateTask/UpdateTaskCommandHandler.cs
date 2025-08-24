using Infrastructure;
using MediatR;

namespace Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Guid>
    {
        private readonly AppDbContext _db;
        public UpdateTaskCommandHandler(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Guid> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var Task = await _db.Tasks.FindAsync(new object[] { request.Id }, cancellationToken);

            if (Task == null)
            {
                throw new KeyNotFoundException($"Task with Id {request.Id} not found.");
            }

            Task.Title = request.Title;
            Task.Description = request.Description;
            Task.Status = request.Status;
            Task.AssignedToUserId = request.AssignedToUserId;
            Task.TeamId = request.TeamId;
            Task.CreatedByUserId = request.CreatedByUserId;
            Task.DueDate = request.DueDate;

            _db.Tasks.Update(Task);

            await _db.SaveChangesAsync(cancellationToken);

            return Task.Id;
        }

    }
}
