namespace GearShare.Application.Entities;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public string AssetTag { get; set; } = "";

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public ItemCondition Condition { get; set; }
    public ItemStatus Status { get; set; } = ItemStatus.Available;

    public decimal ReplacementCost { get; set; }
    public decimal? DailyLateFeeOverride { get; set; }

    public uint Version { get; set; }
}