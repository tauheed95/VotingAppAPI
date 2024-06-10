#region Using Directives
using MediatR;
using VotingApp.Application.Voters.Commands;
using VotingApp.Domain.Entities;
using VotingApp.Persistence;
#endregion

namespace VotingApp.Application.Voters.Handlers
{
    /// <summary>
    /// Handles the creation of a new voter.
    /// </summary>
    public class CreateVoterCommandHandler : IRequestHandler<CreateVoterCommand, int>
    {
        private readonly VotingContext _context;

        public CreateVoterCommandHandler(VotingContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateVoterCommand request, CancellationToken cancellationToken)
        {
            var voter = new Voter
            {
                Name = request.Name,
                HasVoted = false
            };

            _context.Voters.Add(voter);
            await _context.SaveChangesAsync(cancellationToken);

            return voter.Id;
        }
    }
}
