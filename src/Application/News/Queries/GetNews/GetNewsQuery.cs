namespace gma_news_api.Application.News.Queries.GetSportsNews;

using gma_news_api.Application.News.Entities;
using MediatR;

public class GetNewsQuery(string[]? section, string[]? subSection) : IRequest<List<News>>
{
    public string[]? Section { get; set; } = section;
    public string[]? SubSection { get; set; } = subSection;
}

