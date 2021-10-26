// Decompiled with JetBrains decompiler
// Type: Terraria.Modules.TileObjectBaseModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Terraria.DataStructures;
using Terraria.Enums;

namespace Terraria.Modules
{
  public class TileObjectBaseModule
  {
    public int width;
    public int height;
    public Point16 origin;
    public TileObjectDirection direction;
    public int randomRange;
    public bool flattenAnchors;

    public TileObjectBaseModule(TileObjectBaseModule copyFrom = null)
    {
      if (copyFrom == null)
      {
        this.width = 1;
        this.height = 1;
        this.origin = Point16.Zero;
        this.direction = TileObjectDirection.None;
        this.randomRange = 0;
        this.flattenAnchors = false;
      }
      else
      {
        this.width = copyFrom.width;
        this.height = copyFrom.height;
        this.origin = copyFrom.origin;
        this.direction = copyFrom.direction;
        this.randomRange = copyFrom.randomRange;
        this.flattenAnchors = copyFrom.flattenAnchors;
      }
    }
  }
}
