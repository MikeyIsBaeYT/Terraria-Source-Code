// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.CampsiteBiome
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
  public class CampsiteBiome : MicroBiome
  {
    public override bool Place(Point origin, StructureMap structures)
    {
      Ref<int> count1 = new Ref<int>(0);
      Ref<int> count2 = new Ref<int>(0);
      WorldUtils.Gen(origin, (GenShape) new Shapes.Circle(10), Actions.Chain((GenAction) new Actions.Scanner(count2), (GenAction) new Modifiers.IsSolid(), (GenAction) new Actions.Scanner(count1)));
      if (count1.Value < count2.Value - 5)
        return false;
      int radius = GenBase._random.Next(6, 10);
      int num1 = GenBase._random.Next(5);
      if (!structures.CanPlace(new Microsoft.Xna.Framework.Rectangle(origin.X - radius, origin.Y - radius, radius * 2, radius * 2)))
        return false;
      ShapeData data = new ShapeData();
      WorldUtils.Gen(origin, (GenShape) new Shapes.Slime(radius), Actions.Chain(new Modifiers.Blotches(num1, num1, num1, 1).Output(data), (GenAction) new Modifiers.Offset(0, -2), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 53
      }), (GenAction) new Actions.SetTile((ushort) 397, true), (GenAction) new Modifiers.OnlyWalls(new byte[1]), (GenAction) new Actions.PlaceWall((byte) 16)));
      WorldUtils.Gen(origin, (GenShape) new ModShapes.All(data), Actions.Chain((GenAction) new Actions.ClearTile(), (GenAction) new Actions.SetLiquid(value: (byte) 0), (GenAction) new Actions.SetFrames(true), (GenAction) new Modifiers.OnlyWalls(new byte[1]), (GenAction) new Actions.PlaceWall((byte) 16)));
      Point result;
      if (!WorldUtils.Find(origin, Searches.Chain((GenSearch) new Searches.Down(10), (GenCondition) new Conditions.IsSolid()), out result))
        return false;
      int j = result.Y - 1;
      bool flag = GenBase._random.Next() % 2 == 0;
      if (GenBase._random.Next() % 10 != 0)
      {
        int num2 = GenBase._random.Next(1, 4);
        int num3 = flag ? 4 : -(radius >> 1);
        for (int index1 = 0; index1 < num2; ++index1)
        {
          int num4 = GenBase._random.Next(1, 3);
          for (int index2 = 0; index2 < num4; ++index2)
            WorldGen.PlaceTile(origin.X + num3 - index1, j - index2, 331);
        }
      }
      int num5 = (radius - 3) * (flag ? -1 : 1);
      if (GenBase._random.Next() % 10 != 0)
        WorldGen.PlaceTile(origin.X + num5, j, 186);
      if (GenBase._random.Next() % 10 != 0)
      {
        WorldGen.PlaceTile(origin.X, j, 215, true);
        if (GenBase._tiles[origin.X, j].active() && GenBase._tiles[origin.X, j].type == (ushort) 215)
        {
          GenBase._tiles[origin.X, j].frameY += (short) 36;
          GenBase._tiles[origin.X - 1, j].frameY += (short) 36;
          GenBase._tiles[origin.X + 1, j].frameY += (short) 36;
          GenBase._tiles[origin.X, j - 1].frameY += (short) 36;
          GenBase._tiles[origin.X - 1, j - 1].frameY += (short) 36;
          GenBase._tiles[origin.X + 1, j - 1].frameY += (short) 36;
        }
      }
      structures.AddStructure(new Microsoft.Xna.Framework.Rectangle(origin.X - radius, origin.Y - radius, radius * 2, radius * 2), 4);
      return true;
    }
  }
}
