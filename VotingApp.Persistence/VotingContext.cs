#region Using Directives
using Microsoft.EntityFrameworkCore;
using VotingApp.Domain.Entities;
#endregion

namespace VotingApp.Persistence
{
    /// <summary>
    /// Database context for the voting application.
    /// </summary>
    public class VotingContext : DbContext
    {
        public VotingContext(DbContextOptions<VotingContext> options) : base(options) { }

        public DbSet<Voter> Voters { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
    }
    
}
