using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Voters.Commands;
using VotingApp.Application.Voters.Handlers;
using VotingApp.Persistence;

namespace VotingApp.Application.Tests.Voters.Handlers
{
    public class CreateVoterCommandHandlerTests
    {
        private readonly VotingContext _context;
        private readonly CreateVoterCommandHandler _handler;

        public CreateVoterCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<VotingContext>()
                .UseInMemoryDatabase(databaseName: "VotingAppTest")
                .Options;

            _context = new VotingContext(options);
            _handler = new CreateVoterCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_ShouldCreateNewVoter()
        {
            // Arrange
            var command = new CreateVoterCommand { Name = "John Doe" };

            // Act
            var voterId = await _handler.Handle(command, CancellationToken.None);

            // Assert
            var voter = await _context.Voters.FindAsync(voterId);
            Assert.NotNull(voter);
            Assert.Equal("John Doe", voter.Name);
            Assert.False(voter.HasVoted);
        }
    }
}
