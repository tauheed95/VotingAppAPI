using MediatR;

namespace VotingApp.Application.Voters.Commands
{
    public class CreateVoterCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
