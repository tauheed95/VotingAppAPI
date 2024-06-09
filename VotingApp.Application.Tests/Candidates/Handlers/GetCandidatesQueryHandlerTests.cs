using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Candidates.Handlers;
using VotingApp.Application.Candidates.Queries;
using VotingApp.Application.Common.Mappings;
using VotingApp.Domain.Entities;
using VotingApp.Persistence;

namespace VotingApp.Application.Tests.Candidates.Handlers
{
    public class GetCandidatesQueryHandlerTests
    {
        private readonly IMapper _mapper;
        public GetCandidatesQueryHandlerTests()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public async Task Handle_GivenRequest_ShouldReturnListOfCandidates()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<VotingContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Use a unique database name for each test
                .Options;

            using var context = new VotingContext(options);

            // Clear any pre-existing data in the context (if necessary)
            context.Candidates.RemoveRange(context.Candidates);
            await context.SaveChangesAsync();

            context.Candidates.Add(new Candidate { Name = "Test Candidate 1" });
            context.Candidates.Add(new Candidate { Name = "Test Candidate 2" });
            await context.SaveChangesAsync();

            var handler = new GetCandidatesQueryHandler(context, _mapper);

            // Act
            var result = await handler.Handle(new GetCandidatesQuery(), CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Count);
        }
    }
}
