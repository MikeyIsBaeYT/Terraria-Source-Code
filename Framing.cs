// Decompiled with JetBrains decompiler
// Type: Terraria.Framing
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.ID;

namespace Terraria
{
  public class Framing
  {
    private static Point16[][] selfFrame8WayLookup;
    private static Point16[][] wallFrameLookup;
    private static Point16 frameSize8Way;
    private static Point16 wallFrameSize;
    private static Framing.BlockStyle[] blockStyleLookup;
    private static int[][] phlebasTileFrameNumberLookup;
    private static int[][] lazureTileFrameNumberLookup;
    private static int[][] centerWallFrameLookup;

    public static void Initialize()
    {
      Framing.selfFrame8WayLookup = new Point16[256][];
      Framing.frameSize8Way = new Point16(18, 18);
      Framing.Add8WayLookup(0, (short) 9, (short) 3, (short) 10, (short) 3, (short) 11, (short) 3);
      Framing.Add8WayLookup(1, (short) 6, (short) 3, (short) 7, (short) 3, (short) 8, (short) 3);
      Framing.Add8WayLookup(2, (short) 12, (short) 0, (short) 12, (short) 1, (short) 12, (short) 2);
      Framing.Add8WayLookup(3, (short) 15, (short) 2);
      Framing.Add8WayLookup(4, (short) 9, (short) 0, (short) 9, (short) 1, (short) 9, (short) 2);
      Framing.Add8WayLookup(5, (short) 13, (short) 2);
      Framing.Add8WayLookup(6, (short) 6, (short) 4, (short) 7, (short) 4, (short) 8, (short) 4);
      Framing.Add8WayLookup(7, (short) 14, (short) 2);
      Framing.Add8WayLookup(8, (short) 6, (short) 0, (short) 7, (short) 0, (short) 8, (short) 0);
      Framing.Add8WayLookup(9, (short) 5, (short) 0, (short) 5, (short) 1, (short) 5, (short) 2);
      Framing.Add8WayLookup(10, (short) 15, (short) 0);
      Framing.Add8WayLookup(11, (short) 15, (short) 1);
      Framing.Add8WayLookup(12, (short) 13, (short) 0);
      Framing.Add8WayLookup(13, (short) 13, (short) 1);
      Framing.Add8WayLookup(14, (short) 14, (short) 0);
      Framing.Add8WayLookup(15, (short) 14, (short) 1);
      Framing.Add8WayLookup(19, (short) 1, (short) 4, (short) 3, (short) 4, (short) 5, (short) 4);
      Framing.Add8WayLookup(23, (short) 16, (short) 3);
      Framing.Add8WayLookup(27, (short) 17, (short) 0);
      Framing.Add8WayLookup(31, (short) 13, (short) 4);
      Framing.Add8WayLookup(37, (short) 0, (short) 4, (short) 2, (short) 4, (short) 4, (short) 4);
      Framing.Add8WayLookup(39, (short) 17, (short) 3);
      Framing.Add8WayLookup(45, (short) 16, (short) 0);
      Framing.Add8WayLookup(47, (short) 12, (short) 4);
      Framing.Add8WayLookup(55, (short) 1, (short) 2, (short) 2, (short) 2, (short) 3, (short) 2);
      Framing.Add8WayLookup(63, (short) 6, (short) 2, (short) 7, (short) 2, (short) 8, (short) 2);
      Framing.Add8WayLookup(74, (short) 1, (short) 3, (short) 3, (short) 3, (short) 5, (short) 3);
      Framing.Add8WayLookup(75, (short) 17, (short) 1);
      Framing.Add8WayLookup(78, (short) 16, (short) 2);
      Framing.Add8WayLookup(79, (short) 13, (short) 3);
      Framing.Add8WayLookup(91, (short) 4, (short) 0, (short) 4, (short) 1, (short) 4, (short) 2);
      Framing.Add8WayLookup(95, (short) 11, (short) 0, (short) 11, (short) 1, (short) 11, (short) 2);
      Framing.Add8WayLookup(111, (short) 17, (short) 4);
      Framing.Add8WayLookup((int) sbyte.MaxValue, (short) 14, (short) 3);
      Framing.Add8WayLookup(140, (short) 0, (short) 3, (short) 2, (short) 3, (short) 4, (short) 3);
      Framing.Add8WayLookup(141, (short) 16, (short) 1);
      Framing.Add8WayLookup(142, (short) 17, (short) 2);
      Framing.Add8WayLookup(143, (short) 12, (short) 3);
      Framing.Add8WayLookup(159, (short) 16, (short) 4);
      Framing.Add8WayLookup(173, (short) 0, (short) 0, (short) 0, (short) 1, (short) 0, (short) 2);
      Framing.Add8WayLookup(175, (short) 10, (short) 0, (short) 10, (short) 1, (short) 10, (short) 2);
      Framing.Add8WayLookup(191, (short) 15, (short) 3);
      Framing.Add8WayLookup(206, (short) 1, (short) 0, (short) 2, (short) 0, (short) 3, (short) 0);
      Framing.Add8WayLookup(207, (short) 6, (short) 1, (short) 7, (short) 1, (short) 8, (short) 1);
      Framing.Add8WayLookup(223, (short) 14, (short) 4);
      Framing.Add8WayLookup(239, (short) 15, (short) 4);
      Framing.Add8WayLookup((int) byte.MaxValue, (short) 1, (short) 1, (short) 2, (short) 1, (short) 3, (short) 1);
      Framing.blockStyleLookup = new Framing.BlockStyle[6];
      Framing.blockStyleLookup[0] = new Framing.BlockStyle(true, true, true, true);
      Framing.blockStyleLookup[1] = new Framing.BlockStyle(false, true, true, true);
      Framing.blockStyleLookup[2] = new Framing.BlockStyle(false, true, true, false);
      Framing.blockStyleLookup[3] = new Framing.BlockStyle(false, true, false, true);
      Framing.blockStyleLookup[4] = new Framing.BlockStyle(true, false, true, false);
      Framing.blockStyleLookup[5] = new Framing.BlockStyle(true, false, false, true);
      Framing.phlebasTileFrameNumberLookup = new int[4][]
      {
        new int[3]{ 2, 4, 2 },
        new int[3]{ 1, 3, 1 },
        new int[3]{ 2, 2, 4 },
        new int[3]{ 1, 1, 3 }
      };
      Framing.lazureTileFrameNumberLookup = new int[2][]
      {
        new int[2]{ 1, 3 },
        new int[2]{ 2, 4 }
      };
      Framing.centerWallFrameLookup = new int[3][]
      {
        new int[3]{ 2, 0, 0 },
        new int[3]{ 0, 1, 4 },
        new int[3]{ 0, 3, 0 }
      };
      Framing.wallFrameLookup = new Point16[20][];
      Framing.wallFrameSize = new Point16(36, 36);
      Framing.AddWallFrameLookup(0, (short) 9, (short) 3, (short) 10, (short) 3, (short) 11, (short) 3, (short) 6, (short) 6);
      Framing.AddWallFrameLookup(1, (short) 6, (short) 3, (short) 7, (short) 3, (short) 8, (short) 3, (short) 4, (short) 6);
      Framing.AddWallFrameLookup(2, (short) 12, (short) 0, (short) 12, (short) 1, (short) 12, (short) 2, (short) 12, (short) 5);
      Framing.AddWallFrameLookup(3, (short) 1, (short) 4, (short) 3, (short) 4, (short) 5, (short) 4, (short) 3, (short) 6);
      Framing.AddWallFrameLookup(4, (short) 9, (short) 0, (short) 9, (short) 1, (short) 9, (short) 2, (short) 9, (short) 5);
      Framing.AddWallFrameLookup(5, (short) 0, (short) 4, (short) 2, (short) 4, (short) 4, (short) 4, (short) 2, (short) 6);
      Framing.AddWallFrameLookup(6, (short) 6, (short) 4, (short) 7, (short) 4, (short) 8, (short) 4, (short) 5, (short) 6);
      Framing.AddWallFrameLookup(7, (short) 1, (short) 2, (short) 2, (short) 2, (short) 3, (short) 2, (short) 3, (short) 5);
      Framing.AddWallFrameLookup(8, (short) 6, (short) 0, (short) 7, (short) 0, (short) 8, (short) 0, (short) 6, (short) 5);
      Framing.AddWallFrameLookup(9, (short) 5, (short) 0, (short) 5, (short) 1, (short) 5, (short) 2, (short) 5, (short) 5);
      Framing.AddWallFrameLookup(10, (short) 1, (short) 3, (short) 3, (short) 3, (short) 5, (short) 3, (short) 1, (short) 6);
      Framing.AddWallFrameLookup(11, (short) 4, (short) 0, (short) 4, (short) 1, (short) 4, (short) 2, (short) 4, (short) 5);
      Framing.AddWallFrameLookup(12, (short) 0, (short) 3, (short) 2, (short) 3, (short) 4, (short) 3, (short) 0, (short) 6);
      Framing.AddWallFrameLookup(13, (short) 0, (short) 0, (short) 0, (short) 1, (short) 0, (short) 2, (short) 0, (short) 5);
      Framing.AddWallFrameLookup(14, (short) 1, (short) 0, (short) 2, (short) 0, (short) 3, (short) 0, (short) 1, (short) 6);
      Framing.AddWallFrameLookup(15, (short) 1, (short) 1, (short) 2, (short) 1, (short) 3, (short) 1, (short) 2, (short) 5);
      Framing.AddWallFrameLookup(16, (short) 6, (short) 1, (short) 7, (short) 1, (short) 8, (short) 1, (short) 7, (short) 5);
      Framing.AddWallFrameLookup(17, (short) 6, (short) 2, (short) 7, (short) 2, (short) 8, (short) 2, (short) 8, (short) 5);
      Framing.AddWallFrameLookup(18, (short) 10, (short) 0, (short) 10, (short) 1, (short) 10, (short) 2, (short) 10, (short) 5);
      Framing.AddWallFrameLookup(19, (short) 11, (short) 0, (short) 11, (short) 1, (short) 11, (short) 2, (short) 11, (short) 5);
    }

