using web.api.books.Contracts;

namespace web.api.books.Database;

/// <summary>
/// Books repository.
/// </summary>
public interface IBookRespository
{
    /// <summary>
    /// Create book in the database.
    /// </summary>
    /// <param name="book">Added book.</param>
    /// <param name="cancellationToken">Token of cancell.</param>
    /// <returns></returns>
    Task CreateAsync(Book book, CancellationToken cancellationToken);

    /// <summary>
    /// Get all books from the database.
    /// </summary>
    /// <param name="cancellationToken">Token of cancell.</param>
    /// <returns></returns>
    Task<List<Book>> GetAllBooksAsync(CancellationToken cancellationToken);
}
