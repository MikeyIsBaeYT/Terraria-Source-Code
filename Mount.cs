// Decompiled with JetBrains decompiler
// Type: Terraria.Mount
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;
using Terraria.ID;

namespace Terraria
{
  public class Mount
  {
    public static int currentShader = 0;
    public const int None = -1;
    public const int Rudolph = 0;
    public const int Bunny = 1;
    public const int Pigron = 2;
    public const int Slime = 3;
    public const int Turtle = 4;
    public const int Bee = 5;
    public const int Minecart = 6;
    public const int UFO = 7;
    public const int Drill = 8;
    public const int Scutlix = 9;
    public const int Unicorn = 10;
    public const int MinecartMech = 11;
    public const int CuteFishron = 12;
    public const int MinecartWood = 13;
    public const int Basilisk = 14;
    public const int maxMounts = 15;
    public const int FrameStanding = 0;
    public const int FrameRunning = 1;
    public const int FrameInAir = 2;
    public const int FrameFlying = 3;
    public const int FrameSwimming = 4;
    public const int FrameDashing = 5;
    public const int DrawBack = 0;
    public const int DrawBackExtra = 1;
    public const int DrawFront = 2;
    public const int DrawFrontExtra = 3;
    private static Mount.MountData[] mounts;
    private static Vector2[] scutlixEyePositions;
    private static Vector2 scutlixTextureSize;
    public const int scutlixBaseDamage = 50;
    public static Vector2 drillDiodePoint1 = new Vector2(36f, -6f);
    public static Vector2 drillDiodePoint2 = new Vector2(36f, 8f);
    public static Vector2 drillTextureSize;
    public const int drillTextureWidth = 80;
    public const float drillRotationChange = 0.05235988f;
    public static int drillPickPower = 210;
    public static int drillPickTime = 6;
    public static int drillBeamCooldownMax = 1;
    public const float maxDrillLength = 48f;
    private Mount.MountData _data;
    private int _type;
    private bool _flipDraw;
    private int _frame;
    private float _frameCounter;
    private int _frameExtra;
    private float _frameExtraCounter;
    private int _frameState;
    private int _flyTime;
    private int _idleTime;
    private int _idleTimeNext;
    private float _fatigue;
    private float _fatigueMax;
    private bool _abilityCharging;
    private int _abilityCharge;
    private int _abilityCooldown;
    private int _abilityDuration;
    private bool _abilityActive;
    private bool _aiming;
    public List<DrillDebugDraw> _debugDraw;
    private object _mountSpecificData;
    private bool _active;

    public Mount()
    {
      this._debugDraw = new List<DrillDebugDraw>();
      this.Reset();
    }

    public void Reset()
    {
      this._active = false;
      this._type = -1;
      this._flipDraw = false;
      this._frame = 0;
      this._frameCounter = 0.0f;
      this._frameExtra = 0;
      this._frameExtraCounter = 0.0f;
      this._frameState = 0;
      this._flyTime = 0;
      this._idleTime = 0;
      this._idleTimeNext = -1;
      this._fatigueMax = 0.0f;
      this._abilityCharging = false;
      this._abilityCharge = 0;
      this._aiming = false;
    }

