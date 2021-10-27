// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetLiquidModule
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;
using System.IO;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
  public class NetLiquidModule : NetModule
  {
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
  }
}
