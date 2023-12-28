namespace gma_news_api.Application.News.Queries.GetSectionNews;

using gma_news_api.Application.News.Entities;
using MediatR;
public class GetSectionNewsQuery(string? section, string[]? subSection) : IRequest<List<News>>
{
    public string? Section { get; set; } = section;
    public string[]? SubSection { get; set; } = subSection;
}