    public static void Initialize()
    {
      Mount.mounts = new Mount.MountData[15];
      Mount.MountData mountData1 = new Mount.MountData();
      Mount.mounts[0] = mountData1;
      mountData1.spawnDust = 57;
      mountData1.spawnDustNoGravity = false;
      mountData1.buff = 90;
      mountData1.heightBoost = 20;
      mountData1.flightTimeMax = 160;
      mountData1.runSpeed = 5.5f;
      mountData1.dashSpeed = 12f;
      mountData1.acceleration = 0.09f;
      mountData1.jumpHeight = 17;
      mountData1.jumpSpeed = 5.31f;
      mountData1.totalFrames = 12;
      int[] numArray1 = new int[mountData1.totalFrames];
      for (int index = 0; index < numArray1.Length; ++index)
        numArray1[index] = 30;
      numArray1[1] += 2;
      numArray1[11] += 2;
      mountData1.playerYOffsets = numArray1;
      mountData1.xOffset = 13;
      mountData1.bodyFrame = 3;
      mountData1.yOffset = -7;
      mountData1.playerHeadOffset = 22;
      mountData1.standingFrameCount = 1;
      mountData1.standingFrameDelay = 12;
      mountData1.standingFrameStart = 0;
      mountData1.runningFrameCount = 6;
      mountData1.runningFrameDelay = 12;
      mountData1.runningFrameStart = 6;
      mountData1.flyingFrameCount = 6;
      mountData1.flyingFrameDelay = 6;
      mountData1.flyingFrameStart = 6;
      mountData1.inAirFrameCount = 1;
      mountData1.inAirFrameDelay = 12;
      mountData1.inAirFrameStart = 1;
      mountData1.idleFrameCount = 4;
      mountData1.idleFrameDelay = 30;
      mountData1.idleFrameStart = 2;
      mountData1.idleFrameLoop = true;
      mountData1.swimFrameCount = mountData1.inAirFrameCount;
      mountData1.swimFrameDelay = mountData1.inAirFrameDelay;
      mountData1.swimFrameStart = mountData1.inAirFrameStart;
      if (Main.netMode != 2)
      {
        mountData1.backTexture = Main.rudolphMountTexture[0];
        mountData1.backTextureExtra = (Texture2D) null;
        mountData1.frontTexture = Main.rudolphMountTexture[1];
        mountData1.frontTextureExtra = Main.rudolphMountTexture[2];
        mountData1.textureWidth = mountData1.backTexture.Width;
        mountData1.textureHeight = mountData1.backTexture.Height;
      }
      Mount.MountData mountData2 = new Mount.MountData();
      Mount.mounts[2] = mountData2;
      mountData2.spawnDust = 58;
      mountData2.buff = 129;
      mountData2.heightBoost = 20;
      mountData2.flightTimeMax = 160;
      mountData2.runSpeed = 5f;
      mountData2.dashSpeed = 9f;
      mountData2.acceleration = 0.08f;
      mountData2.jumpHeight = 10;
      mountData2.jumpSpeed = 6.01f;
      mountData2.totalFrames = 16;
      int[] numArray2 = new int[mountData2.totalFrames];
      for (int index = 0; index < numArray2.Length; ++index)
        numArray2[index] = 22;
      numArray2[12] += 2;
      numArray2[13] += 4;
      numArray2[14] += 2;
      mountData2.playerYOffsets = numArray2;
      mountData2.xOffset = 1;
      mountData2.bodyFrame = 3;
      mountData2.yOffset = 8;
      mountData2.playerHeadOffset = 22;
      mountData2.standingFrameCount = 1;
      mountData2.standingFrameDelay = 12;
      mountData2.standingFrameStart = 7;
      mountData2.runningFrameCount = 5;
      mountData2.runningFrameDelay = 12;
      mountData2.runningFrameStart = 11;
      mountData2.flyingFrameCount = 6;
      mountData2.flyingFrameDelay = 6;
      mountData2.flyingFrameStart = 1;
      mountData2.inAirFrameCount = 1;
      mountData2.inAirFrameDelay = 12;
      mountData2.inAirFrameStart = 0;
      mountData2.idleFrameCount = 3;
      mountData2.idleFrameDelay = 30;
      mountData2.idleFrameStart = 8;
      mountData2.idleFrameLoop = false;
      mountData2.swimFrameCount = mountData2.inAirFrameCount;
      mountData2.swimFrameDelay = mountData2.inAirFrameDelay;
      mountData2.swimFrameStart = mountData2.inAirFrameStart;
      if (Main.netMode != 2)
      {
        mountData2.backTexture = Main.pigronMountTexture;
        mountData2.backTextureExtra = (Texture2D) null;
        mountData2.frontTexture = (Texture2D) null;
        mountData2.frontTextureExtra = (Texture2D) null;
        mountData2.textureWidth = mountData2.backTexture.Width;
        mountData2.textureHeight = mountData2.backTexture.Height;
      }
      Mount.MountData mountData3 = new Mount.MountData();
      Mount.mounts[1] = mountData3;
      mountData3.spawnDust = 15;
      mountData3.buff = 128;
      mountData3.heightBoost = 20;
      mountData3.flightTimeMax = 0;
      mountData3.fallDamage = 0.8f;
      mountData3.runSpeed = 4f;
      mountData3.dashSpeed = 7.5f;
      mountData3.acceleration = 0.13f;
      mountData3.jumpHeight = 15;
      mountData3.jumpSpeed = 5.01f;
      mountData3.totalFrames = 7;
      int[] numArray3 = new int[mountData3.totalFrames];
      for (int index = 0; index < numArray3.Length; ++index)
        numArray3[index] = 14;
      numArray3[2] += 2;
      numArray3[3] += 4;
      numArray3[4] += 8;
      numArray3[5] += 8;
      mountData3.playerYOffsets = numArray3;
      mountData3.xOffset = 1;
      mountData3.bodyFrame = 3;
      mountData3.yOffset = 4;
      mountData3.playerHeadOffset = 22;
      mountData3.standingFrameCount = 1;
      mountData3.standingFrameDelay = 12;
      mountData3.standingFrameStart = 0;
      mountData3.runningFrameCount = 7;
      mountData3.runningFrameDelay = 12;
      mountData3.runningFrameStart = 0;
      mountData3.flyingFrameCount = 6;
      mountData3.flyingFrameDelay = 6;
      mountData3.flyingFrameStart = 1;
      mountData3.inAirFrameCount = 1;
      mountData3.inAirFrameDelay = 12;
      mountData3.inAirFrameStart = 5;
      mountData3.idleFrameCount = 0;
      mountData3.idleFrameDelay = 0;
      mountData3.idleFrameStart = 0;
      mountData3.idleFrameLoop = false;
      mountData3.swimFrameCount = mountData3.inAirFrameCount;
      mountData3.swimFrameDelay = mountData3.inAirFrameDelay;
      mountData3.swimFrameStart = mountData3.inAirFrameStart;
      if (Main.netMode != 2)
      {
        mountData3.backTexture = Main.bunnyMountTexture;
        mountData3.backTextureExtra = (Texture2D) null;
        mountData3.frontTexture = (Texture2D) null;
        mountData3.frontTextureExtra = (Texture2D) null;
        mountData3.textureWidth = mountData3.backTexture.Width;
        mountData3.textureHeight = mountData3.backTexture.Height;
      }
      Mount.MountData mountData4 = new Mount.MountData();
      Mount.mounts[3] = mountData4;
      mountData4.spawnDust = 56;
      mountData4.buff = 130;
      mountData4.heightBoost = 20;
      mountData4.flightTimeMax = 0;
      mountData4.fallDamage = 0.5f;
      mountData4.runSpeed = 4f;
      mountData4.dashSpeed = 4f;
      mountData4.acceleration = 0.18f;
      mountData4.jumpHeight = 12;
      mountData4.jumpSpeed = 8.25f;
      mountData4.constantJump = true;
      mountData4.totalFrames = 4;
      int[] numArray4 = new int[mountData4.totalFrames];
      for (int index = 0; index < numArray4.Length; ++index)
        numArray4[index] = 20;
      numArray4[1] += 2;
      numArray4[3] -= 2;
      mountData4.playerYOffsets = numArray4;
      mountData4.xOffset = 1;
      mountData4.bodyFrame = 3;
      mountData4.yOffset = 10;
      mountData4.playerHeadOffset = 22;
      mountData4.standingFrameCount = 1;
      mountData4.standingFrameDelay = 12;
      mountData4.standingFrameStart = 0;
      mountData4.runningFrameCount = 4;
      mountData4.runningFrameDelay = 12;
      mountData4.runningFrameStart = 0;
      mountData4.flyingFrameCount = 0;
      mountData4.flyingFrameDelay = 0;
      mountData4.flyingFrameStart = 0;
      mountData4.inAirFrameCount = 1;
      mountData4.inAirFrameDelay = 12;
      mountData4.inAirFrameStart = 1;
      mountData4.idleFrameCount = 0;
      mountData4.idleFrameDelay = 0;
      mountData4.idleFrameStart = 0;
      mountData4.idleFrameLoop = false;
      if (Main.netMode != 2)
      {
        mountData4.backTexture = Main.slimeMountTexture;
        mountData4.backTextureExtra = (Texture2D) null;
        mountData4.frontTexture = (Texture2D) null;
        mountData4.frontTextureExtra = (Texture2D) null;
        mountData4.textureWidth = mountData4.backTexture.Width;
        mountData4.textureHeight = mountData4.backTexture.Height;
      }
      Mount.MountData mountData5 = new Mount.MountData();
      Mount.mounts[6] = mountData5;
      mountData5.Minecart = true;
      mountData5.MinecartDirectional = true;
      mountData5.MinecartDust = new Action<Vector2>(DelegateMethods.Minecart.Sparks);
      mountData5.spawnDust = 213;
      mountData5.buff = 118;
      mountData5.extraBuff = 138;
      mountData5.heightBoost = 10;
      mountData5.flightTimeMax = 0;
      mountData5.fallDamage = 1f;
      mountData5.runSpeed = 13f;
      mountData5.dashSpeed = 13f;
      mountData5.acceleration = 0.04f;
      mountData5.jumpHeight = 15;
      mountData5.jumpSpeed = 5.15f;
      mountData5.blockExtraJumps = true;
      mountData5.totalFrames = 3;
      int[] numArray5 = new int[mountData5.totalFrames];
      for (int index = 0; index < numArray5.Length; ++index)
        numArray5[index] = 8;
      mountData5.playerYOffsets = numArray5;
      mountData5.xOffset = 1;
      mountData5.bodyFrame = 3;
      mountData5.yOffset = 13;
      mountData5.playerHeadOffset = 14;
      mountData5.standingFrameCount = 1;
      mountData5.standingFrameDelay = 12;
      mountData5.standingFrameStart = 0;
      mountData5.runningFrameCount = 3;
      mountData5.runningFrameDelay = 12;
      mountData5.runningFrameStart = 0;
      mountData5.flyingFrameCount = 0;
      mountData5.flyingFrameDelay = 0;
      mountData5.flyingFrameStart = 0;
      mountData5.inAirFrameCount = 0;
      mountData5.inAirFrameDelay = 0;
      mountData5.inAirFrameStart = 0;
      mountData5.idleFrameCount = 0;
      mountData5.idleFrameDelay = 0;
      mountData5.idleFrameStart = 0;
      mountData5.idleFrameLoop = false;
      if (Main.netMode != 2)
      {
        mountData5.backTexture = (Texture2D) null;
        mountData5.backTextureExtra = (Texture2D) null;
        mountData5.frontTexture = Main.minecartMountTexture;
        mountData5.frontTextureExtra = (Texture2D) null;
        mountData5.textureWidth = mountData5.frontTexture.Width;
        mountData5.textureHeight = mountData5.frontTexture.Height;
      }
      Mount.MountData mountData6 = new Mount.MountData();
      Mount.mounts[4] = mountData6;
      mountData6.spawnDust = 56;
      mountData6.buff = 131;
      mountData6.heightBoost = 26;
      mountData6.flightTimeMax = 0;
      mountData6.fallDamage = 1f;
      mountData6.runSpeed = 2f;
      mountData6.dashSpeed = 2f;
      mountData6.swimSpeed = 6f;
      mountData6.acceleration = 0.08f;
      mountData6.jumpHeight = 10;
      mountData6.jumpSpeed = 3.15f;
      mountData6.totalFrames = 12;
      int[] numArray6 = new int[mountData6.totalFrames];
      for (int index = 0; index < numArray6.Length; ++index)
        numArray6[index] = 26;
      mountData6.playerYOffsets = numArray6;
      mountData6.xOffset = 1;
      mountData6.bodyFrame = 3;
      mountData6.yOffset = 13;
      mountData6.playerHeadOffset = 30;
      mountData6.standingFrameCount = 1;
      mountData6.standingFrameDelay = 12;
      mountData6.standingFrameStart = 0;
      mountData6.runningFrameCount = 6;
      mountData6.runningFrameDelay = 12;
      mountData6.runningFrameStart = 0;
      mountData6.flyingFrameCount = 0;
      mountData6.flyingFrameDelay = 0;
      mountData6.flyingFrameStart = 0;
      mountData6.inAirFrameCount = 1;
      mountData6.inAirFrameDelay = 12;
      mountData6.inAirFrameStart = 3;
      mountData6.idleFrameCount = 0;
      mountData6.idleFrameDelay = 0;
      mountData6.idleFrameStart = 0;
      mountData6.idleFrameLoop = false;
      mountData6.swimFrameCount = 6;
      mountData6.swimFrameDelay = 12;
      mountData6.swimFrameStart = 6;
      if (Main.netMode != 2)
      {
        mountData6.backTexture = Main.turtleMountTexture;
        mountData6.backTextureExtra = (Texture2D) null;
        mountData6.frontTexture = (Texture2D) null;
        mountData6.frontTextureExtra = (Texture2D) null;
        mountData6.textureWidth = mountData6.backTexture.Width;
        mountData6.textureHeight = mountData6.backTexture.Height;
      }
      Mount.MountData mountData7 = new Mount.MountData();
      Mount.mounts[5] = mountData7;
      mountData7.spawnDust = 152;
      mountData7.buff = 132;
      mountData7.heightBoost = 16;
      mountData7.flightTimeMax = 320;
      mountData7.fatigueMax = 320;
      mountData7.fallDamage = 0.0f;
      mountData7.usesHover = true;
      mountData7.runSpeed = 2f;
      mountData7.dashSpeed = 2f;
      mountData7.acceleration = 0.16f;
      mountData7.jumpHeight = 10;
      mountData7.jumpSpeed = 4f;
      mountData7.blockExtraJumps = true;
      mountData7.totalFrames = 12;
      int[] numArray7 = new int[mountData7.totalFrames];
      for (int index = 0; index < numArray7.Length; ++index)
        numArray7[index] = 16;
      numArray7[8] = 18;
      mountData7.playerYOffsets = numArray7;
      mountData7.xOffset = 1;
      mountData7.bodyFrame = 3;
      mountData7.yOffset = 4;
      mountData7.playerHeadOffset = 18;
      mountData7.standingFrameCount = 1;
      mountData7.standingFrameDelay = 12;
      mountData7.standingFrameStart = 0;
      mountData7.runningFrameCount = 5;
      mountData7.runningFrameDelay = 12;
      mountData7.runningFrameStart = 0;
      mountData7.flyingFrameCount = 3;
      mountData7.flyingFrameDelay = 12;
      mountData7.flyingFrameStart = 5;
      mountData7.inAirFrameCount = 3;
      mountData7.inAirFrameDelay = 12;
      mountData7.inAirFrameStart = 5;
      mountData7.idleFrameCount = 4;
      mountData7.idleFrameDelay = 12;
      mountData7.idleFrameStart = 8;
      mountData7.idleFrameLoop = true;
      mountData7.swimFrameCount = 0;
      mountData7.swimFrameDelay = 12;
      mountData7.swimFrameStart = 0;
      if (Main.netMode != 2)
      {
        mountData7.backTexture = Main.beeMountTexture[0];
        mountData7.backTextureExtra = Main.beeMountTexture[1];
        mountData7.frontTexture = (Texture2D) null;
        mountData7.frontTextureExtra = (Texture2D) null;
        mountData7.textureWidth = mountData7.backTexture.Width;
        mountData7.textureHeight = mountData7.backTexture.Height;
      }
      Mount.MountData mountData8 = new Mount.MountData();
      Mount.mounts[7] = mountData8;
      mountData8.spawnDust = 226;
      mountData8.spawnDustNoGravity = true;
      mountData8.buff = 141;
      mountData8.heightBoost = 16;
      mountData8.flightTimeMax = 320;
      mountData8.fatigueMax = 320;
      mountData8.fallDamage = 0.0f;
      mountData8.usesHover = true;
      mountData8.runSpeed = 8f;
      mountData8.dashSpeed = 8f;
      mountData8.acceleration = 0.16f;
      mountData8.jumpHeight = 10;
      mountData8.jumpSpeed = 4f;
      mountData8.blockExtraJumps = true;
      mountData8.totalFrames = 8;
      int[] numArray8 = new int[mountData8.totalFrames];
      for (int index = 0; index < numArray8.Length; ++index)
        numArray8[index] = 16;
      mountData8.playerYOffsets = numArray8;
      mountData8.xOffset = 1;
      mountData8.bodyFrame = 3;
      mountData8.yOffset = 4;
      mountData8.playerHeadOffset = 18;
      mountData8.standingFrameCount = 8;
      mountData8.standingFrameDelay = 4;
      mountData8.standingFrameStart = 0;
      mountData8.runningFrameCount = 8;
      mountData8.runningFrameDelay = 4;
      mountData8.runningFrameStart = 0;
      mountData8.flyingFrameCount = 8;
      mountData8.flyingFrameDelay = 4;
      mountData8.flyingFrameStart = 0;
      mountData8.inAirFrameCount = 8;
      mountData8.inAirFrameDelay = 4;
      mountData8.inAirFrameStart = 0;
      mountData8.idleFrameCount = 0;
      mountData8.idleFrameDelay = 12;
      mountData8.idleFrameStart = 0;
      mountData8.idleFrameLoop = true;
      mountData8.swimFrameCount = 0;
      mountData8.swimFrameDelay = 12;
      mountData8.swimFrameStart = 0;
      if (Main.netMode != 2)
      {
        mountData8.backTexture = (Texture2D) null;
        mountData8.backTextureExtra = (Texture2D) null;
        mountData8.frontTexture = Main.UFOMountTexture[0];
        mountData8.frontTextureExtra = Main.UFOMountTexture[1];
        mountData8.textureWidth = mountData8.frontTexture.Width;
        mountData8.textureHeight = mountData8.frontTexture.Height;
      }
      Mount.MountData mountData9 = new Mount.MountData();
      Mount.mounts[8] = mountData9;
      mountData9.spawnDust = 226;
      mountData9.buff = 142;
      mountData9.heightBoost = 16;
      mountData9.flightTimeMax = 320;
      mountData9.fatigueMax = 320;
      mountData9.fallDamage = 1f;
      mountData9.usesHover = true;
      mountData9.swimSpeed = 4f;
      mountData9.runSpeed = 6f;
      mountData9.dashSpeed = 4f;
      mountData9.acceleration = 0.16f;
      mountData9.jumpHeight = 10;
      mountData9.jumpSpeed = 4f;
      mountData9.blockExtraJumps = true;
      mountData9.emitsLight = true;
      mountData9.lightColor = new Vector3(0.3f, 0.3f, 0.4f);
      mountData9.totalFrames = 1;
      int[] numArray9 = new int[mountData9.totalFrames];
      for (int index = 0; index < numArray9.Length; ++index)
        numArray9[index] = 4;
      mountData9.playerYOffsets = numArray9;
      mountData9.xOffset = 1;
      mountData9.bodyFrame = 3;
      mountData9.yOffset = 4;
      mountData9.playerHeadOffset = 18;
      mountData9.standingFrameCount = 1;
      mountData9.standingFrameDelay = 12;
      mountData9.standingFrameStart = 0;
      mountData9.runningFrameCount = 1;
      mountData9.runningFrameDelay = 12;
      mountData9.runningFrameStart = 0;
      mountData9.flyingFrameCount = 1;
      mountData9.flyingFrameDelay = 12;
      mountData9.flyingFrameStart = 0;
      mountData9.inAirFrameCount = 1;
      mountData9.inAirFrameDelay = 12;
      mountData9.inAirFrameStart = 0;
      mountData9.idleFrameCount = 0;
      mountData9.idleFrameDelay = 12;
      mountData9.idleFrameStart = 8;
      mountData9.swimFrameCount = 0;
      mountData9.swimFrameDelay = 12;
      mountData9.swimFrameStart = 0;
      if (Main.netMode != 2)
      {
        mountData9.backTexture = Main.drillMountTexture[0];
        mountData9.backTextureGlow = Main.drillMountTexture[3];
        mountData9.backTextureExtra = (Texture2D) null;
        mountData9.backTextureExtraGlow = (Texture2D) null;
        mountData9.frontTexture = Main.drillMountTexture[1];
        mountData9.frontTextureGlow = Main.drillMountTexture[4];
        mountData9.frontTextureExtra = Main.drillMountTexture[2];
        mountData9.frontTextureExtraGlow = Main.drillMountTexture[5];
        mountData9.textureWidth = mountData9.frontTexture.Width;
        mountData9.textureHeight = mountData9.frontTexture.Height;
      }
      Mount.drillTextureSize = new Vector2(80f, 80f);
      Vector2 vector2_1 = new Vector2((float) mountData9.textureWidth, (float) (mountData9.textureHeight / mountData9.totalFrames));
      if (Mount.drillTextureSize != vector2_1)
        throw new Exception("Be sure to update the Drill texture origin to match the actual texture size of " + (object) mountData9.textureWidth + ", " + (object) mountData9.textureHeight + ".");
      Mount.MountData mountData10 = new Mount.MountData();
      Mount.mounts[9] = mountData10;
      mountData10.spawnDust = 152;
      mountData10.buff = 143;
      mountData10.heightBoost = 16;
      mountData10.flightTimeMax = 0;
      mountData10.fatigueMax = 0;
      mountData10.fallDamage = 0.0f;
      mountData10.abilityChargeMax = 40;
      mountData10.abilityCooldown = 20;
      mountData10.abilityDuration = 0;
      mountData10.runSpeed = 8f;
      mountData10.dashSpeed = 8f;
      mountData10.acceleration = 0.4f;
      mountData10.jumpHeight = 22;
      mountData10.jumpSpeed = 10.01f;
      mountData10.blockExtraJumps = false;
      mountData10.totalFrames = 12;
      int[] numArray10 = new int[mountData10.totalFrames];
      for (int index = 0; index < numArray10.Length; ++index)
        numArray10[index] = 16;
      mountData10.playerYOffsets = numArray10;
      mountData10.xOffset = 1;
      mountData10.bodyFrame = 3;
      mountData10.yOffset = 6;
      mountData10.playerHeadOffset = 18;
      mountData10.standingFrameCount = 6;
      mountData10.standingFrameDelay = 12;
      mountData10.standingFrameStart = 6;
      mountData10.runningFrameCount = 6;
      mountData10.runningFrameDelay = 12;
      mountData10.runningFrameStart = 0;
      mountData10.flyingFrameCount = 0;
      mountData10.flyingFrameDelay = 12;
      mountData10.flyingFrameStart = 0;
      mountData10.inAirFrameCount = 1;
      mountData10.inAirFrameDelay = 12;
      mountData10.inAirFrameStart = 1;
      mountData10.idleFrameCount = 0;
      mountData10.idleFrameDelay = 12;
      mountData10.idleFrameStart = 6;
      mountData10.idleFrameLoop = true;
      mountData10.swimFrameCount = 0;
      mountData10.swimFrameDelay = 12;
      mountData10.swimFrameStart = 0;
      if (Main.netMode != 2)
      {
        mountData10.backTexture = Main.scutlixMountTexture[0];
        mountData10.backTextureExtra = (Texture2D) null;
        mountData10.frontTexture = Main.scutlixMountTexture[1];
        mountData10.frontTextureExtra = Main.scutlixMountTexture[2];
        mountData10.textureWidth = mountData10.backTexture.Width;
        mountData10.textureHeight = mountData10.backTexture.Height;
      }
      Mount.scutlixEyePositions = new Vector2[10];
      Mount.scutlixEyePositions[0] = new Vector2(60f, 2f);
      Mount.scutlixEyePositions[1] = new Vector2(70f, 6f);
      Mount.scutlixEyePositions[2] = new Vector2(68f, 6f);
      Mount.scutlixEyePositions[3] = new Vector2(76f, 12f);
      Mount.scutlixEyePositions[4] = new Vector2(80f, 10f);
      Mount.scutlixEyePositions[5] = new Vector2(84f, 18f);
      Mount.scutlixEyePositions[6] = new Vector2(74f, 20f);
      Mount.scutlixEyePositions[7] = new Vector2(76f, 24f);
      Mount.scutlixEyePositions[8] = new Vector2(70f, 34f);
      Mount.scutlixEyePositions[9] = new Vector2(76f, 34f);
      Mount.scutlixTextureSize = new Vector2(45f, 54f);
      Vector2 vector2_2 = new Vector2((float) (mountData10.textureWidth / 2), (float) (mountData10.textureHeight / mountData10.totalFrames));
      if (Mount.scutlixTextureSize != vector2_2)
        throw new Exception("Be sure to update the Scutlix texture origin to match the actual texture size of " + (object) mountData10.textureWidth + ", " + (object) mountData10.textureHeight + ".");
      for (int index = 0; index < Mount.scutlixEyePositions.Length; ++index)
        Mount.scutlixEyePositions[index] -= Mount.scutlixTextureSize;
      Mount.MountData mountData11 = new Mount.MountData();
      Mount.mounts[10] = mountData11;
      mountData11.spawnDust = 15;
      mountData11.buff = 162;
      mountData11.heightBoost = 34;
      mountData11.flightTimeMax = 0;
      mountData11.fallDamage = 0.2f;
      mountData11.runSpeed = 4f;
      mountData11.dashSpeed = 12f;
      mountData11.acceleration = 0.3f;
      mountData11.jumpHeight = 10;
      mountData11.jumpSpeed = 8.01f;
      mountData11.totalFrames = 16;
      int[] numArray11 = new int[mountData11.totalFrames];
      for (int index = 0; index < numArray11.Length; ++index)
        numArray11[index] = 28;
      numArray11[3] += 2;
      numArray11[4] += 2;
      numArray11[7] += 2;
      numArray11[8] += 2;
      numArray11[12] += 2;
      numArray11[13] += 2;
      numArray11[15] += 4;
      mountData11.playerYOffsets = numArray11;
      mountData11.xOffset = 5;
      mountData11.bodyFrame = 3;
      mountData11.yOffset = 1;
      mountData11.playerHeadOffset = 31;
      mountData11.standingFrameCount = 1;
      mountData11.standingFrameDelay = 12;
      mountData11.standingFrameStart = 0;
      mountData11.runningFrameCount = 7;
      mountData11.runningFrameDelay = 15;
      mountData11.runningFrameStart = 1;
      mountData11.dashingFrameCount = 6;
      mountData11.dashingFrameDelay = 40;
      mountData11.dashingFrameStart = 9;
      mountData11.flyingFrameCount = 6;
      mountData11.flyingFrameDelay = 6;
      mountData11.flyingFrameStart = 1;
      mountData11.inAirFrameCount = 1;
      mountData11.inAirFrameDelay = 12;
      mountData11.inAirFrameStart = 15;
      mountData11.idleFrameCount = 0;
      mountData11.idleFrameDelay = 0;
      mountData11.idleFrameStart = 0;
      mountData11.idleFrameLoop = false;
      mountData11.swimFrameCount = mountData11.inAirFrameCount;
      mountData11.swimFrameDelay = mountData11.inAirFrameDelay;
      mountData11.swimFrameStart = mountData11.inAirFrameStart;
      if (Main.netMode != 2)
      {
        mountData11.backTexture = Main.unicornMountTexture;
        mountData11.backTextureExtra = (Texture2D) null;
        mountData11.frontTexture = (Texture2D) null;
        mountData11.frontTextureExtra = (Texture2D) null;
        mountData11.textureWidth = mountData11.backTexture.Width;
        mountData11.textureHeight = mountData11.backTexture.Height;
      }
      Mount.MountData mountData12 = new Mount.MountData();
      Mount.mounts[11] = mountData12;
      mountData12.Minecart = true;
      mountData12.MinecartDust = new Action<Vector2>(DelegateMethods.Minecart.SparksMech);
      mountData12.spawnDust = 213;
      mountData12.buff = 167;
      mountData12.extraBuff = 166;
      mountData12.heightBoost = 12;
      mountData12.flightTimeMax = 0;
      mountData12.fallDamage = 1f;
      mountData12.runSpeed = 20f;
      mountData12.dashSpeed = 20f;
      mountData12.acceleration = 0.1f;
      mountData12.jumpHeight = 15;
      mountData12.jumpSpeed = 5.15f;
      mountData12.blockExtraJumps = true;
      mountData12.totalFrames = 3;
      int[] numArray12 = new int[mountData12.totalFrames];
      for (int index = 0; index < numArray12.Length; ++index)
        numArray12[index] = 9;
      mountData12.playerYOffsets = numArray12;
      mountData12.xOffset = -1;
      mountData12.bodyFrame = 3;
      mountData12.yOffset = 11;
      mountData12.playerHeadOffset = 14;
      mountData12.standingFrameCount = 1;
      mountData12.standingFrameDelay = 12;
      mountData12.standingFrameStart = 0;
      mountData12.runningFrameCount = 3;
      mountData12.runningFrameDelay = 12;
      mountData12.runningFrameStart = 0;
      mountData12.flyingFrameCount = 0;
      mountData12.flyingFrameDelay = 0;
      mountData12.flyingFrameStart = 0;
      mountData12.inAirFrameCount = 0;
      mountData12.inAirFrameDelay = 0;
      mountData12.inAirFrameStart = 0;
      mountData12.idleFrameCount = 0;
      mountData12.idleFrameDelay = 0;
      mountData12.idleFrameStart = 0;
      mountData12.idleFrameLoop = false;
      if (Main.netMode != 2)
      {
        mountData12.backTexture = (Texture2D) null;
        mountData12.backTextureExtra = (Texture2D) null;
        mountData12.frontTexture = Main.minecartMechMountTexture[0];
        mountData12.frontTextureGlow = Main.minecartMechMountTexture[1];
        mountData12.frontTextureExtra = (Texture2D) null;
        mountData12.textureWidth = mountData12.frontTexture.Width;
        mountData12.textureHeight = mountData12.frontTexture.Height;
      }
      Mount.MountData mountData13 = new Mount.MountData();
      Mount.mounts[12] = mountData13;
      mountData13.spawnDust = 15;
      mountData13.buff = 168;
      mountData13.heightBoost = 14;
      mountData13.flightTimeMax = 320;
      mountData13.fatigueMax = 320;
      mountData13.fallDamage = 0.0f;
      mountData13.usesHover = true;
      mountData13.runSpeed = 2f;
      mountData13.dashSpeed = 1f;
      mountData13.acceleration = 0.2f;
      mountData13.jumpHeight = 4;
      mountData13.jumpSpeed = 3f;
      mountData13.swimSpeed = 16f;
      mountData13.blockExtraJumps = true;
      mountData13.totalFrames = 23;
      int[] numArray13 = new int[mountData13.totalFrames];
      for (int index = 0; index < numArray13.Length; ++index)
        numArray13[index] = 12;
      mountData13.playerYOffsets = numArray13;
      mountData13.xOffset = 2;
      mountData13.bodyFrame = 3;
      mountData13.yOffset = 16;
      mountData13.playerHeadOffset = 31;
      mountData13.standingFrameCount = 1;
      mountData13.standingFrameDelay = 12;
      mountData13.standingFrameStart = 8;
      mountData13.runningFrameCount = 7;
      mountData13.runningFrameDelay = 14;
      mountData13.runningFrameStart = 8;
      mountData13.flyingFrameCount = 8;
      mountData13.flyingFrameDelay = 16;
      mountData13.flyingFrameStart = 0;
      mountData13.inAirFrameCount = 8;
      mountData13.inAirFrameDelay = 6;
      mountData13.inAirFrameStart = 0;
      mountData13.idleFrameCount = 0;
      mountData13.idleFrameDelay = 0;
      mountData13.idleFrameStart = 0;
      mountData13.idleFrameLoop = false;
      mountData13.swimFrameCount = 8;
      mountData13.swimFrameDelay = 4;
      mountData13.swimFrameStart = 15;
      if (Main.netMode != 2)
      {
        mountData13.backTexture = Main.cuteFishronMountTexture[0];
        mountData13.backTextureGlow = Main.cuteFishronMountTexture[1];
        mountData13.frontTexture = (Texture2D) null;
        mountData13.frontTextureExtra = (Texture2D) null;
        mountData13.textureWidth = mountData13.backTexture.Width;
        mountData13.textureHeight = mountData13.backTexture.Height;
      }
      Mount.MountData mountData14 = new Mount.MountData();
      Mount.mounts[13] = mountData14;
      mountData14.Minecart = true;
      mountData14.MinecartDirectional = true;
      mountData14.MinecartDust = new Action<Vector2>(DelegateMethods.Minecart.Sparks);
      mountData14.spawnDust = 213;
      mountData14.buff = 184;
      mountData14.extraBuff = 185;
      mountData14.heightBoost = 10;
      mountData14.flightTimeMax = 0;
      mountData14.fallDamage = 1f;
      mountData14.runSpeed = 10f;
      mountData14.dashSpeed = 10f;
      mountData14.acceleration = 0.03f;
      mountData14.jumpHeight = 12;
      mountData14.jumpSpeed = 5.15f;
      mountData14.blockExtraJumps = true;
      mountData14.totalFrames = 3;
      int[] numArray14 = new int[mountData14.totalFrames];
      for (int index = 0; index < numArray14.Length; ++index)
        numArray14[index] = 8;
      mountData14.playerYOffsets = numArray14;
      mountData14.xOffset = 1;
      mountData14.bodyFrame = 3;
      mountData14.yOffset = 13;
      mountData14.playerHeadOffset = 14;
      mountData14.standingFrameCount = 1;
      mountData14.standingFrameDelay = 12;
      mountData14.standingFrameStart = 0;
      mountData14.runningFrameCount = 3;
      mountData14.runningFrameDelay = 12;
      mountData14.runningFrameStart = 0;
      mountData14.flyingFrameCount = 0;
      mountData14.flyingFrameDelay = 0;
      mountData14.flyingFrameStart = 0;
      mountData14.inAirFrameCount = 0;
      mountData14.inAirFrameDelay = 0;
      mountData14.inAirFrameStart = 0;
      mountData14.idleFrameCount = 0;
      mountData14.idleFrameDelay = 0;
      mountData14.idleFrameStart = 0;
      mountData14.idleFrameLoop = false;
      if (Main.netMode != 2)
      {
        mountData14.backTexture = (Texture2D) null;
        mountData14.backTextureExtra = (Texture2D) null;
        mountData14.frontTexture = Main.minecartWoodMountTexture;
        mountData14.frontTextureExtra = (Texture2D) null;
        mountData14.textureWidth = mountData14.frontTexture.Width;
        mountData14.textureHeight = mountData14.frontTexture.Height;
      }
      Mount.MountData mountData15 = new Mount.MountData();
      Mount.mounts[14] = mountData15;
      mountData15.spawnDust = 15;
      mountData15.buff = 193;
      mountData15.heightBoost = 8;
      mountData15.flightTimeMax = 0;
      mountData15.fallDamage = 0.2f;
      mountData15.runSpeed = 8f;
      mountData15.acceleration = 0.25f;
      mountData15.jumpHeight = 20;
      mountData15.jumpSpeed = 8.01f;
      mountData15.totalFrames = 8;
      int[] numArray15 = new int[mountData15.totalFrames];
      for (int index = 0; index < numArray15.Length; ++index)
        numArray15[index] = 8;
      numArray15[1] += 2;
      numArray15[3] += 2;
      numArray15[6] += 2;
      mountData15.playerYOffsets = numArray15;
      mountData15.xOffset = 4;
      mountData15.bodyFrame = 3;
      mountData15.yOffset = 9;
      mountData15.playerHeadOffset = 10;
      mountData15.standingFrameCount = 1;
      mountData15.standingFrameDelay = 12;
      mountData15.standingFrameStart = 0;
      mountData15.runningFrameCount = 6;
      mountData15.runningFrameDelay = 30;
      mountData15.runningFrameStart = 2;
      mountData15.inAirFrameCount = 1;
      mountData15.inAirFrameDelay = 12;
      mountData15.inAirFrameStart = 1;
      mountData15.idleFrameCount = 0;
      mountData15.idleFrameDelay = 0;
      mountData15.idleFrameStart = 0;
      mountData15.idleFrameLoop = false;
      mountData15.swimFrameCount = mountData15.inAirFrameCount;
      mountData15.swimFrameDelay = mountData15.inAirFrameDelay;
      mountData15.swimFrameStart = mountData15.inAirFrameStart;
      if (Main.netMode == 2)
        return;
      mountData15.backTexture = Main.basiliskMountTexture;
      mountData15.backTextureExtra = (Texture2D) null;
      mountData15.frontTexture = (Texture2D) null;
      mountData15.frontTextureExtra = (Texture2D) null;
      mountData15.textureWidth = mountData15.backTexture.Width;
      mountData15.textureHeight = mountData15.backTexture.Height;
    }

