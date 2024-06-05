using Microsoft.EntityFrameworkCore;
using VotingAppAPI.Data;
using VotingAppAPI.Interfaces;
using VotingAppAPI.Models;

namespace VotingAppAPI.Services
{
    public class CandidatesService : ICandidates
    {
        private readonly VotingContext _context;

        public CandidatesService(VotingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Candidate>> GetCandidates()
        {
            return await _context.Candidates.ToListAsync();
        }
        public async Task<Candidate> AddCandidate(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();
            return candidate;

        }

        public async Task<Candidate> UpdateCandidate(int id, Candidate candidate)
        {
            if (id != candidate.Id)
            {
                return null;
            }
            _context.Entry(candidate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return candidate;
        }
    }
}
