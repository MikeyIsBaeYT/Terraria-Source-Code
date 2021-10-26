// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Tile_Entities.TEItemFrame
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.IO;
using Terraria.DataStructures;

namespace Terraria.GameContent.Tile_Entities
{
  public class TEItemFrame : TileEntity
  {
    private static byte _myEntityID;
    public Item item;

    public override void RegisterTileEntityID(int assignedID) => TEItemFrame._myEntityID = (byte) assignedID;

    public override void NetPlaceEntityAttempt(int x, int y) => TEItemFrame.NetPlaceEntity(x, y);

    public static void NetPlaceEntity(int x, int y) => NetMessage.SendData(86, number: TEItemFrame.Place(x, y), number2: ((float) x), number3: ((float) y));

    public override TileEntity GenerateInstance() => (TileEntity) new TEItemFrame();

    public TEItemFrame() => this.item = new Item();

    public static int Place(int x, int y)
    {
      TEItemFrame teItemFrame = new TEItemFrame();
      teItemFrame.Position = new Point16(x, y);
      teItemFrame.ID = TileEntity.AssignNewID();
      teItemFrame.type = TEItemFrame._myEntityID;
      TileEntity.ByID[teItemFrame.ID] = (TileEntity) teItemFrame;
      TileEntity.ByPosition[teItemFrame.Position] = (TileEntity) teItemFrame;
      return teItemFrame.ID;
    }

    public override bool IsTileValidForEntity(int x, int y) => TEItemFrame.ValidTile(x, y);

    public static int Hook_AfterPlacement(
      int x,
      int y,
      int type = 395,
      int style = 0,
      int direction = 1,
      int alternate = 0)
    {
      if (Main.netMode != 1)
        return TEItemFrame.Place(x, y);
      NetMessage.SendTileSquare(Main.myPlayer, x, y, 2);
      NetMessage.SendData(87, number: x, number2: ((float) y), number3: ((float) TEItemFrame._myEntityID));
      return -1;
    }

    public static void Kill(int x, int y)
    {
      TileEntity tileEntity;
      if (!TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) || (int) tileEntity.type != (int) TEItemFrame._myEntityID)
        return;
      TileEntity.ByID.Remove(tileEntity.ID);
      TileEntity.ByPosition.Remove(new Point16(x, y));
    }

    public static int Find(int x, int y)
    {
      TileEntity tileEntity;
      return TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) && (int) tileEntity.type == (int) TEItemFrame._myEntityID ? tileEntity.ID : -1;
    }

    public static bool ValidTile(int x, int y) => Main.tile[x, y].active() && Main.tile[x, y].type == (ushort) 395 && Main.tile[x, y].frameY == (short) 0 && (int) Main.tile[x, y].frameX % 36 == 0;

    public override void WriteExtraData(BinaryWriter writer, bool networkSend)
    {
      writer.Write((short) this.item.netID);
      writer.Write(this.item.prefix);
      writer.Write((short) this.item.stack);
    }

    public override void ReadExtraData(BinaryReader reader, bool networkSend)
    {
      this.item = new Item();
      this.item.netDefaults((int) reader.ReadInt16());
      this.item.Prefix((int) reader.ReadByte());
      this.item.stack = (int) reader.ReadInt16();
    }

    public override string ToString() => this.Position.X.ToString() + "x  " + (object) this.Position.Y + "y item: " + (object) this.item;

    public void DropItem()
    {
      if (Main.netMode != 1)
        Item.NewItem((int) this.Position.X * 16, (int) this.Position.Y * 16, 32, 32, this.item.netID, pfix: ((int) this.item.prefix));
      this.item = new Item();
    }

    public static void TryPlacing(int x, int y, int netid, int prefix, int stack)
    {
      WorldGen.RangeFrame(x, y, x + 2, y + 2);
      int key = TEItemFrame.Find(x, y);
      if (key == -1)
      {
        int number = Item.NewItem(x * 16, y * 16, 32, 32, 1);
        Main.item[number].netDefaults(netid);
        Main.item[number].Prefix(prefix);
        Main.item[number].stack = stack;
        NetMessage.SendData(21, number: number);
      }
      else
      {
        TEItemFrame teItemFrame = (TEItemFrame) TileEntity.ByID[key];
        if (teItemFrame.item.stack > 0)
          teItemFrame.DropItem();
        teItemFrame.item = new Item();
        teItemFrame.item.netDefaults(netid);
        teItemFrame.item.Prefix(prefix);
        teItemFrame.item.stack = stack;
        NetMessage.SendData(86, number: teItemFrame.ID, number2: ((float) x), number3: ((float) y));
      }
    }

    public static void OnPlayerInteraction(Player player, int clickX, int clickY)
    {
      if (TEItemFrame.FitsItemFrame(player.inventory[player.selectedItem]) && !player.inventory[player.selectedItem].favorited)
      {
        player.GamepadEnableGrappleCooldown();
        TEItemFrame.PlaceItemInFrame(player, clickX, clickY);
        Recipe.FindRecipes();
      }
      else
      {
        int x = clickX;
        int y = clickY;
        if ((int) Main.tile[x, y].frameX % 36 != 0)
          --x;
        if ((int) Main.tile[x, y].frameY % 36 != 0)
          --y;
        int key = TEItemFrame.Find(x, y);
        if (key == -1 || ((TEItemFrame) TileEntity.ByID[key]).item.stack <= 0)
          return;
        player.GamepadEnableGrappleCooldown();
        WorldGen.KillTile(clickX, clickY, true);
        if (Main.netMode != 1)
          return;
        NetMessage.SendData(17, number2: ((float) x), number3: ((float) y), number4: 1f);
      }
    }

    public static bool FitsItemFrame(Item i) => i.stack > 0;

    public static void PlaceItemInFrame(Player player, int x, int y)
    {
      if ((int) Main.tile[x, y].frameX % 36 != 0)
        --x;
      if ((int) Main.tile[x, y].frameY % 36 != 0)
        --y;
      int key = TEItemFrame.Find(x, y);
      if (key == -1)
        return;
      if (((TEItemFrame) TileEntity.ByID[key]).item.stack > 0)
      {
        WorldGen.KillTile(x, y, true);
        if (Main.netMode == 1)
          NetMessage.SendData(17, number2: ((float) Player.tileTargetX), number3: ((float) y), number4: 1f);
      }
      if (Main.netMode == 1)
        NetMessage.SendData(89, number: x, number2: ((float) y), number3: ((float) player.selectedItem), number4: ((float) player.whoAmI), number5: 1);
      else
        TEItemFrame.TryPlacing(x, y, player.inventory[player.selectedItem].netID, (int) player.inventory[player.selectedItem].prefix, 1);
      --player.inventory[player.selectedItem].stack;
      if (player.inventory[player.selectedItem].stack <= 0)
      {
        player.inventory[player.selectedItem].SetDefaults();
        Main.mouseItem.SetDefaults();
      }
      if (player.selectedItem == 58)
        Main.mouseItem = player.inventory[player.selectedItem].Clone();
      player.releaseUseItem = false;
      player.mouseInterface = true;
      WorldGen.RangeFrame(x, y, x + 2, y + 2);
    }
  }
}
