using GearShare.Application.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GearShare.Infrastructure.Identity;

namespace GearShare.Infrastructure.Persistence;

public class GearShareDbContext(DbContextOptions<GearShareDbContext> options)
    : IdentityUserContext<AppUser, Guid>(options)
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Item> Items => Set<Item>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GearShareDbContext).Assembly);
    }
}