namespace web.api.books.Contracts;

/// <summary>
/// Update model for book.
/// </summary>
public class BookUpdate
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Author { get; set; }

    public decimal? Price { get; set; }
}
