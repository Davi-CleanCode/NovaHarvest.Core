namespace NovaHarvest.Core.Models;
public enum CropState { Empty, Planted, Growing, ReadyToHarvest, Dead }
public sealed class FarmPlot { public int Id{get;} public CropState State{get;private set;}=CropState.Empty; public string? SeedId{get;private set;} public int GrowthDay{get;private set;} public int WateredOnDay{get;private set;}=-1;
public FarmPlot(int id){Id=id;} public bool Plant(string seedId){if(string.IsNullOrWhiteSpace(seedId)||State!=CropState.Empty)return false;SeedId=seedId;GrowthDay=0;WateredOnDay=-1;State=CropState.Planted;return true;}
public bool Water(int day){if(State is CropState.Empty or CropState.ReadyToHarvest or CropState.Dead||WateredOnDay==day)return false;WateredOnDay=day;return true;}
internal void AdvanceDay(int completedDay,SeedData seed){if(State is CropState.Empty or CropState.ReadyToHarvest or CropState.Dead)return;if(WateredOnDay!=completedDay){State=CropState.Dead;return;}GrowthDay++;State=GrowthDay>=seed.GrowthDays?CropState.ReadyToHarvest:CropState.Growing;}
public int Harvest(SeedData seed){if(State!=CropState.ReadyToHarvest)return 0;State=CropState.Empty;SeedId=null;GrowthDay=0;WateredOnDay=-1;return seed.HarvestAmount;} }
