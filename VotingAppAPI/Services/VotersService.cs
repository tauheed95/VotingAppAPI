using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VotingAppAPI.Data;
using VotingAppAPI.Interfaces;
using VotingAppAPI.Models;

namespace VotingAppAPI.Services
{
    public class VotersService : IVoters
    {
        private readonly VotingContext _context;

        public VotersService(VotingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Voter>> GetVoters()
        {
            return await _context.Voters.ToListAsync();
        }

        public async Task<Voter> AddVoter(Voter voter)
        {
            _context.Voters.Add(voter);
            await _context.SaveChangesAsync();
            return voter;
        }
        public async Task<Voter> UpdateVoter(int id, Voter voter)
        {
            if (id != voter.Id)
            {
                return null;
            }
            _context.Entry(voter).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return voter;

        }
    }
}
