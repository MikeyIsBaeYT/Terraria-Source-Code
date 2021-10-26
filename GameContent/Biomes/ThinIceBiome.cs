// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.ThinIceBiome
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Biomes
{
  public class ThinIceBiome : MicroBiome
  {
    public override bool Place(Point origin, StructureMap structures)
    {
      Dictionary<ushort, int> resultsOutput = new Dictionary<ushort, int>();
      WorldUtils.Gen(new Point(origin.X - 25, origin.Y - 25), (GenShape) new Shapes.Rectangle(50, 50), (GenAction) new Actions.TileScanner(new ushort[5]
      {
        (ushort) 0,
        (ushort) 59,
        (ushort) 147,
        (ushort) 1,
        (ushort) 225
      }).Output(resultsOutput));
      int num1 = resultsOutput[(ushort) 0] + resultsOutput[(ushort) 1];
      int num2 = resultsOutput[(ushort) 59];
      int num3 = resultsOutput[(ushort) 147];
      if (resultsOutput[(ushort) 225] > 0 || num3 <= num2 || num3 <= num1)
        return false;
      int num4 = 0;
      for (int radius = GenBase._random.Next(10, 15); radius > 5; --radius)
      {
        int num5 = GenBase._random.Next(-5, 5);
        WorldUtils.Gen(new Point(origin.X + num5, origin.Y + num4), (GenShape) new Shapes.Circle(radius), Actions.Chain((GenAction) new Modifiers.Blotches(4), (GenAction) new Modifiers.OnlyTiles(new ushort[5]
        {
          (ushort) 147,
          (ushort) 161,
          (ushort) 224,
          (ushort) 0,
          (ushort) 1
        }), (GenAction) new Actions.SetTile((ushort) 162, true)));
        WorldUtils.Gen(new Point(origin.X + num5, origin.Y + num4), (GenShape) new Shapes.Circle(radius), Actions.Chain((GenAction) new Modifiers.Blotches(4), (GenAction) new Modifiers.HasLiquid(), (GenAction) new Actions.SetTile((ushort) 162, true), (GenAction) new Actions.SetLiquid(value: (byte) 0)));
        num4 += radius - 2;
      }
      structures.AddStructure(new Microsoft.Xna.Framework.Rectangle(origin.X - 25, origin.Y - 25, 50, 50), 8);
      return true;
    }
  }
}
