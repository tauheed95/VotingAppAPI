using Microsoft.AspNetCore.Mvc;
using VotingAppAPI.Interfaces;
using VotingAppAPI.Models;

namespace VotingAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidates _candidatesService;

        public CandidatesController(ICandidates candidatesService)
        {
            _candidatesService = candidatesService;
        }

        [HttpGet("getcandidateslist")]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidates()
        {
            var list = await _candidatesService.GetCandidates();
            return Ok(list);
        }

        [HttpPost("addcandidates")]
        public async Task<ActionResult<Candidate>> Save(Candidate candidate)
        {
            var createdCandidate = await _candidatesService.AddCandidate(candidate);
            return CreatedAtAction(nameof(GetCandidates), new { id = createdCandidate.Id }, createdCandidate);
        }

        [HttpPut("updateCandidate/{id}")]
        public async Task<IActionResult> UpdateCandidate(int id, Candidate candidate)
        {
            if (id != candidate.Id)
            {
                return BadRequest();
            }

            var updatedCandidate = await _candidatesService.UpdateCandidate(id, candidate);
            if (updatedCandidate == null)
            {
                return BadRequest();
            }

            return NoContent();

        }
    }
}
