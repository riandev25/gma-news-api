namespace gma_news_api.Application.News;
using System.Threading.Tasks;
using Entities;
using gma_news_api.Application.News.Queries.GetSectionNews;
using gma_news_api.Application.News.Queries.GetSportsNews;

public interface INewsRepository
{
    Task<List<News>> GetNews(GetNewsQuery request, CancellationToken cancellationToken);
    Task<List<News>> GetSectionNews(GetSectionNewsQuery request, CancellationToken cancellationToken);
}
