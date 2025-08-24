using Application.Tasks.Commands.CreateTask;
using Application.Tasks.Commands.DeleteTask;
using Application.Tasks.Commands.UpdateTask;
using Application.Tasks.Queries.GetAll;
using Application.Tasks.Queries.GetById;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<TasksController>
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string orderBy = "Id",
            [FromQuery] string order = "ASC",
            [FromQuery] string? search = null)
        {
            var filter = new FilterOption
            {
                Page = page,
                PageSize = pageSize,
                OrderBy = orderBy,
                Order = order,
                Search = search
            };

            var tasks = await _mediator.Send(new TaskQueryAll(filter));
            return Ok(tasks);
        }


        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var Task = await _mediator.Send(new TaskQueryById(id));
            if (Task == null)
            {
                return NotFound("Task not found");
            }

            return Ok(Task);
        }

        // POST api/<TasksController>
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> Create(CreareTaskCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return Ok(id);
        }

        // PUT api/<TasksController>/5
        [Authorize(Roles = "Manager,Employee")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateTaskCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return Ok(id);
        }

        // DELETE api/<TasksController>/5
        [Authorize(Roles = "Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var deletedTaskId = await _mediator.Send(new DeleteTaskCommand(id));
            return Ok(deletedTaskId);
        }
    }
}
