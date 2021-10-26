// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.HiveBiome
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using Terraria.Utilities;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Biomes
{
  public class HiveBiome : MicroBiome
  {
    public override bool Place(Point origin, StructureMap structures)
    {
      if (!structures.CanPlace(new Microsoft.Xna.Framework.Rectangle(origin.X - 50, origin.Y - 50, 100, 100)) || HiveBiome.TooCloseToImportantLocations(origin))
        return false;
      Ref<int> count1 = new Ref<int>(0);
      Ref<int> count2 = new Ref<int>(0);
      Ref<int> count3 = new Ref<int>(0);
      WorldUtils.Gen(origin, (GenShape) new Shapes.Circle(15), Actions.Chain((GenAction) new Modifiers.IsSolid(), (GenAction) new Actions.Scanner(count1), (GenAction) new Modifiers.OnlyTiles(new ushort[2]
      {
        (ushort) 60,
        (ushort) 59
      }), (GenAction) new Actions.Scanner(count2), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 60
      }), (GenAction) new Actions.Scanner(count3)));
      if ((double) count2.Value / (double) count1.Value < 0.75 || count3.Value < 2)
        return false;
      int index1 = 0;
      int[] numArray1 = new int[1000];
      int[] numArray2 = new int[1000];
      Vector2 position1 = origin.ToVector2();
      int num1 = WorldGen.genRand.Next(2, 5);
      if (WorldGen.drunkWorldGen)
        num1 += WorldGen.genRand.Next(7, 10);
      for (int index2 = 0; index2 < num1; ++index2)
      {
        Vector2 vector2 = position1;
        int num2 = WorldGen.genRand.Next(2, 5);
        for (int index3 = 0; index3 < num2; ++index3)
          vector2 = HiveBiome.CreateHiveTunnel((int) position1.X, (int) position1.Y, WorldGen.genRand);
        position1 = vector2;
        numArray1[index1] = (int) position1.X;
        numArray2[index1] = (int) position1.Y;
        ++index1;
      }
      HiveBiome.FrameOutAllHiveContents(origin, 50);
      for (int index4 = 0; index4 < index1; ++index4)
      {
        int x1 = numArray1[index4];
        int y = numArray2[index4];
        int dir = 1;
        if (WorldGen.genRand.Next(2) == 0)
          dir = -1;
        bool flag = false;
        while (WorldGen.InWorld(x1, y, 10) && HiveBiome.BadSpotForHoneyFall(x1, y))
        {
          x1 += dir;
          if (Math.Abs(x1 - numArray1[index4]) > 50)
          {
            flag = true;
            break;
          }
        }
        if (!flag)
        {
          int x2 = x1 + dir;
          if (!HiveBiome.SpotActuallyNotInHive(x2, y))
          {
            HiveBiome.CreateBlockedHoneyCube(x2, y);
            HiveBiome.CreateDentForHoneyFall(x2, y, dir);
          }
        }
      }
      HiveBiome.CreateStandForLarva(position1);
      if (WorldGen.drunkWorldGen)
      {
        for (int index5 = 0; index5 < 1000; ++index5)
        {
          Vector2 position2 = position1;
          position2.X += (float) WorldGen.genRand.Next(-50, 51);
          position2.Y += (float) WorldGen.genRand.Next(-50, 51);
          if (WorldGen.InWorld((int) position2.X, (int) position2.Y) && (double) Vector2.Distance(position1, position2) > 10.0 && !Main.tile[(int) position2.X, (int) position2.Y].active() && Main.tile[(int) position2.X, (int) position2.Y].wall == (ushort) 86)
          {
            HiveBiome.CreateStandForLarva(position2);
            break;
          }
        }
      }
      structures.AddProtectedStructure(new Microsoft.Xna.Framework.Rectangle(origin.X - 50, origin.Y - 50, 100, 100), 5);
      return true;
    }

    private static void FrameOutAllHiveContents(Point origin, int squareHalfWidth)
    {
      int num1 = Math.Max(10, origin.X - squareHalfWidth);
      int num2 = Math.Min(Main.maxTilesX - 10, origin.X + squareHalfWidth);
      int num3 = Math.Max(10, origin.Y - squareHalfWidth);
      int num4 = Math.Min(Main.maxTilesY - 10, origin.Y + squareHalfWidth);
      for (int i = num1; i < num2; ++i)
      {
        for (int j = num3; j < num4; ++j)
        {
          Tile tile = Main.tile[i, j];
          if (tile.active() && tile.type == (ushort) 225)
            WorldGen.SquareTileFrame(i, j);
          if (tile.wall == (ushort) 86)
            WorldGen.SquareWallFrame(i, j);
        }
      }
    }

    private static Vector2 CreateHiveTunnel(int i, int j, UnifiedRandom random)
    {
      double num1 = (double) random.Next(12, 21);
      float num2 = (float) random.Next(10, 21);
      if (WorldGen.drunkWorldGen)
      {
        double num3 = (double) random.Next(8, 26);
        float num4 = (float) random.Next(10, 41);
        float num5 = (float) (((double) (Main.maxTilesX / 4200) + 1.0) / 2.0);
        num1 = num3 * (double) num5;
        num2 = num4 * num5;
      }
      double num6 = num1;
      Vector2 vector2_1;
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j;
      Vector2 vector2_2;
      vector2_2.X = (float) random.Next(-10, 11) * 0.2f;
      vector2_2.Y = (float) random.Next(-10, 11) * 0.2f;
      while (num1 > 0.0 && (double) num2 > 0.0)
      {
        if ((double) vector2_1.Y > (double) (Main.maxTilesY - 250))
          num2 = 0.0f;
        num1 = num6 * (1.0 + (double) random.Next(-20, 20) * 0.00999999977648258);
        float num7 = num2 - 1f;
        int num8 = (int) ((double) vector2_1.X - num1);
        int num9 = (int) ((double) vector2_1.X + num1);
        int num10 = (int) ((double) vector2_1.Y - num1);
        int num11 = (int) ((double) vector2_1.Y + num1);
        if (num8 < 1)
          num8 = 1;
        if (num9 > Main.maxTilesX - 1)
          num9 = Main.maxTilesX - 1;
        if (num10 < 1)
          num10 = 1;
        if (num11 > Main.maxTilesY - 1)
          num11 = Main.maxTilesY - 1;
        for (int x = num8; x < num9; ++x)
        {
          for (int y = num10; y < num11; ++y)
          {
            if (!WorldGen.InWorld(x, y, 50))
            {
              num7 = 0.0f;
            }
            else
            {
              if (Main.tile[x - 10, y].wall == (ushort) 87)
                num7 = 0.0f;
              if (Main.tile[x + 10, y].wall == (ushort) 87)
                num7 = 0.0f;
              if (Main.tile[x, y - 10].wall == (ushort) 87)
                num7 = 0.0f;
              if (Main.tile[x, y + 10].wall == (ushort) 87)
                num7 = 0.0f;
            }
            if ((double) y < Main.worldSurface && Main.tile[x, y - 5].wall == (ushort) 0)
              num7 = 0.0f;
            double num12 = (double) Math.Abs((float) x - vector2_1.X);
            float num13 = Math.Abs((float) y - vector2_1.Y);
            double num14 = Math.Sqrt(num12 * num12 + (double) num13 * (double) num13);
            if (num14 < num6 * 0.4 * (1.0 + (double) random.Next(-10, 11) * 0.005))
            {
              if (random.Next(3) == 0)
                Main.tile[x, y].liquid = byte.MaxValue;
              if (WorldGen.drunkWorldGen)
                Main.tile[x, y].liquid = byte.MaxValue;
              Main.tile[x, y].honey(true);
              Main.tile[x, y].wall = (ushort) 86;
              Main.tile[x, y].active(false);
              Main.tile[x, y].halfBrick(false);
              Main.tile[x, y].slope((byte) 0);
            }
            else if (num14 < num6 * 0.75 * (1.0 + (double) random.Next(-10, 11) * 0.005))
            {
              Main.tile[x, y].liquid = (byte) 0;
              if (Main.tile[x, y].wall != (ushort) 86)
              {
                Main.tile[x, y].active(true);
                Main.tile[x, y].halfBrick(false);
                Main.tile[x, y].slope((byte) 0);
                Main.tile[x, y].type = (ushort) 225;
              }
            }
            if (num14 < num6 * 0.6 * (1.0 + (double) random.Next(-10, 11) * 0.005))
            {
              Main.tile[x, y].wall = (ushort) 86;
              if (WorldGen.drunkWorldGen && random.Next(2) == 0)
              {
                Main.tile[x, y].liquid = byte.MaxValue;
                Main.tile[x, y].honey(true);
              }
            }
          }
        }
        vector2_1 += vector2_2;
        num2 = num7 - 1f;
        vector2_2.Y += (float) random.Next(-10, 11) * 0.05f;
        vector2_2.X += (float) random.Next(-10, 11) * 0.05f;
      }
      return vector2_1;
    }

    private static bool TooCloseToImportantLocations(Point origin)
    {
      int x = origin.X;
      int y = origin.Y;
      int num = 150;
      for (int index1 = x - num; index1 < x + num; index1 += 10)
      {
        if (index1 > 0 && index1 <= Main.maxTilesX - 1)
        {
          for (int index2 = y - num; index2 < y + num; index2 += 10)
          {
            if (index2 > 0 && index2 <= Main.maxTilesY - 1 && (Main.tile[index1, index2].active() && Main.tile[index1, index2].type == (ushort) 226 || Main.tile[index1, index2].wall == (ushort) 83 || Main.tile[index1, index2].wall == (ushort) 3 || Main.tile[index1, index2].wall == (ushort) 87))
              return true;
          }
        }
      }
      return false;
    }

    private static void CreateDentForHoneyFall(int x, int y, int dir)
    {
      dir *= -1;
      ++y;
      int num = 0;
      while ((num < 4 || WorldGen.SolidTile(x, y)) && x > 10 && x < Main.maxTilesX - 10)
      {
        ++num;
        x += dir;
        if (WorldGen.SolidTile(x, y))
        {
          WorldGen.PoundTile(x, y);
          if (!Main.tile[x, y + 1].active())
          {
            Main.tile[x, y + 1].active(true);
            Main.tile[x, y + 1].type = (ushort) 225;
          }
        }
      }
    }

    private static void CreateBlockedHoneyCube(int x, int y)
    {
      for (int index1 = x - 1; index1 <= x + 2; ++index1)
      {
        for (int index2 = y - 1; index2 <= y + 2; ++index2)
        {
          if (index1 >= x && index1 <= x + 1 && index2 >= y && index2 <= y + 1)
          {
            Main.tile[index1, index2].active(false);
            Main.tile[index1, index2].liquid = byte.MaxValue;
            Main.tile[index1, index2].honey(true);
          }
          else
          {
            Main.tile[index1, index2].active(true);
            Main.tile[index1, index2].type = (ushort) 225;
          }
        }
      }
    }

    private static bool SpotActuallyNotInHive(int x, int y)
    {
      for (int index1 = x - 1; index1 <= x + 2; ++index1)
      {
        for (int index2 = y - 1; index2 <= y + 2; ++index2)
        {
          if (index1 < 10 || index1 > Main.maxTilesX - 10 || Main.tile[index1, index2].active() && Main.tile[index1, index2].type != (ushort) 225)
            return true;
        }
      }
      return false;
    }

    private static bool BadSpotForHoneyFall(int x, int y) => !Main.tile[x, y].active() || !Main.tile[x, y + 1].active() || !Main.tile[x + 1, y].active() || !Main.tile[x + 1, y + 1].active();

    public static void CreateStandForLarva(Vector2 position)
    {
      WorldGen.larvaX[WorldGen.numLarva] = Utils.Clamp<int>((int) position.X, 5, Main.maxTilesX - 5);
      WorldGen.larvaY[WorldGen.numLarva] = Utils.Clamp<int>((int) position.Y, 5, Main.maxTilesY - 5);
      ++WorldGen.numLarva;
      if (WorldGen.numLarva >= WorldGen.larvaX.Length)
        WorldGen.numLarva = WorldGen.larvaX.Length - 1;
      int x = (int) position.X;
      int y = (int) position.Y;
      for (int index1 = x - 1; index1 <= x + 1 && index1 > 0 && index1 < Main.maxTilesX; ++index1)
      {
        for (int index2 = y - 2; index2 <= y + 1 && index2 > 0 && index2 < Main.maxTilesY; ++index2)
        {
          if (index2 != y + 1)
          {
            Main.tile[index1, index2].active(false);
          }
          else
          {
            Main.tile[index1, index2].active(true);
            Main.tile[index1, index2].type = (ushort) 225;
            Main.tile[index1, index2].slope((byte) 0);
            Main.tile[index1, index2].halfBrick(false);
          }
        }
      }
    }
  }
}
