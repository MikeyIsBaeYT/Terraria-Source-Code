// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.Passes
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Terraria.IO;

namespace Terraria.WorldBuilding
{
  public static class Passes
  {
    public class Clear : GenPass
    {
      public Clear()
        : base("clear", 1f)
      {
      }

      protected override void ApplyPass(
        GenerationProgress progress,
        GameConfiguration configuration)
      {
        for (int index1 = 0; index1 < GenBase._worldWidth; ++index1)
        {
          for (int index2 = 0; index2 < GenBase._worldHeight; ++index2)
          {
            if (GenBase._tiles[index1, index2] == null)
              GenBase._tiles[index1, index2] = new Tile();
            else
              GenBase._tiles[index1, index2].ClearEverything();
          }
        }
      }
    }

    public class ScatterCustom : GenPass
    {
      private GenBase.CustomPerUnitAction _perUnit;
      private int _count;

      public ScatterCustom(
        string name,
        float loadWeight,
        int count,
        GenBase.CustomPerUnitAction perUnit = null)
        : base(name, loadWeight)
      {
        this._perUnit = perUnit;
        this._count = count;
      }

      public void SetCustomAction(GenBase.CustomPerUnitAction perUnit) => this._perUnit = perUnit;

      protected override void ApplyPass(
        GenerationProgress progress,
        GameConfiguration configuration)
      {
        int count = this._count;
        while (count > 0)
        {
          if (this._perUnit(GenBase._random.Next(1, GenBase._worldWidth), GenBase._random.Next(1, GenBase._worldHeight), new object[0]))
            --count;
        }
      }
    }
  }
}
