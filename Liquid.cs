// Decompiled with JetBrains decompiler
// Type: Terraria.Liquid
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;

namespace Terraria
{
  public class Liquid
  {
    public static int skipCount = 0;
    public static int stuckCount = 0;
    public static int stuckAmount = 0;
    public static int cycles = 10;
    public static int resLiquid = 5000;
    public static int maxLiquid = 5000;
    public static int numLiquid;
    public static bool stuck = false;
    public static bool quickFall = false;
    public static bool quickSettle = false;
    private static int wetCounter;
    public static int panicCounter = 0;
    public static bool panicMode = false;
    public static int panicY = 0;
    public int x;
    public int y;
    public int kill;
    public int delay;

    public static double QuickWater(int verbose = 0, int minY = -1, int maxY = -1)
    {
      int num1 = 0;
      if (minY == -1)
        minY = 3;
      if (maxY == -1)
        maxY = Main.maxTilesY - 3;
      for (int index1 = maxY; index1 >= minY; --index1)
      {
        if (verbose > 0)
        {
          float num2 = (float) (maxY - index1) / (float) (maxY - minY + 1) / (float) verbose;
          Main.statusText = Lang.gen[27] + " " + (object) (int) ((double) num2 * 100.0 + 1.0) + "%";
        }
        else if (verbose < 0)
        {
          float num3 = (float) (maxY - index1) / (float) (maxY - minY + 1) / (float) -verbose;
          Main.statusText = Lang.gen[18] + " " + (object) (int) ((double) num3 * 100.0 + 1.0) + "%";
        }
        for (int index2 = 0; index2 < 2; ++index2)
        {
          int num4 = 2;
          int num5 = Main.maxTilesX - 2;
          int num6 = 1;
          if (index2 == 1)
          {
            num4 = Main.maxTilesX - 2;
            num5 = 2;
            num6 = -1;
          }
          for (int index3 = num4; index3 != num5; index3 += num6)
          {
            if (Main.tile[index3, index1].liquid > (byte) 0)
            {
              int num7 = -num6;
              bool flag1 = false;
              int x = index3;
              int y = index1;
              bool flag2 = Main.tile[index3, index1].lava;
              byte liquid = Main.tile[index3, index1].liquid;
              Main.tile[index3, index1].liquid = (byte) 0;
              bool flag3 = true;
              int num8 = 0;
              while (flag3 && x > 3 && x < Main.maxTilesX - 3 && y < Main.maxTilesY - 3)
              {
                flag3 = false;
                while (Main.tile[x, y + 1].liquid == (byte) 0 && y < Main.maxTilesY - 5 && (!Main.tile[x, y + 1].active || !Main.tileSolid[(int) Main.tile[x, y + 1].type] || Main.tileSolidTop[(int) Main.tile[x, y + 1].type]))
                {
                  flag1 = true;
                  num7 = num6;
                  num8 = 0;
                  flag3 = true;
                  ++y;
                  if (y > WorldGen.waterLine)
                    flag2 = true;
                }
                if (Main.tile[x, y + 1].liquid > (byte) 0 && Main.tile[x, y + 1].liquid < byte.MaxValue && Main.tile[x, y + 1].lava == flag2)
                {
                  int num9 = (int) byte.MaxValue - (int) Main.tile[x, y + 1].liquid;
                  if (num9 > (int) liquid)
                    num9 = (int) liquid;
                  Main.tile[x, y + 1].liquid += (byte) num9;
                  liquid -= (byte) num9;
                  if (liquid <= (byte) 0)
                  {
                    ++num1;
                    break;
                  }
                }
                if (num8 == 0)
                {
                  if (Main.tile[x + num7, y].liquid == (byte) 0 && (!Main.tile[x + num7, y].active || !Main.tileSolid[(int) Main.tile[x + num7, y].type] || Main.tileSolidTop[(int) Main.tile[x + num7, y].type]))
                    num8 = num7;
                  else if (Main.tile[x - num7, y].liquid == (byte) 0 && (!Main.tile[x - num7, y].active || !Main.tileSolid[(int) Main.tile[x - num7, y].type] || Main.tileSolidTop[(int) Main.tile[x - num7, y].type]))
                    num8 = -num7;
                }
                if (num8 != 0 && Main.tile[x + num8, y].liquid == (byte) 0 && (!Main.tile[x + num8, y].active || !Main.tileSolid[(int) Main.tile[x + num8, y].type] || Main.tileSolidTop[(int) Main.tile[x + num8, y].type]))
                {
                  flag3 = true;
                  x += num8;
                }
                if (flag1 && !flag3)
                {
                  flag1 = false;
                  flag3 = true;
                  num7 = -num6;
                  num8 = 0;
                }
              }
              if (index3 != x && index1 != y)
                ++num1;
              Main.tile[x, y].liquid = liquid;
              Main.tile[x, y].lava = flag2;
              if (Main.tile[x - 1, y].liquid > (byte) 0 && Main.tile[x - 1, y].lava != flag2)
              {
                if (flag2)
                  Liquid.LavaCheck(x, y);
                else
                  Liquid.LavaCheck(x - 1, y);
              }
              else if (Main.tile[x + 1, y].liquid > (byte) 0 && Main.tile[x + 1, y].lava != flag2)
              {
                if (flag2)
                  Liquid.LavaCheck(x, y);
                else
                  Liquid.LavaCheck(x + 1, y);
              }
              else if (Main.tile[x, y - 1].liquid > (byte) 0 && Main.tile[x, y - 1].lava != flag2)
              {
                if (flag2)
                  Liquid.LavaCheck(x, y);
                else
                  Liquid.LavaCheck(x, y - 1);
              }
              else if (Main.tile[x, y + 1].liquid > (byte) 0 && Main.tile[x, y + 1].lava != flag2)
              {
                if (flag2)
                  Liquid.LavaCheck(x, y);
                else
                  Liquid.LavaCheck(x, y + 1);
              }
            }
          }
        }
      }
      return (double) num1;
    }

