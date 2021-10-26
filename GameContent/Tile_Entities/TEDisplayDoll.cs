// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Tile_Entities.TEDisplayDoll
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.UI;

namespace Terraria.GameContent.Tile_Entities
{
  public class TEDisplayDoll : TileEntity
  {
    private static byte _myEntityID;
    private const int MyTileID = 470;
    private const int entityTileWidth = 2;
    private const int entityTileHeight = 3;
    private Player _dollPlayer;
    private Item[] _items;
    private Item[] _dyes;
    private static int accessoryTargetSlot = 3;

    public TEDisplayDoll()
    {
      this._items = new Item[8];
      for (int index = 0; index < this._items.Length; ++index)
        this._items[index] = new Item();
      this._dyes = new Item[8];
      for (int index = 0; index < this._dyes.Length; ++index)
        this._dyes[index] = new Item();
      this._dollPlayer = new Player();
      this._dollPlayer.hair = 15;
      this._dollPlayer.skinColor = Color.White;
      this._dollPlayer.skinVariant = 10;
    }

    public override void RegisterTileEntityID(int assignedID) => TEDisplayDoll._myEntityID = (byte) assignedID;

    public override TileEntity GenerateInstance() => (TileEntity) new TEDisplayDoll();

    public override void NetPlaceEntityAttempt(int x, int y) => NetMessage.SendData(86, number: TEDisplayDoll.Place(x, y), number2: ((float) x), number3: ((float) y));

    public static int Place(int x, int y)
    {
      TEDisplayDoll teDisplayDoll = new TEDisplayDoll();
      teDisplayDoll.Position = new Point16(x, y);
      teDisplayDoll.ID = TileEntity.AssignNewID();
      teDisplayDoll.type = TEDisplayDoll._myEntityID;
      TileEntity.ByID[teDisplayDoll.ID] = (TileEntity) teDisplayDoll;
      TileEntity.ByPosition[teDisplayDoll.Position] = (TileEntity) teDisplayDoll;
      return teDisplayDoll.ID;
    }

    public static int Hook_AfterPlacement(
      int x,
      int y,
      int type = 470,
      int style = 0,
      int direction = 1,
      int alternate = 0)
    {
      if (Main.netMode != 1)
        return TEDisplayDoll.Place(x, y - 2);
      NetMessage.SendTileSquare(Main.myPlayer, x, y - 1, 3);
      NetMessage.SendData(87, number: x, number2: ((float) (y - 2)), number3: ((float) TEDisplayDoll._myEntityID));
      return -1;
    }

    public static void Kill(int x, int y)
    {
      TileEntity tileEntity;
      if (!TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) || (int) tileEntity.type != (int) TEDisplayDoll._myEntityID)
        return;
      TileEntity.ByID.Remove(tileEntity.ID);
      TileEntity.ByPosition.Remove(new Point16(x, y));
    }

