// Decompiled with JetBrains decompiler
// Type: Terraria.Tile
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria
{
  public class Tile
  {
    public bool active;
    public byte type;
    public byte wall;
    public byte wallFrameX;
    public byte wallFrameY;
    public byte wallFrameNumber;
    public bool wire;
    public byte liquid;
    public bool checkingLiquid;
    public bool skipLiquid;
    public bool lava;
    public byte frameNumber;
    public short frameX;
    public short frameY;

    public object Clone() => this.MemberwiseClone();

    public bool isTheSameAs(Tile compTile) => this.active == compTile.active && (!this.active || (int) this.type == (int) compTile.type && (!Main.tileFrameImportant[(int) this.type] || (int) this.frameX == (int) compTile.frameX && (int) this.frameY == (int) compTile.frameY)) && (int) this.wall == (int) compTile.wall && (int) this.liquid == (int) compTile.liquid && this.lava == compTile.lava && this.wire == compTile.wire;
  }
}
