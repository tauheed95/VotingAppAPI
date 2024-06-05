using VotingAppAPI.Models;

namespace VotingAppAPI.Interfaces
{
    public interface ICandidates
    {
        Task<IEnumerable<Candidate>> GetCandidates();
        Task<Candidate> AddCandidate(Candidate candidate);
        Task<Candidate> UpdateCandidate(int id, Candidate candidate);
    }
}