    public void Update()
    {
      if (Main.tile[this.x, this.y].active && Main.tileSolid[(int) Main.tile[this.x, this.y].type] && !Main.tileSolidTop[(int) Main.tile[this.x, this.y].type])
      {
        int type = (int) Main.tile[this.x, this.y].type;
        this.kill = 9;
      }
      else
      {
        byte liquid = Main.tile[this.x, this.y].liquid;
        if (this.y > Main.maxTilesY - 200 && !Main.tile[this.x, this.y].lava && Main.tile[this.x, this.y].liquid > (byte) 0)
        {
          byte num = 2;
          if ((int) Main.tile[this.x, this.y].liquid < (int) num)
            num = Main.tile[this.x, this.y].liquid;
          Main.tile[this.x, this.y].liquid -= num;
        }
        if (Main.tile[this.x, this.y].liquid == (byte) 0)
        {
          this.kill = 9;
        }
        else
        {
          if (Main.tile[this.x, this.y].lava)
          {
            Liquid.LavaCheck(this.x, this.y);
            if (!Liquid.quickFall)
            {
              if (this.delay < 5)
              {
                ++this.delay;
                return;
              }
              this.delay = 0;
            }
          }
          else
          {
            if (Main.tile[this.x - 1, this.y].lava)
              Liquid.AddWater(this.x - 1, this.y);
            if (Main.tile[this.x + 1, this.y].lava)
              Liquid.AddWater(this.x + 1, this.y);
            if (Main.tile[this.x, this.y - 1].lava)
              Liquid.AddWater(this.x, this.y - 1);
            if (Main.tile[this.x, this.y + 1].lava)
              Liquid.AddWater(this.x, this.y + 1);
          }
          if ((!Main.tile[this.x, this.y + 1].active || !Main.tileSolid[(int) Main.tile[this.x, this.y + 1].type] || Main.tileSolidTop[(int) Main.tile[this.x, this.y + 1].type]) && (Main.tile[this.x, this.y + 1].liquid <= (byte) 0 || Main.tile[this.x, this.y + 1].lava == Main.tile[this.x, this.y].lava) && Main.tile[this.x, this.y + 1].liquid < byte.MaxValue)
          {
            float num = (float) ((int) byte.MaxValue - (int) Main.tile[this.x, this.y + 1].liquid);
            if ((double) num > (double) Main.tile[this.x, this.y].liquid)
              num = (float) Main.tile[this.x, this.y].liquid;
            Main.tile[this.x, this.y].liquid -= (byte) num;
            Main.tile[this.x, this.y + 1].liquid += (byte) num;
            Main.tile[this.x, this.y + 1].lava = Main.tile[this.x, this.y].lava;
            Liquid.AddWater(this.x, this.y + 1);
            Main.tile[this.x, this.y + 1].skipLiquid = true;
            Main.tile[this.x, this.y].skipLiquid = true;
            if (Main.tile[this.x, this.y].liquid > (byte) 250)
            {
              Main.tile[this.x, this.y].liquid = byte.MaxValue;
            }
            else
            {
              Liquid.AddWater(this.x - 1, this.y);
              Liquid.AddWater(this.x + 1, this.y);
            }
          }
          if (Main.tile[this.x, this.y].liquid > (byte) 0)
          {
            bool flag1 = true;
            bool flag2 = true;
            bool flag3 = true;
            bool flag4 = true;
            if (Main.tile[this.x - 1, this.y].active && Main.tileSolid[(int) Main.tile[this.x - 1, this.y].type] && !Main.tileSolidTop[(int) Main.tile[this.x - 1, this.y].type])
              flag1 = false;
            else if (Main.tile[this.x - 1, this.y].liquid > (byte) 0 && Main.tile[this.x - 1, this.y].lava != Main.tile[this.x, this.y].lava)
              flag1 = false;
            else if (Main.tile[this.x - 2, this.y].active && Main.tileSolid[(int) Main.tile[this.x - 2, this.y].type] && !Main.tileSolidTop[(int) Main.tile[this.x - 2, this.y].type])
              flag3 = false;
            else if (Main.tile[this.x - 2, this.y].liquid == (byte) 0)
              flag3 = false;
            else if (Main.tile[this.x - 2, this.y].liquid > (byte) 0 && Main.tile[this.x - 2, this.y].lava != Main.tile[this.x, this.y].lava)
              flag3 = false;
            if (Main.tile[this.x + 1, this.y].active && Main.tileSolid[(int) Main.tile[this.x + 1, this.y].type] && !Main.tileSolidTop[(int) Main.tile[this.x + 1, this.y].type])
              flag2 = false;
            else if (Main.tile[this.x + 1, this.y].liquid > (byte) 0 && Main.tile[this.x + 1, this.y].lava != Main.tile[this.x, this.y].lava)
              flag2 = false;
            else if (Main.tile[this.x + 2, this.y].active && Main.tileSolid[(int) Main.tile[this.x + 2, this.y].type] && !Main.tileSolidTop[(int) Main.tile[this.x + 2, this.y].type])
              flag4 = false;
            else if (Main.tile[this.x + 2, this.y].liquid == (byte) 0)
              flag4 = false;
            else if (Main.tile[this.x + 2, this.y].liquid > (byte) 0 && Main.tile[this.x + 2, this.y].lava != Main.tile[this.x, this.y].lava)
              flag4 = false;
            int num1 = 0;
            if (Main.tile[this.x, this.y].liquid < (byte) 3)
              num1 = -1;
            if (flag1 && flag2)
            {
              if (flag3 && flag4)
              {
                bool flag5 = true;
                bool flag6 = true;
                if (Main.tile[this.x - 3, this.y].active && Main.tileSolid[(int) Main.tile[this.x - 3, this.y].type] && !Main.tileSolidTop[(int) Main.tile[this.x - 3, this.y].type])
                  flag5 = false;
                else if (Main.tile[this.x - 3, this.y].liquid == (byte) 0)
                  flag5 = false;
                else if (Main.tile[this.x - 3, this.y].lava != Main.tile[this.x, this.y].lava)
                  flag5 = false;
                if (Main.tile[this.x + 3, this.y].active && Main.tileSolid[(int) Main.tile[this.x + 3, this.y].type] && !Main.tileSolidTop[(int) Main.tile[this.x + 3, this.y].type])
                  flag6 = false;
                else if (Main.tile[this.x + 3, this.y].liquid == (byte) 0)
                  flag6 = false;
                else if (Main.tile[this.x + 3, this.y].lava != Main.tile[this.x, this.y].lava)
                  flag6 = false;
                if (flag5 && flag6)
                {
                  float num2 = (float) Math.Round((double) ((int) Main.tile[this.x - 1, this.y].liquid + (int) Main.tile[this.x + 1, this.y].liquid + (int) Main.tile[this.x - 2, this.y].liquid + (int) Main.tile[this.x + 2, this.y].liquid + (int) Main.tile[this.x - 3, this.y].liquid + (int) Main.tile[this.x + 3, this.y].liquid + (int) Main.tile[this.x, this.y].liquid + num1) / 7.0);
                  int num3 = 0;
                  Main.tile[this.x - 1, this.y].lava = Main.tile[this.x, this.y].lava;
                  if ((int) Main.tile[this.x - 1, this.y].liquid != (int) (byte) num2)
                  {
                    Liquid.AddWater(this.x - 1, this.y);
                    Main.tile[this.x - 1, this.y].liquid = (byte) num2;
                  }
                  else
                    ++num3;
                  Main.tile[this.x + 1, this.y].lava = Main.tile[this.x, this.y].lava;
                  if ((int) Main.tile[this.x + 1, this.y].liquid != (int) (byte) num2)
                  {
                    Liquid.AddWater(this.x + 1, this.y);
                    Main.tile[this.x + 1, this.y].liquid = (byte) num2;
                  }
                  else
                    ++num3;
                  Main.tile[this.x - 2, this.y].lava = Main.tile[this.x, this.y].lava;
                  if ((int) Main.tile[this.x - 2, this.y].liquid != (int) (byte) num2)
                  {
                    Liquid.AddWater(this.x - 2, this.y);
                    Main.tile[this.x - 2, this.y].liquid = (byte) num2;
                  }
                  else
                    ++num3;
                  Main.tile[this.x + 2, this.y].lava = Main.tile[this.x, this.y].lava;
                  if ((int) Main.tile[this.x + 2, this.y].liquid != (int) (byte) num2)
                  {
                    Liquid.AddWater(this.x + 2, this.y);
                    Main.tile[this.x + 2, this.y].liquid = (byte) num2;
                  }
                  else
                    ++num3;
                  Main.tile[this.x - 3, this.y].lava = Main.tile[this.x, this.y].lava;
                  if ((int) Main.tile[this.x - 3, this.y].liquid != (int) (byte) num2)
                  {
                    Liquid.AddWater(this.x - 3, this.y);
                    Main.tile[this.x - 3, this.y].liquid = (byte) num2;
                  }
                  else
                    ++num3;
                  Main.tile[this.x + 3, this.y].lava = Main.tile[this.x, this.y].lava;
                  if ((int) Main.tile[this.x + 3, this.y].liquid != (int) (byte) num2)
                  {
                    Liquid.AddWater(this.x + 3, this.y);
                    Main.tile[this.x + 3, this.y].liquid = (byte) num2;
                  }
                  else
                    ++num3;
                  if ((int) Main.tile[this.x - 1, this.y].liquid != (int) (byte) num2 || (int) Main.tile[this.x, this.y].liquid != (int) (byte) num2)
                    Liquid.AddWater(this.x - 1, this.y);
                  if ((int) Main.tile[this.x + 1, this.y].liquid != (int) (byte) num2 || (int) Main.tile[this.x, this.y].liquid != (int) (byte) num2)
                    Liquid.AddWater(this.x + 1, this.y);
                  if ((int) Main.tile[this.x - 2, this.y].liquid != (int) (byte) num2 || (int) Main.tile[this.x, this.y].liquid != (int) (byte) num2)
                    Liquid.AddWater(this.x - 2, this.y);
                  if ((int) Main.tile[this.x + 2, this.y].liquid != (int) (byte) num2 || (int) Main.tile[this.x, this.y].liquid != (int) (byte) num2)
                    Liquid.AddWater(this.x + 2, this.y);
                  if ((int) Main.tile[this.x - 3, this.y].liquid != (int) (byte) num2 || (int) Main.tile[this.x, this.y].liquid != (int) (byte) num2)
                    Liquid.AddWater(this.x - 3, this.y);
                  if ((int) Main.tile[this.x + 3, this.y].liquid != (int) (byte) num2 || (int) Main.tile[this.x, this.y].liquid != (int) (byte) num2)
                    Liquid.AddWater(this.x + 3, this.y);
                  if (num3 != 6 || Main.tile[this.x, this.y - 1].liquid <= (byte) 0)
                    Main.tile[this.x, this.y].liquid = (byte) num2;
                }
                else
                {
                  int num4 = 0;
                  float num5 = (float) Math.Round((double) ((int) Main.tile[this.x - 1, this.y].liquid + (int) Main.tile[this.x + 1, this.y].liquid + (int) Main.tile[this.x - 2, this.y].liquid + (int) Main.tile[this.x + 2, this.y].liquid + (int) Main.tile[this.x, this.y].liquid + num1) / 5.0);
                  Main.tile[this.x - 1, this.y].lava = Main.tile[this.x, this.y].lava;
                  if ((int) Main.tile[this.x - 1, this.y].liquid != (int) (byte) num5)
                  {
                    Liquid.AddWater(this.x - 1, this.y);
                    Main.tile[this.x - 1, this.y].liquid = (byte) num5;
                  }
                  else
                    ++num4;
                  Main.tile[this.x + 1, this.y].lava = Main.tile[this.x, this.y].lava;
                  if ((int) Main.tile[this.x + 1, this.y].liquid != (int) (byte) num5)
                  {
                    Liquid.AddWater(this.x + 1, this.y);
                    Main.tile[this.x + 1, this.y].liquid = (byte) num5;
                  }
                  else
                    ++num4;
                  Main.tile[this.x - 2, this.y].lava = Main.tile[this.x, this.y].lava;
                  if ((int) Main.tile[this.x - 2, this.y].liquid != (int) (byte) num5)
                  {
                    Liquid.AddWater(this.x - 2, this.y);
                    Main.tile[this.x - 2, this.y].liquid = (byte) num5;
                  }
                  else
                    ++num4;
                  Main.tile[this.x + 2, this.y].lava = Main.tile[this.x, this.y].lava;
                  if ((int) Main.tile[this.x + 2, this.y].liquid != (int) (byte) num5)
                  {
                    Liquid.AddWater(this.x + 2, this.y);
                    Main.tile[this.x + 2, this.y].liquid = (byte) num5;
                  }
                  else
                    ++num4;
                  if ((int) Main.tile[this.x - 1, this.y].liquid != (int) (byte) num5 || (int) Main.tile[this.x, this.y].liquid != (int) (byte) num5)
                    Liquid.AddWater(this.x - 1, this.y);
                  if ((int) Main.tile[this.x + 1, this.y].liquid != (int) (byte) num5 || (int) Main.tile[this.x, this.y].liquid != (int) (byte) num5)
                    Liquid.AddWater(this.x + 1, this.y);
                  if ((int) Main.tile[this.x - 2, this.y].liquid != (int) (byte) num5 || (int) Main.tile[this.x, this.y].liquid != (int) (byte) num5)
                    Liquid.AddWater(this.x - 2, this.y);
                  if ((int) Main.tile[this.x + 2, this.y].liquid != (int) (byte) num5 || (int) Main.tile[this.x, this.y].liquid != (int) (byte) num5)
                    Liquid.AddWater(this.x + 2, this.y);
                  if (num4 != 4 || Main.tile[this.x, this.y - 1].liquid <= (byte) 0)
                    Main.tile[this.x, this.y].liquid = (byte) num5;
                }
              }
              else if (flag3)
              {
                float num6 = (float) Math.Round((double) ((int) Main.tile[this.x - 1, this.y].liquid + (int) Main.tile[this.x + 1, this.y].liquid + (int) Main.tile[this.x - 2, this.y].liquid + (int) Main.tile[this.x, this.y].liquid + num1) / 4.0 + 0.001);
                Main.tile[this.x - 1, this.y].lava = Main.tile[this.x, this.y].lava;
                if ((int) Main.tile[this.x - 1, this.y].liquid != (int) (byte) num6 || (int) Main.tile[this.x, this.y].liquid != (int) (byte) num6)
                {
                  Liquid.AddWater(this.x - 1, this.y);
                  Main.tile[this.x - 1, this.y].liquid = (byte) num6;
                }
                Main.tile[this.x + 1, this.y].lava = Main.tile[this.x, this.y].lava;
                if ((int) Main.tile[this.x + 1, this.y].liquid != (int) (byte) num6 || (int) Main.tile[this.x, this.y].liquid != (int) (byte) num6)
                {
                  Liquid.AddWater(this.x + 1, this.y);
                  Main.tile[this.x + 1, this.y].liquid = (byte) num6;
                }
                Main.tile[this.x - 2, this.y].lava = Main.tile[this.x, this.y].lava;
                if ((int) Main.tile[this.x - 2, this.y].liquid != (int) (byte) num6 || (int) Main.tile[this.x, this.y].liquid != (int) (byte) num6)
                {
                  Main.tile[this.x - 2, this.y].liquid = (byte) num6;
                  Liquid.AddWater(this.x - 2, this.y);
                }
                Main.tile[this.x, this.y].liquid = (byte) num6;
              }
              else if (flag4)
              {
                float num7 = (float) Math.Round((double) ((int) Main.tile[this.x - 1, this.y].liquid + (int) Main.tile[this.x + 1, this.y].liquid + (int) Main.tile[this.x + 2, this.y].liquid + (int) Main.tile[this.x, this.y].liquid + num1) / 4.0 + 0.001);
                Main.tile[this.x - 1, this.y].lava = Main.tile[this.x, this.y].lava;
                if ((int) Main.tile[this.x - 1, this.y].liquid != (int) (byte) num7 || (int) Main.tile[this.x, this.y].liquid != (int) (byte) num7)
                {
                  Liquid.AddWater(this.x - 1, this.y);
                  Main.tile[this.x - 1, this.y].liquid = (byte) num7;
                }
                Main.tile[this.x + 1, this.y].lava = Main.tile[this.x, this.y].lava;
                if ((int) Main.tile[this.x + 1, this.y].liquid != (int) (byte) num7 || (int) Main.tile[this.x, this.y].liquid != (int) (byte) num7)
                {
                  Liquid.AddWater(this.x + 1, this.y);
                  Main.tile[this.x + 1, this.y].liquid = (byte) num7;
                }
                Main.tile[this.x + 2, this.y].lava = Main.tile[this.x, this.y].lava;
                if ((int) Main.tile[this.x + 2, this.y].liquid != (int) (byte) num7 || (int) Main.tile[this.x, this.y].liquid != (int) (byte) num7)
                {
                  Main.tile[this.x + 2, this.y].liquid = (byte) num7;
                  Liquid.AddWater(this.x + 2, this.y);
                }
                Main.tile[this.x, this.y].liquid = (byte) num7;
              }
              else
              {
                float num8 = (float) Math.Round((double) ((int) Main.tile[this.x - 1, this.y].liquid + (int) Main.tile[this.x + 1, this.y].liquid + (int) Main.tile[this.x, this.y].liquid + num1) / 3.0 + 0.001);
                Main.tile[this.x - 1, this.y].lava = Main.tile[this.x, this.y].lava;
                if ((int) Main.tile[this.x - 1, this.y].liquid != (int) (byte) num8)
                  Main.tile[this.x - 1, this.y].liquid = (byte) num8;
                if ((int) Main.tile[this.x, this.y].liquid != (int) (byte) num8 || (int) Main.tile[this.x - 1, this.y].liquid != (int) (byte) num8)
                  Liquid.AddWater(this.x - 1, this.y);
                Main.tile[this.x + 1, this.y].lava = Main.tile[this.x, this.y].lava;
                if ((int) Main.tile[this.x + 1, this.y].liquid != (int) (byte) num8)
                  Main.tile[this.x + 1, this.y].liquid = (byte) num8;
                if ((int) Main.tile[this.x, this.y].liquid != (int) (byte) num8 || (int) Main.tile[this.x + 1, this.y].liquid != (int) (byte) num8)
                  Liquid.AddWater(this.x + 1, this.y);
                Main.tile[this.x, this.y].liquid = (byte) num8;
              }
            }
            else if (flag1)
            {
              float num9 = (float) Math.Round((double) ((int) Main.tile[this.x - 1, this.y].liquid + (int) Main.tile[this.x, this.y].liquid + num1) / 2.0 + 0.001);
              if ((int) Main.tile[this.x - 1, this.y].liquid != (int) (byte) num9)
                Main.tile[this.x - 1, this.y].liquid = (byte) num9;
              Main.tile[this.x - 1, this.y].lava = Main.tile[this.x, this.y].lava;
              if ((int) Main.tile[this.x, this.y].liquid != (int) (byte) num9 || (int) Main.tile[this.x - 1, this.y].liquid != (int) (byte) num9)
                Liquid.AddWater(this.x - 1, this.y);
              Main.tile[this.x, this.y].liquid = (byte) num9;
            }
            else if (flag2)
            {
              float num10 = (float) Math.Round((double) ((int) Main.tile[this.x + 1, this.y].liquid + (int) Main.tile[this.x, this.y].liquid + num1) / 2.0 + 0.001);
              if ((int) Main.tile[this.x + 1, this.y].liquid != (int) (byte) num10)
                Main.tile[this.x + 1, this.y].liquid = (byte) num10;
              Main.tile[this.x + 1, this.y].lava = Main.tile[this.x, this.y].lava;
              if ((int) Main.tile[this.x, this.y].liquid != (int) (byte) num10 || (int) Main.tile[this.x + 1, this.y].liquid != (int) (byte) num10)
                Liquid.AddWater(this.x + 1, this.y);
              Main.tile[this.x, this.y].liquid = (byte) num10;
            }
          }
          if ((int) Main.tile[this.x, this.y].liquid != (int) liquid)
          {
            if (Main.tile[this.x, this.y].liquid == (byte) 254 && liquid == byte.MaxValue)
            {
              Main.tile[this.x, this.y].liquid = byte.MaxValue;
              ++this.kill;
            }
            else
            {
              Liquid.AddWater(this.x, this.y - 1);
              this.kill = 0;
            }
          }
          else
            ++this.kill;
        }
      }
    }

