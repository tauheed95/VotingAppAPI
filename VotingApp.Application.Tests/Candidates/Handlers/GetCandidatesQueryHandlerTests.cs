using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Candidates.Handlers;
using VotingApp.Application.Candidates.Queries;
using VotingApp.Domain.Entities;
using VotingApp.Persistence;

namespace VotingApp.Application.Tests.Candidates.Handlers
{
    public class GetCandidatesQueryHandlerTests : IClassFixture<TestDbContextFixture>
    {
        private readonly VotingContext _context;
        private readonly GetCandidatesQueryHandler _handler;

        public GetCandidatesQueryHandlerTests(TestDbContextFixture fixture)
        {
            _context = fixture.Context;
            _handler = new GetCandidatesQueryHandler(_context);

            // Ensure a clean state before each test
            _context.Candidates.RemoveRange(_context.Candidates);
            _context.Candidates.AddRange(
                new Candidate { Name = "Alice Forgusan", Votes = 0 },
                new Candidate { Name = "Alice Forgusan", Votes = 1 });
            _context.SaveChanges();
        }

        [Fact]
        public async Task Handle_ShouldReturnAllCandidates()
        {
            // Arrange
            var query = new GetCandidatesQuery();

            // Act
            var candidates = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(2, candidates.Count);
            Assert.Contains(candidates, c => c.Name == "Alice Forgusan");
            Assert.Contains(candidates, c => c.Name == "Alice Forgusan");
        }
    }
}