    public bool Active => this._active;

    public int Type => this._type;

    public int FlyTime => this._flyTime;

    public int BuffType => this._data.buff;

    public int BodyFrame => this._data.bodyFrame;

    public int XOffset => this._data.xOffset;

    public int YOffset => this._data.yOffset;

    public int PlayerOffset => !this._active ? 0 : this._data.playerYOffsets[this._frame];

    public int PlayerOffsetHitbox => !this._active ? 0 : this._data.playerYOffsets[0] - this._data.playerYOffsets[this._frame] + this._data.playerYOffsets[0] / 4;

    public int PlayerHeadOffset => !this._active ? 0 : this._data.playerHeadOffset;

    public int HeightBoost => this._data.heightBoost;

    public static int GetHeightBoost(int MountType) => MountType <= -1 || MountType >= 15 ? 0 : Mount.mounts[MountType].heightBoost;

    public float RunSpeed
    {
      get
      {
        if (this._type == 4 && this._frameState == 4 || this._type == 12 && this._frameState == 4)
          return this._data.swimSpeed;
        if (this._type == 12 && this._frameState == 2)
          return this._data.runSpeed + 11f;
        return this._type == 5 && this._frameState == 2 ? this._data.runSpeed + (float) (4.0 * (1.0 - (double) (this._fatigue / this._fatigueMax))) : this._data.runSpeed;
      }
    }

