#region Using Directives
using AutoMapper;
using VotingApp.Application.Candidates.Queries;
using VotingApp.Application.Voters.Queries;
using VotingApp.Domain.Entities;
#endregion

namespace VotingApp.Application.Common.Mappings
{
    /// <summary>
    /// Mapping profile for AutoMapper.
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Voter, VoterDto>();
            CreateMap<Candidate, CandidateDto>();
        }
    }
}
