namespace VotingApp.Application.Candidates.Queries
{
    /// <summary>
    /// Data Transfer Object for Candidate.
    /// </summary>
    public class CandidateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Votes { get; set; }
    }
}
