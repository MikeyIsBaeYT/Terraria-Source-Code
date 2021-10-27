// Decompiled with JetBrains decompiler
// Type: Terraria.Chest
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ObjectData;

namespace Terraria
{
  public class Chest
  {
    public const int maxChestTypes = 52;
    public static int[] chestTypeToIcon = new int[52];
    public static int[] chestItemSpawn = new int[52];
    public const int maxChestTypes2 = 2;
    public static int[] chestTypeToIcon2 = new int[2];
    public static int[] chestItemSpawn2 = new int[2];
    public const int maxDresserTypes = 32;
    public static int[] dresserTypeToIcon = new int[32];
    public static int[] dresserItemSpawn = new int[32];
    public const int maxItems = 40;
    public const int MaxNameLength = 20;
    public Item[] item;
    public int x;
    public int y;
    public bool bankChest;
    public string name;
    public int frameCounter;
    public int frame;

    public Chest(bool bank = false)
    {
      this.item = new Item[40];
      this.bankChest = bank;
      this.name = string.Empty;
    }

    public override string ToString()
    {
      int num = 0;
      for (int index = 0; index < this.item.Length; ++index)
      {
        if (this.item[index].stack > 0)
          ++num;
      }
      return string.Format("{{X: {0}, Y: {1}, Count: {2}}}", (object) this.x, (object) this.y, (object) num);
    }

    public static void Initialize()
    {
      int[] chestItemSpawn = Chest.chestItemSpawn;
      int[] chestTypeToIcon = Chest.chestTypeToIcon;
      chestTypeToIcon[0] = chestItemSpawn[0] = 48;
      chestTypeToIcon[1] = chestItemSpawn[1] = 306;
      chestTypeToIcon[2] = 327;
      chestItemSpawn[2] = 306;
      chestTypeToIcon[3] = chestItemSpawn[3] = 328;
      chestTypeToIcon[4] = 329;
      chestItemSpawn[4] = 328;
      chestTypeToIcon[5] = chestItemSpawn[5] = 343;
      chestTypeToIcon[6] = chestItemSpawn[6] = 348;
      chestTypeToIcon[7] = chestItemSpawn[7] = 625;
      chestTypeToIcon[8] = chestItemSpawn[8] = 626;
      chestTypeToIcon[9] = chestItemSpawn[9] = 627;
      chestTypeToIcon[10] = chestItemSpawn[10] = 680;
      chestTypeToIcon[11] = chestItemSpawn[11] = 681;
      chestTypeToIcon[12] = chestItemSpawn[12] = 831;
      chestTypeToIcon[13] = chestItemSpawn[13] = 838;
      chestTypeToIcon[14] = chestItemSpawn[14] = 914;
      chestTypeToIcon[15] = chestItemSpawn[15] = 952;
      chestTypeToIcon[16] = chestItemSpawn[16] = 1142;
      chestTypeToIcon[17] = chestItemSpawn[17] = 1298;
      chestTypeToIcon[18] = chestItemSpawn[18] = 1528;
      chestTypeToIcon[19] = chestItemSpawn[19] = 1529;
      chestTypeToIcon[20] = chestItemSpawn[20] = 1530;
      chestTypeToIcon[21] = chestItemSpawn[21] = 1531;
      chestTypeToIcon[22] = chestItemSpawn[22] = 1532;
      chestTypeToIcon[23] = 1533;
      chestItemSpawn[23] = 1528;
      chestTypeToIcon[24] = 1534;
      chestItemSpawn[24] = 1529;
      chestTypeToIcon[25] = 1535;
      chestItemSpawn[25] = 1530;
      chestTypeToIcon[26] = 1536;
      chestItemSpawn[26] = 1531;
      chestTypeToIcon[27] = 1537;
      chestItemSpawn[27] = 1532;
      chestTypeToIcon[28] = chestItemSpawn[28] = 2230;
      chestTypeToIcon[29] = chestItemSpawn[29] = 2249;
      chestTypeToIcon[30] = chestItemSpawn[30] = 2250;
      chestTypeToIcon[31] = chestItemSpawn[31] = 2526;
      chestTypeToIcon[32] = chestItemSpawn[32] = 2544;
      chestTypeToIcon[33] = chestItemSpawn[33] = 2559;
      chestTypeToIcon[34] = chestItemSpawn[34] = 2574;
      chestTypeToIcon[35] = chestItemSpawn[35] = 2612;
      chestTypeToIcon[36] = 327;
      chestItemSpawn[36] = 2612;
      chestTypeToIcon[37] = chestItemSpawn[37] = 2613;
      chestTypeToIcon[38] = 327;
      chestItemSpawn[38] = 2613;
      chestTypeToIcon[39] = chestItemSpawn[39] = 2614;
      chestTypeToIcon[40] = 327;
      chestItemSpawn[40] = 2614;
      chestTypeToIcon[41] = chestItemSpawn[41] = 2615;
      chestTypeToIcon[42] = chestItemSpawn[42] = 2616;
      chestTypeToIcon[43] = chestItemSpawn[43] = 2617;
      chestTypeToIcon[44] = chestItemSpawn[44] = 2618;
      chestTypeToIcon[45] = chestItemSpawn[45] = 2619;
      chestTypeToIcon[46] = chestItemSpawn[46] = 2620;
      chestTypeToIcon[47] = chestItemSpawn[47] = 2748;
      chestTypeToIcon[48] = chestItemSpawn[48] = 2814;
      chestTypeToIcon[49] = chestItemSpawn[49] = 3180;
      chestTypeToIcon[50] = chestItemSpawn[50] = 3125;
      chestTypeToIcon[51] = chestItemSpawn[51] = 3181;
      int[] chestItemSpawn2 = Chest.chestItemSpawn2;
      int[] chestTypeToIcon2 = Chest.chestTypeToIcon2;
      chestTypeToIcon2[0] = chestItemSpawn2[0] = 3884;
      chestTypeToIcon2[1] = chestItemSpawn2[1] = 3885;
      Chest.dresserTypeToIcon[0] = Chest.dresserItemSpawn[0] = 334;
      Chest.dresserTypeToIcon[1] = Chest.dresserItemSpawn[1] = 647;
      Chest.dresserTypeToIcon[2] = Chest.dresserItemSpawn[2] = 648;
      Chest.dresserTypeToIcon[3] = Chest.dresserItemSpawn[3] = 649;
      Chest.dresserTypeToIcon[4] = Chest.dresserItemSpawn[4] = 918;
      Chest.dresserTypeToIcon[5] = Chest.dresserItemSpawn[5] = 2386;
      Chest.dresserTypeToIcon[6] = Chest.dresserItemSpawn[6] = 2387;
      Chest.dresserTypeToIcon[7] = Chest.dresserItemSpawn[7] = 2388;
      Chest.dresserTypeToIcon[8] = Chest.dresserItemSpawn[8] = 2389;
      Chest.dresserTypeToIcon[9] = Chest.dresserItemSpawn[9] = 2390;
      Chest.dresserTypeToIcon[10] = Chest.dresserItemSpawn[10] = 2391;
      Chest.dresserTypeToIcon[11] = Chest.dresserItemSpawn[11] = 2392;
      Chest.dresserTypeToIcon[12] = Chest.dresserItemSpawn[12] = 2393;
      Chest.dresserTypeToIcon[13] = Chest.dresserItemSpawn[13] = 2394;
      Chest.dresserTypeToIcon[14] = Chest.dresserItemSpawn[14] = 2395;
      Chest.dresserTypeToIcon[15] = Chest.dresserItemSpawn[15] = 2396;
      Chest.dresserTypeToIcon[16] = Chest.dresserItemSpawn[16] = 2529;
      Chest.dresserTypeToIcon[17] = Chest.dresserItemSpawn[17] = 2545;
      Chest.dresserTypeToIcon[18] = Chest.dresserItemSpawn[18] = 2562;
      Chest.dresserTypeToIcon[19] = Chest.dresserItemSpawn[19] = 2577;
      Chest.dresserTypeToIcon[20] = Chest.dresserItemSpawn[20] = 2637;
      Chest.dresserTypeToIcon[21] = Chest.dresserItemSpawn[21] = 2638;
      Chest.dresserTypeToIcon[22] = Chest.dresserItemSpawn[22] = 2639;
      Chest.dresserTypeToIcon[23] = Chest.dresserItemSpawn[23] = 2640;
      Chest.dresserTypeToIcon[24] = Chest.dresserItemSpawn[24] = 2816;
      Chest.dresserTypeToIcon[25] = Chest.dresserItemSpawn[25] = 3132;
      Chest.dresserTypeToIcon[26] = Chest.dresserItemSpawn[26] = 3134;
      Chest.dresserTypeToIcon[27] = Chest.dresserItemSpawn[27] = 3133;
      Chest.dresserTypeToIcon[28] = Chest.dresserItemSpawn[28] = 3911;
      Chest.dresserTypeToIcon[29] = Chest.dresserItemSpawn[29] = 3912;
      Chest.dresserTypeToIcon[30] = Chest.dresserItemSpawn[30] = 3913;
      Chest.dresserTypeToIcon[31] = Chest.dresserItemSpawn[31] = 3914;
    }

    private static bool IsPlayerInChest(int i)
    {
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (Main.player[index].chest == i)
          return true;
      }
      return false;
    }

