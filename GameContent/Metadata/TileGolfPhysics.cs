// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Metadata.TileGolfPhysics
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Newtonsoft.Json;

namespace Terraria.GameContent.Metadata
{
  public class TileGolfPhysics
  {
    [JsonProperty]
    public float DirectImpactDampening { get; private set; }

    [JsonProperty]
    public float SideImpactDampening { get; private set; }

    [JsonProperty]
    public float ClubImpactDampening { get; private set; }

    [JsonProperty]
    public float PassThroughDampening { get; private set; }

    [JsonProperty]
    public float ImpactDampeningResistanceEfficiency { get; private set; }
  }
}
