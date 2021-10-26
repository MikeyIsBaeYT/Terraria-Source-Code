// Decompiled with JetBrains decompiler
// Type: Terraria.Tile
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Terraria
{
  public class Tile
  {
    public ushort type;
    public ushort wall;
    public byte liquid;
    public short sTileHeader;
    public byte bTileHeader;
    public byte bTileHeader2;
    public byte bTileHeader3;
    public short frameX;
    public short frameY;
    public const int Type_Solid = 0;
    public const int Type_Halfbrick = 1;
    public const int Type_SlopeDownRight = 2;
    public const int Type_SlopeDownLeft = 3;
    public const int Type_SlopeUpRight = 4;
    public const int Type_SlopeUpLeft = 5;
    public const int Liquid_Water = 0;
    public const int Liquid_Lava = 1;
    public const int Liquid_Honey = 2;

    public Tile()
    {
      this.type = (ushort) 0;
      this.wall = (ushort) 0;
      this.liquid = (byte) 0;
      this.sTileHeader = (short) 0;
      this.bTileHeader = (byte) 0;
      this.bTileHeader2 = (byte) 0;
      this.bTileHeader3 = (byte) 0;
      this.frameX = (short) 0;
      this.frameY = (short) 0;
    }

    public Tile(Tile copy)
    {
      if (copy == null)
      {
        this.type = (ushort) 0;
        this.wall = (ushort) 0;
        this.liquid = (byte) 0;
        this.sTileHeader = (short) 0;
        this.bTileHeader = (byte) 0;
        this.bTileHeader2 = (byte) 0;
        this.bTileHeader3 = (byte) 0;
        this.frameX = (short) 0;
        this.frameY = (short) 0;
      }
      else
      {
        this.type = copy.type;
        this.wall = copy.wall;
        this.liquid = copy.liquid;
        this.sTileHeader = copy.sTileHeader;
        this.bTileHeader = copy.bTileHeader;
        this.bTileHeader2 = copy.bTileHeader2;
        this.bTileHeader3 = copy.bTileHeader3;
        this.frameX = copy.frameX;
        this.frameY = copy.frameY;
      }
    }

    public object Clone() => this.MemberwiseClone();

    public void ClearEverything()
    {
      this.type = (ushort) 0;
      this.wall = (ushort) 0;
      this.liquid = (byte) 0;
      this.sTileHeader = (short) 0;
      this.bTileHeader = (byte) 0;
      this.bTileHeader2 = (byte) 0;
      this.bTileHeader3 = (byte) 0;
      this.frameX = (short) 0;
      this.frameY = (short) 0;
    }

    public void ClearTile()
    {
      this.slope((byte) 0);
      this.halfBrick(false);
      this.active(false);
      this.inActive(false);
    }

    public void CopyFrom(Tile from)
    {
      this.type = from.type;
      this.wall = from.wall;
      this.liquid = from.liquid;
      this.sTileHeader = from.sTileHeader;
      this.bTileHeader = from.bTileHeader;
      this.bTileHeader2 = from.bTileHeader2;
      this.bTileHeader3 = from.bTileHeader3;
      this.frameX = from.frameX;
      this.frameY = from.frameY;
    }

    public int collisionType
    {
      get
      {
        if (!this.active())
          return 0;
        if (this.halfBrick())
          return 2;
        if (this.slope() > (byte) 0)
          return 2 + (int) this.slope();
        return Main.tileSolid[(int) this.type] && !Main.tileSolidTop[(int) this.type] ? 1 : -1;
      }
    }

    public bool isTheSameAs(Tile compTile)
    {
      if (compTile == null || (int) this.sTileHeader != (int) compTile.sTileHeader || this.active() && ((int) this.type != (int) compTile.type || Main.tileFrameImportant[(int) this.type] && ((int) this.frameX != (int) compTile.frameX || (int) this.frameY != (int) compTile.frameY)) || (int) this.wall != (int) compTile.wall || (int) this.liquid != (int) compTile.liquid)
        return false;
      if (compTile.liquid == (byte) 0)
      {
        if ((int) this.wallColor() != (int) compTile.wallColor() || this.wire4() != compTile.wire4())
          return false;
      }
      else if ((int) this.bTileHeader != (int) compTile.bTileHeader)
        return false;
      return true;
    }

    public int blockType()
    {
      if (this.halfBrick())
        return 1;
      int num = (int) this.slope();
      if (num > 0)
        ++num;
      return num;
    }

    public void liquidType(int liquidType)
    {
      switch (liquidType)
      {
        case 0:
          this.bTileHeader &= (byte) 159;
          break;
        case 1:
          this.lava(true);
          break;
        case 2:
          this.honey(true);
          break;
      }
    }

    public byte liquidType() => (byte) (((int) this.bTileHeader & 96) >> 5);

    public bool nactive() => ((int) this.sTileHeader & 96) == 32;

    public void ResetToType(ushort type)
    {
      this.liquid = (byte) 0;
      this.sTileHeader = (short) 32;
      this.bTileHeader = (byte) 0;
      this.bTileHeader2 = (byte) 0;
      this.bTileHeader3 = (byte) 0;
      this.frameX = (short) 0;
      this.frameY = (short) 0;
      this.type = type;
    }

    internal void ClearMetadata()
    {
      this.liquid = (byte) 0;
      this.sTileHeader = (short) 0;
      this.bTileHeader = (byte) 0;
      this.bTileHeader2 = (byte) 0;
      this.bTileHeader3 = (byte) 0;
      this.frameX = (short) 0;
      this.frameY = (short) 0;
    }

    public Color actColor(Color oldColor)
    {
      if (!this.inActive())
        return oldColor;
      double num = 0.4;
      return new Color((int) (byte) (num * (double) oldColor.R), (int) (byte) (num * (double) oldColor.G), (int) (byte) (num * (double) oldColor.B), (int) oldColor.A);
    }

    public void actColor(ref Vector3 oldColor)
    {
      if (!this.inActive())
        return;
      oldColor *= 0.4f;
    }

    public bool topSlope()
    {
      byte num = this.slope();
      return num == (byte) 1 || num == (byte) 2;
    }

    public bool bottomSlope()
    {
      byte num = this.slope();
      return num == (byte) 3 || num == (byte) 4;
    }

    public bool leftSlope()
    {
      byte num = this.slope();
      return num == (byte) 2 || num == (byte) 4;
    }

    public bool rightSlope()
    {
      byte num = this.slope();
      return num == (byte) 1 || num == (byte) 3;
    }

    public bool HasSameSlope(Tile tile) => ((int) this.sTileHeader & 29696) == ((int) tile.sTileHeader & 29696);

    public byte wallColor() => (byte) ((uint) this.bTileHeader & 31U);

    public void wallColor(byte wallColor) => this.bTileHeader = (byte) ((uint) this.bTileHeader & 224U | (uint) wallColor);

    public bool lava() => ((int) this.bTileHeader & 32) == 32;

    public void lava(bool lava)
    {
      if (lava)
        this.bTileHeader = (byte) ((int) this.bTileHeader & 159 | 32);
      else
        this.bTileHeader &= (byte) 223;
    }

    public bool honey() => ((int) this.bTileHeader & 64) == 64;

    public void honey(bool honey)
    {
      if (honey)
        this.bTileHeader = (byte) ((int) this.bTileHeader & 159 | 64);
      else
        this.bTileHeader &= (byte) 191;
    }

    public bool wire4() => ((int) this.bTileHeader & 128) == 128;

    public void wire4(bool wire4)
    {
      if (wire4)
        this.bTileHeader |= (byte) 128;
      else
        this.bTileHeader &= (byte) 127;
    }

    public int wallFrameX() => ((int) this.bTileHeader2 & 15) * 36;

    public void wallFrameX(int wallFrameX) => this.bTileHeader2 = (byte) ((int) this.bTileHeader2 & 240 | wallFrameX / 36 & 15);

    public byte frameNumber() => (byte) (((int) this.bTileHeader2 & 48) >> 4);

    public void frameNumber(byte frameNumber) => this.bTileHeader2 = (byte) ((int) this.bTileHeader2 & 207 | ((int) frameNumber & 3) << 4);

    public byte wallFrameNumber() => (byte) (((int) this.bTileHeader2 & 192) >> 6);

    public void wallFrameNumber(byte wallFrameNumber) => this.bTileHeader2 = (byte) ((int) this.bTileHeader2 & 63 | ((int) wallFrameNumber & 3) << 6);

    public int wallFrameY() => ((int) this.bTileHeader3 & 7) * 36;

    public void wallFrameY(int wallFrameY) => this.bTileHeader3 = (byte) ((int) this.bTileHeader3 & 248 | wallFrameY / 36 & 7);

    public bool checkingLiquid() => ((int) this.bTileHeader3 & 8) == 8;

    public void checkingLiquid(bool checkingLiquid)
    {
      if (checkingLiquid)
        this.bTileHeader3 |= (byte) 8;
      else
        this.bTileHeader3 &= (byte) 247;
    }

    public bool skipLiquid() => ((int) this.bTileHeader3 & 16) == 16;

    public void skipLiquid(bool skipLiquid)
    {
      if (skipLiquid)
        this.bTileHeader3 |= (byte) 16;
      else
        this.bTileHeader3 &= (byte) 239;
    }

    public byte color() => (byte) ((uint) this.sTileHeader & 31U);

    public void color(byte color) => this.sTileHeader = (short) ((int) this.sTileHeader & 65504 | (int) color);

    public bool active() => ((int) this.sTileHeader & 32) == 32;

    public void active(bool active)
    {
      if (active)
        this.sTileHeader |= (short) 32;
      else
        this.sTileHeader &= (short) -33;
    }

    public bool inActive() => ((int) this.sTileHeader & 64) == 64;

    public void inActive(bool inActive)
    {
      if (inActive)
        this.sTileHeader |= (short) 64;
      else
        this.sTileHeader &= (short) -65;
    }

    public bool wire() => ((int) this.sTileHeader & 128) == 128;

    public void wire(bool wire)
    {
      if (wire)
        this.sTileHeader |= (short) 128;
      else
        this.sTileHeader &= (short) -129;
    }

    public bool wire2() => ((int) this.sTileHeader & 256) == 256;

    public void wire2(bool wire2)
    {
      if (wire2)
        this.sTileHeader |= (short) 256;
      else
        this.sTileHeader &= (short) -257;
    }

    public bool wire3() => ((int) this.sTileHeader & 512) == 512;

    public void wire3(bool wire3)
    {
      if (wire3)
        this.sTileHeader |= (short) 512;
      else
        this.sTileHeader &= (short) -513;
    }

    public bool halfBrick() => ((int) this.sTileHeader & 1024) == 1024;

    public void halfBrick(bool halfBrick)
    {
      if (halfBrick)
        this.sTileHeader |= (short) 1024;
      else
        this.sTileHeader &= (short) -1025;
    }

    public bool actuator() => ((int) this.sTileHeader & 2048) == 2048;

    public void actuator(bool actuator)
    {
      if (actuator)
        this.sTileHeader |= (short) 2048;
      else
        this.sTileHeader &= (short) -2049;
    }

    public byte slope() => (byte) (((int) this.sTileHeader & 28672) >> 12);

    public void slope(byte slope) => this.sTileHeader = (short) ((int) this.sTileHeader & 36863 | ((int) slope & 7) << 12);

    public void Clear(TileDataType types)
    {
      if ((types & TileDataType.Tile) != (TileDataType) 0)
      {
        this.type = (ushort) 0;
        this.active(false);
        this.frameX = (short) 0;
        this.frameY = (short) 0;
      }
      if ((types & TileDataType.Wall) != (TileDataType) 0)
      {
        this.wall = (ushort) 0;
        this.wallFrameX(0);
        this.wallFrameY(0);
      }
      if ((types & TileDataType.TilePaint) != (TileDataType) 0)
        this.color((byte) 0);
      if ((types & TileDataType.WallPaint) != (TileDataType) 0)
        this.wallColor((byte) 0);
      if ((types & TileDataType.Liquid) != (TileDataType) 0)
      {
        this.liquid = (byte) 0;
        this.liquidType(0);
        this.checkingLiquid(false);
      }
      if ((types & TileDataType.Slope) != (TileDataType) 0)
      {
        this.slope((byte) 0);
        this.halfBrick(false);
      }
      if ((types & TileDataType.Wiring) != (TileDataType) 0)
      {
        this.wire(false);
        this.wire2(false);
        this.wire3(false);
        this.wire4(false);
      }
      if ((types & TileDataType.Actuator) == (TileDataType) 0)
        return;
      this.actuator(false);
      this.inActive(false);
    }

    public static void SmoothSlope(int x, int y, bool applyToNeighbors = true, bool sync = false)
    {
      if (applyToNeighbors)
      {
        Tile.SmoothSlope(x + 1, y, false, sync);
        Tile.SmoothSlope(x - 1, y, false, sync);
        Tile.SmoothSlope(x, y + 1, false, sync);
        Tile.SmoothSlope(x, y - 1, false, sync);
      }
      Tile tile = Main.tile[x, y];
      if (!WorldGen.CanPoundTile(x, y) || !WorldGen.SolidOrSlopedTile(x, y))
        return;
      bool flag1 = !WorldGen.TileEmpty(x, y - 1);
      bool flag2 = !WorldGen.SolidOrSlopedTile(x, y - 1) & flag1;
      bool flag3 = WorldGen.SolidOrSlopedTile(x, y + 1);
      bool flag4 = WorldGen.SolidOrSlopedTile(x - 1, y);
      bool flag5 = WorldGen.SolidOrSlopedTile(x + 1, y);
      int num1 = (flag1 ? 1 : 0) << 3 | (flag3 ? 1 : 0) << 2 | (flag4 ? 1 : 0) << 1 | (flag5 ? 1 : 0);
      bool flag6 = tile.halfBrick();
      int num2 = (int) tile.slope();
      switch (num1)
      {
        case 4:
          tile.slope((byte) 0);
          tile.halfBrick(true);
          break;
        case 5:
          tile.halfBrick(false);
          tile.slope((byte) 2);
          break;
        case 6:
          tile.halfBrick(false);
          tile.slope((byte) 1);
          break;
        case 9:
          if (!flag2)
          {
            tile.halfBrick(false);
            tile.slope((byte) 4);
            break;
          }
          break;
        case 10:
          if (!flag2)
          {
            tile.halfBrick(false);
            tile.slope((byte) 3);
            break;
          }
          break;
        default:
          tile.halfBrick(false);
          tile.slope((byte) 0);
          break;
      }
      if (!sync)
        return;
      int num3 = (int) tile.slope();
      bool flag7 = flag6 != tile.halfBrick();
      bool flag8 = num2 != num3;
      if (flag7 & flag8)
        NetMessage.SendData(17, number: 23, number2: ((float) x), number3: ((float) y), number4: ((float) num3));
      else if (flag7)
      {
        NetMessage.SendData(17, number: 7, number2: ((float) x), number3: ((float) y), number4: 1f);
      }
      else
      {
        if (!flag8)
          return;
        NetMessage.SendData(17, number: 14, number2: ((float) x), number3: ((float) y), number4: ((float) num3));
      }
    }

    public override string ToString() => "Tile Type:" + (object) this.type + " Active:" + this.active().ToString() + " Wall:" + (object) this.wall + " Slope:" + (object) this.slope() + " fX:" + (object) this.frameX + " fY:" + (object) this.frameY;
  }
}
