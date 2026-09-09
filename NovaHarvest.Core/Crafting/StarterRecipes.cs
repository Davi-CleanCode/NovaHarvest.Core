namespace NovaHarvest.Core.Crafting;
public static class StarterRecipes { public static IReadOnlyList<CraftingRecipe> Create()=>new List<CraftingRecipe>{
new CraftingRecipe("craft_farm_plot","Canteiro","farm_plot",1,new[]{new CraftingMaterial("alien_wood",5),new CraftingMaterial("stone",3)}),
new CraftingRecipe("craft_campfire","Fogueira","campfire",1,new[]{new CraftingMaterial("alien_wood",5),new CraftingMaterial("stone",2)}),
new CraftingRecipe("craft_chest","Baú","chest",1,new[]{new CraftingMaterial("alien_wood",8)}),
new CraftingRecipe("craft_pickaxe","Picareta Simples","pickaxe",1,new[]{new CraftingMaterial("alien_wood",3),new CraftingMaterial("stone",5)}),
new CraftingRecipe("craft_axe","Machado Simples","axe",1,new[]{new CraftingMaterial("alien_wood",3),new CraftingMaterial("stone",3)})}; }
