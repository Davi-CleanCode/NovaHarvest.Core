namespace NovaHarvest.Core.Models;

public enum ItemType { Resource, Seed, Crop, Tool, Food, Quest, Building, Artifact }
public sealed class Item
{
    public string Id { get; }
    public string Name { get; }
    public ItemType Type { get; }
    public int MaxStack { get; }
    public Item(string id, string name, ItemType type, int maxStack = 99) { Id = id; Name = name; Type = type; MaxStack = maxStack; }
}
