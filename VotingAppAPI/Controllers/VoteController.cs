using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Voters.Commands;

namespace VotingAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Vote(int voterId, int candidateId)
        {
            var command = new VoteCommand(voterId, candidateId);
            var result = await _mediator.Send(command);

            if (!result)
            {
                return BadRequest("Voting operation failed. The voter might have already voted or the candidate might not exist.");
            }

            return Ok("Vote recorded successfully.");
        }
    }
}
