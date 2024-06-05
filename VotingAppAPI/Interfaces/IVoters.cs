using VotingAppAPI.Models;

namespace VotingAppAPI.Interfaces
{
    public interface IVoters
    {
        Task<IEnumerable<Voter>> GetVoters();
        Task<Voter> AddVoter(Voter voter);
        Task<Voter> UpdateVoter(int id, Voter voter);
    }
}
