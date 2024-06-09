using MediatR;
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
            var voter = await _context.Voters.FindAsync(request.VoterId);
            if (voter == null || voter.HasVoted)
            {
                return false; // Voter either doesn't exist or has already voted
            }

            var candidate = await _context.Candidates.FindAsync(request.CandidateId);
            if (candidate == null)
            {
                return false; // Candidate doesn't exist
            }

            voter.HasVoted = true;
            candidate.Votes++;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
