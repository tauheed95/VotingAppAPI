#region Using Directives
using MediatR;
using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Voters.Commands;
using VotingApp.Persistence;
#endregion

namespace VotingApp.Application.Voters.Handlers
{
    /// <summary>
    /// Handles the command to cast a vote for a candidate.
    /// </summary>
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
