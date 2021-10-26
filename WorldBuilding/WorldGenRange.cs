// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.WorldGenRange
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Terraria.Utilities;

namespace Terraria.WorldBuilding
{
  public class WorldGenRange
  {
    public static readonly WorldGenRange Empty = new WorldGenRange(0, 0);
    [JsonProperty("Min")]
    public readonly int Minimum;
    [JsonProperty("Max")]
    public readonly int Maximum;
    [JsonProperty]
    [JsonConverter(typeof (StringEnumConverter))]
    public readonly WorldGenRange.ScalingMode ScaleWith;

    public int ScaledMinimum => this.ScaleValue(this.Minimum);

    public int ScaledMaximum => this.ScaleValue(this.Maximum);

    public WorldGenRange(int minimum, int maximum)
    {
      this.Minimum = minimum;
      this.Maximum = maximum;
    }

    public int GetRandom(UnifiedRandom random) => random.Next(this.ScaledMinimum, this.ScaledMaximum + 1);

    private int ScaleValue(int value)
    {
      float num = 1f;
      switch (this.ScaleWith)
      {
        case WorldGenRange.ScalingMode.None:
          num = 1f;
          break;
        case WorldGenRange.ScalingMode.WorldArea:
          num = (float) (Main.maxTilesX * Main.maxTilesY) / 5040000f;
          break;
        case WorldGenRange.ScalingMode.WorldWidth:
          num = (float) Main.maxTilesX / 4200f;
          break;
      }
      return (int) ((double) num * (double) value);
    }

    public enum ScalingMode
    {
      None,
      WorldArea,
      WorldWidth,
    }
  }
}
