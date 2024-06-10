#region Using Directives
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Voters.Commands;
#endregion

namespace VotingAppAPI.Controllers
{
    /// <summary>
    /// Controller for managing vote casting.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Casts a vote for a candidate.
        /// </summary>
        /// <param name="command">The vote command.</param>
        /// <returns>HTTP status.</returns>

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
