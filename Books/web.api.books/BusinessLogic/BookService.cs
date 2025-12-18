using web.api.books.BusinessLogic.RequestModels;
using web.api.books.Contracts;
using web.api.books.Database;

namespace web.api.books.BusinessLogic;

internal class BookService(IBookRespository bookRepository) : IBookService
{
    public async Task CreateAsync(BookRequest book, CancellationToken cancellationToken = default)
    {
        var createdBook = new Book
        {
            Title = book.Title,
            Description = book.Description,
            Author = book.Author,
            Price = book.Price,
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow
        };

        await bookRepository.CreateAsync(createdBook, cancellationToken);
    }

    public async Task<List<Book>> GetAllBooksAsync(CancellationToken cancellationToken)
    {
        return await bookRepository.GetAllBooksAsync(cancellationToken);
    }
}
