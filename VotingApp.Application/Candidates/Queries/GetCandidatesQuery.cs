using MediatR;
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Candidates.Queries
{
    public class GetCandidatesQuery : IRequest<List<Candidate>>
    {
    }
}
