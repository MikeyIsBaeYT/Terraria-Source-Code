// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetCreativeUnlocksPlayerReportModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.IO;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
  public class NetCreativeUnlocksPlayerReportModule : NetModule
  {
    private const byte _requestItemSacrificeId = 0;

    public static NetPacket SerializeSacrificeRequest(int itemId, int amount)
    {
      NetPacket packet = NetModule.CreatePacket<NetCreativeUnlocksPlayerReportModule>(5);
      packet.Writer.Write((byte) 0);
      packet.Writer.Write((ushort) itemId);
      packet.Writer.Write((ushort) amount);
      return packet;
    }

    public override bool Deserialize(BinaryReader reader, int userId)
    {
      if (reader.ReadByte() == (byte) 0)
      {
        int num1 = (int) reader.ReadUInt16();
        int num2 = (int) reader.ReadUInt16();
      }
      return true;
    }
  }
}