    public static void StartPanic()
    {
      if (Liquid.panicMode)
        return;
      WorldGen.waterLine = Main.maxTilesY;
      Liquid.numLiquid = 0;
      LiquidBuffer.numLiquidBuffer = 0;
      Liquid.panicCounter = 0;
      Liquid.panicMode = true;
      Liquid.panicY = Main.maxTilesY - 3;
      if (!Main.dedServ)
        return;
      Console.WriteLine("Forcing water to settle.");
    }

    public static void UpdateLiquid()
    {
      if (Main.netMode == 2)
      {
        Liquid.cycles = 30;
        Liquid.maxLiquid = 6000;
      }
      if (!WorldGen.gen)
      {
        if (!Liquid.panicMode)
        {
          if (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer > 4000)
          {
            ++Liquid.panicCounter;
            if (Liquid.panicCounter > 1800 || Liquid.numLiquid + LiquidBuffer.numLiquidBuffer > 13500)
              Liquid.StartPanic();
          }
          else
            Liquid.panicCounter = 0;
        }
        if (Liquid.panicMode)
        {
          int num = 0;
          while (Liquid.panicY >= 3 && num < 5)
          {
            ++num;
            Liquid.QuickWater(minY: Liquid.panicY, maxY: Liquid.panicY);
            --Liquid.panicY;
            if (Liquid.panicY < 3)
            {
              Console.WriteLine("Water has been settled.");
              Liquid.panicCounter = 0;
              Liquid.panicMode = false;
              WorldGen.WaterCheck();
              if (Main.netMode == 2)
              {
                for (int index1 = 0; index1 < (int) byte.MaxValue; ++index1)
                {
                  for (int index2 = 0; index2 < Main.maxSectionsX; ++index2)
                  {
                    for (int index3 = 0; index3 < Main.maxSectionsY; ++index3)
                      Netplay.serverSock[index1].tileSection[index2, index3] = false;
                  }
                }
              }
            }
          }
          return;
        }
      }
      Liquid.quickFall = Liquid.quickSettle || Liquid.numLiquid > 2000;
      ++Liquid.wetCounter;
      int num1 = Liquid.maxLiquid / Liquid.cycles;
      int num2 = num1 * (Liquid.wetCounter - 1);
      int num3 = num1 * Liquid.wetCounter;
      if (Liquid.wetCounter == Liquid.cycles)
        num3 = Liquid.numLiquid;
      if (num3 > Liquid.numLiquid)
      {
        num3 = Liquid.numLiquid;
        int netMode = Main.netMode;
        Liquid.wetCounter = Liquid.cycles;
      }
      if (Liquid.quickFall)
      {
        for (int index = num2; index < num3; ++index)
        {
          Main.liquid[index].delay = 10;
          Main.liquid[index].Update();
          Main.tile[Main.liquid[index].x, Main.liquid[index].y].skipLiquid = false;
        }
      }
      else
      {
        for (int index = num2; index < num3; ++index)
        {
          if (!Main.tile[Main.liquid[index].x, Main.liquid[index].y].skipLiquid)
            Main.liquid[index].Update();
          else
            Main.tile[Main.liquid[index].x, Main.liquid[index].y].skipLiquid = false;
        }
      }
      if (Liquid.wetCounter < Liquid.cycles)
        return;
      Liquid.wetCounter = 0;
      for (int l = Liquid.numLiquid - 1; l >= 0; --l)
      {
        if (Main.liquid[l].kill > 3)
          Liquid.DelWater(l);
      }
      int num4 = Liquid.maxLiquid - (Liquid.maxLiquid - Liquid.numLiquid);
      if (num4 > LiquidBuffer.numLiquidBuffer)
        num4 = LiquidBuffer.numLiquidBuffer;
      for (int index = 0; index < num4; ++index)
      {
        Main.tile[Main.liquidBuffer[0].x, Main.liquidBuffer[0].y].checkingLiquid = false;
        Liquid.AddWater(Main.liquidBuffer[0].x, Main.liquidBuffer[0].y);
        LiquidBuffer.DelBuffer(0);
      }
      if (Liquid.numLiquid > 0 && Liquid.numLiquid > Liquid.stuckAmount - 50 && Liquid.numLiquid < Liquid.stuckAmount + 50)
      {
        ++Liquid.stuckCount;
        if (Liquid.stuckCount < 10000)
          return;
        Liquid.stuck = true;
        for (int l = Liquid.numLiquid - 1; l >= 0; --l)
          Liquid.DelWater(l);
        Liquid.stuck = false;
        Liquid.stuckCount = 0;
      }
      else
      {
        Liquid.stuckCount = 0;
        Liquid.stuckAmount = Liquid.numLiquid;
      }
    }

