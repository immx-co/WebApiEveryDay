namespace web.api.books.BusinessLogic.RequestModels;

public class BookRequest
{
    public required string Title { get; set; }

    public required string Description { get; set; }

    public required string Author { get; set; }

    public required decimal Price { get; set; }
}
