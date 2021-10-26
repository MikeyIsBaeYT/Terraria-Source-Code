// Decompiled with JetBrains decompiler
// Type: Terraria.Item
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
  public class Item
  {
    public static int potionDelay = 3600;
    public static int[] headType = new int[45];
    public static int[] bodyType = new int[26];
    public static int[] legType = new int[25];
    public bool mech;
    public bool wet;
    public byte wetCount;
    public bool lavaWet;
    public Vector2 position;
    public Vector2 velocity;
    public int width;
    public int height;
    public bool active;
    public int noGrabDelay;
    public bool beingGrabbed;
    public int spawnTime;
    public bool wornArmor;
    public int ownIgnore = -1;
    public int ownTime;
    public int keepTime;
    public int type;
    public string name;
    public int holdStyle;
    public int useStyle;
    public bool channel;
    public bool accessory;
    public int useAnimation;
    public int useTime;
    public int stack;
    public int maxStack;
    public int pick;
    public int axe;
    public int hammer;
    public int tileBoost;
    public int createTile = -1;
    public int createWall = -1;
    public int placeStyle;
    public int damage;
    public float knockBack;
    public int healLife;
    public int healMana;
    public bool potion;
    public bool consumable;
    public bool autoReuse;
    public bool useTurn;
    public Color color;
    public int alpha;
    public float scale = 1f;
    public int useSound;
    public int defense;
    public int headSlot = -1;
    public int bodySlot = -1;
    public int legSlot = -1;
    public string toolTip;
    public string toolTip2;
    public int owner = (int) byte.MaxValue;
    public int rare;
    public int shoot;
    public float shootSpeed;
    public int ammo;
    public int useAmmo;
    public int lifeRegen;
    public int manaIncrease;
    public bool buyOnce;
    public int mana;
    public bool noUseGraphic;
    public bool noMelee;
    public int release;
    public int value;
    public bool buy;
    public bool social;
    public bool vanity;
    public bool material;
    public bool noWet;
    public int buffType;
    public int buffTime;
    public int netID;
    public int crit;
    public byte prefix;
    public bool melee;
    public bool magic;
    public bool ranged;
    public int reuseDelay;

    public bool Prefix(int pre)
    {
      if (pre == 0 || this.type == 0)
        return false;
      int num1 = pre;
      float num2 = 1f;
      float num3 = 1f;
      float num4 = 1f;
      float num5 = 1f;
      float num6 = 1f;
      float num7 = 1f;
      int num8 = 0;
      bool flag = true;
      while (flag)
      {
        num2 = 1f;
        num3 = 1f;
        num4 = 1f;
        num5 = 1f;
        num6 = 1f;
        num7 = 1f;
        num8 = 0;
        flag = false;
        if (num1 == -1 && Main.rand.Next(4) == 0)
          num1 = 0;
        if (pre < -1)
          num1 = -1;
        if (num1 == -1 || num1 == -2 || num1 == -3)
        {
          if (this.type == 1 || this.type == 4 || this.type == 6 || this.type == 7 || this.type == 10 || this.type == 24 || this.type == 45 || this.type == 46 || this.type == 103 || this.type == 104 || this.type == 121 || this.type == 122 || this.type == 155 || this.type == 190 || this.type == 196 || this.type == 198 || this.type == 199 || this.type == 200 || this.type == 201 || this.type == 202 || this.type == 203 || this.type == 204 || this.type == 213 || this.type == 217 || this.type == 273 || this.type == 367 || this.type == 368 || this.type == 426 || this.type == 482 || this.type == 483 || this.type == 484)
          {
            int num9 = Main.rand.Next(40);
            if (num9 == 0)
              num1 = 1;
            if (num9 == 1)
              num1 = 2;
            if (num9 == 2)
              num1 = 3;
            if (num9 == 3)
              num1 = 4;
            if (num9 == 4)
              num1 = 5;
            if (num9 == 5)
              num1 = 6;
            if (num9 == 6)
              num1 = 7;
            if (num9 == 7)
              num1 = 8;
            if (num9 == 8)
              num1 = 9;
            if (num9 == 9)
              num1 = 10;
            if (num9 == 10)
              num1 = 11;
            if (num9 == 11)
              num1 = 12;
            if (num9 == 12)
              num1 = 13;
            if (num9 == 13)
              num1 = 14;
            if (num9 == 14)
              num1 = 15;
            if (num9 == 15)
              num1 = 36;
            if (num9 == 16)
              num1 = 37;
            if (num9 == 17)
              num1 = 38;
            if (num9 == 18)
              num1 = 53;
            if (num9 == 19)
              num1 = 54;
            if (num9 == 20)
              num1 = 55;
            if (num9 == 21)
              num1 = 39;
            if (num9 == 22)
              num1 = 40;
            if (num9 == 23)
              num1 = 56;
            if (num9 == 24)
              num1 = 41;
            if (num9 == 25)
              num1 = 57;
            if (num9 == 26)
              num1 = 42;
            if (num9 == 27)
              num1 = 43;
            if (num9 == 28)
              num1 = 44;
            if (num9 == 29)
              num1 = 45;
            if (num9 == 30)
              num1 = 46;
            if (num9 == 31)
              num1 = 47;
            if (num9 == 32)
              num1 = 48;
            if (num9 == 33)
              num1 = 49;
            if (num9 == 34)
              num1 = 50;
            if (num9 == 35)
              num1 = 51;
            if (num9 == 36)
              num1 = 59;
            if (num9 == 37)
              num1 = 60;
            if (num9 == 38)
              num1 = 61;
            if (num9 == 39)
              num1 = 81;
          }
          else if (this.type == 162 || this.type == 160 || this.type == 163 || this.type == 220 || this.type == 274 || this.type == 277 || this.type == 280 || this.type == 383 || this.type == 384 || this.type == 385 || this.type == 386 || this.type == 387 || this.type == 388 || this.type == 389 || this.type == 390 || this.type == 406 || this.type == 537 || this.type == 550 || this.type == 579)
          {
            int num10 = Main.rand.Next(14);
            if (num10 == 0)
              num1 = 36;
            if (num10 == 1)
              num1 = 37;
            if (num10 == 2)
              num1 = 38;
            if (num10 == 3)
              num1 = 53;
            if (num10 == 4)
              num1 = 54;
            if (num10 == 5)
              num1 = 55;
            if (num10 == 6)
              num1 = 39;
            if (num10 == 7)
              num1 = 40;
            if (num10 == 8)
              num1 = 56;
            if (num10 == 9)
              num1 = 41;
            if (num10 == 10)
              num1 = 57;
            if (num10 == 11)
              num1 = 59;
            if (num10 == 12)
              num1 = 60;
            if (num10 == 13)
              num1 = 61;
          }
          else if (this.type == 39 || this.type == 44 || this.type == 95 || this.type == 96 || this.type == 98 || this.type == 99 || this.type == 120 || this.type == 164 || this.type == 197 || this.type == 219 || this.type == 266 || this.type == 281 || this.type == 434 || this.type == 435 || this.type == 436 || this.type == 481 || this.type == 506 || this.type == 533 || this.type == 534 || this.type == 578)
          {
            int num11 = Main.rand.Next(36);
            if (num11 == 0)
              num1 = 16;
            if (num11 == 1)
              num1 = 17;
            if (num11 == 2)
              num1 = 18;
            if (num11 == 3)
              num1 = 19;
            if (num11 == 4)
              num1 = 20;
            if (num11 == 5)
              num1 = 21;
            if (num11 == 6)
              num1 = 22;
            if (num11 == 7)
              num1 = 23;
            if (num11 == 8)
              num1 = 24;
            if (num11 == 9)
              num1 = 25;
            if (num11 == 10)
              num1 = 58;
            if (num11 == 11)
              num1 = 36;
            if (num11 == 12)
              num1 = 37;
            if (num11 == 13)
              num1 = 38;
            if (num11 == 14)
              num1 = 53;
            if (num11 == 15)
              num1 = 54;
            if (num11 == 16)
              num1 = 55;
            if (num11 == 17)
              num1 = 39;
            if (num11 == 18)
              num1 = 40;
            if (num11 == 19)
              num1 = 56;
            if (num11 == 20)
              num1 = 41;
            if (num11 == 21)
              num1 = 57;
            if (num11 == 22)
              num1 = 42;
            if (num11 == 23)
              num1 = 43;
            if (num11 == 24)
              num1 = 44;
            if (num11 == 25)
              num1 = 45;
            if (num11 == 26)
              num1 = 46;
            if (num11 == 27)
              num1 = 47;
            if (num11 == 28)
              num1 = 48;
            if (num11 == 29)
              num1 = 49;
            if (num11 == 30)
              num1 = 50;
            if (num11 == 31)
              num1 = 51;
            if (num11 == 32)
              num1 = 59;
            if (num11 == 33)
              num1 = 60;
            if (num11 == 34)
              num1 = 61;
            if (num11 == 35)
              num1 = 82;
          }
          else if (this.type == 64 || this.type == 65 || this.type == 112 || this.type == 113 || this.type == (int) sbyte.MaxValue || this.type == 157 || this.type == 165 || this.type == 218 || this.type == 272 || this.type == 494 || this.type == 495 || this.type == 496 || this.type == 514 || this.type == 517 || this.type == 518 || this.type == 519)
          {
            int num12 = Main.rand.Next(36);
            if (num12 == 0)
              num1 = 26;
            if (num12 == 1)
              num1 = 27;
            if (num12 == 2)
              num1 = 28;
            if (num12 == 3)
              num1 = 29;
            if (num12 == 4)
              num1 = 30;
            if (num12 == 5)
              num1 = 31;
            if (num12 == 6)
              num1 = 32;
            if (num12 == 7)
              num1 = 33;
            if (num12 == 8)
              num1 = 34;
            if (num12 == 9)
              num1 = 35;
            if (num12 == 10)
              num1 = 52;
            if (num12 == 11)
              num1 = 36;
            if (num12 == 12)
              num1 = 37;
            if (num12 == 13)
              num1 = 38;
            if (num12 == 14)
              num1 = 53;
            if (num12 == 15)
              num1 = 54;
            if (num12 == 16)
              num1 = 55;
            if (num12 == 17)
              num1 = 39;
            if (num12 == 18)
              num1 = 40;
            if (num12 == 19)
              num1 = 56;
            if (num12 == 20)
              num1 = 41;
            if (num12 == 21)
              num1 = 57;
            if (num12 == 22)
              num1 = 42;
            if (num12 == 23)
              num1 = 43;
            if (num12 == 24)
              num1 = 44;
            if (num12 == 25)
              num1 = 45;
            if (num12 == 26)
              num1 = 46;
            if (num12 == 27)
              num1 = 47;
            if (num12 == 28)
              num1 = 48;
            if (num12 == 29)
              num1 = 49;
            if (num12 == 30)
              num1 = 50;
            if (num12 == 31)
              num1 = 51;
            if (num12 == 32)
              num1 = 59;
            if (num12 == 33)
              num1 = 60;
            if (num12 == 34)
              num1 = 61;
            if (num12 == 35)
              num1 = 83;
          }
          else if (this.type == 55 || this.type == 119 || this.type == 191 || this.type == 284)
          {
            int num13 = Main.rand.Next(14);
            if (num13 == 0)
              num1 = 36;
            if (num13 == 1)
              num1 = 37;
            if (num13 == 2)
              num1 = 38;
            if (num13 == 3)
              num1 = 53;
            if (num13 == 4)
              num1 = 54;
            if (num13 == 5)
              num1 = 55;
            if (num13 == 6)
              num1 = 39;
            if (num13 == 7)
              num1 = 40;
            if (num13 == 8)
              num1 = 56;
            if (num13 == 9)
              num1 = 41;
            if (num13 == 10)
              num1 = 57;
            if (num13 == 11)
              num1 = 59;
            if (num13 == 12)
              num1 = 60;
            if (num13 == 13)
              num1 = 61;
          }
          else
          {
            if (!this.accessory || this.type == 267 || this.type == 562 || this.type == 563 || this.type == 564 || this.type == 565 || this.type == 566 || this.type == 567 || this.type == 568 || this.type == 569 || this.type == 570 || this.type == 571 || this.type == 572 || this.type == 573 || this.type == 574 || this.type == 576)
              return false;
            num1 = Main.rand.Next(62, 81);
          }
        }
        switch (pre)
        {
          case -3:
            return true;
          case -1:
            if ((num1 == 7 || num1 == 8 || num1 == 9 || num1 == 10 || num1 == 11 || num1 == 22 || num1 == 23 || num1 == 24 || num1 == 29 || num1 == 30 || num1 == 31 || num1 == 39 || num1 == 40 || num1 == 56 || num1 == 41 || num1 == 47 || num1 == 48 || num1 == 49) && Main.rand.Next(3) != 0)
            {
              num1 = 0;
              break;
            }
            break;
        }
        switch (num1)
        {
          case 1:
            num5 = 1.12f;
            break;
          case 2:
            num5 = 1.18f;
            break;
          case 3:
            num2 = 1.05f;
            num8 = 2;
            num5 = 1.05f;
            break;
          case 4:
            num2 = 1.1f;
            num5 = 1.1f;
            num3 = 1.1f;
            break;
          case 5:
            num2 = 1.15f;
            break;
          case 6:
            num2 = 1.1f;
            break;
          case 7:
            num5 = 0.82f;
            break;
          case 8:
            num3 = 0.85f;
            num2 = 0.85f;
            num5 = 0.87f;
            break;
          case 9:
            num5 = 0.9f;
            break;
          case 10:
            num2 = 0.85f;
            break;
          case 11:
            num4 = 1.1f;
            num3 = 0.9f;
            num5 = 0.9f;
            break;
          case 12:
            num3 = 1.1f;
            num2 = 1.05f;
            num5 = 1.1f;
            num4 = 1.15f;
            break;
          case 13:
            num3 = 0.8f;
            num2 = 0.9f;
            num5 = 1.1f;
            break;
          case 14:
            num3 = 1.15f;
            num4 = 1.1f;
            break;
          case 15:
            num3 = 0.9f;
            num4 = 0.85f;
            break;
          case 16:
            num2 = 1.1f;
            num8 = 3;
            break;
          case 17:
            num4 = 0.85f;
            num6 = 1.1f;
            break;
          case 18:
            num4 = 0.9f;
            num6 = 1.15f;
            break;
          case 19:
            num3 = 1.15f;
            num6 = 1.05f;
            break;
          case 20:
            num3 = 1.05f;
            num6 = 1.05f;
            num2 = 1.1f;
            num4 = 0.95f;
            num8 = 2;
            break;
          case 21:
            num3 = 1.15f;
            num2 = 1.1f;
            break;
          case 22:
            num3 = 0.9f;
            num6 = 0.9f;
            num2 = 0.85f;
            break;
          case 23:
            num4 = 1.15f;
            num6 = 0.9f;
            break;
          case 24:
            num4 = 1.1f;
            num3 = 0.8f;
            break;
          case 25:
            num4 = 1.1f;
            num2 = 1.15f;
            num8 = 1;
            break;
          case 26:
            num7 = 0.85f;
            num2 = 1.1f;
            break;
          case 27:
            num7 = 0.85f;
            break;
          case 28:
            num7 = 0.85f;
            num2 = 1.15f;
            num3 = 1.05f;
            break;
          case 29:
            num7 = 1.1f;
            break;
          case 30:
            num7 = 1.2f;
            num2 = 0.9f;
            break;
          case 31:
            num3 = 0.9f;
            num2 = 0.9f;
            break;
          case 32:
            num7 = 1.15f;
            num2 = 1.1f;
            break;
          case 33:
            num7 = 1.1f;
            num3 = 1.1f;
            num4 = 0.9f;
            break;
          case 34:
            num7 = 0.9f;
            num3 = 1.1f;
            num4 = 1.1f;
            num2 = 1.1f;
            break;
          case 35:
            num7 = 1.2f;
            num2 = 1.15f;
            num3 = 1.15f;
            break;
          case 36:
            num8 = 3;
            break;
          case 37:
            num2 = 1.1f;
            num8 = 3;
            num3 = 1.1f;
            break;
          case 38:
            num3 = 1.15f;
            break;
          case 39:
            num2 = 0.7f;
            num3 = 0.8f;
            break;
          case 40:
            num2 = 0.85f;
            break;
          case 41:
            num3 = 0.85f;
            num2 = 0.9f;
            break;
          case 42:
            num4 = 0.9f;
            break;
          case 43:
            num2 = 1.1f;
            num4 = 0.9f;
            break;
          case 44:
            num4 = 0.9f;
            num8 = 3;
            break;
          case 45:
            num4 = 0.95f;
            break;
          case 46:
            num8 = 3;
            num4 = 0.94f;
            num2 = 1.07f;
            break;
          case 47:
            num4 = 1.15f;
            break;
          case 48:
            num4 = 1.2f;
            break;
          case 49:
            num4 = 1.08f;
            break;
          case 50:
            num2 = 0.8f;
            num4 = 1.15f;
            break;
          case 51:
            num3 = 0.9f;
            num4 = 0.9f;
            num2 = 1.05f;
            num8 = 2;
            break;
          case 52:
            num7 = 0.9f;
            num2 = 0.9f;
            num4 = 0.9f;
            break;
          case 53:
            num2 = 1.1f;
            break;
          case 54:
            num3 = 1.15f;
            break;
          case 55:
            num3 = 1.15f;
            num2 = 1.05f;
            break;
          case 56:
            num3 = 0.8f;
            break;
          case 57:
            num3 = 0.9f;
            num2 = 1.18f;
            break;
          case 58:
            num4 = 0.85f;
            num2 = 0.85f;
            break;
          case 59:
            num3 = 1.15f;
            num2 = 1.15f;
            num8 = 5;
            break;
          case 60:
            num2 = 1.15f;
            num8 = 5;
            break;
          case 61:
            num8 = 5;
            break;
          case 81:
            num3 = 1.15f;
            num2 = 1.15f;
            num8 = 5;
            num4 = 0.9f;
            num5 = 1.1f;
            break;
          case 82:
            num3 = 1.15f;
            num2 = 1.15f;
            num8 = 5;
            num4 = 0.9f;
            num6 = 1.1f;
            break;
          case 83:
            num3 = 1.15f;
            num2 = 1.15f;
            num8 = 5;
            num4 = 0.9f;
            num7 = 0.9f;
            break;
        }
        if ((double) num2 != 1.0 && Math.Round((double) this.damage * (double) num2) == (double) this.damage)
        {
          flag = true;
          num1 = -1;
        }
        if ((double) num4 != 1.0 && Math.Round((double) this.useAnimation * (double) num4) == (double) this.useAnimation)
        {
          flag = true;
          num1 = -1;
        }
        if ((double) num7 != 1.0 && Math.Round((double) this.mana * (double) num7) == (double) this.mana)
        {
          flag = true;
          num1 = -1;
        }
        if ((double) num3 != 1.0 && (double) this.knockBack == 0.0)
        {
          flag = true;
          num1 = -1;
        }
        if (pre == -2 && num1 == 0)
        {
          num1 = -1;
          flag = true;
        }
      }
      this.damage = (int) Math.Round((double) this.damage * (double) num2);
      this.useAnimation = (int) Math.Round((double) this.useAnimation * (double) num4);
      this.useTime = (int) Math.Round((double) this.useTime * (double) num4);
      this.reuseDelay = (int) Math.Round((double) this.reuseDelay * (double) num4);
      this.mana = (int) Math.Round((double) this.mana * (double) num7);
      this.knockBack *= num3;
      this.scale *= num5;
      this.shootSpeed *= num6;
      this.crit += num8;
      float num14 = (float) (1.0 * (double) num2 * (2.0 - (double) num4) * (2.0 - (double) num7) * (double) num5 * (double) num3 * (double) num6 * (1.0 + (double) this.crit * 0.0199999995529652));
      if (num1 == 62 || num1 == 69 || num1 == 73 || num1 == 77)
        num14 *= 1.05f;
      if (num1 == 63 || num1 == 70 || num1 == 74 || num1 == 78 || num1 == 67)
        num14 *= 1.1f;
      if (num1 == 64 || num1 == 71 || num1 == 75 || num1 == 79 || num1 == 66)
        num14 *= 1.15f;
      if (num1 == 65 || num1 == 72 || num1 == 76 || num1 == 80 || num1 == 68)
        num14 *= 1.2f;
      if ((double) num14 >= 1.2)
        this.rare += 2;
      else if ((double) num14 >= 1.05)
        ++this.rare;
      else if ((double) num14 <= 0.8)
        this.rare -= 2;
      else if ((double) num14 <= 0.95)
        --this.rare;
      if (this.rare < -1)
        this.rare = -1;
      if (this.rare > 6)
        this.rare = 6;
      this.value = (int) ((double) this.value * (double) (num14 * num14));
      this.prefix = (byte) num1;
      return true;
    }

    public string AffixName()
    {
      string str1 = "";
      if (Lang.lang <= 1)
      {
        if (this.prefix == (byte) 1)
          str1 = "Large";
        if (this.prefix == (byte) 2)
          str1 = "Massive";
        if (this.prefix == (byte) 3)
          str1 = "Dangerous";
        if (this.prefix == (byte) 4)
          str1 = "Savage";
        if (this.prefix == (byte) 5)
          str1 = "Sharp";
        if (this.prefix == (byte) 6)
          str1 = "Pointy";
        if (this.prefix == (byte) 7)
          str1 = "Tiny";
        if (this.prefix == (byte) 8)
          str1 = "Terrible";
        if (this.prefix == (byte) 9)
          str1 = "Small";
        if (this.prefix == (byte) 10)
          str1 = "Dull";
        if (this.prefix == (byte) 11)
          str1 = "Unhappy";
        if (this.prefix == (byte) 12)
          str1 = "Bulky";
        if (this.prefix == (byte) 13)
          str1 = "Shameful";
        if (this.prefix == (byte) 14)
          str1 = "Heavy";
        if (this.prefix == (byte) 15)
          str1 = "Light";
        if (this.prefix == (byte) 16)
          str1 = "Sighted";
        if (this.prefix == (byte) 17)
          str1 = "Rapid";
        if (this.prefix == (byte) 18)
          str1 = "Hasty";
        if (this.prefix == (byte) 19)
          str1 = "Intimidating";
        if (this.prefix == (byte) 20)
          str1 = "Deadly";
        if (this.prefix == (byte) 21)
          str1 = "Staunch";
        if (this.prefix == (byte) 22)
          str1 = "Awful";
        if (this.prefix == (byte) 23)
          str1 = "Lethargic";
        if (this.prefix == (byte) 24)
          str1 = "Awkward";
        if (this.prefix == (byte) 25)
          str1 = "Powerful";
        if (this.prefix == (byte) 58)
          str1 = "Frenzying";
        if (this.prefix == (byte) 26)
          str1 = "Mystic";
        if (this.prefix == (byte) 27)
          str1 = "Adept";
        if (this.prefix == (byte) 28)
          str1 = "Masterful";
        if (this.prefix == (byte) 29)
          str1 = "Inept";
        if (this.prefix == (byte) 30)
          str1 = "Ignorant";
        if (this.prefix == (byte) 31)
          str1 = "Deranged";
        if (this.prefix == (byte) 32)
          str1 = "Intense";
        if (this.prefix == (byte) 33)
          str1 = "Taboo";
        if (this.prefix == (byte) 34)
          str1 = "Celestial";
        if (this.prefix == (byte) 35)
          str1 = "Furious";
        if (this.prefix == (byte) 52)
          str1 = "Manic";
        if (this.prefix == (byte) 36)
          str1 = "Keen";
        if (this.prefix == (byte) 37)
          str1 = "Superior";
        if (this.prefix == (byte) 38)
          str1 = "Forceful";
        if (this.prefix == (byte) 53)
          str1 = "Hurtful";
        if (this.prefix == (byte) 54)
          str1 = "Strong";
        if (this.prefix == (byte) 55)
          str1 = "Unpleasant";
        if (this.prefix == (byte) 39)
          str1 = "Broken";
        if (this.prefix == (byte) 40)
          str1 = "Damaged";
        if (this.prefix == (byte) 56)
          str1 = "Weak";
        if (this.prefix == (byte) 41)
          str1 = "Shoddy";
        if (this.prefix == (byte) 57)
          str1 = "Ruthless";
        if (this.prefix == (byte) 42)
          str1 = "Quick";
        if (this.prefix == (byte) 43)
          str1 = "Deadly";
        if (this.prefix == (byte) 44)
          str1 = "Agile";
        if (this.prefix == (byte) 45)
          str1 = "Nimble";
        if (this.prefix == (byte) 46)
          str1 = "Murderous";
        if (this.prefix == (byte) 47)
          str1 = "Slow";
        if (this.prefix == (byte) 48)
          str1 = "Sluggish";
        if (this.prefix == (byte) 49)
          str1 = "Lazy";
        if (this.prefix == (byte) 50)
          str1 = "Annoying";
        if (this.prefix == (byte) 51)
          str1 = "Nasty";
        if (this.prefix == (byte) 59)
          str1 = "Godly";
        if (this.prefix == (byte) 60)
          str1 = "Demonic";
        if (this.prefix == (byte) 61)
          str1 = "Zealous";
        if (this.prefix == (byte) 62)
          str1 = "Hard";
        if (this.prefix == (byte) 63)
          str1 = "Guarding";
        if (this.prefix == (byte) 64)
          str1 = "Armored";
        if (this.prefix == (byte) 65)
          str1 = "Warding";
        if (this.prefix == (byte) 66)
          str1 = "Arcane";
        if (this.prefix == (byte) 67)
          str1 = "Precise";
        if (this.prefix == (byte) 68)
          str1 = "Lucky";
        if (this.prefix == (byte) 69)
          str1 = "Jagged";
        if (this.prefix == (byte) 70)
          str1 = "Spiked";
        if (this.prefix == (byte) 71)
          str1 = "Angry";
        if (this.prefix == (byte) 72)
          str1 = "Menacing";
        if (this.prefix == (byte) 73)
          str1 = "Brisk";
        if (this.prefix == (byte) 74)
          str1 = "Fleeting";
        if (this.prefix == (byte) 75)
          str1 = "Hasty";
        if (this.prefix == (byte) 76)
          str1 = "Quick";
        if (this.prefix == (byte) 77)
          str1 = "Wild";
        if (this.prefix == (byte) 78)
          str1 = "Rash";
        if (this.prefix == (byte) 79)
          str1 = "Intrepid";
        if (this.prefix == (byte) 80)
          str1 = "Violent";
        if (this.prefix == (byte) 81)
          str1 = "Legendary";
        if (this.prefix == (byte) 82)
          str1 = "Unreal";
        if (this.prefix == (byte) 83)
          str1 = "Mythical";
      }
      else if (Lang.lang == 2)
      {
        if (this.prefix == (byte) 1)
          str1 = "Gross";
        if (this.prefix == (byte) 2)
          str1 = "Massiv";
        if (this.prefix == (byte) 3)
          str1 = "Gefährlich";
        if (this.prefix == (byte) 4)
          str1 = "Barbarisch";
        if (this.prefix == (byte) 5)
          str1 = "Scharf";
        if (this.prefix == (byte) 6)
          str1 = "Spitze";
        if (this.prefix == (byte) 7)
          str1 = "Winzig";
        if (this.prefix == (byte) 8)
          str1 = "Schrecklicher";
        if (this.prefix == (byte) 9)
          str1 = "Klein";
        if (this.prefix == (byte) 10)
          str1 = "Stumpf";
        if (this.prefix == (byte) 11)
          str1 = "Unglücklich";
        if (this.prefix == (byte) 12)
          str1 = "Sperrig";
        if (this.prefix == (byte) 13)
          str1 = "Beschämend";
        if (this.prefix == (byte) 14)
          str1 = "Schwer";
        if (this.prefix == (byte) 15)
          str1 = "Locker";
        if (this.prefix == (byte) 16)
          str1 = "Gesichtet";
        if (this.prefix == (byte) 17)
          str1 = "Schnell";
        if (this.prefix == (byte) 18)
          str1 = "Hastig";
        if (this.prefix == (byte) 19)
          str1 = "Einschüchternd";
        if (this.prefix == (byte) 20)
          str1 = "Tödlich";
        if (this.prefix == (byte) 21)
          str1 = "Stillen";
        if (this.prefix == (byte) 22)
          str1 = "Schrecklich";
        if (this.prefix == (byte) 23)
          str1 = "Lethargisch";
        if (this.prefix == (byte) 24)
          str1 = "Unbeholfen";
        if (this.prefix == (byte) 25)
          str1 = "Mächtig";
        if (this.prefix == (byte) 26)
          str1 = "Mystisch";
        if (this.prefix == (byte) 27)
          str1 = "Geschickt";
        if (this.prefix == (byte) 28)
          str1 = "Meisterhaft";
        if (this.prefix == (byte) 29)
          str1 = "Ungeschickt";
        if (this.prefix == (byte) 30)
          str1 = "Unwissend";
        if (this.prefix == (byte) 31)
          str1 = "Gestört";
        if (this.prefix == (byte) 32)
          str1 = "Intensiv";
        if (this.prefix == (byte) 33)
          str1 = "Tabu";
        if (this.prefix == (byte) 34)
          str1 = "Himmlisch";
        if (this.prefix == (byte) 35)
          str1 = "Wütend";
        if (this.prefix == (byte) 36)
          str1 = "Scharf";
        if (this.prefix == (byte) 37)
          str1 = "Überlegen";
        if (this.prefix == (byte) 38)
          str1 = "Kraftvoll";
        if (this.prefix == (byte) 39)
          str1 = "Gebrochen";
        if (this.prefix == (byte) 40)
          str1 = "Beschädigt";
        if (this.prefix == (byte) 41)
          str1 = "Schäbig";
        if (this.prefix == (byte) 42)
          str1 = "Rasch";
        if (this.prefix == (byte) 43)
          str1 = "Tödlich";
        if (this.prefix == (byte) 44)
          str1 = "Agil";
        if (this.prefix == (byte) 45)
          str1 = "Wendig";
        if (this.prefix == (byte) 46)
          str1 = "Mörderisch";
        if (this.prefix == (byte) 47)
          str1 = "Langsam";
        if (this.prefix == (byte) 48)
          str1 = "Träge";
        if (this.prefix == (byte) 49)
          str1 = "Faul";
        if (this.prefix == (byte) 50)
          str1 = "Lästig";
        if (this.prefix == (byte) 51)
          str1 = "Böse";
        if (this.prefix == (byte) 52)
          str1 = "Manisch";
        if (this.prefix == (byte) 53)
          str1 = "Verletzend";
        if (this.prefix == (byte) 54)
          str1 = "Stark";
        if (this.prefix == (byte) 55)
          str1 = "Unangenehm";
        if (this.prefix == (byte) 56)
          str1 = "Schwach";
        if (this.prefix == (byte) 57)
          str1 = "Rücksichtslos";
        if (this.prefix == (byte) 58)
          str1 = "Rasend";
        if (this.prefix == (byte) 59)
          str1 = "Fromm";
        if (this.prefix == (byte) 60)
          str1 = "Dämonisch";
        if (this.prefix == (byte) 61)
          str1 = "Eifrig";
        if (this.prefix == (byte) 62)
          str1 = "Schwer";
        if (this.prefix == (byte) 63)
          str1 = "Schutz-";
        if (this.prefix == (byte) 64)
          str1 = "Gepanzert";
        if (this.prefix == (byte) 65)
          str1 = "Defensiv";
        if (this.prefix == (byte) 66)
          str1 = "Geheimnisvoll";
        if (this.prefix == (byte) 67)
          str1 = "Präzise";
        if (this.prefix == (byte) 68)
          str1 = "Glücklich";
        if (this.prefix == (byte) 69)
          str1 = "Gezackt";
        if (this.prefix == (byte) 70)
          str1 = "Spike";
        if (this.prefix == (byte) 71)
          str1 = "Wütend";
        if (this.prefix == (byte) 72)
          str1 = "Bedrohlich";
        if (this.prefix == (byte) 73)
          str1 = "Rege";
        if (this.prefix == (byte) 74)
          str1 = "Flüchtig";
        if (this.prefix == (byte) 75)
          str1 = "Hastig";
        if (this.prefix == (byte) 76)
          str1 = "Rasch";
        if (this.prefix == (byte) 77)
          str1 = "Wild";
        if (this.prefix == (byte) 78)
          str1 = "Voreilig";
        if (this.prefix == (byte) 79)
          str1 = "Unerschrocken";
        if (this.prefix == (byte) 80)
          str1 = "Gewalttätig";
        if (this.prefix == (byte) 81)
          str1 = "Legendär";
        if (this.prefix == (byte) 82)
          str1 = "Unwirklich";
        if (this.prefix == (byte) 83)
          str1 = "Mythisch";
      }
      else if (Lang.lang == 3)
      {
        if (this.prefix == (byte) 1)
          str1 = "Grande";
        if (this.prefix == (byte) 2)
          str1 = "Massiccio";
        if (this.prefix == (byte) 3)
          str1 = "Pericoloso";
        if (this.prefix == (byte) 4)
          str1 = "Selvaggio";
        if (this.prefix == (byte) 5)
          str1 = "Appuntito";
        if (this.prefix == (byte) 6)
          str1 = "Tagliente";
        if (this.prefix == (byte) 7)
          str1 = "Minuto";
        if (this.prefix == (byte) 8)
          str1 = "Terribile";
        if (this.prefix == (byte) 9)
          str1 = "Piccolo";
        if (this.prefix == (byte) 10)
          str1 = "Opaco";
        if (this.prefix == (byte) 11)
          str1 = "Infelice";
        if (this.prefix == (byte) 12)
          str1 = "Ingombrante";
        if (this.prefix == (byte) 13)
          str1 = "Vergognoso";
        if (this.prefix == (byte) 14)
          str1 = "Pesante";
        if (this.prefix == (byte) 15)
          str1 = "Luce";
        if (this.prefix == (byte) 16)
          str1 = "Avvistato";
        if (this.prefix == (byte) 17)
          str1 = "Rapido";
        if (this.prefix == (byte) 18)
          str1 = "Frettoloso";
        if (this.prefix == (byte) 19)
          str1 = "Intimidatorio";
        if (this.prefix == (byte) 20)
          str1 = "Mortale";
        if (this.prefix == (byte) 21)
          str1 = "Convinto";
        if (this.prefix == (byte) 22)
          str1 = "Orribile";
        if (this.prefix == (byte) 23)
          str1 = "Letargico";
        if (this.prefix == (byte) 24)
          str1 = "Scomodo";
        if (this.prefix == (byte) 25)
          str1 = "Potente";
        if (this.prefix == (byte) 26)
          str1 = "Mistico";
        if (this.prefix == (byte) 27)
          str1 = "Esperto";
        if (this.prefix == (byte) 28)
          str1 = "Magistrale";
        if (this.prefix == (byte) 29)
          str1 = "Inetto";
        if (this.prefix == (byte) 30)
          str1 = "Ignorante";
        if (this.prefix == (byte) 31)
          str1 = "Squilibrato";
        if (this.prefix == (byte) 32)
          str1 = "Intenso";
        if (this.prefix == (byte) 33)
          str1 = "Tabù";
        if (this.prefix == (byte) 34)
          str1 = "Celeste";
        if (this.prefix == (byte) 35)
          str1 = "Furioso";
        if (this.prefix == (byte) 36)
          str1 = "Appassionato";
        if (this.prefix == (byte) 37)
          str1 = "Superiore";
        if (this.prefix == (byte) 38)
          str1 = "Forte";
        if (this.prefix == (byte) 39)
          str1 = "Rotto";
        if (this.prefix == (byte) 40)
          str1 = "Danneggiato";
        if (this.prefix == (byte) 41)
          str1 = "Scadente";
        if (this.prefix == (byte) 42)
          str1 = "Veloce";
        if (this.prefix == (byte) 43)
          str1 = "Mortale";
        if (this.prefix == (byte) 44)
          str1 = "Agile";
        if (this.prefix == (byte) 45)
          str1 = "Lesto";
        if (this.prefix == (byte) 46)
          str1 = "Omicida";
        if (this.prefix == (byte) 47)
          str1 = "Lento";
        if (this.prefix == (byte) 48)
          str1 = "Pigro";
        if (this.prefix == (byte) 49)
          str1 = "Indolente";
        if (this.prefix == (byte) 50)
          str1 = "Fastidioso";
        if (this.prefix == (byte) 51)
          str1 = "Brutto";
        if (this.prefix == (byte) 52)
          str1 = "Maniaco";
        if (this.prefix == (byte) 53)
          str1 = "Offensivo";
        if (this.prefix == (byte) 54)
          str1 = "Robusto";
        if (this.prefix == (byte) 55)
          str1 = "Sgradevole";
        if (this.prefix == (byte) 56)
          str1 = "Debole";
        if (this.prefix == (byte) 57)
          str1 = "Spietato";
        if (this.prefix == (byte) 58)
          str1 = "Frenetico";
        if (this.prefix == (byte) 59)
          str1 = "Devoto";
        if (this.prefix == (byte) 60)
          str1 = "Demonico";
        if (this.prefix == (byte) 61)
          str1 = "Zelante";
        if (this.prefix == (byte) 62)
          str1 = "Duro";
        if (this.prefix == (byte) 63)
          str1 = "Protettivo";
        if (this.prefix == (byte) 64)
          str1 = "Corazzato";
        if (this.prefix == (byte) 65)
          str1 = "Difensivo";
        if (this.prefix == (byte) 66)
          str1 = "Arcano";
        if (this.prefix == (byte) 67)
          str1 = "Preciso";
        if (this.prefix == (byte) 68)
          str1 = "Fortunato";
        if (this.prefix == (byte) 69)
          str1 = "Frastagliato";
        if (this.prefix == (byte) 70)
          str1 = "Spillo";
        if (this.prefix == (byte) 71)
          str1 = "Arrabbiato";
        if (this.prefix == (byte) 72)
          str1 = "Minaccioso";
        if (this.prefix == (byte) 73)
          str1 = "Vivace";
        if (this.prefix == (byte) 74)
          str1 = "Fugace";
        if (this.prefix == (byte) 75)
          str1 = "Frettoloso";
        if (this.prefix == (byte) 76)
          str1 = "Veloce";
        if (this.prefix == (byte) 77)
          str1 = "Selvaggio";
        if (this.prefix == (byte) 78)
          str1 = "Temerario";
        if (this.prefix == (byte) 79)
          str1 = "Intrepido";
        if (this.prefix == (byte) 80)
          str1 = "Violento";
        if (this.prefix == (byte) 81)
          str1 = "Leggendario";
        if (this.prefix == (byte) 82)
          str1 = "Irreale";
        if (this.prefix == (byte) 83)
          str1 = "Mitico";
      }
      else if (Lang.lang == 4)
      {
        if (this.prefix == (byte) 1)
          str1 = "Grand";
        if (this.prefix == (byte) 2)
          str1 = "Massif";
        if (this.prefix == (byte) 3)
          str1 = "Dangereuses";
        if (this.prefix == (byte) 4)
          str1 = "Sauvages";
        if (this.prefix == (byte) 5)
          str1 = "Coupante";
        if (this.prefix == (byte) 6)
          str1 = "Pointues";
        if (this.prefix == (byte) 7)
          str1 = "Minuscules";
        if (this.prefix == (byte) 8)
          str1 = "Terrible";
        if (this.prefix == (byte) 9)
          str1 = "Petit";
        if (this.prefix == (byte) 10)
          str1 = "Terne";
        if (this.prefix == (byte) 11)
          str1 = "Malheureux";
        if (this.prefix == (byte) 12)
          str1 = "Volumineux";
        if (this.prefix == (byte) 13)
          str1 = "Honteux";
        if (this.prefix == (byte) 14)
          str1 = "Lourds";
        if (this.prefix == (byte) 15)
          str1 = "Léger";
        if (this.prefix == (byte) 16)
          str1 = "Voyants";
        if (this.prefix == (byte) 17)
          str1 = "Rapide";
        if (this.prefix == (byte) 18)
          str1 = "Hâtif";
        if (this.prefix == (byte) 19)
          str1 = "Intimidant";
        if (this.prefix == (byte) 20)
          str1 = "Mortelle";
        if (this.prefix == (byte) 21)
          str1 = "Dévoué";
        if (this.prefix == (byte) 22)
          str1 = "Affreux";
        if (this.prefix == (byte) 23)
          str1 = "Léthargique";
        if (this.prefix == (byte) 24)
          str1 = "Scomodo";
        if (this.prefix == (byte) 25)
          str1 = "Puissante";
        if (this.prefix == (byte) 26)
          str1 = "Mystique";
        if (this.prefix == (byte) 27)
          str1 = "Expert";
        if (this.prefix == (byte) 28)
          str1 = "Magistrale";
        if (this.prefix == (byte) 29)
          str1 = "Inepte";
        if (this.prefix == (byte) 30)
          str1 = "Ignorants";
        if (this.prefix == (byte) 31)
          str1 = "Dérangé";
        if (this.prefix == (byte) 32)
          str1 = "Intenses";
        if (this.prefix == (byte) 33)
          str1 = "Tabou";
        if (this.prefix == (byte) 34)
          str1 = "Célestes";
        if (this.prefix == (byte) 35)
          str1 = "Furieux";
        if (this.prefix == (byte) 36)
          str1 = "Vif";
        if (this.prefix == (byte) 37)
          str1 = "Supérieure";
        if (this.prefix == (byte) 38)
          str1 = "Énergique";
        if (this.prefix == (byte) 39)
          str1 = "Rompu";
        if (this.prefix == (byte) 40)
          str1 = "Endommagés";
        if (this.prefix == (byte) 41)
          str1 = "Mesquin";
        if (this.prefix == (byte) 42)
          str1 = "Prompt";
        if (this.prefix == (byte) 43)
          str1 = "Mortelle";
        if (this.prefix == (byte) 44)
          str1 = "Agile";
        if (this.prefix == (byte) 45)
          str1 = "Leste";
        if (this.prefix == (byte) 46)
          str1 = "Meurtrier";
        if (this.prefix == (byte) 47)
          str1 = "Lente";
        if (this.prefix == (byte) 48)
          str1 = "Paresseux";
        if (this.prefix == (byte) 49)
          str1 = "Fainéant";
        if (this.prefix == (byte) 50)
          str1 = "Ennuyeux";
        if (this.prefix == (byte) 51)
          str1 = "Méchant";
        if (this.prefix == (byte) 52)
          str1 = "Maniaco";
        if (this.prefix == (byte) 53)
          str1 = "Blessant";
        if (this.prefix == (byte) 54)
          str1 = "Robuste";
        if (this.prefix == (byte) 55)
          str1 = "Désagréables";
        if (this.prefix == (byte) 56)
          str1 = "Faibles";
        if (this.prefix == (byte) 57)
          str1 = "Impitoyable";
        if (this.prefix == (byte) 58)
          str1 = "Frénétique";
        if (this.prefix == (byte) 59)
          str1 = "Pieux";
        if (this.prefix == (byte) 60)
          str1 = "Démoniaque";
        if (this.prefix == (byte) 61)
          str1 = "Zélé";
        if (this.prefix == (byte) 62)
          str1 = "Durs";
        if (this.prefix == (byte) 63)
          str1 = "Protecteur";
        if (this.prefix == (byte) 64)
          str1 = "Blindés";
        if (this.prefix == (byte) 65)
          str1 = "Défensif";
        if (this.prefix == (byte) 66)
          str1 = "Ésotérique";
        if (this.prefix == (byte) 67)
          str1 = "Précise";
        if (this.prefix == (byte) 68)
          str1 = "Chanceux";
        if (this.prefix == (byte) 69)
          str1 = "Déchiqueté";
        if (this.prefix == (byte) 70)
          str1 = "Pointes";
        if (this.prefix == (byte) 71)
          str1 = "Fâché";
        if (this.prefix == (byte) 72)
          str1 = "Menaçant";
        if (this.prefix == (byte) 73)
          str1 = "Brusque";
        if (this.prefix == (byte) 74)
          str1 = "Fugace";
        if (this.prefix == (byte) 75)
          str1 = "Hâtif";
        if (this.prefix == (byte) 76)
          str1 = "Prompt";
        if (this.prefix == (byte) 77)
          str1 = "Sauvages";
        if (this.prefix == (byte) 78)
          str1 = "Téméraire";
        if (this.prefix == (byte) 79)
          str1 = "Intrépide";
        if (this.prefix == (byte) 80)
          str1 = "Violent";
        if (this.prefix == (byte) 81)
          str1 = "Légendaire";
        if (this.prefix == (byte) 82)
          str1 = "Irréel";
        if (this.prefix == (byte) 83)
          str1 = "Mythique";
      }
      else if (Lang.lang == 5)
      {
        if (this.prefix == (byte) 1)
          str1 = "Grande";
        if (this.prefix == (byte) 2)
          str1 = "Masivo";
        if (this.prefix == (byte) 3)
          str1 = "Peligroso";
        if (this.prefix == (byte) 4)
          str1 = "Salvaje";
        if (this.prefix == (byte) 5)
          str1 = "Puntiagudo";
        if (this.prefix == (byte) 6)
          str1 = "Agudo";
        if (this.prefix == (byte) 7)
          str1 = "Diminuto";
        if (this.prefix == (byte) 8)
          str1 = "Mala ";
        if (this.prefix == (byte) 9)
          str1 = "Pequeño";
        if (this.prefix == (byte) 10)
          str1 = "Aburrido";
        if (this.prefix == (byte) 11)
          str1 = "Infeliz";
        if (this.prefix == (byte) 12)
          str1 = "Voluminoso";
        if (this.prefix == (byte) 13)
          str1 = "Vergonzoso";
        if (this.prefix == (byte) 14)
          str1 = "Pesado";
        if (this.prefix == (byte) 15)
          str1 = "Ligero";
        if (this.prefix == (byte) 16)
          str1 = "Ámbito";
        if (this.prefix == (byte) 17)
          str1 = "Rápido";
        if (this.prefix == (byte) 18)
          str1 = "Precipitado";
        if (this.prefix == (byte) 19)
          str1 = "Intimidante";
        if (this.prefix == (byte) 20)
          str1 = "Mortal";
        if (this.prefix == (byte) 21)
          str1 = "Firme";
        if (this.prefix == (byte) 22)
          str1 = "Atroz";
        if (this.prefix == (byte) 23)
          str1 = "Letárgico";
        if (this.prefix == (byte) 24)
          str1 = "Torpe";
        if (this.prefix == (byte) 25)
          str1 = "Poderoso";
        if (this.prefix == (byte) 26)
          str1 = "Místico";
        if (this.prefix == (byte) 27)
          str1 = "Experto";
        if (this.prefix == (byte) 28)
          str1 = "Maestro";
        if (this.prefix == (byte) 29)
          str1 = "Inepto";
        if (this.prefix == (byte) 30)
          str1 = "Ignorante";
        if (this.prefix == (byte) 31)
          str1 = "Trastornado";
        if (this.prefix == (byte) 32)
          str1 = "Intenso";
        if (this.prefix == (byte) 33)
          str1 = "Tabú";
        if (this.prefix == (byte) 34)
          str1 = "Celeste";
        if (this.prefix == (byte) 35)
          str1 = "Furioso";
        if (this.prefix == (byte) 36)
          str1 = "Afilado";
        if (this.prefix == (byte) 37)
          str1 = "Superior";
        if (this.prefix == (byte) 38)
          str1 = "Fuerte";
        if (this.prefix == (byte) 39)
          str1 = "Roto";
        if (this.prefix == (byte) 40)
          str1 = "Estropeado";
        if (this.prefix == (byte) 41)
          str1 = "Regenerado";
        if (this.prefix == (byte) 42)
          str1 = "Pronto";
        if (this.prefix == (byte) 43)
          str1 = "Mortal";
        if (this.prefix == (byte) 44)
          str1 = "Ágil";
        if (this.prefix == (byte) 45)
          str1 = "Listo";
        if (this.prefix == (byte) 46)
          str1 = "Asesino";
        if (this.prefix == (byte) 47)
          str1 = "Lento";
        if (this.prefix == (byte) 48)
          str1 = "Perezoso";
        if (this.prefix == (byte) 49)
          str1 = "Gandul";
        if (this.prefix == (byte) 50)
          str1 = "Molesto";
        if (this.prefix == (byte) 51)
          str1 = "Feo";
        if (this.prefix == (byte) 52)
          str1 = "Maníacos";
        if (this.prefix == (byte) 53)
          str1 = "Hiriente";
        if (this.prefix == (byte) 54)
          str1 = "Vigoroso";
        if (this.prefix == (byte) 55)
          str1 = "Desagradable";
        if (this.prefix == (byte) 56)
          str1 = "Débil";
        if (this.prefix == (byte) 57)
          str1 = "Despiadado";
        if (this.prefix == (byte) 58)
          str1 = "Frenético";
        if (this.prefix == (byte) 59)
          str1 = "Piadoso";
        if (this.prefix == (byte) 60)
          str1 = "Demoníaco";
        if (this.prefix == (byte) 61)
          str1 = "Celoso";
        if (this.prefix == (byte) 62)
          str1 = "Duro";
        if (this.prefix == (byte) 63)
          str1 = "Protector";
        if (this.prefix == (byte) 64)
          str1 = "Blindado";
        if (this.prefix == (byte) 65)
          str1 = "Defensivo";
        if (this.prefix == (byte) 66)
          str1 = "Arcano";
        if (this.prefix == (byte) 67)
          str1 = "Preciso";
        if (this.prefix == (byte) 68)
          str1 = "Afortunado";
        if (this.prefix == (byte) 69)
          str1 = "Dentado";
        if (this.prefix == (byte) 70)
          str1 = "Claveteado";
        if (this.prefix == (byte) 71)
          str1 = "Enojado";
        if (this.prefix == (byte) 72)
          str1 = "Amenazador";
        if (this.prefix == (byte) 73)
          str1 = "Enérgico";
        if (this.prefix == (byte) 74)
          str1 = "Fugaz";
        if (this.prefix == (byte) 75)
          str1 = "Precipitado";
        if (this.prefix == (byte) 76)
          str1 = "Pronto";
        if (this.prefix == (byte) 77)
          str1 = "Salvaje";
        if (this.prefix == (byte) 78)
          str1 = "Temerario";
        if (this.prefix == (byte) 79)
          str1 = "Intrépido";
        if (this.prefix == (byte) 80)
          str1 = "Violento";
        if (this.prefix == (byte) 81)
          str1 = "Legendario";
        if (this.prefix == (byte) 82)
          str1 = "Irreal";
        if (this.prefix == (byte) 83)
          str1 = "Mítico";
      }
      if (Lang.lang <= 1)
      {
        string str2 = this.name;
        if (str1 != "")
          str2 = str1 + " " + this.name;
        return str2;
      }
      if (Lang.lang == 2)
      {
        string str3 = this.name;
        if (str1 != "")
          str3 = this.name + " (" + str1 + ")";
        return str3;
      }
      if (Lang.lang == 3)
      {
        string str4 = this.name;
        if (str1 != "")
          str4 = this.name + " (" + str1 + ")";
        return str4;
      }
      if (Lang.lang == 4)
      {
        string str5 = this.name;
        if (str1 != "")
          str5 = this.name + " (" + str1 + ")";
        return str5;
      }
      string str6 = this.name;
      if (str1 != "")
        str6 = this.name + " (" + str1 + ")";
      return str6;
    }

    public void CheckTip()
    {
      if (this.toolTip != "")
        this.toolTip = Lang.toolTip(this.netID);
      if (!(this.toolTip2 != ""))
        return;
      this.toolTip2 = Lang.toolTip2(this.netID);
    }

    public void SetDefaults(string ItemName)
    {
      this.name = "";
      bool flag = false;
      if (ItemName == "Gold Pickaxe")
      {
        this.SetDefaults(1);
        this.color = new Color(210, 190, 0, 100);
        this.useTime = 17;
        this.pick = 55;
        this.useAnimation = 20;
        this.scale = 1.05f;
        this.damage = 6;
        this.value = 10000;
        this.toolTip = "Can mine Meteorite";
        this.netID = -1;
      }
      else if (ItemName == "Gold Broadsword")
      {
        this.SetDefaults(4);
        this.color = new Color(210, 190, 0, 100);
        this.useAnimation = 20;
        this.damage = 13;
        this.scale = 1.05f;
        this.value = 9000;
        this.netID = -2;
      }
      else if (ItemName == "Gold Shortsword")
      {
        this.SetDefaults(6);
        this.color = new Color(210, 190, 0, 100);
        this.damage = 11;
        this.useAnimation = 11;
        this.scale = 0.95f;
        this.value = 7000;
        this.netID = -3;
      }
      else if (ItemName == "Gold Axe")
      {
        this.SetDefaults(10);
        this.color = new Color(210, 190, 0, 100);
        this.useTime = 18;
        this.axe = 11;
        this.useAnimation = 26;
        this.scale = 1.15f;
        this.damage = 7;
        this.value = 8000;
        this.netID = -4;
      }
      else if (ItemName == "Gold Hammer")
      {
        this.SetDefaults(7);
        this.color = new Color(210, 190, 0, 100);
        this.useAnimation = 28;
        this.useTime = 23;
        this.scale = 1.25f;
        this.damage = 9;
        this.hammer = 55;
        this.value = 8000;
        this.netID = -5;
      }
      else if (ItemName == "Gold Bow")
      {
        this.SetDefaults(99);
        this.useAnimation = 26;
        this.useTime = 26;
        this.color = new Color(210, 190, 0, 100);
        this.damage = 11;
        this.value = 7000;
        this.netID = -6;
      }
      else if (ItemName == "Silver Pickaxe")
      {
        this.SetDefaults(1);
        this.color = new Color(180, 180, 180, 100);
        this.useTime = 11;
        this.pick = 45;
        this.useAnimation = 19;
        this.scale = 1.05f;
        this.damage = 6;
        this.value = 5000;
        this.netID = -7;
      }
      else if (ItemName == "Silver Broadsword")
      {
        this.SetDefaults(4);
        this.color = new Color(180, 180, 180, 100);
        this.useAnimation = 21;
        this.damage = 11;
        this.value = 4500;
        this.netID = -8;
      }
      else if (ItemName == "Silver Shortsword")
      {
        this.SetDefaults(6);
        this.color = new Color(180, 180, 180, 100);
        this.damage = 9;
        this.useAnimation = 12;
        this.scale = 0.95f;
        this.value = 3500;
        this.netID = -9;
      }
      else if (ItemName == "Silver Axe")
      {
        this.SetDefaults(10);
        this.color = new Color(180, 180, 180, 100);
        this.useTime = 18;
        this.axe = 10;
        this.useAnimation = 26;
        this.scale = 1.15f;
        this.damage = 6;
        this.value = 4000;
        this.netID = -10;
      }
      else if (ItemName == "Silver Hammer")
      {
        this.SetDefaults(7);
        this.color = new Color(180, 180, 180, 100);
        this.useAnimation = 29;
        this.useTime = 19;
        this.scale = 1.25f;
        this.damage = 9;
        this.hammer = 45;
        this.value = 4000;
        this.netID = -11;
      }
      else if (ItemName == "Silver Bow")
      {
        this.SetDefaults(99);
        this.useAnimation = 27;
        this.useTime = 27;
        this.color = new Color(180, 180, 180, 100);
        this.damage = 9;
        this.value = 3500;
        this.netID = -12;
      }
      else if (ItemName == "Copper Pickaxe")
      {
        this.SetDefaults(1);
        this.color = new Color(180, 100, 45, 80);
        this.useTime = 15;
        this.pick = 35;
        this.useAnimation = 23;
        this.damage = 4;
        this.scale = 0.9f;
        this.tileBoost = -1;
        this.value = 500;
        this.netID = -13;
      }
      else if (ItemName == "Copper Broadsword")
      {
        this.SetDefaults(4);
        this.color = new Color(180, 100, 45, 80);
        this.useAnimation = 23;
        this.damage = 8;
        this.value = 450;
        this.netID = -14;
      }
      else if (ItemName == "Copper Shortsword")
      {
        this.SetDefaults(6);
        this.color = new Color(180, 100, 45, 80);
        this.damage = 5;
        this.useAnimation = 13;
        this.scale = 0.8f;
        this.value = 350;
        this.netID = -15;
      }
      else if (ItemName == "Copper Axe")
      {
        this.SetDefaults(10);
        this.color = new Color(180, 100, 45, 80);
        this.useTime = 21;
        this.axe = 7;
        this.useAnimation = 30;
        this.scale = 1f;
        this.damage = 3;
        this.tileBoost = -1;
        this.value = 400;
        this.netID = -16;
      }
      else if (ItemName == "Copper Hammer")
      {
        this.SetDefaults(7);
        this.color = new Color(180, 100, 45, 80);
        this.useAnimation = 33;
        this.useTime = 23;
        this.scale = 1.1f;
        this.damage = 4;
        this.hammer = 35;
        this.tileBoost = -1;
        this.value = 400;
        this.netID = -17;
      }
      else if (ItemName == "Copper Bow")
      {
        this.SetDefaults(99);
        this.useAnimation = 29;
        this.useTime = 29;
        this.color = new Color(180, 100, 45, 80);
        this.damage = 6;
        this.value = 350;
        this.netID = -18;
      }
      else if (ItemName == "Blue Phasesaber")
      {
        this.SetDefaults(198);
        this.damage = 41;
        this.scale = 1.15f;
        flag = true;
        this.autoReuse = true;
        this.useTurn = true;
        this.rare = 4;
        this.netID = -19;
      }
      else if (ItemName == "Red Phasesaber")
      {
        this.SetDefaults(199);
        this.damage = 41;
        this.scale = 1.15f;
        flag = true;
        this.autoReuse = true;
        this.useTurn = true;
        this.rare = 4;
        this.netID = -20;
      }
      else if (ItemName == "Green Phasesaber")
      {
        this.SetDefaults(200);
        this.damage = 41;
        this.scale = 1.15f;
        flag = true;
        this.autoReuse = true;
        this.useTurn = true;
        this.rare = 4;
        this.netID = -21;
      }
      else if (ItemName == "Purple Phasesaber")
      {
        this.SetDefaults(201);
        this.damage = 41;
        this.scale = 1.15f;
        flag = true;
        this.autoReuse = true;
        this.useTurn = true;
        this.rare = 4;
        this.netID = -22;
      }
      else if (ItemName == "White Phasesaber")
      {
        this.SetDefaults(202);
        this.damage = 41;
        this.scale = 1.15f;
        flag = true;
        this.autoReuse = true;
        this.useTurn = true;
        this.rare = 4;
        this.netID = -23;
      }
      else if (ItemName == "Yellow Phasesaber")
      {
        this.SetDefaults(203);
        this.damage = 41;
        this.scale = 1.15f;
        flag = true;
        this.autoReuse = true;
        this.useTurn = true;
        this.rare = 4;
        this.netID = -24;
      }
      else if (ItemName != "")
      {
        for (int Type = 0; Type < 604; ++Type)
        {
          if (Main.itemName[Type] == ItemName)
          {
            this.SetDefaults(Type);
            this.checkMat();
            return;
          }
        }
        this.name = "";
        this.stack = 0;
        this.type = 0;
      }
      if (this.type == 0)
        return;
      if (flag)
        this.material = false;
      else
        this.checkMat();
      this.name = ItemName;
      this.name = Lang.itemName(this.netID);
      this.CheckTip();
    }

    public bool checkMat()
    {
      if (this.type >= 71 && this.type <= 74)
      {
        this.material = false;
        return false;
      }
      for (int index1 = 0; index1 < Recipe.numRecipes; ++index1)
      {
        for (int index2 = 0; Main.recipe[index1].requiredItem[index2].type > 0; ++index2)
        {
          if (this.netID == Main.recipe[index1].requiredItem[index2].netID)
          {
            this.material = true;
            return true;
          }
        }
      }
      this.material = false;
      return false;
    }

    public void netDefaults(int type)
    {
      if (type < 0)
      {
        switch (type)
        {
          case -24:
            this.SetDefaults("Yellow Phasesaber");
            break;
          case -23:
            this.SetDefaults("White Phasesaber");
            break;
          case -22:
            this.SetDefaults("Purple Phasesaber");
            break;
          case -21:
            this.SetDefaults("Green Phasesaber");
            break;
          case -20:
            this.SetDefaults("Red Phasesaber");
            break;
          case -19:
            this.SetDefaults("Blue Phasesaber");
            break;
          case -18:
            this.SetDefaults("Copper Bow");
            break;
          case -17:
            this.SetDefaults("Copper Hammer");
            break;
          case -16:
            this.SetDefaults("Copper Axe");
            break;
          case -15:
            this.SetDefaults("Copper Shortsword");
            break;
          case -14:
            this.SetDefaults("Copper Broadsword");
            break;
          case -13:
            this.SetDefaults("Copper Pickaxe");
            break;
          case -12:
            this.SetDefaults("Silver Bow");
            break;
          case -11:
            this.SetDefaults("Silver Hammer");
            break;
          case -10:
            this.SetDefaults("Silver Axe");
            break;
          case -9:
            this.SetDefaults("Silver Shortsword");
            break;
          case -8:
            this.SetDefaults("Silver Broadsword");
            break;
          case -7:
            this.SetDefaults("Silver Pickaxe");
            break;
          case -6:
            this.SetDefaults("Gold Bow");
            break;
          case -5:
            this.SetDefaults("Gold Hammer");
            break;
          case -4:
            this.SetDefaults("Gold Axe");
            break;
          case -3:
            this.SetDefaults("Gold Shortsword");
            break;
          case -2:
            this.SetDefaults("Gold Broadsword");
            break;
          case -1:
            this.SetDefaults("Gold Pickaxe");
            break;
        }
      }
      else
        this.SetDefaults(type);
    }

    public void SetDefaults(int Type, bool noMatCheck = false)
    {
      this.owner = Main.netMode == 1 || Main.netMode == 2 ? (int) byte.MaxValue : Main.myPlayer;
      this.netID = 0;
      this.prefix = (byte) 0;
      this.crit = 0;
      this.mech = false;
      this.reuseDelay = 0;
      this.melee = false;
      this.magic = false;
      this.ranged = false;
      this.placeStyle = 0;
      this.buffTime = 0;
      this.buffType = 0;
      this.material = false;
      this.noWet = false;
      this.vanity = false;
      this.mana = 0;
      this.wet = false;
      this.wetCount = (byte) 0;
      this.lavaWet = false;
      this.channel = false;
      this.manaIncrease = 0;
      this.release = 0;
      this.noMelee = false;
      this.noUseGraphic = false;
      this.lifeRegen = 0;
      this.shootSpeed = 0.0f;
      this.active = true;
      this.alpha = 0;
      this.ammo = 0;
      this.useAmmo = 0;
      this.autoReuse = false;
      this.accessory = false;
      this.axe = 0;
      this.healMana = 0;
      this.bodySlot = -1;
      this.legSlot = -1;
      this.headSlot = -1;
      this.potion = false;
      this.color = new Color();
      this.consumable = false;
      this.createTile = -1;
      this.createWall = -1;
      this.damage = -1;
      this.defense = 0;
      this.hammer = 0;
      this.healLife = 0;
      this.holdStyle = 0;
      this.knockBack = 0.0f;
      this.maxStack = 1;
      this.pick = 0;
      this.rare = 0;
      this.scale = 1f;
      this.shoot = 0;
      this.stack = 1;
      this.toolTip = (string) null;
      this.toolTip2 = (string) null;
      this.tileBoost = 0;
      this.type = Type;
      this.useStyle = 0;
      this.useSound = 0;
      this.useTime = 100;
      this.useAnimation = 100;
      this.value = 0;
      this.useTurn = false;
      this.buy = false;
      if (this.type == 0)
      {
        this.name = "";
        this.stack = 0;
      }
      else if (this.type == 1)
      {
        this.name = "Iron Pickaxe";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 20;
        this.useTime = 13;
        this.autoReuse = true;
        this.width = 24;
        this.height = 28;
        this.damage = 5;
        this.pick = 40;
        this.useSound = 1;
        this.knockBack = 2f;
        this.value = 2000;
        this.melee = true;
      }
      else if (this.type == 2)
      {
        this.name = "Dirt Block";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 0;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 3)
      {
        this.name = "Stone Block";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 1;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 4)
      {
        this.name = "Iron Broadsword";
        this.useStyle = 1;
        this.useTurn = false;
        this.useAnimation = 21;
        this.useTime = 21;
        this.width = 24;
        this.height = 28;
        this.damage = 10;
        this.knockBack = 5f;
        this.useSound = 1;
        this.scale = 1f;
        this.value = 1800;
        this.melee = true;
      }
      else if (this.type == 5)
      {
        this.name = "Mushroom";
        this.useStyle = 2;
        this.useSound = 2;
        this.useTurn = false;
        this.useAnimation = 17;
        this.useTime = 17;
        this.width = 16;
        this.height = 18;
        this.healLife = 15;
        this.maxStack = 99;
        this.consumable = true;
        this.potion = true;
        this.value = 25;
      }
      else if (this.type == 6)
      {
        this.name = "Iron Shortsword";
        this.useStyle = 3;
        this.useTurn = false;
        this.useAnimation = 12;
        this.useTime = 12;
        this.width = 24;
        this.height = 28;
        this.damage = 8;
        this.knockBack = 4f;
        this.scale = 0.9f;
        this.useSound = 1;
        this.useTurn = true;
        this.value = 1400;
        this.melee = true;
      }
      else if (this.type == 7)
      {
        this.name = "Iron Hammer";
        this.autoReuse = true;
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 30;
        this.useTime = 20;
        this.hammer = 45;
        this.width = 24;
        this.height = 28;
        this.damage = 7;
        this.knockBack = 5.5f;
        this.scale = 1.2f;
        this.useSound = 1;
        this.value = 1600;
        this.melee = true;
      }
      else if (this.type == 8)
      {
        this.noWet = true;
        this.name = "Torch";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.holdStyle = 1;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 4;
        this.width = 10;
        this.height = 12;
        this.toolTip = "Provides light";
        this.value = 50;
      }
      else if (this.type == 9)
      {
        this.name = "Wood";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 30;
        this.width = 8;
        this.height = 10;
      }
      else if (this.type == 10)
      {
        this.name = "Iron Axe";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 27;
        this.knockBack = 4.5f;
        this.useTime = 19;
        this.autoReuse = true;
        this.width = 24;
        this.height = 28;
        this.damage = 5;
        this.axe = 9;
        this.scale = 1.1f;
        this.useSound = 1;
        this.value = 1600;
        this.melee = true;
      }
      else if (this.type == 11)
      {
        this.name = "Iron Ore";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 6;
        this.width = 12;
        this.height = 12;
        this.value = 500;
      }
      else if (this.type == 12)
      {
        this.name = "Copper Ore";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 7;
        this.width = 12;
        this.height = 12;
        this.value = 250;
      }
      else if (this.type == 13)
      {
        this.name = "Gold Ore";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 8;
        this.width = 12;
        this.height = 12;
        this.value = 2000;
      }
      else if (this.type == 14)
      {
        this.name = "Silver Ore";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 9;
        this.width = 12;
        this.height = 12;
        this.value = 1000;
      }
      else if (this.type == 15)
      {
        this.name = "Copper Watch";
        this.width = 24;
        this.height = 28;
        this.accessory = true;
        this.toolTip = "Tells the time";
        this.value = 1000;
      }
      else if (this.type == 16)
      {
        this.name = "Silver Watch";
        this.width = 24;
        this.height = 28;
        this.accessory = true;
        this.toolTip = "Tells the time";
        this.value = 5000;
      }
      else if (this.type == 17)
      {
        this.name = "Gold Watch";
        this.width = 24;
        this.height = 28;
        this.accessory = true;
        this.rare = 1;
        this.toolTip = "Tells the time";
        this.value = 10000;
      }
      else if (this.type == 18)
      {
        this.name = "Depth Meter";
        this.width = 24;
        this.height = 18;
        this.accessory = true;
        this.rare = 1;
        this.toolTip = "Shows depth";
        this.value = 10000;
      }
      else if (this.type == 19)
      {
        this.name = "Gold Bar";
        this.width = 20;
        this.height = 20;
        this.maxStack = 99;
        this.value = 6000;
      }
      else if (this.type == 20)
      {
        this.name = "Copper Bar";
        this.width = 20;
        this.height = 20;
        this.maxStack = 99;
        this.value = 750;
      }
      else if (this.type == 21)
      {
        this.name = "Silver Bar";
        this.width = 20;
        this.height = 20;
        this.maxStack = 99;
        this.value = 3000;
      }
      else if (this.type == 22)
      {
        this.name = "Iron Bar";
        this.width = 20;
        this.height = 20;
        this.maxStack = 99;
        this.value = 1500;
      }
      else if (this.type == 23)
      {
        this.name = "Gel";
        this.width = 10;
        this.height = 12;
        this.maxStack = 250;
        this.alpha = 175;
        this.ammo = 23;
        this.color = new Color(0, 80, (int) byte.MaxValue, 100);
        this.toolTip = "'Both tasty and flammable'";
        this.value = 5;
      }
      else if (this.type == 24)
      {
        this.name = "Wooden Sword";
        this.useStyle = 1;
        this.useTurn = false;
        this.useAnimation = 25;
        this.width = 24;
        this.height = 28;
        this.damage = 7;
        this.knockBack = 4f;
        this.scale = 0.95f;
        this.useSound = 1;
        this.value = 100;
        this.melee = true;
      }
      else if (this.type == 25)
      {
        this.name = "Wooden Door";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 10;
        this.width = 14;
        this.height = 28;
        this.value = 200;
      }
      else if (this.type == 26)
      {
        this.name = "Stone Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 1;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 27)
      {
        this.name = "Acorn";
        this.useTurn = true;
        this.useStyle = 1;
        this.useAnimation = 15;
        this.useTime = 10;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 20;
        this.width = 18;
        this.height = 18;
        this.value = 10;
      }
      else if (this.type == 28)
      {
        this.name = "Lesser Healing Potion";
        this.useSound = 3;
        this.healLife = 50;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.potion = true;
        this.value = 300;
      }
      else if (this.type == 29)
      {
        this.name = "Life Crystal";
        this.maxStack = 99;
        this.consumable = true;
        this.width = 18;
        this.height = 18;
        this.useStyle = 4;
        this.useTime = 30;
        this.useSound = 4;
        this.useAnimation = 30;
        this.toolTip = "Permanently increases maximum life by 20";
        this.rare = 2;
        this.value = 75000;
      }
      else if (this.type == 30)
      {
        this.name = "Dirt Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 16;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 31)
      {
        this.name = "Bottle";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 13;
        this.width = 16;
        this.height = 24;
        this.value = 20;
      }
      else if (this.type == 32)
      {
        this.name = "Wooden Table";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 14;
        this.width = 26;
        this.height = 20;
        this.value = 300;
      }
      else if (this.type == 33)
      {
        this.name = "Furnace";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 17;
        this.width = 26;
        this.height = 24;
        this.value = 300;
        this.toolTip = "Used for smelting ore";
      }
      else if (this.type == 34)
      {
        this.name = "Wooden Chair";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 15;
        this.width = 12;
        this.height = 30;
        this.value = 150;
      }
      else if (this.type == 35)
      {
        this.name = "Iron Anvil";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 16;
        this.width = 28;
        this.height = 14;
        this.value = 5000;
        this.toolTip = "Used to craft items from metal bars";
      }
      else if (this.type == 36)
      {
        this.name = "Work Bench";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 18;
        this.width = 28;
        this.height = 14;
        this.value = 150;
        this.toolTip = "Used for basic crafting";
      }
      else if (this.type == 37)
      {
        this.name = "Goggles";
        this.width = 28;
        this.height = 12;
        this.defense = 1;
        this.headSlot = 10;
        this.rare = 1;
        this.value = 1000;
      }
      else if (this.type == 38)
      {
        this.name = "Lens";
        this.width = 12;
        this.height = 20;
        this.maxStack = 99;
        this.value = 500;
      }
      else if (this.type == 39)
      {
        this.useStyle = 5;
        this.useAnimation = 30;
        this.useTime = 30;
        this.name = "Wooden Bow";
        this.width = 12;
        this.height = 28;
        this.shoot = 1;
        this.useAmmo = 1;
        this.useSound = 5;
        this.damage = 4;
        this.shootSpeed = 6.1f;
        this.noMelee = true;
        this.value = 100;
        this.ranged = true;
      }
      else if (this.type == 40)
      {
        this.name = "Wooden Arrow";
        this.shootSpeed = 3f;
        this.shoot = 1;
        this.damage = 4;
        this.width = 10;
        this.height = 28;
        this.maxStack = 250;
        this.consumable = true;
        this.ammo = 1;
        this.knockBack = 2f;
        this.value = 10;
        this.ranged = true;
      }
      else if (this.type == 41)
      {
        this.name = "Flaming Arrow";
        this.shootSpeed = 3.5f;
        this.shoot = 2;
        this.damage = 6;
        this.width = 10;
        this.height = 28;
        this.maxStack = 250;
        this.consumable = true;
        this.ammo = 1;
        this.knockBack = 2f;
        this.value = 15;
        this.ranged = true;
      }
      else if (this.type == 42)
      {
        this.useStyle = 1;
        this.name = "Shuriken";
        this.shootSpeed = 9f;
        this.shoot = 3;
        this.damage = 10;
        this.width = 18;
        this.height = 20;
        this.maxStack = 250;
        this.consumable = true;
        this.useSound = 1;
        this.useAnimation = 15;
        this.useTime = 15;
        this.noUseGraphic = true;
        this.noMelee = true;
        this.value = 20;
        this.ranged = true;
      }
      else if (this.type == 43)
      {
        this.useStyle = 4;
        this.name = "Suspicious Looking Eye";
        this.width = 22;
        this.height = 14;
        this.consumable = true;
        this.useAnimation = 45;
        this.useTime = 45;
        this.maxStack = 20;
        this.toolTip = "Summons the Eye of Cthulhu";
      }
      else if (this.type == 44)
      {
        this.useStyle = 5;
        this.useAnimation = 25;
        this.useTime = 25;
        this.name = "Demon Bow";
        this.width = 12;
        this.height = 28;
        this.shoot = 1;
        this.useAmmo = 1;
        this.useSound = 5;
        this.damage = 14;
        this.shootSpeed = 6.7f;
        this.knockBack = 1f;
        this.alpha = 30;
        this.rare = 1;
        this.noMelee = true;
        this.value = 18000;
        this.ranged = true;
      }
      else if (this.type == 45)
      {
        this.name = "War Axe of the Night";
        this.autoReuse = true;
        this.useStyle = 1;
        this.useAnimation = 30;
        this.knockBack = 6f;
        this.useTime = 15;
        this.width = 24;
        this.height = 28;
        this.damage = 20;
        this.axe = 15;
        this.scale = 1.2f;
        this.useSound = 1;
        this.rare = 1;
        this.value = 13500;
        this.melee = true;
      }
      else if (this.type == 46)
      {
        this.name = "Light's Bane";
        this.useStyle = 1;
        this.useAnimation = 20;
        this.knockBack = 5f;
        this.width = 24;
        this.height = 28;
        this.damage = 17;
        this.scale = 1.1f;
        this.useSound = 1;
        this.rare = 1;
        this.value = 13500;
        this.melee = true;
      }
      else if (this.type == 47)
      {
        this.name = "Unholy Arrow";
        this.shootSpeed = 3.4f;
        this.shoot = 4;
        this.damage = 8;
        this.width = 10;
        this.height = 28;
        this.maxStack = 250;
        this.consumable = true;
        this.ammo = 1;
        this.knockBack = 3f;
        this.alpha = 30;
        this.rare = 1;
        this.value = 40;
        this.ranged = true;
      }
      else if (this.type == 48)
      {
        this.name = "Chest";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 21;
        this.width = 26;
        this.height = 22;
        this.value = 500;
      }
      else if (this.type == 49)
      {
        this.name = "Band of Regeneration";
        this.width = 22;
        this.height = 22;
        this.accessory = true;
        this.lifeRegen = 1;
        this.rare = 1;
        this.toolTip = "Slowly regenerates life";
        this.value = 50000;
      }
      else if (this.type == 50)
      {
        this.mana = 20;
        this.name = "Magic Mirror";
        this.useTurn = true;
        this.width = 20;
        this.height = 20;
        this.useStyle = 4;
        this.useTime = 90;
        this.useSound = 6;
        this.useAnimation = 90;
        this.toolTip = "Gaze in the mirror to return home";
        this.rare = 1;
        this.value = 50000;
      }
      else if (this.type == 51)
      {
        this.name = "Jester's Arrow";
        this.shootSpeed = 0.5f;
        this.shoot = 5;
        this.damage = 9;
        this.width = 10;
        this.height = 28;
        this.maxStack = 250;
        this.consumable = true;
        this.ammo = 1;
        this.knockBack = 4f;
        this.rare = 1;
        this.value = 100;
        this.ranged = true;
      }
      else if (this.type == 52)
      {
        this.name = "Angel Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 1;
      }
      else if (this.type == 53)
      {
        this.name = "Cloud in a Bottle";
        this.width = 16;
        this.height = 24;
        this.accessory = true;
        this.rare = 1;
        this.toolTip = "Allows the holder to double jump";
        this.value = 50000;
      }
      else if (this.type == 54)
      {
        this.name = "Hermes Boots";
        this.width = 28;
        this.height = 24;
        this.accessory = true;
        this.rare = 1;
        this.toolTip = "The wearer can run super fast";
        this.value = 50000;
      }
      else if (this.type == 55)
      {
        this.noMelee = true;
        this.useStyle = 1;
        this.name = "Enchanted Boomerang";
        this.shootSpeed = 10f;
        this.shoot = 6;
        this.damage = 13;
        this.knockBack = 8f;
        this.width = 14;
        this.height = 28;
        this.useSound = 1;
        this.useAnimation = 15;
        this.useTime = 15;
        this.noUseGraphic = true;
        this.rare = 1;
        this.value = 50000;
        this.melee = true;
      }
      else if (this.type == 56)
      {
        this.name = "Demonite Ore";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 22;
        this.width = 12;
        this.height = 12;
        this.rare = 1;
        this.toolTip = "'Pulsing with dark energy'";
        this.value = 4000;
      }
      else if (this.type == 57)
      {
        this.name = "Demonite Bar";
        this.width = 20;
        this.height = 20;
        this.maxStack = 99;
        this.rare = 1;
        this.toolTip = "'Pulsing with dark energy'";
        this.value = 16000;
      }
      else if (this.type == 58)
      {
        this.name = "Heart";
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 59)
      {
        this.name = "Corrupt Seeds";
        this.useTurn = true;
        this.useStyle = 1;
        this.useAnimation = 15;
        this.useTime = 10;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 23;
        this.width = 14;
        this.height = 14;
        this.value = 500;
      }
      else if (this.type == 60)
      {
        this.name = "Vile Mushroom";
        this.width = 16;
        this.height = 18;
        this.maxStack = 99;
        this.value = 50;
      }
      else if (this.type == 61)
      {
        this.name = "Ebonstone Block";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 25;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 62)
      {
        this.name = "Grass Seeds";
        this.useTurn = true;
        this.useStyle = 1;
        this.useAnimation = 15;
        this.useTime = 10;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 2;
        this.width = 14;
        this.height = 14;
        this.value = 20;
      }
      else if (this.type == 63)
      {
        this.name = "Sunflower";
        this.useTurn = true;
        this.useStyle = 1;
        this.useAnimation = 15;
        this.useTime = 10;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 27;
        this.width = 26;
        this.height = 26;
        this.value = 200;
      }
      else if (this.type == 64)
      {
        this.mana = 12;
        this.damage = 8;
        this.useStyle = 1;
        this.name = "Vilethorn";
        this.shootSpeed = 32f;
        this.shoot = 7;
        this.width = 26;
        this.height = 28;
        this.useSound = 8;
        this.useAnimation = 30;
        this.useTime = 30;
        this.rare = 1;
        this.noMelee = true;
        this.knockBack = 1f;
        this.toolTip = "Summons a vile thorn";
        this.value = 10000;
        this.magic = true;
      }
      else if (this.type == 65)
      {
        this.autoReuse = true;
        this.mana = 16;
        this.knockBack = 5f;
        this.alpha = 100;
        this.color = new Color(150, 150, 150, 0);
        this.damage = 16;
        this.useStyle = 1;
        this.scale = 1.15f;
        this.name = "Starfury";
        this.shootSpeed = 12f;
        this.shoot = 9;
        this.width = 14;
        this.height = 28;
        this.useSound = 9;
        this.useAnimation = 25;
        this.useTime = 10;
        this.rare = 1;
        this.toolTip = "Causes stars to rain from the sky";
        this.toolTip2 = "'Forged with the fury of heaven'";
        this.value = 50000;
        this.magic = true;
      }
      else if (this.type == 66)
      {
        this.useStyle = 1;
        this.name = "Purification Powder";
        this.shootSpeed = 4f;
        this.shoot = 10;
        this.width = 16;
        this.height = 24;
        this.maxStack = 99;
        this.consumable = true;
        this.useSound = 1;
        this.useAnimation = 15;
        this.useTime = 15;
        this.noMelee = true;
        this.toolTip = "Cleanses the corruption";
        this.value = 75;
      }
      else if (this.type == 67)
      {
        this.damage = 0;
        this.useStyle = 1;
        this.name = "Vile Powder";
        this.shootSpeed = 4f;
        this.shoot = 11;
        this.width = 16;
        this.height = 24;
        this.maxStack = 99;
        this.consumable = true;
        this.useSound = 1;
        this.useAnimation = 15;
        this.useTime = 15;
        this.noMelee = true;
        this.value = 100;
        this.toolTip = "Removes the Hallow";
      }
      else if (this.type == 68)
      {
        this.name = "Rotten Chunk";
        this.width = 18;
        this.height = 20;
        this.maxStack = 99;
        this.toolTip = "'Looks tasty!'";
        this.value = 10;
      }
      else if (this.type == 69)
      {
        this.name = "Worm Tooth";
        this.width = 8;
        this.height = 20;
        this.maxStack = 99;
        this.value = 100;
      }
      else if (this.type == 70)
      {
        this.useStyle = 4;
        this.consumable = true;
        this.useAnimation = 45;
        this.useTime = 45;
        this.name = "Worm Food";
        this.width = 28;
        this.height = 28;
        this.maxStack = 20;
        this.toolTip = "Summons the Eater of Worlds";
      }
      else if (this.type == 71)
      {
        this.name = "Copper Coin";
        this.width = 10;
        this.height = 12;
        this.maxStack = 100;
        this.value = 5;
      }
      else if (this.type == 72)
      {
        this.name = "Silver Coin";
        this.width = 10;
        this.height = 12;
        this.maxStack = 100;
        this.value = 500;
      }
      else if (this.type == 73)
      {
        this.name = "Gold Coin";
        this.width = 10;
        this.height = 12;
        this.maxStack = 100;
        this.value = 50000;
      }
      else if (this.type == 74)
      {
        this.name = "Platinum Coin";
        this.width = 10;
        this.height = 12;
        this.maxStack = 100;
        this.value = 5000000;
      }
      else if (this.type == 75)
      {
        this.name = "Fallen Star";
        this.width = 18;
        this.height = 20;
        this.maxStack = 100;
        this.alpha = 75;
        this.ammo = 15;
        this.toolTip = "Disappears after the sunrise";
        this.value = 500;
        this.useStyle = 4;
        this.useSound = 4;
        this.useTurn = false;
        this.useAnimation = 17;
        this.useTime = 17;
        this.consumable = true;
        this.rare = 1;
      }
      else if (this.type == 76)
      {
        this.name = "Copper Greaves";
        this.width = 18;
        this.height = 18;
        this.defense = 1;
        this.legSlot = 1;
        this.value = 750;
      }
      else if (this.type == 77)
      {
        this.name = "Iron Greaves";
        this.width = 18;
        this.height = 18;
        this.defense = 2;
        this.legSlot = 2;
        this.value = 3000;
      }
      else if (this.type == 78)
      {
        this.name = "Silver Greaves";
        this.width = 18;
        this.height = 18;
        this.defense = 3;
        this.legSlot = 3;
        this.value = 7500;
      }
      else if (this.type == 79)
      {
        this.name = "Gold Greaves";
        this.width = 18;
        this.height = 18;
        this.defense = 4;
        this.legSlot = 4;
        this.value = 15000;
      }
      else if (this.type == 80)
      {
        this.name = "Copper Chainmail";
        this.width = 18;
        this.height = 18;
        this.defense = 2;
        this.bodySlot = 1;
        this.value = 1000;
      }
      else if (this.type == 81)
      {
        this.name = "Iron Chainmail";
        this.width = 18;
        this.height = 18;
        this.defense = 3;
        this.bodySlot = 2;
        this.value = 4000;
      }
      else if (this.type == 82)
      {
        this.name = "Silver Chainmail";
        this.width = 18;
        this.height = 18;
        this.defense = 4;
        this.bodySlot = 3;
        this.value = 10000;
      }
      else if (this.type == 83)
      {
        this.name = "Gold Chainmail";
        this.width = 18;
        this.height = 18;
        this.defense = 5;
        this.bodySlot = 4;
        this.value = 20000;
      }
      else if (this.type == 84)
      {
        this.noUseGraphic = true;
        this.damage = 0;
        this.knockBack = 7f;
        this.useStyle = 5;
        this.name = "Grappling Hook";
        this.shootSpeed = 11f;
        this.shoot = 13;
        this.width = 18;
        this.height = 28;
        this.useSound = 1;
        this.useAnimation = 20;
        this.useTime = 20;
        this.rare = 1;
        this.noMelee = true;
        this.value = 20000;
        this.toolTip = "'Get over here!'";
      }
      else if (this.type == 85)
      {
        this.name = "Iron Chain";
        this.width = 14;
        this.height = 20;
        this.maxStack = 99;
        this.value = 1000;
      }
      else if (this.type == 86)
      {
        this.name = "Shadow Scale";
        this.width = 14;
        this.height = 18;
        this.maxStack = 99;
        this.rare = 1;
        this.value = 500;
      }
      else if (this.type == 87)
      {
        this.name = "Piggy Bank";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 29;
        this.width = 20;
        this.height = 12;
        this.value = 10000;
      }
      else if (this.type == 88)
      {
        this.name = "Mining Helmet";
        this.width = 22;
        this.height = 16;
        this.defense = 1;
        this.headSlot = 11;
        this.rare = 1;
        this.value = 80000;
        this.toolTip = "Provides light when worn";
      }
      else if (this.type == 89)
      {
        this.name = "Copper Helmet";
        this.width = 18;
        this.height = 18;
        this.defense = 1;
        this.headSlot = 1;
        this.value = 1250;
      }
      else if (this.type == 90)
      {
        this.name = "Iron Helmet";
        this.width = 18;
        this.height = 18;
        this.defense = 2;
        this.headSlot = 2;
        this.value = 5000;
      }
      else if (this.type == 91)
      {
        this.name = "Silver Helmet";
        this.width = 18;
        this.height = 18;
        this.defense = 3;
        this.headSlot = 3;
        this.value = 12500;
      }
      else if (this.type == 92)
      {
        this.name = "Gold Helmet";
        this.width = 18;
        this.height = 18;
        this.defense = 4;
        this.headSlot = 4;
        this.value = 25000;
      }
      else if (this.type == 93)
      {
        this.name = "Wood Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 4;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 94)
      {
        this.name = "Wood Platform";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 19;
        this.width = 8;
        this.height = 10;
      }
      else if (this.type == 95)
      {
        this.useStyle = 5;
        this.useAnimation = 16;
        this.useTime = 16;
        this.name = "Flintlock Pistol";
        this.width = 24;
        this.height = 28;
        this.shoot = 14;
        this.useAmmo = 14;
        this.useSound = 11;
        this.damage = 10;
        this.shootSpeed = 5f;
        this.noMelee = true;
        this.value = 50000;
        this.scale = 0.9f;
        this.rare = 1;
        this.ranged = true;
      }
      else if (this.type == 96)
      {
        this.useStyle = 5;
        this.autoReuse = true;
        this.useAnimation = 43;
        this.useTime = 43;
        this.name = "Musket";
        this.width = 44;
        this.height = 14;
        this.shoot = 10;
        this.useAmmo = 14;
        this.useSound = 11;
        this.damage = 23;
        this.shootSpeed = 8f;
        this.noMelee = true;
        this.value = 100000;
        this.knockBack = 4f;
        this.rare = 1;
        this.ranged = true;
      }
      else if (this.type == 97)
      {
        this.name = "Musket Ball";
        this.shootSpeed = 4f;
        this.shoot = 14;
        this.damage = 7;
        this.width = 8;
        this.height = 8;
        this.maxStack = 250;
        this.consumable = true;
        this.ammo = 14;
        this.knockBack = 2f;
        this.value = 7;
        this.ranged = true;
      }
      else if (this.type == 98)
      {
        this.useStyle = 5;
        this.autoReuse = true;
        this.useAnimation = 8;
        this.useTime = 8;
        this.name = "Minishark";
        this.width = 50;
        this.height = 18;
        this.shoot = 10;
        this.useAmmo = 14;
        this.useSound = 11;
        this.damage = 6;
        this.shootSpeed = 7f;
        this.noMelee = true;
        this.value = 350000;
        this.rare = 2;
        this.toolTip = "33% chance to not consume ammo";
        this.toolTip2 = "'Half shark, half gun, completely awesome.'";
        this.ranged = true;
      }
      else if (this.type == 99)
      {
        this.useStyle = 5;
        this.useAnimation = 28;
        this.useTime = 28;
        this.name = "Iron Bow";
        this.width = 12;
        this.height = 28;
        this.shoot = 1;
        this.useAmmo = 1;
        this.useSound = 5;
        this.damage = 8;
        this.shootSpeed = 6.6f;
        this.noMelee = true;
        this.value = 1400;
        this.ranged = true;
      }
      else if (this.type == 100)
      {
        this.name = "Shadow Greaves";
        this.width = 18;
        this.height = 18;
        this.defense = 6;
        this.legSlot = 5;
        this.rare = 1;
        this.value = 22500;
        this.toolTip = "7% increased melee speed";
      }
      else if (this.type == 101)
      {
        this.name = "Shadow Scalemail";
        this.width = 18;
        this.height = 18;
        this.defense = 7;
        this.bodySlot = 5;
        this.rare = 1;
        this.value = 30000;
        this.toolTip = "7% increased melee speed";
      }
      else if (this.type == 102)
      {
        this.name = "Shadow Helmet";
        this.width = 18;
        this.height = 18;
        this.defense = 6;
        this.headSlot = 5;
        this.rare = 1;
        this.value = 37500;
        this.toolTip = "7% increased melee speed";
      }
      else if (this.type == 103)
      {
        this.name = "Nightmare Pickaxe";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 20;
        this.useTime = 15;
        this.autoReuse = true;
        this.width = 24;
        this.height = 28;
        this.damage = 9;
        this.pick = 65;
        this.useSound = 1;
        this.knockBack = 3f;
        this.rare = 1;
        this.value = 18000;
        this.scale = 1.15f;
        this.toolTip = "Able to mine Hellstone";
        this.melee = true;
      }
      else if (this.type == 104)
      {
        this.name = "The Breaker";
        this.autoReuse = true;
        this.useStyle = 1;
        this.useAnimation = 45;
        this.useTime = 19;
        this.hammer = 55;
        this.width = 24;
        this.height = 28;
        this.damage = 24;
        this.knockBack = 6f;
        this.scale = 1.3f;
        this.useSound = 1;
        this.rare = 1;
        this.value = 15000;
        this.melee = true;
      }
      else if (this.type == 105)
      {
        this.noWet = true;
        this.name = "Candle";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 33;
        this.width = 8;
        this.height = 18;
        this.holdStyle = 1;
      }
      else if (this.type == 106)
      {
        this.name = "Copper Chandelier";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 34;
        this.width = 26;
        this.height = 26;
      }
      else if (this.type == 107)
      {
        this.name = "Silver Chandelier";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 35;
        this.width = 26;
        this.height = 26;
      }
      else if (this.type == 108)
      {
        this.name = "Gold Chandelier";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 36;
        this.width = 26;
        this.height = 26;
      }
      else if (this.type == 109)
      {
        this.name = "Mana Crystal";
        this.maxStack = 99;
        this.consumable = true;
        this.width = 18;
        this.height = 18;
        this.useStyle = 4;
        this.useTime = 30;
        this.useSound = 29;
        this.useAnimation = 30;
        this.toolTip = "Permanently increases maximum mana by 20";
        this.rare = 2;
      }
      else if (this.type == 110)
      {
        this.name = "Lesser Mana Potion";
        this.useSound = 3;
        this.healMana = 50;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 20;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.value = 100;
      }
      else if (this.type == 111)
      {
        this.name = "Band of Starpower";
        this.width = 22;
        this.height = 22;
        this.accessory = true;
        this.rare = 1;
        this.toolTip = "Increases maximum mana by 20";
        this.value = 50000;
      }
      else if (this.type == 112)
      {
        this.mana = 17;
        this.damage = 44;
        this.useStyle = 1;
        this.name = "Flower of Fire";
        this.shootSpeed = 6f;
        this.shoot = 15;
        this.width = 26;
        this.height = 28;
        this.useSound = 20;
        this.useAnimation = 20;
        this.useTime = 20;
        this.rare = 3;
        this.noMelee = true;
        this.knockBack = 5.5f;
        this.toolTip = "Throws balls of fire";
        this.value = 10000;
        this.magic = true;
      }
      else if (this.type == 113)
      {
        this.mana = 10;
        this.channel = true;
        this.damage = 22;
        this.useStyle = 1;
        this.name = "Magic Missile";
        this.shootSpeed = 6f;
        this.shoot = 16;
        this.width = 26;
        this.height = 28;
        this.useSound = 9;
        this.useAnimation = 17;
        this.useTime = 17;
        this.rare = 2;
        this.noMelee = true;
        this.knockBack = 5f;
        this.toolTip = "Casts a controllable missile";
        this.value = 10000;
        this.magic = true;
      }
      else if (this.type == 114)
      {
        this.mana = 5;
        this.channel = true;
        this.damage = 0;
        this.useStyle = 1;
        this.name = "Dirt Rod";
        this.shoot = 17;
        this.width = 26;
        this.height = 28;
        this.useSound = 8;
        this.useAnimation = 20;
        this.useTime = 20;
        this.rare = 1;
        this.noMelee = true;
        this.knockBack = 5f;
        this.toolTip = "Magically moves dirt";
        this.value = 200000;
      }
      else if (this.type == 115)
      {
        this.mana = 40;
        this.channel = true;
        this.damage = 0;
        this.useStyle = 4;
        this.name = "Orb of Light";
        this.shoot = 18;
        this.width = 24;
        this.height = 24;
        this.useSound = 8;
        this.useAnimation = 20;
        this.useTime = 20;
        this.rare = 1;
        this.noMelee = true;
        this.toolTip = "Creates a magical orb of light";
        this.value = 10000;
        this.buffType = 19;
        this.buffTime = 18000;
      }
      else if (this.type == 116)
      {
        this.name = "Meteorite";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 37;
        this.width = 12;
        this.height = 12;
        this.value = 1000;
      }
      else if (this.type == 117)
      {
        this.name = "Meteorite Bar";
        this.width = 20;
        this.height = 20;
        this.maxStack = 99;
        this.rare = 1;
        this.toolTip = "'Warm to the touch'";
        this.value = 7000;
      }
      else if (this.type == 118)
      {
        this.name = "Hook";
        this.maxStack = 99;
        this.width = 18;
        this.height = 18;
        this.value = 1000;
        this.toolTip = "Sometimes dropped by Skeletons and Piranha";
      }
      else if (this.type == 119)
      {
        this.noMelee = true;
        this.useStyle = 1;
        this.name = "Flamarang";
        this.shootSpeed = 11f;
        this.shoot = 19;
        this.damage = 32;
        this.knockBack = 8f;
        this.width = 14;
        this.height = 28;
        this.useSound = 1;
        this.useAnimation = 15;
        this.useTime = 15;
        this.noUseGraphic = true;
        this.rare = 3;
        this.value = 100000;
        this.melee = true;
      }
      else if (this.type == 120)
      {
        this.useStyle = 5;
        this.useAnimation = 25;
        this.useTime = 25;
        this.name = "Molten Fury";
        this.width = 14;
        this.height = 32;
        this.shoot = 1;
        this.useAmmo = 1;
        this.useSound = 5;
        this.damage = 29;
        this.shootSpeed = 8f;
        this.knockBack = 2f;
        this.alpha = 30;
        this.rare = 3;
        this.noMelee = true;
        this.scale = 1.1f;
        this.value = 27000;
        this.toolTip = "Lights wooden arrows ablaze";
        this.ranged = true;
      }
      else if (this.type == 121)
      {
        this.name = "Fiery Greatsword";
        this.useStyle = 1;
        this.useAnimation = 34;
        this.knockBack = 6.5f;
        this.width = 24;
        this.height = 28;
        this.damage = 36;
        this.scale = 1.3f;
        this.useSound = 1;
        this.rare = 3;
        this.value = 27000;
        this.toolTip = "'It's made out of fire!'";
        this.melee = true;
      }
      if (this.type == 122)
      {
        this.name = "Molten Pickaxe";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 25;
        this.useTime = 25;
        this.autoReuse = true;
        this.width = 24;
        this.height = 28;
        this.damage = 12;
        this.pick = 100;
        this.scale = 1.15f;
        this.useSound = 1;
        this.knockBack = 2f;
        this.rare = 3;
        this.value = 27000;
        this.melee = true;
      }
      else if (this.type == 123)
      {
        this.name = "Meteor Helmet";
        this.width = 18;
        this.height = 18;
        this.defense = 3;
        this.headSlot = 6;
        this.rare = 1;
        this.value = 45000;
        this.toolTip = "5% increased magic damage";
      }
      else if (this.type == 124)
      {
        this.name = "Meteor Suit";
        this.width = 18;
        this.height = 18;
        this.defense = 4;
        this.bodySlot = 6;
        this.rare = 1;
        this.value = 30000;
        this.toolTip = "5% increased magic damage";
      }
      else if (this.type == 125)
      {
        this.name = "Meteor Leggings";
        this.width = 18;
        this.height = 18;
        this.defense = 3;
        this.legSlot = 6;
        this.rare = 1;
        this.value = 30000;
        this.toolTip = "5% increased magic damage";
      }
      else if (this.type == 126)
      {
        this.name = "Bottled Water";
        this.useSound = 3;
        this.healLife = 20;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.potion = true;
        this.value = 20;
      }
      else if (this.type == (int) sbyte.MaxValue)
      {
        this.autoReuse = true;
        this.useStyle = 5;
        this.useAnimation = 19;
        this.useTime = 19;
        this.name = "Space Gun";
        this.width = 24;
        this.height = 28;
        this.shoot = 20;
        this.mana = 8;
        this.useSound = 12;
        this.knockBack = 0.5f;
        this.damage = 17;
        this.shootSpeed = 10f;
        this.noMelee = true;
        this.scale = 0.8f;
        this.rare = 1;
        this.magic = true;
        this.value = 20000;
      }
      else if (this.type == 128)
      {
        this.name = "Rocket Boots";
        this.width = 28;
        this.height = 24;
        this.accessory = true;
        this.rare = 3;
        this.toolTip = "Allows flight";
        this.value = 50000;
      }
      else if (this.type == 129)
      {
        this.name = "Gray Brick";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 38;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 130)
      {
        this.name = "Gray Brick Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 5;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 131)
      {
        this.name = "Red Brick";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 39;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 132)
      {
        this.name = "Red Brick Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 6;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 133)
      {
        this.name = "Clay Block";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 40;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 134)
      {
        this.name = "Blue Brick";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 41;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 135)
      {
        this.name = "Blue Brick Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 17;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 136)
      {
        this.name = "Chain Lantern";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 42;
        this.width = 12;
        this.height = 28;
      }
      else if (this.type == 137)
      {
        this.name = "Green Brick";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 43;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 138)
      {
        this.name = "Green Brick Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 18;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 139)
      {
        this.name = "Pink Brick";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 44;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 140)
      {
        this.name = "Pink Brick Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 19;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 141)
      {
        this.name = "Gold Brick";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 45;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 142)
      {
        this.name = "Gold Brick Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 10;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 143)
      {
        this.name = "Silver Brick";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 46;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 144)
      {
        this.name = "Silver Brick Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 11;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 145)
      {
        this.name = "Copper Brick";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 47;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 146)
      {
        this.name = "Copper Brick Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 12;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 147)
      {
        this.name = "Spike";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 48;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 148)
      {
        this.noWet = true;
        this.name = "Water Candle";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 49;
        this.width = 8;
        this.height = 18;
        this.holdStyle = 1;
        this.toolTip = "Holding this may attract unwanted attention";
      }
      else if (this.type == 149)
      {
        this.name = "Book";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 50;
        this.width = 24;
        this.height = 28;
        this.toolTip = "'It contains strange symbols'";
      }
      else if (this.type == 150)
      {
        this.name = "Cobweb";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 51;
        this.width = 20;
        this.height = 24;
        this.alpha = 100;
      }
      else if (this.type == 151)
      {
        this.name = "Necro Helmet";
        this.width = 18;
        this.height = 18;
        this.defense = 5;
        this.headSlot = 7;
        this.rare = 2;
        this.value = 45000;
        this.toolTip = "4% increased ranged damage.";
      }
      else if (this.type == 152)
      {
        this.name = "Necro Breastplate";
        this.width = 18;
        this.height = 18;
        this.defense = 6;
        this.bodySlot = 7;
        this.rare = 2;
        this.value = 30000;
        this.toolTip = "4% increased ranged damage.";
      }
      else if (this.type == 153)
      {
        this.name = "Necro Greaves";
        this.width = 18;
        this.height = 18;
        this.defense = 5;
        this.legSlot = 7;
        this.rare = 2;
        this.value = 30000;
        this.toolTip = "4% increased ranged damage.";
      }
      else if (this.type == 154)
      {
        this.name = "Bone";
        this.maxStack = 99;
        this.consumable = true;
        this.width = 12;
        this.height = 14;
        this.value = 50;
        this.useAnimation = 12;
        this.useTime = 12;
        this.useStyle = 1;
        this.useSound = 1;
        this.shootSpeed = 8f;
        this.noUseGraphic = true;
        this.damage = 22;
        this.knockBack = 4f;
        this.shoot = 21;
        this.ranged = true;
      }
      else if (this.type == 155)
      {
        this.autoReuse = true;
        this.useTurn = true;
        this.name = "Muramasa";
        this.useStyle = 1;
        this.useAnimation = 20;
        this.width = 40;
        this.height = 40;
        this.damage = 18;
        this.scale = 1.1f;
        this.useSound = 1;
        this.rare = 2;
        this.value = 27000;
        this.knockBack = 1f;
        this.melee = true;
      }
      else if (this.type == 156)
      {
        this.name = "Cobalt Shield";
        this.width = 24;
        this.height = 28;
        this.rare = 2;
        this.value = 27000;
        this.accessory = true;
        this.defense = 1;
        this.toolTip = "Grants immunity to knockback";
      }
      else if (this.type == 157)
      {
        this.mana = 7;
        this.autoReuse = true;
        this.name = "Aqua Scepter";
        this.useStyle = 5;
        this.useAnimation = 16;
        this.useTime = 8;
        this.knockBack = 5f;
        this.width = 38;
        this.height = 10;
        this.damage = 14;
        this.scale = 1f;
        this.shoot = 22;
        this.shootSpeed = 11f;
        this.useSound = 13;
        this.rare = 2;
        this.value = 27000;
        this.toolTip = "Sprays out a shower of water";
        this.magic = true;
      }
      else if (this.type == 158)
      {
        this.name = "Lucky Horseshoe";
        this.width = 20;
        this.height = 22;
        this.rare = 1;
        this.value = 27000;
        this.accessory = true;
        this.toolTip = "Negates fall damage";
      }
      else if (this.type == 159)
      {
        this.name = "Shiny Red Balloon";
        this.width = 14;
        this.height = 28;
        this.rare = 1;
        this.value = 27000;
        this.accessory = true;
        this.toolTip = "Increases jump height";
      }
      else if (this.type == 160)
      {
        this.autoReuse = true;
        this.name = "Harpoon";
        this.useStyle = 5;
        this.useAnimation = 30;
        this.useTime = 30;
        this.knockBack = 6f;
        this.width = 30;
        this.height = 10;
        this.damage = 25;
        this.scale = 1.1f;
        this.shoot = 23;
        this.shootSpeed = 11f;
        this.useSound = 10;
        this.rare = 2;
        this.value = 27000;
        this.ranged = true;
      }
      else if (this.type == 161)
      {
        this.useStyle = 1;
        this.name = "Spiky Ball";
        this.shootSpeed = 5f;
        this.shoot = 24;
        this.knockBack = 1f;
        this.damage = 15;
        this.width = 10;
        this.height = 10;
        this.maxStack = 250;
        this.consumable = true;
        this.useSound = 1;
        this.useAnimation = 15;
        this.useTime = 15;
        this.noUseGraphic = true;
        this.noMelee = true;
        this.value = 80;
        this.ranged = true;
      }
      else if (this.type == 162)
      {
        this.name = "Ball O' Hurt";
        this.useStyle = 5;
        this.useAnimation = 45;
        this.useTime = 45;
        this.knockBack = 6.5f;
        this.width = 30;
        this.height = 10;
        this.damage = 15;
        this.scale = 1.1f;
        this.noUseGraphic = true;
        this.shoot = 25;
        this.shootSpeed = 12f;
        this.useSound = 1;
        this.rare = 1;
        this.value = 27000;
        this.melee = true;
        this.channel = true;
        this.noMelee = true;
      }
      else if (this.type == 163)
      {
        this.name = "Blue Moon";
        this.useStyle = 5;
        this.useAnimation = 45;
        this.useTime = 45;
        this.knockBack = 7f;
        this.width = 30;
        this.height = 10;
        this.damage = 23;
        this.scale = 1.1f;
        this.noUseGraphic = true;
        this.shoot = 26;
        this.shootSpeed = 12f;
        this.useSound = 1;
        this.rare = 2;
        this.value = 27000;
        this.melee = true;
        this.channel = true;
      }
      else if (this.type == 164)
      {
        this.autoReuse = false;
        this.useStyle = 5;
        this.useAnimation = 12;
        this.useTime = 12;
        this.name = "Handgun";
        this.width = 24;
        this.height = 24;
        this.shoot = 14;
        this.knockBack = 3f;
        this.useAmmo = 14;
        this.useSound = 11;
        this.damage = 14;
        this.shootSpeed = 10f;
        this.noMelee = true;
        this.value = 50000;
        this.scale = 0.75f;
        this.rare = 2;
        this.ranged = true;
      }
      else if (this.type == 165)
      {
        this.autoReuse = true;
        this.rare = 2;
        this.mana = 14;
        this.useSound = 21;
        this.name = "Water Bolt";
        this.useStyle = 5;
        this.damage = 17;
        this.useAnimation = 17;
        this.useTime = 17;
        this.width = 24;
        this.height = 28;
        this.shoot = 27;
        this.scale = 0.9f;
        this.shootSpeed = 4.5f;
        this.knockBack = 5f;
        this.toolTip = "Casts a slow moving bolt of water";
        this.magic = true;
        this.value = 50000;
      }
      else if (this.type == 166)
      {
        this.useStyle = 1;
        this.name = "Bomb";
        this.shootSpeed = 5f;
        this.shoot = 28;
        this.width = 20;
        this.height = 20;
        this.maxStack = 50;
        this.consumable = true;
        this.useSound = 1;
        this.useAnimation = 25;
        this.useTime = 25;
        this.noUseGraphic = true;
        this.noMelee = true;
        this.value = 500;
        this.damage = 0;
        this.toolTip = "A small explosion that will destroy some tiles";
      }
      else if (this.type == 167)
      {
        this.useStyle = 1;
        this.name = "Dynamite";
        this.shootSpeed = 4f;
        this.shoot = 29;
        this.width = 8;
        this.height = 28;
        this.maxStack = 5;
        this.consumable = true;
        this.useSound = 1;
        this.useAnimation = 40;
        this.useTime = 40;
        this.noUseGraphic = true;
        this.noMelee = true;
        this.value = 5000;
        this.rare = 1;
        this.toolTip = "A large explosion that will destroy most tiles";
      }
      else if (this.type == 168)
      {
        this.useStyle = 5;
        this.name = "Grenade";
        this.shootSpeed = 5.5f;
        this.shoot = 30;
        this.width = 20;
        this.height = 20;
        this.maxStack = 99;
        this.consumable = true;
        this.useSound = 1;
        this.useAnimation = 45;
        this.useTime = 45;
        this.noUseGraphic = true;
        this.noMelee = true;
        this.value = 400;
        this.damage = 60;
        this.knockBack = 8f;
        this.toolTip = "A small explosion that will not destroy tiles";
        this.ranged = true;
      }
      else if (this.type == 169)
      {
        this.name = "Sand Block";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 53;
        this.width = 12;
        this.height = 12;
        this.ammo = 42;
      }
      else if (this.type == 170)
      {
        this.name = "Glass";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 54;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 171)
      {
        this.name = "Sign";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 55;
        this.width = 28;
        this.height = 28;
      }
      else if (this.type == 172)
      {
        this.name = "Ash Block";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 57;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 173)
      {
        this.name = "Obsidian";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 56;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 174)
      {
        this.name = "Hellstone";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 58;
        this.width = 12;
        this.height = 12;
        this.rare = 2;
      }
      else if (this.type == 175)
      {
        this.name = "Hellstone Bar";
        this.width = 20;
        this.height = 20;
        this.maxStack = 99;
        this.rare = 2;
        this.toolTip = "'Hot to the touch'";
        this.value = 20000;
      }
      else if (this.type == 176)
      {
        this.name = "Mud Block";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 59;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 181)
      {
        this.name = "Amethyst";
        this.maxStack = 99;
        this.alpha = 50;
        this.width = 10;
        this.height = 14;
        this.value = 1875;
      }
      else if (this.type == 180)
      {
        this.name = "Topaz";
        this.maxStack = 99;
        this.alpha = 50;
        this.width = 10;
        this.height = 14;
        this.value = 3750;
      }
      else if (this.type == 177)
      {
        this.name = "Sapphire";
        this.maxStack = 99;
        this.alpha = 50;
        this.width = 10;
        this.height = 14;
        this.value = 5625;
      }
      else if (this.type == 179)
      {
        this.name = "Emerald";
        this.maxStack = 99;
        this.alpha = 50;
        this.width = 10;
        this.height = 14;
        this.value = 7500;
      }
      else if (this.type == 178)
      {
        this.name = "Ruby";
        this.maxStack = 99;
        this.alpha = 50;
        this.width = 10;
        this.height = 14;
        this.value = 11250;
      }
      else if (this.type == 182)
      {
        this.name = "Diamond";
        this.maxStack = 99;
        this.alpha = 50;
        this.width = 10;
        this.height = 14;
        this.value = 15000;
      }
      else if (this.type == 183)
      {
        this.name = "Glowing Mushroom";
        this.useStyle = 2;
        this.useSound = 2;
        this.useTurn = false;
        this.useAnimation = 17;
        this.useTime = 17;
        this.width = 16;
        this.height = 18;
        this.healLife = 25;
        this.maxStack = 99;
        this.consumable = true;
        this.potion = true;
        this.value = 50;
      }
      else if (this.type == 184)
      {
        this.name = "Star";
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 185)
      {
        this.noUseGraphic = true;
        this.damage = 0;
        this.knockBack = 7f;
        this.useStyle = 5;
        this.name = "Ivy Whip";
        this.shootSpeed = 13f;
        this.shoot = 32;
        this.width = 18;
        this.height = 28;
        this.useSound = 1;
        this.useAnimation = 20;
        this.useTime = 20;
        this.rare = 3;
        this.noMelee = true;
        this.value = 20000;
      }
      else if (this.type == 186)
      {
        this.name = "Breathing Reed";
        this.width = 44;
        this.height = 44;
        this.rare = 1;
        this.value = 10000;
        this.holdStyle = 2;
        this.toolTip = "'Because not drowning is kinda nice'";
      }
      else if (this.type == 187)
      {
        this.name = "Flipper";
        this.width = 28;
        this.height = 28;
        this.rare = 1;
        this.value = 10000;
        this.accessory = true;
        this.toolTip = "Grants the ability to swim";
      }
      else if (this.type == 188)
      {
        this.name = "Healing Potion";
        this.useSound = 3;
        this.healLife = 100;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.rare = 1;
        this.potion = true;
        this.value = 1000;
      }
      else if (this.type == 189)
      {
        this.name = "Mana Potion";
        this.useSound = 3;
        this.healMana = 100;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 50;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.rare = 1;
        this.value = 250;
      }
      else if (this.type == 190)
      {
        this.name = "Blade of Grass";
        this.useStyle = 1;
        this.useAnimation = 30;
        this.knockBack = 3f;
        this.width = 40;
        this.height = 40;
        this.damage = 28;
        this.scale = 1.4f;
        this.useSound = 1;
        this.rare = 3;
        this.value = 27000;
        this.melee = true;
      }
      else if (this.type == 191)
      {
        this.noMelee = true;
        this.useStyle = 1;
        this.name = "Thorn Chakram";
        this.shootSpeed = 11f;
        this.shoot = 33;
        this.damage = 25;
        this.knockBack = 8f;
        this.width = 14;
        this.height = 28;
        this.useSound = 1;
        this.useAnimation = 15;
        this.useTime = 15;
        this.noUseGraphic = true;
        this.rare = 3;
        this.value = 50000;
        this.melee = true;
      }
      else if (this.type == 192)
      {
        this.name = "Obsidian Brick";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 75;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 193)
      {
        this.name = "Obsidian Skull";
        this.width = 20;
        this.height = 22;
        this.rare = 2;
        this.value = 27000;
        this.accessory = true;
        this.defense = 1;
        this.toolTip = "Grants immunity to fire blocks";
      }
      else if (this.type == 194)
      {
        this.name = "Mushroom Grass Seeds";
        this.useTurn = true;
        this.useStyle = 1;
        this.useAnimation = 15;
        this.useTime = 10;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 70;
        this.width = 14;
        this.height = 14;
        this.value = 150;
      }
      else if (this.type == 195)
      {
        this.name = "Jungle Grass Seeds";
        this.useTurn = true;
        this.useStyle = 1;
        this.useAnimation = 15;
        this.useTime = 10;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 60;
        this.width = 14;
        this.height = 14;
        this.value = 150;
      }
      else if (this.type == 196)
      {
        this.name = "Wooden Hammer";
        this.autoReuse = true;
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 37;
        this.useTime = 25;
        this.hammer = 25;
        this.width = 24;
        this.height = 28;
        this.damage = 2;
        this.knockBack = 5.5f;
        this.scale = 1.2f;
        this.useSound = 1;
        this.tileBoost = -1;
        this.value = 50;
        this.melee = true;
      }
      else if (this.type == 197)
      {
        this.autoReuse = true;
        this.useStyle = 5;
        this.useAnimation = 12;
        this.useTime = 12;
        this.name = "Star Cannon";
        this.width = 50;
        this.height = 18;
        this.shoot = 12;
        this.useAmmo = 15;
        this.useSound = 9;
        this.damage = 55;
        this.shootSpeed = 14f;
        this.noMelee = true;
        this.value = 500000;
        this.rare = 2;
        this.toolTip = "Shoots fallen stars";
        this.ranged = true;
      }
      else if (this.type == 198)
      {
        this.name = "Blue Phaseblade";
        this.useStyle = 1;
        this.useAnimation = 25;
        this.knockBack = 3f;
        this.width = 40;
        this.height = 40;
        this.damage = 21;
        this.scale = 1f;
        this.useSound = 15;
        this.rare = 1;
        this.value = 27000;
        this.melee = true;
      }
      else if (this.type == 199)
      {
        this.name = "Red Phaseblade";
        this.useStyle = 1;
        this.useAnimation = 25;
        this.knockBack = 3f;
        this.width = 40;
        this.height = 40;
        this.damage = 21;
        this.scale = 1f;
        this.useSound = 15;
        this.rare = 1;
        this.value = 27000;
        this.melee = true;
      }
      else if (this.type == 200)
      {
        this.name = "Green Phaseblade";
        this.useStyle = 1;
        this.useAnimation = 25;
        this.knockBack = 3f;
        this.width = 40;
        this.height = 40;
        this.damage = 21;
        this.scale = 1f;
        this.useSound = 15;
        this.rare = 1;
        this.value = 27000;
        this.melee = true;
      }
      else if (this.type == 201)
      {
        this.name = "Purple Phaseblade";
        this.useStyle = 1;
        this.useAnimation = 25;
        this.knockBack = 3f;
        this.width = 40;
        this.height = 40;
        this.damage = 21;
        this.scale = 1f;
        this.useSound = 15;
        this.rare = 1;
        this.value = 27000;
        this.melee = true;
      }
      else if (this.type == 202)
      {
        this.name = "White Phaseblade";
        this.useStyle = 1;
        this.useAnimation = 25;
        this.knockBack = 3f;
        this.width = 40;
        this.height = 40;
        this.damage = 21;
        this.scale = 1f;
        this.useSound = 15;
        this.rare = 1;
        this.value = 27000;
        this.melee = true;
      }
      else if (this.type == 203)
      {
        this.name = "Yellow Phaseblade";
        this.useStyle = 1;
        this.useAnimation = 25;
        this.knockBack = 3f;
        this.width = 40;
        this.height = 40;
        this.damage = 21;
        this.scale = 1f;
        this.useSound = 15;
        this.rare = 1;
        this.value = 27000;
        this.melee = true;
      }
      else if (this.type == 204)
      {
        this.name = "Meteor Hamaxe";
        this.useTurn = true;
        this.autoReuse = true;
        this.useStyle = 1;
        this.useAnimation = 30;
        this.useTime = 16;
        this.hammer = 60;
        this.axe = 20;
        this.width = 24;
        this.height = 28;
        this.damage = 20;
        this.knockBack = 7f;
        this.scale = 1.2f;
        this.useSound = 1;
        this.rare = 1;
        this.value = 15000;
        this.melee = true;
      }
      else if (this.type == 205)
      {
        this.name = "Empty Bucket";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.width = 20;
        this.height = 20;
        this.headSlot = 13;
        this.defense = 1;
      }
      else if (this.type == 206)
      {
        this.name = "Water Bucket";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.width = 20;
        this.height = 20;
      }
      else if (this.type == 207)
      {
        this.name = "Lava Bucket";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.width = 20;
        this.height = 20;
      }
      else if (this.type == 208)
      {
        this.name = "Jungle Rose";
        this.width = 20;
        this.height = 20;
        this.value = 100;
        this.headSlot = 23;
        this.toolTip = "'It's pretty, oh so pretty'";
        this.vanity = true;
      }
      else if (this.type == 209)
      {
        this.name = "Stinger";
        this.width = 16;
        this.height = 18;
        this.maxStack = 99;
        this.value = 200;
      }
      else if (this.type == 210)
      {
        this.name = "Vine";
        this.width = 14;
        this.height = 20;
        this.maxStack = 99;
        this.value = 1000;
      }
      else if (this.type == 211)
      {
        this.name = "Feral Claws";
        this.width = 20;
        this.height = 20;
        this.accessory = true;
        this.rare = 3;
        this.toolTip = "12% increased melee speed";
        this.value = 50000;
      }
      else if (this.type == 212)
      {
        this.name = "Anklet of the Wind";
        this.width = 20;
        this.height = 20;
        this.accessory = true;
        this.rare = 3;
        this.toolTip = "10% increased movement speed";
        this.value = 50000;
      }
      else if (this.type == 213)
      {
        this.name = "Staff of Regrowth";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 25;
        this.useTime = 13;
        this.autoReuse = true;
        this.width = 24;
        this.height = 28;
        this.damage = 7;
        this.createTile = 2;
        this.scale = 1.2f;
        this.useSound = 1;
        this.knockBack = 3f;
        this.rare = 3;
        this.value = 2000;
        this.toolTip = "Creates grass on dirt";
        this.melee = true;
      }
      else if (this.type == 214)
      {
        this.name = "Hellstone Brick";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 76;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 215)
      {
        this.name = "Whoopie Cushion";
        this.width = 18;
        this.height = 18;
        this.useTurn = true;
        this.useTime = 30;
        this.useAnimation = 30;
        this.noUseGraphic = true;
        this.useStyle = 10;
        this.useSound = 16;
        this.rare = 2;
        this.toolTip = "'May annoy others'";
        this.value = 100;
      }
      else if (this.type == 216)
      {
        this.name = "Shackle";
        this.width = 20;
        this.height = 20;
        this.rare = 1;
        this.value = 1500;
        this.accessory = true;
        this.defense = 1;
      }
      else if (this.type == 217)
      {
        this.name = "Molten Hamaxe";
        this.useTurn = true;
        this.autoReuse = true;
        this.useStyle = 1;
        this.useAnimation = 27;
        this.useTime = 14;
        this.hammer = 70;
        this.axe = 30;
        this.width = 24;
        this.height = 28;
        this.damage = 20;
        this.knockBack = 7f;
        this.scale = 1.4f;
        this.useSound = 1;
        this.rare = 3;
        this.value = 15000;
        this.melee = true;
      }
      else if (this.type == 218)
      {
        this.mana = 16;
        this.channel = true;
        this.damage = 34;
        this.useStyle = 1;
        this.name = "Flamelash";
        this.shootSpeed = 6f;
        this.shoot = 34;
        this.width = 26;
        this.height = 28;
        this.useSound = 20;
        this.useAnimation = 20;
        this.useTime = 20;
        this.rare = 3;
        this.noMelee = true;
        this.knockBack = 6.5f;
        this.toolTip = "Summons a controllable ball of fire";
        this.value = 10000;
        this.magic = true;
      }
      else if (this.type == 219)
      {
        this.autoReuse = false;
        this.useStyle = 5;
        this.useAnimation = 11;
        this.useTime = 11;
        this.name = "Phoenix Blaster";
        this.width = 24;
        this.height = 22;
        this.shoot = 14;
        this.knockBack = 2f;
        this.useAmmo = 14;
        this.useSound = 11;
        this.damage = 23;
        this.shootSpeed = 13f;
        this.noMelee = true;
        this.value = 50000;
        this.scale = 0.75f;
        this.rare = 3;
        this.ranged = true;
      }
      else if (this.type == 220)
      {
        this.name = "Sunfury";
        this.noMelee = true;
        this.useStyle = 5;
        this.useAnimation = 45;
        this.useTime = 45;
        this.knockBack = 7f;
        this.width = 30;
        this.height = 10;
        this.damage = 33;
        this.scale = 1.1f;
        this.noUseGraphic = true;
        this.shoot = 35;
        this.shootSpeed = 12f;
        this.useSound = 1;
        this.rare = 3;
        this.value = 27000;
        this.melee = true;
        this.channel = true;
      }
      else if (this.type == 221)
      {
        this.name = "Hellforge";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 77;
        this.width = 26;
        this.height = 24;
        this.value = 3000;
      }
      else if (this.type == 222)
      {
        this.name = "Clay Pot";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 78;
        this.width = 14;
        this.height = 14;
        this.value = 100;
        this.toolTip = "Grows plants";
      }
      else if (this.type == 223)
      {
        this.name = "Nature's Gift";
        this.width = 20;
        this.height = 22;
        this.rare = 3;
        this.value = 27000;
        this.accessory = true;
        this.toolTip = "6% reduced mana usage";
      }
      else if (this.type == 224)
      {
        this.name = "Bed";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 79;
        this.width = 28;
        this.height = 20;
        this.value = 2000;
      }
      else if (this.type == 225)
      {
        this.name = "Silk";
        this.maxStack = 99;
        this.width = 22;
        this.height = 22;
        this.value = 1000;
      }
      else if (this.type == 226)
      {
        this.name = "Lesser Restoration Potion";
        this.useSound = 3;
        this.healMana = 50;
        this.healLife = 50;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 20;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.potion = true;
        this.value = 2000;
      }
      else if (this.type == 227)
      {
        this.name = "Restoration Potion";
        this.useSound = 3;
        this.healMana = 100;
        this.healLife = 100;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 20;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.potion = true;
        this.value = 4000;
      }
      else if (this.type == 228)
      {
        this.name = "Jungle Hat";
        this.width = 18;
        this.height = 18;
        this.defense = 4;
        this.headSlot = 8;
        this.rare = 3;
        this.value = 45000;
        this.toolTip = "Increases maximum mana by 20";
        this.toolTip2 = "3% increased magic critical strike chance";
      }
      else if (this.type == 229)
      {
        this.name = "Jungle Shirt";
        this.width = 18;
        this.height = 18;
        this.defense = 5;
        this.bodySlot = 8;
        this.rare = 3;
        this.value = 30000;
        this.toolTip = "Increases maximum mana by 20";
        this.toolTip2 = "3% increased magic critical strike chance";
      }
      else if (this.type == 230)
      {
        this.name = "Jungle Pants";
        this.width = 18;
        this.height = 18;
        this.defense = 4;
        this.legSlot = 8;
        this.rare = 3;
        this.value = 30000;
        this.toolTip = "Increases maximum mana by 20";
        this.toolTip2 = "3% increased magic critical strike chance";
      }
      else if (this.type == 231)
      {
        this.name = "Molten Helmet";
        this.width = 18;
        this.height = 18;
        this.defense = 8;
        this.headSlot = 9;
        this.rare = 3;
        this.value = 45000;
      }
      else if (this.type == 232)
      {
        this.name = "Molten Breastplate";
        this.width = 18;
        this.height = 18;
        this.defense = 9;
        this.bodySlot = 9;
        this.rare = 3;
        this.value = 30000;
      }
      else if (this.type == 233)
      {
        this.name = "Molten Greaves";
        this.width = 18;
        this.height = 18;
        this.defense = 8;
        this.legSlot = 9;
        this.rare = 3;
        this.value = 30000;
      }
      else if (this.type == 234)
      {
        this.name = "Meteor Shot";
        this.shootSpeed = 3f;
        this.shoot = 36;
        this.damage = 9;
        this.width = 8;
        this.height = 8;
        this.maxStack = 250;
        this.consumable = true;
        this.ammo = 14;
        this.knockBack = 1f;
        this.value = 8;
        this.rare = 1;
        this.ranged = true;
      }
      else if (this.type == 235)
      {
        this.useStyle = 1;
        this.name = "Sticky Bomb";
        this.shootSpeed = 5f;
        this.shoot = 37;
        this.width = 20;
        this.height = 20;
        this.maxStack = 50;
        this.consumable = true;
        this.useSound = 1;
        this.useAnimation = 25;
        this.useTime = 25;
        this.noUseGraphic = true;
        this.noMelee = true;
        this.value = 500;
        this.damage = 0;
        this.toolTip = "'Tossing may be difficult.'";
      }
      else if (this.type == 236)
      {
        this.name = "Black Lens";
        this.width = 12;
        this.height = 20;
        this.maxStack = 99;
        this.value = 5000;
      }
      else if (this.type == 237)
      {
        this.name = "Sunglasses";
        this.width = 28;
        this.height = 12;
        this.headSlot = 12;
        this.rare = 2;
        this.value = 10000;
        this.toolTip = "'Makes you look cool!'";
        this.vanity = true;
      }
      else if (this.type == 238)
      {
        this.name = "Wizard Hat";
        this.width = 28;
        this.height = 20;
        this.headSlot = 14;
        this.rare = 2;
        this.value = 10000;
        this.defense = 2;
        this.toolTip = "15% increased magic damage";
      }
      else if (this.type == 239)
      {
        this.name = "Top Hat";
        this.width = 18;
        this.height = 18;
        this.headSlot = 15;
        this.value = 10000;
        this.vanity = true;
      }
      else if (this.type == 240)
      {
        this.name = "Tuxedo Shirt";
        this.width = 18;
        this.height = 18;
        this.bodySlot = 10;
        this.value = 5000;
        this.vanity = true;
      }
      else if (this.type == 241)
      {
        this.name = "Tuxedo Pants";
        this.width = 18;
        this.height = 18;
        this.legSlot = 10;
        this.value = 5000;
        this.vanity = true;
      }
      else if (this.type == 242)
      {
        this.name = "Summer Hat";
        this.width = 18;
        this.height = 18;
        this.headSlot = 16;
        this.value = 10000;
        this.vanity = true;
      }
      else if (this.type == 243)
      {
        this.name = "Bunny Hood";
        this.width = 18;
        this.height = 18;
        this.headSlot = 17;
        this.value = 20000;
        this.vanity = true;
      }
      else if (this.type == 244)
      {
        this.name = "Plumber's Hat";
        this.width = 18;
        this.height = 12;
        this.headSlot = 18;
        this.value = 10000;
        this.vanity = true;
      }
      else if (this.type == 245)
      {
        this.name = "Plumber's Shirt";
        this.width = 18;
        this.height = 18;
        this.bodySlot = 11;
        this.value = 250000;
        this.vanity = true;
      }
      else if (this.type == 246)
      {
        this.name = "Plumber's Pants";
        this.width = 18;
        this.height = 18;
        this.legSlot = 11;
        this.value = 250000;
        this.vanity = true;
      }
      else if (this.type == 247)
      {
        this.name = "Hero's Hat";
        this.width = 18;
        this.height = 12;
        this.headSlot = 19;
        this.value = 10000;
        this.vanity = true;
      }
      else if (this.type == 248)
      {
        this.name = "Hero's Shirt";
        this.width = 18;
        this.height = 18;
        this.bodySlot = 12;
        this.value = 5000;
        this.vanity = true;
      }
      else if (this.type == 249)
      {
        this.name = "Hero's Pants";
        this.width = 18;
        this.height = 18;
        this.legSlot = 12;
        this.value = 5000;
        this.vanity = true;
      }
      else if (this.type == 250)
      {
        this.name = "Fish Bowl";
        this.width = 18;
        this.height = 18;
        this.headSlot = 20;
        this.value = 10000;
        this.vanity = true;
      }
      else if (this.type == 251)
      {
        this.name = "Archaeologist's Hat";
        this.width = 18;
        this.height = 12;
        this.headSlot = 21;
        this.value = 10000;
        this.vanity = true;
      }
      else if (this.type == 252)
      {
        this.name = "Archaeologist's Jacket";
        this.width = 18;
        this.height = 18;
        this.bodySlot = 13;
        this.value = 5000;
        this.vanity = true;
      }
      else if (this.type == 253)
      {
        this.name = "Archaeologist's Pants";
        this.width = 18;
        this.height = 18;
        this.legSlot = 13;
        this.value = 5000;
        this.vanity = true;
      }
      else if (this.type == 254)
      {
        this.name = "Black Dye";
        this.maxStack = 99;
        this.width = 12;
        this.height = 20;
        this.value = 10000;
      }
      else if (this.type == (int) byte.MaxValue)
      {
        this.name = "Green Dye";
        this.maxStack = 99;
        this.width = 12;
        this.height = 20;
        this.value = 2000;
      }
      else if (this.type == 256)
      {
        this.name = "Ninja Hood";
        this.width = 18;
        this.height = 12;
        this.headSlot = 22;
        this.value = 10000;
        this.vanity = true;
      }
      else if (this.type == 257)
      {
        this.name = "Ninja Shirt";
        this.width = 18;
        this.height = 18;
        this.bodySlot = 14;
        this.value = 5000;
        this.vanity = true;
      }
      else if (this.type == 258)
      {
        this.name = "Ninja Pants";
        this.width = 18;
        this.height = 18;
        this.legSlot = 14;
        this.value = 5000;
        this.vanity = true;
      }
      else if (this.type == 259)
      {
        this.name = "Leather";
        this.width = 18;
        this.height = 20;
        this.maxStack = 99;
        this.value = 50;
      }
      else if (this.type == 260)
      {
        this.name = "Red Hat";
        this.width = 18;
        this.height = 14;
        this.headSlot = 24;
        this.value = 1000;
        this.vanity = true;
      }
      else if (this.type == 261)
      {
        this.name = "Goldfish";
        this.useStyle = 2;
        this.useSound = 2;
        this.useTurn = false;
        this.useAnimation = 17;
        this.useTime = 17;
        this.width = 20;
        this.height = 10;
        this.maxStack = 99;
        this.healLife = 20;
        this.consumable = true;
        this.value = 1000;
        this.potion = true;
        this.toolTip = "'It's smiling, might be a good snack'";
      }
      else if (this.type == 262)
      {
        this.name = "Robe";
        this.width = 18;
        this.height = 14;
        this.bodySlot = 15;
        this.value = 2000;
        this.vanity = true;
      }
      else if (this.type == 263)
      {
        this.name = "Robot Hat";
        this.width = 18;
        this.height = 18;
        this.headSlot = 25;
        this.value = 10000;
        this.vanity = true;
      }
      else if (this.type == 264)
      {
        this.name = "Gold Crown";
        this.width = 18;
        this.height = 18;
        this.headSlot = 26;
        this.value = 10000;
        this.vanity = true;
      }
      else if (this.type == 265)
      {
        this.name = "Hellfire Arrow";
        this.shootSpeed = 6.5f;
        this.shoot = 41;
        this.damage = 10;
        this.width = 10;
        this.height = 28;
        this.maxStack = 250;
        this.consumable = true;
        this.ammo = 1;
        this.knockBack = 8f;
        this.value = 100;
        this.rare = 2;
        this.ranged = true;
      }
      else if (this.type == 266)
      {
        this.useStyle = 5;
        this.useAnimation = 16;
        this.useTime = 16;
        this.autoReuse = true;
        this.name = "Sandgun";
        this.width = 40;
        this.height = 20;
        this.shoot = 42;
        this.useAmmo = 42;
        this.useSound = 11;
        this.damage = 30;
        this.shootSpeed = 12f;
        this.noMelee = true;
        this.knockBack = 5f;
        this.value = 10000;
        this.rare = 2;
        this.toolTip = "'This is a good idea!'";
        this.ranged = true;
      }
      else if (this.type == 267)
      {
        this.accessory = true;
        this.name = "Guide Voodoo Doll";
        this.width = 14;
        this.height = 26;
        this.value = 1000;
        this.toolTip = "'You are a terrible person.'";
      }
      else if (this.type == 268)
      {
        this.headSlot = 27;
        this.defense = 2;
        this.name = "Diving Helmet";
        this.width = 20;
        this.height = 20;
        this.value = 1000;
        this.rare = 2;
        this.toolTip = "Greatly extends underwater breathing";
      }
      else if (this.type == 269)
      {
        this.name = "Familiar Shirt";
        this.bodySlot = 0;
        this.width = 20;
        this.height = 20;
        this.value = 10000;
        this.color = Main.player[Main.myPlayer].shirtColor;
      }
      else if (this.type == 270)
      {
        this.name = "Familiar Pants";
        this.legSlot = 0;
        this.width = 20;
        this.height = 20;
        this.value = 10000;
        this.color = Main.player[Main.myPlayer].pantsColor;
      }
      else if (this.type == 271)
      {
        this.name = "Familiar Wig";
        this.headSlot = 0;
        this.width = 20;
        this.height = 20;
        this.value = 10000;
        this.color = Main.player[Main.myPlayer].hairColor;
      }
      else if (this.type == 272)
      {
        this.mana = 14;
        this.damage = 35;
        this.useStyle = 5;
        this.name = "Demon Scythe";
        this.shootSpeed = 0.2f;
        this.shoot = 45;
        this.width = 26;
        this.height = 28;
        this.useSound = 8;
        this.useAnimation = 20;
        this.useTime = 20;
        this.rare = 3;
        this.noMelee = true;
        this.knockBack = 5f;
        this.scale = 0.9f;
        this.toolTip = "Casts a demon scythe";
        this.value = 10000;
        this.magic = true;
      }
      else if (this.type == 273)
      {
        this.name = "Night's Edge";
        this.useStyle = 1;
        this.useAnimation = 27;
        this.useTime = 27;
        this.knockBack = 4.5f;
        this.width = 40;
        this.height = 40;
        this.damage = 42;
        this.scale = 1.15f;
        this.useSound = 1;
        this.rare = 3;
        this.value = 27000;
        this.melee = true;
      }
      else if (this.type == 274)
      {
        this.name = "Dark Lance";
        this.useStyle = 5;
        this.useAnimation = 25;
        this.useTime = 25;
        this.shootSpeed = 5f;
        this.knockBack = 4f;
        this.width = 40;
        this.height = 40;
        this.damage = 27;
        this.scale = 1.1f;
        this.useSound = 1;
        this.shoot = 46;
        this.rare = 3;
        this.value = 27000;
        this.noMelee = true;
        this.noUseGraphic = true;
        this.melee = true;
      }
      else if (this.type == 275)
      {
        this.name = "Coral";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 81;
        this.width = 20;
        this.height = 22;
        this.value = 400;
      }
      else if (this.type == 276)
      {
        this.name = "Cactus";
        this.maxStack = 250;
        this.width = 12;
        this.height = 12;
        this.value = 10;
      }
      else if (this.type == 277)
      {
        this.name = "Trident";
        this.useStyle = 5;
        this.useAnimation = 31;
        this.useTime = 31;
        this.shootSpeed = 4f;
        this.knockBack = 5f;
        this.width = 40;
        this.height = 40;
        this.damage = 10;
        this.scale = 1.1f;
        this.useSound = 1;
        this.shoot = 47;
        this.rare = 1;
        this.value = 10000;
        this.noMelee = true;
        this.noUseGraphic = true;
        this.melee = true;
      }
      else if (this.type == 278)
      {
        this.name = "Silver Bullet";
        this.shootSpeed = 4.5f;
        this.shoot = 14;
        this.damage = 9;
        this.width = 8;
        this.height = 8;
        this.maxStack = 250;
        this.consumable = true;
        this.ammo = 14;
        this.knockBack = 3f;
        this.value = 15;
        this.ranged = true;
      }
      else if (this.type == 279)
      {
        this.useStyle = 1;
        this.name = "Throwing Knife";
        this.shootSpeed = 10f;
        this.shoot = 48;
        this.damage = 12;
        this.width = 18;
        this.height = 20;
        this.maxStack = 250;
        this.consumable = true;
        this.useSound = 1;
        this.useAnimation = 15;
        this.useTime = 15;
        this.noUseGraphic = true;
        this.noMelee = true;
        this.value = 50;
        this.knockBack = 2f;
        this.ranged = true;
      }
      else if (this.type == 280)
      {
        this.name = "Spear";
        this.useStyle = 5;
        this.useAnimation = 31;
        this.useTime = 31;
        this.shootSpeed = 3.7f;
        this.knockBack = 6.5f;
        this.width = 32;
        this.height = 32;
        this.damage = 8;
        this.scale = 1f;
        this.useSound = 1;
        this.shoot = 49;
        this.value = 1000;
        this.noMelee = true;
        this.noUseGraphic = true;
        this.melee = true;
      }
      else if (this.type == 281)
      {
        this.useStyle = 5;
        this.autoReuse = true;
        this.useAnimation = 45;
        this.useTime = 45;
        this.name = "Blowpipe";
        this.width = 38;
        this.height = 6;
        this.shoot = 10;
        this.useAmmo = 51;
        this.useSound = 5;
        this.damage = 9;
        this.shootSpeed = 11f;
        this.noMelee = true;
        this.value = 10000;
        this.knockBack = 4f;
        this.useAmmo = 51;
        this.toolTip = "Allows the collection of seeds for ammo";
        this.ranged = true;
      }
      else if (this.type == 282)
      {
        this.useStyle = 1;
        this.name = "Glowstick";
        this.shootSpeed = 6f;
        this.shoot = 50;
        this.width = 12;
        this.height = 12;
        this.maxStack = 99;
        this.consumable = true;
        this.useSound = 1;
        this.useAnimation = 15;
        this.useTime = 15;
        this.noMelee = true;
        this.value = 10;
        this.holdStyle = 1;
        this.toolTip = "Works when wet";
      }
      else if (this.type == 283)
      {
        this.name = "Seed";
        this.shoot = 51;
        this.width = 8;
        this.height = 8;
        this.maxStack = 250;
        this.ammo = 51;
        this.toolTip = "For use with Blowpipe";
      }
      else if (this.type == 284)
      {
        this.noMelee = true;
        this.useStyle = 1;
        this.name = "Wooden Boomerang";
        this.shootSpeed = 6.5f;
        this.shoot = 52;
        this.damage = 7;
        this.knockBack = 5f;
        this.width = 14;
        this.height = 28;
        this.useSound = 1;
        this.useAnimation = 16;
        this.useTime = 16;
        this.noUseGraphic = true;
        this.value = 5000;
        this.melee = true;
      }
      else if (this.type == 285)
      {
        this.name = "Aglet";
        this.width = 24;
        this.height = 8;
        this.accessory = true;
        this.toolTip = "5% increased movement speed";
        this.value = 5000;
      }
      else if (this.type == 286)
      {
        this.useStyle = 1;
        this.name = "Sticky Glowstick";
        this.shootSpeed = 6f;
        this.shoot = 53;
        this.width = 12;
        this.height = 12;
        this.maxStack = 99;
        this.consumable = true;
        this.useSound = 1;
        this.useAnimation = 15;
        this.useTime = 15;
        this.noMelee = true;
        this.value = 20;
        this.holdStyle = 1;
      }
      else if (this.type == 287)
      {
        this.useStyle = 1;
        this.name = "Poisoned Knife";
        this.shootSpeed = 11f;
        this.shoot = 54;
        this.damage = 13;
        this.width = 18;
        this.height = 20;
        this.maxStack = 250;
        this.consumable = true;
        this.useSound = 1;
        this.useAnimation = 15;
        this.useTime = 15;
        this.noUseGraphic = true;
        this.noMelee = true;
        this.value = 60;
        this.knockBack = 2f;
        this.ranged = true;
      }
      else if (this.type == 288)
      {
        this.name = "Obsidian Skin Potion";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.buffType = 1;
        this.buffTime = 14400;
        this.toolTip = "Provides immunity to lava";
        this.value = 1000;
        this.rare = 1;
      }
      else if (this.type == 289)
      {
        this.name = "Regeneration Potion";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.buffType = 2;
        this.buffTime = 18000;
        this.toolTip = "Provides life regeneration";
        this.value = 1000;
        this.rare = 1;
      }
      else if (this.type == 290)
      {
        this.name = "Swiftness Potion";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.buffType = 3;
        this.buffTime = 14400;
        this.toolTip = "25% increased movement speed";
        this.value = 1000;
        this.rare = 1;
      }
      else if (this.type == 291)
      {
        this.name = "Gills Potion";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.buffType = 4;
        this.buffTime = 7200;
        this.toolTip = "Breathe water instead of air";
        this.value = 1000;
        this.rare = 1;
      }
      else if (this.type == 292)
      {
        this.name = "Ironskin Potion";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.buffType = 5;
        this.buffTime = 18000;
        this.toolTip = "Increase defense by 8";
        this.value = 1000;
        this.rare = 1;
      }
      else if (this.type == 293)
      {
        this.name = "Mana Regeneration Potion";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.buffType = 6;
        this.buffTime = 7200;
        this.toolTip = "Increased mana regeneration";
        this.value = 1000;
        this.rare = 1;
      }
      else if (this.type == 294)
      {
        this.name = "Magic Power Potion";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.buffType = 7;
        this.buffTime = 7200;
        this.toolTip = "20% increased magic damage";
        this.value = 1000;
        this.rare = 1;
      }
      else if (this.type == 295)
      {
        this.name = "Featherfall Potion";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.buffType = 8;
        this.buffTime = 18000;
        this.toolTip = "Slows falling speed";
        this.value = 1000;
        this.rare = 1;
      }
      else if (this.type == 296)
      {
        this.name = "Spelunker Potion";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.buffType = 9;
        this.buffTime = 18000;
        this.toolTip = "Shows the location of treasure and ore";
        this.value = 1000;
        this.rare = 1;
      }
      else if (this.type == 297)
      {
        this.name = "Invisibility Potion";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.buffType = 10;
        this.buffTime = 7200;
        this.toolTip = "Grants invisibility";
        this.value = 1000;
        this.rare = 1;
      }
      else if (this.type == 298)
      {
        this.name = "Shine Potion";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.buffType = 11;
        this.buffTime = 18000;
        this.toolTip = "Emits an aura of light";
        this.value = 1000;
        this.rare = 1;
      }
      else if (this.type == 299)
      {
        this.name = "Night Owl Potion";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.buffType = 12;
        this.buffTime = 14400;
        this.toolTip = "Increases night vision";
        this.value = 1000;
        this.rare = 1;
      }
      else if (this.type == 300)
      {
        this.name = "Battle Potion";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.buffType = 13;
        this.buffTime = 25200;
        this.toolTip = "Increases enemy spawn rate";
        this.value = 1000;
        this.rare = 1;
      }
      else if (this.type == 301)
      {
        this.name = "Thorns Potion";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.buffType = 14;
        this.buffTime = 7200;
        this.toolTip = "Attackers also take damage";
        this.value = 1000;
        this.rare = 1;
      }
      else if (this.type == 302)
      {
        this.name = "Water Walking Potion";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.buffType = 15;
        this.buffTime = 18000;
        this.toolTip = "Allows the ability to walk on water";
        this.value = 1000;
        this.rare = 1;
      }
      else if (this.type == 303)
      {
        this.name = "Archery Potion";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.buffType = 16;
        this.buffTime = 14400;
        this.toolTip = "20% increased arrow speed and damage";
        this.value = 1000;
        this.rare = 1;
      }
      else if (this.type == 304)
      {
        this.name = "Hunter Potion";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.buffType = 17;
        this.buffTime = 18000;
        this.toolTip = "Shows the location of enemies";
        this.value = 1000;
        this.rare = 1;
      }
      else if (this.type == 305)
      {
        this.name = "Gravitation Potion";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.buffType = 18;
        this.buffTime = 10800;
        this.toolTip = "Allows the control of gravity";
        this.value = 1000;
        this.rare = 1;
      }
      else if (this.type == 306)
      {
        this.name = "Gold Chest";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 21;
        this.placeStyle = 1;
        this.width = 26;
        this.height = 22;
        this.value = 5000;
      }
      else if (this.type == 307)
      {
        this.name = "Daybloom Seeds";
        this.useTurn = true;
        this.useStyle = 1;
        this.useAnimation = 15;
        this.useTime = 10;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 82;
        this.placeStyle = 0;
        this.width = 12;
        this.height = 14;
        this.value = 80;
      }
      else if (this.type == 308)
      {
        this.name = "Moonglow Seeds";
        this.useTurn = true;
        this.useStyle = 1;
        this.useAnimation = 15;
        this.useTime = 10;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 82;
        this.placeStyle = 1;
        this.width = 12;
        this.height = 14;
        this.value = 80;
      }
      else if (this.type == 309)
      {
        this.name = "Blinkroot Seeds";
        this.useTurn = true;
        this.useStyle = 1;
        this.useAnimation = 15;
        this.useTime = 10;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 82;
        this.placeStyle = 2;
        this.width = 12;
        this.height = 14;
        this.value = 80;
      }
      else if (this.type == 310)
      {
        this.name = "Deathweed Seeds";
        this.useTurn = true;
        this.useStyle = 1;
        this.useAnimation = 15;
        this.useTime = 10;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 82;
        this.placeStyle = 3;
        this.width = 12;
        this.height = 14;
        this.value = 80;
      }
      else if (this.type == 311)
      {
        this.name = "Waterleaf Seeds";
        this.useTurn = true;
        this.useStyle = 1;
        this.useAnimation = 15;
        this.useTime = 10;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 82;
        this.placeStyle = 4;
        this.width = 12;
        this.height = 14;
        this.value = 80;
      }
      else if (this.type == 312)
      {
        this.name = "Fireblossom Seeds";
        this.useTurn = true;
        this.useStyle = 1;
        this.useAnimation = 15;
        this.useTime = 10;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 82;
        this.placeStyle = 5;
        this.width = 12;
        this.height = 14;
        this.value = 80;
      }
      else if (this.type == 313)
      {
        this.name = "Daybloom";
        this.maxStack = 99;
        this.width = 12;
        this.height = 14;
        this.value = 100;
      }
      else if (this.type == 314)
      {
        this.name = "Moonglow";
        this.maxStack = 99;
        this.width = 12;
        this.height = 14;
        this.value = 100;
      }
      else if (this.type == 315)
      {
        this.name = "Blinkroot";
        this.maxStack = 99;
        this.width = 12;
        this.height = 14;
        this.value = 100;
      }
      else if (this.type == 316)
      {
        this.name = "Deathweed";
        this.maxStack = 99;
        this.width = 12;
        this.height = 14;
        this.value = 100;
      }
      else if (this.type == 317)
      {
        this.name = "Waterleaf";
        this.maxStack = 99;
        this.width = 12;
        this.height = 14;
        this.value = 100;
      }
      else if (this.type == 318)
      {
        this.name = "Fireblossom";
        this.maxStack = 99;
        this.width = 12;
        this.height = 14;
        this.value = 100;
      }
      else if (this.type == 319)
      {
        this.name = "Shark Fin";
        this.maxStack = 99;
        this.width = 16;
        this.height = 14;
        this.value = 200;
      }
      else if (this.type == 320)
      {
        this.name = "Feather";
        this.maxStack = 99;
        this.width = 16;
        this.height = 14;
        this.value = 50;
      }
      else if (this.type == 321)
      {
        this.name = "Tombstone";
        this.useTurn = true;
        this.useStyle = 1;
        this.useAnimation = 15;
        this.useTime = 10;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 85;
        this.width = 20;
        this.height = 20;
      }
      else if (this.type == 322)
      {
        this.name = "Mime Mask";
        this.headSlot = 28;
        this.width = 20;
        this.height = 20;
        this.value = 20000;
      }
      else if (this.type == 323)
      {
        this.name = "Antlion Mandible";
        this.width = 10;
        this.height = 20;
        this.maxStack = 99;
        this.value = 50;
      }
      else if (this.type == 324)
      {
        this.name = "Illegal Gun Parts";
        this.width = 10;
        this.height = 20;
        this.maxStack = 99;
        this.value = 750000;
        this.toolTip = "'Banned in most places'";
      }
      else if (this.type == 325)
      {
        this.name = "The Doctor's Shirt";
        this.width = 18;
        this.height = 18;
        this.bodySlot = 16;
        this.value = 200000;
        this.vanity = true;
      }
      else if (this.type == 326)
      {
        this.name = "The Doctor's Pants";
        this.width = 18;
        this.height = 18;
        this.legSlot = 15;
        this.value = 200000;
        this.vanity = true;
      }
      else if (this.type == 327)
      {
        this.name = "Golden Key";
        this.width = 14;
        this.height = 20;
        this.maxStack = 99;
        this.toolTip = "Opens one Gold Chest";
      }
      else if (this.type == 328)
      {
        this.name = "Shadow Chest";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 21;
        this.placeStyle = 3;
        this.width = 26;
        this.height = 22;
        this.value = 5000;
      }
      else if (this.type == 329)
      {
        this.name = "Shadow Key";
        this.width = 14;
        this.height = 20;
        this.maxStack = 1;
        this.toolTip = "Opens all Shadow Chests";
        this.value = 75000;
      }
      else if (this.type == 330)
      {
        this.name = "Obsidian Brick Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 20;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 331)
      {
        this.name = "Jungle Spores";
        this.width = 18;
        this.height = 16;
        this.maxStack = 99;
        this.value = 100;
      }
      else if (this.type == 332)
      {
        this.name = "Loom";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 86;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.toolTip = "Used for crafting cloth";
      }
      else if (this.type == 333)
      {
        this.name = "Piano";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 87;
        this.width = 20;
        this.height = 20;
        this.value = 300;
      }
      else if (this.type == 334)
      {
        this.name = "Dresser";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 88;
        this.width = 20;
        this.height = 20;
        this.value = 300;
      }
      else if (this.type == 335)
      {
        this.name = "Bench";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 89;
        this.width = 20;
        this.height = 20;
        this.value = 300;
      }
      else if (this.type == 336)
      {
        this.name = "Bathtub";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 90;
        this.width = 20;
        this.height = 20;
        this.value = 300;
      }
      else if (this.type == 337)
      {
        this.name = "Red Banner";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 91;
        this.placeStyle = 0;
        this.width = 10;
        this.height = 24;
        this.value = 500;
      }
      else if (this.type == 338)
      {
        this.name = "Green Banner";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 91;
        this.placeStyle = 1;
        this.width = 10;
        this.height = 24;
        this.value = 500;
      }
      else if (this.type == 339)
      {
        this.name = "Blue Banner";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 91;
        this.placeStyle = 2;
        this.width = 10;
        this.height = 24;
        this.value = 500;
      }
      else if (this.type == 340)
      {
        this.name = "Yellow Banner";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 91;
        this.placeStyle = 3;
        this.width = 10;
        this.height = 24;
        this.value = 500;
      }
      else if (this.type == 341)
      {
        this.name = "Lamp Post";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 92;
        this.width = 10;
        this.height = 24;
        this.value = 500;
      }
      else if (this.type == 342)
      {
        this.name = "Tiki Torch";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 93;
        this.width = 10;
        this.height = 24;
        this.value = 500;
      }
      else if (this.type == 343)
      {
        this.name = "Barrel";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 21;
        this.placeStyle = 5;
        this.width = 20;
        this.height = 20;
        this.value = 500;
      }
      else if (this.type == 344)
      {
        this.name = "Chinese Lantern";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 95;
        this.width = 20;
        this.height = 20;
        this.value = 500;
      }
      else if (this.type == 345)
      {
        this.name = "Cooking Pot";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 96;
        this.width = 20;
        this.height = 20;
        this.value = 500;
      }
      else if (this.type == 346)
      {
        this.name = "Safe";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 97;
        this.width = 20;
        this.height = 20;
        this.value = 500000;
      }
      else if (this.type == 347)
      {
        this.name = "Skull Lantern";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 98;
        this.width = 20;
        this.height = 20;
        this.value = 500;
      }
      else if (this.type == 348)
      {
        this.name = "Trash Can";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 21;
        this.placeStyle = 6;
        this.width = 20;
        this.height = 20;
        this.value = 1000;
      }
      else if (this.type == 349)
      {
        this.name = "Candelabra";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 100;
        this.width = 20;
        this.height = 20;
        this.value = 1500;
      }
      else if (this.type == 350)
      {
        this.name = "Pink Vase";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 13;
        this.placeStyle = 3;
        this.width = 16;
        this.height = 24;
        this.value = 70;
      }
      else if (this.type == 351)
      {
        this.name = "Mug";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 13;
        this.placeStyle = 4;
        this.width = 16;
        this.height = 24;
        this.value = 20;
      }
      else if (this.type == 352)
      {
        this.name = "Keg";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 94;
        this.width = 24;
        this.height = 24;
        this.value = 600;
        this.toolTip = "Used for brewing ale";
      }
      else if (this.type == 353)
      {
        this.name = "Ale";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 10;
        this.height = 10;
        this.buffType = 25;
        this.buffTime = 7200;
        this.value = 100;
      }
      else if (this.type == 354)
      {
        this.name = "Bookcase";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 101;
        this.width = 20;
        this.height = 20;
        this.value = 300;
      }
      else if (this.type == 355)
      {
        this.name = "Throne";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 102;
        this.width = 20;
        this.height = 20;
        this.value = 300;
      }
      else if (this.type == 356)
      {
        this.name = "Bowl";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 103;
        this.width = 16;
        this.height = 24;
        this.value = 20;
      }
      else if (this.type == 357)
      {
        this.name = "Bowl of Soup";
        this.useSound = 3;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 10;
        this.height = 10;
        this.buffType = 26;
        this.buffTime = 36000;
        this.rare = 1;
        this.toolTip = "Minor improvements to all stats";
        this.value = 1000;
      }
      else if (this.type == 358)
      {
        this.name = "Toilet";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 15;
        this.placeStyle = 1;
        this.width = 12;
        this.height = 30;
        this.value = 150;
      }
      else if (this.type == 359)
      {
        this.name = "Grandfather Clock";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 104;
        this.width = 20;
        this.height = 20;
        this.value = 300;
      }
      else if (this.type == 360)
      {
        this.name = "Armor Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
      }
      else if (this.type == 361)
      {
        this.useStyle = 4;
        this.consumable = true;
        this.useAnimation = 45;
        this.useTime = 45;
        this.name = "Goblin Battle Standard";
        this.width = 28;
        this.height = 28;
        this.toolTip = "Summons a Goblin Army";
      }
      else if (this.type == 362)
      {
        this.name = "Tattered Cloth";
        this.maxStack = 99;
        this.width = 24;
        this.height = 24;
        this.value = 30;
      }
      else if (this.type == 363)
      {
        this.name = "Sawmill";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 106;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.toolTip = "Used for advanced wood crafting";
      }
      else if (this.type == 364)
      {
        this.name = "Cobalt Ore";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 107;
        this.width = 12;
        this.height = 12;
        this.value = 3500;
        this.rare = 3;
      }
      else if (this.type == 365)
      {
        this.name = "Mythril Ore";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 108;
        this.width = 12;
        this.height = 12;
        this.value = 5500;
        this.rare = 3;
      }
      else if (this.type == 366)
      {
        this.name = "Adamantite Ore";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 111;
        this.width = 12;
        this.height = 12;
        this.value = 7500;
        this.rare = 3;
      }
      else if (this.type == 367)
      {
        this.name = "Pwnhammer";
        this.useTurn = true;
        this.autoReuse = true;
        this.useStyle = 1;
        this.useAnimation = 27;
        this.useTime = 14;
        this.hammer = 80;
        this.width = 24;
        this.height = 28;
        this.damage = 26;
        this.knockBack = 7.5f;
        this.scale = 1.2f;
        this.useSound = 1;
        this.rare = 4;
        this.value = 39000;
        this.melee = true;
        this.toolTip = "Strong enough to destroy Demon Altars";
      }
      else if (this.type == 368)
      {
        this.autoReuse = true;
        this.name = "Excalibur";
        this.useStyle = 1;
        this.useAnimation = 25;
        this.useTime = 25;
        this.knockBack = 4.5f;
        this.width = 40;
        this.height = 40;
        this.damage = 47;
        this.scale = 1.15f;
        this.useSound = 1;
        this.rare = 5;
        this.value = 230000;
        this.melee = true;
      }
      else if (this.type == 369)
      {
        this.name = "Hallowed Seeds";
        this.useTurn = true;
        this.useStyle = 1;
        this.useAnimation = 15;
        this.useTime = 10;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 109;
        this.width = 14;
        this.height = 14;
        this.value = 2000;
        this.rare = 3;
      }
      else if (this.type == 370)
      {
        this.name = "Ebonsand Block";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 112;
        this.width = 12;
        this.height = 12;
        this.ammo = 42;
      }
      else if (this.type == 371)
      {
        this.name = "Cobalt Hat";
        this.width = 18;
        this.height = 18;
        this.defense = 2;
        this.headSlot = 29;
        this.rare = 4;
        this.value = 75000;
        this.toolTip = "Increases maximum mana by 40";
        this.toolTip2 = "9% increased magic critical strike chance";
      }
      else if (this.type == 372)
      {
        this.name = "Cobalt Helmet";
        this.width = 18;
        this.height = 18;
        this.defense = 11;
        this.headSlot = 30;
        this.rare = 4;
        this.value = 75000;
        this.toolTip = "7% increased movement speed";
        this.toolTip2 = "12% increased melee speed";
      }
      else if (this.type == 373)
      {
        this.name = "Cobalt Mask";
        this.width = 18;
        this.height = 18;
        this.defense = 4;
        this.headSlot = 31;
        this.rare = 4;
        this.value = 75000;
        this.toolTip = "10% increased ranged damage";
        this.toolTip2 = "6% increased ranged critical strike chance";
      }
      else if (this.type == 374)
      {
        this.name = "Cobalt Breastplate";
        this.width = 18;
        this.height = 18;
        this.defense = 8;
        this.bodySlot = 17;
        this.rare = 4;
        this.value = 60000;
        this.toolTip2 = "3% increased critical strike chance";
      }
      else if (this.type == 375)
      {
        this.name = "Cobalt Leggings";
        this.width = 18;
        this.height = 18;
        this.defense = 7;
        this.legSlot = 16;
        this.rare = 4;
        this.value = 45000;
        this.toolTip2 = "10% increased movement speed";
      }
      else if (this.type == 376)
      {
        this.name = "Mythril Hood";
        this.width = 18;
        this.height = 18;
        this.defense = 3;
        this.headSlot = 32;
        this.rare = 4;
        this.value = 112500;
        this.toolTip = "Increases maximum mana by 60";
        this.toolTip2 = "15% increased magic damage";
      }
      else if (this.type == 377)
      {
        this.name = "Mythril Helmet";
        this.width = 18;
        this.height = 18;
        this.defense = 16;
        this.headSlot = 33;
        this.rare = 4;
        this.value = 112500;
        this.toolTip = "5% increased melee critical strike chance";
        this.toolTip2 = "10% increased melee damage";
      }
      else if (this.type == 378)
      {
        this.name = "Mythril Hat";
        this.width = 18;
        this.height = 18;
        this.defense = 6;
        this.headSlot = 34;
        this.rare = 4;
        this.value = 112500;
        this.toolTip = "12% increased ranged damage";
        this.toolTip2 = "7% increased ranged critical strike chance";
      }
      else if (this.type == 379)
      {
        this.name = "Mythril Chainmail";
        this.width = 18;
        this.height = 18;
        this.defense = 12;
        this.bodySlot = 18;
        this.rare = 4;
        this.value = 90000;
        this.toolTip2 = "5% increased damage";
      }
      else if (this.type == 380)
      {
        this.name = "Mythril Greaves";
        this.width = 18;
        this.height = 18;
        this.defense = 9;
        this.legSlot = 17;
        this.rare = 4;
        this.value = 67500;
        this.toolTip2 = "3% increased critical strike chance";
      }
      else if (this.type == 381)
      {
        this.name = "Cobalt Bar";
        this.width = 20;
        this.height = 20;
        this.maxStack = 99;
        this.value = 10500;
        this.rare = 3;
      }
      else if (this.type == 382)
      {
        this.name = "Mythril Bar";
        this.width = 20;
        this.height = 20;
        this.maxStack = 99;
        this.value = 22000;
        this.rare = 3;
      }
      else if (this.type == 383)
      {
        this.name = "Cobalt Chainsaw";
        this.useStyle = 5;
        this.useAnimation = 25;
        this.useTime = 8;
        this.shootSpeed = 40f;
        this.knockBack = 2.75f;
        this.width = 20;
        this.height = 12;
        this.damage = 23;
        this.axe = 14;
        this.useSound = 23;
        this.shoot = 57;
        this.rare = 4;
        this.value = 54000;
        this.noMelee = true;
        this.noUseGraphic = true;
        this.melee = true;
        this.channel = true;
      }
      else if (this.type == 384)
      {
        this.name = "Mythril Chainsaw";
        this.useStyle = 5;
        this.useAnimation = 25;
        this.useTime = 8;
        this.shootSpeed = 40f;
        this.knockBack = 3f;
        this.width = 20;
        this.height = 12;
        this.damage = 29;
        this.axe = 17;
        this.useSound = 23;
        this.shoot = 58;
        this.rare = 4;
        this.value = 81000;
        this.noMelee = true;
        this.noUseGraphic = true;
        this.melee = true;
        this.channel = true;
      }
      else if (this.type == 385)
      {
        this.name = "Cobalt Drill";
        this.useStyle = 5;
        this.useAnimation = 25;
        this.useTime = 13;
        this.shootSpeed = 32f;
        this.knockBack = 0.0f;
        this.width = 20;
        this.height = 12;
        this.damage = 10;
        this.pick = 110;
        this.useSound = 23;
        this.shoot = 59;
        this.rare = 4;
        this.value = 54000;
        this.noMelee = true;
        this.noUseGraphic = true;
        this.melee = true;
        this.channel = true;
        this.toolTip = "Can mine Mythril";
      }
      else if (this.type == 386)
      {
        this.name = "Mythril Drill";
        this.useStyle = 5;
        this.useAnimation = 25;
        this.useTime = 10;
        this.shootSpeed = 32f;
        this.knockBack = 0.0f;
        this.width = 20;
        this.height = 12;
        this.damage = 15;
        this.pick = 150;
        this.useSound = 23;
        this.shoot = 60;
        this.rare = 4;
        this.value = 81000;
        this.noMelee = true;
        this.noUseGraphic = true;
        this.melee = true;
        this.channel = true;
        this.toolTip = "Can mine Adamantite";
      }
      else if (this.type == 387)
      {
        this.name = "Adamantite Chainsaw";
        this.useStyle = 5;
        this.useAnimation = 25;
        this.useTime = 6;
        this.shootSpeed = 40f;
        this.knockBack = 4.5f;
        this.width = 20;
        this.height = 12;
        this.damage = 33;
        this.axe = 20;
        this.useSound = 23;
        this.shoot = 61;
        this.rare = 4;
        this.value = 108000;
        this.noMelee = true;
        this.noUseGraphic = true;
        this.melee = true;
        this.channel = true;
      }
      else if (this.type == 388)
      {
        this.name = "Adamantite Drill";
        this.useStyle = 5;
        this.useAnimation = 25;
        this.useTime = 7;
        this.shootSpeed = 32f;
        this.knockBack = 0.0f;
        this.width = 20;
        this.height = 12;
        this.damage = 20;
        this.pick = 180;
        this.useSound = 23;
        this.shoot = 62;
        this.rare = 4;
        this.value = 108000;
        this.noMelee = true;
        this.noUseGraphic = true;
        this.melee = true;
        this.channel = true;
      }
      else if (this.type == 389)
      {
        this.name = "Dao of Pow";
        this.noMelee = true;
        this.useStyle = 5;
        this.useAnimation = 45;
        this.useTime = 45;
        this.knockBack = 7f;
        this.width = 30;
        this.height = 10;
        this.damage = 49;
        this.scale = 1.1f;
        this.noUseGraphic = true;
        this.shoot = 63;
        this.shootSpeed = 15f;
        this.useSound = 1;
        this.rare = 5;
        this.value = 144000;
        this.melee = true;
        this.channel = true;
        this.toolTip = "Has a chance to confuse";
        this.toolTip2 = "'Find your inner pieces'";
      }
      else if (this.type == 390)
      {
        this.name = "Mythril Halberd";
        this.useStyle = 5;
        this.useAnimation = 26;
        this.useTime = 26;
        this.shootSpeed = 4.5f;
        this.knockBack = 5f;
        this.width = 40;
        this.height = 40;
        this.damage = 35;
        this.scale = 1.1f;
        this.useSound = 1;
        this.shoot = 64;
        this.rare = 4;
        this.value = 67500;
        this.noMelee = true;
        this.noUseGraphic = true;
        this.melee = true;
      }
      else if (this.type == 391)
      {
        this.name = "Adamantite Bar";
        this.width = 20;
        this.height = 20;
        this.maxStack = 99;
        this.value = 37500;
        this.rare = 3;
      }
      else if (this.type == 392)
      {
        this.name = "Glass Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 21;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 393)
      {
        this.name = "Compass";
        this.width = 24;
        this.height = 28;
        this.rare = 3;
        this.value = 100000;
        this.accessory = true;
        this.toolTip = "Shows horizontal position";
      }
      else if (this.type == 394)
      {
        this.name = "Diving Gear";
        this.width = 24;
        this.height = 28;
        this.rare = 4;
        this.value = 100000;
        this.accessory = true;
        this.toolTip = "Grants the ability to swim";
        this.toolTip2 = "Greatly extends underwater breathing";
      }
      else if (this.type == 395)
      {
        this.name = "GPS";
        this.width = 24;
        this.height = 28;
        this.rare = 4;
        this.value = 150000;
        this.accessory = true;
        this.toolTip = "Shows position";
        this.toolTip2 = "Tells the time";
      }
      else if (this.type == 396)
      {
        this.name = "Obsidian Horseshoe";
        this.width = 24;
        this.height = 28;
        this.rare = 4;
        this.value = 100000;
        this.accessory = true;
        this.toolTip = "Negates fall damage";
        this.toolTip2 = "Grants immunity to fire blocks";
      }
      else if (this.type == 397)
      {
        this.name = "Obsidian Shield";
        this.width = 24;
        this.height = 28;
        this.rare = 4;
        this.value = 100000;
        this.accessory = true;
        this.defense = 2;
        this.toolTip = "Grants immunity to knockback";
        this.toolTip2 = "Grants immunity to fire blocks";
      }
      else if (this.type == 398)
      {
        this.name = "Tinkerer's Workshop";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 114;
        this.width = 26;
        this.height = 20;
        this.value = 100000;
        this.toolTip = "Allows the combining of some accessories";
      }
      else if (this.type == 399)
      {
        this.name = "Cloud in a Balloon";
        this.width = 14;
        this.height = 28;
        this.rare = 4;
        this.value = 150000;
        this.accessory = true;
        this.toolTip = "Allows the holder to double jump";
        this.toolTip2 = "Increases jump height";
      }
      else if (this.type == 400)
      {
        this.name = "Adamantite Headgear";
        this.width = 18;
        this.height = 18;
        this.defense = 4;
        this.headSlot = 35;
        this.rare = 4;
        this.value = 150000;
        this.toolTip = "Increases maximum mana by 80";
        this.toolTip2 = "11% increased magic damage and critical strike chance";
      }
      else if (this.type == 401)
      {
        this.name = "Adamantite Helmet";
        this.width = 18;
        this.height = 18;
        this.defense = 22;
        this.headSlot = 36;
        this.rare = 4;
        this.value = 150000;
        this.toolTip = "7% increased melee critical strike chance";
        this.toolTip2 = "14% increased melee damage";
      }
      else if (this.type == 402)
      {
        this.name = "Adamantite Mask";
        this.width = 18;
        this.height = 18;
        this.defense = 8;
        this.headSlot = 37;
        this.rare = 4;
        this.value = 150000;
        this.toolTip = "14% increased ranged damage";
        this.toolTip2 = "8% increased ranged critical strike chance";
      }
      else if (this.type == 403)
      {
        this.name = "Adamantite Breastplate";
        this.width = 18;
        this.height = 18;
        this.defense = 14;
        this.bodySlot = 19;
        this.rare = 4;
        this.value = 120000;
        this.toolTip = "6% increased damage";
      }
      else if (this.type == 404)
      {
        this.name = "Adamantite Leggings";
        this.width = 18;
        this.height = 18;
        this.defense = 10;
        this.legSlot = 18;
        this.rare = 4;
        this.value = 90000;
        this.toolTip = "4% increased critical strike chance";
        this.toolTip2 = "5% increased movement speed";
      }
      else if (this.type == 405)
      {
        this.name = "Spectre Boots";
        this.width = 28;
        this.height = 24;
        this.accessory = true;
        this.rare = 4;
        this.toolTip = "Allows flight";
        this.toolTip2 = "The wearer can run super fast";
        this.value = 100000;
      }
      else if (this.type == 406)
      {
        this.name = "Adamantite Glaive";
        this.useStyle = 5;
        this.useAnimation = 25;
        this.useTime = 25;
        this.shootSpeed = 5f;
        this.knockBack = 6f;
        this.width = 40;
        this.height = 40;
        this.damage = 38;
        this.scale = 1.1f;
        this.useSound = 1;
        this.shoot = 66;
        this.rare = 4;
        this.value = 90000;
        this.noMelee = true;
        this.noUseGraphic = true;
        this.melee = true;
      }
      else if (this.type == 407)
      {
        this.name = "Toolbelt";
        this.width = 28;
        this.height = 24;
        this.accessory = true;
        this.rare = 3;
        this.toolTip = "Increases block placement range";
        this.value = 100000;
      }
      else if (this.type == 408)
      {
        this.name = "Pearlsand Block";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 116;
        this.width = 12;
        this.height = 12;
        this.ammo = 42;
      }
      else if (this.type == 409)
      {
        this.name = "Pearlstone Block";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 117;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 410)
      {
        this.name = "Mining Shirt";
        this.width = 18;
        this.height = 18;
        this.defense = 1;
        this.bodySlot = 20;
        this.value = 5000;
        this.rare = 1;
      }
      else if (this.type == 411)
      {
        this.name = "Mining Pants";
        this.width = 18;
        this.height = 18;
        this.defense = 1;
        this.legSlot = 19;
        this.value = 5000;
        this.rare = 1;
      }
      else if (this.type == 412)
      {
        this.name = "Pearlstone Brick";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 118;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 413)
      {
        this.name = "Iridescent Brick";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 119;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 414)
      {
        this.name = "Mudstone Block";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 120;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 415)
      {
        this.name = "Cobalt Brick";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 121;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 416)
      {
        this.name = "Mythril Brick";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 122;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 417)
      {
        this.name = "Pearlstone Brick Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 22;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 418)
      {
        this.name = "Iridescent Brick Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 23;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 419)
      {
        this.name = "Mudstone Brick Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 24;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 420)
      {
        this.name = "Cobalt Brick Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 25;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 421)
      {
        this.name = "Mythril Brick Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 26;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 422)
      {
        this.useStyle = 1;
        this.name = "Holy Water";
        this.shootSpeed = 9f;
        this.rare = 3;
        this.damage = 20;
        this.shoot = 69;
        this.width = 18;
        this.height = 20;
        this.maxStack = 250;
        this.consumable = true;
        this.knockBack = 3f;
        this.useSound = 1;
        this.useAnimation = 15;
        this.useTime = 15;
        this.noUseGraphic = true;
        this.noMelee = true;
        this.value = 200;
        this.toolTip = "Spreads the Hallow to some blocks";
      }
      else if (this.type == 423)
      {
        this.useStyle = 1;
        this.name = "Unholy Water";
        this.shootSpeed = 9f;
        this.rare = 3;
        this.damage = 20;
        this.shoot = 70;
        this.width = 18;
        this.height = 20;
        this.maxStack = 250;
        this.consumable = true;
        this.knockBack = 3f;
        this.useSound = 1;
        this.useAnimation = 15;
        this.useTime = 15;
        this.noUseGraphic = true;
        this.noMelee = true;
        this.value = 200;
        this.toolTip = "Spreads the corruption to some blocks";
      }
      else if (this.type == 424)
      {
        this.name = "Silt Block";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 123;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 425)
      {
        this.mana = 40;
        this.channel = true;
        this.damage = 0;
        this.useStyle = 1;
        this.name = "Fairy Bell";
        this.shoot = 72;
        this.width = 24;
        this.height = 24;
        this.useSound = 25;
        this.useAnimation = 20;
        this.useTime = 20;
        this.rare = 5;
        this.noMelee = true;
        this.toolTip = "Summons a magical fairy";
        this.value = this.value = 250000;
        this.buffType = 27;
        this.buffTime = 18000;
      }
      else if (this.type == 426)
      {
        this.name = "Breaker Blade";
        this.useStyle = 1;
        this.useAnimation = 30;
        this.knockBack = 8f;
        this.width = 60;
        this.height = 70;
        this.damage = 39;
        this.scale = 1.05f;
        this.useSound = 1;
        this.rare = 4;
        this.value = 150000;
        this.melee = true;
      }
      else if (this.type == 427)
      {
        this.noWet = true;
        this.name = "Blue Torch";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.holdStyle = 1;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 4;
        this.placeStyle = 1;
        this.width = 10;
        this.height = 12;
        this.value = 200;
      }
      else if (this.type == 428)
      {
        this.noWet = true;
        this.name = "Red Torch";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.holdStyle = 1;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 4;
        this.placeStyle = 2;
        this.width = 10;
        this.height = 12;
        this.value = 200;
      }
      else if (this.type == 429)
      {
        this.noWet = true;
        this.name = "Green Torch";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.holdStyle = 1;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 4;
        this.placeStyle = 3;
        this.width = 10;
        this.height = 12;
        this.value = 200;
      }
      else if (this.type == 430)
      {
        this.noWet = true;
        this.name = "Purple Torch";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.holdStyle = 1;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 4;
        this.placeStyle = 4;
        this.width = 10;
        this.height = 12;
        this.value = 200;
      }
      else if (this.type == 431)
      {
        this.noWet = true;
        this.name = "White Torch";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.holdStyle = 1;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 4;
        this.placeStyle = 5;
        this.width = 10;
        this.height = 12;
        this.value = 500;
      }
      else if (this.type == 432)
      {
        this.noWet = true;
        this.name = "Yellow Torch";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.holdStyle = 1;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 4;
        this.placeStyle = 6;
        this.width = 10;
        this.height = 12;
        this.value = 200;
      }
      else if (this.type == 433)
      {
        this.noWet = true;
        this.name = "Demon Torch";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.holdStyle = 1;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 4;
        this.placeStyle = 7;
        this.width = 10;
        this.height = 12;
        this.value = 300;
      }
      else if (this.type == 434)
      {
        this.autoReuse = true;
        this.useStyle = 5;
        this.useAnimation = 12;
        this.useTime = 4;
        this.reuseDelay = 14;
        this.name = "Clockwork Assault Rifle";
        this.width = 50;
        this.height = 18;
        this.shoot = 10;
        this.useAmmo = 14;
        this.useSound = 31;
        this.damage = 19;
        this.shootSpeed = 7.75f;
        this.noMelee = true;
        this.value = 150000;
        this.rare = 4;
        this.ranged = true;
        this.toolTip = "Three round burst";
        this.toolTip2 = "Only the first shot consumes ammo";
      }
      else if (this.type == 435)
      {
        this.useStyle = 5;
        this.autoReuse = true;
        this.useAnimation = 25;
        this.useTime = 25;
        this.name = "Cobalt Repeater";
        this.width = 50;
        this.height = 18;
        this.shoot = 1;
        this.useAmmo = 1;
        this.useSound = 5;
        this.damage = 30;
        this.shootSpeed = 9f;
        this.noMelee = true;
        this.value = 60000;
        this.ranged = true;
        this.rare = 4;
        this.knockBack = 1.5f;
      }
      else if (this.type == 436)
      {
        this.useStyle = 5;
        this.autoReuse = true;
        this.useAnimation = 23;
        this.useTime = 23;
        this.name = "Mythril Repeater";
        this.width = 50;
        this.height = 18;
        this.shoot = 1;
        this.useAmmo = 1;
        this.useSound = 5;
        this.damage = 34;
        this.shootSpeed = 9.5f;
        this.noMelee = true;
        this.value = 90000;
        this.ranged = true;
        this.rare = 4;
        this.knockBack = 2f;
      }
      else if (this.type == 437)
      {
        this.noUseGraphic = true;
        this.damage = 0;
        this.knockBack = 7f;
        this.useStyle = 5;
        this.name = "Dual Hook";
        this.shootSpeed = 14f;
        this.shoot = 73;
        this.width = 18;
        this.height = 28;
        this.useSound = 1;
        this.useAnimation = 20;
        this.useTime = 20;
        this.rare = 4;
        this.noMelee = true;
        this.value = 200000;
      }
      else if (this.type == 438)
      {
        this.name = "Star Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 2;
      }
      else if (this.type == 439)
      {
        this.name = "Sword Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 3;
      }
      else if (this.type == 440)
      {
        this.name = "Slime Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 4;
      }
      else if (this.type == 441)
      {
        this.name = "Goblin Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 5;
      }
      else if (this.type == 442)
      {
        this.name = "Shield Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 6;
      }
      else if (this.type == 443)
      {
        this.name = "Bat Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 7;
      }
      else if (this.type == 444)
      {
        this.name = "Fish Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 8;
      }
      else if (this.type == 445)
      {
        this.name = "Bunny Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 9;
      }
      else if (this.type == 446)
      {
        this.name = "Skeleton Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 10;
      }
      else if (this.type == 447)
      {
        this.name = "Reaper Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 11;
      }
      else if (this.type == 448)
      {
        this.name = "Woman Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 12;
      }
      else if (this.type == 449)
      {
        this.name = "Imp Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 13;
      }
      else if (this.type == 450)
      {
        this.name = "Gargoyle Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 14;
      }
      else if (this.type == 451)
      {
        this.name = "Gloom Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 15;
      }
      else if (this.type == 452)
      {
        this.name = "Hornet Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 16;
      }
      else if (this.type == 453)
      {
        this.name = "Bomb Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 17;
      }
      else if (this.type == 454)
      {
        this.name = "Crab Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 18;
      }
      else if (this.type == 455)
      {
        this.name = "Hammer Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 19;
      }
      else if (this.type == 456)
      {
        this.name = "Potion Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 20;
      }
      else if (this.type == 457)
      {
        this.name = "Spear Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 21;
      }
      else if (this.type == 458)
      {
        this.name = "Cross Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 22;
      }
      else if (this.type == 459)
      {
        this.name = "Jellyfish Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 23;
      }
      else if (this.type == 460)
      {
        this.name = "Bow Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 24;
      }
      else if (this.type == 461)
      {
        this.name = "Boomerang Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 25;
      }
      else if (this.type == 462)
      {
        this.name = "Boot Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 26;
      }
      else if (this.type == 463)
      {
        this.name = "Chest Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 27;
      }
      else if (this.type == 464)
      {
        this.name = "Bird Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 28;
      }
      else if (this.type == 465)
      {
        this.name = "Axe Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 29;
      }
      else if (this.type == 466)
      {
        this.name = "Corrupt Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 30;
      }
      else if (this.type == 467)
      {
        this.name = "Tree Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 31;
      }
      else if (this.type == 468)
      {
        this.name = "Anvil Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 32;
      }
      else if (this.type == 469)
      {
        this.name = "Pickaxe Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 33;
      }
      else if (this.type == 470)
      {
        this.name = "Mushroom Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 34;
      }
      else if (this.type == 471)
      {
        this.name = "Eyeball Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 35;
      }
      else if (this.type == 472)
      {
        this.name = "Pillar Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 36;
      }
      else if (this.type == 473)
      {
        this.name = "Heart Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 37;
      }
      else if (this.type == 474)
      {
        this.name = "Pot Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 38;
      }
      else if (this.type == 475)
      {
        this.name = "Sunflower Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 39;
      }
      else if (this.type == 476)
      {
        this.name = "King Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 40;
      }
      else if (this.type == 477)
      {
        this.name = "Queen Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 41;
      }
      else if (this.type == 478)
      {
        this.name = "Pirahna Statue";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 105;
        this.width = 20;
        this.height = 20;
        this.value = 300;
        this.placeStyle = 42;
      }
      else if (this.type == 479)
      {
        this.name = "Planked Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 7;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 27;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 480)
      {
        this.name = "Wooden Beam";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 124;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 481)
      {
        this.useStyle = 5;
        this.autoReuse = true;
        this.useAnimation = 20;
        this.useTime = 20;
        this.name = "Adamantite Repeater";
        this.width = 50;
        this.height = 18;
        this.shoot = 1;
        this.useAmmo = 1;
        this.useSound = 5;
        this.damage = 37;
        this.shootSpeed = 10f;
        this.noMelee = true;
        this.value = 120000;
        this.ranged = true;
        this.rare = 4;
        this.knockBack = 2.5f;
      }
      else if (this.type == 482)
      {
        this.name = "Adamantite Sword";
        this.useStyle = 1;
        this.useAnimation = 27;
        this.useTime = 27;
        this.knockBack = 6f;
        this.width = 40;
        this.height = 40;
        this.damage = 44;
        this.scale = 1.2f;
        this.useSound = 1;
        this.rare = 4;
        this.value = 138000;
        this.melee = true;
      }
      else if (this.type == 483)
      {
        this.useTurn = true;
        this.autoReuse = true;
        this.name = "Cobalt Sword";
        this.useStyle = 1;
        this.useAnimation = 23;
        this.useTime = 23;
        this.knockBack = 3.85f;
        this.width = 40;
        this.height = 40;
        this.damage = 34;
        this.scale = 1.1f;
        this.useSound = 1;
        this.rare = 4;
        this.value = 69000;
        this.melee = true;
      }
      else if (this.type == 484)
      {
        this.name = "Mythril Sword";
        this.useStyle = 1;
        this.useAnimation = 26;
        this.useTime = 26;
        this.knockBack = 6f;
        this.width = 40;
        this.height = 40;
        this.damage = 39;
        this.scale = 1.15f;
        this.useSound = 1;
        this.rare = 4;
        this.value = 103500;
        this.melee = true;
      }
      else if (this.type == 485)
      {
        this.rare = 4;
        this.name = "Moon Charm";
        this.width = 24;
        this.height = 28;
        this.accessory = true;
        this.toolTip = "Turns the holder into a werewolf on full moons";
        this.value = 150000;
      }
      else if (this.type == 486)
      {
        this.name = "Ruler";
        this.width = 10;
        this.height = 26;
        this.accessory = true;
        this.toolTip = "Creates a grid on screen for block placement";
        this.value = 10000;
        this.rare = 1;
      }
      else if (this.type == 487)
      {
        this.name = "Crystal Ball";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 125;
        this.width = 22;
        this.height = 22;
        this.value = 100000;
        this.rare = 3;
      }
      else if (this.type == 488)
      {
        this.name = "Disco Ball";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 126;
        this.width = 22;
        this.height = 26;
        this.value = 10000;
      }
      else if (this.type == 489)
      {
        this.name = "Sorcerer Emblem";
        this.width = 24;
        this.height = 24;
        this.accessory = true;
        this.toolTip = "15% increased magic damage";
        this.value = 100000;
        this.rare = 4;
      }
      else if (this.type == 491)
      {
        this.name = "Ranger Emblem";
        this.width = 24;
        this.height = 24;
        this.accessory = true;
        this.toolTip = "15% increased ranged damage";
        this.value = 100000;
      }
      else if (this.type == 490)
      {
        this.name = "Warrior Emblem";
        this.width = 24;
        this.height = 24;
        this.accessory = true;
        this.toolTip = "15% increased melee damage";
        this.value = 100000;
        this.rare = 4;
      }
      else if (this.type == 492)
      {
        this.name = "Demon Wings";
        this.width = 24;
        this.height = 8;
        this.accessory = true;
        this.toolTip = "Allows flight and slow fall";
        this.value = 400000;
        this.rare = 5;
      }
      else if (this.type == 493)
      {
        this.name = "Angel Wings";
        this.width = 24;
        this.height = 8;
        this.accessory = true;
        this.toolTip = "Allows flight and slow fall";
        this.value = 400000;
        this.rare = 5;
      }
      else if (this.type == 494)
      {
        this.rare = 5;
        this.useStyle = 5;
        this.useAnimation = 12;
        this.useTime = 12;
        this.name = "Magical Harp";
        this.width = 12;
        this.height = 28;
        this.shoot = 76;
        this.holdStyle = 3;
        this.autoReuse = true;
        this.damage = 30;
        this.shootSpeed = 4.5f;
        this.noMelee = true;
        this.value = 200000;
        this.mana = 4;
        this.magic = true;
      }
      else if (this.type == 495)
      {
        this.rare = 5;
        this.mana = 10;
        this.channel = true;
        this.damage = 53;
        this.useStyle = 1;
        this.name = "Rainbow Rod";
        this.shootSpeed = 6f;
        this.shoot = 79;
        this.width = 26;
        this.height = 28;
        this.useSound = 28;
        this.useAnimation = 15;
        this.useTime = 15;
        this.noMelee = true;
        this.knockBack = 5f;
        this.toolTip = "Casts a controllable rainbow";
        this.value = 200000;
        this.magic = true;
      }
      else if (this.type == 496)
      {
        this.rare = 4;
        this.mana = 7;
        this.damage = 26;
        this.useStyle = 1;
        this.name = "Ice Rod";
        this.shootSpeed = 12f;
        this.shoot = 80;
        this.width = 26;
        this.height = 28;
        this.useSound = 28;
        this.useAnimation = 17;
        this.useTime = 17;
        this.rare = 4;
        this.autoReuse = true;
        this.noMelee = true;
        this.knockBack = 0.0f;
        this.toolTip = "Summons a block of ice";
        this.value = 1000000;
        this.magic = true;
        this.knockBack = 2f;
      }
      else if (this.type == 497)
      {
        this.name = "Neptune's Shell";
        this.width = 24;
        this.height = 28;
        this.accessory = true;
        this.toolTip = "Transforms the holder into merfolk when entering water";
        this.value = 150000;
        this.rare = 5;
      }
      else if (this.type == 498)
      {
        this.name = "Mannequin";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 128;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 499)
      {
        this.name = "Greater Healing Potion";
        this.useSound = 3;
        this.healLife = 150;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 30;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.rare = 3;
        this.potion = true;
        this.value = 5000;
      }
      else if (this.type == 500)
      {
        this.name = "Greater Mana Potion";
        this.useSound = 3;
        this.healMana = 200;
        this.useStyle = 2;
        this.useTurn = true;
        this.useAnimation = 17;
        this.useTime = 17;
        this.maxStack = 99;
        this.consumable = true;
        this.width = 14;
        this.height = 24;
        this.rare = 3;
        this.value = 500;
      }
      else if (this.type == 501)
      {
        this.name = "Pixie Dust";
        this.width = 16;
        this.height = 14;
        this.maxStack = 99;
        this.value = 500;
        this.rare = 1;
      }
      else if (this.type == 502)
      {
        this.name = "Crystal Shard";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 129;
        this.width = 24;
        this.height = 24;
        this.value = 8000;
        this.rare = 1;
      }
      else if (this.type == 503)
      {
        this.name = "Clown Hat";
        this.width = 18;
        this.height = 18;
        this.headSlot = 40;
        this.value = 20000;
        this.vanity = true;
        this.rare = 2;
      }
      else if (this.type == 504)
      {
        this.name = "Clown Shirt";
        this.width = 18;
        this.height = 18;
        this.bodySlot = 23;
        this.value = 10000;
        this.vanity = true;
        this.rare = 2;
      }
      else if (this.type == 505)
      {
        this.name = "Clown Pants";
        this.width = 18;
        this.height = 18;
        this.legSlot = 22;
        this.value = 10000;
        this.vanity = true;
        this.rare = 2;
      }
      else if (this.type == 506)
      {
        this.useStyle = 5;
        this.autoReuse = true;
        this.useAnimation = 30;
        this.useTime = 6;
        this.name = "Flamethrower";
        this.width = 50;
        this.height = 18;
        this.shoot = 85;
        this.useAmmo = 23;
        this.useSound = 34;
        this.damage = 27;
        this.knockBack = 0.3f;
        this.shootSpeed = 7f;
        this.noMelee = true;
        this.value = 500000;
        this.rare = 5;
        this.ranged = true;
        this.toolTip = "Uses gel for ammo";
      }
      else if (this.type == 507)
      {
        this.rare = 3;
        this.useStyle = 1;
        this.useAnimation = 12;
        this.useTime = 12;
        this.name = "Bell";
        this.width = 12;
        this.height = 28;
        this.autoReuse = true;
        this.noMelee = true;
        this.value = 10000;
      }
      else if (this.type == 508)
      {
        this.rare = 3;
        this.useStyle = 5;
        this.useAnimation = 12;
        this.useTime = 12;
        this.name = "Harp";
        this.width = 12;
        this.height = 28;
        this.autoReuse = true;
        this.noMelee = true;
        this.value = 10000;
      }
      else if (this.type == 509)
      {
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.name = "Wrench";
        this.width = 24;
        this.height = 28;
        this.rare = 1;
        this.toolTip = "Places wire";
        this.value = 20000;
        this.mech = true;
      }
      else if (this.type == 510)
      {
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.name = "Wire Cutter";
        this.width = 24;
        this.height = 28;
        this.rare = 1;
        this.toolTip = "Removes wire";
        this.value = 20000;
        this.mech = true;
      }
      else if (this.type == 511)
      {
        this.name = "Active Stone Block";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 130;
        this.width = 12;
        this.height = 12;
        this.value = 1000;
        this.mech = true;
      }
      else if (this.type == 512)
      {
        this.name = "Inactive Stone Block";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 131;
        this.width = 12;
        this.height = 12;
        this.value = 1000;
        this.mech = true;
      }
      else if (this.type == 513)
      {
        this.name = "Lever";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 132;
        this.width = 24;
        this.height = 24;
        this.value = 3000;
        this.mech = true;
      }
      else if (this.type == 514)
      {
        this.autoReuse = true;
        this.useStyle = 5;
        this.useAnimation = 12;
        this.useTime = 12;
        this.name = "Laser Rifle";
        this.width = 36;
        this.height = 22;
        this.shoot = 88;
        this.mana = 8;
        this.useSound = 12;
        this.knockBack = 2.5f;
        this.damage = 29;
        this.shootSpeed = 17f;
        this.noMelee = true;
        this.rare = 4;
        this.magic = true;
        this.value = 500000;
      }
      else if (this.type == 515)
      {
        this.name = "Crystal Bullet";
        this.shootSpeed = 5f;
        this.shoot = 89;
        this.damage = 9;
        this.width = 8;
        this.height = 8;
        this.maxStack = 250;
        this.consumable = true;
        this.ammo = 14;
        this.knockBack = 1f;
        this.value = 30;
        this.ranged = true;
        this.rare = 3;
        this.toolTip = "Creates several crystal shards on impact";
      }
      else if (this.type == 516)
      {
        this.name = "Holy Arrow";
        this.shootSpeed = 3.5f;
        this.shoot = 91;
        this.damage = 6;
        this.width = 10;
        this.height = 28;
        this.maxStack = 250;
        this.consumable = true;
        this.ammo = 1;
        this.knockBack = 2f;
        this.value = 80;
        this.ranged = true;
        this.rare = 3;
        this.toolTip = "Summons falling stars on impact";
      }
      else if (this.type == 517)
      {
        this.useStyle = 1;
        this.name = "Magic Dagger";
        this.shootSpeed = 10f;
        this.shoot = 93;
        this.damage = 28;
        this.width = 18;
        this.height = 20;
        this.mana = 7;
        this.useSound = 1;
        this.useAnimation = 15;
        this.useTime = 15;
        this.noUseGraphic = true;
        this.noMelee = true;
        this.value = 1000000;
        this.knockBack = 2f;
        this.magic = true;
        this.rare = 4;
        this.toolTip = "A magical returning dagger";
      }
      else if (this.type == 518)
      {
        this.autoReuse = true;
        this.rare = 4;
        this.mana = 5;
        this.useSound = 9;
        this.name = "Crystal Storm";
        this.useStyle = 5;
        this.damage = 26;
        this.useAnimation = 7;
        this.useTime = 7;
        this.width = 24;
        this.height = 28;
        this.shoot = 94;
        this.scale = 0.9f;
        this.shootSpeed = 16f;
        this.knockBack = 5f;
        this.toolTip = "Summons rapid fire crystal shards";
        this.magic = true;
        this.value = 500000;
      }
      else if (this.type == 519)
      {
        this.autoReuse = true;
        this.rare = 4;
        this.mana = 14;
        this.useSound = 20;
        this.name = "Cursed Flames";
        this.useStyle = 5;
        this.damage = 35;
        this.useAnimation = 20;
        this.useTime = 20;
        this.width = 24;
        this.height = 28;
        this.shoot = 95;
        this.scale = 0.9f;
        this.shootSpeed = 10f;
        this.knockBack = 6.5f;
        this.toolTip = "Summons unholy fire balls";
        this.magic = true;
        this.value = 500000;
      }
      else if (this.type == 520)
      {
        this.name = "Soul of Light";
        this.width = 18;
        this.height = 18;
        this.maxStack = 250;
        this.value = 1000;
        this.rare = 3;
        this.toolTip = "'The essence of light creatures'";
      }
      else if (this.type == 521)
      {
        this.name = "Soul of Night";
        this.width = 18;
        this.height = 18;
        this.maxStack = 250;
        this.value = 1000;
        this.rare = 3;
        this.toolTip = "'The essence of dark creatures'";
      }
      else if (this.type == 522)
      {
        this.name = "Cursed Flame";
        this.width = 12;
        this.height = 14;
        this.maxStack = 99;
        this.value = 4000;
        this.rare = 3;
        this.toolTip = "'Not even water can put the flame out'";
      }
      else if (this.type == 523)
      {
        this.name = "Cursed Torch";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.holdStyle = 1;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 4;
        this.placeStyle = 8;
        this.width = 10;
        this.height = 12;
        this.value = 300;
        this.rare = 1;
        this.toolTip = "Can be placed in water";
      }
      else if (this.type == 524)
      {
        this.name = "Adamantite Forge";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 133;
        this.width = 44;
        this.height = 30;
        this.value = 50000;
        this.toolTip = "Used to smelt adamantite ore";
        this.rare = 3;
      }
      else if (this.type == 525)
      {
        this.name = "Mythril Anvil";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 134;
        this.width = 28;
        this.height = 14;
        this.value = 25000;
        this.toolTip = "Used to craft items from mythril and adamantite bars";
        this.rare = 3;
      }
      else if (this.type == 526)
      {
        this.name = "Unicorn Horn";
        this.width = 14;
        this.height = 14;
        this.maxStack = 99;
        this.value = 15000;
        this.rare = 1;
        this.toolTip = "'Sharp and magical!'";
      }
      else if (this.type == 527)
      {
        this.name = "Dark Shard";
        this.width = 14;
        this.height = 14;
        this.maxStack = 99;
        this.value = 4500;
        this.rare = 2;
        this.toolTip = "'Sometimes carried by creatures in corrupt deserts'";
      }
      else if (this.type == 528)
      {
        this.name = "Light Shard";
        this.width = 14;
        this.height = 14;
        this.maxStack = 99;
        this.value = 4500;
        this.rare = 2;
        this.toolTip = "'Sometimes carried by creatures in light deserts'";
      }
      else if (this.type == 529)
      {
        this.name = "Red Pressure Plate";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 135;
        this.width = 12;
        this.height = 12;
        this.placeStyle = 0;
        this.mech = true;
        this.value = 5000;
        this.mech = true;
        this.toolTip = "Activates when stepped on";
      }
      else if (this.type == 530)
      {
        this.name = "Wire";
        this.width = 12;
        this.height = 18;
        this.maxStack = 250;
        this.value = 500;
        this.mech = true;
      }
      else if (this.type == 531)
      {
        this.name = "Spell Tome";
        this.width = 12;
        this.height = 18;
        this.maxStack = 99;
        this.value = 50000;
        this.rare = 1;
        this.toolTip = "Can be enchanted";
      }
      else if (this.type == 532)
      {
        this.name = "Star Cloak";
        this.width = 20;
        this.height = 24;
        this.value = 100000;
        this.toolTip = "Causes stars to fall when injured";
        this.accessory = true;
        this.rare = 4;
      }
      else if (this.type == 533)
      {
        this.useStyle = 5;
        this.autoReuse = true;
        this.useAnimation = 7;
        this.useTime = 7;
        this.name = "Megashark";
        this.width = 50;
        this.height = 18;
        this.shoot = 10;
        this.useAmmo = 14;
        this.useSound = 11;
        this.damage = 23;
        this.shootSpeed = 10f;
        this.noMelee = true;
        this.value = 300000;
        this.rare = 5;
        this.toolTip = "50% chance to not consume ammo";
        this.toolTip2 = "'Minishark's older brother'";
        this.knockBack = 1f;
        this.ranged = true;
      }
      else if (this.type == 534)
      {
        this.knockBack = 6.5f;
        this.useStyle = 5;
        this.useAnimation = 45;
        this.useTime = 45;
        this.name = "Shotgun";
        this.width = 50;
        this.height = 14;
        this.shoot = 10;
        this.useAmmo = 14;
        this.useSound = 36;
        this.damage = 18;
        this.shootSpeed = 6f;
        this.noMelee = true;
        this.value = 700000;
        this.rare = 4;
        this.ranged = true;
        this.toolTip = "Fires a spread of bullets";
      }
      else if (this.type == 535)
      {
        this.name = "Philosopher's Stone";
        this.width = 12;
        this.height = 18;
        this.value = 100000;
        this.toolTip = "Reduces the cooldown of healing potions";
        this.accessory = true;
        this.rare = 4;
      }
      else if (this.type == 536)
      {
        this.name = "Titan Glove";
        this.width = 12;
        this.height = 18;
        this.value = 100000;
        this.toolTip = "Increases melee knockback";
        this.rare = 4;
        this.accessory = true;
      }
      else if (this.type == 537)
      {
        this.name = "Cobalt Naginata";
        this.useStyle = 5;
        this.useAnimation = 28;
        this.useTime = 28;
        this.shootSpeed = 4.3f;
        this.knockBack = 4f;
        this.width = 40;
        this.height = 40;
        this.damage = 29;
        this.scale = 1.1f;
        this.useSound = 1;
        this.shoot = 97;
        this.rare = 4;
        this.value = 45000;
        this.noMelee = true;
        this.noUseGraphic = true;
        this.melee = true;
      }
      else if (this.type == 538)
      {
        this.name = "Switch";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 136;
        this.width = 12;
        this.height = 12;
        this.value = 2000;
        this.mech = true;
      }
      else if (this.type == 539)
      {
        this.name = "Dart Trap";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 137;
        this.width = 12;
        this.height = 12;
        this.value = 10000;
        this.mech = true;
      }
      else if (this.type == 540)
      {
        this.name = "Boulder";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 138;
        this.width = 12;
        this.height = 12;
        this.mech = true;
      }
      else if (this.type == 541)
      {
        this.name = "Green Pressure Plate";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 135;
        this.width = 12;
        this.height = 12;
        this.placeStyle = 1;
        this.mech = true;
        this.value = 5000;
        this.toolTip = "Activates when stepped on";
      }
      else if (this.type == 542)
      {
        this.name = "Gray Pressure Plate";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 135;
        this.width = 12;
        this.height = 12;
        this.placeStyle = 2;
        this.mech = true;
        this.value = 5000;
        this.toolTip = "Activates when stepped on";
      }
      else if (this.type == 543)
      {
        this.name = "Brown Pressure Plate";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 135;
        this.width = 12;
        this.height = 12;
        this.placeStyle = 3;
        this.mech = true;
        this.value = 5000;
        this.toolTip = "Activates when stepped on";
      }
      else if (this.type == 544)
      {
        this.useStyle = 4;
        this.name = "Mechanical Eye";
        this.width = 22;
        this.height = 14;
        this.consumable = true;
        this.useAnimation = 45;
        this.useTime = 45;
        this.maxStack = 20;
        this.toolTip = "Summons The Twins";
        this.rare = 3;
      }
      else if (this.type == 545)
      {
        this.name = "Cursed Arrow";
        this.shootSpeed = 4f;
        this.shoot = 103;
        this.damage = 14;
        this.width = 10;
        this.height = 28;
        this.maxStack = 250;
        this.consumable = true;
        this.ammo = 1;
        this.knockBack = 3f;
        this.value = 80;
        this.ranged = true;
        this.rare = 3;
      }
      else if (this.type == 546)
      {
        this.name = "Cursed Bullet";
        this.shootSpeed = 5f;
        this.shoot = 104;
        this.damage = 12;
        this.width = 8;
        this.height = 8;
        this.maxStack = 250;
        this.consumable = true;
        this.ammo = 14;
        this.knockBack = 4f;
        this.value = 30;
        this.rare = 1;
        this.ranged = true;
        this.rare = 3;
      }
      else if (this.type == 547)
      {
        this.name = "Soul of Fright";
        this.width = 18;
        this.height = 18;
        this.maxStack = 250;
        this.value = 100000;
        this.rare = 5;
        this.toolTip = "'The essence of pure terror'";
      }
      else if (this.type == 548)
      {
        this.name = "Soul of Might";
        this.width = 18;
        this.height = 18;
        this.maxStack = 250;
        this.value = 100000;
        this.rare = 5;
        this.toolTip = "'The essence of the destroyer'";
      }
      else if (this.type == 549)
      {
        this.name = "Soul of Sight";
        this.width = 18;
        this.height = 18;
        this.maxStack = 250;
        this.value = 100000;
        this.rare = 5;
        this.toolTip = "'The essence of omniscient watchers'";
      }
      else if (this.type == 550)
      {
        this.name = "Gungnir";
        this.useStyle = 5;
        this.useAnimation = 22;
        this.useTime = 22;
        this.shootSpeed = 5.6f;
        this.knockBack = 6.4f;
        this.width = 40;
        this.height = 40;
        this.damage = 42;
        this.scale = 1.1f;
        this.useSound = 1;
        this.shoot = 105;
        this.rare = 5;
        this.value = 1500000;
        this.noMelee = true;
        this.noUseGraphic = true;
        this.melee = true;
      }
      else if (this.type == 551)
      {
        this.name = "Hallowed Plate Mail";
        this.width = 18;
        this.height = 18;
        this.defense = 15;
        this.bodySlot = 24;
        this.rare = 5;
        this.value = 200000;
        this.toolTip = "7% increased critical strike chance";
      }
      else if (this.type == 552)
      {
        this.name = "Hallowed Greaves";
        this.width = 18;
        this.height = 18;
        this.defense = 11;
        this.legSlot = 23;
        this.rare = 5;
        this.value = 150000;
        this.toolTip = "7% increased damage";
        this.toolTip2 = "8% increased movement speed";
      }
      else if (this.type == 553)
      {
        this.name = "Hallowed Helmet";
        this.width = 18;
        this.height = 18;
        this.defense = 9;
        this.headSlot = 41;
        this.rare = 5;
        this.value = 250000;
        this.toolTip = "15% increased ranged damage";
        this.toolTip2 = "8% increased ranged critical strike chance";
      }
      else if (this.type == 558)
      {
        this.name = "Hallowed Headgear";
        this.width = 18;
        this.height = 18;
        this.defense = 5;
        this.headSlot = 42;
        this.rare = 5;
        this.value = 250000;
        this.toolTip = "Increases maximum mana by 100";
        this.toolTip2 = "12% increased magic damage and critical strike chance";
      }
      else if (this.type == 559)
      {
        this.name = "Hallowed Mask";
        this.width = 18;
        this.height = 18;
        this.defense = 24;
        this.headSlot = 43;
        this.rare = 5;
        this.value = 250000;
        this.toolTip = "10% increased melee damage and critical strike chance";
        this.toolTip2 = "10% increased melee haste";
      }
      else if (this.type == 554)
      {
        this.name = "Cross Necklace";
        this.width = 20;
        this.height = 24;
        this.value = 1500;
        this.toolTip = "Increases length of invincibility after taking damage";
        this.accessory = true;
        this.rare = 4;
      }
      else if (this.type == 555)
      {
        this.name = "Mana Flower";
        this.width = 20;
        this.height = 24;
        this.value = 50000;
        this.toolTip = "8% reduced mana usage";
        this.toolTip2 = "Automatically use mana potions when needed";
        this.accessory = true;
        this.rare = 4;
      }
      else if (this.type == 556)
      {
        this.useStyle = 4;
        this.name = "Mechanical Worm";
        this.width = 22;
        this.height = 14;
        this.consumable = true;
        this.useAnimation = 45;
        this.useTime = 45;
        this.maxStack = 20;
        this.toolTip = "Summons Destroyer";
        this.rare = 3;
      }
      else if (this.type == 557)
      {
        this.useStyle = 4;
        this.name = "Mechanical Skull";
        this.width = 22;
        this.height = 14;
        this.consumable = true;
        this.useAnimation = 45;
        this.useTime = 45;
        this.maxStack = 20;
        this.toolTip = "Summons Skeletron Prime";
        this.rare = 3;
      }
      else if (this.type == 560)
      {
        this.useStyle = 4;
        this.name = "Slime Crown";
        this.width = 22;
        this.height = 14;
        this.consumable = true;
        this.useAnimation = 45;
        this.useTime = 45;
        this.maxStack = 20;
        this.toolTip = "Summons King Slime";
        this.rare = 1;
      }
      else if (this.type == 561)
      {
        this.melee = true;
        this.autoReuse = true;
        this.noMelee = true;
        this.useStyle = 1;
        this.name = "Light Disc";
        this.shootSpeed = 13f;
        this.shoot = 106;
        this.damage = 35;
        this.knockBack = 8f;
        this.width = 24;
        this.height = 24;
        this.useSound = 1;
        this.useAnimation = 15;
        this.useTime = 15;
        this.noUseGraphic = true;
        this.rare = 5;
        this.maxStack = 5;
        this.value = 500000;
        this.toolTip = "Stacks up to 5";
      }
      else if (this.type == 562)
      {
        this.name = "Music Box (Overworld Day)";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.consumable = true;
        this.createTile = 139;
        this.placeStyle = 0;
        this.width = 24;
        this.height = 24;
        this.rare = 4;
        this.value = 100000;
        this.accessory = true;
      }
      else if (this.type == 563)
      {
        this.name = "Music Box (Eerie)";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.consumable = true;
        this.createTile = 139;
        this.placeStyle = 1;
        this.width = 24;
        this.height = 24;
        this.rare = 4;
        this.value = 100000;
        this.accessory = true;
      }
      else if (this.type == 564)
      {
        this.name = "Music Box (Night)";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.consumable = true;
        this.createTile = 139;
        this.placeStyle = 2;
        this.width = 24;
        this.height = 24;
        this.rare = 4;
        this.value = 100000;
        this.accessory = true;
      }
      else if (this.type == 565)
      {
        this.name = "Music Box (Title)";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.consumable = true;
        this.createTile = 139;
        this.placeStyle = 3;
        this.width = 24;
        this.height = 24;
        this.rare = 4;
        this.value = 100000;
        this.accessory = true;
      }
      else if (this.type == 566)
      {
        this.name = "Music Box (Underground)";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.consumable = true;
        this.createTile = 139;
        this.placeStyle = 4;
        this.width = 24;
        this.height = 24;
        this.rare = 4;
        this.value = 100000;
        this.accessory = true;
      }
      else if (this.type == 567)
      {
        this.name = "Music Box (Boss 1)";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.consumable = true;
        this.createTile = 139;
        this.placeStyle = 5;
        this.width = 24;
        this.height = 24;
        this.rare = 4;
        this.value = 100000;
        this.accessory = true;
      }
      else if (this.type == 568)
      {
        this.name = "Music Box (Jungle)";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.consumable = true;
        this.createTile = 139;
        this.placeStyle = 6;
        this.width = 24;
        this.height = 24;
        this.rare = 4;
        this.value = 100000;
        this.accessory = true;
      }
      else if (this.type == 569)
      {
        this.name = "Music Box (Corruption)";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.consumable = true;
        this.createTile = 139;
        this.placeStyle = 7;
        this.width = 24;
        this.height = 24;
        this.rare = 4;
        this.value = 100000;
        this.accessory = true;
      }
      else if (this.type == 570)
      {
        this.name = "Music Box (Underground Corruption)";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.consumable = true;
        this.createTile = 139;
        this.placeStyle = 8;
        this.width = 24;
        this.height = 24;
        this.rare = 4;
        this.value = 100000;
        this.accessory = true;
      }
      else if (this.type == 571)
      {
        this.name = "Music Box (The Hallow)";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.consumable = true;
        this.createTile = 139;
        this.placeStyle = 9;
        this.width = 24;
        this.height = 24;
        this.rare = 4;
        this.value = 100000;
        this.accessory = true;
      }
      else if (this.type == 572)
      {
        this.name = "Music Box (Boss 2)";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.consumable = true;
        this.createTile = 139;
        this.placeStyle = 10;
        this.width = 24;
        this.height = 24;
        this.rare = 4;
        this.value = 100000;
        this.accessory = true;
      }
      else if (this.type == 573)
      {
        this.name = "Music Box (Underground Hallow)";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.consumable = true;
        this.createTile = 139;
        this.placeStyle = 11;
        this.width = 24;
        this.height = 24;
        this.rare = 4;
        this.value = 100000;
        this.accessory = true;
      }
      else if (this.type == 574)
      {
        this.name = "Music Box (Boss 3)";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.consumable = true;
        this.createTile = 139;
        this.placeStyle = 12;
        this.width = 24;
        this.height = 24;
        this.rare = 3;
        this.value = 100000;
        this.accessory = true;
      }
      else if (this.type == 575)
      {
        this.name = "Soul of Flight";
        this.width = 18;
        this.height = 18;
        this.maxStack = 250;
        this.value = 1000;
        this.rare = 3;
        this.toolTip = "'The essence of powerful flying creatures'";
      }
      else if (this.type == 576)
      {
        this.name = "Music Box";
        this.width = 24;
        this.height = 24;
        this.rare = 3;
        this.toolTip = "Has a chance to record songs";
        this.value = 100000;
        this.accessory = true;
      }
      else if (this.type == 577)
      {
        this.name = "Demonite Brick";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 140;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 578)
      {
        this.useStyle = 5;
        this.autoReuse = true;
        this.useAnimation = 19;
        this.useTime = 19;
        this.name = "Hallowed Repeater";
        this.width = 50;
        this.height = 18;
        this.shoot = 1;
        this.useAmmo = 1;
        this.useSound = 5;
        this.damage = 39;
        this.shootSpeed = 11f;
        this.noMelee = true;
        this.value = 200000;
        this.ranged = true;
        this.rare = 4;
        this.knockBack = 2.5f;
      }
      else if (this.type == 579)
      {
        this.name = "Hamdrax";
        this.useStyle = 5;
        this.useAnimation = 25;
        this.useTime = 7;
        this.shootSpeed = 36f;
        this.knockBack = 4.75f;
        this.width = 20;
        this.height = 12;
        this.damage = 35;
        this.pick = 200;
        this.axe = 22;
        this.hammer = 85;
        this.useSound = 23;
        this.shoot = 107;
        this.rare = 4;
        this.value = 220000;
        this.noMelee = true;
        this.noUseGraphic = true;
        this.melee = true;
        this.channel = true;
        this.toolTip = "'Not to be confused with a hamsaw'";
      }
      else if (this.type == 580)
      {
        this.mech = true;
        this.name = "Explosives";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 141;
        this.width = 12;
        this.height = 12;
        this.toolTip = "Explodes when activated";
      }
      else if (this.type == 581)
      {
        this.mech = true;
        this.name = "Inlet Pump";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 142;
        this.width = 12;
        this.height = 12;
        this.toolTip = "Sends water to outlet pumps";
      }
      else if (this.type == 582)
      {
        this.mech = true;
        this.name = "Outlet Pump";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 143;
        this.width = 12;
        this.height = 12;
        this.toolTip = "Receives water from inlet pumps";
      }
      else if (this.type == 583)
      {
        this.mech = true;
        this.noWet = true;
        this.name = "1 Second Timer";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 144;
        this.placeStyle = 0;
        this.width = 10;
        this.height = 12;
        this.value = 50;
        this.toolTip = "Activates every second";
      }
      else if (this.type == 584)
      {
        this.mech = true;
        this.noWet = true;
        this.name = "3 Second Timer";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 144;
        this.placeStyle = 1;
        this.width = 10;
        this.height = 12;
        this.value = 50;
        this.toolTip = "Activates every 3 seconds";
      }
      else if (this.type == 585)
      {
        this.mech = true;
        this.noWet = true;
        this.name = "5 Second Timer";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 99;
        this.consumable = true;
        this.createTile = 144;
        this.placeStyle = 2;
        this.width = 10;
        this.height = 12;
        this.value = 50;
        this.toolTip = "Activates every 5 seconds";
      }
      else if (this.type == 586)
      {
        this.name = "Candy Cane Block";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 145;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 587)
      {
        this.name = "Candy Cane Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 29;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 588)
      {
        this.name = "Santa Hat";
        this.width = 18;
        this.height = 12;
        this.headSlot = 44;
        this.value = 150000;
        this.vanity = true;
      }
      else if (this.type == 589)
      {
        this.name = "Santa Shirt";
        this.width = 18;
        this.height = 18;
        this.bodySlot = 25;
        this.value = 150000;
        this.vanity = true;
      }
      else if (this.type == 590)
      {
        this.name = "Santa Pants";
        this.width = 18;
        this.height = 18;
        this.legSlot = 24;
        this.value = 150000;
        this.vanity = true;
      }
      else if (this.type == 591)
      {
        this.name = "Green Candy Cane Block";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 146;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 592)
      {
        this.name = "Green Candy Cane Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 30;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 593)
      {
        this.name = "Snow Block";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 147;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 594)
      {
        this.name = "Snow Brick";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 148;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 595)
      {
        this.name = "Snow Brick Wall";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createWall = 31;
        this.width = 12;
        this.height = 12;
      }
      else if (this.type == 596)
      {
        this.name = "Blue Light";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 149;
        this.placeStyle = 0;
        this.width = 12;
        this.height = 12;
        this.value = 500;
      }
      else if (this.type == 597)
      {
        this.name = "Red Light";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 149;
        this.placeStyle = 1;
        this.width = 12;
        this.height = 12;
        this.value = 500;
      }
      else if (this.type == 598)
      {
        this.name = "Green Light";
        this.useStyle = 1;
        this.useTurn = true;
        this.useAnimation = 15;
        this.useTime = 10;
        this.autoReuse = true;
        this.maxStack = 250;
        this.consumable = true;
        this.createTile = 149;
        this.placeStyle = 2;
        this.width = 12;
        this.height = 12;
        this.value = 500;
      }
      else if (this.type == 599)
      {
        this.name = "Blue Present";
        this.width = 12;
        this.height = 12;
        this.rare = 1;
        this.toolTip = "Right click to open";
      }
      else if (this.type == 600)
      {
        this.name = "Green Present";
        this.width = 12;
        this.height = 12;
        this.rare = 1;
        this.toolTip = "Right click to open";
      }
      else if (this.type == 601)
      {
        this.name = "Yellow Present";
        this.width = 12;
        this.height = 12;
        this.rare = 1;
        this.toolTip = "Right click to open";
      }
      else if (this.type == 602)
      {
        this.name = "Snow Globe";
        this.useStyle = 4;
        this.consumable = true;
        this.useAnimation = 45;
        this.useTime = 45;
        this.width = 28;
        this.height = 28;
        this.toolTip = "Summons the Frost Legion";
        this.rare = 2;
      }
      else if (this.type == 603)
      {
        this.damage = 0;
        this.useStyle = 1;
        this.name = "Carrot";
        this.shoot = 111;
        this.width = 16;
        this.height = 30;
        this.useSound = 2;
        this.useAnimation = 20;
        this.useTime = 20;
        this.rare = 3;
        this.noMelee = true;
        this.toolTip = "Summons a pet bunny";
        this.value = 0;
        this.buffType = 40;
      }
      this.netID = this.type;
      if (!noMatCheck)
        this.checkMat();
      this.name = Lang.itemName(this.netID);
      this.CheckTip();
    }

    public static string VersionName(string oldName, int release)
    {
      string str = oldName;
      if (release <= 4)
      {
        if (oldName == "Cobalt Helmet")
          str = "Jungle Hat";
        else if (oldName == "Cobalt Breastplate")
          str = "Jungle Shirt";
        else if (oldName == "Cobalt Greaves")
          str = "Jungle Pants";
      }
      if (release <= 13 && oldName == "Jungle Rose")
        str = "Jungle Spores";
      if (release <= 20)
      {
        if (oldName == "Gills potion")
          str = "Gills Potion";
        else if (oldName == "Thorn Chakrum")
          str = "Thorn Chakram";
        else if (oldName == "Ball 'O Hurt")
          str = "Ball O' Hurt";
      }
      return str;
    }

    public Color GetAlpha(Color newColor)
    {
      if (this.type == 75)
        return new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) newColor.A - this.alpha);
      if (this.type == 121 || this.type == 122 || this.type == 217 || this.type == 218 || this.type == 219 || this.type == 220 || this.type == 120 || this.type == 119)
        return new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      if (this.type == 501)
        return new Color(200, 200, 200, 50);
      if (this.type == 520 || this.type == 521 || this.type == 522 || this.type == 547 || this.type == 548 || this.type == 549 || this.type == 575)
        return new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 50);
      if (this.type == 58 || this.type == 184)
        return new Color(200, 200, 200, 2000);
      float num = (float) ((int) byte.MaxValue - this.alpha) / (float) byte.MaxValue;
      int r = (int) ((double) newColor.R * (double) num);
      int g = (int) ((double) newColor.G * (double) num);
      int b = (int) ((double) newColor.B * (double) num);
      int a = (int) newColor.A - this.alpha;
      if (a < 0)
        a = 0;
      if (a > (int) byte.MaxValue)
        a = (int) byte.MaxValue;
      return this.type >= 198 && this.type <= 203 ? Color.White : new Color(r, g, b, a);
    }

    public Color GetColor(Color newColor)
    {
      int r = (int) this.color.R - ((int) byte.MaxValue - (int) newColor.R);
      int g = (int) this.color.G - ((int) byte.MaxValue - (int) newColor.G);
      int b = (int) this.color.B - ((int) byte.MaxValue - (int) newColor.B);
      int a = (int) this.color.A - ((int) byte.MaxValue - (int) newColor.A);
      if (r < 0)
        r = 0;
      if (r > (int) byte.MaxValue)
        r = (int) byte.MaxValue;
      if (g < 0)
        g = 0;
      if (g > (int) byte.MaxValue)
        g = (int) byte.MaxValue;
      if (b < 0)
        b = 0;
      if (b > (int) byte.MaxValue)
        b = (int) byte.MaxValue;
      if (a < 0)
        a = 0;
      if (a > (int) byte.MaxValue)
        a = (int) byte.MaxValue;
      return new Color(r, g, b, a);
    }

    public static bool MechSpawn(float x, float y, int type)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      for (int index = 0; index < 200; ++index)
      {
        if (Main.item[index].active && Main.item[index].type == type)
        {
          ++num1;
          Vector2 vector2 = new Vector2(x, y);
          float num4 = Main.item[index].position.X - vector2.X;
          float num5 = Main.item[index].position.Y - vector2.Y;
          float num6 = (float) Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5);
          if ((double) num6 < 300.0)
            ++num2;
          if ((double) num6 < 800.0)
            ++num3;
        }
      }
      return num2 < 3 && num3 < 6 && num1 < 10;
    }

    public void UpdateItem(int i)
    {
      if (!this.active)
        return;
      if (Main.netMode == 0)
        this.owner = Main.myPlayer;
      float num1 = 0.1f;
      float num2 = 7f;
      int index1 = (int) ((double) this.position.X + (double) (this.width / 2)) / 16;
      int index2 = (int) ((double) this.position.Y + (double) (this.height / 2)) / 16;
      if (Main.tile[index1, index2] == null)
      {
        num1 = 0.0f;
        this.velocity.X = 0.0f;
        this.velocity.Y = 0.0f;
      }
      if (this.wet)
      {
        num2 = 5f;
        num1 = 0.08f;
      }
      Vector2 vector2 = this.velocity * 0.5f;
      if (this.ownTime > 0)
        --this.ownTime;
      else
        this.ownIgnore = -1;
      if (this.keepTime > 0)
        --this.keepTime;
      if (!this.beingGrabbed)
      {
        if (this.type == 520 || this.type == 521 || this.type == 547 || this.type == 548 || this.type == 549 || this.type == 575)
        {
          this.velocity.X *= 0.95f;
          if ((double) this.velocity.X < 0.1 && (double) this.velocity.X > -0.1)
            this.velocity.X = 0.0f;
          this.velocity.Y *= 0.95f;
          if ((double) this.velocity.Y < 0.1 && (double) this.velocity.Y > -0.1)
            this.velocity.Y = 0.0f;
        }
        else
        {
          this.velocity.Y += num1;
          if ((double) this.velocity.Y > (double) num2)
            this.velocity.Y = num2;
          this.velocity.X *= 0.95f;
          if ((double) this.velocity.X < 0.1 && (double) this.velocity.X > -0.1)
            this.velocity.X = 0.0f;
        }
        bool flag = Collision.LavaCollision(this.position, this.width, this.height);
        if (flag)
          this.lavaWet = true;
        if (Collision.WetCollision(this.position, this.width, this.height))
        {
          if (!this.wet)
          {
            if (this.wetCount == (byte) 0)
            {
              this.wetCount = (byte) 20;
              if (!flag)
              {
                for (int index3 = 0; index3 < 10; ++index3)
                {
                  int index4 = Dust.NewDust(new Vector2(this.position.X - 6f, (float) ((double) this.position.Y + (double) (this.height / 2) - 8.0)), this.width + 12, 24, 33);
                  Main.dust[index4].velocity.Y -= 4f;
                  Main.dust[index4].velocity.X *= 2.5f;
                  Main.dust[index4].scale = 1.3f;
                  Main.dust[index4].alpha = 100;
                  Main.dust[index4].noGravity = true;
                }
                Main.PlaySound(19, (int) this.position.X, (int) this.position.Y);
              }
              else
              {
                for (int index5 = 0; index5 < 5; ++index5)
                {
                  int index6 = Dust.NewDust(new Vector2(this.position.X - 6f, (float) ((double) this.position.Y + (double) (this.height / 2) - 8.0)), this.width + 12, 24, 35);
                  Main.dust[index6].velocity.Y -= 1.5f;
                  Main.dust[index6].velocity.X *= 2.5f;
                  Main.dust[index6].scale = 1.3f;
                  Main.dust[index6].alpha = 100;
                  Main.dust[index6].noGravity = true;
                }
                Main.PlaySound(19, (int) this.position.X, (int) this.position.Y);
              }
            }
            this.wet = true;
          }
        }
        else if (this.wet)
          this.wet = false;
        if (!this.wet)
          this.lavaWet = false;
        if (this.wetCount > (byte) 0)
          --this.wetCount;
        if (this.wet)
        {
          if (this.wet)
          {
            Vector2 velocity = this.velocity;
            this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height);
            if ((double) this.velocity.X != (double) velocity.X)
              vector2.X = this.velocity.X;
            if ((double) this.velocity.Y != (double) velocity.Y)
              vector2.Y = this.velocity.Y;
          }
        }
        else
          this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height);
        if (this.lavaWet)
        {
          if (this.type == 267)
          {
            if (Main.netMode != 1)
            {
              this.active = false;
              this.type = 0;
              this.name = "";
              this.stack = 0;
              for (int number = 0; number < 200; ++number)
              {
                if (Main.npc[number].active && Main.npc[number].type == 22)
                {
                  if (Main.netMode == 2)
                    NetMessage.SendData(28, number: number, number2: 9999f, number3: 10f, number4: ((float) -Main.npc[number].direction));
                  Main.npc[number].StrikeNPC(9999, 10f, -Main.npc[number].direction);
                  NPC.SpawnWOF(this.position);
                }
              }
              NetMessage.SendData(21, number: i);
            }
          }
          else if (this.owner == Main.myPlayer && this.type != 312 && this.type != 318 && this.type != 173 && this.type != 174 && this.type != 175 && this.rare == 0)
          {
            this.active = false;
            this.type = 0;
            this.name = "";
            this.stack = 0;
            if (Main.netMode != 0)
              NetMessage.SendData(21, number: i);
          }
        }
        if (this.type == 520)
        {
          float num3 = (float) Main.rand.Next(90, 111) * 0.01f * Main.essScale;
          Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.5f * num3, 0.1f * num3, 0.25f * num3);
        }
        else if (this.type == 521)
        {
          float num4 = (float) Main.rand.Next(90, 111) * 0.01f * Main.essScale;
          Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.25f * num4, 0.1f * num4, 0.5f * num4);
        }
        else if (this.type == 547)
        {
          float num5 = (float) Main.rand.Next(90, 111) * 0.01f * Main.essScale;
          Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.5f * num5, 0.3f * num5, 0.05f * num5);
        }
        else if (this.type == 548)
        {
          float num6 = (float) Main.rand.Next(90, 111) * 0.01f * Main.essScale;
          Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.1f * num6, 0.1f * num6, 0.6f * num6);
        }
        else if (this.type == 575)
        {
          float num7 = (float) Main.rand.Next(90, 111) * 0.01f * Main.essScale;
          Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.1f * num7, 0.3f * num7, 0.5f * num7);
        }
        else if (this.type == 549)
        {
          float num8 = (float) Main.rand.Next(90, 111) * 0.01f * Main.essScale;
          Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.1f * num8, 0.5f * num8, 0.2f * num8);
        }
        else if (this.type == 58)
        {
          float num9 = (float) Main.rand.Next(90, 111) * 0.01f * (Main.essScale * 0.5f);
          Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.5f * num9, 0.1f * num9, 0.1f * num9);
        }
        else if (this.type == 184)
        {
          float num10 = (float) Main.rand.Next(90, 111) * 0.01f * (Main.essScale * 0.5f);
          Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.1f * num10, 0.1f * num10, 0.5f * num10);
        }
        else if (this.type == 522)
        {
          float num11 = (float) Main.rand.Next(90, 111) * 0.01f * (Main.essScale * 0.2f);
          Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.5f * num11, 1f * num11, 0.1f * num11);
        }
        if (this.type == 75 && Main.dayTime)
        {
          for (int index7 = 0; index7 < 10; ++index7)
            Dust.NewDust(this.position, this.width, this.height, 15, this.velocity.X, this.velocity.Y, 150, Scale: 1.2f);
          for (int index8 = 0; index8 < 3; ++index8)
            Gore.NewGore(this.position, new Vector2(this.velocity.X, this.velocity.Y), Main.rand.Next(16, 18));
          this.active = false;
          this.type = 0;
          this.stack = 0;
          if (Main.netMode == 2)
            NetMessage.SendData(21, number: i);
        }
      }
      else
        this.beingGrabbed = false;
      if (this.type == 501)
      {
        if (Main.rand.Next(6) == 0)
        {
          int index9 = Dust.NewDust(this.position, this.width, this.height, 55, Alpha: 200, newColor: this.color);
          Main.dust[index9].velocity *= 0.3f;
          Main.dust[index9].scale *= 0.5f;
        }
      }
      else if (this.type == 8 || this.type == 105)
      {
        if (!this.wet)
          Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 1f, 0.95f, 0.8f);
      }
      else if (this.type == 523)
        Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.85f, 1f, 0.7f);
      else if (this.type >= 427 && this.type <= 432)
      {
        if (!this.wet)
        {
          float R = 0.0f;
          float G = 0.0f;
          float B = 0.0f;
          int num12 = this.type - 426;
          if (num12 == 1)
          {
            R = 0.1f;
            G = 0.2f;
            B = 1.1f;
          }
          if (num12 == 2)
          {
            R = 1f;
            G = 0.1f;
            B = 0.1f;
          }
          if (num12 == 3)
          {
            R = 0.0f;
            G = 1f;
            B = 0.1f;
          }
          if (num12 == 4)
          {
            R = 0.9f;
            G = 0.0f;
            B = 0.9f;
          }
          if (num12 == 5)
          {
            R = 1.3f;
            G = 1.3f;
            B = 1.3f;
          }
          if (num12 == 6)
          {
            R = 0.9f;
            G = 0.9f;
            B = 0.0f;
          }
          Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), R, G, B);
        }
      }
      else if (this.type == 41)
      {
        if (!this.wet)
          Lighting.addLight((int) (((double) this.position.X + (double) this.width) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 1f, 0.75f, 0.55f);
      }
      else if (this.type == 282)
        Lighting.addLight((int) (((double) this.position.X + (double) this.width) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.7f, 1f, 0.8f);
      else if (this.type == 286)
        Lighting.addLight((int) (((double) this.position.X + (double) this.width) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.7f, 0.8f, 1f);
      else if (this.type == 331)
        Lighting.addLight((int) (((double) this.position.X + (double) this.width) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.55f, 0.75f, 0.6f);
      else if (this.type == 183)
        Lighting.addLight((int) (((double) this.position.X + (double) this.width) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.15f, 0.45f, 0.9f);
      else if (this.type == 75)
        Lighting.addLight((int) (((double) this.position.X + (double) this.width) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.8f, 0.7f, 0.1f);
      if (this.type == 75)
      {
        if (Main.rand.Next(25) == 0)
          Dust.NewDust(this.position, this.width, this.height, 58, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, Scale: 1.2f);
        if (Main.rand.Next(50) == 0)
          Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.2f, this.velocity.Y * 0.2f), Main.rand.Next(16, 18));
      }
      if (this.spawnTime < 2147483646)
        ++this.spawnTime;
      if (Main.netMode == 2 && this.owner != Main.myPlayer)
      {
        ++this.release;
        if (this.release >= 300)
        {
          this.release = 0;
          NetMessage.SendData(39, this.owner, number: i);
        }
      }
      if (this.wet)
        this.position += vector2;
      else
        this.position += this.velocity;
      if (this.noGrabDelay <= 0)
        return;
      --this.noGrabDelay;
    }

    public static int NewItem(
      int X,
      int Y,
      int Width,
      int Height,
      int Type,
      int Stack = 1,
      bool noBroadcast = false,
      int pfix = 0)
    {
      if (Main.rand == null)
        Main.rand = new Random();
      if (WorldGen.gen)
        return 0;
      int index1 = 200;
      Main.item[200] = new Item();
      if (Main.netMode != 1)
      {
        for (int index2 = 0; index2 < 200; ++index2)
        {
          if (!Main.item[index2].active)
          {
            index1 = index2;
            break;
          }
        }
      }
      if (index1 == 200 && Main.netMode != 1)
      {
        int num = 0;
        for (int index3 = 0; index3 < 200; ++index3)
        {
          if (Main.item[index3].spawnTime > num)
          {
            num = Main.item[index3].spawnTime;
            index1 = index3;
          }
        }
      }
      Main.item[index1] = new Item();
      Main.item[index1].SetDefaults(Type);
      Main.item[index1].Prefix(pfix);
      Main.item[index1].position.X = (float) (X + Width / 2 - Main.item[index1].width / 2);
      Main.item[index1].position.Y = (float) (Y + Height / 2 - Main.item[index1].height / 2);
      Main.item[index1].wet = Collision.WetCollision(Main.item[index1].position, Main.item[index1].width, Main.item[index1].height);
      Main.item[index1].velocity.X = (float) Main.rand.Next(-30, 31) * 0.1f;
      Main.item[index1].velocity.Y = (float) Main.rand.Next(-40, -15) * 0.1f;
      if (Type == 520 || Type == 521)
      {
        Main.item[index1].velocity.X = (float) Main.rand.Next(-30, 31) * 0.1f;
        Main.item[index1].velocity.Y = (float) Main.rand.Next(-30, 31) * 0.1f;
      }
      Main.item[index1].active = true;
      Main.item[index1].spawnTime = 0;
      Main.item[index1].stack = Stack;
      if (Main.netMode == 2 && !noBroadcast)
      {
        NetMessage.SendData(21, number: index1);
        Main.item[index1].FindOwner(index1);
      }
      else if (Main.netMode == 0)
        Main.item[index1].owner = Main.myPlayer;
      return index1;
    }

    public void FindOwner(int whoAmI)
    {
      if (this.keepTime > 0)
        return;
      int owner = this.owner;
      this.owner = (int) byte.MaxValue;
      float num1 = -1f;
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (this.ownIgnore != index && Main.player[index].active && Main.player[index].ItemSpace(Main.item[whoAmI]))
        {
          float num2 = Math.Abs(Main.player[index].position.X + (float) (Main.player[index].width / 2) - this.position.X - (float) (this.width / 2)) + Math.Abs(Main.player[index].position.Y + (float) (Main.player[index].height / 2) - this.position.Y - (float) this.height);
          if ((double) num2 < (double) NPC.sWidth && ((double) num1 == -1.0 || (double) num2 < (double) num1))
          {
            num1 = num2;
            this.owner = index;
          }
        }
      }
      if (this.owner == owner || (owner != Main.myPlayer || Main.netMode != 1) && (owner != (int) byte.MaxValue || Main.netMode != 2) && Main.player[owner].active)
        return;
      NetMessage.SendData(21, number: whoAmI);
      if (!this.active)
        return;
      NetMessage.SendData(22, number: whoAmI);
    }

    public object Clone() => this.MemberwiseClone();

    public bool IsTheSameAs(Item compareItem) => this.netID == compareItem.netID;

    public bool IsNotTheSameAs(Item compareItem) => this.netID != compareItem.netID || this.stack != compareItem.stack || (int) this.prefix != (int) compareItem.prefix;
  }
}
