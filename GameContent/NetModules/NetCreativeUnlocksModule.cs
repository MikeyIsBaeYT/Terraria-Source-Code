// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetCreativeUnlocksModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.IO;
using Terraria.ID;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
  public class NetCreativeUnlocksModule : NetModule
  {
    public static NetPacket SerializeItemSacrifice(int itemId, int sacrificeCount)
    {
      NetPacket packet = NetModule.CreatePacket<NetCreativeUnlocksModule>(3);
      packet.Writer.Write((short) itemId);
      packet.Writer.Write((ushort) sacrificeCount);
      return packet;
    }

    public override bool Deserialize(BinaryReader reader, int userId)
    {
      short num = reader.ReadInt16();
      Main.LocalPlayerCreativeTracker.ItemSacrifices.SetSacrificeCountDirectly(ContentSamples.ItemPersistentIdsByNetIds[(int) num], (int) reader.ReadUInt16());
      return true;
    }
  }
}
