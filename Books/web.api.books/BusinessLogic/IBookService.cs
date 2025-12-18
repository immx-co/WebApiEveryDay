using web.api.books.BusinessLogic.RequestModels;
using web.api.books.Contracts;

namespace web.api.books.BusinessLogic;

public interface IBookService
{
    Task CreateAsync(BookRequest book, CancellationToken cancellationToken = default);

    Task<List<Book>> GetAllBooksAsync(CancellationToken cancellationToken = default);
}
