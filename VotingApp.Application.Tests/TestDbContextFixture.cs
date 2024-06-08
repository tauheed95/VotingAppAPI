using Microsoft.EntityFrameworkCore;
using VotingApp.Persistence;

namespace VotingApp.Application.Tests
{
    public class TestDbContextFixture : IDisposable
    {
        public VotingContext Context { get; private set; }

        public TestDbContextFixture()
        {
            var options = new DbContextOptionsBuilder<VotingContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            Context = new VotingContext(options);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
