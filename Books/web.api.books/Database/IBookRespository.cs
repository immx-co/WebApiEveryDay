using System.Runtime.CompilerServices;
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
    /// <returns>Created book.</returns>
    Task CreateAsync(Book book, CancellationToken cancellationToken);

    /// <summary>
    /// Get all books from the database.
    /// </summary>
    /// <param name="cancellationToken">Token of cancell.</param>
    /// <returns>All books from the database.</returns>
    Task<List<Book>> GetAllBooksAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Get book by id.
    /// </summary>
    /// <param name="id">Book id.</param>
    /// <param name="cancellationToken">Token of cancell.</param>
    /// <returns>Book by id from the database.</returns>
    Task<Book> GetBookAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Delete book by id.
    /// </summary>
    /// <param name="id">Book id.</param>
    /// <param name="cancellationToken">Token of cancell.</param>
    /// <returns>Id of deleted book.</returns>
    Task<int> DeleteBookById(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Update book by id.
    /// </summary>
    /// <param name="id">Book id.</param>
    /// <param name="updatedBook">Updated model of book.</param>
    /// <param name="cancellationToken">Token of cancell.</param>
    /// <returns>Updated book in the database.</returns>
    Task<Book> UpdateBook(int id, BookUpdate updatedBook, CancellationToken cancellationToken);
}
