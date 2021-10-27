// Decompiled with JetBrains decompiler
// Type: Terraria.StrayMethods
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
  public class StrayMethods
  {
    public static bool CountSandHorizontally(
      int i,
      int j,
      bool[] fittingTypes,
      int requiredTotalSpread = 4,
      int spreadInEachAxis = 5)
    {
      if (!WorldGen.InWorld(i, j, 2))
        return false;
      int num1 = 0;
      int num2 = 0;
      for (int i1 = i - 1; num1 < spreadInEachAxis && i1 > 0; --i1)
      {
        Tile tile = Main.tile[i1, j];
        if (tile.active() && fittingTypes[(int) tile.type] && !WorldGen.SolidTileAllowBottomSlope(i1, j - 1))
          ++num1;
        else if (!tile.active())
          break;
      }
      for (int i2 = i + 1; num2 < spreadInEachAxis && i2 < Main.maxTilesX - 1; ++i2)
      {
        Tile tile = Main.tile[i2, j];
        if (tile.active() && fittingTypes[(int) tile.type] && !WorldGen.SolidTileAllowBottomSlope(i2, j - 1))
          ++num2;
        else if (!tile.active())
          break;
      }
      return num1 + num2 + 1 >= requiredTotalSpread;
    }

    public static bool CanSpawnSandstormHostile(Vector2 position, int expandUp, int expandDown)
    {
      bool flag = true;
      Point tileCoordinates = position.ToTileCoordinates();
      for (int index = -1; index <= 1; ++index)
      {
        int topY;
        int bottomY;
        Collision.ExpandVertically(tileCoordinates.X + index, tileCoordinates.Y, out topY, out bottomY, expandUp, expandDown);
        ++topY;
        --bottomY;
        if (bottomY - topY < 20)
        {
          flag = false;
          break;
        }
      }
      return flag;
    }

    public static bool CanSpawnSandstormFriendly(Vector2 position, int expandUp, int expandDown)
    {
      bool flag = true;
      Point tileCoordinates = position.ToTileCoordinates();
      for (int index = -1; index <= 1; ++index)
      {
        int topY;
        int bottomY;
        Collision.ExpandVertically(tileCoordinates.X + index, tileCoordinates.Y, out topY, out bottomY, expandUp, expandDown);
        ++topY;
        --bottomY;
        if (bottomY - topY < 10)
        {
          flag = false;
          break;
        }
      }
      return flag;
    }

    public static void CheckArenaScore(
      Vector2 arenaCenter,
      out Point xLeftEnd,
      out Point xRightEnd,
      int walkerWidthInTiles = 5,
      int walkerHeightInTiles = 10)
    {
      bool showDebug = false;
      Point tileCoordinates = arenaCenter.ToTileCoordinates();
      xLeftEnd = xRightEnd = tileCoordinates;
      int bottomY;
      Collision.ExpandVertically(tileCoordinates.X, tileCoordinates.Y, out int _, out bottomY, 0, 4);
      tileCoordinates.Y = bottomY;
      if (showDebug)
        Dust.QuickDust(tileCoordinates, Color.Blue).scale = 5f;
      Point lastIteratedFloorSpot1;
      StrayMethods.SendWalker(tileCoordinates, walkerHeightInTiles, -1, out int _, out lastIteratedFloorSpot1, 120, showDebug);
      Point lastIteratedFloorSpot2;
      StrayMethods.SendWalker(tileCoordinates, walkerHeightInTiles, 1, out int _, out lastIteratedFloorSpot2, 120, showDebug);
      ++lastIteratedFloorSpot1.X;
      --lastIteratedFloorSpot2.X;
      if (showDebug)
        Dust.QuickDustLine(lastIteratedFloorSpot1.ToWorldCoordinates(), lastIteratedFloorSpot2.ToWorldCoordinates(), 50f, Color.Pink);
      xLeftEnd = lastIteratedFloorSpot1;
      xRightEnd = lastIteratedFloorSpot2;
    }

    public static void SendWalker(
      Point startFloorPosition,
      int height,
      int direction,
      out int distanceCoveredInTiles,
      out Point lastIteratedFloorSpot,
      int maxDistance = 100,
      bool showDebug = false)
    {
      distanceCoveredInTiles = 0;
      --startFloorPosition.Y;
      lastIteratedFloorSpot = startFloorPosition;
      for (int index1 = 0; index1 < maxDistance; ++index1)
      {
        for (int index2 = 0; index2 < 3 && WorldGen.SolidTile3(startFloorPosition.X, startFloorPosition.Y); ++index2)
          --startFloorPosition.Y;
        int topY1;
        int bottomY1;
        Collision.ExpandVertically(startFloorPosition.X, startFloorPosition.Y, out topY1, out bottomY1, height, 2);
        ++topY1;
        --bottomY1;
        if (!WorldGen.SolidTile3(startFloorPosition.X, bottomY1 + 1))
        {
          int topY2;
          int bottomY2;
          Collision.ExpandVertically(startFloorPosition.X, bottomY1, out topY2, out bottomY2, 0, 6);
          if (showDebug)
            Dust.QuickBox(new Vector2((float) (startFloorPosition.X * 16 + 8), (float) (topY2 * 16)), new Vector2((float) (startFloorPosition.X * 16 + 8), (float) (bottomY2 * 16)), 1, Color.Blue, (Action<Dust>) null);
          if (!WorldGen.SolidTile3(startFloorPosition.X, bottomY2))
            break;
        }
        if (bottomY1 - topY1 >= height - 1)
        {
          if (showDebug)
          {
            Dust.QuickDust(startFloorPosition, Color.Green).scale = 1f;
            Dust.QuickBox(new Vector2((float) (startFloorPosition.X * 16 + 8), (float) (topY1 * 16)), new Vector2((float) (startFloorPosition.X * 16 + 8), (float) (bottomY1 * 16 + 16)), 1, Color.Red, (Action<Dust>) null);
          }
          distanceCoveredInTiles += direction;
          startFloorPosition.X += direction;
          startFloorPosition.Y = bottomY1;
          lastIteratedFloorSpot = startFloorPosition;
          if (Math.Abs(distanceCoveredInTiles) >= maxDistance)
            break;
        }
        else
          break;
      }
      distanceCoveredInTiles = Math.Abs(distanceCoveredInTiles);
    }
  }
}
