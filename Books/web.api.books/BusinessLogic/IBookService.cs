using web.api.books.BusinessLogic.RequestModels;
using web.api.books.Contracts;

namespace web.api.books.BusinessLogic;

public interface IBookService
{
    Task CreateAsync(BookRequest book, CancellationToken cancellationToken = default);

    Task<List<Book>> GetAllBooksAsync(CancellationToken cancellationToken = default);

    Task<Book> GetBookAsync(int id, CancellationToken cancellationToken = default);

    Task<int> DeleteBookByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<Book> UpdateBookAsync(int id, BookUpdateRequest book, CancellationToken cancellationToken = default);
}
