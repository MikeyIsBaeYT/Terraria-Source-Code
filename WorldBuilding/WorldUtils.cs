// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.WorldUtils
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria.WorldBuilding
{
  public static class WorldUtils
  {
    public static Microsoft.Xna.Framework.Rectangle ClampToWorld(
      World world,
      Microsoft.Xna.Framework.Rectangle tileRectangle)
    {
      int x = Math.Max(0, Math.Min(tileRectangle.Left, world.TileColumns));
      int y = Math.Max(0, Math.Min(tileRectangle.Top, world.TileRows));
      int num1 = Math.Max(0, Math.Min(tileRectangle.Right, world.TileColumns));
      int num2 = Math.Max(0, Math.Min(tileRectangle.Bottom, world.TileRows));
      return new Microsoft.Xna.Framework.Rectangle(x, y, num1 - x, num2 - y);
    }

    public static bool Gen(Point origin, GenShape shape, GenAction action) => shape.Perform(origin, action);

    public static bool Gen(Point origin, GenShapeActionPair pair) => pair.Shape.Perform(origin, pair.Action);

    public static bool Find(Point origin, GenSearch search, out Point result)
    {
      result = search.Find(origin);
      return !(result == GenSearch.NOT_FOUND);
    }

    public static void ClearTile(int x, int y, bool frameNeighbors = false)
    {
      Main.tile[x, y].ClearTile();
      if (!frameNeighbors)
        return;
      WorldGen.TileFrame(x + 1, y);
      WorldGen.TileFrame(x - 1, y);
      WorldGen.TileFrame(x, y + 1);
      WorldGen.TileFrame(x, y - 1);
    }

    public static void ClearWall(int x, int y, bool frameNeighbors = false)
    {
      Main.tile[x, y].wall = (ushort) 0;
      if (!frameNeighbors)
        return;
      WorldGen.SquareWallFrame(x + 1, y);
      WorldGen.SquareWallFrame(x - 1, y);
      WorldGen.SquareWallFrame(x, y + 1);
      WorldGen.SquareWallFrame(x, y - 1);
    }

    public static void TileFrame(int x, int y, bool frameNeighbors = false)
    {
      WorldGen.TileFrame(x, y, true);
      if (!frameNeighbors)
        return;
      WorldGen.TileFrame(x + 1, y, true);
      WorldGen.TileFrame(x - 1, y, true);
      WorldGen.TileFrame(x, y + 1, true);
      WorldGen.TileFrame(x, y - 1, true);
    }

    public static void ClearChestLocation(int x, int y)
    {
      WorldUtils.ClearTile(x, y, true);
      WorldUtils.ClearTile(x - 1, y, true);
      WorldUtils.ClearTile(x, y - 1, true);
      WorldUtils.ClearTile(x - 1, y - 1, true);
    }

    public static void WireLine(Point start, Point end)
    {
      Point point1 = start;
      Point point2 = end;
      if (end.X < start.X)
        Utils.Swap<int>(ref end.X, ref start.X);
      if (end.Y < start.Y)
        Utils.Swap<int>(ref end.Y, ref start.Y);
      for (int x = start.X; x <= end.X; ++x)
        WorldGen.PlaceWire(x, point1.Y);
      for (int y = start.Y; y <= end.Y; ++y)
        WorldGen.PlaceWire(point2.X, y);
    }

    public static void DebugRegen()
    {
      WorldGen.clearWorld();
      WorldGen.GenerateWorld(Main.ActiveWorldFileData.Seed);
      Main.NewText("World Regen Complete.");
    }

    public static void DebugRotate()
    {
      int num1 = 0;
      int num2 = 0;
      int maxTilesY = Main.maxTilesY;
      for (int index1 = 0; index1 < Main.maxTilesX / Main.maxTilesY; ++index1)
      {
        for (int index2 = 0; index2 < maxTilesY / 2; ++index2)
        {
          for (int index3 = index2; index3 < maxTilesY - index2; ++index3)
          {
            Tile tile = Main.tile[index3 + num1, index2 + num2];
            Main.tile[index3 + num1, index2 + num2] = Main.tile[index2 + num1, maxTilesY - index3 + num2];
            Main.tile[index2 + num1, maxTilesY - index3 + num2] = Main.tile[maxTilesY - index3 + num1, maxTilesY - index2 + num2];
            Main.tile[maxTilesY - index3 + num1, maxTilesY - index2 + num2] = Main.tile[maxTilesY - index2 + num1, index3 + num2];
            Main.tile[maxTilesY - index2 + num1, index3 + num2] = tile;
          }
        }
        num1 += maxTilesY;
      }
    }
  }
}
