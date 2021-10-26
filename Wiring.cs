// Decompiled with JetBrains decompiler
// Type: Terraria.Wiring
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Events;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;

namespace Terraria
{
  public static class Wiring
  {
    public static bool blockPlayerTeleportationForOneIteration;
    public static bool running;
    private static Dictionary<Point16, bool> _wireSkip;
    private static DoubleStack<Point16> _wireList;
    private static DoubleStack<byte> _wireDirectionList;
    private static Dictionary<Point16, byte> _toProcess;
    private static Queue<Point16> _GatesCurrent;
    private static Queue<Point16> _LampsToCheck;
    private static Queue<Point16> _GatesNext;
    private static Dictionary<Point16, bool> _GatesDone;
    private static Dictionary<Point16, byte> _PixelBoxTriggers;
    private static Vector2[] _teleport;
    private const int MaxPump = 20;
    private static int[] _inPumpX;
    private static int[] _inPumpY;
    private static int _numInPump;
    private static int[] _outPumpX;
    private static int[] _outPumpY;
    private static int _numOutPump;
    private const int MaxMech = 1000;
    private static int[] _mechX;
    private static int[] _mechY;
    private static int _numMechs;
    private static int[] _mechTime;
    private static int _currentWireColor;
    private static int CurrentUser = (int) byte.MaxValue;

    public static void SetCurrentUser(int plr = -1)
    {
      if (plr < 0 || plr > (int) byte.MaxValue)
        plr = (int) byte.MaxValue;
      if (Main.netMode == 0)
        plr = Main.myPlayer;
      Wiring.CurrentUser = plr;
    }

    public static void Initialize()
    {
      Wiring._wireSkip = new Dictionary<Point16, bool>();
      Wiring._wireList = new DoubleStack<Point16>();
      Wiring._wireDirectionList = new DoubleStack<byte>();
      Wiring._toProcess = new Dictionary<Point16, byte>();
      Wiring._GatesCurrent = new Queue<Point16>();
      Wiring._GatesNext = new Queue<Point16>();
      Wiring._GatesDone = new Dictionary<Point16, bool>();
      Wiring._LampsToCheck = new Queue<Point16>();
      Wiring._PixelBoxTriggers = new Dictionary<Point16, byte>();
      Wiring._inPumpX = new int[20];
      Wiring._inPumpY = new int[20];
      Wiring._outPumpX = new int[20];
      Wiring._outPumpY = new int[20];
      Wiring._teleport = new Vector2[2];
      Wiring._mechX = new int[1000];
      Wiring._mechY = new int[1000];
      Wiring._mechTime = new int[1000];
    }

    public static void SkipWire(int x, int y) => Wiring._wireSkip[new Point16(x, y)] = true;

    public static void SkipWire(Point16 point) => Wiring._wireSkip[point] = true;

    public static void UpdateMech()
    {
      Wiring.SetCurrentUser();
      for (int index1 = Wiring._numMechs - 1; index1 >= 0; --index1)
      {
        --Wiring._mechTime[index1];
        if (Main.tile[Wiring._mechX[index1], Wiring._mechY[index1]].active() && Main.tile[Wiring._mechX[index1], Wiring._mechY[index1]].type == (ushort) 144)
        {
          if (Main.tile[Wiring._mechX[index1], Wiring._mechY[index1]].frameY == (short) 0)
          {
            Wiring._mechTime[index1] = 0;
          }
          else
          {
            int num = (int) Main.tile[Wiring._mechX[index1], Wiring._mechY[index1]].frameX / 18;
            switch (num)
            {
              case 0:
                num = 60;
                break;
              case 1:
                num = 180;
                break;
              case 2:
                num = 300;
                break;
              case 3:
                num = 30;
                break;
              case 4:
                num = 15;
                break;
            }
            if (Math.IEEERemainder((double) Wiring._mechTime[index1], (double) num) == 0.0)
            {
              Wiring._mechTime[index1] = 18000;
              Wiring.TripWire(Wiring._mechX[index1], Wiring._mechY[index1], 1, 1);
            }
          }
        }
        if (Wiring._mechTime[index1] <= 0)
        {
          if (Main.tile[Wiring._mechX[index1], Wiring._mechY[index1]].active() && Main.tile[Wiring._mechX[index1], Wiring._mechY[index1]].type == (ushort) 144)
          {
            Main.tile[Wiring._mechX[index1], Wiring._mechY[index1]].frameY = (short) 0;
            NetMessage.SendTileSquare(-1, Wiring._mechX[index1], Wiring._mechY[index1], 1);
          }
          if (Main.tile[Wiring._mechX[index1], Wiring._mechY[index1]].active() && Main.tile[Wiring._mechX[index1], Wiring._mechY[index1]].type == (ushort) 411)
          {
            Tile tile = Main.tile[Wiring._mechX[index1], Wiring._mechY[index1]];
            int num1 = (int) tile.frameX % 36 / 18;
            int num2 = (int) tile.frameY % 36 / 18;
            int tileX = Wiring._mechX[index1] - num1;
            int tileY = Wiring._mechY[index1] - num2;
            int num3 = 36;
            if (Main.tile[tileX, tileY].frameX >= (short) 36)
              num3 = -36;
            for (int index2 = tileX; index2 < tileX + 2; ++index2)
            {
              for (int index3 = tileY; index3 < tileY + 2; ++index3)
                Main.tile[index2, index3].frameX += (short) num3;
            }
            NetMessage.SendTileSquare(-1, tileX, tileY, 2);
          }
          for (int index4 = index1; index4 < Wiring._numMechs; ++index4)
          {
            Wiring._mechX[index4] = Wiring._mechX[index4 + 1];
            Wiring._mechY[index4] = Wiring._mechY[index4 + 1];
            Wiring._mechTime[index4] = Wiring._mechTime[index4 + 1];
          }
          --Wiring._numMechs;
        }
      }
    }

    public static void HitSwitch(int i, int j)
    {
      if (!WorldGen.InWorld(i, j) || Main.tile[i, j] == null)
        return;
      if (Main.tile[i, j].type == (ushort) 135 || Main.tile[i, j].type == (ushort) 314 || Main.tile[i, j].type == (ushort) 423 || Main.tile[i, j].type == (ushort) 428 || Main.tile[i, j].type == (ushort) 442 || Main.tile[i, j].type == (ushort) 476)
      {
        SoundEngine.PlaySound(28, i * 16, j * 16, 0);
        Wiring.TripWire(i, j, 1, 1);
      }
      else if (Main.tile[i, j].type == (ushort) 440)
      {
        SoundEngine.PlaySound(28, i * 16 + 16, j * 16 + 16, 0);
        Wiring.TripWire(i, j, 3, 3);
      }
      else if (Main.tile[i, j].type == (ushort) 136)
      {
        Main.tile[i, j].frameY = Main.tile[i, j].frameY != (short) 0 ? (short) 0 : (short) 18;
        SoundEngine.PlaySound(28, i * 16, j * 16, 0);
        Wiring.TripWire(i, j, 1, 1);
      }
      else if (Main.tile[i, j].type == (ushort) 443)
        Wiring.GeyserTrap(i, j);
      else if (Main.tile[i, j].type == (ushort) 144)
      {
        if (Main.tile[i, j].frameY == (short) 0)
        {
          Main.tile[i, j].frameY = (short) 18;
          if (Main.netMode != 1)
            Wiring.CheckMech(i, j, 18000);
        }
        else
          Main.tile[i, j].frameY = (short) 0;
        SoundEngine.PlaySound(28, i * 16, j * 16, 0);
      }
      else if (Main.tile[i, j].type == (ushort) 441 || Main.tile[i, j].type == (ushort) 468)
      {
        int num1 = (int) Main.tile[i, j].frameX / 18 * -1;
        int num2 = (int) Main.tile[i, j].frameY / 18 * -1;
        int num3 = num1 % 4;
        if (num3 < -1)
          num3 += 2;
        int left = num3 + i;
        int top = num2 + j;
        SoundEngine.PlaySound(28, i * 16, j * 16, 0);
        Wiring.TripWire(left, top, 2, 2);
      }
      else if (Main.tile[i, j].type == (ushort) 467)
      {
        if ((int) Main.tile[i, j].frameX / 36 != 4)
          return;
        int num4 = (int) Main.tile[i, j].frameX / 18 * -1;
        int num5 = (int) Main.tile[i, j].frameY / 18 * -1;
        int num6 = num4 % 4;
        if (num6 < -1)
          num6 += 2;
        int left = num6 + i;
        int top = num5 + j;
        SoundEngine.PlaySound(28, i * 16, j * 16, 0);
        Wiring.TripWire(left, top, 2, 2);
      }
      else
      {
        if (Main.tile[i, j].type != (ushort) 132 && Main.tile[i, j].type != (ushort) 411)
          return;
        short num7 = 36;
        int num8 = (int) Main.tile[i, j].frameX / 18 * -1;
        int num9 = (int) Main.tile[i, j].frameY / 18 * -1;
        int num10 = num8 % 4;
        if (num10 < -1)
        {
          num10 += 2;
          num7 = (short) -36;
        }
        int index1 = num10 + i;
        int index2 = num9 + j;
        if (Main.netMode != 1 && Main.tile[index1, index2].type == (ushort) 411)
          Wiring.CheckMech(index1, index2, 60);
        for (int index3 = index1; index3 < index1 + 2; ++index3)
        {
          for (int index4 = index2; index4 < index2 + 2; ++index4)
          {
            if (Main.tile[index3, index4].type == (ushort) 132 || Main.tile[index3, index4].type == (ushort) 411)
              Main.tile[index3, index4].frameX += num7;
          }
        }
        WorldGen.TileFrame(index1, index2);
        SoundEngine.PlaySound(28, i * 16, j * 16, 0);
        Wiring.TripWire(index1, index2, 2, 2);
      }
    }

    public static void PokeLogicGate(int lampX, int lampY)
    {
      if (Main.netMode == 1)
        return;
      Wiring._LampsToCheck.Enqueue(new Point16(lampX, lampY));
      Wiring.LogicGatePass();
    }

    public static bool Actuate(int i, int j)
    {
      Tile tile = Main.tile[i, j];
      if (!tile.actuator())
        return false;
      if (tile.inActive())
        Wiring.ReActive(i, j);
      else
        Wiring.DeActive(i, j);
      return true;
    }

    public static void ActuateForced(int i, int j)
    {
      if (Main.tile[i, j].inActive())
        Wiring.ReActive(i, j);
      else
        Wiring.DeActive(i, j);
    }

    public static void MassWireOperation(Point ps, Point pe, Player master)
    {
      int wireCount = 0;
      int actuatorCount = 0;
      for (int index = 0; index < 58; ++index)
      {
        if (master.inventory[index].type == 530)
          wireCount += master.inventory[index].stack;
        if (master.inventory[index].type == 849)
          actuatorCount += master.inventory[index].stack;
      }
      int num1 = wireCount;
      int num2 = actuatorCount;
      Wiring.MassWireOperationInner(ps, pe, master.Center, master.direction == 1, ref wireCount, ref actuatorCount);
      int num3 = wireCount;
      int num4 = num1 - num3;
      int num5 = num2 - actuatorCount;
      if (Main.netMode == 2)
      {
        NetMessage.SendData(110, master.whoAmI, number: 530, number2: ((float) num4), number3: ((float) master.whoAmI));
        NetMessage.SendData(110, master.whoAmI, number: 849, number2: ((float) num5), number3: ((float) master.whoAmI));
      }
      else
      {
        for (int index = 0; index < num4; ++index)
          master.ConsumeItem(530);
        for (int index = 0; index < num5; ++index)
          master.ConsumeItem(849);
      }
    }

    private static bool CheckMech(int i, int j, int time)
    {
      for (int index = 0; index < Wiring._numMechs; ++index)
      {
        if (Wiring._mechX[index] == i && Wiring._mechY[index] == j)
          return false;
      }
      if (Wiring._numMechs >= 999)
        return false;
      Wiring._mechX[Wiring._numMechs] = i;
      Wiring._mechY[Wiring._numMechs] = j;
      Wiring._mechTime[Wiring._numMechs] = time;
      ++Wiring._numMechs;
      return true;
    }

