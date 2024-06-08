using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Candidates.Command;
using VotingApp.Application.Candidates.Queries;
using VotingApp.Domain.Entities;

namespace VotingAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getcandidateslist")]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidates()
        {
            var candidates = await _mediator.Send(new GetCandidatesQuery());
            return Ok(candidates);
        }

        [HttpPost("addcandidates")]
        public async Task<ActionResult<int>> Save(CreateCandidateCommand command)
        {
            var candidateId = await _mediator.Send(command);
            return Ok(candidateId);
        }

        [HttpPut("updateCandidate/{id}")]
        public async Task<IActionResult> UpdateCandidate(int id, [FromBody] Candidate candidate)
        {
            if (id != candidate.Id)
            {
                return BadRequest();
            }

            var command = new CreateCandidateCommand
            {
                Name = candidate.Name
            };

            await _mediator.Send(command);


            return NoContent();

        }
    }
}