    public float DashSpeed => this._data.dashSpeed;

    public float Acceleration => this._data.acceleration;

    public float FallDamage => this._data.fallDamage;

    public int JumpHeight(float xVelocity)
    {
      int jumpHeight = this._data.jumpHeight;
      switch (this._type)
      {
        case 0:
          jumpHeight += (int) ((double) Math.Abs(xVelocity) / 4.0);
          break;
        case 1:
          jumpHeight += (int) ((double) Math.Abs(xVelocity) / 2.5);
          break;
        case 4:
          if (this._frameState == 4)
          {
            jumpHeight += 5;
            break;
          }
          break;
      }
      return jumpHeight;
    }

    public float JumpSpeed(float xVelocity)
    {
      float jumpSpeed = this._data.jumpSpeed;
      switch (this._type)
      {
        case 0:
        case 1:
          jumpSpeed += Math.Abs(xVelocity) / 7f;
          break;
        case 4:
          if (this._frameState == 4)
          {
            jumpSpeed += 2.5f;
            break;
          }
          break;
      }
      return jumpSpeed;
    }

    public bool AutoJump => this._data.constantJump;

    public bool BlockExtraJumps => this._data.blockExtraJumps;

    public bool Cart => this._data != null && this._active && this._data.Minecart;

    public bool Directional => this._data == null || this._data.MinecartDirectional;

    public Action<Vector2> MinecartDust => this._data == null ? new Action<Vector2>(DelegateMethods.Minecart.Sparks) : this._data.MinecartDust;

    public Vector2 Origin => new Vector2((float) this._data.textureWidth / 2f, (float) this._data.textureHeight / (2f * (float) this._data.totalFrames));

    public bool CanFly => this._active && this._data.flightTimeMax != 0;

    public bool CanHover => this._active && this._data.usesHover;

    public bool AbilityReady => this._abilityCooldown == 0;

    public bool AbilityCharging => this._abilityCharging;

    public bool AbilityActive => this._abilityActive;

    public float AbilityCharge => (float) this._abilityCharge / (float) this._data.abilityChargeMax;

    public void StartAbilityCharge(Player mountedPlayer)
    {
      if (Main.myPlayer == mountedPlayer.whoAmI)
      {
        if (this._type != 9)
          return;
        double num = (double) Main.screenPosition.X + (double) Main.mouseX;
        float Y = Main.screenPosition.Y + (float) Main.mouseY;
        float ai0 = (float) num - mountedPlayer.position.X;
        float ai1 = Y - mountedPlayer.position.Y;
        Projectile.NewProjectile((float) num, Y, 0.0f, 0.0f, 441, 0, 0.0f, mountedPlayer.whoAmI, ai0, ai1);
        this._abilityCharging = true;
      }
      else
      {
        if (this._type != 9)
          return;
        this._abilityCharging = true;
      }
    }

    public void StopAbilityCharge()
    {
      if (this._type != 9)
        return;
      this._abilityCharging = false;
      this._abilityCooldown = this._data.abilityCooldown;
      this._abilityDuration = this._data.abilityDuration;
    }

    public bool CheckBuff(int buffID) => this._data.buff == buffID || this._data.extraBuff == buffID;

    public void AbilityRecovery()
    {
      if (this._abilityCharging)
      {
        if (this._abilityCharge < this._data.abilityChargeMax)
          ++this._abilityCharge;
      }
      else if (this._abilityCharge > 0)
        --this._abilityCharge;
      if (this._abilityCooldown > 0)
        --this._abilityCooldown;
      if (this._abilityDuration <= 0)
        return;
      --this._abilityDuration;
    }

    public void FatigueRecovery()
    {
      if ((double) this._fatigue > 2.0)
        this._fatigue -= 2f;
      else
        this._fatigue = 0.0f;
    }

    public bool Flight()
    {
      if (this._flyTime <= 0)
        return false;
      --this._flyTime;
      return true;
    }

    public bool AllowDirectionChange => this._type != 9 || this._abilityCooldown < this._data.abilityCooldown / 2;

    public void UpdateDrill(Player mountedPlayer, bool controlUp, bool controlDown)
    {
      Mount.DrillMountData mountSpecificData = (Mount.DrillMountData) this._mountSpecificData;
      for (int index = 0; index < mountSpecificData.beams.Length; ++index)
      {
        Mount.DrillBeam beam = mountSpecificData.beams[index];
        if (beam.cooldown > 1)
          --beam.cooldown;
        else if (beam.cooldown == 1)
        {
          beam.cooldown = 0;
          beam.curTileTarget = Point16.NegativeOne;
        }
      }
      mountSpecificData.diodeRotation = (float) ((double) mountSpecificData.diodeRotation * 0.850000023841858 + 0.150000005960464 * (double) mountSpecificData.diodeRotationTarget);
      if (mountSpecificData.beamCooldown <= 0)
        return;
      --mountSpecificData.beamCooldown;
    }

    public void UseDrill(Player mountedPlayer)
    {
      if (this._type != 8 || !this._abilityActive)
        return;
      Mount.DrillMountData mountSpecificData = (Mount.DrillMountData) this._mountSpecificData;
      if (mountSpecificData.beamCooldown != 0)
        return;
      for (int index1 = 0; index1 < mountSpecificData.beams.Length; ++index1)
      {
        Mount.DrillBeam beam = mountSpecificData.beams[index1];
        if (beam.cooldown == 0)
        {
          Point16 point16 = this.DrillSmartCursor(mountedPlayer, mountSpecificData);
          if (point16 != Point16.NegativeOne)
          {
            beam.curTileTarget = point16;
            int drillPickPower = Mount.drillPickPower;
            bool flag1 = mountedPlayer.whoAmI == Main.myPlayer;
            if (flag1)
            {
              bool flag2 = true;
              if (WorldGen.InWorld((int) point16.X, (int) point16.Y) && Main.tile[(int) point16.X, (int) point16.Y] != null && Main.tile[(int) point16.X, (int) point16.Y].type == (ushort) 26 && !Main.hardMode)
              {
                flag2 = false;
                mountedPlayer.Hurt(PlayerDeathReason.ByOther(4), mountedPlayer.statLife / 2, -mountedPlayer.direction);
              }
              if (mountedPlayer.noBuilding)
                flag2 = false;
              if (flag2)
                mountedPlayer.PickTile((int) point16.X, (int) point16.Y, drillPickPower);
            }
            Vector2 Position = new Vector2((float) ((int) point16.X << 4) + 8f, (float) ((int) point16.Y << 4) + 8f);
            float rotation = (Position - mountedPlayer.Center).ToRotation();
            for (int index2 = 0; index2 < 2; ++index2)
            {
              float num1 = rotation + (float) ((Main.rand.Next(2) == 1 ? -1.0 : 1.0) * 1.57079637050629);
              float num2 = (float) (Main.rand.NextDouble() * 2.0 + 2.0);
              Vector2 vector2 = new Vector2((float) Math.Cos((double) num1) * num2, (float) Math.Sin((double) num1) * num2);
              int index3 = Dust.NewDust(Position, 0, 0, 230, vector2.X, vector2.Y);
              Main.dust[index3].noGravity = true;
              Main.dust[index3].customData = (object) mountedPlayer;
            }
            if (flag1)
              Tile.SmoothSlope((int) point16.X, (int) point16.Y);
            beam.cooldown = Mount.drillPickTime;
            break;
          }
          break;
        }
      }
      mountSpecificData.beamCooldown = Mount.drillBeamCooldownMax;
    }

    private Point16 DrillSmartCursor(Player mountedPlayer, Mount.DrillMountData data)
    {
      Vector2 vector2_1 = mountedPlayer.whoAmI != Main.myPlayer ? data.crosshairPosition : Main.screenPosition + new Vector2((float) Main.mouseX, (float) Main.mouseY);
      Vector2 center = mountedPlayer.Center;
      Vector2 vector2_2 = vector2_1 - center;
      float num1 = vector2_2.Length();
      if ((double) num1 > 224.0)
        num1 = 224f;
      float num2 = num1 + 32f;
      vector2_2.Normalize();
      Vector2 start = center;
      Vector2 vector2_3 = center + vector2_2 * num2;
      Point16 tilePoint = new Point16(-1, -1);
      Vector2 end = vector2_3;
      Utils.PerLinePoint plot = (Utils.PerLinePoint) ((x, y) =>
      {
        tilePoint = new Point16(x, y);
        for (int index = 0; index < data.beams.Length; ++index)
        {
          if (data.beams[index].curTileTarget == tilePoint)
            return true;
        }
        return !WorldGen.CanKillTile(x, y) || Main.tile[x, y] == null || Main.tile[x, y].inActive() || !Main.tile[x, y].active();
      });
      return !Utils.PlotTileLine(start, end, 65.6f, plot) ? tilePoint : new Point16(-1, -1);
    }

    public void UseAbility(Player mountedPlayer, Vector2 mousePosition, bool toggleOn)
    {
      switch (this._type)
      {
        case 8:
          if (Main.myPlayer == mountedPlayer.whoAmI)
          {
            if (!toggleOn)
            {
              this._abilityActive = false;
              break;
            }
            if (this._abilityActive)
              break;
            if (mountedPlayer.whoAmI == Main.myPlayer)
            {
              double num = (double) Main.screenPosition.X + (double) Main.mouseX;
              float Y = Main.screenPosition.Y + (float) Main.mouseY;
              float ai0 = (float) num - mountedPlayer.position.X;
              float ai1 = Y - mountedPlayer.position.Y;
              Projectile.NewProjectile((float) num, Y, 0.0f, 0.0f, 453, 0, 0.0f, mountedPlayer.whoAmI, ai0, ai1);
            }
            this._abilityActive = true;
            break;
          }
          this._abilityActive = toggleOn;
          break;
        case 9:
          if (Main.myPlayer != mountedPlayer.whoAmI)
            break;
          mousePosition = this.ClampToDeadZone(mountedPlayer, mousePosition);
          Vector2 vector2_1;
          vector2_1.X = mountedPlayer.position.X + (float) (mountedPlayer.width / 2);
          vector2_1.Y = mountedPlayer.position.Y + (float) mountedPlayer.height;
          int num1 = (this._frameExtra - 6) * 2;
          for (int index = 0; index < 2; ++index)
          {
            Vector2 vector2_2;
            vector2_2.Y = vector2_1.Y + Mount.scutlixEyePositions[num1 + index].Y + (float) this._data.yOffset;
            vector2_2.X = mountedPlayer.direction != -1 ? vector2_1.X + Mount.scutlixEyePositions[num1 + index].X + (float) this._data.xOffset : vector2_1.X - Mount.scutlixEyePositions[num1 + index].X - (float) this._data.xOffset;
            Vector2 vector2_3 = mousePosition - vector2_2;
            vector2_3.Normalize();
            Vector2 vector2_4 = vector2_3 * 14f;
            int Damage = 100;
            vector2_2 += vector2_4;
            Projectile.NewProjectile(vector2_2.X, vector2_2.Y, vector2_4.X, vector2_4.Y, 606, Damage, 0.0f, Main.myPlayer);
          }
          break;
      }
    }

