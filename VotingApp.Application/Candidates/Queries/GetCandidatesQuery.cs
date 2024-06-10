#region Using Directives
using MediatR;
#endregion

namespace VotingApp.Application.Candidates.Queries
{
    /// <summary>
    /// Query to get a list of all candidates.
    /// </summary>
    public class GetCandidatesQuery : IRequest<List<CandidateDto>>
    {
    }
}
