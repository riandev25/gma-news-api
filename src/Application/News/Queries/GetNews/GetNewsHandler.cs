namespace gma_news_api.Application.News.Queries.GetSportsNews;

using gma_news_api.Application.News.Entities;
using MediatR;

public class GetNewsHandler(INewsRepository repository) : IRequestHandler<GetNewsQuery, List<News>>
{
    public async Task<List<News>> Handle(GetNewsQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetNews(request, cancellationToken);
    }
}

