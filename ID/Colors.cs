// Decompiled with JetBrains decompiler
// Type: Terraria.ID.Colors
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.ID
{
  public static class Colors
  {
    public static readonly Color RarityAmber = new Color((int) byte.MaxValue, 175, 0);
    public static readonly Color RarityTrash = new Color(130, 130, 130);
    public static readonly Color RarityNormal = Color.White;
    public static readonly Color RarityBlue = new Color(150, 150, (int) byte.MaxValue);
    public static readonly Color RarityGreen = new Color(150, (int) byte.MaxValue, 150);
    public static readonly Color RarityOrange = new Color((int) byte.MaxValue, 200, 150);
    public static readonly Color RarityRed = new Color((int) byte.MaxValue, 150, 150);
    public static readonly Color RarityPink = new Color((int) byte.MaxValue, 150, (int) byte.MaxValue);
    public static readonly Color RarityPurple = new Color(210, 160, (int) byte.MaxValue);
    public static readonly Color RarityLime = new Color(150, (int) byte.MaxValue, 10);
    public static readonly Color RarityYellow = new Color((int) byte.MaxValue, (int) byte.MaxValue, 10);
    public static readonly Color RarityCyan = new Color(5, 200, (int) byte.MaxValue);
    public static readonly Color CoinPlatinum = new Color(220, 220, 198);
    public static readonly Color CoinGold = new Color(224, 201, 92);
    public static readonly Color CoinSilver = new Color(181, 192, 193);
    public static readonly Color CoinCopper = new Color(246, 138, 96);
    public static readonly Color AmbientNPCGastropodLight = new Color(102, 0, 63);
    public static readonly Color JourneyMode = Color.Lerp(Color.HotPink, Color.White, 0.1f);
    public static readonly Color Mediumcore = new Color(1f, 0.6f, 0.0f);
    public static readonly Color Hardcore = new Color(1f, 0.15f, 0.1f);
    public static readonly Color LanternBG = new Color(120, 50, 20);
    public static readonly Color[] _waterfallColors;
    public static readonly Color[] _liquidColors;
    public static readonly Color FancyUIFatButtonMouseOver;
    public static readonly Color InventoryDefaultColor;
    public static readonly Color InventoryDefaultColorWithOpacity;

    public static Color CurrentLiquidColor
    {
      get
      {
        Color color = Color.Transparent;
        bool flag = true;
        for (int index = 0; index < 11; ++index)
        {
          if ((double) Main.liquidAlpha[index] > 0.0)
          {
            if (flag)
            {
              flag = false;
              color = Colors._liquidColors[index];
            }
            else
              color = Color.Lerp(color, Colors._liquidColors[index], Main.liquidAlpha[index]);
          }
        }
        return color;
      }
    }

    public static Color AlphaDarken(Color input) => input * ((float) Main.mouseTextColor / (float) byte.MaxValue);

    public static Color GetSelectionGlowColor(bool isTileSelected, int averageTileLighting) => !isTileSelected ? new Color(averageTileLighting / 2, averageTileLighting / 2, averageTileLighting / 2, averageTileLighting) : new Color(averageTileLighting, averageTileLighting, averageTileLighting / 3, averageTileLighting);

    static Colors()
    {
      Color[] colorArray = new Color[22];
      colorArray[0] = new Color(9, 61, 191);
      colorArray[1] = new Color(253, 32, 3);
      colorArray[2] = new Color(143, 143, 143);
      colorArray[3] = new Color(59, 29, 131);
      colorArray[4] = new Color(7, 145, 142);
      colorArray[5] = new Color(171, 11, 209);
      colorArray[6] = new Color(9, 137, 191);
      colorArray[7] = new Color(168, 106, 32);
      colorArray[8] = new Color(36, 60, 148);
      colorArray[9] = new Color(65, 59, 101);
      colorArray[10] = new Color(200, 0, 0);
      colorArray[13] = new Color(177, 54, 79);
      colorArray[14] = new Color((int) byte.MaxValue, 156, 12);
      colorArray[15] = new Color(91, 34, 104);
      colorArray[16] = new Color(102, 104, 34);
      colorArray[17] = new Color(34, 43, 104);
      colorArray[18] = new Color(34, 104, 38);
      colorArray[19] = new Color(104, 34, 34);
      colorArray[20] = new Color(76, 79, 102);
      colorArray[21] = new Color(104, 61, 34);
      Colors._waterfallColors = colorArray;
      Colors._liquidColors = new Color[12]
      {
        new Color(9, 61, 191),
        new Color(253, 32, 3),
        new Color(59, 29, 131),
        new Color(7, 145, 142),
        new Color(171, 11, 209),
        new Color(9, 137, 191),
        new Color(168, 106, 32),
        new Color(36, 60, 148),
        new Color(65, 59, 101),
        new Color(200, 0, 0),
        new Color(177, 54, 79),
        new Color((int) byte.MaxValue, 156, 12)
      };
      Colors.FancyUIFatButtonMouseOver = Main.OurFavoriteColor;
      Colors.InventoryDefaultColor = new Color(63, 65, 151, (int) byte.MaxValue);
      Colors.InventoryDefaultColorWithOpacity = new Color(63, 65, 151, (int) byte.MaxValue) * 0.785f;
    }
  }
}
