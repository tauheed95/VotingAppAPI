#region Using Directives
using MediatR;
#endregion

namespace VotingApp.Application.Voters.Commands
{
    /// <summary>
    /// Command to create a new voter.
    /// </summary>
    public class CreateVoterCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
