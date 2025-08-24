using Application.Tasks.Queries.GetById;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Tasks.Queries.GetAll
{
    public class TaskQueryHandlerById : IRequestHandler<TaskQueryById, Domain.Entity.Task>
    {
        private readonly AppDbContext _db;
        public TaskQueryHandlerById(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Domain.Entity.Task?> Handle(TaskQueryById request, CancellationToken cancellationToken)
        {
            var Task = _db.Tasks
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == request.id, cancellationToken);

            return await Task;
        }
    }
}