    public static void AddWater(int x, int y)
    {
      if (Main.tile[x, y].checkingLiquid || x >= Main.maxTilesX - 5 || y >= Main.maxTilesY - 5 || x < 5 || y < 5 || Main.tile[x, y] == null || Main.tile[x, y].liquid == (byte) 0)
        return;
      if (Liquid.numLiquid >= Liquid.maxLiquid - 1)
      {
        LiquidBuffer.AddBuffer(x, y);
      }
      else
      {
        Main.tile[x, y].checkingLiquid = true;
        Main.liquid[Liquid.numLiquid].kill = 0;
        Main.liquid[Liquid.numLiquid].x = x;
        Main.liquid[Liquid.numLiquid].y = y;
        Main.liquid[Liquid.numLiquid].delay = 0;
        Main.tile[x, y].skipLiquid = false;
        ++Liquid.numLiquid;
        if (Main.netMode == 2 && Liquid.numLiquid < Liquid.maxLiquid / 3)
          NetMessage.sendWater(x, y);
        if (!Main.tile[x, y].active || !Main.tileWaterDeath[(int) Main.tile[x, y].type] && (!Main.tile[x, y].lava || !Main.tileLavaDeath[(int) Main.tile[x, y].type]) || Main.tile[x, y].type == (byte) 4 && Main.tile[x, y].frameY == (short) 176)
          return;
        if (WorldGen.gen)
        {
          Main.tile[x, y].active = false;
        }
        else
        {
          WorldGen.KillTile(x, y);
          if (Main.netMode != 2)
            return;
          NetMessage.SendData(17, number2: ((float) x), number3: ((float) y));
        }
      }
    }

