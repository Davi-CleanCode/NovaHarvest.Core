using NovaHarvest.Core.Models;

namespace NovaHarvest.Core.Systems;

public sealed class FarmingSystem
{
    private readonly Dictionary<string, SeedData> _seeds;

    private readonly Inventory _inventory;

    public FarmingSystem(
        IEnumerable<SeedData> seeds,
        Inventory inventory)
    {
        _seeds = seeds.ToDictionary(
            x => x.SeedItemId);

        _inventory = inventory;
    }

    public bool Plant(
        FarmPlot plot,
        string seedId)
    {
        if (!_seeds.ContainsKey(seedId))
            return false;

        if (!_inventory.Remove(seedId))
            return false;

        if (!plot.Plant(seedId))
        {
            _inventory.Add(seedId);
            return false;
        }

        return true;
    }

    public bool Water(
        FarmPlot plot,
        int day)
    {
        return plot.Water(day);
    }

    public void AdvanceDay(
        IEnumerable<FarmPlot> plots,
        int day)
    {
        foreach (var plot in plots)
        {
            if (plot.SeedId is not { } seedId)
                continue;

            if (!_seeds.TryGetValue(
                seedId,
                out var seed))
            {
                continue;
            }

            plot.AdvanceDay(
                day,
                seed);
        }
    }

    public bool Harvest(
        FarmPlot plot,
        out int amount)
    {
        amount = 0;

        if (plot.SeedId is not { } seedId)
            return false;

        if (!_seeds.TryGetValue(
            seedId,
            out var seed))
        {
            return false;
        }

        amount = plot.Harvest(seed);

        if (amount <= 0)
            return false;

        _inventory.Add(
            seed.CropItemId,
            amount);

        return true;
    }
}