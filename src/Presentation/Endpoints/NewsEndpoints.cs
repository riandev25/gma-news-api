namespace gma_news_api.Presentation.Endpoints;

using gma_news_api.Presentation.Filters;
using gma_news_api.Presentation.Requests;
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
            .AddEndpointFilter<ValidationFilter<GetSectionNews>>()
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
    public static async Task<IResult> GetTopStoriesNews([FromQuery] GetSectionNews request, IMediator mediator)
    {
        return await GetSectionNews("topstories", request, mediator);
    }
    public static async Task<IResult> GetMoneyNews([FromQuery] GetSectionNews request, IMediator mediator)
    {
        return await GetSectionNews("money", request, mediator);
    }
    public static async Task<IResult> GetSportsNews([FromQuery] GetSectionNews request, IMediator mediator)
    {
        return await GetSectionNews("sports", request, mediator);
    }
    public static async Task<IResult> GetPinoyAbroadNews([FromQuery] GetSectionNews request, IMediator mediator)
    {
        return await GetSectionNews("pinoyabroad", request, mediator);
    }
    public static async Task<IResult> GetScitechNews([FromQuery] GetSectionNews request, IMediator mediator)
    {
        return await GetSectionNews("scitech", request, mediator);
    }
    public static async Task<IResult> GetShowbizNews([FromQuery] GetSectionNews request, IMediator mediator)
    {
        return await GetSectionNews("showbiz", request, mediator);
    }
    public static async Task<IResult> GetLifestyleNews([FromQuery] GetSectionNews request, IMediator mediator)
    {
        return await GetSectionNews("lifestyle", request, mediator);
    }
    public static async Task<IResult> GetOpinionNews([FromQuery] GetSectionNews request, IMediator mediator)
    {
        return await GetSectionNews("opinion", request, mediator);
    }
    public static async Task<IResult> GetHashtagNews([FromQuery] GetSectionNews request, IMediator mediator)
    {
        return await GetSectionNews("hashtag", request, mediator);
    }
    public static async Task<IResult> GetSerbisyoPublikoNews([FromQuery] GetSectionNews request, IMediator mediator)
    {
        return await GetSectionNews("serbisyopubliko", request, mediator);
    }
    public static async Task<IResult> GetCbbNews([FromQuery] GetSectionNews request, IMediator mediator)
    {
        return await GetSectionNews("cbb", request, mediator);
    }
    public static async Task<IResult> GetSectionNews(string section, GetSectionNews request, IMediator mediator)
    {
        try
        {
            return Results.Ok(await mediator.Send(new Queries.GetSectionNews.GetSectionNewsQuery
            {
                Section = section,
                SubSection = request.SubSection,
                Page = request.Page,
                PageSize = request.PageSize,
                SortColumn = request.SortColumn,
                SortOrder = request.SortOrder
            }));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

}

