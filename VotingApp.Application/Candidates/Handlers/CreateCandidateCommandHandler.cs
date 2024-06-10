#region Using Directives
using MediatR;
using VotingApp.Application.Candidates.Command;
using VotingApp.Domain.Entities;
using VotingApp.Persistence;
#endregion

namespace VotingApp.Application.Candidates.Handlers
{
    /// <summary>
    /// Handles the creation of a new candidate.
    /// </summary>
    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, int>
    {
        private readonly VotingContext _context;

        public CreateCandidateCommandHandler(VotingContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = new Candidate
            {
                Name = request.Name,
                Votes = 0
            };

            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync(cancellationToken);

            return candidate.Id;
        }
    }
}
