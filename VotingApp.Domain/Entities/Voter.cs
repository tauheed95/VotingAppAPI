namespace VotingApp.Domain.Entities
{
    /// <summary>
    /// Represents a voter in the voting system.
    /// </summary>
    public class Voter
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool HasVoted { get; set; }
    }
}
