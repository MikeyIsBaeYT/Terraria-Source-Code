// Decompiled with JetBrains decompiler
// Type: Terraria.DeprecatedClassLeftInForLoading
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Terraria
{
  public class DeprecatedClassLeftInForLoading
  {
    public const int MaxDummies = 1000;
    public static DeprecatedClassLeftInForLoading[] dummies = new DeprecatedClassLeftInForLoading[1000];
    public short x;
    public short y;
    public int npc;
    public int whoAmI;

    public static void UpdateDummies()
    {
      Dictionary<int, Rectangle> dictionary = new Dictionary<int, Rectangle>();
      bool flag1 = false;
      Rectangle rectangle = new Rectangle(0, 0, 32, 48);
      rectangle.Inflate(1600, 1600);
      int x = rectangle.X;
      int y = rectangle.Y;
      for (int index = 0; index < 1000; ++index)
      {
        if (DeprecatedClassLeftInForLoading.dummies[index] != null)
        {
          DeprecatedClassLeftInForLoading.dummies[index].whoAmI = index;
          if (DeprecatedClassLeftInForLoading.dummies[index].npc != -1)
          {
            if (!Main.npc[DeprecatedClassLeftInForLoading.dummies[index].npc].active || Main.npc[DeprecatedClassLeftInForLoading.dummies[index].npc].type != 488 || (double) Main.npc[DeprecatedClassLeftInForLoading.dummies[index].npc].ai[0] != (double) DeprecatedClassLeftInForLoading.dummies[index].x || (double) Main.npc[DeprecatedClassLeftInForLoading.dummies[index].npc].ai[1] != (double) DeprecatedClassLeftInForLoading.dummies[index].y)
              DeprecatedClassLeftInForLoading.dummies[index].Deactivate();
          }
          else
          {
            if (!flag1)
            {
              for (int key = 0; key < (int) byte.MaxValue; ++key)
              {
                if (Main.player[key].active)
                  dictionary[key] = Main.player[key].getRect();
              }
              flag1 = true;
            }
            rectangle.X = (int) DeprecatedClassLeftInForLoading.dummies[index].x * 16 + x;
            rectangle.Y = (int) DeprecatedClassLeftInForLoading.dummies[index].y * 16 + y;
            bool flag2 = false;
            foreach (KeyValuePair<int, Rectangle> keyValuePair in dictionary)
            {
              if (keyValuePair.Value.Intersects(rectangle))
              {
                flag2 = true;
                break;
              }
            }
            if (flag2)
              DeprecatedClassLeftInForLoading.dummies[index].Activate();
          }
        }
      }
    }

    public DeprecatedClassLeftInForLoading(int x, int y)
    {
      this.x = (short) x;
      this.y = (short) y;
      this.npc = -1;
    }

    public static int Find(int x, int y)
    {
      for (int index = 0; index < 1000; ++index)
      {
        if (DeprecatedClassLeftInForLoading.dummies[index] != null && (int) DeprecatedClassLeftInForLoading.dummies[index].x == x && (int) DeprecatedClassLeftInForLoading.dummies[index].y == y)
          return index;
      }
      return -1;
    }

    public static int Place(int x, int y)
    {
      int index1 = -1;
      for (int index2 = 0; index2 < 1000; ++index2)
      {
        if (DeprecatedClassLeftInForLoading.dummies[index2] == null)
        {
          index1 = index2;
          break;
        }
      }
      if (index1 == -1)
        return index1;
      DeprecatedClassLeftInForLoading.dummies[index1] = new DeprecatedClassLeftInForLoading(x, y);
      return index1;
    }

    public static void Kill(int x, int y)
    {
      for (int index = 0; index < 1000; ++index)
      {
        DeprecatedClassLeftInForLoading dummy = DeprecatedClassLeftInForLoading.dummies[index];
        if (dummy != null && (int) dummy.x == x && (int) dummy.y == y)
          DeprecatedClassLeftInForLoading.dummies[index] = (DeprecatedClassLeftInForLoading) null;
      }
    }

    public static int Hook_AfterPlacement(int x, int y, int type = 21, int style = 0, int direction = 1)
    {
      if (Main.netMode != 1)
        return DeprecatedClassLeftInForLoading.Place(x - 1, y - 2);
      NetMessage.SendTileSquare(Main.myPlayer, x - 1, y - 1, 3);
      NetMessage.SendData(87, number: (x - 1), number2: ((float) (y - 2)));
      return -1;
    }

    public void Activate()
    {
      int index = NPC.NewNPC((int) this.x * 16 + 16, (int) this.y * 16 + 48, 488, 100);
      Main.npc[index].ai[0] = (float) this.x;
      Main.npc[index].ai[1] = (float) this.y;
      Main.npc[index].netUpdate = true;
      this.npc = index;
      if (Main.netMode == 1)
        return;
      NetMessage.SendData(86, number: this.whoAmI, number2: ((float) this.x), number3: ((float) this.y));
    }

    public void Deactivate()
    {
      if (this.npc != -1)
        Main.npc[this.npc].active = false;
      this.npc = -1;
      if (Main.netMode == 1)
        return;
      NetMessage.SendData(86, number: this.whoAmI, number2: ((float) this.x), number3: ((float) this.y));
    }

    public override string ToString() => this.x.ToString() + "x  " + (object) this.y + "y npc: " + (object) this.npc;
  }
}
