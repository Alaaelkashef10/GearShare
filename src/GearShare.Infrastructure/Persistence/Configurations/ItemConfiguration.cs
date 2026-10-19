using GearShare.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GearShare.Infrastructure.Persistence.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        // Name is required and has a maximum length of 100 characters
        builder.Property(i => i.Name).HasMaxLength(100).IsRequired();
        // Description is optional and has a maximum length of 500 characters
        builder.Property(i => i.Description).HasMaxLength(500);
        // AssetTag is required and has a maximum length of 50 characters
        builder.Property(i => i.AssetTag).HasMaxLength(50).IsRequired();
        builder.HasIndex(i => i.AssetTag).IsUnique();
        // CategoryId is required and has a foreign key relationship with Category
        builder.HasOne(i => i.Category)
            .WithMany(c => c.Items)
            .HasForeignKey(i => i.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        // Condition is required and has a default value of ItemCondition.New
        builder.Property(i => i.Condition).HasConversion<string>().HasMaxLength(20);
        // Status is required and has a default value of ItemStatus.Available
        builder.Property(i => i.Status).HasConversion<string>().HasMaxLength(20);
        // ReplacementCost is required and has a precision of 10,2
        builder.Property(i => i.ReplacementCost).HasPrecision(10, 2);
        // DailyLateFeeOverride is optional and has a precision of 10,2
        builder.Property(i => i.DailyLateFeeOverride).HasPrecision(10, 2);
        // Version is required and is a concurrency token
        builder.Property(i => i.Version).IsRowVersion();

        builder.ToTable(t => t.HasCheckConstraint(
            "CK_Items_ReplacementCost_Positive", "\"ReplacementCost\" > 0"));
    }
}