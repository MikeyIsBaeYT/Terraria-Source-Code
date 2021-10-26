// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetPingModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.IO;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
  public class NetPingModule : NetModule
  {
    public static NetPacket Serialize(Vector2 position)
    {
      NetPacket packet = NetModule.CreatePacket<NetPingModule>(8);
      packet.Writer.WriteVector2(position);
      return packet;
    }

    public override bool Deserialize(BinaryReader reader, int userId)
    {
      Vector2 position = reader.ReadVector2();
      Main.Pings.Add(position);
      return true;
    }
  }
}
