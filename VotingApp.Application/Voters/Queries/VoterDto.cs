namespace VotingApp.Application.Voters.Queries
{
    /// <summary>
    /// Data Transfer Object for Voter.
    /// </summary>
    public class VoterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasVoted { get; set; }
    }
}
