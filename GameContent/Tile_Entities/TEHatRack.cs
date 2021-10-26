// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Tile_Entities.TEHatRack
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
  public class TEHatRack : TileEntity
  {
    private static byte _myEntityID;
    private const int MyTileID = 475;
    private const int entityTileWidth = 3;
    private const int entityTileHeight = 4;
    private Player _dollPlayer;
    private Item[] _items;
    private Item[] _dyes;
    private static int hatTargetSlot;

    public TEHatRack()
    {
      this._items = new Item[2];
      for (int index = 0; index < this._items.Length; ++index)
        this._items[index] = new Item();
      this._dyes = new Item[2];
      for (int index = 0; index < this._dyes.Length; ++index)
        this._dyes[index] = new Item();
      this._dollPlayer = new Player();
      this._dollPlayer.hair = 15;
      this._dollPlayer.skinColor = Color.White;
      this._dollPlayer.skinVariant = 10;
    }

    public override void RegisterTileEntityID(int assignedID) => TEHatRack._myEntityID = (byte) assignedID;

    public override TileEntity GenerateInstance() => (TileEntity) new TEHatRack();

    public override void NetPlaceEntityAttempt(int x, int y) => NetMessage.SendData(86, number: TEHatRack.Place(x, y), number2: ((float) x), number3: ((float) y));

    public static int Place(int x, int y)
    {
      TEHatRack teHatRack = new TEHatRack();
      teHatRack.Position = new Point16(x, y);
      teHatRack.ID = TileEntity.AssignNewID();
      teHatRack.type = TEHatRack._myEntityID;
      TileEntity.ByID[teHatRack.ID] = (TileEntity) teHatRack;
      TileEntity.ByPosition[teHatRack.Position] = (TileEntity) teHatRack;
      return teHatRack.ID;
    }

    public static int Hook_AfterPlacement(
      int x,
      int y,
      int type = 475,
      int style = 0,
      int direction = 1,
      int alternate = 0)
    {
      if (Main.netMode != 1)
        return TEHatRack.Place(x - 1, y - 3);
      NetMessage.SendTileSquare(Main.myPlayer, x, y - 1, 5);
      NetMessage.SendData(87, number: (x - 1), number2: ((float) (y - 3)), number3: ((float) TEHatRack._myEntityID));
      return -1;
    }

    public static void Kill(int x, int y)
    {
      TileEntity tileEntity;
      if (!TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) || (int) tileEntity.type != (int) TEHatRack._myEntityID)
        return;
      TileEntity.ByID.Remove(tileEntity.ID);
      TileEntity.ByPosition.Remove(new Point16(x, y));
    }

    public static int Find(int x, int y)
    {
      TileEntity tileEntity;
      return TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) && (int) tileEntity.type == (int) TEHatRack._myEntityID ? tileEntity.ID : -1;
    }

    public override void WriteExtraData(BinaryWriter writer, bool networkSend)
    {
      BitsByte bitsByte = (BitsByte) (byte) 0;
      bitsByte[0] = !this._items[0].IsAir;
      bitsByte[1] = !this._items[1].IsAir;
      bitsByte[2] = !this._dyes[0].IsAir;
      bitsByte[3] = !this._dyes[1].IsAir;
      writer.Write((byte) bitsByte);
      for (int index = 0; index < 2; ++index)
      {
        Item obj = this._items[index];
        if (!obj.IsAir)
        {
          writer.Write((short) obj.netID);
          writer.Write(obj.prefix);
          writer.Write((short) obj.stack);
        }
      }
      for (int index = 0; index < 2; ++index)
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
      BitsByte bitsByte = (BitsByte) reader.ReadByte();
      for (int key = 0; key < 2; ++key)
      {
        this._items[key] = new Item();
        Item obj = this._items[key];
        if (bitsByte[key])
        {
          obj.netDefaults((int) reader.ReadInt16());
          obj.Prefix((int) reader.ReadByte());
          obj.stack = (int) reader.ReadInt16();
        }
      }
      for (int index = 0; index < 2; ++index)
      {
        this._dyes[index] = new Item();
        Item dye = this._dyes[index];
        if (bitsByte[index + 2])
        {
          dye.netDefaults((int) reader.ReadInt16());
          dye.Prefix((int) reader.ReadByte());
          dye.stack = (int) reader.ReadInt16();
        }
      }
    }

    public override string ToString() => this.Position.X.ToString() + "x  " + (object) this.Position.Y + "y item: " + (object) this._items[0] + " " + (object) this._items[1];

    public static void Framing_CheckTile(int callX, int callY)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = callX;
      int num2 = callY;
      Tile tileSafely = Framing.GetTileSafely(callX, callY);
      int num3 = num1 - (int) tileSafely.frameX / 18 % 3;
      int y = num2 - (int) tileSafely.frameY / 18 % 4;
      bool flag = false;
      for (int index1 = num3; index1 < num3 + 3; ++index1)
      {
        for (int index2 = y; index2 < y + 4; ++index2)
        {
          Tile tile = Main.tile[index1, index2];
          if (!tile.active() || tile.type != (ushort) 475)
            flag = true;
        }
      }
      if (!WorldGen.SolidTileAllowBottomSlope(num3, y + 4) || !WorldGen.SolidTileAllowBottomSlope(num3 + 1, y + 4) || !WorldGen.SolidTileAllowBottomSlope(num3 + 2, y + 4))
        flag = true;
      if (!flag)
        return;
      TEHatRack.Kill(num3, y);
      Item.NewItem(num3 * 16, y * 16, 48, 64, 3977);
      WorldGen.destroyObject = true;
      for (int i = num3; i < num3 + 3; ++i)
      {
        for (int j = y; j < y + 4; ++j)
        {
          if (Main.tile[i, j].active() && Main.tile[i, j].type == (ushort) 475)
            WorldGen.KillTile(i, j);
        }
      }
      WorldGen.destroyObject = false;
    }

    public void Draw(int tileLeftX, int tileTopY)
    {
      Player dollPlayer = this._dollPlayer;
      dollPlayer.direction = -1;
      dollPlayer.Male = true;
      if ((int) Framing.GetTileSafely(tileLeftX, tileTopY).frameX % 216 == 54)
        dollPlayer.direction = 1;
      dollPlayer.isDisplayDollOrInanimate = true;
      dollPlayer.isHatRackDoll = true;
      dollPlayer.armor[0] = this._items[0];
      dollPlayer.dye[0] = this._dyes[0];
      dollPlayer.ResetEffects();
      dollPlayer.ResetVisibleAccessories();
      dollPlayer.invis = true;
      dollPlayer.UpdateDyes();
      dollPlayer.DisplayDollUpdate();
      dollPlayer.PlayerFrame();
      Vector2 vector2_1 = new Vector2((float) tileLeftX + 1.5f, (float) (tileTopY + 4)) * 16f;
      dollPlayer.direction *= -1;
      Vector2 vector2_2 = new Vector2((float) (-dollPlayer.width / 2), (float) (-dollPlayer.height - 6)) + new Vector2((float) (dollPlayer.direction * 14), -2f);
      dollPlayer.position = vector2_1 + vector2_2;
      Main.PlayerRenderer.DrawPlayer(Main.Camera, dollPlayer, dollPlayer.position, 0.0f, dollPlayer.fullRotationOrigin);
      dollPlayer.armor[0] = this._items[1];
      dollPlayer.dye[0] = this._dyes[1];
      dollPlayer.ResetEffects();
      dollPlayer.ResetVisibleAccessories();
      dollPlayer.invis = true;
      dollPlayer.UpdateDyes();
      dollPlayer.DisplayDollUpdate();
      dollPlayer.skipAnimatingValuesInPlayerFrame = true;
      dollPlayer.PlayerFrame();
      dollPlayer.skipAnimatingValuesInPlayerFrame = false;
      dollPlayer.direction *= -1;
      Vector2 vector2_3 = new Vector2((float) (-dollPlayer.width / 2), (float) (-dollPlayer.height - 6)) + new Vector2((float) (dollPlayer.direction * 12), 16f);
      dollPlayer.position = vector2_1 + vector2_3;
      Main.PlayerRenderer.DrawPlayer(Main.Camera, dollPlayer, dollPlayer.position, 0.0f, dollPlayer.fullRotationOrigin);
    }

    public override string GetItemGamepadInstructions(int slot = 0)
    {
      Item[] inv = this._items;
      int slot1 = slot;
      int context = 26;
      if (slot >= 2)
      {
        slot1 -= 2;
        inv = this._dyes;
        context = 27;
      }
      return ItemSlot.GetGamepadInstructions(inv, context, slot1);
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
          if (TEHatRack.FitsHatRack(newItem))
          {
            instruction = Lang.misc[76].Value;
            return true;
          }
          break;
        case 26:
        case 27:
          if (Main.player[Main.myPlayer].ItemSpace(newItem).CanTakeItemToPersonalInventory)
          {
            instruction = Lang.misc[68].Value;
            return true;
          }
          break;
      }
      return false;
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
      int index1 = clickX;
      int index2 = clickY;
      int x1 = index1 - (int) Main.tile[index1, index2].frameX % 54 / 18;
      int y1 = index2 - (int) Main.tile[x1, index2].frameY / 18;
      int id = TEHatRack.Find(x1, y1);
      if (id == -1)
        return;
      int y2 = y1 + 1;
      int x2 = x1 + 1;
      TileEntity.BasicOpenCloseInteraction(player, x2, y2, id);
    }

    public override void OnInventoryDraw(Player player, SpriteBatch spriteBatch)
    {
      if (Main.tile[player.tileEntityAnchor.X, player.tileEntityAnchor.Y].type != (ushort) 475)
      {
        player.tileEntityAnchor.Clear();
        Recipe.FindRecipes();
      }
      else
        this.DrawInner(player, spriteBatch);
    }

    private void DrawInner(Player player, SpriteBatch spriteBatch)
    {
      Main.inventoryScale = 0.72f;
      this.DrawSlotPairSet(player, spriteBatch, 2, 0, 3.5f, 0.5f, 26);
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
            context = 27;
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
      if (!obj.IsAir && !inv[slot].favorited && context == 0 && TEHatRack.FitsHatRack(obj))
      {
        Main.cursorOverride = 9;
        return true;
      }
      if (obj.IsAir || context != 26 && context != 27 || !Main.player[Main.myPlayer].ItemSpace(inv[slot]).CanTakeItemToPersonalInventory)
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
        if (Main.cursorOverride == 9 && !obj.IsAir && !obj.favorited && context == 0 && TEHatRack.FitsHatRack(obj))
          return this.TryFitting(inv, context, slot);
      }
      if ((Main.cursorOverride != 8 || context != 23) && context != 26 && context != 27)
        return false;
      inv[slot] = Main.player[Main.myPlayer].GetItem(Main.myPlayer, inv[slot], GetItemSettings.InventoryEntityToPlayerInventorySettings);
      if (Main.netMode == 1)
        NetMessage.SendData(124, number: Main.myPlayer, number2: ((float) this.ID), number3: ((float) slot));
      return true;
    }

    public static bool FitsHatRack(Item item) => item.maxStack <= 1 && item.headSlot > 0;

    private bool TryFitting(Item[] inv, int context = 0, int slot = 0, bool justCheck = false)
    {
      if (!TEHatRack.FitsHatRack(inv[slot]))
        return false;
      if (justCheck)
        return true;
      int index1 = TEHatRack.hatTargetSlot;
      ++TEHatRack.hatTargetSlot;
      for (int index2 = 0; index2 < 2; ++index2)
      {
        if (this._items[index2].IsAir)
        {
          index1 = index2;
          TEHatRack.hatTargetSlot = index2 + 1;
          break;
        }
      }
      for (int index3 = 0; index3 < 2; ++index3)
      {
        if (inv[slot].type == this._items[index3].type)
          index1 = index3;
      }
      if (TEHatRack.hatTargetSlot >= 2)
        TEHatRack.hatTargetSlot = 0;
      SoundEngine.PlaySound(7);
      Utils.Swap<Item>(ref this._items[index1], ref inv[slot]);
      if (Main.netMode == 1)
        NetMessage.SendData(124, number: Main.myPlayer, number2: ((float) this.ID), number3: ((float) index1));
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

    public override bool IsTileValidForEntity(int x, int y) => Main.tile[x, y].active() && Main.tile[x, y].type == (ushort) 475 && Main.tile[x, y].frameY == (short) 0 && (int) Main.tile[x, y].frameX % 54 == 0;

    public static bool IsBreakable(int clickX, int clickY)
    {
      int index1 = clickX;
      int index2 = clickY;
      int x = index1 - (int) Main.tile[index1, index2].frameX % 54 / 18;
      int y = index2 - (int) Main.tile[x, index2].frameY / 18;
      int key = TEHatRack.Find(x, y);
      return key == -1 || !(TileEntity.ByID[key] as TEHatRack).ContainsItems();
    }

    public bool ContainsItems()
    {
      for (int index = 0; index < 2; ++index)
      {
        if (!this._items[index].IsAir || !this._dyes[index].IsAir)
          return true;
      }
      return false;
    }
  }
}
