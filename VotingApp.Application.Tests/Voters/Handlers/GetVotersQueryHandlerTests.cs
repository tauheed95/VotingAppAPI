using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Common.Mappings;
using VotingApp.Application.Voters.Handlers;
using VotingApp.Application.Voters.Queries;
using VotingApp.Domain.Entities;
using VotingApp.Persistence;

namespace VotingApp.Application.Tests.Voters.Handlers
{
    public class GetVotersQueryHandlerTests
    {
        private readonly IMapper _mapper;

        public GetVotersQueryHandlerTests()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public async Task Handle_GivenRequest_ShouldReturnListOfVoters()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<VotingContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Use a unique database name for each test
                .Options;

            using var context = new VotingContext(options);

            // Clear any pre-existing data in the context (if necessary)
            context.Candidates.RemoveRange(context.Candidates);
            await context.SaveChangesAsync();


            context.Voters.Add(new Voter { Name = "Test Voter 1" });
            context.Voters.Add(new Voter { Name = "Test Voter 2" });
            await context.SaveChangesAsync();

            var handler = new GetVotersQueryHandler(context, _mapper);

            // Act
            var result = await handler.Handle(new GetVotersQuery(), CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Count);
        }

    }
}