    public static bool isLocked(int x, int y) => Main.tile[x, y] == null || Main.tile[x, y].frameX >= (short) 72 && Main.tile[x, y].frameX <= (short) 106 || Main.tile[x, y].frameX >= (short) 144 && Main.tile[x, y].frameX <= (short) 178 || Main.tile[x, y].frameX >= (short) 828 && Main.tile[x, y].frameX <= (short) 1006 || Main.tile[x, y].frameX >= (short) 1296 && Main.tile[x, y].frameX <= (short) 1330 || Main.tile[x, y].frameX >= (short) 1368 && Main.tile[x, y].frameX <= (short) 1402 || Main.tile[x, y].frameX >= (short) 1440 && Main.tile[x, y].frameX <= (short) 1474;

    public static void ServerPlaceItem(int plr, int slot)
    {
      Main.player[plr].inventory[slot] = Chest.PutItemInNearbyChest(Main.player[plr].inventory[slot], Main.player[plr].Center);
      NetMessage.SendData(5, number: plr, number2: ((float) slot), number3: ((float) Main.player[plr].inventory[slot].prefix));
    }

    public static Item PutItemInNearbyChest(Item item, Vector2 position)
    {
      if (Main.netMode == 1)
        return item;
      for (int i = 0; i < 1000; ++i)
      {
        bool flag1 = false;
        bool flag2 = false;
        if (Main.chest[i] != null && !Chest.IsPlayerInChest(i) && !Chest.isLocked(Main.chest[i].x, Main.chest[i].y) && (double) (new Vector2((float) (Main.chest[i].x * 16 + 16), (float) (Main.chest[i].y * 16 + 16)) - position).Length() < 200.0)
        {
          for (int index = 0; index < Main.chest[i].item.Length; ++index)
          {
            if (Main.chest[i].item[index].type > 0 && Main.chest[i].item[index].stack > 0)
            {
              if (item.IsTheSameAs(Main.chest[i].item[index]))
              {
                flag1 = true;
                int num = Main.chest[i].item[index].maxStack - Main.chest[i].item[index].stack;
                if (num > 0)
                {
                  if (num > item.stack)
                    num = item.stack;
                  item.stack -= num;
                  Main.chest[i].item[index].stack += num;
                  if (item.stack <= 0)
                  {
                    item.SetDefaults();
                    return item;
                  }
                }
              }
            }
            else
              flag2 = true;
          }
          if (flag1 & flag2 && item.stack > 0)
          {
            for (int index = 0; index < Main.chest[i].item.Length; ++index)
            {
              if (Main.chest[i].item[index].type == 0 || Main.chest[i].item[index].stack == 0)
              {
                Main.chest[i].item[index] = item.Clone();
                item.SetDefaults();
                return item;
              }
            }
          }
        }
      }
      return item;
    }

    public object Clone() => this.MemberwiseClone();

    public static bool Unlock(int X, int Y)
    {
      if (Main.tile[X, Y] == null)
        return false;
      short num;
      int Type;
      switch ((int) Main.tile[X, Y].frameX / 36)
      {
        case 2:
          num = (short) 36;
          Type = 11;
          AchievementsHelper.NotifyProgressionEvent(19);
          break;
        case 4:
          num = (short) 36;
          Type = 11;
          break;
        case 23:
        case 24:
        case 25:
        case 26:
        case 27:
          if (!NPC.downedPlantBoss)
            return false;
          num = (short) 180;
          Type = 11;
          AchievementsHelper.NotifyProgressionEvent(20);
          break;
        case 36:
        case 38:
        case 40:
          num = (short) 36;
          Type = 11;
          break;
        default:
          return false;
      }
      Main.PlaySound(22, X * 16, Y * 16);
      for (int index1 = X; index1 <= X + 1; ++index1)
      {
        for (int index2 = Y; index2 <= Y + 1; ++index2)
        {
          Main.tile[index1, index2].frameX -= num;
          for (int index3 = 0; index3 < 4; ++index3)
            Dust.NewDust(new Vector2((float) (index1 * 16), (float) (index2 * 16)), 16, 16, Type);
        }
      }
      return true;
    }

    public static int UsingChest(int i)
    {
      if (Main.chest[i] != null)
      {
        for (int index = 0; index < (int) byte.MaxValue; ++index)
        {
          if (Main.player[index].active && Main.player[index].chest == i)
            return index;
        }
      }
      return -1;
    }

    public static int FindChest(int X, int Y)
    {
      for (int index = 0; index < 1000; ++index)
      {
        if (Main.chest[index] != null && Main.chest[index].x == X && Main.chest[index].y == Y)
          return index;
      }
      return -1;
    }

    public static int FindChestByGuessing(int X, int Y)
    {
      for (int index = 0; index < 1000; ++index)
      {
        if (Main.chest[index] != null && Main.chest[index].x >= X && Main.chest[index].x < X + 2 && Main.chest[index].y >= Y && Main.chest[index].y < Y + 2)
          return index;
      }
      return -1;
    }

    public static int FindEmptyChest(int x, int y, int type = 21, int style = 0, int direction = 1)
    {
      int num = -1;
      for (int index = 0; index < 1000; ++index)
      {
        Chest chest = Main.chest[index];
        if (chest != null)
        {
          if (chest.x == x && chest.y == y)
            return -1;
        }
        else if (num == -1)
          num = index;
      }
      return num;
    }

    public static bool NearOtherChests(int x, int y)
    {
      for (int i = x - 25; i < x + 25; ++i)
      {
        for (int j = y - 8; j < y + 8; ++j)
        {
          Tile tileSafely = Framing.GetTileSafely(i, j);
          if (tileSafely.active() && TileID.Sets.BasicChest[(int) tileSafely.type])
            return true;
        }
      }
      return false;
    }

    public static int AfterPlacement_Hook(int x, int y, int type = 21, int style = 0, int direction = 1)
    {
      Point16 baseCoords = new Point16(x, y);
      TileObjectData.OriginToTopLeft(type, style, ref baseCoords);
      int emptyChest = Chest.FindEmptyChest((int) baseCoords.X, (int) baseCoords.Y);
      if (emptyChest == -1)
        return -1;
      if (Main.netMode != 1)
      {
        Chest chest = new Chest();
        chest.x = (int) baseCoords.X;
        chest.y = (int) baseCoords.Y;
        for (int index = 0; index < 40; ++index)
          chest.item[index] = new Item();
        Main.chest[emptyChest] = chest;
      }
      else
      {
        switch (type)
        {
          case 21:
            NetMessage.SendData(34, number2: ((float) x), number3: ((float) y), number4: ((float) style));
            break;
          case 467:
            NetMessage.SendData(34, number: 4, number2: ((float) x), number3: ((float) y), number4: ((float) style));
            break;
          default:
            NetMessage.SendData(34, number: 2, number2: ((float) x), number3: ((float) y), number4: ((float) style));
            break;
        }
      }
      return emptyChest;
    }

    public static int CreateChest(int X, int Y, int id = -1)
    {
      int index1 = id;
      if (index1 == -1)
      {
        index1 = Chest.FindEmptyChest(X, Y);
        if (index1 == -1)
          return -1;
        if (Main.netMode == 1)
          return index1;
      }
      Main.chest[index1] = new Chest();
      Main.chest[index1].x = X;
      Main.chest[index1].y = Y;
      for (int index2 = 0; index2 < 40; ++index2)
        Main.chest[index1].item[index2] = new Item();
      return index1;
    }

    public static bool CanDestroyChest(int X, int Y)
    {
      for (int index1 = 0; index1 < 1000; ++index1)
      {
        Chest chest = Main.chest[index1];
        if (chest != null && chest.x == X && chest.y == Y)
        {
          for (int index2 = 0; index2 < 40; ++index2)
          {
            if (chest.item[index2] != null && chest.item[index2].type > 0 && chest.item[index2].stack > 0)
              return false;
          }
          return true;
        }
      }
      return true;
    }

    public static bool DestroyChest(int X, int Y)
    {
      for (int index1 = 0; index1 < 1000; ++index1)
      {
        Chest chest = Main.chest[index1];
        if (chest != null && chest.x == X && chest.y == Y)
        {
          for (int index2 = 0; index2 < 40; ++index2)
          {
            if (chest.item[index2] != null && chest.item[index2].type > 0 && chest.item[index2].stack > 0)
              return false;
          }
          Main.chest[index1] = (Chest) null;
          if (Main.player[Main.myPlayer].chest == index1)
            Main.player[Main.myPlayer].chest = -1;
          Recipe.FindRecipes();
          return true;
        }
      }
      return true;
    }

    public static void DestroyChestDirect(int X, int Y, int id)
    {
      if (id < 0)
        return;
      if (id >= Main.chest.Length)
        return;
      try
      {
        Chest chest = Main.chest[id];
        if (chest == null || chest.x != X || chest.y != Y)
          return;
        Main.chest[id] = (Chest) null;
        if (Main.player[Main.myPlayer].chest == id)
          Main.player[Main.myPlayer].chest = -1;
        Recipe.FindRecipes();
      }
      catch
      {
      }
    }

    public void AddShop(Item newItem)
    {
      for (int index = 0; index < 39; ++index)
      {
        if (this.item[index] == null || this.item[index].type == 0)
        {
          this.item[index] = newItem.Clone();
          this.item[index].favorited = false;
          this.item[index].buyOnce = true;
          if (this.item[index].value <= 0)
            break;
          this.item[index].value /= 5;
          if (this.item[index].value >= 1)
            break;
          this.item[index].value = 1;
          break;
        }
      }
    }