    private static Framing.BlockStyle FindBlockStyle(Tile blockTile) => Framing.blockStyleLookup[blockTile.blockType()];

    public static void Add8WayLookup(
      int lookup,
      short point1X,
      short point1Y,
      short point2X,
      short point2Y,
      short point3X,
      short point3Y)
    {
      Point16[] point16Array = new Point16[3]
      {
        new Point16((int) point1X * (int) Framing.frameSize8Way.X, (int) point1Y * (int) Framing.frameSize8Way.Y),
        new Point16((int) point2X * (int) Framing.frameSize8Way.X, (int) point2Y * (int) Framing.frameSize8Way.Y),
        new Point16((int) point3X * (int) Framing.frameSize8Way.X, (int) point3Y * (int) Framing.frameSize8Way.Y)
      };
      Framing.selfFrame8WayLookup[lookup] = point16Array;
    }

    public static void Add8WayLookup(int lookup, short x, short y)
    {
      Point16[] point16Array = new Point16[3]
      {
        new Point16((int) x * (int) Framing.frameSize8Way.X, (int) y * (int) Framing.frameSize8Way.Y),
        new Point16((int) x * (int) Framing.frameSize8Way.X, (int) y * (int) Framing.frameSize8Way.Y),
        new Point16((int) x * (int) Framing.frameSize8Way.X, (int) y * (int) Framing.frameSize8Way.Y)
      };
      Framing.selfFrame8WayLookup[lookup] = point16Array;
    }

