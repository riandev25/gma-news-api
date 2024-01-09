namespace gma_news_api.Application.News.Queries.GetSectionNews;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using gma_news_api.Application.News.Entities;
using MediatR;

public class GetSectionNewsHandler(INewsRepository repository) : IRequestHandler<GetSectionNewsQuery, List<News>>
{
    public async Task<List<News>> Handle(GetSectionNewsQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetSectionNews(request, cancellationToken);
    }
}
