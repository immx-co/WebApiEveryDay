using Microsoft.EntityFrameworkCore;
using web.api.books.Contracts;

namespace web.api.books.Database;

public class ApplicationContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasKey(x => x.Id);
        modelBuilder.Entity<Book>().Property(x => x.Title).HasMaxLength(50);
        modelBuilder.Entity<Book>().Property(x => x.Description).HasMaxLength(150);
        modelBuilder.Entity<Book>().Property(x => x.Price).HasPrecision(10, 2);

        base.OnModelCreating(modelBuilder);
    }
}