    public bool Hover(Player mountedPlayer)
    {
      if (this._frameState == 2 || this._frameState == 4)
      {
        bool flag = true;
        float num1 = 1f;
        float num2 = mountedPlayer.gravity / Player.defaultGravity;
        if (mountedPlayer.slowFall)
          num2 /= 3f;
        if ((double) num2 < 0.25)
          num2 = 0.25f;
        if (this._type != 7 && this._type != 8 && this._type != 12)
        {
          if (this._flyTime > 0)
            --this._flyTime;
          else if ((double) this._fatigue < (double) this._fatigueMax)
            this._fatigue += num2;
          else
            flag = false;
        }
        if (this._type == 12 && !mountedPlayer.MountFishronSpecial)
          num1 = 0.5f;
        float num3 = this._fatigue / this._fatigueMax;
        if (this._type == 7 || this._type == 8 || this._type == 12)
          num3 = 0.0f;
        float num4 = 4f * num3;
        float num5 = 4f * num3;
        if ((double) num4 == 0.0)
          num4 = -1f / 1000f;
        if ((double) num5 == 0.0)
          num5 = -1f / 1000f;
        float num6 = mountedPlayer.velocity.Y;
        if (((mountedPlayer.controlUp ? 1 : (mountedPlayer.controlJump ? 1 : 0)) & (flag ? 1 : 0)) != 0)
        {
          num4 = (float) (-2.0 - 6.0 * (1.0 - (double) num3));
          num6 -= this._data.acceleration * num1;
        }
        else if (mountedPlayer.controlDown)
        {
          num6 += this._data.acceleration * num1;
          num5 = 8f;
        }
        else
        {
          int jump = mountedPlayer.jump;
        }
        if ((double) num6 < (double) num4)
        {
          if ((double) num4 - (double) num6 < (double) this._data.acceleration)
            num6 = num4;
          else
            num6 += this._data.acceleration * num1;
        }
        else if ((double) num6 > (double) num5)
        {
          if ((double) num6 - (double) num5 < (double) this._data.acceleration)
            num6 = num5;
          else
            num6 -= this._data.acceleration * num1;
        }
        mountedPlayer.velocity.Y = num6;
        mountedPlayer.fallStart = (int) ((double) mountedPlayer.position.Y / 16.0);
      }
      else if (this._type != 7 && this._type != 8 && this._type != 12)
        mountedPlayer.velocity.Y += mountedPlayer.gravity * mountedPlayer.gravDir;
      else if ((double) mountedPlayer.velocity.Y == 0.0)
        mountedPlayer.velocity.Y = 1f / 1000f;
      if (this._type == 7)
      {
        float num7 = mountedPlayer.velocity.X / this._data.dashSpeed;
        if ((double) num7 > 0.95)
          num7 = 0.95f;
        if ((double) num7 < -0.95)
          num7 = -0.95f;
        float num8 = (float) (0.785398185253143 * (double) num7 / 2.0);
        float num9 = Math.Abs((float) (2.0 - (double) this._frame / 2.0)) / 2f;
        Lighting.AddLight((int) ((double) mountedPlayer.position.X + (double) (mountedPlayer.width / 2)) / 16, (int) ((double) mountedPlayer.position.Y + (double) (mountedPlayer.height / 2)) / 16, 0.4f, 0.2f * num9, 0.0f);
        mountedPlayer.fullRotation = num8;
      }
      else if (this._type == 8)
      {
        float num10 = mountedPlayer.velocity.X / this._data.dashSpeed;
        if ((double) num10 > 0.95)
          num10 = 0.95f;
        if ((double) num10 < -0.95)
          num10 = -0.95f;
        float num11 = (float) (0.785398185253143 * (double) num10 / 2.0);
        mountedPlayer.fullRotation = num11;
        Mount.DrillMountData mountSpecificData = (Mount.DrillMountData) this._mountSpecificData;
        float num12 = mountSpecificData.outerRingRotation + mountedPlayer.velocity.X / 80f;
        if ((double) num12 > 3.14159274101257)
          num12 -= 6.283185f;
        else if ((double) num12 < -3.14159274101257)
          num12 += 6.283185f;
        mountSpecificData.outerRingRotation = num12;
      }
      return true;
    }

    public void UpdateFrame(Player mountedPlayer, int state, Vector2 velocity)
    {
      if (this._frameState != state)
      {
        this._frameState = state;
        this._frameCounter = 0.0f;
      }
      if (state != 0)
        this._idleTime = 0;
      if (this._data.emitsLight)
      {
        Point tileCoordinates = mountedPlayer.Center.ToTileCoordinates();
        Lighting.AddLight(tileCoordinates.X, tileCoordinates.Y, this._data.lightColor.X, this._data.lightColor.Y, this._data.lightColor.Z);
      }
      switch (this._type)
      {
        case 5:
          if (state != 2)
          {
            this._frameExtra = 0;
            this._frameExtraCounter = 0.0f;
            break;
          }
          break;
        case 7:
          state = 2;
          break;
        case 8:
          if (state == 0 || state == 1)
          {
            Vector2 position;
            position.X = mountedPlayer.position.X;
            position.Y = mountedPlayer.position.Y + (float) mountedPlayer.height;
            int num1 = (int) ((double) position.X / 16.0);
            double num2 = (double) position.Y / 16.0;
            float num3 = 0.0f;
            float width = (float) mountedPlayer.width;
            while ((double) width > 0.0)
            {
              float num4 = (float) ((num1 + 1) * 16) - position.X;
              if ((double) num4 > (double) width)
                num4 = width;
              num3 += Collision.GetTileRotation(position) * num4;
              width -= num4;
              position.X += num4;
              ++num1;
            }
            float num5 = num3 / (float) mountedPlayer.width - mountedPlayer.fullRotation;
            float num6 = 0.0f;
            float num7 = 0.1570796f;
            if ((double) num5 < 0.0)
              num6 = (double) num5 <= -(double) num7 ? -num7 : num5;
            else if ((double) num5 > 0.0)
              num6 = (double) num5 >= (double) num7 ? num7 : num5;
            if ((double) num6 != 0.0)
            {
              mountedPlayer.fullRotation += num6;
              if ((double) mountedPlayer.fullRotation > 0.785398185253143)
                mountedPlayer.fullRotation = 0.7853982f;
              if ((double) mountedPlayer.fullRotation < -0.785398185253143)
              {
                mountedPlayer.fullRotation = -0.7853982f;
                break;
              }
              break;
            }
            break;
          }
          break;
        case 9:
          if (!this._aiming)
          {
            ++this._frameExtraCounter;
            if ((double) this._frameExtraCounter >= 12.0)
            {
              this._frameExtraCounter = 0.0f;
              ++this._frameExtra;
              if (this._frameExtra >= 6)
              {
                this._frameExtra = 0;
                break;
              }
              break;
            }
            break;
          }
          break;
        case 10:
          bool flag1 = (double) Math.Abs(velocity.X) > (double) this.DashSpeed - (double) this.RunSpeed / 2.0;
          if (state == 1)
          {
            bool flag2 = false;
            if (flag1)
            {
              state = 5;
              if (this._frameExtra < 6)
                flag2 = true;
              ++this._frameExtra;
            }
            else
              this._frameExtra = 0;
            if (flag2)
            {
              Vector2 Position = mountedPlayer.Center + new Vector2((float) (mountedPlayer.width * mountedPlayer.direction), 0.0f);
              Vector2 vector2_1 = new Vector2(40f, 30f);
              float num8 = 6.283185f * Main.rand.NextFloat();
              for (float num9 = 0.0f; (double) num9 < 14.0; ++num9)
              {
                Dust dust = Main.dust[Dust.NewDust(Position, 0, 0, Utils.SelectRandom<int>(Main.rand, 176, 177, 179))];
                Vector2 vector2_2 = Vector2.UnitY.RotatedBy((double) num9 * 6.28318548202515 / 14.0 + (double) num8) * (0.2f * (float) this._frameExtra);
                dust.position = Position + vector2_2 * vector2_1;
                dust.velocity = vector2_2 + new Vector2(this.RunSpeed - (float) (Math.Sign(velocity.X) * this._frameExtra * 2), 0.0f);
                dust.noGravity = true;
                dust.scale = (float) (1.0 + (double) Main.rand.NextFloat() * 0.800000011920929);
                dust.fadeIn = Main.rand.NextFloat() * 2f;
                dust.shader = GameShaders.Armor.GetSecondaryShader(mountedPlayer.cMount, mountedPlayer);
              }
            }
          }
          if (flag1)
          {
            Dust dust = Main.dust[Dust.NewDust(mountedPlayer.position, mountedPlayer.width, mountedPlayer.height, Utils.SelectRandom<int>(Main.rand, 176, 177, 179))];
            dust.velocity = Vector2.Zero;
            dust.noGravity = true;
            dust.scale = (float) (0.5 + (double) Main.rand.NextFloat() * 0.800000011920929);
            dust.fadeIn = (float) (1.0 + (double) Main.rand.NextFloat() * 2.0);
            dust.shader = GameShaders.Armor.GetSecondaryShader(mountedPlayer.cMount, mountedPlayer);
            break;
          }
          break;
        case 14:
          int num10 = (double) Math.Abs(velocity.X) > (double) this.RunSpeed / 2.0 ? 1 : 0;
          float num11 = (float) Math.Sign(mountedPlayer.velocity.X);
          float y = 12f;
          float num12 = 40f;
          mountedPlayer.basiliskCharge = num10 != 0 ? Utils.Clamp<float>(mountedPlayer.basiliskCharge + 0.005555556f, 0.0f, 1f) : 0.0f;
          if ((double) mountedPlayer.position.Y > Main.worldSurface * 16.0 + 160.0)
            Lighting.AddLight(mountedPlayer.Center, 0.5f, 0.1f, 0.1f);
          if (num10 != 0 && (double) velocity.Y == 0.0)
          {
            for (int index = 0; index < 2; ++index)
            {
              Dust dust = Main.dust[Dust.NewDust(mountedPlayer.BottomLeft, mountedPlayer.width, 6, 31)];
              dust.velocity = new Vector2(velocity.X * 0.15f, Main.rand.NextFloat() * -2f);
              dust.noLight = true;
              dust.scale = (float) (0.5 + (double) Main.rand.NextFloat() * 0.800000011920929);
              dust.fadeIn = (float) (0.5 + (double) Main.rand.NextFloat() * 1.0);
              dust.shader = GameShaders.Armor.GetSecondaryShader(mountedPlayer.cMount, mountedPlayer);
            }
            if (mountedPlayer.cMount == 0)
            {
              Player player1 = mountedPlayer;
              player1.position = player1.position + new Vector2(num11 * 24f, 0.0f);
              mountedPlayer.FloorVisuals(true);
              Player player2 = mountedPlayer;
              player2.position = player2.position - new Vector2(num11 * 24f, 0.0f);
            }
          }
          if ((double) num11 == (double) mountedPlayer.direction)
          {
            for (int index = 0; index < (int) (3.0 * (double) mountedPlayer.basiliskCharge); ++index)
            {
              Dust dust = Main.dust[Dust.NewDust(mountedPlayer.BottomLeft, mountedPlayer.width, 6, 6)];
              Vector2 vector2 = mountedPlayer.Center + new Vector2(num11 * num12, y);
              dust.position = mountedPlayer.Center + new Vector2(num11 * (num12 - 2f), (float) ((double) y - 6.0 + (double) Main.rand.NextFloat() * 12.0));
              dust.velocity = (dust.position - vector2).SafeNormalize(Vector2.Zero) * (float) (3.5 + (double) Main.rand.NextFloat() * 0.5);
              if ((double) dust.velocity.Y < 0.0)
                dust.velocity.Y *= (float) (1.0 + 2.0 * (double) Main.rand.NextFloat());
              dust.velocity += mountedPlayer.velocity * 0.55f;
              dust.velocity *= mountedPlayer.velocity.Length() / this.RunSpeed;
              dust.velocity *= mountedPlayer.basiliskCharge;
              dust.noGravity = true;
              dust.noLight = true;
              dust.scale = (float) (0.5 + (double) Main.rand.NextFloat() * 0.800000011920929);
              dust.fadeIn = (float) (0.5 + (double) Main.rand.NextFloat() * 1.0);
              dust.shader = GameShaders.Armor.GetSecondaryShader(mountedPlayer.cMount, mountedPlayer);
            }
            break;
          }
          break;
      }
      switch (state)
      {
        case 0:
          if (this._data.idleFrameCount != 0)
          {
            if (this._type == 5)
            {
              if ((double) this._fatigue != 0.0)
              {
                if (this._idleTime == 0)
                  this._idleTimeNext = this._idleTime + 1;
              }
              else
              {
                this._idleTime = 0;
                this._idleTimeNext = 2;
              }
            }
            else if (this._idleTime == 0)
              this._idleTimeNext = Main.rand.Next(900, 1500);
            ++this._idleTime;
          }
          ++this._frameCounter;
          if (this._data.idleFrameCount != 0 && this._idleTime >= this._idleTimeNext)
          {
            float idleFrameDelay = (float) this._data.idleFrameDelay;
            if (this._type == 5)
              idleFrameDelay *= (float) (2.0 - 1.0 * (double) this._fatigue / (double) this._fatigueMax);
            int num13 = (int) ((double) (this._idleTime - this._idleTimeNext) / (double) idleFrameDelay);
            if (num13 >= this._data.idleFrameCount)
            {
              if (this._data.idleFrameLoop)
              {
                this._idleTime = this._idleTimeNext;
                this._frame = this._data.idleFrameStart;
              }
              else
              {
                this._frameCounter = 0.0f;
                this._frame = this._data.standingFrameStart;
                this._idleTime = 0;
              }
            }
            else
              this._frame = this._data.idleFrameStart + num13;
            if (this._type != 5)
              break;
            this._frameExtra = this._frame;
            break;
          }
          if ((double) this._frameCounter > (double) this._data.standingFrameDelay)
          {
            this._frameCounter -= (float) this._data.standingFrameDelay;
            ++this._frame;
          }
          if (this._frame >= this._data.standingFrameStart && this._frame < this._data.standingFrameStart + this._data.standingFrameCount)
            break;
          this._frame = this._data.standingFrameStart;
          break;
        case 1:
          float num14;
          switch (this._type)
          {
            case 6:
              num14 = this._flipDraw ? velocity.X : -velocity.X;
              break;
            case 9:
              num14 = !this._flipDraw ? Math.Abs(velocity.X) : -Math.Abs(velocity.X);
              break;
            case 13:
              num14 = this._flipDraw ? velocity.X : -velocity.X;
              break;
            default:
              num14 = Math.Abs(velocity.X);
              break;
          }
          this._frameCounter += num14;
          if ((double) num14 >= 0.0)
          {
            if ((double) this._frameCounter > (double) this._data.runningFrameDelay)
            {
              this._frameCounter -= (float) this._data.runningFrameDelay;
              ++this._frame;
            }
            if (this._frame >= this._data.runningFrameStart && this._frame < this._data.runningFrameStart + this._data.runningFrameCount)
              break;
            this._frame = this._data.runningFrameStart;
            break;
          }
          if ((double) this._frameCounter < 0.0)
          {
            this._frameCounter += (float) this._data.runningFrameDelay;
            --this._frame;
          }
          if (this._frame >= this._data.runningFrameStart && this._frame < this._data.runningFrameStart + this._data.runningFrameCount)
            break;
          this._frame = this._data.runningFrameStart + this._data.runningFrameCount - 1;
          break;
        case 2:
          ++this._frameCounter;
          if ((double) this._frameCounter > (double) this._data.inAirFrameDelay)
          {
            this._frameCounter -= (float) this._data.inAirFrameDelay;
            ++this._frame;
          }
          if (this._frame < this._data.inAirFrameStart || this._frame >= this._data.inAirFrameStart + this._data.inAirFrameCount)
            this._frame = this._data.inAirFrameStart;
          if (this._type == 4)
          {
            if ((double) velocity.Y < 0.0)
            {
              this._frame = 3;
              break;
            }
            this._frame = 6;
            break;
          }
          if (this._type != 5)
            break;
          this._frameExtraCounter += (float) (6.0 - 4.0 * (double) (this._fatigue / this._fatigueMax));
          if ((double) this._frameExtraCounter > (double) this._data.flyingFrameDelay)
          {
            ++this._frameExtra;
            this._frameExtraCounter -= (float) this._data.flyingFrameDelay;
          }
          if (this._frameExtra >= this._data.flyingFrameStart && this._frameExtra < this._data.flyingFrameStart + this._data.flyingFrameCount)
            break;
          this._frameExtra = this._data.flyingFrameStart;
          break;
        case 3:
          ++this._frameCounter;
          if ((double) this._frameCounter > (double) this._data.flyingFrameDelay)
          {
            this._frameCounter -= (float) this._data.flyingFrameDelay;
            ++this._frame;
          }
          if (this._frame >= this._data.flyingFrameStart && this._frame < this._data.flyingFrameStart + this._data.flyingFrameCount)
            break;
          this._frame = this._data.flyingFrameStart;
          break;
        case 4:
          this._frameCounter += (float) (int) (((double) Math.Abs(velocity.X) + (double) Math.Abs(velocity.Y)) / 2.0);
          if ((double) this._frameCounter > (double) this._data.swimFrameDelay)
          {
            this._frameCounter -= (float) this._data.swimFrameDelay;
            ++this._frame;
          }
          if (this._frame >= this._data.swimFrameStart && this._frame < this._data.swimFrameStart + this._data.swimFrameCount)
            break;
          this._frame = this._data.swimFrameStart;
          break;
        case 5:
          float num15;
          switch (this._type)
          {
            case 6:
              num15 = this._flipDraw ? velocity.X : -velocity.X;
              break;
            case 9:
              num15 = !this._flipDraw ? Math.Abs(velocity.X) : -Math.Abs(velocity.X);
              break;
            case 13:
              num15 = this._flipDraw ? velocity.X : -velocity.X;
              break;
            default:
              num15 = Math.Abs(velocity.X);
              break;
          }
          this._frameCounter += num15;
          if ((double) num15 >= 0.0)
          {
            if ((double) this._frameCounter > (double) this._data.dashingFrameDelay)
            {
              this._frameCounter -= (float) this._data.dashingFrameDelay;
              ++this._frame;
            }
            if (this._frame >= this._data.dashingFrameStart && this._frame < this._data.dashingFrameStart + this._data.dashingFrameCount)
              break;
            this._frame = this._data.dashingFrameStart;
            break;
          }
          if ((double) this._frameCounter < 0.0)
          {
            this._frameCounter += (float) this._data.dashingFrameDelay;
            --this._frame;
          }
          if (this._frame >= this._data.dashingFrameStart && this._frame < this._data.dashingFrameStart + this._data.dashingFrameCount)
            break;
          this._frame = this._data.dashingFrameStart + this._data.dashingFrameCount - 1;
          break;
      }
    }

