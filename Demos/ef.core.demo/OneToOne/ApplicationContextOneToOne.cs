using Microsoft.EntityFrameworkCore;

namespace ef.core.demo.OneToOne;

public class ApplicationContextOneToOne : DbContext
{
    public DbSet<UserOneToOne> Users { get; set; } = null!;

    public DbSet<UserProfileOneToOne> UserProfiles { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DemosOneToOne1;Username=postgres;Password=topiho99");
    }
}
