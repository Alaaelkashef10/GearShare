using GearShare.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GearShare.Infrastructure.Persistence.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        // DisplayName is required and has a maximum length of 100 characters
        builder.Property(u => u.DisplayName).HasMaxLength(100).IsRequired();
        // Role and Status are stored as text
        builder.Property(u => u.Role).HasConversion<string>().HasMaxLength(20);
        builder.Property(u => u.Status).HasConversion<string>().HasMaxLength(20);
        // SuspensionReason is optional and has a maximum length of 500 characters
        builder.Property(u => u.SuspensionReason).HasMaxLength(500);
        // Emails are unique; the normalizer trims and upper-cases, so case is ignored
        builder.HasIndex(u => u.NormalizedEmail).IsUnique();
    }
}