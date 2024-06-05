using Microsoft.AspNetCore.Mvc;
using VotingAppAPI.Interfaces;
using VotingAppAPI.Models;

namespace VotingAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotersController : ControllerBase
    {
        private readonly IVoters _votersService;
        public VotersController(IVoters votersService)
        {
            _votersService = votersService;
        }

        [HttpGet("getvoterslist")]
        public async Task<ActionResult<IEnumerable<Voter>>> GetVoters()
        {
            var list = await _votersService.GetVoters();
            return Ok(list);

        }

        [HttpPost("addvoters")]
        public async Task<ActionResult<Voter>> Save(Voter voter)
        {
            var createdVoter = await _votersService.AddVoter(voter);
            return CreatedAtAction(nameof(GetVoters), new { id = createdVoter.Id }, createdVoter);
        }

        [HttpPut("updateVoter/{id}")]
        public async Task<IActionResult> UpdateVoter(int id, Voter voter)
        {
            if (id != voter.Id)
            {
                return BadRequest();
            }

            var updatedVoter = await _votersService.UpdateVoter(id, voter);
            if (updatedVoter == null)
            {
                return BadRequest();
            }
            return NoContent();
        }

    }
}
