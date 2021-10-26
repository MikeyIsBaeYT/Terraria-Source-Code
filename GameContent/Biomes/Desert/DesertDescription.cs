// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.Desert.DesertDescription
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.GameContent.Biomes.Desert
{
  public class DesertDescription
  {
    public static readonly DesertDescription Invalid = new DesertDescription()
    {
      IsValid = false
    };
    private static readonly Vector2 DefaultBlockScale = new Vector2(4f, 2f);
    private const int SCAN_PADDING = 5;

    public Rectangle CombinedArea { get; private set; }

    public Rectangle Desert { get; private set; }

    public Rectangle Hive { get; private set; }

    public Vector2 BlockScale { get; private set; }

    public int BlockColumnCount { get; private set; }

    public int BlockRowCount { get; private set; }

    public bool IsValid { get; private set; }

    public SurfaceMap Surface { get; private set; }

    private DesertDescription()
    {
    }

    public void UpdateSurfaceMap() => this.Surface = SurfaceMap.FromArea(this.CombinedArea.Left - 5, this.CombinedArea.Width + 10);

    public static DesertDescription CreateFromPlacement(Point origin)
    {
      Vector2 defaultBlockScale = DesertDescription.DefaultBlockScale;
      float num1 = (float) Main.maxTilesX / 4200f;
      int num2 = (int) (80.0 * (double) num1);
      int num3 = (int) (((double) WorldGen.genRand.NextFloat() + 1.0) * 170.0 * (double) num1);
      int width = (int) ((double) defaultBlockScale.X * (double) num2);
      int height = (int) ((double) defaultBlockScale.Y * (double) num3);
      origin.X -= width / 2;
      SurfaceMap surfaceMap = SurfaceMap.FromArea(origin.X - 5, width + 10);
      if (DesertDescription.RowHasInvalidTiles(origin.X, surfaceMap.Bottom, width))
        return DesertDescription.Invalid;
      int y = (int) ((double) surfaceMap.Average + (double) surfaceMap.Bottom) / 2;
      origin.Y = y + WorldGen.genRand.Next(40, 60);
      return new DesertDescription()
      {
        CombinedArea = new Rectangle(origin.X, y, width, origin.Y + height - y),
        Hive = new Rectangle(origin.X, origin.Y, width, height),
        Desert = new Rectangle(origin.X, y, width, origin.Y + height / 2 - y),
        BlockScale = defaultBlockScale,
        BlockColumnCount = num2,
        BlockRowCount = num3,
        Surface = surfaceMap,
        IsValid = true
      };
    }

    private static bool RowHasInvalidTiles(int startX, int startY, int width)
    {
      if (WorldGen.skipDesertTileCheck)
        return false;
      for (int index = startX; index < startX + width; ++index)
      {
        switch (Main.tile[index, startY].type)
        {
          case 59:
          case 60:
            return true;
          case 147:
          case 161:
            return true;
          default:
            continue;
        }
      }
      return false;
    }
  }
}
