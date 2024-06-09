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
        public async Task<ActionResult<IEnumerable<CandidateDto>>> GetCandidates()
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
      
    }
}
