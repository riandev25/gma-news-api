namespace gma_news_api.Presentation.Tests.Unit.Endpoints;
using System;
using System.Threading.Tasks;
using gma_news_api.Application.News.Entities;
using gma_news_api.Presentation.Endpoints;
using gma_news_api.Presentation.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using FluentAssertions;
using Queries = Application.News.Queries;
using Xunit;
using System.Collections.Generic;

public class NewsEndpointTests
{
    [Fact]
    public async Task GetSectionNews_ShouldReturn_Ok()
    {
        //Arrange
        var mediator = Substitute.For<IMediator>();
        var section = "sports";
        var request = new GetSectionNews
        {
            SubSection = ["Basketball"],
            Page = 1,
            PageSize = 10,
        };
        var expectedGuid = Guid.NewGuid();
        var expectedTitle = "Expected Title";
        var expectedNewsUrl = new Uri("https://example.com/news");
        var expectedImageUrl = new Uri("https://example.com/image");
        var expectedSection = "sports";
        var expectedSubSection = "Basketball";
        var expectedDateTimeUploaded = DateTime.UtcNow;
        _ = mediator
            //.Send(Arg.Any<Queries.GetSectionNews.GetSectionNewsQuery>())
            .Send(Arg.Is<Queries.GetSectionNews.GetSectionNewsQuery>(query =>
                query.Section == section &&
                (query.SubSection == request.SubSection || (query.SubSection == null && request.SubSection == null)) &&
                query.Page == request.Page &&
                query.PageSize == request.PageSize &&
                (query.SortColumn == request.SortColumn || (query.SortColumn == null && request.SortColumn == null)) &&
                (query.SortOrder == request.SortOrder || (query.SortOrder == null && request.SortOrder == null))))
            .ReturnsForAnyArgs(
            [
                new News()
                {
                    Id = expectedGuid,
                    Title = expectedTitle,
                    NewsUrl = expectedNewsUrl,
                    ImageUrl = expectedImageUrl,
                    Section = expectedSection,
                    SubSection = expectedSubSection,
                    DateTimeUploaded = expectedDateTimeUploaded
                }
            ]);

        // Act
        var response = await NewsEndpoints.GetSectionNews(section, request, mediator);

        // Assert
        var result = response.Should().BeOfType<Ok<List<News>>>().Subject;
        _ = result.StatusCode.Should().Be(StatusCodes.Status200OK);
        var value = result.Value.Should().BeOfType<List<News>>();
        _ = value.Subject.ElementAt(0).Id.Should().Be(expectedGuid);
        _ = value.Subject.ElementAt(0).Title.Should().Be(expectedTitle);
        _ = value.Subject.ElementAt(0).NewsUrl.Should().Be(expectedNewsUrl);
        _ = value.Subject.ElementAt(0).ImageUrl.Should().Be(expectedImageUrl);
        _ = value.Subject.ElementAt(0).DateTimeUploaded.Should().Be(expectedDateTimeUploaded);
    }
}
