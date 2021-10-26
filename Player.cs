// Decompiled with JetBrains decompiler
// Type: Terraria.Player
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Terraria
{
  public class Player
  {
    public const int maxBuffs = 10;
    public bool flapSound;
    public int wingTime;
    public int wings;
    public int wingFrame;
    public int wingFrameCounter;
    public bool male = true;
    public bool ghost;
    public int ghostFrame;
    public int ghostFrameCounter;
    public bool pvpDeath;
    public bool zoneDungeon;
    public bool zoneEvil;
    public bool zoneHoly;
    public bool zoneMeteor;
    public bool zoneJungle;
    public bool boneArmor;
    public float townNPCs;
    public Vector2 position;
    public Vector2 oldPosition;
    public Vector2 velocity;
    public Vector2 oldVelocity;
    public double headFrameCounter;
    public double bodyFrameCounter;
    public double legFrameCounter;
    public int netSkip;
    public int oldSelectItem;
    public bool immune;
    public int immuneTime;
    public int immuneAlphaDirection;
    public int immuneAlpha;
    public int team;
    public bool hbLocked;
    public static int nameLen = 20;
    private float maxRegenDelay;
    public string chatText = "";
    public int sign = -1;
    public int chatShowTime;
    public int reuseDelay;
    public float activeNPCs;
    public bool mouseInterface;
    public int noThrow;
    public int changeItem = -1;
    public int selectedItem;
    public Item[] armor = new Item[11];
    public int itemAnimation;
    public int itemAnimationMax;
    public int itemTime;
    public int toolTime;
    public float itemRotation;
    public int itemWidth;
    public int itemHeight;
    public Vector2 itemLocation;
    public float ghostFade;
    public float ghostDir = 1f;
    public int[] buffType = new int[10];
    public int[] buffTime = new int[10];
    public int heldProj = -1;
    public int breathCD;
    public int breathMax = 200;
    public int breath = 200;
    public bool socialShadow;
    public string setBonus = "";
    public Item[] inventory = new Item[49];
    public Item[] bank = new Item[Chest.maxItems];
    public Item[] bank2 = new Item[Chest.maxItems];
    public float headRotation;
    public float bodyRotation;
    public float legRotation;
    public Vector2 headPosition;
    public Vector2 bodyPosition;
    public Vector2 legPosition;
    public Vector2 headVelocity;
    public Vector2 bodyVelocity;
    public Vector2 legVelocity;
    public int nonTorch = -1;
    public static bool deadForGood = false;
    public bool dead;
    public int respawnTimer;
    public string name = "";
    public int attackCD;
    public int potionDelay;
    public byte difficulty;
    public bool wet;
    public byte wetCount;
    public bool lavaWet;
    public int hitTile;
    public int hitTileX;
    public int hitTileY;
    public int jump;
    public int head = -1;
    public int body = -1;
    public int legs = -1;
    public Rectangle headFrame;
    public Rectangle bodyFrame;
    public Rectangle legFrame;
    public Rectangle hairFrame;
    public bool controlLeft;
    public bool controlRight;
    public bool controlUp;
    public bool controlDown;
    public bool controlJump;
    public bool controlUseItem;
    public bool controlUseTile;
    public bool controlThrow;
    public bool controlInv;
    public bool controlHook;
    public bool controlTorch;
    public bool releaseJump;
    public bool releaseUseItem;
    public bool releaseUseTile;
    public bool releaseInventory;
    public bool releaseHook;
    public bool releaseThrow;
    public bool releaseQuickMana;
    public bool releaseQuickHeal;
    public bool delayUseItem;
    public bool active;
    public int width = 20;
    public int height = 42;
    public int direction = 1;
    public bool showItemIcon;
    public int showItemIcon2;
    public int whoAmi;
    public int runSoundDelay;
    public float shadow;
    public float manaCost = 1f;
    public bool fireWalk;
    public Vector2[] shadowPos = new Vector2[3];
    public int shadowCount;
    public bool channel;
    public int step = -1;
    public int statDefense;
    public int statAttack;
    public int statLifeMax = 100;
    public int statLife = 100;
    public int statMana;
    public int statManaMax;
    public int statManaMax2;
    public int lifeRegen;
    public int lifeRegenCount;
    public int lifeRegenTime;
    public int manaRegen;
    public int manaRegenCount;
    public int manaRegenDelay;
    public bool manaRegenBuff;
    public bool noKnockback;
    public bool spaceGun;
    public float gravDir = 1f;
    public bool ammoCost80;
    public bool ammoCost75;
    public int stickyBreak;
    public bool lightOrb;
    public bool fairy;
    public bool bunny;
    public bool archery;
    public bool poisoned;
    public bool blind;
    public bool onFire;
    public bool onFire2;
    public bool noItems;
    public bool wereWolf;
    public bool wolfAcc;
    public bool rulerAcc;
    public bool bleed;
    public bool confused;
    public bool accMerman;
    public bool merman;
    public bool brokenArmor;
    public bool silence;
    public bool slow;
    public bool gross;
    public bool tongued;
    public bool kbGlove;
    public bool starCloak;
    public bool longInvince;
    public bool pStone;
    public bool manaFlower;
    public int meleeCrit = 4;
    public int rangedCrit = 4;
    public int magicCrit = 4;
    public float meleeDamage = 1f;
    public float rangedDamage = 1f;
    public float magicDamage = 1f;
    public float meleeSpeed = 1f;
    public float moveSpeed = 1f;
    public float pickSpeed = 1f;
    public int SpawnX = -1;
    public int SpawnY = -1;
    public int[] spX = new int[200];
    public int[] spY = new int[200];
    public string[] spN = new string[200];
    public int[] spI = new int[200];
    public static int tileRangeX = 5;
    public static int tileRangeY = 4;
    private static int tileTargetX;
    private static int tileTargetY;
    private static int jumpHeight = 15;
    private static float jumpSpeed = 5.01f;
    public bool adjWater;
    public bool oldAdjWater;
    public bool[] adjTile = new bool[150];
    public bool[] oldAdjTile = new bool[150];
    private static int itemGrabRange = 38;
    private static float itemGrabSpeed = 0.45f;
    private static float itemGrabSpeedMax = 4f;
    public Color hairColor = new Color(215, 90, 55);
    public Color skinColor = new Color((int) byte.MaxValue, 125, 90);
    public Color eyeColor = new Color(105, 90, 75);
    public Color shirtColor = new Color(175, 165, 140);
    public Color underShirtColor = new Color(160, 180, 215);
    public Color pantsColor = new Color((int) byte.MaxValue, 230, 175);
    public Color shoeColor = new Color(160, 105, 60);
    public int hair;
    public bool hostile;
    public int accCompass;
    public int accWatch;
    public int accDepthMeter;
    public bool accDivingHelm;
    public bool accFlipper;
    public bool doubleJump;
    public bool jumpAgain;
    public bool spawnMax;
    public int blockRange;
    public int[] grappling = new int[20];
    public int grapCount;
    public int rocketTime;
    public int rocketTimeMax = 7;
    public int rocketDelay;
    public int rocketDelay2;
    public bool rocketRelease;
    public bool rocketFrame;
    public int rocketBoots;
    public bool canRocket;
    public bool jumpBoost;
    public bool noFallDmg;
    public int swimTime;
    public bool killGuide;
    public bool lavaImmune;
    public bool gills;
    public bool slowFall;
    public bool findTreasure;
    public bool invis;
    public bool detectCreature;
    public bool nightVision;
    public bool enemySpawns;
    public bool thorns;
    public bool waterWalk;
    public bool gravControl;
    public int chest = -1;
    public int chestX;
    public int chestY;
    public int talkNPC = -1;
    public int fallStart;
    public int slowCount;
    public int potionDelayTime = Item.potionDelay;

    public void HealEffect(int healAmount)
    {
      CombatText.NewText(new Rectangle((int) this.position.X, (int) this.position.Y, this.width, this.height), new Color(100, (int) byte.MaxValue, 100, (int) byte.MaxValue), string.Concat((object) healAmount));
      if (Main.netMode != 1 || this.whoAmi != Main.myPlayer)
        return;
      NetMessage.SendData(35, number: this.whoAmi, number2: ((float) healAmount));
    }

    public void ManaEffect(int manaAmount)
    {
      CombatText.NewText(new Rectangle((int) this.position.X, (int) this.position.Y, this.width, this.height), new Color(100, 100, (int) byte.MaxValue, (int) byte.MaxValue), string.Concat((object) manaAmount));
      if (Main.netMode != 1 || this.whoAmi != Main.myPlayer)
        return;
      NetMessage.SendData(43, number: this.whoAmi, number2: ((float) manaAmount));
    }

    public static byte FindClosest(Vector2 Position, int Width, int Height)
    {
      byte num1 = 0;
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (Main.player[index].active)
        {
          num1 = (byte) index;
          break;
        }
      }
      float num2 = -1f;
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (Main.player[index].active && !Main.player[index].dead && ((double) num2 == -1.0 || (double) Math.Abs(Main.player[index].position.X + (float) (Main.player[index].width / 2) - Position.X + (float) (Width / 2)) + (double) Math.Abs(Main.player[index].position.Y + (float) (Main.player[index].height / 2) - Position.Y + (float) (Height / 2)) < (double) num2))
        {
          num2 = Math.Abs(Main.player[index].position.X + (float) (Main.player[index].width / 2) - Position.X + (float) (Width / 2)) + Math.Abs(Main.player[index].position.Y + (float) (Main.player[index].height / 2) - Position.Y + (float) (Height / 2));
          num1 = (byte) index;
        }
      }
      return num1;
    }

    public void checkArmor()
    {
    }

    public void toggleInv()
    {
      if (this.talkNPC >= 0)
      {
        this.talkNPC = -1;
        Main.npcChatText = "";
        Main.PlaySound(11);
      }
      else if (this.sign >= 0)
      {
        this.sign = -1;
        Main.editSign = false;
        Main.npcChatText = "";
        Main.PlaySound(11);
      }
      else if (!Main.playerInventory)
      {
        Recipe.FindRecipes();
        Main.playerInventory = true;
        Main.PlaySound(10);
      }
      else
      {
        Main.playerInventory = false;
        Main.PlaySound(11);
      }
    }

    public void dropItemCheck()
    {
      if (!Main.playerInventory)
        this.noThrow = 0;
      if (this.noThrow > 0)
        --this.noThrow;
      if (!Main.craftGuide && Main.guideItem.type > 0)
      {
        int number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, Main.guideItem.type);
        Main.guideItem.position = Main.item[number].position;
        Main.item[number] = Main.guideItem;
        Main.guideItem = new Item();
        if (Main.netMode == 0)
          Main.item[number].noGrabDelay = 100;
        Main.item[number].velocity.Y = -2f;
        Main.item[number].velocity.X = (float) (4 * this.direction) + this.velocity.X;
        if (Main.netMode == 1)
          NetMessage.SendData(21, number: number);
      }
      if (!Main.reforge && Main.reforgeItem.type > 0)
      {
        int number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, Main.reforgeItem.type);
        Main.reforgeItem.position = Main.item[number].position;
        Main.item[number] = Main.reforgeItem;
        Main.reforgeItem = new Item();
        if (Main.netMode == 0)
          Main.item[number].noGrabDelay = 100;
        Main.item[number].velocity.Y = -2f;
        Main.item[number].velocity.X = (float) (4 * this.direction) + this.velocity.X;
        if (Main.netMode == 1)
          NetMessage.SendData(21, number: number);
      }
      if (Main.myPlayer == this.whoAmi)
        this.inventory[48] = (Item) Main.mouseItem.Clone();
      bool flag1 = true;
      if (Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)
      {
        Player.tileTargetX = (int) (((double) Main.mouseX + (double) Main.screenPosition.X) / 16.0);
        Player.tileTargetY = (int) (((double) Main.mouseY + (double) Main.screenPosition.Y) / 16.0);
        if (this.selectedItem != 48)
          this.oldSelectItem = this.selectedItem;
        this.selectedItem = 48;
        flag1 = false;
      }
      if (flag1 && this.selectedItem == 48)
        this.selectedItem = this.oldSelectItem;
      if ((!this.controlThrow || !this.releaseThrow || this.inventory[this.selectedItem].type <= 0 || Main.chatMode) && ((!Main.mouseRight || this.mouseInterface || !Main.mouseRightRelease) && Main.playerInventory || Main.mouseItem.type <= 0 || Main.mouseItem.stack <= 0) || this.noThrow > 0)
        return;
      Item obj = new Item();
      bool flag2 = false;
      if ((Main.mouseRight && !this.mouseInterface && Main.mouseRightRelease || !Main.playerInventory) && Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)
      {
        obj = this.inventory[this.selectedItem];
        this.inventory[this.selectedItem] = Main.mouseItem;
        this.delayUseItem = true;
        this.controlUseItem = false;
        flag2 = true;
      }
      int number1 = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, this.inventory[this.selectedItem].type);
      if (!flag2 && this.inventory[this.selectedItem].type == 8 && this.inventory[this.selectedItem].stack > 1)
      {
        --this.inventory[this.selectedItem].stack;
      }
      else
      {
        this.inventory[this.selectedItem].position = Main.item[number1].position;
        Main.item[number1] = this.inventory[this.selectedItem];
        this.inventory[this.selectedItem] = new Item();
      }
      if (Main.netMode == 0)
        Main.item[number1].noGrabDelay = 100;
      Main.item[number1].velocity.Y = -2f;
      Main.item[number1].velocity.X = (float) (4 * this.direction) + this.velocity.X;
      if ((Main.mouseRight && !this.mouseInterface || !Main.playerInventory) && Main.mouseItem.type > 0)
      {
        this.inventory[this.selectedItem] = obj;
        Main.mouseItem = new Item();
      }
      else
      {
        this.itemAnimation = 10;
        this.itemAnimationMax = 10;
      }
      Recipe.FindRecipes();
      if (Main.netMode != 1)
        return;
      NetMessage.SendData(21, number: number1);
    }

    public void AddBuff(int type, int time, bool quiet = true)
    {
      if (!quiet && Main.netMode == 1)
        NetMessage.SendData(55, number: this.whoAmi, number2: ((float) type), number3: ((float) time));
      int index1 = -1;
      for (int index2 = 0; index2 < 10; ++index2)
      {
        if (this.buffType[index2] == type)
        {
          if (this.buffTime[index2] >= time)
            return;
          this.buffTime[index2] = time;
          return;
        }
      }
      while (index1 == -1)
      {
        int b = -1;
        for (int index3 = 0; index3 < 10; ++index3)
        {
          if (!Main.debuff[this.buffType[index3]])
          {
            b = index3;
            break;
          }
        }
        if (b == -1)
          return;
        for (int index4 = b; index4 < 10; ++index4)
        {
          if (this.buffType[index4] == 0)
          {
            index1 = index4;
            break;
          }
        }
        if (index1 == -1)
          this.DelBuff(b);
      }
      this.buffType[index1] = type;
      this.buffTime[index1] = time;
    }

    public void DelBuff(int b)
    {
      this.buffTime[b] = 0;
      this.buffType[b] = 0;
      for (int index1 = 0; index1 < 9; ++index1)
      {
        if (this.buffTime[index1] == 0 || this.buffType[index1] == 0)
        {
          for (int index2 = index1 + 1; index2 < 10; ++index2)
          {
            this.buffTime[index2 - 1] = this.buffTime[index2];
            this.buffType[index2 - 1] = this.buffType[index2];
            this.buffTime[index2] = 0;
            this.buffType[index2] = 0;
          }
        }
      }
    }

    public void QuickHeal()
    {
      if (this.noItems || this.statLife == this.statLifeMax || this.potionDelay > 0)
        return;
      for (int index = 0; index < 48; ++index)
      {
        if (this.inventory[index].stack > 0 && this.inventory[index].type > 0 && this.inventory[index].potion && this.inventory[index].healLife > 0)
        {
          Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, this.inventory[index].useSound);
          if (this.inventory[index].potion)
          {
            this.potionDelay = this.potionDelayTime;
            this.AddBuff(21, this.potionDelay);
          }
          this.statLife += this.inventory[index].healLife;
          this.statMana += this.inventory[index].healMana;
          if (this.statLife > this.statLifeMax)
            this.statLife = this.statLifeMax;
          if (this.statMana > this.statManaMax2)
            this.statMana = this.statManaMax2;
          if (this.inventory[index].healLife > 0 && Main.myPlayer == this.whoAmi)
            this.HealEffect(this.inventory[index].healLife);
          if (this.inventory[index].healMana > 0 && Main.myPlayer == this.whoAmi)
            this.ManaEffect(this.inventory[index].healMana);
          --this.inventory[index].stack;
          if (this.inventory[index].stack <= 0)
          {
            this.inventory[index].type = 0;
            this.inventory[index].name = "";
          }
          Recipe.FindRecipes();
          break;
        }
      }
    }

    public void QuickMana()
    {
      if (this.noItems || this.statMana == this.statManaMax2)
        return;
      for (int index = 0; index < 48; ++index)
      {
        if (this.inventory[index].stack > 0 && this.inventory[index].type > 0 && this.inventory[index].healMana > 0 && (this.potionDelay == 0 || !this.inventory[index].potion))
        {
          Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, this.inventory[index].useSound);
          if (this.inventory[index].potion)
          {
            this.potionDelay = this.potionDelayTime;
            this.AddBuff(21, this.potionDelay);
          }
          this.statLife += this.inventory[index].healLife;
          this.statMana += this.inventory[index].healMana;
          if (this.statLife > this.statLifeMax)
            this.statLife = this.statLifeMax;
          if (this.statMana > this.statManaMax2)
            this.statMana = this.statManaMax2;
          if (this.inventory[index].healLife > 0 && Main.myPlayer == this.whoAmi)
            this.HealEffect(this.inventory[index].healLife);
          if (this.inventory[index].healMana > 0 && Main.myPlayer == this.whoAmi)
            this.ManaEffect(this.inventory[index].healMana);
          --this.inventory[index].stack;
          if (this.inventory[index].stack <= 0)
          {
            this.inventory[index].type = 0;
            this.inventory[index].name = "";
          }
          Recipe.FindRecipes();
          break;
        }
      }
    }

    public int countBuffs()
    {
      int index1 = 0;
      for (int index2 = 0; index2 < 10; ++index2)
      {
        if (this.buffType[index1] > 0)
          ++index1;
      }
      return index1;
    }

    public void QuickBuff()
    {
      if (this.noItems)
        return;
      int Style = 0;
      for (int index1 = 0; index1 < 48; ++index1)
      {
        if (this.countBuffs() == 10)
          return;
        if (this.inventory[index1].stack > 0 && this.inventory[index1].type > 0 && this.inventory[index1].buffType > 0)
        {
          bool flag = true;
          for (int index2 = 0; index2 < 10; ++index2)
          {
            if (this.buffType[index2] == this.inventory[index1].buffType)
            {
              flag = false;
              break;
            }
          }
          if (this.inventory[index1].mana > 0 && flag)
          {
            if (this.statMana >= (int) ((double) this.inventory[index1].mana * (double) this.manaCost))
            {
              this.manaRegenDelay = (int) this.maxRegenDelay;
              this.statMana -= (int) ((double) this.inventory[index1].mana * (double) this.manaCost);
            }
            else
              flag = false;
          }
          if (this.whoAmi == Main.myPlayer && this.inventory[index1].type == 603 && !Main.cEd)
            flag = false;
          if (flag)
          {
            Style = this.inventory[index1].useSound;
            int time = this.inventory[index1].buffTime;
            if (time == 0)
              time = 3600;
            this.AddBuff(this.inventory[index1].buffType, time);
            if (this.inventory[index1].consumable)
            {
              --this.inventory[index1].stack;
              if (this.inventory[index1].stack <= 0)
              {
                this.inventory[index1].type = 0;
                this.inventory[index1].name = "";
              }
            }
          }
        }
      }
      if (Style <= 0)
        return;
      Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, Style);
      Recipe.FindRecipes();
    }

    public void StatusNPC(int type, int i)
    {
      switch (type)
      {
        case 121:
          if (Main.rand.Next(2) != 0)
            break;
          Main.npc[i].AddBuff(24, 180);
          break;
        case 122:
          if (Main.rand.Next(10) != 0)
            break;
          Main.npc[i].AddBuff(24, 180);
          break;
        case 190:
          if (Main.rand.Next(4) != 0)
            break;
          Main.npc[i].AddBuff(20, 420);
          break;
        case 217:
          if (Main.rand.Next(5) != 0)
            break;
          Main.npc[i].AddBuff(24, 180);
          break;
      }
    }

    public void StatusPvP(int type, int i)
    {
      switch (type)
      {
        case 121:
          if (Main.rand.Next(2) != 0)
            break;
          Main.player[i].AddBuff(24, 180, false);
          break;
        case 122:
          if (Main.rand.Next(10) != 0)
            break;
          Main.player[i].AddBuff(24, 180, false);
          break;
        case 190:
          if (Main.rand.Next(4) != 0)
            break;
          Main.player[i].AddBuff(20, 420, false);
          break;
        case 217:
          if (Main.rand.Next(5) != 0)
            break;
          Main.player[i].AddBuff(24, 180, false);
          break;
      }
    }

    public void Ghost()
    {
      this.immune = false;
      this.immuneAlpha = 0;
      this.controlUp = false;
      this.controlLeft = false;
      this.controlDown = false;
      this.controlRight = false;
      this.controlJump = false;
      if (Main.hasFocus && !Main.chatMode && !Main.editSign)
      {
        foreach (int pressedKey in Main.keyState.GetPressedKeys())
        {
          string str = string.Concat((object) (Keys) pressedKey);
          if (str == Main.cUp)
            this.controlUp = true;
          if (str == Main.cLeft)
            this.controlLeft = true;
          if (str == Main.cDown)
            this.controlDown = true;
          if (str == Main.cRight)
            this.controlRight = true;
          if (str == Main.cJump)
            this.controlJump = true;
        }
      }
      if (this.controlUp || this.controlJump)
      {
        if ((double) this.velocity.Y > 0.0)
          this.velocity.Y *= 0.9f;
        this.velocity.Y -= 0.1f;
        if ((double) this.velocity.Y < -3.0)
          this.velocity.Y = -3f;
      }
      else if (this.controlDown)
      {
        if ((double) this.velocity.Y < 0.0)
          this.velocity.Y *= 0.9f;
        this.velocity.Y += 0.1f;
        if ((double) this.velocity.Y > 3.0)
          this.velocity.Y = 3f;
      }
      else if ((double) this.velocity.Y < -0.1 || (double) this.velocity.Y > 0.1)
        this.velocity.Y *= 0.9f;
      else
        this.velocity.Y = 0.0f;
      if (this.controlLeft && !this.controlRight)
      {
        if ((double) this.velocity.X > 0.0)
          this.velocity.X *= 0.9f;
        this.velocity.X -= 0.1f;
        if ((double) this.velocity.X < -3.0)
          this.velocity.X = -3f;
      }
      else if (this.controlRight && !this.controlLeft)
      {
        if ((double) this.velocity.X < 0.0)
          this.velocity.X *= 0.9f;
        this.velocity.X += 0.1f;
        if ((double) this.velocity.X > 3.0)
          this.velocity.X = 3f;
      }
      else if ((double) this.velocity.X < -0.1 || (double) this.velocity.X > 0.1)
        this.velocity.X *= 0.9f;
      else
        this.velocity.X = 0.0f;
      this.position += this.velocity;
      ++this.ghostFrameCounter;
      if ((double) this.velocity.X < 0.0)
        this.direction = -1;
      else if ((double) this.velocity.X > 0.0)
        this.direction = 1;
      if (this.ghostFrameCounter >= 8)
      {
        this.ghostFrameCounter = 0;
        ++this.ghostFrame;
        if (this.ghostFrame >= 4)
          this.ghostFrame = 0;
      }
      if ((double) this.position.X < (double) Main.leftWorld + (double) (Lighting.offScreenTiles * 16) + 16.0)
      {
        this.position.X = (float) ((double) Main.leftWorld + (double) (Lighting.offScreenTiles * 16) + 16.0);
        this.velocity.X = 0.0f;
      }
      if ((double) this.position.X + (double) this.width > (double) Main.rightWorld - (double) (Lighting.offScreenTiles * 16) - 32.0)
      {
        this.position.X = (float) ((double) Main.rightWorld - (double) (Lighting.offScreenTiles * 16) - 32.0) - (float) this.width;
        this.velocity.X = 0.0f;
      }
      if ((double) this.position.Y < (double) Main.topWorld + (double) (Lighting.offScreenTiles * 16) + 16.0)
      {
        this.position.Y = (float) ((double) Main.topWorld + (double) (Lighting.offScreenTiles * 16) + 16.0);
        if ((double) this.velocity.Y < -0.1)
          this.velocity.Y = -0.1f;
      }
      if ((double) this.position.Y <= (double) Main.bottomWorld - (double) (Lighting.offScreenTiles * 16) - 32.0 - (double) this.height)
        return;
      this.position.Y = (float) ((double) Main.bottomWorld - (double) (Lighting.offScreenTiles * 16) - 32.0) - (float) this.height;
      this.velocity.Y = 0.0f;
    }

    public void UpdatePlayer(int i)
    {
      // ISSUE: unable to decompile the method.
    }

    public bool SellItem(int price, int stack)
    {
      if (price <= 0)
        return false;
      Item[] objArray = new Item[48];
      for (int index = 0; index < 48; ++index)
      {
        objArray[index] = new Item();
        objArray[index] = (Item) this.inventory[index].Clone();
      }
      int num = price / 5 * stack;
      if (num < 1)
        num = 1;
      bool flag = false;
      while (num >= 1000000 && !flag)
      {
        int index = -1;
        for (int i = 43; i >= 0; --i)
        {
          if (index == -1 && (this.inventory[i].type == 0 || this.inventory[i].stack == 0))
            index = i;
          while (this.inventory[i].type == 74 && this.inventory[i].stack < this.inventory[i].maxStack && num >= 1000000)
          {
            ++this.inventory[i].stack;
            num -= 1000000;
            this.DoCoins(i);
            if (this.inventory[i].stack == 0 && index == -1)
              index = i;
          }
        }
        if (num >= 1000000)
        {
          if (index == -1)
          {
            flag = true;
          }
          else
          {
            this.inventory[index].SetDefaults(74);
            num -= 1000000;
          }
        }
      }
      while (num >= 10000 && !flag)
      {
        int index = -1;
        for (int i = 43; i >= 0; --i)
        {
          if (index == -1 && (this.inventory[i].type == 0 || this.inventory[i].stack == 0))
            index = i;
          while (this.inventory[i].type == 73 && this.inventory[i].stack < this.inventory[i].maxStack && num >= 10000)
          {
            ++this.inventory[i].stack;
            num -= 10000;
            this.DoCoins(i);
            if (this.inventory[i].stack == 0 && index == -1)
              index = i;
          }
        }
        if (num >= 10000)
        {
          if (index == -1)
          {
            flag = true;
          }
          else
          {
            this.inventory[index].SetDefaults(73);
            num -= 10000;
          }
        }
      }
      while (num >= 100 && !flag)
      {
        int index = -1;
        for (int i = 43; i >= 0; --i)
        {
          if (index == -1 && (this.inventory[i].type == 0 || this.inventory[i].stack == 0))
            index = i;
          while (this.inventory[i].type == 72 && this.inventory[i].stack < this.inventory[i].maxStack && num >= 100)
          {
            ++this.inventory[i].stack;
            num -= 100;
            this.DoCoins(i);
            if (this.inventory[i].stack == 0 && index == -1)
              index = i;
          }
        }
        if (num >= 100)
        {
          if (index == -1)
          {
            flag = true;
          }
          else
          {
            this.inventory[index].SetDefaults(72);
            num -= 100;
          }
        }
      }
      while (num >= 1 && !flag)
      {
        int index = -1;
        for (int i = 43; i >= 0; --i)
        {
          if (index == -1 && (this.inventory[i].type == 0 || this.inventory[i].stack == 0))
            index = i;
          while (this.inventory[i].type == 71 && this.inventory[i].stack < this.inventory[i].maxStack && num >= 1)
          {
            ++this.inventory[i].stack;
            --num;
            this.DoCoins(i);
            if (this.inventory[i].stack == 0 && index == -1)
              index = i;
          }
        }
        if (num >= 1)
        {
          if (index == -1)
          {
            flag = true;
          }
          else
          {
            this.inventory[index].SetDefaults(71);
            --num;
          }
        }
      }
      if (!flag)
        return true;
      for (int index = 0; index < 48; ++index)
        this.inventory[index] = (Item) objArray[index].Clone();
      return false;
    }

    public bool BuyItem(int price)
    {
      if (price == 0)
        return true;
      int num1 = 0;
      Item[] objArray = new Item[44];
      for (int index = 0; index < 44; ++index)
      {
        objArray[index] = new Item();
        objArray[index] = (Item) this.inventory[index].Clone();
        if (this.inventory[index].type == 71)
          num1 += this.inventory[index].stack;
        if (this.inventory[index].type == 72)
          num1 += this.inventory[index].stack * 100;
        if (this.inventory[index].type == 73)
          num1 += this.inventory[index].stack * 10000;
        if (this.inventory[index].type == 74)
          num1 += this.inventory[index].stack * 1000000;
      }
      if (num1 < price)
        return false;
      int num2 = price;
      while (num2 > 0)
      {
        if (num2 >= 1000000)
        {
          for (int index = 0; index < 44; ++index)
          {
            if (this.inventory[index].type == 74)
            {
              while (this.inventory[index].stack > 0 && num2 >= 1000000)
              {
                num2 -= 1000000;
                --this.inventory[index].stack;
                if (this.inventory[index].stack == 0)
                  this.inventory[index].type = 0;
              }
            }
          }
        }
        if (num2 >= 10000)
        {
          for (int index = 0; index < 44; ++index)
          {
            if (this.inventory[index].type == 73)
            {
              while (this.inventory[index].stack > 0 && num2 >= 10000)
              {
                num2 -= 10000;
                --this.inventory[index].stack;
                if (this.inventory[index].stack == 0)
                  this.inventory[index].type = 0;
              }
            }
          }
        }
        if (num2 >= 100)
        {
          for (int index = 0; index < 44; ++index)
          {
            if (this.inventory[index].type == 72)
            {
              while (this.inventory[index].stack > 0 && num2 >= 100)
              {
                num2 -= 100;
                --this.inventory[index].stack;
                if (this.inventory[index].stack == 0)
                  this.inventory[index].type = 0;
              }
            }
          }
        }
        if (num2 >= 1)
        {
          for (int index = 0; index < 44; ++index)
          {
            if (this.inventory[index].type == 71)
            {
              while (this.inventory[index].stack > 0 && num2 >= 1)
              {
                --num2;
                --this.inventory[index].stack;
                if (this.inventory[index].stack == 0)
                  this.inventory[index].type = 0;
              }
            }
          }
        }
        if (num2 > 0)
        {
          int index1 = -1;
          for (int index2 = 43; index2 >= 0; --index2)
          {
            if (this.inventory[index2].type == 0 || this.inventory[index2].stack == 0)
            {
              index1 = index2;
              break;
            }
          }
          if (index1 >= 0)
          {
            bool flag = true;
            if (num2 >= 10000)
            {
              for (int index3 = 0; index3 < 48; ++index3)
              {
                if (this.inventory[index3].type == 74 && this.inventory[index3].stack >= 1)
                {
                  --this.inventory[index3].stack;
                  if (this.inventory[index3].stack == 0)
                    this.inventory[index3].type = 0;
                  this.inventory[index1].SetDefaults(73);
                  this.inventory[index1].stack = 100;
                  flag = false;
                  break;
                }
              }
            }
            else if (num2 >= 100)
            {
              for (int index4 = 0; index4 < 44; ++index4)
              {
                if (this.inventory[index4].type == 73 && this.inventory[index4].stack >= 1)
                {
                  --this.inventory[index4].stack;
                  if (this.inventory[index4].stack == 0)
                    this.inventory[index4].type = 0;
                  this.inventory[index1].SetDefaults(72);
                  this.inventory[index1].stack = 100;
                  flag = false;
                  break;
                }
              }
            }
            else if (num2 >= 1)
            {
              for (int index5 = 0; index5 < 44; ++index5)
              {
                if (this.inventory[index5].type == 72 && this.inventory[index5].stack >= 1)
                {
                  --this.inventory[index5].stack;
                  if (this.inventory[index5].stack == 0)
                    this.inventory[index5].type = 0;
                  this.inventory[index1].SetDefaults(71);
                  this.inventory[index1].stack = 100;
                  flag = false;
                  break;
                }
              }
            }
            if (flag)
            {
              if (num2 < 10000)
              {
                for (int index6 = 0; index6 < 44; ++index6)
                {
                  if (this.inventory[index6].type == 73 && this.inventory[index6].stack >= 1)
                  {
                    --this.inventory[index6].stack;
                    if (this.inventory[index6].stack == 0)
                      this.inventory[index6].type = 0;
                    this.inventory[index1].SetDefaults(72);
                    this.inventory[index1].stack = 100;
                    flag = false;
                    break;
                  }
                }
              }
              if (flag && num2 < 1000000)
              {
                for (int index7 = 0; index7 < 44; ++index7)
                {
                  if (this.inventory[index7].type == 74 && this.inventory[index7].stack >= 1)
                  {
                    --this.inventory[index7].stack;
                    if (this.inventory[index7].stack == 0)
                      this.inventory[index7].type = 0;
                    this.inventory[index1].SetDefaults(73);
                    this.inventory[index1].stack = 100;
                    break;
                  }
                }
              }
            }
          }
          else
          {
            for (int index8 = 0; index8 < 44; ++index8)
              this.inventory[index8] = (Item) objArray[index8].Clone();
            return false;
          }
        }
      }
      return true;
    }

    public void AdjTiles()
    {
      int num1 = 4;
      int num2 = 3;
      for (int index = 0; index < 150; ++index)
      {
        this.oldAdjTile[index] = this.adjTile[index];
        this.adjTile[index] = false;
      }
      this.oldAdjWater = this.adjWater;
      this.adjWater = false;
      int num3 = (int) (((double) this.position.X + (double) (this.width / 2)) / 16.0);
      int num4 = (int) (((double) this.position.Y + (double) this.height) / 16.0);
      for (int index1 = num3 - num1; index1 <= num3 + num1; ++index1)
      {
        for (int index2 = num4 - num2; index2 < num4 + num2; ++index2)
        {
          if (Main.tile[index1, index2].active)
          {
            this.adjTile[(int) Main.tile[index1, index2].type] = true;
            if (Main.tile[index1, index2].type == (byte) 77)
              this.adjTile[17] = true;
            if (Main.tile[index1, index2].type == (byte) 133)
            {
              this.adjTile[17] = true;
              this.adjTile[77] = true;
            }
            if (Main.tile[index1, index2].type == (byte) 134)
              this.adjTile[16] = true;
          }
          if (Main.tile[index1, index2].liquid > (byte) 200 && !Main.tile[index1, index2].lava)
            this.adjWater = true;
        }
      }
      if (!Main.playerInventory)
        return;
      bool flag = false;
      for (int index = 0; index < 150; ++index)
      {
        if (this.oldAdjTile[index] != this.adjTile[index])
        {
          flag = true;
          break;
        }
      }
      if (this.adjWater != this.oldAdjWater)
        flag = true;
      if (!flag)
        return;
      Recipe.FindRecipes();
    }

    public void PlayerFrame()
    {
      if (this.swimTime > 0)
      {
        --this.swimTime;
        if (!this.wet)
          this.swimTime = 0;
      }
      this.head = this.armor[0].headSlot;
      this.body = this.armor[1].bodySlot;
      this.legs = this.armor[2].legSlot;
      if (this.armor[8].headSlot >= 0)
        this.head = this.armor[8].headSlot;
      if (this.armor[9].bodySlot >= 0)
        this.body = this.armor[9].bodySlot;
      if (this.armor[10].legSlot >= 0)
        this.legs = this.armor[10].legSlot;
      if (this.wereWolf)
      {
        this.legs = 20;
        this.body = 21;
        this.head = 38;
      }
      if (this.merman)
      {
        this.head = 39;
        this.legs = 21;
        this.body = 22;
      }
      this.socialShadow = false;
      if (this.head == 5 && this.body == 5 && this.legs == 5)
        this.socialShadow = true;
      if (this.head == 5 && this.body == 5 && this.legs == 5 && Main.rand.Next(10) == 0)
        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, Alpha: 200, Scale: 1.2f);
      if (this.head == 6 && this.body == 6 && this.legs == 6 && (double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) > 1.0 && !this.rocketFrame)
      {
        for (int index1 = 0; index1 < 2; ++index1)
        {
          int index2 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, (float) ((double) this.position.Y - 2.0 - (double) this.velocity.Y * 2.0)), this.width, this.height, 6, Alpha: 100, Scale: 2f);
          Main.dust[index2].noGravity = true;
          Main.dust[index2].noLight = true;
          Main.dust[index2].velocity.X -= this.velocity.X * 0.5f;
          Main.dust[index2].velocity.Y -= this.velocity.Y * 0.5f;
        }
      }
      if (this.head == 7 && this.body == 7 && this.legs == 7)
        this.boneArmor = true;
      if (this.head == 8 && this.body == 8 && this.legs == 8 && (double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) > 1.0)
      {
        int index = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, (float) ((double) this.position.Y - 2.0 - (double) this.velocity.Y * 2.0)), this.width, this.height, 40, Alpha: 50, Scale: 1.4f);
        Main.dust[index].noGravity = true;
        Main.dust[index].velocity.X = this.velocity.X * 0.25f;
        Main.dust[index].velocity.Y = this.velocity.Y * 0.25f;
      }
      if (this.head == 9 && this.body == 9 && this.legs == 9 && (double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) > 1.0 && !this.rocketFrame)
      {
        for (int index3 = 0; index3 < 2; ++index3)
        {
          int index4 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, (float) ((double) this.position.Y - 2.0 - (double) this.velocity.Y * 2.0)), this.width, this.height, 6, Alpha: 100, Scale: 2f);
          Main.dust[index4].noGravity = true;
          Main.dust[index4].noLight = true;
          Main.dust[index4].velocity.X -= this.velocity.X * 0.5f;
          Main.dust[index4].velocity.Y -= this.velocity.Y * 0.5f;
        }
      }
      if (this.body == 18 && this.legs == 17 && (this.head == 32 || this.head == 33 || this.head == 34) && Main.rand.Next(10) == 0)
      {
        int index = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, (float) ((double) this.position.Y - 2.0 - (double) this.velocity.Y * 2.0)), this.width, this.height, 43, Alpha: 100, Scale: 0.3f);
        Main.dust[index].fadeIn = 0.8f;
        Main.dust[index].velocity *= 0.0f;
      }
      if (this.body == 24 && this.legs == 23 && (this.head == 42 || this.head == 43 || this.head == 41) && (double) this.velocity.X != 0.0 && (double) this.velocity.Y != 0.0 && Main.rand.Next(10) == 0)
      {
        int index = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, (float) ((double) this.position.Y - 2.0 - (double) this.velocity.Y * 2.0)), this.width, this.height, 43, Alpha: 100, Scale: 0.3f);
        Main.dust[index].fadeIn = 0.8f;
        Main.dust[index].velocity *= 0.0f;
      }
      this.bodyFrame.Width = 40;
      this.bodyFrame.Height = 56;
      this.legFrame.Width = 40;
      this.legFrame.Height = 56;
      this.bodyFrame.X = 0;
      this.legFrame.X = 0;
      if (this.itemAnimation > 0 && this.inventory[this.selectedItem].useStyle != 10)
      {
        if (this.inventory[this.selectedItem].useStyle == 1 || this.inventory[this.selectedItem].type == 0)
          this.bodyFrame.Y = (double) this.itemAnimation >= (double) this.itemAnimationMax * 0.333 ? ((double) this.itemAnimation >= (double) this.itemAnimationMax * 0.666 ? this.bodyFrame.Height : this.bodyFrame.Height * 2) : this.bodyFrame.Height * 3;
        else if (this.inventory[this.selectedItem].useStyle == 2)
          this.bodyFrame.Y = (double) this.itemAnimation <= (double) this.itemAnimationMax * 0.5 ? this.bodyFrame.Height * 2 : this.bodyFrame.Height * 3;
        else if (this.inventory[this.selectedItem].useStyle == 3)
          this.bodyFrame.Y = (double) this.itemAnimation <= (double) this.itemAnimationMax * 0.666 ? this.bodyFrame.Height * 3 : this.bodyFrame.Height * 3;
        else if (this.inventory[this.selectedItem].useStyle == 4)
          this.bodyFrame.Y = this.bodyFrame.Height * 2;
        else if (this.inventory[this.selectedItem].useStyle == 5)
        {
          if (this.inventory[this.selectedItem].type == 281)
          {
            this.bodyFrame.Y = this.bodyFrame.Height * 2;
          }
          else
          {
            float num = this.itemRotation * (float) this.direction;
            this.bodyFrame.Y = this.bodyFrame.Height * 3;
            if ((double) num < -0.75)
            {
              this.bodyFrame.Y = this.bodyFrame.Height * 2;
              if ((double) this.gravDir == -1.0)
                this.bodyFrame.Y = this.bodyFrame.Height * 4;
            }
            if ((double) num > 0.6)
            {
              this.bodyFrame.Y = this.bodyFrame.Height * 4;
              if ((double) this.gravDir == -1.0)
                this.bodyFrame.Y = this.bodyFrame.Height * 2;
            }
          }
        }
      }
      else if (this.inventory[this.selectedItem].holdStyle == 1 && (!this.wet || !this.inventory[this.selectedItem].noWet))
        this.bodyFrame.Y = this.bodyFrame.Height * 3;
      else if (this.inventory[this.selectedItem].holdStyle == 2 && (!this.wet || !this.inventory[this.selectedItem].noWet))
        this.bodyFrame.Y = this.bodyFrame.Height * 2;
      else if (this.inventory[this.selectedItem].holdStyle == 3)
        this.bodyFrame.Y = this.bodyFrame.Height * 3;
      else if (this.grappling[0] >= 0)
      {
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = 0.0f;
        float num2 = 0.0f;
        for (int index = 0; index < this.grapCount; ++index)
        {
          num1 += Main.projectile[this.grappling[index]].position.X + (float) (Main.projectile[this.grappling[index]].width / 2);
          num2 += Main.projectile[this.grappling[index]].position.Y + (float) (Main.projectile[this.grappling[index]].height / 2);
        }
        float num3 = num1 / (float) this.grapCount;
        float num4 = num2 / (float) this.grapCount;
        float num5 = num3 - vector2.X;
        float num6 = num4 - vector2.Y;
        if ((double) num6 < 0.0 && (double) Math.Abs(num6) > (double) Math.Abs(num5))
        {
          this.bodyFrame.Y = this.bodyFrame.Height * 2;
          if ((double) this.gravDir == -1.0)
            this.bodyFrame.Y = this.bodyFrame.Height * 4;
        }
        else if ((double) num6 > 0.0 && (double) Math.Abs(num6) > (double) Math.Abs(num5))
        {
          this.bodyFrame.Y = this.bodyFrame.Height * 4;
          if ((double) this.gravDir == -1.0)
            this.bodyFrame.Y = this.bodyFrame.Height * 2;
        }
        else
          this.bodyFrame.Y = this.bodyFrame.Height * 3;
      }
      else if (this.swimTime > 0)
        this.bodyFrame.Y = this.swimTime <= 20 ? (this.swimTime <= 10 ? 0 : this.bodyFrame.Height * 5) : 0;
      else if ((double) this.velocity.Y != 0.0)
      {
        this.bodyFrame.Y = this.wings <= 0 ? this.bodyFrame.Height * 5 : ((double) this.velocity.Y <= 0.0 ? this.bodyFrame.Height * 6 : (!this.controlJump ? this.bodyFrame.Height * 5 : this.bodyFrame.Height * 6));
        this.bodyFrameCounter = 0.0;
      }
      else if ((double) this.velocity.X != 0.0)
      {
        this.bodyFrameCounter += (double) Math.Abs(this.velocity.X) * 1.5;
        this.bodyFrame.Y = this.legFrame.Y;
      }
      else
      {
        this.bodyFrameCounter = 0.0;
        this.bodyFrame.Y = 0;
      }
      if (this.swimTime > 0)
      {
        this.legFrameCounter += 2.0;
        while (this.legFrameCounter > 8.0)
        {
          this.legFrameCounter -= 8.0;
          this.legFrame.Y += this.legFrame.Height;
        }
        if (this.legFrame.Y < this.legFrame.Height * 7)
        {
          this.legFrame.Y = this.legFrame.Height * 19;
        }
        else
        {
          if (this.legFrame.Y <= this.legFrame.Height * 19)
            return;
          this.legFrame.Y = this.legFrame.Height * 7;
        }
      }
      else if ((double) this.velocity.Y != 0.0 || this.grappling[0] > -1)
      {
        this.legFrameCounter = 0.0;
        this.legFrame.Y = this.legFrame.Height * 5;
      }
      else if ((double) this.velocity.X != 0.0)
      {
        this.legFrameCounter += (double) Math.Abs(this.velocity.X) * 1.3;
        while (this.legFrameCounter > 8.0)
        {
          this.legFrameCounter -= 8.0;
          this.legFrame.Y += this.legFrame.Height;
        }
        if (this.legFrame.Y < this.legFrame.Height * 7)
        {
          this.legFrame.Y = this.legFrame.Height * 19;
        }
        else
        {
          if (this.legFrame.Y <= this.legFrame.Height * 19)
            return;
          this.legFrame.Y = this.legFrame.Height * 7;
        }
      }
      else
      {
        this.legFrameCounter = 0.0;
        this.legFrame.Y = 0;
      }
    }

    public void Spawn()
    {
      if (this.whoAmi == Main.myPlayer)
      {
        Main.quickBG = 10;
        this.FindSpawn();
        if (!Player.CheckSpawn(this.SpawnX, this.SpawnY))
        {
          this.SpawnX = -1;
          this.SpawnY = -1;
        }
        Main.maxQ = true;
      }
      if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
      {
        NetMessage.SendData(12, number: Main.myPlayer);
        Main.gameMenu = false;
      }
      this.headPosition = new Vector2();
      this.bodyPosition = new Vector2();
      this.legPosition = new Vector2();
      this.headRotation = 0.0f;
      this.bodyRotation = 0.0f;
      this.legRotation = 0.0f;
      if (this.statLife <= 0)
      {
        this.statLife = 100;
        this.breath = this.breathMax;
        if (this.spawnMax)
        {
          this.statLife = this.statLifeMax;
          this.statMana = this.statManaMax2;
        }
      }
      this.immune = true;
      this.dead = false;
      this.immuneTime = 0;
      this.active = true;
      if (this.SpawnX >= 0 && this.SpawnY >= 0)
      {
        this.position.X = (float) (this.SpawnX * 16 + 8 - this.width / 2);
        this.position.Y = (float) (this.SpawnY * 16 - this.height);
      }
      else
      {
        this.position.X = (float) (Main.spawnTileX * 16 + 8 - this.width / 2);
        this.position.Y = (float) (Main.spawnTileY * 16 - this.height);
        for (int i = Main.spawnTileX - 1; i < Main.spawnTileX + 2; ++i)
        {
          for (int j = Main.spawnTileY - 3; j < Main.spawnTileY; ++j)
          {
            if (Main.tileSolid[(int) Main.tile[i, j].type] && !Main.tileSolidTop[(int) Main.tile[i, j].type])
              WorldGen.KillTile(i, j);
            if (Main.tile[i, j].liquid > (byte) 0)
            {
              Main.tile[i, j].lava = false;
              Main.tile[i, j].liquid = (byte) 0;
              WorldGen.SquareTileFrame(i, j);
            }
          }
        }
      }
      this.wet = false;
      this.wetCount = (byte) 0;
      this.lavaWet = false;
      this.fallStart = (int) ((double) this.position.Y / 16.0);
      this.velocity.X = 0.0f;
      this.velocity.Y = 0.0f;
      this.talkNPC = -1;
      if (this.pvpDeath)
      {
        this.pvpDeath = false;
        this.immuneTime = 300;
        this.statLife = this.statLifeMax;
      }
      else
        this.immuneTime = 60;
      if (this.whoAmi != Main.myPlayer)
        return;
      Main.renderNow = true;
      if (Main.netMode == 1)
        Netplay.newRecent();
      Main.screenPosition.X = this.position.X + (float) (this.width / 2) - (float) (Main.screenWidth / 2);
      Main.screenPosition.Y = this.position.Y + (float) (this.height / 2) - (float) (Main.screenHeight / 2);
    }

    public double Hurt(
      int Damage,
      int hitDirection,
      bool pvp = false,
      bool quiet = false,
      string deathText = " was slain...",
      bool Crit = false)
    {
      if (this.immune)
        return 0.0;
      int Damage1 = Damage;
      if (pvp)
        Damage1 *= 2;
      double damage = Main.CalculateDamage(Damage1, this.statDefense);
      if (Crit)
        Damage1 *= 2;
      if (damage >= 1.0)
      {
        if (Main.netMode == 1 && this.whoAmi == Main.myPlayer && !quiet)
        {
          int num = 0;
          if (pvp)
            num = 1;
          NetMessage.SendData(13, number: this.whoAmi);
          NetMessage.SendData(16, number: this.whoAmi);
          NetMessage.SendData(26, number: this.whoAmi, number2: ((float) hitDirection), number3: ((float) Damage), number4: ((float) num));
        }
        CombatText.NewText(new Rectangle((int) this.position.X, (int) this.position.Y, this.width, this.height), new Color((int) byte.MaxValue, 80, 90, (int) byte.MaxValue), string.Concat((object) (int) damage), Crit);
        this.statLife -= (int) damage;
        this.immune = true;
        this.immuneTime = 40;
        if (this.longInvince)
          this.immuneTime += 40;
        this.lifeRegenTime = 0;
        if (pvp)
          this.immuneTime = 8;
        if (this.whoAmi == Main.myPlayer && this.starCloak)
        {
          for (int index1 = 0; index1 < 3; ++index1)
          {
            float num1 = this.position.X + (float) Main.rand.Next(-400, 400);
            float num2 = this.position.Y - (float) Main.rand.Next(500, 800);
            Vector2 vector2 = new Vector2(num1, num2);
            float num3 = this.position.X + (float) (this.width / 2) - vector2.X;
            float num4 = this.position.Y + (float) (this.height / 2) - vector2.Y;
            float num5 = num3 + (float) Main.rand.Next(-100, 101);
            float num6 = 23f / (float) Math.Sqrt((double) num5 * (double) num5 + (double) num4 * (double) num4);
            float SpeedX = num5 * num6;
            float SpeedY = num4 * num6;
            int index2 = Projectile.NewProjectile(num1, num2, SpeedX, SpeedY, 92, 30, 5f, this.whoAmi);
            Main.projectile[index2].ai[1] = this.position.Y;
          }
        }
        if (!this.noKnockback && hitDirection != 0)
        {
          this.velocity.X = 4.5f * (float) hitDirection;
          this.velocity.Y = -3.5f;
        }
        if (this.wereWolf)
          Main.PlaySound(3, (int) this.position.X, (int) this.position.Y, 6);
        else if (this.boneArmor)
          Main.PlaySound(3, (int) this.position.X, (int) this.position.Y, 2);
        else if (!this.male)
          Main.PlaySound(20, (int) this.position.X, (int) this.position.Y);
        else
          Main.PlaySound(1, (int) this.position.X, (int) this.position.Y);
        if (this.statLife > 0)
        {
          for (int index = 0; (double) index < damage / (double) this.statLifeMax * 100.0; ++index)
          {
            if (this.boneArmor)
              Dust.NewDust(this.position, this.width, this.height, 26, (float) (2 * hitDirection), -2f);
            else
              Dust.NewDust(this.position, this.width, this.height, 5, (float) (2 * hitDirection), -2f);
          }
        }
        else
        {
          this.statLife = 0;
          if (this.whoAmi == Main.myPlayer)
            this.KillMe(damage, hitDirection, pvp, deathText);
        }
      }
      if (pvp)
        damage = Main.CalculateDamage(Damage1, this.statDefense);
      return damage;
    }

    public void KillMeForGood()
    {
      if (File.Exists(Main.playerPathName))
        File.Delete(Main.playerPathName);
      if (File.Exists(Main.playerPathName + ".bak"))
        File.Delete(Main.playerPathName + ".bak");
      if (File.Exists(Main.playerPathName + ".dat"))
        File.Delete(Main.playerPathName + ".dat");
      Main.playerPathName = "";
    }

    public void KillMe(double dmg, int hitDirection, bool pvp = false, string deathText = " was slain...")
    {
      if (this.dead)
        return;
      if (pvp)
        this.pvpDeath = true;
      if (this.difficulty == (byte) 0)
      {
        if (Main.netMode != 1)
        {
          float num = (float) Main.rand.Next(-35, 36) * 0.1f;
          while ((double) num < 2.0 && (double) num > -2.0)
            num += (float) Main.rand.Next(-30, 31) * 0.1f;
          int index = Projectile.NewProjectile(this.position.X + (float) (this.width / 2), this.position.Y + (float) (this.head / 2), (float) Main.rand.Next(10, 30) * 0.1f * (float) hitDirection + num, (float) Main.rand.Next(-40, -20) * 0.1f, 43, 0, 0.0f, Main.myPlayer);
          Main.projectile[index].miscText = this.name + deathText;
        }
      }
      else
      {
        if (Main.netMode != 1)
        {
          float num = (float) Main.rand.Next(-35, 36) * 0.1f;
          while ((double) num < 2.0 && (double) num > -2.0)
            num += (float) Main.rand.Next(-30, 31) * 0.1f;
          int index = Projectile.NewProjectile(this.position.X + (float) (this.width / 2), this.position.Y + (float) (this.head / 2), (float) Main.rand.Next(10, 30) * 0.1f * (float) hitDirection + num, (float) Main.rand.Next(-40, -20) * 0.1f, 43, 0, 0.0f, Main.myPlayer);
          Main.projectile[index].miscText = this.name + deathText;
        }
        if (Main.myPlayer == this.whoAmi)
        {
          Main.trashItem.SetDefaults(0);
          if (this.difficulty == (byte) 1)
            this.DropItems();
          else if (this.difficulty == (byte) 2)
          {
            this.DropItems();
            this.KillMeForGood();
          }
        }
      }
      Main.PlaySound(5, (int) this.position.X, (int) this.position.Y);
      this.headVelocity.Y = (float) Main.rand.Next(-40, -10) * 0.1f;
      this.bodyVelocity.Y = (float) Main.rand.Next(-40, -10) * 0.1f;
      this.legVelocity.Y = (float) Main.rand.Next(-40, -10) * 0.1f;
      this.headVelocity.X = (float) Main.rand.Next(-20, 21) * 0.1f + (float) (2 * hitDirection);
      this.bodyVelocity.X = (float) Main.rand.Next(-20, 21) * 0.1f + (float) (2 * hitDirection);
      this.legVelocity.X = (float) Main.rand.Next(-20, 21) * 0.1f + (float) (2 * hitDirection);
      for (int index = 0; (double) index < 20.0 + dmg / (double) this.statLifeMax * 100.0; ++index)
      {
        if (this.boneArmor)
          Dust.NewDust(this.position, this.width, this.height, 26, (float) (2 * hitDirection), -2f);
        else
          Dust.NewDust(this.position, this.width, this.height, 5, (float) (2 * hitDirection), -2f);
      }
      this.dead = true;
      this.respawnTimer = 600;
      this.immuneAlpha = 0;
      switch (Main.netMode)
      {
        case 0:
          Main.NewText(this.name + deathText, (byte) 225, (byte) 25, (byte) 25);
          break;
        case 2:
          NetMessage.SendData(25, text: (this.name + deathText), number: ((int) byte.MaxValue), number2: 225f, number3: 25f, number4: 25f);
          break;
      }
      if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
      {
        int num = 0;
        if (pvp)
          num = 1;
        NetMessage.SendData(44, text: deathText, number: this.whoAmi, number2: ((float) hitDirection), number3: ((float) (int) dmg), number4: ((float) num));
      }
      if (!pvp && this.whoAmi == Main.myPlayer && this.difficulty == (byte) 0)
        this.DropCoins();
      if (this.whoAmi != Main.myPlayer)
        return;
      try
      {
        WorldGen.saveToonWhilePlaying();
      }
      catch
      {
      }
    }

    public bool ItemSpace(Item newItem)
    {
      if (newItem.type == 58 || newItem.type == 184)
        return true;
      int num = 40;
      if (newItem.type == 71 || newItem.type == 72 || newItem.type == 73 || newItem.type == 74)
        num = 44;
      for (int index = 0; index < num; ++index)
      {
        if (this.inventory[index].type == 0)
          return true;
      }
      for (int index = 0; index < num; ++index)
      {
        if (this.inventory[index].type > 0 && this.inventory[index].stack < this.inventory[index].maxStack && newItem.IsTheSameAs(this.inventory[index]))
          return true;
      }
      if (newItem.ammo > 0)
      {
        if (newItem.type != 75 && newItem.type != 169 && newItem.type != 23 && newItem.type != 408 && newItem.type != 370)
        {
          for (int index = 44; index < 48; ++index)
          {
            if (this.inventory[index].type == 0)
              return true;
          }
        }
        for (int index = 44; index < 48; ++index)
        {
          if (this.inventory[index].type > 0 && this.inventory[index].stack < this.inventory[index].maxStack && newItem.IsTheSameAs(this.inventory[index]))
            return true;
        }
      }
      return false;
    }

    public void DoCoins(int i)
    {
      if (this.inventory[i].stack != 100 || this.inventory[i].type != 71 && this.inventory[i].type != 72 && this.inventory[i].type != 73)
        return;
      this.inventory[i].SetDefaults(this.inventory[i].type + 1);
      for (int i1 = 0; i1 < 44; ++i1)
      {
        if (this.inventory[i1].IsTheSameAs(this.inventory[i]) && i1 != i && this.inventory[i1].stack < this.inventory[i1].maxStack)
        {
          ++this.inventory[i1].stack;
          this.inventory[i].SetDefaults(0);
          this.inventory[i].active = false;
          this.inventory[i].name = "";
          this.inventory[i].type = 0;
          this.inventory[i].stack = 0;
          this.DoCoins(i1);
        }
      }
    }

    public Item FillAmmo(int plr, Item newItem)
    {
      Item obj = newItem;
      for (int i = 44; i < 48; ++i)
      {
        if (this.inventory[i].type > 0 && this.inventory[i].stack < this.inventory[i].maxStack && obj.IsTheSameAs(this.inventory[i]))
        {
          Main.PlaySound(7, (int) this.position.X, (int) this.position.Y);
          if (obj.stack + this.inventory[i].stack <= this.inventory[i].maxStack)
          {
            this.inventory[i].stack += obj.stack;
            ItemText.NewText(newItem, obj.stack);
            this.DoCoins(i);
            if (plr == Main.myPlayer)
              Recipe.FindRecipes();
            return new Item();
          }
          obj.stack -= this.inventory[i].maxStack - this.inventory[i].stack;
          ItemText.NewText(newItem, this.inventory[i].maxStack - this.inventory[i].stack);
          this.inventory[i].stack = this.inventory[i].maxStack;
          this.DoCoins(i);
          if (plr == Main.myPlayer)
            Recipe.FindRecipes();
        }
      }
      if (obj.type != 169 && obj.type != 75 && obj.type != 23 && obj.type != 408 && obj.type != 370)
      {
        for (int i = 44; i < 48; ++i)
        {
          if (this.inventory[i].type == 0)
          {
            this.inventory[i] = obj;
            ItemText.NewText(newItem, newItem.stack);
            this.DoCoins(i);
            Main.PlaySound(7, (int) this.position.X, (int) this.position.Y);
            if (plr == Main.myPlayer)
              Recipe.FindRecipes();
            return new Item();
          }
        }
      }
      return obj;
    }

    public Item GetItem(int plr, Item newItem)
    {
      Item newItem1 = newItem;
      int num1 = 40;
      if (newItem.noGrabDelay > 0)
        return newItem1;
      int num2 = 0;
      if (newItem.type == 71 || newItem.type == 72 || newItem.type == 73 || newItem.type == 74)
      {
        num2 = -4;
        num1 = 44;
      }
      if (newItem1.ammo > 0)
      {
        newItem1 = this.FillAmmo(plr, newItem1);
        if (newItem1.type == 0 || newItem1.stack == 0)
          return new Item();
      }
      for (int index = num2; index < 40; ++index)
      {
        int i = index;
        if (i < 0)
          i = 44 + index;
        if (this.inventory[i].type > 0 && this.inventory[i].stack < this.inventory[i].maxStack && newItem1.IsTheSameAs(this.inventory[i]))
        {
          Main.PlaySound(7, (int) this.position.X, (int) this.position.Y);
          if (newItem1.stack + this.inventory[i].stack <= this.inventory[i].maxStack)
          {
            this.inventory[i].stack += newItem1.stack;
            ItemText.NewText(newItem, newItem1.stack);
            this.DoCoins(i);
            if (plr == Main.myPlayer)
              Recipe.FindRecipes();
            return new Item();
          }
          newItem1.stack -= this.inventory[i].maxStack - this.inventory[i].stack;
          ItemText.NewText(newItem, this.inventory[i].maxStack - this.inventory[i].stack);
          this.inventory[i].stack = this.inventory[i].maxStack;
          this.DoCoins(i);
          if (plr == Main.myPlayer)
            Recipe.FindRecipes();
        }
      }
      if (newItem.type != 71 && newItem.type != 72 && newItem.type != 73 && newItem.type != 74 && newItem.useStyle > 0)
      {
        for (int i = 0; i < 10; ++i)
        {
          if (this.inventory[i].type == 0)
          {
            this.inventory[i] = newItem1;
            ItemText.NewText(newItem, newItem.stack);
            this.DoCoins(i);
            Main.PlaySound(7, (int) this.position.X, (int) this.position.Y);
            if (plr == Main.myPlayer)
              Recipe.FindRecipes();
            return new Item();
          }
        }
      }
      for (int i = num1 - 1; i >= 0; --i)
      {
        if (this.inventory[i].type == 0)
        {
          this.inventory[i] = newItem1;
          ItemText.NewText(newItem, newItem.stack);
          this.DoCoins(i);
          Main.PlaySound(7, (int) this.position.X, (int) this.position.Y);
          if (plr == Main.myPlayer)
            Recipe.FindRecipes();
          return new Item();
        }
      }
      return newItem1;
    }

    public void PlaceThing()
    {
      if (this.inventory[this.selectedItem].createTile >= 0 && (double) this.position.X / 16.0 - (double) Player.tileRangeX - (double) this.inventory[this.selectedItem].tileBoost - (double) this.blockRange <= (double) Player.tileTargetX && ((double) this.position.X + (double) this.width) / 16.0 + (double) Player.tileRangeX + (double) this.inventory[this.selectedItem].tileBoost - 1.0 + (double) this.blockRange >= (double) Player.tileTargetX && (double) this.position.Y / 16.0 - (double) Player.tileRangeY - (double) this.inventory[this.selectedItem].tileBoost - (double) this.blockRange <= (double) Player.tileTargetY && ((double) this.position.Y + (double) this.height) / 16.0 + (double) Player.tileRangeY + (double) this.inventory[this.selectedItem].tileBoost - 2.0 + (double) this.blockRange >= (double) Player.tileTargetY)
      {
        this.showItemIcon = true;
        bool flag1 = false;
        if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > (byte) 0 && Main.tile[Player.tileTargetX, Player.tileTargetY].lava)
        {
          if (Main.tileSolid[this.inventory[this.selectedItem].createTile])
            flag1 = true;
          else if (Main.tileLavaDeath[this.inventory[this.selectedItem].createTile])
            flag1 = true;
        }
        if ((!Main.tile[Player.tileTargetX, Player.tileTargetY].active && !flag1 || Main.tileCut[(int) Main.tile[Player.tileTargetX, Player.tileTargetY].type] || this.inventory[this.selectedItem].createTile == 23 || this.inventory[this.selectedItem].createTile == 2 || this.inventory[this.selectedItem].createTile == 109 || this.inventory[this.selectedItem].createTile == 60 || this.inventory[this.selectedItem].createTile == 70) && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
        {
          bool flag2 = false;
          if (this.inventory[this.selectedItem].createTile == 23 || this.inventory[this.selectedItem].createTile == 2 || this.inventory[this.selectedItem].createTile == 109)
          {
            if (Main.tile[Player.tileTargetX, Player.tileTargetY].active && Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 0)
              flag2 = true;
          }
          else if (this.inventory[this.selectedItem].createTile == 60 || this.inventory[this.selectedItem].createTile == 70)
          {
            if (Main.tile[Player.tileTargetX, Player.tileTargetY].active && Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 59)
              flag2 = true;
          }
          else if (this.inventory[this.selectedItem].createTile == 4 || this.inventory[this.selectedItem].createTile == 136)
          {
            int index1 = (int) Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type;
            int index2 = (int) Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type;
            int index3 = (int) Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type;
            int num1 = (int) Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].type;
            int num2 = (int) Main.tile[Player.tileTargetX + 1, Player.tileTargetY - 1].type;
            int num3 = (int) Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].type;
            int num4 = (int) Main.tile[Player.tileTargetX + 1, Player.tileTargetY + 1].type;
            if (!Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active)
              index1 = -1;
            if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active)
              index2 = -1;
            if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active)
              index3 = -1;
            if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].active)
              num1 = -1;
            if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY - 1].active)
              num2 = -1;
            if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY + 1].active)
              num3 = -1;
            if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY + 1].active)
              num4 = -1;
            if (index1 >= 0 && Main.tileSolid[index1] && !Main.tileNoAttach[index1])
              flag2 = true;
            else if (index2 >= 0 && Main.tileSolid[index2] && !Main.tileNoAttach[index2] || index2 == 5 && num1 == 5 && num3 == 5 || index2 == 124)
              flag2 = true;
            else if (index3 >= 0 && Main.tileSolid[index3] && !Main.tileNoAttach[index3] || index3 == 5 && num2 == 5 && num4 == 5 || index3 == 124)
              flag2 = true;
          }
          else if (this.inventory[this.selectedItem].createTile == 78 || this.inventory[this.selectedItem].createTile == 98 || this.inventory[this.selectedItem].createTile == 100)
          {
            if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active && (Main.tileSolid[(int) Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type] || Main.tileTable[(int) Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type]))
              flag2 = true;
          }
          else if (this.inventory[this.selectedItem].createTile == 13 || this.inventory[this.selectedItem].createTile == 29 || this.inventory[this.selectedItem].createTile == 33 || this.inventory[this.selectedItem].createTile == 49 || this.inventory[this.selectedItem].createTile == 50 || this.inventory[this.selectedItem].createTile == 103)
          {
            if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active && Main.tileTable[(int) Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type])
              flag2 = true;
          }
          else if (this.inventory[this.selectedItem].createTile == 51)
          {
            if (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > (byte) 0 || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > (byte) 0 || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > (byte) 0 || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > (byte) 0)
              flag2 = true;
          }
          else if (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active && Main.tileSolid[(int) Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type] || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > (byte) 0 || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active && Main.tileSolid[(int) Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type] || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > (byte) 0 || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active && (Main.tileSolid[(int) Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type] || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type == (byte) 124) || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > (byte) 0 || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active && (Main.tileSolid[(int) Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type] || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type == (byte) 124) || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > (byte) 0)
            flag2 = true;
          if (Main.tileAlch[this.inventory[this.selectedItem].createTile])
            flag2 = true;
          if (Main.tile[Player.tileTargetX, Player.tileTargetY].active && Main.tileCut[(int) Main.tile[Player.tileTargetX, Player.tileTargetY].type])
          {
            if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type != (byte) 78)
            {
              WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY);
              if (!Main.tile[Player.tileTargetX, Player.tileTargetY].active && Main.netMode == 1)
                NetMessage.SendData(17, number: 4, number2: ((float) Player.tileTargetX), number3: ((float) Player.tileTargetY));
            }
            else
              flag2 = false;
          }
          if (flag2)
          {
            int num = this.inventory[this.selectedItem].placeStyle;
            if (this.inventory[this.selectedItem].createTile == 141)
              num = Main.rand.Next(2);
            if (this.inventory[this.selectedItem].createTile == 128 || this.inventory[this.selectedItem].createTile == 137)
              num = this.direction >= 0 ? 1 : -1;
            if (WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createTile, plr: this.whoAmi, style: num))
            {
              this.itemTime = this.inventory[this.selectedItem].useTime;
              if (Main.netMode == 1)
                NetMessage.SendData(17, number: 1, number2: ((float) Player.tileTargetX), number3: ((float) Player.tileTargetY), number4: ((float) this.inventory[this.selectedItem].createTile), number5: num);
              if (this.inventory[this.selectedItem].createTile == 15)
              {
                if (this.direction == 1)
                {
                  Main.tile[Player.tileTargetX, Player.tileTargetY].frameX += (short) 18;
                  Main.tile[Player.tileTargetX, Player.tileTargetY - 1].frameX += (short) 18;
                }
                if (Main.netMode == 1)
                  NetMessage.SendTileSquare(-1, Player.tileTargetX - 1, Player.tileTargetY - 1, 3);
              }
              else if ((this.inventory[this.selectedItem].createTile == 79 || this.inventory[this.selectedItem].createTile == 90) && Main.netMode == 1)
                NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 5);
            }
          }
        }
      }
      if (this.inventory[this.selectedItem].createWall < 0 || (double) this.position.X / 16.0 - (double) Player.tileRangeX - (double) this.inventory[this.selectedItem].tileBoost > (double) Player.tileTargetX || ((double) this.position.X + (double) this.width) / 16.0 + (double) Player.tileRangeX + (double) this.inventory[this.selectedItem].tileBoost - 1.0 < (double) Player.tileTargetX || (double) this.position.Y / 16.0 - (double) Player.tileRangeY - (double) this.inventory[this.selectedItem].tileBoost > (double) Player.tileTargetY || ((double) this.position.Y + (double) this.height) / 16.0 + (double) Player.tileRangeY + (double) this.inventory[this.selectedItem].tileBoost - 2.0 < (double) Player.tileTargetY)
        return;
      this.showItemIcon = true;
      if (this.itemTime != 0 || this.itemAnimation <= 0 || !this.controlUseItem || !Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active && Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall <= (byte) 0 && !Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active && Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall <= (byte) 0 && !Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active && Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall <= (byte) 0 && !Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active && Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall <= (byte) 0 || (int) Main.tile[Player.tileTargetX, Player.tileTargetY].wall == this.inventory[this.selectedItem].createWall)
        return;
      WorldGen.PlaceWall(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createWall);
      if ((int) Main.tile[Player.tileTargetX, Player.tileTargetY].wall != this.inventory[this.selectedItem].createWall)
        return;
      this.itemTime = this.inventory[this.selectedItem].useTime;
      if (Main.netMode == 1)
        NetMessage.SendData(17, number: 3, number2: ((float) Player.tileTargetX), number3: ((float) Player.tileTargetY), number4: ((float) this.inventory[this.selectedItem].createWall));
      if (this.inventory[this.selectedItem].stack <= 1)
        return;
      int createWall = this.inventory[this.selectedItem].createWall;
      for (int index4 = 0; index4 < 4; ++index4)
      {
        int tileTargetX = Player.tileTargetX;
        int tileTargetY = Player.tileTargetY;
        if (index4 == 0)
          --tileTargetX;
        if (index4 == 1)
          ++tileTargetX;
        if (index4 == 2)
          --tileTargetY;
        if (index4 == 3)
          ++tileTargetY;
        if (Main.tile[tileTargetX, tileTargetY].wall == (byte) 0)
        {
          int num = 0;
          for (int index5 = 0; index5 < 4; ++index5)
          {
            int index6 = tileTargetX;
            int index7 = tileTargetY;
            if (index5 == 0)
              --index6;
            if (index5 == 1)
              ++index6;
            if (index5 == 2)
              --index7;
            if (index5 == 3)
              ++index7;
            if ((int) Main.tile[index6, index7].wall == createWall)
              ++num;
          }
          if (num == 4)
          {
            WorldGen.PlaceWall(tileTargetX, tileTargetY, createWall);
            if ((int) Main.tile[tileTargetX, tileTargetY].wall == createWall)
            {
              --this.inventory[this.selectedItem].stack;
              if (this.inventory[this.selectedItem].stack == 0)
                this.inventory[this.selectedItem].SetDefaults(0);
              if (Main.netMode == 1)
                NetMessage.SendData(17, number: 3, number2: ((float) tileTargetX), number3: ((float) tileTargetY), number4: ((float) createWall));
            }
          }
        }
      }
    }

    public void ItemCheck(int i)
    {
      int num1 = this.inventory[this.selectedItem].damage;
      if (num1 > 0)
      {
        if (this.inventory[this.selectedItem].melee)
          num1 = (int) ((double) num1 * (double) this.meleeDamage);
        else if (this.inventory[this.selectedItem].ranged)
          num1 = (int) ((double) num1 * (double) this.rangedDamage);
        else if (this.inventory[this.selectedItem].magic)
          num1 = (int) ((double) num1 * (double) this.magicDamage);
      }
      if (this.inventory[this.selectedItem].autoReuse && !this.noItems)
      {
        this.releaseUseItem = true;
        if (this.itemAnimation == 1 && this.inventory[this.selectedItem].stack > 0)
          this.itemAnimation = this.inventory[this.selectedItem].shoot <= 0 || this.whoAmi == Main.myPlayer || !this.controlUseItem ? 0 : 2;
      }
      if (this.itemAnimation == 0 && this.reuseDelay > 0)
      {
        this.itemAnimation = this.reuseDelay;
        this.itemTime = this.reuseDelay;
        this.reuseDelay = 0;
      }
      if (this.controlUseItem && this.releaseUseItem && (this.inventory[this.selectedItem].headSlot > 0 || this.inventory[this.selectedItem].bodySlot > 0 || this.inventory[this.selectedItem].legSlot > 0))
      {
        if (this.inventory[this.selectedItem].useStyle == 0)
          this.releaseUseItem = false;
        if ((double) this.position.X / 16.0 - (double) Player.tileRangeX - (double) this.inventory[this.selectedItem].tileBoost <= (double) Player.tileTargetX && ((double) this.position.X + (double) this.width) / 16.0 + (double) Player.tileRangeX + (double) this.inventory[this.selectedItem].tileBoost - 1.0 >= (double) Player.tileTargetX && (double) this.position.Y / 16.0 - (double) Player.tileRangeY - (double) this.inventory[this.selectedItem].tileBoost <= (double) Player.tileTargetY && ((double) this.position.Y + (double) this.height) / 16.0 + (double) Player.tileRangeY + (double) this.inventory[this.selectedItem].tileBoost - 2.0 >= (double) Player.tileTargetY)
        {
          int tileTargetX = Player.tileTargetX;
          int tileTargetY = Player.tileTargetY;
          if (Main.tile[tileTargetX, tileTargetY].active && Main.tile[tileTargetX, tileTargetY].type == (byte) 128)
          {
            int frameY = (int) Main.tile[tileTargetX, tileTargetY].frameY;
            int num2 = 0;
            if (this.inventory[this.selectedItem].bodySlot >= 0)
              num2 = 1;
            if (this.inventory[this.selectedItem].legSlot >= 0)
              num2 = 2;
            int num3;
            for (num3 = frameY / 18; num2 > num3; num3 = (int) Main.tile[tileTargetX, tileTargetY].frameY / 18)
              ++tileTargetY;
            for (; num2 < num3; num3 = (int) Main.tile[tileTargetX, tileTargetY].frameY / 18)
              --tileTargetY;
            int frameX1 = (int) Main.tile[tileTargetX, tileTargetY].frameX;
            while (frameX1 >= 100)
              frameX1 -= 100;
            if (frameX1 >= 36)
              frameX1 -= 36;
            int index = tileTargetX - frameX1 / 18;
            int frameX2 = (int) Main.tile[index, tileTargetY].frameX;
            WorldGen.KillTile(index, tileTargetY, true);
            if (Main.netMode == 1)
              NetMessage.SendData(17, number2: ((float) index), number3: ((float) tileTargetY), number4: 1f);
            while (frameX2 >= 100)
              frameX2 -= 100;
            if (num3 == 0 && this.inventory[this.selectedItem].headSlot >= 0)
            {
              Main.tile[index, tileTargetY].frameX = (short) (frameX2 + this.inventory[this.selectedItem].headSlot * 100);
              if (Main.netMode == 1)
                NetMessage.SendTileSquare(-1, index, tileTargetY, 1);
              this.inventory[this.selectedItem].SetDefaults(0);
              Main.mouseItem.SetDefaults(0);
              this.releaseUseItem = false;
              this.mouseInterface = true;
            }
            else if (num3 == 1 && this.inventory[this.selectedItem].bodySlot >= 0)
            {
              Main.tile[index, tileTargetY].frameX = (short) (frameX2 + this.inventory[this.selectedItem].bodySlot * 100);
              if (Main.netMode == 1)
                NetMessage.SendTileSquare(-1, index, tileTargetY, 1);
              this.inventory[this.selectedItem].SetDefaults(0);
              Main.mouseItem.SetDefaults(0);
              this.releaseUseItem = false;
              this.mouseInterface = true;
            }
            else if (num3 == 2 && this.inventory[this.selectedItem].legSlot >= 0)
            {
              Main.tile[index, tileTargetY].frameX = (short) (frameX2 + this.inventory[this.selectedItem].legSlot * 100);
              if (Main.netMode == 1)
                NetMessage.SendTileSquare(-1, index, tileTargetY, 1);
              this.inventory[this.selectedItem].SetDefaults(0);
              Main.mouseItem.SetDefaults(0);
              this.releaseUseItem = false;
              this.mouseInterface = true;
            }
          }
        }
      }
      if (this.controlUseItem && this.itemAnimation == 0 && this.releaseUseItem && this.inventory[this.selectedItem].useStyle > 0)
      {
        bool flag = true;
        if (this.inventory[this.selectedItem].shoot == 0)
          this.itemRotation = 0.0f;
        if (this.wet && (this.inventory[this.selectedItem].shoot == 85 || this.inventory[this.selectedItem].shoot == 15 || this.inventory[this.selectedItem].shoot == 34))
          flag = false;
        if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 603 && !Main.cEd)
          flag = false;
        if (this.noItems)
          flag = false;
        if (this.inventory[this.selectedItem].shoot == 6 || this.inventory[this.selectedItem].shoot == 19 || this.inventory[this.selectedItem].shoot == 33 || this.inventory[this.selectedItem].shoot == 52)
        {
          for (int index = 0; index < 1000; ++index)
          {
            if (Main.projectile[index].active && Main.projectile[index].owner == Main.myPlayer && Main.projectile[index].type == this.inventory[this.selectedItem].shoot)
              flag = false;
          }
        }
        if (this.inventory[this.selectedItem].shoot == 106)
        {
          int num4 = 0;
          for (int index = 0; index < 1000; ++index)
          {
            if (Main.projectile[index].active && Main.projectile[index].owner == Main.myPlayer && Main.projectile[index].type == this.inventory[this.selectedItem].shoot)
              ++num4;
          }
          if (num4 >= this.inventory[this.selectedItem].stack)
            flag = false;
        }
        if (this.inventory[this.selectedItem].shoot == 13 || this.inventory[this.selectedItem].shoot == 32)
        {
          for (int index = 0; index < 1000; ++index)
          {
            if (Main.projectile[index].active && Main.projectile[index].owner == Main.myPlayer && Main.projectile[index].type == this.inventory[this.selectedItem].shoot && (double) Main.projectile[index].ai[0] != 2.0)
              flag = false;
          }
        }
        if (this.inventory[this.selectedItem].shoot == 73)
        {
          for (int index = 0; index < 1000; ++index)
          {
            if (Main.projectile[index].active && Main.projectile[index].owner == Main.myPlayer && Main.projectile[index].type == 74)
              flag = false;
          }
        }
        if (this.inventory[this.selectedItem].potion && flag)
        {
          if (this.potionDelay <= 0)
          {
            this.potionDelay = this.potionDelayTime;
            this.AddBuff(21, this.potionDelay);
          }
          else
            flag = false;
        }
        if (this.inventory[this.selectedItem].mana > 0 && this.silence)
          flag = false;
        if (this.inventory[this.selectedItem].mana > 0 && flag)
        {
          if (this.inventory[this.selectedItem].type != (int) sbyte.MaxValue || !this.spaceGun)
          {
            if (this.statMana >= (int) ((double) this.inventory[this.selectedItem].mana * (double) this.manaCost))
              this.statMana -= (int) ((double) this.inventory[this.selectedItem].mana * (double) this.manaCost);
            else if (this.manaFlower)
            {
              this.QuickMana();
              if (this.statMana >= (int) ((double) this.inventory[this.selectedItem].mana * (double) this.manaCost))
                this.statMana -= (int) ((double) this.inventory[this.selectedItem].mana * (double) this.manaCost);
              else
                flag = false;
            }
            else
              flag = false;
          }
          if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].buffType != 0)
            this.AddBuff(this.inventory[this.selectedItem].buffType, this.inventory[this.selectedItem].buffTime);
        }
        if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 603 && Main.cEd)
          this.AddBuff(this.inventory[this.selectedItem].buffType, 3600);
        if (this.inventory[this.selectedItem].type == 43 && Main.dayTime)
          flag = false;
        if (this.inventory[this.selectedItem].type == 544 && Main.dayTime)
          flag = false;
        if (this.inventory[this.selectedItem].type == 556 && Main.dayTime)
          flag = false;
        if (this.inventory[this.selectedItem].type == 557 && Main.dayTime)
          flag = false;
        if (this.inventory[this.selectedItem].type == 70 && !this.zoneEvil)
          flag = false;
        if (this.inventory[this.selectedItem].shoot == 17 && flag && i == Main.myPlayer)
        {
          int i1 = (int) ((double) Main.mouseX + (double) Main.screenPosition.X) / 16;
          int j = (int) ((double) Main.mouseY + (double) Main.screenPosition.Y) / 16;
          if (Main.tile[i1, j].active && (Main.tile[i1, j].type == (byte) 0 || Main.tile[i1, j].type == (byte) 2 || Main.tile[i1, j].type == (byte) 23))
          {
            WorldGen.KillTile(i1, j, noItem: true);
            if (!Main.tile[i1, j].active)
            {
              if (Main.netMode == 1)
                NetMessage.SendData(17, number: 4, number2: ((float) i1), number3: ((float) j));
            }
            else
              flag = false;
          }
          else
            flag = false;
        }
        if (flag && this.inventory[this.selectedItem].useAmmo > 0)
        {
          flag = false;
          for (int index = 0; index < 48; ++index)
          {
            if (this.inventory[index].ammo == this.inventory[this.selectedItem].useAmmo && this.inventory[index].stack > 0)
            {
              flag = true;
              break;
            }
          }
        }
        if (flag)
        {
          if (this.inventory[this.selectedItem].pick > 0 || this.inventory[this.selectedItem].axe > 0 || this.inventory[this.selectedItem].hammer > 0)
            this.toolTime = 1;
          if (this.grappling[0] > -1)
          {
            if (this.controlRight)
              this.direction = 1;
            else if (this.controlLeft)
              this.direction = -1;
          }
          this.channel = this.inventory[this.selectedItem].channel;
          this.attackCD = 0;
          if (this.inventory[this.selectedItem].melee)
          {
            this.itemAnimation = (int) ((double) this.inventory[this.selectedItem].useAnimation * (double) this.meleeSpeed);
            this.itemAnimationMax = (int) ((double) this.inventory[this.selectedItem].useAnimation * (double) this.meleeSpeed);
          }
          else
          {
            this.itemAnimation = this.inventory[this.selectedItem].useAnimation;
            this.itemAnimationMax = this.inventory[this.selectedItem].useAnimation;
            this.reuseDelay = this.inventory[this.selectedItem].reuseDelay;
          }
          if (this.inventory[this.selectedItem].useSound > 0)
            Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, this.inventory[this.selectedItem].useSound);
        }
        if (flag && (this.inventory[this.selectedItem].shoot == 18 || this.inventory[this.selectedItem].shoot == 72 || this.inventory[this.selectedItem].shoot == 86 || this.inventory[this.selectedItem].shoot == 86 || this.inventory[this.selectedItem].shoot == 111))
        {
          for (int index = 0; index < 1000; ++index)
          {
            if (Main.projectile[index].active && Main.projectile[index].owner == i && Main.projectile[index].type == this.inventory[this.selectedItem].shoot)
              Main.projectile[index].Kill();
            if (this.inventory[this.selectedItem].shoot == 72)
            {
              if (Main.projectile[index].active && Main.projectile[index].owner == i && Main.projectile[index].type == 86)
                Main.projectile[index].Kill();
              if (Main.projectile[index].active && Main.projectile[index].owner == i && Main.projectile[index].type == 87)
                Main.projectile[index].Kill();
            }
          }
        }
      }
      if (!this.controlUseItem)
      {
        int num5 = this.channel ? 1 : 0;
        this.channel = false;
      }
      if (this.itemAnimation > 0)
      {
        this.itemAnimationMax = !this.inventory[this.selectedItem].melee ? this.inventory[this.selectedItem].useAnimation : (int) ((double) this.inventory[this.selectedItem].useAnimation * (double) this.meleeSpeed);
        if (this.inventory[this.selectedItem].mana > 0)
          this.manaRegenDelay = (int) this.maxRegenDelay;
        if (Main.dedServ)
        {
          this.itemHeight = this.inventory[this.selectedItem].height;
          this.itemWidth = this.inventory[this.selectedItem].width;
        }
        else
        {
          this.itemHeight = Main.itemTexture[this.inventory[this.selectedItem].type].Height;
          this.itemWidth = Main.itemTexture[this.inventory[this.selectedItem].type].Width;
        }
        --this.itemAnimation;
        if (!Main.dedServ)
        {
          if (this.inventory[this.selectedItem].useStyle == 1)
          {
            if ((double) this.itemAnimation < (double) this.itemAnimationMax * 0.333)
            {
              float num6 = 10f;
              if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 32)
                num6 = 14f;
              if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 64)
                num6 = 28f;
              this.itemLocation.X = (float) ((double) this.position.X + (double) this.width * 0.5 + ((double) Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5 - (double) num6) * (double) this.direction);
              this.itemLocation.Y = this.position.Y + 24f;
            }
            else if ((double) this.itemAnimation < (double) this.itemAnimationMax * 0.666)
            {
              float num7 = 10f;
              if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 32)
                num7 = 18f;
              if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 64)
                num7 = 28f;
              this.itemLocation.X = (float) ((double) this.position.X + (double) this.width * 0.5 + ((double) Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5 - (double) num7) * (double) this.direction);
              float num8 = 10f;
              if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 32)
                num8 = 8f;
              if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 64)
                num8 = 14f;
              this.itemLocation.Y = this.position.Y + num8;
            }
            else
            {
              float num9 = 6f;
              if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 32)
                num9 = 14f;
              if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 64)
                num9 = 28f;
              this.itemLocation.X = (float) ((double) this.position.X + (double) this.width * 0.5 - ((double) Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5 - (double) num9) * (double) this.direction);
              float num10 = 10f;
              if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 32)
                num10 = 10f;
              if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 64)
                num10 = 14f;
              this.itemLocation.Y = this.position.Y + num10;
            }
            this.itemRotation = (float) (((double) this.itemAnimation / (double) this.itemAnimationMax - 0.5) * (double) -this.direction * 3.5 - (double) this.direction * 0.300000011920929);
            if ((double) this.gravDir == -1.0)
            {
              this.itemRotation = -this.itemRotation;
              this.itemLocation.Y = (float) ((double) this.position.Y + (double) this.height + ((double) this.position.Y - (double) this.itemLocation.Y));
            }
          }
          else if (this.inventory[this.selectedItem].useStyle == 2)
          {
            this.itemRotation = (float) ((double) this.itemAnimation / (double) this.itemAnimationMax * (double) this.direction * 2.0 + -1.39999997615814 * (double) this.direction);
            if ((double) this.itemAnimation < (double) this.itemAnimationMax * 0.5)
            {
              this.itemLocation.X = (float) ((double) this.position.X + (double) this.width * 0.5 + ((double) Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5 - 9.0 - (double) this.itemRotation * 12.0 * (double) this.direction) * (double) this.direction);
              this.itemLocation.Y = (float) ((double) this.position.Y + 38.0 + (double) this.itemRotation * (double) this.direction * 4.0);
            }
            else
            {
              this.itemLocation.X = (float) ((double) this.position.X + (double) this.width * 0.5 + ((double) Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5 - 9.0 - (double) this.itemRotation * 16.0 * (double) this.direction) * (double) this.direction);
              this.itemLocation.Y = (float) ((double) this.position.Y + 38.0 + (double) this.itemRotation * (double) this.direction);
            }
            if ((double) this.gravDir == -1.0)
            {
              this.itemRotation = -this.itemRotation;
              this.itemLocation.Y = (float) ((double) this.position.Y + (double) this.height + ((double) this.position.Y - (double) this.itemLocation.Y));
            }
          }
          else if (this.inventory[this.selectedItem].useStyle == 3)
          {
            if ((double) this.itemAnimation > (double) this.itemAnimationMax * 0.666)
            {
              this.itemLocation.X = -1000f;
              this.itemLocation.Y = -1000f;
              this.itemRotation = -1.3f * (float) this.direction;
            }
            else
            {
              this.itemLocation.X = (float) ((double) this.position.X + (double) this.width * 0.5 + ((double) Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5 - 4.0) * (double) this.direction);
              this.itemLocation.Y = this.position.Y + 24f;
              float num11 = (float) ((double) this.itemAnimation / (double) this.itemAnimationMax * (double) Main.itemTexture[this.inventory[this.selectedItem].type].Width * (double) this.direction * (double) this.inventory[this.selectedItem].scale * 1.20000004768372) - (float) (10 * this.direction);
              if ((double) num11 > -4.0 && this.direction == -1)
                num11 = -8f;
              if ((double) num11 < 4.0 && this.direction == 1)
                num11 = 8f;
              this.itemLocation.X -= num11;
              this.itemRotation = 0.8f * (float) this.direction;
            }
            if ((double) this.gravDir == -1.0)
            {
              this.itemRotation = -this.itemRotation;
              this.itemLocation.Y = (float) ((double) this.position.Y + (double) this.height + ((double) this.position.Y - (double) this.itemLocation.Y));
            }
          }
          else if (this.inventory[this.selectedItem].useStyle == 4)
          {
            this.itemRotation = 0.0f;
            this.itemLocation.X = (float) ((double) this.position.X + (double) this.width * 0.5 + ((double) Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5 - 9.0 - (double) this.itemRotation * 14.0 * (double) this.direction - 4.0) * (double) this.direction);
            this.itemLocation.Y = (float) ((double) this.position.Y + (double) Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5 + 4.0);
            if ((double) this.gravDir == -1.0)
            {
              this.itemRotation = -this.itemRotation;
              this.itemLocation.Y = (float) ((double) this.position.Y + (double) this.height + ((double) this.position.Y - (double) this.itemLocation.Y));
            }
          }
          else if (this.inventory[this.selectedItem].useStyle == 5)
          {
            this.itemLocation.X = (float) ((double) this.position.X + (double) this.width * 0.5 - (double) Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5) - (float) (this.direction * 2);
            this.itemLocation.Y = (float) ((double) this.position.Y + (double) this.height * 0.5 - (double) Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5);
          }
        }
      }
      else if (this.inventory[this.selectedItem].holdStyle == 1)
      {
        if (Main.dedServ)
        {
          this.itemLocation.X = (float) ((double) this.position.X + (double) this.width * 0.5 + 20.0 * (double) this.direction);
        }
        else
        {
          this.itemLocation.X = (float) ((double) this.position.X + (double) this.width * 0.5 + ((double) Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5 + 2.0) * (double) this.direction);
          if (this.inventory[this.selectedItem].type == 282 || this.inventory[this.selectedItem].type == 286)
          {
            this.itemLocation.X -= (float) (this.direction * 2);
            this.itemLocation.Y += 4f;
          }
        }
        this.itemLocation.Y = this.position.Y + 24f;
        this.itemRotation = 0.0f;
        if ((double) this.gravDir == -1.0)
        {
          this.itemRotation = -this.itemRotation;
          this.itemLocation.Y = (float) ((double) this.position.Y + (double) this.height + ((double) this.position.Y - (double) this.itemLocation.Y));
        }
      }
      else if (this.inventory[this.selectedItem].holdStyle == 2)
      {
        this.itemLocation.X = this.position.X + (float) this.width * 0.5f + (float) (6 * this.direction);
        this.itemLocation.Y = this.position.Y + 16f;
        this.itemRotation = 0.79f * (float) -this.direction;
        if ((double) this.gravDir == -1.0)
        {
          this.itemRotation = -this.itemRotation;
          this.itemLocation.Y = (float) ((double) this.position.Y + (double) this.height + ((double) this.position.Y - (double) this.itemLocation.Y));
        }
      }
      else if (this.inventory[this.selectedItem].holdStyle == 3 && !Main.dedServ)
      {
        this.itemLocation.X = (float) ((double) this.position.X + (double) this.width * 0.5 - (double) Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5) - (float) (this.direction * 2);
        this.itemLocation.Y = (float) ((double) this.position.Y + (double) this.height * 0.5 - (double) Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5);
        this.itemRotation = 0.0f;
      }
      if ((this.inventory[this.selectedItem].type == 8 || this.inventory[this.selectedItem].type >= 427 && this.inventory[this.selectedItem].type <= 433) && !this.wet || this.inventory[this.selectedItem].type == 523)
      {
        float R = 1f;
        float G = 0.95f;
        float B = 0.8f;
        int num12 = 0;
        if (this.inventory[this.selectedItem].type == 523)
          num12 = 8;
        else if (this.inventory[this.selectedItem].type >= 427)
          num12 = this.inventory[this.selectedItem].type - 426;
        switch (num12)
        {
          case 1:
            R = 0.0f;
            G = 0.1f;
            B = 1.3f;
            break;
          case 2:
            R = 1f;
            G = 0.1f;
            B = 0.1f;
            break;
          case 3:
            R = 0.0f;
            G = 1f;
            B = 0.1f;
            break;
          case 4:
            R = 0.9f;
            G = 0.0f;
            B = 0.9f;
            break;
          case 5:
            R = 1.3f;
            G = 1.3f;
            B = 1.3f;
            break;
          case 6:
            R = 0.9f;
            G = 0.9f;
            B = 0.0f;
            break;
          case 7:
            R = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
            G = 0.3f;
            B = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
            break;
          case 8:
            B = 0.7f;
            R = 0.85f;
            G = 1f;
            break;
        }
        int num13 = num12;
        int Type;
        switch (num13)
        {
          case 0:
            Type = 6;
            break;
          case 8:
            Type = 75;
            break;
          default:
            Type = 58 + num13;
            break;
        }
        int maxValue = 20;
        if (this.itemAnimation > 0)
          maxValue = 7;
        if (this.direction == -1)
        {
          if (Main.rand.Next(maxValue) == 0)
            Dust.NewDust(new Vector2(this.itemLocation.X - 16f, this.itemLocation.Y - 14f * this.gravDir), 4, 4, Type, Alpha: 100);
          Lighting.addLight((int) (((double) this.itemLocation.X - 12.0 + (double) this.velocity.X) / 16.0), (int) (((double) this.itemLocation.Y - 14.0 + (double) this.velocity.Y) / 16.0), R, G, B);
        }
        else
        {
          if (Main.rand.Next(maxValue) == 0)
            Dust.NewDust(new Vector2(this.itemLocation.X + 6f, this.itemLocation.Y - 14f * this.gravDir), 4, 4, Type, Alpha: 100);
          Lighting.addLight((int) (((double) this.itemLocation.X + 12.0 + (double) this.velocity.X) / 16.0), (int) (((double) this.itemLocation.Y - 14.0 + (double) this.velocity.Y) / 16.0), R, G, B);
        }
      }
      if (this.inventory[this.selectedItem].type == 105 && !this.wet)
      {
        int maxValue = 20;
        if (this.itemAnimation > 0)
          maxValue = 7;
        if (this.direction == -1)
        {
          if (Main.rand.Next(maxValue) == 0)
            Dust.NewDust(new Vector2(this.itemLocation.X - 12f, this.itemLocation.Y - 20f * this.gravDir), 4, 4, 6, Alpha: 100);
          Lighting.addLight((int) (((double) this.itemLocation.X - 16.0 + (double) this.velocity.X) / 16.0), (int) (((double) this.itemLocation.Y - 14.0) / 16.0), 1f, 0.95f, 0.8f);
        }
        else
        {
          if (Main.rand.Next(maxValue) == 0)
            Dust.NewDust(new Vector2(this.itemLocation.X + 4f, this.itemLocation.Y - 20f * this.gravDir), 4, 4, 6, Alpha: 100);
          Lighting.addLight((int) (((double) this.itemLocation.X + 6.0 + (double) this.velocity.X) / 16.0), (int) (((double) this.itemLocation.Y - 14.0) / 16.0), 1f, 0.95f, 0.8f);
        }
      }
      else if (this.inventory[this.selectedItem].type == 148 && !this.wet)
      {
        int maxValue = 10;
        if (this.itemAnimation > 0)
          maxValue = 7;
        if (this.direction == -1)
        {
          if (Main.rand.Next(maxValue) == 0)
            Dust.NewDust(new Vector2(this.itemLocation.X - 12f, this.itemLocation.Y - 20f * this.gravDir), 4, 4, 29, Alpha: 100);
          Lighting.addLight((int) (((double) this.itemLocation.X - 16.0 + (double) this.velocity.X) / 16.0), (int) (((double) this.itemLocation.Y - 14.0) / 16.0), 0.3f, 0.3f, 0.75f);
        }
        else
        {
          if (Main.rand.Next(maxValue) == 0)
            Dust.NewDust(new Vector2(this.itemLocation.X + 4f, this.itemLocation.Y - 20f * this.gravDir), 4, 4, 29, Alpha: 100);
          Lighting.addLight((int) (((double) this.itemLocation.X + 6.0 + (double) this.velocity.X) / 16.0), (int) (((double) this.itemLocation.Y - 14.0) / 16.0), 0.3f, 0.3f, 0.75f);
        }
      }
      if (this.inventory[this.selectedItem].type == 282)
      {
        if (this.direction == -1)
          Lighting.addLight((int) (((double) this.itemLocation.X - 16.0 + (double) this.velocity.X) / 16.0), (int) (((double) this.itemLocation.Y - 14.0) / 16.0), 0.7f, 1f, 0.8f);
        else
          Lighting.addLight((int) (((double) this.itemLocation.X + 6.0 + (double) this.velocity.X) / 16.0), (int) (((double) this.itemLocation.Y - 14.0) / 16.0), 0.7f, 1f, 0.8f);
      }
      if (this.inventory[this.selectedItem].type == 286)
      {
        if (this.direction == -1)
          Lighting.addLight((int) (((double) this.itemLocation.X - 16.0 + (double) this.velocity.X) / 16.0), (int) (((double) this.itemLocation.Y - 14.0) / 16.0), 0.7f, 0.8f, 1f);
        else
          Lighting.addLight((int) (((double) this.itemLocation.X + 6.0 + (double) this.velocity.X) / 16.0), (int) (((double) this.itemLocation.Y - 14.0) / 16.0), 0.7f, 0.8f, 1f);
      }
      this.releaseUseItem = !this.controlUseItem;
      if (this.itemTime > 0)
        --this.itemTime;
      if (i == Main.myPlayer)
      {
        if (this.inventory[this.selectedItem].shoot > 0 && this.itemAnimation > 0 && this.itemTime == 0)
        {
          int Type1 = this.inventory[this.selectedItem].shoot;
          float num14 = this.inventory[this.selectedItem].shootSpeed;
          if (this.inventory[this.selectedItem].melee && Type1 != 25 && Type1 != 26 && Type1 != 35)
            num14 /= this.meleeSpeed;
          bool flag1 = false;
          int Damage = num1;
          float KnockBack = this.inventory[this.selectedItem].knockBack;
          if (Type1 == 13 || Type1 == 32)
          {
            this.grappling[0] = -1;
            this.grapCount = 0;
            for (int index = 0; index < 1000; ++index)
            {
              if (Main.projectile[index].active && Main.projectile[index].owner == i && Main.projectile[index].type == 13)
                Main.projectile[index].Kill();
            }
          }
          if (this.inventory[this.selectedItem].useAmmo > 0)
          {
            Item obj = new Item();
            bool flag2 = false;
            for (int index = 44; index < 48; ++index)
            {
              if (this.inventory[index].ammo == this.inventory[this.selectedItem].useAmmo && this.inventory[index].stack > 0)
              {
                obj = this.inventory[index];
                flag1 = true;
                flag2 = true;
                break;
              }
            }
            if (!flag2)
            {
              for (int index = 0; index < 44; ++index)
              {
                if (this.inventory[index].ammo == this.inventory[this.selectedItem].useAmmo && this.inventory[index].stack > 0)
                {
                  obj = this.inventory[index];
                  flag1 = true;
                  break;
                }
              }
            }
            if (flag1)
            {
              if (obj.shoot > 0)
                Type1 = obj.shoot;
              if (Type1 == 42)
              {
                if (obj.type == 370)
                {
                  Type1 = 65;
                  Damage += 5;
                }
                else if (obj.type == 408)
                {
                  Type1 = 68;
                  Damage += 5;
                }
              }
              num14 += obj.shootSpeed;
              if (obj.ranged)
              {
                if (obj.damage > 0)
                  Damage += (int) ((double) obj.damage * (double) this.rangedDamage);
              }
              else
                Damage += obj.damage;
              if (this.inventory[this.selectedItem].useAmmo == 1 && this.archery)
              {
                if ((double) num14 < 20.0)
                {
                  num14 *= 1.2f;
                  if ((double) num14 > 20.0)
                    num14 = 20f;
                }
                Damage = (int) ((double) Damage * 1.2);
              }
              KnockBack += obj.knockBack;
              bool flag3 = false;
              if (this.inventory[this.selectedItem].type == 98 && Main.rand.Next(3) == 0)
                flag3 = true;
              if (this.inventory[this.selectedItem].type == 533 && Main.rand.Next(2) == 0)
                flag3 = true;
              if (this.inventory[this.selectedItem].type == 434 && this.itemAnimation < this.inventory[this.selectedItem].useAnimation - 2)
                flag3 = true;
              if (this.ammoCost80 && Main.rand.Next(5) == 0)
                flag3 = true;
              if (this.ammoCost75 && Main.rand.Next(4) == 0)
                flag3 = true;
              if (Type1 == 85 && this.itemAnimation < this.itemAnimationMax - 6)
                flag3 = true;
              if (!flag3)
              {
                --obj.stack;
                if (obj.stack <= 0)
                {
                  obj.active = false;
                  obj.name = "";
                  obj.type = 0;
                }
              }
            }
          }
          else
            flag1 = true;
          if (Type1 == 72)
          {
            switch (Main.rand.Next(3))
            {
              case 0:
                Type1 = 72;
                break;
              case 1:
                Type1 = 86;
                break;
              case 2:
                Type1 = 87;
                break;
            }
          }
          if (Type1 == 73)
          {
            for (int index = 0; index < 1000; ++index)
            {
              if (Main.projectile[index].active && Main.projectile[index].owner == i)
              {
                if (Main.projectile[index].type == 73)
                  Type1 = 74;
                if (Main.projectile[index].type == 74)
                  flag1 = false;
              }
            }
          }
          if (flag1)
          {
            if (this.inventory[this.selectedItem].mech && this.kbGlove)
              KnockBack *= 1.7f;
            if (Type1 == 1 && this.inventory[this.selectedItem].type == 120)
              Type1 = 2;
            this.itemTime = this.inventory[this.selectedItem].useTime;
            this.direction = (double) Main.mouseX + (double) Main.screenPosition.X <= (double) this.position.X + (double) this.width * 0.5 ? -1 : 1;
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            switch (Type1)
            {
              case 9:
                vector2 = new Vector2(this.position.X + (float) this.width * 0.5f + (float) (Main.rand.Next(601) * -this.direction), (float) ((double) this.position.Y + (double) this.height * 0.5 - 300.0) - (float) Main.rand.Next(100));
                KnockBack = 0.0f;
                break;
              case 51:
                vector2.Y -= 6f * this.gravDir;
                break;
            }
            float num15 = (float) Main.mouseX + Main.screenPosition.X - vector2.X;
            float num16 = (float) Main.mouseY + Main.screenPosition.Y - vector2.Y;
            float num17 = (float) Math.Sqrt((double) num15 * (double) num15 + (double) num16 * (double) num16);
            float num18 = num17;
            float num19 = num14 / num17;
            float SpeedX1 = num15 * num19;
            float SpeedY1 = num16 * num19;
            if (Type1 == 12)
            {
              vector2.X += SpeedX1 * 3f;
              vector2.Y += SpeedY1 * 3f;
            }
            if (this.inventory[this.selectedItem].useStyle == 5)
            {
              this.itemRotation = (float) Math.Atan2((double) SpeedY1 * (double) this.direction, (double) SpeedX1 * (double) this.direction);
              NetMessage.SendData(13, number: this.whoAmi);
              NetMessage.SendData(41, number: this.whoAmi);
            }
            if (Type1 == 17)
            {
              vector2.X = (float) Main.mouseX + Main.screenPosition.X;
              vector2.Y = (float) Main.mouseY + Main.screenPosition.Y;
            }
            if (Type1 == 76)
            {
              int Type2 = Type1 + Main.rand.Next(3);
              float num20 = num18 / (float) (Main.screenHeight / 2);
              if ((double) num20 > 1.0)
                num20 = 1f;
              float num21 = SpeedX1 + (float) Main.rand.Next(-40, 41) * 0.01f;
              float num22 = SpeedY1 + (float) Main.rand.Next(-40, 41) * 0.01f;
              float SpeedX2 = num21 * (num20 + 0.25f);
              float SpeedY2 = num22 * (num20 + 0.25f);
              int number = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX2, SpeedY2, Type2, Damage, KnockBack, i);
              Main.projectile[number].ai[1] = 1f;
              float num23 = (float) ((double) num20 * 2.0 - 1.0);
              if ((double) num23 < -1.0)
                num23 = -1f;
              if ((double) num23 > 1.0)
                num23 = 1f;
              Main.projectile[number].ai[0] = num23;
              NetMessage.SendData(27, number: number);
            }
            else if (this.inventory[this.selectedItem].type == 98 || this.inventory[this.selectedItem].type == 533)
            {
              float SpeedX3 = SpeedX1 + (float) Main.rand.Next(-40, 41) * 0.01f;
              float SpeedY3 = SpeedY1 + (float) Main.rand.Next(-40, 41) * 0.01f;
              Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX3, SpeedY3, Type1, Damage, KnockBack, i);
            }
            else if (this.inventory[this.selectedItem].type == 518)
            {
              float num24 = SpeedX1;
              float num25 = SpeedY1;
              float SpeedX4 = num24 + (float) Main.rand.Next(-40, 41) * 0.04f;
              float SpeedY4 = num25 + (float) Main.rand.Next(-40, 41) * 0.04f;
              Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX4, SpeedY4, Type1, Damage, KnockBack, i);
            }
            else if (this.inventory[this.selectedItem].type == 534)
            {
              for (int index = 0; index < 4; ++index)
              {
                float num26 = SpeedX1;
                float num27 = SpeedY1;
                float SpeedX5 = num26 + (float) Main.rand.Next(-40, 41) * 0.05f;
                float SpeedY5 = num27 + (float) Main.rand.Next(-40, 41) * 0.05f;
                Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX5, SpeedY5, Type1, Damage, KnockBack, i);
              }
            }
            else if (this.inventory[this.selectedItem].type == 434)
            {
              float SpeedX6 = SpeedX1;
              float SpeedY6 = SpeedY1;
              if (this.itemAnimation < 5)
              {
                float num28 = SpeedX6 + (float) Main.rand.Next(-40, 41) * 0.01f;
                float num29 = SpeedY6 + (float) Main.rand.Next(-40, 41) * 0.01f;
                SpeedX6 = num28 * 1.1f;
                SpeedY6 = num29 * 1.1f;
              }
              else if (this.itemAnimation < 10)
              {
                float num30 = SpeedX6 + (float) Main.rand.Next(-20, 21) * 0.01f;
                float num31 = SpeedY6 + (float) Main.rand.Next(-20, 21) * 0.01f;
                SpeedX6 = num30 * 1.05f;
                SpeedY6 = num31 * 1.05f;
              }
              Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX6, SpeedY6, Type1, Damage, KnockBack, i);
            }
            else
            {
              int index = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX1, SpeedY1, Type1, Damage, KnockBack, i);
              if (Type1 == 80)
              {
                Main.projectile[index].ai[0] = (float) Player.tileTargetX;
                Main.projectile[index].ai[1] = (float) Player.tileTargetY;
              }
            }
          }
          else if (this.inventory[this.selectedItem].useStyle == 5)
          {
            this.itemRotation = 0.0f;
            NetMessage.SendData(41, number: this.whoAmi);
          }
        }
        if (this.whoAmi == Main.myPlayer && (this.inventory[this.selectedItem].type == 509 || this.inventory[this.selectedItem].type == 510) && (double) this.position.X / 16.0 - (double) Player.tileRangeX - (double) this.inventory[this.selectedItem].tileBoost - (double) this.blockRange <= (double) Player.tileTargetX && ((double) this.position.X + (double) this.width) / 16.0 + (double) Player.tileRangeX + (double) this.inventory[this.selectedItem].tileBoost - 1.0 + (double) this.blockRange >= (double) Player.tileTargetX && (double) this.position.Y / 16.0 - (double) Player.tileRangeY - (double) this.inventory[this.selectedItem].tileBoost - (double) this.blockRange <= (double) Player.tileTargetY && ((double) this.position.Y + (double) this.height) / 16.0 + (double) Player.tileRangeY + (double) this.inventory[this.selectedItem].tileBoost - 2.0 + (double) this.blockRange >= (double) Player.tileTargetY)
        {
          this.showItemIcon = true;
          if (this.itemAnimation > 0 && this.itemTime == 0 && this.controlUseItem)
          {
            int tileTargetX = Player.tileTargetX;
            int tileTargetY = Player.tileTargetY;
            if (this.inventory[this.selectedItem].type == 509)
            {
              int index1 = -1;
              for (int index2 = 0; index2 < 48; ++index2)
              {
                if (this.inventory[index2].stack > 0 && this.inventory[index2].type == 530)
                {
                  index1 = index2;
                  break;
                }
              }
              if (index1 >= 0 && WorldGen.PlaceWire(tileTargetX, tileTargetY))
              {
                --this.inventory[index1].stack;
                if (this.inventory[index1].stack <= 0)
                  this.inventory[index1].SetDefaults(0);
                this.itemTime = this.inventory[this.selectedItem].useTime;
                NetMessage.SendData(17, number: 5, number2: ((float) Player.tileTargetX), number3: ((float) Player.tileTargetY));
              }
            }
            else if (WorldGen.KillWire(tileTargetX, tileTargetY))
            {
              this.itemTime = this.inventory[this.selectedItem].useTime;
              NetMessage.SendData(17, number: 6, number2: ((float) Player.tileTargetX), number3: ((float) Player.tileTargetY));
            }
          }
        }
        if (this.itemAnimation > 0 && this.itemTime == 0 && (this.inventory[this.selectedItem].type == 507 || this.inventory[this.selectedItem].type == 508))
        {
          this.itemTime = this.inventory[this.selectedItem].useTime;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num32 = (float) Main.mouseX + Main.screenPosition.X - vector2.X;
          float num33 = (float) Main.mouseY + Main.screenPosition.Y - vector2.Y;
          float num34 = (float) Math.Sqrt((double) num32 * (double) num32 + (double) num33 * (double) num33) / (float) (Main.screenHeight / 2);
          if ((double) num34 > 1.0)
            num34 = 1f;
          float number2 = (float) ((double) num34 * 2.0 - 1.0);
          if ((double) number2 < -1.0)
            number2 = -1f;
          if ((double) number2 > 1.0)
            number2 = 1f;
          Main.harpNote = number2;
          int Style = 26;
          if (this.inventory[this.selectedItem].type == 507)
            Style = 35;
          Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, Style);
          NetMessage.SendData(58, number: this.whoAmi, number2: number2);
        }
        if (this.inventory[this.selectedItem].type >= 205 && this.inventory[this.selectedItem].type <= 207 && (double) this.position.X / 16.0 - (double) Player.tileRangeX - (double) this.inventory[this.selectedItem].tileBoost <= (double) Player.tileTargetX && ((double) this.position.X + (double) this.width) / 16.0 + (double) Player.tileRangeX + (double) this.inventory[this.selectedItem].tileBoost - 1.0 >= (double) Player.tileTargetX && (double) this.position.Y / 16.0 - (double) Player.tileRangeY - (double) this.inventory[this.selectedItem].tileBoost <= (double) Player.tileTargetY && ((double) this.position.Y + (double) this.height) / 16.0 + (double) Player.tileRangeY + (double) this.inventory[this.selectedItem].tileBoost - 2.0 >= (double) Player.tileTargetY)
        {
          this.showItemIcon = true;
          if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
          {
            if (this.inventory[this.selectedItem].type == 205)
            {
              bool lava1 = Main.tile[Player.tileTargetX, Player.tileTargetY].lava;
              int num35 = 0;
              for (int index3 = Player.tileTargetX - 1; index3 <= Player.tileTargetX + 1; ++index3)
              {
                for (int index4 = Player.tileTargetY - 1; index4 <= Player.tileTargetY + 1; ++index4)
                {
                  if (Main.tile[index3, index4].lava == lava1)
                    num35 += (int) Main.tile[index3, index4].liquid;
                }
              }
              if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > (byte) 0 && num35 > 100)
              {
                bool lava2 = Main.tile[Player.tileTargetX, Player.tileTargetY].lava;
                if (!Main.tile[Player.tileTargetX, Player.tileTargetY].lava)
                  this.inventory[this.selectedItem].SetDefaults(206);
                else
                  this.inventory[this.selectedItem].SetDefaults(207);
                Main.PlaySound(19, (int) this.position.X, (int) this.position.Y);
                this.itemTime = this.inventory[this.selectedItem].useTime;
                int liquid = (int) Main.tile[Player.tileTargetX, Player.tileTargetY].liquid;
                Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = (byte) 0;
                Main.tile[Player.tileTargetX, Player.tileTargetY].lava = false;
                WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, false);
                if (Main.netMode == 1)
                  NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
                else
                  Liquid.AddWater(Player.tileTargetX, Player.tileTargetY);
                for (int index5 = Player.tileTargetX - 1; index5 <= Player.tileTargetX + 1; ++index5)
                {
                  for (int index6 = Player.tileTargetY - 1; index6 <= Player.tileTargetY + 1; ++index6)
                  {
                    if (liquid < 256 && Main.tile[index5, index6].lava == lava1)
                    {
                      int num36 = (int) Main.tile[index5, index6].liquid;
                      if (num36 + liquid > (int) byte.MaxValue)
                        num36 = (int) byte.MaxValue - liquid;
                      liquid += num36;
                      Main.tile[index5, index6].liquid -= (byte) num36;
                      Main.tile[index5, index6].lava = lava2;
                      if (Main.tile[index5, index6].liquid == (byte) 0)
                        Main.tile[index5, index6].lava = false;
                      WorldGen.SquareTileFrame(index5, index6, false);
                      if (Main.netMode == 1)
                        NetMessage.sendWater(index5, index6);
                      else
                        Liquid.AddWater(index5, index6);
                    }
                  }
                }
              }
            }
            else if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid < (byte) 200 && (!Main.tile[Player.tileTargetX, Player.tileTargetY].active || !Main.tileSolid[(int) Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tileSolidTop[(int) Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
            {
              if (this.inventory[this.selectedItem].type == 207)
              {
                if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == (byte) 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].lava)
                {
                  Main.PlaySound(19, (int) this.position.X, (int) this.position.Y);
                  Main.tile[Player.tileTargetX, Player.tileTargetY].lava = true;
                  Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = byte.MaxValue;
                  WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY);
                  this.inventory[this.selectedItem].SetDefaults(205);
                  this.itemTime = this.inventory[this.selectedItem].useTime;
                  if (Main.netMode == 1)
                    NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
                }
              }
              else if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == (byte) 0 || !Main.tile[Player.tileTargetX, Player.tileTargetY].lava)
              {
                Main.PlaySound(19, (int) this.position.X, (int) this.position.Y);
                Main.tile[Player.tileTargetX, Player.tileTargetY].lava = false;
                Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = byte.MaxValue;
                WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY);
                this.inventory[this.selectedItem].SetDefaults(205);
                this.itemTime = this.inventory[this.selectedItem].useTime;
                if (Main.netMode == 1)
                  NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
              }
            }
          }
        }
        if (!this.channel)
        {
          this.toolTime = this.itemTime;
        }
        else
        {
          --this.toolTime;
          if (this.toolTime < 0)
            this.toolTime = this.inventory[this.selectedItem].pick <= 0 ? (int) ((double) this.inventory[this.selectedItem].useTime * (double) this.pickSpeed) : this.inventory[this.selectedItem].useTime;
        }
        if ((this.inventory[this.selectedItem].pick > 0 || this.inventory[this.selectedItem].axe > 0 || this.inventory[this.selectedItem].hammer > 0) && (double) this.position.X / 16.0 - (double) Player.tileRangeX - (double) this.inventory[this.selectedItem].tileBoost <= (double) Player.tileTargetX && ((double) this.position.X + (double) this.width) / 16.0 + (double) Player.tileRangeX + (double) this.inventory[this.selectedItem].tileBoost - 1.0 >= (double) Player.tileTargetX && (double) this.position.Y / 16.0 - (double) Player.tileRangeY - (double) this.inventory[this.selectedItem].tileBoost <= (double) Player.tileTargetY && ((double) this.position.Y + (double) this.height) / 16.0 + (double) Player.tileRangeY + (double) this.inventory[this.selectedItem].tileBoost - 2.0 >= (double) Player.tileTargetY)
        {
          bool flag4 = true;
          this.showItemIcon = true;
          if (Main.tile[Player.tileTargetX, Player.tileTargetY].active)
          {
            if (this.inventory[this.selectedItem].pick > 0 && !Main.tileAxe[(int) Main.tile[Player.tileTargetX, Player.tileTargetY].type] && !Main.tileHammer[(int) Main.tile[Player.tileTargetX, Player.tileTargetY].type] || this.inventory[this.selectedItem].axe > 0 && Main.tileAxe[(int) Main.tile[Player.tileTargetX, Player.tileTargetY].type] || this.inventory[this.selectedItem].hammer > 0 && Main.tileHammer[(int) Main.tile[Player.tileTargetX, Player.tileTargetY].type])
              flag4 = false;
            if (this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
            {
              if (this.hitTileX != Player.tileTargetX || this.hitTileY != Player.tileTargetY)
              {
                this.hitTile = 0;
                this.hitTileX = Player.tileTargetX;
                this.hitTileY = Player.tileTargetY;
              }
              if (Main.tileNoFail[(int) Main.tile[Player.tileTargetX, Player.tileTargetY].type])
                this.hitTile = 100;
              if (Main.tile[Player.tileTargetX, Player.tileTargetY].type != (byte) 27)
              {
                if (Main.tileHammer[(int) Main.tile[Player.tileTargetX, Player.tileTargetY].type])
                {
                  flag4 = false;
                  if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 48)
                    this.hitTile += this.inventory[this.selectedItem].hammer / 2;
                  else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 129)
                    this.hitTile += this.inventory[this.selectedItem].hammer * 2;
                  else
                    this.hitTile += this.inventory[this.selectedItem].hammer;
                  if ((double) Player.tileTargetY > Main.rockLayer && Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 77 && this.inventory[this.selectedItem].hammer < 60)
                    this.hitTile = 0;
                  if (this.inventory[this.selectedItem].hammer > 0)
                  {
                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 26 && (this.inventory[this.selectedItem].hammer < 80 || !Main.hardMode))
                    {
                      this.hitTile = 0;
                      this.Hurt(this.statLife / 2, -this.direction, deathText: Lang.deathMsg(other: 4));
                      WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true);
                      if (Main.netMode == 1)
                        NetMessage.SendData(17, number2: ((float) Player.tileTargetX), number3: ((float) Player.tileTargetY), number4: 1f);
                    }
                    if (this.hitTile >= 100)
                    {
                      if (Main.netMode == 1 && Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 21)
                      {
                        WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true);
                        NetMessage.SendData(17, number2: ((float) Player.tileTargetX), number3: ((float) Player.tileTargetY), number4: 1f);
                        NetMessage.SendData(34, number: Player.tileTargetX, number2: ((float) Player.tileTargetY));
                      }
                      else
                      {
                        this.hitTile = 0;
                        WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY);
                        if (Main.netMode == 1)
                          NetMessage.SendData(17, number2: ((float) Player.tileTargetX), number3: ((float) Player.tileTargetY));
                      }
                    }
                    else
                    {
                      WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true);
                      if (Main.netMode == 1)
                        NetMessage.SendData(17, number2: ((float) Player.tileTargetX), number3: ((float) Player.tileTargetY), number4: 1f);
                    }
                    this.itemTime = this.inventory[this.selectedItem].useTime;
                  }
                }
                else if (Main.tileAxe[(int) Main.tile[Player.tileTargetX, Player.tileTargetY].type])
                {
                  if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 30 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 124)
                    this.hitTile += this.inventory[this.selectedItem].axe * 5;
                  else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 80)
                    this.hitTile += this.inventory[this.selectedItem].axe * 3;
                  else
                    this.hitTile += this.inventory[this.selectedItem].axe;
                  if (this.inventory[this.selectedItem].axe > 0)
                  {
                    if (this.hitTile >= 100)
                    {
                      this.hitTile = 0;
                      WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY);
                      if (Main.netMode == 1)
                        NetMessage.SendData(17, number2: ((float) Player.tileTargetX), number3: ((float) Player.tileTargetY));
                    }
                    else
                    {
                      WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true);
                      if (Main.netMode == 1)
                        NetMessage.SendData(17, number2: ((float) Player.tileTargetX), number3: ((float) Player.tileTargetY), number4: 1f);
                    }
                    this.itemTime = this.inventory[this.selectedItem].useTime;
                  }
                }
                else if (this.inventory[this.selectedItem].pick > 0)
                {
                  if (Main.tileDungeon[(int) Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 37 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 25 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 58 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 117)
                    this.hitTile += this.inventory[this.selectedItem].pick / 2;
                  else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 107)
                    this.hitTile += this.inventory[this.selectedItem].pick / 2;
                  else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 108)
                    this.hitTile += this.inventory[this.selectedItem].pick / 3;
                  else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 111)
                    this.hitTile += this.inventory[this.selectedItem].pick / 4;
                  else
                    this.hitTile += this.inventory[this.selectedItem].pick;
                  if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 25 && this.inventory[this.selectedItem].pick < 65)
                    this.hitTile = 0;
                  else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 117 && this.inventory[this.selectedItem].pick < 65)
                    this.hitTile = 0;
                  else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 37 && this.inventory[this.selectedItem].pick < 55)
                    this.hitTile = 0;
                  else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 22 && (double) Player.tileTargetY > Main.worldSurface && this.inventory[this.selectedItem].pick < 55)
                    this.hitTile = 0;
                  else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 56 && this.inventory[this.selectedItem].pick < 65)
                    this.hitTile = 0;
                  else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 58 && this.inventory[this.selectedItem].pick < 65)
                    this.hitTile = 0;
                  else if (Main.tileDungeon[(int) Main.tile[Player.tileTargetX, Player.tileTargetY].type] && this.inventory[this.selectedItem].pick < 65)
                  {
                    if ((double) Player.tileTargetX < (double) Main.maxTilesX * 0.25 || (double) Player.tileTargetX > (double) Main.maxTilesX * 0.75)
                      this.hitTile = 0;
                  }
                  else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 107 && this.inventory[this.selectedItem].pick < 100)
                    this.hitTile = 0;
                  else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 108 && this.inventory[this.selectedItem].pick < 110)
                    this.hitTile = 0;
                  else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 111 && this.inventory[this.selectedItem].pick < 120)
                    this.hitTile = 0;
                  if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 40 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 53 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 57 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 59 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 123)
                    this.hitTile += this.inventory[this.selectedItem].pick;
                  if (this.hitTile >= 100 && (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 2 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 23 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 60 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 70 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte) 109))
                    this.hitTile = 0;
                  if (this.hitTile >= 100)
                  {
                    this.hitTile = 0;
                    WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY);
                    if (Main.netMode == 1)
                      NetMessage.SendData(17, number2: ((float) Player.tileTargetX), number3: ((float) Player.tileTargetY));
                  }
                  else
                  {
                    WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true);
                    if (Main.netMode == 1)
                      NetMessage.SendData(17, number2: ((float) Player.tileTargetX), number3: ((float) Player.tileTargetY), number4: 1f);
                  }
                  this.itemTime = (int) ((double) this.inventory[this.selectedItem].useTime * (double) this.pickSpeed);
                }
              }
            }
          }
          int i2 = Player.tileTargetX;
          int j = Player.tileTargetY;
          bool flag5 = true;
          if (Main.tile[i2, j].wall > (byte) 0)
          {
            if (!Main.wallHouse[(int) Main.tile[i2, j].wall])
            {
              for (int index7 = i2 - 1; index7 < i2 + 2; ++index7)
              {
                for (int index8 = j - 1; index8 < j + 2; ++index8)
                {
                  if ((int) Main.tile[index7, index8].wall != (int) Main.tile[i2, j].wall)
                  {
                    flag5 = false;
                    break;
                  }
                }
              }
            }
            else
              flag5 = false;
          }
          if (flag5 && !Main.tile[i2, j].active)
          {
            int num37 = -1;
            if (((double) Main.mouseX + (double) Main.screenPosition.X) / 16.0 < Math.Round(((double) Main.mouseX + (double) Main.screenPosition.X) / 16.0))
              num37 = 0;
            int num38 = -1;
            if (((double) Main.mouseY + (double) Main.screenPosition.Y) / 16.0 < Math.Round(((double) Main.mouseY + (double) Main.screenPosition.Y) / 16.0))
              num38 = 0;
            for (int index9 = Player.tileTargetX + num37; index9 <= Player.tileTargetX + num37 + 1; ++index9)
            {
              for (int index10 = Player.tileTargetY + num38; index10 <= Player.tileTargetY + num38 + 1; ++index10)
              {
                if (flag5)
                {
                  i2 = index9;
                  j = index10;
                  if (Main.tile[i2, j].wall > (byte) 0)
                  {
                    if (!Main.wallHouse[(int) Main.tile[i2, j].wall])
                    {
                      for (int index11 = i2 - 1; index11 < i2 + 2; ++index11)
                      {
                        for (int index12 = j - 1; index12 < j + 2; ++index12)
                        {
                          if ((int) Main.tile[index11, index12].wall != (int) Main.tile[i2, j].wall)
                          {
                            flag5 = false;
                            break;
                          }
                        }
                      }
                    }
                    else
                      flag5 = false;
                  }
                }
              }
            }
          }
          if (flag4 && Main.tile[i2, j].wall > (byte) 0 && this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem && this.inventory[this.selectedItem].hammer > 0)
          {
            bool flag6 = true;
            if (!Main.wallHouse[(int) Main.tile[i2, j].wall])
            {
              flag6 = false;
              for (int index13 = i2 - 1; index13 < i2 + 2; ++index13)
              {
                for (int index14 = j - 1; index14 < j + 2; ++index14)
                {
                  if ((int) Main.tile[index13, index14].wall != (int) Main.tile[i2, j].wall)
                  {
                    flag6 = true;
                    break;
                  }
                }
              }
            }
            if (flag6)
            {
              if (this.hitTileX != i2 || this.hitTileY != j)
              {
                this.hitTile = 0;
                this.hitTileX = i2;
                this.hitTileY = j;
              }
              this.hitTile += (int) ((double) this.inventory[this.selectedItem].hammer * 1.5);
              if (this.hitTile >= 100)
              {
                this.hitTile = 0;
                WorldGen.KillWall(i2, j);
                if (Main.netMode == 1)
                  NetMessage.SendData(17, number: 2, number2: ((float) i2), number3: ((float) j));
              }
              else
              {
                WorldGen.KillWall(i2, j, true);
                if (Main.netMode == 1)
                  NetMessage.SendData(17, number: 2, number2: ((float) i2), number3: ((float) j), number4: 1f);
              }
              this.itemTime = this.inventory[this.selectedItem].useTime / 2;
            }
          }
        }
        if (this.inventory[this.selectedItem].type == 29 && this.itemAnimation > 0 && this.statLifeMax < 400 && this.itemTime == 0)
        {
          this.itemTime = this.inventory[this.selectedItem].useTime;
          this.statLifeMax += 20;
          this.statLife += 20;
          if (Main.myPlayer == this.whoAmi)
            this.HealEffect(20);
        }
        if (this.inventory[this.selectedItem].type == 109 && this.itemAnimation > 0 && this.statManaMax < 200 && this.itemTime == 0)
        {
          this.itemTime = this.inventory[this.selectedItem].useTime;
          this.statManaMax += 20;
          this.statMana += 20;
          if (Main.myPlayer == this.whoAmi)
            this.ManaEffect(20);
        }
        this.PlaceThing();
      }
      if (this.inventory[this.selectedItem].damage >= 0 && this.inventory[this.selectedItem].type > 0 && !this.inventory[this.selectedItem].noMelee && this.itemAnimation > 0)
      {
        bool flag = false;
        Rectangle rectangle1 = new Rectangle((int) this.itemLocation.X, (int) this.itemLocation.Y, 32, 32);
        if (!Main.dedServ)
          rectangle1 = new Rectangle((int) this.itemLocation.X, (int) this.itemLocation.Y, Main.itemTexture[this.inventory[this.selectedItem].type].Width, Main.itemTexture[this.inventory[this.selectedItem].type].Height);
        rectangle1.Width = (int) ((double) rectangle1.Width * (double) this.inventory[this.selectedItem].scale);
        rectangle1.Height = (int) ((double) rectangle1.Height * (double) this.inventory[this.selectedItem].scale);
        if (this.direction == -1)
          rectangle1.X -= rectangle1.Width;
        if ((double) this.gravDir == 1.0)
          rectangle1.Y -= rectangle1.Height;
        if (this.inventory[this.selectedItem].useStyle == 1)
        {
          if ((double) this.itemAnimation < (double) this.itemAnimationMax * 0.333)
          {
            if (this.direction == -1)
              rectangle1.X -= (int) ((double) rectangle1.Width * 1.4 - (double) rectangle1.Width);
            rectangle1.Width = (int) ((double) rectangle1.Width * 1.4);
            rectangle1.Y += (int) ((double) rectangle1.Height * 0.5 * (double) this.gravDir);
            rectangle1.Height = (int) ((double) rectangle1.Height * 1.1);
          }
          else if ((double) this.itemAnimation >= (double) this.itemAnimationMax * 0.666)
          {
            if (this.direction == 1)
              rectangle1.X -= (int) ((double) rectangle1.Width * 1.2);
            rectangle1.Width *= 2;
            rectangle1.Y -= (int) (((double) rectangle1.Height * 1.4 - (double) rectangle1.Height) * (double) this.gravDir);
            rectangle1.Height = (int) ((double) rectangle1.Height * 1.4);
          }
        }
        else if (this.inventory[this.selectedItem].useStyle == 3)
        {
          if ((double) this.itemAnimation > (double) this.itemAnimationMax * 0.666)
          {
            flag = true;
          }
          else
          {
            if (this.direction == -1)
              rectangle1.X -= (int) ((double) rectangle1.Width * 1.4 - (double) rectangle1.Width);
            rectangle1.Width = (int) ((double) rectangle1.Width * 1.4);
            rectangle1.Y += (int) ((double) rectangle1.Height * 0.6);
            rectangle1.Height = (int) ((double) rectangle1.Height * 0.6);
          }
        }
        double gravDir = (double) this.gravDir;
        if (!flag)
        {
          if ((this.inventory[this.selectedItem].type == 44 || this.inventory[this.selectedItem].type == 45 || this.inventory[this.selectedItem].type == 46 || this.inventory[this.selectedItem].type == 103 || this.inventory[this.selectedItem].type == 104) && Main.rand.Next(15) == 0)
            Dust.NewDust(new Vector2((float) rectangle1.X, (float) rectangle1.Y), rectangle1.Width, rectangle1.Height, 14, (float) (this.direction * 2), Alpha: 150, Scale: 1.3f);
          if (this.inventory[this.selectedItem].type == 273)
          {
            if (Main.rand.Next(5) == 0)
              Dust.NewDust(new Vector2((float) rectangle1.X, (float) rectangle1.Y), rectangle1.Width, rectangle1.Height, 14, (float) (this.direction * 2), Alpha: 150, Scale: 1.4f);
            int index = Dust.NewDust(new Vector2((float) rectangle1.X, (float) rectangle1.Y), rectangle1.Width, rectangle1.Height, 27, this.velocity.X * 0.2f + (float) (this.direction * 3), this.velocity.Y * 0.2f, 100, Scale: 1.2f);
            Main.dust[index].noGravity = true;
            Main.dust[index].velocity.X /= 2f;
            Main.dust[index].velocity.Y /= 2f;
          }
          if (this.inventory[this.selectedItem].type == 65)
          {
            if (Main.rand.Next(5) == 0)
              Dust.NewDust(new Vector2((float) rectangle1.X, (float) rectangle1.Y), rectangle1.Width, rectangle1.Height, 58, Alpha: 150, Scale: 1.2f);
            if (Main.rand.Next(10) == 0)
              Gore.NewGore(new Vector2((float) rectangle1.X, (float) rectangle1.Y), new Vector2(), Main.rand.Next(16, 18));
          }
          if (this.inventory[this.selectedItem].type == 190 || this.inventory[this.selectedItem].type == 213)
          {
            int index = Dust.NewDust(new Vector2((float) rectangle1.X, (float) rectangle1.Y), rectangle1.Width, rectangle1.Height, 40, this.velocity.X * 0.2f + (float) (this.direction * 3), this.velocity.Y * 0.2f, Scale: 1.2f);
            Main.dust[index].noGravity = true;
          }
          if (this.inventory[this.selectedItem].type == 121)
          {
            for (int index15 = 0; index15 < 2; ++index15)
            {
              int index16 = Dust.NewDust(new Vector2((float) rectangle1.X, (float) rectangle1.Y), rectangle1.Width, rectangle1.Height, 6, this.velocity.X * 0.2f + (float) (this.direction * 3), this.velocity.Y * 0.2f, 100, Scale: 2.5f);
              Main.dust[index16].noGravity = true;
              Main.dust[index16].velocity.X *= 2f;
              Main.dust[index16].velocity.Y *= 2f;
            }
          }
          if (this.inventory[this.selectedItem].type == 122 || this.inventory[this.selectedItem].type == 217)
          {
            int index = Dust.NewDust(new Vector2((float) rectangle1.X, (float) rectangle1.Y), rectangle1.Width, rectangle1.Height, 6, this.velocity.X * 0.2f + (float) (this.direction * 3), this.velocity.Y * 0.2f, 100, Scale: 1.9f);
            Main.dust[index].noGravity = true;
          }
          if (this.inventory[this.selectedItem].type == 155)
          {
            int index = Dust.NewDust(new Vector2((float) rectangle1.X, (float) rectangle1.Y), rectangle1.Width, rectangle1.Height, 29, this.velocity.X * 0.2f + (float) (this.direction * 3), this.velocity.Y * 0.2f, 100, Scale: 2f);
            Main.dust[index].noGravity = true;
            Main.dust[index].velocity.X /= 2f;
            Main.dust[index].velocity.Y /= 2f;
          }
          if (this.inventory[this.selectedItem].type == 367 || this.inventory[this.selectedItem].type == 368)
          {
            if (Main.rand.Next(3) == 0)
            {
              int index = Dust.NewDust(new Vector2((float) rectangle1.X, (float) rectangle1.Y), rectangle1.Width, rectangle1.Height, 57, this.velocity.X * 0.2f + (float) (this.direction * 3), this.velocity.Y * 0.2f, 100, Scale: 1.1f);
              Main.dust[index].noGravity = true;
              Main.dust[index].velocity.X /= 2f;
              Main.dust[index].velocity.Y /= 2f;
              Main.dust[index].velocity.X += (float) (this.direction * 2);
            }
            if (Main.rand.Next(4) == 0)
            {
              int index = Dust.NewDust(new Vector2((float) rectangle1.X, (float) rectangle1.Y), rectangle1.Width, rectangle1.Height, 43, Alpha: 254, Scale: 0.3f);
              Main.dust[index].velocity *= 0.0f;
            }
          }
          if (this.inventory[this.selectedItem].type >= 198 && this.inventory[this.selectedItem].type <= 203)
          {
            float R = 0.5f;
            float G = 0.5f;
            float B = 0.5f;
            if (this.inventory[this.selectedItem].type == 198)
            {
              R *= 0.1f;
              G *= 0.5f;
              B *= 1.2f;
            }
            else if (this.inventory[this.selectedItem].type == 199)
            {
              R *= 1f;
              G *= 0.2f;
              B *= 0.1f;
            }
            else if (this.inventory[this.selectedItem].type == 200)
            {
              R *= 0.1f;
              G *= 1f;
              B *= 0.2f;
            }
            else if (this.inventory[this.selectedItem].type == 201)
            {
              R *= 0.8f;
              G *= 0.1f;
              B *= 1f;
            }
            else if (this.inventory[this.selectedItem].type == 202)
            {
              R *= 0.8f;
              G *= 0.9f;
              B *= 1f;
            }
            else if (this.inventory[this.selectedItem].type == 203)
            {
              R *= 0.9f;
              G *= 0.9f;
              B *= 0.1f;
            }
            Lighting.addLight((int) (((double) this.itemLocation.X + 6.0 + (double) this.velocity.X) / 16.0), (int) (((double) this.itemLocation.Y - 14.0) / 16.0), R, G, B);
          }
          if (Main.myPlayer == i)
          {
            int num39 = (int) ((double) this.inventory[this.selectedItem].damage * (double) this.meleeDamage);
            float knockBack = this.inventory[this.selectedItem].knockBack;
            if (this.kbGlove)
              knockBack *= 2f;
            int num40 = rectangle1.X / 16;
            int num41 = (rectangle1.X + rectangle1.Width) / 16 + 1;
            int num42 = rectangle1.Y / 16;
            int num43 = (rectangle1.Y + rectangle1.Height) / 16 + 1;
            for (int i3 = num40; i3 < num41; ++i3)
            {
              for (int j = num42; j < num43; ++j)
              {
                if (Main.tile[i3, j] != null && Main.tileCut[(int) Main.tile[i3, j].type] && Main.tile[i3, j + 1] != null && Main.tile[i3, j + 1].type != (byte) 78)
                {
                  WorldGen.KillTile(i3, j);
                  if (Main.netMode == 1)
                    NetMessage.SendData(17, number2: ((float) i3), number3: ((float) j));
                }
              }
            }
            for (int index = 0; index < 200; ++index)
            {
              if (Main.npc[index].active && Main.npc[index].immune[i] == 0 && this.attackCD == 0 && !Main.npc[index].dontTakeDamage && (!Main.npc[index].friendly || Main.npc[index].type == 22 && this.killGuide))
              {
                Rectangle rectangle2 = new Rectangle((int) Main.npc[index].position.X, (int) Main.npc[index].position.Y, Main.npc[index].width, Main.npc[index].height);
                if (rectangle1.Intersects(rectangle2) && (Main.npc[index].noTileCollide || Collision.CanHit(this.position, this.width, this.height, Main.npc[index].position, Main.npc[index].width, Main.npc[index].height)))
                {
                  bool crit = false;
                  if (Main.rand.Next(1, 101) <= this.meleeCrit)
                    crit = true;
                  int Damage = Main.DamageVar((float) num39);
                  this.StatusNPC(this.inventory[this.selectedItem].type, index);
                  Main.npc[index].StrikeNPC(Damage, knockBack, this.direction, crit);
                  if (Main.netMode != 0)
                  {
                    if (crit)
                      NetMessage.SendData(28, number: index, number2: ((float) Damage), number3: knockBack, number4: ((float) this.direction), number5: 1);
                    else
                      NetMessage.SendData(28, number: index, number2: ((float) Damage), number3: knockBack, number4: ((float) this.direction));
                  }
                  Main.npc[index].immune[i] = this.itemAnimation;
                  this.attackCD = (int) ((double) this.itemAnimationMax * 0.33);
                }
              }
            }
            if (this.hostile)
            {
              for (int index = 0; index < (int) byte.MaxValue; ++index)
              {
                if (index != i && Main.player[index].active && Main.player[index].hostile && !Main.player[index].immune && !Main.player[index].dead && (Main.player[i].team == 0 || Main.player[i].team != Main.player[index].team))
                {
                  Rectangle rectangle3 = new Rectangle((int) Main.player[index].position.X, (int) Main.player[index].position.Y, Main.player[index].width, Main.player[index].height);
                  if (rectangle1.Intersects(rectangle3) && Collision.CanHit(this.position, this.width, this.height, Main.player[index].position, Main.player[index].width, Main.player[index].height))
                  {
                    bool Crit = false;
                    if (Main.rand.Next(1, 101) <= 10)
                      Crit = true;
                    int Damage = Main.DamageVar((float) num39);
                    this.StatusPvP(this.inventory[this.selectedItem].type, index);
                    Main.player[index].Hurt(Damage, this.direction, true, deathText: "", Crit: Crit);
                    if (Main.netMode != 0)
                    {
                      if (Crit)
                        NetMessage.SendData(26, text: Lang.deathMsg(this.whoAmi), number: index, number2: ((float) this.direction), number3: ((float) Damage), number4: 1f, number5: 1);
                      else
                        NetMessage.SendData(26, text: Lang.deathMsg(this.whoAmi), number: index, number2: ((float) this.direction), number3: ((float) Damage), number4: 1f);
                    }
                    this.attackCD = (int) ((double) this.itemAnimationMax * 0.33);
                  }
                }
              }
            }
          }
        }
      }
      if (this.itemTime == 0 && this.itemAnimation > 0)
      {
        if (this.inventory[this.selectedItem].healLife > 0)
        {
          this.statLife += this.inventory[this.selectedItem].healLife;
          this.itemTime = this.inventory[this.selectedItem].useTime;
          if (Main.myPlayer == this.whoAmi)
            this.HealEffect(this.inventory[this.selectedItem].healLife);
        }
        if (this.inventory[this.selectedItem].healMana > 0)
        {
          this.statMana += this.inventory[this.selectedItem].healMana;
          this.itemTime = this.inventory[this.selectedItem].useTime;
          if (Main.myPlayer == this.whoAmi)
            this.ManaEffect(this.inventory[this.selectedItem].healMana);
        }
        if (this.inventory[this.selectedItem].buffType > 0)
        {
          if (this.whoAmi == Main.myPlayer)
            this.AddBuff(this.inventory[this.selectedItem].buffType, this.inventory[this.selectedItem].buffTime);
          this.itemTime = this.inventory[this.selectedItem].useTime;
        }
      }
      if (this.whoAmi == Main.myPlayer)
      {
        if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 361)
        {
          this.itemTime = this.inventory[this.selectedItem].useTime;
          Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
          if (Main.netMode != 1)
          {
            if (Main.invasionType == 0)
            {
              Main.invasionDelay = 0;
              Main.StartInvasion();
            }
          }
          else
            NetMessage.SendData(61, number: this.whoAmi, number2: -1f);
        }
        if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 602)
        {
          this.itemTime = this.inventory[this.selectedItem].useTime;
          Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
          if (Main.netMode != 1)
          {
            if (Main.invasionType == 0)
            {
              Main.invasionDelay = 0;
              Main.StartInvasion(2);
            }
          }
          else
            NetMessage.SendData(61, number: this.whoAmi, number2: -2f);
        }
        if (this.itemTime == 0 && this.itemAnimation > 0 && (this.inventory[this.selectedItem].type == 43 || this.inventory[this.selectedItem].type == 70 || this.inventory[this.selectedItem].type == 544 || this.inventory[this.selectedItem].type == 556 || this.inventory[this.selectedItem].type == 557 || this.inventory[this.selectedItem].type == 560))
        {
          bool flag = false;
          for (int index = 0; index < 200; ++index)
          {
            if (Main.npc[index].active && (this.inventory[this.selectedItem].type == 43 && Main.npc[index].type == 4 || this.inventory[this.selectedItem].type == 70 && Main.npc[index].type == 13 || this.inventory[this.selectedItem].type == 560 & Main.npc[index].type == 50 || this.inventory[this.selectedItem].type == 544 && Main.npc[index].type == 125 || this.inventory[this.selectedItem].type == 544 && Main.npc[index].type == 126 || this.inventory[this.selectedItem].type == 556 && Main.npc[index].type == 134 || this.inventory[this.selectedItem].type == 557 && Main.npc[index].type == 128))
            {
              flag = true;
              break;
            }
          }
          if (flag)
          {
            this.itemTime = this.inventory[this.selectedItem].useTime;
            if (Main.myPlayer != this.whoAmi)
              ;
          }
          else if (this.inventory[this.selectedItem].type == 560)
          {
            this.itemTime = this.inventory[this.selectedItem].useTime;
            Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
            if (Main.netMode != 1)
              NPC.SpawnOnPlayer(i, 50);
            else
              NetMessage.SendData(61, number: this.whoAmi, number2: 50f);
          }
          else if (this.inventory[this.selectedItem].type == 43)
          {
            if (!Main.dayTime)
            {
              this.itemTime = this.inventory[this.selectedItem].useTime;
              Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
              if (Main.netMode != 1)
                NPC.SpawnOnPlayer(i, 4);
              else
                NetMessage.SendData(61, number: this.whoAmi, number2: 4f);
            }
          }
          else if (this.inventory[this.selectedItem].type == 70)
          {
            if (this.zoneEvil)
            {
              this.itemTime = this.inventory[this.selectedItem].useTime;
              Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
              if (Main.netMode != 1)
                NPC.SpawnOnPlayer(i, 13);
              else
                NetMessage.SendData(61, number: this.whoAmi, number2: 13f);
            }
          }
          else if (this.inventory[this.selectedItem].type == 544)
          {
            if (!Main.dayTime)
            {
              this.itemTime = this.inventory[this.selectedItem].useTime;
              Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
              if (Main.netMode != 1)
              {
                NPC.SpawnOnPlayer(i, 125);
                NPC.SpawnOnPlayer(i, 126);
              }
              else
              {
                NetMessage.SendData(61, number: this.whoAmi, number2: 125f);
                NetMessage.SendData(61, number: this.whoAmi, number2: 126f);
              }
            }
          }
          else if (this.inventory[this.selectedItem].type == 556)
          {
            if (!Main.dayTime)
            {
              this.itemTime = this.inventory[this.selectedItem].useTime;
              Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
              if (Main.netMode != 1)
                NPC.SpawnOnPlayer(i, 134);
              else
                NetMessage.SendData(61, number: this.whoAmi, number2: 134f);
            }
          }
          else if (this.inventory[this.selectedItem].type == 557 && !Main.dayTime)
          {
            this.itemTime = this.inventory[this.selectedItem].useTime;
            Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
            if (Main.netMode != 1)
              NPC.SpawnOnPlayer(i, (int) sbyte.MaxValue);
            else
              NetMessage.SendData(61, number: this.whoAmi, number2: ((float) sbyte.MaxValue));
          }
        }
      }
      if (this.inventory[this.selectedItem].type == 50 && this.itemAnimation > 0)
      {
        if (Main.rand.Next(2) == 0)
          Dust.NewDust(this.position, this.width, this.height, 15, Alpha: 150, Scale: 1.1f);
        if (this.itemTime == 0)
          this.itemTime = this.inventory[this.selectedItem].useTime;
        else if (this.itemTime == this.inventory[this.selectedItem].useTime / 2)
        {
          for (int index = 0; index < 70; ++index)
            Dust.NewDust(this.position, this.width, this.height, 15, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, Scale: 1.5f);
          this.grappling[0] = -1;
          this.grapCount = 0;
          for (int index = 0; index < 1000; ++index)
          {
            if (Main.projectile[index].active && Main.projectile[index].owner == i && Main.projectile[index].aiStyle == 7)
              Main.projectile[index].Kill();
          }
          this.Spawn();
          for (int index = 0; index < 70; ++index)
            Dust.NewDust(this.position, this.width, this.height, 15, Alpha: 150, Scale: 1.5f);
        }
      }
      if (i != Main.myPlayer)
        return;
      if (this.itemTime == this.inventory[this.selectedItem].useTime && this.inventory[this.selectedItem].consumable)
      {
        bool flag = true;
        if (this.inventory[this.selectedItem].ranged)
        {
          if (this.ammoCost80 && Main.rand.Next(5) == 0)
            flag = false;
          if (this.ammoCost75 && Main.rand.Next(4) == 0)
            flag = false;
        }
        if (flag)
        {
          if (this.inventory[this.selectedItem].stack > 0)
            --this.inventory[this.selectedItem].stack;
          if (this.inventory[this.selectedItem].stack <= 0)
            this.itemTime = this.itemAnimation;
        }
      }
      if (this.inventory[this.selectedItem].stack <= 0 && this.itemAnimation == 0)
        this.inventory[this.selectedItem] = new Item();
      if (this.selectedItem != 48 || this.itemAnimation == 0)
        return;
      Main.mouseItem = (Item) this.inventory[this.selectedItem].Clone();
    }

    public Color GetImmuneAlpha(Color newColor)
    {
      float num = (float) ((int) byte.MaxValue - this.immuneAlpha) / (float) byte.MaxValue;
      if ((double) this.shadow > 0.0)
        num *= 1f - this.shadow;
      if (this.immuneAlpha > 125)
        return new Color(0, 0, 0, 0);
      int r = (int) ((double) newColor.R * (double) num);
      int g = (int) ((double) newColor.G * (double) num);
      int b = (int) ((double) newColor.B * (double) num);
      int a = (int) ((double) newColor.A * (double) num);
      if (a < 0)
        a = 0;
      if (a > (int) byte.MaxValue)
        a = (int) byte.MaxValue;
      return new Color(r, g, b, a);
    }

    public Color GetImmuneAlpha2(Color newColor)
    {
      float num = (float) ((int) byte.MaxValue - this.immuneAlpha) / (float) byte.MaxValue;
      if ((double) this.shadow > 0.0)
        num *= 1f - this.shadow;
      int r = (int) ((double) newColor.R * (double) num);
      int g = (int) ((double) newColor.G * (double) num);
      int b = (int) ((double) newColor.B * (double) num);
      int a = (int) ((double) newColor.A * (double) num);
      if (a < 0)
        a = 0;
      if (a > (int) byte.MaxValue)
        a = (int) byte.MaxValue;
      return new Color(r, g, b, a);
    }

    public Color GetDeathAlpha(Color newColor)
    {
      int r = (int) newColor.R + (int) ((double) this.immuneAlpha * 0.9);
      int g = (int) newColor.G + (int) ((double) this.immuneAlpha * 0.5);
      int b = (int) newColor.B + (int) ((double) this.immuneAlpha * 0.5);
      int a = (int) newColor.A + (int) ((double) this.immuneAlpha * 0.4);
      if (a < 0)
        a = 0;
      if (a > (int) byte.MaxValue)
        a = (int) byte.MaxValue;
      return new Color(r, g, b, a);
    }

    public void DropCoins()
    {
      for (int index = 0; index < 49; ++index)
      {
        if (this.inventory[index].type >= 71 && this.inventory[index].type <= 74)
        {
          int number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, this.inventory[index].type);
          int num1 = this.inventory[index].stack / 2;
          int num2 = this.inventory[index].stack - num1;
          this.inventory[index].stack -= num2;
          if (this.inventory[index].stack <= 0)
            this.inventory[index] = new Item();
          Main.item[number].stack = num2;
          Main.item[number].velocity.Y = (float) Main.rand.Next(-20, 1) * 0.2f;
          Main.item[number].velocity.X = (float) Main.rand.Next(-20, 21) * 0.2f;
          Main.item[number].noGrabDelay = 100;
          if (Main.netMode == 1)
            NetMessage.SendData(21, number: number);
          if (index == 48)
            Main.mouseItem = (Item) this.inventory[index].Clone();
        }
      }
    }

    public void DropItems()
    {
      for (int index = 0; index < 49; ++index)
      {
        if (this.inventory[index].stack > 0 && this.inventory[index].name != "Copper Pickaxe" && this.inventory[index].name != "Copper Axe" && this.inventory[index].name != "Copper Shortsword")
        {
          int number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, this.inventory[index].type);
          Main.item[number].SetDefaults(this.inventory[index].name);
          Main.item[number].Prefix((int) this.inventory[index].prefix);
          Main.item[number].stack = this.inventory[index].stack;
          Main.item[number].velocity.Y = (float) Main.rand.Next(-20, 1) * 0.2f;
          Main.item[number].velocity.X = (float) Main.rand.Next(-20, 21) * 0.2f;
          Main.item[number].noGrabDelay = 100;
          if (Main.netMode == 1)
            NetMessage.SendData(21, number: number);
        }
        this.inventory[index] = new Item();
        if (index < 11)
        {
          if (this.armor[index].stack > 0)
          {
            int number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, this.armor[index].type);
            Main.item[number].SetDefaults(this.armor[index].name);
            Main.item[number].Prefix((int) this.armor[index].prefix);
            Main.item[number].stack = this.armor[index].stack;
            Main.item[number].velocity.Y = (float) Main.rand.Next(-20, 1) * 0.2f;
            Main.item[number].velocity.X = (float) Main.rand.Next(-20, 21) * 0.2f;
            Main.item[number].noGrabDelay = 100;
            if (Main.netMode == 1)
              NetMessage.SendData(21, number: number);
          }
          this.armor[index] = new Item();
        }
      }
      this.inventory[0].SetDefaults("Copper Shortsword");
      this.inventory[0].Prefix(-1);
      this.inventory[1].SetDefaults("Copper Pickaxe");
      this.inventory[1].Prefix(-1);
      this.inventory[2].SetDefaults("Copper Axe");
      this.inventory[2].Prefix(-1);
      Main.mouseItem = new Item();
    }

    public object Clone() => this.MemberwiseClone();

    public object clientClone()
    {
      Player player = new Player();
      player.zoneEvil = this.zoneEvil;
      player.zoneMeteor = this.zoneMeteor;
      player.zoneDungeon = this.zoneDungeon;
      player.zoneJungle = this.zoneJungle;
      player.zoneHoly = this.zoneHoly;
      player.direction = this.direction;
      player.selectedItem = this.selectedItem;
      player.controlUp = this.controlUp;
      player.controlDown = this.controlDown;
      player.controlLeft = this.controlLeft;
      player.controlRight = this.controlRight;
      player.controlJump = this.controlJump;
      player.controlUseItem = this.controlUseItem;
      player.statLife = this.statLife;
      player.statLifeMax = this.statLifeMax;
      player.statMana = this.statMana;
      player.statManaMax = this.statManaMax;
      player.position.X = this.position.X;
      player.chest = this.chest;
      player.talkNPC = this.talkNPC;
      for (int index = 0; index < 49; ++index)
      {
        player.inventory[index] = (Item) this.inventory[index].Clone();
        if (index < 11)
          player.armor[index] = (Item) this.armor[index].Clone();
      }
      for (int index = 0; index < 10; ++index)
      {
        player.buffType[index] = this.buffType[index];
        player.buffTime[index] = this.buffTime[index];
      }
      return (object) player;
    }

    private static void EncryptFile(string inputFile, string outputFile)
    {
      byte[] bytes = new UnicodeEncoding().GetBytes("h3y_gUyZ");
      FileStream fileStream1 = new FileStream(outputFile, FileMode.Create);
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      CryptoStream cryptoStream = new CryptoStream((Stream) fileStream1, rijndaelManaged.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
      FileStream fileStream2 = new FileStream(inputFile, FileMode.Open);
      int num;
      while ((num = fileStream2.ReadByte()) != -1)
        cryptoStream.WriteByte((byte) num);
      fileStream2.Close();
      cryptoStream.Close();
      fileStream1.Close();
    }

    private static bool DecryptFile(string inputFile, string outputFile)
    {
      byte[] bytes = new UnicodeEncoding().GetBytes("h3y_gUyZ");
      FileStream fileStream1 = new FileStream(inputFile, FileMode.Open);
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      CryptoStream cryptoStream = new CryptoStream((Stream) fileStream1, rijndaelManaged.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
      FileStream fileStream2 = new FileStream(outputFile, FileMode.Create);
      try
      {
        int num;
        while ((num = cryptoStream.ReadByte()) != -1)
          fileStream2.WriteByte((byte) num);
        fileStream2.Close();
        cryptoStream.Close();
        fileStream1.Close();
      }
      catch
      {
        fileStream2.Close();
        fileStream1.Close();
        File.Delete(outputFile);
        return true;
      }
      return false;
    }

    public static bool CheckSpawn(int x, int y)
    {
      if (x < 10 || x > Main.maxTilesX - 10 || y < 10 || y > Main.maxTilesX - 10 || Main.tile[x, y - 1] == null || !Main.tile[x, y - 1].active || Main.tile[x, y - 1].type != (byte) 79)
        return false;
      for (int index1 = x - 1; index1 <= x + 1; ++index1)
      {
        for (int index2 = y - 3; index2 < y; ++index2)
        {
          if (Main.tile[index1, index2] == null || Main.tile[index1, index2].active && Main.tileSolid[(int) Main.tile[index1, index2].type] && !Main.tileSolidTop[(int) Main.tile[index1, index2].type])
            return false;
        }
      }
      return WorldGen.StartRoomCheck(x, y - 1);
    }

    public void FindSpawn()
    {
      for (int index = 0; index < 200; ++index)
      {
        if (this.spN[index] == null)
        {
          this.SpawnX = -1;
          this.SpawnY = -1;
          break;
        }
        if (this.spN[index] == Main.worldName && this.spI[index] == Main.worldID)
        {
          this.SpawnX = this.spX[index];
          this.SpawnY = this.spY[index];
          break;
        }
      }
    }

    public void ChangeSpawn(int x, int y)
    {
      for (int index1 = 0; index1 < 200 && this.spN[index1] != null; ++index1)
      {
        if (this.spN[index1] == Main.worldName && this.spI[index1] == Main.worldID)
        {
          for (int index2 = index1; index2 > 0; --index2)
          {
            this.spN[index2] = this.spN[index2 - 1];
            this.spI[index2] = this.spI[index2 - 1];
            this.spX[index2] = this.spX[index2 - 1];
            this.spY[index2] = this.spY[index2 - 1];
          }
          this.spN[0] = Main.worldName;
          this.spI[0] = Main.worldID;
          this.spX[0] = x;
          this.spY[0] = y;
          return;
        }
      }
      for (int index = 199; index > 0; --index)
      {
        if (this.spN[index - 1] != null)
        {
          this.spN[index] = this.spN[index - 1];
          this.spI[index] = this.spI[index - 1];
          this.spX[index] = this.spX[index - 1];
          this.spY[index] = this.spY[index - 1];
        }
      }
      this.spN[0] = Main.worldName;
      this.spI[0] = Main.worldID;
      this.spX[0] = x;
      this.spY[0] = y;
    }

    public static void SavePlayer(Player newPlayer, string playerPath)
    {
      try
      {
        Directory.CreateDirectory(Main.PlayerPath);
      }
      catch
      {
      }
      switch (playerPath)
      {
        case "":
          break;
        case null:
          break;
        default:
          string destFileName = playerPath + ".bak";
          if (File.Exists(playerPath))
            File.Copy(playerPath, destFileName, true);
          string str = playerPath + ".dat";
          using (FileStream fileStream = new FileStream(str, FileMode.Create))
          {
            using (BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream))
            {
              binaryWriter.Write(Main.curRelease);
              binaryWriter.Write(newPlayer.name);
              binaryWriter.Write(newPlayer.difficulty);
              binaryWriter.Write(newPlayer.hair);
              binaryWriter.Write(newPlayer.male);
              binaryWriter.Write(newPlayer.statLife);
              binaryWriter.Write(newPlayer.statLifeMax);
              binaryWriter.Write(newPlayer.statMana);
              binaryWriter.Write(newPlayer.statManaMax);
              binaryWriter.Write(newPlayer.hairColor.R);
              binaryWriter.Write(newPlayer.hairColor.G);
              binaryWriter.Write(newPlayer.hairColor.B);
              binaryWriter.Write(newPlayer.skinColor.R);
              binaryWriter.Write(newPlayer.skinColor.G);
              binaryWriter.Write(newPlayer.skinColor.B);
              binaryWriter.Write(newPlayer.eyeColor.R);
              binaryWriter.Write(newPlayer.eyeColor.G);
              binaryWriter.Write(newPlayer.eyeColor.B);
              binaryWriter.Write(newPlayer.shirtColor.R);
              binaryWriter.Write(newPlayer.shirtColor.G);
              binaryWriter.Write(newPlayer.shirtColor.B);
              binaryWriter.Write(newPlayer.underShirtColor.R);
              binaryWriter.Write(newPlayer.underShirtColor.G);
              binaryWriter.Write(newPlayer.underShirtColor.B);
              binaryWriter.Write(newPlayer.pantsColor.R);
              binaryWriter.Write(newPlayer.pantsColor.G);
              binaryWriter.Write(newPlayer.pantsColor.B);
              binaryWriter.Write(newPlayer.shoeColor.R);
              binaryWriter.Write(newPlayer.shoeColor.G);
              binaryWriter.Write(newPlayer.shoeColor.B);
              for (int index = 0; index < 11; ++index)
              {
                if (newPlayer.armor[index].name == null)
                  newPlayer.armor[index].name = "";
                binaryWriter.Write(newPlayer.armor[index].netID);
                binaryWriter.Write(newPlayer.armor[index].prefix);
              }
              for (int index = 0; index < 48; ++index)
              {
                if (newPlayer.inventory[index].name == null)
                  newPlayer.inventory[index].name = "";
                binaryWriter.Write(newPlayer.inventory[index].netID);
                binaryWriter.Write(newPlayer.inventory[index].stack);
                binaryWriter.Write(newPlayer.inventory[index].prefix);
              }
              for (int index = 0; index < Chest.maxItems; ++index)
              {
                if (newPlayer.bank[index].name == null)
                  newPlayer.bank[index].name = "";
                binaryWriter.Write(newPlayer.bank[index].netID);
                binaryWriter.Write(newPlayer.bank[index].stack);
                binaryWriter.Write(newPlayer.bank[index].prefix);
              }
              for (int index = 0; index < Chest.maxItems; ++index)
              {
                if (newPlayer.bank2[index].name == null)
                  newPlayer.bank2[index].name = "";
                binaryWriter.Write(newPlayer.bank2[index].netID);
                binaryWriter.Write(newPlayer.bank2[index].stack);
                binaryWriter.Write(newPlayer.bank2[index].prefix);
              }
              for (int index = 0; index < 10; ++index)
              {
                binaryWriter.Write(newPlayer.buffType[index]);
                binaryWriter.Write(newPlayer.buffTime[index]);
              }
              for (int index = 0; index < 200; ++index)
              {
                if (newPlayer.spN[index] == null)
                {
                  binaryWriter.Write(-1);
                  break;
                }
                binaryWriter.Write(newPlayer.spX[index]);
                binaryWriter.Write(newPlayer.spY[index]);
                binaryWriter.Write(newPlayer.spI[index]);
                binaryWriter.Write(newPlayer.spN[index]);
              }
              binaryWriter.Write(newPlayer.hbLocked);
              binaryWriter.Close();
            }
          }
          Player.EncryptFile(str, playerPath);
          File.Delete(str);
          break;
      }
    }

    public static Player LoadPlayer(string playerPath)
    {
      if (Main.rand == null)
        Main.rand = new Random((int) DateTime.Now.Ticks);
      Player player = new Player();
      bool flag;
      try
      {
        string str = playerPath + ".dat";
        flag = Player.DecryptFile(playerPath, str);
        if (!flag)
        {
          using (FileStream fileStream = new FileStream(str, FileMode.Open))
          {
            using (BinaryReader binaryReader = new BinaryReader((Stream) fileStream))
            {
              int release = binaryReader.ReadInt32();
              player.name = binaryReader.ReadString();
              if (release >= 10)
              {
                if (release >= 17)
                  player.difficulty = binaryReader.ReadByte();
                else if (binaryReader.ReadBoolean())
                  player.difficulty = (byte) 2;
              }
              player.hair = binaryReader.ReadInt32();
              player.male = release > 17 ? binaryReader.ReadBoolean() : player.hair != 5 && player.hair != 6 && player.hair != 9 && player.hair != 11;
              player.statLife = binaryReader.ReadInt32();
              player.statLifeMax = binaryReader.ReadInt32();
              if (player.statLifeMax > 400)
                player.statLifeMax = 400;
              if (player.statLife > player.statLifeMax)
                player.statLife = player.statLifeMax;
              player.statMana = binaryReader.ReadInt32();
              player.statManaMax = binaryReader.ReadInt32();
              if (player.statManaMax > 200)
                player.statManaMax = 200;
              if (player.statMana > 400)
                player.statMana = 400;
              player.hairColor.R = binaryReader.ReadByte();
              player.hairColor.G = binaryReader.ReadByte();
              player.hairColor.B = binaryReader.ReadByte();
              player.skinColor.R = binaryReader.ReadByte();
              player.skinColor.G = binaryReader.ReadByte();
              player.skinColor.B = binaryReader.ReadByte();
              player.eyeColor.R = binaryReader.ReadByte();
              player.eyeColor.G = binaryReader.ReadByte();
              player.eyeColor.B = binaryReader.ReadByte();
              player.shirtColor.R = binaryReader.ReadByte();
              player.shirtColor.G = binaryReader.ReadByte();
              player.shirtColor.B = binaryReader.ReadByte();
              player.underShirtColor.R = binaryReader.ReadByte();
              player.underShirtColor.G = binaryReader.ReadByte();
              player.underShirtColor.B = binaryReader.ReadByte();
              player.pantsColor.R = binaryReader.ReadByte();
              player.pantsColor.G = binaryReader.ReadByte();
              player.pantsColor.B = binaryReader.ReadByte();
              player.shoeColor.R = binaryReader.ReadByte();
              player.shoeColor.G = binaryReader.ReadByte();
              player.shoeColor.B = binaryReader.ReadByte();
              Main.player[Main.myPlayer].shirtColor = player.shirtColor;
              Main.player[Main.myPlayer].pantsColor = player.pantsColor;
              Main.player[Main.myPlayer].hairColor = player.hairColor;
              if (release >= 38)
              {
                for (int index = 0; index < 11; ++index)
                {
                  player.armor[index].netDefaults(binaryReader.ReadInt32());
                  player.armor[index].Prefix((int) binaryReader.ReadByte());
                }
                for (int index = 0; index < 48; ++index)
                {
                  player.inventory[index].netDefaults(binaryReader.ReadInt32());
                  player.inventory[index].stack = binaryReader.ReadInt32();
                  player.inventory[index].Prefix((int) binaryReader.ReadByte());
                }
                for (int index = 0; index < Chest.maxItems; ++index)
                {
                  player.bank[index].netDefaults(binaryReader.ReadInt32());
                  player.bank[index].stack = binaryReader.ReadInt32();
                  player.bank[index].Prefix((int) binaryReader.ReadByte());
                }
                for (int index = 0; index < Chest.maxItems; ++index)
                {
                  player.bank2[index].netDefaults(binaryReader.ReadInt32());
                  player.bank2[index].stack = binaryReader.ReadInt32();
                  player.bank2[index].Prefix((int) binaryReader.ReadByte());
                }
              }
              else
              {
                for (int index = 0; index < 8; ++index)
                {
                  player.armor[index].SetDefaults(Item.VersionName(binaryReader.ReadString(), release));
                  if (release >= 36)
                    player.armor[index].Prefix((int) binaryReader.ReadByte());
                }
                if (release >= 6)
                {
                  for (int index = 8; index < 11; ++index)
                  {
                    player.armor[index].SetDefaults(Item.VersionName(binaryReader.ReadString(), release));
                    if (release >= 36)
                      player.armor[index].Prefix((int) binaryReader.ReadByte());
                  }
                }
                for (int index = 0; index < 44; ++index)
                {
                  player.inventory[index].SetDefaults(Item.VersionName(binaryReader.ReadString(), release));
                  player.inventory[index].stack = binaryReader.ReadInt32();
                  if (release >= 36)
                    player.inventory[index].Prefix((int) binaryReader.ReadByte());
                }
                if (release >= 15)
                {
                  for (int index = 44; index < 48; ++index)
                  {
                    player.inventory[index].SetDefaults(Item.VersionName(binaryReader.ReadString(), release));
                    player.inventory[index].stack = binaryReader.ReadInt32();
                    if (release >= 36)
                      player.inventory[index].Prefix((int) binaryReader.ReadByte());
                  }
                }
                for (int index = 0; index < Chest.maxItems; ++index)
                {
                  player.bank[index].SetDefaults(Item.VersionName(binaryReader.ReadString(), release));
                  player.bank[index].stack = binaryReader.ReadInt32();
                  if (release >= 36)
                    player.bank[index].Prefix((int) binaryReader.ReadByte());
                }
                if (release >= 20)
                {
                  for (int index = 0; index < Chest.maxItems; ++index)
                  {
                    player.bank2[index].SetDefaults(Item.VersionName(binaryReader.ReadString(), release));
                    player.bank2[index].stack = binaryReader.ReadInt32();
                    if (release >= 36)
                      player.bank2[index].Prefix((int) binaryReader.ReadByte());
                  }
                }
              }
              if (release >= 11)
              {
                for (int index = 0; index < 10; ++index)
                {
                  player.buffType[index] = binaryReader.ReadInt32();
                  player.buffTime[index] = binaryReader.ReadInt32();
                }
              }
              for (int index = 0; index < 200; ++index)
              {
                int num = binaryReader.ReadInt32();
                if (num != -1)
                {
                  player.spX[index] = num;
                  player.spY[index] = binaryReader.ReadInt32();
                  player.spI[index] = binaryReader.ReadInt32();
                  player.spN[index] = binaryReader.ReadString();
                }
                else
                  break;
              }
              if (release >= 16)
                player.hbLocked = binaryReader.ReadBoolean();
              binaryReader.Close();
            }
          }
          player.PlayerFrame();
          File.Delete(str);
          return player;
        }
      }
      catch
      {
        flag = true;
      }
      if (!flag)
        return new Player();
      try
      {
        string str = playerPath + ".bak";
        if (!File.Exists(str))
          return new Player();
        File.Delete(playerPath);
        File.Move(str, playerPath);
        return Player.LoadPlayer(playerPath);
      }
      catch
      {
        return new Player();
      }
    }

    public bool HasItem(int type)
    {
      for (int index = 0; index < 48; ++index)
      {
        if (type == this.inventory[index].type)
          return true;
      }
      return false;
    }

    public void QuickGrapple()
    {
      if (this.noItems)
        return;
      int index1 = -1;
      for (int index2 = 0; index2 < 48; ++index2)
      {
        if (this.inventory[index2].shoot == 13 || this.inventory[index2].shoot == 32 || this.inventory[index2].shoot == 73)
        {
          index1 = index2;
          break;
        }
      }
      if (index1 < 0)
        return;
      if (this.inventory[index1].shoot == 73)
      {
        int num = 0;
        if (index1 >= 0)
        {
          for (int index3 = 0; index3 < 1000; ++index3)
          {
            if (Main.projectile[index3].active && Main.projectile[index3].owner == Main.myPlayer && (Main.projectile[index3].type == 73 || Main.projectile[index3].type == 74))
              ++num;
          }
        }
        if (num > 1)
          index1 = -1;
      }
      else if (index1 >= 0)
      {
        for (int index4 = 0; index4 < 1000; ++index4)
        {
          if (Main.projectile[index4].active && Main.projectile[index4].owner == Main.myPlayer && Main.projectile[index4].type == this.inventory[index1].shoot && (double) Main.projectile[index4].ai[0] != 2.0)
          {
            index1 = -1;
            break;
          }
        }
      }
      if (index1 < 0)
        return;
      Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, this.inventory[index1].useSound);
      if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
        NetMessage.SendData(51, number: this.whoAmi, number2: 2f);
      int Type = this.inventory[index1].shoot;
      float shootSpeed = this.inventory[index1].shootSpeed;
      int damage = this.inventory[index1].damage;
      float knockBack = this.inventory[index1].knockBack;
      if (Type == 13 || Type == 32)
      {
        this.grappling[0] = -1;
        this.grapCount = 0;
        for (int index5 = 0; index5 < 1000; ++index5)
        {
          if (Main.projectile[index5].active && Main.projectile[index5].owner == this.whoAmi && Main.projectile[index5].type == 13)
            Main.projectile[index5].Kill();
        }
      }
      if (Type == 73)
      {
        for (int index6 = 0; index6 < 1000; ++index6)
        {
          if (Main.projectile[index6].active && Main.projectile[index6].owner == this.whoAmi && Main.projectile[index6].type == 73)
            Type = 74;
        }
      }
      Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
      float num1 = (float) Main.mouseX + Main.screenPosition.X - vector2.X;
      float num2 = (float) Main.mouseY + Main.screenPosition.Y - vector2.Y;
      float num3 = (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
      float num4 = shootSpeed / num3;
      float SpeedX = num1 * num4;
      float SpeedY = num2 * num4;
      Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, damage, knockBack, this.whoAmi);
    }

    public Player()
    {
      for (int index = 0; index < 49; ++index)
      {
        if (index < 11)
        {
          this.armor[index] = new Item();
          this.armor[index].name = "";
        }
        this.inventory[index] = new Item();
        this.inventory[index].name = "";
      }
      for (int index = 0; index < Chest.maxItems; ++index)
      {
        this.bank[index] = new Item();
        this.bank[index].name = "";
        this.bank2[index] = new Item();
        this.bank2[index].name = "";
      }
      this.grappling[0] = -1;
      this.inventory[0].SetDefaults("Copper Shortsword");
      this.inventory[1].SetDefaults("Copper Pickaxe");
      this.inventory[2].SetDefaults("Copper Axe");
      if (Main.cEd)
        this.inventory[3].SetDefaults(603);
      for (int index = 0; index < 150; ++index)
      {
        this.adjTile[index] = false;
        this.oldAdjTile[index] = false;
      }
    }
  }
}
