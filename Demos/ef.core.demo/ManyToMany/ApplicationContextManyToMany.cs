using Microsoft.EntityFrameworkCore;

namespace ef.core.demo.ManyToMany;

public class ApplicationContextManyToMany : DbContext
{
    public DbSet<Course> Courses { get; set; } = null!;

    public DbSet<Student> Students { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DemosManyToMany1;Username=postgres;Password=topiho99");
    }
}
