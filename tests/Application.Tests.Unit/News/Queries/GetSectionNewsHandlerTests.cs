namespace gma_news_api.Application.Tests.Unit.News.Queries;

using FluentAssertions;
using gma_news_api.Application.News;
using gma_news_api.Application.News.Entities;
using gma_news_api.Application.News.Queries.GetSectionNews;
using NSubstitute;
using Xunit;

public class GetSectionNewsHandlerTests
{
    [Fact]
    public async Task Handle_ShouldPassThrough_Query()
    {
        // Arrange
        var query = new GetSectionNewsQuery()
        {
            Section = "sports",
            SubSection = ["Basketball"],
            Page = 1,
            PageSize = 10
        };
        var context = Substitute.For<INewsRepository>();
        var handler = new GetSectionNewsHandler(context);
        var token = new CancellationTokenSource().Token;

        var expectedGuid = Guid.NewGuid();
        var expectedNewsUri = new Uri("https://sample.com");
        var expectedImageUri = new Uri("https://sample.com");
        var expectedDateTime = new DateTime(2022, 1, 1);

        _ = context.GetSectionNews(query, token).Returns(
        [
            new News
            {
                Id = expectedGuid,
                Title = "Title",
                NewsUrl = expectedNewsUri,
                ImageUrl = new Uri("https://sample.com"),
                Section = "sports",
                SubSection = "Basketball",
                DateTimeUploaded = expectedDateTime,
            }
        ]);

        // Act
        var result = await handler.Handle(query, token);

        // Assert
        _ = await context.Received(1).GetSectionNews(query, token);
        _ = result.Should().NotBeNull();
        _ = result.Should().BeOfType<List<News>>();

        _ = result[0].Id.Should().Be(expectedGuid);
        _ = result[0].Title.Should().Be("Title");
        _ = result[0].NewsUrl.Should().Be(expectedImageUri);
        _ = result[0].ImageUrl.Should().Be(expectedImageUri);
        _ = result[0].Section.Should().Be("sports");
        _ = result[0].SubSection.Should().Be("Basketball");
    }
}
