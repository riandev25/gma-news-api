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
            .WithDescription("\n    GET /News");

        //_ = root.MapGet("/", GetAuthors)
        //    .Produces<List<Entities.Author>>()
        //    .ProducesProblem(StatusCodes.Status500InternalServerError)
        //    .WithSummary("Lookup all Authors")
        //    .WithDescription("\n    GET /Authors");

        //_ = root.MapGet("/{id}", GetAuthorById)
        //    .AddEndpointFilter<ValidationFilter<Guid>>()
        //    .Produces<Entities.Author>()
        //    .ProducesValidationProblem()
        //    .ProducesProblem(StatusCodes.Status404NotFound)
        //    .ProducesProblem(StatusCodes.Status500InternalServerError)
        //    .WithSummary("Lookup an Author by their Id")
        //    .WithDescription("\n    GET /Authors/00000000-0000-0000-0000-000000000000");

        return app;
    }

    public static async Task<IResult> GetNews([FromQuery] string? section,
    [FromQuery] string? subSection, IMediator mediator)
    {
        try
        {
            return Results.Ok(await mediator.Send(new Queries.GetNews.GetNewsQuery(section, subSection)));
        } catch (Exception ex)
        {
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);

        }
    }
}

