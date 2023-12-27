namespace gma_news_api.Application.News;
using System.Threading.Tasks;
using Entities;
using gma_news_api.Application.News.Queries.GetNews;

public interface INewsRepository
{
    Task<List<News>> GetNews(GetNewsQuery request, CancellationToken cancellationToken);
}