    public void UpdateEffects(Player mountedPlayer)
    {
      mountedPlayer.autoJump = this.AutoJump;
      switch (this._type)
      {
        case 8:
          if (mountedPlayer.ownedProjectileCounts[453] >= 1)
            break;
          this._abilityActive = false;
          break;
        case 9:
          Vector2 center = mountedPlayer.Center;
          Vector2 mousePosition = center;
          bool flag1 = false;
          float num1 = 1500f;
          for (int index = 0; index < 200; ++index)
          {
            NPC npc = Main.npc[index];
            if (npc.CanBeChasedBy((object) this))
            {
              Vector2 v = npc.Center - center;
              float num2 = v.Length();
              if ((double) Vector2.Distance(mousePosition, center) > (double) num2 && (double) num2 < (double) num1 || !flag1)
              {
                bool flag2 = true;
                float num3 = Math.Abs(v.ToRotation());
                if (mountedPlayer.direction == 1 && (double) num3 > 1.04719759490799)
                  flag2 = false;
                else if (mountedPlayer.direction == -1 && (double) num3 < 2.09439514610459)
                  flag2 = false;
                if (Collision.CanHitLine(center, 0, 0, npc.position, npc.width, npc.height) & flag2)
                {
                  num1 = num2;
                  mousePosition = npc.Center;
                  flag1 = true;
                }
              }
            }
          }
          if (flag1)
          {
            if (this._abilityCooldown == 0 && mountedPlayer.whoAmI == Main.myPlayer)
            {
              this.AimAbility(mountedPlayer, mousePosition);
              this.StopAbilityCharge();
              this.UseAbility(mountedPlayer, mousePosition, false);
              break;
            }
            this.AimAbility(mountedPlayer, mousePosition);
            this._abilityCharging = true;
            break;
          }
          this._abilityCharging = false;
          this.ResetHeadPosition();
          break;
        case 10:
          mountedPlayer.doubleJumpUnicorn = true;
          if ((double) Math.Abs(mountedPlayer.velocity.X) > (double) mountedPlayer.mount.DashSpeed - (double) mountedPlayer.mount.RunSpeed / 2.0)
            mountedPlayer.noKnockback = true;
          if (mountedPlayer.itemAnimation <= 0 || mountedPlayer.inventory[mountedPlayer.selectedItem].type != 1260)
            break;
          AchievementsHelper.HandleSpecialEvent(mountedPlayer, 5);
          break;
        case 11:
          Vector3 vector3_1 = new Vector3(0.4f, 0.12f, 0.15f);
          float num4 = (float) (1.0 + (double) Math.Abs(mountedPlayer.velocity.X) / (double) this.RunSpeed * 2.5);
          mountedPlayer.statDefense += (int) (2.0 * (double) num4);
          int num5 = Math.Sign(mountedPlayer.velocity.X);
          if (num5 == 0)
            num5 = mountedPlayer.direction;
          if (Main.netMode != 2)
          {
            Vector3 vector3_2 = vector3_1 * num4;
            Lighting.AddLight(mountedPlayer.Center, vector3_2.X, vector3_2.Y, vector3_2.Z);
            Lighting.AddLight(mountedPlayer.Top, vector3_2.X, vector3_2.Y, vector3_2.Z);
            Lighting.AddLight(mountedPlayer.Bottom, vector3_2.X, vector3_2.Y, vector3_2.Z);
            Lighting.AddLight(mountedPlayer.Left, vector3_2.X, vector3_2.Y, vector3_2.Z);
            Lighting.AddLight(mountedPlayer.Right, vector3_2.X, vector3_2.Y, vector3_2.Z);
            float num6 = -24f;
            if (mountedPlayer.direction != num5)
              num6 = -22f;
            if (num5 == -1)
              ++num6;
            Vector2 vector2_1 = new Vector2(num6 * (float) num5, -19f).RotatedBy((double) mountedPlayer.fullRotation);
            Vector2 vector2_2 = new Vector2(MathHelper.Lerp(0.0f, -8f, mountedPlayer.fullRotation / 0.7853982f), MathHelper.Lerp(0.0f, 2f, Math.Abs(mountedPlayer.fullRotation / 0.7853982f))).RotatedBy((double) mountedPlayer.fullRotation);
            if (num5 == Math.Sign(mountedPlayer.fullRotation))
              vector2_2 *= MathHelper.Lerp(1f, 0.6f, Math.Abs(mountedPlayer.fullRotation / 0.7853982f));
            Vector2 vector2_3 = mountedPlayer.Bottom + vector2_1 + vector2_2;
            Vector2 vector2_4 = mountedPlayer.oldPosition + mountedPlayer.Size * new Vector2(0.5f, 1f) + vector2_1 + vector2_2;
            if ((double) Vector2.Distance(vector2_3, vector2_4) > 3.0)
            {
              int num7 = (int) Vector2.Distance(vector2_3, vector2_4) / 3;
              if ((double) Vector2.Distance(vector2_3, vector2_4) % 3.0 != 0.0)
                ++num7;
              for (float num8 = 1f; (double) num8 <= (double) num7; ++num8)
              {
                Dust dust = Main.dust[Dust.NewDust(mountedPlayer.Center, 0, 0, 182)];
                dust.position = Vector2.Lerp(vector2_4, vector2_3, num8 / (float) num7);
                dust.noGravity = true;
                dust.velocity = Vector2.Zero;
                dust.customData = (object) mountedPlayer;
                dust.shader = GameShaders.Armor.GetSecondaryShader(mountedPlayer.cMinecart, mountedPlayer);
              }
            }
            else
            {
              Dust dust = Main.dust[Dust.NewDust(mountedPlayer.Center, 0, 0, 182)];
              dust.position = vector2_3;
              dust.noGravity = true;
              dust.velocity = Vector2.Zero;
              dust.customData = (object) mountedPlayer;
              dust.shader = GameShaders.Armor.GetSecondaryShader(mountedPlayer.cMinecart, mountedPlayer);
            }
          }
          if (mountedPlayer.whoAmI != Main.myPlayer || (double) mountedPlayer.velocity.X == 0.0)
            break;
          Vector2 minecartMechPoint = Mount.GetMinecartMechPoint(mountedPlayer, 20, -19);
          int num9 = 60;
          int num10 = 0;
          float num11 = 0.0f;
          for (int index1 = 0; index1 < 200; ++index1)
          {
            NPC npc = Main.npc[index1];
            if (npc.active && npc.immune[mountedPlayer.whoAmI] <= 0 && !npc.dontTakeDamage && (double) npc.Distance(minecartMechPoint) < 300.0 && npc.CanBeChasedBy((object) mountedPlayer) && Collision.CanHitLine(npc.position, npc.width, npc.height, minecartMechPoint, 0, 0) && (double) Math.Abs(MathHelper.WrapAngle(MathHelper.WrapAngle(npc.AngleFrom(minecartMechPoint)) - MathHelper.WrapAngle((double) mountedPlayer.fullRotation + (double) num5 == -1.0 ? 3.141593f : 0.0f))) < 0.785398185253143)
            {
              Vector2 v = npc.position + npc.Size * Utils.RandomVector2(Main.rand, 0.0f, 1f) - minecartMechPoint;
              num11 += v.ToRotation();
              ++num10;
              int index2 = Projectile.NewProjectile(minecartMechPoint.X, minecartMechPoint.Y, v.X, v.Y, 591, 0, 0.0f, mountedPlayer.whoAmI, (float) mountedPlayer.whoAmI);
              Main.projectile[index2].Center = npc.Center;
              Main.projectile[index2].damage = num9;
              Main.projectile[index2].Damage();
              Main.projectile[index2].damage = 0;
              Main.projectile[index2].Center = minecartMechPoint;
            }
          }
          break;
        case 12:
          if (mountedPlayer.MountFishronSpecial)
          {
            Vector3 vector3_3 = Colors.CurrentLiquidColor.ToVector3() * 0.4f;
            Point tileCoordinates = (mountedPlayer.Center + Vector2.UnitX * (float) mountedPlayer.direction * 20f + mountedPlayer.velocity * 10f).ToTileCoordinates();
            if (!WorldGen.SolidTile(tileCoordinates.X, tileCoordinates.Y))
              Lighting.AddLight(tileCoordinates.X, tileCoordinates.Y, vector3_3.X, vector3_3.Y, vector3_3.Z);
            else
              Lighting.AddLight(mountedPlayer.Center + Vector2.UnitX * (float) mountedPlayer.direction * 20f, vector3_3.X, vector3_3.Y, vector3_3.Z);
            mountedPlayer.meleeDamage += 0.15f;
            mountedPlayer.rangedDamage += 0.15f;
            mountedPlayer.magicDamage += 0.15f;
            mountedPlayer.minionDamage += 0.15f;
            mountedPlayer.thrownDamage += 0.15f;
          }
          if (mountedPlayer.statLife <= mountedPlayer.statLifeMax2 / 2)
            mountedPlayer.MountFishronSpecialCounter = 60f;
          if (!mountedPlayer.wet)
            break;
          mountedPlayer.MountFishronSpecialCounter = 300f;
          break;
      }
    }