    private static void XferWater()
    {
      for (int index1 = 0; index1 < Wiring._numInPump; ++index1)
      {
        int i1 = Wiring._inPumpX[index1];
        int j1 = Wiring._inPumpY[index1];
        int liquid1 = (int) Main.tile[i1, j1].liquid;
        if (liquid1 > 0)
        {
          bool lava = Main.tile[i1, j1].lava();
          bool honey = Main.tile[i1, j1].honey();
          for (int index2 = 0; index2 < Wiring._numOutPump; ++index2)
          {
            int i2 = Wiring._outPumpX[index2];
            int j2 = Wiring._outPumpY[index2];
            int liquid2 = (int) Main.tile[i2, j2].liquid;
            if (liquid2 < (int) byte.MaxValue)
            {
              bool flag1 = Main.tile[i2, j2].lava();
              bool flag2 = Main.tile[i2, j2].honey();
              if (liquid2 == 0)
              {
                flag1 = lava;
                flag2 = honey;
              }
              if (lava == flag1 && honey == flag2)
              {
                int num = liquid1;
                if (num + liquid2 > (int) byte.MaxValue)
                  num = (int) byte.MaxValue - liquid2;
                Main.tile[i2, j2].liquid += (byte) num;
                Main.tile[i1, j1].liquid -= (byte) num;
                liquid1 = (int) Main.tile[i1, j1].liquid;
                Main.tile[i2, j2].lava(lava);
                Main.tile[i2, j2].honey(honey);
                WorldGen.SquareTileFrame(i2, j2);
                if (Main.tile[i1, j1].liquid == (byte) 0)
                {
                  Main.tile[i1, j1].lava(false);
                  WorldGen.SquareTileFrame(i1, j1);
                  break;
                }
              }
            }
          }
          WorldGen.SquareTileFrame(i1, j1);
        }
      }
    }

    private static void TripWire(int left, int top, int width, int height)
    {
      if (Main.netMode == 1)
        return;
      Wiring.running = true;
      if (Wiring._wireList.Count != 0)
        Wiring._wireList.Clear(true);
      if (Wiring._wireDirectionList.Count != 0)
        Wiring._wireDirectionList.Clear(true);
      Vector2[] vector2Array1 = new Vector2[8];
      int num1 = 0;
      Point16 back;
      for (int X = left; X < left + width; ++X)
      {
        for (int Y = top; Y < top + height; ++Y)
        {
          back = new Point16(X, Y);
          Tile tile = Main.tile[X, Y];
          if (tile != null && tile.wire())
            Wiring._wireList.PushBack(back);
        }
      }
      Wiring._teleport[0].X = -1f;
      Wiring._teleport[0].Y = -1f;
      Wiring._teleport[1].X = -1f;
      Wiring._teleport[1].Y = -1f;
      if (Wiring._wireList.Count > 0)
      {
        Wiring._numInPump = 0;
        Wiring._numOutPump = 0;
        Wiring.HitWire(Wiring._wireList, 1);
        if (Wiring._numInPump > 0 && Wiring._numOutPump > 0)
          Wiring.XferWater();
      }
      Vector2[] vector2Array2 = vector2Array1;
      int index1 = num1;
      int num2 = index1 + 1;
      Vector2 vector2_1 = Wiring._teleport[0];
      vector2Array2[index1] = vector2_1;
      Vector2[] vector2Array3 = vector2Array1;
      int index2 = num2;
      int num3 = index2 + 1;
      Vector2 vector2_2 = Wiring._teleport[1];
      vector2Array3[index2] = vector2_2;
      for (int X = left; X < left + width; ++X)
      {
        for (int Y = top; Y < top + height; ++Y)
        {
          back = new Point16(X, Y);
          Tile tile = Main.tile[X, Y];
          if (tile != null && tile.wire2())
            Wiring._wireList.PushBack(back);
        }
      }
      Wiring._teleport[0].X = -1f;
      Wiring._teleport[0].Y = -1f;
      Wiring._teleport[1].X = -1f;
      Wiring._teleport[1].Y = -1f;
      if (Wiring._wireList.Count > 0)
      {
        Wiring._numInPump = 0;
        Wiring._numOutPump = 0;
        Wiring.HitWire(Wiring._wireList, 2);
        if (Wiring._numInPump > 0 && Wiring._numOutPump > 0)
          Wiring.XferWater();
      }
      Vector2[] vector2Array4 = vector2Array1;
      int index3 = num3;
      int num4 = index3 + 1;
      Vector2 vector2_3 = Wiring._teleport[0];
      vector2Array4[index3] = vector2_3;
      Vector2[] vector2Array5 = vector2Array1;
      int index4 = num4;
      int num5 = index4 + 1;
      Vector2 vector2_4 = Wiring._teleport[1];
      vector2Array5[index4] = vector2_4;
      Wiring._teleport[0].X = -1f;
      Wiring._teleport[0].Y = -1f;
      Wiring._teleport[1].X = -1f;
      Wiring._teleport[1].Y = -1f;
      for (int X = left; X < left + width; ++X)
      {
        for (int Y = top; Y < top + height; ++Y)
        {
          back = new Point16(X, Y);
          Tile tile = Main.tile[X, Y];
          if (tile != null && tile.wire3())
            Wiring._wireList.PushBack(back);
        }
      }
      if (Wiring._wireList.Count > 0)
      {
        Wiring._numInPump = 0;
        Wiring._numOutPump = 0;
        Wiring.HitWire(Wiring._wireList, 3);
        if (Wiring._numInPump > 0 && Wiring._numOutPump > 0)
          Wiring.XferWater();
      }
      Vector2[] vector2Array6 = vector2Array1;
      int index5 = num5;
      int num6 = index5 + 1;
      Vector2 vector2_5 = Wiring._teleport[0];
      vector2Array6[index5] = vector2_5;
      Vector2[] vector2Array7 = vector2Array1;
      int index6 = num6;
      int num7 = index6 + 1;
      Vector2 vector2_6 = Wiring._teleport[1];
      vector2Array7[index6] = vector2_6;
      Wiring._teleport[0].X = -1f;
      Wiring._teleport[0].Y = -1f;
      Wiring._teleport[1].X = -1f;
      Wiring._teleport[1].Y = -1f;
      for (int X = left; X < left + width; ++X)
      {
        for (int Y = top; Y < top + height; ++Y)
        {
          back = new Point16(X, Y);
          Tile tile = Main.tile[X, Y];
          if (tile != null && tile.wire4())
            Wiring._wireList.PushBack(back);
        }
      }
      if (Wiring._wireList.Count > 0)
      {
        Wiring._numInPump = 0;
        Wiring._numOutPump = 0;
        Wiring.HitWire(Wiring._wireList, 4);
        if (Wiring._numInPump > 0 && Wiring._numOutPump > 0)
          Wiring.XferWater();
      }
      Vector2[] vector2Array8 = vector2Array1;
      int index7 = num7;
      int num8 = index7 + 1;
      Vector2 vector2_7 = Wiring._teleport[0];
      vector2Array8[index7] = vector2_7;
      Vector2[] vector2Array9 = vector2Array1;
      int index8 = num8;
      int num9 = index8 + 1;
      Vector2 vector2_8 = Wiring._teleport[1];
      vector2Array9[index8] = vector2_8;
      Wiring.running = false;
      for (int index9 = 0; index9 < 8; index9 += 2)
      {
        Wiring._teleport[0] = vector2Array1[index9];
        Wiring._teleport[1] = vector2Array1[index9 + 1];
        if ((double) Wiring._teleport[0].X >= 0.0 && (double) Wiring._teleport[1].X >= 0.0)
          Wiring.Teleport();
      }
      Wiring.PixelBoxPass();
      Wiring.LogicGatePass();
    }

    private static void PixelBoxPass()
    {
      foreach (KeyValuePair<Point16, byte> pixelBoxTrigger in Wiring._PixelBoxTriggers)
      {
        if (pixelBoxTrigger.Value != (byte) 2)
        {
          if (pixelBoxTrigger.Value == (byte) 1)
          {
            if (Main.tile[(int) pixelBoxTrigger.Key.X, (int) pixelBoxTrigger.Key.Y].frameX != (short) 0)
            {
              Main.tile[(int) pixelBoxTrigger.Key.X, (int) pixelBoxTrigger.Key.Y].frameX = (short) 0;
              NetMessage.SendTileSquare(-1, (int) pixelBoxTrigger.Key.X, (int) pixelBoxTrigger.Key.Y, 1);
            }
          }
          else if (pixelBoxTrigger.Value == (byte) 3 && Main.tile[(int) pixelBoxTrigger.Key.X, (int) pixelBoxTrigger.Key.Y].frameX != (short) 18)
          {
            Main.tile[(int) pixelBoxTrigger.Key.X, (int) pixelBoxTrigger.Key.Y].frameX = (short) 18;
            NetMessage.SendTileSquare(-1, (int) pixelBoxTrigger.Key.X, (int) pixelBoxTrigger.Key.Y, 1);
          }
        }
      }
      Wiring._PixelBoxTriggers.Clear();
    }

    private static void LogicGatePass()
    {
      if (Wiring._GatesCurrent.Count != 0)
        return;
      Wiring._GatesDone.Clear();
      while (Wiring._LampsToCheck.Count > 0)
      {
        while (Wiring._LampsToCheck.Count > 0)
        {
          Point16 point16 = Wiring._LampsToCheck.Dequeue();
          Wiring.CheckLogicGate((int) point16.X, (int) point16.Y);
        }
        while (Wiring._GatesNext.Count > 0)
        {
          Utils.Swap<Queue<Point16>>(ref Wiring._GatesCurrent, ref Wiring._GatesNext);
          while (Wiring._GatesCurrent.Count > 0)
          {
            Point16 key = Wiring._GatesCurrent.Peek();
            bool flag;
            if (Wiring._GatesDone.TryGetValue(key, out flag) && flag)
            {
              Wiring._GatesCurrent.Dequeue();
            }
            else
            {
              Wiring._GatesDone.Add(key, true);
              Wiring.TripWire((int) key.X, (int) key.Y, 1, 1);
              Wiring._GatesCurrent.Dequeue();
            }
          }
        }
      }
      Wiring._GatesDone.Clear();
      if (!Wiring.blockPlayerTeleportationForOneIteration)
        return;
      Wiring.blockPlayerTeleportationForOneIteration = false;
    }

    private static void CheckLogicGate(int lampX, int lampY)
    {
      if (!WorldGen.InWorld(lampX, lampY, 1))
        return;
      for (int index1 = lampY; index1 < Main.maxTilesY; ++index1)
      {
        Tile tile1 = Main.tile[lampX, index1];
        if (!tile1.active())
          break;
        if (tile1.type == (ushort) 420)
        {
          bool flag1;
          Wiring._GatesDone.TryGetValue(new Point16(lampX, index1), out flag1);
          int num1 = (int) tile1.frameY / 18;
          bool flag2 = tile1.frameX == (short) 18;
          bool flag3 = tile1.frameX == (short) 36;
          if (num1 < 0)
            break;
          int num2 = 0;
          int num3 = 0;
          bool flag4 = false;
          for (int index2 = index1 - 1; index2 > 0; --index2)
          {
            Tile tile2 = Main.tile[lampX, index2];
            if (tile2.active() && tile2.type == (ushort) 419)
            {
              if (tile2.frameX == (short) 36)
              {
                flag4 = true;
                break;
              }
              ++num2;
              num3 += (tile2.frameX == (short) 18).ToInt();
            }
            else
              break;
          }
          bool flag5;
          switch (num1)
          {
            case 0:
              flag5 = num2 == num3;
              break;
            case 1:
              flag5 = num3 > 0;
              break;
            case 2:
              flag5 = num2 != num3;
              break;
            case 3:
              flag5 = num3 == 0;
              break;
            case 4:
              flag5 = num3 == 1;
              break;
            case 5:
              flag5 = num3 != 1;
              break;
            default:
              return;
          }
          bool flag6 = !flag4 & flag3;
          bool flag7 = false;
          if (flag4 && Framing.GetTileSafely(lampX, lampY).frameX == (short) 36)
            flag7 = true;
          if (!(flag5 != flag2 | flag6 | flag7))
            break;
          int num4 = (int) tile1.frameX % 18 / 18;
          tile1.frameX = (short) (18 * flag5.ToInt());
          if (flag4)
            tile1.frameX = (short) 36;
          Wiring.SkipWire(lampX, index1);
          WorldGen.SquareTileFrame(lampX, index1);
          NetMessage.SendTileSquare(-1, lampX, index1, 1);
          bool flag8 = !flag4 | flag7;
          if (flag7)
          {
            if (num3 == 0 || num2 == 0)
              ;
            flag8 = (double) Main.rand.NextFloat() < (double) num3 / (double) num2;
          }
          if (flag6)
            flag8 = false;
          if (!flag8)
            break;
          if (!flag1)
          {
            Wiring._GatesNext.Enqueue(new Point16(lampX, index1));
            break;
          }
          Vector2 position = new Vector2((float) lampX, (float) index1) * 16f - new Vector2(10f);
          Utils.PoofOfSmoke(position);
          NetMessage.SendData(106, number: ((int) position.X), number2: position.Y);
          break;
        }
        if (tile1.type != (ushort) 419)
          break;
      }
    }

