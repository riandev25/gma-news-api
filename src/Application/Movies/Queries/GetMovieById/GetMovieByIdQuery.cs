namespace gma_news_api.Application.Movies.Queries.GetMovieById;

using System.ComponentModel.DataAnnotations;
using Entities;
using MediatR;

public class GetMovieByIdQuery : IRequest<Movie>
{
    [Required]
    public Guid Id { get; init; }
}