    public static void SetupTravelShop()
    {
      for (int index = 0; index < 40; ++index)
        Main.travelShop[index] = 0;
      int num1 = Main.rand.Next(4, 7);
      if (Main.rand.Next(4) == 0)
        ++num1;
      if (Main.rand.Next(8) == 0)
        ++num1;
      if (Main.rand.Next(16) == 0)
        ++num1;
      if (Main.rand.Next(32) == 0)
        ++num1;
      if (Main.expertMode && Main.rand.Next(2) == 0)
        ++num1;
      int index1 = 0;
      int num2 = 0;
      int[] numArray = new int[6]
      {
        100,
        200,
        300,
        400,
        500,
        600
      };
      while (num2 < num1)
      {
        int num3 = 0;
        if (Main.rand.Next(numArray[4]) == 0)
          num3 = 3309;
        if (Main.rand.Next(numArray[3]) == 0)
          num3 = 3314;
        if (Main.rand.Next(numArray[5]) == 0)
          num3 = 1987;
        if (Main.rand.Next(numArray[4]) == 0 && Main.hardMode)
          num3 = 2270;
        if (Main.rand.Next(numArray[4]) == 0)
          num3 = 2278;
        if (Main.rand.Next(numArray[4]) == 0)
          num3 = 2271;
        if (Main.rand.Next(numArray[3]) == 0 && Main.hardMode && NPC.downedPlantBoss)
          num3 = 2223;
        if (Main.rand.Next(numArray[3]) == 0)
          num3 = 2272;
        if (Main.rand.Next(numArray[3]) == 0)
          num3 = 2219;
        if (Main.rand.Next(numArray[3]) == 0)
          num3 = 2276;
        if (Main.rand.Next(numArray[3]) == 0)
          num3 = 2284;
        if (Main.rand.Next(numArray[3]) == 0)
          num3 = 2285;
        if (Main.rand.Next(numArray[3]) == 0)
          num3 = 2286;
        if (Main.rand.Next(numArray[3]) == 0)
          num3 = 2287;
        if (Main.rand.Next(numArray[3]) == 0)
          num3 = 2296;
        if (Main.rand.Next(numArray[3]) == 0)
          num3 = 3628;
        if (Main.rand.Next(numArray[2]) == 0 && WorldGen.shadowOrbSmashed)
          num3 = 2269;
        if (Main.rand.Next(numArray[2]) == 0)
          num3 = 2177;
        if (Main.rand.Next(numArray[2]) == 0)
          num3 = 1988;
        if (Main.rand.Next(numArray[2]) == 0)
          num3 = 2275;
        if (Main.rand.Next(numArray[2]) == 0)
          num3 = 2279;
        if (Main.rand.Next(numArray[2]) == 0)
          num3 = 2277;
        if (Main.rand.Next(numArray[2]) == 0 && NPC.downedBoss1)
          num3 = 3262;
        if (Main.rand.Next(numArray[2]) == 0 && NPC.downedMechBossAny)
          num3 = 3284;
        if (Main.rand.Next(numArray[2]) == 0 && Main.hardMode && NPC.downedMoonlord)
          num3 = 3596;
        if (Main.rand.Next(numArray[2]) == 0 && Main.hardMode && NPC.downedMartians)
          num3 = 2865;
        if (Main.rand.Next(numArray[2]) == 0 && Main.hardMode && NPC.downedMartians)
          num3 = 2866;
        if (Main.rand.Next(numArray[2]) == 0 && Main.hardMode && NPC.downedMartians)
          num3 = 2867;
        if (Main.rand.Next(numArray[2]) == 0 && Main.xMas)
          num3 = 3055;
        if (Main.rand.Next(numArray[2]) == 0 && Main.xMas)
          num3 = 3056;
        if (Main.rand.Next(numArray[2]) == 0 && Main.xMas)
          num3 = 3057;
        if (Main.rand.Next(numArray[2]) == 0 && Main.xMas)
          num3 = 3058;
        if (Main.rand.Next(numArray[2]) == 0 && Main.xMas)
          num3 = 3059;
        if (Main.rand.Next(numArray[1]) == 0)
          num3 = 2214;
        if (Main.rand.Next(numArray[1]) == 0)
          num3 = 2215;
        if (Main.rand.Next(numArray[1]) == 0)
          num3 = 2216;
        if (Main.rand.Next(numArray[1]) == 0)
          num3 = 2217;
        if (Main.rand.Next(numArray[1]) == 0)
          num3 = 3624;
        if (Main.rand.Next(numArray[1]) == 0)
          num3 = 2273;
        if (Main.rand.Next(numArray[1]) == 0)
          num3 = 2274;
        if (Main.rand.Next(numArray[0]) == 0)
          num3 = 2266;
        if (Main.rand.Next(numArray[0]) == 0)
          num3 = 2267;
        if (Main.rand.Next(numArray[0]) == 0)
          num3 = 2268;
        if (Main.rand.Next(numArray[0]) == 0)
          num3 = 2281 + Main.rand.Next(3);
        if (Main.rand.Next(numArray[0]) == 0)
          num3 = 2258;
        if (Main.rand.Next(numArray[0]) == 0)
          num3 = 2242;
        if (Main.rand.Next(numArray[0]) == 0)
          num3 = 2260;
        if (Main.rand.Next(numArray[0]) == 0)
          num3 = 3637;
        if (Main.rand.Next(numArray[0]) == 0)
          num3 = 3119;
        if (Main.rand.Next(numArray[0]) == 0)
          num3 = 3118;
        if (Main.rand.Next(numArray[0]) == 0)
          num3 = 3099;
        if (num3 != 0)
        {
          for (int index2 = 0; index2 < 40; ++index2)
          {
            if (Main.travelShop[index2] == num3)
            {
              num3 = 0;
              break;
            }
            if (num3 == 3637)
            {
              switch (Main.travelShop[index2])
              {
                case 3621:
                case 3622:
                case 3633:
                case 3634:
                case 3635:
                case 3636:
                case 3637:
                case 3638:
                case 3639:
                case 3640:
                case 3641:
                case 3642:
                  num3 = 0;
                  break;
              }
              if (num3 == 0)
                break;
            }
          }
        }
        if (num3 != 0)
        {
          ++num2;
          Main.travelShop[index1] = num3;
          ++index1;
          if (num3 == 2260)
          {
            Main.travelShop[index1] = 2261;
            int index3 = index1 + 1;
            Main.travelShop[index3] = 2262;
            index1 = index3 + 1;
          }
          if (num3 == 3637)
          {
            --index1;
            switch (Main.rand.Next(6))
            {
              case 0:
                int[] travelShop1 = Main.travelShop;
                int index4 = index1;
                int num4 = index4 + 1;
                travelShop1[index4] = 3637;
                int[] travelShop2 = Main.travelShop;
                int index5 = num4;
                index1 = index5 + 1;
                travelShop2[index5] = 3642;
                continue;
              case 1:
                int[] travelShop3 = Main.travelShop;
                int index6 = index1;
                int num5 = index6 + 1;
                travelShop3[index6] = 3621;
                int[] travelShop4 = Main.travelShop;
                int index7 = num5;
                index1 = index7 + 1;
                travelShop4[index7] = 3622;
                continue;
              case 2:
                int[] travelShop5 = Main.travelShop;
                int index8 = index1;
                int num6 = index8 + 1;
                travelShop5[index8] = 3634;
                int[] travelShop6 = Main.travelShop;
                int index9 = num6;
                index1 = index9 + 1;
                travelShop6[index9] = 3639;
                continue;
              case 3:
                int[] travelShop7 = Main.travelShop;
                int index10 = index1;
                int num7 = index10 + 1;
                travelShop7[index10] = 3633;
                int[] travelShop8 = Main.travelShop;
                int index11 = num7;
                index1 = index11 + 1;
                travelShop8[index11] = 3638;
                continue;
              case 4:
                int[] travelShop9 = Main.travelShop;
                int index12 = index1;
                int num8 = index12 + 1;
                travelShop9[index12] = 3635;
                int[] travelShop10 = Main.travelShop;
                int index13 = num8;
                index1 = index13 + 1;
                travelShop10[index13] = 3640;
                continue;
              case 5:
                int[] travelShop11 = Main.travelShop;
                int index14 = index1;
                int num9 = index14 + 1;
                travelShop11[index14] = 3636;
                int[] travelShop12 = Main.travelShop;
                int index15 = num9;
                index1 = index15 + 1;
                travelShop12[index15] = 3641;
                continue;
              default:
                continue;
            }
          }
        }
      }
    }

