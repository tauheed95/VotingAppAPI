using Microsoft.EntityFrameworkCore;
using VotingApp.Domain.Entities;

namespace VotingApp.Persistence
{
    public class VotingContext : DbContext
    {
        public VotingContext(DbContextOptions<VotingContext> options) : base(options) { }

        public DbSet<Voter> Voters { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
    }
    
}
