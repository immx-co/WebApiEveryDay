using category.core.Models;
using Microsoft.EntityFrameworkCore;

namespace category.persistance;

public class ApplicationContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(e =>
        {
            e.ToTable("Categories");
            e.Property(e => e.Name).HasMaxLength(20);
        });
    }
}
