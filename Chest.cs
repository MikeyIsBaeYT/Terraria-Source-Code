// Decompiled with JetBrains decompiler
// Type: Terraria.Chest
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria
{
  public class Chest
  {
    public static int maxItems = 20;
    public Item[] item = new Item[Chest.maxItems];
    public int x;
    public int y;

    public object Clone() => this.MemberwiseClone();

    public static void Unlock(int X, int Y)
    {
      Main.PlaySound(22, X * 16, Y * 16);
      for (int index1 = X; index1 <= X + 1; ++index1)
      {
        for (int index2 = Y; index2 <= Y + 1; ++index2)
        {
          if (Main.tile[index1, index2] == null)
            Main.tile[index1, index2] = new Tile();
          if (Main.tile[index1, index2].frameX >= (short) 72 && Main.tile[index1, index2].frameX <= (short) 106 || Main.tile[index1, index2].frameX >= (short) 144 && Main.tile[index1, index2].frameX <= (short) 178)
          {
            Main.tile[index1, index2].frameX -= (short) 36;
            for (int index3 = 0; index3 < 4; ++index3)
              Dust.NewDust(new Vector2((float) (index1 * 16), (float) (index2 * 16)), 16, 16, 11);
          }
        }
      }
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

    public static int CreateChest(int X, int Y)
    {
      for (int index = 0; index < 1000; ++index)
      {
        if (Main.chest[index] != null && Main.chest[index].x == X && Main.chest[index].y == Y)
          return -1;
      }
      for (int index1 = 0; index1 < 1000; ++index1)
      {
        if (Main.chest[index1] == null)
        {
          Main.chest[index1] = new Chest();
          Main.chest[index1].x = X;
          Main.chest[index1].y = Y;
          for (int index2 = 0; index2 < Chest.maxItems; ++index2)
            Main.chest[index1].item[index2] = new Item();
          return index1;
        }
      }
      return -1;
    }

    public static bool DestroyChest(int X, int Y)
    {
      for (int index1 = 0; index1 < 1000; ++index1)
      {
        if (Main.chest[index1] != null && Main.chest[index1].x == X && Main.chest[index1].y == Y)
        {
          for (int index2 = 0; index2 < Chest.maxItems; ++index2)
          {
            if (Main.chest[index1].item[index2].type > 0 && Main.chest[index1].item[index2].stack > 0)
              return false;
          }
          Main.chest[index1] = (Chest) null;
          return true;
        }
      }
      return true;
    }

    public void AddShop(Item newItem)
    {
      for (int index = 0; index < 19; ++index)
      {
        if (this.item[index] == null || this.item[index].type == 0)
        {
          this.item[index] = (Item) newItem.Clone();
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

    public void SetupShop(int type)
    {
      for (int index = 0; index < Chest.maxItems; ++index)
        this.item[index] = new Item();
      switch (type)
      {
        case 1:
          int index1 = 0;
          this.item[index1].SetDefaults("Mining Helmet");
          int index2 = index1 + 1;
          this.item[index2].SetDefaults("Piggy Bank");
          int index3 = index2 + 1;
          this.item[index3].SetDefaults("Iron Anvil");
          int index4 = index3 + 1;
          this.item[index4].SetDefaults("Copper Pickaxe");
          int index5 = index4 + 1;
          this.item[index5].SetDefaults("Copper Axe");
          int index6 = index5 + 1;
          this.item[index6].SetDefaults("Torch");
          int index7 = index6 + 1;
          this.item[index7].SetDefaults("Lesser Healing Potion");
          int index8 = index7 + 1;
          if (Main.player[Main.myPlayer].statManaMax == 200)
          {
            this.item[index8].SetDefaults("Lesser Mana Potion");
            ++index8;
          }
          this.item[index8].SetDefaults("Wooden Arrow");
          int index9 = index8 + 1;
          this.item[index9].SetDefaults("Shuriken");
          int index10 = index9 + 1;
          if (Main.bloodMoon)
          {
            this.item[index10].SetDefaults("Throwing Knife");
            ++index10;
          }
          if (!Main.dayTime)
          {
            this.item[index10].SetDefaults("Glowstick");
            ++index10;
          }
          if (NPC.downedBoss3)
          {
            this.item[index10].SetDefaults("Safe");
            ++index10;
          }
          if (!Main.hardMode)
            break;
          this.item[index10].SetDefaults(488);
          int num1 = index10 + 1;
          break;
        case 2:
          int index11 = 0;
          this.item[index11].SetDefaults("Musket Ball");
          int index12 = index11 + 1;
          if (Main.bloodMoon || Main.hardMode)
          {
            this.item[index12].SetDefaults("Silver Bullet");
            ++index12;
          }
          if (NPC.downedBoss2 && !Main.dayTime || Main.hardMode)
          {
            this.item[index12].SetDefaults(47);
            ++index12;
          }
          this.item[index12].SetDefaults("Flintlock Pistol");
          int index13 = index12 + 1;
          this.item[index13].SetDefaults("Minishark");
          int index14 = index13 + 1;
          if (!Main.dayTime)
          {
            this.item[index14].SetDefaults(324);
            ++index14;
          }
          if (Main.hardMode)
            this.item[index14].SetDefaults(534);
          int num2 = index14 + 1;
          break;
        case 3:
          int index15 = 0;
          int index16;
          if (Main.bloodMoon)
          {
            this.item[index15].SetDefaults(67);
            int index17 = index15 + 1;
            this.item[index17].SetDefaults(59);
            index16 = index17 + 1;
          }
          else
          {
            this.item[index15].SetDefaults("Purification Powder");
            int index18 = index15 + 1;
            this.item[index18].SetDefaults("Grass Seeds");
            int index19 = index18 + 1;
            this.item[index19].SetDefaults("Sunflower");
            index16 = index19 + 1;
          }
          this.item[index16].SetDefaults("Acorn");
          int index20 = index16 + 1;
          this.item[index20].SetDefaults(114);
          int index21 = index20 + 1;
          if (Main.hardMode)
            this.item[index21].SetDefaults(369);
          int num3 = index21 + 1;
          break;
        case 4:
          int index22 = 0;
          this.item[index22].SetDefaults("Grenade");
          int index23 = index22 + 1;
          this.item[index23].SetDefaults("Bomb");
          int index24 = index23 + 1;
          this.item[index24].SetDefaults("Dynamite");
          int index25 = index24 + 1;
          if (Main.hardMode)
            this.item[index25].SetDefaults("Hellfire Arrow");
          int num4 = index25 + 1;
          break;
        case 5:
          int index26 = 0;
          this.item[index26].SetDefaults(254);
          int index27 = index26 + 1;
          if (Main.dayTime)
          {
            this.item[index27].SetDefaults(242);
            ++index27;
          }
          switch (Main.moonPhase)
          {
            case 0:
              this.item[index27].SetDefaults(245);
              int index28 = index27 + 1;
              this.item[index28].SetDefaults(246);
              index27 = index28 + 1;
              break;
            case 1:
              this.item[index27].SetDefaults(325);
              int index29 = index27 + 1;
              this.item[index29].SetDefaults(326);
              index27 = index29 + 1;
              break;
          }
          this.item[index27].SetDefaults(269);
          int index30 = index27 + 1;
          this.item[index30].SetDefaults(270);
          int index31 = index30 + 1;
          this.item[index31].SetDefaults(271);
          int index32 = index31 + 1;
          if (NPC.downedClown)
          {
            this.item[index32].SetDefaults(503);
            int index33 = index32 + 1;
            this.item[index33].SetDefaults(504);
            int index34 = index33 + 1;
            this.item[index34].SetDefaults(505);
            index32 = index34 + 1;
          }
          if (!Main.bloodMoon)
            break;
          this.item[index32].SetDefaults(322);
          int num5 = index32 + 1;
          break;
        case 6:
          int index35 = 0;
          this.item[index35].SetDefaults(128);
          int index36 = index35 + 1;
          this.item[index36].SetDefaults(486);
          int index37 = index36 + 1;
          this.item[index37].SetDefaults(398);
          int index38 = index37 + 1;
          this.item[index38].SetDefaults(84);
          int index39 = index38 + 1;
          this.item[index39].SetDefaults(407);
          int index40 = index39 + 1;
          this.item[index40].SetDefaults(161);
          int num6 = index40 + 1;
          break;
        case 7:
          int index41 = 0;
          this.item[index41].SetDefaults(487);
          int index42 = index41 + 1;
          this.item[index42].SetDefaults(496);
          int index43 = index42 + 1;
          this.item[index43].SetDefaults(500);
          int index44 = index43 + 1;
          this.item[index44].SetDefaults(507);
          int index45 = index44 + 1;
          this.item[index45].SetDefaults(508);
          int index46 = index45 + 1;
          this.item[index46].SetDefaults(531);
          int index47 = index46 + 1;
          this.item[index47].SetDefaults(576);
          int num7 = index47 + 1;
          break;
        case 8:
          int index48 = 0;
          this.item[index48].SetDefaults(509);
          int index49 = index48 + 1;
          this.item[index49].SetDefaults(510);
          int index50 = index49 + 1;
          this.item[index50].SetDefaults(530);
          int index51 = index50 + 1;
          this.item[index51].SetDefaults(513);
          int index52 = index51 + 1;
          this.item[index52].SetDefaults(538);
          int index53 = index52 + 1;
          this.item[index53].SetDefaults(529);
          int index54 = index53 + 1;
          this.item[index54].SetDefaults(541);
          int index55 = index54 + 1;
          this.item[index55].SetDefaults(542);
          int index56 = index55 + 1;
          this.item[index56].SetDefaults(543);
          int num8 = index56 + 1;
          break;
        case 9:
          int index57 = 0;
          this.item[index57].SetDefaults(588);
          int index58 = index57 + 1;
          this.item[index58].SetDefaults(589);
          int index59 = index58 + 1;
          this.item[index59].SetDefaults(590);
          int index60 = index59 + 1;
          this.item[index60].SetDefaults(597);
          int index61 = index60 + 1;
          this.item[index61].SetDefaults(598);
          int index62 = index61 + 1;
          this.item[index62].SetDefaults(596);
          int num9 = index62 + 1;
          break;
      }
    }
  }
}
