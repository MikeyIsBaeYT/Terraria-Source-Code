// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.Desert.DesertHive
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.Utilities;

namespace Terraria.GameContent.Biomes.Desert
{
  public static class DesertHive
  {
    public static void Place(DesertDescription description)
    {
      DesertHive.ClusterGroup clusters = DesertHive.ClusterGroup.FromDescription(description);
      DesertHive.PlaceClusters(description, clusters);
      DesertHive.AddTileVariance(description);
    }

    private static void PlaceClusters(
      DesertDescription description,
      DesertHive.ClusterGroup clusters)
    {
      Rectangle hive = description.Hive;
      hive.Inflate(20, 20);
      DesertHive.PostPlacementEffect[,] postEffectMap = new DesertHive.PostPlacementEffect[hive.Width, hive.Height];
      DesertHive.PlaceClustersArea(description, clusters, hive, postEffectMap, Point.Zero);
      for (int left = hive.Left; left < hive.Right; ++left)
      {
        for (int top = hive.Top; top < hive.Bottom; ++top)
        {
          if (postEffectMap[left - hive.Left, top - hive.Top].HasFlag((Enum) DesertHive.PostPlacementEffect.Smooth))
            Tile.SmoothSlope(left, top, false);
        }
      }
    }

    private static void PlaceClustersArea(
      DesertDescription description,
      DesertHive.ClusterGroup clusters,
      Rectangle area,
      DesertHive.PostPlacementEffect[,] postEffectMap,
      Point postEffectMapOffset)
    {
      FastRandom fastRandom1 = new FastRandom(Main.ActiveWorldFileData.Seed).WithModifier(57005UL);
      Vector2 vector2_1 = new Vector2((float) description.Hive.Width, (float) description.Hive.Height);
      Vector2 vector2_2 = new Vector2((float) clusters.Width, (float) clusters.Height);
      Vector2 vector2_3 = description.BlockScale / 2f;
      for (int left = area.Left; left < area.Right; ++left)
      {
        for (int top = area.Top; top < area.Bottom; ++top)
        {
          if (WorldGen.InWorld(left, top, 1))
          {
            float num1 = 0.0f;
            int num2 = -1;
            float num3 = 0.0f;
            ushort type = 53;
            if (fastRandom1.Next(3) == 0)
              type = (ushort) 397;
            int x = left - description.Hive.X;
            int y = top - description.Hive.Y;
            Vector2 vector2_4 = (new Vector2((float) x, (float) y) - vector2_3) / vector2_1 * vector2_2;
            for (int index = 0; index < clusters.Count; ++index)
            {
              DesertHive.Cluster cluster = clusters[index];
              if ((double) Math.Abs(cluster[0].Position.X - vector2_4.X) <= 10.0 && (double) Math.Abs(cluster[0].Position.Y - vector2_4.Y) <= 10.0)
              {
                float num4 = 0.0f;
                foreach (DesertHive.Block block in (List<DesertHive.Block>) cluster)
                  num4 += 1f / Vector2.DistanceSquared(block.Position, vector2_4);
                if ((double) num4 > (double) num1)
                {
                  if ((double) num1 > (double) num3)
                    num3 = num1;
                  num1 = num4;
                  num2 = index;
                }
                else if ((double) num4 > (double) num3)
                  num3 = num4;
              }
            }
            float num5 = num1 + num3;
            Tile tile = Main.tile[left, top];
            bool flag = (double) ((new Vector2((float) x, (float) y) - vector2_3) / vector2_1 * 2f - Vector2.One).Length() >= 0.800000011920929;
            DesertHive.PostPlacementEffect postPlacementEffect = DesertHive.PostPlacementEffect.None;
            if ((double) num5 > 3.5)
            {
              postPlacementEffect = DesertHive.PostPlacementEffect.Smooth;
              tile.ClearEverything();
              tile.wall = (ushort) 187;
              if (num2 % 15 == 2)
                tile.ResetToType((ushort) 404);
            }
            else if ((double) num5 > 1.79999995231628)
            {
              tile.wall = (ushort) 187;
              if ((double) top < Main.worldSurface)
                tile.liquid = (byte) 0;
              else
                tile.lava(true);
              if (!flag || tile.active())
              {
                tile.ResetToType((ushort) 396);
                postPlacementEffect = DesertHive.PostPlacementEffect.Smooth;
              }
            }
            else if ((double) num5 > 0.699999988079071 || !flag)
            {
              tile.wall = (ushort) 216;
              tile.liquid = (byte) 0;
              if (!flag || tile.active())
              {
                tile.ResetToType(type);
                postPlacementEffect = DesertHive.PostPlacementEffect.Smooth;
              }
            }
            else if ((double) num5 > 0.25)
            {
              FastRandom fastRandom2 = fastRandom1.WithModifier(x, y);
              float num6 = (float) (((double) num5 - 0.25) / 0.449999988079071);
              if ((double) fastRandom2.NextFloat() < (double) num6)
              {
                tile.wall = (ushort) 187;
                if ((double) top < Main.worldSurface)
                  tile.liquid = (byte) 0;
                else
                  tile.lava(true);
                if (tile.active())
                {
                  tile.ResetToType(type);
                  postPlacementEffect = DesertHive.PostPlacementEffect.Smooth;
                }
              }
            }
            postEffectMap[left - area.X + postEffectMapOffset.X, top - area.Y + postEffectMapOffset.Y] = postPlacementEffect;
          }
        }
      }
    }

