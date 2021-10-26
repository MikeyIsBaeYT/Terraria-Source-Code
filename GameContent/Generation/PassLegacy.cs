// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Generation.PassLegacy
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Generation
{
  public class PassLegacy : GenPass
  {
    private static readonly Dictionary<string, float> _weightMap_135 = new Dictionary<string, float>()
    {
      {
        "Reset",
        2.2056f
      },
      {
        "Terrain",
        449.3722f
      },
      {
        "Tunnels",
        5.379f
      },
      {
        "Dunes",
        779.3144f
      },
      {
        "Mount Caves",
        36.1749f
      },
      {
        "Dirt Wall Backgrounds",
        238.8786f
      },
      {
        "Rocks In Dirt",
        1539.898f
      },
      {
        "Dirt In Rocks",
        1640.048f
      },
      {
        "Clay",
        302.2475f
      },
      {
        "Small Holes",
        3047.099f
      },
      {
        "Dirt Layer Caves",
        250.0248f
      },
      {
        "Rock Layer Caves",
        2635.903f
      },
      {
        "Surface Caves",
        41.3442f
      },
      {
        "Slush Check",
        62.3121f
      },
      {
        "Grass",
        27.8485f
      },
      {
        "Jungle",
        10154.65f
      },
      {
        "Marble",
        3140.926f
      },
      {
        "Granite",
        6769.554f
      },
      {
        "Mud Caves To Grass",
        29042.46f
      },
      {
        "Full Desert",
        7802.509f
      },
      {
        "Floating Islands",
        1504.831f
      },
      {
        "Mushroom Patches",
        1001.21f
      },
      {
        "Mud To Dirt",
        355.9895f
      },
      {
        "Silt",
        198.4567f
      },
      {
        "Shinies",
        253.9256f
      },
      {
        "Webs",
        53.7234f
      },
      {
        "Underworld",
        9213.443f
      },
      {
        "Lakes",
        14.6001f
      },
      {
        "Corruption",
        1367.068f
      },
      {
        "Dungeon",
        386.8962f
      },
      {
        "Slush",
        56.7959f
      },
      {
        "Mountain Caves",
        14.2958f
      },
      {
        "Beaches",
        7.6043f
      },
      {
        "Gems",
        1016.745f
      },
      {
        "Gravitating Sand",
        875.1385f
      },
      {
        "Clean Up Dirt",
        632.9365f
      },
      {
        "Pyramids",
        0.3045f
      },
      {
        "Dirt Rock Wall Runner",
        24.1628f
      },
      {
        "Living Trees",
        5.6897f
      },
      {
        "Wood Tree Walls",
        72.6673f
      },
      {
        "Altars",
        24.975f
      },
      {
        "Wet Jungle",
        18.2339f
      },
      {
        "Remove Water From Sand",
        14.3244f
      },
      {
        "Jungle Temple",
        838.0293f
      },
      {
        "Hives",
        7194.68f
      },
      {
        "Jungle Chests",
        2.3522f
      },
      {
        "Smooth World",
        6418.349f
      },
      {
        "Settle Liquids",
        13069.07f
      },
      {
        "Waterfalls",
        4614.806f
      },
      {
        "Ice",
        236.3986f
      },
      {
        "Wall Variety",
        5988.028f
      },
      {
        "Traps",
        113.9219f
      },
      {
        "Life Crystals",
        3.4912f
      },
      {
        "Statues",
        72.0258f
      },
      {
        "Buried Chests",
        2371.881f
      },
      {
        "Surface Chests",
        22.1015f
      },
      {
        "Jungle Chests Placement",
        11.6857f
      },
      {
        "Water Chests",
        18.6092f
      },
      {
        "Spider Caves",
        8218.94f
      },
      {
        "Gem Caves",
        96.4863f
      },
      {
        "Moss",
        4440.283f
      },
      {
        "Temple",
        12.6321f
      },
      {
        "Ice Walls",
        8744.889f
      },
      {
        "Jungle Trees",
        933.2522f
      },
      {
        "Floating Island Houses",
        2.8349f
      },
      {
        "Quick Cleanup",
        1339.91f
      },
      {
        "Pots",
        1363.35f
      },
      {
        "Spreading Grass",
        80.3414f
      },
      {
        "Piles",
        274.4605f
      },
      {
        "Cactus",
        30.4524f
      },
      {
        "Spawn Point",
        0.3068f
      },
      {
        "Grass Wall",
        512.8323f
      },
      {
        "Guide",
        3.1494f
      },
      {
        "Sunflowers",
        4.7643f
      },
      {
        "Planting Trees",
        356.2866f
      },
      {
        "Herbs",
        123.8192f
      },
      {
        "Dye Plants",
        437.3852f
      },
      {
        "Webs And Honey",
        770.3133f
      },
      {
        "Weeds",
        224.6974f
      },
      {
        "Mud Caves To Grass 2",
        737.635f
      },
      {
        "Jungle Plants",
        1037.098f
      },
      {
        "Vines",
        897.331f
      },
      {
        "Flowers",
        1.3216f
      },
      {
        "Mushrooms",
        0.7789f
      },
      {
        "Stalac",
        1079.509f
      },
      {
        "Gems In Ice Biome",
        14.8002f
      },
      {
        "Random Gems",
        15.3893f
      },
      {
        "Moss Grass",
        770.8217f
      },
      {
        "Muds Walls In Jungle",
        73.5705f
      },
      {
        "Larva",
        0.5222f
      },
      {
        "Settle Liquids Again",
        7461.561f
      },
      {
        "Tile Cleanup",
        1813.04f
      },
      {
        "Lihzahrd Altars",
        0.2171f
      },
      {
        "Micro Biomes",
        24240.07f
      },
      {
        "Final Cleanup",
        1768.462f
      }
    };
    private static readonly Dictionary<string, float> _weightMap = new Dictionary<string, float>()
    {
      {
        "Reset",
        0.9667f
      },
      {
        "Terrain",
        507.352f
      },
      {
        "Dunes",
        239.7913f
      },
      {
        "Ocean Sand",
        10.4129f
      },
      {
        "Sand Patches",
        452.6755f
      },
      {
        "Tunnels",
        4.3622f
      },
      {
        "Mount Caves",
        49.9993f
      },
      {
        "Dirt Wall Backgrounds",
        328.7817f
      },
      {
        "Rocks In Dirt",
        1537.466f
      },
      {
        "Dirt In Rocks",
        1515.23f
      },
      {
        "Clay",
        314.8327f
      },
      {
        "Small Holes",
        2955.926f
      },
      {
        "Dirt Layer Caves",
        238.2545f
      },
      {
        "Rock Layer Caves",
        2708.396f
      },
      {
        "Surface Caves",
        42.3857f
      },
      {
        "Generate Ice Biome",
        100.005f
      },
      {
        "Grass",
        29.7885f
      },
      {
        "Jungle",
        11205.83f
      },
      {
        "Marble",
        5358.884f
      },
      {
        "Granite",
        2142.664f
      },
      {
        "Mud Caves To Grass",
        3319.761f
      },
      {
        "Full Desert",
        9730.408f
      },
      {
        "Floating Islands",
        1364.346f
      },
      {
        "Mushroom Patches",
        743.7686f
      },
      {
        "Dirt To Mud",
        351.3519f
      },
      {
        "Silt",
        211.84f
      },
      {
        "Shinies",
        237.4298f
      },
      {
        "Webs",
        50.6646f
      },
      {
        "Underworld",
        8936.494f
      },
      {
        "Lakes",
        12.1766f
      },
      {
        "Corruption",
        1094.237f
      },
      {
        "Dungeon",
        477.1963f
      },
      {
        "Slush",
        55.1857f
      },
      {
        "Mountain Caves",
        11.4819f
      },
      {
        "Beaches",
        7.8287f
      },
      {
        "Gems",
        895.426f
      },
      {
        "Gravitating Sand",
        933.5295f
      },
      {
        "Clean Up Dirt",
        697.0276f
      },
      {
        "Pyramids",
        6.6884f
      },
      {
        "Dirt Rock Wall Runner",
        24.7648f
      },
      {
        "Living Trees",
        4.937f
      },
      {
        "Wood Tree Walls",
        76.8709f
      },
      {
        "Altars",
        72.6607f
      },
      {
        "Wet Jungle",
        23.492f
      },
      {
        "Remove Water From Sand",
        22.0898f
      },
      {
        "Jungle Temple",
        595.8422f
      },
      {
        "Hives",
        371.392f
      },
      {
        "Jungle Chests",
        0.5896f
      },
      {
        "Smooth World",
        5841.608f
      },
      {
        "Settle Liquids",
        9398.525f
      },
      {
        "Waterfalls",
        4118.666f
      },
      {
        "Ice",
        163.0777f
      },
      {
        "Wall Variety",
        5264.021f
      },
      {
        "Life Crystals",
        2.7582f
      },
      {
        "Statues",
        64.5737f
      },
      {
        "Buried Chests",
        1102.553f
      },
      {
        "Surface Chests",
        12.8337f
      },
      {
        "Jungle Chests Placement",
        1.3546f
      },
      {
        "Water Chests",
        12.5981f
      },
      {
        "Spider Caves",
        475.4143f
      },
      {
        "Gem Caves",
        36.0143f
      },
      {
        "Moss",
        655.8314f
      },
      {
        "Temple",
        5.6917f
      },
      {
        "Ice Walls",
        957.0317f
      },
      {
        "Jungle Trees",
        817.2459f
      },
      {
        "Floating Island Houses",
        1.5022f
      },
      {
        "Quick Cleanup",
        1374.467f
      },
      {
        "Pots",
        1638.609f
      },
      {
        "Hellforge",
        2.8645f
      },
      {
        "Spreading Grass",
        127.7581f
      },
      {
        "Place Fallen Log",
        17.3377f
      },
      {
        "Traps",
        562.9085f
      },
      {
        "Piles",
        288.3675f
      },
      {
        "Spawn Point",
        0.012f
      },
      {
        "Grass Wall",
        604.9992f
      },
      {
        "Guide",
        0.016f
      },
      {
        "Sunflowers",
        4.1757f
      },
      {
        "Planting Trees",
        325.0993f
      },
      {
        "Cactus & Coral",
        31.6349f
      },
      {
        "Herbs",
        120.1871f
      },
      {
        "Dye Plants",
        226.6394f
      },
      {
        "Webs And Honey",
        608.9524f
      },
      {
        "Weeds",
        187.9759f
      },
      {
        "Mud Caves To Grass 2",
        686.4958f
      },
      {
        "Jungle Plants",
        1295.038f
      },
      {
        "Vines",
        1132.555f
      },
      {
        "Flowers",
        16.7723f
      },
      {
        "Mushrooms",
        0.2294f
      },
      {
        "Gems In Ice Biome",
        10.3092f
      },
      {
        "Random Gems",
        18.4925f
      },
      {
        "Moss Grass",
        687.742f
      },
      {
        "Muds Walls In Jungle",
        89.7739f
      },
      {
        "Larva",
        0.2074f
      },
      {
        "Settle Liquids Again",
        7073.647f
      },
      {
        "Tile Cleanup",
        1896.76f
      },
      {
        "Lihzahrd Altars",
        0.0071f
      },
      {
        "Micro Biomes",
        3547.43f
      },
      {
        "Stalac",
        1180.906f
      },
      {
        "Remove Broken Traps",
        1293.425f
      },
      {
        "Final Cleanup",
        2080.294f
      }
    };
    private readonly WorldGenLegacyMethod _method;

    public PassLegacy(string name, WorldGenLegacyMethod method)
      : base(name, PassLegacy.GetWeight(name))
    {
      this._method = method;
    }

    public PassLegacy(string name, WorldGenLegacyMethod method, float weight)
      : base(name, weight)
    {
      this._method = method;
    }

    private static float GetWeight(string name)
    {
      float num;
      if (!PassLegacy._weightMap.TryGetValue(name, out num))
        num = 1f;
      return num;
    }

    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration) => this._method(progress, configuration);
  }
}
