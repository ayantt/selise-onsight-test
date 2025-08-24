using Domain.Common;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Tasks.Queries.GetAll
{
    public class TaskQueryHandlerAll : IRequestHandler<TaskQueryAll, List<Domain.Entity.Task>>
    {
        private readonly AppDbContext _db;
        public TaskQueryHandlerAll(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Domain.Entity.Task>> Handle(TaskQueryAll request, CancellationToken cancellationToken)
        {
            var filter = request.Filter ?? new FilterOption();

            IQueryable<Domain.Entity.Task> query = _db.Tasks.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                string searchLower = filter.Search.ToLower();
                query = query.Where(t =>
                    t.Title.ToLower().Contains(searchLower) ||
                    (t.Description != null && t.Description.ToLower().Contains(searchLower))
                );
            }

            // Apply ordering
            query = filter.OrderBy.ToLower() switch
            {
                "title" => filter.Order.ToLower() == "desc" ? query.OrderByDescending(t => t.Title) : query.OrderBy(t => t.Title),
                "duedate" => filter.Order.ToLower() == "desc" ? query.OrderByDescending(t => t.DueDate) : query.OrderBy(t => t.DueDate),
                _ => filter.Order.ToLower() == "desc" ? query.OrderByDescending(t => t.Id) : query.OrderBy(t => t.Id)
            };

            // Apply pagination
            query = query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize);

            return await query.ToListAsync(cancellationToken);
        }
    }
}