    public static void AddWallFrameLookup(
      int lookup,
      short point1X,
      short point1Y,
      short point2X,
      short point2Y,
      short point3X,
      short point3Y,
      short point4X,
      short point4Y)
    {
      Point16[] point16Array = new Point16[4]
      {
        new Point16((int) point1X * (int) Framing.wallFrameSize.X, (int) point1Y * (int) Framing.wallFrameSize.Y),
        new Point16((int) point2X * (int) Framing.wallFrameSize.X, (int) point2Y * (int) Framing.wallFrameSize.Y),
        new Point16((int) point3X * (int) Framing.wallFrameSize.X, (int) point3Y * (int) Framing.wallFrameSize.Y),
        new Point16((int) point4X * (int) Framing.wallFrameSize.X, (int) point4Y * (int) Framing.wallFrameSize.Y)
      };
      Framing.wallFrameLookup[lookup] = point16Array;
    }

    public static void SelfFrame4Way()
    {
    }

    public static void SelfFrame8Way(int i, int j, Tile centerTile, bool resetFrame)
    {
      if (!centerTile.active())
        return;
      ushort gemsparkFramingType = TileID.Sets.GemsparkFramingTypes[(int) centerTile.type];
      Framing.BlockStyle blockStyle1 = Framing.FindBlockStyle(centerTile);
      int index = 0;
      Framing.BlockStyle blockStyle2 = new Framing.BlockStyle();
      if (blockStyle1.top)
      {
        Tile tileSafely = Framing.GetTileSafely(i, j - 1);
        if (tileSafely.active() && (int) TileID.Sets.GemsparkFramingTypes[(int) tileSafely.type] == (int) gemsparkFramingType)
        {
          blockStyle2 = Framing.FindBlockStyle(tileSafely);
          if (blockStyle2.bottom)
            index |= 1;
          else
            blockStyle2.Clear();
        }
      }
      Framing.BlockStyle blockStyle3 = new Framing.BlockStyle();
      if (blockStyle1.left)
      {
        Tile tileSafely = Framing.GetTileSafely(i - 1, j);
        if (tileSafely.active() && (int) TileID.Sets.GemsparkFramingTypes[(int) tileSafely.type] == (int) gemsparkFramingType)
        {
          blockStyle3 = Framing.FindBlockStyle(tileSafely);
          if (blockStyle3.right)
            index |= 2;
          else
            blockStyle3.Clear();
        }
      }
      Framing.BlockStyle blockStyle4 = new Framing.BlockStyle();
      if (blockStyle1.right)
      {
        Tile tileSafely = Framing.GetTileSafely(i + 1, j);
        if (tileSafely.active() && (int) TileID.Sets.GemsparkFramingTypes[(int) tileSafely.type] == (int) gemsparkFramingType)
        {
          blockStyle4 = Framing.FindBlockStyle(tileSafely);
          if (blockStyle4.left)
            index |= 4;
          else
            blockStyle4.Clear();
        }
      }
      Framing.BlockStyle blockStyle5 = new Framing.BlockStyle();
      if (blockStyle1.bottom)
      {
        Tile tileSafely = Framing.GetTileSafely(i, j + 1);
        if (tileSafely.active() && (int) TileID.Sets.GemsparkFramingTypes[(int) tileSafely.type] == (int) gemsparkFramingType)
        {
          blockStyle5 = Framing.FindBlockStyle(tileSafely);
          if (blockStyle5.top)
            index |= 8;
          else
            blockStyle5.Clear();
        }
      }
      if (blockStyle2.left && blockStyle3.top)
      {
        Tile tileSafely = Framing.GetTileSafely(i - 1, j - 1);
        if (tileSafely.active() && (int) TileID.Sets.GemsparkFramingTypes[(int) tileSafely.type] == (int) gemsparkFramingType)
        {
          Framing.BlockStyle blockStyle6 = Framing.FindBlockStyle(tileSafely);
          if (blockStyle6.right && blockStyle6.bottom)
            index |= 16;
        }
      }
      if (blockStyle2.right && blockStyle4.top)
      {
        Tile tileSafely = Framing.GetTileSafely(i + 1, j - 1);
        if (tileSafely.active() && (int) TileID.Sets.GemsparkFramingTypes[(int) tileSafely.type] == (int) gemsparkFramingType)
        {
          Framing.BlockStyle blockStyle7 = Framing.FindBlockStyle(tileSafely);
          if (blockStyle7.left && blockStyle7.bottom)
            index |= 32;
        }
      }
      if (blockStyle5.left && blockStyle3.bottom)
      {
        Tile tileSafely = Framing.GetTileSafely(i - 1, j + 1);
        if (tileSafely.active() && (int) TileID.Sets.GemsparkFramingTypes[(int) tileSafely.type] == (int) gemsparkFramingType)
        {
          Framing.BlockStyle blockStyle8 = Framing.FindBlockStyle(tileSafely);
          if (blockStyle8.right && blockStyle8.top)
            index |= 64;
        }
      }
      if (blockStyle5.right && blockStyle4.bottom)
      {
        Tile tileSafely = Framing.GetTileSafely(i + 1, j + 1);
        if (tileSafely.active() && (int) TileID.Sets.GemsparkFramingTypes[(int) tileSafely.type] == (int) gemsparkFramingType)
        {
          Framing.BlockStyle blockStyle9 = Framing.FindBlockStyle(tileSafely);
          if (blockStyle9.left && blockStyle9.top)
            index |= 128;
        }
      }
      if (resetFrame)
        centerTile.frameNumber((byte) WorldGen.genRand.Next(0, 3));
      Point16 point16 = Framing.selfFrame8WayLookup[index][(int) centerTile.frameNumber()];
      centerTile.frameX = point16.X;
      centerTile.frameY = point16.Y;
    }

