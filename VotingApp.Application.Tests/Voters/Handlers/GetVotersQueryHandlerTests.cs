using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Voters.Handlers;
using VotingApp.Application.Voters.Queries;
using VotingApp.Domain.Entities;
using VotingApp.Persistence;

namespace VotingApp.Application.Tests.Voters.Handlers
{
    public class GetVotersQueryHandlerTests: IClassFixture<TestDbContextFixture>
    {
        private readonly VotingContext _context;
        private readonly GetVotersQueryHandler _handler;

        public GetVotersQueryHandlerTests(TestDbContextFixture fixture)
        {
            _context = fixture.Context;
            _handler = new GetVotersQueryHandler(_context);

            // Ensure a clean state before each test
            _context.Voters.RemoveRange(_context.Voters);
            _context.Voters.AddRange(
                new Voter { Name = "John Doe", HasVoted = false },
                new Voter { Name = "Jane Doe", HasVoted = true });
            _context.SaveChanges();
        }

        [Fact]
        public async Task Handle_ShouldReturnAllVoters()
        {
            // Arrange
            var query = new GetVotersQuery();

            // Act
            var voters = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(2, voters.Count);
            Assert.Contains(voters, v => v.Name == "John Doe");
            Assert.Contains(voters, v => v.Name == "Jane Doe");
        }
    }
}
