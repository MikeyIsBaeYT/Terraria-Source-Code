// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetParticlesModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.IO;
using Terraria.GameContent.Drawing;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
  public class NetParticlesModule : NetModule
  {
    public static NetPacket Serialize(
      ParticleOrchestraType particleType,
      ParticleOrchestraSettings settings)
    {
      NetPacket packet = NetModule.CreatePacket<NetParticlesModule>(22);
      packet.Writer.Write((byte) particleType);
      settings.Serialize(packet.Writer);
      return packet;
    }

    public override bool Deserialize(BinaryReader reader, int userId)
    {
      ParticleOrchestraType particleOrchestraType = (ParticleOrchestraType) reader.ReadByte();
      ParticleOrchestraSettings settings = new ParticleOrchestraSettings();
      settings.DeserializeFrom(reader);
      if (Main.netMode == 2)
        NetManager.Instance.Broadcast(NetParticlesModule.Serialize(particleOrchestraType, settings), userId);
      else
        ParticleOrchestrator.SpawnParticlesDirect(particleOrchestraType, settings);
      return true;
    }
  }
}
