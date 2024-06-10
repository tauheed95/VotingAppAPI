#region Using Directives
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Candidates.Command;
using VotingApp.Application.Candidates.Queries;
#endregion

namespace VotingAppAPI.Controllers
{
    /// <summary>
    /// Controller for managing candidates.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets the list of all candidates.
        /// </summary>
        /// <returns>List of candidates.</returns>
        [HttpGet("getcandidateslist")]
        public async Task<ActionResult<IEnumerable<CandidateDto>>> GetCandidates()
        {
            var candidates = await _mediator.Send(new GetCandidatesQuery());
            return Ok(candidates);
        }

        /// <summary>
        /// Creates a new candidate.
        /// </summary>
        /// <param name="command">The create candidate command.</param>
        /// <returns>The ID of the created candidate.</returns>
        [HttpPost("addcandidates")]
        public async Task<ActionResult<int>> Save(CreateCandidateCommand command)
        {
            var candidateId = await _mediator.Send(command);
            return Ok(candidateId);
        }
      
    }
}
