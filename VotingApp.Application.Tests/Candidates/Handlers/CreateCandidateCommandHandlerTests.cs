using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Candidates.Command;
using VotingApp.Application.Candidates.Handlers;
using VotingApp.Persistence;

namespace VotingApp.Application.Tests.Candidates.Handlers
{
    public class CreateCandidateCommandHandlerTests
    {
        private readonly VotingContext _context;
        private readonly CreateCandidateCommandHandler _handler;

        public CreateCandidateCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<VotingContext>()
                .UseInMemoryDatabase(databaseName: "VotingAppTest")
                .Options;

            _context = new VotingContext(options);
            _handler = new CreateCandidateCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_ShouldCreateNewCandidate()
        {
            // Arrange
            var command = new CreateCandidateCommand { Name = "John Doe" };

            // Act
            var candidateId = await _handler.Handle(command, CancellationToken.None);

            // Assert
            var candidate = await _context.Candidates.FindAsync(candidateId);
            Assert.NotNull(candidate);
            Assert.Equal("John Doe", candidate.Name);
            Assert.Equal(0, candidate.Votes);
        }
    }
}