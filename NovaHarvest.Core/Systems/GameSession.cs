using NovaHarvest.Core.Crafting;
using NovaHarvest.Core.Models;
using NovaHarvest.Core.NPC;
using NovaHarvest.Core.NPC.Characters;
using NovaHarvest.Core.Player;
using NovaHarvest.Core.World;

namespace NovaHarvest.Core.Systems;

public sealed class GameSession
{
    public WorldManager World { get; }

    public PlayerController Player { get; }

    public Inventory Inventory { get; }

    public ProgressionSystem Progression { get; }

    public NPCManager NPCs { get; }

    public WorldTime Time { get; }

    public InteractionSystem Interaction { get; }

    public CraftingSystem Crafting { get; }

    public BuildingSystem Building { get; }

    public FarmingSystem Farming { get; }

    public ColonySystem Colony { get; }

    public QuestManager Quests { get; }

    public DialogueManager Dialogue { get; }

    public EventSystem Events { get; }

    public GameSession()
    {
        World = DemoWorld.Create();

        Player = new PlayerController(
            startX: 5,
            startY: 5);

        Inventory = new Inventory();

        Progression = new ProgressionSystem();

        NPCs = new NPCManager();

        Time = new WorldTime();

        Interaction = new InteractionSystem(
            Player,
            Inventory);

        Crafting = new CraftingSystem(
            Inventory);

        Building = new BuildingSystem(
            Player,
            Inventory,
            World);

        Farming = new FarmingSystem(
            StarterSeeds.Create(),
            Inventory);

        Colony = new ColonySystem(
            NPCs);

        Quests = new QuestManager(
            NPCs,
            Progression);

        Dialogue = new DialogueManager();

        Events = new EventSystem();

        InitializeCrafting();

        InitializeNPCs();

        InitializeQuests();

        InitializeStartingInventory();

        Time.NewDay += HandleNewDay;
    }

    private void InitializeCrafting()
    {
        foreach (var recipe in StarterRecipes.Create())
        {
            Crafting.AddRecipe(recipe);
        }
    }

    private void InitializeNPCs()
    {
        var lyra = Lyra.Create();

        NPCs.Add(lyra);
    }

    private void InitializeQuests()
    {
        var lyraQuest =
            LyraQuests.FirstQuest();

        Quests.Add(
            lyraQuest);
    }

    private void InitializeStartingInventory()
    {
        Inventory.Add(
            "seed_lumen_berry",
            5);

        Inventory.Add(
            "alien_wood",
            10);

        Inventory.Add(
            "stone",
            10);
    }

    private void HandleNewDay()
    {
        var farmPlots = World.Objects
            .OfType<FarmPlotObject>()
            .Select(x => x.Plot)
            .ToList();

        Farming.AdvanceDay(
            farmPlots,
            Time.Day);
    }
}