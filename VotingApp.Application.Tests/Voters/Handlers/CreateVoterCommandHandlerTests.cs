using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Voters.Commands;
using VotingApp.Application.Voters.Handlers;
using VotingApp.Persistence;

namespace VotingApp.Application.Tests.Voters.Handlers
{
    public class CreateVoterCommandHandlerTests
    {
        [Fact]
        public async Task Handle_GivenValidRequest_ShouldCreateVoter()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<VotingContext>()
                .UseInMemoryDatabase(databaseName: "VotingAppTest")
                .Options;

            using var context = new VotingContext(options);
            var handler = new CreateVoterCommandHandler(context);

            var command = new CreateVoterCommand
            {
                Name = "Test Voter"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            var voter = await context.Voters.FindAsync(result);
            Assert.NotNull(voter);
            Assert.Equal("Test Voter", voter.Name);
        }
    }
}
