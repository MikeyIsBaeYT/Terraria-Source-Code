// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Tile_Entities.TETeleportationPylon
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Terraria.DataStructures;

namespace Terraria.GameContent.Tile_Entities
{
  public class TETeleportationPylon : TileEntity
  {
    private static byte _myEntityID;
    private const int MyTileID = 597;
    private const int entityTileWidth = 3;
    private const int entityTileHeight = 4;

    public override void RegisterTileEntityID(int assignedID) => TETeleportationPylon._myEntityID = (byte) assignedID;

    public override TileEntity GenerateInstance() => (TileEntity) new TETeleportationPylon();

    public override void NetPlaceEntityAttempt(int x, int y)
    {
      TeleportPylonType pylonType;
      if (!this.TryGetPylonTypeFromTileCoords(x, y, out pylonType))
        TETeleportationPylon.RejectPlacementFromNet(x, y);
      else if (Main.PylonSystem.HasPylonOfType(pylonType))
        TETeleportationPylon.RejectPlacementFromNet(x, y);
      else
        NetMessage.SendData(86, number: TETeleportationPylon.Place(x, y), number2: ((float) x), number3: ((float) y));
    }

    public bool TryGetPylonType(out TeleportPylonType pylonType) => this.TryGetPylonTypeFromTileCoords((int) this.Position.X, (int) this.Position.Y, out pylonType);

    private static void RejectPlacementFromNet(int x, int y)
    {
      WorldGen.KillTile(x, y);
      if (Main.netMode != 2)
        return;
      NetMessage.SendData(17, number2: ((float) x), number3: ((float) y));
    }

    public static int Place(int x, int y)
    {
      TETeleportationPylon teleportationPylon = new TETeleportationPylon();
      teleportationPylon.Position = new Point16(x, y);
      teleportationPylon.ID = TileEntity.AssignNewID();
      teleportationPylon.type = TETeleportationPylon._myEntityID;
      TileEntity.ByID[teleportationPylon.ID] = (TileEntity) teleportationPylon;
      TileEntity.ByPosition[teleportationPylon.Position] = (TileEntity) teleportationPylon;
      Main.PylonSystem.RequestImmediateUpdate();
      return teleportationPylon.ID;
    }

    public static void Kill(int x, int y)
    {
      TileEntity tileEntity;
      if (!TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) || (int) tileEntity.type != (int) TETeleportationPylon._myEntityID)
        return;
      TileEntity.ByID.Remove(tileEntity.ID);
      TileEntity.ByPosition.Remove(new Point16(x, y));
      Main.PylonSystem.RequestImmediateUpdate();
    }

    public override string ToString() => this.Position.X.ToString() + "x  " + (object) this.Position.Y + "y";

    public static void Framing_CheckTile(int callX, int callY)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = callX;
      int num2 = callY;
      Tile tileSafely = Framing.GetTileSafely(callX, callY);
      int num3 = num1 - (int) tileSafely.frameX / 18 % 3;
      int y = num2 - (int) tileSafely.frameY / 18 % 4;
      int pylonStyleFromTile = TETeleportationPylon.GetPylonStyleFromTile(tileSafely);
      bool flag = false;
      for (int index1 = num3; index1 < num3 + 3; ++index1)
      {
        for (int index2 = y; index2 < y + 4; ++index2)
        {
          Tile tile = Main.tile[index1, index2];
          if (!tile.active() || tile.type != (ushort) 597)
            flag = true;
        }
      }
      if (!WorldGen.SolidTileAllowBottomSlope(num3, y + 4) || !WorldGen.SolidTileAllowBottomSlope(num3 + 1, y + 4) || !WorldGen.SolidTileAllowBottomSlope(num3 + 2, y + 4))
        flag = true;
      if (!flag)
        return;
      TETeleportationPylon.Kill(num3, y);
      int typeFromTileStyle = TETeleportationPylon.GetPylonItemTypeFromTileStyle(pylonStyleFromTile);
      Item.NewItem(num3 * 16, y * 16, 48, 64, typeFromTileStyle);
      WorldGen.destroyObject = true;
      for (int i = num3; i < num3 + 3; ++i)
      {
        for (int j = y; j < y + 4; ++j)
        {
          if (Main.tile[i, j].active() && Main.tile[i, j].type == (ushort) 597)
            WorldGen.KillTile(i, j);
        }
      }
      WorldGen.destroyObject = false;
    }

    public static int GetPylonStyleFromTile(Tile tile) => (int) tile.frameX / 54;

    public static int GetPylonItemTypeFromTileStyle(int style)
    {
      switch (style)
      {
        case 1:
          return 4875;
        case 2:
          return 4916;
        case 3:
          return 4917;
        case 4:
          return 4918;
        case 5:
          return 4919;
        case 6:
          return 4920;
        case 7:
          return 4921;
        case 8:
          return 4951;
        default:
          return 4876;
      }
    }

    public override bool IsTileValidForEntity(int x, int y) => Main.tile[x, y].active() && Main.tile[x, y].type == (ushort) 597 && Main.tile[x, y].frameY == (short) 0 && (int) Main.tile[x, y].frameX % 54 == 0;

    public static int PlacementPreviewHook_AfterPlacement(
      int x,
      int y,
      int type = 597,
      int style = 0,
      int direction = 1,
      int alternate = 0)
    {
      if (Main.netMode != 1)
        return TETeleportationPylon.Place(x - 1, y - 3);
      NetMessage.SendTileSquare(Main.myPlayer, x, y - 1, 5);
      NetMessage.SendData(87, number: (x - 1), number2: ((float) (y - 3)), number3: ((float) TETeleportationPylon._myEntityID));
      return -1;
    }

    public static int PlacementPreviewHook_CheckIfCanPlace(
      int x,
      int y,
      int type = 597,
      int style = 0,
      int direction = 1,
      int alternate = 0)
    {
      TeleportPylonType fromPylonTileStyle = TETeleportationPylon.GetPylonTypeFromPylonTileStyle(style);
      return Main.PylonSystem.HasPylonOfType(fromPylonTileStyle) ? 1 : 0;
    }

    private bool TryGetPylonTypeFromTileCoords(int x, int y, out TeleportPylonType pylonType)
    {
      pylonType = TeleportPylonType.SurfacePurity;
      Tile tile = Main.tile[x, y];
      if (tile == null || !tile.active() || tile.type != (ushort) 597)
        return false;
      int pylonStyle = (int) tile.frameX / 54;
      pylonType = TETeleportationPylon.GetPylonTypeFromPylonTileStyle(pylonStyle);
      return true;
    }

    private static TeleportPylonType GetPylonTypeFromPylonTileStyle(int pylonStyle) => (TeleportPylonType) pylonStyle;

    public static int Find(int x, int y)
    {
      TileEntity tileEntity;
      return TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) && (int) tileEntity.type == (int) TETeleportationPylon._myEntityID ? tileEntity.ID : -1;
    }
  }
}
