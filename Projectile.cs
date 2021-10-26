// Decompiled with JetBrains decompiler
// Type: Terraria.Projectile
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
  public class Projectile
  {
    public bool wet;
    public byte wetCount;
    public bool lavaWet;
    public int whoAmI;
    public static int maxAI = 2;
    public Vector2 position;
    public Vector2 lastPosition;
    public Vector2 velocity;
    public int width;
    public int height;
    public float scale = 1f;
    public float rotation;
    public int type;
    public int alpha;
    public int owner = (int) byte.MaxValue;
    public bool active;
    public string name = "";
    public float[] ai = new float[Projectile.maxAI];
    public float[] localAI = new float[Projectile.maxAI];
    public int aiStyle;
    public int timeLeft;
    public int soundDelay;
    public int damage;
    public int direction;
    public int spriteDirection = 1;
    public bool hostile;
    public float knockBack;
    public bool friendly;
    public int penetrate = 1;
    public int identity;
    public float light;
    public bool netUpdate;
    public bool netUpdate2;
    public int netSpam;
    public Vector2[] oldPos = new Vector2[10];
    public int restrikeDelay;
    public bool tileCollide;
    public int maxUpdates;
    public int numUpdates;
    public bool ignoreWater;
    public bool hide;
    public bool ownerHitCheck;
    public int[] playerImmune = new int[(int) byte.MaxValue];
    public string miscText = "";
    public bool melee;
    public bool ranged;
    public bool magic;
    public int frameCounter;
    public int frame;

    public void SetDefaults(int Type)
    {
      for (int index = 0; index < this.oldPos.Length; ++index)
      {
        this.oldPos[index].X = 0.0f;
        this.oldPos[index].Y = 0.0f;
      }
      for (int index = 0; index < Projectile.maxAI; ++index)
      {
        this.ai[index] = 0.0f;
        this.localAI[index] = 0.0f;
      }
      for (int index = 0; index < (int) byte.MaxValue; ++index)
        this.playerImmune[index] = 0;
      this.soundDelay = 0;
      this.spriteDirection = 1;
      this.melee = false;
      this.ranged = false;
      this.magic = false;
      this.ownerHitCheck = false;
      this.hide = false;
      this.lavaWet = false;
      this.wetCount = (byte) 0;
      this.wet = false;
      this.ignoreWater = false;
      this.hostile = false;
      this.netUpdate = false;
      this.netUpdate2 = false;
      this.netSpam = 0;
      this.numUpdates = 0;
      this.maxUpdates = 0;
      this.identity = 0;
      this.restrikeDelay = 0;
      this.light = 0.0f;
      this.penetrate = 1;
      this.tileCollide = true;
      this.position = new Vector2();
      this.velocity = new Vector2();
      this.aiStyle = 0;
      this.alpha = 0;
      this.type = Type;
      this.active = true;
      this.rotation = 0.0f;
      this.scale = 1f;
      this.owner = (int) byte.MaxValue;
      this.timeLeft = 3600;
      this.name = "";
      this.friendly = false;
      this.damage = 0;
      this.knockBack = 0.0f;
      this.miscText = "";
      if (this.type == 1)
      {
        this.name = "Wooden Arrow";
        this.width = 10;
        this.height = 10;
        this.aiStyle = 1;
        this.friendly = true;
        this.ranged = true;
      }
      else if (this.type == 2)
      {
        this.name = "Fire Arrow";
        this.width = 10;
        this.height = 10;
        this.aiStyle = 1;
        this.friendly = true;
        this.light = 1f;
        this.ranged = true;
      }
      else if (this.type == 3)
      {
        this.name = "Shuriken";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 2;
        this.friendly = true;
        this.penetrate = 4;
        this.ranged = true;
      }
      else if (this.type == 4)
      {
        this.name = "Unholy Arrow";
        this.width = 10;
        this.height = 10;
        this.aiStyle = 1;
        this.friendly = true;
        this.light = 0.35f;
        this.penetrate = 5;
        this.ranged = true;
      }
      else if (this.type == 5)
      {
        this.name = "Jester's Arrow";
        this.width = 10;
        this.height = 10;
        this.aiStyle = 1;
        this.friendly = true;
        this.light = 0.4f;
        this.penetrate = -1;
        this.timeLeft = 40;
        this.alpha = 100;
        this.ignoreWater = true;
        this.ranged = true;
      }
      else if (this.type == 6)
      {
        this.name = "Enchanted Boomerang";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 3;
        this.friendly = true;
        this.penetrate = -1;
        this.melee = true;
        this.light = 0.4f;
      }
      else if (this.type == 7 || this.type == 8)
      {
        this.name = "Vilethorn";
        this.width = 28;
        this.height = 28;
        this.aiStyle = 4;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.alpha = (int) byte.MaxValue;
        this.ignoreWater = true;
        this.magic = true;
      }
      else if (this.type == 9)
      {
        this.name = "Starfury";
        this.width = 24;
        this.height = 24;
        this.aiStyle = 5;
        this.friendly = true;
        this.penetrate = 2;
        this.alpha = 50;
        this.scale = 0.8f;
        this.tileCollide = false;
        this.magic = true;
      }
      else if (this.type == 10)
      {
        this.name = "Purification Powder";
        this.width = 64;
        this.height = 64;
        this.aiStyle = 6;
        this.friendly = true;
        this.tileCollide = false;
        this.penetrate = -1;
        this.alpha = (int) byte.MaxValue;
        this.ignoreWater = true;
      }
      else if (this.type == 11)
      {
        this.name = "Vile Powder";
        this.width = 48;
        this.height = 48;
        this.aiStyle = 6;
        this.friendly = true;
        this.tileCollide = false;
        this.penetrate = -1;
        this.alpha = (int) byte.MaxValue;
        this.ignoreWater = true;
      }
      else if (this.type == 12)
      {
        this.name = "Falling Star";
        this.width = 16;
        this.height = 16;
        this.aiStyle = 5;
        this.friendly = true;
        this.penetrate = -1;
        this.alpha = 50;
        this.light = 1f;
      }
      else if (this.type == 13)
      {
        this.name = "Hook";
        this.width = 18;
        this.height = 18;
        this.aiStyle = 7;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.timeLeft *= 10;
      }
      else if (this.type == 14)
      {
        this.name = "Bullet";
        this.width = 4;
        this.height = 4;
        this.aiStyle = 1;
        this.friendly = true;
        this.penetrate = 1;
        this.light = 0.5f;
        this.alpha = (int) byte.MaxValue;
        this.maxUpdates = 1;
        this.scale = 1.2f;
        this.timeLeft = 600;
        this.ranged = true;
      }
      else if (this.type == 15)
      {
        this.name = "Ball of Fire";
        this.width = 16;
        this.height = 16;
        this.aiStyle = 8;
        this.friendly = true;
        this.light = 0.8f;
        this.alpha = 100;
        this.magic = true;
      }
      else if (this.type == 16)
      {
        this.name = "Magic Missile";
        this.width = 10;
        this.height = 10;
        this.aiStyle = 9;
        this.friendly = true;
        this.light = 0.8f;
        this.alpha = 100;
        this.magic = true;
      }
      else if (this.type == 17)
      {
        this.name = "Dirt Ball";
        this.width = 10;
        this.height = 10;
        this.aiStyle = 10;
        this.friendly = true;
      }
      else if (this.type == 18)
      {
        this.name = "Orb of Light";
        this.width = 32;
        this.height = 32;
        this.aiStyle = 11;
        this.friendly = true;
        this.light = 0.45f;
        this.alpha = 150;
        this.tileCollide = false;
        this.penetrate = -1;
        this.timeLeft *= 5;
        this.ignoreWater = true;
        this.scale = 0.8f;
      }
      else if (this.type == 19)
      {
        this.name = "Flamarang";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 3;
        this.friendly = true;
        this.penetrate = -1;
        this.light = 1f;
        this.melee = true;
      }
      else if (this.type == 20)
      {
        this.name = "Green Laser";
        this.width = 4;
        this.height = 4;
        this.aiStyle = 1;
        this.friendly = true;
        this.penetrate = 3;
        this.light = 0.75f;
        this.alpha = (int) byte.MaxValue;
        this.maxUpdates = 2;
        this.scale = 1.4f;
        this.timeLeft = 600;
        this.magic = true;
      }
      else if (this.type == 21)
      {
        this.name = "Bone";
        this.width = 16;
        this.height = 16;
        this.aiStyle = 2;
        this.scale = 1.2f;
        this.friendly = true;
        this.ranged = true;
      }
      else if (this.type == 22)
      {
        this.name = "Water Stream";
        this.width = 18;
        this.height = 18;
        this.aiStyle = 12;
        this.friendly = true;
        this.alpha = (int) byte.MaxValue;
        this.penetrate = -1;
        this.maxUpdates = 2;
        this.ignoreWater = true;
        this.magic = true;
      }
      else if (this.type == 23)
      {
        this.name = "Harpoon";
        this.width = 4;
        this.height = 4;
        this.aiStyle = 13;
        this.friendly = true;
        this.penetrate = -1;
        this.alpha = (int) byte.MaxValue;
        this.ranged = true;
      }
      else if (this.type == 24)
      {
        this.name = "Spiky Ball";
        this.width = 14;
        this.height = 14;
        this.aiStyle = 14;
        this.friendly = true;
        this.penetrate = 6;
        this.ranged = true;
      }
      else if (this.type == 25)
      {
        this.name = "Ball 'O Hurt";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 15;
        this.friendly = true;
        this.penetrate = -1;
        this.melee = true;
        this.scale = 0.8f;
      }
      else if (this.type == 26)
      {
        this.name = "Blue Moon";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 15;
        this.friendly = true;
        this.penetrate = -1;
        this.melee = true;
        this.scale = 0.8f;
      }
      else if (this.type == 27)
      {
        this.name = "Water Bolt";
        this.width = 16;
        this.height = 16;
        this.aiStyle = 8;
        this.friendly = true;
        this.light = 0.8f;
        this.alpha = 200;
        this.timeLeft /= 2;
        this.penetrate = 10;
        this.magic = true;
      }
      else if (this.type == 28)
      {
        this.name = "Bomb";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 16;
        this.friendly = true;
        this.penetrate = -1;
      }
      else if (this.type == 29)
      {
        this.name = "Dynamite";
        this.width = 10;
        this.height = 10;
        this.aiStyle = 16;
        this.friendly = true;
        this.penetrate = -1;
      }
      else if (this.type == 30)
      {
        this.name = "Grenade";
        this.width = 14;
        this.height = 14;
        this.aiStyle = 16;
        this.friendly = true;
        this.penetrate = -1;
        this.ranged = true;
      }
      else if (this.type == 31)
      {
        this.name = "Sand Ball";
        this.knockBack = 6f;
        this.width = 10;
        this.height = 10;
        this.aiStyle = 10;
        this.friendly = true;
        this.hostile = true;
        this.penetrate = -1;
      }
      else if (this.type == 32)
      {
        this.name = "Ivy Whip";
        this.width = 18;
        this.height = 18;
        this.aiStyle = 7;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.timeLeft *= 10;
      }
      else if (this.type == 33)
      {
        this.name = "Thorn Chakrum";
        this.width = 28;
        this.height = 28;
        this.aiStyle = 3;
        this.friendly = true;
        this.scale = 0.9f;
        this.penetrate = -1;
        this.melee = true;
      }
      else if (this.type == 34)
      {
        this.name = "Flamelash";
        this.width = 14;
        this.height = 14;
        this.aiStyle = 9;
        this.friendly = true;
        this.light = 0.8f;
        this.alpha = 100;
        this.penetrate = 1;
        this.magic = true;
      }
      else if (this.type == 35)
      {
        this.name = "Sunfury";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 15;
        this.friendly = true;
        this.penetrate = -1;
        this.melee = true;
        this.scale = 0.8f;
      }
      else if (this.type == 36)
      {
        this.name = "Meteor Shot";
        this.width = 4;
        this.height = 4;
        this.aiStyle = 1;
        this.friendly = true;
        this.penetrate = 2;
        this.light = 0.6f;
        this.alpha = (int) byte.MaxValue;
        this.maxUpdates = 1;
        this.scale = 1.4f;
        this.timeLeft = 600;
        this.ranged = true;
      }
      else if (this.type == 37)
      {
        this.name = "Sticky Bomb";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 16;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
      }
      else if (this.type == 38)
      {
        this.name = "Harpy Feather";
        this.width = 14;
        this.height = 14;
        this.aiStyle = 0;
        this.hostile = true;
        this.penetrate = -1;
        this.aiStyle = 1;
        this.tileCollide = true;
      }
      else if (this.type == 39)
      {
        this.name = "Mud Ball";
        this.knockBack = 6f;
        this.width = 10;
        this.height = 10;
        this.aiStyle = 10;
        this.friendly = true;
        this.hostile = true;
        this.penetrate = -1;
      }
      else if (this.type == 40)
      {
        this.name = "Ash Ball";
        this.knockBack = 6f;
        this.width = 10;
        this.height = 10;
        this.aiStyle = 10;
        this.friendly = true;
        this.hostile = true;
        this.penetrate = -1;
      }
      else if (this.type == 41)
      {
        this.name = "Hellfire Arrow";
        this.width = 10;
        this.height = 10;
        this.aiStyle = 1;
        this.friendly = true;
        this.penetrate = -1;
        this.ranged = true;
        this.light = 0.3f;
      }
      else if (this.type == 42)
      {
        this.name = "Sand Ball";
        this.knockBack = 8f;
        this.width = 10;
        this.height = 10;
        this.aiStyle = 10;
        this.friendly = true;
        this.maxUpdates = 1;
      }
      else if (this.type == 43)
      {
        this.name = "Tombstone";
        this.knockBack = 12f;
        this.width = 24;
        this.height = 24;
        this.aiStyle = 17;
        this.penetrate = -1;
      }
      else if (this.type == 44)
      {
        this.name = "Demon Sickle";
        this.width = 48;
        this.height = 48;
        this.alpha = 100;
        this.light = 0.2f;
        this.aiStyle = 18;
        this.hostile = true;
        this.penetrate = -1;
        this.tileCollide = true;
        this.scale = 0.9f;
      }
      else if (this.type == 45)
      {
        this.name = "Demon Scythe";
        this.width = 48;
        this.height = 48;
        this.alpha = 100;
        this.light = 0.2f;
        this.aiStyle = 18;
        this.friendly = true;
        this.penetrate = 5;
        this.tileCollide = true;
        this.scale = 0.9f;
        this.magic = true;
      }
      else if (this.type == 46)
      {
        this.name = "Dark Lance";
        this.width = 20;
        this.height = 20;
        this.aiStyle = 19;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.scale = 1.1f;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
      }
      else if (this.type == 47)
      {
        this.name = "Trident";
        this.width = 18;
        this.height = 18;
        this.aiStyle = 19;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.scale = 1.1f;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
      }
      else if (this.type == 48)
      {
        this.name = "Throwing Knife";
        this.width = 12;
        this.height = 12;
        this.aiStyle = 2;
        this.friendly = true;
        this.penetrate = 2;
        this.ranged = true;
      }
      else if (this.type == 49)
      {
        this.name = "Spear";
        this.width = 18;
        this.height = 18;
        this.aiStyle = 19;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.scale = 1.2f;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
      }
      else if (this.type == 50)
      {
        this.name = "Glowstick";
        this.width = 6;
        this.height = 6;
        this.aiStyle = 14;
        this.penetrate = -1;
        this.alpha = 75;
        this.light = 1f;
        this.timeLeft *= 5;
      }
      else if (this.type == 51)
      {
        this.name = "Seed";
        this.width = 8;
        this.height = 8;
        this.aiStyle = 1;
        this.friendly = true;
      }
      else if (this.type == 52)
      {
        this.name = "Wooden Boomerang";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 3;
        this.friendly = true;
        this.penetrate = -1;
        this.melee = true;
      }
      else if (this.type == 53)
      {
        this.name = "Sticky Glowstick";
        this.width = 6;
        this.height = 6;
        this.aiStyle = 14;
        this.penetrate = -1;
        this.alpha = 75;
        this.light = 1f;
        this.timeLeft *= 5;
        this.tileCollide = false;
      }
      else if (this.type == 54)
      {
        this.name = "Poisoned Knife";
        this.width = 12;
        this.height = 12;
        this.aiStyle = 2;
        this.friendly = true;
        this.penetrate = 2;
        this.ranged = true;
      }
      else if (this.type == 55)
      {
        this.name = "Stinger";
        this.width = 10;
        this.height = 10;
        this.aiStyle = 0;
        this.hostile = true;
        this.penetrate = -1;
        this.aiStyle = 1;
        this.tileCollide = true;
      }
      else if (this.type == 56)
      {
        this.name = "Ebonsand Ball";
        this.knockBack = 6f;
        this.width = 10;
        this.height = 10;
        this.aiStyle = 10;
        this.friendly = true;
        this.hostile = true;
        this.penetrate = -1;
      }
      else if (this.type == 57)
      {
        this.name = "Cobalt Chainsaw";
        this.width = 18;
        this.height = 18;
        this.aiStyle = 20;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
      }
      else if (this.type == 58)
      {
        this.name = "Mythril Chainsaw";
        this.width = 18;
        this.height = 18;
        this.aiStyle = 20;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
        this.scale = 1.08f;
      }
      else if (this.type == 59)
      {
        this.name = "Cobalt Drill";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 20;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
        this.scale = 0.9f;
      }
      else if (this.type == 60)
      {
        this.name = "Mythril Drill";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 20;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
        this.scale = 0.9f;
      }
      else if (this.type == 61)
      {
        this.name = "Adamantite Chainsaw";
        this.width = 18;
        this.height = 18;
        this.aiStyle = 20;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
        this.scale = 1.16f;
      }
      else if (this.type == 62)
      {
        this.name = "Adamantite Drill";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 20;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
        this.scale = 0.9f;
      }
      else if (this.type == 63)
      {
        this.name = "The Dao of Pow";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 15;
        this.friendly = true;
        this.penetrate = -1;
        this.melee = true;
      }
      else if (this.type == 64)
      {
        this.name = "Mythril Halberd";
        this.width = 18;
        this.height = 18;
        this.aiStyle = 19;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.scale = 1.25f;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
      }
      else if (this.type == 65)
      {
        this.name = "Ebonsand Ball";
        this.knockBack = 6f;
        this.width = 10;
        this.height = 10;
        this.aiStyle = 10;
        this.friendly = true;
        this.penetrate = -1;
        this.maxUpdates = 1;
      }
      else if (this.type == 66)
      {
        this.name = "Adamantite Glaive";
        this.width = 18;
        this.height = 18;
        this.aiStyle = 19;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.scale = 1.27f;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
      }
      else if (this.type == 67)
      {
        this.name = "Pearl Sand Ball";
        this.knockBack = 6f;
        this.width = 10;
        this.height = 10;
        this.aiStyle = 10;
        this.friendly = true;
        this.hostile = true;
        this.penetrate = -1;
      }
      else if (this.type == 68)
      {
        this.name = "Pearl Sand Ball";
        this.knockBack = 6f;
        this.width = 10;
        this.height = 10;
        this.aiStyle = 10;
        this.friendly = true;
        this.penetrate = -1;
        this.maxUpdates = 1;
      }
      else if (this.type == 69)
      {
        this.name = "Holy Water";
        this.width = 14;
        this.height = 14;
        this.aiStyle = 2;
        this.friendly = true;
        this.penetrate = 1;
      }
      else if (this.type == 70)
      {
        this.name = "Unholy Water";
        this.width = 14;
        this.height = 14;
        this.aiStyle = 2;
        this.friendly = true;
        this.penetrate = 1;
      }
      else if (this.type == 71)
      {
        this.name = "Gravel Ball";
        this.knockBack = 6f;
        this.width = 10;
        this.height = 10;
        this.aiStyle = 10;
        this.friendly = true;
        this.hostile = true;
        this.penetrate = -1;
      }
      else if (this.type == 72)
      {
        this.name = "Blue Fairy";
        this.width = 18;
        this.height = 18;
        this.aiStyle = 11;
        this.friendly = true;
        this.light = 0.9f;
        this.tileCollide = false;
        this.penetrate = -1;
        this.timeLeft *= 5;
        this.ignoreWater = true;
        this.scale = 0.8f;
      }
      else if (this.type == 73 || this.type == 74)
      {
        this.name = "Hook";
        this.width = 18;
        this.height = 18;
        this.aiStyle = 7;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.timeLeft *= 10;
        this.light = 0.4f;
      }
      else if (this.type == 75)
      {
        this.name = "Happy Bomb";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 16;
        this.hostile = true;
        this.penetrate = -1;
      }
      else if (this.type == 76 || this.type == 77 || this.type == 78)
      {
        if (this.type == 76)
        {
          this.width = 10;
          this.height = 22;
        }
        else if (this.type == 77)
        {
          this.width = 18;
          this.height = 24;
        }
        else
        {
          this.width = 22;
          this.height = 24;
        }
        this.name = "Note";
        this.aiStyle = 21;
        this.friendly = true;
        this.ranged = true;
        this.alpha = 100;
        this.light = 0.3f;
        this.penetrate = -1;
        this.timeLeft = 180;
      }
      else if (this.type == 79)
      {
        this.name = "Rainbow";
        this.width = 10;
        this.height = 10;
        this.aiStyle = 9;
        this.friendly = true;
        this.light = 0.8f;
        this.alpha = (int) byte.MaxValue;
        this.magic = true;
      }
      else if (this.type == 80)
      {
        this.name = "Ice Block";
        this.width = 16;
        this.height = 16;
        this.aiStyle = 22;
        this.friendly = true;
        this.magic = true;
        this.tileCollide = false;
        this.light = 0.5f;
      }
      else if (this.type == 81)
      {
        this.name = "Wooden Arrow";
        this.width = 10;
        this.height = 10;
        this.aiStyle = 1;
        this.hostile = true;
        this.ranged = true;
      }
      else if (this.type == 82)
      {
        this.name = "Flaming Arrow";
        this.width = 10;
        this.height = 10;
        this.aiStyle = 1;
        this.hostile = true;
        this.ranged = true;
      }
      else if (this.type == 83)
      {
        this.name = "Eye Laser";
        this.width = 4;
        this.height = 4;
        this.aiStyle = 1;
        this.hostile = true;
        this.penetrate = 3;
        this.light = 0.75f;
        this.alpha = (int) byte.MaxValue;
        this.maxUpdates = 2;
        this.scale = 1.7f;
        this.timeLeft = 600;
        this.magic = true;
      }
      else if (this.type == 84)
      {
        this.name = "Pink Laser";
        this.width = 4;
        this.height = 4;
        this.aiStyle = 1;
        this.hostile = true;
        this.penetrate = 3;
        this.light = 0.75f;
        this.alpha = (int) byte.MaxValue;
        this.maxUpdates = 2;
        this.scale = 1.2f;
        this.timeLeft = 600;
        this.magic = true;
      }
      else if (this.type == 85)
      {
        this.name = "Flames";
        this.width = 6;
        this.height = 6;
        this.aiStyle = 23;
        this.friendly = true;
        this.alpha = (int) byte.MaxValue;
        this.penetrate = 3;
        this.maxUpdates = 2;
        this.magic = true;
      }
      else if (this.type == 86)
      {
        this.name = "Pink Fairy";
        this.width = 18;
        this.height = 18;
        this.aiStyle = 11;
        this.friendly = true;
        this.light = 0.9f;
        this.tileCollide = false;
        this.penetrate = -1;
        this.timeLeft *= 5;
        this.ignoreWater = true;
        this.scale = 0.8f;
      }
      else if (this.type == 87)
      {
        this.name = "Pink Fairy";
        this.width = 18;
        this.height = 18;
        this.aiStyle = 11;
        this.friendly = true;
        this.light = 0.9f;
        this.tileCollide = false;
        this.penetrate = -1;
        this.timeLeft *= 5;
        this.ignoreWater = true;
        this.scale = 0.8f;
      }
      else if (this.type == 88)
      {
        this.name = "Purple Laser";
        this.width = 6;
        this.height = 6;
        this.aiStyle = 1;
        this.friendly = true;
        this.penetrate = 3;
        this.light = 0.75f;
        this.alpha = (int) byte.MaxValue;
        this.maxUpdates = 4;
        this.scale = 1.4f;
        this.timeLeft = 600;
        this.magic = true;
      }
      else if (this.type == 89)
      {
        this.name = "Crystal Bullet";
        this.width = 4;
        this.height = 4;
        this.aiStyle = 1;
        this.friendly = true;
        this.penetrate = 1;
        this.light = 0.5f;
        this.alpha = (int) byte.MaxValue;
        this.maxUpdates = 1;
        this.scale = 1.2f;
        this.timeLeft = 600;
        this.ranged = true;
      }
      else if (this.type == 90)
      {
        this.name = "Crystal Shard";
        this.width = 6;
        this.height = 6;
        this.aiStyle = 24;
        this.friendly = true;
        this.penetrate = 1;
        this.light = 0.5f;
        this.alpha = 50;
        this.scale = 1.2f;
        this.timeLeft = 600;
        this.ranged = true;
        this.tileCollide = false;
      }
      else if (this.type == 91)
      {
        this.name = "Holy Arrow";
        this.width = 10;
        this.height = 10;
        this.aiStyle = 1;
        this.friendly = true;
        this.ranged = true;
      }
      else if (this.type == 92)
      {
        this.name = "Hallow Star";
        this.width = 24;
        this.height = 24;
        this.aiStyle = 5;
        this.friendly = true;
        this.penetrate = 2;
        this.alpha = 50;
        this.scale = 0.8f;
        this.tileCollide = false;
        this.magic = true;
      }
      else if (this.type == 93)
      {
        this.light = 0.15f;
        this.name = "Magic Dagger";
        this.width = 12;
        this.height = 12;
        this.aiStyle = 2;
        this.friendly = true;
        this.penetrate = 2;
        this.magic = true;
      }
      else if (this.type == 94)
      {
        this.ignoreWater = true;
        this.name = "Crystal Storm";
        this.width = 8;
        this.height = 8;
        this.aiStyle = 24;
        this.friendly = true;
        this.light = 0.5f;
        this.alpha = 50;
        this.scale = 1.2f;
        this.timeLeft = 600;
        this.magic = true;
        this.tileCollide = true;
        this.penetrate = 1;
      }
      else if (this.type == 95)
      {
        this.name = "Cursed Flame";
        this.width = 16;
        this.height = 16;
        this.aiStyle = 8;
        this.friendly = true;
        this.light = 0.8f;
        this.alpha = 100;
        this.magic = true;
        this.penetrate = 2;
      }
      else if (this.type == 96)
      {
        this.name = "Cursed Flame";
        this.width = 16;
        this.height = 16;
        this.aiStyle = 8;
        this.hostile = true;
        this.light = 0.8f;
        this.alpha = 100;
        this.magic = true;
        this.penetrate = -1;
        this.scale = 0.9f;
        this.scale = 1.3f;
      }
      else if (this.type == 97)
      {
        this.name = "Cobalt Naginata";
        this.width = 18;
        this.height = 18;
        this.aiStyle = 19;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.scale = 1.1f;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
      }
      else if (this.type == 98)
      {
        this.name = "Poison Dart";
        this.width = 10;
        this.height = 10;
        this.aiStyle = 1;
        this.friendly = true;
        this.hostile = true;
        this.ranged = true;
        this.penetrate = -1;
      }
      else if (this.type == 99)
      {
        this.name = "Boulder";
        this.width = 31;
        this.height = 31;
        this.aiStyle = 25;
        this.friendly = true;
        this.hostile = true;
        this.ranged = true;
        this.penetrate = -1;
      }
      else if (this.type == 100)
      {
        this.name = "Death Laser";
        this.width = 4;
        this.height = 4;
        this.aiStyle = 1;
        this.hostile = true;
        this.penetrate = 3;
        this.light = 0.75f;
        this.alpha = (int) byte.MaxValue;
        this.maxUpdates = 2;
        this.scale = 1.8f;
        this.timeLeft = 1200;
        this.magic = true;
      }
      else if (this.type == 101)
      {
        this.name = "Eye Fire";
        this.width = 6;
        this.height = 6;
        this.aiStyle = 23;
        this.hostile = true;
        this.alpha = (int) byte.MaxValue;
        this.penetrate = -1;
        this.maxUpdates = 3;
        this.magic = true;
      }
      else if (this.type == 102)
      {
        this.name = "Bomb";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 16;
        this.hostile = true;
        this.penetrate = -1;
        this.ranged = true;
      }
      else if (this.type == 103)
      {
        this.name = "Cursed Arrow";
        this.width = 10;
        this.height = 10;
        this.aiStyle = 1;
        this.friendly = true;
        this.light = 1f;
        this.ranged = true;
      }
      else if (this.type == 104)
      {
        this.name = "Cursed Bullet";
        this.width = 4;
        this.height = 4;
        this.aiStyle = 1;
        this.friendly = true;
        this.penetrate = 1;
        this.light = 0.5f;
        this.alpha = (int) byte.MaxValue;
        this.maxUpdates = 1;
        this.scale = 1.2f;
        this.timeLeft = 600;
        this.ranged = true;
      }
      else if (this.type == 105)
      {
        this.name = "Gungnir";
        this.width = 18;
        this.height = 18;
        this.aiStyle = 19;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.scale = 1.3f;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
      }
      else if (this.type == 106)
      {
        this.name = "Light Disc";
        this.width = 32;
        this.height = 32;
        this.aiStyle = 3;
        this.friendly = true;
        this.penetrate = -1;
        this.melee = true;
        this.light = 0.4f;
      }
      else if (this.type == 107)
      {
        this.name = "Hamdrax";
        this.width = 22;
        this.height = 22;
        this.aiStyle = 20;
        this.friendly = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.hide = true;
        this.ownerHitCheck = true;
        this.melee = true;
        this.scale = 1.1f;
      }
      else if (this.type == 108)
      {
        this.name = "Explosives";
        this.width = 260;
        this.height = 260;
        this.aiStyle = 16;
        this.friendly = true;
        this.hostile = true;
        this.penetrate = -1;
        this.tileCollide = false;
        this.alpha = (int) byte.MaxValue;
        this.timeLeft = 2;
      }
      else if (this.type == 109)
      {
        this.name = "Snow Ball";
        this.knockBack = 6f;
        this.width = 10;
        this.height = 10;
        this.aiStyle = 10;
        this.hostile = true;
        this.scale = 0.9f;
        this.penetrate = -1;
      }
      else if (this.type == 110)
      {
        this.name = "Bullet";
        this.width = 4;
        this.height = 4;
        this.aiStyle = 1;
        this.hostile = true;
        this.penetrate = -1;
        this.light = 0.5f;
        this.alpha = (int) byte.MaxValue;
        this.maxUpdates = 1;
        this.scale = 1.2f;
        this.timeLeft = 600;
        this.ranged = true;
      }
      else if (this.type == 111)
      {
        this.name = "Bunny";
        this.width = 18;
        this.height = 18;
        this.aiStyle = 26;
        this.friendly = true;
        this.penetrate = -1;
        this.timeLeft *= 5;
      }
      else
        this.active = false;
      this.width = (int) ((double) this.width * (double) this.scale);
      this.height = (int) ((double) this.height * (double) this.scale);
    }

    public static int NewProjectile(
      float X,
      float Y,
      float SpeedX,
      float SpeedY,
      int Type,
      int Damage,
      float KnockBack,
      int Owner = 255)
    {
      int number = 1000;
      for (int index = 0; index < 1000; ++index)
      {
        if (!Main.projectile[index].active)
        {
          number = index;
          break;
        }
      }
      if (number == 1000)
        return number;
      Main.projectile[number].SetDefaults(Type);
      Main.projectile[number].position.X = X - (float) Main.projectile[number].width * 0.5f;
      Main.projectile[number].position.Y = Y - (float) Main.projectile[number].height * 0.5f;
      Main.projectile[number].owner = Owner;
      Main.projectile[number].velocity.X = SpeedX;
      Main.projectile[number].velocity.Y = SpeedY;
      Main.projectile[number].damage = Damage;
      Main.projectile[number].knockBack = KnockBack;
      Main.projectile[number].identity = number;
      Main.projectile[number].wet = Collision.WetCollision(Main.projectile[number].position, Main.projectile[number].width, Main.projectile[number].height);
      if (Main.netMode != 0 && Owner == Main.myPlayer)
        NetMessage.SendData(27, number: number);
      if (Owner == Main.myPlayer)
      {
        if (Type == 28)
          Main.projectile[number].timeLeft = 180;
        if (Type == 29)
          Main.projectile[number].timeLeft = 300;
        if (Type == 30)
          Main.projectile[number].timeLeft = 180;
        if (Type == 37)
          Main.projectile[number].timeLeft = 180;
        if (Type == 75)
          Main.projectile[number].timeLeft = 180;
      }
      return number;
    }

    public void StatusNPC(int i)
    {
      if (this.type == 2)
      {
        if (Main.rand.Next(3) != 0)
          return;
        Main.npc[i].AddBuff(24, 180);
      }
      else if (this.type == 15)
      {
        if (Main.rand.Next(2) != 0)
          return;
        Main.npc[i].AddBuff(24, 300);
      }
      else if (this.type == 19)
      {
        if (Main.rand.Next(5) != 0)
          return;
        Main.npc[i].AddBuff(24, 180);
      }
      else if (this.type == 33)
      {
        if (Main.rand.Next(5) != 0)
          return;
        Main.npc[i].AddBuff(20, 420);
      }
      else if (this.type == 34)
      {
        if (Main.rand.Next(2) != 0)
          return;
        Main.npc[i].AddBuff(24, 240);
      }
      else if (this.type == 35)
      {
        if (Main.rand.Next(4) != 0)
          return;
        Main.npc[i].AddBuff(24, 180);
      }
      else if (this.type == 54)
      {
        if (Main.rand.Next(2) != 0)
          return;
        Main.npc[i].AddBuff(20, 600);
      }
      else if (this.type == 63)
      {
        if (Main.rand.Next(3) == 0)
          return;
        Main.npc[i].AddBuff(31, 120);
      }
      else if (this.type == 85)
        Main.npc[i].AddBuff(24, 1200);
      else if (this.type == 95 || this.type == 103 || this.type == 104)
      {
        Main.npc[i].AddBuff(39, 420);
      }
      else
      {
        if (this.type != 98)
          return;
        Main.npc[i].AddBuff(20, 600);
      }
    }

    public void StatusPvP(int i)
    {
      if (this.type == 2)
      {
        if (Main.rand.Next(3) != 0)
          return;
        Main.player[i].AddBuff(24, 180, false);
      }
      else if (this.type == 15)
      {
        if (Main.rand.Next(2) != 0)
          return;
        Main.player[i].AddBuff(24, 300, false);
      }
      else if (this.type == 19)
      {
        if (Main.rand.Next(5) != 0)
          return;
        Main.player[i].AddBuff(24, 180, false);
      }
      else if (this.type == 33)
      {
        if (Main.rand.Next(5) != 0)
          return;
        Main.player[i].AddBuff(20, 420, false);
      }
      else if (this.type == 34)
      {
        if (Main.rand.Next(2) != 0)
          return;
        Main.player[i].AddBuff(24, 240, false);
      }
      else if (this.type == 35)
      {
        if (Main.rand.Next(4) != 0)
          return;
        Main.player[i].AddBuff(24, 180, false);
      }
      else if (this.type == 54)
      {
        if (Main.rand.Next(2) != 0)
          return;
        Main.player[i].AddBuff(20, 600, false);
      }
      else if (this.type == 63)
      {
        if (Main.rand.Next(3) == 0)
          return;
        Main.player[i].AddBuff(31, 120);
      }
      else if (this.type == 85)
      {
        Main.player[i].AddBuff(24, 1200, false);
      }
      else
      {
        if (this.type != 95 && this.type != 103 && this.type != 104)
          return;
        Main.player[i].AddBuff(39, 420);
      }
    }

    public void StatusPlayer(int i)
    {
      if (this.type == 55 && Main.rand.Next(3) == 0)
        Main.player[i].AddBuff(20, 600);
      if (this.type == 44 && Main.rand.Next(3) == 0)
        Main.player[i].AddBuff(22, 900);
      if (this.type == 82 && Main.rand.Next(3) == 0)
        Main.player[i].AddBuff(24, 420);
      if ((this.type == 96 || this.type == 101) && Main.rand.Next(3) == 0)
        Main.player[i].AddBuff(39, 480);
      if (this.type != 98)
        return;
      Main.player[i].AddBuff(20, 600);
    }

    public void Damage()
    {
      if (this.type == 18 || this.type == 72 || this.type == 86 || this.type == 87 || this.type == 111)
        return;
      Rectangle rectangle1 = new Rectangle((int) this.position.X, (int) this.position.Y, this.width, this.height);
      if (this.type == 85 || this.type == 101)
      {
        int num = 30;
        rectangle1.X -= num;
        rectangle1.Y -= num;
        rectangle1.Width += num * 2;
        rectangle1.Height += num * 2;
      }
      if (this.friendly && this.owner == Main.myPlayer)
      {
        if ((this.aiStyle == 16 || this.type == 41) && (this.timeLeft <= 1 || this.type == 108))
        {
          int player = Main.myPlayer;
          if (Main.player[player].active && !Main.player[player].dead && !Main.player[player].immune && (!this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.player[player].position, Main.player[player].width, Main.player[player].height)))
          {
            Rectangle rectangle2 = new Rectangle((int) Main.player[player].position.X, (int) Main.player[player].position.Y, Main.player[player].width, Main.player[player].height);
            if (rectangle1.Intersects(rectangle2))
            {
              this.direction = (double) Main.player[player].position.X + (double) (Main.player[player].width / 2) >= (double) this.position.X + (double) (this.width / 2) ? 1 : -1;
              int Damage = Main.DamageVar((float) this.damage);
              this.StatusPlayer(player);
              Main.player[player].Hurt(Damage, this.direction, true, deathText: Lang.deathMsg(this.owner, proj: this.whoAmI));
              if (Main.netMode != 0)
                NetMessage.SendData(26, text: Lang.deathMsg(this.owner, proj: this.whoAmI), number: player, number2: ((float) this.direction), number3: ((float) Damage), number4: 1f);
            }
          }
        }
        if (this.type != 69 && this.type != 70 && this.type != 10 && this.type != 11)
        {
          int num1 = (int) ((double) this.position.X / 16.0);
          int num2 = (int) (((double) this.position.X + (double) this.width) / 16.0) + 1;
          int num3 = (int) ((double) this.position.Y / 16.0);
          int num4 = (int) (((double) this.position.Y + (double) this.height) / 16.0) + 1;
          if (num1 < 0)
            num1 = 0;
          if (num2 > Main.maxTilesX)
            num2 = Main.maxTilesX;
          if (num3 < 0)
            num3 = 0;
          if (num4 > Main.maxTilesY)
            num4 = Main.maxTilesY;
          for (int i = num1; i < num2; ++i)
          {
            for (int j = num3; j < num4; ++j)
            {
              if (Main.tile[i, j] != null && Main.tileCut[(int) Main.tile[i, j].type] && Main.tile[i, j + 1] != null && Main.tile[i, j + 1].type != (byte) 78)
              {
                WorldGen.KillTile(i, j);
                if (Main.netMode != 0)
                  NetMessage.SendData(17, number2: ((float) i), number3: ((float) j));
              }
            }
          }
        }
      }
      if (this.owner == Main.myPlayer)
      {
        if (this.damage > 0)
        {
          for (int index = 0; index < 200; ++index)
          {
            if (Main.npc[index].active && !Main.npc[index].dontTakeDamage && ((!Main.npc[index].friendly || Main.npc[index].type == 22 && this.owner < (int) byte.MaxValue && Main.player[this.owner].killGuide) && this.friendly || Main.npc[index].friendly && this.hostile) && (this.owner < 0 || Main.npc[index].immune[this.owner] == 0))
            {
              bool flag = false;
              if (this.type == 11 && (Main.npc[index].type == 47 || Main.npc[index].type == 57))
                flag = true;
              else if (this.type == 31 && Main.npc[index].type == 69)
                flag = true;
              if (!flag && (Main.npc[index].noTileCollide || !this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.npc[index].position, Main.npc[index].width, Main.npc[index].height)))
              {
                Rectangle rectangle3 = new Rectangle((int) Main.npc[index].position.X, (int) Main.npc[index].position.Y, Main.npc[index].width, Main.npc[index].height);
                if (rectangle1.Intersects(rectangle3))
                {
                  if (this.aiStyle == 3)
                  {
                    if ((double) this.ai[0] == 0.0)
                    {
                      this.velocity.X = -this.velocity.X;
                      this.velocity.Y = -this.velocity.Y;
                      this.netUpdate = true;
                    }
                    this.ai[0] = 1f;
                  }
                  else if (this.aiStyle == 16)
                  {
                    if (this.timeLeft > 3)
                      this.timeLeft = 3;
                    this.direction = (double) Main.npc[index].position.X + (double) (Main.npc[index].width / 2) >= (double) this.position.X + (double) (this.width / 2) ? 1 : -1;
                  }
                  if (this.type == 41 && this.timeLeft > 1)
                    this.timeLeft = 1;
                  bool crit = false;
                  if (this.melee && Main.rand.Next(1, 101) <= Main.player[this.owner].meleeCrit)
                    crit = true;
                  if (this.ranged && Main.rand.Next(1, 101) <= Main.player[this.owner].rangedCrit)
                    crit = true;
                  if (this.magic && Main.rand.Next(1, 101) <= Main.player[this.owner].magicCrit)
                    crit = true;
                  int Damage = Main.DamageVar((float) this.damage);
                  this.StatusNPC(index);
                  Main.npc[index].StrikeNPC(Damage, this.knockBack, this.direction, crit);
                  if (Main.netMode != 0)
                  {
                    if (crit)
                      NetMessage.SendData(28, number: index, number2: ((float) Damage), number3: this.knockBack, number4: ((float) this.direction), number5: 1);
                    else
                      NetMessage.SendData(28, number: index, number2: ((float) Damage), number3: this.knockBack, number4: ((float) this.direction));
                  }
                  if (this.penetrate != 1)
                    Main.npc[index].immune[this.owner] = 10;
                  if (this.penetrate > 0)
                  {
                    --this.penetrate;
                    if (this.penetrate == 0)
                      break;
                  }
                  if (this.aiStyle == 7)
                  {
                    this.ai[0] = 1f;
                    this.damage = 0;
                    this.netUpdate = true;
                  }
                  else if (this.aiStyle == 13)
                  {
                    this.ai[0] = 1f;
                    this.netUpdate = true;
                  }
                }
              }
            }
          }
        }
        if (this.damage > 0 && Main.player[Main.myPlayer].hostile)
        {
          for (int index = 0; index < (int) byte.MaxValue; ++index)
          {
            if (index != this.owner && Main.player[index].active && !Main.player[index].dead && !Main.player[index].immune && Main.player[index].hostile && this.playerImmune[index] <= 0 && (Main.player[Main.myPlayer].team == 0 || Main.player[Main.myPlayer].team != Main.player[index].team) && (!this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.player[index].position, Main.player[index].width, Main.player[index].height)))
            {
              Rectangle rectangle4 = new Rectangle((int) Main.player[index].position.X, (int) Main.player[index].position.Y, Main.player[index].width, Main.player[index].height);
              if (rectangle1.Intersects(rectangle4))
              {
                if (this.aiStyle == 3)
                {
                  if ((double) this.ai[0] == 0.0)
                  {
                    this.velocity.X = -this.velocity.X;
                    this.velocity.Y = -this.velocity.Y;
                    this.netUpdate = true;
                  }
                  this.ai[0] = 1f;
                }
                else if (this.aiStyle == 16)
                {
                  if (this.timeLeft > 3)
                    this.timeLeft = 3;
                  this.direction = (double) Main.player[index].position.X + (double) (Main.player[index].width / 2) >= (double) this.position.X + (double) (this.width / 2) ? 1 : -1;
                }
                if (this.type == 41 && this.timeLeft > 1)
                  this.timeLeft = 1;
                bool Crit = false;
                if (this.melee && Main.rand.Next(1, 101) <= Main.player[this.owner].meleeCrit)
                  Crit = true;
                int Damage = Main.DamageVar((float) this.damage);
                if (!Main.player[index].immune)
                  this.StatusPvP(index);
                Main.player[index].Hurt(Damage, this.direction, true, deathText: Lang.deathMsg(this.owner, proj: this.whoAmI), Crit: Crit);
                if (Main.netMode != 0)
                {
                  if (Crit)
                    NetMessage.SendData(26, text: Lang.deathMsg(this.owner, proj: this.whoAmI), number: index, number2: ((float) this.direction), number3: ((float) Damage), number4: 1f, number5: 1);
                  else
                    NetMessage.SendData(26, text: Lang.deathMsg(this.owner, proj: this.whoAmI), number: index, number2: ((float) this.direction), number3: ((float) Damage), number4: 1f);
                }
                this.playerImmune[index] = 40;
                if (this.penetrate > 0)
                {
                  --this.penetrate;
                  if (this.penetrate == 0)
                    break;
                }
                if (this.aiStyle == 7)
                {
                  this.ai[0] = 1f;
                  this.damage = 0;
                  this.netUpdate = true;
                }
                else if (this.aiStyle == 13)
                {
                  this.ai[0] = 1f;
                  this.netUpdate = true;
                }
              }
            }
          }
        }
      }
      if (this.type == 11 && Main.netMode != 1)
      {
        for (int index = 0; index < 200; ++index)
        {
          if (Main.npc[index].active)
          {
            if (Main.npc[index].type == 46)
            {
              Rectangle rectangle5 = new Rectangle((int) Main.npc[index].position.X, (int) Main.npc[index].position.Y, Main.npc[index].width, Main.npc[index].height);
              if (rectangle1.Intersects(rectangle5))
                Main.npc[index].Transform(47);
            }
            else if (Main.npc[index].type == 55)
            {
              Rectangle rectangle6 = new Rectangle((int) Main.npc[index].position.X, (int) Main.npc[index].position.Y, Main.npc[index].width, Main.npc[index].height);
              if (rectangle1.Intersects(rectangle6))
                Main.npc[index].Transform(57);
            }
          }
        }
      }
      if (Main.netMode == 2 || !this.hostile || Main.myPlayer >= (int) byte.MaxValue || this.damage <= 0)
        return;
      int player1 = Main.myPlayer;
      if (!Main.player[player1].active || Main.player[player1].dead || Main.player[player1].immune)
        return;
      Rectangle rectangle7 = new Rectangle((int) Main.player[player1].position.X, (int) Main.player[player1].position.Y, Main.player[player1].width, Main.player[player1].height);
      if (!rectangle1.Intersects(rectangle7))
        return;
      int direction = this.direction;
      int hitDirection = (double) Main.player[player1].position.X + (double) (Main.player[player1].width / 2) >= (double) this.position.X + (double) (this.width / 2) ? 1 : -1;
      int num5 = Main.DamageVar((float) this.damage);
      if (!Main.player[player1].immune)
        this.StatusPlayer(player1);
      Main.player[player1].Hurt(num5 * 2, hitDirection, deathText: Lang.deathMsg(proj: this.whoAmI));
    }

    public void Update(int i)
    {
      if (!this.active)
        return;
      Vector2 vector2 = this.velocity;
      if ((double) this.position.X <= (double) Main.leftWorld || (double) this.position.X + (double) this.width >= (double) Main.rightWorld || (double) this.position.Y <= (double) Main.topWorld || (double) this.position.Y + (double) this.height >= (double) Main.bottomWorld)
      {
        this.active = false;
      }
      else
      {
        this.whoAmI = i;
        if (this.soundDelay > 0)
          --this.soundDelay;
        this.netUpdate = false;
        for (int index = 0; index < (int) byte.MaxValue; ++index)
        {
          if (this.playerImmune[index] > 0)
            --this.playerImmune[index];
        }
        this.AI();
        if (this.owner < (int) byte.MaxValue && !Main.player[this.owner].active)
          this.Kill();
        if (!this.ignoreWater)
        {
          bool flag1;
          bool flag2;
          try
          {
            flag1 = Collision.LavaCollision(this.position, this.width, this.height);
            flag2 = Collision.WetCollision(this.position, this.width, this.height);
            if (flag1)
              this.lavaWet = true;
          }
          catch
          {
            this.active = false;
            return;
          }
          if (this.wet && !this.lavaWet)
          {
            if (this.type == 85 || this.type == 15 || this.type == 34)
              this.Kill();
            if (this.type == 2)
            {
              this.type = 1;
              this.light = 0.0f;
            }
          }
          if (this.type == 80)
          {
            flag2 = false;
            this.wet = false;
            if (flag1 && (double) this.ai[0] >= 0.0)
              this.Kill();
          }
          if (flag2)
          {
            if (this.wetCount == (byte) 0)
            {
              this.wetCount = (byte) 10;
              if (!this.wet)
              {
                if (!flag1)
                {
                  for (int index1 = 0; index1 < 10; ++index1)
                  {
                    int index2 = Dust.NewDust(new Vector2(this.position.X - 6f, (float) ((double) this.position.Y + (double) (this.height / 2) - 8.0)), this.width + 12, 24, 33);
                    Main.dust[index2].velocity.Y -= 4f;
                    Main.dust[index2].velocity.X *= 2.5f;
                    Main.dust[index2].scale = 1.3f;
                    Main.dust[index2].alpha = 100;
                    Main.dust[index2].noGravity = true;
                  }
                  Main.PlaySound(19, (int) this.position.X, (int) this.position.Y);
                }
                else
                {
                  for (int index3 = 0; index3 < 10; ++index3)
                  {
                    int index4 = Dust.NewDust(new Vector2(this.position.X - 6f, (float) ((double) this.position.Y + (double) (this.height / 2) - 8.0)), this.width + 12, 24, 35);
                    Main.dust[index4].velocity.Y -= 1.5f;
                    Main.dust[index4].velocity.X *= 2.5f;
                    Main.dust[index4].scale = 1.3f;
                    Main.dust[index4].alpha = 100;
                    Main.dust[index4].noGravity = true;
                  }
                  Main.PlaySound(19, (int) this.position.X, (int) this.position.Y);
                }
              }
              this.wet = true;
            }
          }
          else if (this.wet)
          {
            this.wet = false;
            if (this.wetCount == (byte) 0)
            {
              this.wetCount = (byte) 10;
              if (!this.lavaWet)
              {
                for (int index5 = 0; index5 < 10; ++index5)
                {
                  int index6 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float) (this.height / 2)), this.width + 12, 24, 33);
                  Main.dust[index6].velocity.Y -= 4f;
                  Main.dust[index6].velocity.X *= 2.5f;
                  Main.dust[index6].scale = 1.3f;
                  Main.dust[index6].alpha = 100;
                  Main.dust[index6].noGravity = true;
                }
                Main.PlaySound(19, (int) this.position.X, (int) this.position.Y);
              }
              else
              {
                for (int index7 = 0; index7 < 10; ++index7)
                {
                  int index8 = Dust.NewDust(new Vector2(this.position.X - 6f, (float) ((double) this.position.Y + (double) (this.height / 2) - 8.0)), this.width + 12, 24, 35);
                  Main.dust[index8].velocity.Y -= 1.5f;
                  Main.dust[index8].velocity.X *= 2.5f;
                  Main.dust[index8].scale = 1.3f;
                  Main.dust[index8].alpha = 100;
                  Main.dust[index8].noGravity = true;
                }
                Main.PlaySound(19, (int) this.position.X, (int) this.position.Y);
              }
            }
          }
          if (!this.wet)
            this.lavaWet = false;
          if (this.wetCount > (byte) 0)
            --this.wetCount;
        }
        this.lastPosition = this.position;
        if (this.tileCollide)
        {
          Vector2 velocity1 = this.velocity;
          bool flag3 = true;
          if (this.type == 9 || this.type == 12 || this.type == 15 || this.type == 13 || this.type == 31 || this.type == 39 || this.type == 40)
            flag3 = false;
          if (this.aiStyle == 10)
            this.velocity = this.type == 42 || this.type == 65 || this.type == 68 || this.type == 31 && (double) this.ai[0] == 2.0 ? Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag3, flag3) : Collision.AnyCollision(this.position, this.velocity, this.width, this.height);
          else if (this.aiStyle == 18)
          {
            int Width = this.width - 36;
            int Height = this.height - 36;
            this.velocity = Collision.TileCollision(new Vector2(this.position.X + (float) (this.width / 2) - (float) (Width / 2), this.position.Y + (float) (this.height / 2) - (float) (Height / 2)), this.velocity, Width, Height, flag3, flag3);
          }
          else if (this.wet)
          {
            Vector2 velocity2 = this.velocity;
            this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag3, flag3);
            vector2 = this.velocity * 0.5f;
            if ((double) this.velocity.X != (double) velocity2.X)
              vector2.X = this.velocity.X;
            if ((double) this.velocity.Y != (double) velocity2.Y)
              vector2.Y = this.velocity.Y;
          }
          else
            this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag3, flag3);
          if (velocity1 != this.velocity && this.type != 111)
          {
            if (this.type == 94)
            {
              if ((double) this.velocity.X != (double) velocity1.X)
                this.velocity.X = -velocity1.X;
              if ((double) this.velocity.Y != (double) velocity1.Y)
                this.velocity.Y = -velocity1.Y;
            }
            else if (this.type == 99)
            {
              if ((double) this.velocity.Y != (double) velocity1.Y && (double) velocity1.Y > 5.0)
              {
                Collision.HitTiles(this.position, this.velocity, this.width, this.height);
                Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
                this.velocity.Y = (float) (-(double) velocity1.Y * 0.200000002980232);
              }
              if ((double) this.velocity.X != (double) velocity1.X)
                this.Kill();
            }
            else if (this.type == 36)
            {
              if (this.penetrate > 1)
              {
                Collision.HitTiles(this.position, this.velocity, this.width, this.height);
                Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
                --this.penetrate;
                if ((double) this.velocity.X != (double) velocity1.X)
                  this.velocity.X = -velocity1.X;
                if ((double) this.velocity.Y != (double) velocity1.Y)
                  this.velocity.Y = -velocity1.Y;
              }
              else
                this.Kill();
            }
            else if (this.aiStyle == 21)
            {
              if ((double) this.velocity.X != (double) velocity1.X)
                this.velocity.X = -velocity1.X;
              if ((double) this.velocity.Y != (double) velocity1.Y)
                this.velocity.Y = -velocity1.Y;
            }
            else if (this.aiStyle == 17)
            {
              if ((double) this.velocity.X != (double) velocity1.X)
                this.velocity.X = velocity1.X * -0.75f;
              if ((double) this.velocity.Y != (double) velocity1.Y && (double) velocity1.Y > 1.5)
                this.velocity.Y = velocity1.Y * -0.7f;
            }
            else if (this.aiStyle == 15)
            {
              bool flag4 = false;
              if ((double) velocity1.X != (double) this.velocity.X)
              {
                if ((double) Math.Abs(velocity1.X) > 4.0)
                  flag4 = true;
                this.position.X += this.velocity.X;
                this.velocity.X = (float) (-(double) velocity1.X * 0.200000002980232);
              }
              if ((double) velocity1.Y != (double) this.velocity.Y)
              {
                if ((double) Math.Abs(velocity1.Y) > 4.0)
                  flag4 = true;
                this.position.Y += this.velocity.Y;
                this.velocity.Y = (float) (-(double) velocity1.Y * 0.200000002980232);
              }
              this.ai[0] = 1f;
              if (flag4)
              {
                this.netUpdate = true;
                Collision.HitTiles(this.position, this.velocity, this.width, this.height);
                Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
              }
            }
            else if (this.aiStyle == 3 || this.aiStyle == 13)
            {
              Collision.HitTiles(this.position, this.velocity, this.width, this.height);
              if (this.type == 33 || this.type == 106)
              {
                if ((double) this.velocity.X != (double) velocity1.X)
                  this.velocity.X = -velocity1.X;
                if ((double) this.velocity.Y != (double) velocity1.Y)
                  this.velocity.Y = -velocity1.Y;
              }
              else
              {
                this.ai[0] = 1f;
                if (this.aiStyle == 3)
                {
                  this.velocity.X = -velocity1.X;
                  this.velocity.Y = -velocity1.Y;
                }
              }
              this.netUpdate = true;
              Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
            }
            else if (this.aiStyle == 8 && this.type != 96)
            {
              Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
              ++this.ai[0];
              if ((double) this.ai[0] >= 5.0)
              {
                this.position += this.velocity;
                this.Kill();
              }
              else
              {
                if (this.type == 15 && (double) this.velocity.Y > 4.0)
                {
                  if ((double) this.velocity.Y != (double) velocity1.Y)
                    this.velocity.Y = (float) (-(double) velocity1.Y * 0.800000011920929);
                }
                else if ((double) this.velocity.Y != (double) velocity1.Y)
                  this.velocity.Y = -velocity1.Y;
                if ((double) this.velocity.X != (double) velocity1.X)
                  this.velocity.X = -velocity1.X;
              }
            }
            else if (this.aiStyle == 14)
            {
              if (this.type == 50)
              {
                if ((double) this.velocity.X != (double) velocity1.X)
                  this.velocity.X = velocity1.X * -0.2f;
                if ((double) this.velocity.Y != (double) velocity1.Y && (double) velocity1.Y > 1.5)
                  this.velocity.Y = velocity1.Y * -0.2f;
              }
              else
              {
                if ((double) this.velocity.X != (double) velocity1.X)
                  this.velocity.X = velocity1.X * -0.5f;
                if ((double) this.velocity.Y != (double) velocity1.Y && (double) velocity1.Y > 1.0)
                  this.velocity.Y = velocity1.Y * -0.5f;
              }
            }
            else if (this.aiStyle == 16)
            {
              if ((double) this.velocity.X != (double) velocity1.X)
              {
                this.velocity.X = velocity1.X * -0.4f;
                if (this.type == 29)
                  this.velocity.X *= 0.8f;
              }
              if ((double) this.velocity.Y != (double) velocity1.Y && (double) velocity1.Y > 0.7 && this.type != 102)
              {
                this.velocity.Y = velocity1.Y * -0.4f;
                if (this.type == 29)
                  this.velocity.Y *= 0.8f;
              }
            }
            else if (this.aiStyle != 9 || this.owner == Main.myPlayer)
            {
              this.position += this.velocity;
              this.Kill();
            }
          }
        }
        if (this.type != 7 && this.type != 8)
        {
          if (this.wet)
            this.position += vector2;
          else
            this.position += this.velocity;
        }
        if ((this.aiStyle != 3 || (double) this.ai[0] != 1.0) && (this.aiStyle != 7 || (double) this.ai[0] != 1.0) && (this.aiStyle != 13 || (double) this.ai[0] != 1.0) && (this.aiStyle != 15 || (double) this.ai[0] != 1.0) && this.aiStyle != 15 && this.aiStyle != 26)
          this.direction = (double) this.velocity.X >= 0.0 ? 1 : -1;
        if (!this.active)
          return;
        if ((double) this.light > 0.0)
        {
          float R = this.light;
          float G = this.light;
          float B = this.light;
          if (this.type == 2 || this.type == 82)
          {
            G *= 0.75f;
            B *= 0.55f;
          }
          else if (this.type == 94)
          {
            R *= 0.5f;
            G *= 0.0f;
          }
          else if (this.type == 95 || this.type == 96 || this.type == 103 || this.type == 104)
          {
            R *= 0.35f;
            G *= 1f;
            B *= 0.0f;
          }
          else if (this.type == 4)
          {
            G *= 0.1f;
            R *= 0.5f;
          }
          else if (this.type == 9)
          {
            G *= 0.1f;
            B *= 0.6f;
          }
          else if (this.type == 92)
          {
            G *= 0.6f;
            R *= 0.8f;
          }
          else if (this.type == 93)
          {
            G *= 1f;
            R *= 1f;
            B *= 0.01f;
          }
          else if (this.type == 12)
          {
            R *= 0.9f;
            G *= 0.8f;
            B *= 0.1f;
          }
          else if (this.type == 14 || this.type == 110)
          {
            G *= 0.7f;
            B *= 0.1f;
          }
          else if (this.type == 15)
          {
            G *= 0.4f;
            B *= 0.1f;
            R = 1f;
          }
          else if (this.type == 16)
          {
            R *= 0.1f;
            G *= 0.4f;
            B = 1f;
          }
          else if (this.type == 18)
          {
            G *= 0.7f;
            B *= 0.3f;
          }
          else if (this.type == 19)
          {
            G *= 0.5f;
            B *= 0.1f;
          }
          else if (this.type == 20)
          {
            R *= 0.1f;
            B *= 0.3f;
          }
          else if (this.type == 22)
          {
            R = 0.0f;
            G = 0.0f;
          }
          else if (this.type == 27)
          {
            R *= 0.0f;
            G *= 0.3f;
            B = 1f;
          }
          else if (this.type == 34)
          {
            G *= 0.1f;
            B *= 0.1f;
          }
          else if (this.type == 36)
          {
            R = 0.8f;
            G *= 0.2f;
            B *= 0.6f;
          }
          else if (this.type == 41)
          {
            G *= 0.8f;
            B *= 0.6f;
          }
          else if (this.type == 44 || this.type == 45)
          {
            B = 1f;
            R *= 0.6f;
            G *= 0.1f;
          }
          else if (this.type == 50)
          {
            R *= 0.7f;
            B *= 0.8f;
          }
          else if (this.type == 53)
          {
            R *= 0.7f;
            G *= 0.8f;
          }
          else if (this.type == 72)
          {
            R *= 0.45f;
            G *= 0.75f;
            B = 1f;
          }
          else if (this.type == 86)
          {
            R *= 1f;
            G *= 0.45f;
            B = 0.75f;
          }
          else if (this.type == 87)
          {
            R *= 0.45f;
            G = 1f;
            B *= 0.75f;
          }
          else if (this.type == 73)
          {
            R *= 0.4f;
            G *= 0.6f;
            B *= 1f;
          }
          else if (this.type == 74)
          {
            R *= 1f;
            G *= 0.4f;
            B *= 0.6f;
          }
          else if (this.type == 76 || this.type == 77 || this.type == 78)
          {
            R *= 1f;
            G *= 0.3f;
            B *= 0.6f;
          }
          else if (this.type == 79)
          {
            R = (float) Main.DiscoR / (float) byte.MaxValue;
            G = (float) Main.DiscoG / (float) byte.MaxValue;
            B = (float) Main.DiscoB / (float) byte.MaxValue;
          }
          else if (this.type == 80)
          {
            R *= 0.0f;
            G *= 0.8f;
            B *= 1f;
          }
          else if (this.type == 83 || this.type == 88)
          {
            R *= 0.7f;
            G *= 0.0f;
            B *= 1f;
          }
          else if (this.type == 100)
          {
            R *= 1f;
            G *= 0.5f;
            B *= 0.0f;
          }
          else if (this.type == 84)
          {
            R *= 0.8f;
            G *= 0.0f;
            B *= 0.5f;
          }
          else if (this.type == 89 || this.type == 90)
          {
            G *= 0.2f;
            B *= 1f;
            R *= 0.05f;
          }
          else if (this.type == 106)
          {
            R *= 0.0f;
            G *= 0.5f;
            B *= 1f;
          }
          Lighting.addLight((int) (((double) this.position.X + (double) (this.width / 2)) / 16.0), (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0), R, G, B);
        }
        if (this.type == 2 || this.type == 82)
          Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100);
        else if (this.type == 103)
        {
          int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, Alpha: 100);
          if (Main.rand.Next(2) == 0)
          {
            Main.dust[index].noGravity = true;
            Main.dust[index].scale *= 2f;
          }
        }
        else if (this.type == 4)
        {
          if (Main.rand.Next(5) == 0)
            Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, Alpha: 150, Scale: 1.1f);
        }
        else if (this.type == 5)
        {
          int Type;
          switch (Main.rand.Next(3))
          {
            case 0:
              Type = 15;
              break;
            case 1:
              Type = 57;
              break;
            default:
              Type = 58;
              break;
          }
          Dust.NewDust(this.position, this.width, this.height, Type, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, Scale: 1.2f);
        }
        this.Damage();
        if (Main.netMode != 1 && this.type == 99)
          Collision.SwitchTiles(this.position, this.width, this.height, this.lastPosition);
        if (this.type == 94)
        {
          for (int index = this.oldPos.Length - 1; index > 0; --index)
            this.oldPos[index] = this.oldPos[index - 1];
          this.oldPos[0] = this.position;
        }
        --this.timeLeft;
        if (this.timeLeft <= 0)
          this.Kill();
        if (this.penetrate == 0)
          this.Kill();
        if (this.active && this.owner == Main.myPlayer)
        {
          if (this.netUpdate2)
            this.netUpdate = true;
          if (!this.active)
            this.netSpam = 0;
          if (this.netUpdate)
          {
            if (this.netSpam < 60)
            {
              this.netSpam += 5;
              NetMessage.SendData(27, number: i);
              this.netUpdate2 = false;
            }
            else
              this.netUpdate2 = true;
          }
          if (this.netSpam > 0)
            --this.netSpam;
        }
        if (this.active && this.maxUpdates > 0)
        {
          --this.numUpdates;
          if (this.numUpdates >= 0)
            this.Update(i);
          else
            this.numUpdates = this.maxUpdates;
        }
        this.netUpdate = false;
      }
    }

    public void AI()
    {
      if (this.aiStyle == 1)
      {
        if (this.type == 83 && (double) this.ai[1] == 0.0)
        {
          this.ai[1] = 1f;
          Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 33);
        }
        if (this.type == 110 && (double) this.ai[1] == 0.0)
        {
          this.ai[1] = 1f;
          Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 11);
        }
        if (this.type == 84 && (double) this.ai[1] == 0.0)
        {
          this.ai[1] = 1f;
          Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 12);
        }
        if (this.type == 100 && (double) this.ai[1] == 0.0)
        {
          this.ai[1] = 1f;
          Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 33);
        }
        if (this.type == 98 && (double) this.ai[1] == 0.0)
        {
          this.ai[1] = 1f;
          Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 17);
        }
        if ((this.type == 81 || this.type == 82) && (double) this.ai[1] == 0.0)
        {
          Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 5);
          this.ai[1] = 1f;
        }
        if (this.type == 41)
        {
          int index1 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, Alpha: 100, Scale: 1.6f);
          Main.dust[index1].noGravity = true;
          int index2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 2f);
          Main.dust[index2].noGravity = true;
        }
        else if (this.type == 55)
        {
          int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 18, Scale: 0.9f);
          Main.dust[index].noGravity = true;
        }
        else if (this.type == 91 && Main.rand.Next(2) == 0)
        {
          int index = Dust.NewDust(this.position, this.width, this.height, Main.rand.Next(2) != 0 ? 58 : 15, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 150, Scale: 0.9f);
          Main.dust[index].velocity *= 0.25f;
        }
        if (this.type == 20 || this.type == 14 || this.type == 36 || this.type == 83 || this.type == 84 || this.type == 89 || this.type == 100 || this.type == 104 || this.type == 110)
        {
          if (this.alpha > 0)
            this.alpha -= 15;
          if (this.alpha < 0)
            this.alpha = 0;
        }
        if (this.type == 88)
        {
          if (this.alpha > 0)
            this.alpha -= 10;
          if (this.alpha < 0)
            this.alpha = 0;
        }
        if (this.type != 5 && this.type != 14 && this.type != 20 && this.type != 36 && this.type != 38 && this.type != 55 && this.type != 83 && this.type != 84 && this.type != 88 && this.type != 89 && this.type != 98 && this.type != 100 && this.type != 104 && this.type != 110)
          ++this.ai[0];
        if (this.type == 81 || this.type == 91)
        {
          if ((double) this.ai[0] >= 20.0)
          {
            this.ai[0] = 20f;
            this.velocity.Y += 0.07f;
          }
        }
        else if ((double) this.ai[0] >= 15.0)
        {
          this.ai[0] = 15f;
          this.velocity.Y += 0.1f;
        }
        this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 1.57f;
        if ((double) this.velocity.Y <= 16.0)
          return;
        this.velocity.Y = 16f;
      }
      else if (this.aiStyle == 2)
      {
        if (this.type == 93 && Main.rand.Next(5) == 0)
        {
          int index = Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.2f + (float) (this.direction * 3), this.velocity.Y * 0.2f, 100, Scale: 0.3f);
          Main.dust[index].velocity.X *= 0.3f;
          Main.dust[index].velocity.Y *= 0.3f;
        }
        this.rotation += (float) (((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y)) * 0.0299999993294477) * (float) this.direction;
        if (this.type == 69 || this.type == 70)
        {
          ++this.ai[0];
          if ((double) this.ai[0] >= 10.0)
          {
            this.velocity.Y += 0.25f;
            this.velocity.X *= 0.99f;
          }
        }
        else
        {
          ++this.ai[0];
          if ((double) this.ai[0] >= 20.0)
          {
            this.velocity.Y += 0.4f;
            this.velocity.X *= 0.97f;
          }
          else if (this.type == 48 || this.type == 54 || this.type == 93)
            this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 1.57f;
        }
        if ((double) this.velocity.Y > 16.0)
          this.velocity.Y = 16f;
        if (this.type != 54 || Main.rand.Next(20) != 0)
          return;
        Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 40, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, Scale: 0.75f);
      }
      else if (this.aiStyle == 3)
      {
        if (this.soundDelay == 0)
        {
          this.soundDelay = 8;
          Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 7);
        }
        if (this.type == 19)
        {
          for (int index3 = 0; index3 < 2; ++index3)
          {
            int index4 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, Scale: 2f);
            Main.dust[index4].noGravity = true;
            Main.dust[index4].velocity.X *= 0.3f;
            Main.dust[index4].velocity.Y *= 0.3f;
          }
        }
        else if (this.type == 33)
        {
          if (Main.rand.Next(1) == 0)
          {
            int index = Dust.NewDust(this.position, this.width, this.height, 40, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, Scale: 1.4f);
            Main.dust[index].noGravity = true;
          }
        }
        else if (this.type == 6 && Main.rand.Next(5) == 0)
        {
          int Type;
          switch (Main.rand.Next(3))
          {
            case 0:
              Type = 15;
              break;
            case 1:
              Type = 57;
              break;
            default:
              Type = 58;
              break;
          }
          Dust.NewDust(this.position, this.width, this.height, Type, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 150, Scale: 0.7f);
        }
        if ((double) this.ai[0] == 0.0)
        {
          ++this.ai[1];
          if (this.type == 106)
          {
            if ((double) this.ai[1] >= 45.0)
            {
              this.ai[0] = 1f;
              this.ai[1] = 0.0f;
              this.netUpdate = true;
            }
          }
          else if ((double) this.ai[1] >= 30.0)
          {
            this.ai[0] = 1f;
            this.ai[1] = 0.0f;
            this.netUpdate = true;
          }
        }
        else
        {
          this.tileCollide = false;
          float num1 = 9f;
          float num2 = 0.4f;
          if (this.type == 19)
          {
            num1 = 13f;
            num2 = 0.6f;
          }
          else if (this.type == 33)
          {
            num1 = 15f;
            num2 = 0.8f;
          }
          else if (this.type == 106)
          {
            num1 = 16f;
            num2 = 1.2f;
          }
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num3 = Main.player[this.owner].position.X + (float) (Main.player[this.owner].width / 2) - vector2.X;
          float num4 = Main.player[this.owner].position.Y + (float) (Main.player[this.owner].height / 2) - vector2.Y;
          float num5 = (float) Math.Sqrt((double) num3 * (double) num3 + (double) num4 * (double) num4);
          if ((double) num5 > 3000.0)
            this.Kill();
          float num6 = num1 / num5;
          float num7 = num3 * num6;
          float num8 = num4 * num6;
          if ((double) this.velocity.X < (double) num7)
          {
            this.velocity.X += num2;
            if ((double) this.velocity.X < 0.0 && (double) num7 > 0.0)
              this.velocity.X += num2;
          }
          else if ((double) this.velocity.X > (double) num7)
          {
            this.velocity.X -= num2;
            if ((double) this.velocity.X > 0.0 && (double) num7 < 0.0)
              this.velocity.X -= num2;
          }
          if ((double) this.velocity.Y < (double) num8)
          {
            this.velocity.Y += num2;
            if ((double) this.velocity.Y < 0.0 && (double) num8 > 0.0)
              this.velocity.Y += num2;
          }
          else if ((double) this.velocity.Y > (double) num8)
          {
            this.velocity.Y -= num2;
            if ((double) this.velocity.Y > 0.0 && (double) num8 < 0.0)
              this.velocity.Y -= num2;
          }
          if (Main.myPlayer == this.owner && new Rectangle((int) this.position.X, (int) this.position.Y, this.width, this.height).Intersects(new Rectangle((int) Main.player[this.owner].position.X, (int) Main.player[this.owner].position.Y, Main.player[this.owner].width, Main.player[this.owner].height)))
            this.Kill();
        }
        if (this.type == 106)
          this.rotation += 0.3f * (float) this.direction;
        else
          this.rotation += 0.4f * (float) this.direction;
      }
      else if (this.aiStyle == 4)
      {
        this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 1.57f;
        if ((double) this.ai[0] == 0.0)
        {
          this.alpha -= 50;
          if (this.alpha > 0)
            return;
          this.alpha = 0;
          this.ai[0] = 1f;
          if ((double) this.ai[1] == 0.0)
          {
            ++this.ai[1];
            this.position += this.velocity * 1f;
          }
          if (this.type != 7 || Main.myPlayer != this.owner)
            return;
          int type = this.type;
          if ((double) this.ai[1] >= 6.0)
            ++type;
          int number = Projectile.NewProjectile(this.position.X + this.velocity.X + (float) (this.width / 2), this.position.Y + this.velocity.Y + (float) (this.height / 2), this.velocity.X, this.velocity.Y, type, this.damage, this.knockBack, this.owner);
          Main.projectile[number].damage = this.damage;
          Main.projectile[number].ai[1] = this.ai[1] + 1f;
          NetMessage.SendData(27, number: number);
        }
        else
        {
          if (this.alpha < 170 && this.alpha + 5 >= 170)
          {
            for (int index = 0; index < 3; ++index)
              Dust.NewDust(this.position, this.width, this.height, 18, this.velocity.X * 0.025f, this.velocity.Y * 0.025f, 170, Scale: 1.2f);
            Dust.NewDust(this.position, this.width, this.height, 14, Alpha: 170, Scale: 1.1f);
          }
          this.alpha += 5;
          if (this.alpha < (int) byte.MaxValue)
            return;
          this.Kill();
        }
      }
      else if (this.aiStyle == 5)
      {
        if (this.type == 92)
        {
          if ((double) this.position.Y > (double) this.ai[1])
            this.tileCollide = true;
        }
        else
        {
          if ((double) this.ai[1] == 0.0 && !Collision.SolidCollision(this.position, this.width, this.height))
          {
            this.ai[1] = 1f;
            this.netUpdate = true;
          }
          if ((double) this.ai[1] != 0.0)
            this.tileCollide = true;
        }
        if (this.soundDelay == 0)
        {
          this.soundDelay = 20 + Main.rand.Next(40);
          Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 9);
        }
        if ((double) this.localAI[0] == 0.0)
          this.localAI[0] = 1f;
        this.alpha += (int) (25.0 * (double) this.localAI[0]);
        if (this.alpha > 200)
        {
          this.alpha = 200;
          this.localAI[0] = -1f;
        }
        if (this.alpha < 0)
        {
          this.alpha = 0;
          this.localAI[0] = 1f;
        }
        this.rotation += (float) (((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y)) * 0.00999999977648258) * (float) this.direction;
        if ((double) this.ai[1] != 1.0 && this.type != 92)
          return;
        this.light = 0.9f;
        if (Main.rand.Next(10) == 0)
          Dust.NewDust(this.position, this.width, this.height, 58, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, Scale: 1.2f);
        if (Main.rand.Next(20) != 0)
          return;
        Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.2f, this.velocity.Y * 0.2f), Main.rand.Next(16, 18));
      }
      else if (this.aiStyle == 6)
      {
        this.velocity *= 0.95f;
        ++this.ai[0];
        if ((double) this.ai[0] == 180.0)
          this.Kill();
        if ((double) this.ai[1] == 0.0)
        {
          this.ai[1] = 1f;
          for (int index = 0; index < 30; ++index)
            Dust.NewDust(this.position, this.width, this.height, 10 + this.type, this.velocity.X, this.velocity.Y, 50);
        }
        if (this.type != 10 && this.type != 11)
          return;
        int num9 = (int) ((double) this.position.X / 16.0) - 1;
        int num10 = (int) (((double) this.position.X + (double) this.width) / 16.0) + 2;
        int num11 = (int) ((double) this.position.Y / 16.0) - 1;
        int num12 = (int) (((double) this.position.Y + (double) this.height) / 16.0) + 2;
        if (num9 < 0)
          num9 = 0;
        if (num10 > Main.maxTilesX)
          num10 = Main.maxTilesX;
        if (num11 < 0)
          num11 = 0;
        if (num12 > Main.maxTilesY)
          num12 = Main.maxTilesY;
        for (int index5 = num9; index5 < num10; ++index5)
        {
          for (int index6 = num11; index6 < num12; ++index6)
          {
            Vector2 vector2;
            vector2.X = (float) (index5 * 16);
            vector2.Y = (float) (index6 * 16);
            if ((double) this.position.X + (double) this.width > (double) vector2.X && (double) this.position.X < (double) vector2.X + 16.0 && (double) this.position.Y + (double) this.height > (double) vector2.Y && (double) this.position.Y < (double) vector2.Y + 16.0 && Main.myPlayer == this.owner && Main.tile[index5, index6].active)
            {
              if (this.type == 10)
              {
                if (Main.tile[index5, index6].type == (byte) 23)
                {
                  Main.tile[index5, index6].type = (byte) 2;
                  WorldGen.SquareTileFrame(index5, index6);
                  if (Main.netMode == 1)
                    NetMessage.SendTileSquare(-1, index5, index6, 1);
                }
                if (Main.tile[index5, index6].type == (byte) 25)
                {
                  Main.tile[index5, index6].type = (byte) 1;
                  WorldGen.SquareTileFrame(index5, index6);
                  if (Main.netMode == 1)
                    NetMessage.SendTileSquare(-1, index5, index6, 1);
                }
                if (Main.tile[index5, index6].type == (byte) 112)
                {
                  Main.tile[index5, index6].type = (byte) 53;
                  WorldGen.SquareTileFrame(index5, index6);
                  if (Main.netMode == 1)
                    NetMessage.SendTileSquare(-1, index5, index6, 1);
                }
              }
              else if (this.type == 11)
              {
                if (Main.tile[index5, index6].type == (byte) 109)
                {
                  Main.tile[index5, index6].type = (byte) 2;
                  WorldGen.SquareTileFrame(index5, index6);
                  if (Main.netMode == 1)
                    NetMessage.SendTileSquare(-1, index5, index6, 1);
                }
                if (Main.tile[index5, index6].type == (byte) 116)
                {
                  Main.tile[index5, index6].type = (byte) 53;
                  WorldGen.SquareTileFrame(index5, index6);
                  if (Main.netMode == 1)
                    NetMessage.SendTileSquare(-1, index5, index6, 1);
                }
                if (Main.tile[index5, index6].type == (byte) 117)
                {
                  Main.tile[index5, index6].type = (byte) 1;
                  WorldGen.SquareTileFrame(index5, index6);
                  if (Main.netMode == 1)
                    NetMessage.SendTileSquare(-1, index5, index6, 1);
                }
              }
            }
          }
        }
      }
      else if (this.aiStyle == 7)
      {
        if (Main.player[this.owner].dead)
        {
          this.Kill();
        }
        else
        {
          Vector2 vector2_1 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num13 = Main.player[this.owner].position.X + (float) (Main.player[this.owner].width / 2) - vector2_1.X;
          float num14 = Main.player[this.owner].position.Y + (float) (Main.player[this.owner].height / 2) - vector2_1.Y;
          float num15 = (float) Math.Sqrt((double) num13 * (double) num13 + (double) num14 * (double) num14);
          this.rotation = (float) Math.Atan2((double) num14, (double) num13) - 1.57f;
          if ((double) this.ai[0] == 0.0)
          {
            if ((double) num15 > 300.0 && this.type == 13 || (double) num15 > 400.0 && this.type == 32 || (double) num15 > 440.0 && this.type == 73 || (double) num15 > 440.0 && this.type == 74)
              this.ai[0] = 1f;
            int num16 = (int) ((double) this.position.X / 16.0) - 1;
            int num17 = (int) (((double) this.position.X + (double) this.width) / 16.0) + 2;
            int num18 = (int) ((double) this.position.Y / 16.0) - 1;
            int num19 = (int) (((double) this.position.Y + (double) this.height) / 16.0) + 2;
            if (num16 < 0)
              num16 = 0;
            if (num17 > Main.maxTilesX)
              num17 = Main.maxTilesX;
            if (num18 < 0)
              num18 = 0;
            if (num19 > Main.maxTilesY)
              num19 = Main.maxTilesY;
            for (int i = num16; i < num17; ++i)
            {
              for (int j = num18; j < num19; ++j)
              {
                if (Main.tile[i, j] == null)
                  Main.tile[i, j] = new Tile();
                Vector2 vector2_2;
                vector2_2.X = (float) (i * 16);
                vector2_2.Y = (float) (j * 16);
                if ((double) this.position.X + (double) this.width > (double) vector2_2.X && (double) this.position.X < (double) vector2_2.X + 16.0 && (double) this.position.Y + (double) this.height > (double) vector2_2.Y && (double) this.position.Y < (double) vector2_2.Y + 16.0 && Main.tile[i, j].active && Main.tileSolid[(int) Main.tile[i, j].type])
                {
                  if (Main.player[this.owner].grapCount < 10)
                  {
                    Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
                    ++Main.player[this.owner].grapCount;
                  }
                  if (Main.myPlayer == this.owner)
                  {
                    int num20 = 0;
                    int index7 = -1;
                    int num21 = 100000;
                    if (this.type == 73 || this.type == 74)
                    {
                      for (int index8 = 0; index8 < 1000; ++index8)
                      {
                        if (index8 != this.whoAmI && Main.projectile[index8].active && Main.projectile[index8].owner == this.owner && Main.projectile[index8].aiStyle == 7 && (double) Main.projectile[index8].ai[0] == 2.0)
                          Main.projectile[index8].Kill();
                      }
                    }
                    else
                    {
                      for (int index9 = 0; index9 < 1000; ++index9)
                      {
                        if (Main.projectile[index9].active && Main.projectile[index9].owner == this.owner && Main.projectile[index9].aiStyle == 7)
                        {
                          if (Main.projectile[index9].timeLeft < num21)
                          {
                            index7 = index9;
                            num21 = Main.projectile[index9].timeLeft;
                          }
                          ++num20;
                        }
                      }
                      if (num20 > 3)
                        Main.projectile[index7].Kill();
                    }
                  }
                  WorldGen.KillTile(i, j, true, true);
                  Main.PlaySound(0, i * 16, j * 16);
                  this.velocity.X = 0.0f;
                  this.velocity.Y = 0.0f;
                  this.ai[0] = 2f;
                  this.position.X = (float) (i * 16 + 8 - this.width / 2);
                  this.position.Y = (float) (j * 16 + 8 - this.height / 2);
                  this.damage = 0;
                  this.netUpdate = true;
                  if (Main.myPlayer == this.owner)
                  {
                    NetMessage.SendData(13, number: this.owner);
                    break;
                  }
                  break;
                }
              }
              if ((double) this.ai[0] == 2.0)
                break;
            }
          }
          else if ((double) this.ai[0] == 1.0)
          {
            float num22 = 11f;
            if (this.type == 32)
              num22 = 15f;
            if (this.type == 73 || this.type == 74)
              num22 = 17f;
            if ((double) num15 < 24.0)
              this.Kill();
            float num23 = num22 / num15;
            float num24 = num13 * num23;
            float num25 = num14 * num23;
            this.velocity.X = num24;
            this.velocity.Y = num25;
          }
          else
          {
            if ((double) this.ai[0] != 2.0)
              return;
            int num26 = (int) ((double) this.position.X / 16.0) - 1;
            int num27 = (int) (((double) this.position.X + (double) this.width) / 16.0) + 2;
            int num28 = (int) ((double) this.position.Y / 16.0) - 1;
            int num29 = (int) (((double) this.position.Y + (double) this.height) / 16.0) + 2;
            if (num26 < 0)
              num26 = 0;
            if (num27 > Main.maxTilesX)
              num27 = Main.maxTilesX;
            if (num28 < 0)
              num28 = 0;
            if (num29 > Main.maxTilesY)
              num29 = Main.maxTilesY;
            bool flag = true;
            for (int index10 = num26; index10 < num27; ++index10)
            {
              for (int index11 = num28; index11 < num29; ++index11)
              {
                if (Main.tile[index10, index11] == null)
                  Main.tile[index10, index11] = new Tile();
                Vector2 vector2_3;
                vector2_3.X = (float) (index10 * 16);
                vector2_3.Y = (float) (index11 * 16);
                if ((double) this.position.X + (double) (this.width / 2) > (double) vector2_3.X && (double) this.position.X + (double) (this.width / 2) < (double) vector2_3.X + 16.0 && (double) this.position.Y + (double) (this.height / 2) > (double) vector2_3.Y && (double) this.position.Y + (double) (this.height / 2) < (double) vector2_3.Y + 16.0 && Main.tile[index10, index11].active && Main.tileSolid[(int) Main.tile[index10, index11].type])
                  flag = false;
              }
            }
            if (flag)
            {
              this.ai[0] = 1f;
            }
            else
            {
              if (Main.player[this.owner].grapCount >= 10)
                return;
              Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
              ++Main.player[this.owner].grapCount;
            }
          }
        }
      }
      else if (this.aiStyle == 8)
      {
        if (this.type == 96 && (double) this.localAI[0] == 0.0)
        {
          this.localAI[0] = 1f;
          Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 20);
        }
        if (this.type == 27)
        {
          int index = Dust.NewDust(new Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y), this.width, this.height, 29, this.velocity.X, this.velocity.Y, 100, Scale: 3f);
          Main.dust[index].noGravity = true;
          if (Main.rand.Next(10) == 0)
            Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 29, this.velocity.X, this.velocity.Y, 100, Scale: 1.4f);
        }
        else if (this.type == 95 || this.type == 96)
        {
          int index = Dust.NewDust(new Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y), this.width, this.height, 75, this.velocity.X, this.velocity.Y, 100, Scale: (3f * this.scale));
          Main.dust[index].noGravity = true;
        }
        else
        {
          for (int index12 = 0; index12 < 2; ++index12)
          {
            int index13 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, Scale: 2f);
            Main.dust[index13].noGravity = true;
            Main.dust[index13].velocity.X *= 0.3f;
            Main.dust[index13].velocity.Y *= 0.3f;
          }
        }
        if (this.type != 27 && this.type != 96)
          ++this.ai[1];
        if ((double) this.ai[1] >= 20.0)
          this.velocity.Y += 0.2f;
        this.rotation += 0.3f * (float) this.direction;
        if ((double) this.velocity.Y <= 16.0)
          return;
        this.velocity.Y = 16f;
      }
      else if (this.aiStyle == 9)
      {
        if (this.type == 34)
        {
          int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, Scale: 3.5f);
          Main.dust[index].noGravity = true;
          Main.dust[index].velocity *= 1.4f;
          Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100, Scale: 1.5f);
        }
        else if (this.type == 79)
        {
          if (this.soundDelay == 0 && (double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) > 2.0)
          {
            this.soundDelay = 10;
            Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 9);
          }
          for (int index14 = 0; index14 < 1; ++index14)
          {
            int index15 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 66, Alpha: 100, newColor: new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), Scale: 2.5f);
            Main.dust[index15].velocity *= 0.1f;
            Main.dust[index15].velocity += this.velocity * 0.2f;
            Main.dust[index15].position.X = (float) ((double) this.position.X + (double) (this.width / 2) + 4.0) + (float) Main.rand.Next(-2, 3);
            Main.dust[index15].position.Y = this.position.Y + (float) (this.height / 2) + (float) Main.rand.Next(-2, 3);
            Main.dust[index15].noGravity = true;
          }
        }
        else
        {
          if (this.soundDelay == 0 && (double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) > 2.0)
          {
            this.soundDelay = 10;
            Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 9);
          }
          int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 15, Alpha: 100, Scale: 2f);
          Main.dust[index].velocity *= 0.3f;
          Main.dust[index].position.X = (float) ((double) this.position.X + (double) (this.width / 2) + 4.0) + (float) Main.rand.Next(-4, 5);
          Main.dust[index].position.Y = this.position.Y + (float) (this.height / 2) + (float) Main.rand.Next(-4, 5);
          Main.dust[index].noGravity = true;
        }
        if (Main.myPlayer == this.owner && (double) this.ai[0] == 0.0)
        {
          if (Main.player[this.owner].channel)
          {
            float num30 = 12f;
            if (this.type == 16)
              num30 = 15f;
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num31 = (float) Main.mouseX + Main.screenPosition.X - vector2.X;
            float num32 = (float) Main.mouseY + Main.screenPosition.Y - vector2.Y;
            float num33 = (float) Math.Sqrt((double) num31 * (double) num31 + (double) num32 * (double) num32);
            float num34 = (float) Math.Sqrt((double) num31 * (double) num31 + (double) num32 * (double) num32);
            if ((double) num34 > (double) num30)
            {
              float num35 = num30 / num34;
              float num36 = num31 * num35;
              float num37 = num32 * num35;
              int num38 = (int) ((double) num36 * 1000.0);
              int num39 = (int) ((double) this.velocity.X * 1000.0);
              int num40 = (int) ((double) num37 * 1000.0);
              int num41 = (int) ((double) this.velocity.Y * 1000.0);
              if (num38 != num39 || num40 != num41)
                this.netUpdate = true;
              this.velocity.X = num36;
              this.velocity.Y = num37;
            }
            else
            {
              int num42 = (int) ((double) num31 * 1000.0);
              int num43 = (int) ((double) this.velocity.X * 1000.0);
              int num44 = (int) ((double) num32 * 1000.0);
              int num45 = (int) ((double) this.velocity.Y * 1000.0);
              if (num42 != num43 || num44 != num45)
                this.netUpdate = true;
              this.velocity.X = num31;
              this.velocity.Y = num32;
            }
          }
          else if ((double) this.ai[0] == 0.0)
          {
            this.ai[0] = 1f;
            this.netUpdate = true;
            float num46 = 12f;
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num47 = (float) Main.mouseX + Main.screenPosition.X - vector2.X;
            float num48 = (float) Main.mouseY + Main.screenPosition.Y - vector2.Y;
            float num49 = (float) Math.Sqrt((double) num47 * (double) num47 + (double) num48 * (double) num48);
            if ((double) num49 == 0.0)
            {
              vector2 = new Vector2(Main.player[this.owner].position.X + (float) (Main.player[this.owner].width / 2), Main.player[this.owner].position.Y + (float) (Main.player[this.owner].height / 2));
              num47 = this.position.X + (float) this.width * 0.5f - vector2.X;
              num48 = this.position.Y + (float) this.height * 0.5f - vector2.Y;
              num49 = (float) Math.Sqrt((double) num47 * (double) num47 + (double) num48 * (double) num48);
            }
            float num50 = num46 / num49;
            float num51 = num47 * num50;
            float num52 = num48 * num50;
            this.velocity.X = num51;
            this.velocity.Y = num52;
            if ((double) this.velocity.X == 0.0 && (double) this.velocity.Y == 0.0)
              this.Kill();
          }
        }
        if (this.type == 34)
          this.rotation += 0.3f * (float) this.direction;
        else if ((double) this.velocity.X != 0.0 || (double) this.velocity.Y != 0.0)
          this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) - 2.355f;
        if ((double) this.velocity.Y <= 16.0)
          return;
        this.velocity.Y = 16f;
      }
      else if (this.aiStyle == 10)
      {
        if (this.type == 31 && (double) this.ai[0] != 2.0)
        {
          if (Main.rand.Next(2) == 0)
          {
            int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32, SpeedY: (this.velocity.Y / 2f));
            Main.dust[index].velocity.X *= 0.4f;
          }
        }
        else if (this.type == 39)
        {
          if (Main.rand.Next(2) == 0)
          {
            int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 38, SpeedY: (this.velocity.Y / 2f));
            Main.dust[index].velocity.X *= 0.4f;
          }
        }
        else if (this.type == 40)
        {
          if (Main.rand.Next(2) == 0)
          {
            int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 36, SpeedY: (this.velocity.Y / 2f));
            Main.dust[index].velocity *= 0.4f;
          }
        }
        else if (this.type == 42 || this.type == 31)
        {
          if (Main.rand.Next(2) == 0)
          {
            int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32);
            Main.dust[index].velocity.X *= 0.4f;
          }
        }
        else if (this.type == 56 || this.type == 65)
        {
          if (Main.rand.Next(2) == 0)
          {
            int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14);
            Main.dust[index].velocity.X *= 0.4f;
          }
        }
        else if (this.type == 67 || this.type == 68)
        {
          if (Main.rand.Next(2) == 0)
          {
            int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 51);
            Main.dust[index].velocity.X *= 0.4f;
          }
        }
        else if (this.type == 71)
        {
          if (Main.rand.Next(2) == 0)
          {
            int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 53);
            Main.dust[index].velocity.X *= 0.4f;
          }
        }
        else if (this.type != 109 && Main.rand.Next(20) == 0)
          Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0);
        if (Main.myPlayer == this.owner && (double) this.ai[0] == 0.0)
        {
          if (Main.player[this.owner].channel)
          {
            float num53 = 12f;
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num54 = (float) Main.mouseX + Main.screenPosition.X - vector2.X;
            float num55 = (float) Main.mouseY + Main.screenPosition.Y - vector2.Y;
            float num56 = (float) Math.Sqrt((double) num54 * (double) num54 + (double) num55 * (double) num55);
            float num57 = (float) Math.Sqrt((double) num54 * (double) num54 + (double) num55 * (double) num55);
            if ((double) num57 > (double) num53)
            {
              float num58 = num53 / num57;
              float num59 = num54 * num58;
              float num60 = num55 * num58;
              if ((double) num59 != (double) this.velocity.X || (double) num60 != (double) this.velocity.Y)
                this.netUpdate = true;
              this.velocity.X = num59;
              this.velocity.Y = num60;
            }
            else
            {
              if ((double) num54 != (double) this.velocity.X || (double) num55 != (double) this.velocity.Y)
                this.netUpdate = true;
              this.velocity.X = num54;
              this.velocity.Y = num55;
            }
          }
          else
          {
            this.ai[0] = 1f;
            this.netUpdate = true;
          }
        }
        if ((double) this.ai[0] == 1.0 && this.type != 109)
        {
          if (this.type == 42 || this.type == 65 || this.type == 68)
          {
            ++this.ai[1];
            if ((double) this.ai[1] >= 60.0)
            {
              this.ai[1] = 60f;
              this.velocity.Y += 0.2f;
            }
          }
          else
            this.velocity.Y += 0.41f;
        }
        else if ((double) this.ai[0] == 2.0 && this.type != 109)
        {
          this.velocity.Y += 0.2f;
          if ((double) this.velocity.X < -0.04)
            this.velocity.X += 0.04f;
          else if ((double) this.velocity.X > 0.04)
            this.velocity.X -= 0.04f;
          else
            this.velocity.X = 0.0f;
        }
        this.rotation += 0.1f;
        if ((double) this.velocity.Y <= 10.0)
          return;
        this.velocity.Y = 10f;
      }
      else if (this.aiStyle == 11)
      {
        if (this.type == 72 || this.type == 86 || this.type == 87)
        {
          if ((double) this.velocity.X > 0.0)
            this.spriteDirection = -1;
          else if ((double) this.velocity.X < 0.0)
            this.spriteDirection = 1;
          this.rotation = this.velocity.X * 0.1f;
          ++this.frameCounter;
          if (this.frameCounter >= 4)
          {
            ++this.frame;
            this.frameCounter = 0;
          }
          if (this.frame >= 4)
            this.frame = 0;
          if (Main.rand.Next(6) == 0)
          {
            int Type = 56;
            if (this.type == 86)
              Type = 73;
            else if (this.type == 87)
              Type = 74;
            int index = Dust.NewDust(this.position, this.width, this.height, Type, Alpha: 200, Scale: 0.8f);
            Main.dust[index].velocity *= 0.3f;
          }
        }
        else
          this.rotation += 0.02f;
        if (Main.myPlayer == this.owner)
        {
          if (this.type == 72 || this.type == 86 || this.type == 87)
          {
            if (Main.player[Main.myPlayer].fairy)
              this.timeLeft = 2;
          }
          else if (Main.player[Main.myPlayer].lightOrb)
            this.timeLeft = 2;
        }
        if (!Main.player[this.owner].dead)
        {
          float num61 = 2.5f;
          if (this.type == 72 || this.type == 86 || this.type == 87)
            num61 = 3.5f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num62 = Main.player[this.owner].position.X + (float) (Main.player[this.owner].width / 2) - vector2.X;
          float num63 = Main.player[this.owner].position.Y + (float) (Main.player[this.owner].height / 2) - vector2.Y;
          float num64 = (float) Math.Sqrt((double) num62 * (double) num62 + (double) num63 * (double) num63);
          float num65 = (float) Math.Sqrt((double) num62 * (double) num62 + (double) num63 * (double) num63);
          int num66 = 70;
          if (this.type == 72 || this.type == 86 || this.type == 87)
            num66 = 40;
          if ((double) num65 > 800.0)
          {
            this.position.X = Main.player[this.owner].position.X + (float) (Main.player[this.owner].width / 2) - (float) (this.width / 2);
            this.position.Y = Main.player[this.owner].position.Y + (float) (Main.player[this.owner].height / 2) - (float) (this.height / 2);
          }
          else if ((double) num65 > (double) num66)
          {
            float num67 = num61 / num65;
            float num68 = num62 * num67;
            float num69 = num63 * num67;
            this.velocity.X = num68;
            this.velocity.Y = num69;
          }
          else
          {
            this.velocity.X = 0.0f;
            this.velocity.Y = 0.0f;
          }
        }
        else
          this.Kill();
      }
      else if (this.aiStyle == 12)
      {
        this.scale -= 0.04f;
        if ((double) this.scale <= 0.0)
          this.Kill();
        if ((double) this.ai[0] > 4.0)
        {
          this.alpha = 150;
          this.light = 0.8f;
          int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 29, this.velocity.X, this.velocity.Y, 100, Scale: 2.5f);
          Main.dust[index].noGravity = true;
          Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 29, this.velocity.X, this.velocity.Y, 100, Scale: 1.5f);
        }
        else
          ++this.ai[0];
        this.rotation += 0.3f * (float) this.direction;
      }
      else if (this.aiStyle == 13)
      {
        if (Main.player[this.owner].dead)
        {
          this.Kill();
        }
        else
        {
          Main.player[this.owner].itemAnimation = 5;
          Main.player[this.owner].itemTime = 5;
          Main.player[this.owner].direction = (double) this.position.X + (double) (this.width / 2) <= (double) Main.player[this.owner].position.X + (double) (Main.player[this.owner].width / 2) ? -1 : 1;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num70 = Main.player[this.owner].position.X + (float) (Main.player[this.owner].width / 2) - vector2.X;
          float num71 = Main.player[this.owner].position.Y + (float) (Main.player[this.owner].height / 2) - vector2.Y;
          float num72 = (float) Math.Sqrt((double) num70 * (double) num70 + (double) num71 * (double) num71);
          if ((double) this.ai[0] == 0.0)
          {
            if ((double) num72 > 700.0)
              this.ai[0] = 1f;
            this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 1.57f;
            ++this.ai[1];
            if ((double) this.ai[1] > 2.0)
              this.alpha = 0;
            if ((double) this.ai[1] < 10.0)
              return;
            this.ai[1] = 15f;
            this.velocity.Y += 0.3f;
          }
          else
          {
            if ((double) this.ai[0] != 1.0)
              return;
            this.tileCollide = false;
            this.rotation = (float) Math.Atan2((double) num71, (double) num70) - 1.57f;
            float num73 = 20f;
            if ((double) num72 < 50.0)
              this.Kill();
            float num74 = num73 / num72;
            float num75 = num70 * num74;
            float num76 = num71 * num74;
            this.velocity.X = num75;
            this.velocity.Y = num76;
          }
        }
      }
      else if (this.aiStyle == 14)
      {
        if (this.type == 53)
        {
          try
          {
            int num77 = this.velocity != Collision.TileCollision(this.position, this.velocity, this.width, this.height) ? 1 : 0;
            int num78 = (int) ((double) this.position.X / 16.0) - 1;
            int num79 = (int) (((double) this.position.X + (double) this.width) / 16.0) + 2;
            int num80 = (int) ((double) this.position.Y / 16.0) - 1;
            int num81 = (int) (((double) this.position.Y + (double) this.height) / 16.0) + 2;
            if (num78 < 0)
              num78 = 0;
            if (num79 > Main.maxTilesX)
              num79 = Main.maxTilesX;
            if (num80 < 0)
              num80 = 0;
            if (num81 > Main.maxTilesY)
              num81 = Main.maxTilesY;
            for (int index16 = num78; index16 < num79; ++index16)
            {
              for (int index17 = num80; index17 < num81; ++index17)
              {
                if (Main.tile[index16, index17] != null && Main.tile[index16, index17].active && (Main.tileSolid[(int) Main.tile[index16, index17].type] || Main.tileSolidTop[(int) Main.tile[index16, index17].type] && Main.tile[index16, index17].frameY == (short) 0))
                {
                  Vector2 vector2;
                  vector2.X = (float) (index16 * 16);
                  vector2.Y = (float) (index17 * 16);
                  if ((double) this.position.X + (double) this.width > (double) vector2.X && (double) this.position.X < (double) vector2.X + 16.0 && (double) this.position.Y + (double) this.height > (double) vector2.Y && (double) this.position.Y < (double) vector2.Y + 16.0)
                  {
                    this.velocity.X = 0.0f;
                    this.velocity.Y = -0.2f;
                  }
                }
              }
            }
          }
          catch
          {
          }
        }
        ++this.ai[0];
        if ((double) this.ai[0] > 5.0)
        {
          this.ai[0] = 5f;
          if ((double) this.velocity.Y == 0.0 && (double) this.velocity.X != 0.0)
          {
            this.velocity.X *= 0.97f;
            if ((double) this.velocity.X > -0.01 && (double) this.velocity.X < 0.01)
            {
              this.velocity.X = 0.0f;
              this.netUpdate = true;
            }
          }
          this.velocity.Y += 0.2f;
        }
        this.rotation += this.velocity.X * 0.1f;
        if ((double) this.velocity.Y <= 16.0)
          return;
        this.velocity.Y = 16f;
      }
      else if (this.aiStyle == 15)
      {
        if (this.type == 25)
        {
          if (Main.rand.Next(15) == 0)
            Dust.NewDust(this.position, this.width, this.height, 14, Alpha: 150, Scale: 1.3f);
        }
        else if (this.type == 26)
        {
          int index = Dust.NewDust(this.position, this.width, this.height, 29, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 100, Scale: 2.5f);
          Main.dust[index].noGravity = true;
          Main.dust[index].velocity.X /= 2f;
          Main.dust[index].velocity.Y /= 2f;
        }
        else if (this.type == 35)
        {
          int index = Dust.NewDust(this.position, this.width, this.height, 6, this.velocity.X * 0.4f, this.velocity.Y * 0.4f, 100, Scale: 3f);
          Main.dust[index].noGravity = true;
          Main.dust[index].velocity.X *= 2f;
          Main.dust[index].velocity.Y *= 2f;
        }
        if (Main.player[this.owner].dead)
        {
          this.Kill();
        }
        else
        {
          Main.player[this.owner].itemAnimation = 10;
          Main.player[this.owner].itemTime = 10;
          if ((double) this.position.X + (double) (this.width / 2) > (double) Main.player[this.owner].position.X + (double) (Main.player[this.owner].width / 2))
          {
            Main.player[this.owner].direction = 1;
            this.direction = 1;
          }
          else
          {
            Main.player[this.owner].direction = -1;
            this.direction = -1;
          }
          Vector2 vector2_4 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num82 = Main.player[this.owner].position.X + (float) (Main.player[this.owner].width / 2) - vector2_4.X;
          float num83 = Main.player[this.owner].position.Y + (float) (Main.player[this.owner].height / 2) - vector2_4.Y;
          float num84 = (float) Math.Sqrt((double) num82 * (double) num82 + (double) num83 * (double) num83);
          if ((double) this.ai[0] == 0.0)
          {
            float num85 = 160f;
            if (this.type == 63)
              num85 *= 1.5f;
            this.tileCollide = true;
            if ((double) num84 > (double) num85)
            {
              this.ai[0] = 1f;
              this.netUpdate = true;
            }
            else if (!Main.player[this.owner].channel)
            {
              if ((double) this.velocity.Y < 0.0)
                this.velocity.Y *= 0.9f;
              ++this.velocity.Y;
              this.velocity.X *= 0.9f;
            }
          }
          else if ((double) this.ai[0] == 1.0)
          {
            float num86 = 14f / Main.player[this.owner].meleeSpeed;
            float num87 = 0.9f / Main.player[this.owner].meleeSpeed;
            float num88 = 300f;
            if (this.type == 63)
            {
              num88 *= 1.5f;
              num86 *= 1.5f;
              num87 *= 1.5f;
            }
            double num89 = (double) Math.Abs(num82);
            double num90 = (double) Math.Abs(num83);
            if ((double) this.ai[1] == 1.0)
              this.tileCollide = false;
            if (!Main.player[this.owner].channel || (double) num84 > (double) num88 || !this.tileCollide)
            {
              this.ai[1] = 1f;
              if (this.tileCollide)
                this.netUpdate = true;
              this.tileCollide = false;
              if ((double) num84 < 20.0)
                this.Kill();
            }
            if (!this.tileCollide)
              num87 *= 2f;
            if ((double) num84 > 60.0 || !this.tileCollide)
            {
              float num91 = num86 / num84;
              num82 *= num91;
              num83 *= num91;
              Vector2 vector2_5 = new Vector2(this.velocity.X, this.velocity.Y);
              float num92 = num82 - this.velocity.X;
              float num93 = num83 - this.velocity.Y;
              float num94 = (float) Math.Sqrt((double) num92 * (double) num92 + (double) num93 * (double) num93);
              float num95 = num87 / num94;
              float num96 = num92 * num95;
              float num97 = num93 * num95;
              this.velocity.X *= 0.98f;
              this.velocity.Y *= 0.98f;
              this.velocity.X += num96;
              this.velocity.Y += num97;
            }
            else
            {
              if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) < 6.0)
              {
                this.velocity.X *= 0.96f;
                this.velocity.Y += 0.2f;
              }
              if ((double) Main.player[this.owner].velocity.X == 0.0)
                this.velocity.X *= 0.96f;
            }
          }
          this.rotation = (float) Math.Atan2((double) num83, (double) num82) - this.velocity.X * 0.1f;
        }
      }
      else if (this.aiStyle == 16)
      {
        if (this.type == 108)
        {
          ++this.ai[0];
          if ((double) this.ai[0] > 3.0)
            this.Kill();
        }
        if (this.type == 37)
        {
          try
          {
            int num98 = (int) ((double) this.position.X / 16.0) - 1;
            int num99 = (int) (((double) this.position.X + (double) this.width) / 16.0) + 2;
            int num100 = (int) ((double) this.position.Y / 16.0) - 1;
            int num101 = (int) (((double) this.position.Y + (double) this.height) / 16.0) + 2;
            if (num98 < 0)
              num98 = 0;
            if (num99 > Main.maxTilesX)
              num99 = Main.maxTilesX;
            if (num100 < 0)
              num100 = 0;
            if (num101 > Main.maxTilesY)
              num101 = Main.maxTilesY;
            for (int index18 = num98; index18 < num99; ++index18)
            {
              for (int index19 = num100; index19 < num101; ++index19)
              {
                if (Main.tile[index18, index19] != null && Main.tile[index18, index19].active && (Main.tileSolid[(int) Main.tile[index18, index19].type] || Main.tileSolidTop[(int) Main.tile[index18, index19].type] && Main.tile[index18, index19].frameY == (short) 0))
                {
                  Vector2 vector2;
                  vector2.X = (float) (index18 * 16);
                  vector2.Y = (float) (index19 * 16);
                  if ((double) this.position.X + (double) this.width - 4.0 > (double) vector2.X && (double) this.position.X + 4.0 < (double) vector2.X + 16.0 && (double) this.position.Y + (double) this.height - 4.0 > (double) vector2.Y && (double) this.position.Y + 4.0 < (double) vector2.Y + 16.0)
                  {
                    this.velocity.X = 0.0f;
                    this.velocity.Y = -0.2f;
                  }
                }
              }
            }
          }
          catch
          {
          }
        }
        if (this.type == 102)
        {
          if ((double) this.velocity.Y > 10.0)
            this.velocity.Y = 10f;
          if ((double) this.localAI[0] == 0.0)
          {
            this.localAI[0] = 1f;
            Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
          }
          ++this.frameCounter;
          if (this.frameCounter > 3)
          {
            ++this.frame;
            this.frameCounter = 0;
          }
          if (this.frame > 1)
            this.frame = 0;
          if ((double) this.velocity.Y == 0.0)
          {
            this.position.X += (float) (this.width / 2);
            this.position.Y += (float) (this.height / 2);
            this.width = 128;
            this.height = 128;
            this.position.X -= (float) (this.width / 2);
            this.position.Y -= (float) (this.height / 2);
            this.damage = 40;
            this.knockBack = 8f;
            this.timeLeft = 3;
            this.netUpdate = true;
          }
        }
        if (this.owner == Main.myPlayer && this.timeLeft <= 3)
        {
          this.ai[1] = 0.0f;
          this.alpha = (int) byte.MaxValue;
          if (this.type == 28 || this.type == 37 || this.type == 75)
          {
            this.position.X += (float) (this.width / 2);
            this.position.Y += (float) (this.height / 2);
            this.width = 128;
            this.height = 128;
            this.position.X -= (float) (this.width / 2);
            this.position.Y -= (float) (this.height / 2);
            this.damage = 100;
            this.knockBack = 8f;
          }
          else if (this.type == 29)
          {
            this.position.X += (float) (this.width / 2);
            this.position.Y += (float) (this.height / 2);
            this.width = 250;
            this.height = 250;
            this.position.X -= (float) (this.width / 2);
            this.position.Y -= (float) (this.height / 2);
            this.damage = 250;
            this.knockBack = 10f;
          }
          else if (this.type == 30)
          {
            this.position.X += (float) (this.width / 2);
            this.position.Y += (float) (this.height / 2);
            this.width = 128;
            this.height = 128;
            this.position.X -= (float) (this.width / 2);
            this.position.Y -= (float) (this.height / 2);
            this.knockBack = 8f;
          }
        }
        else
        {
          if (this.type != 30 && this.type != 108)
            this.damage = 0;
          if (this.type != 30 && Main.rand.Next(4) == 0)
            Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100);
        }
        ++this.ai[0];
        if (this.type == 30 && (double) this.ai[0] > 10.0 || this.type != 30 && (double) this.ai[0] > 5.0)
        {
          this.ai[0] = 10f;
          if ((double) this.velocity.Y == 0.0 && (double) this.velocity.X != 0.0)
          {
            this.velocity.X *= 0.97f;
            if (this.type == 29)
              this.velocity.X *= 0.99f;
            if ((double) this.velocity.X > -0.01 && (double) this.velocity.X < 0.01)
            {
              this.velocity.X = 0.0f;
              this.netUpdate = true;
            }
          }
          this.velocity.Y += 0.2f;
        }
        this.rotation += this.velocity.X * 0.1f;
      }
      else if (this.aiStyle == 17)
      {
        if ((double) this.velocity.Y == 0.0)
          this.velocity.X *= 0.98f;
        this.rotation += this.velocity.X * 0.1f;
        this.velocity.Y += 0.2f;
        if (this.owner != Main.myPlayer)
          return;
        int i1 = (int) (((double) this.position.X + (double) (this.width / 2)) / 16.0);
        int j = (int) (((double) this.position.Y + (double) this.height - 4.0) / 16.0);
        if (Main.tile[i1, j] == null || Main.tile[i1, j].active)
          return;
        WorldGen.PlaceTile(i1, j, 85);
        if (!Main.tile[i1, j].active)
          return;
        if (Main.netMode != 0)
          NetMessage.SendData(17, number: 1, number2: ((float) i1), number3: ((float) j), number4: 85f);
        int i2 = Sign.ReadSign(i1, j);
        if (i2 >= 0)
          Sign.TextSign(i2, this.miscText);
        this.Kill();
      }
      else if (this.aiStyle == 18)
      {
        if ((double) this.ai[1] == 0.0 && this.type == 44)
        {
          this.ai[1] = 1f;
          Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 8);
        }
        this.rotation += (float) this.direction * 0.8f;
        ++this.ai[0];
        if ((double) this.ai[0] >= 30.0)
        {
          if ((double) this.ai[0] < 100.0)
            this.velocity *= 1.06f;
          else
            this.ai[0] = 200f;
        }
        for (int index20 = 0; index20 < 2; ++index20)
        {
          int index21 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, Alpha: 100);
          Main.dust[index21].noGravity = true;
        }
      }
      else if (this.aiStyle == 19)
      {
        this.direction = Main.player[this.owner].direction;
        Main.player[this.owner].heldProj = this.whoAmI;
        Main.player[this.owner].itemTime = Main.player[this.owner].itemAnimation;
        this.position.X = Main.player[this.owner].position.X + (float) (Main.player[this.owner].width / 2) - (float) (this.width / 2);
        this.position.Y = Main.player[this.owner].position.Y + (float) (Main.player[this.owner].height / 2) - (float) (this.height / 2);
        if (this.type == 46)
        {
          if ((double) this.ai[0] == 0.0)
          {
            this.ai[0] = 3f;
            this.netUpdate = true;
          }
          if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
            this.ai[0] -= 1.6f;
          else
            this.ai[0] += 1.4f;
        }
        else if (this.type == 105)
        {
          if ((double) this.ai[0] == 0.0)
          {
            this.ai[0] = 3f;
            this.netUpdate = true;
          }
          if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
            this.ai[0] -= 2.4f;
          else
            this.ai[0] += 2.1f;
        }
        else if (this.type == 47)
        {
          if ((double) this.ai[0] == 0.0)
          {
            this.ai[0] = 4f;
            this.netUpdate = true;
          }
          if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
            this.ai[0] -= 1.2f;
          else
            this.ai[0] += 0.9f;
        }
        else if (this.type == 49)
        {
          if ((double) this.ai[0] == 0.0)
          {
            this.ai[0] = 4f;
            this.netUpdate = true;
          }
          if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
            this.ai[0] -= 1.1f;
          else
            this.ai[0] += 0.85f;
        }
        else if (this.type == 64)
        {
          this.spriteDirection = -this.direction;
          if ((double) this.ai[0] == 0.0)
          {
            this.ai[0] = 3f;
            this.netUpdate = true;
          }
          if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
            this.ai[0] -= 1.9f;
          else
            this.ai[0] += 1.7f;
        }
        else if (this.type == 66 || this.type == 97)
        {
          this.spriteDirection = -this.direction;
          if ((double) this.ai[0] == 0.0)
          {
            this.ai[0] = 3f;
            this.netUpdate = true;
          }
          if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
            this.ai[0] -= 2.1f;
          else
            this.ai[0] += 1.9f;
        }
        else if (this.type == 97)
        {
          this.spriteDirection = -this.direction;
          if ((double) this.ai[0] == 0.0)
          {
            this.ai[0] = 3f;
            this.netUpdate = true;
          }
          if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
            this.ai[0] -= 1.6f;
          else
            this.ai[0] += 1.4f;
        }
        this.position += this.velocity * this.ai[0];
        if (Main.player[this.owner].itemAnimation == 0)
          this.Kill();
        this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 2.355f;
        if (this.spriteDirection == -1)
          this.rotation -= 1.57f;
        if (this.type == 46)
        {
          if (Main.rand.Next(5) == 0)
            Dust.NewDust(this.position, this.width, this.height, 14, Alpha: 150, Scale: 1.4f);
          int index22 = Dust.NewDust(this.position, this.width, this.height, 27, this.velocity.X * 0.2f + (float) (this.direction * 3), this.velocity.Y * 0.2f, 100, Scale: 1.2f);
          Main.dust[index22].noGravity = true;
          Main.dust[index22].velocity.X /= 2f;
          Main.dust[index22].velocity.Y /= 2f;
          int index23 = Dust.NewDust(this.position - this.velocity * 2f, this.width, this.height, 27, Alpha: 150, Scale: 1.4f);
          Main.dust[index23].velocity.X /= 5f;
          Main.dust[index23].velocity.Y /= 5f;
        }
        else
        {
          if (this.type != 105)
            return;
          if (Main.rand.Next(3) == 0)
          {
            int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 57, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 200, Scale: 1.2f);
            Main.dust[index].velocity += this.velocity * 0.3f;
            Main.dust[index].velocity *= 0.2f;
          }
          if (Main.rand.Next(4) != 0)
            return;
          int index24 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 43, Alpha: 254, Scale: 0.3f);
          Main.dust[index24].velocity += this.velocity * 0.5f;
          Main.dust[index24].velocity *= 0.5f;
        }
      }
      else if (this.aiStyle == 20)
      {
        if (this.soundDelay <= 0)
        {
          Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 22);
          this.soundDelay = 30;
        }
        if (Main.myPlayer == this.owner)
        {
          if (Main.player[this.owner].channel)
          {
            float num102 = Main.player[this.owner].inventory[Main.player[this.owner].selectedItem].shootSpeed * this.scale;
            Vector2 vector2 = new Vector2(Main.player[this.owner].position.X + (float) Main.player[this.owner].width * 0.5f, Main.player[this.owner].position.Y + (float) Main.player[this.owner].height * 0.5f);
            float num103 = (float) Main.mouseX + Main.screenPosition.X - vector2.X;
            float num104 = (float) Main.mouseY + Main.screenPosition.Y - vector2.Y;
            float num105 = (float) Math.Sqrt((double) num103 * (double) num103 + (double) num104 * (double) num104);
            float num106 = (float) Math.Sqrt((double) num103 * (double) num103 + (double) num104 * (double) num104);
            float num107 = num102 / num106;
            float num108 = num103 * num107;
            float num109 = num104 * num107;
            if ((double) num108 != (double) this.velocity.X || (double) num109 != (double) this.velocity.Y)
              this.netUpdate = true;
            this.velocity.X = num108;
            this.velocity.Y = num109;
          }
          else
            this.Kill();
        }
        if ((double) this.velocity.X > 0.0)
          Main.player[this.owner].direction = 1;
        else if ((double) this.velocity.X < 0.0)
          Main.player[this.owner].direction = -1;
        this.spriteDirection = this.direction;
        Main.player[this.owner].direction = this.direction;
        Main.player[this.owner].heldProj = this.whoAmI;
        Main.player[this.owner].itemTime = 2;
        Main.player[this.owner].itemAnimation = 2;
        this.position.X = Main.player[this.owner].position.X + (float) (Main.player[this.owner].width / 2) - (float) (this.width / 2);
        this.position.Y = Main.player[this.owner].position.Y + (float) (Main.player[this.owner].height / 2) - (float) (this.height / 2);
        this.rotation = (float) (Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 1.57000005245209);
        Main.player[this.owner].itemRotation = Main.player[this.owner].direction != 1 ? (float) Math.Atan2((double) this.velocity.Y * (double) this.direction, (double) this.velocity.X * (double) this.direction) : (float) Math.Atan2((double) this.velocity.Y * (double) this.direction, (double) this.velocity.X * (double) this.direction);
        this.velocity.X *= (float) (1.0 + (double) Main.rand.Next(-3, 4) * 0.00999999977648258);
        if (Main.rand.Next(6) != 0)
          return;
        int index = Dust.NewDust(this.position + this.velocity * (float) Main.rand.Next(6, 10) * 0.1f, this.width, this.height, 31, Alpha: 80, Scale: 1.4f);
        Main.dust[index].position.X -= 4f;
        Main.dust[index].noGravity = true;
        Main.dust[index].velocity *= 0.2f;
        Main.dust[index].velocity.Y = (float) -Main.rand.Next(7, 13) * 0.15f;
      }
      else if (this.aiStyle == 21)
      {
        this.rotation = this.velocity.X * 0.1f;
        this.spriteDirection = -this.direction;
        if (Main.rand.Next(3) == 0)
        {
          int index = Dust.NewDust(this.position, this.width, this.height, 27, Alpha: 80);
          Main.dust[index].noGravity = true;
          Main.dust[index].velocity *= 0.2f;
        }
        if ((double) this.ai[1] != 1.0)
          return;
        this.ai[1] = 0.0f;
        Main.harpNote = this.ai[0];
        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 26);
      }
      else if (this.aiStyle == 22)
      {
        if ((double) this.velocity.X == 0.0 && (double) this.velocity.Y == 0.0)
          this.alpha = (int) byte.MaxValue;
        if ((double) this.ai[1] < 0.0)
        {
          if ((double) this.velocity.X > 0.0)
            this.rotation += 0.3f;
          else
            this.rotation -= 0.3f;
          int num110 = (int) ((double) this.position.X / 16.0) - 1;
          int num111 = (int) (((double) this.position.X + (double) this.width) / 16.0) + 2;
          int num112 = (int) ((double) this.position.Y / 16.0) - 1;
          int num113 = (int) (((double) this.position.Y + (double) this.height) / 16.0) + 2;
          if (num110 < 0)
            num110 = 0;
          if (num111 > Main.maxTilesX)
            num111 = Main.maxTilesX;
          if (num112 < 0)
            num112 = 0;
          if (num113 > Main.maxTilesY)
            num113 = Main.maxTilesY;
          int num114 = (int) this.position.X + 4;
          int num115 = (int) this.position.Y + 4;
          for (int index25 = num110; index25 < num111; ++index25)
          {
            for (int index26 = num112; index26 < num113; ++index26)
            {
              if (Main.tile[index25, index26] != null && Main.tile[index25, index26].active && Main.tile[index25, index26].type != (byte) 127 && Main.tileSolid[(int) Main.tile[index25, index26].type] && !Main.tileSolidTop[(int) Main.tile[index25, index26].type])
              {
                Vector2 vector2;
                vector2.X = (float) (index25 * 16);
                vector2.Y = (float) (index26 * 16);
                if ((double) (num114 + 8) > (double) vector2.X && (double) num114 < (double) vector2.X + 16.0 && (double) (num115 + 8) > (double) vector2.Y && (double) num115 < (double) vector2.Y + 16.0)
                  this.Kill();
              }
            }
          }
          int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67);
          Main.dust[index].noGravity = true;
          Main.dust[index].velocity *= 0.3f;
        }
        else if ((double) this.ai[0] < 0.0)
        {
          if ((double) this.ai[0] == -1.0)
          {
            for (int index27 = 0; index27 < 10; ++index27)
            {
              int index28 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, Scale: 1.1f);
              Main.dust[index28].noGravity = true;
              Main.dust[index28].velocity *= 1.3f;
            }
          }
          else if (Main.rand.Next(30) == 0)
          {
            int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67, Alpha: 100);
            Main.dust[index].velocity *= 0.2f;
          }
          int i = (int) this.position.X / 16;
          int j = (int) this.position.Y / 16;
          if (Main.tile[i, j] == null || !Main.tile[i, j].active)
            this.Kill();
          --this.ai[0];
          if ((double) this.ai[0] > -300.0 || Main.myPlayer != this.owner && Main.netMode != 2 || !Main.tile[i, j].active || Main.tile[i, j].type != (byte) 127)
            return;
          WorldGen.KillTile(i, j);
          if (Main.netMode == 1)
            NetMessage.SendData(17, number2: ((float) i), number3: ((float) j));
          this.Kill();
        }
        else
        {
          int num116 = (int) ((double) this.position.X / 16.0) - 1;
          int num117 = (int) (((double) this.position.X + (double) this.width) / 16.0) + 2;
          int num118 = (int) ((double) this.position.Y / 16.0) - 1;
          int num119 = (int) (((double) this.position.Y + (double) this.height) / 16.0) + 2;
          if (num116 < 0)
            num116 = 0;
          if (num117 > Main.maxTilesX)
            num117 = Main.maxTilesX;
          if (num118 < 0)
            num118 = 0;
          if (num119 > Main.maxTilesY)
            num119 = Main.maxTilesY;
          int num120 = (int) this.position.X + 4;
          int num121 = (int) this.position.Y + 4;
          for (int index29 = num116; index29 < num117; ++index29)
          {
            for (int index30 = num118; index30 < num119; ++index30)
            {
              if (Main.tile[index29, index30] != null && Main.tile[index29, index30].active && Main.tile[index29, index30].type != (byte) 127 && Main.tileSolid[(int) Main.tile[index29, index30].type] && !Main.tileSolidTop[(int) Main.tile[index29, index30].type])
              {
                Vector2 vector2;
                vector2.X = (float) (index29 * 16);
                vector2.Y = (float) (index30 * 16);
                if ((double) (num120 + 8) > (double) vector2.X && (double) num120 < (double) vector2.X + 16.0 && (double) (num121 + 8) > (double) vector2.Y && (double) num121 < (double) vector2.Y + 16.0)
                  this.Kill();
              }
            }
          }
          if (this.lavaWet)
            this.Kill();
          if (!this.active)
            return;
          int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67);
          Main.dust[index].noGravity = true;
          Main.dust[index].velocity *= 0.3f;
          int i = (int) this.ai[0];
          int j = (int) this.ai[1];
          if ((double) this.velocity.X > 0.0)
            this.rotation += 0.3f;
          else
            this.rotation -= 0.3f;
          if (Main.myPlayer != this.owner)
            return;
          int num122 = (int) (((double) this.position.X + (double) (this.width / 2)) / 16.0);
          int num123 = (int) (((double) this.position.Y + (double) (this.height / 2)) / 16.0);
          bool flag = false;
          if (num122 == i && num123 == j)
            flag = true;
          if (((double) this.velocity.X <= 0.0 && num122 <= i || (double) this.velocity.X >= 0.0 && num122 >= i) && ((double) this.velocity.Y <= 0.0 && num123 <= j || (double) this.velocity.Y >= 0.0 && num123 >= j))
            flag = true;
          if (!flag)
            return;
          if (WorldGen.PlaceTile(i, j, (int) sbyte.MaxValue, plr: this.owner))
          {
            if (Main.netMode == 1)
              NetMessage.SendData(17, number: 1, number2: ((float) (int) this.ai[0]), number3: ((float) (int) this.ai[1]), number4: ((float) sbyte.MaxValue));
            this.damage = 0;
            this.ai[0] = -1f;
            this.velocity *= 0.0f;
            this.alpha = (int) byte.MaxValue;
            this.position.X = (float) (i * 16);
            this.position.Y = (float) (j * 16);
            this.netUpdate = true;
          }
          else
            this.ai[1] = -1f;
        }
      }
      else if (this.aiStyle == 23)
      {
        if (this.timeLeft > 60)
          this.timeLeft = 60;
        if ((double) this.ai[0] > 7.0)
        {
          float num = 1f;
          if ((double) this.ai[0] == 8.0)
            num = 0.25f;
          else if ((double) this.ai[0] == 9.0)
            num = 0.5f;
          else if ((double) this.ai[0] == 10.0)
            num = 0.75f;
          ++this.ai[0];
          int Type = 6;
          if (this.type == 101)
            Type = 75;
          if (Type == 6 || Main.rand.Next(2) == 0)
          {
            for (int index31 = 0; index31 < 1; ++index31)
            {
              int index32 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, Type, this.velocity.X * 0.2f, this.velocity.Y * 0.2f, 100);
              if (Main.rand.Next(3) != 0 || Type == 75 && Main.rand.Next(3) == 0)
              {
                Main.dust[index32].noGravity = true;
                Main.dust[index32].scale *= 3f;
                Main.dust[index32].velocity.X *= 2f;
                Main.dust[index32].velocity.Y *= 2f;
              }
              Main.dust[index32].scale *= 1.5f;
              Main.dust[index32].velocity.X *= 1.2f;
              Main.dust[index32].velocity.Y *= 1.2f;
              Main.dust[index32].scale *= num;
              if (Type == 75)
              {
                Main.dust[index32].velocity += this.velocity;
                if (!Main.dust[index32].noGravity)
                  Main.dust[index32].velocity *= 0.5f;
              }
            }
          }
        }
        else
          ++this.ai[0];
        this.rotation += 0.3f * (float) this.direction;
      }
      else if (this.aiStyle == 24)
      {
        this.light = this.scale * 0.5f;
        this.rotation += this.velocity.X * 0.2f;
        ++this.ai[1];
        if (this.type == 94)
        {
          if (Main.rand.Next(4) == 0)
          {
            int index = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 70);
            Main.dust[index].noGravity = true;
            Main.dust[index].velocity *= 0.5f;
            Main.dust[index].scale *= 0.9f;
          }
          this.velocity *= 0.985f;
          if ((double) this.ai[1] <= 130.0)
            return;
          this.scale -= 0.05f;
          if ((double) this.scale > 0.2)
            return;
          this.scale = 0.2f;
          this.Kill();
        }
        else
        {
          this.velocity *= 0.96f;
          if ((double) this.ai[1] <= 15.0)
            return;
          this.scale -= 0.05f;
          if ((double) this.scale > 0.2)
            return;
          this.scale = 0.2f;
          this.Kill();
        }
      }
      else if (this.aiStyle == 25)
      {
        if ((double) this.ai[0] != 0.0 && (double) this.velocity.Y <= 0.0 && (double) this.velocity.X == 0.0)
        {
          float num = 0.5f;
          int i3 = (int) (((double) this.position.X - 8.0) / 16.0);
          int j1 = (int) ((double) this.position.Y / 16.0);
          bool flag1 = false;
          bool flag2 = false;
          if (WorldGen.SolidTile(i3, j1) || WorldGen.SolidTile(i3, j1 + 1))
            flag1 = true;
          int i4 = (int) (((double) this.position.X + (double) this.width + 8.0) / 16.0);
          if (WorldGen.SolidTile(i4, j1) || WorldGen.SolidTile(i4, j1 + 1))
            flag2 = true;
          if (flag1)
            this.velocity.X = num;
          else if (flag2)
          {
            this.velocity.X = -num;
          }
          else
          {
            int i5 = (int) (((double) this.position.X - 8.0 - 16.0) / 16.0);
            int j2 = (int) ((double) this.position.Y / 16.0);
            bool flag3 = false;
            bool flag4 = false;
            if (WorldGen.SolidTile(i5, j2) || WorldGen.SolidTile(i5, j2 + 1))
              flag3 = true;
            int i6 = (int) (((double) this.position.X + (double) this.width + 8.0 + 16.0) / 16.0);
            if (WorldGen.SolidTile(i6, j2) || WorldGen.SolidTile(i6, j2 + 1))
              flag4 = true;
            if (flag3)
              this.velocity.X = num;
            else if (flag4)
            {
              this.velocity.X = -num;
            }
            else
            {
              int i7 = (int) (((double) this.position.X + 4.0) / 16.0);
              int j3 = (int) (((double) this.position.Y + (double) this.height + 8.0) / 16.0);
              if (WorldGen.SolidTile(i7, j3) || WorldGen.SolidTile(i7, j3 + 1))
                flag3 = true;
              this.velocity.X = flag3 ? -num : num;
            }
          }
        }
        this.rotation += this.velocity.X * 0.06f;
        this.ai[0] = 1f;
        if ((double) this.velocity.Y > 16.0)
          this.velocity.Y = 16f;
        if ((double) this.velocity.Y <= 6.0)
        {
          if ((double) this.velocity.X > 0.0 && (double) this.velocity.X < 7.0)
            this.velocity.X += 0.05f;
          if ((double) this.velocity.X < 0.0 && (double) this.velocity.X > -7.0)
            this.velocity.X -= 0.05f;
        }
        this.velocity.Y += 0.3f;
      }
      else
      {
        if (this.aiStyle != 26)
          return;
        bool flag5 = false;
        bool flag6 = false;
        bool flag7 = false;
        bool flag8 = false;
        int num124 = 60;
        if (Main.myPlayer == this.owner)
        {
          if (Main.player[Main.myPlayer].dead)
            Main.player[Main.myPlayer].bunny = false;
          if (Main.player[Main.myPlayer].bunny)
            this.timeLeft = 2;
        }
        if ((double) Main.player[this.owner].position.X + (double) (Main.player[this.owner].width / 2) < (double) this.position.X + (double) (this.width / 2) - (double) num124)
          flag5 = true;
        else if ((double) Main.player[this.owner].position.X + (double) (Main.player[this.owner].width / 2) > (double) this.position.X + (double) (this.width / 2) + (double) num124)
          flag6 = true;
        if (Main.player[this.owner].rocketDelay2 > 0)
          this.ai[0] = 1f;
        Vector2 vector2_6 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num125 = Main.player[this.owner].position.X + (float) (Main.player[this.owner].width / 2) - vector2_6.X;
        float num126 = Main.player[this.owner].position.Y + (float) (Main.player[this.owner].height / 2) - vector2_6.Y;
        float num127 = (float) Math.Sqrt((double) num125 * (double) num125 + (double) num126 * (double) num126);
        if ((double) num127 > 2000.0)
        {
          this.position.X = Main.player[this.owner].position.X + (float) (Main.player[this.owner].width / 2) - (float) (this.width / 2);
          this.position.Y = Main.player[this.owner].position.Y + (float) (Main.player[this.owner].height / 2) - (float) (this.height / 2);
        }
        else if ((double) num127 > 500.0 || (double) Math.Abs(num126) > 300.0)
        {
          this.ai[0] = 1f;
          if ((double) num126 > 0.0 && (double) this.velocity.Y < 0.0)
            this.velocity.Y = 0.0f;
          if ((double) num126 < 0.0 && (double) this.velocity.Y > 0.0)
            this.velocity.Y = 0.0f;
        }
        if ((double) this.ai[0] != 0.0)
        {
          this.tileCollide = false;
          Vector2 vector2_7 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num128 = Main.player[this.owner].position.X + (float) (Main.player[this.owner].width / 2) - vector2_7.X;
          float num129 = Main.player[this.owner].position.Y + (float) (Main.player[this.owner].height / 2) - vector2_7.Y;
          float num130 = (float) Math.Sqrt((double) num128 * (double) num128 + (double) num129 * (double) num129);
          float num131 = 10f;
          if ((double) num130 < 200.0 && (double) Main.player[this.owner].velocity.Y == 0.0 && (double) this.position.Y + (double) this.height <= (double) Main.player[this.owner].position.Y + (double) Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
          {
            this.ai[0] = 0.0f;
            if ((double) this.velocity.Y < -6.0)
              this.velocity.Y = -6f;
          }
          float num132;
          float num133;
          if ((double) num130 < 60.0)
          {
            num132 = this.velocity.X;
            num133 = this.velocity.Y;
          }
          else
          {
            float num134 = num131 / num130;
            num132 = num128 * num134;
            num133 = num129 * num134;
          }
          if ((double) this.velocity.X < (double) num132)
          {
            this.velocity.X += 0.2f;
            if ((double) this.velocity.X < 0.0)
              this.velocity.X += 0.3f;
          }
          if ((double) this.velocity.X > (double) num132)
          {
            this.velocity.X -= 0.2f;
            if ((double) this.velocity.X > 0.0)
              this.velocity.X -= 0.3f;
          }
          if ((double) this.velocity.Y < (double) num133)
          {
            this.velocity.Y += 0.2f;
            if ((double) this.velocity.Y < 0.0)
              this.velocity.Y += 0.3f;
          }
          if ((double) this.velocity.Y > (double) num133)
          {
            this.velocity.Y -= 0.2f;
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y -= 0.3f;
          }
          this.frame = 7;
          if ((double) this.velocity.X > 0.5)
            this.spriteDirection = -1;
          else if ((double) this.velocity.X < -0.5)
            this.spriteDirection = 1;
          this.rotation = this.spriteDirection != -1 ? (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 3.14f : (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X);
          int index = Dust.NewDust(new Vector2((float) ((double) this.position.X + (double) (this.width / 2) - 4.0), (float) ((double) this.position.Y + (double) (this.height / 2) - 4.0)) - this.velocity, 8, 8, 16, (float) (-(double) this.velocity.X * 0.5), this.velocity.Y * 0.5f, 50, Scale: 1.7f);
          Main.dust[index].velocity.X *= 0.2f;
          Main.dust[index].velocity.Y *= 0.2f;
          Main.dust[index].noGravity = true;
        }
        else
        {
          this.rotation = 0.0f;
          this.tileCollide = true;
          if (flag5)
          {
            if ((double) this.velocity.X > -3.5)
              this.velocity.X -= 0.08f;
            else
              this.velocity.X -= 0.02f;
          }
          else if (flag6)
          {
            if ((double) this.velocity.X < 3.5)
              this.velocity.X += 0.08f;
            else
              this.velocity.X += 0.02f;
          }
          else
          {
            this.velocity.X *= 0.9f;
            if ((double) this.velocity.X >= -0.08 && (double) this.velocity.X <= 0.08)
              this.velocity.X = 0.0f;
          }
          if (flag5 || flag6)
          {
            int num135 = (int) ((double) this.position.X + (double) (this.width / 2)) / 16;
            int j = (int) ((double) this.position.Y + (double) (this.width / 2)) / 16;
            if (flag5)
              --num135;
            if (flag6)
              ++num135;
            if (WorldGen.SolidTile(num135 + (int) this.velocity.X, j))
              flag8 = true;
          }
          if ((double) Main.player[this.owner].position.Y + (double) Main.player[this.owner].height > (double) this.position.Y + (double) this.height)
            flag7 = true;
          if ((double) this.velocity.Y == 0.0)
          {
            if (!flag7 && ((double) this.velocity.X < 0.0 || (double) this.velocity.X > 0.0))
            {
              int i = (int) ((double) this.position.X + (double) (this.width / 2)) / 16;
              int j = (int) ((double) this.position.Y + (double) (this.height / 2)) / 16 + 1;
              if (flag5)
                --i;
              if (flag6)
                ++i;
              if (!WorldGen.SolidTile(i, j))
                flag8 = true;
            }
            if (flag8 && WorldGen.SolidTile((int) ((double) this.position.X + (double) (this.width / 2)) / 16, (int) ((double) this.position.Y + (double) (this.height / 2)) / 16 + 1))
              this.velocity.Y = -9.1f;
          }
          if ((double) this.velocity.X > 6.5)
            this.velocity.X = 6.5f;
          if ((double) this.velocity.X < -6.5)
            this.velocity.X = -6.5f;
          if ((double) this.velocity.X > 0.07 && flag6)
            this.direction = 1;
          if ((double) this.velocity.X < -0.07 && flag5)
            this.direction = -1;
          if (this.direction == -1)
            this.spriteDirection = 1;
          if (this.direction == 1)
            this.spriteDirection = -1;
          if ((double) this.velocity.Y == 0.0)
          {
            if ((double) this.velocity.X == 0.0)
            {
              this.frame = 0;
              this.frameCounter = 0;
            }
            else if ((double) this.velocity.X < -0.8 || (double) this.velocity.X > 0.8)
            {
              this.frameCounter += (int) Math.Abs(this.velocity.X);
              ++this.frameCounter;
              if (this.frameCounter > 6)
              {
                ++this.frame;
                this.frameCounter = 0;
              }
              if (this.frame >= 7)
                this.frame = 0;
            }
            else
            {
              this.frame = 0;
              this.frameCounter = 0;
            }
          }
          else if ((double) this.velocity.Y < 0.0)
          {
            this.frameCounter = 0;
            this.frame = 4;
          }
          else if ((double) this.velocity.Y > 0.0)
          {
            this.frameCounter = 0;
            this.frame = 6;
          }
          this.velocity.Y += 0.4f;
          if ((double) this.velocity.Y <= 10.0)
            return;
          this.velocity.Y = 10f;
        }
      }
    }

    public void Kill()
    {
      if (!this.active)
        return;
      this.timeLeft = 0;
      if (this.type == 1 || this.type == 81 || this.type == 98)
      {
        Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
        for (int index = 0; index < 10; ++index)
          Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 7);
      }
      else if (this.type == 111)
      {
        int index = Gore.NewGore(new Vector2(this.position.X - (float) (this.width / 2), this.position.Y - (float) (this.height / 2)), new Vector2(0.0f, 0.0f), Main.rand.Next(11, 14), this.scale);
        Main.gore[index].velocity *= 0.1f;
      }
      else if (this.type == 93)
      {
        Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
        for (int index1 = 0; index1 < 10; ++index1)
        {
          int index2 = Dust.NewDust(this.position, this.width, this.height, 57, Alpha: 100, Scale: 0.5f);
          Main.dust[index2].velocity.X *= 2f;
          Main.dust[index2].velocity.Y *= 2f;
        }
      }
      else if (this.type == 99)
      {
        Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
        for (int index3 = 0; index3 < 30; ++index3)
        {
          int index4 = Dust.NewDust(this.position, this.width, this.height, 1);
          if (Main.rand.Next(2) == 0)
            Main.dust[index4].scale *= 1.4f;
          this.velocity *= 1.9f;
        }
      }
      else if (this.type == 91 || this.type == 92)
      {
        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
        for (int index = 0; index < 10; ++index)
          Dust.NewDust(this.position, this.width, this.height, 58, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, Scale: 1.2f);
        for (int index = 0; index < 3; ++index)
          Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18));
        if (this.type == 12 && this.damage < 500)
        {
          for (int index = 0; index < 10; ++index)
            Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, Scale: 1.2f);
          for (int index = 0; index < 3; ++index)
            Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18));
        }
        if ((this.type == 91 || this.type == 92 && (double) this.ai[0] > 0.0) && this.owner == Main.myPlayer)
        {
          float num1 = this.position.X + (float) Main.rand.Next(-400, 400);
          float num2 = this.position.Y - (float) Main.rand.Next(600, 900);
          Vector2 vector2 = new Vector2(num1, num2);
          float num3 = this.position.X + (float) (this.width / 2) - vector2.X;
          float num4 = this.position.Y + (float) (this.height / 2) - vector2.Y;
          float num5 = 22f / (float) Math.Sqrt((double) num3 * (double) num3 + (double) num4 * (double) num4);
          float SpeedX = num3 * num5;
          float SpeedY = num4 * num5;
          int Damage = this.damage;
          if (this.type == 91)
            Damage = (int) ((double) Damage * 0.5);
          int index = Projectile.NewProjectile(num1, num2, SpeedX, SpeedY, 92, Damage, this.knockBack, this.owner);
          if (this.type == 91)
          {
            Main.projectile[index].ai[1] = this.position.Y;
            Main.projectile[index].ai[0] = 1f;
          }
          else
            Main.projectile[index].ai[1] = this.position.Y;
        }
      }
      else if (this.type == 89)
      {
        Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
        for (int index5 = 0; index5 < 5; ++index5)
        {
          int index6 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 68);
          Main.dust[index6].noGravity = true;
          Main.dust[index6].velocity *= 1.5f;
          Main.dust[index6].scale *= 0.9f;
        }
        if (this.type == 89 && this.owner == Main.myPlayer)
        {
          for (int index = 0; index < 3; ++index)
          {
            float SpeedX = (float) (-(double) this.velocity.X * (double) Main.rand.Next(40, 70) * 0.00999999977648258 + (double) Main.rand.Next(-20, 21) * 0.400000005960464);
            float SpeedY = (float) (-(double) this.velocity.Y * (double) Main.rand.Next(40, 70) * 0.00999999977648258 + (double) Main.rand.Next(-20, 21) * 0.400000005960464);
            Projectile.NewProjectile(this.position.X + SpeedX, this.position.Y + SpeedY, SpeedX, SpeedY, 90, (int) ((double) this.damage * 0.6), 0.0f, this.owner);
          }
        }
      }
      else if (this.type == 80)
      {
        if ((double) this.ai[0] >= 0.0)
        {
          Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 27);
          for (int index = 0; index < 10; ++index)
            Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 67);
        }
        int i = (int) this.position.X / 16;
        int j = (int) this.position.Y / 16;
        if (Main.tile[i, j] == null)
          Main.tile[i, j] = new Tile();
        if (Main.tile[i, j].type == (byte) 127 && Main.tile[i, j].active)
          WorldGen.KillTile(i, j);
      }
      else if (this.type == 76 || this.type == 77 || this.type == 78)
      {
        for (int index7 = 0; index7 < 5; ++index7)
        {
          int index8 = Dust.NewDust(this.position, this.width, this.height, 27, Alpha: 80, Scale: 1.5f);
          Main.dust[index8].noGravity = true;
        }
      }
      else if (this.type == 55)
      {
        for (int index9 = 0; index9 < 5; ++index9)
        {
          int index10 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 18, Scale: 1.5f);
          Main.dust[index10].noGravity = true;
        }
      }
      else if (this.type == 51)
      {
        Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
        for (int index = 0; index < 5; ++index)
          Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0, Scale: 0.7f);
      }
      else if (this.type == 2 || this.type == 82)
      {
        Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
        for (int index = 0; index < 20; ++index)
          Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100);
      }
      else if (this.type == 103)
      {
        Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
        for (int index11 = 0; index11 < 20; ++index11)
        {
          int index12 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, Alpha: 100);
          if (Main.rand.Next(2) == 0)
          {
            Main.dust[index12].scale *= 2.5f;
            Main.dust[index12].noGravity = true;
            Main.dust[index12].velocity *= 5f;
          }
        }
      }
      else if (this.type == 3 || this.type == 48 || this.type == 54)
      {
        Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
        for (int index = 0; index < 10; ++index)
          Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 1, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, Scale: 0.75f);
      }
      else if (this.type == 4)
      {
        Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
        for (int index = 0; index < 10; ++index)
          Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, Alpha: 150, Scale: 1.1f);
      }
      else if (this.type == 5)
      {
        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
        for (int index = 0; index < 60; ++index)
        {
          int Type;
          switch (Main.rand.Next(3))
          {
            case 0:
              Type = 15;
              break;
            case 1:
              Type = 57;
              break;
            default:
              Type = 58;
              break;
          }
          Dust.NewDust(this.position, this.width, this.height, Type, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, Scale: 1.5f);
        }
      }
      else if (this.type == 9 || this.type == 12)
      {
        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
        for (int index = 0; index < 10; ++index)
          Dust.NewDust(this.position, this.width, this.height, 58, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, Scale: 1.2f);
        for (int index = 0; index < 3; ++index)
          Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18));
        if (this.type == 12 && this.damage < 100)
        {
          for (int index = 0; index < 10; ++index)
            Dust.NewDust(this.position, this.width, this.height, 57, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 150, Scale: 1.2f);
          for (int index = 0; index < 3; ++index)
            Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18));
        }
      }
      else if (this.type == 14 || this.type == 20 || this.type == 36 || this.type == 83 || this.type == 84 || this.type == 100 || this.type == 110)
      {
        Collision.HitTiles(this.position, this.velocity, this.width, this.height);
        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
      }
      else if (this.type == 15 || this.type == 34)
      {
        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
        for (int index13 = 0; index13 < 20; ++index13)
        {
          int index14 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, (float) (-(double) this.velocity.X * 0.200000002980232), (float) (-(double) this.velocity.Y * 0.200000002980232), 100, Scale: 2f);
          Main.dust[index14].noGravity = true;
          Main.dust[index14].velocity *= 2f;
          int index15 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, (float) (-(double) this.velocity.X * 0.200000002980232), (float) (-(double) this.velocity.Y * 0.200000002980232), 100);
          Main.dust[index15].velocity *= 2f;
        }
      }
      else if (this.type == 95 || this.type == 96)
      {
        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
        for (int index16 = 0; index16 < 20; ++index16)
        {
          int index17 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, (float) (-(double) this.velocity.X * 0.200000002980232), (float) (-(double) this.velocity.Y * 0.200000002980232), 100, Scale: (2f * this.scale));
          Main.dust[index17].noGravity = true;
          Main.dust[index17].velocity *= 2f;
          int index18 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, (float) (-(double) this.velocity.X * 0.200000002980232), (float) (-(double) this.velocity.Y * 0.200000002980232), 100, Scale: (1f * this.scale));
          Main.dust[index18].velocity *= 2f;
        }
      }
      else if (this.type == 79)
      {
        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
        for (int index19 = 0; index19 < 20; ++index19)
        {
          int index20 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 66, Alpha: 100, newColor: new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), Scale: 2f);
          Main.dust[index20].noGravity = true;
          Main.dust[index20].velocity *= 4f;
        }
      }
      else if (this.type == 16)
      {
        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
        for (int index21 = 0; index21 < 20; ++index21)
        {
          int index22 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 15, Alpha: 100, Scale: 2f);
          Main.dust[index22].noGravity = true;
          Main.dust[index22].velocity *= 2f;
          Dust.NewDust(new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y), this.width, this.height, 15, Alpha: 100);
        }
      }
      else if (this.type == 17)
      {
        Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
        for (int index = 0; index < 5; ++index)
          Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 0);
      }
      else if (this.type == 31 || this.type == 42)
      {
        Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
        for (int index23 = 0; index23 < 5; ++index23)
        {
          int index24 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 32);
          Main.dust[index24].velocity *= 0.6f;
        }
      }
      else if (this.type == 109)
      {
        Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
        for (int index25 = 0; index25 < 5; ++index25)
        {
          int index26 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 51, Scale: 0.6f);
          Main.dust[index26].velocity *= 0.6f;
        }
      }
      else if (this.type == 39)
      {
        Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
        for (int index27 = 0; index27 < 5; ++index27)
        {
          int index28 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 38);
          Main.dust[index28].velocity *= 0.6f;
        }
      }
      else if (this.type == 71)
      {
        Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
        for (int index29 = 0; index29 < 5; ++index29)
        {
          int index30 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 53);
          Main.dust[index30].velocity *= 0.6f;
        }
      }
      else if (this.type == 40)
      {
        Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
        for (int index31 = 0; index31 < 5; ++index31)
        {
          int index32 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 36);
          Main.dust[index32].velocity *= 0.6f;
        }
      }
      else if (this.type == 21)
      {
        Main.PlaySound(0, (int) this.position.X, (int) this.position.Y);
        for (int index = 0; index < 10; ++index)
          Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 26, Scale: 0.8f);
      }
      else if (this.type == 24)
      {
        for (int index = 0; index < 10; ++index)
          Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 1, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, Scale: 0.75f);
      }
      else if (this.type == 27)
      {
        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
        for (int index33 = 0; index33 < 30; ++index33)
        {
          int index34 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 29, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 100, Scale: 3f);
          Main.dust[index34].noGravity = true;
          Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 29, this.velocity.X * 0.1f, this.velocity.Y * 0.1f, 100, Scale: 2f);
        }
      }
      else if (this.type == 38)
      {
        for (int index = 0; index < 10; ++index)
          Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 42, this.velocity.X * 0.1f, this.velocity.Y * 0.1f);
      }
      else if (this.type == 44 || this.type == 45)
      {
        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
        for (int index35 = 0; index35 < 30; ++index35)
        {
          int index36 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, this.velocity.X, this.velocity.Y, 100, Scale: 1.7f);
          Main.dust[index36].noGravity = true;
          Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 27, this.velocity.X, this.velocity.Y, 100);
        }
      }
      else if (this.type == 41)
      {
        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 14);
        for (int index = 0; index < 10; ++index)
          Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, Alpha: 100, Scale: 1.5f);
        for (int index37 = 0; index37 < 5; ++index37)
        {
          int index38 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 2.5f);
          Main.dust[index38].noGravity = true;
          Main.dust[index38].velocity *= 3f;
          int index39 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 1.5f);
          Main.dust[index39].velocity *= 2f;
        }
        int index40 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index40].velocity *= 0.4f;
        Main.gore[index40].velocity.X += (float) Main.rand.Next(-10, 11) * 0.1f;
        Main.gore[index40].velocity.Y += (float) Main.rand.Next(-10, 11) * 0.1f;
        int index41 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index41].velocity *= 0.4f;
        Main.gore[index41].velocity.X += (float) Main.rand.Next(-10, 11) * 0.1f;
        Main.gore[index41].velocity.Y += (float) Main.rand.Next(-10, 11) * 0.1f;
        if (this.owner == Main.myPlayer)
        {
          this.penetrate = -1;
          this.position.X += (float) (this.width / 2);
          this.position.Y += (float) (this.height / 2);
          this.width = 64;
          this.height = 64;
          this.position.X -= (float) (this.width / 2);
          this.position.Y -= (float) (this.height / 2);
          this.Damage();
        }
      }
      else if (this.type == 28 || this.type == 30 || this.type == 37 || this.type == 75 || this.type == 102)
      {
        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 14);
        this.position.X += (float) (this.width / 2);
        this.position.Y += (float) (this.height / 2);
        this.width = 22;
        this.height = 22;
        this.position.X -= (float) (this.width / 2);
        this.position.Y -= (float) (this.height / 2);
        for (int index42 = 0; index42 < 20; ++index42)
        {
          int index43 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, Alpha: 100, Scale: 1.5f);
          Main.dust[index43].velocity *= 1.4f;
        }
        for (int index44 = 0; index44 < 10; ++index44)
        {
          int index45 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 2.5f);
          Main.dust[index45].noGravity = true;
          Main.dust[index45].velocity *= 5f;
          int index46 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 1.5f);
          Main.dust[index46].velocity *= 3f;
        }
        int index47 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index47].velocity *= 0.4f;
        ++Main.gore[index47].velocity.X;
        ++Main.gore[index47].velocity.Y;
        int index48 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index48].velocity *= 0.4f;
        --Main.gore[index48].velocity.X;
        ++Main.gore[index48].velocity.Y;
        int index49 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index49].velocity *= 0.4f;
        ++Main.gore[index49].velocity.X;
        --Main.gore[index49].velocity.Y;
        int index50 = Gore.NewGore(new Vector2(this.position.X, this.position.Y), new Vector2(), Main.rand.Next(61, 64));
        Main.gore[index50].velocity *= 0.4f;
        --Main.gore[index50].velocity.X;
        --Main.gore[index50].velocity.Y;
      }
      else if (this.type == 29 || this.type == 108)
      {
        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 14);
        if (this.type == 29)
        {
          this.position.X += (float) (this.width / 2);
          this.position.Y += (float) (this.height / 2);
          this.width = 200;
          this.height = 200;
          this.position.X -= (float) (this.width / 2);
          this.position.Y -= (float) (this.height / 2);
        }
        for (int index51 = 0; index51 < 50; ++index51)
        {
          int index52 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, Alpha: 100, Scale: 2f);
          Main.dust[index52].velocity *= 1.4f;
        }
        for (int index53 = 0; index53 < 80; ++index53)
        {
          int index54 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 3f);
          Main.dust[index54].noGravity = true;
          Main.dust[index54].velocity *= 5f;
          int index55 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, Alpha: 100, Scale: 2f);
          Main.dust[index55].velocity *= 3f;
        }
        for (int index56 = 0; index56 < 2; ++index56)
        {
          int index57 = Gore.NewGore(new Vector2((float) ((double) this.position.X + (double) (this.width / 2) - 24.0), (float) ((double) this.position.Y + (double) (this.height / 2) - 24.0)), new Vector2(), Main.rand.Next(61, 64));
          Main.gore[index57].scale = 1.5f;
          Main.gore[index57].velocity.X += 1.5f;
          Main.gore[index57].velocity.Y += 1.5f;
          int index58 = Gore.NewGore(new Vector2((float) ((double) this.position.X + (double) (this.width / 2) - 24.0), (float) ((double) this.position.Y + (double) (this.height / 2) - 24.0)), new Vector2(), Main.rand.Next(61, 64));
          Main.gore[index58].scale = 1.5f;
          Main.gore[index58].velocity.X -= 1.5f;
          Main.gore[index58].velocity.Y += 1.5f;
          int index59 = Gore.NewGore(new Vector2((float) ((double) this.position.X + (double) (this.width / 2) - 24.0), (float) ((double) this.position.Y + (double) (this.height / 2) - 24.0)), new Vector2(), Main.rand.Next(61, 64));
          Main.gore[index59].scale = 1.5f;
          Main.gore[index59].velocity.X += 1.5f;
          Main.gore[index59].velocity.Y -= 1.5f;
          int index60 = Gore.NewGore(new Vector2((float) ((double) this.position.X + (double) (this.width / 2) - 24.0), (float) ((double) this.position.Y + (double) (this.height / 2) - 24.0)), new Vector2(), Main.rand.Next(61, 64));
          Main.gore[index60].scale = 1.5f;
          Main.gore[index60].velocity.X -= 1.5f;
          Main.gore[index60].velocity.Y -= 1.5f;
        }
        this.position.X += (float) (this.width / 2);
        this.position.Y += (float) (this.height / 2);
        this.width = 10;
        this.height = 10;
        this.position.X -= (float) (this.width / 2);
        this.position.Y -= (float) (this.height / 2);
      }
      else if (this.type == 69)
      {
        Main.PlaySound(13, (int) this.position.X, (int) this.position.Y);
        for (int index = 0; index < 5; ++index)
          Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 13);
        for (int index61 = 0; index61 < 30; ++index61)
        {
          int index62 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 33, SpeedY: -2f, Scale: 1.1f);
          Main.dust[index62].alpha = 100;
          Main.dust[index62].velocity.X *= 1.5f;
          Main.dust[index62].velocity *= 3f;
        }
      }
      else if (this.type == 70)
      {
        Main.PlaySound(13, (int) this.position.X, (int) this.position.Y);
        for (int index = 0; index < 5; ++index)
          Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 13);
        for (int index63 = 0; index63 < 30; ++index63)
        {
          int index64 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 52, SpeedY: -2f, Scale: 1.1f);
          Main.dust[index64].alpha = 100;
          Main.dust[index64].velocity.X *= 1.5f;
          Main.dust[index64].velocity *= 3f;
        }
      }
      if (this.owner == Main.myPlayer)
      {
        if (this.type == 28 || this.type == 29 || this.type == 37 || this.type == 75 || this.type == 108)
        {
          int num6 = 3;
          if (this.type == 29)
            num6 = 7;
          if (this.type == 108)
            num6 = 10;
          int num7 = (int) ((double) this.position.X / 16.0 - (double) num6);
          int num8 = (int) ((double) this.position.X / 16.0 + (double) num6);
          int num9 = (int) ((double) this.position.Y / 16.0 - (double) num6);
          int num10 = (int) ((double) this.position.Y / 16.0 + (double) num6);
          if (num7 < 0)
            num7 = 0;
          if (num8 > Main.maxTilesX)
            num8 = Main.maxTilesX;
          if (num9 < 0)
            num9 = 0;
          if (num10 > Main.maxTilesY)
            num10 = Main.maxTilesY;
          bool flag1 = false;
          for (int index65 = num7; index65 <= num8; ++index65)
          {
            for (int index66 = num9; index66 <= num10; ++index66)
            {
              float num11 = Math.Abs((float) index65 - this.position.X / 16f);
              float num12 = Math.Abs((float) index66 - this.position.Y / 16f);
              if (Math.Sqrt((double) num11 * (double) num11 + (double) num12 * (double) num12) < (double) num6 && Main.tile[index65, index66] != null && Main.tile[index65, index66].wall == (byte) 0)
              {
                flag1 = true;
                break;
              }
            }
          }
          for (int i1 = num7; i1 <= num8; ++i1)
          {
            for (int j1 = num9; j1 <= num10; ++j1)
            {
              float num13 = Math.Abs((float) i1 - this.position.X / 16f);
              float num14 = Math.Abs((float) j1 - this.position.Y / 16f);
              if (Math.Sqrt((double) num13 * (double) num13 + (double) num14 * (double) num14) < (double) num6)
              {
                bool flag2 = true;
                if (Main.tile[i1, j1] != null && Main.tile[i1, j1].active)
                {
                  flag2 = true;
                  if (Main.tileDungeon[(int) Main.tile[i1, j1].type] || Main.tile[i1, j1].type == (byte) 21 || Main.tile[i1, j1].type == (byte) 26 || Main.tile[i1, j1].type == (byte) 107 || Main.tile[i1, j1].type == (byte) 108 || Main.tile[i1, j1].type == (byte) 111)
                    flag2 = false;
                  if (!Main.hardMode && Main.tile[i1, j1].type == (byte) 58)
                    flag2 = false;
                  if (flag2)
                  {
                    WorldGen.KillTile(i1, j1);
                    if (!Main.tile[i1, j1].active && Main.netMode != 0)
                      NetMessage.SendData(17, number2: ((float) i1), number3: ((float) j1));
                  }
                }
                if (flag2)
                {
                  for (int i2 = i1 - 1; i2 <= i1 + 1; ++i2)
                  {
                    for (int j2 = j1 - 1; j2 <= j1 + 1; ++j2)
                    {
                      if (Main.tile[i2, j2] != null && Main.tile[i2, j2].wall > (byte) 0 && flag1)
                      {
                        WorldGen.KillWall(i2, j2);
                        if (Main.tile[i2, j2].wall == (byte) 0 && Main.netMode != 0)
                          NetMessage.SendData(17, number: 2, number2: ((float) i2), number3: ((float) j2));
                      }
                    }
                  }
                }
              }
            }
          }
        }
        if (Main.netMode != 0)
          NetMessage.SendData(29, number: this.identity, number2: ((float) this.owner));
        int number = -1;
        if (this.aiStyle == 10)
        {
          int i = (int) ((double) this.position.X + (double) (this.width / 2)) / 16;
          int j = (int) ((double) this.position.Y + (double) (this.width / 2)) / 16;
          int type = 0;
          int Type = 2;
          if (this.type == 109)
          {
            type = 147;
            Type = 0;
          }
          if (this.type == 31)
          {
            type = 53;
            Type = 0;
          }
          if (this.type == 42)
          {
            type = 53;
            Type = 0;
          }
          if (this.type == 56)
          {
            type = 112;
            Type = 0;
          }
          if (this.type == 65)
          {
            type = 112;
            Type = 0;
          }
          if (this.type == 67)
          {
            type = 116;
            Type = 0;
          }
          if (this.type == 68)
          {
            type = 116;
            Type = 0;
          }
          if (this.type == 71)
          {
            type = 123;
            Type = 0;
          }
          if (this.type == 39)
          {
            type = 59;
            Type = 176;
          }
          if (this.type == 40)
          {
            type = 57;
            Type = 172;
          }
          if (!Main.tile[i, j].active)
          {
            WorldGen.PlaceTile(i, j, type, forced: true);
            if (Main.tile[i, j].active && (int) Main.tile[i, j].type == type)
              NetMessage.SendData(17, number: 1, number2: ((float) i), number3: ((float) j), number4: ((float) type));
            else if (Type > 0)
              number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, Type);
          }
          else if (Type > 0)
            number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, Type);
        }
        if (this.type == 1 && Main.rand.Next(3) == 0)
          number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 40);
        if (this.type == 103 && Main.rand.Next(6) == 0)
          number = Main.rand.Next(3) != 0 ? Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 40) : Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 545);
        if (this.type == 2 && Main.rand.Next(3) == 0)
          number = Main.rand.Next(3) != 0 ? Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 40) : Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 41);
        if (this.type == 91 && Main.rand.Next(6) == 0)
          number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 516);
        if (this.type == 50 && Main.rand.Next(3) == 0)
          number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 282);
        if (this.type == 53 && Main.rand.Next(3) == 0)
          number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 286);
        if (this.type == 48 && Main.rand.Next(2) == 0)
          number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 279);
        if (this.type == 54 && Main.rand.Next(2) == 0)
          number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 287);
        if (this.type == 3 && Main.rand.Next(2) == 0)
          number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 42);
        if (this.type == 4 && Main.rand.Next(4) == 0)
          number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 47);
        if (this.type == 12 && this.damage > 100)
          number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 75);
        if (this.type == 69 || this.type == 70)
        {
          int num15 = (int) ((double) this.position.X + (double) (this.width / 2)) / 16;
          int num16 = (int) ((double) this.position.Y + (double) (this.height / 2)) / 16;
          for (int index67 = num15 - 4; index67 <= num15 + 4; ++index67)
          {
            for (int index68 = num16 - 4; index68 <= num16 + 4; ++index68)
            {
              if (Math.Abs(index67 - num15) + Math.Abs(index68 - num16) < 6)
              {
                if (this.type == 69)
                {
                  if (Main.tile[index67, index68].type == (byte) 2)
                  {
                    Main.tile[index67, index68].type = (byte) 109;
                    WorldGen.SquareTileFrame(index67, index68);
                    NetMessage.SendTileSquare(-1, index67, index68, 1);
                  }
                  else if (Main.tile[index67, index68].type == (byte) 1)
                  {
                    Main.tile[index67, index68].type = (byte) 117;
                    WorldGen.SquareTileFrame(index67, index68);
                    NetMessage.SendTileSquare(-1, index67, index68, 1);
                  }
                  else if (Main.tile[index67, index68].type == (byte) 53)
                  {
                    Main.tile[index67, index68].type = (byte) 116;
                    WorldGen.SquareTileFrame(index67, index68);
                    NetMessage.SendTileSquare(-1, index67, index68, 1);
                  }
                  else if (Main.tile[index67, index68].type == (byte) 23)
                  {
                    Main.tile[index67, index68].type = (byte) 109;
                    WorldGen.SquareTileFrame(index67, index68);
                    NetMessage.SendTileSquare(-1, index67, index68, 1);
                  }
                  else if (Main.tile[index67, index68].type == (byte) 25)
                  {
                    Main.tile[index67, index68].type = (byte) 117;
                    WorldGen.SquareTileFrame(index67, index68);
                    NetMessage.SendTileSquare(-1, index67, index68, 1);
                  }
                  else if (Main.tile[index67, index68].type == (byte) 112)
                  {
                    Main.tile[index67, index68].type = (byte) 116;
                    WorldGen.SquareTileFrame(index67, index68);
                    NetMessage.SendTileSquare(-1, index67, index68, 1);
                  }
                }
                else if (Main.tile[index67, index68].type == (byte) 2)
                {
                  Main.tile[index67, index68].type = (byte) 23;
                  WorldGen.SquareTileFrame(index67, index68);
                  NetMessage.SendTileSquare(-1, index67, index68, 1);
                }
                else if (Main.tile[index67, index68].type == (byte) 1)
                {
                  Main.tile[index67, index68].type = (byte) 25;
                  WorldGen.SquareTileFrame(index67, index68);
                  NetMessage.SendTileSquare(-1, index67, index68, 1);
                }
                else if (Main.tile[index67, index68].type == (byte) 53)
                {
                  Main.tile[index67, index68].type = (byte) 112;
                  WorldGen.SquareTileFrame(index67, index68);
                  NetMessage.SendTileSquare(-1, index67, index68, 1);
                }
                else if (Main.tile[index67, index68].type == (byte) 109)
                {
                  Main.tile[index67, index68].type = (byte) 23;
                  WorldGen.SquareTileFrame(index67, index68);
                  NetMessage.SendTileSquare(-1, index67, index68, 1);
                }
                else if (Main.tile[index67, index68].type == (byte) 117)
                {
                  Main.tile[index67, index68].type = (byte) 25;
                  WorldGen.SquareTileFrame(index67, index68);
                  NetMessage.SendTileSquare(-1, index67, index68, 1);
                }
                else if (Main.tile[index67, index68].type == (byte) 116)
                {
                  Main.tile[index67, index68].type = (byte) 112;
                  WorldGen.SquareTileFrame(index67, index68);
                  NetMessage.SendTileSquare(-1, index67, index68, 1);
                }
              }
            }
          }
        }
        if (this.type == 21 && Main.rand.Next(2) == 0)
          number = Item.NewItem((int) this.position.X, (int) this.position.Y, this.width, this.height, 154);
        if (Main.netMode == 1 && number >= 0)
          NetMessage.SendData(21, number: number);
      }
      this.active = false;
    }

    public Color GetAlpha(Color newColor)
    {
      if (this.type == 34 || this.type == 15 || this.type == 93 || this.type == 94 || this.type == 95 || this.type == 96 || this.type == 102 && this.alpha < (int) byte.MaxValue)
        return new Color(200, 200, 200, 25);
      if (this.type == 83 || this.type == 88 || this.type == 89 || this.type == 90 || this.type == 100 || this.type == 104)
        return this.alpha < 200 ? new Color((int) byte.MaxValue - this.alpha, (int) byte.MaxValue - this.alpha, (int) byte.MaxValue - this.alpha, 0) : new Color(0, 0, 0, 0);
      if (this.type == 34 || this.type == 35 || this.type == 15 || this.type == 19 || this.type == 44 || this.type == 45)
        return Color.White;
      if (this.type == 79)
      {
        int discoR = Main.DiscoR;
        int discoG = Main.DiscoG;
        int discoB = Main.DiscoB;
        return new Color();
      }
      int r;
      int g;
      int b;
      if (this.type == 9 || this.type == 15 || this.type == 34 || this.type == 50 || this.type == 53 || this.type == 76 || this.type == 77 || this.type == 78 || this.type == 92 || this.type == 91)
      {
        r = (int) newColor.R - this.alpha / 3;
        g = (int) newColor.G - this.alpha / 3;
        b = (int) newColor.B - this.alpha / 3;
      }
      else if (this.type == 16 || this.type == 18 || this.type == 44 || this.type == 45)
      {
        r = (int) newColor.R;
        g = (int) newColor.G;
        b = (int) newColor.B;
      }
      else
      {
        if (this.type == 12 || this.type == 72 || this.type == 86 || this.type == 87)
          return new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) newColor.A - this.alpha);
        r = (int) newColor.R - this.alpha;
        g = (int) newColor.G - this.alpha;
        b = (int) newColor.B - this.alpha;
      }
      int a = (int) newColor.A - this.alpha;
      if (a < 0)
        a = 0;
      if (a > (int) byte.MaxValue)
        a = (int) byte.MaxValue;
      return new Color(r, g, b, a);
    }
  }
}
