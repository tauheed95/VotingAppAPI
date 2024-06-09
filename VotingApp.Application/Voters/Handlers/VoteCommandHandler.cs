using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Application.Voters.Commands;
using VotingApp.Persistence;

namespace VotingApp.Application.Voters.Handlers
{
    public class VoteCommandHandler : IRequestHandler<VoteCommand, bool>
    {
        private readonly VotingContext _context;

        public VoteCommandHandler(VotingContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(VoteCommand request, CancellationToken cancellationToken)
        {
            var voter = await _context.Voters.FirstOrDefaultAsync(v => v.Id == request.VoterId, cancellationToken);
            var candidate = await _context.Candidates.FirstOrDefaultAsync(c => c.Id == request.CandidateId, cancellationToken);

            if (voter == null || candidate == null)
            {
                throw new Exception("Invalid voter or candidate.");
            }

            if (voter.HasVoted)
            {
                throw new Exception("Voter has already voted.");
            }


            voter.HasVoted = true;
            candidate.Votes++;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
