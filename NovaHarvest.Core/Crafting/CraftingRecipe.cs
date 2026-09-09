namespace NovaHarvest.Core.Crafting;
public sealed class CraftingMaterial { public string ItemId{get;} public int Amount{get;} public CraftingMaterial(string itemId,int amount){ItemId=itemId;Amount=Math.Max(1,amount);} }
public sealed class CraftingRecipe { public string Id{get;} public string Name{get;} public string ResultItemId{get;} public int ResultAmount{get;} public IReadOnlyList<CraftingMaterial> Materials{get;}
public CraftingRecipe(string id,string name,string resultItemId,int resultAmount,IEnumerable<CraftingMaterial> materials){Id=id;Name=name;ResultItemId=resultItemId;ResultAmount=Math.Max(1,resultAmount);Materials=materials.ToList();} }