    public static void LavaCheck(int x, int y)
    {
      if (Main.tile[x - 1, y].liquid > (byte) 0 && !Main.tile[x - 1, y].lava || Main.tile[x + 1, y].liquid > (byte) 0 && !Main.tile[x + 1, y].lava || Main.tile[x, y - 1].liquid > (byte) 0 && !Main.tile[x, y - 1].lava)
      {
        int num = 0;
        if (!Main.tile[x - 1, y].lava)
        {
          num += (int) Main.tile[x - 1, y].liquid;
          Main.tile[x - 1, y].liquid = (byte) 0;
        }
        if (!Main.tile[x + 1, y].lava)
        {
          num += (int) Main.tile[x + 1, y].liquid;
          Main.tile[x + 1, y].liquid = (byte) 0;
        }
        if (!Main.tile[x, y - 1].lava)
        {
          num += (int) Main.tile[x, y - 1].liquid;
          Main.tile[x, y - 1].liquid = (byte) 0;
        }
        if (num < 32 || Main.tile[x, y].active)
          return;
        Main.tile[x, y].liquid = (byte) 0;
        Main.tile[x, y].lava = false;
        WorldGen.PlaceTile(x, y, 56, true, true);
        WorldGen.SquareTileFrame(x, y);
        if (Main.netMode != 2)
          return;
        NetMessage.SendTileSquare(-1, x - 1, y - 1, 3);
      }
      else
      {
        if (Main.tile[x, y + 1].liquid <= (byte) 0 || Main.tile[x, y + 1].lava || Main.tile[x, y + 1].active)
          return;
        Main.tile[x, y].liquid = (byte) 0;
        Main.tile[x, y].lava = false;
        Main.tile[x, y + 1].liquid = (byte) 0;
        WorldGen.PlaceTile(x, y + 1, 56, true, true);
        WorldGen.SquareTileFrame(x, y + 1);
        if (Main.netMode != 2)
          return;
        NetMessage.SendTileSquare(-1, x - 1, y, 3);
      }
    }

