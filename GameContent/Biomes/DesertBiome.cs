// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.DesertBiome
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Terraria.GameContent.Biomes.Desert;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Biomes
{
  public class DesertBiome : MicroBiome
  {
    [JsonProperty("ChanceOfEntrance")]
    public float ChanceOfEntrance = 0.3333f;

    public override bool Place(Point origin, StructureMap structures)
    {
      DesertDescription fromPlacement = DesertDescription.CreateFromPlacement(origin);
      if (!fromPlacement.IsValid)
        return false;
      DesertBiome.ExportDescriptionToEngine(fromPlacement);
      SandMound.Place(fromPlacement);
      fromPlacement.UpdateSurfaceMap();
      if ((double) GenBase._random.NextFloat() <= (double) this.ChanceOfEntrance)
      {
        switch (GenBase._random.Next(4))
        {
          case 0:
            ChambersEntrance.Place(fromPlacement);
            break;
          case 1:
            AnthillEntrance.Place(fromPlacement);
            break;
          case 2:
            LarvaHoleEntrance.Place(fromPlacement);
            break;
          case 3:
            PitEntrance.Place(fromPlacement);
            break;
        }
      }
      DesertHive.Place(fromPlacement);
      DesertBiome.CleanupArea(fromPlacement.Hive);
      Microsoft.Xna.Framework.Rectangle area = new Microsoft.Xna.Framework.Rectangle(fromPlacement.CombinedArea.X, 50, fromPlacement.CombinedArea.Width, fromPlacement.CombinedArea.Bottom - 20);
      structures.AddStructure(area, 10);
      return true;
    }

    private static void ExportDescriptionToEngine(DesertDescription description)
    {
      WorldGen.UndergroundDesertLocation = description.CombinedArea;
      WorldGen.UndergroundDesertLocation.Inflate(10, 10);
      WorldGen.UndergroundDesertHiveLocation = description.Hive;
    }

    private static void CleanupArea(Microsoft.Xna.Framework.Rectangle area)
    {
      for (int index1 = area.Left - 20; index1 < area.Right + 20; ++index1)
      {
        for (int index2 = area.Top - 20; index2 < area.Bottom + 20; ++index2)
        {
          if (index1 > 0 && index1 < Main.maxTilesX - 1 && index2 > 0 && index2 < Main.maxTilesY - 1)
          {
            WorldGen.SquareWallFrame(index1, index2);
            WorldUtils.TileFrame(index1, index2, true);
          }
        }
      }
    }
  }
}
