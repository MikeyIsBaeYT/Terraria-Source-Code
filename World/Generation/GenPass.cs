// Decompiled with JetBrains decompiler
// Type: Terraria.World.Generation.GenPass
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.World.Generation
{
  public abstract class GenPass : GenBase
  {
    public string Name;
    public float Weight;

    public GenPass(string name, float loadWeight)
    {
      this.Name = name;
      this.Weight = loadWeight;
    }

    public abstract void Apply(GenerationProgress progress);
  }
}
