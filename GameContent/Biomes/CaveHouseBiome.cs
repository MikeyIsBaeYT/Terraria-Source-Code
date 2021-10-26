// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.CaveHouseBiome
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Terraria.GameContent.Biomes.CaveHouse;
using Terraria.ID;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Biomes
{
  public class CaveHouseBiome : MicroBiome
  {
    private readonly HouseBuilderContext _builderContext = new HouseBuilderContext();

    [JsonProperty]
    public float IceChestChance { get; set; }

    [JsonProperty]
    public float JungleChestChance { get; set; }

    [JsonProperty]
    public float GoldChestChance { get; set; }

    [JsonProperty]
    public float GraniteChestChance { get; set; }

    [JsonProperty]
    public float MarbleChestChance { get; set; }

    [JsonProperty]
    public float MushroomChestChance { get; set; }

    [JsonProperty]
    public float DesertChestChance { get; set; }

    public override bool Place(Point origin, StructureMap structures)
    {
      if (!WorldGen.InWorld(origin.X, origin.Y, 10))
        return false;
      int num = 25;
      for (int index1 = origin.X - num; index1 <= origin.X + num; ++index1)
      {
        for (int index2 = origin.Y - num; index2 <= origin.Y + num; ++index2)
        {
          if (Main.tile[index1, index2].wire() || TileID.Sets.BasicChest[(int) Main.tile[index1, index2].type])
            return false;
        }
      }
      HouseBuilder builder = HouseUtils.CreateBuilder(origin, structures);
      if (!builder.IsValid)
        return false;
      this.ApplyConfigurationToBuilder(builder);
      builder.Place(this._builderContext, structures);
      return true;
    }

    private void ApplyConfigurationToBuilder(HouseBuilder builder)
    {
      switch (builder.Type)
      {
        case HouseType.Wood:
          builder.ChestChance = this.GoldChestChance;
          break;
        case HouseType.Ice:
          builder.ChestChance = this.IceChestChance;
          break;
        case HouseType.Desert:
          builder.ChestChance = this.DesertChestChance;
          break;
        case HouseType.Jungle:
          builder.ChestChance = this.JungleChestChance;
          break;
        case HouseType.Mushroom:
          builder.ChestChance = this.MushroomChestChance;
          break;
        case HouseType.Granite:
          builder.ChestChance = this.GraniteChestChance;
          break;
        case HouseType.Marble:
          builder.ChestChance = this.MarbleChestChance;
          break;
      }
    }
  }
}
