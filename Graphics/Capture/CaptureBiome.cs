// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Capture.CaptureBiome
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.Graphics.Capture
{
  public class CaptureBiome
  {
    public static CaptureBiome[] Biomes = new CaptureBiome[12]
    {
      new CaptureBiome(0, 0, 0),
      null,
      new CaptureBiome(1, 2, 2, CaptureBiome.TileColorStyle.Corrupt),
      new CaptureBiome(3, 0, 3, CaptureBiome.TileColorStyle.Jungle),
      new CaptureBiome(6, 2, 4),
      new CaptureBiome(7, 4, 5),
      new CaptureBiome(2, 1, 6),
      new CaptureBiome(9, 6, 7, CaptureBiome.TileColorStyle.Mushroom),
      new CaptureBiome(0, 0, 8),
      null,
      new CaptureBiome(8, 5, 10, CaptureBiome.TileColorStyle.Crimson),
      null
    };
    public readonly int WaterStyle;
    public readonly int BackgroundIndex;
    public readonly int BackgroundIndex2;
    public readonly CaptureBiome.TileColorStyle TileColor;

    public CaptureBiome(
      int backgroundIndex,
      int backgroundIndex2,
      int waterStyle,
      CaptureBiome.TileColorStyle tileColorStyle = CaptureBiome.TileColorStyle.Normal)
    {
      this.BackgroundIndex = backgroundIndex;
      this.BackgroundIndex2 = backgroundIndex2;
      this.WaterStyle = waterStyle;
      this.TileColor = tileColorStyle;
    }

    public enum TileColorStyle
    {
      Normal,
      Jungle,
      Crimson,
      Corrupt,
      Mushroom,
    }
  }
}
