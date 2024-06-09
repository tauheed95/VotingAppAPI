using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Candidates.Command;
using VotingApp.Application.Candidates.Handlers;
using VotingApp.Persistence;

namespace VotingApp.Application.Tests.Candidates.Handlers
{
    public class CreateCandidateCommandHandlerTests
    {
        [Fact]
        public async Task Handle_GivenValidRequest_ShouldCreateCandidate()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<VotingContext>()
                .UseInMemoryDatabase(databaseName: "VotingAppTest")
                .Options;

            using var context = new VotingContext(options);
            var handler = new CreateCandidateCommandHandler(context);

            var command = new CreateCandidateCommand
            {
                Name = "Test Candidate"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            var candidate = await context.Candidates.FindAsync(result);
            Assert.NotNull(candidate);
            Assert.Equal("Test Candidate", candidate.Name);
        }
    }
}