    private static void AddTileVariance(DesertDescription description)
    {
      for (int index1 = -20; index1 < description.Hive.Width + 20; ++index1)
      {
        for (int index2 = -20; index2 < description.Hive.Height + 20; ++index2)
        {
          int x = index1 + description.Hive.X;
          int y = index2 + description.Hive.Y;
          if (WorldGen.InWorld(x, y, 1))
          {
            Tile tile = Main.tile[x, y];
            Tile testTile1 = Main.tile[x, y + 1];
            Tile testTile2 = Main.tile[x, y + 2];
            if (tile.type == (ushort) 53 && (!WorldGen.SolidTile(testTile1) || !WorldGen.SolidTile(testTile2)))
              tile.type = (ushort) 397;
          }
        }
      }
      for (int index3 = -20; index3 < description.Hive.Width + 20; ++index3)
      {
        for (int index4 = -20; index4 < description.Hive.Height + 20; ++index4)
        {
          int index5 = index3 + description.Hive.X;
          int y = index4 + description.Hive.Y;
          if (WorldGen.InWorld(index5, y, 1))
          {
            Tile tile = Main.tile[index5, y];
            if (tile.active() && tile.type == (ushort) 396)
            {
              bool flag1 = true;
              for (int index6 = -1; index6 >= -3; --index6)
              {
                if (Main.tile[index5, y + index6].active())
                {
                  flag1 = false;
                  break;
                }
              }
              bool flag2 = true;
              for (int index7 = 1; index7 <= 3; ++index7)
              {
                if (Main.tile[index5, y + index7].active())
                {
                  flag2 = false;
                  break;
                }
              }
              if (flag1 && WorldGen.genRand.Next(5) == 0)
                WorldGen.PlaceTile(index5, y - 1, 485, true, true, style: WorldGen.genRand.Next(4));
              else if (flag1 && WorldGen.genRand.Next(5) == 0)
                WorldGen.PlaceTile(index5, y - 1, 484, true, true);
              else if (flag1 ^ flag2 && WorldGen.genRand.Next(5) == 0)
                WorldGen.PlaceTile(index5, y + (flag1 ? -1 : 1), 165, true, true);
              else if (flag1 && WorldGen.genRand.Next(5) == 0)
                WorldGen.PlaceTile(index5, y - 1, 187, true, true, style: (29 + WorldGen.genRand.Next(6)));
            }
          }
        }
      }
    }

    private struct Block
    {
      public Vector2 Position;

      public Block(float x, float y) => this.Position = new Vector2(x, y);
    }

    private class Cluster : List<DesertHive.Block>
    {
    }

    private class ClusterGroup : List<DesertHive.Cluster>
    {
      public readonly int Width;
      public readonly int Height;

