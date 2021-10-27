// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.HiveBiome
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
  public class HiveBiome : MicroBiome
  {
    public override bool Place(Point origin, StructureMap structures)
    {
      Ref<int> count1 = new Ref<int>(0);
      Ref<int> count2 = new Ref<int>(0);
      Ref<int> count3 = new Ref<int>(0);
      Ref<int> count4 = new Ref<int>(0);
      WorldUtils.Gen(origin, (GenShape) new Shapes.Circle(15), Actions.Chain((GenAction) new Actions.Scanner(count3), (GenAction) new Modifiers.IsSolid(), (GenAction) new Actions.Scanner(count1), (GenAction) new Modifiers.OnlyTiles(new ushort[2]
      {
        (ushort) 60,
        (ushort) 59
      }), (GenAction) new Actions.Scanner(count2), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 60
      }), (GenAction) new Actions.Scanner(count4)));
      if ((double) count2.Value / (double) count1.Value < 0.75 || count4.Value < 2 || !structures.CanPlace(new Microsoft.Xna.Framework.Rectangle(origin.X - 50, origin.Y - 50, 100, 100)))
        return false;
      int x1 = origin.X;
      int y1 = origin.Y;
      int num1 = 150;
      for (int index1 = x1 - num1; index1 < x1 + num1; index1 += 10)
      {
        if (index1 > 0 && index1 <= Main.maxTilesX - 1)
        {
          for (int index2 = y1 - num1; index2 < y1 + num1; index2 += 10)
          {
            if (index2 > 0 && index2 <= Main.maxTilesY - 1 && (Main.tile[index1, index2].active() && Main.tile[index1, index2].type == (ushort) 226 || Main.tile[index1, index2].wall == (byte) 87 || Main.tile[index1, index2].wall == (byte) 3 || Main.tile[index1, index2].wall == (byte) 83))
              return false;
          }
        }
      }
      int x2 = origin.X;
      int y2 = origin.Y;
      int index3 = 0;
      int[] numArray1 = new int[10];
      int[] numArray2 = new int[10];
      Vector2 vector2_1 = new Vector2((float) x2, (float) y2);
      Vector2 vector2_2 = vector2_1;
      int num2 = WorldGen.genRand.Next(2, 5);
      for (int index4 = 0; index4 < num2; ++index4)
      {
        int num3 = WorldGen.genRand.Next(2, 5);
        for (int index5 = 0; index5 < num3; ++index5)
          vector2_2 = WorldGen.Hive((int) vector2_1.X, (int) vector2_1.Y);
        vector2_1 = vector2_2;
        numArray1[index3] = (int) vector2_1.X;
        numArray2[index3] = (int) vector2_1.Y;
        ++index3;
      }
      for (int index6 = 0; index6 < index3; ++index6)
      {
        int index7 = numArray1[index6];
        int index8 = numArray2[index6];
        bool flag = false;
        int num4 = 1;
        if (WorldGen.genRand.Next(2) == 0)
          num4 = -1;
        while (index7 > 10 && index7 < Main.maxTilesX - 10 && index8 > 10 && index8 < Main.maxTilesY - 10 && (!Main.tile[index7, index8].active() || !Main.tile[index7, index8 + 1].active() || !Main.tile[index7 + 1, index8].active() || !Main.tile[index7 + 1, index8 + 1].active()))
        {
          index7 += num4;
          if (Math.Abs(index7 - numArray1[index6]) > 50)
          {
            flag = true;
            break;
          }
        }
        if (!flag)
        {
          int i = index7 + num4;
          for (int index9 = i - 1; index9 <= i + 2; ++index9)
          {
            for (int index10 = index8 - 1; index10 <= index8 + 2; ++index10)
            {
              if (index9 < 10 || index9 > Main.maxTilesX - 10)
                flag = true;
              else if (Main.tile[index9, index10].active() && Main.tile[index9, index10].type != (ushort) 225)
              {
                flag = true;
                break;
              }
            }
          }
          if (!flag)
          {
            for (int index11 = i - 1; index11 <= i + 2; ++index11)
            {
              for (int index12 = index8 - 1; index12 <= index8 + 2; ++index12)
              {
                if (index11 >= i && index11 <= i + 1 && index12 >= index8 && index12 <= index8 + 1)
                {
                  Main.tile[index11, index12].active(false);
                  Main.tile[index11, index12].liquid = byte.MaxValue;
                  Main.tile[index11, index12].honey(true);
                }
                else
                {
                  Main.tile[index11, index12].active(true);
                  Main.tile[index11, index12].type = (ushort) 225;
                }
              }
            }
            int num5 = num4 * -1;
            int j = index8 + 1;
            int num6 = 0;
            while ((num6 < 4 || WorldGen.SolidTile(i, j)) && i > 10 && i < Main.maxTilesX - 10)
            {
              ++num6;
              i += num5;
              if (WorldGen.SolidTile(i, j))
              {
                WorldGen.PoundTile(i, j);
                if (!Main.tile[i, j + 1].active())
                {
                  Main.tile[i, j + 1].active(true);
                  Main.tile[i, j + 1].type = (ushort) 225;
                }
              }
            }
          }
        }
      }
      WorldGen.larvaX[WorldGen.numLarva] = Utils.Clamp<int>((int) vector2_1.X, 5, Main.maxTilesX - 5);
      WorldGen.larvaY[WorldGen.numLarva] = Utils.Clamp<int>((int) vector2_1.Y, 5, Main.maxTilesY - 5);
      ++WorldGen.numLarva;
      int x3 = (int) vector2_1.X;
      int y3 = (int) vector2_1.Y;
      for (int index13 = x3 - 1; index13 <= x3 + 1 && index13 > 0 && index13 < Main.maxTilesX; ++index13)
      {
        for (int index14 = y3 - 2; index14 <= y3 + 1 && index14 > 0 && index14 < Main.maxTilesY; ++index14)
        {
          if (index14 != y3 + 1)
          {
            Main.tile[index13, index14].active(false);
          }
          else
          {
            Main.tile[index13, index14].active(true);
            Main.tile[index13, index14].type = (ushort) 225;
            Main.tile[index13, index14].slope((byte) 0);
            Main.tile[index13, index14].halfBrick(false);
          }
        }
      }
      structures.AddStructure(new Microsoft.Xna.Framework.Rectangle(origin.X - 50, origin.Y - 50, 100, 100), 5);
      return true;
    }
  }
}
