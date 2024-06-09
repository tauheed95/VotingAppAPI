using MediatR;

namespace VotingApp.Application.Voters.Commands
{
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