      private ClusterGroup(int width, int height)
      {
        this.Width = width;
        this.Height = height;
        this.Generate();
      }

      public static DesertHive.ClusterGroup FromDescription(DesertDescription description) => new DesertHive.ClusterGroup(description.BlockColumnCount, description.BlockRowCount);

      private static void SearchForCluster(
        bool[,] blockMap,
        List<Point> pointCluster,
        int x,
        int y,
        int level = 2)
      {
        pointCluster.Add(new Point(x, y));
        blockMap[x, y] = false;
        --level;
        if (level == -1)
          return;
        if (x > 0 && blockMap[x - 1, y])
          DesertHive.ClusterGroup.SearchForCluster(blockMap, pointCluster, x - 1, y, level);
        if (x < blockMap.GetLength(0) - 1 && blockMap[x + 1, y])
          DesertHive.ClusterGroup.SearchForCluster(blockMap, pointCluster, x + 1, y, level);
        if (y > 0 && blockMap[x, y - 1])
          DesertHive.ClusterGroup.SearchForCluster(blockMap, pointCluster, x, y - 1, level);
        if (y >= blockMap.GetLength(1) - 1 || !blockMap[x, y + 1])
          return;
        DesertHive.ClusterGroup.SearchForCluster(blockMap, pointCluster, x, y + 1, level);
      }

      private static void AttemptClaim(
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

      private void Generate()
      {
        this.Clear();
        bool[,] blockMap = new bool[this.Width, this.Height];
        int num1 = this.Width / 2 - 1;
        int y1 = this.Height / 2 - 1;
        int num2 = (num1 + 1) * (num1 + 1);
        Point point1 = new Point(num1, y1);
        for (int index1 = point1.Y - y1; index1 <= point1.Y + y1; ++index1)
        {
          float num3 = (float) num1 / (float) y1 * (float) (index1 - point1.Y);
          int num4 = Math.Min(num1, (int) Math.Sqrt((double) num2 - (double) num3 * (double) num3));
          for (int index2 = point1.X - num4; index2 <= point1.X + num4; ++index2)
            blockMap[index2, index1] = WorldGen.genRand.Next(2) == 0;
        }
        List<List<Point>> pointClusters = new List<List<Point>>();
        for (int x = 0; x < blockMap.GetLength(0); ++x)
        {
          for (int y2 = 0; y2 < blockMap.GetLength(1); ++y2)
          {
            if (blockMap[x, y2] && WorldGen.genRand.Next(2) == 0)
            {
              List<Point> pointCluster = new List<Point>();
              DesertHive.ClusterGroup.SearchForCluster(blockMap, pointCluster, x, y2);
              if (pointCluster.Count > 2)
                pointClusters.Add(pointCluster);
            }
          }
        }
        int[,] clusterIndexMap = new int[blockMap.GetLength(0), blockMap.GetLength(1)];
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
                DesertHive.ClusterGroup.AttemptClaim(x - 1, y3, clusterIndexMap, pointClusters, index6);
              if (x < clusterIndexMap.GetLength(0) - 1)
                DesertHive.ClusterGroup.AttemptClaim(x + 1, y3, clusterIndexMap, pointClusters, index6);
              if (y3 > 0)
                DesertHive.ClusterGroup.AttemptClaim(x, y3 - 1, clusterIndexMap, pointClusters, index6);
              if (y3 < clusterIndexMap.GetLength(1) - 1)
                DesertHive.ClusterGroup.AttemptClaim(x, y3 + 1, clusterIndexMap, pointClusters, index6);
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
          DesertHive.Cluster cluster = new DesertHive.Cluster();
          if (pointList.Count > 0)
          {
            foreach (Point point4 in pointList)
              cluster.Add(new DesertHive.Block((float) point4.X + (float) (((double) WorldGen.genRand.NextFloat() - 0.5) * 0.5), (float) point4.Y + (float) (((double) WorldGen.genRand.NextFloat() - 0.5) * 0.5)));
            this.Add(cluster);
          }
        }
      }
    }

    [Flags]
    private enum PostPlacementEffect : byte
    {
      None = 0,
      Smooth = 1,
    }
  }
}
