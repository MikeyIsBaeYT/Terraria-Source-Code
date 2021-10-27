// Decompiled with JetBrains decompiler
// Type: Terraria.World.Generation.MicroBiome
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.World.Generation
{
  public abstract class MicroBiome : GenStructure
  {
    public virtual void Reset()
    {
    }

    public static void ResetAll()
    {
      foreach (MicroBiome biome in BiomeCollection.Biomes)
        biome.Reset();
    }
  }
}
