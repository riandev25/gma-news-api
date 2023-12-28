namespace gma_news_api.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities = Application.News.Entities;
using Queries = Application.News.Queries;

public static class NewsEndpoints
{
    public static WebApplication MapNewsEndpoints(this WebApplication app)
    {
        var root = app.MapGroup("/api/news")
            .WithTags("news")
            .WithOpenApi();

        _ = root.MapGet("/", GetNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all news")
            .WithDescription("\n    GET /news");

        _ = root.MapGet("/topstories", GetTopStoriesNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all top stories news")
            .WithDescription("\n    GET /news/topstories");

        _ = root.MapGet("/money", GetMoneyNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all top stories news")
            .WithDescription("\n    GET /news/money");

        _ = root.MapGet("/sports", GetSportsNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all sports news")
            .WithDescription("\n    GET /news/sports");

        _ = root.MapGet("/pinoyabroad", GetPinoyAbroadNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all sports news")
            .WithDescription("\n    GET /news/pinoyabroad");

        _ = root.MapGet("/scitech", GetScitechNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all science and technology news")
            .WithDescription("\n    GET /news/scitech");

        _ = root.MapGet("/showbiz", GetShowbizNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all showbiz news")
            .WithDescription("\n    GET /news/showbiz");

        _ = root.MapGet("/lifestyle", GetLifestyleNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all lifestyle news")
            .WithDescription("\n    GET /news/lifestyle");

        _ = root.MapGet("/opinion", GetOpinionNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all opinion news")
            .WithDescription("\n    GET /news/opinion");

        _ = root.MapGet("/hashtag", GetHashtagNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all hashtag news")
            .WithDescription("\n    GET /news/hashtag");

        _ = root.MapGet("/serbisyopubliko", GetSerbisyoPublikoNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all serbisyo publiko news")
            .WithDescription("\n    GET /news/serbisyopubliko");

        _ = root.MapGet("/cbb", GetCbbNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all cbb news")
            .WithDescription("\n    GET /news/cbb");

        return app;
    }

    public static async Task<IResult> GetNews([FromQuery] string[]? section,
    [FromQuery] string[]? subSection, IMediator mediator)
    {
        try
        {
            return Results.Ok(await mediator.Send(new Queries.GetSportsNews.GetNewsQuery(section, subSection)));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);

        }
    }
    public static async Task<IResult> GetTopStoriesNews([FromQuery] string[]? subSection, IMediator mediator)
    {
        return await GetSectionNews("topstories", subSection, mediator);
    }
    public static async Task<IResult> GetMoneyNews([FromQuery] string[]? subSection, IMediator mediator)
    {
        return await GetSectionNews("money", subSection, mediator);
    }
    public static async Task<IResult> GetSportsNews([FromQuery] string[]? subSection, IMediator mediator)
    {
        return await GetSectionNews("sports", subSection, mediator);
    }
    public static async Task<IResult> GetPinoyAbroadNews([FromQuery] string[]? subSection, IMediator mediator)
    {
        return await GetSectionNews("pinoyabroad", subSection, mediator);
    }
    public static async Task<IResult> GetScitechNews([FromQuery] string[]? subSection, IMediator mediator)
    {
        return await GetSectionNews("scitech", subSection, mediator);
    }
    public static async Task<IResult> GetShowbizNews([FromQuery] string[]? subSection, IMediator mediator)
    {
        return await GetSectionNews("showbiz", subSection, mediator);
    }
    public static async Task<IResult> GetLifestyleNews([FromQuery] string[]? subSection, IMediator mediator)
    {
        return await GetSectionNews("lifestyle", subSection, mediator);
    }
    public static async Task<IResult> GetOpinionNews([FromQuery] string[]? subSection, IMediator mediator)
    {
        return await GetSectionNews("opinion", subSection, mediator);
    }
    public static async Task<IResult> GetHashtagNews([FromQuery] string[]? subSection, IMediator mediator)
    {
        return await GetSectionNews("hashtag", subSection, mediator);
    }
    public static async Task<IResult> GetSerbisyoPublikoNews([FromQuery] string[]? subSection, IMediator mediator)
    {
        return await GetSectionNews("serbisyopubliko", subSection, mediator);
    }
    public static async Task<IResult> GetCbbNews([FromQuery] string[]? subSection, IMediator mediator)
    {
        return await GetSectionNews("cbb", subSection, mediator);
    }
    private static async Task<IResult> GetSectionNews(string section, string[]? subSection, IMediator mediator)
    {
        try
        {
            return Results.Ok(await mediator.Send(new Queries.GetSectionNews.GetSectionNewsQuery(section, subSection)));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

}

