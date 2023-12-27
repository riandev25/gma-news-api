namespace gma_news_api.Presentation.Requests;

public class UpdateReviewRequest
{
    public Guid AuthorId { get; init; }

    public Guid MovieId { get; init; }

    public int Stars { get; init; }
}
