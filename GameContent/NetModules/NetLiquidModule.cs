// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetLiquidModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
  public class NetLiquidModule : NetModule
  {
    private static List<int> _changesForPlayerCache = new List<int>();
    private static Dictionary<Point, NetLiquidModule.ChunkChanges> _changesByChunkCoords = new Dictionary<Point, NetLiquidModule.ChunkChanges>();

    public static NetPacket Serialize(HashSet<int> changes)
    {
      NetPacket packet = NetModule.CreatePacket<NetLiquidModule>(changes.Count * 6 + 2);
      packet.Writer.Write((ushort) changes.Count);
      foreach (int change in changes)
      {
        int index1 = change >> 16 & (int) ushort.MaxValue;
        int index2 = change & (int) ushort.MaxValue;
        packet.Writer.Write(change);
        packet.Writer.Write(Main.tile[index1, index2].liquid);
        packet.Writer.Write(Main.tile[index1, index2].liquidType());
      }
      return packet;
    }

    public static NetPacket SerializeForPlayer(int playerIndex)
    {
      NetLiquidModule._changesForPlayerCache.Clear();
      foreach (KeyValuePair<Point, NetLiquidModule.ChunkChanges> changesByChunkCoord in NetLiquidModule._changesByChunkCoords)
      {
        if (changesByChunkCoord.Value.BroadcastingCondition(playerIndex))
          NetLiquidModule._changesForPlayerCache.AddRange((IEnumerable<int>) changesByChunkCoord.Value.DirtiedPackedTileCoords);
      }
      NetPacket packet = NetModule.CreatePacket<NetLiquidModule>(NetLiquidModule._changesForPlayerCache.Count * 6 + 2);
      packet.Writer.Write((ushort) NetLiquidModule._changesForPlayerCache.Count);
      foreach (int num in NetLiquidModule._changesForPlayerCache)
      {
        int index1 = num >> 16 & (int) ushort.MaxValue;
        int index2 = num & (int) ushort.MaxValue;
        packet.Writer.Write(num);
        packet.Writer.Write(Main.tile[index1, index2].liquid);
        packet.Writer.Write(Main.tile[index1, index2].liquidType());
      }
      return packet;
    }

    public override bool Deserialize(BinaryReader reader, int userId)
    {
      int num1 = (int) reader.ReadUInt16();
      for (int index1 = 0; index1 < num1; ++index1)
      {
        int num2 = reader.ReadInt32();
        byte num3 = reader.ReadByte();
        byte num4 = reader.ReadByte();
        int index2 = num2 >> 16 & (int) ushort.MaxValue;
        int index3 = num2 & (int) ushort.MaxValue;
        Tile tile = Main.tile[index2, index3];
        if (tile != null)
        {
          tile.liquid = num3;
          tile.liquidType((int) num4);
        }
      }
      return true;
    }

    public static void CreateAndBroadcastByChunk(HashSet<int> dirtiedPackedTileCoords)
    {
      NetLiquidModule.PrepareChunks(dirtiedPackedTileCoords);
      NetLiquidModule.PrepareAndSendToEachPlayerSeparately();
    }

    private static void PrepareAndSendToEachPlayerSeparately()
    {
      for (int index = 0; index < 256; ++index)
      {
        if (Netplay.Clients[index].IsConnected())
          NetManager.Instance.SendToClient(NetLiquidModule.SerializeForPlayer(index), index);
      }
    }

    private static void BroadcastEachChunkSeparately()
    {
      foreach (KeyValuePair<Point, NetLiquidModule.ChunkChanges> changesByChunkCoord in NetLiquidModule._changesByChunkCoords)
        NetManager.Instance.Broadcast(NetLiquidModule.Serialize(changesByChunkCoord.Value.DirtiedPackedTileCoords), new NetManager.BroadcastCondition(changesByChunkCoord.Value.BroadcastingCondition));
    }

    private static void PrepareChunks(HashSet<int> dirtiedPackedTileCoords)
    {
      foreach (KeyValuePair<Point, NetLiquidModule.ChunkChanges> changesByChunkCoord in NetLiquidModule._changesByChunkCoords)
        changesByChunkCoord.Value.DirtiedPackedTileCoords.Clear();
      NetLiquidModule.DistributeChangesIntoChunks(dirtiedPackedTileCoords);
    }

    private static void BroadcastAllChanges(HashSet<int> dirtiedPackedTileCoords) => NetManager.Instance.Broadcast(NetLiquidModule.Serialize(dirtiedPackedTileCoords));

    private static void DistributeChangesIntoChunks(HashSet<int> dirtiedPackedTileCoords)
    {
      foreach (int dirtiedPackedTileCoord in dirtiedPackedTileCoords)
      {
        int x = dirtiedPackedTileCoord >> 16 & (int) ushort.MaxValue;
        int y = dirtiedPackedTileCoord & (int) ushort.MaxValue;
        Point key;
        key.X = Netplay.GetSectionX(x);
        key.Y = Netplay.GetSectionY(y);
        NetLiquidModule.ChunkChanges chunkChanges;
        if (!NetLiquidModule._changesByChunkCoords.TryGetValue(key, out chunkChanges))
        {
          chunkChanges = new NetLiquidModule.ChunkChanges(key.X, key.Y);
          NetLiquidModule._changesByChunkCoords[key] = chunkChanges;
        }
        chunkChanges.DirtiedPackedTileCoords.Add(dirtiedPackedTileCoord);
      }
    }

    private class ChunkChanges
    {
      public HashSet<int> DirtiedPackedTileCoords;
      public int ChunkX;
      public int ChunkY;

      public ChunkChanges(int x, int y)
      {
        this.ChunkX = x;
        this.ChunkY = y;
        this.DirtiedPackedTileCoords = new HashSet<int>();
      }

      public bool BroadcastingCondition(int clientIndex) => Netplay.Clients[clientIndex].TileSections[this.ChunkX, this.ChunkY];
    }
  }
}
