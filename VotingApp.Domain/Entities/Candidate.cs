namespace VotingApp.Domain.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Votes { get; set; }
    }
}
