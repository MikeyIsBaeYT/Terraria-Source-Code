// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Generation.PassLegacy
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using System.Globalization;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
  public class PassLegacy : GenPass
  {
    private static Dictionary<string, float> _weightMap = PassLegacy.GenerateWeightMap();
    private WorldGenLegacyMethod _method;

    private static Dictionary<string, float> GenerateWeightMap()
    {
      Dictionary<string, float> dictionary = new Dictionary<string, float>();
      char[] chArray1 = new char[1]{ ',' };
      foreach (string str in "Reset:1.794,Terrain:233.6416,Tunnels:4.6075,Sand:256.211,Mount Caves:28.2501,Dirt Wall Backgrounds:91.1031,Rocks In Dirt:568.933,Dirt In Rocks:612.0777,Clay:99.0829,Small Holes:1080.6658,Dirt Layer Caves:97.6719,Rock Layer Caves:978.5062,Surface Caves:13.8707,Slush Check:40.0098,Grass:14.2435,Jungle:2404.0004,Marble:644.4756,Granite:7445.4057,Mud Caves To Grass:13289.4058,Full Desert:1977.3443,Floating Islands:430.9967,Mushroom Patches:305.0517,Mud To Dirt:135.7024,Silt:76.367,Shinies:106.5187,Webs:22.2261,Underworld:5202.7952,Lakes:12.458,Dungeon:273.1042,Corruption:100.9735,Slush:24.1356,Mud Caves To Grass:8.4174,Beaches:4.4018,Gems:289.1701,Gravitating Sand:207.9566,Clean Up Dirt:459.6188,Pyramids:0.4286,Dirt Rock Wall Runner:18.2315,Living Trees:11.9772,Wood Tree Walls:61.6,Altars:18.7726,Wet Jungle:10.5711,Remove Water From Sand:11.0268,Jungle Temple:140.1556,Hives:2144.6166,Jungle Chests:1.3979,Smooth World:2242.1054,Settle Liquids:4844.7201,Waterfalls:1868.306,Ice:80.3287,Wall Variety:2390.3296,Traps:42.6118,Life Crystals:2.0239,Statues:15.5157,Buried Chests:591.4215,Surface Chests:9.5181,Jungle Chests Placement:1.8203,Water Chests:5.5477,Spider Caves:4979.7116,Gem Caves:41.1786,Moss:2116.5164,Temple:6.6512,Ice Walls:7890.5261,Jungle Trees:230.5412,Floating Island Houses:2.299,Quick Cleanup:417.1482,Pots:515.7405,Hellforge:5.3522,Spreading Grass:47.0313,Piles:160.8168,Moss:11.8533,Spawn Point:0.2951,Grass Wall:293.7116,Guide:4.4433,Sunflowers:4.6765,Planting Trees:203.2509,Herbs:86.5444,Dye Plants:178.949,Webs And Honey:336.4474,Weeds:137.5676,Mud Caves To Grass:179.8629,Jungle Plants:606.4348,Vines:264.2856,Flowers:0.8461,Mushrooms:0.4203,Stalac:347.0403,Gems In Ice Biome:5.491,Random Gems:9.3797,Moss Grass:267.3524,Muds Walls In Jungle:34.8689,Larva:0.6675,Tile Cleanup:675.7305,Lihzahrd Altars:0.2615,Micro Biomes:2734.7864,Final Cleanup:648.6878".Split(chArray1))
      {
        char[] chArray2 = new char[1]{ ':' };
        string[] strArray = str.Split(chArray2);
        dictionary[strArray[0]] = float.Parse(strArray[1], NumberStyles.AllowDecimalPoint, (IFormatProvider) CultureInfo.InvariantCulture);
      }
      return dictionary;
    }

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

    public override void Apply(GenerationProgress progress) => this._method(progress);
  }
}
