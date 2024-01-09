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

        _ = root.MapGet("/topstories", GetTopStoriesNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all top stories news. Select one or more sub sections (Ulat Filipino, Nation, World, Regions, Metro, Special Reports). Automatically choose all sub-sections if none are explicitly selected.")
            .WithDescription("\n    GET /news/topstories");

        _ = root.MapGet("/money", GetMoneyNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all money news. Select one or more sub sections (Economy, Personal Finance, Companies, Monitoring). Automatically choose all sub-sections if none are explicitly selected.")
            .WithDescription("\n    GET /news/money");

        _ = root.MapGet("/sports", GetSportsNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all sports news. Select one or more sub sections (Volleyball, Basketball, Boxing, Football). Automatically choose all sub-sections if none are explicitly selected.")
            .WithDescription("\n    GET /news/sports");

        _ = root.MapGet("/pinoyabroad", GetPinoyAbroadNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all pinoy abroad news. Select one or more sub sections (Dispatch, Pinoy Achievers, Immigration Guide). Automatically choose all sub-sections if none are explicitly selected.")
            .WithDescription("\n    GET /news/pinoyabroad");

        _ = root.MapGet("/scitech", GetScitechNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all science and technology news. Select one or more sub sections (Weather, Science and Research, Boxing, -Technology, Gadgets and Gaming-). Automatically choose all sub-sections if none are explicitly selected.")
            .WithDescription("\n    GET /news/scitech");

        _ = root.MapGet("/showbiz", GetShowbizNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all showbiz news. Select one or more sub sections (Pep, Chika Minute, Showbiz Abroad). Automatically choose all sub-sections if none are explicitly selected.")
            .WithDescription("\n    GET /news/showbiz");

        _ = root.MapGet("/lifestyle", GetLifestyleNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all lifestyle news. Select one or more sub sections (Family and Relationships, Travel, Food, Art and Culture, Health and Wellness, Shopping and Fashion, Hobbies and Activities). Automatically choose all sub-sections if none are explicitly selected.")
            .WithDescription("\n    GET /news/lifestyle");

        _ = root.MapGet("/opinion", GetOpinionNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all opinion news. Select one or more sub sections (News Hardcore). Automatically choose all sub-sections if none are explicitly selected.")
            .WithDescription("\n    GET /news/opinion");

        _ = root.MapGet("/hashtag", GetHashtagNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all hashtag news")
            .WithDescription("\n    GET /news/hashtag");

        _ = root.MapGet("/serbisyopubliko", GetSerbisyoPublikoNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all serbisyo publiko news. Select one or more sub sections (Walang Pasok, Transportation, Missing Persons). Automatically choose all sub-sections if none are explicitly selected.")
            .WithDescription("\n    GET /news/serbisyopubliko");

        _ = root.MapGet("/cbb", GetCbbNews)
            .Produces<List<Entities.News>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all cbb news")
            .WithDescription("\n    GET /news/cbb");

        return app;
    }
    public static async Task<IResult> GetTopStoriesNews([FromQuery] string[]? subSection, int page, int pageSize, string? sortColumn, string? sortOrder, IMediator mediator)
    {
        return await GetSectionNews("topstories", subSection, page, pageSize, sortColumn, sortOrder, mediator);
    }
    public static async Task<IResult> GetMoneyNews([FromQuery] string[]? subSection, int page, int pageSize, string? sortColumn, string? sortOrder, IMediator mediator)
    {
        return await GetSectionNews("money", subSection, page, pageSize, sortColumn, sortOrder, mediator);
    }
    public static async Task<IResult> GetSportsNews([FromQuery] string[]? subSection, int page, int pageSize, string? sortColumn, string? sortOrder, IMediator mediator)
    {
        return await GetSectionNews("sports", subSection, page, pageSize, sortColumn, sortOrder, mediator);
    }
    public static async Task<IResult> GetPinoyAbroadNews([FromQuery] string[]? subSection, int page, int pageSize, string? sortColumn, string? sortOrder, IMediator mediator)
    {
        return await GetSectionNews("pinoyabroad", subSection, page, pageSize, sortColumn, sortOrder, mediator);
    }
    public static async Task<IResult> GetScitechNews([FromQuery] string[]? subSection, int page, int pageSize, string? sortColumn, string? sortOrder, IMediator mediator)
    {
        return await GetSectionNews("scitech", subSection, page, pageSize, sortColumn, sortOrder, mediator);
    }
    public static async Task<IResult> GetShowbizNews([FromQuery] string[]? subSection, int page, int pageSize, string? sortColumn, string? sortOrder, IMediator mediator)
    {
        return await GetSectionNews("showbiz", subSection, page, pageSize, sortColumn, sortOrder, mediator);
    }
    public static async Task<IResult> GetLifestyleNews([FromQuery] string[]? subSection, int page, int pageSize, string? sortColumn, string? sortOrder, IMediator mediator)
    {
        return await GetSectionNews("lifestyle", subSection, page, pageSize, sortColumn, sortOrder, mediator);
    }
    public static async Task<IResult> GetOpinionNews([FromQuery] string[]? subSection, int page, int pageSize, string? sortColumn, string? sortOrder, IMediator mediator)
    {
        return await GetSectionNews("opinion", subSection, page, pageSize, sortColumn, sortOrder, mediator);
    }
    public static async Task<IResult> GetHashtagNews([FromQuery] string[]? subSection, int page, int pageSize, string? sortColumn, string? sortOrder, IMediator mediator)
    {
        return await GetSectionNews("hashtag", subSection, page, pageSize, sortColumn, sortOrder, mediator);
    }
    public static async Task<IResult> GetSerbisyoPublikoNews([FromQuery] string[]? subSection, int page, int pageSize, string? sortColumn, string? sortOrder, IMediator mediator)
    {
        return await GetSectionNews("serbisyopubliko", subSection, page, pageSize, sortColumn, sortOrder, mediator);
    }
    public static async Task<IResult> GetCbbNews([FromQuery] string[]? subSection, int page, int pageSize, string? sortColumn, string? sortOrder, IMediator mediator)
    {
        return await GetSectionNews("cbb", subSection, page, pageSize, sortColumn, sortOrder, mediator);
    }
    private static async Task<IResult> GetSectionNews(string section, string[]? subSection, int page, int pageSize, string? sortColumn, string? sortOrder, IMediator mediator)
    {
        try
        {
            return Results.Ok(await mediator.Send(new Queries.GetSectionNews.GetSectionNewsQuery
            {
                Section = section,
                SubSection = subSection,
                Page = page,
                PageSize = pageSize,
                SortColumn = sortColumn,
                SortOrder = sortOrder
            }));
            //return Results.Ok(await mediator.Send(new Queries.GetSectionNews.GetSectionNewsQuery(section, subSection, page, pageSize, sortColumn, sortOrder)));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

}

