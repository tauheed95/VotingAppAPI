#region Using Directives
using MediatR;
#endregion

namespace VotingApp.Application.Candidates.Command
{
    /// <summary>
    /// Command to create a new candidate.
    /// </summary>
    public class CreateCandidateCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
