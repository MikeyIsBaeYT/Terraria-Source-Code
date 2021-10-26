// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.StructureMap
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ID;

namespace Terraria.WorldBuilding
{
  public class StructureMap
  {
    private readonly List<Microsoft.Xna.Framework.Rectangle> _structures = new List<Microsoft.Xna.Framework.Rectangle>(2048);
    private readonly List<Microsoft.Xna.Framework.Rectangle> _protectedStructures = new List<Microsoft.Xna.Framework.Rectangle>(2048);
    private readonly object _lock = new object();

    public bool CanPlace(Microsoft.Xna.Framework.Rectangle area, int padding = 0) => this.CanPlace(area, TileID.Sets.GeneralPlacementTiles, padding);

    public bool CanPlace(Microsoft.Xna.Framework.Rectangle area, bool[] validTiles, int padding = 0)
    {
      lock (this._lock)
      {
        if (area.X < 0 || area.Y < 0 || area.X + area.Width > Main.maxTilesX - 1 || area.Y + area.Height > Main.maxTilesY - 1)
          return false;
        Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(area.X - padding, area.Y - padding, area.Width + padding * 2, area.Height + padding * 2);
        for (int index = 0; index < this._protectedStructures.Count; ++index)
        {
          if (rectangle.Intersects(this._protectedStructures[index]))
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
    }

    public Microsoft.Xna.Framework.Rectangle GetBoundingBox()
    {
      lock (this._lock)
      {
        if (this._structures.Count == 0)
          return Microsoft.Xna.Framework.Rectangle.Empty;
        Point point1 = new Point(this._structures.Min<Microsoft.Xna.Framework.Rectangle>((Func<Microsoft.Xna.Framework.Rectangle, int>) (rect => rect.Left)), this._structures.Min<Microsoft.Xna.Framework.Rectangle>((Func<Microsoft.Xna.Framework.Rectangle, int>) (rect => rect.Top)));
        Point point2 = new Point(this._structures.Max<Microsoft.Xna.Framework.Rectangle>((Func<Microsoft.Xna.Framework.Rectangle, int>) (rect => rect.Right)), this._structures.Max<Microsoft.Xna.Framework.Rectangle>((Func<Microsoft.Xna.Framework.Rectangle, int>) (rect => rect.Bottom)));
        return new Microsoft.Xna.Framework.Rectangle(point1.X, point1.Y, point2.X - point1.X, point2.Y - point1.Y);
      }
    }

    public void AddStructure(Microsoft.Xna.Framework.Rectangle area, int padding = 0)
    {
      lock (this._lock)
      {
        area.Inflate(padding, padding);
        this._structures.Add(area);
      }
    }

    public void AddProtectedStructure(Microsoft.Xna.Framework.Rectangle area, int padding = 0)
    {
      lock (this._lock)
      {
        area.Inflate(padding, padding);
        this._structures.Add(area);
        this._protectedStructures.Add(area);
      }
    }

    public void Reset()
    {
      lock (this._lock)
        this._protectedStructures.Clear();
    }
  }
}
