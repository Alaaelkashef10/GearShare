using GearShare.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GearShare.Infrastructure.Data;

public class GearShareDbContext(DbContextOptions<GearShareDbContext> options)
    : IdentityUserContext<AppUser, Guid>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AppUser>(user =>
        {
            user.Property(u => u.DisplayName).IsRequired().HasMaxLength(100);
            user.Property(u => u.Role).HasConversion<string>().HasMaxLength(20);
            user.Property(u => u.Status).HasConversion<string>().HasMaxLength(20);
            user.Property(u => u.SuspensionReason).HasMaxLength(500);

            // Identity already defines this index; make it unique.
            user.HasIndex(u => u.NormalizedEmail).IsUnique();
        });
    }
}