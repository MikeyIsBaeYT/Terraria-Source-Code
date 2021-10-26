// Decompiled with JetBrains decompiler
// Type: Terraria.Initializers.NetworkInitializer
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Terraria.GameContent.NetModules;
using Terraria.Net;

namespace Terraria.Initializers
{
  public static class NetworkInitializer
  {
    public static void Load()
    {
      NetManager.Instance.Register<NetLiquidModule>();
      NetManager.Instance.Register<NetTextModule>();
      NetManager.Instance.Register<NetPingModule>();
      NetManager.Instance.Register<NetAmbienceModule>();
      NetManager.Instance.Register<NetBestiaryModule>();
      NetManager.Instance.Register<NetCreativeUnlocksModule>();
      NetManager.Instance.Register<NetCreativePowersModule>();
      NetManager.Instance.Register<NetCreativeUnlocksPlayerReportModule>();
      NetManager.Instance.Register<NetTeleportPylonModule>();
      NetManager.Instance.Register<NetParticlesModule>();
      NetManager.Instance.Register<NetCreativePowerPermissionsModule>();
    }
  }
}
