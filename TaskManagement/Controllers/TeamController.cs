using Application.Teams.Commands.CreateTeam;
using Application.Teams.Commands.DeleteTeam;
using Application.Teams.Commands.UpdateTeam;
using Application.Teams.Queries.GetAll;
using Application.Teams.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TeamsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<TeamsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Teams = await _mediator.Send(new TeamQueryAll());
            return Ok(Teams);
        }

        // GET api/<TeamsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var Team = await _mediator.Send(new TeamQueryById(id));
            if (Team == null)
            {
                return NotFound("Team not found");
            }

            return Ok(Team);
        }

        // POST api/<TeamsController>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreareTeamCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return Ok(id);
        }

        // PUT api/<TeamsController>/5

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateTeamCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return Ok(id);
        }

        // DELETE api/<TeamsController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(Guid id)
        {
            var deletedTeamId = await _mediator.Send(new DeleteTeamCommand(id));
            return Ok(deletedTeamId);
        }
    }
}
