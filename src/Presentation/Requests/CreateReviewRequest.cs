namespace gma_news_api.Presentation.Requests;

public class CreateReviewRequest
{
    public Guid AuthorId { get; init; }

    public Guid MovieId { get; init; }

    public int Stars { get; init; }
}
