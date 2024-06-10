#region Using Directives
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Voters.Queries;
using VotingApp.Persistence;
#endregion

namespace VotingApp.Application.Voters.Handlers
{
    /// <summary>
    /// Handles the query to get a list of all voters.
    /// </summary>
    public class GetVotersQueryHandler : IRequestHandler<GetVotersQuery, List<VoterDto>>
    {
        private readonly VotingContext _context;
        private readonly IMapper _mapper;

        public GetVotersQueryHandler(VotingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<VoterDto>> Handle(GetVotersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Voters
              .ProjectTo<VoterDto>(_mapper.ConfigurationProvider)
              .ToListAsync(cancellationToken);
        }
    }
}
