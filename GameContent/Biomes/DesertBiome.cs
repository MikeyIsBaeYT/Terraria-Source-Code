// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.DesertBiome
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
  public class DesertBiome : MicroBiome
  {
    private void PlaceSand(DesertBiome.ClusterGroup clusters, Point start, Vector2 scale)
    {
      int num1 = (int) ((double) scale.X * (double) clusters.Width);
      int num2 = (int) ((double) scale.Y * (double) clusters.Height);
      int num3 = 5;
      int val1 = start.Y + (num2 >> 1);
      float num4 = 0.0f;
      short[] numArray = new short[num1 + num3 * 2];
      for (int index = -num3; index < num1 + num3; ++index)
      {
        for (int y = 150; y < val1; ++y)
        {
          if (WorldGen.SolidOrSlopedTile(index + start.X, y))
          {
            num4 += (float) (y - 1);
            numArray[index + num3] = (short) (y - 1);
            break;
          }
        }
      }
      float num5 = num4 / (float) (num1 + num3 * 2);
      int num6 = 0;
      for (int index1 = -num3; index1 < num1 + num3; ++index1)
      {
        float num7 = MathHelper.Clamp((float) ((double) Math.Abs((float) (index1 + num3) / (float) (num1 + num3 * 2)) * 2.0 - 1.0), -1f, 1f);
        if (index1 % 3 == 0)
          num6 = Utils.Clamp<int>(num6 + GenBase._random.Next(-1, 2), -10, 10);
        float num8 = (float) Math.Sqrt(1.0 - (double) num7 * (double) num7 * (double) num7 * (double) num7);
        int val2_1 = val1 - (int) ((double) num8 * (double) ((float) val1 - num5)) + num6;
        int val2_2 = val1 - (int) ((double) ((float) val1 - num5) * ((double) num8 - 0.150000005960464 / Math.Sqrt(Math.Max(0.01, (double) Math.Abs(8f * num7) - 0.1)) + 0.25));
        int num9 = Math.Min(val1, val2_2);
        if ((double) Math.Abs(num7) < 0.800000011920929)
        {
          float num10 = Utils.SmoothStep(0.5f, 0.8f, Math.Abs(num7));
          float num11 = num10 * num10 * num10;
          int num12 = Math.Min(10 + (int) ((double) num5 - (double) num11 * 20.0) + num6, val2_1);
          int num13 = 50;
          for (int index2 = num13; (double) index2 < (double) num5; ++index2)
          {
            int index3 = index1 + start.X;
            if (GenBase._tiles[index3, index2].active() && (GenBase._tiles[index3, index2].type == (ushort) 189 || GenBase._tiles[index3, index2].type == (ushort) 196))
              num13 = index2 + 5;
          }
          for (int index4 = num13; index4 < num12; ++index4)
          {
            int index5 = index1 + start.X;
            int index6 = index4;
            GenBase._tiles[index5, index6].active(false);
            GenBase._tiles[index5, index6].wall = (byte) 0;
          }
          numArray[index1 + num3] = (short) num12;
        }
        for (int index7 = val1 - 1; index7 >= val2_1; --index7)
        {
          int i = index1 + start.X;
          int j = index7;
          Tile tile1 = GenBase._tiles[i, j];
          tile1.liquid = (byte) 0;
          Tile tile2 = GenBase._tiles[i, j + 1];
          Tile tile3 = GenBase._tiles[i, j + 2];
          tile1.type = !WorldGen.SolidTile(tile2) || !WorldGen.SolidTile(tile3) ? (ushort) 397 : (ushort) 53;
          if (index7 > val2_1 + 5)
            tile1.wall = (byte) 187;
          tile1.active(true);
          if (tile1.wall != (byte) 187)
            tile1.wall = (byte) 0;
          if (index7 < num9)
          {
            if (index7 > val2_1 + 5)
              tile1.wall = (byte) 187;
            tile1.active(false);
          }
          WorldGen.SquareWallFrame(i, j);
        }
      }
    }

    private void PlaceClusters(DesertBiome.ClusterGroup clusters, Point start, Vector2 scale)
    {
      int num1 = (int) ((double) scale.X * (double) clusters.Width);
      int num2 = (int) ((double) scale.Y * (double) clusters.Height);
      Vector2 vector2_1 = new Vector2((float) num1, (float) num2);
      Vector2 vector2_2 = new Vector2((float) clusters.Width, (float) clusters.Height);
      for (int index1 = -20; index1 < num1 + 20; ++index1)
      {
        for (int index2 = -20; index2 < num2 + 20; ++index2)
        {
          float num3 = 0.0f;
          int num4 = -1;
          float num5 = 0.0f;
          int x = index1 + start.X;
          int y = index2 + start.Y;
          Vector2 vector2_3 = new Vector2((float) index1, (float) index2) / vector2_1 * vector2_2;
          float num6 = (new Vector2((float) index1, (float) index2) / vector2_1 * 2f - Vector2.One).Length();
          for (int index3 = 0; index3 < clusters.Count; ++index3)
          {
            DesertBiome.Cluster cluster = clusters[index3];
            if ((double) Math.Abs(cluster[0].Position.X - vector2_3.X) <= 10.0 && (double) Math.Abs(cluster[0].Position.Y - vector2_3.Y) <= 10.0)
            {
              float num7 = 0.0f;
              foreach (DesertBiome.Hub hub in (List<DesertBiome.Hub>) cluster)
                num7 += 1f / Vector2.DistanceSquared(hub.Position, vector2_3);
              if ((double) num7 > (double) num3)
              {
                if ((double) num3 > (double) num5)
                  num5 = num3;
                num3 = num7;
                num4 = index3;
              }
              else if ((double) num7 > (double) num5)
                num5 = num7;
            }
          }
          float num8 = num3 + num5;
          Tile tile = GenBase._tiles[x, y];
          bool flag = (double) num6 >= 0.800000011920929;
          if ((double) num8 > 3.5)
          {
            tile.ClearEverything();
            tile.wall = (byte) 187;
            tile.liquid = (byte) 0;
            if (num4 % 15 == 2)
            {
              tile.ResetToType((ushort) 404);
              tile.wall = (byte) 187;
              tile.active(true);
            }
            Tile.SmoothSlope(x, y);
          }
          else if ((double) num8 > 1.79999995231628)
          {
            tile.wall = (byte) 187;
            if (!flag || tile.active())
            {
              tile.ResetToType((ushort) 396);
              tile.wall = (byte) 187;
              tile.active(true);
              Tile.SmoothSlope(x, y);
            }
            tile.liquid = (byte) 0;
          }
          else if ((double) num8 > 0.699999988079071 || !flag)
          {
            if (!flag || tile.active())
            {
              tile.ResetToType((ushort) 397);
              tile.active(true);
              Tile.SmoothSlope(x, y);
            }
            tile.liquid = (byte) 0;
            tile.wall = (byte) 216;
          }
          else if ((double) num8 > 0.25)
          {
            float num9 = (float) (((double) num8 - 0.25) / 0.449999988079071);
            if ((double) GenBase._random.NextFloat() < (double) num9)
            {
              if (tile.active())
              {
                tile.ResetToType((ushort) 397);
                tile.active(true);
                Tile.SmoothSlope(x, y);
                tile.wall = (byte) 216;
              }
              tile.liquid = (byte) 0;
              tile.wall = (byte) 187;
            }
          }
        }
      }
    }

    private void AddTileVariance(DesertBiome.ClusterGroup clusters, Point start, Vector2 scale)
    {
      int num1 = (int) ((double) scale.X * (double) clusters.Width);
      int num2 = (int) ((double) scale.Y * (double) clusters.Height);
      for (int index1 = -20; index1 < num1 + 20; ++index1)
      {
        for (int index2 = -20; index2 < num2 + 20; ++index2)
        {
          int index3 = index1 + start.X;
          int index4 = index2 + start.Y;
          Tile tile1 = GenBase._tiles[index3, index4];
          Tile tile2 = GenBase._tiles[index3, index4 + 1];
          Tile tile3 = GenBase._tiles[index3, index4 + 2];
          if (tile1.type == (ushort) 53 && (!WorldGen.SolidTile(tile2) || !WorldGen.SolidTile(tile3)))
            tile1.type = (ushort) 397;
        }
      }
      for (int index5 = -20; index5 < num1 + 20; ++index5)
      {
        for (int index6 = -20; index6 < num2 + 20; ++index6)
        {
          int i = index5 + start.X;
          int index7 = index6 + start.Y;
          Tile tile = GenBase._tiles[i, index7];
          if (tile.active() && tile.type == (ushort) 396)
          {
            bool flag1 = true;
            for (int index8 = -1; index8 >= -3; --index8)
            {
              if (GenBase._tiles[i, index7 + index8].active())
              {
                flag1 = false;
                break;
              }
            }
            bool flag2 = true;
            for (int index9 = 1; index9 <= 3; ++index9)
            {
              if (GenBase._tiles[i, index7 + index9].active())
              {
                flag2 = false;
                break;
              }
            }
            if (flag1 ^ flag2 && GenBase._random.Next(5) == 0)
              WorldGen.PlaceTile(i, index7 + (flag1 ? -1 : 1), 165, true, true);
            else if (flag1 && GenBase._random.Next(5) == 0)
              WorldGen.PlaceTile(i, index7 - 1, 187, true, true, style: (29 + GenBase._random.Next(6)));
          }
        }
      }
    }

    private bool FindStart(
      Point origin,
      Vector2 scale,
      int xHubCount,
      int yHubCount,
      out Point start)
    {
      start = new Point(0, 0);
      int width = (int) ((double) scale.X * (double) xHubCount);
      int height = (int) ((double) scale.Y * (double) yHubCount);
      origin.X -= width >> 1;
      int y = 220;
label_10:
      for (int index = -20; index < width + 20; ++index)
      {
        for (int j = 220; j < Main.maxTilesY; ++j)
        {
          if (WorldGen.SolidTile(index + origin.X, j))
          {
            switch (GenBase._tiles[index + origin.X, j].type)
            {
              case 59:
              case 60:
                return false;
              default:
                if (j > y)
                {
                  y = j;
                  goto label_10;
                }
                else
                  goto label_10;
            }
          }
        }
      }
      WorldGen.UndergroundDesertLocation = new Microsoft.Xna.Framework.Rectangle(origin.X, y, width, height);
      start = new Point(origin.X, y);
      return true;
    }

    public override bool Place(Point origin, StructureMap structures)
    {
      float num1 = (float) Main.maxTilesX / 4200f;
      int num2 = (int) (80.0 * (double) num1);
      int num3 = (int) (((double) GenBase._random.NextFloat() + 1.0) * 80.0 * (double) num1);
      Vector2 scale = new Vector2(4f, 2f);
      Point start;
      if (!this.FindStart(origin, scale, num2, num3, out start))
        return false;
      DesertBiome.ClusterGroup clusters = new DesertBiome.ClusterGroup();
      clusters.Generate(num2, num3);
      this.PlaceSand(clusters, start, scale);
      this.PlaceClusters(clusters, start, scale);
      this.AddTileVariance(clusters, start, scale);
      int num4 = (int) ((double) scale.X * (double) clusters.Width);
      int num5 = (int) ((double) scale.Y * (double) clusters.Height);
      for (int index1 = -20; index1 < num4 + 20; ++index1)
      {
        for (int index2 = -20; index2 < num5 + 20; ++index2)
        {
          if (index1 + start.X > 0 && index1 + start.X < Main.maxTilesX - 1 && index2 + start.Y > 0 && index2 + start.Y < Main.maxTilesY - 1)
          {
            WorldGen.SquareWallFrame(index1 + start.X, index2 + start.Y);
            WorldUtils.TileFrame(index1 + start.X, index2 + start.Y, true);
          }
        }
      }
      return true;
    }

    private struct Hub
    {
      public Vector2 Position;

      public Hub(Vector2 position) => this.Position = position;

      public Hub(float x, float y) => this.Position = new Vector2(x, y);
    }

    private class Cluster : List<DesertBiome.Hub>
    {
    }

    private class ClusterGroup : List<DesertBiome.Cluster>
    {
      public int Width;
      public int Height;

      private void SearchForCluster(
        bool[,] hubMap,
        List<Point> pointCluster,
        int x,
        int y,
        int level = 2)
      {
        pointCluster.Add(new Point(x, y));
        hubMap[x, y] = false;
        --level;
        if (level == -1)
          return;
        if (x > 0 && hubMap[x - 1, y])
          this.SearchForCluster(hubMap, pointCluster, x - 1, y, level);
        if (x < hubMap.GetLength(0) - 1 && hubMap[x + 1, y])
          this.SearchForCluster(hubMap, pointCluster, x + 1, y, level);
        if (y > 0 && hubMap[x, y - 1])
          this.SearchForCluster(hubMap, pointCluster, x, y - 1, level);
        if (y >= hubMap.GetLength(1) - 1 || !hubMap[x, y + 1])
          return;
        this.SearchForCluster(hubMap, pointCluster, x, y + 1, level);
      }

      private void AttemptClaim(
        int x,
        int y,
        int[,] clusterIndexMap,
        List<List<Point>> pointClusters,
        int index)
      {
        int clusterIndex = clusterIndexMap[x, y];
        if (clusterIndex == -1 || clusterIndex == index)
          return;
        int num = WorldGen.genRand.Next(2) == 0 ? -1 : index;
        foreach (Point point in pointClusters[clusterIndex])
          clusterIndexMap[point.X, point.Y] = num;
      }

      public void Generate(int width, int height)
      {
        this.Width = width;
        this.Height = height;
        this.Clear();
        bool[,] hubMap = new bool[width, height];
        int num1 = (width >> 1) - 1;
        int y1 = (height >> 1) - 1;
        int num2 = (num1 + 1) * (num1 + 1);
        Point point1 = new Point(num1, y1);
        for (int index1 = point1.Y - y1; index1 <= point1.Y + y1; ++index1)
        {
          float num3 = (float) num1 / (float) y1 * (float) (index1 - point1.Y);
          int num4 = Math.Min(num1, (int) Math.Sqrt((double) num2 - (double) num3 * (double) num3));
          for (int index2 = point1.X - num4; index2 <= point1.X + num4; ++index2)
            hubMap[index2, index1] = WorldGen.genRand.Next(2) == 0;
        }
        List<List<Point>> pointClusters = new List<List<Point>>();
        for (int x = 0; x < hubMap.GetLength(0); ++x)
        {
          for (int y2 = 0; y2 < hubMap.GetLength(1); ++y2)
          {
            if (hubMap[x, y2] && WorldGen.genRand.Next(2) == 0)
            {
              List<Point> pointCluster = new List<Point>();
              this.SearchForCluster(hubMap, pointCluster, x, y2);
              if (pointCluster.Count > 2)
                pointClusters.Add(pointCluster);
            }
          }
        }
        int[,] clusterIndexMap = new int[hubMap.GetLength(0), hubMap.GetLength(1)];
        for (int index3 = 0; index3 < clusterIndexMap.GetLength(0); ++index3)
        {
          for (int index4 = 0; index4 < clusterIndexMap.GetLength(1); ++index4)
            clusterIndexMap[index3, index4] = -1;
        }
        for (int index = 0; index < pointClusters.Count; ++index)
        {
          foreach (Point point2 in pointClusters[index])
            clusterIndexMap[point2.X, point2.Y] = index;
        }
        for (int index5 = 0; index5 < pointClusters.Count; ++index5)
        {
          foreach (Point point3 in pointClusters[index5])
          {
            int x = point3.X;
            int y3 = point3.Y;
            if (clusterIndexMap[x, y3] != -1)
            {
              int index6 = clusterIndexMap[x, y3];
              if (x > 0)
                this.AttemptClaim(x - 1, y3, clusterIndexMap, pointClusters, index6);
              if (x < clusterIndexMap.GetLength(0) - 1)
                this.AttemptClaim(x + 1, y3, clusterIndexMap, pointClusters, index6);
              if (y3 > 0)
                this.AttemptClaim(x, y3 - 1, clusterIndexMap, pointClusters, index6);
              if (y3 < clusterIndexMap.GetLength(1) - 1)
                this.AttemptClaim(x, y3 + 1, clusterIndexMap, pointClusters, index6);
            }
            else
              break;
          }
        }
        foreach (List<Point> pointList in pointClusters)
          pointList.Clear();
        for (int x = 0; x < clusterIndexMap.GetLength(0); ++x)
        {
          for (int y4 = 0; y4 < clusterIndexMap.GetLength(1); ++y4)
          {
            if (clusterIndexMap[x, y4] != -1)
              pointClusters[clusterIndexMap[x, y4]].Add(new Point(x, y4));
          }
        }
        foreach (List<Point> pointList in pointClusters)
        {
          if (pointList.Count < 4)
            pointList.Clear();
        }
        foreach (List<Point> pointList in pointClusters)
        {
          DesertBiome.Cluster cluster = new DesertBiome.Cluster();
          if (pointList.Count > 0)
          {
            foreach (Point point4 in pointList)
              cluster.Add(new DesertBiome.Hub((float) point4.X + (float) (((double) WorldGen.genRand.NextFloat() - 0.5) * 0.5), (float) point4.Y + (float) (((double) WorldGen.genRand.NextFloat() - 0.5) * 0.5)));
            this.Add(cluster);
          }
        }
      }
    }
  }
}