    public void SetupShop(int type)
    {
      for (int index = 0; index < 40; ++index)
        this.item[index] = new Item();
      int index1 = 0;
      switch (type)
      {
        case 1:
          this.item[index1].SetDefaults(88);
          int index2 = index1 + 1;
          this.item[index2].SetDefaults(87);
          int index3 = index2 + 1;
          this.item[index3].SetDefaults(35);
          int index4 = index3 + 1;
          this.item[index4].SetDefaults(1991);
          int index5 = index4 + 1;
          this.item[index5].SetDefaults(3509);
          int index6 = index5 + 1;
          this.item[index6].SetDefaults(3506);
          int index7 = index6 + 1;
          this.item[index7].SetDefaults(8);
          int index8 = index7 + 1;
          this.item[index8].SetDefaults(28);
          int index9 = index8 + 1;
          this.item[index9].SetDefaults(110);
          int index10 = index9 + 1;
          this.item[index10].SetDefaults(40);
          int index11 = index10 + 1;
          this.item[index11].SetDefaults(42);
          int index12 = index11 + 1;
          this.item[index12].SetDefaults(965);
          int index13 = index12 + 1;
          if (Main.player[Main.myPlayer].ZoneSnow)
          {
            this.item[index13].SetDefaults(967);
            ++index13;
          }
          if (Main.bloodMoon)
          {
            this.item[index13].SetDefaults(279);
            ++index13;
          }
          if (!Main.dayTime)
          {
            this.item[index13].SetDefaults(282);
            ++index13;
          }
          if (NPC.downedBoss3)
          {
            this.item[index13].SetDefaults(346);
            ++index13;
          }
          if (Main.hardMode)
          {
            this.item[index13].SetDefaults(488);
            ++index13;
          }
          for (int index14 = 0; index14 < 58; ++index14)
          {
            if (Main.player[Main.myPlayer].inventory[index14].type == 930)
            {
              this.item[index13].SetDefaults(931);
              int index15 = index13 + 1;
              this.item[index15].SetDefaults(1614);
              index13 = index15 + 1;
              break;
            }
          }
          this.item[index13].SetDefaults(1786);
          index1 = index13 + 1;
          if (Main.hardMode)
          {
            this.item[index1].SetDefaults(1348);
            ++index1;
          }
          if (Main.player[Main.myPlayer].HasItem(3107))
          {
            this.item[index1].SetDefaults(3108);
            ++index1;
          }
          if (Main.halloween)
          {
            Item[] objArray1 = this.item;
            int index16 = index1;
            int num1 = index16 + 1;
            objArray1[index16].SetDefaults(3242);
            Item[] objArray2 = this.item;
            int index17 = num1;
            int num2 = index17 + 1;
            objArray2[index17].SetDefaults(3243);
            Item[] objArray3 = this.item;
            int index18 = num2;
            index1 = index18 + 1;
            objArray3[index18].SetDefaults(3244);
            break;
          }
          break;
        case 2:
          this.item[index1].SetDefaults(97);
          int index19 = index1 + 1;
          if (Main.bloodMoon || Main.hardMode)
          {
            this.item[index19].SetDefaults(278);
            ++index19;
          }
          if (NPC.downedBoss2 && !Main.dayTime || Main.hardMode)
          {
            this.item[index19].SetDefaults(47);
            ++index19;
          }
          this.item[index19].SetDefaults(95);
          int index20 = index19 + 1;
          this.item[index20].SetDefaults(98);
          index1 = index20 + 1;
          if (!Main.dayTime)
          {
            this.item[index1].SetDefaults(324);
            ++index1;
          }
          if (Main.hardMode)
          {
            this.item[index1].SetDefaults(534);
            ++index1;
          }
          if (Main.hardMode)
          {
            this.item[index1].SetDefaults(1432);
            ++index1;
          }
          if (Main.player[Main.myPlayer].HasItem(1258))
          {
            this.item[index1].SetDefaults(1261);
            ++index1;
          }
          if (Main.player[Main.myPlayer].HasItem(1835))
          {
            this.item[index1].SetDefaults(1836);
            ++index1;
          }
          if (Main.player[Main.myPlayer].HasItem(3107))
          {
            this.item[index1].SetDefaults(3108);
            ++index1;
          }
          if (Main.player[Main.myPlayer].HasItem(1782))
          {
            this.item[index1].SetDefaults(1783);
            ++index1;
          }
          if (Main.player[Main.myPlayer].HasItem(1784))
          {
            this.item[index1].SetDefaults(1785);
            ++index1;
          }
          if (Main.halloween)
          {
            this.item[index1].SetDefaults(1736);
            int index21 = index1 + 1;
            this.item[index21].SetDefaults(1737);
            int index22 = index21 + 1;
            this.item[index22].SetDefaults(1738);
            index1 = index22 + 1;
            break;
          }
          break;
        case 3:
          int index23;
          if (Main.bloodMoon)
          {
            if (WorldGen.crimson)
            {
              this.item[index1].SetDefaults(2886);
              int index24 = index1 + 1;
              this.item[index24].SetDefaults(2171);
              index23 = index24 + 1;
            }
            else
            {
              this.item[index1].SetDefaults(67);
              int index25 = index1 + 1;
              this.item[index25].SetDefaults(59);
              index23 = index25 + 1;
            }
          }
          else
          {
            this.item[index1].SetDefaults(66);
            int index26 = index1 + 1;
            this.item[index26].SetDefaults(62);
            int index27 = index26 + 1;
            this.item[index27].SetDefaults(63);
            index23 = index27 + 1;
          }
          this.item[index23].SetDefaults(27);
          int index28 = index23 + 1;
          this.item[index28].SetDefaults(114);
          int index29 = index28 + 1;
          this.item[index29].SetDefaults(1828);
          int index30 = index29 + 1;
          this.item[index30].SetDefaults(745);
          int index31 = index30 + 1;
          this.item[index31].SetDefaults(747);
          index1 = index31 + 1;
          if (Main.hardMode)
          {
            this.item[index1].SetDefaults(746);
            ++index1;
          }
          if (Main.hardMode)
          {
            this.item[index1].SetDefaults(369);
            ++index1;
          }
          if (Main.shroomTiles > 50)
          {
            this.item[index1].SetDefaults(194);
            ++index1;
          }
          if (Main.halloween)
          {
            this.item[index1].SetDefaults(1853);
            int index32 = index1 + 1;
            this.item[index32].SetDefaults(1854);
            index1 = index32 + 1;
          }
          if (NPC.downedSlimeKing)
          {
            this.item[index1].SetDefaults(3215);
            ++index1;
          }
          if (NPC.downedQueenBee)
          {
            this.item[index1].SetDefaults(3216);
            ++index1;
          }
          if (NPC.downedBoss1)
          {
            this.item[index1].SetDefaults(3219);
            ++index1;
          }
          if (NPC.downedBoss2)
          {
            if (WorldGen.crimson)
            {
              this.item[index1].SetDefaults(3218);
              ++index1;
            }
            else
            {
              this.item[index1].SetDefaults(3217);
              ++index1;
            }
          }
          if (NPC.downedBoss3)
          {
            this.item[index1].SetDefaults(3220);
            int index33 = index1 + 1;
            this.item[index33].SetDefaults(3221);
            index1 = index33 + 1;
          }
          if (Main.hardMode)
          {
            this.item[index1].SetDefaults(3222);
            ++index1;
            break;
          }
          break;
        case 4:
          this.item[index1].SetDefaults(168);
          int index34 = index1 + 1;
          this.item[index34].SetDefaults(166);
          int index35 = index34 + 1;
          this.item[index35].SetDefaults(167);
          index1 = index35 + 1;
          if (Main.hardMode)
          {
            this.item[index1].SetDefaults(265);
            ++index1;
          }
          if (Main.hardMode && NPC.downedPlantBoss && NPC.downedPirates)
          {
            this.item[index1].SetDefaults(937);
            ++index1;
          }
          if (Main.hardMode)
          {
            this.item[index1].SetDefaults(1347);
            ++index1;
            break;
          }
          break;
        case 5:
          this.item[index1].SetDefaults(254);
          int index36 = index1 + 1;
          this.item[index36].SetDefaults(981);
          int index37 = index36 + 1;
          if (Main.dayTime)
          {
            this.item[index37].SetDefaults(242);
            ++index37;
          }
          switch (Main.moonPhase)
          {
            case 0:
              this.item[index37].SetDefaults(245);
              int index38 = index37 + 1;
              this.item[index38].SetDefaults(246);
              index37 = index38 + 1;
              if (!Main.dayTime)
              {
                Item[] objArray4 = this.item;
                int index39 = index37;
                int num = index39 + 1;
                objArray4[index39].SetDefaults(1288);
                Item[] objArray5 = this.item;
                int index40 = num;
                index37 = index40 + 1;
                objArray5[index40].SetDefaults(1289);
                break;
              }
              break;
            case 1:
              this.item[index37].SetDefaults(325);
              int index41 = index37 + 1;
              this.item[index41].SetDefaults(326);
              index37 = index41 + 1;
              break;
          }
          this.item[index37].SetDefaults(269);
          int index42 = index37 + 1;
          this.item[index42].SetDefaults(270);
          int index43 = index42 + 1;
          this.item[index43].SetDefaults(271);
          index1 = index43 + 1;
          if (NPC.downedClown)
          {
            this.item[index1].SetDefaults(503);
            int index44 = index1 + 1;
            this.item[index44].SetDefaults(504);
            int index45 = index44 + 1;
            this.item[index45].SetDefaults(505);
            index1 = index45 + 1;
          }
          if (Main.bloodMoon)
          {
            this.item[index1].SetDefaults(322);
            ++index1;
            if (!Main.dayTime)
            {
              Item[] objArray6 = this.item;
              int index46 = index1;
              int num = index46 + 1;
              objArray6[index46].SetDefaults(3362);
              Item[] objArray7 = this.item;
              int index47 = num;
              index1 = index47 + 1;
              objArray7[index47].SetDefaults(3363);
            }
          }
          if (NPC.downedAncientCultist)
          {
            if (Main.dayTime)
            {
              Item[] objArray8 = this.item;
              int index48 = index1;
              int num = index48 + 1;
              objArray8[index48].SetDefaults(2856);
              Item[] objArray9 = this.item;
              int index49 = num;
              index1 = index49 + 1;
              objArray9[index49].SetDefaults(2858);
            }
            else
            {
              Item[] objArray10 = this.item;
              int index50 = index1;
              int num = index50 + 1;
              objArray10[index50].SetDefaults(2857);
              Item[] objArray11 = this.item;
              int index51 = num;
              index1 = index51 + 1;
              objArray11[index51].SetDefaults(2859);
            }
          }
          if (NPC.AnyNPCs(441))
          {
            Item[] objArray12 = this.item;
            int index52 = index1;
            int num3 = index52 + 1;
            objArray12[index52].SetDefaults(3242);
            Item[] objArray13 = this.item;
            int index53 = num3;
            int num4 = index53 + 1;
            objArray13[index53].SetDefaults(3243);
            Item[] objArray14 = this.item;
            int index54 = num4;
            index1 = index54 + 1;
            objArray14[index54].SetDefaults(3244);
          }
          if (Main.player[Main.myPlayer].ZoneSnow)
          {
            this.item[index1].SetDefaults(1429);
            ++index1;
          }
          if (Main.halloween)
          {
            this.item[index1].SetDefaults(1740);
            ++index1;
          }
          if (Main.hardMode)
          {
            if (Main.moonPhase == 2)
            {
              this.item[index1].SetDefaults(869);
              ++index1;
            }
            if (Main.moonPhase == 4)
            {
              this.item[index1].SetDefaults(864);
              int index55 = index1 + 1;
              this.item[index55].SetDefaults(865);
              index1 = index55 + 1;
            }
            if (Main.moonPhase == 6)
            {
              this.item[index1].SetDefaults(873);
              int index56 = index1 + 1;
              this.item[index56].SetDefaults(874);
              int index57 = index56 + 1;
              this.item[index57].SetDefaults(875);
              index1 = index57 + 1;
            }
          }
          if (NPC.downedFrost)
          {
            this.item[index1].SetDefaults(1275);
            int index58 = index1 + 1;
            this.item[index58].SetDefaults(1276);
            index1 = index58 + 1;
          }
          if (Main.halloween)
          {
            Item[] objArray15 = this.item;
            int index59 = index1;
            int num = index59 + 1;
            objArray15[index59].SetDefaults(3246);
            Item[] objArray16 = this.item;
            int index60 = num;
            index1 = index60 + 1;
            objArray16[index60].SetDefaults(3247);
          }
          if (BirthdayParty.PartyIsUp)
          {
            Item[] objArray17 = this.item;
            int index61 = index1;
            int num5 = index61 + 1;
            objArray17[index61].SetDefaults(3730);
            Item[] objArray18 = this.item;
            int index62 = num5;
            int num6 = index62 + 1;
            objArray18[index62].SetDefaults(3731);
            Item[] objArray19 = this.item;
            int index63 = num6;
            int num7 = index63 + 1;
            objArray19[index63].SetDefaults(3733);
            Item[] objArray20 = this.item;
            int index64 = num7;
            int num8 = index64 + 1;
            objArray20[index64].SetDefaults(3734);
            Item[] objArray21 = this.item;
            int index65 = num8;
            index1 = index65 + 1;
            objArray21[index65].SetDefaults(3735);
            break;
          }
          break;
        case 6:
          this.item[index1].SetDefaults(128);
          int index66 = index1 + 1;
          this.item[index66].SetDefaults(486);
          int index67 = index66 + 1;
          this.item[index67].SetDefaults(398);
          int index68 = index67 + 1;
          this.item[index68].SetDefaults(84);
          int index69 = index68 + 1;
          this.item[index69].SetDefaults(407);
          int index70 = index69 + 1;
          this.item[index70].SetDefaults(161);
          index1 = index70 + 1;
          break;
        case 7:
          this.item[index1].SetDefaults(487);
          int index71 = index1 + 1;
          this.item[index71].SetDefaults(496);
          int index72 = index71 + 1;
          this.item[index72].SetDefaults(500);
          int index73 = index72 + 1;
          this.item[index73].SetDefaults(507);
          int index74 = index73 + 1;
          this.item[index74].SetDefaults(508);
          int index75 = index74 + 1;
          this.item[index75].SetDefaults(531);
          int index76 = index75 + 1;
          this.item[index76].SetDefaults(576);
          int index77 = index76 + 1;
          this.item[index77].SetDefaults(3186);
          index1 = index77 + 1;
          if (Main.halloween)
          {
            this.item[index1].SetDefaults(1739);
            ++index1;
            break;
          }
          break;
        case 8:
          this.item[index1].SetDefaults(509);
          int index78 = index1 + 1;
          this.item[index78].SetDefaults(850);
          int index79 = index78 + 1;
          this.item[index79].SetDefaults(851);
          int index80 = index79 + 1;
          this.item[index80].SetDefaults(3612);
          int index81 = index80 + 1;
          this.item[index81].SetDefaults(510);
          int index82 = index81 + 1;
          this.item[index82].SetDefaults(530);
          int index83 = index82 + 1;
          this.item[index83].SetDefaults(513);
          int index84 = index83 + 1;
          this.item[index84].SetDefaults(538);
          int index85 = index84 + 1;
          this.item[index85].SetDefaults(529);
          int index86 = index85 + 1;
          this.item[index86].SetDefaults(541);
          int index87 = index86 + 1;
          this.item[index87].SetDefaults(542);
          int index88 = index87 + 1;
          this.item[index88].SetDefaults(543);
          int index89 = index88 + 1;
          this.item[index89].SetDefaults(852);
          int index90 = index89 + 1;
          this.item[index90].SetDefaults(853);
          int num9 = index90 + 1;
          Item[] objArray22 = this.item;
          int index91 = num9;
          int index92 = index91 + 1;
          objArray22[index91].SetDefaults(3707);
          this.item[index92].SetDefaults(2739);
          int index93 = index92 + 1;
          this.item[index93].SetDefaults(849);
          int num10 = index93 + 1;
          Item[] objArray23 = this.item;
          int index94 = num10;
          int num11 = index94 + 1;
          objArray23[index94].SetDefaults(3616);
          Item[] objArray24 = this.item;
          int index95 = num11;
          int num12 = index95 + 1;
          objArray24[index95].SetDefaults(2799);
          Item[] objArray25 = this.item;
          int index96 = num12;
          int num13 = index96 + 1;
          objArray25[index96].SetDefaults(3619);
          Item[] objArray26 = this.item;
          int index97 = num13;
          int num14 = index97 + 1;
          objArray26[index97].SetDefaults(3627);
          Item[] objArray27 = this.item;
          int index98 = num14;
          index1 = index98 + 1;
          objArray27[index98].SetDefaults(3629);
          if (NPC.AnyNPCs(369) && Main.hardMode && Main.moonPhase == 3)
          {
            this.item[index1].SetDefaults(2295);
            ++index1;
            break;
          }
          break;
        case 9:
          this.item[index1].SetDefaults(588);
          int index99 = index1 + 1;
          this.item[index99].SetDefaults(589);
          int index100 = index99 + 1;
          this.item[index100].SetDefaults(590);
          int index101 = index100 + 1;
          this.item[index101].SetDefaults(597);
          int index102 = index101 + 1;
          this.item[index102].SetDefaults(598);
          int index103 = index102 + 1;
          this.item[index103].SetDefaults(596);
          index1 = index103 + 1;
          for (int Type = 1873; Type < 1906; ++Type)
          {
            this.item[index1].SetDefaults(Type);
            ++index1;
          }
          break;
        case 10:
          if (NPC.downedMechBossAny)
          {
            this.item[index1].SetDefaults(756);
            int index104 = index1 + 1;
            this.item[index104].SetDefaults(787);
            index1 = index104 + 1;
          }
          this.item[index1].SetDefaults(868);
          int index105 = index1 + 1;
          if (NPC.downedPlantBoss)
          {
            this.item[index105].SetDefaults(1551);
            ++index105;
          }
          this.item[index105].SetDefaults(1181);
          int index106 = index105 + 1;
          this.item[index106].SetDefaults(783);
          index1 = index106 + 1;
          break;
        case 11:
          this.item[index1].SetDefaults(779);
          int index107 = index1 + 1;
          int index108;
          if (Main.moonPhase >= 4)
          {
            this.item[index107].SetDefaults(748);
            index108 = index107 + 1;
          }
          else
          {
            this.item[index107].SetDefaults(839);
            int index109 = index107 + 1;
            this.item[index109].SetDefaults(840);
            int index110 = index109 + 1;
            this.item[index110].SetDefaults(841);
            index108 = index110 + 1;
          }
          if (NPC.downedGolemBoss)
          {
            this.item[index108].SetDefaults(948);
            ++index108;
          }
          Item[] objArray28 = this.item;
          int index111 = index108;
          int num15 = index111 + 1;
          objArray28[index111].SetDefaults(3623);
          Item[] objArray29 = this.item;
          int index112 = num15;
          int num16 = index112 + 1;
          objArray29[index112].SetDefaults(3603);
          Item[] objArray30 = this.item;
          int index113 = num16;
          int num17 = index113 + 1;
          objArray30[index113].SetDefaults(3604);
          Item[] objArray31 = this.item;
          int index114 = num17;
          int num18 = index114 + 1;
          objArray31[index114].SetDefaults(3607);
          Item[] objArray32 = this.item;
          int index115 = num18;
          int num19 = index115 + 1;
          objArray32[index115].SetDefaults(3605);
          Item[] objArray33 = this.item;
          int index116 = num19;
          int num20 = index116 + 1;
          objArray33[index116].SetDefaults(3606);
          Item[] objArray34 = this.item;
          int index117 = num20;
          int num21 = index117 + 1;
          objArray34[index117].SetDefaults(3608);
          Item[] objArray35 = this.item;
          int index118 = num21;
          int num22 = index118 + 1;
          objArray35[index118].SetDefaults(3618);
          Item[] objArray36 = this.item;
          int index119 = num22;
          int num23 = index119 + 1;
          objArray36[index119].SetDefaults(3602);
          Item[] objArray37 = this.item;
          int index120 = num23;
          int num24 = index120 + 1;
          objArray37[index120].SetDefaults(3663);
          Item[] objArray38 = this.item;
          int index121 = num24;
          int num25 = index121 + 1;
          objArray38[index121].SetDefaults(3609);
          Item[] objArray39 = this.item;
          int index122 = num25;
          int index123 = index122 + 1;
          objArray39[index122].SetDefaults(3610);
          this.item[index123].SetDefaults(995);
          int index124 = index123 + 1;
          if (NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3)
          {
            this.item[index124].SetDefaults(2203);
            ++index124;
          }
          if (WorldGen.crimson)
          {
            this.item[index124].SetDefaults(2193);
            ++index124;
          }
          this.item[index124].SetDefaults(1263);
          int index125 = index124 + 1;
          if (Main.eclipse || Main.bloodMoon)
          {
            if (WorldGen.crimson)
            {
              this.item[index125].SetDefaults(784);
              index1 = index125 + 1;
            }
            else
            {
              this.item[index125].SetDefaults(782);
              index1 = index125 + 1;
            }
          }
          else if (Main.player[Main.myPlayer].ZoneHoly)
          {
            this.item[index125].SetDefaults(781);
            index1 = index125 + 1;
          }
          else
          {
            this.item[index125].SetDefaults(780);
            index1 = index125 + 1;
          }
          if (Main.hardMode)
          {
            this.item[index1].SetDefaults(1344);
            ++index1;
          }
          if (Main.halloween)
          {
            this.item[index1].SetDefaults(1742);
            ++index1;
            break;
          }
          break;
        case 12:
          this.item[index1].SetDefaults(1037);
          int index126 = index1 + 1;
          this.item[index126].SetDefaults(2874);
          int index127 = index126 + 1;
          this.item[index127].SetDefaults(1120);
          index1 = index127 + 1;
          if (Main.netMode == 1)
          {
            this.item[index1].SetDefaults(1969);
            ++index1;
          }
          if (Main.halloween)
          {
            this.item[index1].SetDefaults(3248);
            int index128 = index1 + 1;
            this.item[index128].SetDefaults(1741);
            index1 = index128 + 1;
          }
          if (Main.moonPhase == 0)
          {
            this.item[index1].SetDefaults(2871);
            int index129 = index1 + 1;
            this.item[index129].SetDefaults(2872);
            index1 = index129 + 1;
            break;
          }
          break;
        case 13:
          this.item[index1].SetDefaults(859);
          int index130 = index1 + 1;
          this.item[index130].SetDefaults(1000);
          int index131 = index130 + 1;
          this.item[index131].SetDefaults(1168);
          int index132 = index131 + 1;
          this.item[index132].SetDefaults(1449);
          int index133 = index132 + 1;
          this.item[index133].SetDefaults(1345);
          int index134 = index133 + 1;
          this.item[index134].SetDefaults(1450);
          int num26 = index134 + 1;
          Item[] objArray40 = this.item;
          int index135 = num26;
          int num27 = index135 + 1;
          objArray40[index135].SetDefaults(3253);
          Item[] objArray41 = this.item;
          int index136 = num27;
          int num28 = index136 + 1;
          objArray41[index136].SetDefaults(2700);
          Item[] objArray42 = this.item;
          int index137 = num28;
          int index138 = index137 + 1;
          objArray42[index137].SetDefaults(2738);
          if (Main.player[Main.myPlayer].HasItem(3548))
          {
            this.item[index138].SetDefaults(3548);
            ++index138;
          }
          if (NPC.AnyNPCs(229))
            this.item[index138++].SetDefaults(3369);
          if (Main.hardMode)
          {
            this.item[index138].SetDefaults(3214);
            int index139 = index138 + 1;
            this.item[index139].SetDefaults(2868);
            int index140 = index139 + 1;
            this.item[index140].SetDefaults(970);
            int index141 = index140 + 1;
            this.item[index141].SetDefaults(971);
            int index142 = index141 + 1;
            this.item[index142].SetDefaults(972);
            int index143 = index142 + 1;
            this.item[index143].SetDefaults(973);
            index138 = index143 + 1;
          }
          Item[] objArray43 = this.item;
          int index144 = index138;
          int num29 = index144 + 1;
          objArray43[index144].SetDefaults(3747);
          Item[] objArray44 = this.item;
          int index145 = num29;
          int num30 = index145 + 1;
          objArray44[index145].SetDefaults(3732);
          Item[] objArray45 = this.item;
          int index146 = num30;
          index1 = index146 + 1;
          objArray45[index146].SetDefaults(3742);
          if (BirthdayParty.PartyIsUp)
          {
            Item[] objArray46 = this.item;
            int index147 = index1;
            int num31 = index147 + 1;
            objArray46[index147].SetDefaults(3749);
            Item[] objArray47 = this.item;
            int index148 = num31;
            int num32 = index148 + 1;
            objArray47[index148].SetDefaults(3746);
            Item[] objArray48 = this.item;
            int index149 = num32;
            int num33 = index149 + 1;
            objArray48[index149].SetDefaults(3739);
            Item[] objArray49 = this.item;
            int index150 = num33;
            int num34 = index150 + 1;
            objArray49[index150].SetDefaults(3740);
            Item[] objArray50 = this.item;
            int index151 = num34;
            int num35 = index151 + 1;
            objArray50[index151].SetDefaults(3741);
            Item[] objArray51 = this.item;
            int index152 = num35;
            int num36 = index152 + 1;
            objArray51[index152].SetDefaults(3737);
            Item[] objArray52 = this.item;
            int index153 = num36;
            int num37 = index153 + 1;
            objArray52[index153].SetDefaults(3738);
            Item[] objArray53 = this.item;
            int index154 = num37;
            int num38 = index154 + 1;
            objArray53[index154].SetDefaults(3736);
            Item[] objArray54 = this.item;
            int index155 = num38;
            int num39 = index155 + 1;
            objArray54[index155].SetDefaults(3745);
            Item[] objArray55 = this.item;
            int index156 = num39;
            int num40 = index156 + 1;
            objArray55[index156].SetDefaults(3744);
            Item[] objArray56 = this.item;
            int index157 = num40;
            index1 = index157 + 1;
            objArray56[index157].SetDefaults(3743);
            break;
          }
          break;
        case 14:
          this.item[index1].SetDefaults(771);
          ++index1;
          if (Main.bloodMoon)
          {
            this.item[index1].SetDefaults(772);
            ++index1;
          }
          if (!Main.dayTime || Main.eclipse)
          {
            this.item[index1].SetDefaults(773);
            ++index1;
          }
          if (Main.eclipse)
          {
            this.item[index1].SetDefaults(774);
            ++index1;
          }
          if (Main.hardMode)
          {
            this.item[index1].SetDefaults(760);
            ++index1;
          }
          if (Main.hardMode)
          {
            this.item[index1].SetDefaults(1346);
            ++index1;
          }
          if (Main.halloween)
          {
            this.item[index1].SetDefaults(1743);
            int index158 = index1 + 1;
            this.item[index158].SetDefaults(1744);
            int index159 = index158 + 1;
            this.item[index159].SetDefaults(1745);
            index1 = index159 + 1;
          }
          if (NPC.downedMartians)
          {
            Item[] objArray57 = this.item;
            int index160 = index1;
            int num41 = index160 + 1;
            objArray57[index160].SetDefaults(2862);
            Item[] objArray58 = this.item;
            int index161 = num41;
            index1 = index161 + 1;
            objArray58[index161].SetDefaults(3109);
          }
          if (Main.player[Main.myPlayer].HasItem(3384) || Main.player[Main.myPlayer].HasItem(3664))
          {
            this.item[index1].SetDefaults(3664);
            ++index1;
            break;
          }
          break;
        case 15:
          this.item[index1].SetDefaults(1071);
          int index162 = index1 + 1;
          this.item[index162].SetDefaults(1072);
          int index163 = index162 + 1;
          this.item[index163].SetDefaults(1100);
          int index164 = index163 + 1;
          for (int Type = 1073; Type <= 1084; ++Type)
          {
            this.item[index164].SetDefaults(Type);
            ++index164;
          }
          this.item[index164].SetDefaults(1097);
          int index165 = index164 + 1;
          this.item[index165].SetDefaults(1099);
          int index166 = index165 + 1;
          this.item[index166].SetDefaults(1098);
          int index167 = index166 + 1;
          this.item[index167].SetDefaults(1966);
          int index168 = index167 + 1;
          if (Main.hardMode)
          {
            this.item[index168].SetDefaults(1967);
            int index169 = index168 + 1;
            this.item[index169].SetDefaults(1968);
            index168 = index169 + 1;
          }
          this.item[index168].SetDefaults(1490);
          int index170 = index168 + 1;
          if (Main.moonPhase <= 1)
          {
            this.item[index170].SetDefaults(1481);
            index1 = index170 + 1;
          }
          else if (Main.moonPhase <= 3)
          {
            this.item[index170].SetDefaults(1482);
            index1 = index170 + 1;
          }
          else if (Main.moonPhase <= 5)
          {
            this.item[index170].SetDefaults(1483);
            index1 = index170 + 1;
          }
          else
          {
            this.item[index170].SetDefaults(1484);
            index1 = index170 + 1;
          }
          if (Main.player[Main.myPlayer].ZoneCrimson)
          {
            this.item[index1].SetDefaults(1492);
            ++index1;
          }
          if (Main.player[Main.myPlayer].ZoneCorrupt)
          {
            this.item[index1].SetDefaults(1488);
            ++index1;
          }
          if (Main.player[Main.myPlayer].ZoneHoly)
          {
            this.item[index1].SetDefaults(1489);
            ++index1;
          }
          if (Main.player[Main.myPlayer].ZoneJungle)
          {
            this.item[index1].SetDefaults(1486);
            ++index1;
          }
          if (Main.player[Main.myPlayer].ZoneSnow)
          {
            this.item[index1].SetDefaults(1487);
            ++index1;
          }
          if (Main.sandTiles > 1000)
          {
            this.item[index1].SetDefaults(1491);
            ++index1;
          }
          if (Main.bloodMoon)
          {
            this.item[index1].SetDefaults(1493);
            ++index1;
          }
          if ((double) Main.player[Main.myPlayer].position.Y / 16.0 < Main.worldSurface * 0.349999994039536)
          {
            this.item[index1].SetDefaults(1485);
            ++index1;
          }
          if ((double) Main.player[Main.myPlayer].position.Y / 16.0 < Main.worldSurface * 0.349999994039536 && Main.hardMode)
          {
            this.item[index1].SetDefaults(1494);
            ++index1;
          }
          if (Main.xMas)
          {
            for (int Type = 1948; Type <= 1957; ++Type)
            {
              this.item[index1].SetDefaults(Type);
              ++index1;
            }
          }
          for (int Type = 2158; Type <= 2160; ++Type)
          {
            if (index1 < 39)
              this.item[index1].SetDefaults(Type);
            ++index1;
          }
          for (int Type = 2008; Type <= 2014; ++Type)
          {
            if (index1 < 39)
              this.item[index1].SetDefaults(Type);
            ++index1;
          }
          break;
        case 16:
          this.item[index1].SetDefaults(1430);
          int index171 = index1 + 1;
          this.item[index171].SetDefaults(986);
          int index172 = index171 + 1;
          if (NPC.AnyNPCs(108))
            this.item[index172++].SetDefaults(2999);
          if (Main.hardMode && NPC.downedPlantBoss)
          {
            if (Main.player[Main.myPlayer].HasItem(1157))
            {
              this.item[index172].SetDefaults(1159);
              int index173 = index172 + 1;
              this.item[index173].SetDefaults(1160);
              int index174 = index173 + 1;
              this.item[index174].SetDefaults(1161);
              index172 = index174 + 1;
              if (!Main.dayTime)
              {
                this.item[index172].SetDefaults(1158);
                ++index172;
              }
              if (Main.player[Main.myPlayer].ZoneJungle)
              {
                this.item[index172].SetDefaults(1167);
                ++index172;
              }
            }
            this.item[index172].SetDefaults(1339);
            ++index172;
          }
          if (Main.hardMode && Main.player[Main.myPlayer].ZoneJungle)
          {
            this.item[index172].SetDefaults(1171);
            ++index172;
            if (!Main.dayTime)
            {
              this.item[index172].SetDefaults(1162);
              ++index172;
            }
          }
          this.item[index172].SetDefaults(909);
          int index175 = index172 + 1;
          this.item[index175].SetDefaults(910);
          int index176 = index175 + 1;
          this.item[index176].SetDefaults(940);
          int index177 = index176 + 1;
          this.item[index177].SetDefaults(941);
          int index178 = index177 + 1;
          this.item[index178].SetDefaults(942);
          int index179 = index178 + 1;
          this.item[index179].SetDefaults(943);
          int index180 = index179 + 1;
          this.item[index180].SetDefaults(944);
          int index181 = index180 + 1;
          this.item[index181].SetDefaults(945);
          index1 = index181 + 1;
          if (Main.player[Main.myPlayer].HasItem(1835))
          {
            this.item[index1].SetDefaults(1836);
            ++index1;
          }
          if (Main.player[Main.myPlayer].HasItem(1258))
          {
            this.item[index1].SetDefaults(1261);
            ++index1;
          }
          if (Main.halloween)
          {
            this.item[index1].SetDefaults(1791);
            ++index1;
            break;
          }
          break;
        case 17:
          this.item[index1].SetDefaults(928);
          int index182 = index1 + 1;
          this.item[index182].SetDefaults(929);
          int index183 = index182 + 1;
          this.item[index183].SetDefaults(876);
          int index184 = index183 + 1;
          this.item[index184].SetDefaults(877);
          int index185 = index184 + 1;
          this.item[index185].SetDefaults(878);
          int index186 = index185 + 1;
          this.item[index186].SetDefaults(2434);
          index1 = index186 + 1;
          int num42 = (int) (((double) Main.screenPosition.X + (double) (Main.screenWidth / 2)) / 16.0);
          if ((double) Main.screenPosition.Y / 16.0 < Main.worldSurface + 10.0 && (num42 < 380 || num42 > Main.maxTilesX - 380))
          {
            this.item[index1].SetDefaults(1180);
            ++index1;
          }
          if (Main.hardMode && NPC.downedMechBossAny && NPC.AnyNPCs(208))
          {
            this.item[index1].SetDefaults(1337);
            ++index1;
            break;
          }
          break;
        case 18:
          this.item[index1].SetDefaults(1990);
          int index187 = index1 + 1;
          this.item[index187].SetDefaults(1979);
          index1 = index187 + 1;
          if (Main.player[Main.myPlayer].statLifeMax >= 400)
          {
            this.item[index1].SetDefaults(1977);
            ++index1;
          }
          if (Main.player[Main.myPlayer].statManaMax >= 200)
          {
            this.item[index1].SetDefaults(1978);
            ++index1;
          }
          long num43 = 0;
          for (int index188 = 0; index188 < 54; ++index188)
          {
            if (Main.player[Main.myPlayer].inventory[index188].type == 71)
              num43 += (long) Main.player[Main.myPlayer].inventory[index188].stack;
            if (Main.player[Main.myPlayer].inventory[index188].type == 72)
              num43 += (long) (Main.player[Main.myPlayer].inventory[index188].stack * 100);
            if (Main.player[Main.myPlayer].inventory[index188].type == 73)
              num43 += (long) (Main.player[Main.myPlayer].inventory[index188].stack * 10000);
            if (Main.player[Main.myPlayer].inventory[index188].type == 74)
              num43 += (long) (Main.player[Main.myPlayer].inventory[index188].stack * 1000000);
          }
          if (num43 >= 1000000L)
          {
            this.item[index1].SetDefaults(1980);
            ++index1;
          }
          if (Main.moonPhase % 2 == 0 && Main.dayTime || Main.moonPhase % 2 == 1 && !Main.dayTime)
          {
            this.item[index1].SetDefaults(1981);
            ++index1;
          }
          if (Main.player[Main.myPlayer].team != 0)
          {
            this.item[index1].SetDefaults(1982);
            ++index1;
          }
          if (Main.hardMode)
          {
            this.item[index1].SetDefaults(1983);
            ++index1;
          }
          if (NPC.AnyNPCs(208))
          {
            this.item[index1].SetDefaults(1984);
            ++index1;
          }
          if (Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
          {
            this.item[index1].SetDefaults(1985);
            ++index1;
          }
          if (Main.hardMode && NPC.downedMechBossAny)
          {
            this.item[index1].SetDefaults(1986);
            ++index1;
          }
          if (Main.hardMode && NPC.downedMartians)
          {
            this.item[index1].SetDefaults(2863);
            int index189 = index1 + 1;
            this.item[index189].SetDefaults(3259);
            index1 = index189 + 1;
            break;
          }
          break;
        case 19:
          for (int index190 = 0; index190 < 40; ++index190)
          {
            if (Main.travelShop[index190] != 0)
            {
              this.item[index1].netDefaults(Main.travelShop[index190]);
              ++index1;
            }
          }
          break;
        case 20:
          if (Main.moonPhase % 2 == 0)
            this.item[index1].SetDefaults(3001);
          else
            this.item[index1].SetDefaults(28);
          int index191 = index1 + 1;
          if (!Main.dayTime || Main.moonPhase == 0)
            this.item[index191].SetDefaults(3002);
          else
            this.item[index191].SetDefaults(282);
          int index192 = index191 + 1;
          if (Main.time % 60.0 * 60.0 * 6.0 <= 10800.0)
            this.item[index192].SetDefaults(3004);
          else
            this.item[index192].SetDefaults(8);
          int index193 = index192 + 1;
          if (Main.moonPhase == 0 || Main.moonPhase == 1 || Main.moonPhase == 4 || Main.moonPhase == 5)
            this.item[index193].SetDefaults(3003);
          else
            this.item[index193].SetDefaults(40);
          int index194 = index193 + 1;
          if (Main.moonPhase % 4 == 0)
            this.item[index194].SetDefaults(3310);
          else if (Main.moonPhase % 4 == 1)
            this.item[index194].SetDefaults(3313);
          else if (Main.moonPhase % 4 == 2)
            this.item[index194].SetDefaults(3312);
          else
            this.item[index194].SetDefaults(3311);
          int index195 = index194 + 1;
          this.item[index195].SetDefaults(166);
          int index196 = index195 + 1;
          this.item[index196].SetDefaults(965);
          index1 = index196 + 1;
          if (Main.hardMode)
          {
            if (Main.moonPhase < 4)
              this.item[index1].SetDefaults(3316);
            else
              this.item[index1].SetDefaults(3315);
            int index197 = index1 + 1;
            this.item[index197].SetDefaults(3334);
            index1 = index197 + 1;
            if (Main.bloodMoon)
            {
              this.item[index1].SetDefaults(3258);
              ++index1;
            }
          }
          if (Main.moonPhase == 0 && !Main.dayTime)
          {
            this.item[index1].SetDefaults(3043);
            ++index1;
            break;
          }
          break;
        case 21:
          bool flag = Main.hardMode && NPC.downedMechBossAny;
          int num44 = !Main.hardMode ? 0 : (NPC.downedGolemBoss ? 1 : 0);
          this.item[index1].SetDefaults(353);
          int index198 = index1 + 1;
          this.item[index198].SetDefaults(3828);
          this.item[index198].shopCustomPrice = num44 == 0 ? (!flag ? new int?(Item.buyPrice(silver: 25)) : new int?(Item.buyPrice(gold: 1))) : new int?(Item.buyPrice(gold: 4));
          int index199 = index198 + 1;
          this.item[index199].SetDefaults(3816);
          int index200 = index199 + 1;
          this.item[index200].SetDefaults(3813);
          this.item[index200].shopCustomPrice = new int?(75);
          this.item[index200].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
          int num45 = index200 + 1;
          int index201 = 10;
          this.item[index201].SetDefaults(3818);
          this.item[index201].shopCustomPrice = new int?(5);
          this.item[index201].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
          int index202 = index201 + 1;
          this.item[index202].SetDefaults(3824);
          this.item[index202].shopCustomPrice = new int?(5);
          this.item[index202].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
          int index203 = index202 + 1;
          this.item[index203].SetDefaults(3832);
          this.item[index203].shopCustomPrice = new int?(5);
          this.item[index203].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
          index1 = index203 + 1;
          this.item[index1].SetDefaults(3829);
          this.item[index1].shopCustomPrice = new int?(5);
          this.item[index1].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
          if (flag)
          {
            int index204 = 20;
            this.item[index204].SetDefaults(3819);
            this.item[index204].shopCustomPrice = new int?(25);
            this.item[index204].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index205 = index204 + 1;
            this.item[index205].SetDefaults(3825);
            this.item[index205].shopCustomPrice = new int?(25);
            this.item[index205].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index206 = index205 + 1;
            this.item[index206].SetDefaults(3833);
            this.item[index206].shopCustomPrice = new int?(25);
            this.item[index206].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            index1 = index206 + 1;
            this.item[index1].SetDefaults(3830);
            this.item[index1].shopCustomPrice = new int?(25);
            this.item[index1].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
          }
          if (num44 != 0)
          {
            int index207 = 30;
            this.item[index207].SetDefaults(3820);
            this.item[index207].shopCustomPrice = new int?(100);
            this.item[index207].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index208 = index207 + 1;
            this.item[index208].SetDefaults(3826);
            this.item[index208].shopCustomPrice = new int?(100);
            this.item[index208].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index209 = index208 + 1;
            this.item[index209].SetDefaults(3834);
            this.item[index209].shopCustomPrice = new int?(100);
            this.item[index209].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            index1 = index209 + 1;
            this.item[index1].SetDefaults(3831);
            this.item[index1].shopCustomPrice = new int?(100);
            this.item[index1].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
          }
          if (flag)
          {
            int index210 = 4;
            this.item[index210].SetDefaults(3800);
            this.item[index210].shopCustomPrice = new int?(25);
            this.item[index210].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index211 = index210 + 1;
            this.item[index211].SetDefaults(3801);
            this.item[index211].shopCustomPrice = new int?(25);
            this.item[index211].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index212 = index211 + 1;
            this.item[index212].SetDefaults(3802);
            this.item[index212].shopCustomPrice = new int?(25);
            this.item[index212].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            num45 = index212 + 1;
            int index213 = 14;
            this.item[index213].SetDefaults(3797);
            this.item[index213].shopCustomPrice = new int?(25);
            this.item[index213].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index214 = index213 + 1;
            this.item[index214].SetDefaults(3798);
            this.item[index214].shopCustomPrice = new int?(25);
            this.item[index214].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index215 = index214 + 1;
            this.item[index215].SetDefaults(3799);
            this.item[index215].shopCustomPrice = new int?(25);
            this.item[index215].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            num45 = index215 + 1;
            int index216 = 24;
            this.item[index216].SetDefaults(3803);
            this.item[index216].shopCustomPrice = new int?(25);
            this.item[index216].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index217 = index216 + 1;
            this.item[index217].SetDefaults(3804);
            this.item[index217].shopCustomPrice = new int?(25);
            this.item[index217].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index218 = index217 + 1;
            this.item[index218].SetDefaults(3805);
            this.item[index218].shopCustomPrice = new int?(25);
            this.item[index218].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            num45 = index218 + 1;
            int index219 = 34;
            this.item[index219].SetDefaults(3806);
            this.item[index219].shopCustomPrice = new int?(25);
            this.item[index219].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index220 = index219 + 1;
            this.item[index220].SetDefaults(3807);
            this.item[index220].shopCustomPrice = new int?(25);
            this.item[index220].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index221 = index220 + 1;
            this.item[index221].SetDefaults(3808);
            this.item[index221].shopCustomPrice = new int?(25);
            this.item[index221].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            index1 = index221 + 1;
          }
          if (num44 != 0)
          {
            int index222 = 7;
            this.item[index222].SetDefaults(3871);
            this.item[index222].shopCustomPrice = new int?(75);
            this.item[index222].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index223 = index222 + 1;
            this.item[index223].SetDefaults(3872);
            this.item[index223].shopCustomPrice = new int?(75);
            this.item[index223].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index224 = index223 + 1;
            this.item[index224].SetDefaults(3873);
            this.item[index224].shopCustomPrice = new int?(75);
            this.item[index224].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            num45 = index224 + 1;
            int index225 = 17;
            this.item[index225].SetDefaults(3874);
            this.item[index225].shopCustomPrice = new int?(75);
            this.item[index225].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index226 = index225 + 1;
            this.item[index226].SetDefaults(3875);
            this.item[index226].shopCustomPrice = new int?(75);
            this.item[index226].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index227 = index226 + 1;
            this.item[index227].SetDefaults(3876);
            this.item[index227].shopCustomPrice = new int?(75);
            this.item[index227].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            num45 = index227 + 1;
            int index228 = 27;
            this.item[index228].SetDefaults(3877);
            this.item[index228].shopCustomPrice = new int?(75);
            this.item[index228].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index229 = index228 + 1;
            this.item[index229].SetDefaults(3878);
            this.item[index229].shopCustomPrice = new int?(75);
            this.item[index229].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index230 = index229 + 1;
            this.item[index230].SetDefaults(3879);
            this.item[index230].shopCustomPrice = new int?(75);
            this.item[index230].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            num45 = index230 + 1;
            int index231 = 37;
            this.item[index231].SetDefaults(3880);
            this.item[index231].shopCustomPrice = new int?(75);
            this.item[index231].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index232 = index231 + 1;
            this.item[index232].SetDefaults(3881);
            this.item[index232].shopCustomPrice = new int?(75);
            this.item[index232].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            int index233 = index232 + 1;
            this.item[index233].SetDefaults(3882);
            this.item[index233].shopCustomPrice = new int?(75);
            this.item[index233].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
            index1 = index233 + 1;
            break;
          }
          break;
      }
      if (!Main.player[Main.myPlayer].discount)
        return;
      for (int index234 = 0; index234 < index1; ++index234)
        this.item[index234].value = (int) ((double) this.item[index234].value * 0.800000011920929);
    }

    public static void UpdateChestFrames()
    {
      bool[] flagArray = new bool[1000];
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (Main.player[index].active && Main.player[index].chest >= 0 && Main.player[index].chest < 1000)
          flagArray[Main.player[index].chest] = true;
      }
      for (int index = 0; index < 1000; ++index)
      {
        Chest chest = Main.chest[index];
        if (chest != null)
        {
          if (flagArray[index])
            ++chest.frameCounter;
          else
            --chest.frameCounter;
          if (chest.frameCounter < 0)
            chest.frameCounter = 0;
          if (chest.frameCounter > 10)
            chest.frameCounter = 10;
          chest.frame = chest.frameCounter != 0 ? (chest.frameCounter != 10 ? 1 : 2) : 0;
        }
      }
    }
  }
}