    public static void NetAddWater(int x, int y)
    {
      if (x >= Main.maxTilesX - 5 || y >= Main.maxTilesY - 5 || x < 5 || y < 5 || Main.tile[x, y] == null || Main.tile[x, y].liquid == (byte) 0)
        return;
      for (int index = 0; index < Liquid.numLiquid; ++index)
      {
        if (Main.liquid[index].x == x && Main.liquid[index].y == y)
        {
          Main.liquid[index].kill = 0;
          Main.tile[x, y].skipLiquid = true;
          return;
        }
      }
      if (Liquid.numLiquid >= Liquid.maxLiquid - 1)
      {
        LiquidBuffer.AddBuffer(x, y);
      }
      else
      {
        Main.tile[x, y].checkingLiquid = true;
        Main.tile[x, y].skipLiquid = true;
        Main.liquid[Liquid.numLiquid].kill = 0;
        Main.liquid[Liquid.numLiquid].x = x;
        Main.liquid[Liquid.numLiquid].y = y;
        ++Liquid.numLiquid;
        int netMode = Main.netMode;
        if (!Main.tile[x, y].active || !Main.tileWaterDeath[(int) Main.tile[x, y].type] && (!Main.tile[x, y].lava || !Main.tileLavaDeath[(int) Main.tile[x, y].type]))
          return;
        WorldGen.KillTile(x, y);
        if (Main.netMode != 2)
          return;
        NetMessage.SendData(17, number2: ((float) x), number3: ((float) y));
      }
    }

