using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal;

public class CatApiDbContext : DbContext
{
    public CatApiDbContext(DbContextOptions<CatApiDbContext> options)
        : base(options) { }

    public DbSet<Cat> Cats { get; set; }
    public DbSet<Owner> Owners { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cat>()
            .HasMany(c => c.Friends).WithMany();
    }
}