    private static void HitWire(DoubleStack<Point16> next, int wireType)
    {
      Wiring._wireDirectionList.Clear(true);
      for (int index = 0; index < next.Count; ++index)
      {
        Point16 point16 = next.PopFront();
        Wiring.SkipWire(point16);
        Wiring._toProcess.Add(point16, (byte) 4);
        next.PushBack(point16);
        Wiring._wireDirectionList.PushBack((byte) 0);
      }
      Wiring._currentWireColor = wireType;
      while (next.Count > 0)
      {
        Point16 key = next.PopFront();
        int num1 = (int) Wiring._wireDirectionList.PopFront();
        int x = (int) key.X;
        int y = (int) key.Y;
        if (!Wiring._wireSkip.ContainsKey(key))
          Wiring.HitWireSingle(x, y);
        for (int index = 0; index < 4; ++index)
        {
          int X;
          int Y;
          switch (index)
          {
            case 0:
              X = x;
              Y = y + 1;
              break;
            case 1:
              X = x;
              Y = y - 1;
              break;
            case 2:
              X = x + 1;
              Y = y;
              break;
            case 3:
              X = x - 1;
              Y = y;
              break;
            default:
              X = x;
              Y = y + 1;
              break;
          }
          if (X >= 2 && X < Main.maxTilesX - 2 && Y >= 2 && Y < Main.maxTilesY - 2)
          {
            Tile tile1 = Main.tile[X, Y];
            if (tile1 != null)
            {
              Tile tile2 = Main.tile[x, y];
              if (tile2 != null)
              {
                byte num2 = 3;
                if (tile1.type == (ushort) 424 || tile1.type == (ushort) 445)
                  num2 = (byte) 0;
                if (tile2.type == (ushort) 424)
                {
                  switch ((int) tile2.frameX / 18)
                  {
                    case 0:
                      if (index == num1)
                        break;
                      continue;
                    case 1:
                      if (num1 == 0 && index == 3 || num1 == 3 && index == 0 || num1 == 1 && index == 2 || num1 == 2 && index == 1)
                        break;
                      continue;
                    case 2:
                      if (num1 == 0 && index == 2 || num1 == 2 && index == 0 || num1 == 1 && index == 3 || num1 == 3 && index == 1)
                        break;
                      continue;
                  }
                }
                if (tile2.type == (ushort) 445)
                {
                  if (index == num1)
                  {
                    if (Wiring._PixelBoxTriggers.ContainsKey(key))
                      Wiring._PixelBoxTriggers[key] |= index == 0 | index == 1 ? (byte) 2 : (byte) 1;
                    else
                      Wiring._PixelBoxTriggers[key] = index == 0 | index == 1 ? (byte) 2 : (byte) 1;
                  }
                  else
                    continue;
                }
                bool flag;
                switch (wireType)
                {
                  case 1:
                    flag = tile1.wire();
                    break;
                  case 2:
                    flag = tile1.wire2();
                    break;
                  case 3:
                    flag = tile1.wire3();
                    break;
                  case 4:
                    flag = tile1.wire4();
                    break;
                  default:
                    flag = false;
                    break;
                }
                if (flag)
                {
                  Point16 point16 = new Point16(X, Y);
                  byte num3;
                  if (Wiring._toProcess.TryGetValue(point16, out num3))
                  {
                    --num3;
                    if (num3 == (byte) 0)
                      Wiring._toProcess.Remove(point16);
                    else
                      Wiring._toProcess[point16] = num3;
                  }
                  else
                  {
                    next.PushBack(point16);
                    Wiring._wireDirectionList.PushBack((byte) index);
                    if (num2 > (byte) 0)
                      Wiring._toProcess.Add(point16, num2);
                  }
                }
              }
            }
          }
        }
      }
      Wiring._wireSkip.Clear();
      Wiring._toProcess.Clear();
    }

