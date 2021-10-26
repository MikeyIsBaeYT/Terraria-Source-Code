// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.TerrainPass
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Biomes
{
  public class TerrainPass : GenPass
  {
    public double WorldSurface { get; private set; }

    public double WorldSurfaceHigh { get; private set; }

    public double WorldSurfaceLow { get; private set; }

    public double RockLayer { get; private set; }

    public double RockLayerHigh { get; private set; }

    public double RockLayerLow { get; private set; }

    public int WaterLine { get; private set; }

    public int LavaLine { get; private set; }

    public int LeftBeachSize { get; set; }

    public int RightBeachSize { get; set; }

    public TerrainPass()
      : base("Terrain", 449.3722f)
    {
    }

    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
    {
      int num1 = configuration.Get<int>("FlatBeachPadding");
      progress.Message = Lang.gen[0].Value;
      TerrainPass.TerrainFeatureType featureType = TerrainPass.TerrainFeatureType.Plateau;
      double num2 = (double) Main.maxTilesY * 0.3 * ((double) GenBase._random.Next(90, 110) * 0.005);
      double num3 = (num2 + (double) Main.maxTilesY * 0.2) * ((double) GenBase._random.Next(90, 110) * 0.01);
      double val2_1 = num2;
      double val2_2 = num2;
      double val2_3 = num3;
      double val2_4 = num3;
      double num4 = (double) Main.maxTilesY * 0.23;
      TerrainPass.SurfaceHistory history = new TerrainPass.SurfaceHistory(500);
      int num5 = this.LeftBeachSize + num1;
      for (int index = 0; index < Main.maxTilesX; ++index)
      {
        progress.Set((float) index / (float) Main.maxTilesX);
        val2_1 = Math.Min(num2, val2_1);
        val2_2 = Math.Max(num2, val2_2);
        val2_3 = Math.Min(num3, val2_3);
        val2_4 = Math.Max(num3, val2_4);
        if (num5 <= 0)
        {
          featureType = (TerrainPass.TerrainFeatureType) GenBase._random.Next(0, 5);
          num5 = GenBase._random.Next(5, 40);
          if (featureType == TerrainPass.TerrainFeatureType.Plateau)
            num5 *= (int) ((double) GenBase._random.Next(5, 30) * 0.2);
        }
        --num5;
        if ((double) index > (double) Main.maxTilesX * 0.45 && (double) index < (double) Main.maxTilesX * 0.55 && (featureType == TerrainPass.TerrainFeatureType.Mountain || featureType == TerrainPass.TerrainFeatureType.Valley))
          featureType = (TerrainPass.TerrainFeatureType) GenBase._random.Next(3);
        if ((double) index > (double) Main.maxTilesX * 0.48 && (double) index < (double) Main.maxTilesX * 0.52)
          featureType = TerrainPass.TerrainFeatureType.Plateau;
        num2 += TerrainPass.GenerateWorldSurfaceOffset(featureType);
        float num6 = 0.17f;
        float num7 = 0.26f;
        if (WorldGen.drunkWorldGen)
        {
          num6 = 0.15f;
          num7 = 0.28f;
        }
        if (index < this.LeftBeachSize + num1 || index > Main.maxTilesX - this.RightBeachSize - num1)
          num2 = Utils.Clamp<double>(num2, (double) Main.maxTilesY * 0.17, num4);
        else if (num2 < (double) Main.maxTilesY * (double) num6)
        {
          num2 = (double) Main.maxTilesY * (double) num6;
          num5 = 0;
        }
        else if (num2 > (double) Main.maxTilesY * (double) num7)
        {
          num2 = (double) Main.maxTilesY * (double) num7;
          num5 = 0;
        }
        while (GenBase._random.Next(0, 3) == 0)
          num3 += (double) GenBase._random.Next(-2, 3);
        if (num3 < num2 + (double) Main.maxTilesY * 0.06)
          ++num3;
        if (num3 > num2 + (double) Main.maxTilesY * 0.35)
          --num3;
        history.Record(num2);
        TerrainPass.FillColumn(index, num2, num3);
        if (index == Main.maxTilesX - this.RightBeachSize - num1)
        {
          if (num2 > num4)
            TerrainPass.RetargetSurfaceHistory(history, index, num4);
          featureType = TerrainPass.TerrainFeatureType.Plateau;
          num5 = Main.maxTilesX - index;
        }
      }
      Main.worldSurface = (double) (int) (val2_2 + 25.0);
      Main.rockLayer = val2_4;
      double num8 = (double) ((int) ((Main.rockLayer - Main.worldSurface) / 6.0) * 6);
      Main.rockLayer = (double) (int) (Main.worldSurface + num8);
      int num9 = (int) (Main.rockLayer + (double) Main.maxTilesY) / 2 + GenBase._random.Next(-100, 20);
      int num10 = num9 + GenBase._random.Next(50, 80);
      int num11 = 20;
      if (val2_3 < val2_2 + (double) num11)
      {
        double num12 = (val2_3 + val2_2) / 2.0;
        double num13 = Math.Abs(val2_3 - val2_2);
        if (num13 < (double) num11)
          num13 = (double) num11;
        val2_3 = num12 + num13 / 2.0;
        val2_2 = num12 - num13 / 2.0;
      }
      this.RockLayer = num3;
      this.RockLayerHigh = val2_4;
      this.RockLayerLow = val2_3;
      this.WorldSurface = num2;
      this.WorldSurfaceHigh = val2_2;
      this.WorldSurfaceLow = val2_1;
      this.WaterLine = num9;
      this.LavaLine = num10;
    }

    private static void FillColumn(int x, double worldSurface, double rockLayer)
    {
      for (int index = 0; (double) index < worldSurface; ++index)
      {
        Main.tile[x, index].active(false);
        Main.tile[x, index].frameX = (short) -1;
        Main.tile[x, index].frameY = (short) -1;
      }
      for (int index = (int) worldSurface; index < Main.maxTilesY; ++index)
      {
        if ((double) index < rockLayer)
        {
          Main.tile[x, index].active(true);
          Main.tile[x, index].type = (ushort) 0;
          Main.tile[x, index].frameX = (short) -1;
          Main.tile[x, index].frameY = (short) -1;
        }
        else
        {
          Main.tile[x, index].active(true);
          Main.tile[x, index].type = (ushort) 1;
          Main.tile[x, index].frameX = (short) -1;
          Main.tile[x, index].frameY = (short) -1;
        }
      }
    }

    private static void RetargetColumn(int x, double worldSurface)
    {
      for (int index = 0; (double) index < worldSurface; ++index)
      {
        Main.tile[x, index].active(false);
        Main.tile[x, index].frameX = (short) -1;
        Main.tile[x, index].frameY = (short) -1;
      }
      for (int index = (int) worldSurface; index < Main.maxTilesY; ++index)
      {
        if (Main.tile[x, index].type != (ushort) 1 || !Main.tile[x, index].active())
        {
          Main.tile[x, index].active(true);
          Main.tile[x, index].type = (ushort) 0;
          Main.tile[x, index].frameX = (short) -1;
          Main.tile[x, index].frameY = (short) -1;
        }
      }
    }

    private static double GenerateWorldSurfaceOffset(TerrainPass.TerrainFeatureType featureType)
    {
      double num = 0.0;
      if ((WorldGen.drunkWorldGen || WorldGen.getGoodWorldGen) && WorldGen.genRand.Next(2) == 0)
      {
        switch (featureType)
        {
          case TerrainPass.TerrainFeatureType.Plateau:
            while (GenBase._random.Next(0, 6) == 0)
              num += (double) GenBase._random.Next(-1, 2);
            break;
          case TerrainPass.TerrainFeatureType.Hill:
            while (GenBase._random.Next(0, 3) == 0)
              --num;
            while (GenBase._random.Next(0, 10) == 0)
              ++num;
            break;
          case TerrainPass.TerrainFeatureType.Dale:
            while (GenBase._random.Next(0, 3) == 0)
              ++num;
            while (GenBase._random.Next(0, 10) == 0)
              --num;
            break;
          case TerrainPass.TerrainFeatureType.Mountain:
            while (GenBase._random.Next(0, 3) != 0)
              --num;
            while (GenBase._random.Next(0, 6) == 0)
              ++num;
            break;
          case TerrainPass.TerrainFeatureType.Valley:
            while (GenBase._random.Next(0, 3) != 0)
              ++num;
            while (GenBase._random.Next(0, 5) == 0)
              --num;
            break;
        }
      }
      else
      {
        switch (featureType)
        {
          case TerrainPass.TerrainFeatureType.Plateau:
            while (GenBase._random.Next(0, 7) == 0)
              num += (double) GenBase._random.Next(-1, 2);
            break;
          case TerrainPass.TerrainFeatureType.Hill:
            while (GenBase._random.Next(0, 4) == 0)
              --num;
            while (GenBase._random.Next(0, 10) == 0)
              ++num;
            break;
          case TerrainPass.TerrainFeatureType.Dale:
            while (GenBase._random.Next(0, 4) == 0)
              ++num;
            while (GenBase._random.Next(0, 10) == 0)
              --num;
            break;
          case TerrainPass.TerrainFeatureType.Mountain:
            while (GenBase._random.Next(0, 2) == 0)
              --num;
            while (GenBase._random.Next(0, 6) == 0)
              ++num;
            break;
          case TerrainPass.TerrainFeatureType.Valley:
            while (GenBase._random.Next(0, 2) == 0)
              ++num;
            while (GenBase._random.Next(0, 5) == 0)
              --num;
            break;
        }
      }
      return num;
    }

    private static void RetargetSurfaceHistory(
      TerrainPass.SurfaceHistory history,
      int targetX,
      double targetHeight)
    {
      for (int index1 = 0; index1 < history.Length / 2 && history[history.Length - 1] > targetHeight; ++index1)
      {
        for (int index2 = 0; index2 < history.Length - index1 * 2; ++index2)
        {
          double num = history[history.Length - index2 - 1] - 1.0;
          history[history.Length - index2 - 1] = num;
          if (num <= targetHeight)
            break;
        }
      }
      for (int index = 0; index < history.Length; ++index)
      {
        double worldSurface = history[history.Length - index - 1];
        TerrainPass.RetargetColumn(targetX - index, worldSurface);
      }
    }

    private enum TerrainFeatureType
    {
      Plateau,
      Hill,
      Dale,
      Mountain,
      Valley,
    }

    private class SurfaceHistory
    {
      private readonly double[] _heights;
      private int _index;

      public double this[int index]
      {
        get => this._heights[(index + this._index) % this._heights.Length];
        set => this._heights[(index + this._index) % this._heights.Length] = value;
      }

      public int Length => this._heights.Length;

      public SurfaceHistory(int size) => this._heights = new double[size];

      public void Record(double height)
      {
        this._heights[this._index] = height;
        this._index = (this._index + 1) % this._heights.Length;
      }
    }
  }
}
