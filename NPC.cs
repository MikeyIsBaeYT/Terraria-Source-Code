// Decompiled with JetBrains decompiler
// Type: Terraria.NPC
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
  public class NPC
  {
    public const int maxBuffs = 5;
    public static int immuneTime = 20;
    public static int maxAI = 4;
    public int netSpam;
    private static int spawnSpaceX = 3;
    private static int spawnSpaceY = 3;
    private static int maxAttack = 20;
    private static int[] attackNPC = new int[NPC.maxAttack];
    public Vector2[] oldPos = new Vector2[10];
    public int netSkip;
    public bool netAlways;
    public int realLife = -1;
    public static int sWidth = 1920;
    public static int sHeight = 1080;
    private static int spawnRangeX = (int) ((double) (NPC.sWidth / 16) * 0.7);
    private static int spawnRangeY = (int) ((double) (NPC.sHeight / 16) * 0.7);
    public static int safeRangeX = (int) ((double) (NPC.sWidth / 16) * 0.52);
    public static int safeRangeY = (int) ((double) (NPC.sHeight / 16) * 0.52);
    private static int activeRangeX = (int) ((double) NPC.sWidth * 1.7);
    private static int activeRangeY = (int) ((double) NPC.sHeight * 1.7);
    private static int townRangeX = NPC.sWidth;
    private static int townRangeY = NPC.sHeight;
    public float npcSlots = 1f;
    private static bool noSpawnCycle = false;
    private static int activeTime = 750;
    private static int defaultSpawnRate = 600;
    private static int defaultMaxSpawns = 5;
    public bool wet;
    public byte wetCount;
    public bool lavaWet;
    public int[] buffType = new int[5];
    public int[] buffTime = new int[5];
    public bool[] buffImmune = new bool[41];
    public bool onFire;
    public bool onFire2;
    public bool poisoned;
    public int lifeRegen;
    public int lifeRegenCount;
    public bool confused;
    public static bool downedBoss1 = false;
    public static bool downedBoss2 = false;
    public static bool downedBoss3 = false;
    public static bool savedGoblin = false;
    public static bool savedWizard = false;
    public static bool savedMech = false;
    public static bool downedGoblins = false;
    public static bool downedFrost = false;
    public static bool downedClown = false;
    private static int spawnRate = NPC.defaultSpawnRate;
    private static int maxSpawns = NPC.defaultMaxSpawns;
    public int soundDelay;
    public Vector2 position;
    public Vector2 velocity;
    public Vector2 oldPosition;
    public Vector2 oldVelocity;
    public int width;
    public int height;
    public bool active;
    public int[] immune = new int[256];
    public int direction = 1;
    public int directionY = 1;
    public int type;
    public float[] ai = new float[NPC.maxAI];
    public float[] localAI = new float[NPC.maxAI];
    public int aiAction;
    public int aiStyle;
    public bool justHit;
    public int timeLeft;
    public int target = -1;
    public int damage;
    public int defense;
    public int defDamage;
    public int defDefense;
    public int soundHit;
    public int soundKilled;
    public int life;
    public int lifeMax;
    public Rectangle targetRect;
    public double frameCounter;
    public Rectangle frame;
    public string name;
    public string displayName;
    public Color color;
    public int alpha;
    public float scale = 1f;
    public float knockBackResist = 1f;
    public int oldDirection;
    public int oldDirectionY;
    public int oldTarget;
    public int whoAmI;
    public float rotation;
    public bool noGravity;
    public bool noTileCollide;
    public bool netUpdate;
    public bool netUpdate2;
    public bool collideX;
    public bool collideY;
    public bool boss;
    public int spriteDirection = -1;
    public bool behindTiles;
    public bool lavaImmune;
    public float value;
    public bool dontTakeDamage;
    public int netID;
    public bool townNPC;
    public bool homeless;
    public int homeTileX = -1;
    public int homeTileY = -1;
    public bool oldHomeless;
    public int oldHomeTileX = -1;
    public int oldHomeTileY = -1;
    public bool friendly;
    public bool closeDoor;
    public int doorX;
    public int doorY;
    public int friendlyRegen;

    public static void clrNames()
    {
      for (int index = 0; index < 147; ++index)
        Main.chrName[index] = "";
    }

    public static void setNames()
    {
      if (WorldGen.genRand == null)
        WorldGen.genRand = new Random();
      int num1 = WorldGen.genRand.Next(23);
      string str1 = "";
      string str2;
      switch (num1)
      {
        case 0:
          str2 = "Molly";
          break;
        case 1:
          str2 = "Amy";
          break;
        case 2:
          str2 = "Claire";
          break;
        case 3:
          str2 = "Emily";
          break;
        case 4:
          str2 = "Katie";
          break;
        case 5:
          str2 = "Madeline";
          break;
        case 6:
          str2 = "Katelyn";
          break;
        case 7:
          str2 = "Emma";
          break;
        case 8:
          str2 = "Abigail";
          break;
        case 9:
          str2 = "Carly";
          break;
        case 10:
          str2 = "Jenna";
          break;
        case 11:
          str2 = "Heather";
          break;
        case 12:
          str2 = "Katherine";
          break;
        case 13:
          str2 = "Caitlin";
          break;
        case 14:
          str2 = "Kaitlin";
          break;
        case 15:
          str2 = "Holly";
          break;
        case 16:
          str2 = "Kaitlyn";
          break;
        case 17:
          str2 = "Hannah";
          break;
        case 18:
          str2 = "Kathryn";
          break;
        case 19:
          str2 = "Lorraine";
          break;
        case 20:
          str2 = "Helen";
          break;
        case 21:
          str2 = "Kayla";
          break;
        default:
          str2 = "Allison";
          break;
      }
      if (Main.chrName[18] == "")
        Main.chrName[18] = str2;
      int num2 = WorldGen.genRand.Next(24);
      str1 = "";
      string str3;
      switch (num2)
      {
        case 0:
          str3 = "Shayna";
          break;
        case 1:
          str3 = "Korrie";
          break;
        case 2:
          str3 = "Ginger";
          break;
        case 3:
          str3 = "Brooke";
          break;
        case 4:
          str3 = "Jenny";
          break;
        case 5:
          str3 = "Autumn";
          break;
        case 6:
          str3 = "Nancy";
          break;
        case 7:
          str3 = "Ella";
          break;
        case 8:
          str3 = "Kayla";
          break;
        case 9:
          str3 = "Beth";
          break;
        case 10:
          str3 = "Sophia";
          break;
        case 11:
          str3 = "Marshanna";
          break;
        case 12:
          str3 = "Lauren";
          break;
        case 13:
          str3 = "Trisha";
          break;
        case 14:
          str3 = "Shirlena";
          break;
        case 15:
          str3 = "Sheena";
          break;
        case 16:
          str3 = "Ellen";
          break;
        case 17:
          str3 = "Amy";
          break;
        case 18:
          str3 = "Dawn";
          break;
        case 19:
          str3 = "Susana";
          break;
        case 20:
          str3 = "Meredith";
          break;
        case 21:
          str3 = "Selene";
          break;
        case 22:
          str3 = "Terra";
          break;
        default:
          str3 = "Sally";
          break;
      }
      if (Main.chrName[124] == "")
        Main.chrName[124] = str3;
      int num3 = WorldGen.genRand.Next(23);
      str1 = "";
      string str4;
      switch (num3)
      {
        case 0:
          str4 = "DeShawn";
          break;
        case 1:
          str4 = "DeAndre";
          break;
        case 2:
          str4 = "Marquis";
          break;
        case 3:
          str4 = "Darnell";
          break;
        case 4:
          str4 = "Terrell";
          break;
        case 5:
          str4 = "Malik";
          break;
        case 6:
          str4 = "Trevon";
          break;
        case 7:
          str4 = "Tyrone";
          break;
        case 8:
          str4 = "Willie";
          break;
        case 9:
          str4 = "Dominique";
          break;
        case 10:
          str4 = "Demetrius";
          break;
        case 11:
          str4 = "Reginald";
          break;
        case 12:
          str4 = "Jamal";
          break;
        case 13:
          str4 = "Maurice";
          break;
        case 14:
          str4 = "Jalen";
          break;
        case 15:
          str4 = "Darius";
          break;
        case 16:
          str4 = "Xavier";
          break;
        case 17:
          str4 = "Terrance";
          break;
        case 18:
          str4 = "Andre";
          break;
        case 19:
          str4 = "Dante";
          break;
        case 20:
          str4 = "Brimst";
          break;
        case 21:
          str4 = "Bronson";
          break;
        default:
          str4 = "Darryl";
          break;
      }
      if (Main.chrName[19] == "")
        Main.chrName[19] = str4;
      int num4 = WorldGen.genRand.Next(35);
      str1 = "";
      string str5;
      switch (num4)
      {
        case 0:
          str5 = "Jake";
          break;
        case 1:
          str5 = "Connor";
          break;
        case 2:
          str5 = "Tanner";
          break;
        case 3:
          str5 = "Wyatt";
          break;
        case 4:
          str5 = "Cody";
          break;
        case 5:
          str5 = "Dustin";
          break;
        case 6:
          str5 = "Luke";
          break;
        case 7:
          str5 = "Jack";
          break;
        case 8:
          str5 = "Scott";
          break;
        case 9:
          str5 = "Logan";
          break;
        case 10:
          str5 = "Cole";
          break;
        case 11:
          str5 = "Lucas";
          break;
        case 12:
          str5 = "Bradley";
          break;
        case 13:
          str5 = "Jacob";
          break;
        case 14:
          str5 = "Garrett";
          break;
        case 15:
          str5 = "Dylan";
          break;
        case 16:
          str5 = "Maxwell";
          break;
        case 17:
          str5 = "Steve";
          break;
        case 18:
          str5 = "Brett";
          break;
        case 19:
          str5 = "Andrew";
          break;
        case 20:
          str5 = "Harley";
          break;
        case 21:
          str5 = "Kyle";
          break;
        case 22:
          str5 = "Jake";
          break;
        case 23:
          str5 = "Ryan";
          break;
        case 24:
          str5 = "Jeffrey";
          break;
        case 25:
          str5 = "Seth";
          break;
        case 26:
          str5 = "Marty";
          break;
        case 27:
          str5 = "Brandon";
          break;
        case 28:
          str5 = "Zach";
          break;
        case 29:
          str5 = "Jeff";
          break;
        case 30:
          str5 = "Daniel";
          break;
        case 31:
          str5 = "Trent";
          break;
        case 32:
          str5 = "Kevin";
          break;
        case 33:
          str5 = "Brian";
          break;
        default:
          str5 = "Colin";
          break;
      }
      if (Main.chrName[22] == "")
        Main.chrName[22] = str5;
      int num5 = WorldGen.genRand.Next(22);
      str1 = "";
      string str6;
      switch (num5)
      {
        case 0:
          str6 = "Alalia";
          break;
        case 1:
          str6 = "Alalia";
          break;
        case 2:
          str6 = "Alura";
          break;
        case 3:
          str6 = "Ariella";
          break;
        case 4:
          str6 = "Caelia";
          break;
        case 5:
          str6 = "Calista";
          break;
        case 6:
          str6 = "Chryseis";
          break;
        case 7:
          str6 = "Emerenta";
          break;
        case 8:
          str6 = "Elysia";
          break;
        case 9:
          str6 = "Evvie";
          break;
        case 10:
          str6 = "Faye";
          break;
        case 11:
          str6 = "Felicitae";
          break;
        case 12:
          str6 = "Lunette";
          break;
        case 13:
          str6 = "Nata";
          break;
        case 14:
          str6 = "Nissa";
          break;
        case 15:
          str6 = "Tatiana";
          break;
        case 16:
          str6 = "Rosalva";
          break;
        case 17:
          str6 = "Shea";
          break;
        case 18:
          str6 = "Tania";
          break;
        case 19:
          str6 = "Isis";
          break;
        case 20:
          str6 = "Celestia";
          break;
        default:
          str6 = "Xylia";
          break;
      }
      if (Main.chrName[20] == "")
        Main.chrName[20] = str6;
      int num6 = WorldGen.genRand.Next(22);
      str1 = "";
      string str7;
      switch (num6)
      {
        case 0:
          str7 = "Dolbere";
          break;
        case 1:
          str7 = "Bazdin";
          break;
        case 2:
          str7 = "Durim";
          break;
        case 3:
          str7 = "Tordak";
          break;
        case 4:
          str7 = "Garval";
          break;
        case 5:
          str7 = "Morthal";
          break;
        case 6:
          str7 = "Oten";
          break;
        case 7:
          str7 = "Dolgen";
          break;
        case 8:
          str7 = "Gimli";
          break;
        case 9:
          str7 = "Gimut";
          break;
        case 10:
          str7 = "Duerthen";
          break;
        case 11:
          str7 = "Beldin";
          break;
        case 12:
          str7 = "Jarut";
          break;
        case 13:
          str7 = "Ovbere";
          break;
        case 14:
          str7 = "Norkas";
          break;
        case 15:
          str7 = "Dolgrim";
          break;
        case 16:
          str7 = "Boften";
          break;
        case 17:
          str7 = "Norsun";
          break;
        case 18:
          str7 = "Dias";
          break;
        case 19:
          str7 = "Fikod";
          break;
        case 20:
          str7 = "Urist";
          break;
        default:
          str7 = "Darur";
          break;
      }
      if (Main.chrName[38] == "")
        Main.chrName[38] = str7;
      int num7 = WorldGen.genRand.Next(21);
      str1 = "";
      string str8;
      switch (num7)
      {
        case 0:
          str8 = "Dalamar";
          break;
        case 1:
          str8 = "Dulais";
          break;
        case 2:
          str8 = "Elric";
          break;
        case 3:
          str8 = "Arddun";
          break;
        case 4:
          str8 = "Maelor";
          break;
        case 5:
          str8 = "Leomund";
          break;
        case 6:
          str8 = "Hirael";
          break;
        case 7:
          str8 = "Gwentor";
          break;
        case 8:
          str8 = "Greum";
          break;
        case 9:
          str8 = "Gearroid";
          break;
        case 10:
          str8 = "Fizban";
          break;
        case 11:
          str8 = "Ningauble";
          break;
        case 12:
          str8 = "Seonag";
          break;
        case 13:
          str8 = "Sargon";
          break;
        case 14:
          str8 = "Merlyn";
          break;
        case 15:
          str8 = "Magius";
          break;
        case 16:
          str8 = "Berwyn";
          break;
        case 17:
          str8 = "Arwyn";
          break;
        case 18:
          str8 = "Alasdair";
          break;
        case 19:
          str8 = "Tagar";
          break;
        default:
          str8 = "Xanadu";
          break;
      }
      if (Main.chrName[108] == "")
        Main.chrName[108] = str8;
      int num8 = WorldGen.genRand.Next(23);
      str1 = "";
      string str9;
      switch (num8)
      {
        case 0:
          str9 = "Alfred";
          break;
        case 1:
          str9 = "Barney";
          break;
        case 2:
          str9 = "Calvin";
          break;
        case 3:
          str9 = "Edmund";
          break;
        case 4:
          str9 = "Edwin";
          break;
        case 5:
          str9 = "Eugene";
          break;
        case 6:
          str9 = "Frank";
          break;
        case 7:
          str9 = "Frederick";
          break;
        case 8:
          str9 = "Gilbert";
          break;
        case 9:
          str9 = "Gus";
          break;
        case 10:
          str9 = "Wilbur";
          break;
        case 11:
          str9 = "Seymour";
          break;
        case 12:
          str9 = "Louis";
          break;
        case 13:
          str9 = "Humphrey";
          break;
        case 14:
          str9 = "Harold";
          break;
        case 15:
          str9 = "Milton";
          break;
        case 16:
          str9 = "Mortimer";
          break;
        case 17:
          str9 = "Howard";
          break;
        case 18:
          str9 = "Walter";
          break;
        case 19:
          str9 = "Finn";
          break;
        case 20:
          str9 = "Isacc";
          break;
        case 21:
          str9 = "Joseph";
          break;
        default:
          str9 = "Ralph";
          break;
      }
      if (Main.chrName[17] == "")
        Main.chrName[17] = str9;
      int num9 = WorldGen.genRand.Next(24);
      str1 = "";
      string str10;
      switch (num9)
      {
        case 0:
          str10 = "Sebastian";
          break;
        case 1:
          str10 = "Rupert";
          break;
        case 2:
          str10 = "Clive";
          break;
        case 3:
          str10 = "Nigel";
          break;
        case 4:
          str10 = "Mervyn";
          break;
        case 5:
          str10 = "Cedric";
          break;
        case 6:
          str10 = "Pip";
          break;
        case 7:
          str10 = "Cyril";
          break;
        case 8:
          str10 = "Fitz";
          break;
        case 9:
          str10 = "Lloyd";
          break;
        case 10:
          str10 = "Arthur";
          break;
        case 11:
          str10 = "Rodney";
          break;
        case 12:
          str10 = "Graham";
          break;
        case 13:
          str10 = "Edward";
          break;
        case 14:
          str10 = "Alfred";
          break;
        case 15:
          str10 = "Edmund";
          break;
        case 16:
          str10 = "Henry";
          break;
        case 17:
          str10 = "Herald";
          break;
        case 18:
          str10 = "Roland";
          break;
        case 19:
          str10 = "Lincoln";
          break;
        case 20:
          str10 = "Lloyd";
          break;
        case 21:
          str10 = "Edgar";
          break;
        case 22:
          str10 = "Eustace";
          break;
        default:
          str10 = "Rodrick";
          break;
      }
      if (Main.chrName[54] == "")
        Main.chrName[54] = str10;
      int num10 = WorldGen.genRand.Next(25);
      str1 = "";
      string str11;
      switch (num10)
      {
        case 0:
          str11 = "Grodax";
          break;
        case 1:
          str11 = "Sarx";
          break;
        case 2:
          str11 = "Xon";
          break;
        case 3:
          str11 = "Mrunok";
          break;
        case 4:
          str11 = "Nuxatk";
          break;
        case 5:
          str11 = "Tgerd";
          break;
        case 6:
          str11 = "Darz";
          break;
        case 7:
          str11 = "Smador";
          break;
        case 8:
          str11 = "Stazen";
          break;
        case 9:
          str11 = "Mobart";
          break;
        case 10:
          str11 = "Knogs";
          break;
        case 11:
          str11 = "Tkanus";
          break;
        case 12:
          str11 = "Negurk";
          break;
        case 13:
          str11 = "Nort";
          break;
        case 14:
          str11 = "Durnok";
          break;
        case 15:
          str11 = "Trogem";
          break;
        case 16:
          str11 = "Stezom";
          break;
        case 17:
          str11 = "Gnudar";
          break;
        case 18:
          str11 = "Ragz";
          break;
        case 19:
          str11 = "Fahd";
          break;
        case 20:
          str11 = "Xanos";
          break;
        case 21:
          str11 = "Arback";
          break;
        case 22:
          str11 = "Fjell";
          break;
        case 23:
          str11 = "Dalek";
          break;
        default:
          str11 = "Knub";
          break;
      }
      if (!(Main.chrName[107] == ""))
        return;
      Main.chrName[107] = str11;
    }

    public void netDefaults(int type)
    {
      if (type < 0)
      {
        switch (type)
        {
          case -17:
            this.SetDefaults("Big Stinger");
            break;
          case -16:
            this.SetDefaults("Little Stinger");
            break;
          case -15:
            this.SetDefaults("Heavy Skeleton");
            break;
          case -14:
            this.SetDefaults("Big Boned");
            break;
          case -13:
            this.SetDefaults("Short Bones");
            break;
          case -12:
            this.SetDefaults("Big Eater");
            break;
          case -11:
            this.SetDefaults("Little Eater");
            break;
          case -10:
            this.SetDefaults("Jungle Slime");
            break;
          case -9:
            this.SetDefaults("Yellow Slime");
            break;
          case -8:
            this.SetDefaults("Red Slime");
            break;
          case -7:
            this.SetDefaults("Purple Slime");
            break;
          case -6:
            this.SetDefaults("Black Slime");
            break;
          case -5:
            this.SetDefaults("Baby Slime");
            break;
          case -4:
            this.SetDefaults("Pinky");
            break;
          case -3:
            this.SetDefaults("Green Slime");
            break;
          case -2:
            this.SetDefaults("Slimer2");
            break;
          case -1:
            this.SetDefaults("Slimeling");
            break;
        }
      }
      else
        this.SetDefaults(type);
    }

    public void SetDefaults(string Name)
    {
      this.SetDefaults(0);
      if (Name == "Slimeling")
      {
        this.SetDefaults(81, 0.6f);
        this.name = Name;
        this.damage = 45;
        this.defense = 10;
        this.life = 90;
        this.knockBackResist = 1.2f;
        this.value = 100f;
        this.netID = -1;
      }
      else if (Name == "Slimer2")
      {
        this.SetDefaults(81, 0.9f);
        this.displayName = "Slimer";
        this.name = Name;
        this.damage = 45;
        this.defense = 20;
        this.life = 90;
        this.knockBackResist = 1.2f;
        this.value = 100f;
        this.netID = -2;
      }
      else if (Name == "Green Slime")
      {
        this.SetDefaults(1, 0.9f);
        this.name = Name;
        this.damage = 6;
        this.defense = 0;
        this.life = 14;
        this.knockBackResist = 1.2f;
        this.color = new Color(0, 220, 40, 100);
        this.value = 3f;
        this.netID = -3;
      }
      else if (Name == "Pinky")
      {
        this.SetDefaults(1, 0.6f);
        this.name = Name;
        this.damage = 5;
        this.defense = 5;
        this.life = 150;
        this.knockBackResist = 1.4f;
        this.color = new Color(250, 30, 90, 90);
        this.value = 10000f;
        this.netID = -4;
      }
      else if (Name == "Baby Slime")
      {
        this.SetDefaults(1, 0.9f);
        this.name = Name;
        this.damage = 13;
        this.defense = 4;
        this.life = 30;
        this.knockBackResist = 0.95f;
        this.alpha = 120;
        this.color = new Color(0, 0, 0, 50);
        this.value = 10f;
        this.netID = -5;
      }
      else if (Name == "Black Slime")
      {
        this.SetDefaults(1);
        this.name = Name;
        this.damage = 15;
        this.defense = 4;
        this.life = 45;
        this.color = new Color(0, 0, 0, 50);
        this.value = 20f;
        this.netID = -6;
      }
      else if (Name == "Purple Slime")
      {
        this.SetDefaults(1, 1.2f);
        this.name = Name;
        this.damage = 12;
        this.defense = 6;
        this.life = 40;
        this.knockBackResist = 0.9f;
        this.color = new Color(200, 0, (int) byte.MaxValue, 150);
        this.value = 10f;
        this.netID = -7;
      }
      else if (Name == "Red Slime")
      {
        this.SetDefaults(1);
        this.name = Name;
        this.damage = 12;
        this.defense = 4;
        this.life = 35;
        this.color = new Color((int) byte.MaxValue, 30, 0, 100);
        this.value = 8f;
        this.netID = -8;
      }
      else if (Name == "Yellow Slime")
      {
        this.SetDefaults(1, 1.2f);
        this.name = Name;
        this.damage = 15;
        this.defense = 7;
        this.life = 45;
        this.color = new Color((int) byte.MaxValue, (int) byte.MaxValue, 0, 100);
        this.value = 10f;
        this.netID = -9;
      }
      else if (Name == "Jungle Slime")
      {
        this.SetDefaults(1, 1.1f);
        this.name = Name;
        this.damage = 18;
        this.defense = 6;
        this.life = 60;
        this.color = new Color(143, 215, 93, 100);
        this.value = 500f;
        this.netID = -10;
      }
      else if (Name == "Little Eater")
      {
        this.SetDefaults(6, 0.85f);
        this.name = Name;
        this.defense = (int) ((double) this.defense * (double) this.scale);
        this.damage = (int) ((double) this.damage * (double) this.scale);
        this.life = (int) ((double) this.life * (double) this.scale);
        this.value = (float) (int) ((double) this.value * (double) this.scale);
        this.npcSlots *= this.scale;
        this.knockBackResist *= 2f - this.scale;
        this.netID = -11;
      }
      else if (Name == "Big Eater")
      {
        this.SetDefaults(6, 1.15f);
        this.name = Name;
        this.defense = (int) ((double) this.defense * (double) this.scale);
        this.damage = (int) ((double) this.damage * (double) this.scale);
        this.life = (int) ((double) this.life * (double) this.scale);
        this.value = (float) (int) ((double) this.value * (double) this.scale);
        this.npcSlots *= this.scale;
        this.knockBackResist *= 2f - this.scale;
        this.netID = -12;
      }
      else if (Name == "Short Bones")
      {
        this.SetDefaults(31, 0.9f);
        this.name = Name;
        this.defense = (int) ((double) this.defense * (double) this.scale);
        this.damage = (int) ((double) this.damage * (double) this.scale);
        this.life = (int) ((double) this.life * (double) this.scale);
        this.value = (float) (int) ((double) this.value * (double) this.scale);
        this.netID = -13;
      }
      else if (Name == "Big Boned")
      {
        this.SetDefaults(31, 1.15f);
        this.name = Name;
        this.defense = (int) ((double) this.defense * (double) this.scale);
        this.damage = (int) ((double) this.damage * (double) this.scale * 1.1);
        this.life = (int) ((double) this.life * (double) this.scale * 1.1);
        this.value = (float) (int) ((double) this.value * (double) this.scale);
        this.npcSlots = 2f;
        this.knockBackResist *= 2f - this.scale;
        this.netID = -14;
      }
      else if (Name == "Heavy Skeleton")
      {
        this.SetDefaults(77, 1.15f);
        this.name = Name;
        this.defense = (int) ((double) this.defense * (double) this.scale);
        this.damage = (int) ((double) this.damage * (double) this.scale * 1.1);
        this.life = 400;
        this.value = (float) (int) ((double) this.value * (double) this.scale);
        this.npcSlots = 2f;
        this.knockBackResist *= 2f - this.scale;
        this.height = 44;
        this.netID = -15;
      }
      else if (Name == "Little Stinger")
      {
        this.SetDefaults(42, 0.85f);
        this.name = Name;
        this.defense = (int) ((double) this.defense * (double) this.scale);
        this.damage = (int) ((double) this.damage * (double) this.scale);
        this.life = (int) ((double) this.life * (double) this.scale);
        this.value = (float) (int) ((double) this.value * (double) this.scale);
        this.npcSlots *= this.scale;
        this.knockBackResist *= 2f - this.scale;
        this.netID = -16;
      }
      else if (Name == "Big Stinger")
      {
        this.SetDefaults(42, 1.2f);
        this.name = Name;
        this.defense = (int) ((double) this.defense * (double) this.scale);
        this.damage = (int) ((double) this.damage * (double) this.scale);
        this.life = (int) ((double) this.life * (double) this.scale);
        this.value = (float) (int) ((double) this.value * (double) this.scale);
        this.npcSlots *= this.scale;
        this.knockBackResist *= 2f - this.scale;
        this.netID = -17;
      }
      else if (Name != "")
      {
        for (int Type = 1; Type < 147; ++Type)
        {
          if (Main.npcName[Type] == Name)
          {
            this.SetDefaults(Type);
            return;
          }
        }
        this.SetDefaults(0);
        this.active = false;
      }
      else
        this.active = false;
      this.displayName = Lang.npcName(this.netID);
      this.lifeMax = this.life;
      this.defDamage = this.damage;
      this.defDefense = this.defense;
    }

    public static bool MechSpawn(float x, float y, int type)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      for (int index = 0; index < 200; ++index)
      {
        if (Main.npc[index].active && Main.npc[index].type == type)
        {
          ++num1;
          Vector2 vector2 = new Vector2(x, y);
          float num4 = Main.npc[index].position.X - vector2.X;
          float num5 = Main.npc[index].position.Y - vector2.Y;
          float num6 = (float) Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5);
          if ((double) num6 < 200.0)
            ++num2;
          if ((double) num6 < 600.0)
            ++num3;
        }
      }
      return num2 < 3 && num3 < 6 && num1 < 10;
    }

    public static int TypeToNum(int type)
    {
      switch (type)
      {
        case 17:
          return 2;
        case 18:
          return 3;
        case 19:
          return 6;
        case 20:
          return 5;
        case 22:
          return 1;
        case 38:
          return 4;
        case 54:
          return 7;
        case 107:
          return 9;
        case 108:
          return 10;
        case 124:
          return 8;
        case 142:
          return 11;
        default:
          return -1;
      }
    }

    public static int NumToType(int type)
    {
      switch (type)
      {
        case 1:
          return 22;
        case 2:
          return 17;
        case 3:
          return 18;
        case 4:
          return 38;
        case 5:
          return 20;
        case 6:
          return 19;
        case 7:
          return 54;
        case 8:
          return 124;
        case 9:
          return 107;
        case 10:
          return 108;
        case 11:
          return 142;
        default:
          return -1;
      }
    }

    public void SetDefaults(int Type, float scaleOverride = -1f)
    {
      this.netID = 0;
      this.netAlways = false;
      this.netSpam = 0;
      for (int index = 0; index < this.oldPos.Length; ++index)
      {
        this.oldPos[index].X = 0.0f;
        this.oldPos[index].Y = 0.0f;
      }
      for (int index = 0; index < 5; ++index)
      {
        this.buffTime[index] = 0;
        this.buffType[index] = 0;
      }
      for (int index = 0; index < 41; ++index)
        this.buffImmune[index] = false;
      this.buffImmune[31] = true;
      this.netSkip = -2;
      this.realLife = -1;
      this.lifeRegen = 0;
      this.lifeRegenCount = 0;
      this.poisoned = false;
      this.onFire = false;
      this.confused = false;
      this.onFire2 = false;
      this.justHit = false;
      this.dontTakeDamage = false;
      this.npcSlots = 1f;
      this.lavaImmune = false;
      this.lavaWet = false;
      this.wetCount = (byte) 0;
      this.wet = false;
      this.townNPC = false;
      this.homeless = false;
      this.homeTileX = -1;
      this.homeTileY = -1;
      this.friendly = false;
      this.behindTiles = false;
      this.boss = false;
      this.noTileCollide = false;
      this.rotation = 0.0f;
      this.active = true;
      this.alpha = 0;
      this.color = new Color();
      this.collideX = false;
      this.collideY = false;
      this.direction = 0;
      this.oldDirection = this.direction;
      this.frameCounter = 0.0;
      this.netUpdate = true;
      this.netUpdate2 = false;
      this.knockBackResist = 1f;
      this.name = "";
      this.displayName = "";
      this.noGravity = false;
      this.scale = 1f;
      this.soundHit = 0;
      this.soundKilled = 0;
      this.spriteDirection = -1;
      this.target = (int) byte.MaxValue;
      this.oldTarget = this.target;
      this.targetRect = new Rectangle();
      this.timeLeft = NPC.activeTime;
      this.type = Type;
      this.value = 0.0f;
      for (int index = 0; index < NPC.maxAI; ++index)
        this.ai[index] = 0.0f;
      for (int index = 0; index < NPC.maxAI; ++index)
        this.localAI[index] = 0.0f;
      if (this.type == 1)
      {
        this.name = "Blue Slime";
        this.width = 24;
        this.height = 18;
        this.aiStyle = 1;
        this.damage = 7;
        this.defense = 2;
        this.lifeMax = 25;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.alpha = 175;
        this.color = new Color(0, 80, (int) byte.MaxValue, 100);
        this.value = 25f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if (this.type == 2)
      {
        this.name = "Demon Eye";
        this.width = 30;
        this.height = 32;
        this.aiStyle = 2;
        this.damage = 18;
        this.defense = 2;
        this.lifeMax = 60;
        this.soundHit = 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = 1;
        this.value = 75f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 3)
      {
        this.name = "Zombie";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 14;
        this.defense = 6;
        this.lifeMax = 45;
        this.soundHit = 1;
        this.soundKilled = 2;
        this.knockBackResist = 0.5f;
        this.value = 60f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 4)
      {
        this.name = "Eye of Cthulhu";
        this.width = 100;
        this.height = 110;
        this.aiStyle = 4;
        this.damage = 15;
        this.defense = 12;
        this.lifeMax = 2800;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.0f;
        this.noGravity = true;
        this.noTileCollide = true;
        this.timeLeft = NPC.activeTime * 30;
        this.boss = true;
        this.value = 30000f;
        this.npcSlots = 5f;
      }
      else if (this.type == 5)
      {
        this.name = "Servant of Cthulhu";
        this.width = 20;
        this.height = 20;
        this.aiStyle = 5;
        this.damage = 12;
        this.defense = 0;
        this.lifeMax = 8;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.noGravity = true;
        this.noTileCollide = true;
      }
      else if (this.type == 6)
      {
        this.npcSlots = 1f;
        this.name = "Eater of Souls";
        this.width = 30;
        this.height = 30;
        this.aiStyle = 5;
        this.damage = 22;
        this.defense = 8;
        this.lifeMax = 40;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.noGravity = true;
        this.knockBackResist = 0.5f;
        this.value = 90f;
      }
      else if (this.type == 7)
      {
        this.displayName = "Devourer";
        this.npcSlots = 3.5f;
        this.name = "Devourer Head";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 6;
        this.damage = 31;
        this.defense = 2;
        this.lifeMax = 100;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 140f;
        this.netAlways = true;
      }
      else if (this.type == 8)
      {
        this.displayName = "Devourer";
        this.name = "Devourer Body";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 16;
        this.defense = 6;
        this.lifeMax = 100;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 140f;
      }
      else if (this.type == 9)
      {
        this.displayName = "Devourer";
        this.name = "Devourer Tail";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 13;
        this.defense = 10;
        this.lifeMax = 100;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 140f;
      }
      else if (this.type == 10)
      {
        this.displayName = "Giant Worm";
        this.name = "Giant Worm Head";
        this.width = 14;
        this.height = 14;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 8;
        this.defense = 0;
        this.lifeMax = 30;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 40f;
      }
      else if (this.type == 11)
      {
        this.displayName = "Giant Worm";
        this.name = "Giant Worm Body";
        this.width = 14;
        this.height = 14;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 4;
        this.defense = 4;
        this.lifeMax = 30;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 40f;
      }
      else if (this.type == 12)
      {
        this.displayName = "Giant Worm";
        this.name = "Giant Worm Tail";
        this.width = 14;
        this.height = 14;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 4;
        this.defense = 6;
        this.lifeMax = 30;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 40f;
      }
      else if (this.type == 13)
      {
        this.displayName = "Eater of Worlds";
        this.npcSlots = 5f;
        this.name = "Eater of Worlds Head";
        this.width = 38;
        this.height = 38;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 22;
        this.defense = 2;
        this.lifeMax = 65;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 300f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 14)
      {
        this.displayName = "Eater of Worlds";
        this.name = "Eater of Worlds Body";
        this.width = 38;
        this.height = 38;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 13;
        this.defense = 4;
        this.lifeMax = 150;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 300f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 15)
      {
        this.displayName = "Eater of Worlds";
        this.name = "Eater of Worlds Tail";
        this.width = 38;
        this.height = 38;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 11;
        this.defense = 8;
        this.lifeMax = 220;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 300f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 16)
      {
        this.npcSlots = 2f;
        this.name = "Mother Slime";
        this.width = 36;
        this.height = 24;
        this.aiStyle = 1;
        this.damage = 20;
        this.defense = 7;
        this.lifeMax = 90;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.alpha = 120;
        this.color = new Color(0, 0, 0, 50);
        this.value = 75f;
        this.scale = 1.25f;
        this.knockBackResist = 0.6f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if (this.type == 17)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Merchant";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.5f;
      }
      else if (this.type == 18)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Nurse";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.5f;
      }
      else if (this.type == 19)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Arms Dealer";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.5f;
      }
      else if (this.type == 20)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Dryad";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.5f;
      }
      else if (this.type == 21)
      {
        this.name = "Skeleton";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 20;
        this.defense = 8;
        this.lifeMax = 60;
        this.soundHit = 2;
        this.soundKilled = 2;
        this.knockBackResist = 0.5f;
        this.value = 100f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if (this.type == 22)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Guide";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.5f;
      }
      else if (this.type == 23)
      {
        this.name = "Meteor Head";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 5;
        this.damage = 40;
        this.defense = 6;
        this.lifeMax = 26;
        this.soundHit = 3;
        this.soundKilled = 3;
        this.noGravity = true;
        this.noTileCollide = true;
        this.value = 80f;
        this.knockBackResist = 0.4f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 24)
      {
        this.npcSlots = 3f;
        this.name = "Fire Imp";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 8;
        this.damage = 30;
        this.defense = 16;
        this.lifeMax = 70;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.5f;
        this.lavaImmune = true;
        this.value = 350f;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 25)
      {
        this.name = "Burning Sphere";
        this.width = 16;
        this.height = 16;
        this.aiStyle = 9;
        this.damage = 30;
        this.defense = 0;
        this.lifeMax = 1;
        this.soundHit = 3;
        this.soundKilled = 3;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.alpha = 100;
      }
      else if (this.type == 26)
      {
        this.name = "Goblin Peon";
        this.scale = 0.9f;
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 12;
        this.defense = 4;
        this.lifeMax = 60;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.8f;
        this.value = 100f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 27)
      {
        this.name = "Goblin Thief";
        this.scale = 0.95f;
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 20;
        this.defense = 6;
        this.lifeMax = 80;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.7f;
        this.value = 200f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 28)
      {
        this.name = "Goblin Warrior";
        this.scale = 1.1f;
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 25;
        this.defense = 8;
        this.lifeMax = 110;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.5f;
        this.value = 150f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 29)
      {
        this.name = "Goblin Sorcerer";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 8;
        this.damage = 20;
        this.defense = 2;
        this.lifeMax = 40;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.6f;
        this.value = 200f;
      }
      else if (this.type == 30)
      {
        this.name = "Chaos Ball";
        this.width = 16;
        this.height = 16;
        this.aiStyle = 9;
        this.damage = 20;
        this.defense = 0;
        this.lifeMax = 1;
        this.soundHit = 3;
        this.soundKilled = 3;
        this.noGravity = true;
        this.noTileCollide = true;
        this.alpha = 100;
        this.knockBackResist = 0.0f;
      }
      else if (this.type == 31)
      {
        this.name = "Angry Bones";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 26;
        this.defense = 8;
        this.lifeMax = 80;
        this.soundHit = 2;
        this.soundKilled = 2;
        this.knockBackResist = 0.8f;
        this.value = 130f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if (this.type == 32)
      {
        this.name = "Dark Caster";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 8;
        this.damage = 20;
        this.defense = 2;
        this.lifeMax = 50;
        this.soundHit = 2;
        this.soundKilled = 2;
        this.knockBackResist = 0.6f;
        this.value = 140f;
        this.npcSlots = 2f;
        this.buffImmune[20] = true;
      }
      else if (this.type == 33)
      {
        this.name = "Water Sphere";
        this.width = 16;
        this.height = 16;
        this.aiStyle = 9;
        this.damage = 20;
        this.defense = 0;
        this.lifeMax = 1;
        this.soundHit = 3;
        this.soundKilled = 3;
        this.noGravity = true;
        this.noTileCollide = true;
        this.alpha = 100;
        this.knockBackResist = 0.0f;
      }
      else if (this.type == 34)
      {
        this.name = "Cursed Skull";
        this.width = 26;
        this.height = 28;
        this.aiStyle = 10;
        this.damage = 35;
        this.defense = 6;
        this.lifeMax = 40;
        this.soundHit = 2;
        this.soundKilled = 2;
        this.noGravity = true;
        this.noTileCollide = true;
        this.value = 150f;
        this.knockBackResist = 0.2f;
        this.npcSlots = 0.75f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 35)
      {
        this.displayName = "Skeletron";
        this.name = "Skeletron Head";
        this.width = 80;
        this.height = 102;
        this.aiStyle = 11;
        this.damage = 32;
        this.defense = 10;
        this.lifeMax = 4400;
        this.soundHit = 2;
        this.soundKilled = 2;
        this.noGravity = true;
        this.noTileCollide = true;
        this.value = 50000f;
        this.knockBackResist = 0.0f;
        this.boss = true;
        this.npcSlots = 6f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 36)
      {
        this.displayName = "Skeletron";
        this.name = "Skeletron Hand";
        this.width = 52;
        this.height = 52;
        this.aiStyle = 12;
        this.damage = 20;
        this.defense = 14;
        this.lifeMax = 600;
        this.soundHit = 2;
        this.soundKilled = 2;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 37)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Old Man";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.5f;
      }
      else if (this.type == 38)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Demolitionist";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.5f;
      }
      else if (this.type == 39)
      {
        this.npcSlots = 6f;
        this.name = "Bone Serpent Head";
        this.displayName = "Bone Serpent";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 30;
        this.defense = 10;
        this.lifeMax = 250;
        this.soundHit = 2;
        this.soundKilled = 5;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 1200f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 40)
      {
        this.name = "Bone Serpent Body";
        this.displayName = "Bone Serpent";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 15;
        this.defense = 12;
        this.lifeMax = 250;
        this.soundHit = 2;
        this.soundKilled = 5;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 1200f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 41)
      {
        this.name = "Bone Serpent Tail";
        this.displayName = "Bone Serpent";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 10;
        this.defense = 18;
        this.lifeMax = 250;
        this.soundHit = 2;
        this.soundKilled = 5;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 1200f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 42)
      {
        this.name = "Hornet";
        this.width = 34;
        this.height = 32;
        this.aiStyle = 5;
        this.damage = 34;
        this.defense = 12;
        this.lifeMax = 50;
        this.soundHit = 1;
        this.knockBackResist = 0.5f;
        this.soundKilled = 1;
        this.value = 200f;
        this.noGravity = true;
        this.buffImmune[20] = true;
      }
      else if (this.type == 43)
      {
        this.noGravity = true;
        this.noTileCollide = true;
        this.name = "Man Eater";
        this.width = 30;
        this.height = 30;
        this.aiStyle = 13;
        this.damage = 42;
        this.defense = 14;
        this.lifeMax = 130;
        this.soundHit = 1;
        this.knockBackResist = 0.0f;
        this.soundKilled = 1;
        this.value = 350f;
        this.buffImmune[20] = true;
      }
      else if (this.type == 44)
      {
        this.name = "Undead Miner";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 22;
        this.defense = 9;
        this.lifeMax = 70;
        this.soundHit = 2;
        this.soundKilled = 2;
        this.knockBackResist = 0.5f;
        this.value = 250f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if (this.type == 45)
      {
        this.name = "Tim";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 8;
        this.damage = 20;
        this.defense = 4;
        this.lifeMax = 200;
        this.soundHit = 2;
        this.soundKilled = 2;
        this.knockBackResist = 0.6f;
        this.value = 5000f;
        this.buffImmune[20] = true;
      }
      else if (this.type == 46)
      {
        this.name = "Bunny";
        this.width = 18;
        this.height = 20;
        this.aiStyle = 7;
        this.damage = 0;
        this.defense = 0;
        this.lifeMax = 5;
        this.soundHit = 1;
        this.soundKilled = 1;
      }
      else if (this.type == 47)
      {
        this.name = "Corrupt Bunny";
        this.width = 18;
        this.height = 20;
        this.aiStyle = 3;
        this.damage = 20;
        this.defense = 4;
        this.lifeMax = 70;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.value = 500f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 48)
      {
        this.name = "Harpy";
        this.width = 24;
        this.height = 34;
        this.aiStyle = 14;
        this.damage = 25;
        this.defense = 8;
        this.lifeMax = 100;
        this.soundHit = 1;
        this.knockBackResist = 0.6f;
        this.soundKilled = 1;
        this.value = 300f;
      }
      else if (this.type == 49)
      {
        this.npcSlots = 0.5f;
        this.name = "Cave Bat";
        this.width = 22;
        this.height = 18;
        this.aiStyle = 14;
        this.damage = 13;
        this.defense = 2;
        this.lifeMax = 16;
        this.soundHit = 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = 4;
        this.value = 90f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 50)
      {
        this.boss = true;
        this.name = "King Slime";
        this.width = 98;
        this.height = 92;
        this.aiStyle = 15;
        this.damage = 40;
        this.defense = 10;
        this.lifeMax = 2000;
        this.knockBackResist = 0.0f;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.alpha = 30;
        this.value = 10000f;
        this.scale = 1.25f;
        this.buffImmune[20] = true;
      }
      else if (this.type == 51)
      {
        this.npcSlots = 0.5f;
        this.name = "Jungle Bat";
        this.width = 22;
        this.height = 18;
        this.aiStyle = 14;
        this.damage = 20;
        this.defense = 4;
        this.lifeMax = 34;
        this.soundHit = 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = 4;
        this.value = 80f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 52)
      {
        this.name = "Doctor Bones";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 20;
        this.defense = 10;
        this.lifeMax = 500;
        this.soundHit = 1;
        this.soundKilled = 2;
        this.knockBackResist = 0.5f;
        this.value = 1000f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 53)
      {
        this.name = "The Groom";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 14;
        this.defense = 8;
        this.lifeMax = 200;
        this.soundHit = 1;
        this.soundKilled = 2;
        this.knockBackResist = 0.5f;
        this.value = 1000f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 54)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Clothier";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.5f;
      }
      else if (this.type == 55)
      {
        this.noGravity = true;
        this.name = "Goldfish";
        this.width = 20;
        this.height = 18;
        this.aiStyle = 16;
        this.damage = 0;
        this.defense = 0;
        this.lifeMax = 5;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.5f;
      }
      else if (this.type == 56)
      {
        this.noTileCollide = true;
        this.noGravity = true;
        this.name = "Snatcher";
        this.width = 30;
        this.height = 30;
        this.aiStyle = 13;
        this.damage = 25;
        this.defense = 10;
        this.lifeMax = 60;
        this.soundHit = 1;
        this.knockBackResist = 0.0f;
        this.soundKilled = 1;
        this.value = 90f;
        this.buffImmune[20] = true;
      }
      else if (this.type == 57)
      {
        this.noGravity = true;
        this.name = "Corrupt Goldfish";
        this.width = 18;
        this.height = 20;
        this.aiStyle = 16;
        this.damage = 30;
        this.defense = 6;
        this.lifeMax = 100;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.value = 500f;
      }
      else if (this.type == 58)
      {
        this.npcSlots = 0.5f;
        this.noGravity = true;
        this.name = "Piranha";
        this.width = 18;
        this.height = 20;
        this.aiStyle = 16;
        this.damage = 25;
        this.defense = 2;
        this.lifeMax = 30;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.value = 50f;
      }
      else if (this.type == 59)
      {
        this.name = "Lava Slime";
        this.width = 24;
        this.height = 18;
        this.aiStyle = 1;
        this.damage = 15;
        this.defense = 10;
        this.lifeMax = 50;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.scale = 1.1f;
        this.alpha = 50;
        this.lavaImmune = true;
        this.value = 120f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.buffImmune[31] = false;
      }
      else if (this.type == 60)
      {
        this.npcSlots = 0.5f;
        this.name = "Hellbat";
        this.width = 22;
        this.height = 18;
        this.aiStyle = 14;
        this.damage = 35;
        this.defense = 8;
        this.lifeMax = 46;
        this.soundHit = 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = 4;
        this.value = 120f;
        this.scale = 1.1f;
        this.lavaImmune = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.buffImmune[31] = false;
      }
      else if (this.type == 61)
      {
        this.name = "Vulture";
        this.width = 36;
        this.height = 36;
        this.aiStyle = 17;
        this.damage = 15;
        this.defense = 4;
        this.lifeMax = 40;
        this.soundHit = 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = 1;
        this.value = 60f;
      }
      else if (this.type == 62)
      {
        this.npcSlots = 2f;
        this.name = "Demon";
        this.width = 28;
        this.height = 48;
        this.aiStyle = 14;
        this.damage = 32;
        this.defense = 8;
        this.lifeMax = 120;
        this.soundHit = 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = 1;
        this.value = 300f;
        this.lavaImmune = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 63)
      {
        this.noGravity = true;
        this.name = "Blue Jellyfish";
        this.width = 26;
        this.height = 26;
        this.aiStyle = 18;
        this.damage = 20;
        this.defense = 2;
        this.lifeMax = 30;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.value = 100f;
        this.alpha = 20;
      }
      else if (this.type == 64)
      {
        this.noGravity = true;
        this.name = "Pink Jellyfish";
        this.width = 26;
        this.height = 26;
        this.aiStyle = 18;
        this.damage = 30;
        this.defense = 6;
        this.lifeMax = 70;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.value = 100f;
        this.alpha = 20;
      }
      else if (this.type == 65)
      {
        this.noGravity = true;
        this.name = "Shark";
        this.width = 100;
        this.height = 24;
        this.aiStyle = 16;
        this.damage = 40;
        this.defense = 2;
        this.lifeMax = 300;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.value = 400f;
        this.knockBackResist = 0.7f;
      }
      else if (this.type == 66)
      {
        this.npcSlots = 2f;
        this.name = "Voodoo Demon";
        this.width = 28;
        this.height = 48;
        this.aiStyle = 14;
        this.damage = 32;
        this.defense = 8;
        this.lifeMax = 140;
        this.soundHit = 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = 1;
        this.value = 1000f;
        this.lavaImmune = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 67)
      {
        this.name = "Crab";
        this.width = 28;
        this.height = 20;
        this.aiStyle = 3;
        this.damage = 20;
        this.defense = 10;
        this.lifeMax = 40;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.value = 60f;
      }
      else if (this.type == 68)
      {
        this.name = "Dungeon Guardian";
        this.width = 80;
        this.height = 102;
        this.aiStyle = 11;
        this.damage = 9000;
        this.defense = 9000;
        this.lifeMax = 9999;
        this.soundHit = 2;
        this.soundKilled = 2;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 69)
      {
        this.name = "Antlion";
        this.width = 24;
        this.height = 24;
        this.aiStyle = 19;
        this.damage = 10;
        this.defense = 6;
        this.lifeMax = 45;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.0f;
        this.value = 60f;
        this.behindTiles = true;
      }
      else if (this.type == 70)
      {
        this.npcSlots = 0.3f;
        this.name = "Spike Ball";
        this.width = 34;
        this.height = 34;
        this.aiStyle = 20;
        this.damage = 32;
        this.defense = 100;
        this.lifeMax = 100;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.0f;
        this.noGravity = true;
        this.noTileCollide = true;
        this.dontTakeDamage = true;
        this.scale = 1.5f;
      }
      else if (this.type == 71)
      {
        this.npcSlots = 2f;
        this.name = "Dungeon Slime";
        this.width = 36;
        this.height = 24;
        this.aiStyle = 1;
        this.damage = 30;
        this.defense = 7;
        this.lifeMax = 150;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.alpha = 60;
        this.value = 150f;
        this.scale = 1.25f;
        this.knockBackResist = 0.6f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if (this.type == 72)
      {
        this.npcSlots = 0.3f;
        this.name = "Blazing Wheel";
        this.width = 34;
        this.height = 34;
        this.aiStyle = 21;
        this.damage = 24;
        this.defense = 100;
        this.lifeMax = 100;
        this.alpha = 100;
        this.behindTiles = true;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.0f;
        this.noGravity = true;
        this.dontTakeDamage = true;
        this.scale = 1.2f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 73)
      {
        this.name = "Goblin Scout";
        this.scale = 0.95f;
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 20;
        this.defense = 6;
        this.lifeMax = 80;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.7f;
        this.value = 200f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 74)
      {
        this.name = "Bird";
        this.width = 14;
        this.height = 14;
        this.aiStyle = 24;
        this.damage = 0;
        this.defense = 0;
        this.lifeMax = 5;
        this.soundHit = 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = 1;
      }
      else if (this.type == 75)
      {
        this.noGravity = true;
        this.name = "Pixie";
        this.width = 20;
        this.height = 20;
        this.aiStyle = 22;
        this.damage = 55;
        this.defense = 20;
        this.lifeMax = 150;
        this.soundHit = 5;
        this.knockBackResist = 0.6f;
        this.soundKilled = 7;
        this.value = 350f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.buffImmune[31] = false;
      }
      else if (this.type == 77)
      {
        this.name = "Armored Skeleton";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 60;
        this.defense = 36;
        this.lifeMax = 340;
        this.soundHit = 2;
        this.soundKilled = 2;
        this.knockBackResist = 0.4f;
        this.value = 400f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if (this.type == 78)
      {
        this.name = "Mummy";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 50;
        this.defense = 16;
        this.lifeMax = 130;
        this.soundHit = 1;
        this.soundKilled = 6;
        this.knockBackResist = 0.6f;
        this.value = 600f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 79)
      {
        this.name = "Dark Mummy";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 60;
        this.defense = 18;
        this.lifeMax = 180;
        this.soundHit = 1;
        this.soundKilled = 6;
        this.knockBackResist = 0.5f;
        this.value = 700f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 80)
      {
        this.name = "Light Mummy";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 55;
        this.defense = 18;
        this.lifeMax = 200;
        this.soundHit = 1;
        this.soundKilled = 6;
        this.knockBackResist = 0.55f;
        this.value = 700f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 81)
      {
        this.name = "Corrupt Slime";
        this.width = 40;
        this.height = 30;
        this.aiStyle = 1;
        this.damage = 55;
        this.defense = 20;
        this.lifeMax = 170;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.alpha = 55;
        this.value = 400f;
        this.scale = 1.1f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if (this.type == 82)
      {
        this.noGravity = true;
        this.noTileCollide = true;
        this.name = "Wraith";
        this.width = 24;
        this.height = 44;
        this.aiStyle = 22;
        this.damage = 75;
        this.defense = 18;
        this.lifeMax = 200;
        this.soundHit = 1;
        this.soundKilled = 6;
        this.alpha = 100;
        this.value = 500f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.knockBackResist = 0.7f;
      }
      else if (this.type == 83)
      {
        this.name = "Cursed Hammer";
        this.width = 40;
        this.height = 40;
        this.aiStyle = 23;
        this.damage = 80;
        this.defense = 18;
        this.lifeMax = 200;
        this.soundHit = 4;
        this.soundKilled = 6;
        this.value = 1000f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.knockBackResist = 0.4f;
      }
      else if (this.type == 84)
      {
        this.name = "Enchanted Sword";
        this.width = 40;
        this.height = 40;
        this.aiStyle = 23;
        this.damage = 80;
        this.defense = 18;
        this.lifeMax = 200;
        this.soundHit = 4;
        this.soundKilled = 6;
        this.value = 1000f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.knockBackResist = 0.4f;
      }
      else if (this.type == 85)
      {
        this.name = "Mimic";
        this.width = 24;
        this.height = 24;
        this.aiStyle = 25;
        this.damage = 80;
        this.defense = 30;
        this.lifeMax = 500;
        this.soundHit = 4;
        this.soundKilled = 6;
        this.value = 100000f;
        this.knockBackResist = 0.3f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 86)
      {
        this.name = "Unicorn";
        this.width = 46;
        this.height = 42;
        this.aiStyle = 26;
        this.damage = 65;
        this.defense = 30;
        this.lifeMax = 400;
        this.soundHit = 10;
        this.soundKilled = 1;
        this.knockBackResist = 0.3f;
        this.value = 1000f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 87)
      {
        this.displayName = "Wyvern";
        this.noTileCollide = true;
        this.npcSlots = 5f;
        this.name = "Wyvern Head";
        this.width = 32;
        this.height = 32;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 80;
        this.defense = 10;
        this.lifeMax = 4000;
        this.soundHit = 7;
        this.soundKilled = 8;
        this.noGravity = true;
        this.knockBackResist = 0.0f;
        this.value = 10000f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 88)
      {
        this.displayName = "Wyvern";
        this.noTileCollide = true;
        this.name = "Wyvern Legs";
        this.width = 32;
        this.height = 32;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 40;
        this.defense = 20;
        this.lifeMax = 4000;
        this.soundHit = 7;
        this.soundKilled = 8;
        this.noGravity = true;
        this.knockBackResist = 0.0f;
        this.value = 10000f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 89)
      {
        this.displayName = "Wyvern";
        this.noTileCollide = true;
        this.name = "Wyvern Body";
        this.width = 32;
        this.height = 32;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 40;
        this.defense = 20;
        this.lifeMax = 4000;
        this.soundHit = 7;
        this.soundKilled = 8;
        this.noGravity = true;
        this.knockBackResist = 0.0f;
        this.value = 2000f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 90)
      {
        this.displayName = "Wyvern";
        this.noTileCollide = true;
        this.name = "Wyvern Body 2";
        this.width = 32;
        this.height = 32;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 40;
        this.defense = 20;
        this.lifeMax = 4000;
        this.soundHit = 7;
        this.soundKilled = 8;
        this.noGravity = true;
        this.knockBackResist = 0.0f;
        this.value = 10000f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 91)
      {
        this.displayName = "Wyvern";
        this.noTileCollide = true;
        this.name = "Wyvern Body 3";
        this.width = 32;
        this.height = 32;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 40;
        this.defense = 20;
        this.lifeMax = 4000;
        this.soundHit = 7;
        this.soundKilled = 8;
        this.noGravity = true;
        this.knockBackResist = 0.0f;
        this.value = 10000f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 92)
      {
        this.displayName = "Wyvern";
        this.noTileCollide = true;
        this.name = "Wyvern Tail";
        this.width = 32;
        this.height = 32;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 40;
        this.defense = 20;
        this.lifeMax = 4000;
        this.soundHit = 7;
        this.soundKilled = 8;
        this.noGravity = true;
        this.knockBackResist = 0.0f;
        this.value = 10000f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 93)
      {
        this.npcSlots = 0.5f;
        this.name = "Giant Bat";
        this.width = 26;
        this.height = 20;
        this.aiStyle = 14;
        this.damage = 70;
        this.defense = 20;
        this.lifeMax = 160;
        this.soundHit = 1;
        this.knockBackResist = 0.75f;
        this.soundKilled = 4;
        this.value = 400f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 94)
      {
        this.npcSlots = 1f;
        this.name = "Corruptor";
        this.width = 44;
        this.height = 44;
        this.aiStyle = 5;
        this.damage = 60;
        this.defense = 32;
        this.lifeMax = 230;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.noGravity = true;
        this.knockBackResist = 0.55f;
        this.value = 500f;
      }
      else if (this.type == 95)
      {
        this.displayName = "Digger";
        this.name = "Digger Head";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 45;
        this.defense = 10;
        this.lifeMax = 200;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.scale = 0.9f;
        this.value = 300f;
      }
      else if (this.type == 96)
      {
        this.displayName = "Digger";
        this.name = "Digger Body";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 28;
        this.defense = 20;
        this.lifeMax = 200;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.scale = 0.9f;
        this.value = 300f;
      }
      else if (this.type == 97)
      {
        this.displayName = "Digger";
        this.name = "Digger Tail";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 26;
        this.defense = 30;
        this.lifeMax = 200;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.scale = 0.9f;
        this.value = 300f;
      }
      else if (this.type == 98)
      {
        this.displayName = "World Feeder";
        this.npcSlots = 3.5f;
        this.name = "Seeker Head";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 70;
        this.defense = 36;
        this.lifeMax = 500;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 700f;
      }
      else if (this.type == 99)
      {
        this.displayName = "World Feeder";
        this.name = "Seeker Body";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 55;
        this.defense = 40;
        this.lifeMax = 500;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 700f;
      }
      else if (this.type == 100)
      {
        this.displayName = "World Feeder";
        this.name = "Seeker Tail";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 40;
        this.defense = 44;
        this.lifeMax = 500;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 700f;
      }
      else if (this.type == 101)
      {
        this.noGravity = true;
        this.noTileCollide = true;
        this.behindTiles = true;
        this.name = "Clinger";
        this.width = 30;
        this.height = 30;
        this.aiStyle = 13;
        this.damage = 70;
        this.defense = 30;
        this.lifeMax = 320;
        this.soundHit = 1;
        this.knockBackResist = 0.2f;
        this.soundKilled = 1;
        this.value = 600f;
      }
      else if (this.type == 102)
      {
        this.npcSlots = 0.5f;
        this.noGravity = true;
        this.name = "Angler Fish";
        this.width = 18;
        this.height = 20;
        this.aiStyle = 16;
        this.damage = 80;
        this.defense = 22;
        this.lifeMax = 90;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.value = 500f;
      }
      else if (this.type == 103)
      {
        this.noGravity = true;
        this.name = "Green Jellyfish";
        this.width = 26;
        this.height = 26;
        this.aiStyle = 18;
        this.damage = 80;
        this.defense = 30;
        this.lifeMax = 120;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.value = 800f;
        this.alpha = 20;
      }
      else if (this.type == 104)
      {
        this.name = "Werewolf";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 70;
        this.defense = 40;
        this.lifeMax = 400;
        this.soundHit = 6;
        this.soundKilled = 1;
        this.knockBackResist = 0.4f;
        this.value = 1000f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 105)
      {
        this.friendly = true;
        this.name = "Bound Goblin";
        this.width = 18;
        this.height = 34;
        this.aiStyle = 0;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.5f;
        this.scale = 0.9f;
      }
      else if (this.type == 106)
      {
        this.friendly = true;
        this.name = "Bound Wizard";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 0;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.5f;
      }
      else if (this.type == 107)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Goblin Tinkerer";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.5f;
        this.scale = 0.9f;
      }
      else if (this.type == 108)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Wizard";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.5f;
      }
      else if (this.type == 109)
      {
        this.name = "Clown";
        this.width = 34;
        this.height = 78;
        this.aiStyle = 3;
        this.damage = 50;
        this.defense = 20;
        this.lifeMax = 400;
        this.soundHit = 1;
        this.soundKilled = 2;
        this.knockBackResist = 0.4f;
        this.value = 8000f;
      }
      else if (this.type == 110)
      {
        this.name = "Skeleton Archer";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 55;
        this.defense = 28;
        this.lifeMax = 260;
        this.soundHit = 2;
        this.soundKilled = 2;
        this.knockBackResist = 0.55f;
        this.value = 400f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if (this.type == 111)
      {
        this.name = "Goblin Archer";
        this.scale = 0.95f;
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 20;
        this.defense = 6;
        this.lifeMax = 80;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.7f;
        this.value = 200f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 112)
      {
        this.name = "Vile Spit";
        this.width = 16;
        this.height = 16;
        this.aiStyle = 9;
        this.damage = 65;
        this.defense = 0;
        this.lifeMax = 1;
        this.soundHit = 0;
        this.soundKilled = 9;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.scale = 0.9f;
        this.alpha = 80;
      }
      else if (this.type == 113)
      {
        this.npcSlots = 10f;
        this.name = "Wall of Flesh";
        this.width = 100;
        this.height = 100;
        this.aiStyle = 27;
        this.damage = 50;
        this.defense = 12;
        this.lifeMax = 8000;
        this.soundHit = 8;
        this.soundKilled = 10;
        this.noGravity = true;
        this.noTileCollide = true;
        this.behindTiles = true;
        this.knockBackResist = 0.0f;
        this.scale = 1.2f;
        this.boss = true;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.value = 80000f;
      }
      else if (this.type == 114)
      {
        this.name = "Wall of Flesh Eye";
        this.displayName = "Wall of Flesh";
        this.width = 100;
        this.height = 100;
        this.aiStyle = 28;
        this.damage = 50;
        this.defense = 0;
        this.lifeMax = 8000;
        this.soundHit = 8;
        this.soundKilled = 10;
        this.noGravity = true;
        this.noTileCollide = true;
        this.behindTiles = true;
        this.knockBackResist = 0.0f;
        this.scale = 1.2f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.value = 80000f;
      }
      else if (this.type == 115)
      {
        this.name = "The Hungry";
        this.width = 30;
        this.height = 30;
        this.aiStyle = 29;
        this.damage = 30;
        this.defense = 10;
        this.lifeMax = 240;
        this.soundHit = 9;
        this.soundKilled = 11;
        this.noGravity = true;
        this.behindTiles = true;
        this.noTileCollide = true;
        this.knockBackResist = 1.1f;
      }
      else if (this.type == 116)
      {
        this.name = "The Hungry II";
        this.displayName = "The Hungry";
        this.width = 30;
        this.height = 32;
        this.aiStyle = 2;
        this.damage = 30;
        this.defense = 6;
        this.lifeMax = 80;
        this.soundHit = 9;
        this.knockBackResist = 0.8f;
        this.soundKilled = 12;
      }
      else if (this.type == 117)
      {
        this.displayName = "Leech";
        this.name = "Leech Head";
        this.width = 14;
        this.height = 14;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 26;
        this.defense = 2;
        this.lifeMax = 60;
        this.soundHit = 9;
        this.soundKilled = 12;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
      }
      else if (this.type == 118)
      {
        this.displayName = "Leech";
        this.name = "Leech Body";
        this.width = 14;
        this.height = 14;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 22;
        this.defense = 6;
        this.lifeMax = 60;
        this.soundHit = 9;
        this.soundKilled = 12;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
      }
      else if (this.type == 119)
      {
        this.displayName = "Leech";
        this.name = "Leech Tail";
        this.width = 14;
        this.height = 14;
        this.aiStyle = 6;
        this.netAlways = true;
        this.damage = 18;
        this.defense = 10;
        this.lifeMax = 60;
        this.soundHit = 9;
        this.soundKilled = 12;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
      }
      else if (this.type == 120)
      {
        this.name = "Chaos Elemental";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 40;
        this.defense = 30;
        this.lifeMax = 370;
        this.soundHit = 1;
        this.soundKilled = 6;
        this.knockBackResist = 0.4f;
        this.value = 600f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.buffImmune[31] = false;
      }
      else if (this.type == 121)
      {
        this.name = "Slimer";
        this.width = 40;
        this.height = 30;
        this.aiStyle = 14;
        this.damage = 45;
        this.defense = 20;
        this.lifeMax = 60;
        this.soundHit = 1;
        this.alpha = 55;
        this.knockBackResist = 0.8f;
        this.scale = 1.1f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if (this.type == 122)
      {
        this.noGravity = true;
        this.name = "Gastropod";
        this.width = 20;
        this.height = 20;
        this.aiStyle = 22;
        this.damage = 60;
        this.defense = 22;
        this.lifeMax = 220;
        this.soundHit = 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = 1;
        this.value = 600f;
        this.buffImmune[20] = true;
      }
      else if (this.type == 123)
      {
        this.friendly = true;
        this.name = "Bound Mechanic";
        this.width = 18;
        this.height = 34;
        this.aiStyle = 0;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.5f;
        this.scale = 0.9f;
      }
      else if (this.type == 124)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Mechanic";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.5f;
      }
      else if (this.type == 125)
      {
        this.name = "Retinazer";
        this.width = 100;
        this.height = 110;
        this.aiStyle = 30;
        this.damage = 50;
        this.defense = 10;
        this.lifeMax = 24000;
        this.soundHit = 1;
        this.soundKilled = 14;
        this.knockBackResist = 0.0f;
        this.noGravity = true;
        this.noTileCollide = true;
        this.timeLeft = NPC.activeTime * 30;
        this.boss = true;
        this.value = 120000f;
        this.npcSlots = 5f;
        this.boss = true;
      }
      else if (this.type == 126)
      {
        this.name = "Spazmatism";
        this.width = 100;
        this.height = 110;
        this.aiStyle = 31;
        this.damage = 50;
        this.defense = 10;
        this.lifeMax = 24000;
        this.soundHit = 1;
        this.soundKilled = 14;
        this.knockBackResist = 0.0f;
        this.noGravity = true;
        this.noTileCollide = true;
        this.timeLeft = NPC.activeTime * 30;
        this.boss = true;
        this.value = 120000f;
        this.npcSlots = 5f;
        this.boss = true;
      }
      else if (this.type == (int) sbyte.MaxValue)
      {
        this.name = "Skeletron Prime";
        this.width = 80;
        this.height = 102;
        this.aiStyle = 32;
        this.damage = 50;
        this.defense = 25;
        this.lifeMax = 30000;
        this.soundHit = 4;
        this.soundKilled = 14;
        this.noGravity = true;
        this.noTileCollide = true;
        this.value = 120000f;
        this.knockBackResist = 0.0f;
        this.boss = true;
        this.npcSlots = 6f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.boss = true;
      }
      else if (this.type == 128)
      {
        this.name = "Prime Cannon";
        this.width = 52;
        this.height = 52;
        this.aiStyle = 35;
        this.damage = 30;
        this.defense = 25;
        this.lifeMax = 7000;
        this.soundHit = 4;
        this.soundKilled = 14;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.netAlways = true;
      }
      else if (this.type == 129)
      {
        this.name = "Prime Saw";
        this.width = 52;
        this.height = 52;
        this.aiStyle = 33;
        this.damage = 52;
        this.defense = 40;
        this.lifeMax = 10000;
        this.soundHit = 4;
        this.soundKilled = 14;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.netAlways = true;
      }
      else if (this.type == 130)
      {
        this.name = "Prime Vice";
        this.width = 52;
        this.height = 52;
        this.aiStyle = 34;
        this.damage = 45;
        this.defense = 35;
        this.lifeMax = 10000;
        this.soundHit = 4;
        this.soundKilled = 14;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.netAlways = true;
      }
      else if (this.type == 131)
      {
        this.name = "Prime Laser";
        this.width = 52;
        this.height = 52;
        this.aiStyle = 36;
        this.damage = 29;
        this.defense = 20;
        this.lifeMax = 6000;
        this.soundHit = 4;
        this.soundKilled = 14;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.netAlways = true;
      }
      else if (this.type == 132)
      {
        this.displayName = "Zombie";
        this.name = "Bald Zombie";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 14;
        this.defense = 6;
        this.lifeMax = 45;
        this.soundHit = 1;
        this.soundKilled = 2;
        this.knockBackResist = 0.5f;
        this.value = 60f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 133)
      {
        this.name = "Wandering Eye";
        this.width = 30;
        this.height = 32;
        this.aiStyle = 2;
        this.damage = 40;
        this.defense = 20;
        this.lifeMax = 300;
        this.soundHit = 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = 1;
        this.value = 500f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 134)
      {
        this.displayName = "The Destroyer";
        this.npcSlots = 5f;
        this.name = "The Destroyer";
        this.width = 38;
        this.height = 38;
        this.aiStyle = 37;
        this.damage = 60;
        this.defense = 0;
        this.lifeMax = 80000;
        this.soundHit = 4;
        this.soundKilled = 14;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 120000f;
        this.scale = 1.25f;
        this.boss = true;
        this.netAlways = true;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 135)
      {
        this.displayName = "The Destroyer";
        this.npcSlots = 5f;
        this.name = "The Destroyer Body";
        this.width = 38;
        this.height = 38;
        this.aiStyle = 37;
        this.damage = 40;
        this.defense = 30;
        this.lifeMax = 80000;
        this.soundHit = 4;
        this.soundKilled = 14;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.netAlways = true;
        this.scale = 1.25f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 136)
      {
        this.displayName = "The Destroyer";
        this.npcSlots = 5f;
        this.name = "The Destroyer Tail";
        this.width = 38;
        this.height = 38;
        this.aiStyle = 37;
        this.damage = 20;
        this.defense = 35;
        this.lifeMax = 80000;
        this.soundHit = 4;
        this.soundKilled = 14;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.scale = 1.25f;
        this.netAlways = true;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 137)
      {
        this.name = "Illuminant Bat";
        this.width = 26;
        this.height = 20;
        this.aiStyle = 14;
        this.damage = 75;
        this.defense = 30;
        this.lifeMax = 200;
        this.soundHit = 1;
        this.knockBackResist = 0.75f;
        this.soundKilled = 6;
        this.value = 500f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.buffImmune[31] = false;
      }
      else if (this.type == 138)
      {
        this.name = "Illuminant Slime";
        this.width = 24;
        this.height = 18;
        this.aiStyle = 1;
        this.damage = 70;
        this.defense = 30;
        this.lifeMax = 180;
        this.soundHit = 1;
        this.soundKilled = 6;
        this.alpha = 100;
        this.value = 400f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.knockBackResist = 0.85f;
        this.scale = 1.05f;
        this.buffImmune[31] = false;
      }
      else if (this.type == 139)
      {
        this.npcSlots = 1f;
        this.name = "Probe";
        this.width = 30;
        this.height = 30;
        this.aiStyle = 5;
        this.damage = 50;
        this.defense = 20;
        this.lifeMax = 200;
        this.soundHit = 4;
        this.soundKilled = 14;
        this.noGravity = true;
        this.knockBackResist = 0.8f;
        this.noTileCollide = true;
      }
      else if (this.type == 140)
      {
        this.name = "Possessed Armor";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 3;
        this.damage = 55;
        this.defense = 28;
        this.lifeMax = 260;
        this.soundHit = 4;
        this.soundKilled = 6;
        this.knockBackResist = 0.4f;
        this.value = 400f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
        this.buffImmune[24] = true;
      }
      else if (this.type == 141)
      {
        this.name = "Toxic Sludge";
        this.width = 34;
        this.height = 28;
        this.aiStyle = 1;
        this.damage = 50;
        this.defense = 18;
        this.lifeMax = 150;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.alpha = 55;
        this.value = 400f;
        this.scale = 1.1f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
        this.knockBackResist = 0.8f;
      }
      else if (this.type == 142)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Santa Claus";
        this.width = 18;
        this.height = 40;
        this.aiStyle = 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = 1;
        this.soundKilled = 1;
        this.knockBackResist = 0.5f;
      }
      else if (this.type == 143)
      {
        this.name = "Snowman Gangsta";
        this.width = 26;
        this.height = 40;
        this.aiStyle = 38;
        this.damage = 50;
        this.defense = 20;
        this.lifeMax = 200;
        this.soundHit = 11;
        this.soundKilled = 15;
        this.knockBackResist = 0.6f;
        this.value = 400f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 144)
      {
        this.name = "Mister Stabby";
        this.width = 26;
        this.height = 40;
        this.aiStyle = 38;
        this.damage = 65;
        this.defense = 26;
        this.lifeMax = 240;
        this.soundHit = 11;
        this.soundKilled = 15;
        this.knockBackResist = 0.6f;
        this.value = 400f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if (this.type == 145)
      {
        this.name = "Snow Balla";
        this.width = 26;
        this.height = 40;
        this.aiStyle = 38;
        this.damage = 55;
        this.defense = 22;
        this.lifeMax = 220;
        this.soundHit = 11;
        this.soundKilled = 15;
        this.knockBackResist = 0.6f;
        this.value = 400f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      this.frame = !Main.dedServ ? new Rectangle(0, 0, Main.npcTexture[this.type].Width, Main.npcTexture[this.type].Height / Main.npcFrameCount[this.type]) : new Rectangle();
      if ((double) scaleOverride > 0.0)
      {
        int num1 = (int) ((double) this.width * (double) this.scale);
        int num2 = (int) ((double) this.height * (double) this.scale);
        this.position.X += (float) (num1 / 2);
        this.position.Y += (float) num2;
        this.scale = scaleOverride;
        this.width = (int) ((double) this.width * (double) this.scale);
        this.height = (int) ((double) this.height * (double) this.scale);
        if (this.height == 16 || this.height == 32)
          ++this.height;
        this.position.X -= (float) (this.width / 2);
        this.position.Y -= (float) this.height;
      }
      else
      {
        this.width = (int) ((double) this.width * (double) this.scale);
        this.height = (int) ((double) this.height * (double) this.scale);
      }
      this.life = this.lifeMax;
      this.defDamage = this.damage;
      this.defDefense = this.defense;
      this.netID = this.type;
      this.displayName = Lang.npcName(this.netID);
    }

    public void AI()
    {
      if (this.aiStyle == 0)
      {
        for (int index = 0; index < (int) byte.MaxValue; ++index)
        {
          if (Main.player[index].active && Main.player[index].talkNPC == this.whoAmI)
          {
            if (this.type == 105)
            {
              this.Transform(107);
              return;
            }
            if (this.type == 106)
            {
              this.Transform(108);
              return;
            }
            if (this.type == 123)
            {
              this.Transform(124);
              return;
            }
          }
        }
        this.velocity.X *= 0.93f;
        if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
          this.velocity.X = 0.0f;
        this.TargetClosest();
        this.spriteDirection = this.direction;
      }
      else if (this.aiStyle == 1)
      {
        bool flag = false;
        if (!Main.dayTime || this.life != this.lifeMax || (double) this.position.Y > Main.worldSurface * 16.0)
          flag = true;
        if (this.type == 81)
        {
          flag = true;
          if (Main.rand.Next(30) == 0)
          {
            int index = Dust.NewDust(this.position, this.width, this.height, 14, Alpha: this.alpha, newColor: this.color);
            Main.dust[index].velocity *= 0.3f;
          }
        }
        if (this.type == 59)
        {
          Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 1f, 0.3f, 0.1f);
          int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, Scale: 1.7f);
          Main.dust[index].noGravity = true;
        }
        if ((double) this.ai[2] > 1.0)
          --this.ai[2];
        if (this.wet)
        {
          if (this.collideY)
            this.velocity.Y = -2f;
          if ((double) this.velocity.Y < 0.0 && (double) this.ai[3] == (double) this.position.X)
          {
            this.direction *= -1;
            this.ai[2] = 200f;
          }
          if ((double) this.velocity.Y > 0.0)
            this.ai[3] = this.position.X;
          if (this.type == 59)
          {
            if ((double) this.velocity.Y > 2.0)
              this.velocity.Y *= 0.9f;
            else if (this.directionY < 0)
              this.velocity.Y -= 0.8f;
            this.velocity.Y -= 0.5f;
            if ((double) this.velocity.Y < -10.0)
              this.velocity.Y = -10f;
          }
          else
          {
            if ((double) this.velocity.Y > 2.0)
              this.velocity.Y *= 0.9f;
            this.velocity.Y -= 0.5f;
            if ((double) this.velocity.Y < -4.0)
              this.velocity.Y = -4f;
          }
          if ((double) this.ai[2] == 1.0 && flag)
            this.TargetClosest();
        }
        this.aiAction = 0;
        if ((double) this.ai[2] == 0.0)
        {
          this.ai[0] = -100f;
          this.ai[2] = 1f;
          this.TargetClosest();
        }
        if ((double) this.velocity.Y == 0.0)
        {
          if ((double) this.ai[3] == (double) this.position.X)
          {
            this.direction *= -1;
            this.ai[2] = 200f;
          }
          this.ai[3] = 0.0f;
          this.velocity.X *= 0.8f;
          if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
            this.velocity.X = 0.0f;
          if (flag)
            ++this.ai[0];
          ++this.ai[0];
          if (this.type == 59)
            this.ai[0] += 2f;
          if (this.type == 71)
            this.ai[0] += 3f;
          if (this.type == 138)
            this.ai[0] += 2f;
          if (this.type == 81)
          {
            if ((double) this.scale >= 0.0)
              this.ai[0] += 4f;
            else
              ++this.ai[0];
          }
          if ((double) this.ai[0] >= 0.0)
          {
            this.netUpdate = true;
            if (flag && (double) this.ai[2] == 1.0)
              this.TargetClosest();
            if ((double) this.ai[1] == 2.0)
            {
              this.velocity.Y = -8f;
              if (this.type == 59)
                this.velocity.Y -= 2f;
              this.velocity.X += (float) (3 * this.direction);
              if (this.type == 59)
                this.velocity.X += 0.5f * (float) this.direction;
              this.ai[0] = -200f;
              this.ai[1] = 0.0f;
              this.ai[3] = this.position.X;
            }
            else
            {
              this.velocity.Y = -6f;
              this.velocity.X += (float) (2 * this.direction);
              if (this.type == 59)
                this.velocity.X += (float) (2 * this.direction);
              this.ai[0] = -120f;
              ++this.ai[1];
            }
            if (this.type != 141)
              return;
            this.velocity.Y *= 1.3f;
            this.velocity.X *= 1.2f;
          }
          else
          {
            if ((double) this.ai[0] < -30.0)
              return;
            this.aiAction = 1;
          }
        }
        else
        {
          if (this.target >= (int) byte.MaxValue || (this.direction != 1 || (double) this.velocity.X >= 3.0) && (this.direction != -1 || (double) this.velocity.X <= -3.0))
            return;
          if (this.direction == -1 && (double) this.velocity.X < 0.1 || this.direction == 1 && (double) this.velocity.X > -0.1)
            this.velocity.X += 0.2f * (float) this.direction;
          else
            this.velocity.X *= 0.93f;
        }
      }
      else if (this.aiStyle == 2)
      {
        this.noGravity = true;
        if (this.collideX)
        {
          this.velocity.X = this.oldVelocity.X * -0.5f;
          if (this.direction == -1 && (double) this.velocity.X > 0.0 && (double) this.velocity.X < 2.0)
            this.velocity.X = 2f;
          if (this.direction == 1 && (double) this.velocity.X < 0.0 && (double) this.velocity.X > -2.0)
            this.velocity.X = -2f;
        }
        if (this.collideY)
        {
          this.velocity.Y = this.oldVelocity.Y * -0.5f;
          if ((double) this.velocity.Y > 0.0 && (double) this.velocity.Y < 1.0)
            this.velocity.Y = 1f;
          if ((double) this.velocity.Y < 0.0 && (double) this.velocity.Y > -1.0)
            this.velocity.Y = -1f;
        }
        if (Main.dayTime && (double) this.position.Y <= Main.worldSurface * 16.0 && (this.type == 2 || this.type == 133))
        {
          if (this.timeLeft > 10)
            this.timeLeft = 10;
          this.directionY = -1;
          if ((double) this.velocity.Y > 0.0)
            this.direction = 1;
          this.direction = -1;
          if ((double) this.velocity.X > 0.0)
            this.direction = 1;
        }
        else
          this.TargetClosest();
        if (this.type == 116)
        {
          this.TargetClosest();
          Lighting.addLight((int) ((double) this.position.X + (double) (this.width / 2)) / 16, (int) ((double) this.position.Y + (double) (this.height / 2)) / 16, 0.3f, 0.2f, 0.1f);
          if (this.direction == -1 && (double) this.velocity.X > -6.0)
          {
            this.velocity.X -= 0.1f;
            if ((double) this.velocity.X > 6.0)
              this.velocity.X -= 0.1f;
            else if ((double) this.velocity.X > 0.0)
              this.velocity.X -= 0.2f;
            if ((double) this.velocity.X < -6.0)
              this.velocity.X = -6f;
          }
          else if (this.direction == 1 && (double) this.velocity.X < 6.0)
          {
            this.velocity.X += 0.1f;
            if ((double) this.velocity.X < -6.0)
              this.velocity.X += 0.1f;
            else if ((double) this.velocity.X < 0.0)
              this.velocity.X += 0.2f;
            if ((double) this.velocity.X > 6.0)
              this.velocity.X = 6f;
          }
          if (this.directionY == -1 && (double) this.velocity.Y > -2.5)
          {
            this.velocity.Y -= 0.04f;
            if ((double) this.velocity.Y > 2.5)
              this.velocity.Y -= 0.05f;
            else if ((double) this.velocity.Y > 0.0)
              this.velocity.Y -= 0.15f;
            if ((double) this.velocity.Y < -2.5)
              this.velocity.Y = -2.5f;
          }
          else if (this.directionY == 1 && (double) this.velocity.Y < 1.5)
          {
            this.velocity.Y += 0.04f;
            if ((double) this.velocity.Y < -2.5)
              this.velocity.Y += 0.05f;
            else if ((double) this.velocity.Y < 0.0)
              this.velocity.Y += 0.15f;
            if ((double) this.velocity.Y > 2.5)
              this.velocity.Y = 2.5f;
          }
          if (Main.rand.Next(40) == 0)
          {
            int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float) this.height * 0.25f), this.width, (int) ((double) this.height * 0.5), 5, this.velocity.X, 2f);
            Main.dust[index].velocity.X *= 0.5f;
            Main.dust[index].velocity.Y *= 0.1f;
          }
        }
        else if (this.type == 133)
        {
          if ((double) this.life < (double) this.lifeMax * 0.5)
          {
            if (this.direction == -1 && (double) this.velocity.X > -6.0)
            {
              this.velocity.X -= 0.1f;
              if ((double) this.velocity.X > 6.0)
                this.velocity.X -= 0.1f;
              else if ((double) this.velocity.X > 0.0)
                this.velocity.X += 0.05f;
              if ((double) this.velocity.X < -6.0)
                this.velocity.X = -6f;
            }
            else if (this.direction == 1 && (double) this.velocity.X < 6.0)
            {
              this.velocity.X += 0.1f;
              if ((double) this.velocity.X < -6.0)
                this.velocity.X += 0.1f;
              else if ((double) this.velocity.X < 0.0)
                this.velocity.X -= 0.05f;
              if ((double) this.velocity.X > 6.0)
                this.velocity.X = 6f;
            }
            if (this.directionY == -1 && (double) this.velocity.Y > -4.0)
            {
              this.velocity.Y -= 0.1f;
              if ((double) this.velocity.Y > 4.0)
                this.velocity.Y -= 0.1f;
              else if ((double) this.velocity.Y > 0.0)
                this.velocity.Y += 0.05f;
              if ((double) this.velocity.Y < -4.0)
                this.velocity.Y = -4f;
            }
            else if (this.directionY == 1 && (double) this.velocity.Y < 4.0)
            {
              this.velocity.Y += 0.1f;
              if ((double) this.velocity.Y < -4.0)
                this.velocity.Y += 0.1f;
              else if ((double) this.velocity.Y < 0.0)
                this.velocity.Y -= 0.05f;
              if ((double) this.velocity.Y > 4.0)
                this.velocity.Y = 4f;
            }
          }
          else
          {
            if (this.direction == -1 && (double) this.velocity.X > -4.0)
            {
              this.velocity.X -= 0.1f;
              if ((double) this.velocity.X > 4.0)
                this.velocity.X -= 0.1f;
              else if ((double) this.velocity.X > 0.0)
                this.velocity.X += 0.05f;
              if ((double) this.velocity.X < -4.0)
                this.velocity.X = -4f;
            }
            else if (this.direction == 1 && (double) this.velocity.X < 4.0)
            {
              this.velocity.X += 0.1f;
              if ((double) this.velocity.X < -4.0)
                this.velocity.X += 0.1f;
              else if ((double) this.velocity.X < 0.0)
                this.velocity.X -= 0.05f;
              if ((double) this.velocity.X > 4.0)
                this.velocity.X = 4f;
            }
            if (this.directionY == -1 && (double) this.velocity.Y > -1.5)
            {
              this.velocity.Y -= 0.04f;
              if ((double) this.velocity.Y > 1.5)
                this.velocity.Y -= 0.05f;
              else if ((double) this.velocity.Y > 0.0)
                this.velocity.Y += 0.03f;
              if ((double) this.velocity.Y < -1.5)
                this.velocity.Y = -1.5f;
            }
            else if (this.directionY == 1 && (double) this.velocity.Y < 1.5)
            {
              this.velocity.Y += 0.04f;
              if ((double) this.velocity.Y < -1.5)
                this.velocity.Y += 0.05f;
              else if ((double) this.velocity.Y < 0.0)
                this.velocity.Y -= 0.03f;
              if ((double) this.velocity.Y > 1.5)
                this.velocity.Y = 1.5f;
            }
          }
        }
        else
        {
          if (this.direction == -1 && (double) this.velocity.X > -4.0)
          {
            this.velocity.X -= 0.1f;
            if ((double) this.velocity.X > 4.0)
              this.velocity.X -= 0.1f;
            else if ((double) this.velocity.X > 0.0)
              this.velocity.X += 0.05f;
            if ((double) this.velocity.X < -4.0)
              this.velocity.X = -4f;
          }
          else if (this.direction == 1 && (double) this.velocity.X < 4.0)
          {
            this.velocity.X += 0.1f;
            if ((double) this.velocity.X < -4.0)
              this.velocity.X += 0.1f;
            else if ((double) this.velocity.X < 0.0)
              this.velocity.X -= 0.05f;
            if ((double) this.velocity.X > 4.0)
              this.velocity.X = 4f;
          }
          if (this.directionY == -1 && (double) this.velocity.Y > -1.5)
          {
            this.velocity.Y -= 0.04f;
            if ((double) this.velocity.Y > 1.5)
              this.velocity.Y -= 0.05f;
            else if ((double) this.velocity.Y > 0.0)
              this.velocity.Y += 0.03f;
            if ((double) this.velocity.Y < -1.5)
              this.velocity.Y = -1.5f;
          }
          else if (this.directionY == 1 && (double) this.velocity.Y < 1.5)
          {
            this.velocity.Y += 0.04f;
            if ((double) this.velocity.Y < -1.5)
              this.velocity.Y += 0.05f;
            else if ((double) this.velocity.Y < 0.0)
              this.velocity.Y -= 0.03f;
            if ((double) this.velocity.Y > 1.5)
              this.velocity.Y = 1.5f;
          }
        }
        if ((this.type == 2 || this.type == 133) && Main.rand.Next(40) == 0)
        {
          int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float) this.height * 0.25f), this.width, (int) ((double) this.height * 0.5), 5, this.velocity.X, 2f);
          Main.dust[index].velocity.X *= 0.5f;
          Main.dust[index].velocity.Y *= 0.1f;
        }
        if (!this.wet)
          return;
        if ((double) this.velocity.Y > 0.0)
          this.velocity.Y *= 0.95f;
        this.velocity.Y -= 0.5f;
        if ((double) this.velocity.Y < -4.0)
          this.velocity.Y = -4f;
        this.TargetClosest();
      }
      else if (this.aiStyle == 3)
      {
        int num1 = 60;
        if (this.type == 120)
        {
          num1 = 20;
          if ((double) this.ai[3] == -120.0)
          {
            this.velocity *= 0.0f;
            this.ai[3] = 0.0f;
            Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 8);
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num2 = this.oldPos[2].X + (float) this.width * 0.5f - vector2.X;
            float num3 = this.oldPos[2].Y + (float) this.height * 0.5f - vector2.Y;
            float num4 = 2f / (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
            float SpeedX = num2 * num4;
            float SpeedY = num3 * num4;
            for (int index1 = 0; index1 < 20; ++index1)
            {
              int index2 = Dust.NewDust(this.position, this.width, this.height, 71, SpeedX, SpeedY, 200, Scale: 2f);
              Main.dust[index2].noGravity = true;
              Main.dust[index2].velocity.X *= 2f;
            }
            for (int index3 = 0; index3 < 20; ++index3)
            {
              int index4 = Dust.NewDust(this.oldPos[2], this.width, this.height, 71, -SpeedX, -SpeedY, 200, Scale: 2f);
              Main.dust[index4].noGravity = true;
              Main.dust[index4].velocity.X *= 2f;
            }
          }
        }
        bool flag1 = false;
        bool flag2 = true;
        if (this.type == 47 || this.type == 67 || this.type == 109 || this.type == 110 || this.type == 111 || this.type == 120)
          flag2 = false;
        if (this.type != 110 && this.type != 111 || (double) this.ai[2] <= 0.0)
        {
          if ((double) this.velocity.Y == 0.0 && ((double) this.velocity.X > 0.0 && this.direction < 0 || (double) this.velocity.X < 0.0 && this.direction > 0))
            flag1 = true;
          if ((double) this.position.X == (double) this.oldPosition.X || (double) this.ai[3] >= (double) num1 || flag1)
            ++this.ai[3];
          else if ((double) Math.Abs(this.velocity.X) > 0.9 && (double) this.ai[3] > 0.0)
            --this.ai[3];
          if ((double) this.ai[3] > (double) (num1 * 10))
            this.ai[3] = 0.0f;
          if (this.justHit)
            this.ai[3] = 0.0f;
          if ((double) this.ai[3] == (double) num1)
            this.netUpdate = true;
        }
        if ((!Main.dayTime || (double) this.position.Y > Main.worldSurface * 16.0 || this.type == 26 || this.type == 27 || this.type == 28 || this.type == 31 || this.type == 47 || this.type == 67 || this.type == 73 || this.type == 77 || this.type == 78 || this.type == 79 || this.type == 80 || this.type == 110 || this.type == 111 || this.type == 120) && (double) this.ai[3] < (double) num1)
        {
          if ((this.type == 3 || this.type == 21 || this.type == 31 || this.type == 77 || this.type == 110 || this.type == 132) && Main.rand.Next(1000) == 0)
            Main.PlaySound(14, (int) this.position.X, (int) this.position.Y);
          if ((this.type == 78 || this.type == 79 || this.type == 80) && Main.rand.Next(500) == 0)
            Main.PlaySound(26, (int) this.position.X, (int) this.position.Y);
          this.TargetClosest();
        }
        else if (this.type != 110 && this.type != 111 || (double) this.ai[2] <= 0.0)
        {
          if (Main.dayTime && (double) this.position.Y / 16.0 < Main.worldSurface && this.timeLeft > 10)
            this.timeLeft = 10;
          if ((double) this.velocity.X == 0.0)
          {
            if ((double) this.velocity.Y == 0.0)
            {
              ++this.ai[0];
              if ((double) this.ai[0] >= 2.0)
              {
                this.direction *= -1;
                this.spriteDirection = this.direction;
                this.ai[0] = 0.0f;
              }
            }
          }
          else
            this.ai[0] = 0.0f;
          if (this.direction == 0)
            this.direction = 1;
        }
        if (this.type == 120)
        {
          if ((double) this.velocity.X < -3.0 || (double) this.velocity.X > 3.0)
          {
            if ((double) this.velocity.Y == 0.0)
              this.velocity *= 0.8f;
          }
          else if ((double) this.velocity.X < 3.0 && this.direction == 1)
          {
            if ((double) this.velocity.Y == 0.0 && (double) this.velocity.X < 0.0)
              this.velocity.X *= 0.99f;
            this.velocity.X += 0.07f;
            if ((double) this.velocity.X > 3.0)
              this.velocity.X = 3f;
          }
          else if ((double) this.velocity.X > -3.0 && this.direction == -1)
          {
            if ((double) this.velocity.Y == 0.0 && (double) this.velocity.X > 0.0)
              this.velocity.X *= 0.99f;
            this.velocity.X -= 0.07f;
            if ((double) this.velocity.X < -3.0)
              this.velocity.X = -3f;
          }
        }
        else if (this.type == 27 || this.type == 77 || this.type == 104)
        {
          if ((double) this.velocity.X < -2.0 || (double) this.velocity.X > 2.0)
          {
            if ((double) this.velocity.Y == 0.0)
              this.velocity *= 0.8f;
          }
          else if ((double) this.velocity.X < 2.0 && this.direction == 1)
          {
            this.velocity.X += 0.07f;
            if ((double) this.velocity.X > 2.0)
              this.velocity.X = 2f;
          }
          else if ((double) this.velocity.X > -2.0 && this.direction == -1)
          {
            this.velocity.X -= 0.07f;
            if ((double) this.velocity.X < -2.0)
              this.velocity.X = -2f;
          }
        }
        else if (this.type == 109)
        {
          if ((double) this.velocity.X < -2.0 || (double) this.velocity.X > 2.0)
          {
            if ((double) this.velocity.Y == 0.0)
              this.velocity *= 0.8f;
          }
          else if ((double) this.velocity.X < 2.0 && this.direction == 1)
          {
            this.velocity.X += 0.04f;
            if ((double) this.velocity.X > 2.0)
              this.velocity.X = 2f;
          }
          else if ((double) this.velocity.X > -2.0 && this.direction == -1)
          {
            this.velocity.X -= 0.04f;
            if ((double) this.velocity.X < -2.0)
              this.velocity.X = -2f;
          }
        }
        else if (this.type == 21 || this.type == 26 || this.type == 31 || this.type == 47 || this.type == 73 || this.type == 140)
        {
          if ((double) this.velocity.X < -1.5 || (double) this.velocity.X > 1.5)
          {
            if ((double) this.velocity.Y == 0.0)
              this.velocity *= 0.8f;
          }
          else if ((double) this.velocity.X < 1.5 && this.direction == 1)
          {
            this.velocity.X += 0.07f;
            if ((double) this.velocity.X > 1.5)
              this.velocity.X = 1.5f;
          }
          else if ((double) this.velocity.X > -1.5 && this.direction == -1)
          {
            this.velocity.X -= 0.07f;
            if ((double) this.velocity.X < -1.5)
              this.velocity.X = -1.5f;
          }
        }
        else if (this.type == 67)
        {
          if ((double) this.velocity.X < -0.5 || (double) this.velocity.X > 0.5)
          {
            if ((double) this.velocity.Y == 0.0)
              this.velocity *= 0.7f;
          }
          else if ((double) this.velocity.X < 0.5 && this.direction == 1)
          {
            this.velocity.X += 0.03f;
            if ((double) this.velocity.X > 0.5)
              this.velocity.X = 0.5f;
          }
          else if ((double) this.velocity.X > -0.5 && this.direction == -1)
          {
            this.velocity.X -= 0.03f;
            if ((double) this.velocity.X < -0.5)
              this.velocity.X = -0.5f;
          }
        }
        else if (this.type == 78 || this.type == 79 || this.type == 80)
        {
          float num5 = 1f;
          float num6 = 0.05f;
          if (this.life < this.lifeMax / 2)
          {
            num5 = 2f;
            num6 = 0.1f;
          }
          if (this.type == 79)
            num5 *= 1.5f;
          if ((double) this.velocity.X < -(double) num5 || (double) this.velocity.X > (double) num5)
          {
            if ((double) this.velocity.Y == 0.0)
              this.velocity *= 0.7f;
          }
          else if ((double) this.velocity.X < (double) num5 && this.direction == 1)
          {
            this.velocity.X += num6;
            if ((double) this.velocity.X > (double) num5)
              this.velocity.X = num5;
          }
          else if ((double) this.velocity.X > -(double) num5 && this.direction == -1)
          {
            this.velocity.X -= num6;
            if ((double) this.velocity.X < -(double) num5)
              this.velocity.X = -num5;
          }
        }
        else if (this.type != 110 && this.type != 111)
        {
          if ((double) this.velocity.X < -1.0 || (double) this.velocity.X > 1.0)
          {
            if ((double) this.velocity.Y == 0.0)
              this.velocity *= 0.8f;
          }
          else if ((double) this.velocity.X < 1.0 && this.direction == 1)
          {
            this.velocity.X += 0.07f;
            if ((double) this.velocity.X > 1.0)
              this.velocity.X = 1f;
          }
          else if ((double) this.velocity.X > -1.0 && this.direction == -1)
          {
            this.velocity.X -= 0.07f;
            if ((double) this.velocity.X < -1.0)
              this.velocity.X = -1f;
          }
        }
        if (this.type == 110 || this.type == 111)
        {
          if (this.confused)
          {
            this.ai[2] = 0.0f;
          }
          else
          {
            if ((double) this.ai[1] > 0.0)
              --this.ai[1];
            if (this.justHit)
            {
              this.ai[1] = 30f;
              this.ai[2] = 0.0f;
            }
            int num7 = 70;
            if (this.type == 111)
              num7 = 180;
            if ((double) this.ai[2] > 0.0)
            {
              this.TargetClosest();
              if ((double) this.ai[1] == (double) (num7 / 2))
              {
                float num8 = 11f;
                if (this.type == 111)
                  num8 = 9f;
                Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
                float num9 = Main.player[this.target].position.X + (float) Main.player[this.target].width * 0.5f - vector2.X;
                float num10 = Math.Abs(num9) * 0.1f;
                float num11 = Main.player[this.target].position.Y + (float) Main.player[this.target].height * 0.5f - vector2.Y - num10;
                float num12 = num9 + (float) Main.rand.Next(-40, 41);
                float num13 = num11 + (float) Main.rand.Next(-40, 41);
                float num14 = (float) Math.Sqrt((double) num12 * (double) num12 + (double) num13 * (double) num13);
                this.netUpdate = true;
                float num15 = num8 / num14;
                float SpeedX = num12 * num15;
                float SpeedY = num13 * num15;
                int Damage = 35;
                if (this.type == 111)
                  Damage = 11;
                int Type = 82;
                if (this.type == 111)
                  Type = 81;
                vector2.X += SpeedX;
                vector2.Y += SpeedY;
                if (Main.netMode != 1)
                  Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
                this.ai[2] = (double) Math.Abs(SpeedY) <= (double) Math.Abs(SpeedX) * 2.0 ? ((double) Math.Abs(SpeedX) <= (double) Math.Abs(SpeedY) * 2.0 ? ((double) SpeedY <= 0.0 ? 4f : 2f) : 3f) : ((double) SpeedY <= 0.0 ? 5f : 1f);
              }
              if ((double) this.velocity.Y != 0.0 || (double) this.ai[1] <= 0.0)
              {
                this.ai[2] = 0.0f;
                this.ai[1] = 0.0f;
              }
              else
              {
                this.velocity.X *= 0.9f;
                this.spriteDirection = this.direction;
              }
            }
            if ((double) this.ai[2] <= 0.0 && (double) this.velocity.Y == 0.0 && (double) this.ai[1] <= 0.0 && !Main.player[this.target].dead && Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
            {
              float num16 = 10f;
              Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
              float num17 = Main.player[this.target].position.X + (float) Main.player[this.target].width * 0.5f - vector2.X;
              float num18 = Math.Abs(num17) * 0.1f;
              float num19 = Main.player[this.target].position.Y + (float) Main.player[this.target].height * 0.5f - vector2.Y - num18;
              float num20 = num17 + (float) Main.rand.Next(-40, 41);
              float num21 = num19 + (float) Main.rand.Next(-40, 41);
              float num22 = (float) Math.Sqrt((double) num20 * (double) num20 + (double) num21 * (double) num21);
              if ((double) num22 < 700.0)
              {
                this.netUpdate = true;
                this.velocity.X *= 0.5f;
                float num23 = num16 / num22;
                float num24 = num20 * num23;
                float num25 = num21 * num23;
                this.ai[2] = 3f;
                this.ai[1] = (float) num7;
                this.ai[2] = (double) Math.Abs(num25) <= (double) Math.Abs(num24) * 2.0 ? ((double) Math.Abs(num24) <= (double) Math.Abs(num25) * 2.0 ? ((double) num25 <= 0.0 ? 4f : 2f) : 3f) : ((double) num25 <= 0.0 ? 5f : 1f);
              }
            }
            if ((double) this.ai[2] <= 0.0)
            {
              if ((double) this.velocity.X < -1.0 || (double) this.velocity.X > 1.0)
              {
                if ((double) this.velocity.Y == 0.0)
                  this.velocity *= 0.8f;
              }
              else if ((double) this.velocity.X < 1.0 && this.direction == 1)
              {
                this.velocity.X += 0.07f;
                if ((double) this.velocity.X > 1.0)
                  this.velocity.X = 1f;
              }
              else if ((double) this.velocity.X > -1.0 && this.direction == -1)
              {
                this.velocity.X -= 0.07f;
                if ((double) this.velocity.X < -1.0)
                  this.velocity.X = -1f;
              }
            }
          }
        }
        if (this.type == 109 && Main.netMode != 1 && !Main.player[this.target].dead)
        {
          if (this.justHit)
            this.ai[2] = 0.0f;
          ++this.ai[2];
          if ((double) this.ai[2] > 450.0)
          {
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f - (float) (this.direction * 24), this.position.Y + 4f);
            int num26 = 3 * this.direction;
            int num27 = -5;
            int index = Projectile.NewProjectile(vector2.X, vector2.Y, (float) num26, (float) num27, 75, 0, 0.0f, Main.myPlayer);
            Main.projectile[index].timeLeft = 300;
            this.ai[2] = 0.0f;
          }
        }
        bool flag3 = false;
        if ((double) this.velocity.Y == 0.0)
        {
          int index5 = (int) ((double) this.position.Y + (double) this.height + 8.0) / 16;
          int num28 = (int) this.position.X / 16;
          int num29 = (int) ((double) this.position.X + (double) this.width) / 16;
          for (int index6 = num28; index6 <= num29; ++index6)
          {
            if (Main.tile[index6, index5] == null)
              return;
            if (Main.tile[index6, index5].active && Main.tileSolid[(int) Main.tile[index6, index5].type])
            {
              flag3 = true;
              break;
            }
          }
        }
        if (flag3)
        {
          int i = (int) (((double) this.position.X + (double) (this.width / 2) + (double) (15 * this.direction)) / 16.0);
          int j = (int) (((double) this.position.Y + (double) this.height - 15.0) / 16.0);
          if (this.type == 109)
            i = (int) (((double) this.position.X + (double) (this.width / 2) + (double) ((this.width / 2 + 16) * this.direction)) / 16.0);
          if (Main.tile[i, j] == null)
            Main.tile[i, j] = new Tile();
          if (Main.tile[i, j - 1] == null)
            Main.tile[i, j - 1] = new Tile();
          if (Main.tile[i, j - 2] == null)
            Main.tile[i, j - 2] = new Tile();
          if (Main.tile[i, j - 3] == null)
            Main.tile[i, j - 3] = new Tile();
          if (Main.tile[i, j + 1] == null)
            Main.tile[i, j + 1] = new Tile();
          if (Main.tile[i + this.direction, j - 1] == null)
            Main.tile[i + this.direction, j - 1] = new Tile();
          if (Main.tile[i + this.direction, j + 1] == null)
            Main.tile[i + this.direction, j + 1] = new Tile();
          if (Main.tile[i, j - 1].active && Main.tile[i, j - 1].type == (byte) 10 && flag2)
          {
            ++this.ai[2];
            this.ai[3] = 0.0f;
            if ((double) this.ai[2] >= 60.0)
            {
              if (!Main.bloodMoon && (this.type == 3 || this.type == 132))
                this.ai[1] = 0.0f;
              this.velocity.X = 0.5f * (float) -this.direction;
              ++this.ai[1];
              if (this.type == 27)
                ++this.ai[1];
              if (this.type == 31)
                this.ai[1] += 6f;
              this.ai[2] = 0.0f;
              bool flag4 = false;
              if ((double) this.ai[1] >= 10.0)
              {
                flag4 = true;
                this.ai[1] = 10f;
              }
              WorldGen.KillTile(i, j - 1, true);
              if ((Main.netMode != 1 || !flag4) && flag4 && Main.netMode != 1)
              {
                if (this.type == 26)
                {
                  WorldGen.KillTile(i, j - 1);
                  if (Main.netMode == 2)
                    NetMessage.SendData(17, number2: ((float) i), number3: ((float) (j - 1)));
                }
                else
                {
                  bool flag5 = WorldGen.OpenDoor(i, j, this.direction);
                  if (!flag5)
                  {
                    this.ai[3] = (float) num1;
                    this.netUpdate = true;
                  }
                  if (Main.netMode == 2 && flag5)
                    NetMessage.SendData(19, number2: ((float) i), number3: ((float) j), number4: ((float) this.direction));
                }
              }
            }
          }
          else
          {
            if ((double) this.velocity.X < 0.0 && this.spriteDirection == -1 || (double) this.velocity.X > 0.0 && this.spriteDirection == 1)
            {
              if (Main.tile[i, j - 2].active && Main.tileSolid[(int) Main.tile[i, j - 2].type])
              {
                if (Main.tile[i, j - 3].active && Main.tileSolid[(int) Main.tile[i, j - 3].type])
                {
                  this.velocity.Y = -8f;
                  this.netUpdate = true;
                }
                else
                {
                  this.velocity.Y = -7f;
                  this.netUpdate = true;
                }
              }
              else if (Main.tile[i, j - 1].active && Main.tileSolid[(int) Main.tile[i, j - 1].type])
              {
                this.velocity.Y = -6f;
                this.netUpdate = true;
              }
              else if (Main.tile[i, j].active && Main.tileSolid[(int) Main.tile[i, j].type])
              {
                this.velocity.Y = -5f;
                this.netUpdate = true;
              }
              else if (this.directionY < 0 && this.type != 67 && (!Main.tile[i, j + 1].active || !Main.tileSolid[(int) Main.tile[i, j + 1].type]) && (!Main.tile[i + this.direction, j + 1].active || !Main.tileSolid[(int) Main.tile[i + this.direction, j + 1].type]))
              {
                this.velocity.Y = -8f;
                this.velocity.X *= 1.5f;
                this.netUpdate = true;
              }
              else if (flag2)
              {
                this.ai[1] = 0.0f;
                this.ai[2] = 0.0f;
              }
            }
            if ((this.type == 31 || this.type == 47 || this.type == 77 || this.type == 104) && (double) this.velocity.Y == 0.0 && (double) Math.Abs((float) ((double) this.position.X + (double) (this.width / 2) - ((double) Main.player[this.target].position.X + (double) (Main.player[this.target].width / 2)))) < 100.0 && (double) Math.Abs((float) ((double) this.position.Y + (double) (this.height / 2) - ((double) Main.player[this.target].position.Y + (double) (Main.player[this.target].height / 2)))) < 50.0 && (this.direction > 0 && (double) this.velocity.X >= 1.0 || this.direction < 0 && (double) this.velocity.X <= -1.0))
            {
              this.velocity.X *= 2f;
              if ((double) this.velocity.X > 3.0)
                this.velocity.X = 3f;
              if ((double) this.velocity.X < -3.0)
                this.velocity.X = -3f;
              this.velocity.Y = -4f;
              this.netUpdate = true;
            }
            if (this.type == 120 && (double) this.velocity.Y < 0.0)
              this.velocity.Y *= 1.1f;
          }
        }
        else if (flag2)
        {
          this.ai[1] = 0.0f;
          this.ai[2] = 0.0f;
        }
        if (Main.netMode == 1 || this.type != 120 || (double) this.ai[3] < (double) num1)
          return;
        int num30 = (int) Main.player[this.target].position.X / 16;
        int num31 = (int) Main.player[this.target].position.Y / 16;
        int num32 = (int) this.position.X / 16;
        int num33 = (int) this.position.Y / 16;
        int num34 = 20;
        int num35 = 0;
        bool flag6 = false;
        if ((double) Math.Abs(this.position.X - Main.player[this.target].position.X) + (double) Math.Abs(this.position.Y - Main.player[this.target].position.Y) > 2000.0)
        {
          num35 = 100;
          flag6 = true;
        }
        while (!flag6 && num35 < 100)
        {
          ++num35;
          int index7 = Main.rand.Next(num30 - num34, num30 + num34);
          for (int index8 = Main.rand.Next(num31 - num34, num31 + num34); index8 < num31 + num34; ++index8)
          {
            if ((index8 < num31 - 4 || index8 > num31 + 4 || index7 < num30 - 4 || index7 > num30 + 4) && (index8 < num33 - 1 || index8 > num33 + 1 || index7 < num32 - 1 || index7 > num32 + 1) && Main.tile[index7, index8].active)
            {
              bool flag7 = true;
              if (this.type == 32 && Main.tile[index7, index8 - 1].wall == (byte) 0)
                flag7 = false;
              else if (Main.tile[index7, index8 - 1].lava)
                flag7 = false;
              if (flag7 && Main.tileSolid[(int) Main.tile[index7, index8].type] && !Collision.SolidTiles(index7 - 1, index7 + 1, index8 - 4, index8 - 1))
              {
                this.position.X = (float) (index7 * 16 - this.width / 2);
                this.position.Y = (float) (index8 * 16 - this.height);
                this.netUpdate = true;
                this.ai[3] = -120f;
              }
            }
          }
        }
      }
      else if (this.aiStyle == 4)
      {
        if (this.target < 0 || this.target == (int) byte.MaxValue || Main.player[this.target].dead || !Main.player[this.target].active)
          this.TargetClosest();
        bool dead = Main.player[this.target].dead;
        float num36 = this.position.X + (float) (this.width / 2) - Main.player[this.target].position.X - (float) (Main.player[this.target].width / 2);
        float num37 = (float) Math.Atan2((double) ((float) ((double) this.position.Y + (double) this.height - 59.0) - Main.player[this.target].position.Y - (float) (Main.player[this.target].height / 2)), (double) num36) + 1.57f;
        if ((double) num37 < 0.0)
          num37 += 6.283f;
        else if ((double) num37 > 6.283)
          num37 -= 6.283f;
        float num38 = 0.0f;
        if ((double) this.ai[0] == 0.0 && (double) this.ai[1] == 0.0)
          num38 = 0.02f;
        if ((double) this.ai[0] == 0.0 && (double) this.ai[1] == 2.0 && (double) this.ai[2] > 40.0)
          num38 = 0.05f;
        if ((double) this.ai[0] == 3.0 && (double) this.ai[1] == 0.0)
          num38 = 0.05f;
        if ((double) this.ai[0] == 3.0 && (double) this.ai[1] == 2.0 && (double) this.ai[2] > 40.0)
          num38 = 0.08f;
        if ((double) this.rotation < (double) num37)
        {
          if ((double) num37 - (double) this.rotation > 3.1415)
            this.rotation -= num38;
          else
            this.rotation += num38;
        }
        else if ((double) this.rotation > (double) num37)
        {
          if ((double) this.rotation - (double) num37 > 3.1415)
            this.rotation += num38;
          else
            this.rotation -= num38;
        }
        if ((double) this.rotation > (double) num37 - (double) num38 && (double) this.rotation < (double) num37 + (double) num38)
          this.rotation = num37;
        if ((double) this.rotation < 0.0)
          this.rotation += 6.283f;
        else if ((double) this.rotation > 6.283)
          this.rotation -= 6.283f;
        if ((double) this.rotation > (double) num37 - (double) num38 && (double) this.rotation < (double) num37 + (double) num38)
          this.rotation = num37;
        if (Main.rand.Next(5) == 0)
        {
          int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float) this.height * 0.25f), this.width, (int) ((double) this.height * 0.5), 5, this.velocity.X, 2f);
          Main.dust[index].velocity.X *= 0.5f;
          Main.dust[index].velocity.Y *= 0.1f;
        }
        if (Main.dayTime || dead)
        {
          this.velocity.Y -= 0.04f;
          if (this.timeLeft <= 10)
            return;
          this.timeLeft = 10;
        }
        else if ((double) this.ai[0] == 0.0)
        {
          if ((double) this.ai[1] == 0.0)
          {
            float num39 = 5f;
            float num40 = 0.04f;
            Vector2 vector2_1 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num41 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2_1.X;
            float num42 = (float) ((double) Main.player[this.target].position.Y + (double) (Main.player[this.target].height / 2) - 200.0) - vector2_1.Y;
            float num43 = (float) Math.Sqrt((double) num41 * (double) num41 + (double) num42 * (double) num42);
            float num44 = num43;
            float num45 = num39 / num43;
            float num46 = num41 * num45;
            float num47 = num42 * num45;
            if ((double) this.velocity.X < (double) num46)
            {
              this.velocity.X += num40;
              if ((double) this.velocity.X < 0.0 && (double) num46 > 0.0)
                this.velocity.X += num40;
            }
            else if ((double) this.velocity.X > (double) num46)
            {
              this.velocity.X -= num40;
              if ((double) this.velocity.X > 0.0 && (double) num46 < 0.0)
                this.velocity.X -= num40;
            }
            if ((double) this.velocity.Y < (double) num47)
            {
              this.velocity.Y += num40;
              if ((double) this.velocity.Y < 0.0 && (double) num47 > 0.0)
                this.velocity.Y += num40;
            }
            else if ((double) this.velocity.Y > (double) num47)
            {
              this.velocity.Y -= num40;
              if ((double) this.velocity.Y > 0.0 && (double) num47 < 0.0)
                this.velocity.Y -= num40;
            }
            ++this.ai[2];
            if ((double) this.ai[2] >= 600.0)
            {
              this.ai[1] = 1f;
              this.ai[2] = 0.0f;
              this.ai[3] = 0.0f;
              this.target = (int) byte.MaxValue;
              this.netUpdate = true;
            }
            else if ((double) this.position.Y + (double) this.height < (double) Main.player[this.target].position.Y && (double) num44 < 500.0)
            {
              if (!Main.player[this.target].dead)
                ++this.ai[3];
              if ((double) this.ai[3] >= 110.0)
              {
                this.ai[3] = 0.0f;
                this.rotation = num37;
                float num48 = 5f;
                float num49 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2_1.X;
                float num50 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2_1.Y;
                float num51 = (float) Math.Sqrt((double) num49 * (double) num49 + (double) num50 * (double) num50);
                float num52 = num48 / num51;
                Vector2 Position = vector2_1;
                Vector2 vector2_2;
                vector2_2.X = num49 * num52;
                vector2_2.Y = num50 * num52;
                Position.X += vector2_2.X * 10f;
                Position.Y += vector2_2.Y * 10f;
                if (Main.netMode != 1)
                {
                  int number = NPC.NewNPC((int) Position.X, (int) Position.Y, 5);
                  Main.npc[number].velocity.X = vector2_2.X;
                  Main.npc[number].velocity.Y = vector2_2.Y;
                  if (Main.netMode == 2 && number < 200)
                    NetMessage.SendData(23, number: number);
                }
                Main.PlaySound(3, (int) Position.X, (int) Position.Y);
                for (int index = 0; index < 10; ++index)
                  Dust.NewDust(Position, 20, 20, 5, vector2_2.X * 0.4f, vector2_2.Y * 0.4f);
              }
            }
          }
          else if ((double) this.ai[1] == 1.0)
          {
            this.rotation = num37;
            float num53 = 6f;
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num54 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
            float num55 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
            float num56 = (float) Math.Sqrt((double) num54 * (double) num54 + (double) num55 * (double) num55);
            float num57 = num53 / num56;
            this.velocity.X = num54 * num57;
            this.velocity.Y = num55 * num57;
            this.ai[1] = 2f;
          }
          else if ((double) this.ai[1] == 2.0)
          {
            ++this.ai[2];
            if ((double) this.ai[2] >= 40.0)
            {
              this.velocity.X *= 0.98f;
              this.velocity.Y *= 0.98f;
              if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
                this.velocity.X = 0.0f;
              if ((double) this.velocity.Y > -0.1 && (double) this.velocity.Y < 0.1)
                this.velocity.Y = 0.0f;
            }
            else
              this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) - 1.57f;
            if ((double) this.ai[2] >= 150.0)
            {
              ++this.ai[3];
              this.ai[2] = 0.0f;
              this.target = (int) byte.MaxValue;
              this.rotation = num37;
              if ((double) this.ai[3] >= 3.0)
              {
                this.ai[1] = 0.0f;
                this.ai[3] = 0.0f;
              }
              else
                this.ai[1] = 1f;
            }
          }
          if ((double) this.life >= (double) this.lifeMax * 0.5)
            return;
          this.ai[0] = 1f;
          this.ai[1] = 0.0f;
          this.ai[2] = 0.0f;
          this.ai[3] = 0.0f;
          this.netUpdate = true;
        }
        else if ((double) this.ai[0] == 1.0 || (double) this.ai[0] == 2.0)
        {
          if ((double) this.ai[0] == 1.0)
          {
            this.ai[2] += 0.005f;
            if ((double) this.ai[2] > 0.5)
              this.ai[2] = 0.5f;
          }
          else
          {
            this.ai[2] -= 0.005f;
            if ((double) this.ai[2] < 0.0)
              this.ai[2] = 0.0f;
          }
          this.rotation += this.ai[2];
          ++this.ai[1];
          if ((double) this.ai[1] == 100.0)
          {
            ++this.ai[0];
            this.ai[1] = 0.0f;
            if ((double) this.ai[0] == 3.0)
            {
              this.ai[2] = 0.0f;
            }
            else
            {
              Main.PlaySound(3, (int) this.position.X, (int) this.position.Y);
              for (int index = 0; index < 2; ++index)
              {
                Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 8);
                Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 7);
                Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 6);
              }
              for (int index = 0; index < 20; ++index)
                Dust.NewDust(this.position, this.width, this.height, 5, (float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f);
              Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
            }
          }
          Dust.NewDust(this.position, this.width, this.height, 5, (float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f);
          this.velocity.X *= 0.98f;
          this.velocity.Y *= 0.98f;
          if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
            this.velocity.X = 0.0f;
          if ((double) this.velocity.Y <= -0.1 || (double) this.velocity.Y >= 0.1)
            return;
          this.velocity.Y = 0.0f;
        }
        else
        {
          this.damage = 23;
          this.defense = 0;
          if ((double) this.ai[1] == 0.0)
          {
            float num58 = 6f;
            float num59 = 0.07f;
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num60 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
            float num61 = (float) ((double) Main.player[this.target].position.Y + (double) (Main.player[this.target].height / 2) - 120.0) - vector2.Y;
            float num62 = (float) Math.Sqrt((double) num60 * (double) num60 + (double) num61 * (double) num61);
            float num63 = num58 / num62;
            float num64 = num60 * num63;
            float num65 = num61 * num63;
            if ((double) this.velocity.X < (double) num64)
            {
              this.velocity.X += num59;
              if ((double) this.velocity.X < 0.0 && (double) num64 > 0.0)
                this.velocity.X += num59;
            }
            else if ((double) this.velocity.X > (double) num64)
            {
              this.velocity.X -= num59;
              if ((double) this.velocity.X > 0.0 && (double) num64 < 0.0)
                this.velocity.X -= num59;
            }
            if ((double) this.velocity.Y < (double) num65)
            {
              this.velocity.Y += num59;
              if ((double) this.velocity.Y < 0.0 && (double) num65 > 0.0)
                this.velocity.Y += num59;
            }
            else if ((double) this.velocity.Y > (double) num65)
            {
              this.velocity.Y -= num59;
              if ((double) this.velocity.Y > 0.0 && (double) num65 < 0.0)
                this.velocity.Y -= num59;
            }
            ++this.ai[2];
            if ((double) this.ai[2] < 200.0)
              return;
            this.ai[1] = 1f;
            this.ai[2] = 0.0f;
            this.ai[3] = 0.0f;
            this.target = (int) byte.MaxValue;
            this.netUpdate = true;
          }
          else if ((double) this.ai[1] == 1.0)
          {
            Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
            this.rotation = num37;
            float num66 = 6.8f;
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num67 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
            float num68 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
            float num69 = (float) Math.Sqrt((double) num67 * (double) num67 + (double) num68 * (double) num68);
            float num70 = num66 / num69;
            this.velocity.X = num67 * num70;
            this.velocity.Y = num68 * num70;
            this.ai[1] = 2f;
          }
          else
          {
            if ((double) this.ai[1] != 2.0)
              return;
            ++this.ai[2];
            if ((double) this.ai[2] >= 40.0)
            {
              this.velocity.X *= 0.97f;
              this.velocity.Y *= 0.97f;
              if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
                this.velocity.X = 0.0f;
              if ((double) this.velocity.Y > -0.1 && (double) this.velocity.Y < 0.1)
                this.velocity.Y = 0.0f;
            }
            else
              this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) - 1.57f;
            if ((double) this.ai[2] < 130.0)
              return;
            ++this.ai[3];
            this.ai[2] = 0.0f;
            this.target = (int) byte.MaxValue;
            this.rotation = num37;
            if ((double) this.ai[3] >= 3.0)
            {
              this.ai[1] = 0.0f;
              this.ai[3] = 0.0f;
            }
            else
              this.ai[1] = 1f;
          }
        }
      }
      else if (this.aiStyle == 5)
      {
        if (this.target < 0 || this.target == (int) byte.MaxValue || Main.player[this.target].dead)
          this.TargetClosest();
        float num71 = 6f;
        float num72 = 0.05f;
        if (this.type == 6)
        {
          num71 = 4f;
          num72 = 0.02f;
        }
        else if (this.type == 94)
        {
          num71 = 4.2f;
          num72 = 0.022f;
        }
        else if (this.type == 42)
        {
          num71 = 3.5f;
          num72 = 0.021f;
        }
        else if (this.type == 23)
        {
          num71 = 1f;
          num72 = 0.03f;
        }
        else if (this.type == 5)
        {
          num71 = 5f;
          num72 = 0.03f;
        }
        Vector2 vector2_3 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num73 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2);
        float num74 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2);
        float num75 = (float) ((int) ((double) num73 / 8.0) * 8);
        float num76 = (float) ((int) ((double) num74 / 8.0) * 8);
        vector2_3.X = (float) ((int) ((double) vector2_3.X / 8.0) * 8);
        vector2_3.Y = (float) ((int) ((double) vector2_3.Y / 8.0) * 8);
        float num77 = num75 - vector2_3.X;
        float num78 = num76 - vector2_3.Y;
        float num79 = (float) Math.Sqrt((double) num77 * (double) num77 + (double) num78 * (double) num78);
        float num80 = num79;
        bool flag = false;
        if ((double) num79 > 600.0)
          flag = true;
        float SpeedX1;
        float SpeedY1;
        if ((double) num79 == 0.0)
        {
          SpeedX1 = this.velocity.X;
          SpeedY1 = this.velocity.Y;
        }
        else
        {
          float num81 = num71 / num79;
          SpeedX1 = num77 * num81;
          SpeedY1 = num78 * num81;
        }
        if (this.type == 6 || this.type == 42 || this.type == 94 || this.type == 139)
        {
          if ((double) num80 > 100.0 || this.type == 42 || this.type == 94)
          {
            ++this.ai[0];
            if ((double) this.ai[0] > 0.0)
              this.velocity.Y += 23f / 1000f;
            else
              this.velocity.Y -= 23f / 1000f;
            if ((double) this.ai[0] < -100.0 || (double) this.ai[0] > 100.0)
              this.velocity.X += 23f / 1000f;
            else
              this.velocity.X -= 23f / 1000f;
            if ((double) this.ai[0] > 200.0)
              this.ai[0] = -200f;
          }
          if ((double) num80 < 150.0 && (this.type == 6 || this.type == 94))
          {
            this.velocity.X += SpeedX1 * 0.007f;
            this.velocity.Y += SpeedY1 * 0.007f;
          }
        }
        if (Main.player[this.target].dead)
        {
          SpeedX1 = (float) ((double) this.direction * (double) num71 / 2.0);
          SpeedY1 = (float) (-(double) num71 / 2.0);
        }
        if ((double) this.velocity.X < (double) SpeedX1)
        {
          this.velocity.X += num72;
          if (this.type != 6 && this.type != 42 && this.type != 94 && this.type != 139 && (double) this.velocity.X < 0.0 && (double) SpeedX1 > 0.0)
            this.velocity.X += num72;
        }
        else if ((double) this.velocity.X > (double) SpeedX1)
        {
          this.velocity.X -= num72;
          if (this.type != 6 && this.type != 42 && this.type != 94 && this.type != 139 && (double) this.velocity.X > 0.0 && (double) SpeedX1 < 0.0)
            this.velocity.X -= num72;
        }
        if ((double) this.velocity.Y < (double) SpeedY1)
        {
          this.velocity.Y += num72;
          if (this.type != 6 && this.type != 42 && this.type != 94 && this.type != 139 && (double) this.velocity.Y < 0.0 && (double) SpeedY1 > 0.0)
            this.velocity.Y += num72;
        }
        else if ((double) this.velocity.Y > (double) SpeedY1)
        {
          this.velocity.Y -= num72;
          if (this.type != 6 && this.type != 42 && this.type != 94 && this.type != 139 && (double) this.velocity.Y > 0.0 && (double) SpeedY1 < 0.0)
            this.velocity.Y -= num72;
        }
        if (this.type == 23)
        {
          if ((double) SpeedX1 > 0.0)
          {
            this.spriteDirection = 1;
            this.rotation = (float) Math.Atan2((double) SpeedY1, (double) SpeedX1);
          }
          else if ((double) SpeedX1 < 0.0)
          {
            this.spriteDirection = -1;
            this.rotation = (float) Math.Atan2((double) SpeedY1, (double) SpeedX1) + 3.14f;
          }
        }
        else if (this.type == 139)
        {
          ++this.localAI[0];
          if (this.justHit)
            this.localAI[0] = 0.0f;
          if (Main.netMode != 1 && (double) this.localAI[0] >= 120.0)
          {
            this.localAI[0] = 0.0f;
            if (Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
            {
              int Damage = 25;
              int Type = 84;
              Projectile.NewProjectile(vector2_3.X, vector2_3.Y, SpeedX1, SpeedY1, Type, Damage, 0.0f, Main.myPlayer);
            }
          }
          if (!WorldGen.SolidTile(((int) this.position.X + this.width / 2) / 16, ((int) this.position.Y + this.height / 2) / 16))
            Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.3f, 0.1f, 0.05f);
          if ((double) SpeedX1 > 0.0)
          {
            this.spriteDirection = 1;
            this.rotation = (float) Math.Atan2((double) SpeedY1, (double) SpeedX1);
          }
          if ((double) SpeedX1 < 0.0)
          {
            this.spriteDirection = -1;
            this.rotation = (float) Math.Atan2((double) SpeedY1, (double) SpeedX1) + 3.14f;
          }
        }
        else if (this.type == 6 || this.type == 94)
          this.rotation = (float) Math.Atan2((double) SpeedY1, (double) SpeedX1) - 1.57f;
        else if (this.type == 42)
        {
          if ((double) SpeedX1 > 0.0)
            this.spriteDirection = 1;
          if ((double) SpeedX1 < 0.0)
            this.spriteDirection = -1;
          this.rotation = this.velocity.X * 0.1f;
        }
        else
          this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) - 1.57f;
        if (this.type == 6 || this.type == 23 || this.type == 42 || this.type == 94 || this.type == 139)
        {
          float num82 = 0.7f;
          if (this.type == 6)
            num82 = 0.4f;
          if (this.collideX)
          {
            this.netUpdate = true;
            this.velocity.X = this.oldVelocity.X * -num82;
            if (this.direction == -1 && (double) this.velocity.X > 0.0 && (double) this.velocity.X < 2.0)
              this.velocity.X = 2f;
            if (this.direction == 1 && (double) this.velocity.X < 0.0 && (double) this.velocity.X > -2.0)
              this.velocity.X = -2f;
          }
          if (this.collideY)
          {
            this.netUpdate = true;
            this.velocity.Y = this.oldVelocity.Y * -num82;
            if ((double) this.velocity.Y > 0.0 && (double) this.velocity.Y < 1.5)
              this.velocity.Y = 2f;
            if ((double) this.velocity.Y < 0.0 && (double) this.velocity.Y > -1.5)
              this.velocity.Y = -2f;
          }
          if (this.type == 23)
          {
            int index = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, Scale: 2f);
            Main.dust[index].noGravity = true;
            Main.dust[index].velocity.X *= 0.3f;
            Main.dust[index].velocity.Y *= 0.3f;
          }
          else if (this.type != 42 && this.type != 139 && Main.rand.Next(20) == 0)
          {
            int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float) this.height * 0.25f), this.width, (int) ((double) this.height * 0.5), 18, this.velocity.X, 2f, 75, this.color, this.scale);
            Main.dust[index].velocity.X *= 0.5f;
            Main.dust[index].velocity.Y *= 0.1f;
          }
        }
        else if (Main.rand.Next(40) == 0)
        {
          int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float) this.height * 0.25f), this.width, (int) ((double) this.height * 0.5), 5, this.velocity.X, 2f);
          Main.dust[index].velocity.X *= 0.5f;
          Main.dust[index].velocity.Y *= 0.1f;
        }
        if ((this.type == 6 || this.type == 94) && this.wet)
        {
          if ((double) this.velocity.Y > 0.0)
            this.velocity.Y *= 0.95f;
          this.velocity.Y -= 0.3f;
          if ((double) this.velocity.Y < -2.0)
            this.velocity.Y = -2f;
        }
        if (this.type == 42)
        {
          if (this.wet)
          {
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y *= 0.95f;
            this.velocity.Y -= 0.5f;
            if ((double) this.velocity.Y < -4.0)
              this.velocity.Y = -4f;
            this.TargetClosest();
          }
          if ((double) this.ai[1] == 101.0)
          {
            Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 17);
            this.ai[1] = 0.0f;
          }
          if (Main.netMode != 1)
          {
            this.ai[1] += (float) Main.rand.Next(5, 20) * 0.1f * this.scale;
            if ((double) this.ai[1] >= 130.0)
            {
              if (Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
              {
                float num83 = 8f;
                Vector2 vector2_4 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) (this.height / 2));
                float num84 = Main.player[this.target].position.X + (float) Main.player[this.target].width * 0.5f - vector2_4.X + (float) Main.rand.Next(-20, 21);
                float num85 = Main.player[this.target].position.Y + (float) Main.player[this.target].height * 0.5f - vector2_4.Y + (float) Main.rand.Next(-20, 21);
                if ((double) num84 < 0.0 && (double) this.velocity.X < 0.0 || (double) num84 > 0.0 && (double) this.velocity.X > 0.0)
                {
                  float num86 = (float) Math.Sqrt((double) num84 * (double) num84 + (double) num85 * (double) num85);
                  float num87 = num83 / num86;
                  float SpeedX2 = num84 * num87;
                  float SpeedY2 = num85 * num87;
                  int Damage = (int) (13.0 * (double) this.scale);
                  int Type = 55;
                  int index = Projectile.NewProjectile(vector2_4.X, vector2_4.Y, SpeedX2, SpeedY2, Type, Damage, 0.0f, Main.myPlayer);
                  Main.projectile[index].timeLeft = 300;
                  this.ai[1] = 101f;
                  this.netUpdate = true;
                }
                else
                  this.ai[1] = 0.0f;
              }
              else
                this.ai[1] = 0.0f;
            }
          }
        }
        if (this.type == 139 && flag)
        {
          if ((double) this.velocity.X > 0.0 && (double) SpeedX1 > 0.0 || (double) this.velocity.X < 0.0 && (double) SpeedX1 < 0.0)
          {
            if ((double) Math.Abs(this.velocity.X) < 12.0)
              this.velocity.X *= 1.05f;
          }
          else
            this.velocity.X *= 0.9f;
        }
        if (Main.netMode != 1 && this.type == 94 && !Main.player[this.target].dead)
        {
          if (this.justHit)
            this.localAI[0] = 0.0f;
          ++this.localAI[0];
          if ((double) this.localAI[0] == 180.0)
          {
            if (Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
              NPC.NewNPC((int) ((double) this.position.X + (double) (this.width / 2) + (double) this.velocity.X), (int) ((double) this.position.Y + (double) (this.height / 2) + (double) this.velocity.Y), 112);
            this.localAI[0] = 0.0f;
          }
        }
        if (Main.dayTime && this.type != 6 && this.type != 23 && this.type != 42 && this.type != 94 || Main.player[this.target].dead)
        {
          this.velocity.Y -= num72 * 2f;
          if (this.timeLeft > 10)
            this.timeLeft = 10;
        }
        if (((double) this.velocity.X <= 0.0 || (double) this.oldVelocity.X >= 0.0) && ((double) this.velocity.X >= 0.0 || (double) this.oldVelocity.X <= 0.0) && ((double) this.velocity.Y <= 0.0 || (double) this.oldVelocity.Y >= 0.0) && ((double) this.velocity.Y >= 0.0 || (double) this.oldVelocity.Y <= 0.0) || this.justHit)
          return;
        this.netUpdate = true;
      }
      else if (this.aiStyle == 6)
      {
        if (this.type == 117 && (double) this.localAI[1] == 0.0)
        {
          this.localAI[1] = 1f;
          Main.PlaySound(4, (int) this.position.X, (int) this.position.Y, 13);
          int num = 1;
          if ((double) this.velocity.X < 0.0)
            num = -1;
          for (int index = 0; index < 20; ++index)
            Dust.NewDust(new Vector2(this.position.X - 20f, this.position.Y - 20f), this.width + 40, this.height + 40, 5, (float) (num * 8), -1f);
        }
        if (this.type >= 13 && this.type <= 15)
          this.realLife = -1;
        else if ((double) this.ai[3] > 0.0)
          this.realLife = (int) this.ai[3];
        if (this.target < 0 || this.target == (int) byte.MaxValue || Main.player[this.target].dead)
          this.TargetClosest();
        if (Main.player[this.target].dead && this.timeLeft > 300)
          this.timeLeft = 300;
        if (Main.netMode != 1)
        {
          if (this.type == 87 && (double) this.ai[0] == 0.0)
          {
            this.ai[3] = (float) this.whoAmI;
            this.realLife = this.whoAmI;
            int index9 = this.whoAmI;
            for (int index10 = 0; index10 < 14; ++index10)
            {
              int Type = 89;
              if (index10 == 1 || index10 == 8)
              {
                Type = 88;
              }
              else
              {
                switch (index10)
                {
                  case 11:
                    Type = 90;
                    break;
                  case 12:
                    Type = 91;
                    break;
                  case 13:
                    Type = 92;
                    break;
                }
              }
              int number = NPC.NewNPC((int) ((double) this.position.X + (double) (this.width / 2)), (int) ((double) this.position.Y + (double) this.height), Type, this.whoAmI);
              Main.npc[number].ai[3] = (float) this.whoAmI;
              Main.npc[number].realLife = this.whoAmI;
              Main.npc[number].ai[1] = (float) index9;
              Main.npc[index9].ai[0] = (float) number;
              NetMessage.SendData(23, number: number);
              index9 = number;
            }
          }
          if ((this.type == 7 || this.type == 8 || this.type == 10 || this.type == 11 || this.type == 13 || this.type == 14 || this.type == 39 || this.type == 40 || this.type == 95 || this.type == 96 || this.type == 98 || this.type == 99 || this.type == 117 || this.type == 118) && (double) this.ai[0] == 0.0)
          {
            if (this.type == 7 || this.type == 10 || this.type == 13 || this.type == 39 || this.type == 95 || this.type == 98 || this.type == 117)
            {
              if (this.type < 13 || this.type > 15)
              {
                this.ai[3] = (float) this.whoAmI;
                this.realLife = this.whoAmI;
              }
              this.ai[2] = (float) Main.rand.Next(8, 13);
              if (this.type == 10)
                this.ai[2] = (float) Main.rand.Next(4, 7);
              if (this.type == 13)
                this.ai[2] = (float) Main.rand.Next(45, 56);
              if (this.type == 39)
                this.ai[2] = (float) Main.rand.Next(12, 19);
              if (this.type == 95)
                this.ai[2] = (float) Main.rand.Next(6, 12);
              if (this.type == 98)
                this.ai[2] = (float) Main.rand.Next(20, 26);
              if (this.type == 117)
                this.ai[2] = (float) Main.rand.Next(3, 6);
              this.ai[0] = (float) NPC.NewNPC((int) ((double) this.position.X + (double) (this.width / 2)), (int) ((double) this.position.Y + (double) this.height), this.type + 1, this.whoAmI);
            }
            else
              this.ai[0] = this.type != 8 && this.type != 11 && this.type != 14 && this.type != 40 && this.type != 96 && this.type != 99 && this.type != 118 || (double) this.ai[2] <= 0.0 ? (float) NPC.NewNPC((int) ((double) this.position.X + (double) (this.width / 2)), (int) ((double) this.position.Y + (double) this.height), this.type + 1, this.whoAmI) : (float) NPC.NewNPC((int) ((double) this.position.X + (double) (this.width / 2)), (int) ((double) this.position.Y + (double) this.height), this.type, this.whoAmI);
            if (this.type < 13 || this.type > 15)
            {
              Main.npc[(int) this.ai[0]].ai[3] = this.ai[3];
              Main.npc[(int) this.ai[0]].realLife = this.realLife;
            }
            Main.npc[(int) this.ai[0]].ai[1] = (float) this.whoAmI;
            Main.npc[(int) this.ai[0]].ai[2] = this.ai[2] - 1f;
            this.netUpdate = true;
          }
          if ((this.type == 8 || this.type == 9 || this.type == 11 || this.type == 12 || this.type == 40 || this.type == 41 || this.type == 96 || this.type == 97 || this.type == 99 || this.type == 100 || this.type > 87 && this.type <= 92 || this.type == 118 || this.type == 119) && (!Main.npc[(int) this.ai[1]].active || Main.npc[(int) this.ai[1]].aiStyle != this.aiStyle))
          {
            this.life = 0;
            this.HitEffect();
            this.active = false;
          }
          if ((this.type == 7 || this.type == 8 || this.type == 10 || this.type == 11 || this.type == 39 || this.type == 40 || this.type == 95 || this.type == 96 || this.type == 98 || this.type == 99 || this.type >= 87 && this.type < 92 || this.type == 117 || this.type == 118) && (!Main.npc[(int) this.ai[0]].active || Main.npc[(int) this.ai[0]].aiStyle != this.aiStyle))
          {
            this.life = 0;
            this.HitEffect();
            this.active = false;
          }
          if (this.type == 13 || this.type == 14 || this.type == 15)
          {
            if (!Main.npc[(int) this.ai[1]].active && !Main.npc[(int) this.ai[0]].active)
            {
              this.life = 0;
              this.HitEffect();
              this.active = false;
            }
            if (this.type == 13 && !Main.npc[(int) this.ai[0]].active)
            {
              this.life = 0;
              this.HitEffect();
              this.active = false;
            }
            if (this.type == 15 && !Main.npc[(int) this.ai[1]].active)
            {
              this.life = 0;
              this.HitEffect();
              this.active = false;
            }
            if (this.type == 14 && (!Main.npc[(int) this.ai[1]].active || Main.npc[(int) this.ai[1]].aiStyle != this.aiStyle))
            {
              this.type = 13;
              int whoAmI = this.whoAmI;
              float num88 = (float) this.life / (float) this.lifeMax;
              float num89 = this.ai[0];
              this.SetDefaults(this.type);
              this.life = (int) ((double) this.lifeMax * (double) num88);
              this.ai[0] = num89;
              this.TargetClosest();
              this.netUpdate = true;
              this.whoAmI = whoAmI;
            }
            if (this.type == 14 && (!Main.npc[(int) this.ai[0]].active || Main.npc[(int) this.ai[0]].aiStyle != this.aiStyle))
            {
              int whoAmI = this.whoAmI;
              float num90 = (float) this.life / (float) this.lifeMax;
              float num91 = this.ai[1];
              this.SetDefaults(this.type);
              this.life = (int) ((double) this.lifeMax * (double) num90);
              this.ai[1] = num91;
              this.TargetClosest();
              this.netUpdate = true;
              this.whoAmI = whoAmI;
            }
            if (this.life == 0)
            {
              bool flag = true;
              for (int index = 0; index < 200; ++index)
              {
                if (Main.npc[index].active && (Main.npc[index].type == 13 || Main.npc[index].type == 14 || Main.npc[index].type == 15))
                {
                  flag = false;
                  break;
                }
              }
              if (flag)
              {
                this.boss = true;
                this.NPCLoot();
              }
            }
          }
          if (!this.active && Main.netMode == 2)
            NetMessage.SendData(28, number: this.whoAmI, number2: -1f);
        }
        int num92 = (int) ((double) this.position.X / 16.0) - 1;
        int num93 = (int) (((double) this.position.X + (double) this.width) / 16.0) + 2;
        int num94 = (int) ((double) this.position.Y / 16.0) - 1;
        int num95 = (int) (((double) this.position.Y + (double) this.height) / 16.0) + 2;
        if (num92 < 0)
          num92 = 0;
        if (num93 > Main.maxTilesX)
          num93 = Main.maxTilesX;
        if (num94 < 0)
          num94 = 0;
        if (num95 > Main.maxTilesY)
          num95 = Main.maxTilesY;
        bool flag8 = false;
        if (this.type >= 87 && this.type <= 92)
          flag8 = true;
        if (!flag8)
        {
          for (int i = num92; i < num93; ++i)
          {
            for (int j = num94; j < num95; ++j)
            {
              if (Main.tile[i, j] != null && (Main.tile[i, j].active && (Main.tileSolid[(int) Main.tile[i, j].type] || Main.tileSolidTop[(int) Main.tile[i, j].type] && Main.tile[i, j].frameY == (short) 0) || Main.tile[i, j].liquid > (byte) 64))
              {
                Vector2 vector2;
                vector2.X = (float) (i * 16);
                vector2.Y = (float) (j * 16);
                if ((double) this.position.X + (double) this.width > (double) vector2.X && (double) this.position.X < (double) vector2.X + 16.0 && (double) this.position.Y + (double) this.height > (double) vector2.Y && (double) this.position.Y < (double) vector2.Y + 16.0)
                {
                  flag8 = true;
                  if (Main.rand.Next(100) == 0 && this.type != 117 && Main.tile[i, j].active)
                    WorldGen.KillTile(i, j, true, true);
                  if (Main.netMode != 1 && Main.tile[i, j].type == (byte) 2)
                  {
                    int type = (int) Main.tile[i, j - 1].type;
                  }
                }
              }
            }
          }
        }
        if (!flag8 && (this.type == 7 || this.type == 10 || this.type == 13 || this.type == 39 || this.type == 95 || this.type == 98 || this.type == 117))
        {
          Rectangle rectangle1 = new Rectangle((int) this.position.X, (int) this.position.Y, this.width, this.height);
          int num96 = 1000;
          bool flag9 = true;
          for (int index = 0; index < (int) byte.MaxValue; ++index)
          {
            if (Main.player[index].active)
            {
              Rectangle rectangle2 = new Rectangle((int) Main.player[index].position.X - num96, (int) Main.player[index].position.Y - num96, num96 * 2, num96 * 2);
              if (rectangle1.Intersects(rectangle2))
              {
                flag9 = false;
                break;
              }
            }
          }
          if (flag9)
            flag8 = true;
        }
        if (this.type >= 87 && this.type <= 92)
        {
          if ((double) this.velocity.X < 0.0)
            this.spriteDirection = 1;
          else if ((double) this.velocity.X > 0.0)
            this.spriteDirection = -1;
        }
        float num97 = 8f;
        float num98 = 0.07f;
        if (this.type == 95)
        {
          num97 = 5.5f;
          num98 = 0.045f;
        }
        if (this.type == 10)
        {
          num97 = 6f;
          num98 = 0.05f;
        }
        if (this.type == 13)
        {
          num97 = 10f;
          num98 = 0.07f;
        }
        if (this.type == 87)
        {
          num97 = 11f;
          num98 = 0.25f;
        }
        if (this.type == 117 && Main.wof >= 0)
        {
          float num99 = (float) Main.npc[Main.wof].life / (float) Main.npc[Main.wof].lifeMax;
          if ((double) num99 < 0.5)
          {
            ++num97;
            num98 += 0.1f;
          }
          if ((double) num99 < 0.25)
          {
            ++num97;
            num98 += 0.1f;
          }
          if ((double) num99 < 0.1)
          {
            num97 += 2f;
            num98 += 0.1f;
          }
        }
        Vector2 vector2_5 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num100 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2);
        float num101 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2);
        float num102 = (float) ((int) ((double) num100 / 16.0) * 16);
        float num103 = (float) ((int) ((double) num101 / 16.0) * 16);
        vector2_5.X = (float) ((int) ((double) vector2_5.X / 16.0) * 16);
        vector2_5.Y = (float) ((int) ((double) vector2_5.Y / 16.0) * 16);
        float num104 = num102 - vector2_5.X;
        float num105 = num103 - vector2_5.Y;
        float num106 = (float) Math.Sqrt((double) num104 * (double) num104 + (double) num105 * (double) num105);
        if ((double) this.ai[1] > 0.0)
        {
          if ((double) this.ai[1] < (double) Main.npc.Length)
          {
            try
            {
              vector2_5 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
              num104 = Main.npc[(int) this.ai[1]].position.X + (float) (Main.npc[(int) this.ai[1]].width / 2) - vector2_5.X;
              num105 = Main.npc[(int) this.ai[1]].position.Y + (float) (Main.npc[(int) this.ai[1]].height / 2) - vector2_5.Y;
            }
            catch
            {
            }
            this.rotation = (float) Math.Atan2((double) num105, (double) num104) + 1.57f;
            float num107 = (float) Math.Sqrt((double) num104 * (double) num104 + (double) num105 * (double) num105);
            int num108 = this.width;
            if (this.type >= 87 && this.type <= 92)
              num108 = 42;
            float num109 = (num107 - (float) num108) / num107;
            float num110 = num104 * num109;
            float num111 = num105 * num109;
            this.velocity = new Vector2();
            this.position.X += num110;
            this.position.Y += num111;
            if (this.type < 87 || this.type > 92)
              return;
            if ((double) num110 < 0.0)
            {
              this.spriteDirection = 1;
              return;
            }
            if ((double) num110 <= 0.0)
              return;
            this.spriteDirection = -1;
            return;
          }
        }
        if (!flag8)
        {
          this.TargetClosest();
          this.velocity.Y += 0.11f;
          if ((double) this.velocity.Y > (double) num97)
            this.velocity.Y = num97;
          if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) < (double) num97 * 0.4)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X -= num98 * 1.1f;
            else
              this.velocity.X += num98 * 1.1f;
          }
          else if ((double) this.velocity.Y == (double) num97)
          {
            if ((double) this.velocity.X < (double) num104)
              this.velocity.X += num98;
            else if ((double) this.velocity.X > (double) num104)
              this.velocity.X -= num98;
          }
          else if ((double) this.velocity.Y > 4.0)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X += num98 * 0.9f;
            else
              this.velocity.X -= num98 * 0.9f;
          }
        }
        else
        {
          if (this.type != 87 && this.type != 117 && this.soundDelay == 0)
          {
            float num112 = num106 / 40f;
            if ((double) num112 < 10.0)
              num112 = 10f;
            if ((double) num112 > 20.0)
              num112 = 20f;
            this.soundDelay = (int) num112;
            Main.PlaySound(15, (int) this.position.X, (int) this.position.Y);
          }
          float num113 = (float) Math.Sqrt((double) num104 * (double) num104 + (double) num105 * (double) num105);
          float num114 = Math.Abs(num104);
          float num115 = Math.Abs(num105);
          float num116 = num97 / num113;
          float num117 = num104 * num116;
          float num118 = num105 * num116;
          if ((this.type == 13 || this.type == 7) && !Main.player[this.target].zoneEvil)
          {
            bool flag10 = true;
            for (int index = 0; index < (int) byte.MaxValue; ++index)
            {
              if (Main.player[index].active && !Main.player[index].dead && Main.player[index].zoneEvil)
                flag10 = false;
            }
            if (flag10)
            {
              if (Main.netMode != 1 && (double) this.position.Y / 16.0 > (Main.rockLayer + (double) Main.maxTilesY) / 2.0)
              {
                this.active = false;
                int num119;
                for (int number = (int) this.ai[0]; number > 0 && number < 200 && Main.npc[number].active && Main.npc[number].aiStyle == this.aiStyle; number = num119)
                {
                  num119 = (int) Main.npc[number].ai[0];
                  Main.npc[number].active = false;
                  this.life = 0;
                  if (Main.netMode == 2)
                    NetMessage.SendData(23, number: number);
                }
                if (Main.netMode == 2)
                  NetMessage.SendData(23, number: this.whoAmI);
              }
              num117 = 0.0f;
              num118 = num97;
            }
          }
          bool flag11 = false;
          if (this.type == 87)
          {
            if (((double) this.velocity.X > 0.0 && (double) num117 < 0.0 || (double) this.velocity.X < 0.0 && (double) num117 > 0.0 || (double) this.velocity.Y > 0.0 && (double) num118 < 0.0 || (double) this.velocity.Y < 0.0 && (double) num118 > 0.0) && (double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) > (double) num98 / 2.0 && (double) num113 < 300.0)
            {
              flag11 = true;
              if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) < (double) num97)
                this.velocity *= 1.1f;
            }
            if ((double) this.position.Y > (double) Main.player[this.target].position.Y || (double) Main.player[this.target].position.Y / 16.0 > Main.worldSurface || Main.player[this.target].dead)
            {
              flag11 = true;
              if ((double) Math.Abs(this.velocity.X) < (double) num97 / 2.0)
              {
                if ((double) this.velocity.X == 0.0)
                  this.velocity.X -= (float) this.direction;
                this.velocity.X *= 1.1f;
              }
              else if ((double) this.velocity.Y > -(double) num97)
                this.velocity.Y -= num98;
            }
          }
          if (!flag11)
          {
            if ((double) this.velocity.X > 0.0 && (double) num117 > 0.0 || (double) this.velocity.X < 0.0 && (double) num117 < 0.0 || (double) this.velocity.Y > 0.0 && (double) num118 > 0.0 || (double) this.velocity.Y < 0.0 && (double) num118 < 0.0)
            {
              if ((double) this.velocity.X < (double) num117)
                this.velocity.X += num98;
              else if ((double) this.velocity.X > (double) num117)
                this.velocity.X -= num98;
              if ((double) this.velocity.Y < (double) num118)
                this.velocity.Y += num98;
              else if ((double) this.velocity.Y > (double) num118)
                this.velocity.Y -= num98;
              if ((double) Math.Abs(num118) < (double) num97 * 0.2 && ((double) this.velocity.X > 0.0 && (double) num117 < 0.0 || (double) this.velocity.X < 0.0 && (double) num117 > 0.0))
              {
                if ((double) this.velocity.Y > 0.0)
                  this.velocity.Y += num98 * 2f;
                else
                  this.velocity.Y -= num98 * 2f;
              }
              if ((double) Math.Abs(num117) < (double) num97 * 0.2 && ((double) this.velocity.Y > 0.0 && (double) num118 < 0.0 || (double) this.velocity.Y < 0.0 && (double) num118 > 0.0))
              {
                if ((double) this.velocity.X > 0.0)
                  this.velocity.X += num98 * 2f;
                else
                  this.velocity.X -= num98 * 2f;
              }
            }
            else if ((double) num114 > (double) num115)
            {
              if ((double) this.velocity.X < (double) num117)
                this.velocity.X += num98 * 1.1f;
              else if ((double) this.velocity.X > (double) num117)
                this.velocity.X -= num98 * 1.1f;
              if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) < (double) num97 * 0.5)
              {
                if ((double) this.velocity.Y > 0.0)
                  this.velocity.Y += num98;
                else
                  this.velocity.Y -= num98;
              }
            }
            else
            {
              if ((double) this.velocity.Y < (double) num118)
                this.velocity.Y += num98 * 1.1f;
              else if ((double) this.velocity.Y > (double) num118)
                this.velocity.Y -= num98 * 1.1f;
              if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) < (double) num97 * 0.5)
              {
                if ((double) this.velocity.X > 0.0)
                  this.velocity.X += num98;
                else
                  this.velocity.X -= num98;
              }
            }
          }
        }
        this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 1.57f;
        if (this.type != 7 && this.type != 10 && this.type != 13 && this.type != 39 && this.type != 95 && this.type != 98 && this.type != 117)
          return;
        if (flag8)
        {
          if ((double) this.localAI[0] != 1.0)
            this.netUpdate = true;
          this.localAI[0] = 1f;
        }
        else
        {
          if ((double) this.localAI[0] != 0.0)
            this.netUpdate = true;
          this.localAI[0] = 0.0f;
        }
        if (((double) this.velocity.X <= 0.0 || (double) this.oldVelocity.X >= 0.0) && ((double) this.velocity.X >= 0.0 || (double) this.oldVelocity.X <= 0.0) && ((double) this.velocity.Y <= 0.0 || (double) this.oldVelocity.Y >= 0.0) && ((double) this.velocity.Y >= 0.0 || (double) this.oldVelocity.Y <= 0.0) || this.justHit)
          return;
        this.netUpdate = true;
      }
      else if (this.aiStyle == 7)
      {
        if (this.type == 142 && Main.netMode != 1 && !Main.xMas)
        {
          this.StrikeNPC(9999, 0.0f, 0);
          if (Main.netMode == 2)
            NetMessage.SendData(28, number: this.whoAmI, number2: 9999f);
        }
        int index11 = (int) ((double) this.position.X + (double) (this.width / 2)) / 16;
        int index12 = (int) ((double) this.position.Y + (double) this.height + 1.0) / 16;
        if (this.type == 107)
          NPC.savedGoblin = true;
        if (this.type == 108)
          NPC.savedWizard = true;
        if (this.type == 124)
          NPC.savedMech = true;
        if (this.type == 46 && this.target == (int) byte.MaxValue)
          this.TargetClosest();
        bool flag12 = false;
        this.directionY = -1;
        if (this.direction == 0)
          this.direction = 1;
        for (int index13 = 0; index13 < (int) byte.MaxValue; ++index13)
        {
          if (Main.player[index13].active && Main.player[index13].talkNPC == this.whoAmI)
          {
            flag12 = true;
            if ((double) this.ai[0] != 0.0)
              this.netUpdate = true;
            this.ai[0] = 0.0f;
            this.ai[1] = 300f;
            this.ai[2] = 100f;
            this.direction = (double) Main.player[index13].position.X + (double) (Main.player[index13].width / 2) >= (double) this.position.X + (double) (this.width / 2) ? 1 : -1;
          }
        }
        if ((double) this.ai[3] > 0.0)
        {
          this.life = -1;
          this.HitEffect();
          this.active = false;
          if (this.type == 37)
            Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
        }
        if (this.type == 37 && Main.netMode != 1)
        {
          this.homeless = false;
          this.homeTileX = Main.dungeonX;
          this.homeTileY = Main.dungeonY;
          if (NPC.downedBoss3)
          {
            this.ai[3] = 1f;
            this.netUpdate = true;
          }
        }
        int homeTileY = this.homeTileY;
        if (Main.netMode != 1 && this.homeTileY > 0)
        {
          while (!WorldGen.SolidTile(this.homeTileX, homeTileY) && homeTileY < Main.maxTilesY - 20)
            ++homeTileY;
        }
        if (Main.netMode != 1 && this.townNPC && (!Main.dayTime || Main.tileDungeon[(int) Main.tile[index11, index12].type]) && (index11 != this.homeTileX || index12 != homeTileY) && !this.homeless)
        {
          bool flag13 = true;
          for (int index14 = 0; index14 < 2; ++index14)
          {
            Rectangle rectangle = new Rectangle((int) ((double) this.position.X + (double) (this.width / 2) - (double) (NPC.sWidth / 2) - (double) NPC.safeRangeX), (int) ((double) this.position.Y + (double) (this.height / 2) - (double) (NPC.sHeight / 2) - (double) NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
            if (index14 == 1)
              rectangle = new Rectangle(this.homeTileX * 16 + 8 - NPC.sWidth / 2 - NPC.safeRangeX, homeTileY * 16 + 8 - NPC.sHeight / 2 - NPC.safeRangeY, NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
            for (int index15 = 0; index15 < (int) byte.MaxValue; ++index15)
            {
              if (Main.player[index15].active && new Rectangle((int) Main.player[index15].position.X, (int) Main.player[index15].position.Y, Main.player[index15].width, Main.player[index15].height).Intersects(rectangle))
              {
                flag13 = false;
                break;
              }
              if (!flag13)
                break;
            }
          }
          if (flag13)
          {
            if (this.type == 37 || !Collision.SolidTiles(this.homeTileX - 1, this.homeTileX + 1, homeTileY - 3, homeTileY - 1))
            {
              this.velocity.X = 0.0f;
              this.velocity.Y = 0.0f;
              this.position.X = (float) (this.homeTileX * 16 + 8 - this.width / 2);
              this.position.Y = (float) (homeTileY * 16 - this.height) - 0.1f;
              this.netUpdate = true;
            }
            else
            {
              this.homeless = true;
              WorldGen.QuickFindHome(this.whoAmI);
            }
          }
        }
        if ((double) this.ai[0] == 0.0)
        {
          if ((double) this.ai[2] > 0.0)
            --this.ai[2];
          if (!Main.dayTime && !flag12 && this.type != 46)
          {
            if (Main.netMode != 1)
            {
              if (index11 == this.homeTileX && index12 == homeTileY)
              {
                if ((double) this.velocity.X != 0.0)
                  this.netUpdate = true;
                if ((double) this.velocity.X > 0.1)
                  this.velocity.X -= 0.1f;
                else if ((double) this.velocity.X < -0.1)
                  this.velocity.X += 0.1f;
                else
                  this.velocity.X = 0.0f;
              }
              else if (!flag12)
              {
                this.direction = index11 <= this.homeTileX ? 1 : -1;
                this.ai[0] = 1f;
                this.ai[1] = (float) (200 + Main.rand.Next(200));
                this.ai[2] = 0.0f;
                this.netUpdate = true;
              }
            }
          }
          else
          {
            if ((double) this.velocity.X > 0.1)
              this.velocity.X -= 0.1f;
            else if ((double) this.velocity.X < -0.1)
              this.velocity.X += 0.1f;
            else
              this.velocity.X = 0.0f;
            if (Main.netMode != 1)
            {
              if ((double) this.ai[1] > 0.0)
                --this.ai[1];
              if ((double) this.ai[1] <= 0.0)
              {
                this.ai[0] = 1f;
                this.ai[1] = (float) (200 + Main.rand.Next(200));
                if (this.type == 46)
                  this.ai[1] += (float) Main.rand.Next(200, 400);
                this.ai[2] = 0.0f;
                this.netUpdate = true;
              }
            }
          }
          if (Main.netMode == 1 || !Main.dayTime && (index11 != this.homeTileX || index12 != homeTileY))
            return;
          if (index11 < this.homeTileX - 25 || index11 > this.homeTileX + 25)
          {
            if ((double) this.ai[2] != 0.0)
              return;
            if (index11 < this.homeTileX - 50 && this.direction == -1)
            {
              this.direction = 1;
              this.netUpdate = true;
            }
            else
            {
              if (index11 <= this.homeTileX + 50 || this.direction != 1)
                return;
              this.direction = -1;
              this.netUpdate = true;
            }
          }
          else
          {
            if (Main.rand.Next(80) != 0 || (double) this.ai[2] != 0.0)
              return;
            this.ai[2] = 200f;
            this.direction *= -1;
            this.netUpdate = true;
          }
        }
        else
        {
          if ((double) this.ai[0] != 1.0)
            return;
          if (Main.netMode != 1 && !Main.dayTime && index11 == this.homeTileX && index12 == this.homeTileY && this.type != 46)
          {
            this.ai[0] = 0.0f;
            this.ai[1] = (float) (200 + Main.rand.Next(200));
            this.ai[2] = 60f;
            this.netUpdate = true;
          }
          else
          {
            if (Main.netMode != 1 && !this.homeless && !Main.tileDungeon[(int) Main.tile[index11, index12].type] && (index11 < this.homeTileX - 35 || index11 > this.homeTileX + 35))
            {
              if ((double) this.position.X < (double) (this.homeTileX * 16) && this.direction == -1)
                this.ai[1] -= 5f;
              else if ((double) this.position.X > (double) (this.homeTileX * 16) && this.direction == 1)
                this.ai[1] -= 5f;
            }
            --this.ai[1];
            if ((double) this.ai[1] <= 0.0)
            {
              this.ai[0] = 0.0f;
              this.ai[1] = (float) (300 + Main.rand.Next(300));
              if (this.type == 46)
                this.ai[1] -= (float) Main.rand.Next(100);
              this.ai[2] = 60f;
              this.netUpdate = true;
            }
            if (this.closeDoor && (((double) this.position.X + (double) (this.width / 2)) / 16.0 > (double) (this.doorX + 2) || ((double) this.position.X + (double) (this.width / 2)) / 16.0 < (double) (this.doorX - 2)))
            {
              if (WorldGen.CloseDoor(this.doorX, this.doorY))
              {
                this.closeDoor = false;
                NetMessage.SendData(19, number: 1, number2: ((float) this.doorX), number3: ((float) this.doorY), number4: ((float) this.direction));
              }
              if (((double) this.position.X + (double) (this.width / 2)) / 16.0 > (double) (this.doorX + 4) || ((double) this.position.X + (double) (this.width / 2)) / 16.0 < (double) (this.doorX - 4) || ((double) this.position.Y + (double) (this.height / 2)) / 16.0 > (double) (this.doorY + 4) || ((double) this.position.Y + (double) (this.height / 2)) / 16.0 < (double) (this.doorY - 4))
                this.closeDoor = false;
            }
            if ((double) this.velocity.X < -1.0 || (double) this.velocity.X > 1.0)
            {
              if ((double) this.velocity.Y == 0.0)
                this.velocity *= 0.8f;
            }
            else if ((double) this.velocity.X < 1.15 && this.direction == 1)
            {
              this.velocity.X += 0.07f;
              if ((double) this.velocity.X > 1.0)
                this.velocity.X = 1f;
            }
            else if ((double) this.velocity.X > -1.0 && this.direction == -1)
            {
              this.velocity.X -= 0.07f;
              if ((double) this.velocity.X > 1.0)
                this.velocity.X = 1f;
            }
            if ((double) this.velocity.Y != 0.0)
              return;
            if ((double) this.position.X == (double) this.ai[2])
              this.direction *= -1;
            this.ai[2] = -1f;
            int index16 = (int) (((double) this.position.X + (double) (this.width / 2) + (double) (15 * this.direction)) / 16.0);
            int index17 = (int) (((double) this.position.Y + (double) this.height - 16.0) / 16.0);
            if (Main.tile[index16, index17] == null)
              Main.tile[index16, index17] = new Tile();
            if (Main.tile[index16, index17 - 1] == null)
              Main.tile[index16, index17 - 1] = new Tile();
            if (Main.tile[index16, index17 - 2] == null)
              Main.tile[index16, index17 - 2] = new Tile();
            if (Main.tile[index16, index17 - 3] == null)
              Main.tile[index16, index17 - 3] = new Tile();
            if (Main.tile[index16, index17 + 1] == null)
              Main.tile[index16, index17 + 1] = new Tile();
            if (Main.tile[index16 + this.direction, index17 - 1] == null)
              Main.tile[index16 + this.direction, index17 - 1] = new Tile();
            if (Main.tile[index16 + this.direction, index17 + 1] == null)
              Main.tile[index16 + this.direction, index17 + 1] = new Tile();
            if (this.townNPC && Main.tile[index16, index17 - 2].active && Main.tile[index16, index17 - 2].type == (byte) 10 && (Main.rand.Next(10) == 0 || !Main.dayTime))
            {
              if (Main.netMode == 1)
                return;
              if (WorldGen.OpenDoor(index16, index17 - 2, this.direction))
              {
                this.closeDoor = true;
                this.doorX = index16;
                this.doorY = index17 - 2;
                NetMessage.SendData(19, number2: ((float) index16), number3: ((float) (index17 - 2)), number4: ((float) this.direction));
                this.netUpdate = true;
                this.ai[1] += 80f;
              }
              else if (WorldGen.OpenDoor(index16, index17 - 2, -this.direction))
              {
                this.closeDoor = true;
                this.doorX = index16;
                this.doorY = index17 - 2;
                NetMessage.SendData(19, number2: ((float) index16), number3: ((float) (index17 - 2)), number4: ((float) -this.direction));
                this.netUpdate = true;
                this.ai[1] += 80f;
              }
              else
              {
                this.direction *= -1;
                this.netUpdate = true;
              }
            }
            else
            {
              if ((double) this.velocity.X < 0.0 && this.spriteDirection == -1 || (double) this.velocity.X > 0.0 && this.spriteDirection == 1)
              {
                if (Main.tile[index16, index17 - 2].active && Main.tileSolid[(int) Main.tile[index16, index17 - 2].type] && !Main.tileSolidTop[(int) Main.tile[index16, index17 - 2].type])
                {
                  if (this.direction == 1 && !Collision.SolidTiles(index16 - 2, index16 - 1, index17 - 5, index17 - 1) || this.direction == -1 && !Collision.SolidTiles(index16 + 1, index16 + 2, index17 - 5, index17 - 1))
                  {
                    if (!Collision.SolidTiles(index16, index16, index17 - 5, index17 - 3))
                    {
                      this.velocity.Y = -6f;
                      this.netUpdate = true;
                    }
                    else
                    {
                      this.direction *= -1;
                      this.netUpdate = true;
                    }
                  }
                  else
                  {
                    this.direction *= -1;
                    this.netUpdate = true;
                  }
                }
                else if (Main.tile[index16, index17 - 1].active && Main.tileSolid[(int) Main.tile[index16, index17 - 1].type] && !Main.tileSolidTop[(int) Main.tile[index16, index17 - 1].type])
                {
                  if (this.direction == 1 && !Collision.SolidTiles(index16 - 2, index16 - 1, index17 - 4, index17 - 1) || this.direction == -1 && !Collision.SolidTiles(index16 + 1, index16 + 2, index17 - 4, index17 - 1))
                  {
                    if (!Collision.SolidTiles(index16, index16, index17 - 4, index17 - 2))
                    {
                      this.velocity.Y = -5f;
                      this.netUpdate = true;
                    }
                    else
                    {
                      this.direction *= -1;
                      this.netUpdate = true;
                    }
                  }
                  else
                  {
                    this.direction *= -1;
                    this.netUpdate = true;
                  }
                }
                else if (Main.tile[index16, index17].active)
                {
                  if (Main.tileSolid[(int) Main.tile[index16, index17].type])
                  {
                    if (!Main.tileSolidTop[(int) Main.tile[index16, index17].type])
                    {
                      if (this.direction == 1 && !Collision.SolidTiles(index16 - 2, index16, index17 - 3, index17 - 1) || this.direction == -1 && !Collision.SolidTiles(index16, index16 + 2, index17 - 3, index17 - 1))
                      {
                        this.velocity.Y = -3.6f;
                        this.netUpdate = true;
                      }
                      else
                      {
                        this.direction *= -1;
                        this.netUpdate = true;
                      }
                    }
                  }
                }
                try
                {
                  if (Main.tile[index16, index17 + 1] == null)
                    Main.tile[index16, index17 + 1] = new Tile();
                  if (Main.tile[index16 - this.direction, index17 + 1] == null)
                    Main.tile[index16 - this.direction, index17 + 1] = new Tile();
                  if (Main.tile[index16, index17 + 2] == null)
                    Main.tile[index16, index17 + 2] = new Tile();
                  if (Main.tile[index16 - this.direction, index17 + 2] == null)
                    Main.tile[index16 - this.direction, index17 + 2] = new Tile();
                  if (Main.tile[index16, index17 + 3] == null)
                    Main.tile[index16, index17 + 3] = new Tile();
                  if (Main.tile[index16 - this.direction, index17 + 3] == null)
                    Main.tile[index16 - this.direction, index17 + 3] = new Tile();
                  if (Main.tile[index16, index17 + 4] == null)
                    Main.tile[index16, index17 + 4] = new Tile();
                  if (Main.tile[index16 - this.direction, index17 + 4] == null)
                    Main.tile[index16 - this.direction, index17 + 4] = new Tile();
                  else if (index11 >= this.homeTileX - 35)
                  {
                    if (index11 <= this.homeTileX + 35)
                    {
                      if (Main.tile[index16, index17 + 1].active)
                      {
                        if (Main.tileSolid[(int) Main.tile[index16, index17 + 1].type])
                          goto label_1136;
                      }
                      if (Main.tile[index16 - this.direction, index17 + 1].active)
                      {
                        if (Main.tileSolid[(int) Main.tile[index16 - this.direction, index17 + 1].type])
                          goto label_1136;
                      }
                      if (Main.tile[index16, index17 + 2].active)
                      {
                        if (Main.tileSolid[(int) Main.tile[index16, index17 + 2].type])
                          goto label_1136;
                      }
                      if (Main.tile[index16 - this.direction, index17 + 2].active)
                      {
                        if (Main.tileSolid[(int) Main.tile[index16 - this.direction, index17 + 2].type])
                          goto label_1136;
                      }
                      if (Main.tile[index16, index17 + 3].active)
                      {
                        if (Main.tileSolid[(int) Main.tile[index16, index17 + 3].type])
                          goto label_1136;
                      }
                      if (Main.tile[index16 - this.direction, index17 + 3].active)
                      {
                        if (Main.tileSolid[(int) Main.tile[index16 - this.direction, index17 + 3].type])
                          goto label_1136;
                      }
                      if (Main.tile[index16, index17 + 4].active)
                      {
                        if (Main.tileSolid[(int) Main.tile[index16, index17 + 4].type])
                          goto label_1136;
                      }
                      if (Main.tile[index16 - this.direction, index17 + 4].active)
                      {
                        if (Main.tileSolid[(int) Main.tile[index16 - this.direction, index17 + 4].type])
                          goto label_1136;
                      }
                      if (this.type != 46)
                      {
                        this.direction *= -1;
                        this.velocity.X *= -1f;
                        this.netUpdate = true;
                      }
                    }
                  }
                }
                catch
                {
                }
label_1136:
                if ((double) this.velocity.Y < 0.0)
                  this.ai[2] = this.position.X;
              }
              if ((double) this.velocity.Y < 0.0 && this.wet)
                this.velocity.Y *= 1.2f;
              if ((double) this.velocity.Y >= 0.0 || this.type != 46)
                return;
              this.velocity.Y *= 1.2f;
            }
          }
        }
      }
      else if (this.aiStyle == 8)
      {
        this.TargetClosest();
        this.velocity.X *= 0.93f;
        if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
          this.velocity.X = 0.0f;
        if ((double) this.ai[0] == 0.0)
          this.ai[0] = 500f;
        if ((double) this.ai[2] != 0.0 && (double) this.ai[3] != 0.0)
        {
          Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 8);
          for (int index18 = 0; index18 < 50; ++index18)
          {
            if (this.type == 29 || this.type == 45)
            {
              int index19 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, Alpha: 100, Scale: ((float) Main.rand.Next(1, 3)));
              Main.dust[index19].velocity *= 3f;
              if ((double) Main.dust[index19].scale > 1.0)
                Main.dust[index19].noGravity = true;
            }
            else if (this.type == 32)
            {
              int index20 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 29, Alpha: 100, Scale: 2.5f);
              Main.dust[index20].velocity *= 3f;
              Main.dust[index20].noGravity = true;
            }
            else
            {
              int index21 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 2.5f);
              Main.dust[index21].velocity *= 3f;
              Main.dust[index21].noGravity = true;
            }
          }
          this.position.X = (float) ((double) this.ai[2] * 16.0 - (double) (this.width / 2) + 8.0);
          this.position.Y = this.ai[3] * 16f - (float) this.height;
          this.velocity.X = 0.0f;
          this.velocity.Y = 0.0f;
          this.ai[2] = 0.0f;
          this.ai[3] = 0.0f;
          Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 8);
          for (int index22 = 0; index22 < 50; ++index22)
          {
            if (this.type == 29 || this.type == 45)
            {
              int index23 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, Alpha: 100, Scale: ((float) Main.rand.Next(1, 3)));
              Main.dust[index23].velocity *= 3f;
              if ((double) Main.dust[index23].scale > 1.0)
                Main.dust[index23].noGravity = true;
            }
            else if (this.type == 32)
            {
              int index24 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 29, Alpha: 100, Scale: 2.5f);
              Main.dust[index24].velocity *= 3f;
              Main.dust[index24].noGravity = true;
            }
            else
            {
              int index25 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 2.5f);
              Main.dust[index25].velocity *= 3f;
              Main.dust[index25].noGravity = true;
            }
          }
        }
        ++this.ai[0];
        if ((double) this.ai[0] == 100.0 || (double) this.ai[0] == 200.0 || (double) this.ai[0] == 300.0)
        {
          this.ai[1] = 30f;
          this.netUpdate = true;
        }
        else if ((double) this.ai[0] >= 650.0 && Main.netMode != 1)
        {
          this.ai[0] = 1f;
          int num120 = (int) Main.player[this.target].position.X / 16;
          int num121 = (int) Main.player[this.target].position.Y / 16;
          int num122 = (int) this.position.X / 16;
          int num123 = (int) this.position.Y / 16;
          int num124 = 20;
          int num125 = 0;
          bool flag14 = false;
          if ((double) Math.Abs(this.position.X - Main.player[this.target].position.X) + (double) Math.Abs(this.position.Y - Main.player[this.target].position.Y) > 2000.0)
          {
            num125 = 100;
            flag14 = true;
          }
          while (!flag14 && num125 < 100)
          {
            ++num125;
            int index26 = Main.rand.Next(num120 - num124, num120 + num124);
            for (int index27 = Main.rand.Next(num121 - num124, num121 + num124); index27 < num121 + num124; ++index27)
            {
              if ((index27 < num121 - 4 || index27 > num121 + 4 || index26 < num120 - 4 || index26 > num120 + 4) && (index27 < num123 - 1 || index27 > num123 + 1 || index26 < num122 - 1 || index26 > num122 + 1) && Main.tile[index26, index27].active)
              {
                bool flag15 = true;
                if (this.type == 32 && Main.tile[index26, index27 - 1].wall == (byte) 0)
                  flag15 = false;
                else if (Main.tile[index26, index27 - 1].lava)
                  flag15 = false;
                if (flag15 && Main.tileSolid[(int) Main.tile[index26, index27].type] && !Collision.SolidTiles(index26 - 1, index26 + 1, index27 - 4, index27 - 1))
                {
                  this.ai[1] = 20f;
                  this.ai[2] = (float) index26;
                  this.ai[3] = (float) index27;
                  flag14 = true;
                  break;
                }
              }
            }
          }
          this.netUpdate = true;
        }
        if ((double) this.ai[1] > 0.0)
        {
          --this.ai[1];
          if ((double) this.ai[1] == 25.0)
          {
            Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 8);
            if (Main.netMode != 1)
            {
              if (this.type == 29 || this.type == 45)
                NPC.NewNPC((int) this.position.X + this.width / 2, (int) this.position.Y - 8, 30);
              else if (this.type == 32)
                NPC.NewNPC((int) this.position.X + this.width / 2, (int) this.position.Y - 8, 33);
              else
                NPC.NewNPC((int) this.position.X + this.width / 2 + this.direction * 8, (int) this.position.Y + 20, 25);
            }
          }
        }
        if (this.type == 29 || this.type == 45)
        {
          if (Main.rand.Next(5) != 0)
            return;
          int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 2f), this.width, this.height, 27, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, Scale: 1.5f);
          Main.dust[index].noGravity = true;
          Main.dust[index].velocity.X *= 0.5f;
          Main.dust[index].velocity.Y = -2f;
        }
        else if (this.type == 32)
        {
          if (Main.rand.Next(2) != 0)
            return;
          int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 2f), this.width, this.height, 29, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, Scale: 2f);
          Main.dust[index].noGravity = true;
          Main.dust[index].velocity.X *= 1f;
          Main.dust[index].velocity.Y *= 1f;
        }
        else
        {
          if (Main.rand.Next(2) != 0)
            return;
          int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 2f), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, Scale: 2f);
          Main.dust[index].noGravity = true;
          Main.dust[index].velocity.X *= 1f;
          Main.dust[index].velocity.Y *= 1f;
        }
      }
      else if (this.aiStyle == 9)
      {
        if (this.target == (int) byte.MaxValue)
        {
          this.TargetClosest();
          float num126 = 6f;
          if (this.type == 25)
            num126 = 5f;
          if (this.type == 112)
            num126 = 7f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num127 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
          float num128 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
          float num129 = (float) Math.Sqrt((double) num127 * (double) num127 + (double) num128 * (double) num128);
          float num130 = num126 / num129;
          this.velocity.X = num127 * num130;
          this.velocity.Y = num128 * num130;
        }
        if (this.type == 112)
        {
          ++this.ai[0];
          if ((double) this.ai[0] > 3.0)
            this.ai[0] = 3f;
          if ((double) this.ai[0] == 2.0)
          {
            this.position += this.velocity;
            Main.PlaySound(4, (int) this.position.X, (int) this.position.Y, 9);
            for (int index28 = 0; index28 < 20; ++index28)
            {
              int index29 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 2f), this.width, this.height, 18, Alpha: 100, Scale: 1.8f);
              Main.dust[index29].velocity *= 1.3f;
              Main.dust[index29].velocity += this.velocity;
              Main.dust[index29].noGravity = true;
            }
          }
        }
        if (this.type == 112 && Collision.SolidCollision(this.position, this.width, this.height))
        {
          if (Main.netMode != 1)
          {
            int num131 = (int) ((double) this.position.X + (double) (this.width / 2)) / 16;
            int num132 = (int) ((double) this.position.Y + (double) (this.height / 2)) / 16;
            int num133 = 8;
            for (int index30 = num131 - num133; index30 <= num131 + num133; ++index30)
            {
              for (int index31 = num132 - num133; index31 < num132 + num133; ++index31)
              {
                if ((double) (Math.Abs(index30 - num131) + Math.Abs(index31 - num132)) < (double) num133 * 0.5)
                {
                  if (Main.tile[index30, index31].type == (byte) 2)
                  {
                    Main.tile[index30, index31].type = (byte) 23;
                    WorldGen.SquareTileFrame(index30, index31);
                    if (Main.netMode == 2)
                      NetMessage.SendTileSquare(-1, index30, index31, 1);
                  }
                  else if (Main.tile[index30, index31].type == (byte) 1)
                  {
                    Main.tile[index30, index31].type = (byte) 25;
                    WorldGen.SquareTileFrame(index30, index31);
                    if (Main.netMode == 2)
                      NetMessage.SendTileSquare(-1, index30, index31, 1);
                  }
                  else if (Main.tile[index30, index31].type == (byte) 53)
                  {
                    Main.tile[index30, index31].type = (byte) 112;
                    WorldGen.SquareTileFrame(index30, index31);
                    if (Main.netMode == 2)
                      NetMessage.SendTileSquare(-1, index30, index31, 1);
                  }
                  else if (Main.tile[index30, index31].type == (byte) 109)
                  {
                    Main.tile[index30, index31].type = (byte) 23;
                    WorldGen.SquareTileFrame(index30, index31);
                    if (Main.netMode == 2)
                      NetMessage.SendTileSquare(-1, index30, index31, 1);
                  }
                  else if (Main.tile[index30, index31].type == (byte) 117)
                  {
                    Main.tile[index30, index31].type = (byte) 25;
                    WorldGen.SquareTileFrame(index30, index31);
                    if (Main.netMode == 2)
                      NetMessage.SendTileSquare(-1, index30, index31, 1);
                  }
                  else if (Main.tile[index30, index31].type == (byte) 116)
                  {
                    Main.tile[index30, index31].type = (byte) 112;
                    WorldGen.SquareTileFrame(index30, index31);
                    if (Main.netMode == 2)
                      NetMessage.SendTileSquare(-1, index30, index31, 1);
                  }
                }
              }
            }
          }
          this.StrikeNPC(999, 0.0f, 0);
        }
        if (this.timeLeft > 100)
          this.timeLeft = 100;
        for (int index32 = 0; index32 < 2; ++index32)
        {
          if (this.type == 30)
          {
            int index33 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 2f), this.width, this.height, 27, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, Scale: 2f);
            Main.dust[index33].noGravity = true;
            Main.dust[index33].velocity *= 0.3f;
            Main.dust[index33].velocity.X -= this.velocity.X * 0.2f;
            Main.dust[index33].velocity.Y -= this.velocity.Y * 0.2f;
          }
          else if (this.type == 33)
          {
            int index34 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 2f), this.width, this.height, 29, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, Scale: 2f);
            Main.dust[index34].noGravity = true;
            Main.dust[index34].velocity.X *= 0.3f;
            Main.dust[index34].velocity.Y *= 0.3f;
          }
          else if (this.type == 112)
          {
            int index35 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 2f), this.width, this.height, 18, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 80, Scale: 1.3f);
            Main.dust[index35].velocity *= 0.3f;
            Main.dust[index35].noGravity = true;
          }
          else
          {
            Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 1f, 0.3f, 0.1f);
            int index36 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 2f), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, Scale: 2f);
            Main.dust[index36].noGravity = true;
            Main.dust[index36].velocity.X *= 0.3f;
            Main.dust[index36].velocity.Y *= 0.3f;
          }
        }
        this.rotation += 0.4f * (float) this.direction;
      }
      else if (this.aiStyle == 10)
      {
        float num134 = 1f;
        float num135 = 11f / 1000f;
        this.TargetClosest();
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num136 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
        float num137 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
        float num138 = (float) Math.Sqrt((double) num136 * (double) num136 + (double) num137 * (double) num137);
        float num139 = num138;
        ++this.ai[1];
        if ((double) this.ai[1] > 600.0)
        {
          num135 *= 8f;
          num134 = 4f;
          if ((double) this.ai[1] > 650.0)
            this.ai[1] = 0.0f;
        }
        else if ((double) num139 < 250.0)
        {
          this.ai[0] += 0.9f;
          if ((double) this.ai[0] > 0.0)
            this.velocity.Y += 0.019f;
          else
            this.velocity.Y -= 0.019f;
          if ((double) this.ai[0] < -100.0 || (double) this.ai[0] > 100.0)
            this.velocity.X += 0.019f;
          else
            this.velocity.X -= 0.019f;
          if ((double) this.ai[0] > 200.0)
            this.ai[0] = -200f;
        }
        if ((double) num139 > 350.0)
        {
          num134 = 5f;
          num135 = 0.3f;
        }
        else if ((double) num139 > 300.0)
        {
          num134 = 3f;
          num135 = 0.2f;
        }
        else if ((double) num139 > 250.0)
        {
          num134 = 1.5f;
          num135 = 0.1f;
        }
        float num140 = num134 / num138;
        float num141 = num136 * num140;
        float num142 = num137 * num140;
        if (Main.player[this.target].dead)
        {
          num141 = (float) ((double) this.direction * (double) num134 / 2.0);
          num142 = (float) (-(double) num134 / 2.0);
        }
        if ((double) this.velocity.X < (double) num141)
          this.velocity.X += num135;
        else if ((double) this.velocity.X > (double) num141)
          this.velocity.X -= num135;
        if ((double) this.velocity.Y < (double) num142)
          this.velocity.Y += num135;
        else if ((double) this.velocity.Y > (double) num142)
          this.velocity.Y -= num135;
        if ((double) num141 > 0.0)
        {
          this.spriteDirection = -1;
          this.rotation = (float) Math.Atan2((double) num142, (double) num141);
        }
        if ((double) num141 >= 0.0)
          return;
        this.spriteDirection = 1;
        this.rotation = (float) Math.Atan2((double) num142, (double) num141) + 3.14f;
      }
      else if (this.aiStyle == 11)
      {
        if ((double) this.ai[0] == 0.0 && Main.netMode != 1)
        {
          this.TargetClosest();
          this.ai[0] = 1f;
          if (this.type != 68)
          {
            int index37 = NPC.NewNPC((int) ((double) this.position.X + (double) (this.width / 2)), (int) this.position.Y + this.height / 2, 36, this.whoAmI);
            Main.npc[index37].ai[0] = -1f;
            Main.npc[index37].ai[1] = (float) this.whoAmI;
            Main.npc[index37].target = this.target;
            Main.npc[index37].netUpdate = true;
            int index38 = NPC.NewNPC((int) ((double) this.position.X + (double) (this.width / 2)), (int) this.position.Y + this.height / 2, 36, this.whoAmI);
            Main.npc[index38].ai[0] = 1f;
            Main.npc[index38].ai[1] = (float) this.whoAmI;
            Main.npc[index38].ai[3] = 150f;
            Main.npc[index38].target = this.target;
            Main.npc[index38].netUpdate = true;
          }
        }
        if (this.type == 68 && (double) this.ai[1] != 3.0 && (double) this.ai[1] != 2.0)
        {
          Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
          this.ai[1] = 2f;
        }
        if (Main.player[this.target].dead || (double) Math.Abs(this.position.X - Main.player[this.target].position.X) > 2000.0 || (double) Math.Abs(this.position.Y - Main.player[this.target].position.Y) > 2000.0)
        {
          this.TargetClosest();
          if (Main.player[this.target].dead || (double) Math.Abs(this.position.X - Main.player[this.target].position.X) > 2000.0 || (double) Math.Abs(this.position.Y - Main.player[this.target].position.Y) > 2000.0)
            this.ai[1] = 3f;
        }
        if (Main.dayTime && (double) this.ai[1] != 3.0 && (double) this.ai[1] != 2.0)
        {
          this.ai[1] = 2f;
          Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
        }
        if ((double) this.ai[1] == 0.0)
        {
          this.defense = 10;
          ++this.ai[2];
          if ((double) this.ai[2] >= 800.0)
          {
            this.ai[2] = 0.0f;
            this.ai[1] = 1f;
            this.TargetClosest();
            this.netUpdate = true;
          }
          this.rotation = this.velocity.X / 15f;
          if ((double) this.position.Y > (double) Main.player[this.target].position.Y - 250.0)
          {
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y *= 0.98f;
            this.velocity.Y -= 0.02f;
            if ((double) this.velocity.Y > 2.0)
              this.velocity.Y = 2f;
          }
          else if ((double) this.position.Y < (double) Main.player[this.target].position.Y - 250.0)
          {
            if ((double) this.velocity.Y < 0.0)
              this.velocity.Y *= 0.98f;
            this.velocity.Y += 0.02f;
            if ((double) this.velocity.Y < -2.0)
              this.velocity.Y = -2f;
          }
          if ((double) this.position.X + (double) (this.width / 2) > (double) Main.player[this.target].position.X + (double) (Main.player[this.target].width / 2))
          {
            if ((double) this.velocity.X > 0.0)
              this.velocity.X *= 0.98f;
            this.velocity.X -= 0.05f;
            if ((double) this.velocity.X > 8.0)
              this.velocity.X = 8f;
          }
          if ((double) this.position.X + (double) (this.width / 2) < (double) Main.player[this.target].position.X + (double) (Main.player[this.target].width / 2))
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X *= 0.98f;
            this.velocity.X += 0.05f;
            if ((double) this.velocity.X < -8.0)
              this.velocity.X = -8f;
          }
        }
        else if ((double) this.ai[1] == 1.0)
        {
          this.defense = 0;
          ++this.ai[2];
          if ((double) this.ai[2] == 2.0)
            Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
          if ((double) this.ai[2] >= 400.0)
          {
            this.ai[2] = 0.0f;
            this.ai[1] = 0.0f;
          }
          this.rotation += (float) this.direction * 0.3f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num143 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
          float num144 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
          float num145 = 1.5f / (float) Math.Sqrt((double) num143 * (double) num143 + (double) num144 * (double) num144);
          this.velocity.X = num143 * num145;
          this.velocity.Y = num144 * num145;
        }
        else if ((double) this.ai[1] == 2.0)
        {
          this.damage = 9999;
          this.defense = 9999;
          this.rotation += (float) this.direction * 0.3f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num146 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
          float num147 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
          float num148 = 8f / (float) Math.Sqrt((double) num146 * (double) num146 + (double) num147 * (double) num147);
          this.velocity.X = num146 * num148;
          this.velocity.Y = num147 * num148;
        }
        else if ((double) this.ai[1] == 3.0)
        {
          this.velocity.Y += 0.1f;
          if ((double) this.velocity.Y < 0.0)
            this.velocity.Y *= 0.95f;
          this.velocity.X *= 0.95f;
          if (this.timeLeft > 500)
            this.timeLeft = 500;
        }
        if ((double) this.ai[1] == 2.0 || (double) this.ai[1] == 3.0 || this.type == 68)
          return;
        int index39 = Dust.NewDust(new Vector2((float) ((double) this.position.X + (double) (this.width / 2) - 15.0 - (double) this.velocity.X * 5.0), (float) ((double) this.position.Y + (double) this.height - 2.0)), 30, 10, 5, (float) (-(double) this.velocity.X * 0.200000002980232), 3f, Scale: 2f);
        Main.dust[index39].noGravity = true;
        Main.dust[index39].velocity.X *= 1.3f;
        Main.dust[index39].velocity.X += this.velocity.X * 0.4f;
        Main.dust[index39].velocity.Y += 2f + this.velocity.Y;
        for (int index40 = 0; index40 < 2; ++index40)
        {
          int index41 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 120f), this.width, 60, 5, this.velocity.X, this.velocity.Y, Scale: 2f);
          Main.dust[index41].noGravity = true;
          Main.dust[index41].velocity -= this.velocity;
          Main.dust[index41].velocity.Y += 5f;
        }
      }
      else if (this.aiStyle == 12)
      {
        this.spriteDirection = -(int) this.ai[0];
        if (!Main.npc[(int) this.ai[1]].active || Main.npc[(int) this.ai[1]].aiStyle != 11)
        {
          this.ai[2] += 10f;
          if ((double) this.ai[2] > 50.0 || Main.netMode != 2)
          {
            this.life = -1;
            this.HitEffect();
            this.active = false;
          }
        }
        if ((double) this.ai[2] == 0.0 || (double) this.ai[2] == 3.0)
        {
          if ((double) Main.npc[(int) this.ai[1]].ai[1] == 3.0 && this.timeLeft > 10)
            this.timeLeft = 10;
          if ((double) Main.npc[(int) this.ai[1]].ai[1] != 0.0)
          {
            if ((double) this.position.Y > (double) Main.npc[(int) this.ai[1]].position.Y - 100.0)
            {
              if ((double) this.velocity.Y > 0.0)
                this.velocity.Y *= 0.96f;
              this.velocity.Y -= 0.07f;
              if ((double) this.velocity.Y > 6.0)
                this.velocity.Y = 6f;
            }
            else if ((double) this.position.Y < (double) Main.npc[(int) this.ai[1]].position.Y - 100.0)
            {
              if ((double) this.velocity.Y < 0.0)
                this.velocity.Y *= 0.96f;
              this.velocity.Y += 0.07f;
              if ((double) this.velocity.Y < -6.0)
                this.velocity.Y = -6f;
            }
            if ((double) this.position.X + (double) (this.width / 2) > (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 120.0 * (double) this.ai[0])
            {
              if ((double) this.velocity.X > 0.0)
                this.velocity.X *= 0.96f;
              this.velocity.X -= 0.1f;
              if ((double) this.velocity.X > 8.0)
                this.velocity.X = 8f;
            }
            if ((double) this.position.X + (double) (this.width / 2) < (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 120.0 * (double) this.ai[0])
            {
              if ((double) this.velocity.X < 0.0)
                this.velocity.X *= 0.96f;
              this.velocity.X += 0.1f;
              if ((double) this.velocity.X < -8.0)
                this.velocity.X = -8f;
            }
          }
          else
          {
            ++this.ai[3];
            if ((double) this.ai[3] >= 300.0)
            {
              ++this.ai[2];
              this.ai[3] = 0.0f;
              this.netUpdate = true;
            }
            if ((double) this.position.Y > (double) Main.npc[(int) this.ai[1]].position.Y + 230.0)
            {
              if ((double) this.velocity.Y > 0.0)
                this.velocity.Y *= 0.96f;
              this.velocity.Y -= 0.04f;
              if ((double) this.velocity.Y > 3.0)
                this.velocity.Y = 3f;
            }
            else if ((double) this.position.Y < (double) Main.npc[(int) this.ai[1]].position.Y + 230.0)
            {
              if ((double) this.velocity.Y < 0.0)
                this.velocity.Y *= 0.96f;
              this.velocity.Y += 0.04f;
              if ((double) this.velocity.Y < -3.0)
                this.velocity.Y = -3f;
            }
            if ((double) this.position.X + (double) (this.width / 2) > (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 200.0 * (double) this.ai[0])
            {
              if ((double) this.velocity.X > 0.0)
                this.velocity.X *= 0.96f;
              this.velocity.X -= 0.07f;
              if ((double) this.velocity.X > 8.0)
                this.velocity.X = 8f;
            }
            if ((double) this.position.X + (double) (this.width / 2) < (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 200.0 * (double) this.ai[0])
            {
              if ((double) this.velocity.X < 0.0)
                this.velocity.X *= 0.96f;
              this.velocity.X += 0.07f;
              if ((double) this.velocity.X < -8.0)
                this.velocity.X = -8f;
            }
          }
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num149 = (float) ((double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 200.0 * (double) this.ai[0]) - vector2.X;
          float num150 = Main.npc[(int) this.ai[1]].position.Y + 230f - vector2.Y;
          Math.Sqrt((double) num149 * (double) num149 + (double) num150 * (double) num150);
          this.rotation = (float) Math.Atan2((double) num150, (double) num149) + 1.57f;
        }
        else if ((double) this.ai[2] == 1.0)
        {
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num151 = (float) ((double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 200.0 * (double) this.ai[0]) - vector2.X;
          float num152 = Main.npc[(int) this.ai[1]].position.Y + 230f - vector2.Y;
          float num153 = (float) Math.Sqrt((double) num151 * (double) num151 + (double) num152 * (double) num152);
          this.rotation = (float) Math.Atan2((double) num152, (double) num151) + 1.57f;
          this.velocity.X *= 0.95f;
          this.velocity.Y -= 0.1f;
          if ((double) this.velocity.Y < -8.0)
            this.velocity.Y = -8f;
          if ((double) this.position.Y >= (double) Main.npc[(int) this.ai[1]].position.Y - 200.0)
            return;
          this.TargetClosest();
          this.ai[2] = 2f;
          vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num154 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
          float num155 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
          float num156 = 18f / (float) Math.Sqrt((double) num154 * (double) num154 + (double) num155 * (double) num155);
          this.velocity.X = num154 * num156;
          this.velocity.Y = num155 * num156;
          this.netUpdate = true;
        }
        else if ((double) this.ai[2] == 2.0)
        {
          if ((double) this.position.Y <= (double) Main.player[this.target].position.Y && (double) this.velocity.Y >= 0.0)
            return;
          this.ai[2] = 3f;
        }
        else if ((double) this.ai[2] == 4.0)
        {
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num157 = (float) ((double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 200.0 * (double) this.ai[0]) - vector2.X;
          float num158 = Main.npc[(int) this.ai[1]].position.Y + 230f - vector2.Y;
          float num159 = (float) Math.Sqrt((double) num157 * (double) num157 + (double) num158 * (double) num158);
          this.rotation = (float) Math.Atan2((double) num158, (double) num157) + 1.57f;
          this.velocity.Y *= 0.95f;
          this.velocity.X += (float) (0.100000001490116 * -(double) this.ai[0]);
          if ((double) this.velocity.X < -8.0)
            this.velocity.X = -8f;
          if ((double) this.velocity.X > 8.0)
            this.velocity.X = 8f;
          if ((double) this.position.X + (double) (this.width / 2) >= (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 500.0 && (double) this.position.X + (double) (this.width / 2) <= (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) + 500.0)
            return;
          this.TargetClosest();
          this.ai[2] = 5f;
          vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num160 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
          float num161 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
          float num162 = 17f / (float) Math.Sqrt((double) num160 * (double) num160 + (double) num161 * (double) num161);
          this.velocity.X = num160 * num162;
          this.velocity.Y = num161 * num162;
          this.netUpdate = true;
        }
        else
        {
          if ((double) this.ai[2] != 5.0 || ((double) this.velocity.X <= 0.0 || (double) this.position.X + (double) (this.width / 2) <= (double) Main.player[this.target].position.X + (double) (Main.player[this.target].width / 2)) && ((double) this.velocity.X >= 0.0 || (double) this.position.X + (double) (this.width / 2) >= (double) Main.player[this.target].position.X + (double) (Main.player[this.target].width / 2)))
            return;
          this.ai[2] = 0.0f;
        }
      }
      else if (this.aiStyle == 13)
      {
        if (Main.tile[(int) this.ai[0], (int) this.ai[1]] == null)
          Main.tile[(int) this.ai[0], (int) this.ai[1]] = new Tile();
        if (!Main.tile[(int) this.ai[0], (int) this.ai[1]].active)
        {
          this.life = -1;
          this.HitEffect();
          this.active = false;
        }
        else
        {
          this.TargetClosest();
          float num163 = 0.035f;
          float num164 = 150f;
          if (this.type == 43)
            num164 = 250f;
          if (this.type == 101)
            num164 = 175f;
          ++this.ai[2];
          if ((double) this.ai[2] > 300.0)
          {
            num164 = (float) (int) ((double) num164 * 1.3);
            if ((double) this.ai[2] > 450.0)
              this.ai[2] = 0.0f;
          }
          Vector2 vector2 = new Vector2((float) ((double) this.ai[0] * 16.0 + 8.0), (float) ((double) this.ai[1] * 16.0 + 8.0));
          float num165 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - (float) (this.width / 2) - vector2.X;
          float num166 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - (float) (this.height / 2) - vector2.Y;
          float num167 = (float) Math.Sqrt((double) num165 * (double) num165 + (double) num166 * (double) num166);
          if ((double) num167 > (double) num164)
          {
            float num168 = num164 / num167;
            num165 *= num168;
            num166 *= num168;
          }
          if ((double) this.position.X < (double) this.ai[0] * 16.0 + 8.0 + (double) num165)
          {
            this.velocity.X += num163;
            if ((double) this.velocity.X < 0.0 && (double) num165 > 0.0)
              this.velocity.X += num163 * 1.5f;
          }
          else if ((double) this.position.X > (double) this.ai[0] * 16.0 + 8.0 + (double) num165)
          {
            this.velocity.X -= num163;
            if ((double) this.velocity.X > 0.0 && (double) num165 < 0.0)
              this.velocity.X -= num163 * 1.5f;
          }
          if ((double) this.position.Y < (double) this.ai[1] * 16.0 + 8.0 + (double) num166)
          {
            this.velocity.Y += num163;
            if ((double) this.velocity.Y < 0.0 && (double) num166 > 0.0)
              this.velocity.Y += num163 * 1.5f;
          }
          else if ((double) this.position.Y > (double) this.ai[1] * 16.0 + 8.0 + (double) num166)
          {
            this.velocity.Y -= num163;
            if ((double) this.velocity.Y > 0.0 && (double) num166 < 0.0)
              this.velocity.Y -= num163 * 1.5f;
          }
          if (this.type == 43)
          {
            if ((double) this.velocity.X > 3.0)
              this.velocity.X = 3f;
            if ((double) this.velocity.X < -3.0)
              this.velocity.X = -3f;
            if ((double) this.velocity.Y > 3.0)
              this.velocity.Y = 3f;
            if ((double) this.velocity.Y < -3.0)
              this.velocity.Y = -3f;
          }
          else
          {
            if ((double) this.velocity.X > 2.0)
              this.velocity.X = 2f;
            if ((double) this.velocity.X < -2.0)
              this.velocity.X = -2f;
            if ((double) this.velocity.Y > 2.0)
              this.velocity.Y = 2f;
            if ((double) this.velocity.Y < -2.0)
              this.velocity.Y = -2f;
          }
          if ((double) num165 > 0.0)
          {
            this.spriteDirection = 1;
            this.rotation = (float) Math.Atan2((double) num166, (double) num165);
          }
          if ((double) num165 < 0.0)
          {
            this.spriteDirection = -1;
            this.rotation = (float) Math.Atan2((double) num166, (double) num165) + 3.14f;
          }
          if (this.collideX)
          {
            this.netUpdate = true;
            this.velocity.X = this.oldVelocity.X * -0.7f;
            if ((double) this.velocity.X > 0.0 && (double) this.velocity.X < 2.0)
              this.velocity.X = 2f;
            if ((double) this.velocity.X < 0.0 && (double) this.velocity.X > -2.0)
              this.velocity.X = -2f;
          }
          if (this.collideY)
          {
            this.netUpdate = true;
            this.velocity.Y = this.oldVelocity.Y * -0.7f;
            if ((double) this.velocity.Y > 0.0 && (double) this.velocity.Y < 2.0)
              this.velocity.Y = 2f;
            if ((double) this.velocity.Y < 0.0 && (double) this.velocity.Y > -2.0)
              this.velocity.Y = -2f;
          }
          if (Main.netMode == 1 || this.type != 101 || Main.player[this.target].dead)
            return;
          if (this.justHit)
            this.localAI[0] = 0.0f;
          ++this.localAI[0];
          if ((double) this.localAI[0] < 120.0)
            return;
          if (!Collision.SolidCollision(this.position, this.width, this.height) && Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
          {
            float num169 = 10f;
            vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num170 = Main.player[this.target].position.X + (float) Main.player[this.target].width * 0.5f - vector2.X + (float) Main.rand.Next(-10, 11);
            float num171 = Main.player[this.target].position.Y + (float) Main.player[this.target].height * 0.5f - vector2.Y + (float) Main.rand.Next(-10, 11);
            float num172 = (float) Math.Sqrt((double) num170 * (double) num170 + (double) num171 * (double) num171);
            float num173 = num169 / num172;
            float SpeedX = num170 * num173;
            float SpeedY = num171 * num173;
            int Damage = 22;
            int Type = 96;
            int index = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
            Main.projectile[index].timeLeft = 300;
            this.localAI[0] = 0.0f;
          }
          else
            this.localAI[0] = 100f;
        }
      }
      else if (this.aiStyle == 14)
      {
        if (this.type == 60)
        {
          int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, Scale: 2f);
          Main.dust[index].noGravity = true;
        }
        this.noGravity = true;
        if (this.collideX)
        {
          this.velocity.X = this.oldVelocity.X * -0.5f;
          if (this.direction == -1 && (double) this.velocity.X > 0.0 && (double) this.velocity.X < 2.0)
            this.velocity.X = 2f;
          if (this.direction == 1 && (double) this.velocity.X < 0.0 && (double) this.velocity.X > -2.0)
            this.velocity.X = -2f;
        }
        if (this.collideY)
        {
          this.velocity.Y = this.oldVelocity.Y * -0.5f;
          if ((double) this.velocity.Y > 0.0 && (double) this.velocity.Y < 1.0)
            this.velocity.Y = 1f;
          if ((double) this.velocity.Y < 0.0 && (double) this.velocity.Y > -1.0)
            this.velocity.Y = -1f;
        }
        this.TargetClosest();
        if (this.direction == -1 && (double) this.velocity.X > -4.0)
        {
          this.velocity.X -= 0.1f;
          if ((double) this.velocity.X > 4.0)
            this.velocity.X -= 0.1f;
          else if ((double) this.velocity.X > 0.0)
            this.velocity.X += 0.05f;
          if ((double) this.velocity.X < -4.0)
            this.velocity.X = -4f;
        }
        else if (this.direction == 1 && (double) this.velocity.X < 4.0)
        {
          this.velocity.X += 0.1f;
          if ((double) this.velocity.X < -4.0)
            this.velocity.X += 0.1f;
          else if ((double) this.velocity.X < 0.0)
            this.velocity.X -= 0.05f;
          if ((double) this.velocity.X > 4.0)
            this.velocity.X = 4f;
        }
        if (this.directionY == -1 && (double) this.velocity.Y > -1.5)
        {
          this.velocity.Y -= 0.04f;
          if ((double) this.velocity.Y > 1.5)
            this.velocity.Y -= 0.05f;
          else if ((double) this.velocity.Y > 0.0)
            this.velocity.Y += 0.03f;
          if ((double) this.velocity.Y < -1.5)
            this.velocity.Y = -1.5f;
        }
        else if (this.directionY == 1 && (double) this.velocity.Y < 1.5)
        {
          this.velocity.Y += 0.04f;
          if ((double) this.velocity.Y < -1.5)
            this.velocity.Y += 0.05f;
          else if ((double) this.velocity.Y < 0.0)
            this.velocity.Y -= 0.03f;
          if ((double) this.velocity.Y > 1.5)
            this.velocity.Y = 1.5f;
        }
        if (this.type == 49 || this.type == 51 || this.type == 60 || this.type == 62 || this.type == 66 || this.type == 93 || this.type == 137)
        {
          if (this.wet)
          {
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y *= 0.95f;
            this.velocity.Y -= 0.5f;
            if ((double) this.velocity.Y < -4.0)
              this.velocity.Y = -4f;
            this.TargetClosest();
          }
          if (this.type == 60)
          {
            if (this.direction == -1 && (double) this.velocity.X > -4.0)
            {
              this.velocity.X -= 0.1f;
              if ((double) this.velocity.X > 4.0)
                this.velocity.X -= 0.07f;
              else if ((double) this.velocity.X > 0.0)
                this.velocity.X += 0.03f;
              if ((double) this.velocity.X < -4.0)
                this.velocity.X = -4f;
            }
            else if (this.direction == 1 && (double) this.velocity.X < 4.0)
            {
              this.velocity.X += 0.1f;
              if ((double) this.velocity.X < -4.0)
                this.velocity.X += 0.07f;
              else if ((double) this.velocity.X < 0.0)
                this.velocity.X -= 0.03f;
              if ((double) this.velocity.X > 4.0)
                this.velocity.X = 4f;
            }
            if (this.directionY == -1 && (double) this.velocity.Y > -1.5)
            {
              this.velocity.Y -= 0.04f;
              if ((double) this.velocity.Y > 1.5)
                this.velocity.Y -= 0.03f;
              else if ((double) this.velocity.Y > 0.0)
                this.velocity.Y += 0.02f;
              if ((double) this.velocity.Y < -1.5)
                this.velocity.Y = -1.5f;
            }
            else if (this.directionY == 1 && (double) this.velocity.Y < 1.5)
            {
              this.velocity.Y += 0.04f;
              if ((double) this.velocity.Y < -1.5)
                this.velocity.Y += 0.03f;
              else if ((double) this.velocity.Y < 0.0)
                this.velocity.Y -= 0.02f;
              if ((double) this.velocity.Y > 1.5)
                this.velocity.Y = 1.5f;
            }
          }
          else
          {
            if (this.direction == -1 && (double) this.velocity.X > -4.0)
            {
              this.velocity.X -= 0.1f;
              if ((double) this.velocity.X > 4.0)
                this.velocity.X -= 0.1f;
              else if ((double) this.velocity.X > 0.0)
                this.velocity.X += 0.05f;
              if ((double) this.velocity.X < -4.0)
                this.velocity.X = -4f;
            }
            else if (this.direction == 1 && (double) this.velocity.X < 4.0)
            {
              this.velocity.X += 0.1f;
              if ((double) this.velocity.X < -4.0)
                this.velocity.X += 0.1f;
              else if ((double) this.velocity.X < 0.0)
                this.velocity.X -= 0.05f;
              if ((double) this.velocity.X > 4.0)
                this.velocity.X = 4f;
            }
            if (this.directionY == -1 && (double) this.velocity.Y > -1.5)
            {
              this.velocity.Y -= 0.04f;
              if ((double) this.velocity.Y > 1.5)
                this.velocity.Y -= 0.05f;
              else if ((double) this.velocity.Y > 0.0)
                this.velocity.Y += 0.03f;
              if ((double) this.velocity.Y < -1.5)
                this.velocity.Y = -1.5f;
            }
            else if (this.directionY == 1 && (double) this.velocity.Y < 1.5)
            {
              this.velocity.Y += 0.04f;
              if ((double) this.velocity.Y < -1.5)
                this.velocity.Y += 0.05f;
              else if ((double) this.velocity.Y < 0.0)
                this.velocity.Y -= 0.03f;
              if ((double) this.velocity.Y > 1.5)
                this.velocity.Y = 1.5f;
            }
          }
        }
        ++this.ai[1];
        if ((double) this.ai[1] > 200.0)
        {
          if (!Main.player[this.target].wet && Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
            this.ai[1] = 0.0f;
          float num174 = 0.2f;
          float num175 = 0.1f;
          float num176 = 4f;
          float num177 = 1.5f;
          if (this.type == 48 || this.type == 62 || this.type == 66)
          {
            num174 = 0.12f;
            num175 = 0.07f;
            num176 = 3f;
            num177 = 1.25f;
          }
          if ((double) this.ai[1] > 1000.0)
            this.ai[1] = 0.0f;
          ++this.ai[2];
          if ((double) this.ai[2] > 0.0)
          {
            if ((double) this.velocity.Y < (double) num177)
              this.velocity.Y += num175;
          }
          else if ((double) this.velocity.Y > -(double) num177)
            this.velocity.Y -= num175;
          if ((double) this.ai[2] < -150.0 || (double) this.ai[2] > 150.0)
          {
            if ((double) this.velocity.X < (double) num176)
              this.velocity.X += num174;
          }
          else if ((double) this.velocity.X > -(double) num176)
            this.velocity.X -= num174;
          if ((double) this.ai[2] > 300.0)
            this.ai[2] = -300f;
        }
        if (Main.netMode == 1)
          return;
        if (this.type == 48)
        {
          ++this.ai[0];
          if ((double) this.ai[0] == 30.0 || (double) this.ai[0] == 60.0 || (double) this.ai[0] == 90.0)
          {
            if (Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
            {
              float num178 = 6f;
              Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
              float num179 = Main.player[this.target].position.X + (float) Main.player[this.target].width * 0.5f - vector2.X + (float) Main.rand.Next(-100, 101);
              float num180 = Main.player[this.target].position.Y + (float) Main.player[this.target].height * 0.5f - vector2.Y + (float) Main.rand.Next(-100, 101);
              float num181 = (float) Math.Sqrt((double) num179 * (double) num179 + (double) num180 * (double) num180);
              float num182 = num178 / num181;
              float SpeedX = num179 * num182;
              float SpeedY = num180 * num182;
              int Damage = 15;
              int Type = 38;
              int index = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
              Main.projectile[index].timeLeft = 300;
            }
          }
          else if ((double) this.ai[0] >= (double) (400 + Main.rand.Next(400)))
            this.ai[0] = 0.0f;
        }
        if (this.type != 62 && this.type != 66)
          return;
        ++this.ai[0];
        if ((double) this.ai[0] == 20.0 || (double) this.ai[0] == 40.0 || (double) this.ai[0] == 60.0 || (double) this.ai[0] == 80.0)
        {
          if (!Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
            return;
          float num183 = 0.2f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num184 = Main.player[this.target].position.X + (float) Main.player[this.target].width * 0.5f - vector2.X + (float) Main.rand.Next(-100, 101);
          float num185 = Main.player[this.target].position.Y + (float) Main.player[this.target].height * 0.5f - vector2.Y + (float) Main.rand.Next(-100, 101);
          float num186 = (float) Math.Sqrt((double) num184 * (double) num184 + (double) num185 * (double) num185);
          float num187 = num183 / num186;
          float SpeedX = num184 * num187;
          float SpeedY = num185 * num187;
          int Damage = 21;
          int Type = 44;
          int index = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
          Main.projectile[index].timeLeft = 300;
        }
        else
        {
          if ((double) this.ai[0] < (double) (300 + Main.rand.Next(300)))
            return;
          this.ai[0] = 0.0f;
        }
      }
      else if (this.aiStyle == 15)
      {
        this.aiAction = 0;
        if ((double) this.ai[3] == 0.0 && this.life > 0)
          this.ai[3] = (float) this.lifeMax;
        if ((double) this.ai[2] == 0.0)
        {
          this.ai[0] = -100f;
          this.ai[2] = 1f;
          this.TargetClosest();
        }
        if ((double) this.velocity.Y == 0.0)
        {
          this.velocity.X *= 0.8f;
          if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
            this.velocity.X = 0.0f;
          this.ai[0] += 2f;
          if ((double) this.life < (double) this.lifeMax * 0.8)
            ++this.ai[0];
          if ((double) this.life < (double) this.lifeMax * 0.6)
            ++this.ai[0];
          if ((double) this.life < (double) this.lifeMax * 0.4)
            this.ai[0] += 2f;
          if ((double) this.life < (double) this.lifeMax * 0.2)
            this.ai[0] += 3f;
          if ((double) this.life < (double) this.lifeMax * 0.1)
            this.ai[0] += 4f;
          if ((double) this.ai[0] >= 0.0)
          {
            this.netUpdate = true;
            this.TargetClosest();
            if ((double) this.ai[1] == 3.0)
            {
              this.velocity.Y = -13f;
              this.velocity.X += 3.5f * (float) this.direction;
              this.ai[0] = -200f;
              this.ai[1] = 0.0f;
            }
            else if ((double) this.ai[1] == 2.0)
            {
              this.velocity.Y = -6f;
              this.velocity.X += 4.5f * (float) this.direction;
              this.ai[0] = -120f;
              ++this.ai[1];
            }
            else
            {
              this.velocity.Y = -8f;
              this.velocity.X += 4f * (float) this.direction;
              this.ai[0] = -120f;
              ++this.ai[1];
            }
          }
          else if ((double) this.ai[0] >= -30.0)
            this.aiAction = 1;
        }
        else if (this.target < (int) byte.MaxValue && (this.direction == 1 && (double) this.velocity.X < 3.0 || this.direction == -1 && (double) this.velocity.X > -3.0))
        {
          if (this.direction == -1 && (double) this.velocity.X < 0.1 || this.direction == 1 && (double) this.velocity.X > -0.1)
            this.velocity.X += 0.2f * (float) this.direction;
          else
            this.velocity.X *= 0.93f;
        }
        int index42 = Dust.NewDust(this.position, this.width, this.height, 4, this.velocity.X, this.velocity.Y, (int) byte.MaxValue, new Color(0, 80, (int) byte.MaxValue, 80), this.scale * 1.2f);
        Main.dust[index42].noGravity = true;
        Main.dust[index42].velocity *= 0.5f;
        if (this.life <= 0)
          return;
        float num188 = (float) ((double) ((float) this.life / (float) this.lifeMax) * 0.5 + 0.75);
        if ((double) num188 != (double) this.scale)
        {
          this.position.X += (float) (this.width / 2);
          this.position.Y += (float) this.height;
          this.scale = num188;
          this.width = (int) (98.0 * (double) this.scale);
          this.height = (int) (92.0 * (double) this.scale);
          this.position.X -= (float) (this.width / 2);
          this.position.Y -= (float) this.height;
        }
        if (Main.netMode == 1 || (double) (this.life + (int) ((double) this.lifeMax * 0.05)) >= (double) this.ai[3])
          return;
        this.ai[3] = (float) this.life;
        int num189 = Main.rand.Next(1, 4);
        for (int index43 = 0; index43 < num189; ++index43)
        {
          int number = NPC.NewNPC((int) ((double) this.position.X + (double) Main.rand.Next(this.width - 32)), (int) ((double) this.position.Y + (double) Main.rand.Next(this.height - 32)), 1);
          Main.npc[number].SetDefaults(1);
          Main.npc[number].velocity.X = (float) Main.rand.Next(-15, 16) * 0.1f;
          Main.npc[number].velocity.Y = (float) Main.rand.Next(-30, 1) * 0.1f;
          Main.npc[number].ai[1] = (float) Main.rand.Next(3);
          if (Main.netMode == 2 && number < 200)
            NetMessage.SendData(23, number: number);
        }
      }
      else if (this.aiStyle == 16)
      {
        if (this.direction == 0)
          this.TargetClosest();
        if (this.wet)
        {
          bool flag = false;
          if (this.type != 55)
          {
            this.TargetClosest(false);
            if (Main.player[this.target].wet && !Main.player[this.target].dead)
              flag = true;
          }
          if (!flag)
          {
            if (this.collideX)
            {
              this.velocity.X *= -1f;
              this.direction *= -1;
              this.netUpdate = true;
            }
            if (this.collideY)
            {
              this.netUpdate = true;
              if ((double) this.velocity.Y > 0.0)
              {
                this.velocity.Y = Math.Abs(this.velocity.Y) * -1f;
                this.directionY = -1;
                this.ai[0] = -1f;
              }
              else if ((double) this.velocity.Y < 0.0)
              {
                this.velocity.Y = Math.Abs(this.velocity.Y);
                this.directionY = 1;
                this.ai[0] = 1f;
              }
            }
          }
          if (this.type == 102)
            Lighting.addLight((int) ((double) this.position.X + (double) (this.width / 2) + (double) (this.direction * (this.width + 8))) / 16, (int) ((double) this.position.Y + 2.0) / 16, 0.07f, 0.04f, 0.025f);
          if (flag)
          {
            this.TargetClosest();
            if (this.type == 65 || this.type == 102)
            {
              this.velocity.X += (float) this.direction * 0.15f;
              this.velocity.Y += (float) this.directionY * 0.15f;
              if ((double) this.velocity.X > 5.0)
                this.velocity.X = 5f;
              if ((double) this.velocity.X < -5.0)
                this.velocity.X = -5f;
              if ((double) this.velocity.Y > 3.0)
                this.velocity.Y = 3f;
              if ((double) this.velocity.Y < -3.0)
                this.velocity.Y = -3f;
            }
            else
            {
              this.velocity.X += (float) this.direction * 0.1f;
              this.velocity.Y += (float) this.directionY * 0.1f;
              if ((double) this.velocity.X > 3.0)
                this.velocity.X = 3f;
              if ((double) this.velocity.X < -3.0)
                this.velocity.X = -3f;
              if ((double) this.velocity.Y > 2.0)
                this.velocity.Y = 2f;
              if ((double) this.velocity.Y < -2.0)
                this.velocity.Y = -2f;
            }
          }
          else
          {
            this.velocity.X += (float) this.direction * 0.1f;
            if ((double) this.velocity.X < -1.0 || (double) this.velocity.X > 1.0)
              this.velocity.X *= 0.95f;
            if ((double) this.ai[0] == -1.0)
            {
              this.velocity.Y -= 0.01f;
              if ((double) this.velocity.Y < -0.3)
                this.ai[0] = 1f;
            }
            else
            {
              this.velocity.Y += 0.01f;
              if ((double) this.velocity.Y > 0.3)
                this.ai[0] = -1f;
            }
            int index = (int) ((double) this.position.X + (double) (this.width / 2)) / 16;
            int num = (int) ((double) this.position.Y + (double) (this.height / 2)) / 16;
            if (Main.tile[index, num - 1] == null)
              Main.tile[index, num - 1] = new Tile();
            if (Main.tile[index, num + 1] == null)
              Main.tile[index, num + 1] = new Tile();
            if (Main.tile[index, num + 2] == null)
              Main.tile[index, num + 2] = new Tile();
            if (Main.tile[index, num - 1].liquid > (byte) 128)
            {
              if (Main.tile[index, num + 1].active)
                this.ai[0] = -1f;
              else if (Main.tile[index, num + 2].active)
                this.ai[0] = -1f;
            }
            if ((double) this.velocity.Y > 0.4 || (double) this.velocity.Y < -0.4)
              this.velocity.Y *= 0.95f;
          }
        }
        else
        {
          if ((double) this.velocity.Y == 0.0)
          {
            if (this.type == 65)
            {
              this.velocity.X *= 0.94f;
              if ((double) this.velocity.X > -0.2 && (double) this.velocity.X < 0.2)
                this.velocity.X = 0.0f;
            }
            else if (Main.netMode != 1)
            {
              this.velocity.Y = (float) Main.rand.Next(-50, -20) * 0.1f;
              this.velocity.X = (float) Main.rand.Next(-20, 20) * 0.1f;
              this.netUpdate = true;
            }
          }
          this.velocity.Y += 0.3f;
          if ((double) this.velocity.Y > 10.0)
            this.velocity.Y = 10f;
          this.ai[0] = 1f;
        }
        this.rotation = (float) ((double) this.velocity.Y * (double) this.direction * 0.100000001490116);
        if ((double) this.rotation < -0.2)
          this.rotation = -0.2f;
        if ((double) this.rotation <= 0.2)
          return;
        this.rotation = 0.2f;
      }
      else if (this.aiStyle == 17)
      {
        this.noGravity = true;
        if ((double) this.ai[0] == 0.0)
        {
          this.noGravity = false;
          this.TargetClosest();
          if (Main.netMode != 1)
          {
            if ((double) this.velocity.X != 0.0 || (double) this.velocity.Y < 0.0 || (double) this.velocity.Y > 0.3)
            {
              this.ai[0] = 1f;
              this.netUpdate = true;
            }
            else if (new Rectangle((int) this.position.X - 100, (int) this.position.Y - 100, this.width + 200, this.height + 200).Intersects(new Rectangle((int) Main.player[this.target].position.X, (int) Main.player[this.target].position.Y, Main.player[this.target].width, Main.player[this.target].height)) || this.life < this.lifeMax)
            {
              this.ai[0] = 1f;
              this.velocity.Y -= 6f;
              this.netUpdate = true;
            }
          }
        }
        else if (!Main.player[this.target].dead)
        {
          if (this.collideX)
          {
            this.velocity.X = this.oldVelocity.X * -0.5f;
            if (this.direction == -1 && (double) this.velocity.X > 0.0 && (double) this.velocity.X < 2.0)
              this.velocity.X = 2f;
            if (this.direction == 1 && (double) this.velocity.X < 0.0 && (double) this.velocity.X > -2.0)
              this.velocity.X = -2f;
          }
          if (this.collideY)
          {
            this.velocity.Y = this.oldVelocity.Y * -0.5f;
            if ((double) this.velocity.Y > 0.0 && (double) this.velocity.Y < 1.0)
              this.velocity.Y = 1f;
            if ((double) this.velocity.Y < 0.0 && (double) this.velocity.Y > -1.0)
              this.velocity.Y = -1f;
          }
          this.TargetClosest();
          if (this.direction == -1 && (double) this.velocity.X > -3.0)
          {
            this.velocity.X -= 0.1f;
            if ((double) this.velocity.X > 3.0)
              this.velocity.X -= 0.1f;
            else if ((double) this.velocity.X > 0.0)
              this.velocity.X -= 0.05f;
            if ((double) this.velocity.X < -3.0)
              this.velocity.X = -3f;
          }
          else if (this.direction == 1 && (double) this.velocity.X < 3.0)
          {
            this.velocity.X += 0.1f;
            if ((double) this.velocity.X < -3.0)
              this.velocity.X += 0.1f;
            else if ((double) this.velocity.X < 0.0)
              this.velocity.X += 0.05f;
            if ((double) this.velocity.X > 3.0)
              this.velocity.X = 3f;
          }
          float num190 = Math.Abs((float) ((double) this.position.X + (double) (this.width / 2) - ((double) Main.player[this.target].position.X + (double) (Main.player[this.target].width / 2))));
          float num191 = Main.player[this.target].position.Y - (float) (this.height / 2);
          if ((double) num190 > 50.0)
            num191 -= 100f;
          if ((double) this.position.Y < (double) num191)
          {
            this.velocity.Y += 0.05f;
            if ((double) this.velocity.Y < 0.0)
              this.velocity.Y += 0.01f;
          }
          else
          {
            this.velocity.Y -= 0.05f;
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y -= 0.01f;
          }
          if ((double) this.velocity.Y < -3.0)
            this.velocity.Y = -3f;
          if ((double) this.velocity.Y > 3.0)
            this.velocity.Y = 3f;
        }
        if (!this.wet)
          return;
        if ((double) this.velocity.Y > 0.0)
          this.velocity.Y *= 0.95f;
        this.velocity.Y -= 0.5f;
        if ((double) this.velocity.Y < -4.0)
          this.velocity.Y = -4f;
        this.TargetClosest();
      }
      else if (this.aiStyle == 18)
      {
        if (this.type == 63)
          Lighting.addLight((int) ((double) this.position.X + (double) (this.height / 2)) / 16, (int) ((double) this.position.Y + (double) (this.height / 2)) / 16, 0.05f, 0.15f, 0.4f);
        else if (this.type == 103)
          Lighting.addLight((int) ((double) this.position.X + (double) (this.height / 2)) / 16, (int) ((double) this.position.Y + (double) (this.height / 2)) / 16, 0.05f, 0.45f, 0.1f);
        else
          Lighting.addLight((int) ((double) this.position.X + (double) (this.height / 2)) / 16, (int) ((double) this.position.Y + (double) (this.height / 2)) / 16, 0.35f, 0.05f, 0.2f);
        if (this.direction == 0)
          this.TargetClosest();
        if (this.wet)
        {
          if (this.collideX)
          {
            this.velocity.X *= -1f;
            this.direction *= -1;
          }
          if (this.collideY)
          {
            if ((double) this.velocity.Y > 0.0)
            {
              this.velocity.Y = Math.Abs(this.velocity.Y) * -1f;
              this.directionY = -1;
              this.ai[0] = -1f;
            }
            else if ((double) this.velocity.Y < 0.0)
            {
              this.velocity.Y = Math.Abs(this.velocity.Y);
              this.directionY = 1;
              this.ai[0] = 1f;
            }
          }
          bool flag = false;
          if (!this.friendly)
          {
            this.TargetClosest(false);
            if (Main.player[this.target].wet && !Main.player[this.target].dead)
              flag = true;
          }
          if (flag)
          {
            this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 1.57f;
            this.velocity *= 0.98f;
            float num192 = 0.2f;
            if (this.type == 103)
            {
              this.velocity *= 0.98f;
              num192 = 0.6f;
            }
            if ((double) this.velocity.X <= -(double) num192 || (double) this.velocity.X >= (double) num192 || (double) this.velocity.Y <= -(double) num192 || (double) this.velocity.Y >= (double) num192)
              return;
            this.TargetClosest();
            float num193 = 7f;
            if (this.type == 103)
              num193 = 9f;
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num194 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
            float num195 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
            float num196 = (float) Math.Sqrt((double) num194 * (double) num194 + (double) num195 * (double) num195);
            float num197 = num193 / num196;
            float num198 = num194 * num197;
            float num199 = num195 * num197;
            this.velocity.X = num198;
            this.velocity.Y = num199;
          }
          else
          {
            this.velocity.X += (float) this.direction * 0.02f;
            this.rotation = this.velocity.X * 0.4f;
            if ((double) this.velocity.X < -1.0 || (double) this.velocity.X > 1.0)
              this.velocity.X *= 0.95f;
            if ((double) this.ai[0] == -1.0)
            {
              this.velocity.Y -= 0.01f;
              if ((double) this.velocity.Y < -1.0)
                this.ai[0] = 1f;
            }
            else
            {
              this.velocity.Y += 0.01f;
              if ((double) this.velocity.Y > 1.0)
                this.ai[0] = -1f;
            }
            int index = (int) ((double) this.position.X + (double) (this.width / 2)) / 16;
            int num = (int) ((double) this.position.Y + (double) (this.height / 2)) / 16;
            if (Main.tile[index, num - 1] == null)
              Main.tile[index, num - 1] = new Tile();
            if (Main.tile[index, num + 1] == null)
              Main.tile[index, num + 1] = new Tile();
            if (Main.tile[index, num + 2] == null)
              Main.tile[index, num + 2] = new Tile();
            if (Main.tile[index, num - 1].liquid > (byte) 128)
            {
              if (Main.tile[index, num + 1].active)
                this.ai[0] = -1f;
              else if (Main.tile[index, num + 2].active)
                this.ai[0] = -1f;
            }
            else
              this.ai[0] = 1f;
            if ((double) this.velocity.Y <= 1.2 && (double) this.velocity.Y >= -1.2)
              return;
            this.velocity.Y *= 0.99f;
          }
        }
        else
        {
          this.rotation += this.velocity.X * 0.1f;
          if ((double) this.velocity.Y == 0.0)
          {
            this.velocity.X *= 0.98f;
            if ((double) this.velocity.X > -0.01 && (double) this.velocity.X < 0.01)
              this.velocity.X = 0.0f;
          }
          this.velocity.Y += 0.2f;
          if ((double) this.velocity.Y > 10.0)
            this.velocity.Y = 10f;
          this.ai[0] = 1f;
        }
      }
      else if (this.aiStyle == 19)
      {
        this.TargetClosest();
        float num200 = 12f;
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num201 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
        float num202 = Main.player[this.target].position.Y - vector2.Y;
        float num203 = (float) Math.Sqrt((double) num201 * (double) num201 + (double) num202 * (double) num202);
        float num204 = num200 / num203;
        float SpeedX = num201 * num204;
        float SpeedY = num202 * num204;
        bool flag16 = false;
        if (this.directionY < 0)
        {
          this.rotation = (float) (Math.Atan2((double) SpeedY, (double) SpeedX) + 1.57);
          flag16 = (double) this.rotation >= -1.2 && (double) this.rotation <= 1.2;
          if ((double) this.rotation < -0.8)
            this.rotation = -0.8f;
          else if ((double) this.rotation > 0.8)
            this.rotation = 0.8f;
          if ((double) this.velocity.X != 0.0)
          {
            this.velocity.X *= 0.9f;
            if ((double) this.velocity.X > -0.1 || (double) this.velocity.X < 0.1)
            {
              this.netUpdate = true;
              this.velocity.X = 0.0f;
            }
          }
        }
        if ((double) this.ai[0] > 0.0)
        {
          if ((double) this.ai[0] == 200.0)
            Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 5);
          --this.ai[0];
        }
        if (Main.netMode != 1)
        {
          if (flag16)
          {
            if ((double) this.ai[0] == 0.0)
            {
              if (Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
              {
                this.ai[0] = 200f;
                int Damage = 10;
                int Type = 31;
                int number = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
                Main.projectile[number].ai[0] = 2f;
                Main.projectile[number].timeLeft = 300;
                Main.projectile[number].friendly = false;
                NetMessage.SendData(27, number: number);
                this.netUpdate = true;
              }
            }
          }
        }
        try
        {
          int index44 = (int) this.position.X / 16;
          int index45 = (int) ((double) this.position.X + (double) (this.width / 2)) / 16;
          int index46 = (int) ((double) this.position.X + (double) this.width) / 16;
          int index47 = (int) ((double) this.position.Y + (double) this.height) / 16;
          bool flag17 = false;
          if (Main.tile[index44, index47] == null)
            Main.tile[index44, index47] = new Tile();
          if (Main.tile[index45, index47] == null)
            Main.tile[index44, index47] = new Tile();
          if (Main.tile[index46, index47] == null)
            Main.tile[index44, index47] = new Tile();
          if (Main.tile[index44, index47].active && Main.tileSolid[(int) Main.tile[index44, index47].type] || Main.tile[index45, index47].active && Main.tileSolid[(int) Main.tile[index45, index47].type] || Main.tile[index46, index47].active && Main.tileSolid[(int) Main.tile[index46, index47].type])
            flag17 = true;
          if (flag17)
          {
            this.noGravity = true;
            this.noTileCollide = true;
            this.velocity.Y = -0.2f;
          }
          else
          {
            this.noGravity = false;
            this.noTileCollide = false;
            if (Main.rand.Next(2) != 0)
              return;
            int index48 = Dust.NewDust(new Vector2(this.position.X - 4f, (float) ((double) this.position.Y + (double) this.height - 8.0)), this.width + 8, 24, 32, SpeedY: (this.velocity.Y / 2f));
            Main.dust[index48].velocity.X *= 0.4f;
            Main.dust[index48].velocity.Y *= -1f;
            if (Main.rand.Next(2) != 0)
              return;
            Main.dust[index48].noGravity = true;
            Main.dust[index48].scale += 0.2f;
          }
        }
        catch
        {
        }
      }
      else if (this.aiStyle == 20)
      {
        if ((double) this.ai[0] == 0.0)
        {
          if (Main.netMode != 1)
          {
            this.TargetClosest();
            this.direction *= -1;
            this.directionY *= -1;
            this.position.Y += (float) (this.height / 2 + 8);
            this.ai[1] = this.position.X + (float) (this.width / 2);
            this.ai[2] = this.position.Y + (float) (this.height / 2);
            if (this.direction == 0)
              this.direction = 1;
            if (this.directionY == 0)
              this.directionY = 1;
            this.ai[3] = (float) (1.0 + (double) Main.rand.Next(15) * 0.100000001490116);
            this.velocity.Y = (float) (this.directionY * 6) * this.ai[3];
            ++this.ai[0];
            this.netUpdate = true;
          }
          else
          {
            this.ai[1] = this.position.X + (float) (this.width / 2);
            this.ai[2] = this.position.Y + (float) (this.height / 2);
          }
        }
        else
        {
          float num205 = 6f * this.ai[3];
          float num206 = 0.2f * this.ai[3];
          float num207 = (float) ((double) num205 / (double) num206 / 2.0);
          if ((double) this.ai[0] >= 1.0 && (double) this.ai[0] < (double) (int) num207)
          {
            this.velocity.Y = (float) this.directionY * num205;
            ++this.ai[0];
          }
          else if ((double) this.ai[0] >= (double) (int) num207)
          {
            this.netUpdate = true;
            this.velocity.Y = 0.0f;
            this.directionY *= -1;
            this.velocity.X = num205 * (float) this.direction;
            this.ai[0] = -1f;
          }
          else
          {
            if (this.directionY > 0)
            {
              if ((double) this.velocity.Y >= (double) num205)
              {
                this.netUpdate = true;
                this.directionY *= -1;
                this.velocity.Y = num205;
              }
            }
            else if (this.directionY < 0 && (double) this.velocity.Y <= -(double) num205)
            {
              this.directionY *= -1;
              this.velocity.Y = -num205;
            }
            if (this.direction > 0)
            {
              if ((double) this.velocity.X >= (double) num205)
              {
                this.direction *= -1;
                this.velocity.X = num205;
              }
            }
            else if (this.direction < 0 && (double) this.velocity.X <= -(double) num205)
            {
              this.direction *= -1;
              this.velocity.X = -num205;
            }
            this.velocity.X += num206 * (float) this.direction;
            this.velocity.Y += num206 * (float) this.directionY;
          }
        }
      }
      else if (this.aiStyle == 21)
      {
        if ((double) this.ai[0] == 0.0)
        {
          this.TargetClosest();
          this.directionY = 1;
          this.ai[0] = 1f;
        }
        int num = 6;
        if ((double) this.ai[1] == 0.0)
        {
          this.rotation += (float) (this.direction * this.directionY) * 0.13f;
          if (this.collideY)
            this.ai[0] = 2f;
          if (!this.collideY && (double) this.ai[0] == 2.0)
          {
            this.direction = -this.direction;
            this.ai[1] = 1f;
            this.ai[0] = 1f;
          }
          if (this.collideX)
          {
            this.directionY = -this.directionY;
            this.ai[1] = 1f;
          }
        }
        else
        {
          this.rotation -= (float) (this.direction * this.directionY) * 0.13f;
          if (this.collideX)
            this.ai[0] = 2f;
          if (!this.collideX && (double) this.ai[0] == 2.0)
          {
            this.directionY = -this.directionY;
            this.ai[1] = 0.0f;
            this.ai[0] = 1f;
          }
          if (this.collideY)
          {
            this.direction = -this.direction;
            this.ai[1] = 0.0f;
          }
        }
        this.velocity.X = (float) (num * this.direction);
        this.velocity.Y = (float) (num * this.directionY);
        Lighting.addLight((int) ((double) this.position.X + (double) (this.width / 2)) / 16, (int) ((double) this.position.Y + (double) (this.height / 2)) / 16, 0.9f, 0.3f + (float) (270 - (int) Main.mouseTextColor) / 400f, 0.2f);
      }
      else if (this.aiStyle == 22)
      {
        bool flag18 = false;
        if (this.justHit)
          this.ai[2] = 0.0f;
        if ((double) this.ai[2] >= 0.0)
        {
          int num208 = 16;
          bool flag19 = false;
          bool flag20 = false;
          if ((double) this.position.X > (double) this.ai[0] - (double) num208 && (double) this.position.X < (double) this.ai[0] + (double) num208)
            flag19 = true;
          else if ((double) this.velocity.X < 0.0 && this.direction > 0 || (double) this.velocity.X > 0.0 && this.direction < 0)
            flag19 = true;
          int num209 = num208 + 24;
          if ((double) this.position.Y > (double) this.ai[1] - (double) num209 && (double) this.position.Y < (double) this.ai[1] + (double) num209)
            flag20 = true;
          if (flag19 && flag20)
          {
            ++this.ai[2];
            if ((double) this.ai[2] >= 30.0 && num209 == 16)
              flag18 = true;
            if ((double) this.ai[2] >= 60.0)
            {
              this.ai[2] = -200f;
              this.direction *= -1;
              this.velocity.X *= -1f;
              this.collideX = false;
            }
          }
          else
          {
            this.ai[0] = this.position.X;
            this.ai[1] = this.position.Y;
            this.ai[2] = 0.0f;
          }
          this.TargetClosest();
        }
        else
        {
          ++this.ai[2];
          this.direction = (double) Main.player[this.target].position.X + (double) (Main.player[this.target].width / 2) <= (double) this.position.X + (double) (this.width / 2) ? 1 : -1;
        }
        int index49 = (int) (((double) this.position.X + (double) (this.width / 2)) / 16.0) + this.direction * 2;
        int num210 = (int) (((double) this.position.Y + (double) this.height) / 16.0);
        bool flag21 = true;
        bool flag22 = false;
        int num211 = 3;
        if (this.type == 122)
        {
          if (this.justHit)
          {
            this.ai[3] = 0.0f;
            this.localAI[1] = 0.0f;
          }
          float num212 = 7f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num213 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
          float num214 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
          float num215 = (float) Math.Sqrt((double) num213 * (double) num213 + (double) num214 * (double) num214);
          float num216 = num212 / num215;
          float SpeedX = num213 * num216;
          float SpeedY = num214 * num216;
          if (Main.netMode != 1 && (double) this.ai[3] == 32.0)
          {
            int Damage = 25;
            int Type = 84;
            Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
          }
          num211 = 8;
          if ((double) this.ai[3] > 0.0)
          {
            ++this.ai[3];
            if ((double) this.ai[3] >= 64.0)
              this.ai[3] = 0.0f;
          }
          if (Main.netMode != 1 && (double) this.ai[3] == 0.0)
          {
            ++this.localAI[1];
            if ((double) this.localAI[1] > 120.0 && Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
            {
              this.localAI[1] = 0.0f;
              this.ai[3] = 1f;
              this.netUpdate = true;
            }
          }
        }
        else if (this.type == 75)
        {
          num211 = 4;
          if (Main.rand.Next(6) == 0)
          {
            int index50 = Dust.NewDust(this.position, this.width, this.height, 55, Alpha: 200, newColor: this.color);
            Main.dust[index50].velocity *= 0.3f;
          }
          if (Main.rand.Next(40) == 0)
            Main.PlaySound(27, (int) this.position.X, (int) this.position.Y);
        }
        for (int index51 = num210; index51 < num210 + num211; ++index51)
        {
          if (Main.tile[index49, index51] == null)
            Main.tile[index49, index51] = new Tile();
          if (Main.tile[index49, index51].active && Main.tileSolid[(int) Main.tile[index49, index51].type] || Main.tile[index49, index51].liquid > (byte) 0)
          {
            if (index51 <= num210 + 1)
              flag22 = true;
            flag21 = false;
            break;
          }
        }
        if (flag18)
        {
          flag22 = false;
          flag21 = true;
        }
        if (flag21)
        {
          if (this.type == 75)
          {
            this.velocity.Y += 0.2f;
            if ((double) this.velocity.Y > 2.0)
              this.velocity.Y = 2f;
          }
          else
          {
            this.velocity.Y += 0.1f;
            if ((double) this.velocity.Y > 3.0)
              this.velocity.Y = 3f;
          }
        }
        else
        {
          if (this.type == 75)
          {
            if (this.directionY < 0 && (double) this.velocity.Y > 0.0 || flag22)
              this.velocity.Y -= 0.2f;
          }
          else if (this.directionY < 0 && (double) this.velocity.Y > 0.0)
            this.velocity.Y -= 0.1f;
          if ((double) this.velocity.Y < -4.0)
            this.velocity.Y = -4f;
        }
        if (this.type == 75 && this.wet)
        {
          this.velocity.Y -= 0.2f;
          if ((double) this.velocity.Y < -2.0)
            this.velocity.Y = -2f;
        }
        if (this.collideX)
        {
          this.velocity.X = this.oldVelocity.X * -0.4f;
          if (this.direction == -1 && (double) this.velocity.X > 0.0 && (double) this.velocity.X < 1.0)
            this.velocity.X = 1f;
          if (this.direction == 1 && (double) this.velocity.X < 0.0 && (double) this.velocity.X > -1.0)
            this.velocity.X = -1f;
        }
        if (this.collideY)
        {
          this.velocity.Y = this.oldVelocity.Y * -0.25f;
          if ((double) this.velocity.Y > 0.0 && (double) this.velocity.Y < 1.0)
            this.velocity.Y = 1f;
          if ((double) this.velocity.Y < 0.0 && (double) this.velocity.Y > -1.0)
            this.velocity.Y = -1f;
        }
        float num217 = 2f;
        if (this.type == 75)
          num217 = 3f;
        if (this.direction == -1 && (double) this.velocity.X > -(double) num217)
        {
          this.velocity.X -= 0.1f;
          if ((double) this.velocity.X > (double) num217)
            this.velocity.X -= 0.1f;
          else if ((double) this.velocity.X > 0.0)
            this.velocity.X += 0.05f;
          if ((double) this.velocity.X < -(double) num217)
            this.velocity.X = -num217;
        }
        else if (this.direction == 1 && (double) this.velocity.X < (double) num217)
        {
          this.velocity.X += 0.1f;
          if ((double) this.velocity.X < -(double) num217)
            this.velocity.X += 0.1f;
          else if ((double) this.velocity.X < 0.0)
            this.velocity.X -= 0.05f;
          if ((double) this.velocity.X > (double) num217)
            this.velocity.X = num217;
        }
        if (this.directionY == -1 && (double) this.velocity.Y > -1.5)
        {
          this.velocity.Y -= 0.04f;
          if ((double) this.velocity.Y > 1.5)
            this.velocity.Y -= 0.05f;
          else if ((double) this.velocity.Y > 0.0)
            this.velocity.Y += 0.03f;
          if ((double) this.velocity.Y < -1.5)
            this.velocity.Y = -1.5f;
        }
        else if (this.directionY == 1 && (double) this.velocity.Y < 1.5)
        {
          this.velocity.Y += 0.04f;
          if ((double) this.velocity.Y < -1.5)
            this.velocity.Y += 0.05f;
          else if ((double) this.velocity.Y < 0.0)
            this.velocity.Y -= 0.03f;
          if ((double) this.velocity.Y > 1.5)
            this.velocity.Y = 1.5f;
        }
        if (this.type != 122)
          return;
        Lighting.addLight((int) this.position.X / 16, (int) this.position.Y / 16, 0.4f, 0.0f, 0.25f);
      }
      else if (this.aiStyle == 23)
      {
        this.noGravity = true;
        this.noTileCollide = true;
        if (this.type == 83)
          Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.2f, 0.05f, 0.3f);
        else
          Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.05f, 0.2f, 0.3f);
        if (this.target < 0 || this.target == (int) byte.MaxValue || Main.player[this.target].dead)
          this.TargetClosest();
        if ((double) this.ai[0] == 0.0)
        {
          float num218 = 9f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num219 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
          float num220 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
          float num221 = (float) Math.Sqrt((double) num219 * (double) num219 + (double) num220 * (double) num220);
          float num222 = num218 / num221;
          float num223 = num219 * num222;
          float num224 = num220 * num222;
          this.velocity.X = num223;
          this.velocity.Y = num224;
          this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 0.785f;
          this.ai[0] = 1f;
          this.ai[1] = 0.0f;
        }
        else if ((double) this.ai[0] == 1.0)
        {
          if (this.justHit)
          {
            this.ai[0] = 2f;
            this.ai[1] = 0.0f;
          }
          this.velocity *= 0.99f;
          ++this.ai[1];
          if ((double) this.ai[1] < 100.0)
            return;
          this.ai[0] = 2f;
          this.ai[1] = 0.0f;
          this.velocity.X = 0.0f;
          this.velocity.Y = 0.0f;
        }
        else
        {
          if (this.justHit)
          {
            this.ai[0] = 2f;
            this.ai[1] = 0.0f;
          }
          this.velocity *= 0.96f;
          ++this.ai[1];
          this.rotation += (float) (0.100000001490116 + (double) (this.ai[1] / 120f) * 0.400000005960464) * (float) this.direction;
          if ((double) this.ai[1] < 120.0)
            return;
          this.netUpdate = true;
          this.ai[0] = 0.0f;
          this.ai[1] = 0.0f;
        }
      }
      else if (this.aiStyle == 24)
      {
        this.noGravity = true;
        if ((double) this.ai[0] == 0.0)
        {
          this.noGravity = false;
          this.TargetClosest();
          if (Main.netMode != 1)
          {
            if ((double) this.velocity.X != 0.0 || (double) this.velocity.Y < 0.0 || (double) this.velocity.Y > 0.3)
            {
              this.ai[0] = 1f;
              this.netUpdate = true;
              this.direction = -this.direction;
            }
            else if (new Rectangle((int) this.position.X - 100, (int) this.position.Y - 100, this.width + 200, this.height + 200).Intersects(new Rectangle((int) Main.player[this.target].position.X, (int) Main.player[this.target].position.Y, Main.player[this.target].width, Main.player[this.target].height)) || this.life < this.lifeMax)
            {
              this.ai[0] = 1f;
              this.velocity.Y -= 6f;
              this.netUpdate = true;
              this.direction = -this.direction;
            }
          }
        }
        else if (!Main.player[this.target].dead)
        {
          if (this.collideX)
          {
            this.direction *= -1;
            this.velocity.X = this.oldVelocity.X * -0.5f;
            if (this.direction == -1 && (double) this.velocity.X > 0.0 && (double) this.velocity.X < 2.0)
              this.velocity.X = 2f;
            if (this.direction == 1 && (double) this.velocity.X < 0.0 && (double) this.velocity.X > -2.0)
              this.velocity.X = -2f;
          }
          if (this.collideY)
          {
            this.velocity.Y = this.oldVelocity.Y * -0.5f;
            if ((double) this.velocity.Y > 0.0 && (double) this.velocity.Y < 1.0)
              this.velocity.Y = 1f;
            if ((double) this.velocity.Y < 0.0 && (double) this.velocity.Y > -1.0)
              this.velocity.Y = -1f;
          }
          if (this.direction == -1 && (double) this.velocity.X > -3.0)
          {
            this.velocity.X -= 0.1f;
            if ((double) this.velocity.X > 3.0)
              this.velocity.X -= 0.1f;
            else if ((double) this.velocity.X > 0.0)
              this.velocity.X -= 0.05f;
            if ((double) this.velocity.X < -3.0)
              this.velocity.X = -3f;
          }
          else if (this.direction == 1 && (double) this.velocity.X < 3.0)
          {
            this.velocity.X += 0.1f;
            if ((double) this.velocity.X < -3.0)
              this.velocity.X += 0.1f;
            else if ((double) this.velocity.X < 0.0)
              this.velocity.X += 0.05f;
            if ((double) this.velocity.X > 3.0)
              this.velocity.X = 3f;
          }
          int index52 = (int) (((double) this.position.X + (double) (this.width / 2)) / 16.0) + this.direction;
          int num225 = (int) (((double) this.position.Y + (double) this.height) / 16.0);
          bool flag23 = true;
          int num226 = 15;
          bool flag24 = false;
          for (int index53 = num225; index53 < num225 + num226; ++index53)
          {
            if (Main.tile[index52, index53] == null)
              Main.tile[index52, index53] = new Tile();
            if (Main.tile[index52, index53].active && Main.tileSolid[(int) Main.tile[index52, index53].type] || Main.tile[index52, index53].liquid > (byte) 0)
            {
              if (index53 < num225 + 5)
                flag24 = true;
              flag23 = false;
              break;
            }
          }
          if (flag23)
            this.velocity.Y += 0.1f;
          else
            this.velocity.Y -= 0.1f;
          if (flag24)
            this.velocity.Y -= 0.2f;
          if ((double) this.velocity.Y > 3.0)
            this.velocity.Y = 3f;
          if ((double) this.velocity.Y < -4.0)
            this.velocity.Y = -4f;
        }
        if (!this.wet)
          return;
        if ((double) this.velocity.Y > 0.0)
          this.velocity.Y *= 0.95f;
        this.velocity.Y -= 0.5f;
        if ((double) this.velocity.Y < -4.0)
          this.velocity.Y = -4f;
        this.TargetClosest();
      }
      else if (this.aiStyle == 25)
      {
        if ((double) this.ai[3] == 0.0)
        {
          this.position.X += 8f;
          this.ai[3] = (double) this.position.Y / 16.0 <= (double) (Main.maxTilesY - 200) ? ((double) this.position.Y / 16.0 <= Main.worldSurface ? 1f : 2f) : 3f;
        }
        if ((double) this.ai[0] == 0.0)
        {
          this.TargetClosest();
          if (Main.netMode == 1)
            return;
          if ((double) this.velocity.X != 0.0 || (double) this.velocity.Y < 0.0 || (double) this.velocity.Y > 0.3)
          {
            this.ai[0] = 1f;
            this.netUpdate = true;
          }
          else
          {
            if (!new Rectangle((int) this.position.X - 100, (int) this.position.Y - 100, this.width + 200, this.height + 200).Intersects(new Rectangle((int) Main.player[this.target].position.X, (int) Main.player[this.target].position.Y, Main.player[this.target].width, Main.player[this.target].height)) && this.life >= this.lifeMax)
              return;
            this.ai[0] = 1f;
            this.netUpdate = true;
          }
        }
        else if ((double) this.velocity.Y == 0.0)
        {
          ++this.ai[2];
          int num = 20;
          if ((double) this.ai[1] == 0.0)
            num = 12;
          if ((double) this.ai[2] < (double) num)
          {
            this.velocity.X *= 0.9f;
          }
          else
          {
            this.ai[2] = 0.0f;
            this.TargetClosest();
            this.spriteDirection = this.direction;
            ++this.ai[1];
            if ((double) this.ai[1] == 2.0)
            {
              this.velocity.X = (float) this.direction * 2.5f;
              this.velocity.Y = -8f;
              this.ai[1] = 0.0f;
            }
            else
            {
              this.velocity.X = (float) this.direction * 3.5f;
              this.velocity.Y = -4f;
            }
            this.netUpdate = true;
          }
        }
        else if (this.direction == 1 && (double) this.velocity.X < 1.0)
        {
          this.velocity.X += 0.1f;
        }
        else
        {
          if (this.direction != -1 || (double) this.velocity.X <= -1.0)
            return;
          this.velocity.X -= 0.1f;
        }
      }
      else if (this.aiStyle == 26)
      {
        int num227 = 30;
        bool flag = false;
        if ((double) this.velocity.Y == 0.0 && ((double) this.velocity.X > 0.0 && this.direction < 0 || (double) this.velocity.X < 0.0 && this.direction > 0))
        {
          flag = true;
          ++this.ai[3];
        }
        if ((double) this.position.X == (double) this.oldPosition.X || (double) this.ai[3] >= (double) num227 || flag)
          ++this.ai[3];
        else if ((double) this.ai[3] > 0.0)
          --this.ai[3];
        if ((double) this.ai[3] > (double) (num227 * 10))
          this.ai[3] = 0.0f;
        if (this.justHit)
          this.ai[3] = 0.0f;
        if ((double) this.ai[3] == (double) num227)
          this.netUpdate = true;
        if ((double) this.ai[3] < (double) num227)
        {
          this.TargetClosest();
        }
        else
        {
          if ((double) this.velocity.X == 0.0)
          {
            if ((double) this.velocity.Y == 0.0)
            {
              ++this.ai[0];
              if ((double) this.ai[0] >= 2.0)
              {
                this.direction *= -1;
                this.spriteDirection = this.direction;
                this.ai[0] = 0.0f;
              }
            }
          }
          else
            this.ai[0] = 0.0f;
          this.directionY = -1;
          if (this.direction == 0)
            this.direction = 1;
        }
        float num228 = 6f;
        if ((double) this.velocity.Y == 0.0 || this.wet || (double) this.velocity.X <= 0.0 && this.direction < 0 || (double) this.velocity.X >= 0.0 && this.direction > 0)
        {
          if ((double) this.velocity.X < -(double) num228 || (double) this.velocity.X > (double) num228)
          {
            if ((double) this.velocity.Y == 0.0)
              this.velocity *= 0.8f;
          }
          else if ((double) this.velocity.X < (double) num228 && this.direction == 1)
          {
            this.velocity.X += 0.07f;
            if ((double) this.velocity.X > (double) num228)
              this.velocity.X = num228;
          }
          else if ((double) this.velocity.X > -(double) num228 && this.direction == -1)
          {
            this.velocity.X -= 0.07f;
            if ((double) this.velocity.X < -(double) num228)
              this.velocity.X = -num228;
          }
        }
        if ((double) this.velocity.Y != 0.0)
          return;
        int index54 = (int) (((double) this.position.X + (double) (this.width / 2) + (double) ((this.width / 2 + 2) * this.direction) + (double) this.velocity.X * 5.0) / 16.0);
        int index55 = (int) (((double) this.position.Y + (double) this.height - 15.0) / 16.0);
        if (Main.tile[index54, index55] == null)
          Main.tile[index54, index55] = new Tile();
        if (Main.tile[index54, index55 - 1] == null)
          Main.tile[index54, index55 - 1] = new Tile();
        if (Main.tile[index54, index55 - 2] == null)
          Main.tile[index54, index55 - 2] = new Tile();
        if (Main.tile[index54, index55 - 3] == null)
          Main.tile[index54, index55 - 3] = new Tile();
        if (Main.tile[index54, index55 + 1] == null)
          Main.tile[index54, index55 + 1] = new Tile();
        if (Main.tile[index54 + this.direction, index55 - 1] == null)
          Main.tile[index54 + this.direction, index55 - 1] = new Tile();
        if (Main.tile[index54 + this.direction, index55 + 1] == null)
          Main.tile[index54 + this.direction, index55 + 1] = new Tile();
        if (((double) this.velocity.X >= 0.0 || this.spriteDirection != -1) && ((double) this.velocity.X <= 0.0 || this.spriteDirection != 1))
          return;
        if (Main.tile[index54, index55 - 2].active && Main.tileSolid[(int) Main.tile[index54, index55 - 2].type])
        {
          if (Main.tile[index54, index55 - 3].active && Main.tileSolid[(int) Main.tile[index54, index55 - 3].type])
          {
            this.velocity.Y = -8.5f;
            this.netUpdate = true;
          }
          else
          {
            this.velocity.Y = -7.5f;
            this.netUpdate = true;
          }
        }
        else if (Main.tile[index54, index55 - 1].active && Main.tileSolid[(int) Main.tile[index54, index55 - 1].type])
        {
          this.velocity.Y = -7f;
          this.netUpdate = true;
        }
        else if (Main.tile[index54, index55].active && Main.tileSolid[(int) Main.tile[index54, index55].type])
        {
          this.velocity.Y = -6f;
          this.netUpdate = true;
        }
        else
        {
          if (this.directionY >= 0 && (double) Math.Abs(this.velocity.X) <= 3.0 || Main.tile[index54, index55 + 1].active && Main.tileSolid[(int) Main.tile[index54, index55 + 1].type] || Main.tile[index54 + this.direction, index55 + 1].active && Main.tileSolid[(int) Main.tile[index54 + this.direction, index55 + 1].type])
            return;
          this.velocity.Y = -8f;
          this.netUpdate = true;
        }
      }
      else if (this.aiStyle == 27)
      {
        if ((double) this.position.X < 160.0 || (double) this.position.X > (double) ((Main.maxTilesX - 10) * 16))
          this.active = false;
        if ((double) this.localAI[0] == 0.0)
        {
          this.localAI[0] = 1f;
          Main.wofB = -1;
          Main.wofT = -1;
        }
        ++this.ai[1];
        if ((double) this.ai[2] == 0.0)
        {
          if ((double) this.life < (double) this.lifeMax * 0.5)
            ++this.ai[1];
          if ((double) this.life < (double) this.lifeMax * 0.2)
            ++this.ai[1];
          if ((double) this.ai[1] > 2700.0)
            this.ai[2] = 1f;
        }
        if ((double) this.ai[2] > 0.0 && (double) this.ai[1] > 60.0)
        {
          int num = 3;
          if ((double) this.life < (double) this.lifeMax * 0.3)
            ++num;
          ++this.ai[2];
          this.ai[1] = 0.0f;
          if ((double) this.ai[2] > (double) num)
            this.ai[2] = 0.0f;
          if (Main.netMode != 1)
          {
            int index = NPC.NewNPC((int) ((double) this.position.X + (double) (this.width / 2)), (int) ((double) this.position.Y + (double) (this.height / 2) + 20.0), 117, 1);
            Main.npc[index].velocity.X = (float) (this.direction * 8);
          }
        }
        ++this.localAI[3];
        if ((double) this.localAI[3] >= (double) (600 + Main.rand.Next(1000)))
        {
          this.localAI[3] = (float) -Main.rand.Next(200);
          Main.PlaySound(4, (int) this.position.X, (int) this.position.Y, 10);
        }
        Main.wof = this.whoAmI;
        int num229 = (int) ((double) this.position.X / 16.0);
        int num230 = (int) (((double) this.position.X + (double) this.width) / 16.0);
        int num231 = (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0);
        int num232 = 0;
        int j1 = num231 + 7;
        while (num232 < 15 && j1 > Main.maxTilesY - 200)
        {
          ++j1;
          for (int i = num229; i <= num230; ++i)
          {
            try
            {
              if (!WorldGen.SolidTile(i, j1))
              {
                if (Main.tile[i, j1].liquid <= (byte) 0)
                  continue;
              }
              ++num232;
            }
            catch
            {
              num232 += 15;
            }
          }
        }
        int num233 = j1 + 4;
        if (Main.wofB == -1)
          Main.wofB = num233 * 16;
        else if (Main.wofB > num233 * 16)
        {
          --Main.wofB;
          if (Main.wofB < num233 * 16)
            Main.wofB = num233 * 16;
        }
        else if (Main.wofB < num233 * 16)
        {
          ++Main.wofB;
          if (Main.wofB > num233 * 16)
            Main.wofB = num233 * 16;
        }
        int num234 = 0;
        int j2 = num231 - 7;
        while (num234 < 15 && j2 < Main.maxTilesY - 10)
        {
          --j2;
          for (int i = num229; i <= num230; ++i)
          {
            try
            {
              if (!WorldGen.SolidTile(i, j2))
              {
                if (Main.tile[i, j2].liquid <= (byte) 0)
                  continue;
              }
              ++num234;
            }
            catch
            {
              num234 += 15;
            }
          }
        }
        int num235 = j2 - 4;
        if (Main.wofT == -1)
          Main.wofT = num235 * 16;
        else if (Main.wofT > num235 * 16)
        {
          --Main.wofT;
          if (Main.wofT < num235 * 16)
            Main.wofT = num235 * 16;
        }
        else if (Main.wofT < num235 * 16)
        {
          ++Main.wofT;
          if (Main.wofT > num235 * 16)
            Main.wofT = num235 * 16;
        }
        float num236 = (float) ((Main.wofB + Main.wofT) / 2 - this.height / 2);
        if ((double) this.position.Y > (double) num236 + 1.0)
          this.velocity.Y = -1f;
        else if ((double) this.position.Y < (double) num236 - 1.0)
          this.velocity.Y = 1f;
        this.velocity.Y = 0.0f;
        this.position.Y = num236;
        float num237 = 1.5f;
        if ((double) this.life < (double) this.lifeMax * 0.75)
          num237 += 0.25f;
        if ((double) this.life < (double) this.lifeMax * 0.5)
          num237 += 0.4f;
        if ((double) this.life < (double) this.lifeMax * 0.25)
          num237 += 0.5f;
        if ((double) this.life < (double) this.lifeMax * 0.1)
          num237 += 0.6f;
        if ((double) this.velocity.X == 0.0)
        {
          this.TargetClosest();
          this.velocity.X = (float) this.direction;
        }
        if ((double) this.velocity.X < 0.0)
        {
          this.velocity.X = -num237;
          this.direction = -1;
        }
        else
        {
          this.velocity.X = num237;
          this.direction = 1;
        }
        this.spriteDirection = this.direction;
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num238 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
        float num239 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
        float num240 = (float) Math.Sqrt((double) num238 * (double) num238 + (double) num239 * (double) num239);
        float num241 = num238 * num240;
        float num242 = num239 * num240;
        this.rotation = this.direction <= 0 ? ((double) Main.player[this.target].position.X + (double) (Main.player[this.target].width / 2) >= (double) this.position.X + (double) (this.width / 2) ? 0.0f : (float) Math.Atan2((double) num242, (double) num241) + 3.14f) : ((double) Main.player[this.target].position.X + (double) (Main.player[this.target].width / 2) <= (double) this.position.X + (double) (this.width / 2) ? 0.0f : (float) Math.Atan2(-(double) num242, -(double) num241) + 3.14f);
        if ((double) this.localAI[0] != 1.0 || Main.netMode == 1)
          return;
        this.localAI[0] = 2f;
        int index56 = NPC.NewNPC((int) this.position.X, (int) (float) (((double) ((Main.wofB + Main.wofT) / 2) + (double) Main.wofT) / 2.0), 114, this.whoAmI);
        Main.npc[index56].ai[0] = 1f;
        int index57 = NPC.NewNPC((int) this.position.X, (int) (float) (((double) ((Main.wofB + Main.wofT) / 2) + (double) Main.wofB) / 2.0), 114, this.whoAmI);
        Main.npc[index57].ai[0] = -1f;
        float num243 = (float) (((double) ((Main.wofB + Main.wofT) / 2) + (double) Main.wofB) / 2.0);
        for (int index58 = 0; index58 < 11; ++index58)
        {
          int index59 = NPC.NewNPC((int) this.position.X, (int) num243, 115, this.whoAmI);
          Main.npc[index59].ai[0] = (float) ((double) index58 * 0.100000001490116 - 0.0500000007450581);
        }
      }
      else if (this.aiStyle == 28)
      {
        if (Main.wof < 0)
        {
          this.active = false;
        }
        else
        {
          this.realLife = Main.wof;
          this.TargetClosest();
          this.position.X = Main.npc[Main.wof].position.X;
          this.direction = Main.npc[Main.wof].direction;
          this.spriteDirection = this.direction;
          float num244 = (float) ((Main.wofB + Main.wofT) / 2);
          float num245 = ((double) this.ai[0] <= 0.0 ? (float) (((double) num244 + (double) Main.wofB) / 2.0) : (float) (((double) num244 + (double) Main.wofT) / 2.0)) - (float) (this.height / 2);
          if ((double) this.position.Y > (double) num245 + 1.0)
            this.velocity.Y = -1f;
          else if ((double) this.position.Y < (double) num245 - 1.0)
          {
            this.velocity.Y = 1f;
          }
          else
          {
            this.velocity.Y = 0.0f;
            this.position.Y = num245;
          }
          if ((double) this.velocity.Y > 5.0)
            this.velocity.Y = 5f;
          if ((double) this.velocity.Y < -5.0)
            this.velocity.Y = -5f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num246 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
          float num247 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
          float num248 = (float) Math.Sqrt((double) num246 * (double) num246 + (double) num247 * (double) num247);
          float num249 = num246 * num248;
          float num250 = num247 * num248;
          bool flag = true;
          if (this.direction > 0)
          {
            if ((double) Main.player[this.target].position.X + (double) (Main.player[this.target].width / 2) > (double) this.position.X + (double) (this.width / 2))
            {
              this.rotation = (float) Math.Atan2(-(double) num250, -(double) num249) + 3.14f;
            }
            else
            {
              this.rotation = 0.0f;
              flag = false;
            }
          }
          else if ((double) Main.player[this.target].position.X + (double) (Main.player[this.target].width / 2) < (double) this.position.X + (double) (this.width / 2))
          {
            this.rotation = (float) Math.Atan2((double) num250, (double) num249) + 3.14f;
          }
          else
          {
            this.rotation = 0.0f;
            flag = false;
          }
          if (Main.netMode == 1)
            return;
          int num251 = 4;
          ++this.localAI[1];
          if ((double) Main.npc[Main.wof].life < (double) Main.npc[Main.wof].lifeMax * 0.75)
          {
            ++this.localAI[1];
            ++num251;
          }
          if ((double) Main.npc[Main.wof].life < (double) Main.npc[Main.wof].lifeMax * 0.5)
          {
            ++this.localAI[1];
            ++num251;
          }
          if ((double) Main.npc[Main.wof].life < (double) Main.npc[Main.wof].lifeMax * 0.25)
          {
            ++this.localAI[1];
            num251 += 2;
          }
          if ((double) Main.npc[Main.wof].life < (double) Main.npc[Main.wof].lifeMax * 0.1)
          {
            this.localAI[1] += 2f;
            num251 += 3;
          }
          if ((double) this.localAI[2] == 0.0)
          {
            if ((double) this.localAI[1] <= 600.0)
              return;
            this.localAI[2] = 1f;
            this.localAI[1] = 0.0f;
          }
          else
          {
            if ((double) this.localAI[1] <= 45.0 || !Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
              return;
            this.localAI[1] = 0.0f;
            ++this.localAI[2];
            if ((double) this.localAI[2] >= (double) num251)
              this.localAI[2] = 0.0f;
            if (!flag)
              return;
            float num252 = 9f;
            int Damage = 11;
            int Type = 83;
            if ((double) Main.npc[Main.wof].life < (double) Main.npc[Main.wof].lifeMax * 0.5)
            {
              ++Damage;
              ++num252;
            }
            if ((double) Main.npc[Main.wof].life < (double) Main.npc[Main.wof].lifeMax * 0.25)
            {
              ++Damage;
              ++num252;
            }
            if ((double) Main.npc[Main.wof].life < (double) Main.npc[Main.wof].lifeMax * 0.1)
            {
              Damage += 2;
              num252 += 2f;
            }
            vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num253 = Main.player[this.target].position.X + (float) Main.player[this.target].width * 0.5f - vector2.X;
            float num254 = Main.player[this.target].position.Y + (float) Main.player[this.target].height * 0.5f - vector2.Y;
            float num255 = (float) Math.Sqrt((double) num253 * (double) num253 + (double) num254 * (double) num254);
            float num256 = num252 / num255;
            float SpeedX = num253 * num256;
            float SpeedY = num254 * num256;
            vector2.X += SpeedX;
            vector2.Y += SpeedY;
            Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
          }
        }
      }
      else if (this.aiStyle == 29)
      {
        if (this.justHit)
          this.ai[1] = 10f;
        if (Main.wof < 0)
        {
          this.active = false;
        }
        else
        {
          this.TargetClosest();
          float num257 = 0.1f;
          float num258 = 300f;
          if ((double) Main.npc[Main.wof].life < (double) Main.npc[Main.wof].lifeMax * 0.25)
          {
            this.damage = 75;
            this.defense = 40;
            num258 = 900f;
          }
          else if ((double) Main.npc[Main.wof].life < (double) Main.npc[Main.wof].lifeMax * 0.5)
          {
            this.damage = 60;
            this.defense = 30;
            num258 = 700f;
          }
          else if ((double) Main.npc[Main.wof].life < (double) Main.npc[Main.wof].lifeMax * 0.75)
          {
            this.damage = 45;
            this.defense = 20;
            num258 = 500f;
          }
          float x = Main.npc[Main.wof].position.X + (float) (Main.npc[Main.wof].width / 2);
          float y1 = Main.npc[Main.wof].position.Y;
          float num259 = (float) (Main.wofB - Main.wofT);
          float y2 = (float) Main.wofT + num259 * this.ai[0];
          ++this.ai[2];
          if ((double) this.ai[2] > 100.0)
          {
            num258 = (float) (int) ((double) num258 * 1.29999995231628);
            if ((double) this.ai[2] > 200.0)
              this.ai[2] = 0.0f;
          }
          Vector2 vector2 = new Vector2(x, y2);
          float num260 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - (float) (this.width / 2) - vector2.X;
          float num261 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - (float) (this.height / 2) - vector2.Y;
          float num262 = (float) Math.Sqrt((double) num260 * (double) num260 + (double) num261 * (double) num261);
          if ((double) this.ai[1] == 0.0)
          {
            if ((double) num262 > (double) num258)
            {
              float num263 = num258 / num262;
              num260 *= num263;
              num261 *= num263;
            }
            if ((double) this.position.X < (double) x + (double) num260)
            {
              this.velocity.X += num257;
              if ((double) this.velocity.X < 0.0 && (double) num260 > 0.0)
                this.velocity.X += num257 * 2.5f;
            }
            else if ((double) this.position.X > (double) x + (double) num260)
            {
              this.velocity.X -= num257;
              if ((double) this.velocity.X > 0.0 && (double) num260 < 0.0)
                this.velocity.X -= num257 * 2.5f;
            }
            if ((double) this.position.Y < (double) y2 + (double) num261)
            {
              this.velocity.Y += num257;
              if ((double) this.velocity.Y < 0.0 && (double) num261 > 0.0)
                this.velocity.Y += num257 * 2.5f;
            }
            else if ((double) this.position.Y > (double) y2 + (double) num261)
            {
              this.velocity.Y -= num257;
              if ((double) this.velocity.Y > 0.0 && (double) num261 < 0.0)
                this.velocity.Y -= num257 * 2.5f;
            }
            if ((double) this.velocity.X > 4.0)
              this.velocity.X = 4f;
            if ((double) this.velocity.X < -4.0)
              this.velocity.X = -4f;
            if ((double) this.velocity.Y > 4.0)
              this.velocity.Y = 4f;
            if ((double) this.velocity.Y < -4.0)
              this.velocity.Y = -4f;
          }
          else if ((double) this.ai[1] > 0.0)
            --this.ai[1];
          else
            this.ai[1] = 0.0f;
          if ((double) num260 > 0.0)
          {
            this.spriteDirection = 1;
            this.rotation = (float) Math.Atan2((double) num261, (double) num260);
          }
          if ((double) num260 < 0.0)
          {
            this.spriteDirection = -1;
            this.rotation = (float) Math.Atan2((double) num261, (double) num260) + 3.14f;
          }
          Lighting.addLight((int) ((double) this.position.X + (double) (this.width / 2)) / 16, (int) ((double) this.position.Y + (double) (this.height / 2)) / 16, 0.3f, 0.2f, 0.1f);
        }
      }
      else if (this.aiStyle == 30)
      {
        if (this.target < 0 || this.target == (int) byte.MaxValue || Main.player[this.target].dead || !Main.player[this.target].active)
          this.TargetClosest();
        bool dead = Main.player[this.target].dead;
        float num264 = this.position.X + (float) (this.width / 2) - Main.player[this.target].position.X - (float) (Main.player[this.target].width / 2);
        float num265 = (float) Math.Atan2((double) ((float) ((double) this.position.Y + (double) this.height - 59.0) - Main.player[this.target].position.Y - (float) (Main.player[this.target].height / 2)), (double) num264) + 1.57f;
        if ((double) num265 < 0.0)
          num265 += 6.283f;
        else if ((double) num265 > 6.283)
          num265 -= 6.283f;
        float num266 = 0.1f;
        if ((double) this.rotation < (double) num265)
        {
          if ((double) num265 - (double) this.rotation > 3.1415)
            this.rotation -= num266;
          else
            this.rotation += num266;
        }
        else if ((double) this.rotation > (double) num265)
        {
          if ((double) this.rotation - (double) num265 > 3.1415)
            this.rotation += num266;
          else
            this.rotation -= num266;
        }
        if ((double) this.rotation > (double) num265 - (double) num266 && (double) this.rotation < (double) num265 + (double) num266)
          this.rotation = num265;
        if ((double) this.rotation < 0.0)
          this.rotation += 6.283f;
        else if ((double) this.rotation > 6.283)
          this.rotation -= 6.283f;
        if ((double) this.rotation > (double) num265 - (double) num266 && (double) this.rotation < (double) num265 + (double) num266)
          this.rotation = num265;
        if (Main.rand.Next(5) == 0)
        {
          int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float) this.height * 0.25f), this.width, (int) ((double) this.height * 0.5), 5, this.velocity.X, 2f);
          Main.dust[index].velocity.X *= 0.5f;
          Main.dust[index].velocity.Y *= 0.1f;
        }
        if (Main.dayTime || dead)
        {
          this.velocity.Y -= 0.04f;
          if (this.timeLeft <= 10)
            return;
          this.timeLeft = 10;
        }
        else if ((double) this.ai[0] == 0.0)
        {
          if ((double) this.ai[1] == 0.0)
          {
            float num267 = 7f;
            float num268 = 0.1f;
            int num269 = 1;
            if ((double) this.position.X + (double) (this.width / 2) < (double) Main.player[this.target].position.X + (double) Main.player[this.target].width)
              num269 = -1;
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num270 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) + (float) (num269 * 300) - vector2.X;
            float num271 = (float) ((double) Main.player[this.target].position.Y + (double) (Main.player[this.target].height / 2) - 300.0) - vector2.Y;
            float num272 = (float) Math.Sqrt((double) num270 * (double) num270 + (double) num271 * (double) num271);
            float num273 = num272;
            float num274 = num267 / num272;
            float num275 = num270 * num274;
            float num276 = num271 * num274;
            if ((double) this.velocity.X < (double) num275)
            {
              this.velocity.X += num268;
              if ((double) this.velocity.X < 0.0 && (double) num275 > 0.0)
                this.velocity.X += num268;
            }
            else if ((double) this.velocity.X > (double) num275)
            {
              this.velocity.X -= num268;
              if ((double) this.velocity.X > 0.0 && (double) num275 < 0.0)
                this.velocity.X -= num268;
            }
            if ((double) this.velocity.Y < (double) num276)
            {
              this.velocity.Y += num268;
              if ((double) this.velocity.Y < 0.0 && (double) num276 > 0.0)
                this.velocity.Y += num268;
            }
            else if ((double) this.velocity.Y > (double) num276)
            {
              this.velocity.Y -= num268;
              if ((double) this.velocity.Y > 0.0 && (double) num276 < 0.0)
                this.velocity.Y -= num268;
            }
            ++this.ai[2];
            if ((double) this.ai[2] >= 600.0)
            {
              this.ai[1] = 1f;
              this.ai[2] = 0.0f;
              this.ai[3] = 0.0f;
              this.target = (int) byte.MaxValue;
              this.netUpdate = true;
            }
            else if ((double) this.position.Y + (double) this.height < (double) Main.player[this.target].position.Y && (double) num273 < 400.0)
            {
              if (!Main.player[this.target].dead)
                ++this.ai[3];
              if ((double) this.ai[3] >= 60.0)
              {
                this.ai[3] = 0.0f;
                vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
                float num277 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
                float num278 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
                if (Main.netMode != 1)
                {
                  float num279 = 9f;
                  int Damage = 20;
                  int Type = 83;
                  float num280 = (float) Math.Sqrt((double) num277 * (double) num277 + (double) num278 * (double) num278);
                  float num281 = num279 / num280;
                  float num282 = num277 * num281;
                  float num283 = num278 * num281;
                  float SpeedX = num282 + (float) Main.rand.Next(-40, 41) * 0.08f;
                  float SpeedY = num283 + (float) Main.rand.Next(-40, 41) * 0.08f;
                  vector2.X += SpeedX * 15f;
                  vector2.Y += SpeedY * 15f;
                  Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
                }
              }
            }
          }
          else if ((double) this.ai[1] == 1.0)
          {
            this.rotation = num265;
            float num284 = 12f;
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num285 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
            float num286 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
            float num287 = (float) Math.Sqrt((double) num285 * (double) num285 + (double) num286 * (double) num286);
            float num288 = num284 / num287;
            this.velocity.X = num285 * num288;
            this.velocity.Y = num286 * num288;
            this.ai[1] = 2f;
          }
          else if ((double) this.ai[1] == 2.0)
          {
            ++this.ai[2];
            if ((double) this.ai[2] >= 25.0)
            {
              this.velocity.X *= 0.96f;
              this.velocity.Y *= 0.96f;
              if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
                this.velocity.X = 0.0f;
              if ((double) this.velocity.Y > -0.1 && (double) this.velocity.Y < 0.1)
                this.velocity.Y = 0.0f;
            }
            else
              this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) - 1.57f;
            if ((double) this.ai[2] >= 70.0)
            {
              ++this.ai[3];
              this.ai[2] = 0.0f;
              this.target = (int) byte.MaxValue;
              this.rotation = num265;
              if ((double) this.ai[3] >= 4.0)
              {
                this.ai[1] = 0.0f;
                this.ai[3] = 0.0f;
              }
              else
                this.ai[1] = 1f;
            }
          }
          if ((double) this.life >= (double) this.lifeMax * 0.5)
            return;
          this.ai[0] = 1f;
          this.ai[1] = 0.0f;
          this.ai[2] = 0.0f;
          this.ai[3] = 0.0f;
          this.netUpdate = true;
        }
        else if ((double) this.ai[0] == 1.0 || (double) this.ai[0] == 2.0)
        {
          if ((double) this.ai[0] == 1.0)
          {
            this.ai[2] += 0.005f;
            if ((double) this.ai[2] > 0.5)
              this.ai[2] = 0.5f;
          }
          else
          {
            this.ai[2] -= 0.005f;
            if ((double) this.ai[2] < 0.0)
              this.ai[2] = 0.0f;
          }
          this.rotation += this.ai[2];
          ++this.ai[1];
          if ((double) this.ai[1] == 100.0)
          {
            ++this.ai[0];
            this.ai[1] = 0.0f;
            if ((double) this.ai[0] == 3.0)
            {
              this.ai[2] = 0.0f;
            }
            else
            {
              Main.PlaySound(3, (int) this.position.X, (int) this.position.Y);
              for (int index = 0; index < 2; ++index)
              {
                Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 143);
                Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 7);
                Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 6);
              }
              for (int index = 0; index < 20; ++index)
                Dust.NewDust(this.position, this.width, this.height, 5, (float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f);
              Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
            }
          }
          Dust.NewDust(this.position, this.width, this.height, 5, (float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f);
          this.velocity.X *= 0.98f;
          this.velocity.Y *= 0.98f;
          if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
            this.velocity.X = 0.0f;
          if ((double) this.velocity.Y <= -0.1 || (double) this.velocity.Y >= 0.1)
            return;
          this.velocity.Y = 0.0f;
        }
        else
        {
          this.damage = (int) ((double) this.defDamage * 1.5);
          this.defense = this.defDefense + 15;
          this.soundHit = 4;
          if ((double) this.ai[1] == 0.0)
          {
            float num289 = 8f;
            float num290 = 0.15f;
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num291 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
            float num292 = (float) ((double) Main.player[this.target].position.Y + (double) (Main.player[this.target].height / 2) - 300.0) - vector2.Y;
            float num293 = (float) Math.Sqrt((double) num291 * (double) num291 + (double) num292 * (double) num292);
            float num294 = num289 / num293;
            float num295 = num291 * num294;
            float num296 = num292 * num294;
            if ((double) this.velocity.X < (double) num295)
            {
              this.velocity.X += num290;
              if ((double) this.velocity.X < 0.0 && (double) num295 > 0.0)
                this.velocity.X += num290;
            }
            else if ((double) this.velocity.X > (double) num295)
            {
              this.velocity.X -= num290;
              if ((double) this.velocity.X > 0.0 && (double) num295 < 0.0)
                this.velocity.X -= num290;
            }
            if ((double) this.velocity.Y < (double) num296)
            {
              this.velocity.Y += num290;
              if ((double) this.velocity.Y < 0.0 && (double) num296 > 0.0)
                this.velocity.Y += num290;
            }
            else if ((double) this.velocity.Y > (double) num296)
            {
              this.velocity.Y -= num290;
              if ((double) this.velocity.Y > 0.0 && (double) num296 < 0.0)
                this.velocity.Y -= num290;
            }
            ++this.ai[2];
            if ((double) this.ai[2] >= 300.0)
            {
              this.ai[1] = 1f;
              this.ai[2] = 0.0f;
              this.ai[3] = 0.0f;
              this.TargetClosest();
              this.netUpdate = true;
            }
            vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num297 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
            float num298 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
            this.rotation = (float) Math.Atan2((double) num298, (double) num297) - 1.57f;
            if (Main.netMode == 1)
              return;
            ++this.localAI[1];
            if ((double) this.life < (double) this.lifeMax * 0.75)
              ++this.localAI[1];
            if ((double) this.life < (double) this.lifeMax * 0.5)
              ++this.localAI[1];
            if ((double) this.life < (double) this.lifeMax * 0.25)
              ++this.localAI[1];
            if ((double) this.life < (double) this.lifeMax * 0.1)
              this.localAI[1] += 2f;
            if ((double) this.localAI[1] <= 140.0 || !Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
              return;
            this.localAI[1] = 0.0f;
            float num299 = 9f;
            int Damage = 25;
            int Type = 100;
            float num300 = (float) Math.Sqrt((double) num297 * (double) num297 + (double) num298 * (double) num298);
            float num301 = num299 / num300;
            float SpeedX = num297 * num301;
            float SpeedY = num298 * num301;
            vector2.X += SpeedX * 15f;
            vector2.Y += SpeedY * 15f;
            Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
          }
          else
          {
            int num302 = 1;
            if ((double) this.position.X + (double) (this.width / 2) < (double) Main.player[this.target].position.X + (double) Main.player[this.target].width)
              num302 = -1;
            float num303 = 8f;
            float num304 = 0.2f;
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num305 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) + (float) (num302 * 340) - vector2.X;
            float num306 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
            float num307 = (float) Math.Sqrt((double) num305 * (double) num305 + (double) num306 * (double) num306);
            float num308 = num303 / num307;
            float num309 = num305 * num308;
            float num310 = num306 * num308;
            if ((double) this.velocity.X < (double) num309)
            {
              this.velocity.X += num304;
              if ((double) this.velocity.X < 0.0 && (double) num309 > 0.0)
                this.velocity.X += num304;
            }
            else if ((double) this.velocity.X > (double) num309)
            {
              this.velocity.X -= num304;
              if ((double) this.velocity.X > 0.0 && (double) num309 < 0.0)
                this.velocity.X -= num304;
            }
            if ((double) this.velocity.Y < (double) num310)
            {
              this.velocity.Y += num304;
              if ((double) this.velocity.Y < 0.0 && (double) num310 > 0.0)
                this.velocity.Y += num304;
            }
            else if ((double) this.velocity.Y > (double) num310)
            {
              this.velocity.Y -= num304;
              if ((double) this.velocity.Y > 0.0 && (double) num310 < 0.0)
                this.velocity.Y -= num304;
            }
            vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num311 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
            float num312 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
            this.rotation = (float) Math.Atan2((double) num312, (double) num311) - 1.57f;
            if (Main.netMode != 1)
            {
              ++this.localAI[1];
              if ((double) this.life < (double) this.lifeMax * 0.75)
                ++this.localAI[1];
              if ((double) this.life < (double) this.lifeMax * 0.5)
                ++this.localAI[1];
              if ((double) this.life < (double) this.lifeMax * 0.25)
                ++this.localAI[1];
              if ((double) this.life < (double) this.lifeMax * 0.1)
                this.localAI[1] += 2f;
              if ((double) this.localAI[1] > 45.0 && Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
              {
                this.localAI[1] = 0.0f;
                float num313 = 9f;
                int Damage = 20;
                int Type = 100;
                float num314 = (float) Math.Sqrt((double) num311 * (double) num311 + (double) num312 * (double) num312);
                float num315 = num313 / num314;
                float SpeedX = num311 * num315;
                float SpeedY = num312 * num315;
                vector2.X += SpeedX * 15f;
                vector2.Y += SpeedY * 15f;
                Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
              }
            }
            ++this.ai[2];
            if ((double) this.ai[2] < 200.0)
              return;
            this.ai[1] = 0.0f;
            this.ai[2] = 0.0f;
            this.ai[3] = 0.0f;
            this.TargetClosest();
            this.netUpdate = true;
          }
        }
      }
      else if (this.aiStyle == 31)
      {
        if (this.target < 0 || this.target == (int) byte.MaxValue || Main.player[this.target].dead || !Main.player[this.target].active)
          this.TargetClosest();
        bool dead = Main.player[this.target].dead;
        float num316 = this.position.X + (float) (this.width / 2) - Main.player[this.target].position.X - (float) (Main.player[this.target].width / 2);
        float num317 = (float) Math.Atan2((double) ((float) ((double) this.position.Y + (double) this.height - 59.0) - Main.player[this.target].position.Y - (float) (Main.player[this.target].height / 2)), (double) num316) + 1.57f;
        if ((double) num317 < 0.0)
          num317 += 6.283f;
        else if ((double) num317 > 6.283)
          num317 -= 6.283f;
        float num318 = 0.15f;
        if ((double) this.rotation < (double) num317)
        {
          if ((double) num317 - (double) this.rotation > 3.1415)
            this.rotation -= num318;
          else
            this.rotation += num318;
        }
        else if ((double) this.rotation > (double) num317)
        {
          if ((double) this.rotation - (double) num317 > 3.1415)
            this.rotation += num318;
          else
            this.rotation -= num318;
        }
        if ((double) this.rotation > (double) num317 - (double) num318 && (double) this.rotation < (double) num317 + (double) num318)
          this.rotation = num317;
        if ((double) this.rotation < 0.0)
          this.rotation += 6.283f;
        else if ((double) this.rotation > 6.283)
          this.rotation -= 6.283f;
        if ((double) this.rotation > (double) num317 - (double) num318 && (double) this.rotation < (double) num317 + (double) num318)
          this.rotation = num317;
        if (Main.rand.Next(5) == 0)
        {
          int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float) this.height * 0.25f), this.width, (int) ((double) this.height * 0.5), 5, this.velocity.X, 2f);
          Main.dust[index].velocity.X *= 0.5f;
          Main.dust[index].velocity.Y *= 0.1f;
        }
        if (Main.dayTime || dead)
        {
          this.velocity.Y -= 0.04f;
          if (this.timeLeft <= 10)
            return;
          this.timeLeft = 10;
        }
        else if ((double) this.ai[0] == 0.0)
        {
          if ((double) this.ai[1] == 0.0)
          {
            this.TargetClosest();
            float num319 = 12f;
            float num320 = 0.4f;
            int num321 = 1;
            if ((double) this.position.X + (double) (this.width / 2) < (double) Main.player[this.target].position.X + (double) Main.player[this.target].width)
              num321 = -1;
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num322 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) + (float) (num321 * 400) - vector2.X;
            float num323 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
            float num324 = (float) Math.Sqrt((double) num322 * (double) num322 + (double) num323 * (double) num323);
            float num325 = num319 / num324;
            float num326 = num322 * num325;
            float num327 = num323 * num325;
            if ((double) this.velocity.X < (double) num326)
            {
              this.velocity.X += num320;
              if ((double) this.velocity.X < 0.0 && (double) num326 > 0.0)
                this.velocity.X += num320;
            }
            else if ((double) this.velocity.X > (double) num326)
            {
              this.velocity.X -= num320;
              if ((double) this.velocity.X > 0.0 && (double) num326 < 0.0)
                this.velocity.X -= num320;
            }
            if ((double) this.velocity.Y < (double) num327)
            {
              this.velocity.Y += num320;
              if ((double) this.velocity.Y < 0.0 && (double) num327 > 0.0)
                this.velocity.Y += num320;
            }
            else if ((double) this.velocity.Y > (double) num327)
            {
              this.velocity.Y -= num320;
              if ((double) this.velocity.Y > 0.0 && (double) num327 < 0.0)
                this.velocity.Y -= num320;
            }
            ++this.ai[2];
            if ((double) this.ai[2] >= 600.0)
            {
              this.ai[1] = 1f;
              this.ai[2] = 0.0f;
              this.ai[3] = 0.0f;
              this.target = (int) byte.MaxValue;
              this.netUpdate = true;
            }
            else
            {
              if (!Main.player[this.target].dead)
                ++this.ai[3];
              if ((double) this.ai[3] >= 60.0)
              {
                this.ai[3] = 0.0f;
                vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
                float num328 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
                float num329 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
                if (Main.netMode != 1)
                {
                  float num330 = 12f;
                  int Damage = 25;
                  int Type = 96;
                  float num331 = (float) Math.Sqrt((double) num328 * (double) num328 + (double) num329 * (double) num329);
                  float num332 = num330 / num331;
                  float num333 = num328 * num332;
                  float num334 = num329 * num332;
                  float SpeedX = num333 + (float) Main.rand.Next(-40, 41) * 0.05f;
                  float SpeedY = num334 + (float) Main.rand.Next(-40, 41) * 0.05f;
                  vector2.X += SpeedX * 4f;
                  vector2.Y += SpeedY * 4f;
                  Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
                }
              }
            }
          }
          else if ((double) this.ai[1] == 1.0)
          {
            this.rotation = num317;
            float num335 = 13f;
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num336 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
            float num337 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
            float num338 = (float) Math.Sqrt((double) num336 * (double) num336 + (double) num337 * (double) num337);
            float num339 = num335 / num338;
            this.velocity.X = num336 * num339;
            this.velocity.Y = num337 * num339;
            this.ai[1] = 2f;
          }
          else if ((double) this.ai[1] == 2.0)
          {
            ++this.ai[2];
            if ((double) this.ai[2] >= 8.0)
            {
              this.velocity.X *= 0.9f;
              this.velocity.Y *= 0.9f;
              if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
                this.velocity.X = 0.0f;
              if ((double) this.velocity.Y > -0.1 && (double) this.velocity.Y < 0.1)
                this.velocity.Y = 0.0f;
            }
            else
              this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) - 1.57f;
            if ((double) this.ai[2] >= 42.0)
            {
              ++this.ai[3];
              this.ai[2] = 0.0f;
              this.target = (int) byte.MaxValue;
              this.rotation = num317;
              if ((double) this.ai[3] >= 10.0)
              {
                this.ai[1] = 0.0f;
                this.ai[3] = 0.0f;
              }
              else
                this.ai[1] = 1f;
            }
          }
          if ((double) this.life >= (double) this.lifeMax * 0.5)
            return;
          this.ai[0] = 1f;
          this.ai[1] = 0.0f;
          this.ai[2] = 0.0f;
          this.ai[3] = 0.0f;
          this.netUpdate = true;
        }
        else if ((double) this.ai[0] == 1.0 || (double) this.ai[0] == 2.0)
        {
          if ((double) this.ai[0] == 1.0)
          {
            this.ai[2] += 0.005f;
            if ((double) this.ai[2] > 0.5)
              this.ai[2] = 0.5f;
          }
          else
          {
            this.ai[2] -= 0.005f;
            if ((double) this.ai[2] < 0.0)
              this.ai[2] = 0.0f;
          }
          this.rotation += this.ai[2];
          ++this.ai[1];
          if ((double) this.ai[1] == 100.0)
          {
            ++this.ai[0];
            this.ai[1] = 0.0f;
            if ((double) this.ai[0] == 3.0)
            {
              this.ai[2] = 0.0f;
            }
            else
            {
              Main.PlaySound(3, (int) this.position.X, (int) this.position.Y);
              for (int index = 0; index < 2; ++index)
              {
                Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 144);
                Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 7);
                Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 6);
              }
              for (int index = 0; index < 20; ++index)
                Dust.NewDust(this.position, this.width, this.height, 5, (float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f);
              Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
            }
          }
          Dust.NewDust(this.position, this.width, this.height, 5, (float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f);
          this.velocity.X *= 0.98f;
          this.velocity.Y *= 0.98f;
          if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
            this.velocity.X = 0.0f;
          if ((double) this.velocity.Y <= -0.1 || (double) this.velocity.Y >= 0.1)
            return;
          this.velocity.Y = 0.0f;
        }
        else
        {
          this.soundHit = 4;
          this.damage = (int) ((double) this.defDamage * 1.5);
          this.defense = this.defDefense + 25;
          if ((double) this.ai[1] == 0.0)
          {
            float num340 = 4f;
            float num341 = 0.1f;
            int num342 = 1;
            if ((double) this.position.X + (double) (this.width / 2) < (double) Main.player[this.target].position.X + (double) Main.player[this.target].width)
              num342 = -1;
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num343 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) + (float) (num342 * 180) - vector2.X;
            float num344 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
            float num345 = (float) Math.Sqrt((double) num343 * (double) num343 + (double) num344 * (double) num344);
            float num346 = num340 / num345;
            float num347 = num343 * num346;
            float num348 = num344 * num346;
            if ((double) this.velocity.X < (double) num347)
            {
              this.velocity.X += num341;
              if ((double) this.velocity.X < 0.0 && (double) num347 > 0.0)
                this.velocity.X += num341;
            }
            else if ((double) this.velocity.X > (double) num347)
            {
              this.velocity.X -= num341;
              if ((double) this.velocity.X > 0.0 && (double) num347 < 0.0)
                this.velocity.X -= num341;
            }
            if ((double) this.velocity.Y < (double) num348)
            {
              this.velocity.Y += num341;
              if ((double) this.velocity.Y < 0.0 && (double) num348 > 0.0)
                this.velocity.Y += num341;
            }
            else if ((double) this.velocity.Y > (double) num348)
            {
              this.velocity.Y -= num341;
              if ((double) this.velocity.Y > 0.0 && (double) num348 < 0.0)
                this.velocity.Y -= num341;
            }
            ++this.ai[2];
            if ((double) this.ai[2] >= 400.0)
            {
              this.ai[1] = 1f;
              this.ai[2] = 0.0f;
              this.ai[3] = 0.0f;
              this.target = (int) byte.MaxValue;
              this.netUpdate = true;
            }
            if (!Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
              return;
            ++this.localAI[2];
            if ((double) this.localAI[2] > 22.0)
            {
              this.localAI[2] = 0.0f;
              Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 34);
            }
            if (Main.netMode == 1)
              return;
            ++this.localAI[1];
            if ((double) this.life < (double) this.lifeMax * 0.75)
              ++this.localAI[1];
            if ((double) this.life < (double) this.lifeMax * 0.5)
              ++this.localAI[1];
            if ((double) this.life < (double) this.lifeMax * 0.25)
              ++this.localAI[1];
            if ((double) this.life < (double) this.lifeMax * 0.1)
              this.localAI[1] += 2f;
            if ((double) this.localAI[1] <= 8.0)
              return;
            this.localAI[1] = 0.0f;
            float num349 = 6f;
            int Damage = 30;
            int Type = 101;
            vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num350 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
            float num351 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
            float num352 = (float) Math.Sqrt((double) num350 * (double) num350 + (double) num351 * (double) num351);
            float num353 = num349 / num352;
            float num354 = num350 * num353;
            float num355 = num351 * num353 + (float) Main.rand.Next(-40, 41) * 0.01f;
            float num356 = num354 + (float) Main.rand.Next(-40, 41) * 0.01f;
            float SpeedY = num355 + this.velocity.Y * 0.5f;
            float SpeedX = num356 + this.velocity.X * 0.5f;
            vector2.X -= SpeedX * 1f;
            vector2.Y -= SpeedY * 1f;
            Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
          }
          else if ((double) this.ai[1] == 1.0)
          {
            Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
            this.rotation = num317;
            float num357 = 14f;
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num358 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
            float num359 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
            float num360 = (float) Math.Sqrt((double) num358 * (double) num358 + (double) num359 * (double) num359);
            float num361 = num357 / num360;
            this.velocity.X = num358 * num361;
            this.velocity.Y = num359 * num361;
            this.ai[1] = 2f;
          }
          else
          {
            if ((double) this.ai[1] != 2.0)
              return;
            ++this.ai[2];
            if ((double) this.ai[2] >= 50.0)
            {
              this.velocity.X *= 0.93f;
              this.velocity.Y *= 0.93f;
              if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
                this.velocity.X = 0.0f;
              if ((double) this.velocity.Y > -0.1 && (double) this.velocity.Y < 0.1)
                this.velocity.Y = 0.0f;
            }
            else
              this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) - 1.57f;
            if ((double) this.ai[2] < 80.0)
              return;
            ++this.ai[3];
            this.ai[2] = 0.0f;
            this.target = (int) byte.MaxValue;
            this.rotation = num317;
            if ((double) this.ai[3] >= 6.0)
            {
              this.ai[1] = 0.0f;
              this.ai[3] = 0.0f;
            }
            else
              this.ai[1] = 1f;
          }
        }
      }
      else if (this.aiStyle == 32)
      {
        this.damage = this.defDamage;
        this.defense = this.defDefense;
        if ((double) this.ai[0] == 0.0 && Main.netMode != 1)
        {
          this.TargetClosest();
          this.ai[0] = 1f;
          if (this.type != 68)
          {
            int index60 = NPC.NewNPC((int) ((double) this.position.X + (double) (this.width / 2)), (int) this.position.Y + this.height / 2, 128, this.whoAmI);
            Main.npc[index60].ai[0] = -1f;
            Main.npc[index60].ai[1] = (float) this.whoAmI;
            Main.npc[index60].target = this.target;
            Main.npc[index60].netUpdate = true;
            int index61 = NPC.NewNPC((int) ((double) this.position.X + (double) (this.width / 2)), (int) this.position.Y + this.height / 2, 129, this.whoAmI);
            Main.npc[index61].ai[0] = 1f;
            Main.npc[index61].ai[1] = (float) this.whoAmI;
            Main.npc[index61].target = this.target;
            Main.npc[index61].netUpdate = true;
            int index62 = NPC.NewNPC((int) ((double) this.position.X + (double) (this.width / 2)), (int) this.position.Y + this.height / 2, 130, this.whoAmI);
            Main.npc[index62].ai[0] = -1f;
            Main.npc[index62].ai[1] = (float) this.whoAmI;
            Main.npc[index62].target = this.target;
            Main.npc[index62].ai[3] = 150f;
            Main.npc[index62].netUpdate = true;
            int index63 = NPC.NewNPC((int) ((double) this.position.X + (double) (this.width / 2)), (int) this.position.Y + this.height / 2, 131, this.whoAmI);
            Main.npc[index63].ai[0] = 1f;
            Main.npc[index63].ai[1] = (float) this.whoAmI;
            Main.npc[index63].target = this.target;
            Main.npc[index63].netUpdate = true;
            Main.npc[index63].ai[3] = 150f;
          }
        }
        if (this.type == 68 && (double) this.ai[1] != 3.0 && (double) this.ai[1] != 2.0)
        {
          Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
          this.ai[1] = 2f;
        }
        if (Main.player[this.target].dead || (double) Math.Abs(this.position.X - Main.player[this.target].position.X) > 6000.0 || (double) Math.Abs(this.position.Y - Main.player[this.target].position.Y) > 6000.0)
        {
          this.TargetClosest();
          if (Main.player[this.target].dead || (double) Math.Abs(this.position.X - Main.player[this.target].position.X) > 6000.0 || (double) Math.Abs(this.position.Y - Main.player[this.target].position.Y) > 6000.0)
            this.ai[1] = 3f;
        }
        if (Main.dayTime && (double) this.ai[1] != 3.0 && (double) this.ai[1] != 2.0)
        {
          this.ai[1] = 2f;
          Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
        }
        if ((double) this.ai[1] == 0.0)
        {
          ++this.ai[2];
          if ((double) this.ai[2] >= 600.0)
          {
            this.ai[2] = 0.0f;
            this.ai[1] = 1f;
            this.TargetClosest();
            this.netUpdate = true;
          }
          this.rotation = this.velocity.X / 15f;
          if ((double) this.position.Y > (double) Main.player[this.target].position.Y - 200.0)
          {
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y *= 0.98f;
            this.velocity.Y -= 0.1f;
            if ((double) this.velocity.Y > 2.0)
              this.velocity.Y = 2f;
          }
          else if ((double) this.position.Y < (double) Main.player[this.target].position.Y - 500.0)
          {
            if ((double) this.velocity.Y < 0.0)
              this.velocity.Y *= 0.98f;
            this.velocity.Y += 0.1f;
            if ((double) this.velocity.Y < -2.0)
              this.velocity.Y = -2f;
          }
          if ((double) this.position.X + (double) (this.width / 2) > (double) Main.player[this.target].position.X + (double) (Main.player[this.target].width / 2) + 100.0)
          {
            if ((double) this.velocity.X > 0.0)
              this.velocity.X *= 0.98f;
            this.velocity.X -= 0.1f;
            if ((double) this.velocity.X > 8.0)
              this.velocity.X = 8f;
          }
          if ((double) this.position.X + (double) (this.width / 2) >= (double) Main.player[this.target].position.X + (double) (Main.player[this.target].width / 2) - 100.0)
            return;
          if ((double) this.velocity.X < 0.0)
            this.velocity.X *= 0.98f;
          this.velocity.X += 0.1f;
          if ((double) this.velocity.X >= -8.0)
            return;
          this.velocity.X = -8f;
        }
        else if ((double) this.ai[1] == 1.0)
        {
          this.defense *= 2;
          this.damage *= 2;
          ++this.ai[2];
          if ((double) this.ai[2] == 2.0)
            Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
          if ((double) this.ai[2] >= 400.0)
          {
            this.ai[2] = 0.0f;
            this.ai[1] = 0.0f;
          }
          this.rotation += (float) this.direction * 0.3f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num362 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
          float num363 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
          float num364 = 2f / (float) Math.Sqrt((double) num362 * (double) num362 + (double) num363 * (double) num363);
          this.velocity.X = num362 * num364;
          this.velocity.Y = num363 * num364;
        }
        else if ((double) this.ai[1] == 2.0)
        {
          this.damage = 9999;
          this.defense = 9999;
          this.rotation += (float) this.direction * 0.3f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num365 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
          float num366 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
          float num367 = 8f / (float) Math.Sqrt((double) num365 * (double) num365 + (double) num366 * (double) num366);
          this.velocity.X = num365 * num367;
          this.velocity.Y = num366 * num367;
        }
        else
        {
          if ((double) this.ai[1] != 3.0)
            return;
          this.velocity.Y += 0.1f;
          if ((double) this.velocity.Y < 0.0)
            this.velocity.Y *= 0.95f;
          this.velocity.X *= 0.95f;
          if (this.timeLeft <= 500)
            return;
          this.timeLeft = 500;
        }
      }
      else if (this.aiStyle == 33)
      {
        Vector2 vector2_6 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num368 = (float) ((double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 200.0 * (double) this.ai[0]) - vector2_6.X;
        float num369 = Main.npc[(int) this.ai[1]].position.Y + 230f - vector2_6.Y;
        float num370 = (float) Math.Sqrt((double) num368 * (double) num368 + (double) num369 * (double) num369);
        if ((double) this.ai[2] != 99.0)
        {
          if ((double) num370 > 800.0)
            this.ai[2] = 99f;
        }
        else if ((double) num370 < 400.0)
          this.ai[2] = 0.0f;
        this.spriteDirection = -(int) this.ai[0];
        if (!Main.npc[(int) this.ai[1]].active || Main.npc[(int) this.ai[1]].aiStyle != 32)
        {
          this.ai[2] += 10f;
          if ((double) this.ai[2] > 50.0 || Main.netMode != 2)
          {
            this.life = -1;
            this.HitEffect();
            this.active = false;
          }
        }
        if ((double) this.ai[2] == 99.0)
        {
          if ((double) this.position.Y > (double) Main.npc[(int) this.ai[1]].position.Y)
          {
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y -= 0.1f;
            if ((double) this.velocity.Y > 8.0)
              this.velocity.Y = 8f;
          }
          else if ((double) this.position.Y < (double) Main.npc[(int) this.ai[1]].position.Y)
          {
            if ((double) this.velocity.Y < 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y += 0.1f;
            if ((double) this.velocity.Y < -8.0)
              this.velocity.Y = -8f;
          }
          if ((double) this.position.X + (double) (this.width / 2) > (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2))
          {
            if ((double) this.velocity.X > 0.0)
              this.velocity.X *= 0.96f;
            this.velocity.X -= 0.5f;
            if ((double) this.velocity.X > 12.0)
              this.velocity.X = 12f;
          }
          if ((double) this.position.X + (double) (this.width / 2) >= (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2))
            return;
          if ((double) this.velocity.X < 0.0)
            this.velocity.X *= 0.96f;
          this.velocity.X += 0.5f;
          if ((double) this.velocity.X >= -12.0)
            return;
          this.velocity.X = -12f;
        }
        else if ((double) this.ai[2] == 0.0 || (double) this.ai[2] == 3.0)
        {
          if ((double) Main.npc[(int) this.ai[1]].ai[1] == 3.0 && this.timeLeft > 10)
            this.timeLeft = 10;
          if ((double) Main.npc[(int) this.ai[1]].ai[1] != 0.0)
          {
            this.TargetClosest();
            if (Main.player[this.target].dead)
            {
              this.velocity.Y += 0.1f;
              if ((double) this.velocity.Y > 16.0)
                this.velocity.Y = 16f;
            }
            else
            {
              Vector2 vector2_7 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
              float num371 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2_7.X;
              float num372 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2_7.Y;
              float num373 = 7f / (float) Math.Sqrt((double) num371 * (double) num371 + (double) num372 * (double) num372);
              float num374 = num371 * num373;
              float num375 = num372 * num373;
              this.rotation = (float) Math.Atan2((double) num375, (double) num374) - 1.57f;
              if ((double) this.velocity.X > (double) num374)
              {
                if ((double) this.velocity.X > 0.0)
                  this.velocity.X *= 0.97f;
                this.velocity.X -= 0.05f;
              }
              if ((double) this.velocity.X < (double) num374)
              {
                if ((double) this.velocity.X < 0.0)
                  this.velocity.X *= 0.97f;
                this.velocity.X += 0.05f;
              }
              if ((double) this.velocity.Y > (double) num375)
              {
                if ((double) this.velocity.Y > 0.0)
                  this.velocity.Y *= 0.97f;
                this.velocity.Y -= 0.05f;
              }
              if ((double) this.velocity.Y < (double) num375)
              {
                if ((double) this.velocity.Y < 0.0)
                  this.velocity.Y *= 0.97f;
                this.velocity.Y += 0.05f;
              }
            }
            ++this.ai[3];
            if ((double) this.ai[3] >= 600.0)
            {
              this.ai[2] = 0.0f;
              this.ai[3] = 0.0f;
              this.netUpdate = true;
            }
          }
          else
          {
            ++this.ai[3];
            if ((double) this.ai[3] >= 300.0)
            {
              ++this.ai[2];
              this.ai[3] = 0.0f;
              this.netUpdate = true;
            }
            if ((double) this.position.Y > (double) Main.npc[(int) this.ai[1]].position.Y + 320.0)
            {
              if ((double) this.velocity.Y > 0.0)
                this.velocity.Y *= 0.96f;
              this.velocity.Y -= 0.04f;
              if ((double) this.velocity.Y > 3.0)
                this.velocity.Y = 3f;
            }
            else if ((double) this.position.Y < (double) Main.npc[(int) this.ai[1]].position.Y + 260.0)
            {
              if ((double) this.velocity.Y < 0.0)
                this.velocity.Y *= 0.96f;
              this.velocity.Y += 0.04f;
              if ((double) this.velocity.Y < -3.0)
                this.velocity.Y = -3f;
            }
            if ((double) this.position.X + (double) (this.width / 2) > (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2))
            {
              if ((double) this.velocity.X > 0.0)
                this.velocity.X *= 0.96f;
              this.velocity.X -= 0.3f;
              if ((double) this.velocity.X > 12.0)
                this.velocity.X = 12f;
            }
            if ((double) this.position.X + (double) (this.width / 2) < (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 250.0)
            {
              if ((double) this.velocity.X < 0.0)
                this.velocity.X *= 0.96f;
              this.velocity.X += 0.3f;
              if ((double) this.velocity.X < -12.0)
                this.velocity.X = -12f;
            }
          }
          Vector2 vector2_8 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num376 = (float) ((double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 200.0 * (double) this.ai[0]) - vector2_8.X;
          float num377 = Main.npc[(int) this.ai[1]].position.Y + 230f - vector2_8.Y;
          Math.Sqrt((double) num376 * (double) num376 + (double) num377 * (double) num377);
          this.rotation = (float) Math.Atan2((double) num377, (double) num376) + 1.57f;
        }
        else if ((double) this.ai[2] == 1.0)
        {
          Vector2 vector2_9 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num378 = (float) ((double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 200.0 * (double) this.ai[0]) - vector2_9.X;
          float num379 = Main.npc[(int) this.ai[1]].position.Y + 230f - vector2_9.Y;
          float num380 = (float) Math.Sqrt((double) num378 * (double) num378 + (double) num379 * (double) num379);
          this.rotation = (float) Math.Atan2((double) num379, (double) num378) + 1.57f;
          this.velocity.X *= 0.95f;
          this.velocity.Y -= 0.1f;
          if ((double) this.velocity.Y < -8.0)
            this.velocity.Y = -8f;
          if ((double) this.position.Y >= (double) Main.npc[(int) this.ai[1]].position.Y - 200.0)
            return;
          this.TargetClosest();
          this.ai[2] = 2f;
          vector2_9 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num381 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2_9.X;
          float num382 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2_9.Y;
          float num383 = 22f / (float) Math.Sqrt((double) num381 * (double) num381 + (double) num382 * (double) num382);
          this.velocity.X = num381 * num383;
          this.velocity.Y = num382 * num383;
          this.netUpdate = true;
        }
        else if ((double) this.ai[2] == 2.0)
        {
          if ((double) this.position.Y <= (double) Main.player[this.target].position.Y && (double) this.velocity.Y >= 0.0)
            return;
          this.ai[2] = 3f;
        }
        else if ((double) this.ai[2] == 4.0)
        {
          this.TargetClosest();
          Vector2 vector2_10 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num384 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2_10.X;
          float num385 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2_10.Y;
          float num386 = 7f / (float) Math.Sqrt((double) num384 * (double) num384 + (double) num385 * (double) num385);
          float num387 = num384 * num386;
          float num388 = num385 * num386;
          if ((double) this.velocity.X > (double) num387)
          {
            if ((double) this.velocity.X > 0.0)
              this.velocity.X *= 0.97f;
            this.velocity.X -= 0.05f;
          }
          if ((double) this.velocity.X < (double) num387)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X *= 0.97f;
            this.velocity.X += 0.05f;
          }
          if ((double) this.velocity.Y > (double) num388)
          {
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y *= 0.97f;
            this.velocity.Y -= 0.05f;
          }
          if ((double) this.velocity.Y < (double) num388)
          {
            if ((double) this.velocity.Y < 0.0)
              this.velocity.Y *= 0.97f;
            this.velocity.Y += 0.05f;
          }
          ++this.ai[3];
          if ((double) this.ai[3] >= 600.0)
          {
            this.ai[2] = 0.0f;
            this.ai[3] = 0.0f;
            this.netUpdate = true;
          }
          vector2_10 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num389 = (float) ((double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 200.0 * (double) this.ai[0]) - vector2_10.X;
          float num390 = Main.npc[(int) this.ai[1]].position.Y + 230f - vector2_10.Y;
          float num391 = (float) Math.Sqrt((double) num389 * (double) num389 + (double) num390 * (double) num390);
          this.rotation = (float) Math.Atan2((double) num390, (double) num389) + 1.57f;
        }
        else
        {
          if ((double) this.ai[2] != 5.0 || ((double) this.velocity.X <= 0.0 || (double) this.position.X + (double) (this.width / 2) <= (double) Main.player[this.target].position.X + (double) (Main.player[this.target].width / 2)) && ((double) this.velocity.X >= 0.0 || (double) this.position.X + (double) (this.width / 2) >= (double) Main.player[this.target].position.X + (double) (Main.player[this.target].width / 2)))
            return;
          this.ai[2] = 0.0f;
        }
      }
      else if (this.aiStyle == 34)
      {
        this.spriteDirection = -(int) this.ai[0];
        Vector2 vector2_11 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num392 = (float) ((double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 200.0 * (double) this.ai[0]) - vector2_11.X;
        float num393 = Main.npc[(int) this.ai[1]].position.Y + 230f - vector2_11.Y;
        float num394 = (float) Math.Sqrt((double) num392 * (double) num392 + (double) num393 * (double) num393);
        if ((double) this.ai[2] != 99.0)
        {
          if ((double) num394 > 800.0)
            this.ai[2] = 99f;
        }
        else if ((double) num394 < 400.0)
          this.ai[2] = 0.0f;
        if (!Main.npc[(int) this.ai[1]].active || Main.npc[(int) this.ai[1]].aiStyle != 32)
        {
          this.ai[2] += 10f;
          if ((double) this.ai[2] > 50.0 || Main.netMode != 2)
          {
            this.life = -1;
            this.HitEffect();
            this.active = false;
          }
        }
        if ((double) this.ai[2] == 99.0)
        {
          if ((double) this.position.Y > (double) Main.npc[(int) this.ai[1]].position.Y)
          {
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y -= 0.1f;
            if ((double) this.velocity.Y > 8.0)
              this.velocity.Y = 8f;
          }
          else if ((double) this.position.Y < (double) Main.npc[(int) this.ai[1]].position.Y)
          {
            if ((double) this.velocity.Y < 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y += 0.1f;
            if ((double) this.velocity.Y < -8.0)
              this.velocity.Y = -8f;
          }
          if ((double) this.position.X + (double) (this.width / 2) > (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2))
          {
            if ((double) this.velocity.X > 0.0)
              this.velocity.X *= 0.96f;
            this.velocity.X -= 0.5f;
            if ((double) this.velocity.X > 12.0)
              this.velocity.X = 12f;
          }
          if ((double) this.position.X + (double) (this.width / 2) >= (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2))
            return;
          if ((double) this.velocity.X < 0.0)
            this.velocity.X *= 0.96f;
          this.velocity.X += 0.5f;
          if ((double) this.velocity.X >= -12.0)
            return;
          this.velocity.X = -12f;
        }
        else if ((double) this.ai[2] == 0.0 || (double) this.ai[2] == 3.0)
        {
          if ((double) Main.npc[(int) this.ai[1]].ai[1] == 3.0 && this.timeLeft > 10)
            this.timeLeft = 10;
          if ((double) Main.npc[(int) this.ai[1]].ai[1] != 0.0)
          {
            this.TargetClosest();
            this.TargetClosest();
            if (Main.player[this.target].dead)
            {
              this.velocity.Y += 0.1f;
              if ((double) this.velocity.Y > 16.0)
                this.velocity.Y = 16f;
            }
            else
            {
              Vector2 vector2_12 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
              float num395 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2_12.X;
              float num396 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2_12.Y;
              float num397 = 12f / (float) Math.Sqrt((double) num395 * (double) num395 + (double) num396 * (double) num396);
              float num398 = num395 * num397;
              float num399 = num396 * num397;
              this.rotation = (float) Math.Atan2((double) num399, (double) num398) - 1.57f;
              if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) < 2.0)
              {
                this.rotation = (float) Math.Atan2((double) num399, (double) num398) - 1.57f;
                this.velocity.X = num398;
                this.velocity.Y = num399;
                this.netUpdate = true;
              }
              else
                this.velocity *= 0.97f;
              ++this.ai[3];
              if ((double) this.ai[3] >= 600.0)
              {
                this.ai[2] = 0.0f;
                this.ai[3] = 0.0f;
                this.netUpdate = true;
              }
            }
          }
          else
          {
            ++this.ai[3];
            if ((double) this.ai[3] >= 600.0)
            {
              ++this.ai[2];
              this.ai[3] = 0.0f;
              this.netUpdate = true;
            }
            if ((double) this.position.Y > (double) Main.npc[(int) this.ai[1]].position.Y + 300.0)
            {
              if ((double) this.velocity.Y > 0.0)
                this.velocity.Y *= 0.96f;
              this.velocity.Y -= 0.1f;
              if ((double) this.velocity.Y > 3.0)
                this.velocity.Y = 3f;
            }
            else if ((double) this.position.Y < (double) Main.npc[(int) this.ai[1]].position.Y + 230.0)
            {
              if ((double) this.velocity.Y < 0.0)
                this.velocity.Y *= 0.96f;
              this.velocity.Y += 0.1f;
              if ((double) this.velocity.Y < -3.0)
                this.velocity.Y = -3f;
            }
            if ((double) this.position.X + (double) (this.width / 2) > (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) + 250.0)
            {
              if ((double) this.velocity.X > 0.0)
                this.velocity.X *= 0.94f;
              this.velocity.X -= 0.3f;
              if ((double) this.velocity.X > 9.0)
                this.velocity.X = 9f;
            }
            if ((double) this.position.X + (double) (this.width / 2) < (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2))
            {
              if ((double) this.velocity.X < 0.0)
                this.velocity.X *= 0.94f;
              this.velocity.X += 0.2f;
              if ((double) this.velocity.X < -8.0)
                this.velocity.X = -8f;
            }
          }
          Vector2 vector2_13 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num400 = (float) ((double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 200.0 * (double) this.ai[0]) - vector2_13.X;
          float num401 = Main.npc[(int) this.ai[1]].position.Y + 230f - vector2_13.Y;
          Math.Sqrt((double) num400 * (double) num400 + (double) num401 * (double) num401);
          this.rotation = (float) Math.Atan2((double) num401, (double) num400) + 1.57f;
        }
        else if ((double) this.ai[2] == 1.0)
        {
          if ((double) this.velocity.Y > 0.0)
            this.velocity.Y *= 0.9f;
          Vector2 vector2_14 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num402 = (float) ((double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 280.0 * (double) this.ai[0]) - vector2_14.X;
          float num403 = Main.npc[(int) this.ai[1]].position.Y + 230f - vector2_14.Y;
          float num404 = (float) Math.Sqrt((double) num402 * (double) num402 + (double) num403 * (double) num403);
          this.rotation = (float) Math.Atan2((double) num403, (double) num402) + 1.57f;
          this.velocity.X = (float) (((double) this.velocity.X * 5.0 + (double) Main.npc[(int) this.ai[1]].velocity.X) / 6.0);
          this.velocity.X += 0.5f;
          this.velocity.Y -= 0.5f;
          if ((double) this.velocity.Y < -9.0)
            this.velocity.Y = -9f;
          if ((double) this.position.Y >= (double) Main.npc[(int) this.ai[1]].position.Y - 280.0)
            return;
          this.TargetClosest();
          this.ai[2] = 2f;
          vector2_14 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num405 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2_14.X;
          float num406 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2_14.Y;
          float num407 = 20f / (float) Math.Sqrt((double) num405 * (double) num405 + (double) num406 * (double) num406);
          this.velocity.X = num405 * num407;
          this.velocity.Y = num406 * num407;
          this.netUpdate = true;
        }
        else if ((double) this.ai[2] == 2.0)
        {
          if ((double) this.position.Y <= (double) Main.player[this.target].position.Y && (double) this.velocity.Y >= 0.0)
            return;
          if ((double) this.ai[3] >= 4.0)
          {
            this.ai[2] = 3f;
            this.ai[3] = 0.0f;
          }
          else
          {
            this.ai[2] = 1f;
            ++this.ai[3];
          }
        }
        else if ((double) this.ai[2] == 4.0)
        {
          Vector2 vector2_15 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num408 = (float) ((double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 200.0 * (double) this.ai[0]) - vector2_15.X;
          float num409 = Main.npc[(int) this.ai[1]].position.Y + 230f - vector2_15.Y;
          float num410 = (float) Math.Sqrt((double) num408 * (double) num408 + (double) num409 * (double) num409);
          this.rotation = (float) Math.Atan2((double) num409, (double) num408) + 1.57f;
          this.velocity.Y = (float) (((double) this.velocity.Y * 5.0 + (double) Main.npc[(int) this.ai[1]].velocity.Y) / 6.0);
          this.velocity.X += 0.5f;
          if ((double) this.velocity.X > 12.0)
            this.velocity.X = 12f;
          if ((double) this.position.X + (double) (this.width / 2) >= (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 500.0 && (double) this.position.X + (double) (this.width / 2) <= (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) + 500.0)
            return;
          this.TargetClosest();
          this.ai[2] = 5f;
          vector2_15 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num411 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2_15.X;
          float num412 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2_15.Y;
          float num413 = 17f / (float) Math.Sqrt((double) num411 * (double) num411 + (double) num412 * (double) num412);
          this.velocity.X = num411 * num413;
          this.velocity.Y = num412 * num413;
          this.netUpdate = true;
        }
        else
        {
          if ((double) this.ai[2] != 5.0 || (double) this.position.X + (double) (this.width / 2) >= (double) Main.player[this.target].position.X + (double) (Main.player[this.target].width / 2) - 100.0)
            return;
          if ((double) this.ai[3] >= 4.0)
          {
            this.ai[2] = 0.0f;
            this.ai[3] = 0.0f;
          }
          else
          {
            this.ai[2] = 4f;
            ++this.ai[3];
          }
        }
      }
      else if (this.aiStyle == 35)
      {
        this.spriteDirection = -(int) this.ai[0];
        if (!Main.npc[(int) this.ai[1]].active || Main.npc[(int) this.ai[1]].aiStyle != 32)
        {
          this.ai[2] += 10f;
          if ((double) this.ai[2] > 50.0 || Main.netMode != 2)
          {
            this.life = -1;
            this.HitEffect();
            this.active = false;
          }
        }
        if ((double) this.ai[2] == 0.0)
        {
          if ((double) Main.npc[(int) this.ai[1]].ai[1] == 3.0 && this.timeLeft > 10)
            this.timeLeft = 10;
          if ((double) Main.npc[(int) this.ai[1]].ai[1] != 0.0)
          {
            this.localAI[0] += 2f;
            if ((double) this.position.Y > (double) Main.npc[(int) this.ai[1]].position.Y - 100.0)
            {
              if ((double) this.velocity.Y > 0.0)
                this.velocity.Y *= 0.96f;
              this.velocity.Y -= 0.07f;
              if ((double) this.velocity.Y > 6.0)
                this.velocity.Y = 6f;
            }
            else if ((double) this.position.Y < (double) Main.npc[(int) this.ai[1]].position.Y - 100.0)
            {
              if ((double) this.velocity.Y < 0.0)
                this.velocity.Y *= 0.96f;
              this.velocity.Y += 0.07f;
              if ((double) this.velocity.Y < -6.0)
                this.velocity.Y = -6f;
            }
            if ((double) this.position.X + (double) (this.width / 2) > (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 120.0 * (double) this.ai[0])
            {
              if ((double) this.velocity.X > 0.0)
                this.velocity.X *= 0.96f;
              this.velocity.X -= 0.1f;
              if ((double) this.velocity.X > 8.0)
                this.velocity.X = 8f;
            }
            if ((double) this.position.X + (double) (this.width / 2) < (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 120.0 * (double) this.ai[0])
            {
              if ((double) this.velocity.X < 0.0)
                this.velocity.X *= 0.96f;
              this.velocity.X += 0.1f;
              if ((double) this.velocity.X < -8.0)
                this.velocity.X = -8f;
            }
          }
          else
          {
            ++this.ai[3];
            if ((double) this.ai[3] >= 1100.0)
            {
              this.localAI[0] = 0.0f;
              this.ai[2] = 1f;
              this.ai[3] = 0.0f;
              this.netUpdate = true;
            }
            if ((double) this.position.Y > (double) Main.npc[(int) this.ai[1]].position.Y - 150.0)
            {
              if ((double) this.velocity.Y > 0.0)
                this.velocity.Y *= 0.96f;
              this.velocity.Y -= 0.04f;
              if ((double) this.velocity.Y > 3.0)
                this.velocity.Y = 3f;
            }
            else if ((double) this.position.Y < (double) Main.npc[(int) this.ai[1]].position.Y - 150.0)
            {
              if ((double) this.velocity.Y < 0.0)
                this.velocity.Y *= 0.96f;
              this.velocity.Y += 0.04f;
              if ((double) this.velocity.Y < -3.0)
                this.velocity.Y = -3f;
            }
            if ((double) this.position.X + (double) (this.width / 2) > (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) + 200.0)
            {
              if ((double) this.velocity.X > 0.0)
                this.velocity.X *= 0.96f;
              this.velocity.X -= 0.2f;
              if ((double) this.velocity.X > 8.0)
                this.velocity.X = 8f;
            }
            if ((double) this.position.X + (double) (this.width / 2) < (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) + 160.0)
            {
              if ((double) this.velocity.X < 0.0)
                this.velocity.X *= 0.96f;
              this.velocity.X += 0.2f;
              if ((double) this.velocity.X < -8.0)
                this.velocity.X = -8f;
            }
          }
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num414 = (float) ((double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 200.0 * (double) this.ai[0]) - vector2.X;
          float num415 = Main.npc[(int) this.ai[1]].position.Y + 230f - vector2.Y;
          float num416 = (float) Math.Sqrt((double) num414 * (double) num414 + (double) num415 * (double) num415);
          this.rotation = (float) Math.Atan2((double) num415, (double) num414) + 1.57f;
          if (Main.netMode == 1)
            return;
          ++this.localAI[0];
          if ((double) this.localAI[0] <= 140.0)
            return;
          this.localAI[0] = 0.0f;
          float num417 = 12f;
          int Damage = 0;
          int Type = 102;
          float num418 = num417 / num416;
          float num419 = -num414 * num418;
          float num420 = -num415 * num418;
          float SpeedX = num419 + (float) Main.rand.Next(-40, 41) * 0.01f;
          float SpeedY = num420 + (float) Main.rand.Next(-40, 41) * 0.01f;
          vector2.X += SpeedX * 4f;
          vector2.Y += SpeedY * 4f;
          Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
        }
        else
        {
          if ((double) this.ai[2] != 1.0)
            return;
          ++this.ai[3];
          if ((double) this.ai[3] >= 300.0)
          {
            this.localAI[0] = 0.0f;
            this.ai[2] = 0.0f;
            this.ai[3] = 0.0f;
            this.netUpdate = true;
          }
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num421 = Main.npc[(int) this.ai[1]].position.X + (float) (Main.npc[(int) this.ai[1]].width / 2) - vector2.X;
          float num422 = Main.npc[(int) this.ai[1]].position.Y - vector2.Y;
          float num423 = (float) ((double) Main.player[this.target].position.Y + (double) (Main.player[this.target].height / 2) - 80.0) - vector2.Y;
          float num424 = 6f / (float) Math.Sqrt((double) num421 * (double) num421 + (double) num423 * (double) num423);
          float num425 = num421 * num424;
          float num426 = num423 * num424;
          if ((double) this.velocity.X > (double) num425)
          {
            if ((double) this.velocity.X > 0.0)
              this.velocity.X *= 0.9f;
            this.velocity.X -= 0.04f;
          }
          if ((double) this.velocity.X < (double) num425)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X *= 0.9f;
            this.velocity.X += 0.04f;
          }
          if ((double) this.velocity.Y > (double) num426)
          {
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y *= 0.9f;
            this.velocity.Y -= 0.08f;
          }
          if ((double) this.velocity.Y < (double) num426)
          {
            if ((double) this.velocity.Y < 0.0)
              this.velocity.Y *= 0.9f;
            this.velocity.Y += 0.08f;
          }
          this.TargetClosest();
          vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num427 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
          float num428 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
          float num429 = (float) Math.Sqrt((double) num427 * (double) num427 + (double) num428 * (double) num428);
          this.rotation = (float) Math.Atan2((double) num428, (double) num427) - 1.57f;
          if (Main.netMode == 1)
            return;
          ++this.localAI[0];
          if ((double) this.localAI[0] <= 40.0)
            return;
          this.localAI[0] = 0.0f;
          float num430 = 10f;
          int Damage = 0;
          int Type = 102;
          float num431 = num430 / num429;
          float num432 = num427 * num431;
          float num433 = num428 * num431;
          float SpeedX = num432 + (float) Main.rand.Next(-40, 41) * 0.01f;
          float SpeedY = num433 + (float) Main.rand.Next(-40, 41) * 0.01f;
          vector2.X += SpeedX * 4f;
          vector2.Y += SpeedY * 4f;
          Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
        }
      }
      else if (this.aiStyle == 36)
      {
        this.spriteDirection = -(int) this.ai[0];
        if (!Main.npc[(int) this.ai[1]].active || Main.npc[(int) this.ai[1]].aiStyle != 32)
        {
          this.ai[2] += 10f;
          if ((double) this.ai[2] > 50.0 || Main.netMode != 2)
          {
            this.life = -1;
            this.HitEffect();
            this.active = false;
          }
        }
        if ((double) this.ai[2] == 0.0 || (double) this.ai[2] == 3.0)
        {
          if ((double) Main.npc[(int) this.ai[1]].ai[1] == 3.0 && this.timeLeft > 10)
            this.timeLeft = 10;
          if ((double) Main.npc[(int) this.ai[1]].ai[1] != 0.0)
          {
            this.localAI[0] += 3f;
            if ((double) this.position.Y > (double) Main.npc[(int) this.ai[1]].position.Y - 100.0)
            {
              if ((double) this.velocity.Y > 0.0)
                this.velocity.Y *= 0.96f;
              this.velocity.Y -= 0.07f;
              if ((double) this.velocity.Y > 6.0)
                this.velocity.Y = 6f;
            }
            else if ((double) this.position.Y < (double) Main.npc[(int) this.ai[1]].position.Y - 100.0)
            {
              if ((double) this.velocity.Y < 0.0)
                this.velocity.Y *= 0.96f;
              this.velocity.Y += 0.07f;
              if ((double) this.velocity.Y < -6.0)
                this.velocity.Y = -6f;
            }
            if ((double) this.position.X + (double) (this.width / 2) > (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 120.0 * (double) this.ai[0])
            {
              if ((double) this.velocity.X > 0.0)
                this.velocity.X *= 0.96f;
              this.velocity.X -= 0.1f;
              if ((double) this.velocity.X > 8.0)
                this.velocity.X = 8f;
            }
            if ((double) this.position.X + (double) (this.width / 2) < (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 120.0 * (double) this.ai[0])
            {
              if ((double) this.velocity.X < 0.0)
                this.velocity.X *= 0.96f;
              this.velocity.X += 0.1f;
              if ((double) this.velocity.X < -8.0)
                this.velocity.X = -8f;
            }
          }
          else
          {
            ++this.ai[3];
            if ((double) this.ai[3] >= 800.0)
            {
              ++this.ai[2];
              this.ai[3] = 0.0f;
              this.netUpdate = true;
            }
            if ((double) this.position.Y > (double) Main.npc[(int) this.ai[1]].position.Y - 100.0)
            {
              if ((double) this.velocity.Y > 0.0)
                this.velocity.Y *= 0.96f;
              this.velocity.Y -= 0.1f;
              if ((double) this.velocity.Y > 3.0)
                this.velocity.Y = 3f;
            }
            else if ((double) this.position.Y < (double) Main.npc[(int) this.ai[1]].position.Y - 100.0)
            {
              if ((double) this.velocity.Y < 0.0)
                this.velocity.Y *= 0.96f;
              this.velocity.Y += 0.1f;
              if ((double) this.velocity.Y < -3.0)
                this.velocity.Y = -3f;
            }
            if ((double) this.position.X + (double) (this.width / 2) > (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 180.0 * (double) this.ai[0])
            {
              if ((double) this.velocity.X > 0.0)
                this.velocity.X *= 0.96f;
              this.velocity.X -= 0.14f;
              if ((double) this.velocity.X > 8.0)
                this.velocity.X = 8f;
            }
            if ((double) this.position.X + (double) (this.width / 2) < (double) Main.npc[(int) this.ai[1]].position.X + (double) (Main.npc[(int) this.ai[1]].width / 2) - 180.0 * (double) this.ai[0])
            {
              if ((double) this.velocity.X < 0.0)
                this.velocity.X *= 0.96f;
              this.velocity.X += 0.14f;
              if ((double) this.velocity.X < -8.0)
                this.velocity.X = -8f;
            }
          }
          this.TargetClosest();
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num434 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
          float num435 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
          float num436 = (float) Math.Sqrt((double) num434 * (double) num434 + (double) num435 * (double) num435);
          this.rotation = (float) Math.Atan2((double) num435, (double) num434) - 1.57f;
          if (Main.netMode == 1)
            return;
          ++this.localAI[0];
          if ((double) this.localAI[0] <= 200.0)
            return;
          this.localAI[0] = 0.0f;
          float num437 = 8f;
          int Damage = 25;
          int Type = 100;
          float num438 = num437 / num436;
          float num439 = num434 * num438;
          float num440 = num435 * num438;
          float SpeedX = num439 + (float) Main.rand.Next(-40, 41) * 0.05f;
          float SpeedY = num440 + (float) Main.rand.Next(-40, 41) * 0.05f;
          vector2.X += SpeedX * 8f;
          vector2.Y += SpeedY * 8f;
          Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
        }
        else
        {
          if ((double) this.ai[2] != 1.0)
            return;
          ++this.ai[3];
          if ((double) this.ai[3] >= 200.0)
          {
            this.localAI[0] = 0.0f;
            this.ai[2] = 0.0f;
            this.ai[3] = 0.0f;
            this.netUpdate = true;
          }
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num441 = (float) ((double) Main.player[this.target].position.X + (double) (Main.player[this.target].width / 2) - 350.0) - vector2.X;
          float num442 = (float) ((double) Main.player[this.target].position.Y + (double) (Main.player[this.target].height / 2) - 20.0) - vector2.Y;
          float num443 = 7f / (float) Math.Sqrt((double) num441 * (double) num441 + (double) num442 * (double) num442);
          float num444 = num441 * num443;
          float num445 = num442 * num443;
          if ((double) this.velocity.X > (double) num444)
          {
            if ((double) this.velocity.X > 0.0)
              this.velocity.X *= 0.9f;
            this.velocity.X -= 0.1f;
          }
          if ((double) this.velocity.X < (double) num444)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X *= 0.9f;
            this.velocity.X += 0.1f;
          }
          if ((double) this.velocity.Y > (double) num445)
          {
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y *= 0.9f;
            this.velocity.Y -= 0.03f;
          }
          if ((double) this.velocity.Y < (double) num445)
          {
            if ((double) this.velocity.Y < 0.0)
              this.velocity.Y *= 0.9f;
            this.velocity.Y += 0.03f;
          }
          this.TargetClosest();
          vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num446 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
          float num447 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2) - vector2.Y;
          float num448 = (float) Math.Sqrt((double) num446 * (double) num446 + (double) num447 * (double) num447);
          this.rotation = (float) Math.Atan2((double) num447, (double) num446) - 1.57f;
          if (Main.netMode != 1)
            return;
          ++this.localAI[0];
          if ((double) this.localAI[0] <= 80.0)
            return;
          this.localAI[0] = 0.0f;
          float num449 = 10f;
          int Damage = 25;
          int Type = 100;
          float num450 = num449 / num448;
          float num451 = num446 * num450;
          float num452 = num447 * num450;
          float SpeedX = num451 + (float) Main.rand.Next(-40, 41) * 0.05f;
          float SpeedY = num452 + (float) Main.rand.Next(-40, 41) * 0.05f;
          vector2.X += SpeedX * 8f;
          vector2.Y += SpeedY * 8f;
          Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
        }
      }
      else if (this.aiStyle == 37)
      {
        if ((double) this.ai[3] > 0.0)
          this.realLife = (int) this.ai[3];
        if (this.target < 0 || this.target == (int) byte.MaxValue || Main.player[this.target].dead)
          this.TargetClosest();
        if (this.type > 134)
        {
          bool flag = false;
          if ((double) this.ai[1] <= 0.0)
            flag = true;
          else if (Main.npc[(int) this.ai[1]].life <= 0)
            flag = true;
          if (flag)
          {
            this.life = 0;
            this.HitEffect();
            this.checkDead();
          }
        }
        if (Main.netMode != 1)
        {
          if ((double) this.ai[0] == 0.0 && this.type == 134)
          {
            this.ai[3] = (float) this.whoAmI;
            this.realLife = this.whoAmI;
            int index64 = this.whoAmI;
            int num = 80;
            for (int index65 = 0; index65 <= num; ++index65)
            {
              int Type = 135;
              if (index65 == num)
                Type = 136;
              int number = NPC.NewNPC((int) ((double) this.position.X + (double) (this.width / 2)), (int) ((double) this.position.Y + (double) this.height), Type, this.whoAmI);
              Main.npc[number].ai[3] = (float) this.whoAmI;
              Main.npc[number].realLife = this.whoAmI;
              Main.npc[number].ai[1] = (float) index64;
              Main.npc[index64].ai[0] = (float) number;
              NetMessage.SendData(23, number: number);
              index64 = number;
            }
          }
          if (this.type == 135)
          {
            this.localAI[0] += (float) Main.rand.Next(4);
            if ((double) this.localAI[0] >= (double) Main.rand.Next(1400, 26000))
            {
              this.localAI[0] = 0.0f;
              this.TargetClosest();
              if (Collision.CanHit(this.position, this.width, this.height, Main.player[this.target].position, Main.player[this.target].width, Main.player[this.target].height))
              {
                float num453 = 8f;
                Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) (this.height / 2));
                float num454 = Main.player[this.target].position.X + (float) Main.player[this.target].width * 0.5f - vector2.X + (float) Main.rand.Next(-20, 21);
                float num455 = Main.player[this.target].position.Y + (float) Main.player[this.target].height * 0.5f - vector2.Y + (float) Main.rand.Next(-20, 21);
                float num456 = (float) Math.Sqrt((double) num454 * (double) num454 + (double) num455 * (double) num455);
                float num457 = num453 / num456;
                float num458 = num454 * num457;
                float num459 = num455 * num457;
                float SpeedX = num458 + (float) Main.rand.Next(-20, 21) * 0.05f;
                float SpeedY = num459 + (float) Main.rand.Next(-20, 21) * 0.05f;
                int Damage = 22;
                int Type = 100;
                vector2.X += SpeedX * 5f;
                vector2.Y += SpeedY * 5f;
                int index = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
                Main.projectile[index].timeLeft = 300;
                this.netUpdate = true;
              }
            }
          }
        }
        int num460 = (int) ((double) this.position.X / 16.0) - 1;
        int num461 = (int) (((double) this.position.X + (double) this.width) / 16.0) + 2;
        int num462 = (int) ((double) this.position.Y / 16.0) - 1;
        int num463 = (int) (((double) this.position.Y + (double) this.height) / 16.0) + 2;
        if (num460 < 0)
          num460 = 0;
        if (num461 > Main.maxTilesX)
          num461 = Main.maxTilesX;
        if (num462 < 0)
          num462 = 0;
        if (num463 > Main.maxTilesY)
          num463 = Main.maxTilesY;
        bool flag25 = false;
        if (!flag25)
        {
          for (int index66 = num460; index66 < num461; ++index66)
          {
            for (int index67 = num462; index67 < num463; ++index67)
            {
              if (Main.tile[index66, index67] != null && (Main.tile[index66, index67].active && (Main.tileSolid[(int) Main.tile[index66, index67].type] || Main.tileSolidTop[(int) Main.tile[index66, index67].type] && Main.tile[index66, index67].frameY == (short) 0) || Main.tile[index66, index67].liquid > (byte) 64))
              {
                Vector2 vector2;
                vector2.X = (float) (index66 * 16);
                vector2.Y = (float) (index67 * 16);
                if ((double) this.position.X + (double) this.width > (double) vector2.X && (double) this.position.X < (double) vector2.X + 16.0 && (double) this.position.Y + (double) this.height > (double) vector2.Y && (double) this.position.Y < (double) vector2.Y + 16.0)
                {
                  flag25 = true;
                  break;
                }
              }
            }
          }
        }
        if (!flag25)
        {
          if (this.type != 135 || (double) this.ai[2] != 1.0)
            Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), 0.3f, 0.1f, 0.05f);
          this.localAI[1] = 1f;
          if (this.type == 134)
          {
            Rectangle rectangle3 = new Rectangle((int) this.position.X, (int) this.position.Y, this.width, this.height);
            int num464 = 1000;
            bool flag26 = true;
            if ((double) this.position.Y > (double) Main.player[this.target].position.Y)
            {
              for (int index = 0; index < (int) byte.MaxValue; ++index)
              {
                if (Main.player[index].active)
                {
                  Rectangle rectangle4 = new Rectangle((int) Main.player[index].position.X - num464, (int) Main.player[index].position.Y - num464, num464 * 2, num464 * 2);
                  if (rectangle3.Intersects(rectangle4))
                  {
                    flag26 = false;
                    break;
                  }
                }
              }
              if (flag26)
                flag25 = true;
            }
          }
        }
        else
          this.localAI[1] = 0.0f;
        float num465 = 16f;
        if (Main.dayTime || Main.player[this.target].dead)
        {
          flag25 = false;
          ++this.velocity.Y;
          if ((double) this.position.Y > Main.worldSurface * 16.0)
          {
            ++this.velocity.Y;
            num465 = 32f;
          }
          if ((double) this.position.Y > Main.rockLayer * 16.0)
          {
            for (int index = 0; index < 200; ++index)
            {
              if (Main.npc[index].aiStyle == this.aiStyle)
                Main.npc[index].active = false;
            }
          }
        }
        float num466 = 0.1f;
        float num467 = 0.15f;
        Vector2 vector2_16 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num468 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2);
        float num469 = Main.player[this.target].position.Y + (float) (Main.player[this.target].height / 2);
        float num470 = (float) ((int) ((double) num468 / 16.0) * 16);
        float num471 = (float) ((int) ((double) num469 / 16.0) * 16);
        vector2_16.X = (float) ((int) ((double) vector2_16.X / 16.0) * 16);
        vector2_16.Y = (float) ((int) ((double) vector2_16.Y / 16.0) * 16);
        float num472 = num470 - vector2_16.X;
        float num473 = num471 - vector2_16.Y;
        float num474 = (float) Math.Sqrt((double) num472 * (double) num472 + (double) num473 * (double) num473);
        if ((double) this.ai[1] > 0.0)
        {
          if ((double) this.ai[1] < (double) Main.npc.Length)
          {
            try
            {
              vector2_16 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
              num472 = Main.npc[(int) this.ai[1]].position.X + (float) (Main.npc[(int) this.ai[1]].width / 2) - vector2_16.X;
              num473 = Main.npc[(int) this.ai[1]].position.Y + (float) (Main.npc[(int) this.ai[1]].height / 2) - vector2_16.Y;
            }
            catch
            {
            }
            this.rotation = (float) Math.Atan2((double) num473, (double) num472) + 1.57f;
            float num475 = (float) Math.Sqrt((double) num472 * (double) num472 + (double) num473 * (double) num473);
            int num476 = (int) (44.0 * (double) this.scale);
            float num477 = (num475 - (float) num476) / num475;
            float num478 = num472 * num477;
            float num479 = num473 * num477;
            this.velocity = new Vector2();
            this.position.X += num478;
            this.position.Y += num479;
            return;
          }
        }
        if (!flag25)
        {
          this.TargetClosest();
          this.velocity.Y += 0.15f;
          if ((double) this.velocity.Y > (double) num465)
            this.velocity.Y = num465;
          if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) < (double) num465 * 0.4)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X -= num466 * 1.1f;
            else
              this.velocity.X += num466 * 1.1f;
          }
          else if ((double) this.velocity.Y == (double) num465)
          {
            if ((double) this.velocity.X < (double) num472)
              this.velocity.X += num466;
            else if ((double) this.velocity.X > (double) num472)
              this.velocity.X -= num466;
          }
          else if ((double) this.velocity.Y > 4.0)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X += num466 * 0.9f;
            else
              this.velocity.X -= num466 * 0.9f;
          }
        }
        else
        {
          if (this.soundDelay == 0)
          {
            float num480 = num474 / 40f;
            if ((double) num480 < 10.0)
              num480 = 10f;
            if ((double) num480 > 20.0)
              num480 = 20f;
            this.soundDelay = (int) num480;
            Main.PlaySound(15, (int) this.position.X, (int) this.position.Y);
          }
          float num481 = (float) Math.Sqrt((double) num472 * (double) num472 + (double) num473 * (double) num473);
          float num482 = Math.Abs(num472);
          float num483 = Math.Abs(num473);
          float num484 = num465 / num481;
          float num485 = num472 * num484;
          float num486 = num473 * num484;
          if (((double) this.velocity.X > 0.0 && (double) num485 > 0.0 || (double) this.velocity.X < 0.0 && (double) num485 < 0.0) && ((double) this.velocity.Y > 0.0 && (double) num486 > 0.0 || (double) this.velocity.Y < 0.0 && (double) num486 < 0.0))
          {
            if ((double) this.velocity.X < (double) num485)
              this.velocity.X += num467;
            else if ((double) this.velocity.X > (double) num485)
              this.velocity.X -= num467;
            if ((double) this.velocity.Y < (double) num486)
              this.velocity.Y += num467;
            else if ((double) this.velocity.Y > (double) num486)
              this.velocity.Y -= num467;
          }
          if ((double) this.velocity.X > 0.0 && (double) num485 > 0.0 || (double) this.velocity.X < 0.0 && (double) num485 < 0.0 || (double) this.velocity.Y > 0.0 && (double) num486 > 0.0 || (double) this.velocity.Y < 0.0 && (double) num486 < 0.0)
          {
            if ((double) this.velocity.X < (double) num485)
              this.velocity.X += num466;
            else if ((double) this.velocity.X > (double) num485)
              this.velocity.X -= num466;
            if ((double) this.velocity.Y < (double) num486)
              this.velocity.Y += num466;
            else if ((double) this.velocity.Y > (double) num486)
              this.velocity.Y -= num466;
            if ((double) Math.Abs(num486) < (double) num465 * 0.2 && ((double) this.velocity.X > 0.0 && (double) num485 < 0.0 || (double) this.velocity.X < 0.0 && (double) num485 > 0.0))
            {
              if ((double) this.velocity.Y > 0.0)
                this.velocity.Y += num466 * 2f;
              else
                this.velocity.Y -= num466 * 2f;
            }
            if ((double) Math.Abs(num485) < (double) num465 * 0.2 && ((double) this.velocity.Y > 0.0 && (double) num486 < 0.0 || (double) this.velocity.Y < 0.0 && (double) num486 > 0.0))
            {
              if ((double) this.velocity.X > 0.0)
                this.velocity.X += num466 * 2f;
              else
                this.velocity.X -= num466 * 2f;
            }
          }
          else if ((double) num482 > (double) num483)
          {
            if ((double) this.velocity.X < (double) num485)
              this.velocity.X += num466 * 1.1f;
            else if ((double) this.velocity.X > (double) num485)
              this.velocity.X -= num466 * 1.1f;
            if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) < (double) num465 * 0.5)
            {
              if ((double) this.velocity.Y > 0.0)
                this.velocity.Y += num466;
              else
                this.velocity.Y -= num466;
            }
          }
          else
          {
            if ((double) this.velocity.Y < (double) num486)
              this.velocity.Y += num466 * 1.1f;
            else if ((double) this.velocity.Y > (double) num486)
              this.velocity.Y -= num466 * 1.1f;
            if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) < (double) num465 * 0.5)
            {
              if ((double) this.velocity.X > 0.0)
                this.velocity.X += num466;
              else
                this.velocity.X -= num466;
            }
          }
        }
        this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 1.57f;
        if (this.type != 134)
          return;
        if (flag25)
        {
          if ((double) this.localAI[0] != 1.0)
            this.netUpdate = true;
          this.localAI[0] = 1f;
        }
        else
        {
          if ((double) this.localAI[0] != 0.0)
            this.netUpdate = true;
          this.localAI[0] = 0.0f;
        }
        if (((double) this.velocity.X <= 0.0 || (double) this.oldVelocity.X >= 0.0) && ((double) this.velocity.X >= 0.0 || (double) this.oldVelocity.X <= 0.0) && ((double) this.velocity.Y <= 0.0 || (double) this.oldVelocity.Y >= 0.0) && ((double) this.velocity.Y >= 0.0 || (double) this.oldVelocity.Y <= 0.0) || this.justHit)
          return;
        this.netUpdate = true;
      }
      else
      {
        if (this.aiStyle != 38)
          return;
        float num487 = 4f;
        float num488 = 1f;
        if (this.type == 143)
        {
          num487 = 3f;
          num488 = 0.7f;
        }
        if (this.type == 145)
        {
          num487 = 3.5f;
          num488 = 0.8f;
        }
        if (this.type == 143)
        {
          ++this.ai[2];
          if ((double) this.ai[2] >= 120.0)
          {
            this.ai[2] = 0.0f;
            if (Main.netMode != 1)
            {
              Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f - (float) (this.direction * 12), this.position.Y + (float) this.height * 0.5f);
              float SpeedX = (float) (12 * this.spriteDirection);
              float SpeedY = 0.0f;
              if (Main.netMode != 1)
              {
                int Damage = 25;
                int Type = 110;
                int number = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
                Main.projectile[number].ai[0] = 2f;
                Main.projectile[number].timeLeft = 300;
                Main.projectile[number].friendly = false;
                NetMessage.SendData(27, number: number);
                this.netUpdate = true;
              }
            }
          }
        }
        if (this.type == 144 && (double) this.ai[1] >= 3.0)
        {
          this.TargetClosest();
          this.spriteDirection = this.direction;
          if ((double) this.velocity.Y == 0.0)
          {
            this.velocity.X *= 0.9f;
            ++this.ai[2];
            if ((double) this.velocity.X > -0.3 && (double) this.velocity.X < 0.3)
              this.velocity.X = 0.0f;
            if ((double) this.ai[2] >= 200.0)
            {
              this.ai[2] = 0.0f;
              this.ai[1] = 0.0f;
            }
          }
        }
        else if (this.type == 145 && (double) this.ai[1] >= 3.0)
        {
          this.TargetClosest();
          if ((double) this.velocity.Y == 0.0)
          {
            this.velocity.X *= 0.9f;
            ++this.ai[2];
            if ((double) this.velocity.X > -0.3 && (double) this.velocity.X < 0.3)
              this.velocity.X = 0.0f;
            if ((double) this.ai[2] >= 16.0)
            {
              this.ai[2] = 0.0f;
              this.ai[1] = 0.0f;
            }
          }
          if ((double) this.velocity.X == 0.0 && (double) this.velocity.Y == 0.0 && (double) this.ai[2] == 8.0)
          {
            float num489 = 10f;
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f - (float) (this.direction * 12), this.position.Y + (float) this.height * 0.25f);
            float num490 = Main.player[this.target].position.X + (float) (Main.player[this.target].width / 2) - vector2.X;
            float num491 = Main.player[this.target].position.Y - vector2.Y;
            float num492 = (float) Math.Sqrt((double) num490 * (double) num490 + (double) num491 * (double) num491);
            float num493 = num489 / num492;
            float SpeedX = num490 * num493;
            float SpeedY = num491 * num493;
            if (Main.netMode != 1)
            {
              int Damage = 35;
              int Type = 109;
              int number = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer);
              Main.projectile[number].ai[0] = 2f;
              Main.projectile[number].timeLeft = 300;
              Main.projectile[number].friendly = false;
              NetMessage.SendData(27, number: number);
              this.netUpdate = true;
            }
          }
        }
        else
        {
          if ((double) this.velocity.Y == 0.0)
          {
            if ((double) this.localAI[2] == (double) this.position.X)
            {
              this.direction *= -1;
              this.ai[3] = 60f;
            }
            this.localAI[2] = this.position.X;
            if ((double) this.ai[3] == 0.0)
              this.TargetClosest();
            ++this.ai[0];
            if ((double) this.ai[0] > 2.0)
            {
              this.ai[0] = 0.0f;
              ++this.ai[1];
              this.velocity.Y = -8.2f;
              this.velocity.X += (float) ((double) this.direction * (double) num488 * 1.10000002384186);
            }
            else
            {
              this.velocity.Y = -6f;
              this.velocity.X += (float) ((double) this.direction * (double) num488 * 0.899999976158142);
            }
            this.spriteDirection = this.direction;
          }
          this.velocity.X += (float) ((double) this.direction * (double) num488 * 0.00999999977648258);
        }
        if ((double) this.ai[3] > 0.0)
          --this.ai[3];
        if ((double) this.velocity.X > (double) num487 && this.direction > 0)
          this.velocity.X = 4f;
        if ((double) this.velocity.X >= -(double) num487 || this.direction >= 0)
          return;
        this.velocity.X = -4f;
      }
    }

    public void FindFrame()
    {
      int num1 = 1;
      if (!Main.dedServ)
        num1 = Main.npcTexture[this.type].Height / Main.npcFrameCount[this.type];
      int num2 = 0;
      if (this.aiAction == 0)
        num2 = (double) this.velocity.Y >= 0.0 ? ((double) this.velocity.Y <= 0.0 ? ((double) this.velocity.X == 0.0 ? 0 : 1) : 3) : 2;
      else if (this.aiAction == 1)
        num2 = 4;
      if (this.type == 1 || this.type == 16 || this.type == 59 || this.type == 71 || this.type == 81 || this.type == 138)
      {
        ++this.frameCounter;
        if (num2 > 0)
          ++this.frameCounter;
        if (num2 == 4)
          ++this.frameCounter;
        if (this.frameCounter >= 8.0)
        {
          this.frame.Y += num1;
          this.frameCounter = 0.0;
        }
        if (this.frame.Y >= num1 * Main.npcFrameCount[this.type])
          this.frame.Y = 0;
      }
      if (this.type == 141)
      {
        this.spriteDirection = this.direction;
        if ((double) this.velocity.Y != 0.0)
        {
          this.frame.Y = num1 * 2;
        }
        else
        {
          ++this.frameCounter;
          if (this.frameCounter >= 8.0)
          {
            this.frame.Y += num1;
            this.frameCounter = 0.0;
          }
          if (this.frame.Y > num1)
            this.frame.Y = 0;
        }
      }
      if (this.type == 143)
      {
        if ((double) this.velocity.Y > 0.0)
          ++this.frameCounter;
        else if ((double) this.velocity.Y < 0.0)
          --this.frameCounter;
        if (this.frameCounter < 6.0)
          this.frame.Y = num1;
        else if (this.frameCounter < 12.0)
          this.frame.Y = num1 * 2;
        else if (this.frameCounter < 18.0)
          this.frame.Y = num1 * 3;
        if (this.frameCounter < 0.0)
          this.frameCounter = 0.0;
        if (this.frameCounter > 17.0)
          this.frameCounter = 17.0;
      }
      if (this.type == 144)
      {
        if ((double) this.velocity.X == 0.0 && (double) this.velocity.Y == 0.0)
        {
          ++this.localAI[3];
          if ((double) this.localAI[3] < 6.0)
            this.frame.Y = 0;
          else if ((double) this.localAI[3] < 12.0)
            this.frame.Y = num1;
          if ((double) this.localAI[3] >= 11.0)
            this.localAI[3] = 0.0f;
        }
        else
        {
          if ((double) this.velocity.Y > 0.0)
            ++this.frameCounter;
          else if ((double) this.velocity.Y < 0.0)
            --this.frameCounter;
          if (this.frameCounter < 6.0)
            this.frame.Y = num1 * 2;
          else if (this.frameCounter < 12.0)
            this.frame.Y = num1 * 3;
          else if (this.frameCounter < 18.0)
            this.frame.Y = num1 * 4;
          if (this.frameCounter < 0.0)
            this.frameCounter = 0.0;
          if (this.frameCounter > 17.0)
            this.frameCounter = 17.0;
        }
      }
      if (this.type == 145)
      {
        if ((double) this.velocity.X == 0.0 && (double) this.velocity.Y == 0.0)
        {
          if ((double) this.ai[2] < 4.0)
            this.frame.Y = 0;
          else if ((double) this.ai[2] < 8.0)
            this.frame.Y = num1;
          else if ((double) this.ai[2] < 12.0)
            this.frame.Y = num1 * 2;
          else if ((double) this.ai[2] < 16.0)
            this.frame.Y = num1 * 3;
        }
        else
        {
          if ((double) this.velocity.Y > 0.0)
            ++this.frameCounter;
          else if ((double) this.velocity.Y < 0.0)
            --this.frameCounter;
          if (this.frameCounter < 6.0)
            this.frame.Y = num1 * 4;
          else if (this.frameCounter < 12.0)
            this.frame.Y = num1 * 5;
          else if (this.frameCounter < 18.0)
            this.frame.Y = num1 * 6;
          if (this.frameCounter < 0.0)
            this.frameCounter = 0.0;
          if (this.frameCounter > 17.0)
            this.frameCounter = 17.0;
        }
      }
      if (this.type == 50)
      {
        if ((double) this.velocity.Y != 0.0)
        {
          this.frame.Y = num1 * 4;
        }
        else
        {
          ++this.frameCounter;
          if (num2 > 0)
            ++this.frameCounter;
          if (num2 == 4)
            ++this.frameCounter;
          if (this.frameCounter >= 8.0)
          {
            this.frame.Y += num1;
            this.frameCounter = 0.0;
          }
          if (this.frame.Y >= num1 * 4)
            this.frame.Y = 0;
        }
      }
      if (this.type == 135)
        this.frame.Y = (double) this.ai[2] != 0.0 ? num1 : 0;
      if (this.type == 85)
      {
        if ((double) this.ai[0] == 0.0)
        {
          this.frameCounter = 0.0;
          this.frame.Y = 0;
        }
        else
        {
          int num3 = 3;
          if ((double) this.velocity.Y == 0.0)
            --this.frameCounter;
          else
            ++this.frameCounter;
          if (this.frameCounter < 0.0)
            this.frameCounter = 0.0;
          if (this.frameCounter > (double) (num3 * 4))
            this.frameCounter = (double) (num3 * 4);
          if (this.frameCounter < (double) num3)
            this.frame.Y = num1;
          else if (this.frameCounter < (double) (num3 * 2))
            this.frame.Y = num1 * 2;
          else if (this.frameCounter < (double) (num3 * 3))
            this.frame.Y = num1 * 3;
          else if (this.frameCounter < (double) (num3 * 4))
            this.frame.Y = num1 * 4;
          else if (this.frameCounter < (double) (num3 * 5))
            this.frame.Y = num1 * 5;
          else if (this.frameCounter < (double) (num3 * 6))
            this.frame.Y = num1 * 4;
          else if (this.frameCounter < (double) (num3 * 7))
          {
            this.frame.Y = num1 * 3;
          }
          else
          {
            this.frame.Y = num1 * 2;
            if (this.frameCounter >= (double) (num3 * 8))
              this.frameCounter = (double) num3;
          }
        }
        if ((double) this.ai[3] == 2.0)
          this.frame.Y += num1 * 6;
        else if ((double) this.ai[3] == 3.0)
          this.frame.Y += num1 * 12;
      }
      if (this.type == 113 || this.type == 114)
      {
        if ((double) this.ai[2] == 0.0)
        {
          ++this.frameCounter;
          if (this.frameCounter >= 12.0)
          {
            this.frame.Y += num1;
            this.frameCounter = 0.0;
          }
          if (this.frame.Y >= num1 * Main.npcFrameCount[this.type])
            this.frame.Y = 0;
        }
        else
        {
          this.frame.Y = 0;
          this.frameCounter = -60.0;
        }
      }
      if (this.type == 61)
      {
        this.spriteDirection = this.direction;
        this.rotation = this.velocity.X * 0.1f;
        if ((double) this.velocity.X == 0.0 && (double) this.velocity.Y == 0.0)
        {
          this.frame.Y = 0;
          this.frameCounter = 0.0;
        }
        else
        {
          ++this.frameCounter;
          if (this.frameCounter < 4.0)
          {
            this.frame.Y = num1;
          }
          else
          {
            this.frame.Y = num1 * 2;
            if (this.frameCounter >= 7.0)
              this.frameCounter = 0.0;
          }
        }
      }
      if (this.type == 122)
      {
        this.spriteDirection = this.direction;
        this.rotation = this.velocity.X * 0.05f;
        if ((double) this.ai[3] > 0.0)
        {
          int num4 = (int) ((double) this.ai[3] / 8.0);
          this.frameCounter = 0.0;
          this.frame.Y = (num4 + 3) * num1;
        }
        else
        {
          ++this.frameCounter;
          if (this.frameCounter >= 8.0)
          {
            this.frame.Y += num1;
            this.frameCounter = 0.0;
          }
          if (this.frame.Y >= num1 * 3)
            this.frame.Y = 0;
        }
      }
      if (this.type == 74)
      {
        this.spriteDirection = this.direction;
        this.rotation = this.velocity.X * 0.1f;
        if ((double) this.velocity.X == 0.0 && (double) this.velocity.Y == 0.0)
        {
          this.frame.Y = num1 * 4;
          this.frameCounter = 0.0;
        }
        else
        {
          ++this.frameCounter;
          if (this.frameCounter >= 4.0)
          {
            this.frame.Y += num1;
            this.frameCounter = 0.0;
          }
          if (this.frame.Y >= num1 * Main.npcFrameCount[this.type])
            this.frame.Y = 0;
        }
      }
      if (this.type == 62 || this.type == 66)
      {
        this.spriteDirection = this.direction;
        this.rotation = this.velocity.X * 0.1f;
        ++this.frameCounter;
        if (this.frameCounter < 6.0)
        {
          this.frame.Y = 0;
        }
        else
        {
          this.frame.Y = num1;
          if (this.frameCounter >= 11.0)
            this.frameCounter = 0.0;
        }
      }
      if (this.type == 63 || this.type == 64 || this.type == 103)
      {
        ++this.frameCounter;
        if (this.frameCounter < 6.0)
          this.frame.Y = 0;
        else if (this.frameCounter < 12.0)
          this.frame.Y = num1;
        else if (this.frameCounter < 18.0)
        {
          this.frame.Y = num1 * 2;
        }
        else
        {
          this.frame.Y = num1 * 3;
          if (this.frameCounter >= 23.0)
            this.frameCounter = 0.0;
        }
      }
      if (this.type == 2 || this.type == 23 || this.type == 121)
      {
        if (this.type == 2)
        {
          if ((double) this.velocity.X > 0.0)
          {
            this.spriteDirection = 1;
            this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X);
          }
          if ((double) this.velocity.X < 0.0)
          {
            this.spriteDirection = -1;
            this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 3.14f;
          }
        }
        else if (this.type == 2 || this.type == 121)
        {
          if ((double) this.velocity.X > 0.0)
            this.spriteDirection = 1;
          if ((double) this.velocity.X < 0.0)
            this.spriteDirection = -1;
          this.rotation = this.velocity.X * 0.1f;
        }
        ++this.frameCounter;
        if (this.frameCounter >= 8.0)
        {
          this.frame.Y += num1;
          this.frameCounter = 0.0;
        }
        if (this.frame.Y >= num1 * Main.npcFrameCount[this.type])
          this.frame.Y = 0;
      }
      if (this.type == 133)
      {
        if ((double) this.velocity.X > 0.0)
        {
          this.spriteDirection = 1;
          this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X);
        }
        if ((double) this.velocity.X < 0.0)
        {
          this.spriteDirection = -1;
          this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 3.14f;
        }
        ++this.frameCounter;
        this.frame.Y = this.frameCounter < 8.0 ? 0 : num1;
        if (this.frameCounter >= 16.0)
        {
          this.frame.Y = 0;
          this.frameCounter = 0.0;
        }
        if ((double) this.life < (double) this.lifeMax * 0.5)
          this.frame.Y += num1 * 2;
      }
      if (this.type == 116)
      {
        if ((double) this.velocity.X > 0.0)
        {
          this.spriteDirection = 1;
          this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X);
        }
        if ((double) this.velocity.X < 0.0)
        {
          this.spriteDirection = -1;
          this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 3.14f;
        }
        ++this.frameCounter;
        if (this.frameCounter >= 5.0)
        {
          this.frame.Y += num1;
          this.frameCounter = 0.0;
        }
        if (this.frame.Y >= num1 * Main.npcFrameCount[this.type])
          this.frame.Y = 0;
      }
      if (this.type == 75)
      {
        this.spriteDirection = (double) this.velocity.X <= 0.0 ? -1 : 1;
        this.rotation = this.velocity.X * 0.1f;
        ++this.frameCounter;
        if (this.frameCounter >= 4.0)
        {
          this.frame.Y += num1;
          this.frameCounter = 0.0;
        }
        if (this.frame.Y >= num1 * Main.npcFrameCount[this.type])
          this.frame.Y = 0;
      }
      if (this.type == 55 || this.type == 57 || this.type == 58 || this.type == 102)
      {
        this.spriteDirection = this.direction;
        ++this.frameCounter;
        if (this.wet)
        {
          if (this.frameCounter < 6.0)
            this.frame.Y = 0;
          else if (this.frameCounter < 12.0)
            this.frame.Y = num1;
          else if (this.frameCounter < 18.0)
            this.frame.Y = num1 * 2;
          else if (this.frameCounter < 24.0)
            this.frame.Y = num1 * 3;
          else
            this.frameCounter = 0.0;
        }
        else if (this.frameCounter < 6.0)
          this.frame.Y = num1 * 4;
        else if (this.frameCounter < 12.0)
          this.frame.Y = num1 * 5;
        else
          this.frameCounter = 0.0;
      }
      if (this.type == 69)
      {
        if ((double) this.ai[0] < 190.0)
        {
          ++this.frameCounter;
          if (this.frameCounter >= 6.0)
          {
            this.frameCounter = 0.0;
            this.frame.Y += num1;
            if (this.frame.Y / num1 >= Main.npcFrameCount[this.type] - 1)
              this.frame.Y = 0;
          }
        }
        else
        {
          this.frameCounter = 0.0;
          this.frame.Y = num1 * (Main.npcFrameCount[this.type] - 1);
        }
      }
      if (this.type == 86)
      {
        if ((double) this.velocity.Y == 0.0 || this.wet)
          this.spriteDirection = (double) this.velocity.X >= -2.0 ? ((double) this.velocity.X <= 2.0 ? this.direction : 1) : -1;
        if ((double) this.velocity.Y != 0.0)
        {
          this.frame.Y = num1 * 15;
          this.frameCounter = 0.0;
        }
        else if ((double) this.velocity.X == 0.0)
        {
          this.frameCounter = 0.0;
          this.frame.Y = 0;
        }
        else if ((double) Math.Abs(this.velocity.X) < 3.0)
        {
          this.frameCounter += (double) Math.Abs(this.velocity.X);
          if (this.frameCounter >= 6.0)
          {
            this.frameCounter = 0.0;
            this.frame.Y += num1;
            if (this.frame.Y / num1 >= 9)
              this.frame.Y = num1;
            if (this.frame.Y / num1 <= 0)
              this.frame.Y = num1;
          }
        }
        else
        {
          this.frameCounter += (double) Math.Abs(this.velocity.X);
          if (this.frameCounter >= 10.0)
          {
            this.frameCounter = 0.0;
            this.frame.Y += num1;
            if (this.frame.Y / num1 >= 15)
              this.frame.Y = num1 * 9;
            if (this.frame.Y / num1 <= 8)
              this.frame.Y = num1 * 9;
          }
        }
      }
      if (this.type == (int) sbyte.MaxValue)
      {
        if ((double) this.ai[1] == 0.0)
        {
          ++this.frameCounter;
          if (this.frameCounter >= 12.0)
          {
            this.frameCounter = 0.0;
            this.frame.Y += num1;
            if (this.frame.Y / num1 >= 2)
              this.frame.Y = 0;
          }
        }
        else
        {
          this.frameCounter = 0.0;
          this.frame.Y = num1 * 2;
        }
      }
      if (this.type == 129)
      {
        if ((double) this.velocity.Y == 0.0)
          this.spriteDirection = this.direction;
        ++this.frameCounter;
        if (this.frameCounter >= 2.0)
        {
          this.frameCounter = 0.0;
          this.frame.Y += num1;
          if (this.frame.Y / num1 >= Main.npcFrameCount[this.type])
            this.frame.Y = 0;
        }
      }
      if (this.type == 130)
      {
        if ((double) this.velocity.Y == 0.0)
          this.spriteDirection = this.direction;
        ++this.frameCounter;
        if (this.frameCounter >= 8.0)
        {
          this.frameCounter = 0.0;
          this.frame.Y += num1;
          if (this.frame.Y / num1 >= Main.npcFrameCount[this.type])
            this.frame.Y = 0;
        }
      }
      if (this.type == 67)
      {
        if ((double) this.velocity.Y == 0.0)
          this.spriteDirection = this.direction;
        ++this.frameCounter;
        if (this.frameCounter >= 6.0)
        {
          this.frameCounter = 0.0;
          this.frame.Y += num1;
          if (this.frame.Y / num1 >= Main.npcFrameCount[this.type])
            this.frame.Y = 0;
        }
      }
      if (this.type == 109)
      {
        if ((double) this.velocity.Y == 0.0 && ((double) this.velocity.X <= 0.0 && this.direction < 0 || (double) this.velocity.X >= 0.0 && this.direction > 0))
          this.spriteDirection = this.direction;
        this.frameCounter += (double) Math.Abs(this.velocity.X);
        if (this.frameCounter >= 7.0)
        {
          this.frameCounter -= 7.0;
          this.frame.Y += num1;
          if (this.frame.Y / num1 >= Main.npcFrameCount[this.type])
            this.frame.Y = 0;
        }
      }
      if (this.type == 83 || this.type == 84)
      {
        if ((double) this.ai[0] == 2.0)
        {
          this.frameCounter = 0.0;
          this.frame.Y = 0;
        }
        else
        {
          ++this.frameCounter;
          if (this.frameCounter >= 4.0)
          {
            this.frameCounter = 0.0;
            this.frame.Y += num1;
            if (this.frame.Y / num1 >= Main.npcFrameCount[this.type])
              this.frame.Y = 0;
          }
        }
      }
      if (this.type == 72)
      {
        ++this.frameCounter;
        if (this.frameCounter >= 3.0)
        {
          this.frameCounter = 0.0;
          this.frame.Y += num1;
          if (this.frame.Y / num1 >= Main.npcFrameCount[this.type])
            this.frame.Y = 0;
        }
      }
      if (this.type == 65)
      {
        this.spriteDirection = this.direction;
        ++this.frameCounter;
        if (this.wet)
        {
          if (this.frameCounter < 6.0)
            this.frame.Y = 0;
          else if (this.frameCounter < 12.0)
            this.frame.Y = num1;
          else if (this.frameCounter < 18.0)
            this.frame.Y = num1 * 2;
          else if (this.frameCounter < 24.0)
            this.frame.Y = num1 * 3;
          else
            this.frameCounter = 0.0;
        }
      }
      if (this.type == 48 || this.type == 49 || this.type == 51 || this.type == 60 || this.type == 82 || this.type == 93 || this.type == 137)
      {
        if ((double) this.velocity.X > 0.0)
          this.spriteDirection = 1;
        if ((double) this.velocity.X < 0.0)
          this.spriteDirection = -1;
        this.rotation = this.velocity.X * 0.1f;
        ++this.frameCounter;
        if (this.frameCounter >= 6.0)
        {
          this.frame.Y += num1;
          this.frameCounter = 0.0;
        }
        if (this.frame.Y >= num1 * 4)
          this.frame.Y = 0;
      }
      if (this.type == 42)
      {
        ++this.frameCounter;
        if (this.frameCounter < 2.0)
          this.frame.Y = 0;
        else if (this.frameCounter < 4.0)
          this.frame.Y = num1;
        else if (this.frameCounter < 6.0)
          this.frame.Y = num1 * 2;
        else if (this.frameCounter < 8.0)
          this.frame.Y = num1;
        else
          this.frameCounter = 0.0;
      }
      if (this.type == 43 || this.type == 56)
      {
        ++this.frameCounter;
        if (this.frameCounter < 6.0)
          this.frame.Y = 0;
        else if (this.frameCounter < 12.0)
          this.frame.Y = num1;
        else if (this.frameCounter < 18.0)
          this.frame.Y = num1 * 2;
        else if (this.frameCounter < 24.0)
          this.frame.Y = num1;
        if (this.frameCounter == 23.0)
          this.frameCounter = 0.0;
      }
      if (this.type == 115)
      {
        ++this.frameCounter;
        if (this.frameCounter < 3.0)
          this.frame.Y = 0;
        else if (this.frameCounter < 6.0)
          this.frame.Y = num1;
        else if (this.frameCounter < 12.0)
          this.frame.Y = num1 * 2;
        else if (this.frameCounter < 15.0)
          this.frame.Y = num1;
        if (this.frameCounter == 15.0)
          this.frameCounter = 0.0;
      }
      if (this.type == 101)
      {
        ++this.frameCounter;
        if (this.frameCounter > 6.0)
        {
          this.frame.Y += num1 * 2;
          this.frameCounter = 0.0;
        }
        if (this.frame.Y > num1 * 2)
          this.frame.Y = 0;
      }
      if (this.type == 17 || this.type == 18 || this.type == 19 || this.type == 20 || this.type == 22 || this.type == 142 || this.type == 38 || this.type == 26 || this.type == 27 || this.type == 28 || this.type == 31 || this.type == 21 || this.type == 44 || this.type == 54 || this.type == 37 || this.type == 73 || this.type == 77 || this.type == 78 || this.type == 79 || this.type == 80 || this.type == 104 || this.type == 107 || this.type == 108 || this.type == 120 || this.type == 124 || this.type == 140)
      {
        if ((double) this.velocity.Y == 0.0)
        {
          if (this.direction == 1)
            this.spriteDirection = 1;
          if (this.direction == -1)
            this.spriteDirection = -1;
          if ((double) this.velocity.X == 0.0)
          {
            if (this.type == 140)
            {
              this.frame.Y = num1;
              this.frameCounter = 0.0;
            }
            else
            {
              this.frame.Y = 0;
              this.frameCounter = 0.0;
            }
          }
          else
          {
            this.frameCounter += (double) Math.Abs(this.velocity.X) * 2.0;
            ++this.frameCounter;
            if (this.frameCounter > 6.0)
            {
              this.frame.Y += num1;
              this.frameCounter = 0.0;
            }
            if (this.frame.Y / num1 >= Main.npcFrameCount[this.type])
              this.frame.Y = num1 * 2;
          }
        }
        else
        {
          this.frameCounter = 0.0;
          this.frame.Y = num1;
          if (this.type == 21 || this.type == 31 || this.type == 44 || this.type == 77 || this.type == 78 || this.type == 79 || this.type == 80 || this.type == 120 || this.type == 140)
            this.frame.Y = 0;
        }
      }
      else if (this.type == 110)
      {
        if ((double) this.velocity.Y == 0.0)
        {
          if (this.direction == 1)
            this.spriteDirection = 1;
          if (this.direction == -1)
            this.spriteDirection = -1;
          if ((double) this.ai[2] > 0.0)
          {
            this.spriteDirection = this.direction;
            this.frame.Y = num1 * (int) this.ai[2];
            this.frameCounter = 0.0;
          }
          else
          {
            if (this.frame.Y < num1 * 6)
              this.frame.Y = num1 * 6;
            this.frameCounter += (double) Math.Abs(this.velocity.X) * 2.0;
            this.frameCounter += (double) this.velocity.X;
            if (this.frameCounter > 6.0)
            {
              this.frame.Y += num1;
              this.frameCounter = 0.0;
            }
            if (this.frame.Y / num1 >= Main.npcFrameCount[this.type])
              this.frame.Y = num1 * 6;
          }
        }
        else
        {
          this.frameCounter = 0.0;
          this.frame.Y = 0;
        }
      }
      if (this.type == 111)
      {
        if ((double) this.velocity.Y == 0.0)
        {
          if (this.direction == 1)
            this.spriteDirection = 1;
          if (this.direction == -1)
            this.spriteDirection = -1;
          if ((double) this.ai[2] > 0.0)
          {
            this.spriteDirection = this.direction;
            this.frame.Y = num1 * ((int) this.ai[2] - 1);
            this.frameCounter = 0.0;
          }
          else
          {
            if (this.frame.Y < num1 * 7)
              this.frame.Y = num1 * 7;
            this.frameCounter += (double) Math.Abs(this.velocity.X) * 2.0;
            this.frameCounter += (double) this.velocity.X * 1.29999995231628;
            if (this.frameCounter > 6.0)
            {
              this.frame.Y += num1;
              this.frameCounter = 0.0;
            }
            if (this.frame.Y / num1 >= Main.npcFrameCount[this.type])
              this.frame.Y = num1 * 7;
          }
        }
        else
        {
          this.frameCounter = 0.0;
          this.frame.Y = num1 * 6;
        }
      }
      else if (this.type == 3 || this.type == 52 || this.type == 53 || this.type == 132)
      {
        if ((double) this.velocity.Y == 0.0)
        {
          if (this.direction == 1)
            this.spriteDirection = 1;
          if (this.direction == -1)
            this.spriteDirection = -1;
        }
        if ((double) this.velocity.Y != 0.0 || this.direction == -1 && (double) this.velocity.X > 0.0 || this.direction == 1 && (double) this.velocity.X < 0.0)
        {
          this.frameCounter = 0.0;
          this.frame.Y = num1 * 2;
        }
        else if ((double) this.velocity.X == 0.0)
        {
          this.frameCounter = 0.0;
          this.frame.Y = 0;
        }
        else
        {
          this.frameCounter += (double) Math.Abs(this.velocity.X);
          if (this.frameCounter < 8.0)
            this.frame.Y = 0;
          else if (this.frameCounter < 16.0)
            this.frame.Y = num1;
          else if (this.frameCounter < 24.0)
            this.frame.Y = num1 * 2;
          else if (this.frameCounter < 32.0)
            this.frame.Y = num1;
          else
            this.frameCounter = 0.0;
        }
      }
      else if (this.type == 46 || this.type == 47)
      {
        if ((double) this.velocity.Y == 0.0)
        {
          if (this.direction == 1)
            this.spriteDirection = 1;
          if (this.direction == -1)
            this.spriteDirection = -1;
          if ((double) this.velocity.X == 0.0)
          {
            this.frame.Y = 0;
            this.frameCounter = 0.0;
          }
          else
          {
            this.frameCounter += (double) Math.Abs(this.velocity.X) * 1.0;
            ++this.frameCounter;
            if (this.frameCounter > 6.0)
            {
              this.frame.Y += num1;
              this.frameCounter = 0.0;
            }
            if (this.frame.Y / num1 >= Main.npcFrameCount[this.type])
              this.frame.Y = 0;
          }
        }
        else if ((double) this.velocity.Y < 0.0)
        {
          this.frameCounter = 0.0;
          this.frame.Y = num1 * 4;
        }
        else if ((double) this.velocity.Y > 0.0)
        {
          this.frameCounter = 0.0;
          this.frame.Y = num1 * 6;
        }
      }
      else if (this.type == 4 || this.type == 125 || this.type == 126)
      {
        ++this.frameCounter;
        if (this.frameCounter < 7.0)
          this.frame.Y = 0;
        else if (this.frameCounter < 14.0)
          this.frame.Y = num1;
        else if (this.frameCounter < 21.0)
        {
          this.frame.Y = num1 * 2;
        }
        else
        {
          this.frameCounter = 0.0;
          this.frame.Y = 0;
        }
        if ((double) this.ai[0] > 1.0)
          this.frame.Y += num1 * 3;
      }
      else if (this.type == 5)
      {
        ++this.frameCounter;
        if (this.frameCounter >= 8.0)
        {
          this.frame.Y += num1;
          this.frameCounter = 0.0;
        }
        if (this.frame.Y >= num1 * Main.npcFrameCount[this.type])
          this.frame.Y = 0;
      }
      else if (this.type == 94)
      {
        ++this.frameCounter;
        if (this.frameCounter < 6.0)
          this.frame.Y = 0;
        else if (this.frameCounter < 12.0)
          this.frame.Y = num1;
        else if (this.frameCounter < 18.0)
        {
          this.frame.Y = num1 * 2;
        }
        else
        {
          this.frame.Y = num1;
          if (this.frameCounter >= 23.0)
            this.frameCounter = 0.0;
        }
      }
      else if (this.type == 6)
      {
        ++this.frameCounter;
        if (this.frameCounter >= 8.0)
        {
          this.frame.Y += num1;
          this.frameCounter = 0.0;
        }
        if (this.frame.Y >= num1 * Main.npcFrameCount[this.type])
          this.frame.Y = 0;
      }
      else if (this.type == 24)
      {
        if ((double) this.velocity.Y == 0.0)
        {
          if (this.direction == 1)
            this.spriteDirection = 1;
          if (this.direction == -1)
            this.spriteDirection = -1;
        }
        if ((double) this.ai[1] > 0.0)
        {
          if (this.frame.Y < 4)
            this.frameCounter = 0.0;
          ++this.frameCounter;
          if (this.frameCounter <= 4.0)
            this.frame.Y = num1 * 4;
          else if (this.frameCounter <= 8.0)
            this.frame.Y = num1 * 5;
          else if (this.frameCounter <= 12.0)
            this.frame.Y = num1 * 6;
          else if (this.frameCounter <= 16.0)
            this.frame.Y = num1 * 7;
          else if (this.frameCounter <= 20.0)
          {
            this.frame.Y = num1 * 8;
          }
          else
          {
            this.frame.Y = num1 * 9;
            this.frameCounter = 100.0;
          }
        }
        else
        {
          ++this.frameCounter;
          if (this.frameCounter <= 4.0)
            this.frame.Y = 0;
          else if (this.frameCounter <= 8.0)
            this.frame.Y = num1;
          else if (this.frameCounter <= 12.0)
          {
            this.frame.Y = num1 * 2;
          }
          else
          {
            this.frame.Y = num1 * 3;
            if (this.frameCounter >= 16.0)
              this.frameCounter = 0.0;
          }
        }
      }
      else if (this.type == 29 || this.type == 32 || this.type == 45)
      {
        if ((double) this.velocity.Y == 0.0)
        {
          if (this.direction == 1)
            this.spriteDirection = 1;
          if (this.direction == -1)
            this.spriteDirection = -1;
        }
        this.frame.Y = 0;
        if ((double) this.velocity.Y != 0.0)
          this.frame.Y += num1;
        else if ((double) this.ai[1] > 0.0)
          this.frame.Y += num1 * 2;
      }
      if (this.type != 34)
        return;
      ++this.frameCounter;
      if (this.frameCounter >= 4.0)
      {
        this.frame.Y += num1;
        this.frameCounter = 0.0;
      }
      if (this.frame.Y < num1 * Main.npcFrameCount[this.type])
        return;
      this.frame.Y = 0;
    }

    public void TargetClosest(bool faceTarget = true)
    {
      float num = -1f;
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (Main.player[index].active && !Main.player[index].dead && ((double) num == -1.0 || (double) Math.Abs(Main.player[index].position.X + (float) (Main.player[index].width / 2) - this.position.X + (float) (this.width / 2)) + (double) Math.Abs(Main.player[index].position.Y + (float) (Main.player[index].height / 2) - this.position.Y + (float) (this.height / 2)) < (double) num))
        {
          num = Math.Abs(Main.player[index].position.X + (float) (Main.player[index].width / 2) - this.position.X + (float) (this.width / 2)) + Math.Abs(Main.player[index].position.Y + (float) (Main.player[index].height / 2) - this.position.Y + (float) (this.height / 2));
          this.target = index;
        }
      }
      if (this.target < 0 || this.target >= (int) byte.MaxValue)
        this.target = 0;
      this.targetRect = new Rectangle((int) Main.player[this.target].position.X, (int) Main.player[this.target].position.Y, Main.player[this.target].width, Main.player[this.target].height);
      if (Main.player[this.target].dead)
        faceTarget = false;
      if (faceTarget)
      {
        this.direction = 1;
        if ((double) (this.targetRect.X + this.targetRect.Width / 2) < (double) this.position.X + (double) (this.width / 2))
          this.direction = -1;
        this.directionY = 1;
        if ((double) (this.targetRect.Y + this.targetRect.Height / 2) < (double) this.position.Y + (double) (this.height / 2))
          this.directionY = -1;
      }
      if (this.confused)
        this.direction *= -1;
      if (this.direction == this.oldDirection && this.directionY == this.oldDirectionY && this.target == this.oldTarget || this.collideX || this.collideY)
        return;
      this.netUpdate = true;
    }

    public void CheckActive()
    {
      if (!this.active || this.type == 8 || this.type == 9 || this.type == 11 || this.type == 12 || this.type == 14 || this.type == 15 || this.type == 40 || this.type == 41 || this.type == 96 || this.type == 97 || this.type == 99 || this.type == 100 || this.type > 87 && this.type <= 92 || this.type == 118 || this.type == 119 || this.type == 113 || this.type == 114 || this.type == 115 || this.type >= 134 && this.type <= 136)
        return;
      if (this.townNPC)
      {
        Rectangle rectangle = new Rectangle((int) ((double) this.position.X + (double) (this.width / 2) - (double) NPC.townRangeX), (int) ((double) this.position.Y + (double) (this.height / 2) - (double) NPC.townRangeY), NPC.townRangeX * 2, NPC.townRangeY * 2);
        for (int index = 0; index < (int) byte.MaxValue; ++index)
        {
          if (Main.player[index].active && rectangle.Intersects(new Rectangle((int) Main.player[index].position.X, (int) Main.player[index].position.Y, Main.player[index].width, Main.player[index].height)))
            Main.player[index].townNPCs += this.npcSlots;
        }
      }
      else
      {
        bool flag = false;
        Rectangle rectangle1 = new Rectangle((int) ((double) this.position.X + (double) (this.width / 2) - (double) NPC.activeRangeX), (int) ((double) this.position.Y + (double) (this.height / 2) - (double) NPC.activeRangeY), NPC.activeRangeX * 2, NPC.activeRangeY * 2);
        Rectangle rectangle2 = new Rectangle((int) ((double) this.position.X + (double) (this.width / 2) - (double) NPC.sWidth * 0.5 - (double) this.width), (int) ((double) this.position.Y + (double) (this.height / 2) - (double) NPC.sHeight * 0.5 - (double) this.height), NPC.sWidth + this.width * 2, NPC.sHeight + this.height * 2);
        for (int index = 0; index < (int) byte.MaxValue; ++index)
        {
          if (Main.player[index].active)
          {
            if (rectangle1.Intersects(new Rectangle((int) Main.player[index].position.X, (int) Main.player[index].position.Y, Main.player[index].width, Main.player[index].height)))
            {
              flag = true;
              if (this.type != 25 && this.type != 30 && this.type != 33 && this.lifeMax > 0)
                Main.player[index].activeNPCs += this.npcSlots;
            }
            if (rectangle2.Intersects(new Rectangle((int) Main.player[index].position.X, (int) Main.player[index].position.Y, Main.player[index].width, Main.player[index].height)))
              this.timeLeft = NPC.activeTime;
            if (this.type == 7 || this.type == 10 || this.type == 13 || this.type == 39 || this.type == 87)
              flag = true;
            if (this.boss || this.type == 35 || this.type == 36 || this.type == (int) sbyte.MaxValue || this.type == 128 || this.type == 129 || this.type == 130 || this.type == 131)
              flag = true;
          }
        }
        --this.timeLeft;
        if (this.timeLeft <= 0)
          flag = false;
        if (flag || Main.netMode == 1)
          return;
        NPC.noSpawnCycle = true;
        this.active = false;
        if (Main.netMode == 2)
        {
          this.netSkip = -1;
          this.life = 0;
          NetMessage.SendData(23, number: this.whoAmI);
        }
        if (this.aiStyle != 6)
          return;
        for (int number = (int) this.ai[0]; number > 0; number = (int) Main.npc[number].ai[0])
        {
          if (Main.npc[number].active)
          {
            Main.npc[number].active = false;
            if (Main.netMode == 2)
            {
              Main.npc[number].life = 0;
              Main.npc[number].netSkip = -1;
              NetMessage.SendData(23, number: number);
            }
          }
        }
      }
    }

    public static void SpawnNPC()
    {
      if (NPC.noSpawnCycle)
      {
        NPC.noSpawnCycle = false;
      }
      else
      {
        bool flag1 = false;
        bool flag2 = false;
        int x = 0;
        int y = 0;
        int num1 = 0;
        for (int index = 0; index < (int) byte.MaxValue; ++index)
        {
          if (Main.player[index].active)
            ++num1;
        }
        for (int index1 = 0; index1 < (int) byte.MaxValue; ++index1)
        {
          if (Main.player[index1].active && !Main.player[index1].dead)
          {
            bool flag3 = false;
            bool flag4 = false;
            bool flag5 = false;
            if (Main.player[index1].active && Main.invasionType > 0 && Main.invasionDelay == 0 && Main.invasionSize > 0 && (double) Main.player[index1].position.Y < Main.worldSurface * 16.0 + (double) NPC.sHeight)
            {
              int num2 = 3000;
              if ((double) Main.player[index1].position.X > Main.invasionX * 16.0 - (double) num2 && (double) Main.player[index1].position.X < Main.invasionX * 16.0 + (double) num2)
                flag4 = true;
            }
            bool flag6 = false;
            NPC.spawnRate = NPC.defaultSpawnRate;
            NPC.maxSpawns = NPC.defaultMaxSpawns;
            if (Main.hardMode)
            {
              NPC.spawnRate = (int) ((double) NPC.defaultSpawnRate * 0.9);
              NPC.maxSpawns = NPC.defaultMaxSpawns + 1;
            }
            if ((double) Main.player[index1].position.Y > (double) ((Main.maxTilesY - 200) * 16))
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 2.0);
            else if ((double) Main.player[index1].position.Y > Main.rockLayer * 16.0 + (double) NPC.sHeight)
            {
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.4);
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.89999997615814);
            }
            else if ((double) Main.player[index1].position.Y > Main.worldSurface * 16.0 + (double) NPC.sHeight)
            {
              if (Main.hardMode)
              {
                NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.45);
                NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.79999995231628);
              }
              else
              {
                NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.5);
                NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.70000004768372);
              }
            }
            else if (!Main.dayTime)
            {
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.6);
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.29999995231628);
              if (Main.bloodMoon)
              {
                NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.3);
                NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.79999995231628);
              }
            }
            if (Main.player[index1].zoneDungeon)
            {
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.4);
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.70000004768372);
            }
            else if (Main.player[index1].zoneJungle)
            {
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.4);
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.5);
            }
            else if (Main.player[index1].zoneEvil)
            {
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.65);
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.29999995231628);
            }
            else if (Main.player[index1].zoneMeteor)
            {
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.4);
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.10000002384186);
            }
            if (Main.player[index1].zoneHoly && (double) Main.player[index1].position.Y > Main.rockLayer * 16.0 + (double) NPC.sHeight)
            {
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.65);
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.29999995231628);
            }
            if (Main.wof >= 0 && (double) Main.player[index1].position.Y > (double) ((Main.maxTilesY - 200) * 16))
            {
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 0.300000011920929);
              NPC.spawnRate *= 3;
            }
            if ((double) Main.player[index1].activeNPCs < (double) NPC.maxSpawns * 0.2)
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.600000023841858);
            else if ((double) Main.player[index1].activeNPCs < (double) NPC.maxSpawns * 0.4)
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.699999988079071);
            else if ((double) Main.player[index1].activeNPCs < (double) NPC.maxSpawns * 0.6)
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.800000011920929);
            else if ((double) Main.player[index1].activeNPCs < (double) NPC.maxSpawns * 0.8)
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.899999976158142);
            if ((double) Main.player[index1].position.Y * 16.0 > (Main.worldSurface + Main.rockLayer) / 2.0 || Main.player[index1].zoneEvil)
            {
              if ((double) Main.player[index1].activeNPCs < (double) NPC.maxSpawns * 0.2)
                NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.699999988079071);
              else if ((double) Main.player[index1].activeNPCs < (double) NPC.maxSpawns * 0.4)
                NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.899999976158142);
            }
            if (Main.player[index1].inventory[Main.player[index1].selectedItem].type == 148)
            {
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.75);
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.5);
            }
            if (Main.player[index1].enemySpawns)
            {
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.5);
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 2.0);
            }
            if ((double) NPC.spawnRate < (double) NPC.defaultSpawnRate * 0.1)
              NPC.spawnRate = (int) ((double) NPC.defaultSpawnRate * 0.1);
            if (NPC.maxSpawns > NPC.defaultMaxSpawns * 3)
              NPC.maxSpawns = NPC.defaultMaxSpawns * 3;
            if (flag4)
            {
              NPC.maxSpawns = (int) ((double) NPC.defaultMaxSpawns * (2.0 + 0.3 * (double) num1));
              NPC.spawnRate = 20;
            }
            if (Main.player[index1].zoneDungeon && !NPC.downedBoss3)
              NPC.spawnRate = 10;
            bool flag7 = false;
            if (!flag4 && (!Main.bloodMoon || Main.dayTime) && !Main.player[index1].zoneDungeon && !Main.player[index1].zoneEvil && !Main.player[index1].zoneMeteor)
            {
              if ((double) Main.player[index1].townNPCs == 1.0)
              {
                flag3 = true;
                if (Main.rand.Next(3) <= 1)
                {
                  flag7 = true;
                  NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 0.6);
                }
                else
                  NPC.spawnRate = (int) ((double) NPC.spawnRate * 2.0);
              }
              else if ((double) Main.player[index1].townNPCs == 2.0)
              {
                flag3 = true;
                if (Main.rand.Next(3) == 0)
                {
                  flag7 = true;
                  NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 0.6);
                }
                else
                  NPC.spawnRate = (int) ((double) NPC.spawnRate * 3.0);
              }
              else if ((double) Main.player[index1].townNPCs >= 3.0)
              {
                flag3 = true;
                flag7 = true;
                NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 0.6);
              }
            }
            if (Main.player[index1].active && !Main.player[index1].dead && (double) Main.player[index1].activeNPCs < (double) NPC.maxSpawns && Main.rand.Next(NPC.spawnRate) == 0)
            {
              int minValue1 = (int) ((double) Main.player[index1].position.X / 16.0) - NPC.spawnRangeX;
              int maxValue1 = (int) ((double) Main.player[index1].position.X / 16.0) + NPC.spawnRangeX;
              int minValue2 = (int) ((double) Main.player[index1].position.Y / 16.0) - NPC.spawnRangeY;
              int maxValue2 = (int) ((double) Main.player[index1].position.Y / 16.0) + NPC.spawnRangeY;
              int num3 = (int) ((double) Main.player[index1].position.X / 16.0) - NPC.safeRangeX;
              int num4 = (int) ((double) Main.player[index1].position.X / 16.0) + NPC.safeRangeX;
              int num5 = (int) ((double) Main.player[index1].position.Y / 16.0) - NPC.safeRangeY;
              int num6 = (int) ((double) Main.player[index1].position.Y / 16.0) + NPC.safeRangeY;
              if (minValue1 < 0)
                minValue1 = 0;
              if (maxValue1 > Main.maxTilesX)
                maxValue1 = Main.maxTilesX;
              if (minValue2 < 0)
                minValue2 = 0;
              if (maxValue2 > Main.maxTilesY)
                maxValue2 = Main.maxTilesY;
              for (int index2 = 0; index2 < 50; ++index2)
              {
                int index3 = Main.rand.Next(minValue1, maxValue1);
                int index4 = Main.rand.Next(minValue2, maxValue2);
                if (!Main.tile[index3, index4].active || !Main.tileSolid[(int) Main.tile[index3, index4].type])
                {
                  if (!Main.wallHouse[(int) Main.tile[index3, index4].wall])
                  {
                    if (!flag4 && (double) index4 < Main.worldSurface * 0.349999994039536 && !flag7 && ((double) index3 < (double) Main.maxTilesX * 0.45 || (double) index3 > (double) Main.maxTilesX * 0.55 || Main.hardMode))
                    {
                      int type = (int) Main.tile[index3, index4].type;
                      x = index3;
                      y = index4;
                      flag6 = true;
                      flag2 = true;
                    }
                    else if (!flag4 && (double) index4 < Main.worldSurface * 0.449999988079071 && !flag7 && Main.hardMode && Main.rand.Next(10) == 0)
                    {
                      int type = (int) Main.tile[index3, index4].type;
                      x = index3;
                      y = index4;
                      flag6 = true;
                      flag2 = true;
                    }
                    else
                    {
                      for (int index5 = index4; index5 < Main.maxTilesY; ++index5)
                      {
                        if (Main.tile[index3, index5].active && Main.tileSolid[(int) Main.tile[index3, index5].type])
                        {
                          if (index3 < num3 || index3 > num4 || index5 < num5 || index5 > num6)
                          {
                            int type = (int) Main.tile[index3, index5].type;
                            x = index3;
                            y = index5;
                            flag6 = true;
                            break;
                          }
                          break;
                        }
                      }
                    }
                    if (flag6)
                    {
                      int num7 = x - NPC.spawnSpaceX / 2;
                      int num8 = x + NPC.spawnSpaceX / 2;
                      int num9 = y - NPC.spawnSpaceY;
                      int num10 = y;
                      if (num7 < 0)
                        flag6 = false;
                      if (num8 > Main.maxTilesX)
                        flag6 = false;
                      if (num9 < 0)
                        flag6 = false;
                      if (num10 > Main.maxTilesY)
                        flag6 = false;
                      if (flag6)
                      {
                        for (int index6 = num7; index6 < num8; ++index6)
                        {
                          for (int index7 = num9; index7 < num10; ++index7)
                          {
                            if (Main.tile[index6, index7].active && Main.tileSolid[(int) Main.tile[index6, index7].type])
                            {
                              flag6 = false;
                              break;
                            }
                            if (Main.tile[index6, index7].lava)
                            {
                              flag6 = false;
                              break;
                            }
                          }
                        }
                      }
                    }
                  }
                  else
                    continue;
                }
                if (flag6 || flag6)
                  break;
              }
            }
            if (flag6)
            {
              Rectangle rectangle1 = new Rectangle(x * 16, y * 16, 16, 16);
              for (int index8 = 0; index8 < (int) byte.MaxValue; ++index8)
              {
                if (Main.player[index8].active)
                {
                  Rectangle rectangle2 = new Rectangle((int) ((double) Main.player[index8].position.X + (double) (Main.player[index8].width / 2) - (double) (NPC.sWidth / 2) - (double) NPC.safeRangeX), (int) ((double) Main.player[index8].position.Y + (double) (Main.player[index8].height / 2) - (double) (NPC.sHeight / 2) - (double) NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
                  if (rectangle1.Intersects(rectangle2))
                    flag6 = false;
                }
              }
            }
            if (flag6)
            {
              if (Main.player[index1].zoneDungeon && (!Main.tileDungeon[(int) Main.tile[x, y].type] || Main.tile[x, y - 1].wall == (byte) 0))
                flag6 = false;
              if (Main.tile[x, y - 1].liquid > (byte) 0 && Main.tile[x, y - 2].liquid > (byte) 0 && !Main.tile[x, y - 1].lava)
                flag5 = true;
            }
            if (flag6)
            {
              flag1 = false;
              int type = (int) Main.tile[x, y].type;
              int number = 200;
              if (flag2)
              {
                if (Main.hardMode && Main.rand.Next(10) == 0 && !NPC.AnyNPCs(87))
                  NPC.NewNPC(x * 16 + 8, y * 16, 87, 1);
                else
                  NPC.NewNPC(x * 16 + 8, y * 16, 48);
              }
              else if (flag4)
              {
                switch (Main.invasionType)
                {
                  case 1:
                    if (Main.rand.Next(9) == 0)
                    {
                      NPC.NewNPC(x * 16 + 8, y * 16, 29);
                      break;
                    }
                    if (Main.rand.Next(5) == 0)
                    {
                      NPC.NewNPC(x * 16 + 8, y * 16, 26);
                      break;
                    }
                    if (Main.rand.Next(3) == 0)
                    {
                      NPC.NewNPC(x * 16 + 8, y * 16, 111);
                      break;
                    }
                    if (Main.rand.Next(3) == 0)
                    {
                      NPC.NewNPC(x * 16 + 8, y * 16, 27);
                      break;
                    }
                    NPC.NewNPC(x * 16 + 8, y * 16, 28);
                    break;
                  case 2:
                    if (Main.rand.Next(7) == 0)
                    {
                      NPC.NewNPC(x * 16 + 8, y * 16, 145);
                      break;
                    }
                    if (Main.rand.Next(3) == 0)
                    {
                      NPC.NewNPC(x * 16 + 8, y * 16, 143);
                      break;
                    }
                    NPC.NewNPC(x * 16 + 8, y * 16, 144);
                    break;
                }
              }
              else if (flag5 && (x < 250 || x > Main.maxTilesX - 250) && type == 53 && (double) y < Main.rockLayer)
              {
                if (Main.rand.Next(8) == 0)
                  NPC.NewNPC(x * 16 + 8, y * 16, 65);
                if (Main.rand.Next(3) == 0)
                  NPC.NewNPC(x * 16 + 8, y * 16, 67);
                else
                  NPC.NewNPC(x * 16 + 8, y * 16, 64);
              }
              else if (flag5 && ((double) y > Main.rockLayer && Main.rand.Next(2) == 0 || type == 60))
              {
                if (Main.hardMode && Main.rand.Next(3) > 0)
                  NPC.NewNPC(x * 16 + 8, y * 16, 102);
                else
                  NPC.NewNPC(x * 16 + 8, y * 16, 58);
              }
              else if (flag5 && (double) y > Main.worldSurface && Main.rand.Next(3) == 0)
              {
                if (Main.hardMode)
                  NPC.NewNPC(x * 16 + 8, y * 16, 103);
                else
                  NPC.NewNPC(x * 16 + 8, y * 16, 63);
              }
              else if (flag5 && Main.rand.Next(4) == 0)
              {
                if (Main.player[index1].zoneEvil)
                  NPC.NewNPC(x * 16 + 8, y * 16, 57);
                else
                  NPC.NewNPC(x * 16 + 8, y * 16, 55);
              }
              else if (NPC.downedGoblins && Main.rand.Next(20) == 0 && !flag5 && (double) y >= Main.rockLayer && y < Main.maxTilesY - 210 && !NPC.savedGoblin && !NPC.AnyNPCs(105))
                NPC.NewNPC(x * 16 + 8, y * 16, 105);
              else if (Main.hardMode && Main.rand.Next(20) == 0 && !flag5 && (double) y >= Main.rockLayer && y < Main.maxTilesY - 210 && !NPC.savedWizard && !NPC.AnyNPCs(106))
                NPC.NewNPC(x * 16 + 8, y * 16, 106);
              else if (flag7)
              {
                if (flag5)
                {
                  NPC.NewNPC(x * 16 + 8, y * 16, 55);
                }
                else
                {
                  if (type != 2 && type != 109 && type != 147 && (double) y <= Main.worldSurface)
                    break;
                  if (Main.rand.Next(2) == 0 && (double) y <= Main.worldSurface)
                    NPC.NewNPC(x * 16 + 8, y * 16, 74);
                  else
                    NPC.NewNPC(x * 16 + 8, y * 16, 46);
                }
              }
              else if (Main.player[index1].zoneDungeon)
              {
                if (!NPC.downedBoss3)
                  number = NPC.NewNPC(x * 16 + 8, y * 16, 68);
                else if (!NPC.savedMech && Main.rand.Next(5) == 0 && !flag5 && !NPC.AnyNPCs(123) && (double) y > Main.rockLayer)
                  NPC.NewNPC(x * 16 + 8, y * 16, 123);
                else if (Main.rand.Next(37) == 0)
                  number = NPC.NewNPC(x * 16 + 8, y * 16, 71);
                else if (Main.rand.Next(4) == 0 && !NPC.NearSpikeBall(x, y))
                  number = NPC.NewNPC(x * 16 + 8, y * 16, 70);
                else if (Main.rand.Next(15) == 0)
                  number = NPC.NewNPC(x * 16 + 8, y * 16, 72);
                else if (Main.rand.Next(9) == 0)
                  number = NPC.NewNPC(x * 16 + 8, y * 16, 34);
                else if (Main.rand.Next(7) == 0)
                {
                  number = NPC.NewNPC(x * 16 + 8, y * 16, 32);
                }
                else
                {
                  number = NPC.NewNPC(x * 16 + 8, y * 16, 31);
                  if (Main.rand.Next(4) == 0)
                    Main.npc[number].SetDefaults("Big Boned");
                  else if (Main.rand.Next(5) == 0)
                    Main.npc[number].SetDefaults("Short Bones");
                }
              }
              else if (Main.player[index1].zoneMeteor)
                number = NPC.NewNPC(x * 16 + 8, y * 16, 23);
              else if (Main.player[index1].zoneEvil && Main.rand.Next(65) == 0)
                number = !Main.hardMode || Main.rand.Next(4) == 0 ? NPC.NewNPC(x * 16 + 8, y * 16, 7, 1) : NPC.NewNPC(x * 16 + 8, y * 16, 98, 1);
              else if (Main.hardMode && (double) y > Main.worldSurface && Main.rand.Next(75) == 0)
                number = NPC.NewNPC(x * 16 + 8, y * 16, 85);
              else if (Main.hardMode && Main.tile[x, y - 1].wall == (byte) 2 && Main.rand.Next(20) == 0)
                number = NPC.NewNPC(x * 16 + 8, y * 16, 85);
              else if (Main.hardMode && (double) y <= Main.worldSurface && !Main.dayTime && (Main.rand.Next(20) == 0 || Main.rand.Next(5) == 0 && Main.moonPhase == 4))
                number = NPC.NewNPC(x * 16 + 8, y * 16, 82);
              else if (type == 60 && Main.rand.Next(500) == 0 && !Main.dayTime)
                number = NPC.NewNPC(x * 16 + 8, y * 16, 52);
              else if (type == 60 && (double) y > (Main.worldSurface + Main.rockLayer) / 2.0)
              {
                if (Main.rand.Next(3) == 0)
                {
                  number = NPC.NewNPC(x * 16 + 8, y * 16, 43);
                  Main.npc[number].ai[0] = (float) x;
                  Main.npc[number].ai[1] = (float) y;
                  Main.npc[number].netUpdate = true;
                }
                else
                {
                  number = NPC.NewNPC(x * 16 + 8, y * 16, 42);
                  if (Main.rand.Next(4) == 0)
                    Main.npc[number].SetDefaults("Little Stinger");
                  else if (Main.rand.Next(4) == 0)
                    Main.npc[number].SetDefaults("Big Stinger");
                }
              }
              else if (type == 60 && Main.rand.Next(4) == 0)
                number = NPC.NewNPC(x * 16 + 8, y * 16, 51);
              else if (type == 60 && Main.rand.Next(8) == 0)
              {
                number = NPC.NewNPC(x * 16 + 8, y * 16, 56);
                Main.npc[number].ai[0] = (float) x;
                Main.npc[number].ai[1] = (float) y;
                Main.npc[number].netUpdate = true;
              }
              else if (Main.hardMode && type == 53 && Main.rand.Next(3) == 0)
                number = NPC.NewNPC(x * 16 + 8, y * 16, 78);
              else if (Main.hardMode && type == 112 && Main.rand.Next(2) == 0)
                number = NPC.NewNPC(x * 16 + 8, y * 16, 79);
              else if (Main.hardMode && type == 116 && Main.rand.Next(2) == 0)
                number = NPC.NewNPC(x * 16 + 8, y * 16, 80);
              else if (Main.hardMode && !flag5 && (double) y < Main.rockLayer && (type == 116 || type == 117 || type == 109))
                number = Main.dayTime || Main.rand.Next(2) != 0 ? (Main.rand.Next(10) != 0 ? NPC.NewNPC(x * 16 + 8, y * 16, 75) : NPC.NewNPC(x * 16 + 8, y * 16, 86)) : NPC.NewNPC(x * 16 + 8, y * 16, 122);
              else if (!flag3 && Main.hardMode && Main.rand.Next(50) == 0 && !flag5 && (double) y >= Main.rockLayer && (type == 116 || type == 117 || type == 109))
                number = NPC.NewNPC(x * 16 + 8, y * 16, 84);
              else if (type == 22 && Main.player[index1].zoneEvil || type == 23 || type == 25 || type == 112)
              {
                if (Main.hardMode && (double) y >= Main.rockLayer && Main.rand.Next(3) == 0)
                {
                  number = NPC.NewNPC(x * 16 + 8, y * 16, 101);
                  Main.npc[number].ai[0] = (float) x;
                  Main.npc[number].ai[1] = (float) y;
                  Main.npc[number].netUpdate = true;
                }
                else if (Main.hardMode && Main.rand.Next(3) == 0)
                  number = Main.rand.Next(3) != 0 ? NPC.NewNPC(x * 16 + 8, y * 16, 81) : NPC.NewNPC(x * 16 + 8, y * 16, 121);
                else if (Main.hardMode && (double) y >= Main.rockLayer && Main.rand.Next(40) == 0)
                  number = NPC.NewNPC(x * 16 + 8, y * 16, 83);
                else if (Main.hardMode && (Main.rand.Next(2) == 0 || (double) y > Main.rockLayer))
                {
                  number = NPC.NewNPC(x * 16 + 8, y * 16, 94);
                }
                else
                {
                  number = NPC.NewNPC(x * 16 + 8, y * 16, 6);
                  if (Main.rand.Next(3) == 0)
                    Main.npc[number].SetDefaults("Little Eater");
                  else if (Main.rand.Next(3) == 0)
                    Main.npc[number].SetDefaults("Big Eater");
                }
              }
              else if ((double) y <= Main.worldSurface)
              {
                if (Main.dayTime)
                {
                  int num11 = Math.Abs(x - Main.spawnTileX);
                  if (num11 < Main.maxTilesX / 3 && Main.rand.Next(15) == 0 && (type == 2 || type == 109 || type == 147))
                    NPC.NewNPC(x * 16 + 8, y * 16, 46);
                  else if (num11 < Main.maxTilesX / 3 && Main.rand.Next(15) == 0 && (type == 2 || type == 109 || type == 147))
                    NPC.NewNPC(x * 16 + 8, y * 16, 74);
                  else if (num11 > Main.maxTilesX / 3 && type == 2 && Main.rand.Next(300) == 0 && !NPC.AnyNPCs(50))
                    number = NPC.NewNPC(x * 16 + 8, y * 16, 50);
                  else if (type == 53 && Main.rand.Next(5) == 0 && !flag5)
                    number = NPC.NewNPC(x * 16 + 8, y * 16, 69);
                  else if (type == 53 && !flag5)
                    number = NPC.NewNPC(x * 16 + 8, y * 16, 61);
                  else if (num11 > Main.maxTilesX / 3 && Main.rand.Next(15) == 0)
                  {
                    number = NPC.NewNPC(x * 16 + 8, y * 16, 73);
                  }
                  else
                  {
                    number = NPC.NewNPC(x * 16 + 8, y * 16, 1);
                    if (type == 60)
                      Main.npc[number].SetDefaults("Jungle Slime");
                    else if (Main.rand.Next(3) == 0 || num11 < 200)
                      Main.npc[number].SetDefaults("Green Slime");
                    else if (Main.rand.Next(10) == 0 && num11 > 400)
                      Main.npc[number].SetDefaults("Purple Slime");
                  }
                }
                else if (Main.rand.Next(6) == 0 || Main.moonPhase == 4 && Main.rand.Next(2) == 0)
                  number = !Main.hardMode || Main.rand.Next(3) != 0 ? NPC.NewNPC(x * 16 + 8, y * 16, 2) : NPC.NewNPC(x * 16 + 8, y * 16, 133);
                else if (Main.hardMode && Main.rand.Next(50) == 0 && Main.bloodMoon && !NPC.AnyNPCs(109))
                  NPC.NewNPC(x * 16 + 8, y * 16, 109);
                else if (Main.rand.Next(250) == 0 && Main.bloodMoon)
                  NPC.NewNPC(x * 16 + 8, y * 16, 53);
                else if (Main.moonPhase == 0 && Main.hardMode && Main.rand.Next(3) != 0)
                  NPC.NewNPC(x * 16 + 8, y * 16, 104);
                else if (Main.hardMode && Main.rand.Next(3) == 0)
                  NPC.NewNPC(x * 16 + 8, y * 16, 140);
                else if (Main.rand.Next(3) == 0)
                  NPC.NewNPC(x * 16 + 8, y * 16, 132);
                else
                  NPC.NewNPC(x * 16 + 8, y * 16, 3);
              }
              else if ((double) y <= Main.rockLayer)
              {
                if (!flag3 && Main.rand.Next(50) == 0)
                  number = !Main.hardMode ? NPC.NewNPC(x * 16 + 8, y * 16, 10, 1) : NPC.NewNPC(x * 16 + 8, y * 16, 95, 1);
                else if (Main.hardMode && Main.rand.Next(3) == 0)
                  number = NPC.NewNPC(x * 16 + 8, y * 16, 140);
                else if (Main.hardMode && Main.rand.Next(4) != 0)
                {
                  number = NPC.NewNPC(x * 16 + 8, y * 16, 141);
                }
                else
                {
                  number = NPC.NewNPC(x * 16 + 8, y * 16, 1);
                  if (Main.rand.Next(5) == 0)
                    Main.npc[number].SetDefaults("Yellow Slime");
                  else if (Main.rand.Next(2) == 0)
                    Main.npc[number].SetDefaults("Blue Slime");
                  else
                    Main.npc[number].SetDefaults("Red Slime");
                }
              }
              else if (y > Main.maxTilesY - 190)
                number = Main.rand.Next(40) != 0 || NPC.AnyNPCs(39) ? (Main.rand.Next(14) != 0 ? (Main.rand.Next(8) != 0 ? (Main.rand.Next(3) != 0 ? NPC.NewNPC(x * 16 + 8, y * 16, 60) : NPC.NewNPC(x * 16 + 8, y * 16, 59)) : (Main.rand.Next(7) != 0 ? NPC.NewNPC(x * 16 + 8, y * 16, 62) : NPC.NewNPC(x * 16 + 8, y * 16, 66))) : NPC.NewNPC(x * 16 + 8, y * 16, 24)) : NPC.NewNPC(x * 16 + 8, y * 16, 39, 1);
              else if ((type == 116 || type == 117) && !flag3 && Main.rand.Next(8) == 0)
                number = NPC.NewNPC(x * 16 + 8, y * 16, 120);
              else if (!flag3 && Main.rand.Next(75) == 0 && !Main.player[index1].zoneHoly)
                number = !Main.hardMode ? NPC.NewNPC(x * 16 + 8, y * 16, 10, 1) : NPC.NewNPC(x * 16 + 8, y * 16, 95, 1);
              else if (!Main.hardMode && Main.rand.Next(10) == 0)
                number = NPC.NewNPC(x * 16 + 8, y * 16, 16);
              else if (!Main.hardMode && Main.rand.Next(4) == 0)
              {
                number = NPC.NewNPC(x * 16 + 8, y * 16, 1);
                if (Main.player[index1].zoneJungle)
                  Main.npc[number].SetDefaults("Jungle Slime");
                else
                  Main.npc[number].SetDefaults("Black Slime");
              }
              else if (Main.rand.Next(2) == 0)
              {
                if ((double) y > (Main.rockLayer + (double) Main.maxTilesY) / 2.0 && Main.rand.Next(700) == 0)
                  number = NPC.NewNPC(x * 16 + 8, y * 16, 45);
                else if (Main.hardMode && Main.rand.Next(10) != 0)
                {
                  if (Main.rand.Next(2) == 0)
                  {
                    number = NPC.NewNPC(x * 16 + 8, y * 16, 77);
                    if ((double) y > (Main.rockLayer + (double) Main.maxTilesY) / 2.0 && Main.rand.Next(5) == 0)
                      Main.npc[number].SetDefaults("Heavy Skeleton");
                  }
                  else
                    number = NPC.NewNPC(x * 16 + 8, y * 16, 110);
                }
                else
                  number = Main.rand.Next(15) != 0 ? NPC.NewNPC(x * 16 + 8, y * 16, 21) : NPC.NewNPC(x * 16 + 8, y * 16, 44);
              }
              else
                number = !Main.hardMode || !(Main.player[index1].zoneHoly & Main.rand.Next(2) == 0) ? (!Main.player[index1].zoneJungle ? (!Main.hardMode || !Main.player[index1].zoneHoly ? (!Main.hardMode || Main.rand.Next(6) <= 0 ? NPC.NewNPC(x * 16 + 8, y * 16, 49) : NPC.NewNPC(x * 16 + 8, y * 16, 93)) : NPC.NewNPC(x * 16 + 8, y * 16, 137)) : NPC.NewNPC(x * 16 + 8, y * 16, 51)) : NPC.NewNPC(x * 16 + 8, y * 16, 138);
              if (Main.npc[number].type == 1 && Main.rand.Next(250) == 0)
                Main.npc[number].SetDefaults("Pinky");
              if (Main.netMode != 2 || number >= 200)
                break;
              NetMessage.SendData(23, number: number);
              break;
            }
          }
        }
      }
    }

    public static void SpawnWOF(Vector2 pos)
    {
      if ((double) pos.Y / 16.0 < (double) (Main.maxTilesY - 205) || Main.wof >= 0 || Main.netMode == 1)
        return;
      int closest = (int) Player.FindClosest(pos, 16, 16);
      int num1 = 1;
      if ((double) pos.X / 16.0 > (double) (Main.maxTilesX / 2))
        num1 = -1;
      bool flag = false;
      int x = (int) pos.X;
      while (!flag)
      {
        flag = true;
        for (int index = 0; index < (int) byte.MaxValue; ++index)
        {
          if (Main.player[index].active && (double) Main.player[index].position.X > (double) (x - 1200) && (double) Main.player[index].position.X < (double) (x + 1200))
          {
            x -= num1 * 16;
            flag = false;
          }
        }
        if (x / 16 < 20 || x / 16 > Main.maxTilesX - 20)
          flag = true;
      }
      int y = (int) pos.Y;
      int i = x / 16;
      int num2 = y / 16;
      int num3 = 0;
      try
      {
        for (; WorldGen.SolidTile(i, num2 - num3) || Main.tile[i, num2 - num3].liquid >= (byte) 100; ++num3)
        {
          if (!WorldGen.SolidTile(i, num2 + num3) && Main.tile[i, num2 + num3].liquid < (byte) 100)
          {
            num2 += num3;
            goto label_20;
          }
        }
        num2 -= num3;
      }
      catch
      {
      }
label_20:
      int Y = num2 * 16;
      int index1 = NPC.NewNPC(x, Y, 113);
      if (Main.npc[index1].displayName == "")
        Main.npc[index1].displayName = Main.npc[index1].name;
      if (Main.netMode == 0)
      {
        Main.NewText(Main.npc[index1].displayName + " " + Lang.misc[16], (byte) 175, (byte) 75);
      }
      else
      {
        if (Main.netMode != 2)
          return;
        NetMessage.SendData(25, text: (Main.npc[index1].displayName + " " + Lang.misc[16]), number: ((int) byte.MaxValue), number2: 175f, number3: 75f, number4: ((float) byte.MaxValue));
      }
    }

    public static void SpawnOnPlayer(int plr, int Type)
    {
      if (Main.netMode == 1)
        return;
      bool flag = false;
      int num1 = 0;
      int num2 = 0;
      int minValue1 = (int) ((double) Main.player[plr].position.X / 16.0) - NPC.spawnRangeX * 2;
      int maxValue1 = (int) ((double) Main.player[plr].position.X / 16.0) + NPC.spawnRangeX * 2;
      int minValue2 = (int) ((double) Main.player[plr].position.Y / 16.0) - NPC.spawnRangeY * 2;
      int maxValue2 = (int) ((double) Main.player[plr].position.Y / 16.0) + NPC.spawnRangeY * 2;
      int num3 = (int) ((double) Main.player[plr].position.X / 16.0) - NPC.safeRangeX;
      int num4 = (int) ((double) Main.player[plr].position.X / 16.0) + NPC.safeRangeX;
      int num5 = (int) ((double) Main.player[plr].position.Y / 16.0) - NPC.safeRangeY;
      int num6 = (int) ((double) Main.player[plr].position.Y / 16.0) + NPC.safeRangeY;
      if (minValue1 < 0)
        minValue1 = 0;
      if (maxValue1 > Main.maxTilesX)
        maxValue1 = Main.maxTilesX;
      if (minValue2 < 0)
        minValue2 = 0;
      if (maxValue2 > Main.maxTilesY)
        maxValue2 = Main.maxTilesY;
      for (int index1 = 0; index1 < 1000; ++index1)
      {
        for (int index2 = 0; index2 < 100; ++index2)
        {
          int index3 = Main.rand.Next(minValue1, maxValue1);
          int index4 = Main.rand.Next(minValue2, maxValue2);
          if (!Main.tile[index3, index4].active || !Main.tileSolid[(int) Main.tile[index3, index4].type])
          {
            if (!Main.wallHouse[(int) Main.tile[index3, index4].wall] || index1 >= 999)
            {
              for (int index5 = index4; index5 < Main.maxTilesY; ++index5)
              {
                if (Main.tile[index3, index5].active && Main.tileSolid[(int) Main.tile[index3, index5].type])
                {
                  if (index3 < num3 || index3 > num4 || index5 < num5 || index5 > num6 || index1 == 999)
                  {
                    int type = (int) Main.tile[index3, index5].type;
                    num1 = index3;
                    num2 = index5;
                    flag = true;
                    break;
                  }
                  break;
                }
              }
              if (flag && index1 < 999)
              {
                int num7 = num1 - NPC.spawnSpaceX / 2;
                int num8 = num1 + NPC.spawnSpaceX / 2;
                int num9 = num2 - NPC.spawnSpaceY;
                int num10 = num2;
                if (num7 < 0)
                  flag = false;
                if (num8 > Main.maxTilesX)
                  flag = false;
                if (num9 < 0)
                  flag = false;
                if (num10 > Main.maxTilesY)
                  flag = false;
                if (flag)
                {
                  for (int index6 = num7; index6 < num8; ++index6)
                  {
                    for (int index7 = num9; index7 < num10; ++index7)
                    {
                      if (Main.tile[index6, index7].active && Main.tileSolid[(int) Main.tile[index6, index7].type])
                      {
                        flag = false;
                        break;
                      }
                    }
                  }
                }
              }
            }
            else
              continue;
          }
          if (flag || flag)
            break;
        }
        if (flag && index1 < 999)
        {
          Rectangle rectangle1 = new Rectangle(num1 * 16, num2 * 16, 16, 16);
          for (int index8 = 0; index8 < (int) byte.MaxValue; ++index8)
          {
            if (Main.player[index8].active)
            {
              Rectangle rectangle2 = new Rectangle((int) ((double) Main.player[index8].position.X + (double) (Main.player[index8].width / 2) - (double) (NPC.sWidth / 2) - (double) NPC.safeRangeX), (int) ((double) Main.player[index8].position.Y + (double) (Main.player[index8].height / 2) - (double) (NPC.sHeight / 2) - (double) NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
              if (rectangle1.Intersects(rectangle2))
                flag = false;
            }
          }
        }
        if (flag)
          break;
      }
      if (!flag)
        return;
      int number = NPC.NewNPC(num1 * 16 + 8, num2 * 16, Type, 1);
      if (number == 200)
        return;
      Main.npc[number].target = plr;
      Main.npc[number].timeLeft *= 20;
      string str = Main.npc[number].name;
      if (Main.npc[number].displayName != "")
        str = Main.npc[number].displayName;
      if (Main.netMode == 2 && number < 200)
        NetMessage.SendData(23, number: number);
      switch (Type)
      {
        case 50:
          break;
        case 82:
          break;
        case 125:
          if (Main.netMode == 0)
          {
            Main.NewText("The Twins " + Lang.misc[16], (byte) 175, (byte) 75);
            break;
          }
          if (Main.netMode != 2)
            break;
          NetMessage.SendData(25, text: ("The Twins " + Lang.misc[16]), number: ((int) byte.MaxValue), number2: 175f, number3: 75f, number4: ((float) byte.MaxValue));
          break;
        case 126:
          break;
        default:
          if (Main.netMode == 0)
          {
            Main.NewText(str + " " + Lang.misc[16], (byte) 175, (byte) 75);
            break;
          }
          if (Main.netMode != 2)
            break;
          NetMessage.SendData(25, text: (str + " " + Lang.misc[16]), number: ((int) byte.MaxValue), number2: 175f, number3: 75f, number4: ((float) byte.MaxValue));
          break;
      }
    }

    public static int NewNPC(int X, int Y, int Type, int Start = 0)
    {
      int index1 = -1;
      for (int index2 = Start; index2 < 200; ++index2)
      {
        if (!Main.npc[index2].active)
        {
          index1 = index2;
          break;
        }
      }
      if (index1 < 0)
        return 200;
      Main.npc[index1] = new NPC();
      Main.npc[index1].SetDefaults(Type);
      Main.npc[index1].position.X = (float) (X - Main.npc[index1].width / 2);
      Main.npc[index1].position.Y = (float) (Y - Main.npc[index1].height);
      Main.npc[index1].active = true;
      Main.npc[index1].timeLeft = (int) ((double) NPC.activeTime * 1.25);
      Main.npc[index1].wet = Collision.WetCollision(Main.npc[index1].position, Main.npc[index1].width, Main.npc[index1].height);
      if (Type == 50)
      {
        switch (Main.netMode)
        {
          case 0:
            Main.NewText(Main.npc[index1].name + " " + Lang.misc[16], (byte) 175, (byte) 75);
            break;
          case 2:
            NetMessage.SendData(25, text: (Main.npc[index1].name + " " + Lang.misc[16]), number: ((int) byte.MaxValue), number2: 175f, number3: 75f, number4: ((float) byte.MaxValue));
            break;
        }
      }
      return index1;
    }

    public void Transform(int newType)
    {
      if (Main.netMode == 1)
        return;
      Vector2 velocity = this.velocity;
      this.position.Y += (float) this.height;
      int spriteDirection = this.spriteDirection;
      this.SetDefaults(newType);
      this.spriteDirection = spriteDirection;
      this.TargetClosest();
      this.velocity = velocity;
      this.position.Y -= (float) this.height;
      if (newType == 107 || newType == 108)
      {
        this.homeTileX = (int) ((double) this.position.X + (double) (this.width / 2)) / 16;
        this.homeTileY = (int) ((double) this.position.Y + (double) this.height) / 16;
        this.homeless = true;
      }
      if (Main.netMode != 2)
        return;
      this.netUpdate = true;
      NetMessage.SendData(23, number: this.whoAmI);
    }

    public double StrikeNPC(
      int Damage,
      float knockBack,
      int hitDirection,
      bool crit = false,
      bool noEffect = false)
    {
      if (!this.active || this.life <= 0)
        return 0.0;
      double damage = Main.CalculateDamage((int) (double) Damage, this.defense);
      if (crit)
        damage *= 2.0;
      if (Damage != 9999 && this.lifeMax > 1)
      {
        if (this.friendly)
          CombatText.NewText(new Rectangle((int) this.position.X, (int) this.position.Y, this.width, this.height), new Color((int) byte.MaxValue, 80, 90, (int) byte.MaxValue), string.Concat((object) (int) damage), crit);
        else
          CombatText.NewText(new Rectangle((int) this.position.X, (int) this.position.Y, this.width, this.height), new Color((int) byte.MaxValue, 160, 80, (int) byte.MaxValue), string.Concat((object) (int) damage), crit);
      }
      if (damage < 1.0)
        return 0.0;
      this.justHit = true;
      if (this.townNPC)
      {
        this.ai[0] = 1f;
        this.ai[1] = (float) (300 + Main.rand.Next(300));
        this.ai[2] = 0.0f;
        this.direction = hitDirection;
        this.netUpdate = true;
      }
      if (this.aiStyle == 8 && Main.netMode != 1)
      {
        this.ai[0] = 400f;
        this.TargetClosest();
      }
      if (this.realLife >= 0)
      {
        Main.npc[this.realLife].life -= (int) damage;
        this.life = Main.npc[this.realLife].life;
        this.lifeMax = Main.npc[this.realLife].lifeMax;
      }
      else
        this.life -= (int) damage;
      if ((double) knockBack > 0.0 && (double) this.knockBackResist > 0.0)
      {
        float num1 = knockBack * this.knockBackResist;
        if ((double) num1 > 8.0)
          num1 = 8f;
        if (crit)
          num1 *= 1.4f;
        if (damage * 10.0 < (double) this.lifeMax)
        {
          if (hitDirection < 0 && (double) this.velocity.X > -(double) num1)
          {
            if ((double) this.velocity.X > 0.0)
              this.velocity.X -= num1;
            this.velocity.X -= num1;
            if ((double) this.velocity.X < -(double) num1)
              this.velocity.X = -num1;
          }
          else if (hitDirection > 0 && (double) this.velocity.X < (double) num1)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X += num1;
            this.velocity.X += num1;
            if ((double) this.velocity.X > (double) num1)
              this.velocity.X = num1;
          }
          float num2 = this.noGravity ? num1 * -0.5f : num1 * -0.75f;
          if ((double) this.velocity.Y > (double) num2)
          {
            this.velocity.Y += num2;
            if ((double) this.velocity.Y < (double) num2)
              this.velocity.Y = num2;
          }
        }
        else
        {
          this.velocity.Y = this.noGravity ? (float) (-(double) num1 * 0.5) * this.knockBackResist : (float) (-(double) num1 * 0.75) * this.knockBackResist;
          this.velocity.X = num1 * (float) hitDirection * this.knockBackResist;
        }
      }
      if ((this.type == 113 || this.type == 114) && this.life <= 0)
      {
        for (int index = 0; index < 200; ++index)
        {
          if (Main.npc[index].active && (Main.npc[index].type == 113 || Main.npc[index].type == 114))
            Main.npc[index].HitEffect(hitDirection, damage);
        }
      }
      else
        this.HitEffect(hitDirection, damage);
      if (this.soundHit > 0)
        Main.PlaySound(3, (int) this.position.X, (int) this.position.Y, this.soundHit);
      if (this.realLife >= 0)
        Main.npc[this.realLife].checkDead();
      else
        this.checkDead();
      return damage;
    }

    public void checkDead()
    {
      if (!this.active || this.realLife >= 0 && this.realLife != this.whoAmI || this.life > 0)
        return;
      NPC.noSpawnCycle = true;
      if (this.townNPC && this.type != 37)
      {
        string str = this.name;
        if (this.displayName != "")
          str = this.displayName;
        if (Main.netMode == 0)
          Main.NewText(str + Lang.misc[19], G: (byte) 25, B: (byte) 25);
        else if (Main.netMode == 2)
          NetMessage.SendData(25, text: (str + Lang.misc[19]), number: ((int) byte.MaxValue), number2: ((float) byte.MaxValue), number3: 25f, number4: 25f);
        if (Main.netMode != 1)
        {
          Main.chrName[this.type] = "";
          NPC.setNames();
          NetMessage.SendData(56, number: this.type);
        }
      }
      if (this.townNPC && Main.netMode != 1 && this.homeless && WorldGen.spawnNPC == this.type)
        WorldGen.spawnNPC = 0;
      if (this.soundKilled > 0)
        Main.PlaySound(4, (int) this.position.X, (int) this.position.Y, this.soundKilled);
      this.NPCLoot();
      this.active = false;
      if (this.type != 26 && this.type != 27 && this.type != 28 && this.type != 29 && this.type != 111 && this.type != 143 && this.type != 144 && this.type != 145)
        return;
      --Main.invasionSize;
    }

    public void NPCLoot()
    {
      if (Main.hardMode && this.lifeMax > 1 && this.damage > 0 && !this.friendly && (double) this.position.Y > Main.rockLayer * 16.0 && Main.rand.Next(7) == 0 && this.type != 121 && (double) this.value > 0.0)
      {
        if (Main.player[(int) Player.FindClosest(this.position, this.width, this.height)].zoneEvil)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 521);
        if (Main.player[(int) Player.FindClosest(this.position, this.width, this.height)].zoneHoly)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 520);
      }
      if (Main.xMas && this.lifeMax > 1 && this.damage > 0 && !this.friendly && this.type != 121 && (double) this.value > 0.0 && Main.rand.Next(13) == 0)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, Main.rand.Next(599, 602));
      if (this.type == 109 && !NPC.downedClown)
      {
        NPC.downedClown = true;
        if (Main.netMode == 2)
          NetMessage.SendData(7);
      }
      if (this.type == 85 && (double) this.value > 0.0)
      {
        int num = Main.rand.Next(7);
        if (num == 0)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 437, pfix: -1);
        if (num == 1)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 517, pfix: -1);
        if (num == 2)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 535, pfix: -1);
        if (num == 3)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 536, pfix: -1);
        if (num == 4)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 532, pfix: -1);
        if (num == 5)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 393, pfix: -1);
        if (num == 6)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 554, pfix: -1);
      }
      if (this.type == 87)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 575, Main.rand.Next(5, 11));
      if (this.type == 143 || this.type == 144 || this.type == 145)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 593, Main.rand.Next(5, 11));
      if (this.type == 79)
      {
        if (Main.rand.Next(10) == 0)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 527);
      }
      else if (this.type == 80 && Main.rand.Next(10) == 0)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 528);
      if (this.type == 101 || this.type == 98)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 522, Main.rand.Next(2, 6));
      if (this.type == 86)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 526);
      if (this.type == 113)
      {
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 367, pfix: -1);
        if (Main.rand.Next(2) == 0)
        {
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, Main.rand.Next(489, 492), pfix: -1);
        }
        else
        {
          switch (Main.rand.Next(3))
          {
            case 0:
              Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 514, pfix: -1);
              break;
            case 1:
              Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 426, pfix: -1);
              break;
            case 2:
              Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 434, pfix: -1);
              break;
          }
        }
        if (Main.netMode != 1)
        {
          int num1 = (int) ((double) this.position.X + (double) (this.width / 2)) / 16;
          int num2 = (int) ((double) this.position.Y + (double) (this.height / 2)) / 16;
          int num3 = this.width / 2 / 16 + 1;
          for (int index1 = num1 - num3; index1 <= num1 + num3; ++index1)
          {
            for (int index2 = num2 - num3; index2 <= num2 + num3; ++index2)
            {
              if ((index1 == num1 - num3 || index1 == num1 + num3 || index2 == num2 - num3 || index2 == num2 + num3) && !Main.tile[index1, index2].active)
              {
                Main.tile[index1, index2].type = (byte) 140;
                Main.tile[index1, index2].active = true;
              }
              Main.tile[index1, index2].lava = false;
              Main.tile[index1, index2].liquid = (byte) 0;
              if (Main.netMode == 2)
                NetMessage.SendTileSquare(-1, index1, index2, 1);
              else
                WorldGen.SquareTileFrame(index1, index2);
            }
          }
        }
      }
      if (this.type == 1 || this.type == 16 || this.type == 138 || this.type == 141)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 23, Main.rand.Next(1, 3));
      if (this.type == 75)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 501, Main.rand.Next(1, 4));
      if (this.type == 81)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 23, Main.rand.Next(2, 5));
      if (this.type == 122)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 23, Main.rand.Next(5, 11));
      if (this.type == 71)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 327);
      if (this.type == 2)
      {
        if (Main.rand.Next(3) == 0)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 38);
        else if (Main.rand.Next(100) == 0)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 236);
      }
      if (this.type == 104 && Main.rand.Next(60) == 0)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 485, pfix: -1);
      if (this.type == 58)
      {
        if (Main.rand.Next(500) == 0)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 263);
        else if (Main.rand.Next(40) == 0)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 118);
      }
      if (this.type == 102 && Main.rand.Next(500) == 0)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 263);
      if ((this.type == 3 || this.type == 132) && Main.rand.Next(50) == 0)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 216, pfix: -1);
      if (this.type == 66)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 267);
      if (this.type == 62 && Main.rand.Next(50) == 0)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 272, pfix: -1);
      if (this.type == 52)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 251);
      if (this.type == 53)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 239);
      if (this.type == 54)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 260);
      if (this.type == 55)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 261);
      if (this.type == 69 && Main.rand.Next(7) == 0)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 323);
      if (this.type == 73)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 362, Main.rand.Next(1, 3));
      if (this.type == 4)
      {
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 47, Main.rand.Next(30) + 20);
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 56, Main.rand.Next(20) + 10);
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 56, Main.rand.Next(20) + 10);
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 56, Main.rand.Next(20) + 10);
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 59, Main.rand.Next(3) + 1);
      }
      if ((this.type == 6 || this.type == 94) && Main.rand.Next(3) == 0)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 68);
      if (this.type == 7 || this.type == 8 || this.type == 9)
      {
        if (Main.rand.Next(3) == 0)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 68, Main.rand.Next(1, 3));
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 69, Main.rand.Next(3, 9));
      }
      if ((this.type == 10 || this.type == 11 || this.type == 12 || this.type == 95 || this.type == 96 || this.type == 97) && Main.rand.Next(500) == 0)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 215);
      if (this.type == 47 && Main.rand.Next(75) == 0)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 243);
      if (this.type == 13 || this.type == 14 || this.type == 15)
      {
        int Stack = Main.rand.Next(1, 3);
        if (Main.rand.Next(2) == 0)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 86, Stack);
        if (Main.rand.Next(2) == 0)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 56, Main.rand.Next(2, 6));
        if (this.boss)
        {
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 56, Main.rand.Next(10, 30));
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 56, Main.rand.Next(10, 31));
        }
        if (Main.rand.Next(3) == 0 && Main.player[(int) Player.FindClosest(this.position, this.width, this.height)].statLife < Main.player[(int) Player.FindClosest(this.position, this.width, this.height)].statLifeMax)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 58);
      }
      if (this.type == 116 || this.type == 117 || this.type == 118 || this.type == 119 || this.type == 139)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 58);
      if (this.type == 63 || this.type == 64 || this.type == 103)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 282, Main.rand.Next(1, 5));
      if (this.type == 21 || this.type == 44)
      {
        if (Main.rand.Next(25) == 0)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 118);
        else if (this.type == 44)
        {
          if (Main.rand.Next(20) == 0)
            Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, Main.rand.Next(410, 412));
          else
            Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 166, Main.rand.Next(1, 4));
        }
      }
      if (this.type == 45)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 238);
      if (this.type == 50)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, Main.rand.Next(256, 259));
      if (this.type == 23 && Main.rand.Next(50) == 0)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 116);
      if (this.type == 24 && Main.rand.Next(300) == 0)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 244);
      if (this.type == 31 || this.type == 32 || this.type == 34)
      {
        if (Main.rand.Next(65) == 0)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 327);
        else
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 154, Main.rand.Next(1, 4));
      }
      if (this.type == 26 || this.type == 27 || this.type == 28 || this.type == 29 || this.type == 111)
      {
        if (Main.rand.Next(200) == 0)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 160);
        else if (Main.rand.Next(2) == 0)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 161, Main.rand.Next(1, 6));
      }
      if (this.type == 42 && Main.rand.Next(2) == 0)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 209);
      if (this.type == 43 && Main.rand.Next(4) == 0)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 210);
      if (this.type == 65)
      {
        if (Main.rand.Next(50) == 0)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 268);
        else
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 319);
      }
      if (this.type == 48 && Main.rand.Next(2) == 0)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 320);
      if (this.type == 125 || this.type == 126)
      {
        int Type = 125;
        if (this.type == 125)
          Type = 126;
        if (!NPC.AnyNPCs(Type))
        {
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 549, Main.rand.Next(20, 31));
        }
        else
        {
          this.value = 0.0f;
          this.boss = false;
        }
      }
      else if (this.type == (int) sbyte.MaxValue)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 547, Main.rand.Next(20, 31));
      else if (this.type == 134)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 548, Main.rand.Next(20, 31));
      if (this.boss)
      {
        if (this.type == 4)
          NPC.downedBoss1 = true;
        else if (this.type == 13 || this.type == 14 || this.type == 15)
        {
          NPC.downedBoss2 = true;
          this.name = "Eater of Worlds";
        }
        else if (this.type == 35)
        {
          NPC.downedBoss3 = true;
          this.name = "Skeletron";
        }
        else
          this.name = this.displayName;
        string str = this.name;
        if (this.displayName != "")
          str = this.displayName;
        int Stack = Main.rand.Next(5, 16);
        int Type = 28;
        if (this.type == 113)
          Type = 188;
        if (this.type > 113)
          Type = 499;
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, Type, Stack);
        int num = Main.rand.Next(5) + 5;
        for (int index = 0; index < num; ++index)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 58);
        if (this.type == 125 || this.type == 126)
        {
          switch (Main.netMode)
          {
            case 0:
              Main.NewText("The Twins " + Lang.misc[17], (byte) 175, (byte) 75);
              break;
            case 2:
              NetMessage.SendData(25, text: ("The Twins " + Lang.misc[17]), number: ((int) byte.MaxValue), number2: 175f, number3: 75f, number4: ((float) byte.MaxValue));
              break;
          }
        }
        else
        {
          switch (Main.netMode)
          {
            case 0:
              Main.NewText(str + " " + Lang.misc[17], (byte) 175, (byte) 75);
              break;
            case 2:
              NetMessage.SendData(25, text: (str + " " + Lang.misc[17]), number: ((int) byte.MaxValue), number2: 175f, number3: 75f, number4: ((float) byte.MaxValue));
              break;
          }
        }
        if (this.type == 113 && Main.netMode != 1)
          WorldGen.StartHardmode();
        if (Main.netMode == 2)
          NetMessage.SendData(7);
      }
      if (Main.rand.Next(6) == 0 && this.lifeMax > 1 && this.damage > 0)
      {
        if (Main.rand.Next(2) == 0 && Main.player[(int) Player.FindClosest(this.position, this.width, this.height)].statMana < Main.player[(int) Player.FindClosest(this.position, this.width, this.height)].statManaMax)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 184);
        else if (Main.rand.Next(2) == 0 && Main.player[(int) Player.FindClosest(this.position, this.width, this.height)].statLife < Main.player[(int) Player.FindClosest(this.position, this.width, this.height)].statLifeMax)
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 58);
      }
      if (Main.rand.Next(2) == 0 && this.lifeMax > 1 && this.damage > 0 && Main.player[(int) Player.FindClosest(this.position, this.width, this.height)].statMana < Main.player[(int) Player.FindClosest(this.position, this.width, this.height)].statManaMax)
        Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 184);
      float num4 = this.value * (float) (1.0 + (double) Main.rand.Next(-20, 21) * 0.00999999977648258);
      if (Main.rand.Next(5) == 0)
        num4 *= (float) (1.0 + (double) Main.rand.Next(5, 11) * 0.00999999977648258);
      if (Main.rand.Next(10) == 0)
        num4 *= (float) (1.0 + (double) Main.rand.Next(10, 21) * 0.00999999977648258);
      if (Main.rand.Next(15) == 0)
        num4 *= (float) (1.0 + (double) Main.rand.Next(15, 31) * 0.00999999977648258);
      if (Main.rand.Next(20) == 0)
        num4 *= (float) (1.0 + (double) Main.rand.Next(20, 41) * 0.00999999977648258);
      while ((int) num4 > 0)
      {
        if ((double) num4 > 1000000.0)
        {
          int Stack = (int) ((double) num4 / 1000000.0);
          if (Stack > 50 && Main.rand.Next(5) == 0)
            Stack /= Main.rand.Next(3) + 1;
          if (Main.rand.Next(5) == 0)
            Stack /= Main.rand.Next(3) + 1;
          num4 -= (float) (1000000 * Stack);
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 74, Stack);
        }
        else if ((double) num4 > 10000.0)
        {
          int Stack = (int) ((double) num4 / 10000.0);
          if (Stack > 50 && Main.rand.Next(5) == 0)
            Stack /= Main.rand.Next(3) + 1;
          if (Main.rand.Next(5) == 0)
            Stack /= Main.rand.Next(3) + 1;
          num4 -= (float) (10000 * Stack);
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 73, Stack);
        }
        else if ((double) num4 > 100.0)
        {
          int Stack = (int) ((double) num4 / 100.0);
          if (Stack > 50 && Main.rand.Next(5) == 0)
            Stack /= Main.rand.Next(3) + 1;
          if (Main.rand.Next(5) == 0)
            Stack /= Main.rand.Next(3) + 1;
          num4 -= (float) (100 * Stack);
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 72, Stack);
        }
        else
        {
          int Stack = (int) num4;
          if (Stack > 50 && Main.rand.Next(5) == 0)
            Stack /= Main.rand.Next(3) + 1;
          if (Main.rand.Next(5) == 0)
            Stack /= Main.rand.Next(4) + 1;
          if (Stack < 1)
            Stack = 1;
          num4 -= (float) Stack;
          Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 71, Stack);
        }
      }
    }

    public void HitEffect(int hitDirection = 0, double dmg = 10.0)
    {
      if (!this.active)
        return;
      if (this.type == 1 || this.type == 16 || this.type == 71)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 4, (float) hitDirection, -1f, this.alpha, this.color);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 4, (float) (2 * hitDirection), -2f, this.alpha, this.color);
          if (Main.netMode != 1 && this.type == 16)
          {
            int num = Main.rand.Next(2) + 2;
            for (int index = 0; index < num; ++index)
            {
              int number = NPC.NewNPC((int) ((double) this.position.X + (double) (this.width / 2)), (int) ((double) this.position.Y + (double) this.height), 1);
              Main.npc[number].SetDefaults("Baby Slime");
              Main.npc[number].velocity.X = this.velocity.X * 2f;
              Main.npc[number].velocity.Y = this.velocity.Y;
              Main.npc[number].velocity.X += (float) ((double) Main.rand.Next(-20, 20) * 0.100000001490116 + (double) (index * this.direction) * 0.300000011920929);
              Main.npc[number].velocity.Y -= (float) Main.rand.Next(0, 10) * 0.1f + (float) index;
              Main.npc[number].ai[1] = (float) index;
              if (Main.netMode == 2 && number < 200)
                NetMessage.SendData(23, number: number);
            }
          }
        }
      }
      if (this.type == 143 || this.type == 144 || this.type == 145)
      {
        if (this.life > 0)
        {
          for (int index1 = 0; (double) index1 < dmg / (double) this.lifeMax * 100.0; ++index1)
          {
            int index2 = Dust.NewDust(this.position, this.width, this.height, 76, (float) hitDirection, -1f);
            Main.dust[index2].noGravity = true;
          }
        }
        else
        {
          for (int index3 = 0; index3 < 50; ++index3)
          {
            int index4 = Dust.NewDust(this.position, this.width, this.height, 76, (float) hitDirection, -1f);
            Main.dust[index4].noGravity = true;
            Main.dust[index4].scale *= 1.2f;
          }
        }
      }
      if (this.type == 141)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 4, (float) hitDirection, -1f, this.alpha, new Color(210, 230, 140));
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 4, (float) (2 * hitDirection), -2f, this.alpha, new Color(210, 230, 140));
        }
      }
      if (this.type == 112)
      {
        for (int index5 = 0; index5 < 20; ++index5)
        {
          int index6 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + 2f), this.width, this.height, 18, Alpha: 100, Scale: 2f);
          if (Main.rand.Next(2) == 0)
          {
            Main.dust[index6].scale *= 0.6f;
          }
          else
          {
            Main.dust[index6].velocity *= 1.4f;
            Main.dust[index6].noGravity = true;
          }
        }
      }
      if (this.type == 81 || this.type == 121)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 14, Alpha: this.alpha, newColor: this.color);
        }
        else
        {
          for (int index7 = 0; index7 < 50; ++index7)
          {
            int index8 = Dust.NewDust(this.position, this.width, this.height, 14, (float) hitDirection, Alpha: this.alpha, newColor: this.color);
            Main.dust[index8].velocity *= 2f;
          }
          if (Main.netMode != 1)
          {
            if (this.type == 121)
            {
              int number = NPC.NewNPC((int) ((double) this.position.X + (double) (this.width / 2)), (int) ((double) this.position.Y + (double) this.height), 81);
              Main.npc[number].SetDefaults("Slimer2");
              Main.npc[number].velocity.X = this.velocity.X;
              Main.npc[number].velocity.Y = this.velocity.Y;
              Gore.NewGore(this.position, this.velocity, 94, this.scale);
              if (Main.netMode == 2 && number < 200)
                NetMessage.SendData(23, number: number);
            }
            else if ((double) this.scale >= 1.0)
            {
              int num = Main.rand.Next(2) + 2;
              for (int index = 0; index < num; ++index)
              {
                int number = NPC.NewNPC((int) ((double) this.position.X + (double) (this.width / 2)), (int) ((double) this.position.Y + (double) this.height), 1);
                Main.npc[number].SetDefaults("Slimeling");
                Main.npc[number].velocity.X = this.velocity.X * 3f;
                Main.npc[number].velocity.Y = this.velocity.Y;
                Main.npc[number].velocity.X += (float) ((double) Main.rand.Next(-10, 10) * 0.100000001490116 + (double) (index * this.direction) * 0.300000011920929);
                Main.npc[number].velocity.Y -= (float) Main.rand.Next(0, 10) * 0.1f + (float) index;
                Main.npc[number].ai[1] = (float) index;
                if (Main.netMode == 2 && number < 200)
                  NetMessage.SendData(23, number: number);
              }
            }
          }
        }
      }
      if (this.type == 120 || this.type == 137 || this.type == 138)
      {
        if (this.life > 0)
        {
          for (int index9 = 0; (double) index9 < dmg / (double) this.lifeMax * 50.0; ++index9)
          {
            int index10 = Dust.NewDust(this.position, this.width, this.height, 71, Alpha: 200);
            Main.dust[index10].velocity *= 1.5f;
          }
        }
        else
        {
          for (int index11 = 0; index11 < 50; ++index11)
          {
            int index12 = Dust.NewDust(this.position, this.width, this.height, 71, (float) hitDirection, Alpha: 200);
            Main.dust[index12].velocity *= 1.5f;
          }
        }
      }
      if (this.type == 122)
      {
        if (this.life > 0)
        {
          for (int index13 = 0; (double) index13 < dmg / (double) this.lifeMax * 50.0; ++index13)
          {
            int index14 = Dust.NewDust(this.position, this.width, this.height, 72, Alpha: 200);
            Main.dust[index14].velocity *= 1.5f;
          }
        }
        else
        {
          for (int index15 = 0; index15 < 50; ++index15)
          {
            int index16 = Dust.NewDust(this.position, this.width, this.height, 72, (float) hitDirection, Alpha: 200);
            Main.dust[index16].velocity *= 1.5f;
          }
        }
      }
      if (this.type == 75)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 55, Alpha: 200, newColor: this.color);
        }
        else
        {
          for (int index17 = 0; index17 < 50; ++index17)
          {
            int index18 = Dust.NewDust(this.position, this.width, this.height, 55, (float) hitDirection, Alpha: 200, newColor: this.color);
            Main.dust[index18].velocity *= 2f;
          }
        }
      }
      if (this.type == 63 || this.type == 64 || this.type == 103)
      {
        Color newColor = new Color(50, 120, (int) byte.MaxValue, 100);
        if (this.type == 64)
          newColor = new Color(225, 70, 140, 100);
        if (this.type == 103)
          newColor = new Color(70, 225, 140, 100);
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 4, (float) hitDirection, -1f, newColor: newColor);
        }
        else
        {
          for (int index = 0; index < 25; ++index)
            Dust.NewDust(this.position, this.width, this.height, 4, (float) (2 * hitDirection), -2f, newColor: newColor);
        }
      }
      else if (this.type == 59 || this.type == 60)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 80.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 6, (float) (hitDirection * 2), -1f, this.alpha, Scale: 1.5f);
        }
        else
        {
          for (int index = 0; index < 40; ++index)
            Dust.NewDust(this.position, this.width, this.height, 6, (float) (hitDirection * 2), -1f, this.alpha, Scale: 1.5f);
        }
      }
      else if (this.type == 50)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 300.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 4, (float) hitDirection, -1f, 175, new Color(0, 80, (int) byte.MaxValue, 100));
        }
        else
        {
          for (int index = 0; index < 200; ++index)
            Dust.NewDust(this.position, this.width, this.height, 4, (float) (2 * hitDirection), -2f, 175, new Color(0, 80, (int) byte.MaxValue, 100));
          if (Main.netMode == 1)
            return;
          int num = Main.rand.Next(4) + 4;
          for (int index = 0; index < num; ++index)
          {
            int number = NPC.NewNPC((int) ((double) this.position.X + (double) Main.rand.Next(this.width - 32)), (int) ((double) this.position.Y + (double) Main.rand.Next(this.height - 32)), 1);
            Main.npc[number].SetDefaults(1);
            Main.npc[number].velocity.X = (float) Main.rand.Next(-15, 16) * 0.1f;
            Main.npc[number].velocity.Y = (float) Main.rand.Next(-30, 1) * 0.1f;
            Main.npc[number].ai[1] = (float) Main.rand.Next(3);
            if (Main.netMode == 2 && number < 200)
              NetMessage.SendData(23, number: number);
          }
        }
      }
      else if (this.type == 49 || this.type == 51 || this.type == 93)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 30.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 15; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) (2 * hitDirection), -2f);
          if (this.type == 51)
            Gore.NewGore(this.position, this.velocity, 83);
          else if (this.type == 93)
            Gore.NewGore(this.position, this.velocity, 107);
          else
            Gore.NewGore(this.position, this.velocity, 82);
        }
      }
      else if (this.type == 46 || this.type == 55 || this.type == 67 || this.type == 74 || this.type == 102)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 20.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 10; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) (2 * hitDirection), -2f);
          if (this.type == 46)
          {
            Gore.NewGore(this.position, this.velocity, 76);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y), this.velocity, 77);
          }
          else if (this.type == 67)
          {
            Gore.NewGore(this.position, this.velocity, 95);
            Gore.NewGore(this.position, this.velocity, 95);
            Gore.NewGore(this.position, this.velocity, 96);
          }
          else if (this.type == 74)
          {
            Gore.NewGore(this.position, this.velocity, 100);
          }
          else
          {
            if (this.type != 102)
              return;
            Gore.NewGore(this.position, this.velocity, 116);
          }
        }
      }
      else if (this.type == 47 || this.type == 57 || this.type == 58)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 20.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 10; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) (2 * hitDirection), -2f);
          if (this.type == 57)
            Gore.NewGore(new Vector2(this.position.X, this.position.Y), this.velocity, 84);
          else if (this.type == 58)
          {
            Gore.NewGore(new Vector2(this.position.X, this.position.Y), this.velocity, 85);
          }
          else
          {
            Gore.NewGore(this.position, this.velocity, 78);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y), this.velocity, 79);
          }
        }
      }
      else if (this.type == 2)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) (2 * hitDirection), -2f);
          Gore.NewGore(this.position, this.velocity, 1);
          Gore.NewGore(new Vector2(this.position.X + 14f, this.position.Y), this.velocity, 2);
        }
      }
      else if (this.type == 133)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
          if ((double) this.life >= (double) this.lifeMax * 0.5 || (double) this.localAI[0] != 0.0)
            return;
          this.localAI[0] = 1f;
          Gore.NewGore(this.position, this.velocity, 1);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) (2 * hitDirection), -2f);
          Gore.NewGore(this.position, this.velocity, 155);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 14f), this.velocity, 155);
        }
      }
      else if (this.type == 69)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) (2 * hitDirection), -2f);
          Gore.NewGore(this.position, this.velocity, 97);
          Gore.NewGore(this.position, this.velocity, 98);
        }
      }
      else if (this.type == 61)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) (2 * hitDirection), -2f);
          Gore.NewGore(this.position, this.velocity, 86);
          Gore.NewGore(new Vector2(this.position.X + 14f, this.position.Y), this.velocity, 87);
          Gore.NewGore(new Vector2(this.position.X + 14f, this.position.Y), this.velocity, 88);
        }
      }
      else if (this.type == 65)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 150.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 75; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) (2 * hitDirection), -2f);
          Gore.NewGore(this.position, this.velocity * 0.8f, 89);
          Gore.NewGore(new Vector2(this.position.X + 14f, this.position.Y), this.velocity * 0.8f, 90);
          Gore.NewGore(new Vector2(this.position.X + 14f, this.position.Y), this.velocity * 0.8f, 91);
          Gore.NewGore(new Vector2(this.position.X + 14f, this.position.Y), this.velocity * 0.8f, 92);
        }
      }
      else if (this.type == 3 || this.type == 52 || this.type == 53 || this.type == 104 || this.type == 109 || this.type == 132)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, 2.5f * (float) hitDirection, -2.5f);
          if (this.type == 104)
          {
            Gore.NewGore(this.position, this.velocity, 117);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 118);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 118);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 119);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 119);
          }
          else if (this.type == 109)
          {
            Gore.NewGore(this.position, this.velocity, 121);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 122);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 122);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 123);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 123);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 46f), this.velocity, 120);
          }
          else
          {
            if (this.type == 132)
              Gore.NewGore(this.position, this.velocity, 154);
            else
              Gore.NewGore(this.position, this.velocity, 3);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 4);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 4);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 5);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 5);
          }
        }
      }
      else if (this.type == 83 || this.type == 84)
      {
        if (this.life > 0)
        {
          for (int index19 = 0; (double) index19 < dmg / (double) this.lifeMax * 50.0; ++index19)
          {
            int index20 = Dust.NewDust(this.position, this.width, this.height, 31, Scale: 1.5f);
            Main.dust[index20].noGravity = true;
          }
        }
        else
        {
          for (int index21 = 0; index21 < 20; ++index21)
          {
            int index22 = Dust.NewDust(this.position, this.width, this.height, 31, Scale: 1.5f);
            Main.dust[index22].velocity *= 2f;
            Main.dust[index22].noGravity = true;
          }
          int index23 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) (this.height / 2) - 10.0)), new Vector2((float) Main.rand.Next(-2, 3), (float) Main.rand.Next(-2, 3)), 61, this.scale);
          Main.gore[index23].velocity *= 0.5f;
          int index24 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) (this.height / 2) - 10.0)), new Vector2((float) Main.rand.Next(-2, 3), (float) Main.rand.Next(-2, 3)), 61, this.scale);
          Main.gore[index24].velocity *= 0.5f;
          int index25 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) (this.height / 2) - 10.0)), new Vector2((float) Main.rand.Next(-2, 3), (float) Main.rand.Next(-2, 3)), 61, this.scale);
          Main.gore[index25].velocity *= 0.5f;
        }
      }
      else if (this.type == 4 || this.type == 126 || this.type == 125)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 150; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) (2 * hitDirection), -2f);
          for (int index = 0; index < 2; ++index)
          {
            Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 2);
            Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 7);
            Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 9);
            if (this.type == 4)
            {
              Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 10);
              Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
            }
            else if (this.type == 125)
              Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 146);
            else if (this.type == 126)
              Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 145);
          }
          if (this.type != 125 && this.type != 126)
            return;
          for (int index26 = 0; index26 < 10; ++index26)
          {
            int index27 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, Alpha: 100, Scale: 1.5f);
            Main.dust[index27].velocity *= 1.4f;
          }
          for (int index28 = 0; index28 < 5; ++index28)
          {
            int index29 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 2.5f);
            Main.dust[index29].noGravity = true;
            Main.dust[index29].velocity *= 5f;
            int index30 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 1.5f);
            Main.dust[index30].velocity *= 3f;
          }
          int index31 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
          Main.gore[index31].velocity *= 0.4f;
          ++Main.gore[index31].velocity.X;
          ++Main.gore[index31].velocity.Y;
          int index32 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
          Main.gore[index32].velocity *= 0.4f;
          --Main.gore[index32].velocity.X;
          ++Main.gore[index32].velocity.Y;
          int index33 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
          Main.gore[index33].velocity *= 0.4f;
          ++Main.gore[index33].velocity.X;
          --Main.gore[index33].velocity.Y;
          int index34 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
          Main.gore[index34].velocity *= 0.4f;
          --Main.gore[index34].velocity.X;
          --Main.gore[index34].velocity.Y;
        }
      }
      else if (this.type == 5)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 20; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) (2 * hitDirection), -2f);
          Gore.NewGore(this.position, this.velocity, 6);
          Gore.NewGore(this.position, this.velocity, 7);
        }
      }
      else if (this.type == 113 || this.type == 114)
      {
        if (this.life > 0)
        {
          for (int index = 0; index < 20; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) (2 * hitDirection), -1f);
          if (this.type == 114)
          {
            Gore.NewGore(new Vector2(this.position.X, this.position.Y), this.velocity, 137, this.scale);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float) (this.height / 2)), this.velocity, 139, this.scale);
            Gore.NewGore(new Vector2(this.position.X + (float) (this.width / 2), this.position.Y), this.velocity, 139, this.scale);
            Gore.NewGore(new Vector2(this.position.X + (float) (this.width / 2), this.position.Y + (float) (this.height / 2)), this.velocity, 137, this.scale);
          }
          else
          {
            Gore.NewGore(new Vector2(this.position.X, this.position.Y), this.velocity, 137, this.scale);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float) (this.height / 2)), this.velocity, 138, this.scale);
            Gore.NewGore(new Vector2(this.position.X + (float) (this.width / 2), this.position.Y), this.velocity, 138, this.scale);
            Gore.NewGore(new Vector2(this.position.X + (float) (this.width / 2), this.position.Y + (float) (this.height / 2)), this.velocity, 137, this.scale);
            if ((double) Main.player[Main.myPlayer].position.Y / 16.0 <= (double) (Main.maxTilesY - 250))
              return;
            int y = (int) Main.screenPosition.Y;
            int num1 = y + Main.screenWidth;
            int x = (int) this.position.X;
            if (this.direction > 0)
              x -= 80;
            int num2 = x + 140;
            int num3 = x;
            for (int index35 = y; index35 < num1; index35 += 50)
            {
              for (; num3 < num2; num3 += 46)
              {
                for (int index36 = 0; index36 < 5; ++index36)
                  Dust.NewDust(new Vector2((float) num3, (float) index35), 32, 32, 5, (float) Main.rand.Next(-60, 61) * 0.1f, (float) Main.rand.Next(-60, 61) * 0.1f);
                Vector2 Velocity = new Vector2((float) Main.rand.Next(-80, 81) * 0.1f, (float) Main.rand.Next(-60, 21) * 0.1f);
                Gore.NewGore(new Vector2((float) num3, (float) index35), Velocity, Main.rand.Next(140, 143));
              }
              num3 = x;
            }
          }
        }
      }
      else if (this.type == 115 || this.type == 116)
      {
        if (this.life > 0)
        {
          for (int index = 0; index < 5; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else if (this.type == 115 && Main.netMode != 1)
        {
          NPC.NewNPC((int) ((double) this.position.X + (double) (this.width / 2)), (int) ((double) this.position.Y + (double) this.height), 116);
          for (int index = 0; index < 10; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 20; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
          Gore.NewGore(this.position, this.velocity, 132, this.scale);
          Gore.NewGore(this.position, this.velocity, 133, this.scale);
        }
      }
      else if (this.type >= 117 && this.type <= 119)
      {
        if (this.life > 0)
        {
          for (int index = 0; index < 5; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 10; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
          Gore.NewGore(this.position, this.velocity, 134 + this.type - 117, this.scale);
        }
      }
      else if (this.type == 6 || this.type == 94)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 18, (float) hitDirection, -1f, this.alpha, this.color, this.scale);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 18, (float) hitDirection, -2f, this.alpha, this.color, this.scale);
          if (this.type == 94)
          {
            int num = Gore.NewGore(this.position, this.velocity, 108, this.scale);
            num = Gore.NewGore(this.position, this.velocity, 108, this.scale);
            num = Gore.NewGore(this.position, this.velocity, 109, this.scale);
            num = Gore.NewGore(this.position, this.velocity, 110, this.scale);
          }
          else
          {
            int index37 = Gore.NewGore(this.position, this.velocity, 14, this.scale);
            Main.gore[index37].alpha = this.alpha;
            int index38 = Gore.NewGore(this.position, this.velocity, 15, this.scale);
            Main.gore[index38].alpha = this.alpha;
          }
        }
      }
      else if (this.type == 101)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 18, (float) hitDirection, -1f, this.alpha, this.color, this.scale);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 18, (float) hitDirection, -2f, this.alpha, this.color, this.scale);
          Gore.NewGore(this.position, this.velocity, 110, this.scale);
          Gore.NewGore(this.position, this.velocity, 114, this.scale);
          Gore.NewGore(this.position, this.velocity, 114, this.scale);
          Gore.NewGore(this.position, this.velocity, 115, this.scale);
        }
      }
      else if (this.type == 7 || this.type == 8 || this.type == 9)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 18, (float) hitDirection, -1f, this.alpha, this.color, this.scale);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 18, (float) hitDirection, -2f, this.alpha, this.color, this.scale);
          int index39 = Gore.NewGore(this.position, this.velocity, this.type - 7 + 18);
          Main.gore[index39].alpha = this.alpha;
        }
      }
      else if (this.type == 98 || this.type == 99 || this.type == 100)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 18, (float) hitDirection, -1f, this.alpha, this.color, this.scale);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 18, (float) hitDirection, -2f, this.alpha, this.color, this.scale);
          int index40 = Gore.NewGore(this.position, this.velocity, 110);
          Main.gore[index40].alpha = this.alpha;
        }
      }
      else if (this.type == 10 || this.type == 11 || this.type == 12)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 10; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, 2.5f * (float) hitDirection, -2.5f);
          Gore.NewGore(this.position, this.velocity, this.type - 7 + 18);
        }
      }
      else if (this.type == 95 || this.type == 96 || this.type == 97)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 10; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, 2.5f * (float) hitDirection, -2.5f);
          Gore.NewGore(this.position, this.velocity, this.type - 95 + 111);
        }
      }
      else if (this.type == 13 || this.type == 14 || this.type == 15)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 18, (float) hitDirection, -1f, this.alpha, this.color, this.scale);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 18, (float) hitDirection, -2f, this.alpha, this.color, this.scale);
          if (this.type == 13)
          {
            Gore.NewGore(this.position, this.velocity, 24);
            Gore.NewGore(this.position, this.velocity, 25);
          }
          else if (this.type == 14)
          {
            Gore.NewGore(this.position, this.velocity, 26);
            Gore.NewGore(this.position, this.velocity, 27);
          }
          else
          {
            Gore.NewGore(this.position, this.velocity, 28);
            Gore.NewGore(this.position, this.velocity, 29);
          }
        }
      }
      else if (this.type == 17)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, 2.5f * (float) hitDirection, -2.5f);
          Gore.NewGore(this.position, this.velocity, 30);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 31);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 31);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 32);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 32);
        }
      }
      else if (this.type == 86)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, 2.5f * (float) hitDirection, -2.5f);
          Gore.NewGore(this.position, this.velocity, 101);
          Gore.NewGore(this.position, this.velocity, 102);
          Gore.NewGore(this.position, this.velocity, 103);
          Gore.NewGore(this.position, this.velocity, 103);
          Gore.NewGore(this.position, this.velocity, 104);
          Gore.NewGore(this.position, this.velocity, 104);
          Gore.NewGore(this.position, this.velocity, 105);
        }
      }
      else if (this.type >= 105 && this.type <= 108)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, 2.5f * (float) hitDirection, -2.5f);
          if (this.type == 105 || this.type == 107)
          {
            Gore.NewGore(this.position, this.velocity, 124);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 125);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 125);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 126);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 126);
          }
          else
          {
            Gore.NewGore(this.position, this.velocity, (int) sbyte.MaxValue);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 128);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 128);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 129);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 129);
          }
        }
      }
      else if (this.type == 123 || this.type == 124)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, 2.5f * (float) hitDirection, -2.5f);
          Gore.NewGore(this.position, this.velocity, 151);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 152);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 152);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 153);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 153);
        }
      }
      else if (this.type == 22)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, 2.5f * (float) hitDirection, -2.5f);
          Gore.NewGore(this.position, this.velocity, 73);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 74);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 74);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 75);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 75);
        }
      }
      else if (this.type == 142)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, 2.5f * (float) hitDirection, -2.5f);
          Gore.NewGore(this.position, this.velocity, 157);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 158);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 158);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 159);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 159);
        }
      }
      else if (this.type == 37 || this.type == 54)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, 2.5f * (float) hitDirection, -2.5f);
          Gore.NewGore(this.position, this.velocity, 58);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 59);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 59);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 60);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 60);
        }
      }
      else if (this.type == 18)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, 2.5f * (float) hitDirection, -2.5f);
          Gore.NewGore(this.position, this.velocity, 33);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 34);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 34);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 35);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 35);
        }
      }
      else if (this.type == 19)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, 2.5f * (float) hitDirection, -2.5f);
          Gore.NewGore(this.position, this.velocity, 36);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 37);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 37);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 38);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 38);
        }
      }
      else if (this.type == 38)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, 2.5f * (float) hitDirection, -2.5f);
          Gore.NewGore(this.position, this.velocity, 64);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 65);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 65);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 66);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 66);
        }
      }
      else if (this.type == 20)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, 2.5f * (float) hitDirection, -2.5f);
          Gore.NewGore(this.position, this.velocity, 39);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 40);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 40);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 41);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 41);
        }
      }
      else if (this.type == 21 || this.type == 31 || this.type == 32 || this.type == 44 || this.type == 45 || this.type == 77 || this.type == 110)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 26, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 20; ++index)
            Dust.NewDust(this.position, this.width, this.height, 26, 2.5f * (float) hitDirection, -2.5f);
          Gore.NewGore(this.position, this.velocity, 42, this.scale);
          if (this.type == 77)
            Gore.NewGore(this.position, this.velocity, 106, this.scale);
          if (this.type == 110)
            Gore.NewGore(this.position, this.velocity, 130, this.scale);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 43, this.scale);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 43, this.scale);
          if (this.type == 110)
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 131, this.scale);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 44, this.scale);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 44, this.scale);
        }
      }
      else if (this.type == 85)
      {
        int Type = 7;
        if ((double) this.ai[3] == 2.0)
          Type = 10;
        if ((double) this.ai[3] == 3.0)
          Type = 37;
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, Type);
        }
        else
        {
          for (int index = 0; index < 20; ++index)
            Dust.NewDust(this.position, this.width, this.height, Type);
          int index41 = Gore.NewGore(new Vector2(this.position.X, this.position.Y - 10f), new Vector2((float) hitDirection, 0.0f), 61, this.scale);
          Main.gore[index41].velocity *= 0.3f;
          int index42 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) (this.height / 2) - 10.0)), new Vector2((float) hitDirection, 0.0f), 62, this.scale);
          Main.gore[index42].velocity *= 0.3f;
          int index43 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) this.height - 10.0)), new Vector2((float) hitDirection, 0.0f), 63, this.scale);
          Main.gore[index43].velocity *= 0.3f;
        }
      }
      else if (this.type >= 87 && this.type <= 92)
      {
        if (this.life > 0)
        {
          for (int index44 = 0; (double) index44 < dmg / (double) this.lifeMax * 50.0; ++index44)
          {
            int index45 = Dust.NewDust(this.position, this.width, this.height, 16, Scale: 1.5f);
            Main.dust[index45].velocity *= 1.5f;
            Main.dust[index45].noGravity = true;
          }
        }
        else
        {
          for (int index46 = 0; index46 < 10; ++index46)
          {
            int index47 = Dust.NewDust(this.position, this.width, this.height, 16, Scale: 1.5f);
            Main.dust[index47].velocity *= 2f;
            Main.dust[index47].noGravity = true;
          }
          int num = Main.rand.Next(1, 4);
          for (int index48 = 0; index48 < num; ++index48)
          {
            int index49 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) (this.height / 2) - 10.0)), new Vector2((float) hitDirection, 0.0f), Main.rand.Next(11, 14), this.scale);
            Main.gore[index49].velocity *= 0.8f;
          }
        }
      }
      else if (this.type == 78 || this.type == 79 || this.type == 80)
      {
        if (this.life > 0)
        {
          for (int index50 = 0; (double) index50 < dmg / (double) this.lifeMax * 50.0; ++index50)
          {
            int index51 = Dust.NewDust(this.position, this.width, this.height, 31, Scale: 1.5f);
            Main.dust[index51].velocity *= 2f;
            Main.dust[index51].noGravity = true;
          }
        }
        else
        {
          for (int index52 = 0; index52 < 20; ++index52)
          {
            int index53 = Dust.NewDust(this.position, this.width, this.height, 31, Scale: 1.5f);
            Main.dust[index53].velocity *= 2f;
            Main.dust[index53].noGravity = true;
          }
          int index54 = Gore.NewGore(new Vector2(this.position.X, this.position.Y - 10f), new Vector2((float) hitDirection, 0.0f), 61, this.scale);
          Main.gore[index54].velocity *= 0.3f;
          int index55 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) (this.height / 2) - 10.0)), new Vector2((float) hitDirection, 0.0f), 62, this.scale);
          Main.gore[index55].velocity *= 0.3f;
          int index56 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) this.height - 10.0)), new Vector2((float) hitDirection, 0.0f), 63, this.scale);
          Main.gore[index56].velocity *= 0.3f;
        }
      }
      else if (this.type == 82)
      {
        if (this.life > 0)
        {
          for (int index57 = 0; (double) index57 < dmg / (double) this.lifeMax * 50.0; ++index57)
          {
            int index58 = Dust.NewDust(this.position, this.width, this.height, 54, Alpha: 50, Scale: 1.5f);
            Main.dust[index58].velocity *= 2f;
            Main.dust[index58].noGravity = true;
          }
        }
        else
        {
          for (int index59 = 0; index59 < 20; ++index59)
          {
            int index60 = Dust.NewDust(this.position, this.width, this.height, 54, Alpha: 50, Scale: 1.5f);
            Main.dust[index60].velocity *= 2f;
            Main.dust[index60].noGravity = true;
          }
          int index61 = Gore.NewGore(new Vector2(this.position.X, this.position.Y - 10f), new Vector2((float) hitDirection, 0.0f), 99, this.scale);
          Main.gore[index61].velocity *= 0.3f;
          int index62 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) (this.height / 2) - 15.0)), new Vector2((float) hitDirection, 0.0f), 99, this.scale);
          Main.gore[index62].velocity *= 0.3f;
          int index63 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) this.height - 20.0)), new Vector2((float) hitDirection, 0.0f), 99, this.scale);
          Main.gore[index63].velocity *= 0.3f;
        }
      }
      else if (this.type == 140)
      {
        if (this.life > 0)
          return;
        for (int index64 = 0; index64 < 20; ++index64)
        {
          int index65 = Dust.NewDust(this.position, this.width, this.height, 54, Alpha: 50, Scale: 1.5f);
          Main.dust[index65].velocity *= 2f;
          Main.dust[index65].noGravity = true;
        }
        int index66 = Gore.NewGore(new Vector2(this.position.X, this.position.Y - 10f), new Vector2((float) hitDirection, 0.0f), 99, this.scale);
        Main.gore[index66].velocity *= 0.3f;
        int index67 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) (this.height / 2) - 15.0)), new Vector2((float) hitDirection, 0.0f), 99, this.scale);
        Main.gore[index67].velocity *= 0.3f;
        int index68 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) this.height - 20.0)), new Vector2((float) hitDirection, 0.0f), 99, this.scale);
        Main.gore[index68].velocity *= 0.3f;
      }
      else if (this.type == 39 || this.type == 40 || this.type == 41)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 26, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 20; ++index)
            Dust.NewDust(this.position, this.width, this.height, 26, 2.5f * (float) hitDirection, -2.5f);
          Gore.NewGore(this.position, this.velocity, this.type - 39 + 67);
        }
      }
      else if (this.type == 34)
      {
        if (this.life > 0)
        {
          for (int index69 = 0; (double) index69 < dmg / (double) this.lifeMax * 30.0; ++index69)
          {
            int index70 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 15, (float) (-(double) this.velocity.X * 0.200000002980232), (float) (-(double) this.velocity.Y * 0.200000002980232), 100, Scale: 1.8f);
            Main.dust[index70].noLight = true;
            Main.dust[index70].noGravity = true;
            Main.dust[index70].velocity *= 1.3f;
            int index71 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 26, (float) (-(double) this.velocity.X * 0.200000002980232), (float) (-(double) this.velocity.Y * 0.200000002980232), Scale: 0.9f);
            Main.dust[index71].noLight = true;
            Main.dust[index71].velocity *= 1.3f;
          }
        }
        else
        {
          for (int index72 = 0; index72 < 15; ++index72)
          {
            int index73 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 15, (float) (-(double) this.velocity.X * 0.200000002980232), (float) (-(double) this.velocity.Y * 0.200000002980232), 100, Scale: 1.8f);
            Main.dust[index73].noLight = true;
            Main.dust[index73].noGravity = true;
            Main.dust[index73].velocity *= 1.3f;
            int index74 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 26, (float) (-(double) this.velocity.X * 0.200000002980232), (float) (-(double) this.velocity.Y * 0.200000002980232), Scale: 0.9f);
            Main.dust[index74].noLight = true;
            Main.dust[index74].velocity *= 1.3f;
          }
        }
      }
      else if (this.type == 35 || this.type == 36)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 26, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 150; ++index)
            Dust.NewDust(this.position, this.width, this.height, 26, 2.5f * (float) hitDirection, -2.5f);
          if (this.type == 35)
          {
            Gore.NewGore(this.position, this.velocity, 54);
            Gore.NewGore(this.position, this.velocity, 55);
          }
          else
          {
            Gore.NewGore(this.position, this.velocity, 56);
            Gore.NewGore(this.position, this.velocity, 57);
            Gore.NewGore(this.position, this.velocity, 57);
            Gore.NewGore(this.position, this.velocity, 57);
          }
        }
      }
      else if (this.type == 139)
      {
        if (this.life > 0)
          return;
        for (int index75 = 0; index75 < 10; ++index75)
        {
          int index76 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, Alpha: 100, Scale: 1.5f);
          Main.dust[index76].velocity *= 1.4f;
        }
        for (int index77 = 0; index77 < 5; ++index77)
        {
          int index78 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 2.5f);
          Main.dust[index78].noGravity = true;
          Main.dust[index78].velocity *= 5f;
          int index79 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 1.5f);
          Main.dust[index79].velocity *= 3f;
        }
        int index80 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index80].velocity *= 0.4f;
        ++Main.gore[index80].velocity.X;
        ++Main.gore[index80].velocity.Y;
        int index81 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index81].velocity *= 0.4f;
        --Main.gore[index81].velocity.X;
        ++Main.gore[index81].velocity.Y;
        int index82 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index82].velocity *= 0.4f;
        ++Main.gore[index82].velocity.X;
        --Main.gore[index82].velocity.Y;
        int index83 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index83].velocity *= 0.4f;
        --Main.gore[index83].velocity.X;
        --Main.gore[index83].velocity.Y;
      }
      else if (this.type >= 134 && this.type <= 136)
      {
        if (this.type == 135 && this.life > 0 && Main.netMode != 1 && (double) this.ai[2] == 0.0 && Main.rand.Next(25) == 0)
        {
          this.ai[2] = 1f;
          int number = NPC.NewNPC((int) ((double) this.position.X + (double) (this.width / 2)), (int) ((double) this.position.Y + (double) this.height), 139);
          if (Main.netMode == 2 && number < 200)
            NetMessage.SendData(23, number: number);
          this.netUpdate = true;
        }
        if (this.life > 0)
          return;
        Gore.NewGore(this.position, this.velocity, 156);
        if (Main.rand.Next(2) != 0)
          return;
        for (int index84 = 0; index84 < 10; ++index84)
        {
          int index85 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, Alpha: 100, Scale: 1.5f);
          Main.dust[index85].velocity *= 1.4f;
        }
        for (int index86 = 0; index86 < 5; ++index86)
        {
          int index87 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 2.5f);
          Main.dust[index87].noGravity = true;
          Main.dust[index87].velocity *= 5f;
          int index88 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 1.5f);
          Main.dust[index88].velocity *= 3f;
        }
        int index89 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index89].velocity *= 0.4f;
        ++Main.gore[index89].velocity.X;
        ++Main.gore[index89].velocity.Y;
        int index90 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index90].velocity *= 0.4f;
        --Main.gore[index90].velocity.X;
        ++Main.gore[index90].velocity.Y;
        int index91 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index91].velocity *= 0.4f;
        ++Main.gore[index91].velocity.X;
        --Main.gore[index91].velocity.Y;
        int index92 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index92].velocity *= 0.4f;
        --Main.gore[index92].velocity.X;
        --Main.gore[index92].velocity.Y;
      }
      else if (this.type == (int) sbyte.MaxValue)
      {
        if (this.life > 0)
          return;
        Gore.NewGore(this.position, this.velocity, 149);
        Gore.NewGore(this.position, this.velocity, 150);
        for (int index93 = 0; index93 < 10; ++index93)
        {
          int index94 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, Alpha: 100, Scale: 1.5f);
          Main.dust[index94].velocity *= 1.4f;
        }
        for (int index95 = 0; index95 < 5; ++index95)
        {
          int index96 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 2.5f);
          Main.dust[index96].noGravity = true;
          Main.dust[index96].velocity *= 5f;
          int index97 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 1.5f);
          Main.dust[index97].velocity *= 3f;
        }
        int index98 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index98].velocity *= 0.4f;
        ++Main.gore[index98].velocity.X;
        ++Main.gore[index98].velocity.Y;
        int index99 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index99].velocity *= 0.4f;
        --Main.gore[index99].velocity.X;
        ++Main.gore[index99].velocity.Y;
        int index100 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index100].velocity *= 0.4f;
        ++Main.gore[index100].velocity.X;
        --Main.gore[index100].velocity.Y;
        int index101 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index101].velocity *= 0.4f;
        --Main.gore[index101].velocity.X;
        --Main.gore[index101].velocity.Y;
      }
      else if (this.type >= 128 && this.type <= 131)
      {
        if (this.life > 0)
          return;
        Gore.NewGore(this.position, this.velocity, 147);
        Gore.NewGore(this.position, this.velocity, 148);
        for (int index102 = 0; index102 < 10; ++index102)
        {
          int index103 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, Alpha: 100, Scale: 1.5f);
          Main.dust[index103].velocity *= 1.4f;
        }
        for (int index104 = 0; index104 < 5; ++index104)
        {
          int index105 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 2.5f);
          Main.dust[index105].noGravity = true;
          Main.dust[index105].velocity *= 5f;
          int index106 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 1.5f);
          Main.dust[index106].velocity *= 3f;
        }
        int index107 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index107].velocity *= 0.4f;
        ++Main.gore[index107].velocity.X;
        ++Main.gore[index107].velocity.Y;
        int index108 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index108].velocity *= 0.4f;
        --Main.gore[index108].velocity.X;
        ++Main.gore[index108].velocity.Y;
        int index109 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index109].velocity *= 0.4f;
        ++Main.gore[index109].velocity.X;
        --Main.gore[index109].velocity.Y;
        int index110 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index110].velocity *= 0.4f;
        --Main.gore[index110].velocity.X;
        --Main.gore[index110].velocity.Y;
      }
      else if (this.type == 23)
      {
        if (this.life > 0)
        {
          for (int index111 = 0; (double) index111 < dmg / (double) this.lifeMax * 100.0; ++index111)
          {
            int Type = 25;
            if (Main.rand.Next(2) == 0)
              Type = 6;
            Dust.NewDust(this.position, this.width, this.height, Type, (float) hitDirection, -1f);
            int index112 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, Scale: 2f);
            Main.dust[index112].noGravity = true;
          }
        }
        else
        {
          for (int index = 0; index < 50; ++index)
          {
            int Type = 25;
            if (Main.rand.Next(2) == 0)
              Type = 6;
            Dust.NewDust(this.position, this.width, this.height, Type, (float) (2 * hitDirection), -2f);
          }
          for (int index113 = 0; index113 < 50; ++index113)
          {
            int index114 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, Scale: 2.5f);
            Main.dust[index114].velocity *= 6f;
            Main.dust[index114].noGravity = true;
          }
        }
      }
      else if (this.type == 24)
      {
        if (this.life > 0)
        {
          for (int index115 = 0; (double) index115 < dmg / (double) this.lifeMax * 100.0; ++index115)
          {
            int index116 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X, this.velocity.Y, 100, Scale: 2.5f);
            Main.dust[index116].noGravity = true;
          }
        }
        else
        {
          for (int index117 = 0; index117 < 50; ++index117)
          {
            int index118 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X, this.velocity.Y, 100, Scale: 2.5f);
            Main.dust[index118].noGravity = true;
            Main.dust[index118].velocity *= 2f;
          }
          Gore.NewGore(this.position, this.velocity, 45);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 46);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 46);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 47);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 47);
        }
      }
      else if (this.type == 25)
      {
        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
        for (int index119 = 0; index119 < 20; ++index119)
        {
          int index120 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, (float) (-(double) this.velocity.X * 0.200000002980232), (float) (-(double) this.velocity.Y * 0.200000002980232), 100, Scale: 2f);
          Main.dust[index120].noGravity = true;
          Main.dust[index120].velocity *= 2f;
          int index121 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, (float) (-(double) this.velocity.X * 0.200000002980232), (float) (-(double) this.velocity.Y * 0.200000002980232), 100);
          Main.dust[index121].velocity *= 2f;
        }
      }
      else if (this.type == 33)
      {
        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
        for (int index122 = 0; index122 < 20; ++index122)
        {
          int index123 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 29, (float) (-(double) this.velocity.X * 0.200000002980232), (float) (-(double) this.velocity.Y * 0.200000002980232), 100, Scale: 2f);
          Main.dust[index123].noGravity = true;
          Main.dust[index123].velocity *= 2f;
          int index124 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 29, (float) (-(double) this.velocity.X * 0.200000002980232), (float) (-(double) this.velocity.Y * 0.200000002980232), 100);
          Main.dust[index124].velocity *= 2f;
        }
      }
      else if (this.type == 26 || this.type == 27 || this.type == 28 || this.type == 29 || this.type == 73 || this.type == 111)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, 2.5f * (float) hitDirection, -2.5f);
          Gore.NewGore(this.position, this.velocity, 48, this.scale);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 49, this.scale);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 49, this.scale);
          if (this.type == 111)
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 131, this.scale);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 50, this.scale);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 50, this.scale);
        }
      }
      else if (this.type == 30)
      {
        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
        for (int index125 = 0; index125 < 20; ++index125)
        {
          int index126 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, (float) (-(double) this.velocity.X * 0.200000002980232), (float) (-(double) this.velocity.Y * 0.200000002980232), 100, Scale: 2f);
          Main.dust[index126].noGravity = true;
          Main.dust[index126].velocity *= 2f;
          int index127 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, (float) (-(double) this.velocity.X * 0.200000002980232), (float) (-(double) this.velocity.Y * 0.200000002980232), 100);
          Main.dust[index127].velocity *= 2f;
        }
      }
      else if (this.type == 42)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 18, (float) hitDirection, -1f, this.alpha, this.color, this.scale);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 18, (float) hitDirection, -2f, this.alpha, this.color, this.scale);
          Gore.NewGore(this.position, this.velocity, 70, this.scale);
          Gore.NewGore(this.position, this.velocity, 71, this.scale);
        }
      }
      else if (this.type == 43 || this.type == 56)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 40, (float) hitDirection, -1f, this.alpha, this.color, 1.2f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 40, (float) hitDirection, -2f, this.alpha, this.color, 1.2f);
          Gore.NewGore(this.position, this.velocity, 72);
          Gore.NewGore(this.position, this.velocity, 72);
        }
      }
      else if (this.type == 48)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) (2 * hitDirection), -2f);
          Gore.NewGore(this.position, this.velocity, 80);
          Gore.NewGore(this.position, this.velocity, 81);
        }
      }
      else
      {
        if (this.type != 62 && this.type != 66)
          return;
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 100.0; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) hitDirection, -1f);
        }
        else
        {
          for (int index = 0; index < 50; ++index)
            Dust.NewDust(this.position, this.width, this.height, 5, (float) (2 * hitDirection), -2f);
          Gore.NewGore(this.position, this.velocity, 93);
          Gore.NewGore(this.position, this.velocity, 94);
          Gore.NewGore(this.position, this.velocity, 94);
        }
      }
    }

    public static bool AnyNPCs(int Type)
    {
      for (int index = 0; index < 200; ++index)
      {
        if (Main.npc[index].active && Main.npc[index].type == Type)
          return true;
      }
      return false;
    }

    public static void SpawnSkeletron()
    {
      bool flag1 = true;
      bool flag2 = false;
      Vector2 vector2 = new Vector2();
      int num1 = 0;
      int num2 = 0;
      for (int index = 0; index < 200; ++index)
      {
        if (Main.npc[index].active && Main.npc[index].type == 35)
        {
          flag1 = false;
          break;
        }
      }
      for (int number = 0; number < 200; ++number)
      {
        if (Main.npc[number].active && Main.npc[number].type == 37)
        {
          flag2 = true;
          Main.npc[number].ai[3] = 1f;
          vector2 = Main.npc[number].position;
          num1 = Main.npc[number].width;
          num2 = Main.npc[number].height;
          if (Main.netMode == 2)
            NetMessage.SendData(23, number: number);
        }
      }
      if (!flag1 || !flag2)
        return;
      int index1 = NPC.NewNPC((int) vector2.X + num1 / 2, (int) vector2.Y + num2 / 2, 35);
      Main.npc[index1].netUpdate = true;
      string str = "Skeletron";
      if (Main.netMode == 0)
      {
        Main.NewText(str + " " + Lang.misc[16], (byte) 175, (byte) 75);
      }
      else
      {
        if (Main.netMode != 2)
          return;
        NetMessage.SendData(25, text: (str + " " + Lang.misc[16]), number: ((int) byte.MaxValue), number2: 175f, number3: 75f, number4: ((float) byte.MaxValue));
      }
    }

    public static bool NearSpikeBall(int x, int y)
    {
      Rectangle rectangle1 = new Rectangle(x * 16 - 300, y * 16 - 300, 600, 600);
      for (int index = 0; index < 200; ++index)
      {
        if (Main.npc[index].active && Main.npc[index].aiStyle == 20)
        {
          Rectangle rectangle2 = new Rectangle((int) Main.npc[index].ai[1], (int) Main.npc[index].ai[2], 20, 20);
          if (rectangle1.Intersects(rectangle2))
            return true;
        }
      }
      return false;
    }

    public void AddBuff(int type, int time, bool quiet = false)
    {
      if (this.buffImmune[type])
        return;
      if (!quiet)
      {
        switch (Main.netMode)
        {
          case 1:
            NetMessage.SendData(53, number: this.whoAmI, number2: ((float) type), number3: ((float) time));
            break;
          case 2:
            NetMessage.SendData(54, number: this.whoAmI);
            break;
        }
      }
      int index1 = -1;
      for (int index2 = 0; index2 < 5; ++index2)
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
        for (int index3 = 0; index3 < 5; ++index3)
        {
          if (!Main.debuff[this.buffType[index3]])
          {
            b = index3;
            break;
          }
        }
        if (b == -1)
          return;
        for (int index4 = b; index4 < 5; ++index4)
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
      for (int index1 = 0; index1 < 4; ++index1)
      {
        if (this.buffTime[index1] == 0 || this.buffType[index1] == 0)
        {
          for (int index2 = index1 + 1; index2 < 5; ++index2)
          {
            this.buffTime[index2 - 1] = this.buffTime[index2];
            this.buffType[index2 - 1] = this.buffType[index2];
            this.buffTime[index2] = 0;
            this.buffType[index2] = 0;
          }
        }
      }
      if (Main.netMode != 2)
        return;
      NetMessage.SendData(54, number: this.whoAmI);
    }

    public void UpdateNPC(int i)
    {
      this.whoAmI = i;
      if (!this.active)
        return;
      if (this.displayName == "")
        this.displayName = this.name;
      if (this.townNPC && Main.chrName[this.type] != "")
        this.displayName = Main.chrName[this.type];
      this.lifeRegen = 0;
      this.poisoned = false;
      this.onFire = false;
      this.onFire2 = false;
      this.confused = false;
      for (int index = 0; index < 5; ++index)
      {
        if (this.buffType[index] > 0 && this.buffTime[index] > 0)
        {
          --this.buffTime[index];
          if (this.buffType[index] == 20)
            this.poisoned = true;
          else if (this.buffType[index] == 24)
            this.onFire = true;
          else if (this.buffType[index] == 31)
            this.confused = true;
          else if (this.buffType[index] == 39)
            this.onFire2 = true;
        }
      }
      if (Main.netMode != 1)
      {
        for (int b = 0; b < 5; ++b)
        {
          if (this.buffType[b] > 0 && this.buffTime[b] <= 0)
          {
            this.DelBuff(b);
            if (Main.netMode == 2)
              NetMessage.SendData(54, number: this.whoAmI);
          }
        }
      }
      if (!this.dontTakeDamage)
      {
        if (this.poisoned)
          this.lifeRegen = -4;
        if (this.onFire)
          this.lifeRegen = -8;
        if (this.onFire2)
          this.lifeRegen = -12;
        this.lifeRegenCount += this.lifeRegen;
        while (this.lifeRegenCount >= 120)
        {
          this.lifeRegenCount -= 120;
          if (this.life < this.lifeMax)
            ++this.life;
          if (this.life > this.lifeMax)
            this.life = this.lifeMax;
        }
        while (this.lifeRegenCount <= -120)
        {
          this.lifeRegenCount += 120;
          int number = this.whoAmI;
          if (this.realLife >= 0)
            number = this.realLife;
          --Main.npc[number].life;
          if (Main.npc[number].life <= 0)
          {
            Main.npc[number].life = 1;
            if (Main.netMode != 1)
            {
              Main.npc[number].StrikeNPC(9999, 0.0f, 0);
              if (Main.netMode == 2)
                NetMessage.SendData(28, number: number, number2: 9999f);
            }
          }
        }
      }
      if (Main.netMode != 1 && Main.bloodMoon)
      {
        if (this.type == 46)
          this.Transform(47);
        else if (this.type == 55)
          this.Transform(57);
      }
      float num1 = 10f;
      float num2 = 0.3f;
      float num3 = (float) (Main.maxTilesX / 4200);
      float num4 = (float) (((double) this.position.Y / 16.0 - (60.0 + 10.0 * (double) (num3 * num3))) / (Main.worldSurface / 6.0));
      if ((double) num4 < 0.25)
        num4 = 0.25f;
      if ((double) num4 > 1.0)
        num4 = 1f;
      float num5 = num2 * num4;
      if (this.wet)
      {
        num5 = 0.2f;
        num1 = 7f;
      }
      if (this.soundDelay > 0)
        --this.soundDelay;
      if (this.life <= 0)
        this.active = false;
      this.oldTarget = this.target;
      this.oldDirection = this.direction;
      this.oldDirectionY = this.directionY;
      this.AI();
      if (this.type == 44)
        Lighting.addLight((int) ((double) this.position.X + (double) (this.width / 2)) / 16, (int) ((double) this.position.Y + 4.0) / 16, 0.9f, 0.75f, 0.5f);
      for (int index = 0; index < 256; ++index)
      {
        if (this.immune[index] > 0)
          --this.immune[index];
      }
      if (!this.noGravity && !this.noTileCollide)
      {
        int index1 = (int) ((double) this.position.X + (double) (this.width / 2)) / 16;
        int index2 = (int) ((double) this.position.Y + (double) (this.height / 2)) / 16;
        if (Main.tile[index1, index2] == null)
        {
          num5 = 0.0f;
          this.velocity.X = 0.0f;
          this.velocity.Y = 0.0f;
        }
      }
      if (!this.noGravity)
      {
        this.velocity.Y += num5;
        if ((double) this.velocity.Y > (double) num1)
          this.velocity.Y = num1;
      }
      if ((double) this.velocity.X < 0.005 && (double) this.velocity.X > -0.005)
        this.velocity.X = 0.0f;
      if (Main.netMode != 1 && this.type != 37 && (this.friendly || this.type == 46 || this.type == 55 || this.type == 74))
      {
        if (this.life < this.lifeMax)
        {
          ++this.friendlyRegen;
          if (this.friendlyRegen > 300)
          {
            this.friendlyRegen = 0;
            ++this.life;
            this.netUpdate = true;
          }
        }
        if (this.immune[(int) byte.MaxValue] == 0)
        {
          Rectangle rectangle1 = new Rectangle((int) this.position.X, (int) this.position.Y, this.width, this.height);
          for (int index = 0; index < 200; ++index)
          {
            if (Main.npc[index].active && !Main.npc[index].friendly && Main.npc[index].damage > 0)
            {
              Rectangle rectangle2 = new Rectangle((int) Main.npc[index].position.X, (int) Main.npc[index].position.Y, Main.npc[index].width, Main.npc[index].height);
              if (rectangle1.Intersects(rectangle2))
              {
                int damage = Main.npc[index].damage;
                int num6 = 6;
                int hitDirection = 1;
                if ((double) Main.npc[index].position.X + (double) (Main.npc[index].width / 2) > (double) this.position.X + (double) (this.width / 2))
                  hitDirection = -1;
                Main.npc[i].StrikeNPC(damage, (float) num6, hitDirection);
                if (Main.netMode != 0)
                  NetMessage.SendData(28, number: i, number2: ((float) damage), number3: ((float) num6), number4: ((float) hitDirection));
                this.netUpdate = true;
                this.immune[(int) byte.MaxValue] = 30;
              }
            }
          }
        }
      }
      if (!this.noTileCollide)
      {
        bool flag1 = Collision.LavaCollision(this.position, this.width, this.height);
        if (flag1)
        {
          this.lavaWet = true;
          if (!this.lavaImmune && !this.dontTakeDamage && Main.netMode != 1 && this.immune[(int) byte.MaxValue] == 0)
          {
            this.AddBuff(24, 420);
            this.immune[(int) byte.MaxValue] = 30;
            this.StrikeNPC(50, 0.0f, 0);
            if (Main.netMode == 2 && Main.netMode != 0)
              NetMessage.SendData(28, number: this.whoAmI, number2: 50f);
          }
        }
        bool flag2;
        if (this.type == 72)
        {
          flag2 = false;
          this.wetCount = (byte) 0;
          flag1 = false;
        }
        else
          flag2 = Collision.WetCollision(this.position, this.width, this.height);
        if (flag2)
        {
          if (this.onFire && !this.lavaWet && Main.netMode != 1)
          {
            for (int b = 0; b < 5; ++b)
            {
              if (this.buffType[b] == 24)
                this.DelBuff(b);
            }
          }
          if (!this.wet && this.wetCount == (byte) 0)
          {
            this.wetCount = (byte) 10;
            if (!flag1)
            {
              for (int index3 = 0; index3 < 30; ++index3)
              {
                int index4 = Dust.NewDust(new Vector2(this.position.X - 6f, (float) ((double) this.position.Y + (double) (this.height / 2) - 8.0)), this.width + 12, 24, 33);
                Main.dust[index4].velocity.Y -= 4f;
                Main.dust[index4].velocity.X *= 2.5f;
                Main.dust[index4].scale = 1.3f;
                Main.dust[index4].alpha = 100;
                Main.dust[index4].noGravity = true;
              }
              if (this.type != 1 && this.type != 59 && !this.noGravity)
                Main.PlaySound(19, (int) this.position.X, (int) this.position.Y, 0);
            }
            else
            {
              for (int index5 = 0; index5 < 10; ++index5)
              {
                int index6 = Dust.NewDust(new Vector2(this.position.X - 6f, (float) ((double) this.position.Y + (double) (this.height / 2) - 8.0)), this.width + 12, 24, 35);
                Main.dust[index6].velocity.Y -= 1.5f;
                Main.dust[index6].velocity.X *= 2.5f;
                Main.dust[index6].scale = 1.3f;
                Main.dust[index6].alpha = 100;
                Main.dust[index6].noGravity = true;
              }
              if (this.type != 1 && this.type != 59 && !this.noGravity)
                Main.PlaySound(19, (int) this.position.X, (int) this.position.Y);
            }
          }
          this.wet = true;
        }
        else if (this.wet)
        {
          this.velocity.X *= 0.5f;
          this.wet = false;
          if (this.wetCount == (byte) 0)
          {
            this.wetCount = (byte) 10;
            if (!this.lavaWet)
            {
              for (int index7 = 0; index7 < 30; ++index7)
              {
                int index8 = Dust.NewDust(new Vector2(this.position.X - 6f, (float) ((double) this.position.Y + (double) (this.height / 2) - 8.0)), this.width + 12, 24, 33);
                Main.dust[index8].velocity.Y -= 4f;
                Main.dust[index8].velocity.X *= 2.5f;
                Main.dust[index8].scale = 1.3f;
                Main.dust[index8].alpha = 100;
                Main.dust[index8].noGravity = true;
              }
              if (this.type != 1 && this.type != 59 && !this.noGravity)
                Main.PlaySound(19, (int) this.position.X, (int) this.position.Y, 0);
            }
            else
            {
              for (int index9 = 0; index9 < 10; ++index9)
              {
                int index10 = Dust.NewDust(new Vector2(this.position.X - 6f, (float) ((double) this.position.Y + (double) (this.height / 2) - 8.0)), this.width + 12, 24, 35);
                Main.dust[index10].velocity.Y -= 1.5f;
                Main.dust[index10].velocity.X *= 2.5f;
                Main.dust[index10].scale = 1.3f;
                Main.dust[index10].alpha = 100;
                Main.dust[index10].noGravity = true;
              }
              if (this.type != 1 && this.type != 59 && !this.noGravity)
                Main.PlaySound(19, (int) this.position.X, (int) this.position.Y);
            }
          }
        }
        if (!this.wet)
          this.lavaWet = false;
        if (this.wetCount > (byte) 0)
          --this.wetCount;
        bool flag3 = false;
        if (this.aiStyle == 10)
          flag3 = true;
        if (this.aiStyle == 14)
          flag3 = true;
        if (this.aiStyle == 3 && this.directionY == 1)
          flag3 = true;
        this.oldVelocity = this.velocity;
        this.collideX = false;
        this.collideY = false;
        if (this.wet)
        {
          Vector2 velocity = this.velocity;
          this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag3, flag3);
          if (Collision.up)
            this.velocity.Y = 0.01f;
          Vector2 vector2 = this.velocity * 0.5f;
          if ((double) this.velocity.X != (double) velocity.X)
          {
            vector2.X = this.velocity.X;
            this.collideX = true;
          }
          if ((double) this.velocity.Y != (double) velocity.Y)
          {
            vector2.Y = this.velocity.Y;
            this.collideY = true;
          }
          this.oldPosition = this.position;
          this.position += vector2;
        }
        else
        {
          if (this.type == 72)
          {
            Vector2 Position = new Vector2(this.position.X + (float) (this.width / 2), this.position.Y + (float) (this.height / 2));
            int Width = 12;
            int Height = 12;
            Position.X -= (float) (Width / 2);
            Position.Y -= (float) (Height / 2);
            this.velocity = Collision.TileCollision(Position, this.velocity, Width, Height, true, true);
          }
          else
            this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag3, flag3);
          if (Collision.up)
            this.velocity.Y = 0.01f;
          if ((double) this.oldVelocity.X != (double) this.velocity.X)
            this.collideX = true;
          if ((double) this.oldVelocity.Y != (double) this.velocity.Y)
            this.collideY = true;
          this.oldPosition = this.position;
          this.position += this.velocity;
        }
      }
      else
      {
        this.oldPosition = this.position;
        this.position += this.velocity;
      }
      if (Main.netMode != 1 && !this.noTileCollide && this.lifeMax > 1 && Collision.SwitchTiles(this.position, this.width, this.height, this.oldPosition) && this.type == 46)
      {
        this.ai[0] = 1f;
        this.ai[1] = 400f;
        this.ai[2] = 0.0f;
      }
      if (!this.active)
        this.netUpdate = true;
      if (Main.netMode == 2)
      {
        if (this.townNPC)
          this.netSpam = 0;
        if (this.netUpdate2)
          this.netUpdate = true;
        if (!this.active)
          this.netSpam = 0;
        if (this.netUpdate)
        {
          if (this.netSpam <= 180)
          {
            this.netSpam += 60;
            NetMessage.SendData(23, number: i);
            this.netUpdate2 = false;
          }
          else
            this.netUpdate2 = true;
        }
        if (this.netSpam > 0)
          --this.netSpam;
        if (this.active && this.townNPC && NPC.TypeToNum(this.type) != -1)
        {
          if (this.homeless != this.oldHomeless || this.homeTileX != this.oldHomeTileX || this.homeTileY != this.oldHomeTileY)
          {
            int num7 = 0;
            if (this.homeless)
              num7 = 1;
            NetMessage.SendData(60, number: i, number2: ((float) Main.npc[i].homeTileX), number3: ((float) Main.npc[i].homeTileY), number4: ((float) num7));
          }
          this.oldHomeless = this.homeless;
          this.oldHomeTileX = this.homeTileX;
          this.oldHomeTileY = this.homeTileY;
        }
      }
      this.FindFrame();
      this.CheckActive();
      this.netUpdate = false;
      this.justHit = false;
      if (this.type == 120 || this.type == 137 || this.type == 138)
      {
        for (int index = this.oldPos.Length - 1; index > 0; --index)
        {
          this.oldPos[index] = this.oldPos[index - 1];
          Lighting.addLight((int) this.position.X / 16, (int) this.position.Y / 16, 0.3f, 0.0f, 0.2f);
        }
        this.oldPos[0] = this.position;
      }
      else if (this.type == 94)
      {
        for (int index = this.oldPos.Length - 1; index > 0; --index)
          this.oldPos[index] = this.oldPos[index - 1];
        this.oldPos[0] = this.position;
      }
      else
      {
        if (this.type != 125 && this.type != 126 && this.type != (int) sbyte.MaxValue && this.type != 128 && this.type != 129 && this.type != 130 && this.type != 131 && this.type != 139 && this.type != 140)
          return;
        for (int index = this.oldPos.Length - 1; index > 0; --index)
          this.oldPos[index] = this.oldPos[index - 1];
        this.oldPos[0] = this.position;
      }
    }

    public Color GetAlpha(Color newColor)
    {
      float num = (float) ((int) byte.MaxValue - this.alpha) / (float) byte.MaxValue;
      int r = (int) ((double) newColor.R * (double) num);
      int g = (int) ((double) newColor.G * (double) num);
      int b = (int) ((double) newColor.B * (double) num);
      int a = (int) newColor.A - this.alpha;
      if (this.type == 25 || this.type == 30 || this.type == 33 || this.type == 59 || this.type == 60)
        return new Color(200, 200, 200, 0);
      if (this.type == 72)
      {
        r = (int) newColor.R;
        g = (int) newColor.G;
        b = (int) newColor.B;
      }
      else if (this.type == 64 || this.type == 63 || this.type == 75 || this.type == 103)
      {
        r = (int) ((double) newColor.R * 1.5);
        g = (int) ((double) newColor.G * 1.5);
        b = (int) ((double) newColor.B * 1.5);
        if (r > (int) byte.MaxValue)
          r = (int) byte.MaxValue;
        if (g > (int) byte.MaxValue)
          g = (int) byte.MaxValue;
        if (b > (int) byte.MaxValue)
          b = (int) byte.MaxValue;
      }
      if (a < 0)
        a = 0;
      if (a > (int) byte.MaxValue)
        a = (int) byte.MaxValue;
      return new Color(r, g, b, a);
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

    public string GetChat()
    {
      Recipe.FindRecipes();
      string str1 = Main.chrName[18];
      string str2 = Main.chrName[17];
      string str3 = Main.chrName[19];
      string str4 = Main.chrName[20];
      string str5 = Main.chrName[38];
      string str6 = Main.chrName[54];
      string str7 = Main.chrName[22];
      string str8 = Main.chrName[108];
      string str9 = Main.chrName[107];
      string str10 = Main.chrName[124];
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      bool flag4 = false;
      bool flag5 = false;
      bool flag6 = false;
      bool flag7 = false;
      bool flag8 = false;
      bool flag9 = false;
      for (int index = 0; index < 200; ++index)
      {
        if (Main.npc[index].active)
        {
          if (Main.npc[index].type == 17)
            flag1 = true;
          else if (Main.npc[index].type == 18)
            flag2 = true;
          else if (Main.npc[index].type == 19)
            flag3 = true;
          else if (Main.npc[index].type == 20)
            flag4 = true;
          else if (Main.npc[index].type == 37)
            flag5 = true;
          else if (Main.npc[index].type == 38)
            flag6 = true;
          else if (Main.npc[index].type == 124)
            flag7 = true;
          else if (Main.npc[index].type == 107)
            flag8 = true;
          else if (Main.npc[index].type == 2)
            flag9 = true;
        }
      }
      string str11 = "";
      if (this.type == 17)
      {
        if (!NPC.downedBoss1 && Main.rand.Next(3) == 0)
          str11 = Main.player[Main.myPlayer].statLifeMax >= 200 ? (Main.player[Main.myPlayer].statDefense > 10 ? Lang.dialog(3) : Lang.dialog(2)) : Lang.dialog(1);
        else if (Main.dayTime)
        {
          if (Main.time < 16200.0)
          {
            switch (Main.rand.Next(3))
            {
              case 0:
                str11 = Lang.dialog(4);
                break;
              case 1:
                str11 = Lang.dialog(5);
                break;
              default:
                str11 = Lang.dialog(6);
                break;
            }
          }
          else if (Main.time > 37800.0)
          {
            switch (Main.rand.Next(3))
            {
              case 0:
                str11 = Lang.dialog(7);
                break;
              case 1:
                str11 = Lang.dialog(8);
                break;
              default:
                str11 = Lang.dialog(9);
                break;
            }
          }
          else
          {
            switch (Main.rand.Next(3))
            {
              case 0:
                str11 = Lang.dialog(10);
                break;
              case 1:
                str11 = Lang.dialog(11);
                break;
              default:
                str11 = Lang.dialog(12);
                break;
            }
          }
        }
        else if (Main.bloodMoon)
        {
          if (flag2 && flag7 && Main.rand.Next(3) == 0)
          {
            str11 = Lang.dialog(13);
          }
          else
          {
            switch (Main.rand.Next(4))
            {
              case 0:
                str11 = Lang.dialog(14);
                break;
              case 1:
                str11 = Lang.dialog(15);
                break;
              case 2:
                str11 = Lang.dialog(16);
                break;
              default:
                str11 = Lang.dialog(17);
                break;
            }
          }
        }
        else if (Main.time < 9720.0)
          str11 = Main.rand.Next(2) != 0 ? Lang.dialog(19) : Lang.dialog(18);
        else if (Main.time > 22680.0)
        {
          str11 = Main.rand.Next(2) != 0 ? Lang.dialog(21) : Lang.dialog(20);
        }
        else
        {
          switch (Main.rand.Next(3))
          {
            case 0:
              str11 = Lang.dialog(22);
              break;
            case 1:
              str11 = Lang.dialog(23);
              break;
            default:
              str11 = Lang.dialog(24);
              break;
          }
        }
      }
      else if (this.type == 18)
      {
        if (Main.bloodMoon)
        {
          if ((double) Main.player[Main.myPlayer].statLife < (double) Main.player[Main.myPlayer].statLifeMax * 0.66)
          {
            switch (Main.rand.Next(3))
            {
              case 0:
                str11 = Lang.dialog(25);
                break;
              case 1:
                str11 = Lang.dialog(26);
                break;
              default:
                str11 = Lang.dialog(27);
                break;
            }
          }
          else
          {
            switch (Main.rand.Next(4))
            {
              case 0:
                str11 = Lang.dialog(28);
                break;
              case 1:
                str11 = Lang.dialog(29);
                break;
              case 2:
                str11 = Lang.dialog(30);
                break;
              default:
                str11 = Lang.dialog(31);
                break;
            }
          }
        }
        else if (Main.rand.Next(3) == 0 && !NPC.downedBoss3)
          str11 = Lang.dialog(32);
        else if (flag6 && Main.rand.Next(4) == 0)
          str11 = Lang.dialog(33);
        else if (flag3 && Main.rand.Next(4) == 0)
          str11 = Lang.dialog(34);
        else if (flag9 && Main.rand.Next(4) == 0)
          str11 = Lang.dialog(35);
        else if ((double) Main.player[Main.myPlayer].statLife < (double) Main.player[Main.myPlayer].statLifeMax * 0.33)
        {
          switch (Main.rand.Next(5))
          {
            case 0:
              str11 = Lang.dialog(36);
              break;
            case 1:
              str11 = Lang.dialog(37);
              break;
            case 2:
              str11 = Lang.dialog(38);
              break;
            case 3:
              str11 = Lang.dialog(39);
              break;
            default:
              str11 = Lang.dialog(40);
              break;
          }
        }
        else if ((double) Main.player[Main.myPlayer].statLife < (double) Main.player[Main.myPlayer].statLifeMax * 0.66)
        {
          switch (Main.rand.Next(7))
          {
            case 0:
              str11 = Lang.dialog(41);
              break;
            case 1:
              str11 = Lang.dialog(42);
              break;
            case 2:
              str11 = Lang.dialog(43);
              break;
            case 3:
              str11 = Lang.dialog(44);
              break;
            case 4:
              str11 = Lang.dialog(45);
              break;
            case 5:
              str11 = Lang.dialog(46);
              break;
            default:
              str11 = Lang.dialog(47);
              break;
          }
        }
        else
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str11 = Lang.dialog(48);
              break;
            case 1:
              str11 = Lang.dialog(49);
              break;
            case 2:
              str11 = Lang.dialog(50);
              break;
            default:
              str11 = Lang.dialog(51);
              break;
          }
        }
      }
      else if (this.type == 19)
      {
        if (NPC.downedBoss3 && !Main.hardMode)
          str11 = Lang.dialog(58);
        else if (flag2 && Main.rand.Next(5) == 0)
          str11 = Lang.dialog(59);
        else if (flag2 && Main.rand.Next(5) == 0)
          str11 = Lang.dialog(60);
        else if (flag4 && Main.rand.Next(5) == 0)
          str11 = Lang.dialog(61);
        else if (flag6 && Main.rand.Next(5) == 0)
          str11 = Lang.dialog(62);
        else if (flag6 && Main.rand.Next(5) == 0)
          str11 = Lang.dialog(63);
        else if (Main.bloodMoon)
        {
          str11 = Main.rand.Next(2) != 0 ? Lang.dialog(65) : Lang.dialog(64);
        }
        else
        {
          switch (Main.rand.Next(3))
          {
            case 0:
              str11 = Lang.dialog(66);
              break;
            case 1:
              str11 = Lang.dialog(67);
              break;
            default:
              str11 = Lang.dialog(68);
              break;
          }
        }
      }
      else if (this.type == 20)
      {
        if (!NPC.downedBoss2 && Main.rand.Next(3) == 0)
          str11 = Lang.dialog(69);
        else if (flag3 && Main.rand.Next(4) == 0)
          str11 = Lang.dialog(70);
        else if (flag1 && Main.rand.Next(4) == 0)
          str11 = Lang.dialog(71);
        else if (flag5 && Main.rand.Next(4) == 0)
          str11 = Lang.dialog(72);
        else if (Main.bloodMoon)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str11 = Lang.dialog(73);
              break;
            case 1:
              str11 = Lang.dialog(74);
              break;
            case 2:
              str11 = Lang.dialog(75);
              break;
            default:
              str11 = Lang.dialog(76);
              break;
          }
        }
        else
        {
          switch (Main.rand.Next(5))
          {
            case 0:
              str11 = Lang.dialog(77);
              break;
            case 1:
              str11 = Lang.dialog(78);
              break;
            case 2:
              str11 = Lang.dialog(79);
              break;
            case 3:
              str11 = Lang.dialog(80);
              break;
            default:
              str11 = Lang.dialog(81);
              break;
          }
        }
      }
      else if (this.type == 37)
      {
        if (Main.dayTime)
        {
          switch (Main.rand.Next(3))
          {
            case 0:
              str11 = Lang.dialog(82);
              break;
            case 1:
              str11 = Lang.dialog(83);
              break;
            default:
              str11 = Lang.dialog(84);
              break;
          }
        }
        else if (Main.player[Main.myPlayer].statLifeMax < 300 || Main.player[Main.myPlayer].statDefense < 10)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str11 = Lang.dialog(85);
              break;
            case 1:
              str11 = Lang.dialog(86);
              break;
            case 2:
              str11 = Lang.dialog(87);
              break;
            default:
              str11 = Lang.dialog(88);
              break;
          }
        }
        else
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str11 = Lang.dialog(89);
              break;
            case 1:
              str11 = Lang.dialog(90);
              break;
            case 2:
              str11 = Lang.dialog(91);
              break;
            default:
              str11 = Lang.dialog(92);
              break;
          }
        }
      }
      else if (this.type == 38)
      {
        if (!NPC.downedBoss2 && Main.rand.Next(3) == 0)
          Lang.dialog(93);
        if (Main.bloodMoon)
        {
          switch (Main.rand.Next(3))
          {
            case 0:
              str11 = Lang.dialog(94);
              break;
            case 1:
              str11 = Lang.dialog(95);
              break;
            default:
              str11 = Lang.dialog(96);
              break;
          }
        }
        else if (flag3 && Main.rand.Next(5) == 0)
          str11 = Lang.dialog(97);
        else if (flag3 && Main.rand.Next(5) == 0)
          str11 = Lang.dialog(98);
        else if (flag2 && Main.rand.Next(4) == 0)
          str11 = Lang.dialog(99);
        else if (flag4 && Main.rand.Next(4) == 0)
          str11 = Lang.dialog(100);
        else if (!Main.dayTime)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str11 = Lang.dialog(101);
              break;
            case 1:
              str11 = Lang.dialog(102);
              break;
            case 2:
              str11 = Lang.dialog(103);
              break;
            default:
              str11 = Lang.dialog(104);
              break;
          }
        }
        else
        {
          switch (Main.rand.Next(5))
          {
            case 0:
              str11 = Lang.dialog(105);
              break;
            case 1:
              str11 = Lang.dialog(106);
              break;
            case 2:
              str11 = Lang.dialog(107);
              break;
            case 3:
              str11 = Lang.dialog(108);
              break;
            default:
              str11 = Lang.dialog(109);
              break;
          }
        }
      }
      else if (this.type == 54)
      {
        if (!flag7 && Main.rand.Next(2) == 0)
          str11 = Lang.dialog(110);
        else if (Main.bloodMoon)
          str11 = Lang.dialog(111);
        else if (flag2 && Main.rand.Next(4) == 0)
          str11 = Lang.dialog(112);
        else if (Main.player[Main.myPlayer].head == 24)
        {
          str11 = Lang.dialog(113);
        }
        else
        {
          switch (Main.rand.Next(6))
          {
            case 0:
              str11 = Lang.dialog(114);
              break;
            case 1:
              str11 = Lang.dialog(115);
              break;
            case 2:
              str11 = Lang.dialog(116);
              break;
            case 3:
              str11 = Lang.dialog(117);
              break;
            case 4:
              str11 = Lang.dialog(118);
              break;
            default:
              str11 = Lang.dialog(119);
              break;
          }
        }
      }
      else if (this.type == 105)
        str11 = Lang.dialog(120);
      else if (this.type == 107)
      {
        if (this.homeless)
        {
          switch (Main.rand.Next(5))
          {
            case 0:
              str11 = Lang.dialog(121);
              break;
            case 1:
              str11 = Lang.dialog(122);
              break;
            case 2:
              str11 = Lang.dialog(123);
              break;
            case 3:
              str11 = Lang.dialog(124);
              break;
            default:
              str11 = Lang.dialog(125);
              break;
          }
        }
        else if (flag7 && Main.rand.Next(4) == 0)
          str11 = Lang.dialog(126);
        else if (!Main.dayTime)
        {
          switch (Main.rand.Next(5))
          {
            case 0:
              str11 = Lang.dialog((int) sbyte.MaxValue);
              break;
            case 1:
              str11 = Lang.dialog(128);
              break;
            case 2:
              str11 = Lang.dialog(129);
              break;
            case 3:
              str11 = Lang.dialog(130);
              break;
            default:
              str11 = Lang.dialog(131);
              break;
          }
        }
        else
        {
          switch (Main.rand.Next(5))
          {
            case 0:
              str11 = Lang.dialog(132);
              break;
            case 1:
              str11 = Lang.dialog(133);
              break;
            case 2:
              str11 = Lang.dialog(134);
              break;
            case 3:
              str11 = Lang.dialog(135);
              break;
            default:
              str11 = Lang.dialog(136);
              break;
          }
        }
      }
      else if (this.type == 106)
        str11 = Lang.dialog(137);
      else if (this.type == 108)
      {
        if (this.homeless)
        {
          int num = Main.rand.Next(3);
          if (num == 0)
            str11 = Lang.dialog(138);
          else if (num == 1 && !Main.player[Main.myPlayer].male)
          {
            str11 = Lang.dialog(139);
          }
          else
          {
            switch (num)
            {
              case 1:
                str11 = Lang.dialog(140);
                break;
              case 2:
                str11 = Lang.dialog(141);
                break;
            }
          }
        }
        else if (Main.player[Main.myPlayer].male && flag9 && Main.rand.Next(6) == 0)
          str11 = Lang.dialog(142);
        else if (Main.player[Main.myPlayer].male && flag6 && Main.rand.Next(6) == 0)
          str11 = Lang.dialog(143);
        else if (Main.player[Main.myPlayer].male && flag8 && Main.rand.Next(6) == 0)
          str11 = Lang.dialog(144);
        else if (!Main.player[Main.myPlayer].male && flag2 && Main.rand.Next(6) == 0)
          str11 = Lang.dialog(145);
        else if (!Main.player[Main.myPlayer].male && flag7 && Main.rand.Next(6) == 0)
          str11 = Lang.dialog(146);
        else if (!Main.player[Main.myPlayer].male && flag4 && Main.rand.Next(6) == 0)
          str11 = Lang.dialog(147);
        else if (!Main.dayTime)
        {
          switch (Main.rand.Next(3))
          {
            case 0:
              str11 = Lang.dialog(148);
              break;
            case 1:
              str11 = Lang.dialog(149);
              break;
            case 2:
              str11 = Lang.dialog(150);
              break;
          }
        }
        else
        {
          switch (Main.rand.Next(5))
          {
            case 0:
              str11 = Lang.dialog(151);
              break;
            case 1:
              str11 = Lang.dialog(152);
              break;
            case 2:
              str11 = Lang.dialog(153);
              break;
            case 3:
              str11 = Lang.dialog(154);
              break;
            default:
              str11 = Lang.dialog(155);
              break;
          }
        }
      }
      else if (this.type == 123)
        str11 = Lang.dialog(156);
      else if (this.type == 124)
      {
        if (this.homeless)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str11 = Lang.dialog(157);
              break;
            case 1:
              str11 = Lang.dialog(158);
              break;
            case 2:
              str11 = Lang.dialog(159);
              break;
            default:
              str11 = Lang.dialog(160);
              break;
          }
        }
        else if (Main.bloodMoon)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str11 = Lang.dialog(161);
              break;
            case 1:
              str11 = Lang.dialog(162);
              break;
            case 2:
              str11 = Lang.dialog(163);
              break;
            default:
              str11 = Lang.dialog(164);
              break;
          }
        }
        else if (flag8 && Main.rand.Next(6) == 0)
          str11 = Lang.dialog(165);
        else if (flag3 && Main.rand.Next(6) == 0)
        {
          str11 = Lang.dialog(166);
        }
        else
        {
          switch (Main.rand.Next(3))
          {
            case 0:
              str11 = Lang.dialog(167);
              break;
            case 1:
              str11 = Lang.dialog(168);
              break;
            default:
              str11 = Lang.dialog(169);
              break;
          }
        }
      }
      else if (this.type == 22)
      {
        if (Main.bloodMoon)
        {
          switch (Main.rand.Next(3))
          {
            case 0:
              str11 = Lang.dialog(170);
              break;
            case 1:
              str11 = Lang.dialog(171);
              break;
            default:
              str11 = Lang.dialog(172);
              break;
          }
        }
        else if (!Main.dayTime)
        {
          str11 = Lang.dialog(173);
        }
        else
        {
          switch (Main.rand.Next(3))
          {
            case 0:
              str11 = Lang.dialog(174);
              break;
            case 1:
              str11 = Lang.dialog(175);
              break;
            default:
              str11 = Lang.dialog(176);
              break;
          }
        }
      }
      else if (this.type == 142)
      {
        switch (Main.rand.Next(3))
        {
          case 0:
            str11 = Lang.dialog(224);
            break;
          case 1:
            str11 = Lang.dialog(225);
            break;
          case 2:
            str11 = Lang.dialog(226);
            break;
        }
      }
      return str11;
    }

    public object Clone() => this.MemberwiseClone();
  }
}
