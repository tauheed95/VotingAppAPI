using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Candidates.Queries;
using VotingApp.Domain.Entities;
using VotingApp.Persistence;

namespace VotingApp.Application.Candidates.Handlers
{
    public class GetCandidatesQueryHandler : IRequestHandler<GetCandidatesQuery, List<CandidateDto>>
    {
        private readonly VotingContext _context;
        private readonly IMapper _mapper;
        public GetCandidatesQueryHandler(VotingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CandidateDto>> Handle(GetCandidatesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Candidates
                .ProjectTo<CandidateDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
