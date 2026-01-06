using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef.core.demo.ForegnKey;

public class ApplicationContextForeignKey : DbContext
{
    public DbSet<UserForeignKey> Users { get; set; } = null!;

    public DbSet<CompanyForeignKey> Companies { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Demos1;Username=postgres;Password=topiho99");
    }
}
