﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Voters.Commands;
using VotingApp.Application.Voters.Queries;

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
        public async Task<ActionResult<IEnumerable<VoterDto>>> GetVoters()
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

    }
}
