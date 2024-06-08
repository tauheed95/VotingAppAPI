using MediatR;
namespace VotingApp.Application.Candidates.Command
{
    public class CreateCandidateCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
