using MediatR;
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Voters.Queries
{
    public class GetVotersQuery : IRequest<List<Voter>>
    {
    }
}
