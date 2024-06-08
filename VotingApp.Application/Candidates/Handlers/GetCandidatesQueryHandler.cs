using MediatR;
using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Candidates.Queries;
using VotingApp.Domain.Entities;
using VotingApp.Persistence;

namespace VotingApp.Application.Candidates.Handlers
{
    public class GetCandidatesQueryHandler : IRequestHandler<GetCandidatesQuery, List<Candidate>>
    {
        private readonly VotingContext _context;

        public GetCandidatesQueryHandler(VotingContext context)
        {
            _context = context;
        }

        public async Task<List<Candidate>> Handle(GetCandidatesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Candidates.ToListAsync(cancellationToken);
        }
    }
}
