using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using VotingApp.Application.Voters.Commands;
using VotingAppAPI.Controllers;

namespace VotingAppAPI.Tests.Controllers
{
    public class VoteControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly VoteController _controller;

        public VoteControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new VoteController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Vote_ShouldReturnOk_WhenVotingSucceeds()
        {
            // Arrange
            var voterId = 1;
            var candidateId = 1;
            _mediatorMock.Setup(m => m.Send(It.IsAny<VoteCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(true);

            // Act
            var result = await _controller.Vote(voterId, candidateId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Vote recorded successfully.", okResult.Value);
        }

        [Fact]
        public async Task Vote_ShouldReturnBadRequest_WhenVotingFails()
        {
            // Arrange
            var voterId = 1;
            var candidateId = 1;
            _mediatorMock.Setup(m => m.Send(It.IsAny<VoteCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(false);

            // Act
            var result = await _controller.Vote(voterId, candidateId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Voting operation failed. The voter might have already voted or the candidate might not exist.", badRequestResult.Value);
        }
    }
}
