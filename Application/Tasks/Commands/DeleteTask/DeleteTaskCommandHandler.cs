using Infrastructure;
using MediatR;

namespace Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Guid>
    {
        private readonly AppDbContext _db;
        public DeleteTaskCommandHandler(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Guid> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var Task = await _db.Tasks.FindAsync(new object[] { request.Id }, cancellationToken);

            if (Task == null)
            {
                throw new KeyNotFoundException($"Task with Id {request.Id} not found.");
            }

            _db.Tasks.Remove(Task);

            await _db.SaveChangesAsync(cancellationToken);

            return Task.Id;
        }


    }
}
