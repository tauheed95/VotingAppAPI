using Microsoft.AspNetCore.Mvc;
using Moq;
using VotingAppAPI.Controllers;
using VotingAppAPI.Interfaces;
using VotingAppAPI.Models;

namespace VotingApp.Tests
{
    public class VotersControllerTests
    {
        private readonly Mock<IVoters> _mockVotersService;
        private readonly VotersController _controller;

        public VotersControllerTests()
        {
            _mockVotersService = new Mock<IVoters>();
            _controller = new VotersController(_mockVotersService.Object);
        }

        [Fact]
        public async Task GetVoters_ReturnsAllVoters()
        {
            // Arrange
            var voters = new List<Voter>
            {
                new Voter { Id = 1, Name = "Alice", HasVoted = false },
                new Voter { Id = 2, Name = "Bob", HasVoted = true }
            };
            _mockVotersService.Setup(service => service.GetVoters()).ReturnsAsync(voters);

            // Act
            var result = await _controller.GetVoters();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Voter>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedVoters = Assert.IsAssignableFrom<IEnumerable<Voter>>(okResult.Value);
            Assert.Equal(2, returnedVoters.Count());
        }

        [Fact]
        public async Task PostVoter_AddsVoter()
        {
            // Arrange
            var newVoter = new Voter { Id = 3, Name = "Charlie", HasVoted = false };
            _mockVotersService.Setup(service => service.AddVoter(It.IsAny<Voter>())).ReturnsAsync(newVoter);

            // Act
            var result = await _controller.Save(newVoter);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Voter>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var voter = Assert.IsType<Voter>(createdAtActionResult.Value);
            Assert.Equal("Charlie", voter.Name);
        }

        [Fact]
        public async Task PutVoter_UpdatesVoter()
        {
            // Arrange
            var voter = new Voter { Id = 1, Name = "Alice Updated", HasVoted = true };
            _mockVotersService.Setup(service => service.UpdateVoter(1, voter)).ReturnsAsync(voter);

            // Act
            var result = await _controller.UpdateVoter(1, voter);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task PutVoter_ReturnsBadRequest_WhenIdMismatch()
        {
            // Arrange
            var updatedVoter = new Voter { Id = 2, Name = "Alice Updated", HasVoted = true };

            // Act
            var result = await _controller.UpdateVoter(1, updatedVoter);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
