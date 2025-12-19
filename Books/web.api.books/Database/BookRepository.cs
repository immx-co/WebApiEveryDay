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

    /// <inheritdoc />
    public async Task<List<Book>> GetAllBooksAsync(CancellationToken cancellationToken)
    {
        return await context.Books.ToListAsync();
    }

    /// <inheritdoc />
    public async Task<Book> GetBookAsync(int id, CancellationToken cancellationToken)
    {
        var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
        if(book is null)
            throw new NullReferenceException($"Книга с Id == {id} не существует.");

        return book;
    }

    /// <inheritdoc />
    public async Task<int> DeleteBookById(int id, CancellationToken cancellationToken)
    {
        var bookToDelete = await context.Books.FirstOrDefaultAsync(b => b.Id == id);

        if (bookToDelete is null)
            throw new NullReferenceException($"Книга с Id == {id} не существует.");

        context.Books.Remove(bookToDelete);

        await context.SaveChangesAsync();

        return bookToDelete.Id;
    }

    /// <inheritdoc />
    public async Task<Book> UpdateBook(int id, BookUpdate book, CancellationToken cancellationToken)
    {
        var findedBook = await context.Books.FirstOrDefaultAsync(b => b.Id == id);

        if(findedBook is null)
            throw new NullReferenceException($"Книга с Id == {id} не существует.");

        if (book.Title is not null)
            findedBook.Title = book.Title;

        if(book.Description is not null)
            findedBook.Description = book.Description;

        if(book.Author is not null)
            findedBook.Author = book.Author;

        if (book.Price is not null)
            findedBook.Price = (decimal)book.Price;

        findedBook.Updated = DateTime.UtcNow;

        context.Books.Update(findedBook);
        await context.SaveChangesAsync();

        return findedBook;
    }
}
