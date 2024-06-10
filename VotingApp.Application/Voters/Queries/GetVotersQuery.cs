#region Using Directives
using MediatR;
#endregion


namespace VotingApp.Application.Voters.Queries
{
    /// <summary>
    /// Query to get a list of all voters.
    /// </summary>
    public class GetVotersQuery : IRequest<List<VoterDto>>
    {
    }
}
