// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.TileEntity
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria.Audio;
using Terraria.GameInput;

namespace Terraria.DataStructures
{
  public abstract class TileEntity
  {
    public static TileEntitiesManager manager;
    public const int MaxEntitiesPerChunk = 1000;
    public static Dictionary<int, TileEntity> ByID = new Dictionary<int, TileEntity>();
    public static Dictionary<Point16, TileEntity> ByPosition = new Dictionary<Point16, TileEntity>();
    public static int TileEntitiesNextID;
    public int ID;
    public Point16 Position;
    public byte type;

    public static int AssignNewID() => TileEntity.TileEntitiesNextID++;

    public static event Action _UpdateStart;

    public static event Action _UpdateEnd;

    public static void Clear()
    {
      TileEntity.ByID.Clear();
      TileEntity.ByPosition.Clear();
      TileEntity.TileEntitiesNextID = 0;
    }

    public static void UpdateStart()
    {
      if (TileEntity._UpdateStart == null)
        return;
      TileEntity._UpdateStart();
    }

    public static void UpdateEnd()
    {
      if (TileEntity._UpdateEnd == null)
        return;
      TileEntity._UpdateEnd();
    }

    public static void InitializeAll()
    {
      TileEntity.manager = new TileEntitiesManager();
      TileEntity.manager.RegisterAll();
    }

    public static void PlaceEntityNet(int x, int y, int type)
    {
      if (!WorldGen.InWorld(x, y) || TileEntity.ByPosition.ContainsKey(new Point16(x, y)))
        return;
      TileEntity.manager.NetPlaceEntity(type, x, y);
    }

    public virtual void Update()
    {
    }

    public static void Write(BinaryWriter writer, TileEntity ent, bool networkSend = false)
    {
      writer.Write(ent.type);
      ent.WriteInner(writer, networkSend);
    }

    public static TileEntity Read(BinaryReader reader, bool networkSend = false)
    {
      byte num = reader.ReadByte();
      TileEntity instance = TileEntity.manager.GenerateInstance((int) num);
      instance.type = num;
      instance.ReadInner(reader, networkSend);
      return instance;
    }

    private void WriteInner(BinaryWriter writer, bool networkSend)
    {
      if (!networkSend)
        writer.Write(this.ID);
      writer.Write(this.Position.X);
      writer.Write(this.Position.Y);
      this.WriteExtraData(writer, networkSend);
    }

    private void ReadInner(BinaryReader reader, bool networkSend)
    {
      if (!networkSend)
        this.ID = reader.ReadInt32();
      this.Position = new Point16(reader.ReadInt16(), reader.ReadInt16());
      this.ReadExtraData(reader, networkSend);
    }

    public virtual void WriteExtraData(BinaryWriter writer, bool networkSend)
    {
    }

    public virtual void ReadExtraData(BinaryReader reader, bool networkSend)
    {
    }

    public virtual void OnPlayerUpdate(Player player)
    {
    }

    public static bool IsOccupied(int id, out int interactingPlayer)
    {
      interactingPlayer = -1;
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        Player player = Main.player[index];
        if (player.active && !player.dead && player.tileEntityAnchor.interactEntityID == id)
        {
          interactingPlayer = index;
          return true;
        }
      }
      return false;
    }

    public virtual void OnInventoryDraw(Player player, SpriteBatch spriteBatch)
    {
    }

    public virtual string GetItemGamepadInstructions(int slot = 0) => "";

    public virtual bool TryGetItemGamepadOverrideInstructions(
      Item[] inv,
      int context,
      int slot,
      out string instruction)
    {
      instruction = (string) null;
      return false;
    }

    public virtual bool OverrideItemSlotHover(Item[] inv, int context = 0, int slot = 0) => false;

    public virtual bool OverrideItemSlotLeftClick(Item[] inv, int context = 0, int slot = 0) => false;

    public static void BasicOpenCloseInteraction(Player player, int x, int y, int id)
    {
      player.CloseSign();
      if (Main.netMode != 1)
      {
        Main.stackSplit = 600;
        player.GamepadEnableGrappleCooldown();
        int interactingPlayer;
        if (TileEntity.IsOccupied(id, out interactingPlayer))
        {
          if (interactingPlayer != player.whoAmI)
            return;
          Recipe.FindRecipes();
          SoundEngine.PlaySound(11);
          player.tileEntityAnchor.Clear();
        }
        else
          TileEntity.SetInteractionAnchor(player, x, y, id);
      }
      else
      {
        Main.stackSplit = 600;
        player.GamepadEnableGrappleCooldown();
        int interactingPlayer;
        if (TileEntity.IsOccupied(id, out interactingPlayer))
        {
          if (interactingPlayer != player.whoAmI)
            return;
          Recipe.FindRecipes();
          SoundEngine.PlaySound(11);
          player.tileEntityAnchor.Clear();
          NetMessage.SendData(122, number: -1, number2: ((float) Main.myPlayer));
        }
        else
          NetMessage.SendData(122, number: id, number2: ((float) Main.myPlayer));
      }
    }

    public static void SetInteractionAnchor(Player player, int x, int y, int id)
    {
      player.chest = -1;
      player.SetTalkNPC(-1);
      if (player.whoAmI == Main.myPlayer)
      {
        Main.playerInventory = true;
        Main.recBigList = false;
        Main.CreativeMenu.CloseMenu();
        if (PlayerInput.GrappleAndInteractAreShared)
          PlayerInput.Triggers.JustPressed.Grapple = false;
        if (player.tileEntityAnchor.interactEntityID != -1)
          SoundEngine.PlaySound(12);
        else
          SoundEngine.PlaySound(10);
      }
      player.tileEntityAnchor.Set(id, x, y);
    }

    public virtual void RegisterTileEntityID(int assignedID)
    {
    }

    public virtual void NetPlaceEntityAttempt(int x, int y)
    {
    }

    public virtual bool IsTileValidForEntity(int x, int y) => false;

    public virtual TileEntity GenerateInstance() => (TileEntity) null;
  }
}
