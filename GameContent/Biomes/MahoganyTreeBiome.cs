// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.MahoganyTreeBiome
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
  public class MahoganyTreeBiome : MicroBiome
  {
    public override bool Place(Point origin, StructureMap structures)
    {
      Point result1;
      if (!WorldUtils.Find(new Point(origin.X - 3, origin.Y), Searches.Chain((GenSearch) new Searches.Down(200), new Conditions.IsSolid().AreaAnd(6, 1)), out result1))
        return false;
      Point result2;
      if (!WorldUtils.Find(new Point(result1.X, result1.Y - 5), Searches.Chain((GenSearch) new Searches.Up(120), new Conditions.IsSolid().AreaOr(6, 1)), out result2) || result1.Y - 5 - result2.Y > 60 || result1.Y - result2.Y < 30 || !structures.CanPlace(new Microsoft.Xna.Framework.Rectangle(result1.X - 30, result1.Y - 60, 60, 90)))
        return false;
      Dictionary<ushort, int> resultsOutput = new Dictionary<ushort, int>();
      WorldUtils.Gen(new Point(result1.X - 25, result1.Y - 25), (GenShape) new Shapes.Rectangle(50, 50), (GenAction) new Actions.TileScanner(new ushort[4]
      {
        (ushort) 0,
        (ushort) 59,
        (ushort) 147,
        (ushort) 1
      }).Output(resultsOutput));
      int num1 = resultsOutput[(ushort) 0] + resultsOutput[(ushort) 1];
      int num2 = resultsOutput[(ushort) 59];
      if (resultsOutput[(ushort) 147] > num2 || num1 > num2 || num2 < 50)
        return false;
      int num3 = (result1.Y - result2.Y - 9) / 5;
      int num4 = num3 * 5;
      int num5 = 0;
      double num6 = GenBase._random.NextDouble() + 1.0;
      double num7 = GenBase._random.NextDouble() + 2.0;
      if (GenBase._random.Next(2) == 0)
        num7 = -num7;
      for (int index = 0; index < num3; ++index)
      {
        int num8 = (int) (Math.Sin((double) (index + 1) / 12.0 * num6 * 3.14159274101257) * num7);
        int num9 = num8 < num5 ? num8 - num5 : 0;
        WorldUtils.Gen(new Point(result1.X + num5 + num9, result1.Y - (index + 1) * 5), (GenShape) new Shapes.Rectangle(6 + Math.Abs(num8 - num5), 7), Actions.Chain((GenAction) new Actions.RemoveWall(), (GenAction) new Actions.SetTile((ushort) 383), (GenAction) new Actions.SetFrames()));
        WorldUtils.Gen(new Point(result1.X + num5 + num9 + 2, result1.Y - (index + 1) * 5), (GenShape) new Shapes.Rectangle(2 + Math.Abs(num8 - num5), 5), Actions.Chain((GenAction) new Actions.ClearTile(true), (GenAction) new Actions.PlaceWall((byte) 78)));
        WorldUtils.Gen(new Point(result1.X + num5 + 2, result1.Y - index * 5), (GenShape) new Shapes.Rectangle(2, 2), Actions.Chain((GenAction) new Actions.ClearTile(true), (GenAction) new Actions.PlaceWall((byte) 78)));
        num5 = num8;
      }
      int num10 = 6;
      if (num7 < 0.0)
        num10 = 0;
      List<Point> endpoints = new List<Point>();
      for (int index = 0; index < 2; ++index)
      {
        double num11 = ((double) index + 1.0) / 3.0;
        int num12 = num10 + (int) (Math.Sin((double) num3 * num11 / 12.0 * num6 * 3.14159274101257) * num7);
        double angle = GenBase._random.NextDouble() * 0.785398185253143 - 0.785398185253143 - 0.200000002980232;
        if (num10 == 0)
          angle -= 1.57079637050629;
        WorldUtils.Gen(new Point(result1.X + num12, result1.Y - (int) ((double) (num3 * 5) * num11)), (GenShape) new ShapeBranch(angle, (double) GenBase._random.Next(12, 16)).OutputEndpoints(endpoints), Actions.Chain((GenAction) new Actions.SetTile((ushort) 383), (GenAction) new Actions.SetFrames(true)));
        num10 = 6 - num10;
      }
      int num13 = (int) (Math.Sin((double) num3 / 12.0 * num6 * 3.14159274101257) * num7);
      WorldUtils.Gen(new Point(result1.X + 6 + num13, result1.Y - num4), (GenShape) new ShapeBranch(-0.685398185253143, (double) GenBase._random.Next(16, 22)).OutputEndpoints(endpoints), Actions.Chain((GenAction) new Actions.SetTile((ushort) 383), (GenAction) new Actions.SetFrames(true)));
      WorldUtils.Gen(new Point(result1.X + num13, result1.Y - num4), (GenShape) new ShapeBranch(-2.45619449615479, (double) GenBase._random.Next(16, 22)).OutputEndpoints(endpoints), Actions.Chain((GenAction) new Actions.SetTile((ushort) 383), (GenAction) new Actions.SetFrames(true)));
      foreach (Point origin1 in endpoints)
      {
        Shapes.Circle circle = new Shapes.Circle(4);
        GenAction action = Actions.Chain((GenAction) new Modifiers.Blotches(4, 2, 0.3), (GenAction) new Modifiers.SkipTiles(new ushort[1]
        {
          (ushort) 383
        }), (GenAction) new Modifiers.SkipWalls(new byte[1]
        {
          (byte) 78
        }), (GenAction) new Actions.SetTile((ushort) 384), (GenAction) new Actions.SetFrames(true));
        WorldUtils.Gen(origin1, (GenShape) circle, action);
      }
      for (int index = 0; index < 4; ++index)
      {
        float angle = (float) ((double) index / 3.0 * 2.0 + 0.570749998092651);
        WorldUtils.Gen(result1, (GenShape) new ShapeRoot(angle, (float) GenBase._random.Next(40, 60)), (GenAction) new Actions.SetTile((ushort) 383, true));
      }
      WorldGen.AddBuriedChest(result1.X + 3, result1.Y - 1, GenBase._random.Next(4) == 0 ? 0 : WorldGen.GetNextJungleChestItem(), Style: 10);
      structures.AddStructure(new Microsoft.Xna.Framework.Rectangle(result1.X - 30, result1.Y - 30, 60, 60));
      return true;
    }
  }
}
