namespace gma_news_api.Application.Tests.Unit.Movies.Queries.GetMovies;

using System.Threading;
using System.Threading.Tasks;
using Application.Movies;
using Application.Movies.Entities;
using Application.Movies.Queries.GetMovies;
using NSubstitute;
using FluentAssertions;
using Xunit;

public class GetMoviesHandlerTests
{
    [Fact]
    public async Task Handle_ShouldPassThrough_Query()
    {
        // Arrange
        var query = new GetMoviesQuery();

        var context = Substitute.For<IMoviesRepository>();
        var handler = new GetMoviesHandler(context);
        var token = new CancellationTokenSource().Token;

        _ = context.GetMovies(token).Returns(
        [
            new Movie
            {
                Id = Guid.Empty,
                Title = "Title"
            }
        ]);

        // Act
        var result = await handler.Handle(query, token);

        // Assert
        _ = await context.Received(1).GetMovies(token);
        _ = result.Should().NotBeNull();
        _ = result.Should().BeOfType<List<Movie>>();

        _ = result.Should().NotBeEmpty();
        _ = result.Count.Should().Be(1);

        _ = result[0].Id.Should().Be(Guid.Empty);
        _ = result[0].Title.Should().Be("Title");
    }
}
