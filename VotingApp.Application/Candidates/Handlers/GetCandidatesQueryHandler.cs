﻿#region Using Directives
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Candidates.Queries;
using VotingApp.Persistence;
#endregion

namespace VotingApp.Application.Candidates.Handlers
{
    /// <summary>
    /// Handles the query to get a list of all candidates.
    /// </summary>
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
