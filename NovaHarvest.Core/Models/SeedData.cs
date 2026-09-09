namespace NovaHarvest.Core.Models;

public sealed class SeedData
{
    public string SeedItemId { get; }
    public string CropItemId { get; }
    public int GrowthDays { get; }
    public int WaterRequiredPerDay { get; }
    public int HarvestAmount { get; }
    public SeedData(string seedItemId, string cropItemId, int growthDays, int waterRequiredPerDay, int harvestAmount = 1) { SeedItemId = seedItemId; CropItemId = cropItemId; GrowthDays = Math.Max(1, growthDays); WaterRequiredPerDay = Math.Max(0, waterRequiredPerDay); HarvestAmount = Math.Max(1, harvestAmount); }
}