    public static void DelWater(int l)
    {
      int x = Main.liquid[l].x;
      int y = Main.liquid[l].y;
      if (Main.tile[x, y].liquid < (byte) 2)
      {
        Main.tile[x, y].liquid = (byte) 0;
        if (Main.tile[x - 1, y].liquid < (byte) 2)
          Main.tile[x - 1, y].liquid = (byte) 0;
        if (Main.tile[x + 1, y].liquid < (byte) 2)
          Main.tile[x + 1, y].liquid = (byte) 0;
      }
      else if (Main.tile[x, y].liquid < (byte) 20)
      {
        if ((int) Main.tile[x - 1, y].liquid < (int) Main.tile[x, y].liquid && (!Main.tile[x - 1, y].active || !Main.tileSolid[(int) Main.tile[x - 1, y].type] || Main.tileSolidTop[(int) Main.tile[x - 1, y].type]) || (int) Main.tile[x + 1, y].liquid < (int) Main.tile[x, y].liquid && (!Main.tile[x + 1, y].active || !Main.tileSolid[(int) Main.tile[x + 1, y].type] || Main.tileSolidTop[(int) Main.tile[x + 1, y].type]) || Main.tile[x, y + 1].liquid < byte.MaxValue && (!Main.tile[x, y + 1].active || !Main.tileSolid[(int) Main.tile[x, y + 1].type] || Main.tileSolidTop[(int) Main.tile[x, y + 1].type]))
          Main.tile[x, y].liquid = (byte) 0;
      }
      else if (Main.tile[x, y + 1].liquid < byte.MaxValue && (!Main.tile[x, y + 1].active || !Main.tileSolid[(int) Main.tile[x, y + 1].type] || Main.tileSolidTop[(int) Main.tile[x, y + 1].type]) && !Liquid.stuck)
      {
        Main.liquid[l].kill = 0;
        return;
      }
      if (Main.tile[x, y].liquid < (byte) 250 && Main.tile[x, y - 1].liquid > (byte) 0)
        Liquid.AddWater(x, y - 1);
      if (Main.tile[x, y].liquid == (byte) 0)
      {
        Main.tile[x, y].lava = false;
      }
      else
      {
        if (Main.tile[x + 1, y].liquid > (byte) 0 && Main.tile[x + 1, y + 1].liquid < (byte) 250 && !Main.tile[x + 1, y + 1].active || Main.tile[x - 1, y].liquid > (byte) 0 && Main.tile[x - 1, y + 1].liquid < (byte) 250 && !Main.tile[x - 1, y + 1].active)
        {
          Liquid.AddWater(x - 1, y);
          Liquid.AddWater(x + 1, y);
        }
        if (Main.tile[x, y].lava)
        {
          Liquid.LavaCheck(x, y);
          for (int i = x - 1; i <= x + 1; ++i)
          {
            for (int j = y - 1; j <= y + 1; ++j)
            {
              if (Main.tile[i, j].active)
              {
                if (Main.tile[i, j].type == (byte) 2 || Main.tile[i, j].type == (byte) 23 || Main.tile[i, j].type == (byte) 109)
                {
                  Main.tile[i, j].type = (byte) 0;
                  WorldGen.SquareTileFrame(i, j);
                  if (Main.netMode == 2)
                    NetMessage.SendTileSquare(-1, x, y, 3);
                }
                else if (Main.tile[i, j].type == (byte) 60 || Main.tile[i, j].type == (byte) 70)
                {
                  Main.tile[i, j].type = (byte) 59;
                  WorldGen.SquareTileFrame(i, j);
                  if (Main.netMode == 2)
                    NetMessage.SendTileSquare(-1, x, y, 3);
                }
              }
            }
          }
        }
      }
      if (Main.netMode == 2)
        NetMessage.sendWater(x, y);
      --Liquid.numLiquid;
      Main.tile[Main.liquid[l].x, Main.liquid[l].y].checkingLiquid = false;
      Main.liquid[l].x = Main.liquid[Liquid.numLiquid].x;
      Main.liquid[l].y = Main.liquid[Liquid.numLiquid].y;
      Main.liquid[l].kill = Main.liquid[Liquid.numLiquid].kill;
      if (!Main.tileAlch[(int) Main.tile[x, y].type])
        return;
      WorldGen.CheckAlch(x, y);
    }
  }
}