    private static void HitWireSingle(int i, int j)
    {
      Tile tile1 = Main.tile[i, j];
      int type = (int) tile1.type;
      if (tile1.actuator())
        Wiring.ActuateForced(i, j);
      if (!tile1.active())
        return;
      switch (type)
      {
        case 144:
          Wiring.HitSwitch(i, j);
          WorldGen.SquareTileFrame(i, j);
          NetMessage.SendTileSquare(-1, i, j, 1);
          break;
        case 421:
          if (!tile1.actuator())
          {
            tile1.type = (ushort) 422;
            WorldGen.SquareTileFrame(i, j);
            NetMessage.SendTileSquare(-1, i, j, 1);
            break;
          }
          break;
        default:
          if (type == 422 && !tile1.actuator())
          {
            tile1.type = (ushort) 421;
            WorldGen.SquareTileFrame(i, j);
            NetMessage.SendTileSquare(-1, i, j, 1);
            break;
          }
          break;
      }
      if (type >= (int) byte.MaxValue && type <= 268)
      {
        if (tile1.actuator())
          return;
        if (type >= 262)
          tile1.type -= (ushort) 7;
        else
          tile1.type += (ushort) 7;
        WorldGen.SquareTileFrame(i, j);
        NetMessage.SendTileSquare(-1, i, j, 1);
      }
      else
      {
        switch (type)
        {
          case 130:
            if (Main.tile[i, j - 1] != null && Main.tile[i, j - 1].active() && (TileID.Sets.BasicChest[(int) Main.tile[i, j - 1].type] || TileID.Sets.BasicChestFake[(int) Main.tile[i, j - 1].type] || Main.tile[i, j - 1].type == (ushort) 88))
              break;
            tile1.type = (ushort) 131;
            WorldGen.SquareTileFrame(i, j);
            NetMessage.SendTileSquare(-1, i, j, 1);
            break;
          case 131:
            tile1.type = (ushort) 130;
            WorldGen.SquareTileFrame(i, j);
            NetMessage.SendTileSquare(-1, i, j, 1);
            break;
          case 209:
            int num1 = (int) tile1.frameX % 72 / 18;
            int num2 = (int) tile1.frameY % 54 / 18;
            int num3 = i - num1;
            int num4 = j - num2;
            int angle = (int) tile1.frameY / 54;
            int num5 = (int) tile1.frameX / 72;
            int num6 = -1;
            if (num1 == 1 || num1 == 2)
              num6 = num2;
            int num7 = 0;
            if (num1 == 3)
              num7 = -54;
            if (num1 == 0)
              num7 = 54;
            if (angle >= 8 && num7 > 0)
              num7 = 0;
            if (angle == 0 && num7 < 0)
              num7 = 0;
            bool flag1 = false;
            if (num7 != 0)
            {
              for (int x = num3; x < num3 + 4; ++x)
              {
                for (int y = num4; y < num4 + 3; ++y)
                {
                  Wiring.SkipWire(x, y);
                  Main.tile[x, y].frameY += (short) num7;
                }
              }
              flag1 = true;
            }
            if ((num5 == 3 || num5 == 4) && (num6 == 0 || num6 == 1))
            {
              int num8 = num5 == 3 ? 72 : -72;
              for (int x = num3; x < num3 + 4; ++x)
              {
                for (int y = num4; y < num4 + 3; ++y)
                {
                  Wiring.SkipWire(x, y);
                  Main.tile[x, y].frameX += (short) num8;
                }
              }
              flag1 = true;
            }
            if (flag1)
              NetMessage.SendTileSquare(-1, num3 + 1, num4 + 1, 4);
            if (num6 == -1)
              break;
            bool flag2 = true;
            if ((num5 == 3 || num5 == 4) && num6 < 2)
              flag2 = false;
            if (!(Wiring.CheckMech(num3, num4, 30) & flag2))
              break;
            WorldGen.ShootFromCannon(num3, num4, angle, num5 + 1, 0, 0.0f, Wiring.CurrentUser);
            break;
          case 212:
            int num9 = (int) tile1.frameX % 54 / 18;
            int num10 = (int) tile1.frameY % 54 / 18;
            int i1 = i - num9;
            int j1 = j - num10;
            int num11 = (int) tile1.frameX / 54;
            int num12 = -1;
            if (num9 == 1)
              num12 = num10;
            int num13 = 0;
            if (num9 == 0)
              num13 = -54;
            if (num9 == 2)
              num13 = 54;
            if (num11 >= 1 && num13 > 0)
              num13 = 0;
            if (num11 == 0 && num13 < 0)
              num13 = 0;
            bool flag3 = false;
            if (num13 != 0)
            {
              for (int x = i1; x < i1 + 3; ++x)
              {
                for (int y = j1; y < j1 + 3; ++y)
                {
                  Wiring.SkipWire(x, y);
                  Main.tile[x, y].frameX += (short) num13;
                }
              }
              flag3 = true;
            }
            if (flag3)
              NetMessage.SendTileSquare(-1, i1 + 1, j1 + 1, 4);
            if (num12 == -1 || !Wiring.CheckMech(i1, j1, 10))
              break;
            double num14 = 12.0 + (double) Main.rand.Next(450) * 0.00999999977648258;
            float num15 = (float) Main.rand.Next(85, 105);
            double num16 = (double) Main.rand.Next(-35, 11);
            int Type1 = 166;
            int Damage1 = 0;
            float KnockBack1 = 0.0f;
            Vector2 vector2_1 = new Vector2((float) ((i1 + 2) * 16 - 8), (float) ((j1 + 2) * 16 - 8));
            if ((int) tile1.frameX / 54 == 0)
            {
              num15 *= -1f;
              vector2_1.X -= 12f;
            }
            else
              vector2_1.X += 12f;
            float num17 = num15;
            float num18 = (float) num16;
            double num19 = Math.Sqrt((double) num17 * (double) num17 + (double) num18 * (double) num18);
            float num20 = (float) (num14 / num19);
            float SpeedX1 = num17 * num20;
            float SpeedY1 = num18 * num20;
            Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX1, SpeedY1, Type1, Damage1, KnockBack1, Wiring.CurrentUser);
            break;
          case 215:
            int num21 = (int) tile1.frameX % 54 / 18;
            int num22 = (int) tile1.frameY % 36 / 18;
            int index1 = i - num21;
            int index2 = j - num22;
            int num23 = 36;
            if (Main.tile[index1, index2].frameY >= (short) 36)
              num23 = -36;
            for (int x = index1; x < index1 + 3; ++x)
            {
              for (int y = index2; y < index2 + 2; ++y)
              {
                Wiring.SkipWire(x, y);
                Main.tile[x, y].frameY += (short) num23;
              }
            }
            NetMessage.SendTileSquare(-1, index1 + 1, index2 + 1, 3);
            break;
          case 405:
            int num24 = (int) tile1.frameX % 54 / 18;
            int num25 = (int) tile1.frameY % 36 / 18;
            int index3 = i - num24;
            int index4 = j - num25;
            int num26 = 54;
            if (Main.tile[index3, index4].frameX >= (short) 54)
              num26 = -54;
            for (int x = index3; x < index3 + 3; ++x)
            {
              for (int y = index4; y < index4 + 2; ++y)
              {
                Wiring.SkipWire(x, y);
                Main.tile[x, y].frameX += (short) num26;
              }
            }
            NetMessage.SendTileSquare(-1, index3 + 1, index4 + 1, 3);
            break;
          case 406:
            int num27 = (int) tile1.frameX % 54 / 18;
            int num28 = (int) tile1.frameY % 54 / 18;
            int index5 = i - num27;
            int index6 = j - num28;
            int num29 = 54;
            if (Main.tile[index5, index6].frameY >= (short) 108)
              num29 = -108;
            for (int x = index5; x < index5 + 3; ++x)
            {
              for (int y = index6; y < index6 + 3; ++y)
              {
                Wiring.SkipWire(x, y);
                Main.tile[x, y].frameY += (short) num29;
              }
            }
            NetMessage.SendTileSquare(-1, index5 + 1, index6 + 1, 3);
            break;
          case 411:
            int num30 = (int) tile1.frameX % 36 / 18;
            int num31 = (int) tile1.frameY % 36 / 18;
            int tileX = i - num30;
            int tileY = j - num31;
            int num32 = 36;
            if (Main.tile[tileX, tileY].frameX >= (short) 36)
              num32 = -36;
            for (int x = tileX; x < tileX + 2; ++x)
            {
              for (int y = tileY; y < tileY + 2; ++y)
              {
                Wiring.SkipWire(x, y);
                Main.tile[x, y].frameX += (short) num32;
              }
            }
            NetMessage.SendTileSquare(-1, tileX, tileY, 2);
            break;
          case 419:
            int num33 = 18;
            if ((int) tile1.frameX >= num33)
              num33 = -num33;
            if (tile1.frameX == (short) 36)
              num33 = 0;
            Wiring.SkipWire(i, j);
            tile1.frameX += (short) num33;
            WorldGen.SquareTileFrame(i, j);
            NetMessage.SendTileSquare(-1, i, j, 1);
            Wiring._LampsToCheck.Enqueue(new Point16(i, j));
            break;
          case 425:
            int num34 = (int) tile1.frameX % 36 / 18;
            int num35 = (int) tile1.frameY % 36 / 18;
            int i2 = i - num34;
            int j2 = j - num35;
            for (int x = i2; x < i2 + 2; ++x)
            {
              for (int y = j2; y < j2 + 2; ++y)
                Wiring.SkipWire(x, y);
            }
            if (Main.AnnouncementBoxDisabled)
              break;
            Color pink = Color.Pink;
            int index7 = Sign.ReadSign(i2, j2, false);
            if (index7 == -1 || Main.sign[index7] == null || string.IsNullOrWhiteSpace(Main.sign[index7].text))
              break;
            if (Main.AnnouncementBoxRange == -1)
            {
              if (Main.netMode == 0)
              {
                Main.NewTextMultiline(Main.sign[index7].text, c: pink, WidthLimit: 460);
                break;
              }
              if (Main.netMode != 2)
                break;
              NetMessage.SendData(107, text: NetworkText.FromLiteral(Main.sign[index7].text), number: ((int) byte.MaxValue), number2: ((float) pink.R), number3: ((float) pink.G), number4: ((float) pink.B), number5: 460);
              break;
            }
            switch (Main.netMode)
            {
              case 0:
                if ((double) Main.player[Main.myPlayer].Distance(new Vector2((float) (i2 * 16 + 16), (float) (j2 * 16 + 16))) > (double) Main.AnnouncementBoxRange)
                  return;
                Main.NewTextMultiline(Main.sign[index7].text, c: pink, WidthLimit: 460);
                return;
              case 2:
                for (int remoteClient = 0; remoteClient < (int) byte.MaxValue; ++remoteClient)
                {
                  if (Main.player[remoteClient].active && (double) Main.player[remoteClient].Distance(new Vector2((float) (i2 * 16 + 16), (float) (j2 * 16 + 16))) <= (double) Main.AnnouncementBoxRange)
                    NetMessage.SendData(107, remoteClient, text: NetworkText.FromLiteral(Main.sign[index7].text), number: ((int) byte.MaxValue), number2: ((float) pink.R), number3: ((float) pink.G), number4: ((float) pink.B), number5: 460);
                }
                return;
              default:
                return;
            }
          case 452:
            int num36 = (int) tile1.frameX % 54 / 18;
            int num37 = (int) tile1.frameY % 54 / 18;
            int index8 = i - num36;
            int index9 = j - num37;
            int num38 = 54;
            if (Main.tile[index8, index9].frameX >= (short) 54)
              num38 = -54;
            for (int x = index8; x < index8 + 3; ++x)
            {
              for (int y = index9; y < index9 + 3; ++y)
              {
                Wiring.SkipWire(x, y);
                Main.tile[x, y].frameX += (short) num38;
              }
            }
            NetMessage.SendTileSquare(-1, index8 + 1, index9 + 1, 3);
            break;
          default:
            if (type == 387 || type == 386)
            {
              bool flag4 = type == 387;
              int num39 = WorldGen.ShiftTrapdoor(i, j, true).ToInt();
              if (num39 == 0)
                num39 = -WorldGen.ShiftTrapdoor(i, j, false).ToInt();
              if (num39 == 0)
                break;
              NetMessage.SendData(19, number: (3 - flag4.ToInt()), number2: ((float) i), number3: ((float) j), number4: ((float) num39));
              break;
            }
            if (type == 389 || type == 388)
            {
              bool closing = type == 389;
              WorldGen.ShiftTallGate(i, j, closing);
              NetMessage.SendData(19, number: (4 + closing.ToInt()), number2: ((float) i), number3: ((float) j));
              break;
            }
            switch (type)
            {
              case 10:
                int direction = 1;
                if (Main.rand.Next(2) == 0)
                  direction = -1;
                if (!WorldGen.OpenDoor(i, j, direction))
                {
                  if (!WorldGen.OpenDoor(i, j, -direction))
                    return;
                  NetMessage.SendData(19, number2: ((float) i), number3: ((float) j), number4: ((float) -direction));
                  return;
                }
                NetMessage.SendData(19, number2: ((float) i), number3: ((float) j), number4: ((float) direction));
                return;
              case 11:
                if (!WorldGen.CloseDoor(i, j, true))
                  return;
                NetMessage.SendData(19, number: 1, number2: ((float) i), number3: ((float) j));
                return;
              case 216:
                WorldGen.LaunchRocket(i, j);
                Wiring.SkipWire(i, j);
                return;
              default:
                if (type == 497 || type == 15 && (int) tile1.frameY / 40 == 1 || type == 15 && (int) tile1.frameY / 40 == 20)
                {
                  int num40 = j - (int) tile1.frameY % 40 / 18;
                  int num41 = i;
                  Wiring.SkipWire(num41, num40);
                  Wiring.SkipWire(num41, num40 + 1);
                  if (!Wiring.CheckMech(num41, num40, 60))
                    return;
                  Projectile.NewProjectile((float) (num41 * 16 + 8), (float) (num40 * 16 + 12), 0.0f, 0.0f, 733, 0, 0.0f, Main.myPlayer);
                  return;
                }
                switch (type)
                {
                  case 4:
                    if (tile1.frameX < (short) 66)
                      tile1.frameX += (short) 66;
                    else
                      tile1.frameX -= (short) 66;
                    NetMessage.SendTileSquare(-1, i, j, 1);
                    return;
                  case 42:
                    int num42 = (int) tile1.frameY / 18;
                    while (num42 >= 2)
                      num42 -= 2;
                    int y1 = j - num42;
                    short num43 = 18;
                    if (tile1.frameX > (short) 0)
                      num43 = (short) -18;
                    Main.tile[i, y1].frameX += num43;
                    Main.tile[i, y1 + 1].frameX += num43;
                    Wiring.SkipWire(i, y1);
                    Wiring.SkipWire(i, y1 + 1);
                    NetMessage.SendTileSquare(-1, i, j, 3);
                    return;
                  case 93:
                    int num44 = (int) tile1.frameY / 18;
                    while (num44 >= 3)
                      num44 -= 3;
                    int y2 = j - num44;
                    short num45 = 18;
                    if (tile1.frameX > (short) 0)
                      num45 = (short) -18;
                    Main.tile[i, y2].frameX += num45;
                    Main.tile[i, y2 + 1].frameX += num45;
                    Main.tile[i, y2 + 2].frameX += num45;
                    Wiring.SkipWire(i, y2);
                    Wiring.SkipWire(i, y2 + 1);
                    Wiring.SkipWire(i, y2 + 2);
                    NetMessage.SendTileSquare(-1, i, y2 + 1, 3);
                    return;
                  case 149:
                    if (tile1.frameX < (short) 54)
                      tile1.frameX += (short) 54;
                    else
                      tile1.frameX -= (short) 54;
                    NetMessage.SendTileSquare(-1, i, j, 1);
                    return;
                  case 235:
                    int num46 = i - (int) tile1.frameX / 18;
                    if (tile1.wall == (ushort) 87 && (double) j > Main.worldSurface && !NPC.downedPlantBoss)
                      return;
                    if ((double) Wiring._teleport[0].X == -1.0)
                    {
                      Wiring._teleport[0].X = (float) num46;
                      Wiring._teleport[0].Y = (float) j;
                      if (!tile1.halfBrick())
                        return;
                      Wiring._teleport[0].Y += 0.5f;
                      return;
                    }
                    if ((double) Wiring._teleport[0].X == (double) num46 && (double) Wiring._teleport[0].Y == (double) j)
                      return;
                    Wiring._teleport[1].X = (float) num46;
                    Wiring._teleport[1].Y = (float) j;
                    if (!tile1.halfBrick())
                      return;
                    Wiring._teleport[1].Y += 0.5f;
                    return;
                  case 244:
                    int num47 = (int) tile1.frameX / 18;
                    while (num47 >= 3)
                      num47 -= 3;
                    int num48 = (int) tile1.frameY / 18;
                    while (num48 >= 3)
                      num48 -= 3;
                    int index10 = i - num47;
                    int index11 = j - num48;
                    int num49 = 54;
                    if (Main.tile[index10, index11].frameX >= (short) 54)
                      num49 = -54;
                    for (int x = index10; x < index10 + 3; ++x)
                    {
                      for (int y3 = index11; y3 < index11 + 2; ++y3)
                      {
                        Wiring.SkipWire(x, y3);
                        Main.tile[x, y3].frameX += (short) num49;
                      }
                    }
                    NetMessage.SendTileSquare(-1, index10 + 1, index11 + 1, 3);
                    return;
                  case 335:
                    int num50 = j - (int) tile1.frameY / 18;
                    int num51 = i - (int) tile1.frameX / 18;
                    Wiring.SkipWire(num51, num50);
                    Wiring.SkipWire(num51, num50 + 1);
                    Wiring.SkipWire(num51 + 1, num50);
                    Wiring.SkipWire(num51 + 1, num50 + 1);
                    if (!Wiring.CheckMech(num51, num50, 30))
                      return;
                    WorldGen.LaunchRocketSmall(num51, num50);
                    return;
                  case 338:
                    int num52 = j - (int) tile1.frameY / 18;
                    int num53 = i - (int) tile1.frameX / 18;
                    Wiring.SkipWire(num53, num52);
                    Wiring.SkipWire(num53, num52 + 1);
                    if (!Wiring.CheckMech(num53, num52, 30))
                      return;
                    bool flag5 = false;
                    for (int index12 = 0; index12 < 1000; ++index12)
                    {
                      if (Main.projectile[index12].active && Main.projectile[index12].aiStyle == 73 && (double) Main.projectile[index12].ai[0] == (double) num53 && (double) Main.projectile[index12].ai[1] == (double) num52)
                      {
                        flag5 = true;
                        break;
                      }
                    }
                    if (flag5)
                      return;
                    Projectile.NewProjectile((float) (num53 * 16 + 8), (float) (num52 * 16 + 2), 0.0f, 0.0f, 419 + Main.rand.Next(4), 0, 0.0f, Main.myPlayer, (float) num53, (float) num52);
                    return;
                  case 429:
                    int num54 = (int) Main.tile[i, j].frameX / 18;
                    bool flag6 = num54 % 2 >= 1;
                    bool flag7 = num54 % 4 >= 2;
                    bool flag8 = num54 % 8 >= 4;
                    bool flag9 = num54 % 16 >= 8;
                    bool flag10 = false;
                    short num55 = 0;
                    switch (Wiring._currentWireColor)
                    {
                      case 1:
                        num55 = (short) 18;
                        flag10 = !flag6;
                        break;
                      case 2:
                        num55 = (short) 72;
                        flag10 = !flag8;
                        break;
                      case 3:
                        num55 = (short) 36;
                        flag10 = !flag7;
                        break;
                      case 4:
                        num55 = (short) 144;
                        flag10 = !flag9;
                        break;
                    }
                    if (flag10)
                      tile1.frameX += num55;
                    else
                      tile1.frameX -= num55;
                    NetMessage.SendTileSquare(-1, i, j, 1);
                    return;
                  case 565:
                    int num56 = (int) tile1.frameX / 18;
                    while (num56 >= 2)
                      num56 -= 2;
                    int num57 = (int) tile1.frameY / 18;
                    while (num57 >= 2)
                      num57 -= 2;
                    int index13 = i - num56;
                    int index14 = j - num57;
                    int num58 = 36;
                    if (Main.tile[index13, index14].frameX >= (short) 36)
                      num58 = -36;
                    for (int x = index13; x < index13 + 2; ++x)
                    {
                      for (int y4 = index14; y4 < index14 + 2; ++y4)
                      {
                        Wiring.SkipWire(x, y4);
                        Main.tile[x, y4].frameX += (short) num58;
                      }
                    }
                    NetMessage.SendTileSquare(-1, index13 + 1, index14 + 1, 3);
                    return;
                  default:
                    if (type == 126 || type == 95 || type == 100 || type == 173 || type == 564)
                    {
                      int num59 = (int) tile1.frameY / 18;
                      while (num59 >= 2)
                        num59 -= 2;
                      int index15 = j - num59;
                      int num60 = (int) tile1.frameX / 18;
                      if (num60 > 1)
                        num60 -= 2;
                      int index16 = i - num60;
                      short num61 = 36;
                      if (Main.tile[index16, index15].frameX > (short) 0)
                        num61 = (short) -36;
                      Main.tile[index16, index15].frameX += num61;
                      Main.tile[index16, index15 + 1].frameX += num61;
                      Main.tile[index16 + 1, index15].frameX += num61;
                      Main.tile[index16 + 1, index15 + 1].frameX += num61;
                      Wiring.SkipWire(index16, index15);
                      Wiring.SkipWire(index16 + 1, index15);
                      Wiring.SkipWire(index16, index15 + 1);
                      Wiring.SkipWire(index16 + 1, index15 + 1);
                      NetMessage.SendTileSquare(-1, index16, index15, 3);
                      return;
                    }
                    switch (type)
                    {
                      case 34:
                        int num62 = (int) tile1.frameY / 18;
                        while (num62 >= 3)
                          num62 -= 3;
                        int index17 = j - num62;
                        int num63 = (int) tile1.frameX % 108 / 18;
                        if (num63 > 2)
                          num63 -= 3;
                        int index18 = i - num63;
                        short num64 = 54;
                        if ((int) Main.tile[index18, index17].frameX % 108 > 0)
                          num64 = (short) -54;
                        for (int x = index18; x < index18 + 3; ++x)
                        {
                          for (int y5 = index17; y5 < index17 + 3; ++y5)
                          {
                            Main.tile[x, y5].frameX += num64;
                            Wiring.SkipWire(x, y5);
                          }
                        }
                        NetMessage.SendTileSquare(-1, index18 + 1, index17 + 1, 3);
                        return;
                      case 314:
                        if (!Wiring.CheckMech(i, j, 5))
                          return;
                        Minecart.FlipSwitchTrack(i, j);
                        return;
                      case 593:
                        int index19 = i;
                        int index20 = j;
                        Wiring.SkipWire(index19, index20);
                        short num65 = Main.tile[index19, index20].frameX != (short) 0 ? (short) -18 : (short) 18;
                        Main.tile[index19, index20].frameX += num65;
                        if (Main.netMode == 2)
                          NetMessage.SendTileRange(-1, index19, index20, 1, 1);
                        int num66 = num65 > (short) 0 ? 4 : 3;
                        Animation.NewTemporaryAnimation(num66, (ushort) 593, index19, index20);
                        NetMessage.SendTemporaryAnimation(-1, num66, 593, index19, index20);
                        return;
                      case 594:
                        int num67 = (int) tile1.frameY / 18;
                        while (num67 >= 2)
                          num67 -= 2;
                        int index21 = j - num67;
                        int num68 = (int) tile1.frameX / 18;
                        if (num68 > 1)
                          num68 -= 2;
                        int index22 = i - num68;
                        Wiring.SkipWire(index22, index21);
                        Wiring.SkipWire(index22, index21 + 1);
                        Wiring.SkipWire(index22 + 1, index21);
                        Wiring.SkipWire(index22 + 1, index21 + 1);
                        short num69 = Main.tile[index22, index21].frameX != (short) 0 ? (short) -36 : (short) 36;
                        for (int index23 = 0; index23 < 2; ++index23)
                        {
                          for (int index24 = 0; index24 < 2; ++index24)
                            Main.tile[index22 + index23, index21 + index24].frameX += num69;
                        }
                        if (Main.netMode == 2)
                          NetMessage.SendTileRange(-1, index22, index21, 2, 2);
                        int num70 = num69 > (short) 0 ? 4 : 3;
                        Animation.NewTemporaryAnimation(num70, (ushort) 594, index22, index21);
                        NetMessage.SendTemporaryAnimation(-1, num70, 594, index22, index21);
                        return;
                      default:
                        if (type == 33 || type == 174 || type == 49 || type == 372)
                        {
                          short num71 = 18;
                          if (tile1.frameX > (short) 0)
                            num71 = (short) -18;
                          tile1.frameX += num71;
                          NetMessage.SendTileSquare(-1, i, j, 3);
                          return;
                        }
                        switch (type)
                        {
                          case 92:
                            int num72 = j - (int) tile1.frameY / 18;
                            short num73 = 18;
                            if (tile1.frameX > (short) 0)
                              num73 = (short) -18;
                            for (int y6 = num72; y6 < num72 + 6; ++y6)
                            {
                              Main.tile[i, y6].frameX += num73;
                              Wiring.SkipWire(i, y6);
                            }
                            NetMessage.SendTileSquare(-1, i, num72 + 3, 7);
                            return;
                          case 137:
                            int num74 = (int) tile1.frameY / 18;
                            Vector2 vector2_2 = Vector2.Zero;
                            float SpeedX2 = 0.0f;
                            float SpeedY2 = 0.0f;
                            int Type2 = 0;
                            int Damage2 = 0;
                            switch (num74)
                            {
                              case 0:
                              case 1:
                              case 2:
                                if (Wiring.CheckMech(i, j, 200))
                                {
                                  int num75 = tile1.frameX == (short) 0 ? -1 : (tile1.frameX == (short) 18 ? 1 : 0);
                                  int num76 = tile1.frameX < (short) 36 ? 0 : (tile1.frameX < (short) 72 ? -1 : 1);
                                  vector2_2 = new Vector2((float) (i * 16 + 8 + 10 * num75), (float) (j * 16 + 8 + 10 * num76));
                                  float num77 = 3f;
                                  if (num74 == 0)
                                  {
                                    Type2 = 98;
                                    Damage2 = 20;
                                    num77 = 12f;
                                  }
                                  if (num74 == 1)
                                  {
                                    Type2 = 184;
                                    Damage2 = 40;
                                    num77 = 12f;
                                  }
                                  if (num74 == 2)
                                  {
                                    Type2 = 187;
                                    Damage2 = 40;
                                    num77 = 5f;
                                  }
                                  SpeedX2 = (float) num75 * num77;
                                  SpeedY2 = (float) num76 * num77;
                                  break;
                                }
                                break;
                              case 3:
                                if (Wiring.CheckMech(i, j, 300))
                                {
                                  int num78 = 200;
                                  for (int index25 = 0; index25 < 1000; ++index25)
                                  {
                                    if (Main.projectile[index25].active && Main.projectile[index25].type == Type2)
                                    {
                                      float num79 = (new Vector2((float) (i * 16 + 8), (float) (j * 18 + 8)) - Main.projectile[index25].Center).Length();
                                      if ((double) num79 < 50.0)
                                        num78 -= 50;
                                      else if ((double) num79 < 100.0)
                                        num78 -= 15;
                                      else if ((double) num79 < 200.0)
                                        num78 -= 10;
                                      else if ((double) num79 < 300.0)
                                        num78 -= 8;
                                      else if ((double) num79 < 400.0)
                                        num78 -= 6;
                                      else if ((double) num79 < 500.0)
                                        num78 -= 5;
                                      else if ((double) num79 < 700.0)
                                        num78 -= 4;
                                      else if ((double) num79 < 900.0)
                                        num78 -= 3;
                                      else if ((double) num79 < 1200.0)
                                        num78 -= 2;
                                      else
                                        --num78;
                                    }
                                  }
                                  if (num78 > 0)
                                  {
                                    Type2 = 185;
                                    Damage2 = 40;
                                    int num80 = 0;
                                    int num81 = 0;
                                    switch ((int) tile1.frameX / 18)
                                    {
                                      case 0:
                                      case 1:
                                        num80 = 0;
                                        num81 = 1;
                                        break;
                                      case 2:
                                        num80 = 0;
                                        num81 = -1;
                                        break;
                                      case 3:
                                        num80 = -1;
                                        num81 = 0;
                                        break;
                                      case 4:
                                        num80 = 1;
                                        num81 = 0;
                                        break;
                                    }
                                    SpeedX2 = (float) (4 * num80) + (float) Main.rand.Next((num80 == 1 ? 20 : 0) - 20, 21 - (num80 == -1 ? 20 : 0)) * 0.05f;
                                    SpeedY2 = (float) (4 * num81) + (float) Main.rand.Next((num81 == 1 ? 20 : 0) - 20, 21 - (num81 == -1 ? 20 : 0)) * 0.05f;
                                    vector2_2 = new Vector2((float) (i * 16 + 8 + 14 * num80), (float) (j * 16 + 8 + 14 * num81));
                                    break;
                                  }
                                  break;
                                }
                                break;
                              case 4:
                                if (Wiring.CheckMech(i, j, 90))
                                {
                                  int num82 = 0;
                                  int num83 = 0;
                                  switch ((int) tile1.frameX / 18)
                                  {
                                    case 0:
                                    case 1:
                                      num82 = 0;
                                      num83 = 1;
                                      break;
                                    case 2:
                                      num82 = 0;
                                      num83 = -1;
                                      break;
                                    case 3:
                                      num82 = -1;
                                      num83 = 0;
                                      break;
                                    case 4:
                                      num82 = 1;
                                      num83 = 0;
                                      break;
                                  }
                                  SpeedX2 = (float) (8 * num82);
                                  SpeedY2 = (float) (8 * num83);
                                  Damage2 = 60;
                                  Type2 = 186;
                                  vector2_2 = new Vector2((float) (i * 16 + 8 + 18 * num82), (float) (j * 16 + 8 + 18 * num83));
                                  break;
                                }
                                break;
                            }
                            switch (num74 + 10)
                            {
                              case 0:
                                if (Wiring.CheckMech(i, j, 200))
                                {
                                  int num84 = -1;
                                  if (tile1.frameX != (short) 0)
                                    num84 = 1;
                                  SpeedX2 = (float) (12 * num84);
                                  Damage2 = 20;
                                  Type2 = 98;
                                  vector2_2 = new Vector2((float) (i * 16 + 8), (float) (j * 16 + 7));
                                  vector2_2.X += (float) (10 * num84);
                                  vector2_2.Y += 2f;
                                  break;
                                }
                                break;
                              case 1:
                                if (Wiring.CheckMech(i, j, 200))
                                {
                                  int num85 = -1;
                                  if (tile1.frameX != (short) 0)
                                    num85 = 1;
                                  SpeedX2 = (float) (12 * num85);
                                  Damage2 = 40;
                                  Type2 = 184;
                                  vector2_2 = new Vector2((float) (i * 16 + 8), (float) (j * 16 + 7));
                                  vector2_2.X += (float) (10 * num85);
                                  vector2_2.Y += 2f;
                                  break;
                                }
                                break;
                              case 2:
                                if (Wiring.CheckMech(i, j, 200))
                                {
                                  int num86 = -1;
                                  if (tile1.frameX != (short) 0)
                                    num86 = 1;
                                  SpeedX2 = (float) (5 * num86);
                                  Damage2 = 40;
                                  Type2 = 187;
                                  vector2_2 = new Vector2((float) (i * 16 + 8), (float) (j * 16 + 7));
                                  vector2_2.X += (float) (10 * num86);
                                  vector2_2.Y += 2f;
                                  break;
                                }
                                break;
                              case 3:
                                if (Wiring.CheckMech(i, j, 300))
                                {
                                  Type2 = 185;
                                  int num87 = 200;
                                  for (int index26 = 0; index26 < 1000; ++index26)
                                  {
                                    if (Main.projectile[index26].active && Main.projectile[index26].type == Type2)
                                    {
                                      float num88 = (new Vector2((float) (i * 16 + 8), (float) (j * 18 + 8)) - Main.projectile[index26].Center).Length();
                                      if ((double) num88 < 50.0)
                                        num87 -= 50;
                                      else if ((double) num88 < 100.0)
                                        num87 -= 15;
                                      else if ((double) num88 < 200.0)
                                        num87 -= 10;
                                      else if ((double) num88 < 300.0)
                                        num87 -= 8;
                                      else if ((double) num88 < 400.0)
                                        num87 -= 6;
                                      else if ((double) num88 < 500.0)
                                        num87 -= 5;
                                      else if ((double) num88 < 700.0)
                                        num87 -= 4;
                                      else if ((double) num88 < 900.0)
                                        num87 -= 3;
                                      else if ((double) num88 < 1200.0)
                                        num87 -= 2;
                                      else
                                        --num87;
                                    }
                                  }
                                  if (num87 > 0)
                                  {
                                    SpeedX2 = (float) Main.rand.Next(-20, 21) * 0.05f;
                                    SpeedY2 = (float) (4.0 + (double) Main.rand.Next(0, 21) * 0.0500000007450581);
                                    Damage2 = 40;
                                    vector2_2 = new Vector2((float) (i * 16 + 8), (float) (j * 16 + 16));
                                    vector2_2.Y += 6f;
                                    Projectile.NewProjectile((float) (int) vector2_2.X, (float) (int) vector2_2.Y, SpeedX2, SpeedY2, Type2, Damage2, 2f, Main.myPlayer);
                                    break;
                                  }
                                  break;
                                }
                                break;
                              case 4:
                                if (Wiring.CheckMech(i, j, 90))
                                {
                                  SpeedX2 = 0.0f;
                                  SpeedY2 = 8f;
                                  Damage2 = 60;
                                  Type2 = 186;
                                  vector2_2 = new Vector2((float) (i * 16 + 8), (float) (j * 16 + 16));
                                  vector2_2.Y += 10f;
                                  break;
                                }
                                break;
                            }
                            if (Type2 == 0)
                              return;
                            Projectile.NewProjectile((float) (int) vector2_2.X, (float) (int) vector2_2.Y, SpeedX2, SpeedY2, Type2, Damage2, 2f, Main.myPlayer);
                            return;
                          case 443:
                            Wiring.GeyserTrap(i, j);
                            return;
                          case 531:
                            int num89 = (int) tile1.frameX / 36;
                            int num90 = (int) tile1.frameY / 54;
                            int i3 = i - ((int) tile1.frameX - num89 * 36) / 18;
                            int j3 = j - ((int) tile1.frameY - num90 * 54) / 18;
                            if (!Wiring.CheckMech(i3, j3, 900))
                              return;
                            Vector2 vector2_3 = new Vector2((float) (i3 + 1), (float) j3) * 16f;
                            vector2_3.Y += 28f;
                            int Type3 = 99;
                            int Damage3 = 70;
                            float KnockBack2 = 10f;
                            if (Type3 == 0)
                              return;
                            Projectile.NewProjectile((float) (int) vector2_3.X, (float) (int) vector2_3.Y, 0.0f, 0.0f, Type3, Damage3, KnockBack2, Main.myPlayer);
                            return;
                          default:
                            if (type == 139 || type == 35)
                            {
                              WorldGen.SwitchMB(i, j);
                              return;
                            }
                            if (type == 207)
                            {
                              WorldGen.SwitchFountain(i, j);
                              return;
                            }
                            if (type == 410 || type == 480 || type == 509)
                            {
                              WorldGen.SwitchMonolith(i, j);
                              return;
                            }
                            switch (type)
                            {
                              case 141:
                                WorldGen.KillTile(i, j, noItem: true);
                                NetMessage.SendTileSquare(-1, i, j, 1);
                                Projectile.NewProjectile((float) (i * 16 + 8), (float) (j * 16 + 8), 0.0f, 0.0f, 108, 500, 10f, Main.myPlayer);
                                return;
                              case 210:
                                WorldGen.ExplodeMine(i, j);
                                return;
                              case 455:
                                BirthdayParty.ToggleManualParty();
                                return;
                              default:
                                if (type == 142 || type == 143)
                                {
                                  int y7 = j - (int) tile1.frameY / 18;
                                  int num91 = (int) tile1.frameX / 18;
                                  if (num91 > 1)
                                    num91 -= 2;
                                  int x = i - num91;
                                  Wiring.SkipWire(x, y7);
                                  Wiring.SkipWire(x, y7 + 1);
                                  Wiring.SkipWire(x + 1, y7);
                                  Wiring.SkipWire(x + 1, y7 + 1);
                                  if (type == 142)
                                  {
                                    for (int index27 = 0; index27 < 4 && Wiring._numInPump < 19; ++index27)
                                    {
                                      int num92;
                                      int num93;
                                      switch (index27)
                                      {
                                        case 0:
                                          num92 = x;
                                          num93 = y7 + 1;
                                          break;
                                        case 1:
                                          num92 = x + 1;
                                          num93 = y7 + 1;
                                          break;
                                        case 2:
                                          num92 = x;
                                          num93 = y7;
                                          break;
                                        default:
                                          num92 = x + 1;
                                          num93 = y7;
                                          break;
                                      }
                                      Wiring._inPumpX[Wiring._numInPump] = num92;
                                      Wiring._inPumpY[Wiring._numInPump] = num93;
                                      ++Wiring._numInPump;
                                    }
                                    return;
                                  }
                                  for (int index28 = 0; index28 < 4 && Wiring._numOutPump < 19; ++index28)
                                  {
                                    int num94;
                                    int num95;
                                    switch (index28)
                                    {
                                      case 0:
                                        num94 = x;
                                        num95 = y7 + 1;
                                        break;
                                      case 1:
                                        num94 = x + 1;
                                        num95 = y7 + 1;
                                        break;
                                      case 2:
                                        num94 = x;
                                        num95 = y7;
                                        break;
                                      default:
                                        num94 = x + 1;
                                        num95 = y7;
                                        break;
                                    }
                                    Wiring._outPumpX[Wiring._numOutPump] = num94;
                                    Wiring._outPumpY[Wiring._numOutPump] = num95;
                                    ++Wiring._numOutPump;
                                  }
                                  return;
                                }
                                switch (type)
                                {
                                  case 105:
                                    int num96 = j - (int) tile1.frameY / 18;
                                    int num97 = (int) tile1.frameX / 18;
                                    int num98 = 0;
                                    while (num97 >= 2)
                                    {
                                      num97 -= 2;
                                      ++num98;
                                    }
                                    int num99 = i - num97;
                                    int num100 = i - (int) tile1.frameX % 36 / 18;
                                    int num101 = j - (int) tile1.frameY % 54 / 18;
                                    int num102 = (int) tile1.frameY / 54 % 3;
                                    int num103 = (int) tile1.frameX / 36 + num102 * 55;
                                    Wiring.SkipWire(num100, num101);
                                    Wiring.SkipWire(num100, num101 + 1);
                                    Wiring.SkipWire(num100, num101 + 2);
                                    Wiring.SkipWire(num100 + 1, num101);
                                    Wiring.SkipWire(num100 + 1, num101 + 1);
                                    Wiring.SkipWire(num100 + 1, num101 + 2);
                                    int X = num100 * 16 + 16;
                                    int Y = (num101 + 3) * 16;
                                    int index29 = -1;
                                    int num104 = -1;
                                    bool flag11 = true;
                                    bool flag12 = false;
                                    switch (num103)
                                    {
                                      case 5:
                                        num104 = 73;
                                        break;
                                      case 13:
                                        num104 = 24;
                                        break;
                                      case 30:
                                        num104 = 6;
                                        break;
                                      case 35:
                                        num104 = 2;
                                        break;
                                      case 51:
                                        num104 = (int) Utils.SelectRandom<short>(Main.rand, (short) 299, (short) 538);
                                        break;
                                      case 52:
                                        num104 = 356;
                                        break;
                                      case 53:
                                        num104 = 357;
                                        break;
                                      case 54:
                                        num104 = (int) Utils.SelectRandom<short>(Main.rand, (short) 355, (short) 358);
                                        break;
                                      case 55:
                                        num104 = (int) Utils.SelectRandom<short>(Main.rand, (short) 367, (short) 366);
                                        break;
                                      case 56:
                                        num104 = (int) Utils.SelectRandom<short>(Main.rand, (short) 359, (short) 359, (short) 359, (short) 359, (short) 360);
                                        break;
                                      case 57:
                                        num104 = 377;
                                        break;
                                      case 58:
                                        num104 = 300;
                                        break;
                                      case 59:
                                        num104 = (int) Utils.SelectRandom<short>(Main.rand, (short) 364, (short) 362);
                                        break;
                                      case 60:
                                        num104 = 148;
                                        break;
                                      case 61:
                                        num104 = 361;
                                        break;
                                      case 62:
                                        num104 = (int) Utils.SelectRandom<short>(Main.rand, (short) 487, (short) 486, (short) 485);
                                        break;
                                      case 63:
                                        num104 = 164;
                                        flag11 &= NPC.MechSpawn((float) X, (float) Y, 165);
                                        break;
                                      case 64:
                                        num104 = 86;
                                        flag12 = true;
                                        break;
                                      case 65:
                                        num104 = 490;
                                        break;
                                      case 66:
                                        num104 = 82;
                                        break;
                                      case 67:
                                        num104 = 449;
                                        break;
                                      case 68:
                                        num104 = 167;
                                        break;
                                      case 69:
                                        num104 = 480;
                                        break;
                                      case 70:
                                        num104 = 48;
                                        break;
                                      case 71:
                                        num104 = (int) Utils.SelectRandom<short>(Main.rand, (short) 170, (short) 180, (short) 171);
                                        flag12 = true;
                                        break;
                                      case 72:
                                        num104 = 481;
                                        break;
                                      case 73:
                                        num104 = 482;
                                        break;
                                      case 74:
                                        num104 = 430;
                                        break;
                                      case 75:
                                        num104 = 489;
                                        break;
                                      case 76:
                                        num104 = 611;
                                        break;
                                      case 77:
                                        num104 = 602;
                                        break;
                                      case 78:
                                        num104 = (int) Utils.SelectRandom<short>(Main.rand, (short) 595, (short) 596, (short) 599, (short) 597, (short) 600, (short) 598);
                                        break;
                                      case 79:
                                        num104 = (int) Utils.SelectRandom<short>(Main.rand, (short) 616, (short) 617);
                                        break;
                                    }
                                    if (((num104 == -1 || !Wiring.CheckMech(num100, num101, 30) ? 0 : (NPC.MechSpawn((float) X, (float) Y, num104) ? 1 : 0)) & (flag11 ? 1 : 0)) != 0)
                                    {
                                      if (!flag12 || !Collision.SolidTiles(num100 - 2, num100 + 3, num101, num101 + 2))
                                      {
                                        index29 = NPC.NewNPC(X, Y, num104);
                                      }
                                      else
                                      {
                                        Vector2 position = new Vector2((float) (X - 4), (float) (Y - 22)) - new Vector2(10f);
                                        Utils.PoofOfSmoke(position);
                                        NetMessage.SendData(106, number: ((int) position.X), number2: position.Y);
                                      }
                                    }
                                    if (index29 <= -1)
                                    {
                                      switch (num103)
                                      {
                                        case 2:
                                          if (Wiring.CheckMech(num100, num101, 600) && Item.MechSpawn((float) X, (float) Y, 184) && Item.MechSpawn((float) X, (float) Y, 1735) && Item.MechSpawn((float) X, (float) Y, 1868))
                                          {
                                            Item.NewItem(X, Y - 16, 0, 0, 184);
                                            break;
                                          }
                                          break;
                                        case 4:
                                          if (Wiring.CheckMech(num100, num101, 30) && NPC.MechSpawn((float) X, (float) Y, 1))
                                          {
                                            index29 = NPC.NewNPC(X, Y - 12, 1);
                                            break;
                                          }
                                          break;
                                        case 7:
                                          if (Wiring.CheckMech(num100, num101, 30) && NPC.MechSpawn((float) X, (float) Y, 49))
                                          {
                                            index29 = NPC.NewNPC(X - 4, Y - 6, 49);
                                            break;
                                          }
                                          break;
                                        case 8:
                                          if (Wiring.CheckMech(num100, num101, 30) && NPC.MechSpawn((float) X, (float) Y, 55))
                                          {
                                            index29 = NPC.NewNPC(X, Y - 12, 55);
                                            break;
                                          }
                                          break;
                                        case 9:
                                          int num105 = 46;
                                          if (BirthdayParty.PartyIsUp)
                                            num105 = 540;
                                          if (Wiring.CheckMech(num100, num101, 30) && NPC.MechSpawn((float) X, (float) Y, num105))
                                          {
                                            index29 = NPC.NewNPC(X, Y - 12, num105);
                                            break;
                                          }
                                          break;
                                        case 10:
                                          if (Wiring.CheckMech(num100, num101, 30) && NPC.MechSpawn((float) X, (float) Y, 21))
                                          {
                                            index29 = NPC.NewNPC(X, Y, 21);
                                            break;
                                          }
                                          break;
                                        case 16:
                                          if (Wiring.CheckMech(num100, num101, 30) && NPC.MechSpawn((float) X, (float) Y, 42))
                                          {
                                            if (!Collision.SolidTiles(num100 - 1, num100 + 1, num101, num101 + 1))
                                            {
                                              index29 = NPC.NewNPC(X, Y - 12, 42);
                                              break;
                                            }
                                            Vector2 position = new Vector2((float) (X - 4), (float) (Y - 22)) - new Vector2(10f);
                                            Utils.PoofOfSmoke(position);
                                            NetMessage.SendData(106, number: ((int) position.X), number2: position.Y);
                                            break;
                                          }
                                          break;
                                        case 17:
                                          if (Wiring.CheckMech(num100, num101, 600) && Item.MechSpawn((float) X, (float) Y, 166))
                                          {
                                            Item.NewItem(X, Y - 20, 0, 0, 166);
                                            break;
                                          }
                                          break;
                                        case 18:
                                          if (Wiring.CheckMech(num100, num101, 30) && NPC.MechSpawn((float) X, (float) Y, 67))
                                          {
                                            index29 = NPC.NewNPC(X, Y - 12, 67);
                                            break;
                                          }
                                          break;
                                        case 23:
                                          if (Wiring.CheckMech(num100, num101, 30) && NPC.MechSpawn((float) X, (float) Y, 63))
                                          {
                                            index29 = NPC.NewNPC(X, Y - 12, 63);
                                            break;
                                          }
                                          break;
                                        case 27:
                                          if (Wiring.CheckMech(num100, num101, 30) && NPC.MechSpawn((float) X, (float) Y, 85))
                                          {
                                            index29 = NPC.NewNPC(X - 9, Y, 85);
                                            break;
                                          }
                                          break;
                                        case 28:
                                          if (Wiring.CheckMech(num100, num101, 30) && NPC.MechSpawn((float) X, (float) Y, 74))
                                          {
                                            index29 = NPC.NewNPC(X, Y - 12, (int) Utils.SelectRandom<short>(Main.rand, (short) 74, (short) 297, (short) 298));
                                            break;
                                          }
                                          break;
                                        case 34:
                                          for (int index30 = 0; index30 < 2; ++index30)
                                          {
                                            for (int index31 = 0; index31 < 3; ++index31)
                                            {
                                              Tile tile2 = Main.tile[num100 + index30, num101 + index31];
                                              tile2.type = (ushort) 349;
                                              tile2.frameX = (short) (index30 * 18 + 216);
                                              tile2.frameY = (short) (index31 * 18);
                                            }
                                          }
                                          Animation.NewTemporaryAnimation(0, (ushort) 349, num100, num101);
                                          if (Main.netMode == 2)
                                          {
                                            NetMessage.SendTileRange(-1, num100, num101, 2, 3);
                                            break;
                                          }
                                          break;
                                        case 37:
                                          if (Wiring.CheckMech(num100, num101, 600) && Item.MechSpawn((float) X, (float) Y, 58) && Item.MechSpawn((float) X, (float) Y, 1734) && Item.MechSpawn((float) X, (float) Y, 1867))
                                          {
                                            Item.NewItem(X, Y - 16, 0, 0, 58);
                                            break;
                                          }
                                          break;
                                        case 40:
                                          if (Wiring.CheckMech(num100, num101, 300))
                                          {
                                            int length = 50;
                                            int[] numArray = new int[length];
                                            int maxValue = 0;
                                            for (int index32 = 0; index32 < 200; ++index32)
                                            {
                                              if (Main.npc[index32].active && (Main.npc[index32].type == 17 || Main.npc[index32].type == 19 || Main.npc[index32].type == 22 || Main.npc[index32].type == 38 || Main.npc[index32].type == 54 || Main.npc[index32].type == 107 || Main.npc[index32].type == 108 || Main.npc[index32].type == 142 || Main.npc[index32].type == 160 || Main.npc[index32].type == 207 || Main.npc[index32].type == 209 || Main.npc[index32].type == 227 || Main.npc[index32].type == 228 || Main.npc[index32].type == 229 || Main.npc[index32].type == 368 || Main.npc[index32].type == 369 || Main.npc[index32].type == 550 || Main.npc[index32].type == 441 || Main.npc[index32].type == 588))
                                              {
                                                numArray[maxValue] = index32;
                                                ++maxValue;
                                                if (maxValue >= length)
                                                  break;
                                              }
                                            }
                                            if (maxValue > 0)
                                            {
                                              int number = numArray[Main.rand.Next(maxValue)];
                                              Main.npc[number].position.X = (float) (X - Main.npc[number].width / 2);
                                              Main.npc[number].position.Y = (float) (Y - Main.npc[number].height - 1);
                                              NetMessage.SendData(23, number: number);
                                              break;
                                            }
                                            break;
                                          }
                                          break;
                                        case 41:
                                          if (Wiring.CheckMech(num100, num101, 300))
                                          {
                                            int length = 50;
                                            int[] numArray = new int[length];
                                            int maxValue = 0;
                                            for (int index33 = 0; index33 < 200; ++index33)
                                            {
                                              if (Main.npc[index33].active && (Main.npc[index33].type == 18 || Main.npc[index33].type == 20 || Main.npc[index33].type == 124 || Main.npc[index33].type == 178 || Main.npc[index33].type == 208 || Main.npc[index33].type == 353 || Main.npc[index33].type == 633))
                                              {
                                                numArray[maxValue] = index33;
                                                ++maxValue;
                                                if (maxValue >= length)
                                                  break;
                                              }
                                            }
                                            if (maxValue > 0)
                                            {
                                              int number = numArray[Main.rand.Next(maxValue)];
                                              Main.npc[number].position.X = (float) (X - Main.npc[number].width / 2);
                                              Main.npc[number].position.Y = (float) (Y - Main.npc[number].height - 1);
                                              NetMessage.SendData(23, number: number);
                                              break;
                                            }
                                            break;
                                          }
                                          break;
                                        case 42:
                                          if (Wiring.CheckMech(num100, num101, 30) && NPC.MechSpawn((float) X, (float) Y, 58))
                                          {
                                            index29 = NPC.NewNPC(X, Y - 12, 58);
                                            break;
                                          }
                                          break;
                                        case 50:
                                          if (Wiring.CheckMech(num100, num101, 30) && NPC.MechSpawn((float) X, (float) Y, 65))
                                          {
                                            if (!Collision.SolidTiles(num100 - 2, num100 + 3, num101, num101 + 2))
                                            {
                                              index29 = NPC.NewNPC(X, Y - 12, 65);
                                              break;
                                            }
                                            Vector2 position = new Vector2((float) (X - 4), (float) (Y - 22)) - new Vector2(10f);
                                            Utils.PoofOfSmoke(position);
                                            NetMessage.SendData(106, number: ((int) position.X), number2: position.Y);
                                            break;
                                          }
                                          break;
                                      }
                                    }
                                    if (index29 < 0)
                                      return;
                                    Main.npc[index29].value = 0.0f;
                                    Main.npc[index29].npcSlots = 0.0f;
                                    Main.npc[index29].SpawnedFromStatue = true;
                                    return;
                                  case 349:
                                    int num106 = (int) tile1.frameY / 18 % 3;
                                    int index34 = j - num106;
                                    int num107 = (int) tile1.frameX / 18;
                                    while (num107 >= 2)
                                      num107 -= 2;
                                    int index35 = i - num107;
                                    Wiring.SkipWire(index35, index34);
                                    Wiring.SkipWire(index35, index34 + 1);
                                    Wiring.SkipWire(index35, index34 + 2);
                                    Wiring.SkipWire(index35 + 1, index34);
                                    Wiring.SkipWire(index35 + 1, index34 + 1);
                                    Wiring.SkipWire(index35 + 1, index34 + 2);
                                    short num108 = Main.tile[index35, index34].frameX != (short) 0 ? (short) -216 : (short) 216;
                                    for (int index36 = 0; index36 < 2; ++index36)
                                    {
                                      for (int index37 = 0; index37 < 3; ++index37)
                                        Main.tile[index35 + index36, index34 + index37].frameX += num108;
                                    }
                                    if (Main.netMode == 2)
                                      NetMessage.SendTileRange(-1, index35, index34, 2, 3);
                                    Animation.NewTemporaryAnimation(num108 > (short) 0 ? 0 : 1, (ushort) 349, index35, index34);
                                    return;
                                  case 506:
                                    int num109 = (int) tile1.frameY / 18 % 3;
                                    int index38 = j - num109;
                                    int num110 = (int) tile1.frameX / 18;
                                    while (num110 >= 2)
                                      num110 -= 2;
                                    int index39 = i - num110;
                                    Wiring.SkipWire(index39, index38);
                                    Wiring.SkipWire(index39, index38 + 1);
                                    Wiring.SkipWire(index39, index38 + 2);
                                    Wiring.SkipWire(index39 + 1, index38);
                                    Wiring.SkipWire(index39 + 1, index38 + 1);
                                    Wiring.SkipWire(index39 + 1, index38 + 2);
                                    short num111 = Main.tile[index39, index38].frameX >= (short) 72 ? (short) -72 : (short) 72;
                                    for (int index40 = 0; index40 < 2; ++index40)
                                    {
                                      for (int index41 = 0; index41 < 3; ++index41)
                                        Main.tile[index39 + index40, index38 + index41].frameX += num111;
                                    }
                                    if (Main.netMode != 2)
                                      return;
                                    NetMessage.SendTileRange(-1, index39, index38, 2, 3);
                                    return;
                                  case 546:
                                    tile1.type = (ushort) 557;
                                    WorldGen.SquareTileFrame(i, j);
                                    NetMessage.SendTileSquare(-1, i, j, 1);
                                    return;
                                  case 557:
                                    tile1.type = (ushort) 546;
                                    WorldGen.SquareTileFrame(i, j);
                                    NetMessage.SendTileSquare(-1, i, j, 1);
                                    return;
                                  default:
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
      }
    }

    private static void GeyserTrap(int i, int j)
    {
      Tile tile = Main.tile[i, j];
      if (tile.type != (ushort) 443)
        return;
      int num = (int) tile.frameX / 36;
      int i1 = i - ((int) tile.frameX - num * 36) / 18;
      int j1 = j;
      if (!Wiring.CheckMech(i1, j1, 200))
        return;
      Vector2 zero = Vector2.Zero;
      Vector2 vector2_1 = Vector2.Zero;
      int Type = 654;
      int Damage = 20;
      Vector2 vector2_2;
      if (num < 2)
      {
        vector2_2 = new Vector2((float) (i1 + 1), (float) j1) * 16f;
        vector2_1 = new Vector2(0.0f, -8f);
      }
      else
      {
        vector2_2 = new Vector2((float) (i1 + 1), (float) (j1 + 1)) * 16f;
        vector2_1 = new Vector2(0.0f, 8f);
      }
      if (Type == 0)
        return;
      Projectile.NewProjectile((float) (int) vector2_2.X, (float) (int) vector2_2.Y, vector2_1.X, vector2_1.Y, Type, Damage, 2f, Main.myPlayer);
    }

    private static void Teleport()
    {
      if ((double) Wiring._teleport[0].X < (double) Wiring._teleport[1].X + 3.0 && (double) Wiring._teleport[0].X > (double) Wiring._teleport[1].X - 3.0 && (double) Wiring._teleport[0].Y > (double) Wiring._teleport[1].Y - 3.0 && (double) Wiring._teleport[0].Y < (double) Wiring._teleport[1].Y)
        return;
      Rectangle[] rectangleArray = new Rectangle[2];
      rectangleArray[0].X = (int) ((double) Wiring._teleport[0].X * 16.0);
      rectangleArray[0].Width = 48;
      rectangleArray[0].Height = 48;
      rectangleArray[0].Y = (int) ((double) Wiring._teleport[0].Y * 16.0 - (double) rectangleArray[0].Height);
      rectangleArray[1].X = (int) ((double) Wiring._teleport[1].X * 16.0);
      rectangleArray[1].Width = 48;
      rectangleArray[1].Height = 48;
      rectangleArray[1].Y = (int) ((double) Wiring._teleport[1].Y * 16.0 - (double) rectangleArray[1].Height);
      for (int index1 = 0; index1 < 2; ++index1)
      {
        Vector2 vector2_1 = new Vector2((float) (rectangleArray[1].X - rectangleArray[0].X), (float) (rectangleArray[1].Y - rectangleArray[0].Y));
        if (index1 == 1)
          vector2_1 = new Vector2((float) (rectangleArray[0].X - rectangleArray[1].X), (float) (rectangleArray[0].Y - rectangleArray[1].Y));
        if (!Wiring.blockPlayerTeleportationForOneIteration)
        {
          for (int playerIndex = 0; playerIndex < (int) byte.MaxValue; ++playerIndex)
          {
            if (Main.player[playerIndex].active && !Main.player[playerIndex].dead && !Main.player[playerIndex].teleporting && Wiring.TeleporterHitboxIntersects(rectangleArray[index1], Main.player[playerIndex].Hitbox))
            {
              Vector2 vector2_2 = Main.player[playerIndex].position + vector2_1;
              Main.player[playerIndex].teleporting = true;
              if (Main.netMode == 2)
                RemoteClient.CheckSection(playerIndex, vector2_2);
              Main.player[playerIndex].Teleport(vector2_2);
              if (Main.netMode == 2)
                NetMessage.SendData(65, number2: ((float) playerIndex), number3: vector2_2.X, number4: vector2_2.Y);
            }
          }
        }
        for (int index2 = 0; index2 < 200; ++index2)
        {
          if (Main.npc[index2].active && !Main.npc[index2].teleporting && Main.npc[index2].lifeMax > 5 && !Main.npc[index2].boss && !Main.npc[index2].noTileCollide)
          {
            int type = Main.npc[index2].type;
            if (!NPCID.Sets.TeleportationImmune[type] && Wiring.TeleporterHitboxIntersects(rectangleArray[index1], Main.npc[index2].Hitbox))
            {
              Main.npc[index2].teleporting = true;
              Main.npc[index2].Teleport(Main.npc[index2].position + vector2_1);
            }
          }
        }
      }
      for (int index = 0; index < (int) byte.MaxValue; ++index)
        Main.player[index].teleporting = false;
      for (int index = 0; index < 200; ++index)
        Main.npc[index].teleporting = false;
    }

    private static bool TeleporterHitboxIntersects(Rectangle teleporter, Rectangle entity)
    {
      Rectangle rectangle = Rectangle.Union(teleporter, entity);
      return rectangle.Width <= teleporter.Width + entity.Width && rectangle.Height <= teleporter.Height + entity.Height;
    }

    private static void DeActive(int i, int j)
    {
      if (!Main.tile[i, j].active() || Main.tile[i, j].type == (ushort) 226 && (double) j > Main.worldSurface && !NPC.downedPlantBoss)
        return;
      bool flag = Main.tileSolid[(int) Main.tile[i, j].type] && !TileID.Sets.NotReallySolid[(int) Main.tile[i, j].type];
      switch (Main.tile[i, j].type)
      {
        case 314:
        case 386:
        case 387:
        case 388:
        case 389:
        case 476:
          flag = false;
          break;
      }
      if (!flag || Main.tile[i, j - 1].active() && (TileID.Sets.BasicChest[(int) Main.tile[i, j - 1].type] || Main.tile[i, j - 1].type == (ushort) 26 || Main.tile[i, j - 1].type == (ushort) 77 || Main.tile[i, j - 1].type == (ushort) 88 || Main.tile[i, j - 1].type == (ushort) 470 || Main.tile[i, j - 1].type == (ushort) 475 || Main.tile[i, j - 1].type == (ushort) 237 || Main.tile[i, j - 1].type == (ushort) 597 || !WorldGen.CanKillTile(i, j - 1)))
        return;
      Main.tile[i, j].inActive(true);
      WorldGen.SquareTileFrame(i, j, false);
      if (Main.netMode == 1)
        return;
      NetMessage.SendTileSquare(-1, i, j, 1);
    }

    private static void ReActive(int i, int j)
    {
      Main.tile[i, j].inActive(false);
      WorldGen.SquareTileFrame(i, j, false);
      if (Main.netMode == 1)
        return;
      NetMessage.SendTileSquare(-1, i, j, 1);
    }

    private static void MassWireOperationInner(
      Point ps,
      Point pe,
      Vector2 dropPoint,
      bool dir,
      ref int wireCount,
      ref int actuatorCount)
    {
      Math.Abs(ps.X - pe.X);
      Math.Abs(ps.Y - pe.Y);
      int num1 = Math.Sign(pe.X - ps.X);
      int num2 = Math.Sign(pe.Y - ps.Y);
      WiresUI.Settings.MultiToolMode toolMode = WiresUI.Settings.ToolMode;
      Point pt = new Point();
      bool flag1 = false;
      Item.StartCachingType(530);
      Item.StartCachingType(849);
      bool flag2 = dir;
      int num3;
      int num4;
      int num5;
      if (flag2)
      {
        pt.X = ps.X;
        num3 = ps.Y;
        num4 = pe.Y;
        num5 = num2;
      }
      else
      {
        pt.Y = ps.Y;
        num3 = ps.X;
        num4 = pe.X;
        num5 = num1;
      }
      for (int index = num3; index != num4 && !flag1; index += num5)
      {
        if (flag2)
          pt.Y = index;
        else
          pt.X = index;
        bool? nullable = Wiring.MassWireOperationStep(pt, toolMode, ref wireCount, ref actuatorCount);
        if (nullable.HasValue && !nullable.Value)
        {
          flag1 = true;
          break;
        }
      }
      int num6;
      int num7;
      int num8;
      if (flag2)
      {
        pt.Y = pe.Y;
        num6 = ps.X;
        num7 = pe.X;
        num8 = num1;
      }
      else
      {
        pt.X = pe.X;
        num6 = ps.Y;
        num7 = pe.Y;
        num8 = num2;
      }
      for (int index = num6; index != num7 && !flag1; index += num8)
      {
        if (!flag2)
          pt.Y = index;
        else
          pt.X = index;
        bool? nullable = Wiring.MassWireOperationStep(pt, toolMode, ref wireCount, ref actuatorCount);
        if (nullable.HasValue && !nullable.Value)
        {
          flag1 = true;
          break;
        }
      }
      if (!flag1)
        Wiring.MassWireOperationStep(pe, toolMode, ref wireCount, ref actuatorCount);
      Item.DropCache(dropPoint, Vector2.Zero, 530);
      Item.DropCache(dropPoint, Vector2.Zero, 849);
    }

    private static bool? MassWireOperationStep(
      Point pt,
      WiresUI.Settings.MultiToolMode mode,
      ref int wiresLeftToConsume,
      ref int actuatorsLeftToConstume)
    {
      if (!WorldGen.InWorld(pt.X, pt.Y, 1))
        return new bool?();
      Tile tile = Main.tile[pt.X, pt.Y];
      if (tile == null)
        return new bool?();
      if (!mode.HasFlag((Enum) WiresUI.Settings.MultiToolMode.Cutter))
      {
        if (mode.HasFlag((Enum) WiresUI.Settings.MultiToolMode.Red) && !tile.wire())
        {
          if (wiresLeftToConsume <= 0)
            return new bool?(false);
          --wiresLeftToConsume;
          WorldGen.PlaceWire(pt.X, pt.Y);
          NetMessage.SendData(17, number: 5, number2: ((float) pt.X), number3: ((float) pt.Y));
        }
        if (mode.HasFlag((Enum) WiresUI.Settings.MultiToolMode.Green) && !tile.wire3())
        {
          if (wiresLeftToConsume <= 0)
            return new bool?(false);
          --wiresLeftToConsume;
          WorldGen.PlaceWire3(pt.X, pt.Y);
          NetMessage.SendData(17, number: 12, number2: ((float) pt.X), number3: ((float) pt.Y));
        }
        if (mode.HasFlag((Enum) WiresUI.Settings.MultiToolMode.Blue) && !tile.wire2())
        {
          if (wiresLeftToConsume <= 0)
            return new bool?(false);
          --wiresLeftToConsume;
          WorldGen.PlaceWire2(pt.X, pt.Y);
          NetMessage.SendData(17, number: 10, number2: ((float) pt.X), number3: ((float) pt.Y));
        }
        if (mode.HasFlag((Enum) WiresUI.Settings.MultiToolMode.Yellow) && !tile.wire4())
        {
          if (wiresLeftToConsume <= 0)
            return new bool?(false);
          --wiresLeftToConsume;
          WorldGen.PlaceWire4(pt.X, pt.Y);
          NetMessage.SendData(17, number: 16, number2: ((float) pt.X), number3: ((float) pt.Y));
        }
        if (mode.HasFlag((Enum) WiresUI.Settings.MultiToolMode.Actuator) && !tile.actuator())
        {
          if (actuatorsLeftToConstume <= 0)
            return new bool?(false);
          --actuatorsLeftToConstume;
          WorldGen.PlaceActuator(pt.X, pt.Y);
          NetMessage.SendData(17, number: 8, number2: ((float) pt.X), number3: ((float) pt.Y));
        }
      }
      if (mode.HasFlag((Enum) WiresUI.Settings.MultiToolMode.Cutter))
      {
        if (mode.HasFlag((Enum) WiresUI.Settings.MultiToolMode.Red) && tile.wire() && WorldGen.KillWire(pt.X, pt.Y))
          NetMessage.SendData(17, number: 6, number2: ((float) pt.X), number3: ((float) pt.Y));
        if (mode.HasFlag((Enum) WiresUI.Settings.MultiToolMode.Green) && tile.wire3() && WorldGen.KillWire3(pt.X, pt.Y))
          NetMessage.SendData(17, number: 13, number2: ((float) pt.X), number3: ((float) pt.Y));
        if (mode.HasFlag((Enum) WiresUI.Settings.MultiToolMode.Blue) && tile.wire2() && WorldGen.KillWire2(pt.X, pt.Y))
          NetMessage.SendData(17, number: 11, number2: ((float) pt.X), number3: ((float) pt.Y));
        if (mode.HasFlag((Enum) WiresUI.Settings.MultiToolMode.Yellow) && tile.wire4() && WorldGen.KillWire4(pt.X, pt.Y))
          NetMessage.SendData(17, number: 17, number2: ((float) pt.X), number3: ((float) pt.Y));
        if (mode.HasFlag((Enum) WiresUI.Settings.MultiToolMode.Actuator) && tile.actuator() && WorldGen.KillActuator(pt.X, pt.Y))
          NetMessage.SendData(17, number: 9, number2: ((float) pt.X), number3: ((float) pt.Y));
      }
      return new bool?(true);
    }
  }
}