    public static Vector2 GetMinecartMechPoint(Player mountedPlayer, int offX, int offY)
    {
      int num1 = Math.Sign(mountedPlayer.velocity.X);
      if (num1 == 0)
        num1 = mountedPlayer.direction;
      float num2 = (float) offX;
      int num3 = Math.Sign(offX);
      if (mountedPlayer.direction != num1)
        num2 -= (float) num3;
      if (num1 == -1)
        num2 -= (float) num3;
      Vector2 vector2_1 = new Vector2(num2 * (float) num1, (float) offY).RotatedBy((double) mountedPlayer.fullRotation);
      Vector2 vector2_2 = new Vector2(MathHelper.Lerp(0.0f, -8f, mountedPlayer.fullRotation / 0.7853982f), MathHelper.Lerp(0.0f, 2f, Math.Abs(mountedPlayer.fullRotation / 0.7853982f))).RotatedBy((double) mountedPlayer.fullRotation);
      if (num1 == Math.Sign(mountedPlayer.fullRotation))
        vector2_2 *= MathHelper.Lerp(1f, 0.6f, Math.Abs(mountedPlayer.fullRotation / 0.7853982f));
      return mountedPlayer.Bottom + vector2_1 + vector2_2;
    }

    public void ResetFlightTime(float xVelocity)
    {
      this._flyTime = this._active ? this._data.flightTimeMax : 0;
      if (this._type != 0)
        return;
      this._flyTime += (int) ((double) Math.Abs(xVelocity) * 20.0);
    }

    public void CheckMountBuff(Player mountedPlayer)
    {
      if (this._type == -1)
        return;
      for (int index = 0; index < 22; ++index)
      {
        if (mountedPlayer.buffType[index] == this._data.buff || this.Cart && mountedPlayer.buffType[index] == this._data.extraBuff)
          return;
      }
      this.Dismount(mountedPlayer);
    }

    public void ResetHeadPosition()
    {
      if (!this._aiming)
        return;
      this._aiming = false;
      this._frameExtra = 0;
      this._flipDraw = false;
    }

    private Vector2 ClampToDeadZone(Player mountedPlayer, Vector2 position)
    {
      int y;
      int x;
      switch (this._type)
      {
        case 8:
          y = (int) Mount.drillTextureSize.Y;
          x = (int) Mount.drillTextureSize.X;
          break;
        case 9:
          y = (int) Mount.scutlixTextureSize.Y;
          x = (int) Mount.scutlixTextureSize.X;
          break;
        default:
          return position;
      }
      Vector2 center = mountedPlayer.Center;
      position -= center;
      if ((double) position.X > (double) -x && (double) position.X < (double) x && (double) position.Y > (double) -y && (double) position.Y < (double) y)
      {
        float num1 = (float) x / Math.Abs(position.X);
        float num2 = (float) y / Math.Abs(position.Y);
        if ((double) num1 > (double) num2)
          position *= num2;
        else
          position *= num1;
      }
      return position + center;
    }

    public bool AimAbility(Player mountedPlayer, Vector2 mousePosition)
    {
      this._aiming = true;
      switch (this._type)
      {
        case 8:
          Vector2 v = this.ClampToDeadZone(mountedPlayer, mousePosition) - mountedPlayer.Center;
          Mount.DrillMountData mountSpecificData = (Mount.DrillMountData) this._mountSpecificData;
          float rotation = v.ToRotation();
          if ((double) rotation < 0.0)
            rotation += 6.283185f;
          mountSpecificData.diodeRotationTarget = rotation;
          float num1 = mountSpecificData.diodeRotation % 6.283185f;
          if ((double) num1 < 0.0)
            num1 += 6.283185f;
          if ((double) num1 < (double) rotation)
          {
            if ((double) rotation - (double) num1 > 3.14159274101257)
              num1 += 6.283185f;
          }
          else if ((double) num1 - (double) rotation > 3.14159274101257)
            num1 -= 6.283185f;
          mountSpecificData.diodeRotation = num1;
          mountSpecificData.crosshairPosition = mousePosition;
          return true;
        case 9:
          int frameExtra = this._frameExtra;
          int direction = mountedPlayer.direction;
          float num2 = MathHelper.ToDegrees((this.ClampToDeadZone(mountedPlayer, mousePosition) - mountedPlayer.Center).ToRotation());
          if ((double) num2 > 90.0)
          {
            mountedPlayer.direction = -1;
            num2 = 180f - num2;
          }
          else if ((double) num2 < -90.0)
          {
            mountedPlayer.direction = -1;
            num2 = -180f - num2;
          }
          else
            mountedPlayer.direction = 1;
          this._flipDraw = mountedPlayer.direction > 0 && (double) mountedPlayer.velocity.X < 0.0 || mountedPlayer.direction < 0 && (double) mountedPlayer.velocity.X > 0.0;
          if ((double) num2 >= 0.0)
          {
            if ((double) num2 < 22.5)
              this._frameExtra = 8;
            else if ((double) num2 < 67.5)
              this._frameExtra = 9;
            else if ((double) num2 < 112.5)
              this._frameExtra = 10;
          }
          else if ((double) num2 > -22.5)
            this._frameExtra = 8;
          else if ((double) num2 > -67.5)
            this._frameExtra = 7;
          else if ((double) num2 > -112.5)
            this._frameExtra = 6;
          float abilityCharge = this.AbilityCharge;
          if ((double) abilityCharge > 0.0)
          {
            Vector2 vector2_1;
            vector2_1.X = mountedPlayer.position.X + (float) (mountedPlayer.width / 2);
            vector2_1.Y = mountedPlayer.position.Y + (float) mountedPlayer.height;
            int num3 = (this._frameExtra - 6) * 2;
            for (int index = 0; index < 2; ++index)
            {
              Vector2 vector2_2;
              vector2_2.Y = vector2_1.Y + Mount.scutlixEyePositions[num3 + index].Y;
              vector2_2.X = mountedPlayer.direction != -1 ? vector2_1.X + Mount.scutlixEyePositions[num3 + index].X + (float) this._data.xOffset : vector2_1.X - Mount.scutlixEyePositions[num3 + index].X - (float) this._data.xOffset;
              Lighting.AddLight((int) ((double) vector2_2.X / 16.0), (int) ((double) vector2_2.Y / 16.0), 1f * abilityCharge, 0.0f, 0.0f);
            }
          }
          return this._frameExtra != frameExtra || mountedPlayer.direction != direction;
        default:
          return false;
      }
    }

    public void Draw(
      List<DrawData> playerDrawData,
      int drawType,
      Player drawPlayer,
      Vector2 Position,
      Color drawColor,
      SpriteEffects playerEffect,
      float shadow)
    {
      if (playerDrawData == null)
        return;
      Texture2D texture1;
      Texture2D texture2;
      switch (drawType)
      {
        case 0:
          texture1 = this._data.backTexture;
          texture2 = this._data.backTextureGlow;
          break;
        case 1:
          texture1 = this._data.backTextureExtra;
          texture2 = this._data.backTextureExtraGlow;
          break;
        case 2:
          if (this._type == 0 && this._idleTime >= this._idleTimeNext)
            return;
          texture1 = this._data.frontTexture;
          texture2 = this._data.frontTextureGlow;
          break;
        case 3:
          texture1 = this._data.frontTextureExtra;
          texture2 = this._data.frontTextureExtraGlow;
          break;
        default:
          texture1 = (Texture2D) null;
          texture2 = (Texture2D) null;
          break;
      }
      if (texture1 == null)
        return;
      switch (this._type)
      {
        case 0:
        case 9:
          if (drawType == 3 && (double) shadow != 0.0)
            return;
          break;
      }
      int xoffset = this.XOffset;
      int num1 = this.YOffset + this.PlayerOffset;
      if (drawPlayer.direction <= 0 && (!this.Cart || !this.Directional))
        xoffset *= -1;
      Position.X = (float) (int) ((double) Position.X - (double) Main.screenPosition.X + (double) (drawPlayer.width / 2) + (double) xoffset);
      Position.Y = (float) (int) ((double) Position.Y - (double) Main.screenPosition.Y + (double) (drawPlayer.height / 2) + (double) num1);
      bool flag1 = false;
      int num2;
      switch (this._type)
      {
        case 5:
          switch (drawType)
          {
            case 0:
              num2 = this._frame;
              break;
            case 1:
              num2 = this._frameExtra;
              break;
            default:
              num2 = 0;
              break;
          }
          break;
        case 9:
          flag1 = true;
          switch (drawType)
          {
            case 0:
              num2 = this._frame;
              break;
            case 2:
              num2 = this._frameExtra;
              break;
            case 3:
              num2 = this._frameExtra;
              break;
            default:
              num2 = 0;
              break;
          }
          break;
        default:
          num2 = this._frame;
          break;
      }
      int height = this._data.textureHeight / this._data.totalFrames;
      Rectangle rectangle1 = new Rectangle(0, height * num2, this._data.textureWidth, height);
      if (flag1)
        rectangle1.Height -= 2;
      switch (this._type)
      {
        case 0:
          if (drawType == 3)
          {
            drawColor = Color.White;
            break;
          }
          break;
        case 7:
          if (drawType == 3)
          {
            drawColor = new Color(250, 250, 250, (int) byte.MaxValue) * drawPlayer.stealth * (1f - shadow);
            break;
          }
          break;
        case 9:
          if (drawType == 3)
          {
            if (this._abilityCharge == 0)
              return;
            drawColor = Color.Multiply(Color.White, (float) this._abilityCharge / (float) this._data.abilityChargeMax);
            drawColor.A = (byte) 0;
            break;
          }
          break;
      }
      Color color1 = new Color(drawColor.ToVector4() * 0.25f + new Vector4(0.75f));
      switch (this._type)
      {
        case 11:
          if (drawType == 2)
          {
            color1 = Color.White;
            color1.A = (byte) 127;
            break;
          }
          break;
        case 12:
          if (drawType == 0)
          {
            float num3 = MathHelper.Clamp(drawPlayer.MountFishronSpecialCounter / 60f, 0.0f, 1f);
            Color color2 = Colors.CurrentLiquidColor;
            if (color2 == Color.Transparent)
              color2 = Color.White;
            color2.A = (byte) 127;
            color1 = color2 * num3;
            break;
          }
          break;
      }
      float rotation1 = 0.0f;
      switch (this._type)
      {
        case 7:
          rotation1 = drawPlayer.fullRotation;
          break;
        case 8:
          Mount.DrillMountData mountSpecificData1 = (Mount.DrillMountData) this._mountSpecificData;
          switch (drawType)
          {
            case 0:
              rotation1 = mountSpecificData1.outerRingRotation - rotation1;
              break;
            case 3:
              rotation1 = mountSpecificData1.diodeRotation - rotation1 - drawPlayer.fullRotation;
              break;
          }
          break;
      }
      Vector2 origin = this.Origin;
      int type1 = this._type;
      float scale1 = 1f;
      SpriteEffects effect;
      switch (this._type)
      {
        case 6:
        case 13:
          effect = this._flipDraw ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
          break;
        case 7:
          effect = SpriteEffects.None;
          break;
        case 8:
          effect = drawPlayer.direction != 1 || drawType != 2 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
          break;
        case 11:
          effect = Math.Sign(drawPlayer.velocity.X) == -drawPlayer.direction ? playerEffect ^ SpriteEffects.FlipHorizontally : playerEffect;
          break;
        default:
          effect = playerEffect;
          break;
      }
      bool flag2 = false;
      int type2 = this._type;
      DrawData drawData;
      if (!flag2)
      {
        drawData = new DrawData(texture1, Position, new Rectangle?(rectangle1), drawColor, rotation1, origin, scale1, effect, 0);
        drawData.shader = Mount.currentShader;
        playerDrawData.Add(drawData);
        if (texture2 != null)
        {
          drawData = new DrawData(texture2, Position, new Rectangle?(rectangle1), color1 * ((float) drawColor.A / (float) byte.MaxValue), rotation1, origin, scale1, effect, 0);
          drawData.shader = Mount.currentShader;
        }
        playerDrawData.Add(drawData);
      }
      if (this._type != 8 || drawType != 3)
        return;
      Mount.DrillMountData mountSpecificData2 = (Mount.DrillMountData) this._mountSpecificData;
      Rectangle rectangle2 = new Rectangle(0, 0, 1, 1);
      Vector2 vector2_1 = Mount.drillDiodePoint1.RotatedBy((double) mountSpecificData2.diodeRotation);
      Vector2 vector2_2 = Mount.drillDiodePoint2.RotatedBy((double) mountSpecificData2.diodeRotation);
      for (int index1 = 0; index1 < mountSpecificData2.beams.Length; ++index1)
      {
        Mount.DrillBeam beam = mountSpecificData2.beams[index1];
        if (!(beam.curTileTarget == Point16.NegativeOne))
        {
          for (int index2 = 0; index2 < 2; ++index2)
          {
            Vector2 vector2_3 = new Vector2((float) ((int) beam.curTileTarget.X * 16 + 8), (float) ((int) beam.curTileTarget.Y * 16 + 8)) - Main.screenPosition - Position;
            Vector2 vector2_4;
            Color color3;
            if (index2 == 0)
            {
              vector2_4 = vector2_1;
              color3 = Color.CornflowerBlue;
            }
            else
            {
              vector2_4 = vector2_2;
              color3 = Color.LightGreen;
            }
            color3.A = (byte) 128;
            Color color4 = color3 * 0.5f;
            Vector2 vector2_5 = vector2_4;
            Vector2 v = vector2_3 - vector2_5;
            float rotation2 = v.ToRotation();
            Vector2 scale2 = new Vector2(2f, v.Length());
            drawData = new DrawData(Main.magicPixel, vector2_4 + Position, new Rectangle?(rectangle2), color4, rotation2 - 1.570796f, Vector2.Zero, scale2, SpriteEffects.None, 0);
            drawData.ignorePlayerRotation = true;
            drawData.shader = Mount.currentShader;
            playerDrawData.Add(drawData);
          }
        }
      }
    }

