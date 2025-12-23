using Microsoft.EntityFrameworkCore;
using web.api.orders.Contracts;

namespace web.api.orders.Database;

public class ApplicationContext : DbContext
{
    public DbSet<Item> Items { get; set; }

    public DbSet<Order> Orders { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemBase>(e =>
        {
            e.ToTable("Items");
            e.Property(x => x.Price).HasPrecision(10, 2);
        });

        modelBuilder.Entity<Order>(e =>
        {
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Order>().Property(x => x.Price).HasPrecision(10, 2);
        });
    }
}
