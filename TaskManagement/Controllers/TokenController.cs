using Application.Users.Queries.GetById;
using Infrastructure.Token;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly JwtService _jwtService;

        public TokenController(IMediator mediator, JwtService jwtService)
        {
            _mediator = mediator;
            _jwtService = jwtService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GenerateTokenAsync(Guid id)
        {
            var user = await _mediator.Send(new UserQueryById(id));
            if (user == null)
            {
                return NotFound("User not found");
            }

            var token = _jwtService.GenerateToken(user.Id.ToString(), user.Role);
            return Ok(new { Token = token });
        }
    }
}
