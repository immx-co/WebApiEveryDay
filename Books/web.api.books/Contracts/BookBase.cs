namespace web.api.books.Contracts;

/// <summary>
/// Base model of book description.
/// </summary>
public class BookBase
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Author { get; set; }

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }

    public decimal Price { get; set; }
}

