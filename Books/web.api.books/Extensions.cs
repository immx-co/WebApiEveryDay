using Microsoft.EntityFrameworkCore;
using web.api.books.BusinessLogic;
using web.api.books.Database;

namespace web.api.books;

public static class Extensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IBookRespository, BookRepository>();
        serviceCollection.AddDbContext<ApplicationContext>(x =>
        {
            x.UseNpgsql("Host=localhost;Port=5432;Database=BooksDb;Username=postgres;Password=topiho99");
        });

        return serviceCollection;
    }

    public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IBookService, BookService>();

        return serviceCollection;
    }
}
