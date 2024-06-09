namespace VotingApp.Application.Voters.Queries
{
    public class VoterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasVoted { get; set; }
    }
}