    public static int Find(int x, int y)
    {
      TileEntity tileEntity;
      return TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) && (int) tileEntity.type == (int) TEDisplayDoll._myEntityID ? tileEntity.ID : -1;
    }

    public override void WriteExtraData(BinaryWriter writer, bool networkSend)
    {
      BitsByte bitsByte1 = (BitsByte) (byte) 0;
      bitsByte1[0] = !this._items[0].IsAir;
      bitsByte1[1] = !this._items[1].IsAir;
      bitsByte1[2] = !this._items[2].IsAir;
      bitsByte1[3] = !this._items[3].IsAir;
      bitsByte1[4] = !this._items[4].IsAir;
      bitsByte1[5] = !this._items[5].IsAir;
      bitsByte1[6] = !this._items[6].IsAir;
      bitsByte1[7] = !this._items[7].IsAir;
      BitsByte bitsByte2 = (BitsByte) (byte) 0;
      bitsByte2[0] = !this._dyes[0].IsAir;
      bitsByte2[1] = !this._dyes[1].IsAir;
      bitsByte2[2] = !this._dyes[2].IsAir;
      bitsByte2[3] = !this._dyes[3].IsAir;
      bitsByte2[4] = !this._dyes[4].IsAir;
      bitsByte2[5] = !this._dyes[5].IsAir;
      bitsByte2[6] = !this._dyes[6].IsAir;
      bitsByte2[7] = !this._dyes[7].IsAir;
      writer.Write((byte) bitsByte1);
      writer.Write((byte) bitsByte2);
      for (int index = 0; index < 8; ++index)
      {
        Item obj = this._items[index];
        if (!obj.IsAir)
        {
          writer.Write((short) obj.netID);
          writer.Write(obj.prefix);
          writer.Write((short) obj.stack);
        }
      }
      for (int index = 0; index < 8; ++index)
      {
        Item dye = this._dyes[index];
        if (!dye.IsAir)
        {
          writer.Write((short) dye.netID);
          writer.Write(dye.prefix);
          writer.Write((short) dye.stack);
        }
      }
    }

    public override void ReadExtraData(BinaryReader reader, bool networkSend)
    {
      BitsByte bitsByte1 = (BitsByte) reader.ReadByte();
      BitsByte bitsByte2 = (BitsByte) reader.ReadByte();
      for (int key = 0; key < 8; ++key)
      {
        this._items[key] = new Item();
        Item obj = this._items[key];
        if (bitsByte1[key])
        {
          obj.netDefaults((int) reader.ReadInt16());
          obj.Prefix((int) reader.ReadByte());
          obj.stack = (int) reader.ReadInt16();
        }
      }
      for (int key = 0; key < 8; ++key)
      {
        this._dyes[key] = new Item();
        Item dye = this._dyes[key];
        if (bitsByte2[key])
        {
          dye.netDefaults((int) reader.ReadInt16());
          dye.Prefix((int) reader.ReadByte());
          dye.stack = (int) reader.ReadInt16();
        }
      }
    }

    public override string ToString() => this.Position.X.ToString() + "x  " + (object) this.Position.Y + "y item: " + (object) this._items[0] + " " + (object) this._items[1] + " " + (object) this._items[2];

    public static void Framing_CheckTile(int callX, int callY)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = callX;
      int num2 = callY;
      Tile tileSafely = Framing.GetTileSafely(callX, callY);
      int num3 = num1 - (int) tileSafely.frameX / 18 % 2;
      int y = num2 - (int) tileSafely.frameY / 18 % 3;
      bool flag = false;
      for (int index1 = num3; index1 < num3 + 2; ++index1)
      {
        for (int index2 = y; index2 < y + 3; ++index2)
        {
          Tile tile = Main.tile[index1, index2];
          if (!tile.active() || tile.type != (ushort) 470)
            flag = true;
        }
      }
      if (!WorldGen.SolidTileAllowBottomSlope(num3, y + 3) || !WorldGen.SolidTileAllowBottomSlope(num3 + 1, y + 3))
        flag = true;
      if (!flag)
        return;
      TEDisplayDoll.Kill(num3, y);
      if ((int) Main.tile[callX, callY].frameX / 72 != 1)
        Item.NewItem(num3 * 16, y * 16, 32, 48, 498);
      else
        Item.NewItem(num3 * 16, y * 16, 32, 48, 1989);
      WorldGen.destroyObject = true;
      for (int i = num3; i < num3 + 2; ++i)
      {
        for (int j = y; j < y + 3; ++j)
        {
          if (Main.tile[i, j].active() && Main.tile[i, j].type == (ushort) 470)
            WorldGen.KillTile(i, j);
        }
      }
      WorldGen.destroyObject = false;
    }

    public void Draw(int tileLeftX, int tileTopY)
    {
      Player dollPlayer = this._dollPlayer;
      for (int index = 0; index < 8; ++index)
      {
        dollPlayer.armor[index] = this._items[index];
        dollPlayer.dye[index] = this._dyes[index];
      }
      dollPlayer.direction = -1;
      dollPlayer.Male = true;
      Tile tileSafely = Framing.GetTileSafely(tileLeftX, tileTopY);
      if ((int) tileSafely.frameX % 72 == 36)
        dollPlayer.direction = 1;
      if ((int) tileSafely.frameX / 72 == 1)
        dollPlayer.Male = false;
      dollPlayer.isDisplayDollOrInanimate = true;
      dollPlayer.ResetEffects();
      dollPlayer.ResetVisibleAccessories();
      dollPlayer.UpdateDyes();
      dollPlayer.DisplayDollUpdate();
      dollPlayer.UpdateSocialShadow();
      dollPlayer.PlayerFrame();
      Vector2 vector2 = new Vector2((float) (tileLeftX + 1), (float) (tileTopY + 3)) * 16f + new Vector2((float) (-dollPlayer.width / 2), (float) (-dollPlayer.height - 6));
      dollPlayer.position = vector2;
      dollPlayer.skinDyePacked = PlayerDrawHelper.PackShader((int) tileSafely.color(), PlayerDrawHelper.ShaderConfiguration.TilePaintID);
      Main.PlayerRenderer.DrawPlayer(Main.Camera, dollPlayer, dollPlayer.position, 0.0f, dollPlayer.fullRotationOrigin);
    }

    public override void OnPlayerUpdate(Player player)
    {
      if (player.InInteractionRange(player.tileEntityAnchor.X, player.tileEntityAnchor.Y) && player.chest == -1 && player.talkNPC == -1)
        return;
      if (player.chest == -1 && player.talkNPC == -1)
        SoundEngine.PlaySound(11);
      player.tileEntityAnchor.Clear();
      Recipe.FindRecipes();
    }

    public static void OnPlayerInteraction(Player player, int clickX, int clickY)
    {
      int x = clickX;
      int index = clickY;
      if ((int) Main.tile[x, index].frameX % 36 != 0)
        --x;
      int y1 = index - (int) Main.tile[x, index].frameY / 18;
      int id = TEDisplayDoll.Find(x, y1);
      if (id == -1)
        return;
      int y2 = y1 + 1;
      TEDisplayDoll.accessoryTargetSlot = 3;
      TileEntity.BasicOpenCloseInteraction(player, x, y2, id);
    }

    public override void OnInventoryDraw(Player player, SpriteBatch spriteBatch)
    {
      if (Main.tile[player.tileEntityAnchor.X, player.tileEntityAnchor.Y].type != (ushort) 470)
      {
        player.tileEntityAnchor.Clear();
        Recipe.FindRecipes();
      }
      else
        this.DrawInner(player, spriteBatch);
    }

    public override bool TryGetItemGamepadOverrideInstructions(
      Item[] inv,
      int context,
      int slot,
      out string instruction)
    {
      instruction = "";
      Item newItem = inv[slot];
      if (newItem.IsAir || newItem.favorited)
        return false;
      switch (context)
      {
        case 0:
          if (TEDisplayDoll.FitsDisplayDoll(newItem))
          {
            instruction = Lang.misc[76].Value;
            return true;
          }
          break;
        case 23:
        case 24:
        case 25:
          if (Main.player[Main.myPlayer].ItemSpace(newItem).CanTakeItemToPersonalInventory)
          {
            instruction = Lang.misc[68].Value;
            return true;
          }
          break;
      }
      return false;
    }

    public override string GetItemGamepadInstructions(int slot = 0)
    {
      Item[] inv = this._items;
      int slot1 = slot;
      int context = 23;
      if (slot >= 8)
      {
        slot1 -= 8;
        inv = this._dyes;
        context = 25;
      }
      else if (slot >= 3)
      {
        inv = this._items;
        context = 24;
      }
      return ItemSlot.GetGamepadInstructions(inv, context, slot1);
    }

    private void DrawInner(Player player, SpriteBatch spriteBatch)
    {
      Main.inventoryScale = 0.72f;
      this.DrawSlotPairSet(player, spriteBatch, 3, 0, 0.0f, 0.5f, 23);
      this.DrawSlotPairSet(player, spriteBatch, 5, 3, 3f, 0.5f, 24);
    }

    private void DrawSlotPairSet(
      Player player,
      SpriteBatch spriteBatch,
      int slotsToShowLine,
      int slotsArrayOffset,
      float offsetX,
      float offsetY,
      int inventoryContextTarget)
    {
      Item[] items = this._items;
      for (int index1 = 0; index1 < slotsToShowLine; ++index1)
      {
        for (int index2 = 0; index2 < 2; ++index2)
        {
          int num1 = (int) (73.0 + ((double) index1 + (double) offsetX) * 56.0 * (double) Main.inventoryScale);
          int num2 = (int) ((double) Main.instance.invBottom + ((double) index2 + (double) offsetY) * 56.0 * (double) Main.inventoryScale);
          Item[] inv;
          int context;
          if (index2 == 0)
          {
            inv = this._items;
            context = inventoryContextTarget;
          }
          else
          {
            inv = this._dyes;
            context = 25;
          }
          if (Utils.FloatIntersect((float) Main.mouseX, (float) Main.mouseY, 0.0f, 0.0f, (float) num1, (float) num2, (float) TextureAssets.InventoryBack.Width() * Main.inventoryScale, (float) TextureAssets.InventoryBack.Height() * Main.inventoryScale) && !PlayerInput.IgnoreMouseInterface)
          {
            player.mouseInterface = true;
            ItemSlot.Handle(inv, context, index1 + slotsArrayOffset);
          }
          ItemSlot.Draw(spriteBatch, inv, context, index1 + slotsArrayOffset, new Vector2((float) num1, (float) num2));
        }
      }
    }

    public override bool OverrideItemSlotHover(Item[] inv, int context = 0, int slot = 0)
    {
      Item obj = inv[slot];
      if (!obj.IsAir && !inv[slot].favorited && context == 0 && TEDisplayDoll.FitsDisplayDoll(obj))
      {
        Main.cursorOverride = 9;
        return true;
      }
      if (obj.IsAir || context != 23 && context != 24 && context != 25 || !Main.player[Main.myPlayer].ItemSpace(inv[slot]).CanTakeItemToPersonalInventory)
        return false;
      Main.cursorOverride = 8;
      return true;
    }

    public override bool OverrideItemSlotLeftClick(Item[] inv, int context = 0, int slot = 0)
    {
      if (!ItemSlot.ShiftInUse)
        return false;
      if (Main.cursorOverride == 9 && context == 0)
      {
        Item obj = inv[slot];
        if (!obj.IsAir && !obj.favorited && TEDisplayDoll.FitsDisplayDoll(obj))
          return this.TryFitting(inv, context, slot);
      }
      if ((Main.cursorOverride != 8 || context != 23) && context != 24 && context != 25)
        return false;
      inv[slot] = Main.player[Main.myPlayer].GetItem(Main.myPlayer, inv[slot], GetItemSettings.InventoryEntityToPlayerInventorySettings);
      if (Main.netMode == 1)
      {
        if (context == 25)
          NetMessage.SendData(121, number: Main.myPlayer, number2: ((float) this.ID), number3: ((float) slot), number4: 1f);
        else
          NetMessage.SendData(121, number: Main.myPlayer, number2: ((float) this.ID), number3: ((float) slot));
      }
      return true;
    }

    public static bool FitsDisplayDoll(Item item)
    {
      if (item.maxStack > 1)
        return false;
      return item.headSlot > 0 || item.bodySlot > 0 || item.legSlot > 0 || item.accessory;
    }

    private bool TryFitting(Item[] inv, int context = 0, int slot = 0, bool justCheck = false)
    {
      Item obj = inv[slot];
      int index1 = -1;
      if (obj.headSlot > 0)
        index1 = 0;
      if (obj.bodySlot > 0)
        index1 = 1;
      if (obj.legSlot > 0)
        index1 = 2;
      if (obj.accessory)
        index1 = TEDisplayDoll.accessoryTargetSlot;
      if (index1 == -1)
        return false;
      if (justCheck)
        return true;
      if (obj.accessory)
      {
        ++TEDisplayDoll.accessoryTargetSlot;
        if (TEDisplayDoll.accessoryTargetSlot >= 8)
          TEDisplayDoll.accessoryTargetSlot = 3;
        for (int index2 = 3; index2 < 8; ++index2)
        {
          if (this._items[index2].IsAir)
          {
            index1 = index2;
            TEDisplayDoll.accessoryTargetSlot = index2;
            break;
          }
        }
        for (int index3 = 3; index3 < 8; ++index3)
        {
          if (inv[slot].type == this._items[index3].type)
            index1 = index3;
        }
      }
      SoundEngine.PlaySound(7);
      Utils.Swap<Item>(ref this._items[index1], ref inv[slot]);
      if (Main.netMode == 1)
        NetMessage.SendData(121, number: Main.myPlayer, number2: ((float) this.ID), number3: ((float) index1));
      return true;
    }

    public void WriteItem(int itemIndex, BinaryWriter writer, bool dye)
    {
      Item dye1 = this._items[itemIndex];
      if (dye)
        dye1 = this._dyes[itemIndex];
      writer.Write((ushort) dye1.netID);
      writer.Write((ushort) dye1.stack);
      writer.Write(dye1.prefix);
    }

    public void ReadItem(int itemIndex, BinaryReader reader, bool dye)
    {
      int Type = (int) reader.ReadUInt16();
      int num = (int) reader.ReadUInt16();
      int pre = (int) reader.ReadByte();
      Item dye1 = this._items[itemIndex];
      if (dye)
        dye1 = this._dyes[itemIndex];
      dye1.SetDefaults(Type);
      dye1.stack = num;
      dye1.Prefix(pre);
    }

    public override bool IsTileValidForEntity(int x, int y) => Main.tile[x, y].active() && Main.tile[x, y].type == (ushort) 470 && Main.tile[x, y].frameY == (short) 0 && (int) Main.tile[x, y].frameX % 36 == 0;

    public void SetInventoryFromMannequin(int headFrame, int shirtFrame, int legFrame)
    {
      headFrame /= 100;
      shirtFrame /= 100;
      legFrame /= 100;
      if (headFrame >= 0 && headFrame < Item.headType.Length)
        this._items[0].SetDefaults(Item.headType[headFrame]);
      if (shirtFrame >= 0 && shirtFrame < Item.bodyType.Length)
        this._items[1].SetDefaults(Item.bodyType[shirtFrame]);
      if (legFrame < 0 || legFrame >= Item.legType.Length)
        return;
      this._items[2].SetDefaults(Item.legType[legFrame]);
    }

    public static bool IsBreakable(int clickX, int clickY)
    {
      int x = clickX;
      int index = clickY;
      if ((int) Main.tile[x, index].frameX % 36 != 0)
        --x;
      int y = index - (int) Main.tile[x, index].frameY / 18;
      int key = TEDisplayDoll.Find(x, y);
      return key == -1 || !(TileEntity.ByID[key] as TEDisplayDoll).ContainsItems();
    }

    public bool ContainsItems()
    {
      for (int index = 0; index < 8; ++index)
      {
        if (!this._items[index].IsAir || !this._dyes[index].IsAir)
          return true;
      }
      return false;
    }
  }
}
