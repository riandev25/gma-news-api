namespace gma_news_api.Application.News.Entities;

using System.ComponentModel.DataAnnotations;

public record News
{
    [Key, Required]
    public Guid Id { get; init; }
    public string Title { get; init; }
    [Url]
    public Uri NewsUrl { get; init; }
    [Url]
    public Uri ImageUrl { get; init; }
    public string Section { get; init; }
    public string SubSection { get; init; }
    public DateTime DateTimeUploaded { get; init; }
}
