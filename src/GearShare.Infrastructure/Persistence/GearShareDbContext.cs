using GearShare.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace GearShare.Infrastructure.Persistence;

public class GearShareDbContext(DbContextOptions<GearShareDbContext> options)
    : DbContext(options)
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Item> Items => Set<Item>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GearShareDbContext).Assembly);
    }
}