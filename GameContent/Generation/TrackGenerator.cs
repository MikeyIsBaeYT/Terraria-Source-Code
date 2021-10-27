// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Generation.TrackGenerator
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using Terraria.ID;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
  public class TrackGenerator
  {
    private static readonly byte[] INVALID_WALLS = new byte[13]
    {
      (byte) 7,
      (byte) 94,
      (byte) 95,
      (byte) 8,
      (byte) 98,
      (byte) 99,
      (byte) 9,
      (byte) 96,
      (byte) 97,
      (byte) 3,
      (byte) 83,
      (byte) 87,
      (byte) 86
    };
    private const int TOTAL_TILE_IGNORES = 150;
    private const int PLAYER_HEIGHT = 6;
    private const int MAX_RETRIES = 400;
    private const int MAX_SMOOTH_DISTANCE = 15;
    private const int MAX_ITERATIONS = 1000000;
    private TrackGenerator.TrackHistory[] _historyCache = new TrackGenerator.TrackHistory[2048];

    public void Generate(int trackCount, int minimumLength)
    {
      int num = trackCount;
      while (num > 0)
      {
        int x = WorldGen.genRand.Next(150, Main.maxTilesX - 150);
        int y = WorldGen.genRand.Next((int) Main.worldSurface + 25, Main.maxTilesY - 200);
        if (this.IsLocationEmpty(x, y))
        {
          while (this.IsLocationEmpty(x, y + 1))
            ++y;
          if (this.FindPath(x, y, minimumLength))
            --num;
        }
      }
    }

    private bool IsLocationEmpty(int x, int y)
    {
      if (y > Main.maxTilesY - 200 || x < 0 || y < (int) Main.worldSurface || x > Main.maxTilesX - 5)
        return false;
      for (int index = 0; index < 6; ++index)
      {
        if (WorldGen.SolidTile(x, y - index))
          return false;
      }
      return true;
    }

    private bool CanTrackBePlaced(int x, int y)
    {
      if (y > Main.maxTilesY - 200 || x < 0 || y < (int) Main.worldSurface || x > Main.maxTilesX - 5)
        return false;
      byte wall = Main.tile[x, y].wall;
      for (int index = 0; index < TrackGenerator.INVALID_WALLS.Length; ++index)
      {
        if ((int) wall == (int) TrackGenerator.INVALID_WALLS[index])
          return false;
      }
      for (int index = -1; index <= 1; ++index)
      {
        if (Main.tile[x + index, y].active() && (Main.tile[x + index, y].type == (ushort) 314 || !TileID.Sets.GeneralPlacementTiles[(int) Main.tile[x + index, y].type]))
          return false;
      }
      return true;
    }

    private void SmoothTrack(TrackGenerator.TrackHistory[] history, int length)
    {
      int val2 = length - 1;
      bool flag = false;
      for (int index1 = length - 1; index1 >= 0; --index1)
      {
        if (flag)
        {
          val2 = Math.Min(index1 + 15, val2);
          if ((int) history[index1].Y >= (int) history[val2].Y)
          {
            for (int index2 = index1 + 1; (int) history[index2].Y > (int) history[index1].Y; ++index2)
              history[index2].Y = history[index1].Y;
            if ((int) history[index1].Y == (int) history[val2].Y)
              flag = false;
          }
        }
        else if ((int) history[index1].Y > (int) history[val2].Y)
          flag = true;
        else
          val2 = index1;
      }
    }

    public bool FindPath(int x, int y, int minimumLength, bool debugMode = false)
    {
      TrackGenerator.TrackHistory[] historyCache = this._historyCache;
      int index1 = 0;
      Tile[,] tile = Main.tile;
      bool flag1 = true;
      int num1 = WorldGen.genRand.Next(2) == 0 ? 1 : -1;
      if (debugMode)
        num1 = Main.player[Main.myPlayer].direction;
      int yDirection = 1;
      int length = 0;
      int num2 = 400;
      bool flag2 = false;
      int num3 = 150;
      int num4 = 0;
      for (int index2 = 1000000; index2 > 0 & flag1 && index1 < historyCache.Length - 1; ++index1)
      {
        --index2;
        historyCache[index1] = new TrackGenerator.TrackHistory(x, y, yDirection);
        bool flag3 = false;
        int num5 = 1;
        if (index1 > minimumLength >> 1)
          num5 = -1;
        else if (index1 > (minimumLength >> 1) - 5)
          num5 = 0;
        if (flag2)
        {
          int num6 = 0;
          int num7 = num3;
          bool flag4 = false;
          for (int index3 = Math.Min(1, yDirection + 1); index3 >= Math.Max(-1, yDirection - 1); --index3)
          {
            int num8;
            for (num8 = 0; num8 <= num3; ++num8)
            {
              if (this.IsLocationEmpty(x + (num8 + 1) * num1, y + (num8 + 1) * index3 * num5))
              {
                flag4 = true;
                break;
              }
            }
            if (num8 < num7)
            {
              num7 = num8;
              num6 = index3;
            }
          }
          if (flag4)
          {
            yDirection = num6;
            for (int index4 = 0; index4 < num7 - 1; ++index4)
            {
              ++index1;
              x += num1;
              y += yDirection * num5;
              historyCache[index1] = new TrackGenerator.TrackHistory(x, y, yDirection);
              num4 = index1;
            }
            x += num1;
            y += yDirection * num5;
            length = index1 + 1;
            flag2 = false;
          }
          num3 -= num7;
          if (num3 < 0)
            flag1 = false;
        }
        else
        {
          for (int index5 = Math.Min(1, yDirection + 1); index5 >= Math.Max(-1, yDirection - 1); --index5)
          {
            if (this.IsLocationEmpty(x + num1, y + index5 * num5))
            {
              yDirection = index5;
              flag3 = true;
              x += num1;
              y += yDirection * num5;
              length = index1 + 1;
              break;
            }
          }
          if (!flag3)
          {
            while (index1 > num4 && y == (int) historyCache[index1].Y)
              --index1;
            x = (int) historyCache[index1].X;
            y = (int) historyCache[index1].Y;
            yDirection = (int) historyCache[index1].YDirection - 1;
            --num2;
            if (num2 <= 0)
            {
              index1 = length;
              x = (int) historyCache[index1].X;
              y = (int) historyCache[index1].Y;
              yDirection = (int) historyCache[index1].YDirection;
              flag2 = true;
              num2 = 200;
            }
            --index1;
          }
        }
      }
      if (!(length > minimumLength | debugMode))
        return false;
      this.SmoothTrack(historyCache, length);
      if (!debugMode)
      {
        for (int index6 = 0; index6 < length; ++index6)
        {
          for (int index7 = -1; index7 < 7; ++index7)
          {
            if (!this.CanTrackBePlaced((int) historyCache[index6].X, (int) historyCache[index6].Y - index7))
              return false;
          }
        }
      }
      for (int index8 = 0; index8 < length; ++index8)
      {
        TrackGenerator.TrackHistory trackHistory = historyCache[index8];
        for (int index9 = 0; index9 < 6; ++index9)
          Main.tile[(int) trackHistory.X, (int) trackHistory.Y - index9].active(false);
      }
      for (int index10 = 0; index10 < length; ++index10)
      {
        TrackGenerator.TrackHistory trackHistory = historyCache[index10];
        Tile.SmoothSlope((int) trackHistory.X, (int) trackHistory.Y + 1);
        Tile.SmoothSlope((int) trackHistory.X, (int) trackHistory.Y - 6);
        bool wire = Main.tile[(int) trackHistory.X, (int) trackHistory.Y].wire();
        Main.tile[(int) trackHistory.X, (int) trackHistory.Y].ResetToType((ushort) 314);
        Main.tile[(int) trackHistory.X, (int) trackHistory.Y].wire(wire);
        if (index10 != 0)
        {
          for (int index11 = 0; index11 < 6; ++index11)
            WorldUtils.TileFrame((int) historyCache[index10 - 1].X, (int) historyCache[index10 - 1].Y - index11, true);
          if (index10 == length - 1)
          {
            for (int index12 = 0; index12 < 6; ++index12)
              WorldUtils.TileFrame((int) trackHistory.X, (int) trackHistory.Y - index12, true);
          }
        }
      }
      return true;
    }

    public static void Run(int trackCount = 30, int minimumLength = 250) => new TrackGenerator().Generate(trackCount, minimumLength);

    public static void Run(Point start) => new TrackGenerator().FindPath(start.X, start.Y, 250, true);

    private struct TrackHistory
    {
      public short X;
      public short Y;
      public byte YDirection;

      public TrackHistory(int x, int y, int yDirection)
      {
        this.X = (short) x;
        this.Y = (short) y;
        this.YDirection = (byte) yDirection;
      }

      public TrackHistory(short x, short y, byte yDirection)
      {
        this.X = x;
        this.Y = y;
        this.YDirection = yDirection;
      }
    }
  }
}
