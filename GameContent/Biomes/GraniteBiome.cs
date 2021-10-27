// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.GraniteBiome
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
  public class GraniteBiome : MicroBiome
  {
    private const int MAX_MAGMA_ITERATIONS = 300;
    private static GraniteBiome.Magma[,] _sourceMagmaMap = new GraniteBiome.Magma[200, 200];
    private static GraniteBiome.Magma[,] _targetMagmaMap = new GraniteBiome.Magma[200, 200];

    public override bool Place(Point origin, StructureMap structures)
    {
      if (GenBase._tiles[origin.X, origin.Y].active())
        return false;
      int length1 = GraniteBiome._sourceMagmaMap.GetLength(0);
      int length2 = GraniteBiome._sourceMagmaMap.GetLength(1);
      int index1 = length1 / 2;
      int index2 = length2 / 2;
      origin.X -= index1;
      origin.Y -= index2;
      for (int index3 = 0; index3 < length1; ++index3)
      {
        for (int index4 = 0; index4 < length2; ++index4)
        {
          int i = index3 + origin.X;
          int j = index4 + origin.Y;
          GraniteBiome._sourceMagmaMap[index3, index4] = GraniteBiome.Magma.CreateEmpty(WorldGen.SolidTile(i, j) ? 4f : 1f);
          GraniteBiome._targetMagmaMap[index3, index4] = GraniteBiome._sourceMagmaMap[index3, index4];
        }
      }
      int max1 = index1;
      int min1 = index1;
      int max2 = index2;
      int min2 = index2;
      for (int index5 = 0; index5 < 300; ++index5)
      {
        for (int index6 = max1; index6 <= min1; ++index6)
        {
          for (int index7 = max2; index7 <= min2; ++index7)
          {
            GraniteBiome.Magma sourceMagma1 = GraniteBiome._sourceMagmaMap[index6, index7];
            if (sourceMagma1.IsActive)
            {
              float num1 = 0.0f;
              Vector2 zero = Vector2.Zero;
              for (int index8 = -1; index8 <= 1; ++index8)
              {
                for (int index9 = -1; index9 <= 1; ++index9)
                {
                  if (index8 != 0 || index9 != 0)
                  {
                    Vector2 vector2 = new Vector2((float) index8, (float) index9);
                    vector2.Normalize();
                    GraniteBiome.Magma sourceMagma2 = GraniteBiome._sourceMagmaMap[index6 + index8, index7 + index9];
                    if ((double) sourceMagma1.Pressure > 0.00999999977648258 && !sourceMagma2.IsActive)
                    {
                      if (index8 == -1)
                        max1 = Utils.Clamp<int>(index6 + index8, 1, max1);
                      else
                        min1 = Utils.Clamp<int>(index6 + index8, min1, length1 - 2);
                      if (index9 == -1)
                        max2 = Utils.Clamp<int>(index7 + index9, 1, max2);
                      else
                        min2 = Utils.Clamp<int>(index7 + index9, min2, length2 - 2);
                      GraniteBiome._targetMagmaMap[index6 + index8, index7 + index9] = sourceMagma2.ToFlow();
                    }
                    float pressure = sourceMagma2.Pressure;
                    num1 += pressure;
                    zero += pressure * vector2;
                  }
                }
              }
              float num2 = num1 / 8f;
              if ((double) num2 > (double) sourceMagma1.Resistance)
              {
                float num3 = zero.Length() / 8f;
                float pressure = Math.Max(0.0f, (float) ((double) Math.Max(num2 - num3 - sourceMagma1.Pressure, 0.0f) + (double) num3 + (double) sourceMagma1.Pressure * 0.875) - sourceMagma1.Resistance);
                GraniteBiome._targetMagmaMap[index6, index7] = GraniteBiome.Magma.CreateFlow(pressure, Math.Max(0.0f, sourceMagma1.Resistance - pressure * 0.02f));
              }
            }
          }
        }
        if (index5 < 2)
          GraniteBiome._targetMagmaMap[index1, index2] = GraniteBiome.Magma.CreateFlow(25f);
        Utils.Swap<GraniteBiome.Magma[,]>(ref GraniteBiome._sourceMagmaMap, ref GraniteBiome._targetMagmaMap);
      }
      bool flag1 = origin.Y + index2 > WorldGen.lavaLine - 30;
      bool flag2 = false;
      for (int index10 = -50; index10 < 50 && !flag2; ++index10)
      {
        for (int index11 = -50; index11 < 50 && !flag2; ++index11)
        {
          if (GenBase._tiles[origin.X + index1 + index10, origin.Y + index2 + index11].active())
          {
            switch (GenBase._tiles[origin.X + index1 + index10, origin.Y + index2 + index11].type)
            {
              case 147:
              case 161:
              case 162:
              case 163:
              case 200:
                flag1 = false;
                flag2 = true;
                continue;
              default:
                continue;
            }
          }
        }
      }
      for (int index12 = max1; index12 <= min1; ++index12)
      {
        for (int index13 = max2; index13 <= min2; ++index13)
        {
          GraniteBiome.Magma sourceMagma = GraniteBiome._sourceMagmaMap[index12, index13];
          if (sourceMagma.IsActive)
          {
            Tile tile = GenBase._tiles[origin.X + index12, origin.Y + index13];
            if ((double) Math.Max(1f - Math.Max(0.0f, (float) (Math.Sin((double) (origin.Y + index13) * 0.400000005960464) * 0.699999988079071 + 1.20000004768372) * (float) (0.200000002980232 + 0.5 / Math.Sqrt((double) Math.Max(0.0f, sourceMagma.Pressure - sourceMagma.Resistance)))), sourceMagma.Pressure / 15f) > 0.349999994039536 + (WorldGen.SolidTile(origin.X + index12, origin.Y + index13) ? 0.0 : 0.5))
            {
              if (TileID.Sets.Ore[(int) tile.type])
                tile.ResetToType(tile.type);
              else
                tile.ResetToType((ushort) 368);
              tile.wall = (byte) 180;
            }
            else if ((double) sourceMagma.Resistance < 0.00999999977648258)
            {
              WorldUtils.ClearTile(origin.X + index12, origin.Y + index13);
              tile.wall = (byte) 180;
            }
            if (tile.liquid > (byte) 0 & flag1)
              tile.liquidType(1);
          }
        }
      }
      List<Point16> point16List = new List<Point16>();
      for (int index14 = max1; index14 <= min1; ++index14)
      {
        for (int index15 = max2; index15 <= min2; ++index15)
        {
          if (GraniteBiome._sourceMagmaMap[index14, index15].IsActive)
          {
            int num4 = 0;
            int num5 = index14 + origin.X;
            int num6 = index15 + origin.Y;
            if (WorldGen.SolidTile(num5, num6))
            {
              for (int index16 = -1; index16 <= 1; ++index16)
              {
                for (int index17 = -1; index17 <= 1; ++index17)
                {
                  if (WorldGen.SolidTile(num5 + index16, num6 + index17))
                    ++num4;
                }
              }
              if (num4 < 3)
                point16List.Add(new Point16(num5, num6));
            }
          }
        }
      }
      foreach (Point16 point16 in point16List)
      {
        int x = (int) point16.X;
        int y = (int) point16.Y;
        WorldUtils.ClearTile(x, y, true);
        GenBase._tiles[x, y].wall = (byte) 180;
      }
      point16List.Clear();
      for (int index18 = max1; index18 <= min1; ++index18)
      {
        for (int index19 = max2; index19 <= min2; ++index19)
        {
          GraniteBiome.Magma sourceMagma = GraniteBiome._sourceMagmaMap[index18, index19];
          int index20 = index18 + origin.X;
          int index21 = index19 + origin.Y;
          if (sourceMagma.IsActive)
          {
            WorldUtils.TileFrame(index20, index21);
            WorldGen.SquareWallFrame(index20, index21);
            if (GenBase._random.Next(8) == 0 && GenBase._tiles[index20, index21].active())
            {
              if (!GenBase._tiles[index20, index21 + 1].active())
                WorldGen.PlaceTight(index20, index21 + 1);
              if (!GenBase._tiles[index20, index21 - 1].active())
                WorldGen.PlaceTight(index20, index21 - 1);
            }
            if (GenBase._random.Next(2) == 0)
              Tile.SmoothSlope(index20, index21);
          }
        }
      }
      return true;
    }

    private struct Magma
    {
      public readonly float Pressure;
      public readonly float Resistance;
      public readonly bool IsActive;

      private Magma(float pressure, float resistance, bool active)
      {
        this.Pressure = pressure;
        this.Resistance = resistance;
        this.IsActive = active;
      }

      public GraniteBiome.Magma ToFlow() => new GraniteBiome.Magma(this.Pressure, this.Resistance, true);

      public static GraniteBiome.Magma CreateFlow(float pressure, float resistance = 0.0f) => new GraniteBiome.Magma(pressure, resistance, true);

      public static GraniteBiome.Magma CreateEmpty(float resistance = 0.0f) => new GraniteBiome.Magma(0.0f, resistance, false);
    }
  }
}
