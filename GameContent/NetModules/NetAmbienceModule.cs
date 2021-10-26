// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetAmbienceModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.IO;
using Terraria.GameContent.Ambience;
using Terraria.GameContent.Skies;
using Terraria.Graphics.Effects;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
  public class NetAmbienceModule : NetModule
  {
    public static NetPacket SerializeSkyEntitySpawn(Player player, SkyEntityType type)
    {
      int num = Main.rand.Next();
      NetPacket packet = NetModule.CreatePacket<NetAmbienceModule>(6);
      packet.Writer.Write((byte) player.whoAmI);
      packet.Writer.Write(num);
      packet.Writer.Write((byte) type);
      return packet;
    }

    public override bool Deserialize(BinaryReader reader, int userId)
    {
      byte playerId = reader.ReadByte();
      int seed = reader.ReadInt32();
      SkyEntityType type = (SkyEntityType) reader.ReadByte();
      Main.QueueMainThreadAction((Action) (() => ((AmbientSky) SkyManager.Instance["Ambience"]).Spawn(Main.player[(int) playerId], type, seed)));
      return true;
    }
  }
}
