using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Voters.Commands;
using VotingApp.Application.Voters.Queries;
using VotingApp.Domain.Entities;

namespace VotingAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VotersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getvoterslist")]
        public async Task<ActionResult<IEnumerable<Voter>>> GetVoters()
        {
            var voters = await _mediator.Send(new GetVotersQuery());
            return Ok(voters);

        }

        [HttpPost("addvoters")]
        public async Task<ActionResult<int>> Save(CreateVoterCommand command)
        {
            var voterId = await _mediator.Send(command);
            return Ok(voterId);
        }

        [HttpPut("updateVoter/{id}")]
        public async Task<IActionResult> UpdateVoter(int id, [FromBody] Voter voter)
        {
            if (id != voter.Id)
            {
                return BadRequest();
            }

            var command = new CreateVoterCommand
            {
                Name = voter.Name
            };

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
