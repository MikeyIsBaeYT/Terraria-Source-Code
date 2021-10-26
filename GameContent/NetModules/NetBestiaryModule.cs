// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetBestiaryModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.IO;
using Terraria.ID;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
  public class NetBestiaryModule : NetModule
  {
    public static NetPacket SerializeKillCount(int npcNetId, int killcount)
    {
      NetPacket packet = NetModule.CreatePacket<NetBestiaryModule>(5);
      packet.Writer.Write((byte) 0);
      packet.Writer.Write((short) npcNetId);
      packet.Writer.Write((ushort) killcount);
      return packet;
    }

    public static NetPacket SerializeSight(int npcNetId)
    {
      NetPacket packet = NetModule.CreatePacket<NetBestiaryModule>(3);
      packet.Writer.Write((byte) 1);
      packet.Writer.Write((short) npcNetId);
      return packet;
    }

    public static NetPacket SerializeChat(int npcNetId)
    {
      NetPacket packet = NetModule.CreatePacket<NetBestiaryModule>(3);
      packet.Writer.Write((byte) 2);
      packet.Writer.Write((short) npcNetId);
      return packet;
    }

    public override bool Deserialize(BinaryReader reader, int userId)
    {
      switch (reader.ReadByte())
      {
        case 0:
          short num1 = reader.ReadInt16();
          string bestiaryCreditId1 = ContentSamples.NpcsByNetId[(int) num1].GetBestiaryCreditId();
          ushort num2 = reader.ReadUInt16();
          Main.BestiaryTracker.Kills.SetKillCountDirectly(bestiaryCreditId1, (int) num2);
          break;
        case 1:
          short num3 = reader.ReadInt16();
          string bestiaryCreditId2 = ContentSamples.NpcsByNetId[(int) num3].GetBestiaryCreditId();
          Main.BestiaryTracker.Sights.SetWasSeenDirectly(bestiaryCreditId2);
          break;
        case 2:
          short num4 = reader.ReadInt16();
          string bestiaryCreditId3 = ContentSamples.NpcsByNetId[(int) num4].GetBestiaryCreditId();
          Main.BestiaryTracker.Chats.SetWasChatWithDirectly(bestiaryCreditId3);
          break;
      }
      return true;
    }

    private enum BestiaryUnlockType : byte
    {
      Kill,
      Sight,
      Chat,
    }
  }
}
