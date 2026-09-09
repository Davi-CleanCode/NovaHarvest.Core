namespace NovaHarvest.Core.World; public class WorldObject { public string Id{get;} public string Name{get;} public WorldObjectType Type{get;} public int X{get;} public int Y{get;} public bool IsInteractable{get;}
public WorldObject(string id,string name,WorldObjectType type,int x,int y,bool isInteractable=true){Id=id;Name=name;Type=type;X=x;Y=y;IsInteractable=isInteractable;} }
