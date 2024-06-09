using AutoMapper;
using VotingApp.Application.Candidates.Queries;
using VotingApp.Application.Voters.Queries;
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Voter, VoterDto>();
            CreateMap<Candidate, CandidateDto>();
        }
    }
}
