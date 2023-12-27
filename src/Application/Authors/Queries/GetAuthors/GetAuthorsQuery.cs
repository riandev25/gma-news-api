namespace gma_news_api.Application.Authors.Queries.GetAuthors;

using Entities;
using MediatR;

public class GetAuthorsQuery : IRequest<List<Author>>
{
}
