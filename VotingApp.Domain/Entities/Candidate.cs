namespace VotingApp.Domain.Entities
{
    /// <summary>
    /// Represents a candidate in the voting system.
    /// </summary>
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Votes { get; set; }
    }
}
