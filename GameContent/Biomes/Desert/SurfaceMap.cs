// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.Desert.SurfaceMap
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;

namespace Terraria.GameContent.Biomes.Desert
{
  public class SurfaceMap
  {
    public readonly float Average;
    public readonly int Bottom;
    public readonly int Top;
    public readonly int X;
    private readonly short[] _heights;

    public int Width => this._heights.Length;

    private SurfaceMap(short[] heights, int x)
    {
      this._heights = heights;
      this.X = x;
      int val1_1 = 0;
      int val1_2 = int.MaxValue;
      int num = 0;
      for (int index = 0; index < heights.Length; ++index)
      {
        num += (int) heights[index];
        val1_1 = Math.Max(val1_1, (int) heights[index]);
        val1_2 = Math.Min(val1_2, (int) heights[index]);
      }
      if ((double) val1_1 > Main.worldSurface - 10.0)
        val1_1 = (int) Main.worldSurface - 10;
      this.Bottom = val1_1;
      this.Top = val1_2;
      this.Average = (float) num / (float) this._heights.Length;
    }

    public short this[int absoluteX] => this._heights[absoluteX - this.X];

    public static SurfaceMap FromArea(int startX, int width)
    {
      int num1 = Main.maxTilesY / 2;
      short[] heights = new short[width];
      for (int index1 = startX; index1 < startX + width; ++index1)
      {
        bool flag = false;
        int num2 = 0;
        for (int index2 = 50; index2 < 50 + num1; ++index2)
        {
          if (Main.tile[index1, index2].active())
          {
            if (Main.tile[index1, index2].type == (ushort) 189 || Main.tile[index1, index2].type == (ushort) 196 || Main.tile[index1, index2].type == (ushort) 460)
              flag = false;
            else if (!flag)
            {
              num2 = index2;
              flag = true;
            }
          }
          if (!flag)
            num2 = num1 + 50;
        }
        heights[index1 - startX] = (short) num2;
      }
      return new SurfaceMap(heights, startX);
    }
  }
}
