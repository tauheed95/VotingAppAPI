#region Using Directives
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Voters.Commands;
using VotingApp.Application.Voters.Queries;
#endregion

namespace VotingAppAPI.Controllers
{
    /// <summary>
    /// Controller for managing voters.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VotersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VotersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets the list of all voters.
        /// </summary>
        /// <returns>List of voters.</returns>
        [HttpGet("getvoterslist")]
        public async Task<ActionResult<IEnumerable<VoterDto>>> GetVoters()
        {
            var voters = await _mediator.Send(new GetVotersQuery());
            return Ok(voters);

        }

        /// <summary>
        /// Creates a new voter.
        /// </summary>
        /// <param name="command">The create voter command.</param>
        /// <returns>The ID of the created voter.</returns>
        [HttpPost("addvoters")]
        public async Task<ActionResult<int>> Save(CreateVoterCommand command)
        {
            var voterId = await _mediator.Send(command);
            return Ok(voterId);
        }     

    }
}
