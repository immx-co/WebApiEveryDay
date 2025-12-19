namespace web.api.books.BusinessLogic.RequestModels;

public class BookUpdateRequest
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Author { get; set; }

    public decimal? Price { get; set; }
}
