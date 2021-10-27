// Decompiled with JetBrains decompiler
// Type: Terraria.World.Generation.GenBase
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Terraria.Utilities;

namespace Terraria.World.Generation
{
  public class GenBase
  {
    protected static UnifiedRandom _random => WorldGen.genRand;

    protected static Tile[,] _tiles => Main.tile;

    protected static int _worldWidth => Main.maxTilesX;

    protected static int _worldHeight => Main.maxTilesY;

    public delegate bool CustomPerUnitAction(int x, int y, params object[] args);
  }
}
