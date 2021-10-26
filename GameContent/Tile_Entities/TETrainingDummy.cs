// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Tile_Entities.TETrainingDummy
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria.DataStructures;

namespace Terraria.GameContent.Tile_Entities
{
  public class TETrainingDummy : TileEntity
  {
    private static Dictionary<int, Rectangle> playerBox = new Dictionary<int, Rectangle>();
    private static bool playerBoxFilled;
    private static byte _myEntityID;
    public int npc;

    public override void RegisterTileEntityID(int assignedID)
    {
      TETrainingDummy._myEntityID = (byte) assignedID;
      TileEntity._UpdateStart += new Action(TETrainingDummy.ClearBoxes);
    }

    public override void NetPlaceEntityAttempt(int x, int y) => TETrainingDummy.NetPlaceEntity(x, y);

    public static void NetPlaceEntity(int x, int y) => TETrainingDummy.Place(x, y);

    public override TileEntity GenerateInstance() => (TileEntity) new TETrainingDummy();

    public override bool IsTileValidForEntity(int x, int y) => TETrainingDummy.ValidTile(x, y);

    public static void ClearBoxes()
    {
      TETrainingDummy.playerBox.Clear();
      TETrainingDummy.playerBoxFilled = false;
    }

    public override void Update()
    {
      Rectangle rectangle = new Rectangle(0, 0, 32, 48);
      rectangle.Inflate(1600, 1600);
      int x = rectangle.X;
      int y = rectangle.Y;
      if (this.npc != -1)
      {
        if (Main.npc[this.npc].active && Main.npc[this.npc].type == 488 && (double) Main.npc[this.npc].ai[0] == (double) this.Position.X && (double) Main.npc[this.npc].ai[1] == (double) this.Position.Y)
          return;
        this.Deactivate();
      }
      else
      {
        TETrainingDummy.FillPlayerHitboxes();
        rectangle.X = (int) this.Position.X * 16 + x;
        rectangle.Y = (int) this.Position.Y * 16 + y;
        bool flag = false;
        foreach (KeyValuePair<int, Rectangle> keyValuePair in TETrainingDummy.playerBox)
        {
          if (keyValuePair.Value.Intersects(rectangle))
          {
            flag = true;
            break;
          }
        }
        if (!flag)
          return;
        this.Activate();
      }
    }

    private static void FillPlayerHitboxes()
    {
      if (TETrainingDummy.playerBoxFilled)
        return;
      for (int key = 0; key < (int) byte.MaxValue; ++key)
      {
        if (Main.player[key].active)
          TETrainingDummy.playerBox[key] = Main.player[key].getRect();
      }
      TETrainingDummy.playerBoxFilled = true;
    }

    public static bool ValidTile(int x, int y) => Main.tile[x, y].active() && Main.tile[x, y].type == (ushort) 378 && Main.tile[x, y].frameY == (short) 0 && (int) Main.tile[x, y].frameX % 36 == 0;

    public TETrainingDummy() => this.npc = -1;

    public static int Place(int x, int y)
    {
      TETrainingDummy teTrainingDummy = new TETrainingDummy();
      teTrainingDummy.Position = new Point16(x, y);
      teTrainingDummy.ID = TileEntity.AssignNewID();
      teTrainingDummy.type = TETrainingDummy._myEntityID;
      TileEntity.ByID[teTrainingDummy.ID] = (TileEntity) teTrainingDummy;
      TileEntity.ByPosition[teTrainingDummy.Position] = (TileEntity) teTrainingDummy;
      return teTrainingDummy.ID;
    }

    public static int Hook_AfterPlacement(
      int x,
      int y,
      int type = 378,
      int style = 0,
      int direction = 1,
      int alternate = 0)
    {
      if (Main.netMode != 1)
        return TETrainingDummy.Place(x - 1, y - 2);
      NetMessage.SendTileSquare(Main.myPlayer, x - 1, y - 1, 3);
      NetMessage.SendData(87, number: (x - 1), number2: ((float) (y - 2)), number3: ((float) TETrainingDummy._myEntityID));
      return -1;
    }

    public static void Kill(int x, int y)
    {
      TileEntity tileEntity;
      if (!TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) || (int) tileEntity.type != (int) TETrainingDummy._myEntityID)
        return;
      TileEntity.ByID.Remove(tileEntity.ID);
      TileEntity.ByPosition.Remove(new Point16(x, y));
    }

    public static int Find(int x, int y)
    {
      TileEntity tileEntity;
      return TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) && (int) tileEntity.type == (int) TETrainingDummy._myEntityID ? tileEntity.ID : -1;
    }

    public override void WriteExtraData(BinaryWriter writer, bool networkSend) => writer.Write((short) this.npc);

    public override void ReadExtraData(BinaryReader reader, bool networkSend) => this.npc = (int) reader.ReadInt16();

    public void Activate()
    {
      int index = NPC.NewNPC((int) this.Position.X * 16 + 16, (int) this.Position.Y * 16 + 48, 488, 100);
      Main.npc[index].ai[0] = (float) this.Position.X;
      Main.npc[index].ai[1] = (float) this.Position.Y;
      Main.npc[index].netUpdate = true;
      this.npc = index;
      if (Main.netMode == 1)
        return;
      NetMessage.SendData(86, number: this.ID, number2: ((float) this.Position.X), number3: ((float) this.Position.Y));
    }

    public void Deactivate()
    {
      if (this.npc != -1)
        Main.npc[this.npc].active = false;
      this.npc = -1;
      if (Main.netMode == 1)
        return;
      NetMessage.SendData(86, number: this.ID, number2: ((float) this.Position.X), number3: ((float) this.Position.Y));
    }

    public override string ToString() => this.Position.X.ToString() + "x  " + (object) this.Position.Y + "y npc: " + (object) this.npc;
  }
}
