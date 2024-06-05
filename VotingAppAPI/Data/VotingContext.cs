using Microsoft.EntityFrameworkCore;
using VotingAppAPI.Models;

namespace VotingAppAPI.Data
{
    public class VotingContext : DbContext
    {
        public VotingContext(DbContextOptions<VotingContext> options) : base(options) { }
        public virtual DbSet<Voter> Voters { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }
    }
}