    public void Dismount(Player mountedPlayer)
    {
      if (!this._active)
        return;
      bool cart = this.Cart;
      this._active = false;
      mountedPlayer.ClearBuff(this._data.buff);
      this._mountSpecificData = (object) null;
      int type = this._type;
      if (cart)
      {
        mountedPlayer.ClearBuff(this._data.extraBuff);
        mountedPlayer.cartFlip = false;
        mountedPlayer.lastBoost = Vector2.Zero;
      }
      mountedPlayer.fullRotation = 0.0f;
      mountedPlayer.fullRotationOrigin = Vector2.Zero;
      if (Main.netMode != 2)
      {
        for (int index1 = 0; index1 < 100; ++index1)
        {
          if (this._type == 6 || this._type == 11 || this._type == 13)
          {
            if (index1 % 10 == 0)
            {
              int Type = Main.rand.Next(61, 64);
              int index2 = Gore.NewGore(new Vector2(mountedPlayer.position.X - 20f, mountedPlayer.position.Y), Vector2.Zero, Type);
              Main.gore[index2].alpha = 100;
              Main.gore[index2].velocity = Vector2.Transform(new Vector2(1f, 0.0f), Matrix.CreateRotationZ((float) (Main.rand.NextDouble() * 6.28318548202515)));
            }
          }
          else
          {
            int index3 = Dust.NewDust(new Vector2(mountedPlayer.position.X - 20f, mountedPlayer.position.Y), mountedPlayer.width + 40, mountedPlayer.height, this._data.spawnDust);
            Main.dust[index3].scale += (float) Main.rand.Next(-10, 21) * 0.01f;
            if (this._data.spawnDustNoGravity)
              Main.dust[index3].noGravity = true;
            else if (Main.rand.Next(2) == 0)
            {
              Main.dust[index3].scale *= 1.3f;
              Main.dust[index3].noGravity = true;
            }
            else
              Main.dust[index3].velocity *= 0.5f;
            Main.dust[index3].velocity += mountedPlayer.velocity * 0.8f;
          }
        }
      }
      this.Reset();
      mountedPlayer.position.Y += (float) mountedPlayer.height;
      mountedPlayer.height = 42;
      mountedPlayer.position.Y -= (float) mountedPlayer.height;
      if (mountedPlayer.whoAmI != Main.myPlayer)
        return;
      NetMessage.SendData(13, number: mountedPlayer.whoAmI);
    }

    public void SetMount(int m, Player mountedPlayer, bool faceLeft = false)
    {
      if (this._type == m || m <= -1 || m >= 15 || m == 5 && mountedPlayer.wet)
        return;
      if (this._active)
      {
        mountedPlayer.ClearBuff(this._data.buff);
        if (this.Cart)
        {
          mountedPlayer.ClearBuff(this._data.extraBuff);
          mountedPlayer.cartFlip = false;
          mountedPlayer.lastBoost = Vector2.Zero;
        }
        mountedPlayer.fullRotation = 0.0f;
        mountedPlayer.fullRotationOrigin = Vector2.Zero;
        this._mountSpecificData = (object) null;
      }
      else
        this._active = true;
      this._flyTime = 0;
      this._type = m;
      this._data = Mount.mounts[m];
      this._fatigueMax = (float) this._data.fatigueMax;
      if (this.Cart && !faceLeft && !this.Directional)
      {
        mountedPlayer.AddBuff(this._data.extraBuff, 3600);
        this._flipDraw = true;
      }
      else
      {
        mountedPlayer.AddBuff(this._data.buff, 3600);
        this._flipDraw = false;
      }
      if (this._type == 9 && this._abilityCooldown < 20)
        this._abilityCooldown = 20;
      mountedPlayer.position.Y += (float) mountedPlayer.height;
      for (int index = 0; index < mountedPlayer.shadowPos.Length; ++index)
        mountedPlayer.shadowPos[index].Y += (float) mountedPlayer.height;
      mountedPlayer.height = 42 + this._data.heightBoost;
      mountedPlayer.position.Y -= (float) mountedPlayer.height;
      for (int index = 0; index < mountedPlayer.shadowPos.Length; ++index)
        mountedPlayer.shadowPos[index].Y -= (float) mountedPlayer.height;
      if (this._type == 7 || this._type == 8)
        mountedPlayer.fullRotationOrigin = new Vector2((float) (mountedPlayer.width / 2), (float) (mountedPlayer.height / 2));
      if (this._type == 8)
        this._mountSpecificData = (object) new Mount.DrillMountData();
      if (Main.netMode != 2)
      {
        for (int index1 = 0; index1 < 100; ++index1)
        {
          if (this._type == 6 || this._type == 11 || this._type == 13)
          {
            if (index1 % 10 == 0)
            {
              int Type = Main.rand.Next(61, 64);
              int index2 = Gore.NewGore(new Vector2(mountedPlayer.position.X - 20f, mountedPlayer.position.Y), Vector2.Zero, Type);
              Main.gore[index2].alpha = 100;
              Main.gore[index2].velocity = Vector2.Transform(new Vector2(1f, 0.0f), Matrix.CreateRotationZ((float) (Main.rand.NextDouble() * 6.28318548202515)));
            }
          }
          else
          {
            int index3 = Dust.NewDust(new Vector2(mountedPlayer.position.X - 20f, mountedPlayer.position.Y), mountedPlayer.width + 40, mountedPlayer.height, this._data.spawnDust);
            Main.dust[index3].scale += (float) Main.rand.Next(-10, 21) * 0.01f;
            if (this._data.spawnDustNoGravity)
              Main.dust[index3].noGravity = true;
            else if (Main.rand.Next(2) == 0)
            {
              Main.dust[index3].scale *= 1.3f;
              Main.dust[index3].noGravity = true;
            }
            else
              Main.dust[index3].velocity *= 0.5f;
            Main.dust[index3].velocity += mountedPlayer.velocity * 0.8f;
          }
        }
      }
      if (mountedPlayer.whoAmI != Main.myPlayer)
        return;
      NetMessage.SendData(13, number: mountedPlayer.whoAmI);
    }

    public bool CanMount(int m, Player mountingPlayer)
    {
      int Height = 42 + Mount.mounts[m].heightBoost;
      return Collision.IsClearSpotTest(mountingPlayer.position + new Vector2(0.0f, (float) (mountingPlayer.height - Height)) + mountingPlayer.velocity, 16f, mountingPlayer.width, Height, true, true);
    }

    public bool FindTileHeight(Vector2 position, int maxTilesDown, out float tileHeight)
    {
      int index1 = (int) ((double) position.X / 16.0);
      int index2 = (int) ((double) position.Y / 16.0);
      for (int index3 = 0; index3 <= maxTilesDown; ++index3)
      {
        Tile tile = Main.tile[index1, index2];
        bool flag1 = Main.tileSolid[(int) tile.type];
        bool flag2 = Main.tileSolidTop[(int) tile.type];
        if (tile.active())
        {
          if (flag1)
          {
            if (!flag2)
              ;
          }
          else
          {
            int num = flag2 ? 1 : 0;
          }
        }
        ++index2;
      }
      tileHeight = 0.0f;
      return true;
    }

    private class DrillBeam
    {
      public Point16 curTileTarget;
      public int cooldown;

      public DrillBeam()
      {
        this.curTileTarget = Point16.NegativeOne;
        this.cooldown = 0;
      }
    }

    private class DrillMountData
    {
      public float diodeRotationTarget;
      public float diodeRotation;
      public float outerRingRotation;
      public Mount.DrillBeam[] beams;
      public int beamCooldown;
      public Vector2 crosshairPosition;

      public DrillMountData()
      {
        this.beams = new Mount.DrillBeam[4];
        for (int index = 0; index < this.beams.Length; ++index)
          this.beams[index] = new Mount.DrillBeam();
      }
    }

    private class MountData
    {
      public Texture2D backTexture;
      public Texture2D backTextureGlow;
      public Texture2D backTextureExtra;
      public Texture2D backTextureExtraGlow;
      public Texture2D frontTexture;
      public Texture2D frontTextureGlow;
      public Texture2D frontTextureExtra;
      public Texture2D frontTextureExtraGlow;
      public int textureWidth;
      public int textureHeight;
      public int xOffset;
      public int yOffset;
      public int[] playerYOffsets;
      public int bodyFrame;
      public int playerHeadOffset;
      public int heightBoost;
      public int buff;
      public int extraBuff;
      public int flightTimeMax;
      public bool usesHover;
      public float runSpeed;
      public float dashSpeed;
      public float swimSpeed;
      public float acceleration;
      public float jumpSpeed;
      public int jumpHeight;
      public float fallDamage;
      public int fatigueMax;
      public bool constantJump;
      public bool blockExtraJumps;
      public int abilityChargeMax;
      public int abilityDuration;
      public int abilityCooldown;
      public int spawnDust;
      public bool spawnDustNoGravity;
      public int totalFrames;
      public int standingFrameStart;
      public int standingFrameCount;
      public int standingFrameDelay;
      public int runningFrameStart;
      public int runningFrameCount;
      public int runningFrameDelay;
      public int flyingFrameStart;
      public int flyingFrameCount;
      public int flyingFrameDelay;
      public int inAirFrameStart;
      public int inAirFrameCount;
      public int inAirFrameDelay;
      public int idleFrameStart;
      public int idleFrameCount;
      public int idleFrameDelay;
      public bool idleFrameLoop;
      public int swimFrameStart;
      public int swimFrameCount;
      public int swimFrameDelay;
      public int dashingFrameStart;
      public int dashingFrameCount;
      public int dashingFrameDelay;
      public bool Minecart;
      public bool MinecartDirectional;
      public Action<Vector2> MinecartDust;
      public Vector3 lightColor = Vector3.One;
      public bool emitsLight;
    }
  }
}
