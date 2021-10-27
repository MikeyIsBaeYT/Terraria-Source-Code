// Decompiled with JetBrains decompiler
// Type: Terraria.World.Generation.Biomes`1
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.World.Generation
{
  public static class Biomes<T> where T : MicroBiome, new()
  {
    private static T _microBiome = Biomes<T>.CreateInstance();

    public static bool Place(int x, int y, StructureMap structures) => Biomes<T>._microBiome.Place(new Point(x, y), structures);

    public static bool Place(Point origin, StructureMap structures) => Biomes<T>._microBiome.Place(origin, structures);

    public static T Get() => Biomes<T>._microBiome;

    private static T CreateInstance()
    {
      T obj = new T();
      BiomeCollection.Biomes.Add((MicroBiome) obj);
      return obj;
    }
  }
}
