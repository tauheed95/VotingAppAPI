using Microsoft.AspNetCore.Mvc;
using Moq;
using VotingAppAPI.Controllers;
using VotingAppAPI.Interfaces;
using VotingAppAPI.Models;

namespace VotingApp.Tests
{
    public class CandidatesControllerTests
    {
        private readonly Mock<ICandidates> _mockCandidatesService;
        private readonly CandidatesController _controller;

        public CandidatesControllerTests()
        {
            _mockCandidatesService = new Mock<ICandidates>();
            _controller = new CandidatesController(_mockCandidatesService.Object);
        }

        [Fact]
        public async Task GetCandidates_ReturnsAllCandidates()
        {
            // Arrange
            var candidates = new List<Candidate>
            {
                new Candidate { Id = 1, Name = "Alice", Votes = 10 },
                new Candidate { Id = 2, Name = "Bob", Votes = 20 }
            };
            _mockCandidatesService.Setup(service => service.GetCandidates()).ReturnsAsync(candidates);

            // Act
            var result = await _controller.GetCandidates();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Candidate>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedCandidates = Assert.IsAssignableFrom<IEnumerable<Candidate>>(okResult.Value);
            Assert.Equal(2, returnedCandidates.Count());
        }

        [Fact]
        public async Task PostCandidate_AddsCandidate()
        {
            // Arrange
            var newCandidate = new Candidate { Id = 3, Name = "Charlie", Votes = 0 };
            _mockCandidatesService.Setup(service => service.AddCandidate(It.IsAny<Candidate>())).ReturnsAsync(newCandidate);

            // Act
            var result = await _controller.Save(newCandidate);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Candidate>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var candidate = Assert.IsType<Candidate>(createdAtActionResult.Value);
            Assert.Equal("Charlie", candidate.Name);
        }

        [Fact]
        public async Task PutCandidate_UpdatesCandidate()
        {
            // Arrange
            var candidate = new Candidate { Id = 1, Name = "Alice Updated", Votes = 15 };
            _mockCandidatesService.Setup(service => service.UpdateCandidate(1, candidate)).ReturnsAsync(candidate);

            // Act
            var result = await _controller.UpdateCandidate(1, candidate);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task PutCandidate_ReturnsBadRequest_WhenIdMismatch()
        {
            // Arrange
            var updatedCandidate = new Candidate { Id = 2, Name = "Alice Updated", Votes = 15 };

            // Act
            var result = await _controller.UpdateCandidate(1, updatedCandidate);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
