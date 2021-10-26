// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.TreeTopsInfo
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.IO;
using Terraria.ID;
using Terraria.Utilities;

namespace Terraria.GameContent
{
  public class TreeTopsInfo
  {
    private int[] _variations = new int[13];

    public void Save(BinaryWriter writer)
    {
      writer.Write(this._variations.Length);
      for (int index = 0; index < this._variations.Length; ++index)
        writer.Write(this._variations[index]);
    }

    public void Load(BinaryReader reader, int loadVersion)
    {
      if (loadVersion < 211)
      {
        this.CopyExistingWorldInfo();
      }
      else
      {
        int num = reader.ReadInt32();
        for (int index = 0; index < num && index < this._variations.Length; ++index)
          this._variations[index] = reader.ReadInt32();
      }
    }

    public void SyncSend(BinaryWriter writer)
    {
      for (int index = 0; index < this._variations.Length; ++index)
        writer.Write((byte) this._variations[index]);
    }

    public void SyncReceive(BinaryReader reader)
    {
      for (int areaID = 0; areaID < this._variations.Length; ++areaID)
      {
        int variation = this._variations[areaID];
        this._variations[areaID] = (int) reader.ReadByte();
        if (this._variations[areaID] != variation)
          this.DoTreeFX(areaID);
      }
    }

    public int GetTreeStyle(int areaId) => this._variations[areaId];

    public void RandomizeTreeStyleBasedOnWorldPosition(UnifiedRandom rand, Vector2 worldPosition)
    {
      Point pt = new Point((int) ((double) worldPosition.X / 16.0), (int) ((double) worldPosition.Y / 16.0) + 1);
      Tile tileSafely = Framing.GetTileSafely(pt);
      if (!tileSafely.active())
        return;
      int areaId = -1;
      if (tileSafely.type == (ushort) 70)
        areaId = 11;
      else if (tileSafely.type == (ushort) 53 && WorldGen.oceanDepths(pt.X, pt.Y))
        areaId = 10;
      else if (tileSafely.type == (ushort) 23)
        areaId = 4;
      else if (tileSafely.type == (ushort) 199)
        areaId = 8;
      else if (tileSafely.type == (ushort) 109 || tileSafely.type == (ushort) 492)
        areaId = 7;
      else if (tileSafely.type == (ushort) 53)
        areaId = 9;
      else if (tileSafely.type == (ushort) 147)
        areaId = 6;
      else if (tileSafely.type == (ushort) 60)
        areaId = 5;
      else if (tileSafely.type == (ushort) 2 || tileSafely.type == (ushort) 477)
        areaId = pt.X >= Main.treeX[0] ? (pt.X >= Main.treeX[1] ? (pt.X >= Main.treeX[2] ? 3 : 2) : 1) : 0;
      if (areaId <= -1)
        return;
      this.RandomizeTreeStyle(rand, areaId);
    }

    public void RandomizeTreeStyle(UnifiedRandom rand, int areaId)
    {
      int variation = this._variations[areaId];
      bool flag = false;
      while (this._variations[areaId] == variation)
      {
        switch (areaId)
        {
          case 0:
          case 1:
          case 2:
          case 3:
            this._variations[areaId] = rand.Next(6);
            break;
          case 4:
            this._variations[areaId] = rand.Next(5);
            break;
          case 5:
            this._variations[areaId] = rand.Next(6);
            break;
          case 6:
            this._variations[areaId] = rand.NextFromList<int>(0, 1, 2, 21, 22, 3, 31, 32, 4, 41, 42, 5, 6, 7);
            break;
          case 7:
            this._variations[areaId] = rand.Next(5);
            break;
          case 8:
            this._variations[areaId] = rand.Next(6);
            break;
          case 9:
            this._variations[areaId] = rand.Next(5);
            break;
          case 10:
            this._variations[areaId] = rand.Next(6);
            break;
          case 11:
            this._variations[areaId] = rand.Next(4);
            break;
          default:
            flag = true;
            break;
        }
        if (flag)
          break;
      }
      if (variation == this._variations[areaId])
        return;
      if (Main.netMode == 2)
        NetMessage.SendData(7);
      else
        this.DoTreeFX(areaId);
    }

    private void DoTreeFX(int areaID)
    {
    }

    public void CopyExistingWorldInfoForWorldGeneration() => this.CopyExistingWorldInfo();

    private void CopyExistingWorldInfo()
    {
      this._variations[0] = Main.treeStyle[0];
      this._variations[1] = Main.treeStyle[1];
      this._variations[2] = Main.treeStyle[2];
      this._variations[3] = Main.treeStyle[3];
      this._variations[4] = WorldGen.corruptBG;
      this._variations[5] = WorldGen.jungleBG;
      this._variations[6] = WorldGen.snowBG;
      this._variations[7] = WorldGen.hallowBG;
      this._variations[8] = WorldGen.crimsonBG;
      this._variations[9] = WorldGen.desertBG;
      this._variations[10] = WorldGen.oceanBG;
      this._variations[11] = WorldGen.mushroomBG;
      this._variations[12] = WorldGen.underworldBG;
    }

    public class AreaId
    {
      public static SetFactory Factory = new SetFactory(13);
      public const int Forest1 = 0;
      public const int Forest2 = 1;
      public const int Forest3 = 2;
      public const int Forest4 = 3;
      public const int Corruption = 4;
      public const int Jungle = 5;
      public const int Snow = 6;
      public const int Hallow = 7;
      public const int Crimson = 8;
      public const int Desert = 9;
      public const int Ocean = 10;
      public const int GlowingMushroom = 11;
      public const int Underworld = 12;
      public const int Count = 13;
    }
  }
}
