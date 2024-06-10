#region Using Directives
using MediatR;
#endregion

namespace VotingApp.Application.Voters.Commands
{
    /// <summary>
    /// Command to cast a vote for a candidate.
    /// </summary>
    public class VoteCommand : IRequest<bool>
    {
        public int VoterId { get; set; }
        public int CandidateId { get; set; }

        public VoteCommand(int voterId, int candidateId)
        {
            VoterId = voterId;
            CandidateId = candidateId;
        }
    }
}
