using Microsoft.EntityFrameworkCore;

namespace ef.core.demo.OneToMany;

public class ApplicationContextOneToMany : DbContext
{
    public DbSet<CompanyOneToMany> Company { get; set; } = null!;

    public DbSet<UserOneToMany> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DemosOneToMany1;Username=postgres;Password=topiho99");
    }
}
