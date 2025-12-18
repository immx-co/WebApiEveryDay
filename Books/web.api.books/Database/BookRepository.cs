using Microsoft.EntityFrameworkCore;
using web.api.books.Contracts;

namespace web.api.books.Database;

internal class BookRepository(ApplicationContext context) : IBookRespository
{
    /// <inheritdoc />
    public async Task CreateAsync(Book book, CancellationToken cancellationToken)
    {
        await context.Books.AddAsync(book, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Book>> GetAllBooksAsync(CancellationToken cancellationToken)
    {
        return await context.Books.ToListAsync();
    }
}
