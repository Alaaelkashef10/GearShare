namespace GearShare.Application.Entities;
public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public List<Item> Items { get; set; } = [];
}