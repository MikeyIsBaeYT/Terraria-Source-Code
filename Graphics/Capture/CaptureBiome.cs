// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Capture.CaptureBiome
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.Graphics.Capture
{
  public class CaptureBiome
  {
    public static readonly CaptureBiome DefaultPurity = new CaptureBiome(0, 0);
    public static CaptureBiome[] BiomesByWaterStyle = new CaptureBiome[15]
    {
      null,
      null,
      new CaptureBiome(1, 2, CaptureBiome.TileColorStyle.Corrupt),
      new CaptureBiome(3, 3, CaptureBiome.TileColorStyle.Jungle),
      new CaptureBiome(6, 4),
      new CaptureBiome(7, 5),
      new CaptureBiome(2, 6),
      new CaptureBiome(0, 7),
      new CaptureBiome(0, 8),
      new CaptureBiome(0, 9),
      new CaptureBiome(8, 10, CaptureBiome.TileColorStyle.Crimson),
      null,
      new CaptureBiome(2, 12),
      new CaptureBiome(4, 0),
      new CaptureBiome(9, 7, CaptureBiome.TileColorStyle.Mushroom)
    };
    public readonly int WaterStyle;
    public readonly int BackgroundIndex;
    public readonly CaptureBiome.TileColorStyle TileColor;

    public CaptureBiome(
      int backgroundIndex,
      int waterStyle,
      CaptureBiome.TileColorStyle tileColorStyle = CaptureBiome.TileColorStyle.Normal)
    {
      this.BackgroundIndex = backgroundIndex;
      this.WaterStyle = waterStyle;
      this.TileColor = tileColorStyle;
    }

    public static CaptureBiome GetCaptureBiome(int biomeChoice)
    {
      switch (biomeChoice)
      {
        case 1:
          return CaptureBiome.GetPurityForPlayer();
        case 2:
          return CaptureBiome.Styles.Corruption;
        case 3:
          return CaptureBiome.Styles.Jungle;
        case 4:
          return CaptureBiome.Styles.Hallow;
        case 5:
          return CaptureBiome.Styles.Snow;
        case 6:
          return CaptureBiome.Styles.Desert;
        case 7:
          return CaptureBiome.Styles.DirtLayer;
        case 8:
          return CaptureBiome.Styles.RockLayer;
        case 9:
          return CaptureBiome.Styles.BloodMoon;
        case 10:
          return CaptureBiome.Styles.UndergroundDesert;
        case 11:
          return CaptureBiome.Styles.Ocean;
        case 12:
          return CaptureBiome.Styles.Mushroom;
        default:
          return CaptureBiome.GetBiomeByLocation() ?? CaptureBiome.GetBiomeByWater() ?? CaptureBiome.GetPurityForPlayer();
      }
    }

    private static CaptureBiome GetBiomeByWater()
    {
      int waterStyle = Main.CalculateWaterStyle(true);
      for (int index = 0; index < CaptureBiome.BiomesByWaterStyle.Length; ++index)
      {
        CaptureBiome captureBiome = CaptureBiome.BiomesByWaterStyle[index];
        if (captureBiome != null && captureBiome.WaterStyle == waterStyle)
          return captureBiome;
      }
      return (CaptureBiome) null;
    }

    private static CaptureBiome GetBiomeByLocation()
    {
      switch (Main.GetPreferredBGStyleForPlayer())
      {
        case 0:
          return CaptureBiome.Styles.Purity;
        case 1:
          return CaptureBiome.Styles.Corruption;
        case 2:
          return CaptureBiome.Styles.Desert;
        case 3:
          return CaptureBiome.Styles.Jungle;
        case 4:
          return CaptureBiome.Styles.Ocean;
        case 5:
          return CaptureBiome.Styles.Desert;
        case 6:
          return CaptureBiome.Styles.Hallow;
        case 7:
          return CaptureBiome.Styles.Snow;
        case 8:
          return CaptureBiome.Styles.Crimson;
        case 9:
          return CaptureBiome.Styles.Mushroom;
        case 10:
          return CaptureBiome.Styles.Purity2;
        case 11:
          return CaptureBiome.Styles.Purity3;
        case 12:
          return CaptureBiome.Styles.Purity4;
        default:
          return (CaptureBiome) null;
      }
    }

    private static CaptureBiome GetPurityForPlayer()
    {
      int num = (int) Main.LocalPlayer.Center.X / 16;
      if (num < Main.treeX[0])
        return CaptureBiome.Styles.Purity;
      if (num < Main.treeX[1])
        return CaptureBiome.Styles.Purity2;
      return num < Main.treeX[2] ? CaptureBiome.Styles.Purity3 : CaptureBiome.Styles.Purity4;
    }

    public enum TileColorStyle
    {
      Normal,
      Jungle,
      Crimson,
      Corrupt,
      Mushroom,
    }

    public class Sets
    {
      public class WaterStyles
      {
        public const int BloodMoon = 9;
      }
    }

    public class Styles
    {
      public static CaptureBiome Purity = new CaptureBiome(0, 0);
      public static CaptureBiome Purity2 = new CaptureBiome(10, 0);
      public static CaptureBiome Purity3 = new CaptureBiome(11, 0);
      public static CaptureBiome Purity4 = new CaptureBiome(12, 0);
      public static CaptureBiome Corruption = new CaptureBiome(1, 2, CaptureBiome.TileColorStyle.Corrupt);
      public static CaptureBiome Jungle = new CaptureBiome(3, 3, CaptureBiome.TileColorStyle.Jungle);
      public static CaptureBiome Hallow = new CaptureBiome(6, 4);
      public static CaptureBiome Snow = new CaptureBiome(7, 5);
      public static CaptureBiome Desert = new CaptureBiome(2, 6);
      public static CaptureBiome DirtLayer = new CaptureBiome(0, 7);
      public static CaptureBiome RockLayer = new CaptureBiome(0, 8);
      public static CaptureBiome BloodMoon = new CaptureBiome(0, 9);
      public static CaptureBiome Crimson = new CaptureBiome(8, 10, CaptureBiome.TileColorStyle.Crimson);
      public static CaptureBiome UndergroundDesert = new CaptureBiome(2, 12);
      public static CaptureBiome Ocean = new CaptureBiome(4, 0);
      public static CaptureBiome Mushroom = new CaptureBiome(9, 7, CaptureBiome.TileColorStyle.Mushroom);
    }

    private enum BiomeChoiceIndex
    {
      AutomatedForPlayer = -1, // 0xFFFFFFFF
      Purity = 1,
      Corruption = 2,
      Jungle = 3,
      Hallow = 4,
      Snow = 5,
      Desert = 6,
      DirtLayer = 7,
      RockLayer = 8,
      BloodMoon = 9,
      UndergroundDesert = 10, // 0x0000000A
      Ocean = 11, // 0x0000000B
      Mushroom = 12, // 0x0000000C
    }
  }
}
