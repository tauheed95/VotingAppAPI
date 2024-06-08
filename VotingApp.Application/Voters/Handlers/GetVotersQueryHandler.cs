using MediatR;
using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Voters.Queries;
using VotingApp.Domain.Entities;
using VotingApp.Persistence;

namespace VotingApp.Application.Voters.Handlers
{
    public class GetVotersQueryHandler : IRequestHandler<GetVotersQuery, List<Voter>>
    {
        private readonly VotingContext _context;

        public GetVotersQueryHandler(VotingContext context)
        {
            _context = context;
        }

        public async Task<List<Voter>> Handle(GetVotersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Voters.ToListAsync(cancellationToken);
        }
    }
}