    public static void WallFrame(int i, int j, bool resetFrame = false)
    {
      if (i <= 0 || j <= 0 || i >= Main.maxTilesX - 1 || j >= Main.maxTilesY - 1 || Main.tile[i, j] == null)
        return;
      WorldGen.UpdateMapTile(i, j);
      Tile tile1 = Main.tile[i, j];
      if (tile1.wall == (byte) 0)
      {
        tile1.wallColor((byte) 0);
      }
      else
      {
        int index1 = 0;
        Tile tile2 = Main.tile[i, j - 1];
        if (tile2 != null && (tile2.wall > (byte) 0 || tile2.active() && tile2.type == (ushort) 54))
          index1 = 1;
        Tile tile3 = Main.tile[i - 1, j];
        if (tile3 != null && (tile3.wall > (byte) 0 || tile3.active() && tile3.type == (ushort) 54))
          index1 |= 2;
        Tile tile4 = Main.tile[i + 1, j];
        if (tile4 != null && (tile4.wall > (byte) 0 || tile4.active() && tile4.type == (ushort) 54))
          index1 |= 4;
        Tile tile5 = Main.tile[i, j + 1];
        if (tile5 != null && (tile5.wall > (byte) 0 || tile5.active() && tile5.type == (ushort) 54))
          index1 |= 8;
        int index2;
        if (Main.wallLargeFrames[(int) tile1.wall] == (byte) 1)
        {
          index2 = Framing.phlebasTileFrameNumberLookup[j % 4][i % 3] - 1;
          tile1.wallFrameNumber((byte) index2);
        }
        else if (Main.wallLargeFrames[(int) tile1.wall] == (byte) 2)
        {
          index2 = Framing.lazureTileFrameNumberLookup[i % 2][j % 2] - 1;
          tile1.wallFrameNumber((byte) index2);
        }
        else if (resetFrame)
        {
          index2 = WorldGen.genRand.Next(0, 3);
          tile1.wallFrameNumber((byte) index2);
        }
        else
          index2 = (int) tile1.wallFrameNumber();
        if (index1 == 15)
          index1 += Framing.centerWallFrameLookup[i % 3][j % 3];
        Point16 point16 = Framing.wallFrameLookup[index1][index2];
        tile1.wallFrameX((int) point16.X);
        tile1.wallFrameY((int) point16.Y);
      }
    }

    public static Tile GetTileSafely(Vector2 position)
    {
      position /= 16f;
      return Framing.GetTileSafely((int) position.X, (int) position.Y);
    }

    public static Tile GetTileSafely(Point pt) => Framing.GetTileSafely(pt.X, pt.Y);

    public static Tile GetTileSafely(Point16 pt) => Framing.GetTileSafely((int) pt.X, (int) pt.Y);

    public static Tile GetTileSafely(int i, int j)
    {
      Tile tile = Main.tile[i, j];
      if (tile == null)
      {
        tile = new Tile();
        Main.tile[i, j] = tile;
      }
      return tile;
    }

    private struct BlockStyle
    {
      public bool top;
      public bool bottom;
      public bool left;
      public bool right;

      public BlockStyle(bool up, bool down, bool left, bool right)
      {
        this.top = up;
        this.bottom = down;
        this.left = left;
        this.right = right;
      }

      public void Clear() => this.top = this.bottom = this.left = this.right = false;
    }
  }
}
