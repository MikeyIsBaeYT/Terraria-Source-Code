// Decompiled with JetBrains decompiler
// Type: Terraria.Steam
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Runtime.InteropServices;

namespace Terraria
{
  public class Steam
  {
    public static bool SteamInit;

    [DllImport("steam_api.dll")]
    private static extern bool SteamAPI_Init();

    [DllImport("steam_api.dll")]
    private static extern bool SteamAPI_Shutdown();

    public static void Init() => Steam.SteamInit = Steam.SteamAPI_Init();

    public static void Kill() => Steam.SteamAPI_Shutdown();
  }
}
