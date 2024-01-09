namespace gma_news_api.Presentation.Requests;

public class GetSectionNews
{
    public string[]? SubSection { get; set; }
    public required int Page { get; set; }
    public required int PageSize { get; set; }
    public string? SortColumn { get; set; }
    public string? SortOrder { get; set; }
}
