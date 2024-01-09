//namespace gma_news_api.Application.News.Queries.GetSectionNews;

//using gma_news_api.Application.News.Entities;
//using MediatR;
//public class GetSectionNewsQuery(string? section, string[]? subSection, int page, int pageSize, string? sortColumn, string? sortOrder) : IRequest<List<News>>
//{
//    public string? Section { get; set; } = section;
//    public string[]? SubSection { get; set; } = subSection;
//    public int Page { get; set; } = page;
//    public int PageSize { get; set; } = pageSize;
//    public string? SortColumn { get; set; } = sortColumn;
//    public string? SortOrder { get; set; } = sortOrder;
//}

namespace gma_news_api.Application.News.Queries.GetSectionNews;

using gma_news_api.Application.News.Entities;
using MediatR;
public class GetSectionNewsQuery : IRequest<List<News>>
{
    public required string Section { get; set; }
    public string[]? SubSection { get; set; }
    public required int Page { get; set; }
    public required int PageSize { get; set; }
    public string? SortColumn { get; set; }
    public string? SortOrder { get; set; }
}

