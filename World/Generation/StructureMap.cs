// Decompiled with JetBrains decompiler
// Type: Terraria.World.Generation.StructureMap
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;
using Terraria.ID;

namespace Terraria.World.Generation
{
  public class StructureMap
  {
    private List<Microsoft.Xna.Framework.Rectangle> _structures = new List<Microsoft.Xna.Framework.Rectangle>(2048);

    public bool CanPlace(Microsoft.Xna.Framework.Rectangle area, int padding = 0) => this.CanPlace(area, TileID.Sets.GeneralPlacementTiles, padding);

    public bool CanPlace(Microsoft.Xna.Framework.Rectangle area, bool[] validTiles, int padding = 0)
    {
      if (area.X < 0 || area.Y < 0 || area.X + area.Width > Main.maxTilesX - 1 || area.Y + area.Height > Main.maxTilesY - 1)
        return false;
      Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(area.X - padding, area.Y - padding, area.Width + padding * 2, area.Height + padding * 2);
      for (int index = 0; index < this._structures.Count; ++index)
      {
        if (rectangle.Intersects(this._structures[index]))
          return false;
      }
      for (int x = rectangle.X; x < rectangle.X + rectangle.Width; ++x)
      {
        for (int y = rectangle.Y; y < rectangle.Y + rectangle.Height; ++y)
        {
          if (Main.tile[x, y].active())
          {
            ushort type = Main.tile[x, y].type;
            if (!validTiles[(int) type])
              return false;
          }
        }
      }
      return true;
    }

    public void AddStructure(Microsoft.Xna.Framework.Rectangle area, int padding = 0) => this._structures.Add(new Microsoft.Xna.Framework.Rectangle(area.X - padding, area.Y - padding, area.Width + padding * 2, area.Height + padding * 2));

    public void Reset() => this._structures.Clear();
  }
}
