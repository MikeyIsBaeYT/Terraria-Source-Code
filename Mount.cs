// Decompiled with JetBrains decompiler
// Type: Terraria.Mount
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Drawing;
using Terraria.Graphics.Shaders;
using Terraria.ID;

namespace Terraria
{
  public class Mount
  {
    public static int currentShader = 0;
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
    private static Vector2 santankTextureSize;
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
    private Mount.MountDelegatesData _defaultDelegatesData = new Mount.MountDelegatesData();

    private static void MeowcartLandingSound(Vector2 Position, int Width, int Height) => SoundEngine.PlaySound(37, (int) Position.X + Width / 2, (int) Position.Y + Height / 2, 5);

    private static void MeowcartBumperSound(Vector2 Position, int Width, int Height) => SoundEngine.PlaySound(37, (int) Position.X + Width / 2, (int) Position.Y + Height / 2, 3);

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
      Mount.mounts = new Mount.MountData[MountID.Count];
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
        mountData1.backTexture = TextureAssets.RudolphMount[0];
        mountData1.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData1.frontTexture = TextureAssets.RudolphMount[1];
        mountData1.frontTextureExtra = TextureAssets.RudolphMount[2];
        mountData1.textureWidth = mountData1.backTexture.Width();
        mountData1.textureHeight = mountData1.backTexture.Height();
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
        mountData2.backTexture = TextureAssets.PigronMount;
        mountData2.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData2.frontTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData2.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData2.textureWidth = mountData2.backTexture.Width();
        mountData2.textureHeight = mountData2.backTexture.Height();
      }
      Mount.MountData mountData3 = new Mount.MountData();
      Mount.mounts[1] = mountData3;
      mountData3.spawnDust = 15;
      mountData3.buff = 128;
      mountData3.heightBoost = 20;
      mountData3.flightTimeMax = 0;
      mountData3.fallDamage = 0.8f;
      mountData3.runSpeed = 4f;
      mountData3.dashSpeed = 7.8f;
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
        mountData3.backTexture = TextureAssets.BunnyMount;
        mountData3.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData3.frontTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData3.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData3.textureWidth = mountData3.backTexture.Width();
        mountData3.textureHeight = mountData3.backTexture.Height();
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
      mountData4.yOffset = 11;
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
        mountData4.backTexture = TextureAssets.SlimeMount;
        mountData4.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData4.frontTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData4.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData4.textureWidth = mountData4.backTexture.Width();
        mountData4.textureHeight = mountData4.backTexture.Height();
      }
      Mount.MountData mountData5 = new Mount.MountData();
      Mount.mounts[6] = mountData5;
      mountData5.Minecart = true;
      mountData5.MinecartDirectional = true;
      mountData5.delegations = new Mount.MountDelegatesData();
      mountData5.delegations.MinecartDust = new Action<Vector2>(DelegateMethods.Minecart.Sparks);
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
        mountData5.backTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData5.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData5.frontTexture = TextureAssets.MinecartMount;
        mountData5.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData5.textureWidth = mountData5.frontTexture.Width();
        mountData5.textureHeight = mountData5.frontTexture.Height();
      }
      Mount.MountData newMount1 = new Mount.MountData();
      Mount.mounts[15] = newMount1;
      Mount.SetAsMinecart(newMount1, 209, 208, TextureAssets.DesertMinecartMount);
      Mount.MountData newMount2 = new Mount.MountData();
      Mount.mounts[18] = newMount2;
      Mount.SetAsMinecart(newMount2, 221, 220, TextureAssets.Extra[108]);
      Mount.MountData newMount3 = new Mount.MountData();
      Mount.mounts[19] = newMount3;
      Mount.SetAsMinecart(newMount3, 223, 222, TextureAssets.Extra[109]);
      Mount.MountData newMount4 = new Mount.MountData();
      Mount.mounts[20] = newMount4;
      Mount.SetAsMinecart(newMount4, 225, 224, TextureAssets.Extra[110]);
      Mount.MountData newMount5 = new Mount.MountData();
      Mount.mounts[21] = newMount5;
      Mount.SetAsMinecart(newMount5, 227, 226, TextureAssets.Extra[111]);
      Mount.MountData newMount6 = new Mount.MountData();
      Mount.mounts[22] = newMount6;
      Mount.SetAsMinecart(newMount6, 229, 228, TextureAssets.Extra[112]);
      Mount.MountData newMount7 = new Mount.MountData();
      Mount.mounts[24] = newMount7;
      Mount.SetAsMinecart(newMount7, 232, 231, TextureAssets.Extra[115]);
      newMount7.frontTextureGlow = TextureAssets.Extra[116];
      Mount.MountData newMount8 = new Mount.MountData();
      Mount.mounts[25] = newMount8;
      Mount.SetAsMinecart(newMount8, 234, 233, TextureAssets.Extra[117]);
      Mount.MountData newMount9 = new Mount.MountData();
      Mount.mounts[26] = newMount9;
      Mount.SetAsMinecart(newMount9, 236, 235, TextureAssets.Extra[118]);
      Mount.MountData newMount10 = new Mount.MountData();
      Mount.mounts[27] = newMount10;
      Mount.SetAsMinecart(newMount10, 238, 237, TextureAssets.Extra[119]);
      Mount.MountData newMount11 = new Mount.MountData();
      Mount.mounts[28] = newMount11;
      Mount.SetAsMinecart(newMount11, 240, 239, TextureAssets.Extra[120]);
      Mount.MountData newMount12 = new Mount.MountData();
      Mount.mounts[29] = newMount12;
      Mount.SetAsMinecart(newMount12, 242, 241, TextureAssets.Extra[121]);
      Mount.MountData newMount13 = new Mount.MountData();
      Mount.mounts[30] = newMount13;
      Mount.SetAsMinecart(newMount13, 244, 243, TextureAssets.Extra[122]);
      Mount.MountData newMount14 = new Mount.MountData();
      Mount.mounts[31] = newMount14;
      Mount.SetAsMinecart(newMount14, 246, 245, TextureAssets.Extra[123]);
      Mount.MountData newMount15 = new Mount.MountData();
      Mount.mounts[32] = newMount15;
      Mount.SetAsMinecart(newMount15, 248, 247, TextureAssets.Extra[124]);
      Mount.MountData newMount16 = new Mount.MountData();
      Mount.mounts[33] = newMount16;
      Mount.SetAsMinecart(newMount16, 250, 249, TextureAssets.Extra[125]);
      newMount16.delegations.MinecartDust = new Action<Vector2>(DelegateMethods.Minecart.SparksMeow);
      newMount16.delegations.MinecartLandingSound = new Action<Vector2, int, int>(Mount.MeowcartLandingSound);
      newMount16.delegations.MinecartBumperSound = new Action<Vector2, int, int>(Mount.MeowcartBumperSound);
      Mount.MountData newMount17 = new Mount.MountData();
      Mount.mounts[34] = newMount17;
      Mount.SetAsMinecart(newMount17, 252, 251, TextureAssets.Extra[126]);
      Mount.MountData newMount18 = new Mount.MountData();
      Mount.mounts[35] = newMount18;
      Mount.SetAsMinecart(newMount18, 254, 253, TextureAssets.Extra[(int) sbyte.MaxValue]);
      Mount.MountData newMount19 = new Mount.MountData();
      Mount.mounts[36] = newMount19;
      Mount.SetAsMinecart(newMount19, 256, (int) byte.MaxValue, TextureAssets.Extra[128]);
      Mount.MountData newMount20 = new Mount.MountData();
      Mount.mounts[38] = newMount20;
      Mount.SetAsMinecart(newMount20, 270, 269, TextureAssets.Extra[150]);
      if (Main.netMode != 2)
        newMount20.backTexture = newMount20.frontTexture;
      Mount.MountData newMount21 = new Mount.MountData();
      Mount.mounts[39] = newMount21;
      Mount.SetAsMinecart(newMount21, 273, 272, TextureAssets.Extra[155]);
      newMount21.yOffset -= 2;
      if (Main.netMode != 2)
        newMount21.frontTextureExtra = TextureAssets.Extra[165];
      newMount21.runSpeed = 6f;
      newMount21.dashSpeed = 6f;
      newMount21.acceleration = 0.02f;
      Mount.MountData mountData6 = new Mount.MountData();
      Mount.mounts[16] = mountData6;
      mountData6.Minecart = true;
      mountData6.delegations = new Mount.MountDelegatesData();
      mountData6.delegations.MinecartDust = new Action<Vector2>(DelegateMethods.Minecart.Sparks);
      mountData6.spawnDust = 213;
      mountData6.buff = 211;
      mountData6.extraBuff = 210;
      mountData6.heightBoost = 10;
      mountData6.flightTimeMax = 0;
      mountData6.fallDamage = 1f;
      mountData6.runSpeed = 13f;
      mountData6.dashSpeed = 13f;
      mountData6.acceleration = 0.04f;
      mountData6.jumpHeight = 15;
      mountData6.jumpSpeed = 5.15f;
      mountData6.blockExtraJumps = true;
      mountData6.totalFrames = 3;
      int[] numArray6 = new int[mountData6.totalFrames];
      for (int index = 0; index < numArray6.Length; ++index)
        numArray6[index] = 8;
      mountData6.playerYOffsets = numArray6;
      mountData6.xOffset = 1;
      mountData6.bodyFrame = 3;
      mountData6.yOffset = 13;
      mountData6.playerHeadOffset = 14;
      mountData6.standingFrameCount = 1;
      mountData6.standingFrameDelay = 12;
      mountData6.standingFrameStart = 0;
      mountData6.runningFrameCount = 3;
      mountData6.runningFrameDelay = 12;
      mountData6.runningFrameStart = 0;
      mountData6.flyingFrameCount = 0;
      mountData6.flyingFrameDelay = 0;
      mountData6.flyingFrameStart = 0;
      mountData6.inAirFrameCount = 0;
      mountData6.inAirFrameDelay = 0;
      mountData6.inAirFrameStart = 0;
      mountData6.idleFrameCount = 0;
      mountData6.idleFrameDelay = 0;
      mountData6.idleFrameStart = 0;
      mountData6.idleFrameLoop = false;
      if (Main.netMode != 2)
      {
        mountData6.backTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData6.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData6.frontTexture = TextureAssets.FishMinecartMount;
        mountData6.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData6.textureWidth = mountData6.frontTexture.Width();
        mountData6.textureHeight = mountData6.frontTexture.Height();
      }
      Mount.MountData mountData7 = new Mount.MountData();
      Mount.mounts[4] = mountData7;
      mountData7.spawnDust = 56;
      mountData7.buff = 131;
      mountData7.heightBoost = 26;
      mountData7.flightTimeMax = 0;
      mountData7.fallDamage = 1f;
      mountData7.runSpeed = 2f;
      mountData7.dashSpeed = 2f;
      mountData7.swimSpeed = 6f;
      mountData7.acceleration = 0.08f;
      mountData7.jumpHeight = 10;
      mountData7.jumpSpeed = 3.15f;
      mountData7.totalFrames = 12;
      int[] numArray7 = new int[mountData7.totalFrames];
      for (int index = 0; index < numArray7.Length; ++index)
        numArray7[index] = 26;
      mountData7.playerYOffsets = numArray7;
      mountData7.xOffset = 1;
      mountData7.bodyFrame = 3;
      mountData7.yOffset = 13;
      mountData7.playerHeadOffset = 28;
      mountData7.standingFrameCount = 1;
      mountData7.standingFrameDelay = 12;
      mountData7.standingFrameStart = 0;
      mountData7.runningFrameCount = 6;
      mountData7.runningFrameDelay = 12;
      mountData7.runningFrameStart = 0;
      mountData7.flyingFrameCount = 0;
      mountData7.flyingFrameDelay = 0;
      mountData7.flyingFrameStart = 0;
      mountData7.inAirFrameCount = 1;
      mountData7.inAirFrameDelay = 12;
      mountData7.inAirFrameStart = 3;
      mountData7.idleFrameCount = 0;
      mountData7.idleFrameDelay = 0;
      mountData7.idleFrameStart = 0;
      mountData7.idleFrameLoop = false;
      mountData7.swimFrameCount = 6;
      mountData7.swimFrameDelay = 12;
      mountData7.swimFrameStart = 6;
      if (Main.netMode != 2)
      {
        mountData7.backTexture = TextureAssets.TurtleMount;
        mountData7.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData7.frontTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData7.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData7.textureWidth = mountData7.backTexture.Width();
        mountData7.textureHeight = mountData7.backTexture.Height();
      }
      Mount.MountData mountData8 = new Mount.MountData();
      Mount.mounts[5] = mountData8;
      mountData8.spawnDust = 152;
      mountData8.buff = 132;
      mountData8.heightBoost = 16;
      mountData8.flightTimeMax = 320;
      mountData8.fatigueMax = 320;
      mountData8.fallDamage = 0.0f;
      mountData8.usesHover = true;
      mountData8.runSpeed = 2f;
      mountData8.dashSpeed = 2f;
      mountData8.acceleration = 0.16f;
      mountData8.jumpHeight = 10;
      mountData8.jumpSpeed = 4f;
      mountData8.blockExtraJumps = true;
      mountData8.totalFrames = 12;
      int[] numArray8 = new int[mountData8.totalFrames];
      for (int index = 0; index < numArray8.Length; ++index)
        numArray8[index] = 16;
      numArray8[8] = 18;
      mountData8.playerYOffsets = numArray8;
      mountData8.xOffset = 1;
      mountData8.bodyFrame = 3;
      mountData8.yOffset = 4;
      mountData8.playerHeadOffset = 18;
      mountData8.standingFrameCount = 1;
      mountData8.standingFrameDelay = 12;
      mountData8.standingFrameStart = 0;
      mountData8.runningFrameCount = 5;
      mountData8.runningFrameDelay = 12;
      mountData8.runningFrameStart = 0;
      mountData8.flyingFrameCount = 3;
      mountData8.flyingFrameDelay = 12;
      mountData8.flyingFrameStart = 5;
      mountData8.inAirFrameCount = 3;
      mountData8.inAirFrameDelay = 12;
      mountData8.inAirFrameStart = 5;
      mountData8.idleFrameCount = 4;
      mountData8.idleFrameDelay = 12;
      mountData8.idleFrameStart = 8;
      mountData8.idleFrameLoop = true;
      mountData8.swimFrameCount = 0;
      mountData8.swimFrameDelay = 12;
      mountData8.swimFrameStart = 0;
      if (Main.netMode != 2)
      {
        mountData8.backTexture = TextureAssets.BeeMount[0];
        mountData8.backTextureExtra = TextureAssets.BeeMount[1];
        mountData8.frontTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData8.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData8.textureWidth = mountData8.backTexture.Width();
        mountData8.textureHeight = mountData8.backTexture.Height();
      }
      Mount.MountData mountData9 = new Mount.MountData();
      Mount.mounts[7] = mountData9;
      mountData9.spawnDust = 226;
      mountData9.spawnDustNoGravity = true;
      mountData9.buff = 141;
      mountData9.heightBoost = 16;
      mountData9.flightTimeMax = 320;
      mountData9.fatigueMax = 320;
      mountData9.fallDamage = 0.0f;
      mountData9.usesHover = true;
      mountData9.runSpeed = 8f;
      mountData9.dashSpeed = 8f;
      mountData9.acceleration = 0.16f;
      mountData9.jumpHeight = 10;
      mountData9.jumpSpeed = 4f;
      mountData9.blockExtraJumps = true;
      mountData9.totalFrames = 8;
      int[] numArray9 = new int[mountData9.totalFrames];
      for (int index = 0; index < numArray9.Length; ++index)
        numArray9[index] = 16;
      mountData9.playerYOffsets = numArray9;
      mountData9.xOffset = 1;
      mountData9.bodyFrame = 3;
      mountData9.yOffset = 4;
      mountData9.playerHeadOffset = 18;
      mountData9.standingFrameCount = 8;
      mountData9.standingFrameDelay = 4;
      mountData9.standingFrameStart = 0;
      mountData9.runningFrameCount = 8;
      mountData9.runningFrameDelay = 4;
      mountData9.runningFrameStart = 0;
      mountData9.flyingFrameCount = 8;
      mountData9.flyingFrameDelay = 4;
      mountData9.flyingFrameStart = 0;
      mountData9.inAirFrameCount = 8;
      mountData9.inAirFrameDelay = 4;
      mountData9.inAirFrameStart = 0;
      mountData9.idleFrameCount = 0;
      mountData9.idleFrameDelay = 12;
      mountData9.idleFrameStart = 0;
      mountData9.idleFrameLoop = true;
      mountData9.swimFrameCount = 0;
      mountData9.swimFrameDelay = 12;
      mountData9.swimFrameStart = 0;
      if (Main.netMode != 2)
      {
        mountData9.backTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData9.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData9.frontTexture = TextureAssets.UfoMount[0];
        mountData9.frontTextureExtra = TextureAssets.UfoMount[1];
        mountData9.textureWidth = mountData9.frontTexture.Width();
        mountData9.textureHeight = mountData9.frontTexture.Height();
      }
      Mount.MountData mountData10 = new Mount.MountData();
      Mount.mounts[8] = mountData10;
      mountData10.spawnDust = 226;
      mountData10.buff = 142;
      mountData10.heightBoost = 16;
      mountData10.flightTimeMax = 320;
      mountData10.fatigueMax = 320;
      mountData10.fallDamage = 1f;
      mountData10.usesHover = true;
      mountData10.swimSpeed = 4f;
      mountData10.runSpeed = 6f;
      mountData10.dashSpeed = 4f;
      mountData10.acceleration = 0.16f;
      mountData10.jumpHeight = 10;
      mountData10.jumpSpeed = 4f;
      mountData10.blockExtraJumps = true;
      mountData10.emitsLight = true;
      mountData10.lightColor = new Vector3(0.3f, 0.3f, 0.4f);
      mountData10.totalFrames = 1;
      int[] numArray10 = new int[mountData10.totalFrames];
      for (int index = 0; index < numArray10.Length; ++index)
        numArray10[index] = 4;
      mountData10.playerYOffsets = numArray10;
      mountData10.xOffset = 1;
      mountData10.bodyFrame = 3;
      mountData10.yOffset = 4;
      mountData10.playerHeadOffset = 18;
      mountData10.standingFrameCount = 1;
      mountData10.standingFrameDelay = 12;
      mountData10.standingFrameStart = 0;
      mountData10.runningFrameCount = 1;
      mountData10.runningFrameDelay = 12;
      mountData10.runningFrameStart = 0;
      mountData10.flyingFrameCount = 1;
      mountData10.flyingFrameDelay = 12;
      mountData10.flyingFrameStart = 0;
      mountData10.inAirFrameCount = 1;
      mountData10.inAirFrameDelay = 12;
      mountData10.inAirFrameStart = 0;
      mountData10.idleFrameCount = 0;
      mountData10.idleFrameDelay = 12;
      mountData10.idleFrameStart = 8;
      mountData10.swimFrameCount = 0;
      mountData10.swimFrameDelay = 12;
      mountData10.swimFrameStart = 0;
      if (Main.netMode != 2)
      {
        mountData10.backTexture = TextureAssets.DrillMount[0];
        mountData10.backTextureGlow = TextureAssets.DrillMount[3];
        mountData10.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData10.backTextureExtraGlow = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData10.frontTexture = TextureAssets.DrillMount[1];
        mountData10.frontTextureGlow = TextureAssets.DrillMount[4];
        mountData10.frontTextureExtra = TextureAssets.DrillMount[2];
        mountData10.frontTextureExtraGlow = TextureAssets.DrillMount[5];
        mountData10.textureWidth = mountData10.frontTexture.Width();
        mountData10.textureHeight = mountData10.frontTexture.Height();
      }
      Mount.drillTextureSize = new Vector2(80f, 80f);
      Vector2 vector2_1 = new Vector2((float) mountData10.textureWidth, (float) (mountData10.textureHeight / mountData10.totalFrames));
      if (Mount.drillTextureSize != vector2_1)
        throw new Exception("Be sure to update the Drill texture origin to match the actual texture size of " + (object) mountData10.textureWidth + ", " + (object) mountData10.textureHeight + ".");
      Mount.MountData mountData11 = new Mount.MountData();
      Mount.mounts[9] = mountData11;
      mountData11.spawnDust = 15;
      mountData11.buff = 143;
      mountData11.heightBoost = 16;
      mountData11.flightTimeMax = 0;
      mountData11.fatigueMax = 0;
      mountData11.fallDamage = 0.0f;
      mountData11.abilityChargeMax = 40;
      mountData11.abilityCooldown = 20;
      mountData11.abilityDuration = 0;
      mountData11.runSpeed = 8f;
      mountData11.dashSpeed = 8f;
      mountData11.acceleration = 0.4f;
      mountData11.jumpHeight = 22;
      mountData11.jumpSpeed = 10.01f;
      mountData11.blockExtraJumps = false;
      mountData11.totalFrames = 12;
      int[] numArray11 = new int[mountData11.totalFrames];
      for (int index = 0; index < numArray11.Length; ++index)
        numArray11[index] = 16;
      mountData11.playerYOffsets = numArray11;
      mountData11.xOffset = 1;
      mountData11.bodyFrame = 3;
      mountData11.yOffset = 6;
      mountData11.playerHeadOffset = 18;
      mountData11.standingFrameCount = 6;
      mountData11.standingFrameDelay = 12;
      mountData11.standingFrameStart = 6;
      mountData11.runningFrameCount = 6;
      mountData11.runningFrameDelay = 12;
      mountData11.runningFrameStart = 0;
      mountData11.flyingFrameCount = 0;
      mountData11.flyingFrameDelay = 12;
      mountData11.flyingFrameStart = 0;
      mountData11.inAirFrameCount = 1;
      mountData11.inAirFrameDelay = 12;
      mountData11.inAirFrameStart = 1;
      mountData11.idleFrameCount = 0;
      mountData11.idleFrameDelay = 12;
      mountData11.idleFrameStart = 6;
      mountData11.idleFrameLoop = true;
      mountData11.swimFrameCount = 0;
      mountData11.swimFrameDelay = 12;
      mountData11.swimFrameStart = 0;
      if (Main.netMode != 2)
      {
        mountData11.backTexture = TextureAssets.ScutlixMount[0];
        mountData11.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData11.frontTexture = TextureAssets.ScutlixMount[1];
        mountData11.frontTextureExtra = TextureAssets.ScutlixMount[2];
        mountData11.textureWidth = mountData11.backTexture.Width();
        mountData11.textureHeight = mountData11.backTexture.Height();
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
      Vector2 vector2_2 = new Vector2((float) (mountData11.textureWidth / 2), (float) (mountData11.textureHeight / mountData11.totalFrames));
      if (Mount.scutlixTextureSize != vector2_2)
        throw new Exception("Be sure to update the Scutlix texture origin to match the actual texture size of " + (object) mountData11.textureWidth + ", " + (object) mountData11.textureHeight + ".");
      for (int index = 0; index < Mount.scutlixEyePositions.Length; ++index)
        Mount.scutlixEyePositions[index] -= Mount.scutlixTextureSize;
      Mount.MountData mountData12 = new Mount.MountData();
      Mount.mounts[10] = mountData12;
      mountData12.spawnDust = 15;
      mountData12.buff = 162;
      mountData12.heightBoost = 34;
      mountData12.flightTimeMax = 0;
      mountData12.fallDamage = 0.2f;
      mountData12.runSpeed = 4f;
      mountData12.dashSpeed = 12f;
      mountData12.acceleration = 0.3f;
      mountData12.jumpHeight = 10;
      mountData12.jumpSpeed = 8.01f;
      mountData12.totalFrames = 16;
      int[] numArray12 = new int[mountData12.totalFrames];
      for (int index = 0; index < numArray12.Length; ++index)
        numArray12[index] = 28;
      numArray12[3] += 2;
      numArray12[4] += 2;
      numArray12[7] += 2;
      numArray12[8] += 2;
      numArray12[12] += 2;
      numArray12[13] += 2;
      numArray12[15] += 4;
      mountData12.playerYOffsets = numArray12;
      mountData12.xOffset = 5;
      mountData12.bodyFrame = 3;
      mountData12.yOffset = 1;
      mountData12.playerHeadOffset = 34;
      mountData12.standingFrameCount = 1;
      mountData12.standingFrameDelay = 12;
      mountData12.standingFrameStart = 0;
      mountData12.runningFrameCount = 7;
      mountData12.runningFrameDelay = 15;
      mountData12.runningFrameStart = 1;
      mountData12.dashingFrameCount = 6;
      mountData12.dashingFrameDelay = 40;
      mountData12.dashingFrameStart = 9;
      mountData12.flyingFrameCount = 6;
      mountData12.flyingFrameDelay = 6;
      mountData12.flyingFrameStart = 1;
      mountData12.inAirFrameCount = 1;
      mountData12.inAirFrameDelay = 12;
      mountData12.inAirFrameStart = 15;
      mountData12.idleFrameCount = 0;
      mountData12.idleFrameDelay = 0;
      mountData12.idleFrameStart = 0;
      mountData12.idleFrameLoop = false;
      mountData12.swimFrameCount = mountData12.inAirFrameCount;
      mountData12.swimFrameDelay = mountData12.inAirFrameDelay;
      mountData12.swimFrameStart = mountData12.inAirFrameStart;
      if (Main.netMode != 2)
      {
        mountData12.backTexture = TextureAssets.UnicornMount;
        mountData12.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData12.frontTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData12.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData12.textureWidth = mountData12.backTexture.Width();
        mountData12.textureHeight = mountData12.backTexture.Height();
      }
      Mount.MountData mountData13 = new Mount.MountData();
      Mount.mounts[11] = mountData13;
      mountData13.Minecart = true;
      mountData13.delegations = new Mount.MountDelegatesData();
      mountData13.delegations.MinecartDust = new Action<Vector2>(DelegateMethods.Minecart.SparksMech);
      mountData13.spawnDust = 213;
      mountData13.buff = 167;
      mountData13.extraBuff = 166;
      mountData13.heightBoost = 12;
      mountData13.flightTimeMax = 0;
      mountData13.fallDamage = 1f;
      mountData13.runSpeed = 20f;
      mountData13.dashSpeed = 20f;
      mountData13.acceleration = 0.1f;
      mountData13.jumpHeight = 15;
      mountData13.jumpSpeed = 5.15f;
      mountData13.blockExtraJumps = true;
      mountData13.totalFrames = 3;
      int[] numArray13 = new int[mountData13.totalFrames];
      for (int index = 0; index < numArray13.Length; ++index)
        numArray13[index] = 9;
      mountData13.playerYOffsets = numArray13;
      mountData13.xOffset = -1;
      mountData13.bodyFrame = 3;
      mountData13.yOffset = 11;
      mountData13.playerHeadOffset = 14;
      mountData13.standingFrameCount = 1;
      mountData13.standingFrameDelay = 12;
      mountData13.standingFrameStart = 0;
      mountData13.runningFrameCount = 3;
      mountData13.runningFrameDelay = 12;
      mountData13.runningFrameStart = 0;
      mountData13.flyingFrameCount = 0;
      mountData13.flyingFrameDelay = 0;
      mountData13.flyingFrameStart = 0;
      mountData13.inAirFrameCount = 0;
      mountData13.inAirFrameDelay = 0;
      mountData13.inAirFrameStart = 0;
      mountData13.idleFrameCount = 0;
      mountData13.idleFrameDelay = 0;
      mountData13.idleFrameStart = 0;
      mountData13.idleFrameLoop = false;
      if (Main.netMode != 2)
      {
        mountData13.backTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData13.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData13.frontTexture = TextureAssets.MinecartMechMount[0];
        mountData13.frontTextureGlow = TextureAssets.MinecartMechMount[1];
        mountData13.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData13.textureWidth = mountData13.frontTexture.Width();
        mountData13.textureHeight = mountData13.frontTexture.Height();
      }
      Mount.MountData mountData14 = new Mount.MountData();
      Mount.mounts[12] = mountData14;
      mountData14.spawnDust = 15;
      mountData14.buff = 168;
      mountData14.heightBoost = 14;
      mountData14.flightTimeMax = 320;
      mountData14.fatigueMax = 320;
      mountData14.fallDamage = 0.0f;
      mountData14.usesHover = true;
      mountData14.runSpeed = 2f;
      mountData14.dashSpeed = 1f;
      mountData14.acceleration = 0.2f;
      mountData14.jumpHeight = 4;
      mountData14.jumpSpeed = 3f;
      mountData14.swimSpeed = 16f;
      mountData14.blockExtraJumps = true;
      mountData14.totalFrames = 23;
      int[] numArray14 = new int[mountData14.totalFrames];
      for (int index = 0; index < numArray14.Length; ++index)
        numArray14[index] = 12;
      mountData14.playerYOffsets = numArray14;
      mountData14.xOffset = 2;
      mountData14.bodyFrame = 3;
      mountData14.yOffset = 16;
      mountData14.playerHeadOffset = 16;
      mountData14.standingFrameCount = 1;
      mountData14.standingFrameDelay = 12;
      mountData14.standingFrameStart = 8;
      mountData14.runningFrameCount = 7;
      mountData14.runningFrameDelay = 14;
      mountData14.runningFrameStart = 8;
      mountData14.flyingFrameCount = 8;
      mountData14.flyingFrameDelay = 16;
      mountData14.flyingFrameStart = 0;
      mountData14.inAirFrameCount = 8;
      mountData14.inAirFrameDelay = 6;
      mountData14.inAirFrameStart = 0;
      mountData14.idleFrameCount = 0;
      mountData14.idleFrameDelay = 0;
      mountData14.idleFrameStart = 0;
      mountData14.idleFrameLoop = false;
      mountData14.swimFrameCount = 8;
      mountData14.swimFrameDelay = 4;
      mountData14.swimFrameStart = 15;
      if (Main.netMode != 2)
      {
        mountData14.backTexture = TextureAssets.CuteFishronMount[0];
        mountData14.backTextureGlow = TextureAssets.CuteFishronMount[1];
        mountData14.frontTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData14.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData14.textureWidth = mountData14.backTexture.Width();
        mountData14.textureHeight = mountData14.backTexture.Height();
      }
      Mount.MountData mountData15 = new Mount.MountData();
      Mount.mounts[13] = mountData15;
      mountData15.Minecart = true;
      mountData15.MinecartDirectional = true;
      mountData15.delegations = new Mount.MountDelegatesData();
      mountData15.delegations.MinecartDust = new Action<Vector2>(DelegateMethods.Minecart.Sparks);
      mountData15.spawnDust = 213;
      mountData15.buff = 184;
      mountData15.extraBuff = 185;
      mountData15.heightBoost = 10;
      mountData15.flightTimeMax = 0;
      mountData15.fallDamage = 1f;
      mountData15.runSpeed = 10f;
      mountData15.dashSpeed = 10f;
      mountData15.acceleration = 0.03f;
      mountData15.jumpHeight = 12;
      mountData15.jumpSpeed = 5.15f;
      mountData15.blockExtraJumps = true;
      mountData15.totalFrames = 3;
      int[] numArray15 = new int[mountData15.totalFrames];
      for (int index = 0; index < numArray15.Length; ++index)
        numArray15[index] = 8;
      mountData15.playerYOffsets = numArray15;
      mountData15.xOffset = 1;
      mountData15.bodyFrame = 3;
      mountData15.yOffset = 13;
      mountData15.playerHeadOffset = 14;
      mountData15.standingFrameCount = 1;
      mountData15.standingFrameDelay = 12;
      mountData15.standingFrameStart = 0;
      mountData15.runningFrameCount = 3;
      mountData15.runningFrameDelay = 12;
      mountData15.runningFrameStart = 0;
      mountData15.flyingFrameCount = 0;
      mountData15.flyingFrameDelay = 0;
      mountData15.flyingFrameStart = 0;
      mountData15.inAirFrameCount = 0;
      mountData15.inAirFrameDelay = 0;
      mountData15.inAirFrameStart = 0;
      mountData15.idleFrameCount = 0;
      mountData15.idleFrameDelay = 0;
      mountData15.idleFrameStart = 0;
      mountData15.idleFrameLoop = false;
      if (Main.netMode != 2)
      {
        mountData15.backTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData15.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData15.frontTexture = TextureAssets.MinecartWoodMount;
        mountData15.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData15.textureWidth = mountData15.frontTexture.Width();
        mountData15.textureHeight = mountData15.frontTexture.Height();
      }
      Mount.MountData mountData16 = new Mount.MountData();
      Mount.mounts[14] = mountData16;
      mountData16.spawnDust = 15;
      mountData16.buff = 193;
      mountData16.heightBoost = 8;
      mountData16.flightTimeMax = 0;
      mountData16.fallDamage = 0.2f;
      mountData16.runSpeed = 8f;
      mountData16.acceleration = 0.25f;
      mountData16.jumpHeight = 20;
      mountData16.jumpSpeed = 8.01f;
      mountData16.totalFrames = 8;
      int[] numArray16 = new int[mountData16.totalFrames];
      for (int index = 0; index < numArray16.Length; ++index)
        numArray16[index] = 8;
      numArray16[1] += 2;
      numArray16[3] += 2;
      numArray16[6] += 2;
      mountData16.playerYOffsets = numArray16;
      mountData16.xOffset = 4;
      mountData16.bodyFrame = 3;
      mountData16.yOffset = 9;
      mountData16.playerHeadOffset = 10;
      mountData16.standingFrameCount = 1;
      mountData16.standingFrameDelay = 12;
      mountData16.standingFrameStart = 0;
      mountData16.runningFrameCount = 6;
      mountData16.runningFrameDelay = 30;
      mountData16.runningFrameStart = 2;
      mountData16.inAirFrameCount = 1;
      mountData16.inAirFrameDelay = 12;
      mountData16.inAirFrameStart = 1;
      mountData16.idleFrameCount = 0;
      mountData16.idleFrameDelay = 0;
      mountData16.idleFrameStart = 0;
      mountData16.idleFrameLoop = false;
      mountData16.swimFrameCount = mountData16.inAirFrameCount;
      mountData16.swimFrameDelay = mountData16.inAirFrameDelay;
      mountData16.swimFrameStart = mountData16.inAirFrameStart;
      if (Main.netMode != 2)
      {
        mountData16.backTexture = TextureAssets.BasiliskMount;
        mountData16.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData16.frontTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData16.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData16.textureWidth = mountData16.backTexture.Width();
        mountData16.textureHeight = mountData16.backTexture.Height();
      }
      Mount.MountData mountData17 = new Mount.MountData();
      Mount.mounts[17] = mountData17;
      mountData17.spawnDust = 15;
      mountData17.buff = 212;
      mountData17.heightBoost = 16;
      mountData17.flightTimeMax = 0;
      mountData17.fallDamage = 0.2f;
      mountData17.runSpeed = 8f;
      mountData17.acceleration = 0.25f;
      mountData17.jumpHeight = 20;
      mountData17.jumpSpeed = 8.01f;
      mountData17.totalFrames = 4;
      int[] numArray17 = new int[mountData17.totalFrames];
      for (int index = 0; index < numArray17.Length; ++index)
        numArray17[index] = 8;
      mountData17.playerYOffsets = numArray17;
      mountData17.xOffset = 2;
      mountData17.bodyFrame = 3;
      mountData17.yOffset = 17 - mountData17.heightBoost;
      mountData17.playerHeadOffset = 18;
      mountData17.standingFrameCount = 1;
      mountData17.standingFrameDelay = 12;
      mountData17.standingFrameStart = 0;
      mountData17.runningFrameCount = 4;
      mountData17.runningFrameDelay = 12;
      mountData17.runningFrameStart = 0;
      mountData17.inAirFrameCount = 1;
      mountData17.inAirFrameDelay = 12;
      mountData17.inAirFrameStart = 1;
      mountData17.idleFrameCount = 0;
      mountData17.idleFrameDelay = 0;
      mountData17.idleFrameStart = 0;
      mountData17.idleFrameLoop = false;
      mountData17.swimFrameCount = mountData17.inAirFrameCount;
      mountData17.swimFrameDelay = mountData17.inAirFrameDelay;
      mountData17.swimFrameStart = mountData17.inAirFrameStart;
      if (Main.netMode != 2)
      {
        mountData17.backTexture = TextureAssets.Extra[97];
        mountData17.backTextureExtra = TextureAssets.Extra[96];
        mountData17.frontTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData17.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData17.textureWidth = mountData17.backTextureExtra.Width();
        mountData17.textureHeight = mountData17.backTextureExtra.Height();
      }
      Mount.MountData mountData18 = new Mount.MountData();
      Mount.mounts[23] = mountData18;
      mountData18.spawnDust = 43;
      mountData18.spawnDustNoGravity = true;
      mountData18.buff = 230;
      mountData18.heightBoost = 0;
      mountData18.flightTimeMax = 320;
      mountData18.fatigueMax = 320;
      mountData18.fallDamage = 0.0f;
      mountData18.usesHover = true;
      mountData18.runSpeed = 8f;
      mountData18.dashSpeed = 8f;
      mountData18.acceleration = 0.16f;
      mountData18.jumpHeight = 10;
      mountData18.jumpSpeed = 4f;
      mountData18.blockExtraJumps = true;
      mountData18.totalFrames = 6;
      int[] numArray18 = new int[mountData18.totalFrames];
      for (int index = 0; index < numArray18.Length; ++index)
        numArray18[index] = 6;
      mountData18.playerYOffsets = numArray18;
      mountData18.xOffset = -2;
      mountData18.bodyFrame = 0;
      mountData18.yOffset = 8;
      mountData18.playerHeadOffset = 0;
      mountData18.standingFrameCount = 1;
      mountData18.standingFrameDelay = 0;
      mountData18.standingFrameStart = 0;
      mountData18.runningFrameCount = 1;
      mountData18.runningFrameDelay = 0;
      mountData18.runningFrameStart = 0;
      mountData18.flyingFrameCount = 1;
      mountData18.flyingFrameDelay = 0;
      mountData18.flyingFrameStart = 0;
      mountData18.inAirFrameCount = 6;
      mountData18.inAirFrameDelay = 8;
      mountData18.inAirFrameStart = 0;
      mountData18.idleFrameCount = 0;
      mountData18.idleFrameDelay = 0;
      mountData18.idleFrameStart = 0;
      mountData18.idleFrameLoop = true;
      mountData18.swimFrameCount = 0;
      mountData18.swimFrameDelay = 0;
      mountData18.swimFrameStart = 0;
      if (Main.netMode != 2)
      {
        mountData18.backTexture = TextureAssets.Extra[113];
        mountData18.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData18.frontTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData18.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData18.textureWidth = mountData18.backTexture.Width();
        mountData18.textureHeight = mountData18.backTexture.Height();
      }
      Mount.MountData mountData19 = new Mount.MountData();
      Mount.mounts[37] = mountData19;
      mountData19.spawnDust = 282;
      mountData19.buff = 265;
      mountData19.heightBoost = 12;
      mountData19.flightTimeMax = 0;
      mountData19.fallDamage = 0.2f;
      mountData19.runSpeed = 7.5f;
      mountData19.acceleration = 0.15f;
      mountData19.jumpHeight = 14;
      mountData19.jumpSpeed = 6.01f;
      mountData19.totalFrames = 10;
      int[] numArray19 = new int[mountData19.totalFrames];
      for (int index = 0; index < numArray19.Length; ++index)
        numArray19[index] = 20;
      mountData19.playerYOffsets = numArray19;
      mountData19.xOffset = 5;
      mountData19.bodyFrame = 4;
      mountData19.yOffset = 1;
      mountData19.playerHeadOffset = 20;
      mountData19.standingFrameCount = 1;
      mountData19.standingFrameDelay = 12;
      mountData19.standingFrameStart = 0;
      mountData19.runningFrameCount = 7;
      mountData19.runningFrameDelay = 20;
      mountData19.runningFrameStart = 2;
      mountData19.inAirFrameCount = 1;
      mountData19.inAirFrameDelay = 12;
      mountData19.inAirFrameStart = 1;
      mountData19.idleFrameCount = 0;
      mountData19.idleFrameDelay = 0;
      mountData19.idleFrameStart = 0;
      mountData19.idleFrameLoop = false;
      mountData19.swimFrameCount = mountData19.runningFrameCount;
      mountData19.swimFrameDelay = 10;
      mountData19.swimFrameStart = mountData19.runningFrameStart;
      if (Main.netMode != 2)
      {
        mountData19.backTexture = TextureAssets.Extra[149];
        mountData19.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData19.frontTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData19.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData19.textureWidth = mountData19.backTexture.Width();
        mountData19.textureHeight = mountData19.backTexture.Height();
      }
      Mount.MountData newMount22 = new Mount.MountData();
      Mount.mounts[40] = newMount22;
      Mount.SetAsHorse(newMount22, 275, TextureAssets.Extra[161]);
      Mount.MountData newMount23 = new Mount.MountData();
      Mount.mounts[41] = newMount23;
      Mount.SetAsHorse(newMount23, 276, TextureAssets.Extra[162]);
      Mount.MountData newMount24 = new Mount.MountData();
      Mount.mounts[42] = newMount24;
      Mount.SetAsHorse(newMount24, 277, TextureAssets.Extra[163]);
      Mount.MountData mountData20 = new Mount.MountData();
      Mount.mounts[43] = mountData20;
      mountData20.spawnDust = 15;
      mountData20.buff = 278;
      mountData20.heightBoost = 12;
      mountData20.flightTimeMax = 0;
      mountData20.fallDamage = 0.4f;
      mountData20.runSpeed = 5f;
      mountData20.acceleration = 0.1f;
      mountData20.jumpHeight = 8;
      mountData20.jumpSpeed = 8f;
      mountData20.constantJump = true;
      mountData20.totalFrames = 4;
      int[] numArray20 = new int[mountData20.totalFrames];
      for (int index = 0; index < numArray20.Length; ++index)
        numArray20[index] = 14;
      mountData20.playerYOffsets = numArray20;
      mountData20.xOffset = 5;
      mountData20.bodyFrame = 4;
      mountData20.yOffset = 10;
      mountData20.playerHeadOffset = 10;
      mountData20.standingFrameCount = 1;
      mountData20.standingFrameDelay = 5;
      mountData20.standingFrameStart = 0;
      mountData20.runningFrameCount = 4;
      mountData20.runningFrameDelay = 5;
      mountData20.runningFrameStart = 0;
      mountData20.inAirFrameCount = 1;
      mountData20.inAirFrameDelay = 5;
      mountData20.inAirFrameStart = 0;
      mountData20.idleFrameCount = 0;
      mountData20.idleFrameDelay = 0;
      mountData20.idleFrameStart = 0;
      mountData20.idleFrameLoop = false;
      mountData20.swimFrameCount = 1;
      mountData20.swimFrameDelay = 5;
      mountData20.swimFrameStart = 0;
      if (Main.netMode != 2)
      {
        mountData20.backTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData20.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData20.frontTexture = TextureAssets.Extra[164];
        mountData20.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData20.textureWidth = mountData20.frontTexture.Width();
        mountData20.textureHeight = mountData20.frontTexture.Height();
      }
      Mount.MountData mountData21 = new Mount.MountData();
      Mount.mounts[44] = mountData21;
      mountData21.spawnDust = 228;
      mountData21.buff = 279;
      mountData21.heightBoost = 24;
      mountData21.flightTimeMax = 320;
      mountData21.fatigueMax = 320;
      mountData21.fallDamage = 0.0f;
      mountData21.usesHover = true;
      mountData21.runSpeed = 8f;
      mountData21.dashSpeed = 16f;
      mountData21.acceleration = 0.1f;
      mountData21.jumpHeight = 3;
      mountData21.jumpSpeed = 1f;
      mountData21.swimSpeed = mountData21.runSpeed;
      mountData21.blockExtraJumps = true;
      mountData21.totalFrames = 10;
      int[] numArray21 = new int[mountData21.totalFrames];
      for (int index = 0; index < numArray21.Length; ++index)
        numArray21[index] = 9;
      mountData21.playerYOffsets = numArray21;
      mountData21.xOffset = 0;
      mountData21.bodyFrame = 3;
      mountData21.yOffset = 8;
      mountData21.playerHeadOffset = 16;
      mountData21.runningFrameCount = 10;
      mountData21.runningFrameDelay = 8;
      mountData21.runningFrameStart = 0;
      if (Main.netMode != 2)
      {
        mountData21.backTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData21.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData21.frontTexture = TextureAssets.Extra[166];
        mountData21.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData21.textureWidth = mountData21.frontTexture.Width();
        mountData21.textureHeight = mountData21.frontTexture.Height();
      }
      Mount.MountData mountData22 = new Mount.MountData();
      Mount.mounts[45] = mountData22;
      mountData22.spawnDust = 6;
      mountData22.buff = 280;
      mountData22.heightBoost = 25;
      mountData22.flightTimeMax = 0;
      mountData22.fallDamage = 0.1f;
      mountData22.runSpeed = 12f;
      mountData22.dashSpeed = 16f;
      mountData22.acceleration = 0.5f;
      mountData22.jumpHeight = 14;
      mountData22.jumpSpeed = 7f;
      mountData22.emitsLight = true;
      mountData22.lightColor = new Vector3(0.6f, 0.4f, 0.35f);
      mountData22.totalFrames = 8;
      int[] numArray22 = new int[mountData22.totalFrames];
      for (int index = 0; index < numArray22.Length; ++index)
        numArray22[index] = 30;
      mountData22.playerYOffsets = numArray22;
      mountData22.xOffset = 0;
      mountData22.bodyFrame = 0;
      mountData22.xOffset = 2;
      mountData22.yOffset = 1;
      mountData22.playerHeadOffset = 20;
      mountData22.standingFrameCount = 1;
      mountData22.standingFrameDelay = 20;
      mountData22.standingFrameStart = 0;
      mountData22.runningFrameCount = 6;
      mountData22.runningFrameDelay = 20;
      mountData22.runningFrameStart = 2;
      mountData22.inAirFrameCount = 1;
      mountData22.inAirFrameDelay = 20;
      mountData22.inAirFrameStart = 1;
      mountData22.swimFrameCount = mountData22.runningFrameCount;
      mountData22.swimFrameDelay = 20;
      mountData22.swimFrameStart = mountData22.runningFrameStart;
      if (Main.netMode != 2)
      {
        mountData22.backTexture = TextureAssets.Extra[167];
        mountData22.backTextureGlow = TextureAssets.GlowMask[283];
        mountData22.frontTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData22.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData22.textureWidth = mountData22.backTexture.Width();
        mountData22.textureHeight = mountData22.backTexture.Height();
      }
      Mount.MountData mountData23 = new Mount.MountData();
      Mount.mounts[46] = mountData23;
      mountData23.spawnDust = 15;
      mountData23.buff = 281;
      mountData23.heightBoost = 0;
      mountData23.flightTimeMax = 0;
      mountData23.fatigueMax = 0;
      mountData23.fallDamage = 0.0f;
      mountData23.abilityChargeMax = 40;
      mountData23.abilityCooldown = 40;
      mountData23.abilityDuration = 0;
      mountData23.runSpeed = 8f;
      mountData23.dashSpeed = 8f;
      mountData23.acceleration = 0.4f;
      mountData23.jumpHeight = 8;
      mountData23.jumpSpeed = 9.01f;
      mountData23.blockExtraJumps = false;
      mountData23.totalFrames = 27;
      int[] numArray23 = new int[mountData23.totalFrames];
      for (int index = 0; index < numArray23.Length; ++index)
      {
        numArray23[index] = 4;
        if (index == 1 || index == 2 || index == 7 || index == 8)
          numArray23[index] += 2;
      }
      mountData23.playerYOffsets = numArray23;
      mountData23.xOffset = 1;
      mountData23.bodyFrame = 3;
      mountData23.yOffset = 1;
      mountData23.playerHeadOffset = 2;
      mountData23.standingFrameCount = 1;
      mountData23.standingFrameDelay = 12;
      mountData23.standingFrameStart = 0;
      mountData23.runningFrameCount = 11;
      mountData23.runningFrameDelay = 12;
      mountData23.runningFrameStart = 0;
      mountData23.inAirFrameCount = 11;
      mountData23.inAirFrameDelay = 12;
      mountData23.inAirFrameStart = 1;
      mountData23.swimFrameCount = mountData23.runningFrameCount;
      mountData23.swimFrameDelay = mountData23.runningFrameDelay;
      mountData23.swimFrameStart = mountData23.runningFrameStart;
      Mount.santankTextureSize = new Vector2(23f, 2f);
      if (Main.netMode != 2)
      {
        mountData23.backTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData23.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData23.frontTexture = TextureAssets.Extra[168];
        mountData23.frontTextureExtra = TextureAssets.Extra[168];
        mountData23.textureWidth = mountData23.frontTexture.Width();
        mountData23.textureHeight = mountData23.frontTexture.Height();
      }
      Mount.MountData mountData24 = new Mount.MountData();
      Mount.mounts[47] = mountData24;
      mountData24.spawnDust = 5;
      mountData24.buff = 282;
      mountData24.heightBoost = 34;
      mountData24.flightTimeMax = 0;
      mountData24.fallDamage = 0.2f;
      mountData24.runSpeed = 4f;
      mountData24.dashSpeed = 12f;
      mountData24.acceleration = 0.3f;
      mountData24.jumpHeight = 10;
      mountData24.jumpSpeed = 8.01f;
      mountData24.totalFrames = 16;
      int[] numArray24 = new int[mountData24.totalFrames];
      for (int index = 0; index < numArray24.Length; ++index)
        numArray24[index] = 30;
      numArray24[3] += 2;
      numArray24[4] += 2;
      numArray24[7] += 2;
      numArray24[8] += 2;
      numArray24[12] += 2;
      numArray24[13] += 2;
      numArray24[15] += 4;
      mountData24.playerYOffsets = numArray24;
      mountData24.xOffset = 5;
      mountData24.bodyFrame = 3;
      mountData24.yOffset = -1;
      mountData24.playerHeadOffset = 34;
      mountData24.standingFrameCount = 1;
      mountData24.standingFrameDelay = 12;
      mountData24.standingFrameStart = 0;
      mountData24.runningFrameCount = 7;
      mountData24.runningFrameDelay = 15;
      mountData24.runningFrameStart = 1;
      mountData24.dashingFrameCount = 6;
      mountData24.dashingFrameDelay = 40;
      mountData24.dashingFrameStart = 9;
      mountData24.flyingFrameCount = 6;
      mountData24.flyingFrameDelay = 6;
      mountData24.flyingFrameStart = 1;
      mountData24.inAirFrameCount = 1;
      mountData24.inAirFrameDelay = 12;
      mountData24.inAirFrameStart = 15;
      mountData24.idleFrameCount = 0;
      mountData24.idleFrameDelay = 0;
      mountData24.idleFrameStart = 0;
      mountData24.idleFrameLoop = false;
      mountData24.swimFrameCount = mountData24.inAirFrameCount;
      mountData24.swimFrameDelay = mountData24.inAirFrameDelay;
      mountData24.swimFrameStart = mountData24.inAirFrameStart;
      if (Main.netMode != 2)
      {
        mountData24.backTexture = TextureAssets.Extra[169];
        mountData24.backTextureGlow = TextureAssets.GlowMask[284];
        mountData24.frontTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData24.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData24.textureWidth = mountData24.backTexture.Width();
        mountData24.textureHeight = mountData24.backTexture.Height();
      }
      Mount.MountData mountData25 = new Mount.MountData();
      Mount.mounts[48] = mountData25;
      mountData25.spawnDust = 62;
      mountData25.buff = 283;
      mountData25.heightBoost = 14;
      mountData25.flightTimeMax = 320;
      mountData25.fallDamage = 0.0f;
      mountData25.usesHover = true;
      mountData25.runSpeed = 8f;
      mountData25.dashSpeed = 8f;
      mountData25.acceleration = 0.2f;
      mountData25.jumpHeight = 5;
      mountData25.jumpSpeed = 6f;
      mountData25.swimSpeed = mountData25.runSpeed;
      mountData25.totalFrames = 6;
      int[] numArray25 = new int[mountData25.totalFrames];
      for (int index = 0; index < numArray25.Length; ++index)
        numArray25[index] = 9;
      numArray25[0] += 6;
      numArray25[1] += 6;
      numArray25[2] += 4;
      numArray25[3] += 4;
      numArray25[4] += 4;
      numArray25[5] += 6;
      mountData25.playerYOffsets = numArray25;
      mountData25.xOffset = 1;
      mountData25.bodyFrame = 0;
      mountData25.yOffset = 16;
      mountData25.playerHeadOffset = 16;
      mountData25.runningFrameCount = 6;
      mountData25.runningFrameDelay = 8;
      mountData25.runningFrameStart = 0;
      if (Main.netMode != 2)
      {
        mountData25.backTexture = TextureAssets.Extra[170];
        mountData25.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData25.frontTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData25.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData25.textureWidth = mountData25.backTexture.Width();
        mountData25.textureHeight = mountData25.backTexture.Height();
      }
      Mount.MountData mountData26 = new Mount.MountData();
      Mount.mounts[49] = mountData26;
      mountData26.spawnDust = 35;
      mountData26.buff = 305;
      mountData26.heightBoost = 8;
      mountData26.runSpeed = 2f;
      mountData26.dashSpeed = 1f;
      mountData26.acceleration = 0.4f;
      mountData26.jumpHeight = 4;
      mountData26.jumpSpeed = 3f;
      mountData26.swimSpeed = 14f;
      mountData26.blockExtraJumps = true;
      mountData26.flightTimeMax = 0;
      mountData26.fatigueMax = 320;
      mountData26.usesHover = true;
      mountData26.emitsLight = true;
      mountData26.lightColor = new Vector3(0.3f, 0.15f, 0.1f);
      mountData26.totalFrames = 8;
      int[] numArray26 = new int[mountData26.totalFrames];
      for (int index = 0; index < numArray26.Length; ++index)
        numArray26[index] = 10;
      mountData26.playerYOffsets = numArray26;
      mountData26.xOffset = 2;
      mountData26.bodyFrame = 3;
      mountData26.yOffset = 1;
      mountData26.playerHeadOffset = 16;
      mountData26.standingFrameCount = 1;
      mountData26.standingFrameDelay = 12;
      mountData26.standingFrameStart = 4;
      mountData26.runningFrameCount = 4;
      mountData26.runningFrameDelay = 14;
      mountData26.runningFrameStart = 4;
      mountData26.inAirFrameCount = 1;
      mountData26.inAirFrameDelay = 6;
      mountData26.inAirFrameStart = 4;
      mountData26.swimFrameCount = 4;
      mountData26.swimFrameDelay = 16;
      mountData26.swimFrameStart = 0;
      if (Main.netMode != 2)
      {
        mountData26.backTexture = TextureAssets.Extra[172];
        mountData26.backTextureGlow = TextureAssets.GlowMask[285];
        mountData26.frontTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData26.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
        mountData26.textureWidth = mountData26.backTexture.Width();
        mountData26.textureHeight = mountData26.backTexture.Height();
      }
      Mount.MountData mountData27 = new Mount.MountData();
      Mount.mounts[50] = mountData27;
      mountData27.spawnDust = 243;
      mountData27.buff = 318;
      mountData27.heightBoost = 20;
      mountData27.flightTimeMax = 160;
      mountData27.fallDamage = 0.5f;
      mountData27.runSpeed = 6.5f;
      mountData27.dashSpeed = 6.5f;
      mountData27.acceleration = 0.2f;
      mountData27.jumpHeight = 10;
      mountData27.jumpSpeed = 7.25f;
      mountData27.constantJump = true;
      mountData27.totalFrames = 8;
      int[] numArray27 = new int[mountData27.totalFrames];
      for (int index = 0; index < numArray27.Length; ++index)
        numArray27[index] = 20;
      numArray27[1] += 2;
      numArray27[4] += 2;
      numArray27[5] += 2;
      mountData27.playerYOffsets = numArray27;
      mountData27.xOffset = 1;
      mountData27.bodyFrame = 3;
      mountData27.yOffset = -1;
      mountData27.playerHeadOffset = 22;
      mountData27.standingFrameCount = 1;
      mountData27.standingFrameDelay = 12;
      mountData27.standingFrameStart = 0;
      mountData27.runningFrameCount = 5;
      mountData27.runningFrameDelay = 16;
      mountData27.runningFrameStart = 0;
      mountData27.flyingFrameCount = 0;
      mountData27.flyingFrameDelay = 0;
      mountData27.flyingFrameStart = 0;
      mountData27.inAirFrameCount = 1;
      mountData27.inAirFrameDelay = 12;
      mountData27.inAirFrameStart = 5;
      mountData27.idleFrameCount = 0;
      mountData27.idleFrameDelay = 0;
      mountData27.idleFrameStart = 0;
      mountData27.idleFrameLoop = false;
      if (Main.netMode == 2)
        return;
      mountData27.backTexture = TextureAssets.Extra[204];
      mountData27.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
      mountData27.frontTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
      mountData27.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
      mountData27.textureWidth = mountData27.backTexture.Width();
      mountData27.textureHeight = mountData27.backTexture.Height();
    }

    private static void SetAsHorse(Mount.MountData newMount, int buff, Asset<Texture2D> texture)
    {
      newMount.spawnDust = 3;
      newMount.buff = buff;
      newMount.heightBoost = 34;
      newMount.flightTimeMax = 0;
      newMount.fallDamage = 0.5f;
      newMount.runSpeed = 3f;
      newMount.dashSpeed = 8f;
      newMount.acceleration = 0.25f;
      newMount.jumpHeight = 6;
      newMount.jumpSpeed = 7.01f;
      newMount.totalFrames = 16;
      int[] numArray = new int[newMount.totalFrames];
      for (int index = 0; index < numArray.Length; ++index)
        numArray[index] = 28;
      numArray[3] += 2;
      numArray[4] += 2;
      numArray[7] += 2;
      numArray[8] += 2;
      numArray[12] += 2;
      numArray[13] += 2;
      numArray[15] += 4;
      newMount.playerYOffsets = numArray;
      newMount.xOffset = 5;
      newMount.bodyFrame = 3;
      newMount.yOffset = 1;
      newMount.playerHeadOffset = 34;
      newMount.standingFrameCount = 1;
      newMount.standingFrameDelay = 12;
      newMount.standingFrameStart = 0;
      newMount.runningFrameCount = 7;
      newMount.runningFrameDelay = 15;
      newMount.runningFrameStart = 1;
      newMount.dashingFrameCount = 6;
      newMount.dashingFrameDelay = 40;
      newMount.dashingFrameStart = 9;
      newMount.flyingFrameCount = 6;
      newMount.flyingFrameDelay = 6;
      newMount.flyingFrameStart = 1;
      newMount.inAirFrameCount = 1;
      newMount.inAirFrameDelay = 12;
      newMount.inAirFrameStart = 15;
      newMount.idleFrameCount = 0;
      newMount.idleFrameDelay = 0;
      newMount.idleFrameStart = 0;
      newMount.idleFrameLoop = false;
      newMount.swimFrameCount = newMount.inAirFrameCount;
      newMount.swimFrameDelay = newMount.inAirFrameDelay;
      newMount.swimFrameStart = newMount.inAirFrameStart;
      if (Main.netMode == 2)
        return;
      newMount.backTexture = texture;
      newMount.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
      newMount.frontTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
      newMount.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
      newMount.textureWidth = newMount.backTexture.Width();
      newMount.textureHeight = newMount.backTexture.Height();
    }

    private static void SetAsMinecart(
      Mount.MountData newMount,
      int buffToLeft,
      int buffToRight,
      Asset<Texture2D> texture)
    {
      newMount.Minecart = true;
      newMount.delegations = new Mount.MountDelegatesData();
      newMount.delegations.MinecartDust = new Action<Vector2>(DelegateMethods.Minecart.Sparks);
      newMount.spawnDust = 213;
      newMount.buff = buffToLeft;
      newMount.extraBuff = buffToRight;
      newMount.heightBoost = 10;
      newMount.flightTimeMax = 0;
      newMount.fallDamage = 1f;
      newMount.runSpeed = 13f;
      newMount.dashSpeed = 13f;
      newMount.acceleration = 0.04f;
      newMount.jumpHeight = 15;
      newMount.jumpSpeed = 5.15f;
      newMount.blockExtraJumps = true;
      newMount.totalFrames = 3;
      int[] numArray = new int[newMount.totalFrames];
      for (int index = 0; index < numArray.Length; ++index)
        numArray[index] = 8;
      newMount.playerYOffsets = numArray;
      newMount.xOffset = 1;
      newMount.bodyFrame = 3;
      newMount.yOffset = 13;
      newMount.playerHeadOffset = 14;
      newMount.standingFrameCount = 1;
      newMount.standingFrameDelay = 12;
      newMount.standingFrameStart = 0;
      newMount.runningFrameCount = 3;
      newMount.runningFrameDelay = 12;
      newMount.runningFrameStart = 0;
      newMount.flyingFrameCount = 0;
      newMount.flyingFrameDelay = 0;
      newMount.flyingFrameStart = 0;
      newMount.inAirFrameCount = 0;
      newMount.inAirFrameDelay = 0;
      newMount.inAirFrameStart = 0;
      newMount.idleFrameCount = 0;
      newMount.idleFrameDelay = 0;
      newMount.idleFrameStart = 0;
      newMount.idleFrameLoop = false;
      if (Main.netMode == 2)
        return;
      newMount.backTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
      newMount.backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
      newMount.frontTexture = texture;
      newMount.frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
      newMount.textureWidth = newMount.frontTexture.Width();
      newMount.textureHeight = newMount.frontTexture.Height();
    }

    public bool Active => this._active;

    public int Type => this._type;

    public int FlyTime => this._flyTime;

    public int BuffType => this._data.buff;

    public int BodyFrame => this._data.bodyFrame;

    public int XOffset => this._data.xOffset;

    public int YOffset => this._data.yOffset;

    public int PlayerOffset => !this._active ? 0 : this._data.playerYOffsets[this._frame];

    public int PlayerOffsetHitbox => !this._active ? 0 : -this.PlayerOffset + this._data.heightBoost;

    public int PlayerHeadOffset => !this._active ? 0 : this._data.playerHeadOffset;

    public int HeightBoost => this._data.heightBoost;

    public static int GetHeightBoost(int MountType) => MountType <= -1 || MountType >= MountID.Count ? 0 : Mount.mounts[MountType].heightBoost;

    public float RunSpeed
    {
      get
      {
        if (this._type == 4 && this._frameState == 4 || (this._type == 12 || this._type == 44 || this._type == 49) && this._frameState == 4)
          return this._data.swimSpeed;
        if (this._type == 12 && this._frameState == 2)
          return this._data.runSpeed + 13.5f;
        if (this._type == 44 && this._frameState == 2)
          return this._data.runSpeed + 4f;
        if (this._type == 5 && this._frameState == 2)
          return this._data.runSpeed + (float) (4.0 * (1.0 - (double) (this._fatigue / this._fatigueMax)));
        return this._type == 50 && this._frameState == 2 ? this._data.runSpeed + 4f : this._data.runSpeed;
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
        case 49:
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
        case 49:
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

    public bool IsConsideredASlimeMount => this._type == 3 || this._type == 50;

    public bool Cart => this._data != null && this._active && this._data.Minecart;

    public bool Directional => this._data == null || this._data.MinecartDirectional;

    public Mount.MountDelegatesData Delegations => this._data == null ? this._defaultDelegatesData : this._data.delegations;

    public Vector2 Origin => new Vector2((float) this._data.textureWidth / 2f, (float) this._data.textureHeight / (2f * (float) this._data.totalFrames));

    public bool CanFly() => this._active && this._data.flightTimeMax != 0 && this._type != 48;

    public bool CanHover()
    {
      if (!this._active || !this._data.usesHover)
        return false;
      if (this._type == 49)
        return this._frameState == 4;
      return this._data.usesHover;
    }

    public bool AbilityCharging => this._abilityCharging;

    public bool AbilityActive => this._abilityActive;

    public float AbilityCharge => (float) this._abilityCharge / (float) this._data.abilityChargeMax;

    public void StartAbilityCharge(Player mountedPlayer)
    {
      if (Main.myPlayer == mountedPlayer.whoAmI)
      {
        if (this._type != 9)
          return;
        int Type = 441;
        double num = (double) Main.screenPosition.X + (double) Main.mouseX;
        float Y = Main.screenPosition.Y + (float) Main.mouseY;
        float ai0 = (float) num - mountedPlayer.position.X;
        float ai1 = Y - mountedPlayer.position.Y;
        Projectile.NewProjectile((float) num, Y, 0.0f, 0.0f, Type, 0, 0.0f, mountedPlayer.whoAmI, ai0, ai1);
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
      switch (this._type)
      {
        case 9:
        case 46:
          this._abilityCharging = false;
          this._abilityCooldown = this._data.abilityCooldown;
          this._abilityDuration = this._data.abilityDuration;
          break;
      }
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
              Tile.SmoothSlope((int) point16.X, (int) point16.Y, sync: true);
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
      Utils.TileActionAttempt plot = (Utils.TileActionAttempt) ((x, y) =>
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
          int Type1 = 606;
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
            Projectile.NewProjectile(vector2_2.X, vector2_2.Y, vector2_4.X, vector2_4.Y, Type1, Damage, 0.0f, Main.myPlayer);
          }
          break;
        case 46:
          if (Main.myPlayer != mountedPlayer.whoAmI)
            break;
          if (this._abilityCooldown <= 10)
          {
            int Damage = 120;
            Vector2 vector2_5 = mountedPlayer.Center + new Vector2((float) (mountedPlayer.width * -mountedPlayer.direction), 26f);
            Vector2 vector2_6 = new Vector2(0.0f, -4f).RotatedByRandom(0.100000001490116);
            Projectile.NewProjectile(vector2_5.X, vector2_5.Y, vector2_6.X, vector2_6.Y, 930, Damage, 0.0f, Main.myPlayer);
            SoundEngine.PlaySound(SoundID.Item89.SoundId, (int) vector2_5.X, (int) vector2_5.Y, SoundID.Item89.Style, 0.2f);
          }
          int Type2 = 14;
          int Damage1 = 100;
          mousePosition = this.ClampToDeadZone(mountedPlayer, mousePosition);
          Vector2 vector2_7;
          vector2_7.X = mountedPlayer.position.X + (float) (mountedPlayer.width / 2);
          vector2_7.Y = mountedPlayer.position.Y + (float) mountedPlayer.height;
          Vector2 vector2_8 = new Vector2(vector2_7.X + (float) (mountedPlayer.width * mountedPlayer.direction), vector2_7.Y - 12f);
          Vector2 vector2_9 = ((mousePosition - vector2_8).SafeNormalize(Vector2.Zero) * 12f).RotatedByRandom(0.200000002980232);
          Projectile.NewProjectile(vector2_8.X, vector2_8.Y, vector2_9.X, vector2_9.Y, Type2, Damage1, 0.0f, Main.myPlayer);
          SoundEngine.PlaySound(SoundID.Item11.SoundId, (int) vector2_8.X, (int) vector2_8.Y, SoundID.Item11.Style, 0.2f);
          break;
      }
    }

    public bool Hover(Player mountedPlayer)
    {
      bool flag1 = this.DoesHoverIgnoresFatigue();
      bool flag2 = this._frameState == 2 || this._frameState == 4;
      if (this._type == 49)
        flag2 = this._frameState == 4;
      if (flag2)
      {
        bool flag3 = true;
        float num1 = 1f;
        float num2 = mountedPlayer.gravity / Player.defaultGravity;
        if (mountedPlayer.slowFall)
          num2 /= 3f;
        if ((double) num2 < 0.25)
          num2 = 0.25f;
        if (!flag1)
        {
          if (this._flyTime > 0)
            --this._flyTime;
          else if ((double) this._fatigue < (double) this._fatigueMax)
            this._fatigue += num2;
          else
            flag3 = false;
        }
        if (this._type == 12 && !mountedPlayer.MountFishronSpecial)
          num1 = 0.5f;
        float num3 = this._fatigue / this._fatigueMax;
        if (flag1)
          num3 = 0.0f;
        bool flag4 = true;
        if (this._type == 48)
          flag4 = false;
        float num4 = 4f * num3;
        float num5 = 4f * num3;
        bool flag5 = false;
        if (this._type == 48)
        {
          num4 = 0.0f;
          num5 = 0.0f;
          if (!flag3)
            flag5 = true;
          if (mountedPlayer.controlDown)
            num5 = 8f;
        }
        if ((double) num4 == 0.0)
          num4 = -1f / 1000f;
        if ((double) num5 == 0.0)
          num5 = -1f / 1000f;
        float num6 = mountedPlayer.velocity.Y;
        if (((!flag4 ? 0 : (mountedPlayer.controlUp ? 1 : (mountedPlayer.controlJump ? 1 : 0))) & (flag3 ? 1 : 0)) != 0)
        {
          num4 = (float) (-2.0 - 6.0 * (1.0 - (double) num3));
          if (this._type == 48)
            num4 /= 3f;
          num6 -= this._data.acceleration * num1;
        }
        else if (mountedPlayer.controlDown)
        {
          num6 += this._data.acceleration * num1;
          num5 = 8f;
        }
        else if (flag5)
        {
          float num7 = mountedPlayer.gravity * mountedPlayer.gravDir;
          num6 += num7;
          num5 = 4f;
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
        if ((double) num4 == -1.0 / 1000.0 && (double) num5 == -1.0 / 1000.0 && (double) num6 == -1.0 / 1000.0)
          mountedPlayer.position.Y -= -1f / 1000f;
        mountedPlayer.fallStart = (int) ((double) mountedPlayer.position.Y / 16.0);
      }
      else if (!flag1)
        mountedPlayer.velocity.Y += mountedPlayer.gravity * mountedPlayer.gravDir;
      else if ((double) mountedPlayer.velocity.Y == 0.0)
      {
        Vector2 Velocity = Vector2.UnitY * mountedPlayer.gravDir * 1f;
        if ((double) Collision.TileCollision(mountedPlayer.position, Velocity, mountedPlayer.width, mountedPlayer.height, gravDir: ((int) mountedPlayer.gravDir)).Y != 0.0 || mountedPlayer.controlDown)
          mountedPlayer.velocity.Y = 1f / 1000f;
      }
      else if ((double) mountedPlayer.velocity.Y == -1.0 / 1000.0)
        mountedPlayer.velocity.Y -= -1f / 1000f;
      if (this._type == 7)
      {
        float num8 = mountedPlayer.velocity.X / this._data.dashSpeed;
        if ((double) num8 > 0.95)
          num8 = 0.95f;
        if ((double) num8 < -0.95)
          num8 = -0.95f;
        float num9 = (float) (0.785398185253143 * (double) num8 / 2.0);
        float num10 = Math.Abs((float) (2.0 - (double) this._frame / 2.0)) / 2f;
        Lighting.AddLight((int) ((double) mountedPlayer.position.X + (double) (mountedPlayer.width / 2)) / 16, (int) ((double) mountedPlayer.position.Y + (double) (mountedPlayer.height / 2)) / 16, 0.4f, 0.2f * num10, 0.0f);
        mountedPlayer.fullRotation = num9;
      }
      else if (this._type == 8)
      {
        float num11 = mountedPlayer.velocity.X / this._data.dashSpeed;
        if ((double) num11 > 0.95)
          num11 = 0.95f;
        if ((double) num11 < -0.95)
          num11 = -0.95f;
        float num12 = (float) (0.785398185253143 * (double) num11 / 2.0);
        mountedPlayer.fullRotation = num12;
        Mount.DrillMountData mountSpecificData = (Mount.DrillMountData) this._mountSpecificData;
        float num13 = mountSpecificData.outerRingRotation + mountedPlayer.velocity.X / 80f;
        if ((double) num13 > 3.14159274101257)
          num13 -= 6.283185f;
        else if ((double) num13 < -3.14159274101257)
          num13 += 6.283185f;
        mountSpecificData.outerRingRotation = num13;
      }
      else if (this._type == 23)
      {
        float num14 = MathHelper.Clamp(-mountedPlayer.velocity.Y / this._data.dashSpeed, -1f, 1f);
        float num15 = MathHelper.Clamp(mountedPlayer.velocity.X / this._data.dashSpeed, -1f, 1f);
        float num16 = -0.1963495f * num14 * (float) mountedPlayer.direction + 0.1963495f * num15;
        mountedPlayer.fullRotation = num16;
        mountedPlayer.fullRotationOrigin = new Vector2((float) (mountedPlayer.width / 2), (float) mountedPlayer.height);
      }
      return true;
    }

    private bool DoesHoverIgnoresFatigue() => this._type == 7 || this._type == 8 || this._type == 12 || this._type == 23 || this._type == 44 || this._type == 49;

    private float GetWitchBroomTrinketRotation(Player player)
    {
      float num1 = Utils.Clamp<float>(player.velocity.X / 10f, -1f, 1f);
      Point tileCoordinates = player.Center.ToTileCoordinates();
      float num2 = 0.5f;
      if (WorldGen.InAPlaceWithWind(tileCoordinates.X, tileCoordinates.Y, 1, 1))
        num2 = 1f;
      float num3 = (float) (Math.Sin((double) player.miscCounter / 300.0 * 6.28318548202515 * 3.0) * 0.785398185253143 * (double) Math.Abs(Main.WindForVisuals) * 0.5 + 0.785398185253143 * -(double) Main.WindForVisuals * 0.5) * num2;
      return (float) ((double) num1 * Math.Sin((double) player.miscCounter / 150.0 * 6.28318548202515 * 3.0) * 0.785398185253143 * 0.5 + (double) num1 * 0.785398185253143 * 0.5) + num3;
    }

    private Vector2 GetWitchBroomTrinketOriginOffset(Player player) => new Vector2((float) (27 * player.direction), 5f);

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
        case 40:
        case 41:
        case 42:
        case 47:
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
            if (((this._type == 10 ? 1 : (this._type == 47 ? 1 : 0)) & (flag2 ? 1 : 0)) != 0)
            {
              int Type = 6;
              if (this._type == 10)
                Type = Utils.SelectRandom<int>(Main.rand, 176, 177, 179);
              Vector2 Position = mountedPlayer.Center + new Vector2((float) (mountedPlayer.width * mountedPlayer.direction), 0.0f);
              Vector2 vector2_1 = new Vector2(40f, 30f);
              float num8 = 6.283185f * Main.rand.NextFloat();
              for (float num9 = 0.0f; (double) num9 < 14.0; ++num9)
              {
                Dust dust = Main.dust[Dust.NewDust(Position, 0, 0, Type)];
                Vector2 vector2_2 = Vector2.UnitY.RotatedBy((double) num9 * 6.28318548202515 / 14.0 + (double) num8) * (0.2f * (float) this._frameExtra);
                dust.position = Position + vector2_2 * vector2_1;
                dust.velocity = vector2_2 + new Vector2(this.RunSpeed - (float) (Math.Sign(velocity.X) * this._frameExtra * 2), 0.0f);
                dust.noGravity = true;
                if (this._type == 47)
                  dust.noLightEmittence = true;
                dust.scale = (float) (1.0 + (double) Main.rand.NextFloat() * 0.800000011920929);
                dust.fadeIn = Main.rand.NextFloat() * 2f;
                dust.shader = GameShaders.Armor.GetSecondaryShader(mountedPlayer.cMount, mountedPlayer);
              }
            }
          }
          if (this._type == 10 & flag1)
          {
            Dust dust = Main.dust[Dust.NewDust(mountedPlayer.position, mountedPlayer.width, mountedPlayer.height, Utils.SelectRandom<int>(Main.rand, 176, 177, 179))];
            dust.velocity = Vector2.Zero;
            dust.noGravity = true;
            dust.scale = (float) (0.5 + (double) Main.rand.NextFloat() * 0.800000011920929);
            dust.fadeIn = (float) (1.0 + (double) Main.rand.NextFloat() * 2.0);
            dust.shader = GameShaders.Armor.GetSecondaryShader(mountedPlayer.cMount, mountedPlayer);
          }
          if (this._type == 47 & flag1 && (double) velocity.Y == 0.0)
          {
            int i = (int) mountedPlayer.Center.X / 16;
            int num = (int) ((double) mountedPlayer.position.Y + (double) mountedPlayer.height - 1.0) / 16;
            Tile tile = Main.tile[i, num + 1];
            if (tile != null && tile.active() && tile.liquid == (byte) 0 && WorldGen.SolidTileAllowBottomSlope(i, num + 1))
            {
              ParticleOrchestrator.RequestParticleSpawn(true, ParticleOrchestraType.WallOfFleshGoatMountFlames, new ParticleOrchestraSettings()
              {
                PositionInWorld = new Vector2((float) (i * 16 + 8), (float) (num * 16 + 16))
              }, new int?(mountedPlayer.whoAmI));
              break;
            }
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
        case 17:
          this.UpdateFrame_GolfCart(mountedPlayer, state, velocity);
          break;
        case 39:
          ++this._frameExtraCounter;
          if ((double) this._frameExtraCounter > 6.0)
          {
            this._frameExtraCounter = 0.0f;
            ++this._frameExtra;
            if (this._frameExtra > 5)
            {
              this._frameExtra = 0;
              break;
            }
            break;
          }
          break;
        case 43:
          if ((double) mountedPlayer.velocity.Y == 0.0)
            mountedPlayer.isPerformingPogostickTricks = false;
          if (mountedPlayer.isPerformingPogostickTricks)
            mountedPlayer.fullRotation += (float) ((double) mountedPlayer.direction * 6.28318548202515 / 30.0);
          else
            mountedPlayer.fullRotation = (float) ((double) Math.Sign(mountedPlayer.velocity.X) * (double) Utils.GetLerpValue(0.0f, this.RunSpeed - 0.2f, Math.Abs(mountedPlayer.velocity.X), true) * 0.400000005960464);
          mountedPlayer.fullRotationOrigin = new Vector2((float) (mountedPlayer.width / 2), (float) mountedPlayer.height * 0.8f);
          break;
        case 44:
          state = 1;
          bool flag3 = (double) Math.Abs(velocity.X) > (double) this.DashSpeed - (double) this.RunSpeed / 4.0;
          if (this._mountSpecificData == null)
            this._mountSpecificData = (object) false;
          bool mountSpecificData1 = (bool) this._mountSpecificData;
          if (mountSpecificData1 && !flag3)
            this._mountSpecificData = (object) false;
          else if (!mountSpecificData1 & flag3)
          {
            this._mountSpecificData = (object) true;
            Vector2 Position = mountedPlayer.Center + new Vector2((float) (mountedPlayer.width * mountedPlayer.direction), 0.0f);
            Vector2 vector2_3 = new Vector2(40f, 30f);
            float num13 = 6.283185f * Main.rand.NextFloat();
            for (float num14 = 0.0f; (double) num14 < 20.0; ++num14)
            {
              Dust dust = Main.dust[Dust.NewDust(Position, 0, 0, 228)];
              Vector2 vector2_4 = Vector2.UnitY.RotatedBy((double) num14 * 6.28318548202515 / 20.0 + (double) num13) * 0.8f;
              dust.position = Position + vector2_4 * vector2_3;
              dust.velocity = vector2_4 + new Vector2(this.RunSpeed - (float) Math.Sign(velocity.Length()), 0.0f);
              if ((double) velocity.X > 0.0)
                dust.velocity.X *= -1f;
              if (Main.rand.Next(2) == 0)
                dust.velocity *= 0.5f;
              dust.noGravity = true;
              dust.scale = (float) (1.5 + (double) Main.rand.NextFloat() * 0.800000011920929);
              dust.fadeIn = 0.0f;
              dust.shader = GameShaders.Armor.GetSecondaryShader(mountedPlayer.cMount, mountedPlayer);
            }
          }
          int maxValue = (int) this.RunSpeed - (int) Math.Abs(velocity.X);
          if (maxValue <= 0)
            maxValue = 1;
          if (Main.rand.Next(maxValue) == 0)
          {
            int Height = 22;
            int num15 = mountedPlayer.width / 2 + 10;
            Vector2 bottom = mountedPlayer.Bottom;
            bottom.X -= (float) num15;
            bottom.Y -= (float) (Height - 6);
            Dust dust = Main.dust[Dust.NewDust(bottom, num15 * 2, Height, 228)];
            dust.velocity = Vector2.Zero;
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale = (float) (0.25 + (double) Main.rand.NextFloat() * 0.800000011920929);
            dust.fadeIn = (float) (0.5 + (double) Main.rand.NextFloat() * 2.0);
            dust.shader = GameShaders.Armor.GetSecondaryShader(mountedPlayer.cMount, mountedPlayer);
            break;
          }
          break;
        case 45:
          bool flag4 = (double) Math.Abs(velocity.X) > (double) this.DashSpeed * 0.899999976158142;
          if (this._mountSpecificData == null)
            this._mountSpecificData = (object) false;
          bool mountSpecificData2 = (bool) this._mountSpecificData;
          if (mountSpecificData2 && !flag4)
            this._mountSpecificData = (object) false;
          else if (!mountSpecificData2 & flag4)
          {
            this._mountSpecificData = (object) true;
            Vector2 Position = mountedPlayer.Center + new Vector2((float) (mountedPlayer.width * mountedPlayer.direction), 0.0f);
            Vector2 vector2_5 = new Vector2(40f, 30f);
            float num16 = 6.283185f * Main.rand.NextFloat();
            for (float num17 = 0.0f; (double) num17 < 20.0; ++num17)
            {
              Dust dust = Main.dust[Dust.NewDust(Position, 0, 0, 6)];
              Vector2 vector2_6 = Vector2.UnitY.RotatedBy((double) num17 * 6.28318548202515 / 20.0 + (double) num16) * 0.8f;
              dust.position = Position + vector2_6 * vector2_5;
              dust.velocity = vector2_6 + new Vector2(this.RunSpeed - (float) Math.Sign(velocity.Length()), 0.0f);
              if ((double) velocity.X > 0.0)
                dust.velocity.X *= -1f;
              if (Main.rand.Next(2) == 0)
                dust.velocity *= 0.5f;
              dust.noGravity = true;
              dust.scale = (float) (1.5 + (double) Main.rand.NextFloat() * 0.800000011920929);
              dust.fadeIn = 0.0f;
              dust.shader = GameShaders.Armor.GetSecondaryShader(mountedPlayer.cMount, mountedPlayer);
            }
          }
          if (flag4)
          {
            int Type = (int) Utils.SelectRandom<short>(Main.rand, (short) 6, (short) 6, (short) 31);
            int num18 = 6;
            Dust dust = Main.dust[Dust.NewDust(mountedPlayer.Center - new Vector2((float) num18, (float) (num18 - 12)), num18 * 2, num18 * 2, Type)];
            dust.velocity = mountedPlayer.velocity * 0.1f;
            if (Main.rand.Next(2) == 0)
              dust.noGravity = true;
            dust.scale = (float) (0.699999988079071 + (double) Main.rand.NextFloat() * 0.800000011920929);
            if (Main.rand.Next(3) == 0)
              dust.fadeIn = 0.1f;
            if (Type == 31)
            {
              dust.noGravity = true;
              dust.scale *= 1.5f;
              dust.fadeIn = 0.2f;
            }
            dust.shader = GameShaders.Armor.GetSecondaryShader(mountedPlayer.cMount, mountedPlayer);
            break;
          }
          break;
        case 46:
          if (state != 0)
            state = 1;
          if (!this._aiming)
          {
            if (state == 0)
            {
              this._frameExtra = 12;
              this._frameExtraCounter = 0.0f;
              break;
            }
            if (this._frameExtra < 12)
              this._frameExtra = 12;
            this._frameExtraCounter += Math.Abs(velocity.X);
            if ((double) this._frameExtraCounter >= 8.0)
            {
              this._frameExtraCounter = 0.0f;
              ++this._frameExtra;
              if (this._frameExtra >= 24)
              {
                this._frameExtra = 12;
                break;
              }
              break;
            }
            break;
          }
          if (this._frameExtra < 24)
            this._frameExtra = 24;
          ++this._frameExtraCounter;
          if ((double) this._frameExtraCounter >= 3.0)
          {
            this._frameExtraCounter = 0.0f;
            ++this._frameExtra;
            if (this._frameExtra >= 27)
            {
              this._frameExtra = 24;
              break;
            }
            break;
          }
          break;
        case 48:
          state = 1;
          break;
        case 49:
          if (state != 4 && mountedPlayer.wet)
            this._frameState = state = 4;
          double num19 = (double) velocity.Length();
          float num20 = mountedPlayer.velocity.Y * 0.05f;
          if (mountedPlayer.direction < 0)
            num20 *= -1f;
          mountedPlayer.fullRotation = num20;
          mountedPlayer.fullRotationOrigin = new Vector2((float) (mountedPlayer.width / 2), (float) (mountedPlayer.height / 2));
          break;
        case 50:
          if ((double) mountedPlayer.velocity.Y == 0.0)
          {
            this._frameExtraCounter = 0.0f;
            this._frameExtra = 3;
            break;
          }
          ++this._frameExtraCounter;
          if (this.Flight())
            ++this._frameExtraCounter;
          if ((double) this._frameExtraCounter > 7.0)
          {
            this._frameExtraCounter = 0.0f;
            ++this._frameExtra;
            if (this._frameExtra > 3)
            {
              this._frameExtra = 0;
              break;
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
            {
              this._idleTimeNext = Main.rand.Next(900, 1500);
              if (this._type == 17)
                this._idleTimeNext = Main.rand.Next(120, 300);
            }
            ++this._idleTime;
          }
          ++this._frameCounter;
          if (this._data.idleFrameCount != 0 && this._idleTime >= this._idleTimeNext)
          {
            float idleFrameDelay = (float) this._data.idleFrameDelay;
            if (this._type == 5)
              idleFrameDelay *= (float) (2.0 - 1.0 * (double) this._fatigue / (double) this._fatigueMax);
            int num21 = (int) ((double) (this._idleTime - this._idleTimeNext) / (double) idleFrameDelay);
            int idleFrameCount = this._data.idleFrameCount;
            if (num21 >= idleFrameCount)
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
              this._frame = this._data.idleFrameStart + num21;
            if (this._type == 5)
              this._frameExtra = this._frame;
            if (this._type != 17)
              break;
            this._frameExtra = this._frame;
            this._frame = 0;
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
          float num22;
          switch (this._type)
          {
            case 6:
              num22 = this._flipDraw ? velocity.X : -velocity.X;
              break;
            case 9:
            case 46:
              num22 = !this._flipDraw ? Math.Abs(velocity.X) : -Math.Abs(velocity.X);
              break;
            case 13:
              num22 = this._flipDraw ? velocity.X : -velocity.X;
              break;
            case 44:
              num22 = Math.Max(1f, Math.Abs(velocity.X) * 0.25f);
              break;
            case 48:
              num22 = Math.Max(0.5f, velocity.Length() * 0.125f);
              break;
            case 50:
              num22 = Math.Abs(velocity.X) * 0.5f;
              break;
            default:
              num22 = Math.Abs(velocity.X);
              break;
          }
          this._frameCounter += num22;
          if ((double) num22 >= 0.0)
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
          if (this._type == 5)
          {
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
          }
          if (this._type != 23)
            break;
          float num23 = mountedPlayer.velocity.Length();
          if ((double) num23 < 1.0)
          {
            this._frame = 0;
            this._frameCounter = 0.0f;
            break;
          }
          if ((double) num23 <= 5.0)
            break;
          ++this._frameCounter;
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
          if (this._frame < this._data.swimFrameStart || this._frame >= this._data.swimFrameStart + this._data.swimFrameCount)
            this._frame = this._data.swimFrameStart;
          if (this.Type != 37 || (double) velocity.X != 0.0)
            break;
          this._frame = 4;
          break;
        case 5:
          float num24;
          switch (this._type)
          {
            case 6:
              num24 = this._flipDraw ? velocity.X : -velocity.X;
              break;
            case 9:
              num24 = !this._flipDraw ? Math.Abs(velocity.X) : -Math.Abs(velocity.X);
              break;
            case 13:
              num24 = this._flipDraw ? velocity.X : -velocity.X;
              break;
            default:
              num24 = Math.Abs(velocity.X);
              break;
          }
          this._frameCounter += num24;
          if ((double) num24 >= 0.0)
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

    public void TryBeginningFlight(Player mountedPlayer, int state)
    {
      if (this._frameState == state || (state == 2 ? 1 : (state == 3 ? 1 : 0)) == 0 || !this.CanHover() || mountedPlayer.controlUp || mountedPlayer.controlDown || mountedPlayer.controlJump)
        return;
      Vector2 Velocity = Vector2.UnitY * mountedPlayer.gravDir;
      if ((double) Collision.TileCollision(mountedPlayer.position + new Vector2(0.0f, -1f / 1000f), Velocity, mountedPlayer.width, mountedPlayer.height, gravDir: ((int) mountedPlayer.gravDir)).Y == 0.0)
        return;
      if (this.DoesHoverIgnoresFatigue())
      {
        mountedPlayer.position.Y += -1f / 1000f;
      }
      else
      {
        float num = mountedPlayer.gravity * mountedPlayer.gravDir;
        mountedPlayer.position.Y -= mountedPlayer.velocity.Y;
        mountedPlayer.velocity.Y -= num;
      }
    }

    public int GetIntendedGroundedFrame(Player mountedPlayer) => ((double) mountedPlayer.velocity.X == 0.0 ? 1 : (!mountedPlayer.slippy && !mountedPlayer.slippy2 && !mountedPlayer.windPushed || mountedPlayer.controlLeft ? 0 : (!mountedPlayer.controlRight ? 1 : 0))) != 0 ? 0 : 1;

    public void TryLanding(Player mountedPlayer)
    {
      if ((this._frameState == 3 ? 1 : (this._frameState == 2 ? 1 : 0)) == 0 || mountedPlayer.controlUp || mountedPlayer.controlDown || mountedPlayer.controlJump)
        return;
      Vector2 Velocity = Vector2.UnitY * mountedPlayer.gravDir * 4f;
      if ((double) Collision.TileCollision(mountedPlayer.position, Velocity, mountedPlayer.width, mountedPlayer.height, gravDir: ((int) mountedPlayer.gravDir)).Y != 0.0)
        return;
      this.UpdateFrame(mountedPlayer, this.GetIntendedGroundedFrame(mountedPlayer), mountedPlayer.velocity);
    }

    private void UpdateFrame_GolfCart(Player mountedPlayer, int state, Vector2 velocity)
    {
      if (state != 2)
      {
        if ((double) this._frameExtraCounter != 0.0 || this._frameExtra != 0)
        {
          if ((double) this._frameExtraCounter == -1.0)
          {
            this._frameExtraCounter = 0.0f;
            this._frameExtra = 1;
          }
          if ((double) ++this._frameExtraCounter >= 6.0)
          {
            this._frameExtraCounter = 0.0f;
            if (this._frameExtra > 0)
              --this._frameExtra;
          }
        }
        else
        {
          this._frameExtra = 0;
          this._frameExtraCounter = 0.0f;
        }
      }
      else if ((double) velocity.Y >= 0.0)
      {
        if (this._frameExtra < 1)
          this._frameExtra = 1;
        if (this._frameExtra == 2)
          this._frameExtraCounter = -1f;
        else if ((double) ++this._frameExtraCounter >= 6.0)
        {
          this._frameExtraCounter = 0.0f;
          if (this._frameExtra < 2)
            ++this._frameExtra;
        }
      }
      if ((state == 2 || state == 0 || state == 3 ? 0 : (state != 4 ? 1 : 0)) != 0)
      {
        Mount.EmitGolfCartWheelDust(mountedPlayer, mountedPlayer.Bottom + new Vector2((float) (mountedPlayer.direction * -20), 0.0f));
        Mount.EmitGolfCartWheelDust(mountedPlayer, mountedPlayer.Bottom + new Vector2((float) (mountedPlayer.direction * 20), 0.0f));
      }
      Mount.EmitGolfCartlight(mountedPlayer.Bottom + new Vector2((float) (mountedPlayer.direction * 40), -20f), mountedPlayer.direction);
    }

    private static void EmitGolfCartSmoke(Player mountedPlayer, bool rushing)
    {
      Vector2 Position = mountedPlayer.Bottom + new Vector2((float) (-mountedPlayer.direction * 34), (float) (-(double) mountedPlayer.gravDir * 12.0));
      Dust dust = Dust.NewDustDirect(Position, 0, 0, 31, (float) -mountedPlayer.direction, (float) (-(double) mountedPlayer.gravDir * 0.239999994635582), 100);
      dust.position = Position;
      dust.velocity *= 0.1f;
      dust.velocity += new Vector2((float) -mountedPlayer.direction, (float) (-(double) mountedPlayer.gravDir * 0.25));
      dust.scale = 0.5f;
      if ((double) mountedPlayer.velocity.X != 0.0)
        dust.velocity += new Vector2((float) Math.Sign(mountedPlayer.velocity.X) * 1.3f, 0.0f);
      if (!rushing)
        return;
      dust.fadeIn = 0.8f;
    }

    private static void EmitGolfCartlight(Vector2 worldLocation, int playerDirection)
    {
      float num1 = 0.0f;
      if (playerDirection == -1)
        num1 = 3.141593f;
      float num2 = (float) Math.PI / 32f;
      int num3 = 5;
      float num4 = 200f;
      DelegateMethods.v2_1 = worldLocation.ToTileCoordinates().ToVector2();
      DelegateMethods.f_1 = num4 / 16f;
      DelegateMethods.v3_1 = new Vector3(0.7f, 0.7f, 0.7f);
      for (float num5 = 0.0f; (double) num5 < (double) num3; ++num5)
      {
        Vector2 rotationVector2 = (num1 + num2 * (num5 - (float) (num3 / 2))).ToRotationVector2();
        Utils.PlotTileLine(worldLocation, worldLocation + rotationVector2 * num4, 8f, new Utils.TileActionAttempt(DelegateMethods.CastLightOpen_StopForSolids_ScaleWithDistance));
      }
    }

    private static bool ShouldGolfCartEmitLight() => true;

    private static void EmitGolfCartWheelDust(Player mountedPlayer, Vector2 legSpot)
    {
      if (Main.rand.Next(5) != 0)
        return;
      Point tileCoordinates = (legSpot + new Vector2(0.0f, mountedPlayer.gravDir * 2f)).ToTileCoordinates();
      if (!WorldGen.InWorld(tileCoordinates.X, tileCoordinates.Y, 10))
        return;
      Tile tileSafely = Framing.GetTileSafely(tileCoordinates.X, tileCoordinates.Y);
      if (!WorldGen.SolidTile(tileCoordinates))
        return;
      int num = WorldGen.KillTile_GetTileDustAmount(true, tileSafely);
      if (num > 1)
        num = 1;
      Vector2 vector2 = new Vector2((float) -mountedPlayer.direction, (float) (-(double) mountedPlayer.gravDir * 1.0));
      for (int index = 0; index < num; ++index)
      {
        Dust dust = Main.dust[WorldGen.KillTile_MakeTileDust(tileCoordinates.X, tileCoordinates.Y, tileSafely)];
        dust.velocity *= 0.2f;
        dust.velocity += vector2;
        dust.position = legSpot;
        dust.scale *= 0.8f;
        dust.fadeIn *= 0.8f;
      }
    }

    private void DoGemMinecartEffect(Player mountedPlayer, int dustType)
    {
      if (Main.rand.Next(10) != 0)
        return;
      Vector2 vector2_1 = Main.rand.NextVector2Square(-1f, 1f) * new Vector2(22f, 10f);
      Vector2 vector2_2 = new Vector2(0.0f, 10f) * mountedPlayer.Directions;
      Vector2 pos = mountedPlayer.Center + vector2_2 + vector2_1;
      Dust dust = Dust.NewDustPerfect(mountedPlayer.RotatedRelativePoint(pos), dustType);
      dust.noGravity = true;
      dust.fadeIn = 0.6f;
      dust.scale = 0.4f;
      dust.velocity *= 0.25f;
      dust.shader = GameShaders.Armor.GetSecondaryShader(mountedPlayer.cMount, mountedPlayer);
    }

    private void DoSteamMinecartEffect(Player mountedPlayer, int dustType)
    {
      float num = Math.Abs(mountedPlayer.velocity.X);
      if ((double) num < 1.0 || (double) num < 6.0 && this._frame != 0)
        return;
      Vector2 vector2_1 = Main.rand.NextVector2Square(-1f, 1f) * new Vector2(3f, 3f);
      Vector2 vector2_2 = new Vector2(-10f, -4f) * mountedPlayer.Directions;
      Vector2 pos = mountedPlayer.Center + vector2_2 + vector2_1;
      Dust dust = Dust.NewDustPerfect(mountedPlayer.RotatedRelativePoint(pos), dustType);
      dust.noGravity = true;
      dust.fadeIn = 0.6f;
      dust.scale = 1.8f;
      dust.velocity *= 0.25f;
      dust.velocity.Y -= 2f;
      dust.shader = GameShaders.Armor.GetSecondaryShader(mountedPlayer.cMount, mountedPlayer);
    }

    private void DoExhaustMinecartEffect(Player mountedPlayer, int dustType)
    {
      float num1 = mountedPlayer.velocity.Length();
      if ((double) num1 < 1.0 && Main.rand.Next(4) != 0)
        return;
      int num2 = 1 + (int) num1 / 6;
      while (num2 > 0)
      {
        --num2;
        Vector2 vector2_1 = Main.rand.NextVector2Square(-1f, 1f) * new Vector2(3f, 3f);
        Vector2 vector2_2 = new Vector2(-18f, 20f) * mountedPlayer.Directions;
        if ((double) num1 > 6.0)
          vector2_2.X += (float) (4 * mountedPlayer.direction);
        if (num2 > 0)
          vector2_2 += mountedPlayer.velocity * (float) (num2 / 3);
        Vector2 pos = mountedPlayer.Center + vector2_2 + vector2_1;
        Dust dust = Dust.NewDustPerfect(mountedPlayer.RotatedRelativePoint(pos), dustType);
        dust.noGravity = true;
        dust.fadeIn = 0.6f;
        dust.scale = 1.2f;
        dust.velocity *= 0.2f;
        if ((double) num1 < 1.0)
          dust.velocity.X -= 0.5f * (float) mountedPlayer.direction;
        dust.shader = GameShaders.Armor.GetSecondaryShader(mountedPlayer.cMount, mountedPlayer);
      }
    }

    private void DoConfettiMinecartEffect(Player mountedPlayer)
    {
      float num1 = mountedPlayer.velocity.Length();
      if ((double) num1 < 1.0 && Main.rand.Next(6) != 0 || (double) num1 < 3.0 && Main.rand.Next(3) != 0)
        return;
      int num2 = 1 + (int) num1 / 6;
      while (num2 > 0)
      {
        --num2;
        float num3 = Main.rand.NextFloat() * 2f;
        Vector2 vector2_1 = Main.rand.NextVector2Square(-1f, 1f) * new Vector2(3f, 8f);
        Vector2 vector2_2 = new Vector2(-18f, 4f) * mountedPlayer.Directions;
        vector2_2.X += (float) ((double) num1 * (double) mountedPlayer.direction * 0.5 + (double) (mountedPlayer.direction * num2) * (double) num3);
        if (num2 > 0)
          vector2_2 += mountedPlayer.velocity * (float) (num2 / 3);
        Vector2 pos = mountedPlayer.Center + vector2_2 + vector2_1;
        Dust dust = Dust.NewDustPerfect(mountedPlayer.RotatedRelativePoint(pos), 139 + Main.rand.Next(4));
        dust.noGravity = true;
        dust.fadeIn = 0.6f;
        dust.scale = (float) (0.5 + (double) num3 / 2.0);
        dust.velocity *= 0.2f;
        if ((double) num1 < 1.0)
          dust.velocity.X -= 0.5f * (float) mountedPlayer.direction;
        dust.shader = GameShaders.Armor.GetSecondaryShader(mountedPlayer.cMount, mountedPlayer);
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
        case 46:
          if (this._type == 46)
            mountedPlayer.hasJumpOption_Santank = true;
          Vector2 center = mountedPlayer.Center;
          Vector2 mousePosition = center;
          bool flag1 = false;
          float num1 = 1500f;
          float num2 = 500f;
          for (int index = 0; index < 200; ++index)
          {
            NPC npc = Main.npc[index];
            if (npc.CanBeChasedBy((object) this))
            {
              Vector2 v = npc.Center - center;
              float num3 = v.Length();
              if ((double) num3 < (double) num2 && ((double) Vector2.Distance(mousePosition, center) > (double) num3 && (double) num3 < (double) num1 || !flag1))
              {
                bool flag2 = true;
                float num4 = Math.Abs(v.ToRotation());
                if (mountedPlayer.direction == 1 && (double) num4 > 1.04719759490799)
                  flag2 = false;
                else if (mountedPlayer.direction == -1 && (double) num4 < 2.09439514610459)
                  flag2 = false;
                if (Collision.CanHitLine(center, 0, 0, npc.position, npc.width, npc.height) & flag2)
                {
                  num1 = num3;
                  mousePosition = npc.Center;
                  flag1 = true;
                }
              }
            }
          }
          if (flag1)
          {
            bool flag3 = this._abilityCooldown == 0;
            if (this._type == 46)
              flag3 = this._abilityCooldown % 10 == 0;
            if (flag3 && mountedPlayer.whoAmI == Main.myPlayer)
            {
              this.AimAbility(mountedPlayer, mousePosition);
              if (this._abilityCooldown == 0)
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
          mountedPlayer.hasJumpOption_Unicorn = true;
          if ((double) Math.Abs(mountedPlayer.velocity.X) > (double) mountedPlayer.mount.DashSpeed - (double) mountedPlayer.mount.RunSpeed / 2.0)
            mountedPlayer.noKnockback = true;
          if (mountedPlayer.itemAnimation <= 0 || mountedPlayer.inventory[mountedPlayer.selectedItem].type != 1260)
            break;
          AchievementsHelper.HandleSpecialEvent(mountedPlayer, 5);
          break;
        case 11:
          Vector3 vector3_1 = new Vector3(0.4f, 0.12f, 0.15f);
          float num5 = (float) (1.0 + (double) Math.Abs(mountedPlayer.velocity.X) / (double) this.RunSpeed * 2.5);
          mountedPlayer.statDefense += (int) (2.0 * (double) num5);
          int num6 = Math.Sign(mountedPlayer.velocity.X);
          if (num6 == 0)
            num6 = mountedPlayer.direction;
          if (Main.netMode != 2)
          {
            Vector3 vector3_2 = vector3_1 * num5;
            Lighting.AddLight(mountedPlayer.Center, vector3_2.X, vector3_2.Y, vector3_2.Z);
            Lighting.AddLight(mountedPlayer.Top, vector3_2.X, vector3_2.Y, vector3_2.Z);
            Lighting.AddLight(mountedPlayer.Bottom, vector3_2.X, vector3_2.Y, vector3_2.Z);
            Lighting.AddLight(mountedPlayer.Left, vector3_2.X, vector3_2.Y, vector3_2.Z);
            Lighting.AddLight(mountedPlayer.Right, vector3_2.X, vector3_2.Y, vector3_2.Z);
            float num7 = -24f;
            if (mountedPlayer.direction != num6)
              num7 = -22f;
            if (num6 == -1)
              ++num7;
            Vector2 vector2_1 = new Vector2(num7 * (float) num6, -19f).RotatedBy((double) mountedPlayer.fullRotation);
            Vector2 vector2_2 = new Vector2(MathHelper.Lerp(0.0f, -8f, mountedPlayer.fullRotation / 0.7853982f), MathHelper.Lerp(0.0f, 2f, Math.Abs(mountedPlayer.fullRotation / 0.7853982f))).RotatedBy((double) mountedPlayer.fullRotation);
            if (num6 == Math.Sign(mountedPlayer.fullRotation))
              vector2_2 *= MathHelper.Lerp(1f, 0.6f, Math.Abs(mountedPlayer.fullRotation / 0.7853982f));
            Vector2 vector2_3 = mountedPlayer.Bottom + vector2_1 + vector2_2;
            Vector2 vector2_4 = mountedPlayer.oldPosition + mountedPlayer.Size * new Vector2(0.5f, 1f) + vector2_1 + vector2_2;
            if ((double) Vector2.Distance(vector2_3, vector2_4) > 3.0)
            {
              int num8 = (int) Vector2.Distance(vector2_3, vector2_4) / 3;
              if ((double) Vector2.Distance(vector2_3, vector2_4) % 3.0 != 0.0)
                ++num8;
              for (float num9 = 1f; (double) num9 <= (double) num8; ++num9)
              {
                Dust dust = Main.dust[Dust.NewDust(mountedPlayer.Center, 0, 0, 182)];
                dust.position = Vector2.Lerp(vector2_4, vector2_3, num9 / (float) num8);
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
          int num10 = 60;
          int num11 = 0;
          float num12 = 0.0f;
          for (int index1 = 0; index1 < 200; ++index1)
          {
            NPC npc = Main.npc[index1];
            if (npc.active && npc.immune[mountedPlayer.whoAmI] <= 0 && !npc.dontTakeDamage && (double) npc.Distance(minecartMechPoint) < 300.0 && npc.CanBeChasedBy((object) mountedPlayer) && Collision.CanHitLine(npc.position, npc.width, npc.height, minecartMechPoint, 0, 0) && (double) Math.Abs(MathHelper.WrapAngle(MathHelper.WrapAngle(npc.AngleFrom(minecartMechPoint)) - MathHelper.WrapAngle((double) mountedPlayer.fullRotation + (double) num6 == -1.0 ? 3.141593f : 0.0f))) < 0.785398185253143)
            {
              Vector2 v = npc.position + npc.Size * Utils.RandomVector2(Main.rand, 0.0f, 1f) - minecartMechPoint;
              num12 += v.ToRotation();
              ++num11;
              int index2 = Projectile.NewProjectile(minecartMechPoint.X, minecartMechPoint.Y, v.X, v.Y, 591, 0, 0.0f, mountedPlayer.whoAmI, (float) mountedPlayer.whoAmI);
              Main.projectile[index2].Center = npc.Center;
              Main.projectile[index2].damage = num10;
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
          }
          if (mountedPlayer.statLife <= mountedPlayer.statLifeMax2 / 2)
            mountedPlayer.MountFishronSpecialCounter = 60f;
          if (!mountedPlayer.wet && (!Main.raining || !WorldGen.InAPlaceWithWind(mountedPlayer.position, mountedPlayer.width, mountedPlayer.height)))
            break;
          mountedPlayer.MountFishronSpecialCounter = 420f;
          break;
        case 14:
          mountedPlayer.hasJumpOption_Basilisk = true;
          if ((double) Math.Abs(mountedPlayer.velocity.X) <= (double) mountedPlayer.mount.DashSpeed - (double) mountedPlayer.mount.RunSpeed / 2.0)
            break;
          mountedPlayer.noKnockback = true;
          break;
        case 16:
          mountedPlayer.ignoreWater = true;
          break;
        case 22:
          mountedPlayer.lavaMax += 420;
          Vector2 pos1 = mountedPlayer.Center + new Vector2(20f, 10f) * mountedPlayer.Directions;
          Vector2 pos2 = pos1 + mountedPlayer.velocity;
          Vector2 pos3 = pos1 + new Vector2(-1f, -0.5f) * mountedPlayer.Directions;
          Vector2 vector2_5 = mountedPlayer.RotatedRelativePoint(pos1);
          Vector2 vector2_6 = mountedPlayer.RotatedRelativePoint(pos2);
          Vector2 vector2_7 = mountedPlayer.RotatedRelativePoint(pos3);
          Vector2 vector2_8 = mountedPlayer.shadowPos[2] - mountedPlayer.position + vector2_5;
          Vector2 vector2_9 = vector2_6 - vector2_5;
          Vector2 vector2_10 = vector2_5 + vector2_9;
          Vector2 vector2_11 = vector2_8 + vector2_9;
          Vector2 vector2_12 = vector2_6 - vector2_7;
          float num13 = MathHelper.Clamp(mountedPlayer.velocity.Length() / 5f, 0.0f, 1f);
          for (float amount = 0.0f; (double) amount <= 1.0; amount += 0.1f)
          {
            if ((double) Main.rand.NextFloat() >= (double) num13)
            {
              Dust dust = Dust.NewDustPerfect(Vector2.Lerp(vector2_11, vector2_10, amount), 65, new Vector2?(Main.rand.NextVector2Circular(0.5f, 0.5f) * num13));
              dust.scale = 0.6f;
              dust.fadeIn = 0.0f;
              dust.customData = (object) mountedPlayer;
              dust.velocity *= -1f;
              dust.noGravity = true;
              dust.velocity -= vector2_12;
              if (Main.rand.Next(10) == 0)
              {
                dust.fadeIn = 1.3f;
                dust.velocity = Main.rand.NextVector2Circular(3f, 3f) * num13;
              }
            }
          }
          break;
        case 23:
          Vector2 pos4 = mountedPlayer.Center + this.GetWitchBroomTrinketOriginOffset(mountedPlayer) + (this.GetWitchBroomTrinketRotation(mountedPlayer) + 1.570796f).ToRotationVector2() * 11f;
          Vector3 rgb = new Vector3(1f, 0.75f, 0.5f) * 0.85f;
          Vector2 vector2_13 = mountedPlayer.RotatedRelativePoint(pos4);
          Lighting.AddLight(vector2_13, rgb);
          if (Main.rand.Next(45) == 0)
          {
            Vector2 vector2_14 = Main.rand.NextVector2Circular(4f, 4f);
            Dust dust = Dust.NewDustPerfect(vector2_13 + vector2_14, 43, new Vector2?(Vector2.Zero), 254, new Color((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue), 0.3f);
            if (vector2_14 != Vector2.Zero)
              dust.velocity = vector2_13.DirectionTo(dust.position) * 0.2f;
            dust.fadeIn = 0.3f;
            dust.noLightEmittence = true;
            dust.customData = (object) mountedPlayer;
            dust.shader = GameShaders.Armor.GetSecondaryShader(mountedPlayer.cMount, mountedPlayer);
          }
          float num14 = 0.1f + mountedPlayer.velocity.Length() / 30f;
          Vector2 pos5 = mountedPlayer.Center + new Vector2((float) (18.0 - 20.0 * (double) Main.rand.NextFloat() * (double) mountedPlayer.direction), 12f);
          Vector2 pos6 = mountedPlayer.Center + new Vector2((float) (52 * mountedPlayer.direction), -6f);
          Vector2 vector2_15 = mountedPlayer.RotatedRelativePoint(pos5);
          Vector2 Origin = mountedPlayer.RotatedRelativePoint(pos6);
          if ((double) Main.rand.NextFloat() > (double) num14)
            break;
          float num15 = Main.rand.NextFloat();
          for (float num16 = 0.0f; (double) num16 < 1.0; num16 += 0.125f)
          {
            if (Main.rand.Next(15) == 0)
            {
              Vector2 vector2_16 = ((6.283185f * num16 + num15).ToRotationVector2() * new Vector2(0.5f, 1f) * 4f).RotatedBy((double) mountedPlayer.fullRotation);
              Dust dust = Dust.NewDustPerfect(vector2_15 + vector2_16, 43, new Vector2?(Vector2.Zero), 254, new Color((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue), 0.3f);
              dust.velocity = vector2_16 * 0.025f + Origin.DirectionTo(dust.position) * 0.5f;
              dust.fadeIn = 0.3f;
              dust.noLightEmittence = true;
              dust.shader = GameShaders.Armor.GetSecondaryShader(mountedPlayer.cMount, mountedPlayer);
            }
          }
          break;
        case 24:
          DelegateMethods.v3_1 = new Vector3(0.1f, 0.3f, 1f) * 0.4f;
          Utils.PlotTileLine(mountedPlayer.MountedCenter, mountedPlayer.MountedCenter + mountedPlayer.velocity * 6f, 40f, new Utils.TileActionAttempt(DelegateMethods.CastLightOpen));
          Utils.PlotTileLine(mountedPlayer.Left, mountedPlayer.Right, 40f, new Utils.TileActionAttempt(DelegateMethods.CastLightOpen));
          break;
        case 25:
          this.DoGemMinecartEffect(mountedPlayer, 86);
          break;
        case 26:
          this.DoGemMinecartEffect(mountedPlayer, 87);
          break;
        case 27:
          this.DoGemMinecartEffect(mountedPlayer, 88);
          break;
        case 28:
          this.DoGemMinecartEffect(mountedPlayer, 89);
          break;
        case 29:
          this.DoGemMinecartEffect(mountedPlayer, 90);
          break;
        case 30:
          this.DoGemMinecartEffect(mountedPlayer, 91);
          break;
        case 31:
          this.DoGemMinecartEffect(mountedPlayer, 262);
          break;
        case 32:
          this.DoExhaustMinecartEffect(mountedPlayer, 31);
          break;
        case 34:
          this.DoConfettiMinecartEffect(mountedPlayer);
          break;
        case 36:
          this.DoSteamMinecartEffect(mountedPlayer, 303);
          break;
        case 37:
          mountedPlayer.canFloatInWater = true;
          mountedPlayer.accFlipper = true;
          break;
        case 40:
        case 41:
        case 42:
          if ((double) Math.Abs(mountedPlayer.velocity.X) <= (double) mountedPlayer.mount.DashSpeed - (double) mountedPlayer.mount.RunSpeed / 2.0)
            break;
          mountedPlayer.noKnockback = true;
          break;
        case 47:
          mountedPlayer.hasJumpOption_WallOfFleshGoat = true;
          if ((double) Math.Abs(mountedPlayer.velocity.X) <= (double) mountedPlayer.mount.DashSpeed - (double) mountedPlayer.mount.RunSpeed / 2.0)
            break;
          mountedPlayer.noKnockback = true;
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
      if (this._type != 46)
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
        case 46:
          y = (int) Mount.santankTextureSize.Y;
          x = (int) Mount.santankTextureSize.X;
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
          int frameExtra1 = this._frameExtra;
          int direction1 = mountedPlayer.direction;
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
          return this._frameExtra != frameExtra1 || mountedPlayer.direction != direction1;
        case 46:
          int frameExtra2 = this._frameExtra;
          int direction2 = mountedPlayer.direction;
          float degrees = MathHelper.ToDegrees((this.ClampToDeadZone(mountedPlayer, mousePosition) - mountedPlayer.Center).ToRotation());
          float num4;
          if ((double) degrees > 90.0)
          {
            mountedPlayer.direction = -1;
            num4 = 180f - degrees;
          }
          else if ((double) degrees < -90.0)
          {
            mountedPlayer.direction = -1;
            num4 = -180f - degrees;
          }
          else
            mountedPlayer.direction = 1;
          this._flipDraw = mountedPlayer.direction > 0 && (double) mountedPlayer.velocity.X < 0.0 || mountedPlayer.direction < 0 && (double) mountedPlayer.velocity.X > 0.0;
          if ((double) this.AbilityCharge > 0.0)
          {
            Vector2 vector2_3;
            vector2_3.X = mountedPlayer.position.X + (float) (mountedPlayer.width / 2);
            vector2_3.Y = mountedPlayer.position.Y + (float) mountedPlayer.height;
            for (int index = 0; index < 2; ++index)
            {
              Vector2 vector2_4 = new Vector2(vector2_3.X + (float) (mountedPlayer.width * mountedPlayer.direction), vector2_3.Y - 12f);
              Lighting.AddLight((int) ((double) vector2_4.X / 16.0), (int) ((double) vector2_4.Y / 16.0), 0.7f, 0.4f, 0.4f);
            }
          }
          return this._frameExtra != frameExtra2 || mountedPlayer.direction != direction2;
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
          texture1 = this._data.backTexture.Value;
          texture2 = this._data.backTextureGlow.Value;
          break;
        case 1:
          texture1 = this._data.backTextureExtra.Value;
          texture2 = this._data.backTextureExtraGlow.Value;
          break;
        case 2:
          if (this._type == 0 && this._idleTime >= this._idleTimeNext)
            return;
          texture1 = this._data.frontTexture.Value;
          texture2 = this._data.frontTextureGlow.Value;
          break;
        case 3:
          texture1 = this._data.frontTextureExtra.Value;
          texture2 = this._data.frontTextureExtraGlow.Value;
          break;
        default:
          texture1 = (Texture2D) null;
          texture2 = (Texture2D) null;
          break;
      }
      if (this._type == 50 && texture1 != null)
      {
        PlayerQueenSlimeMountTextureContent queenSlimeMount = TextureAssets.RenderTargets.QueenSlimeMount;
        queenSlimeMount.Request();
        if (queenSlimeMount.IsReady)
          texture1 = (Texture2D) queenSlimeMount.GetTarget();
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
      bool flag1 = true;
      int num2 = this._data.totalFrames;
      int num3 = this._data.textureHeight;
      int num4;
      switch (this._type)
      {
        case 5:
          switch (drawType)
          {
            case 0:
              num4 = this._frame;
              break;
            case 1:
              num4 = this._frameExtra;
              break;
            default:
              num4 = 0;
              break;
          }
          break;
        case 9:
          switch (drawType)
          {
            case 0:
              num4 = this._frame;
              break;
            case 2:
              num4 = this._frameExtra;
              break;
            case 3:
              num4 = this._frameExtra;
              break;
            default:
              num4 = 0;
              break;
          }
          break;
        case 17:
          num3 = texture1.Height;
          switch (drawType)
          {
            case 0:
              num4 = this._frame;
              num2 = 4;
              break;
            case 1:
              num4 = this._frameExtra;
              num2 = 4;
              break;
            default:
              num4 = 0;
              break;
          }
          break;
        case 23:
          num4 = this._frame;
          break;
        case 39:
          num3 = texture1.Height;
          switch (drawType)
          {
            case 2:
              num4 = this._frame;
              num2 = 3;
              break;
            case 3:
              num4 = this._frameExtra;
              num2 = 6;
              break;
            default:
              num4 = 0;
              break;
          }
          break;
        case 46:
          switch (drawType)
          {
            case 2:
              num4 = this._frame;
              break;
            case 3:
              num4 = this._frameExtra;
              break;
            default:
              num4 = 0;
              break;
          }
          break;
        default:
          num4 = this._frame;
          break;
      }
      int height = num3 / num2;
      Rectangle rectangle1 = new Rectangle(0, height * num4, this._data.textureWidth, height);
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
            float num5 = MathHelper.Clamp(drawPlayer.MountFishronSpecialCounter / 60f, 0.0f, 1f);
            Color color2 = Colors.CurrentLiquidColor;
            if (color2 == Color.Transparent)
              color2 = Color.White;
            color2.A = (byte) 127;
            color1 = color2 * num5;
            break;
          }
          break;
        case 24:
          if (drawType == 2)
          {
            color1 = Color.SkyBlue * 0.5f;
            color1.A = (byte) 20;
            break;
          }
          break;
        case 45:
          if (drawType == 2)
          {
            color1 = new Color(150, 110, 110, 100);
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
      int type = this._type;
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
        default:
          effect = playerEffect;
          break;
      }
      if (MountID.Sets.FacePlayersVelocity[this._type])
        effect = Math.Sign(drawPlayer.velocity.X) == -drawPlayer.direction ? playerEffect ^ SpriteEffects.FlipHorizontally : playerEffect;
      bool flag2 = false;
      DrawData drawData;
      switch (this._type)
      {
        case 35:
          if (drawType == 2)
          {
            Mount.ExtraFrameMountData mountSpecificData2 = (Mount.ExtraFrameMountData) this._mountSpecificData;
            int num6 = -36;
            if (effect.HasFlag((Enum) SpriteEffects.FlipHorizontally))
              num6 *= -1;
            Vector2 vector2 = new Vector2((float) num6, -26f);
            if ((double) shadow == 0.0)
            {
              if ((double) Math.Abs(drawPlayer.velocity.X) > 1.0)
              {
                mountSpecificData2.frameCounter += Math.Min(2f, Math.Abs(drawPlayer.velocity.X * 0.4f));
                while ((double) mountSpecificData2.frameCounter > 6.0)
                {
                  mountSpecificData2.frameCounter -= 6f;
                  ++mountSpecificData2.frame;
                  if (mountSpecificData2.frame > 2 && mountSpecificData2.frame < 5 || mountSpecificData2.frame > 7)
                    mountSpecificData2.frame = 0;
                }
              }
              else
              {
                ++mountSpecificData2.frameCounter;
                while ((double) mountSpecificData2.frameCounter > 6.0)
                {
                  mountSpecificData2.frameCounter -= 6f;
                  ++mountSpecificData2.frame;
                  if (mountSpecificData2.frame > 5)
                    mountSpecificData2.frame = 5;
                }
              }
            }
            Texture2D texture2D = TextureAssets.Extra[142].Value;
            Rectangle rectangle2 = texture2D.Frame(verticalFrames: 8, frameY: mountSpecificData2.frame);
            if (flag1)
              rectangle2.Height -= 2;
            drawData = new DrawData(texture2D, Position + vector2, new Rectangle?(rectangle2), drawColor, rotation1, origin, scale1, effect, 0);
            drawData.shader = Mount.currentShader;
            playerDrawData.Add(drawData);
            break;
          }
          break;
        case 38:
          if (drawType == 0)
          {
            int num7 = 0;
            if (effect.HasFlag((Enum) SpriteEffects.FlipHorizontally))
              num7 = 22;
            Vector2 vector2 = new Vector2((float) num7, -10f);
            Texture2D texture2D = TextureAssets.Extra[151].Value;
            Rectangle rectangle3 = texture2D.Frame();
            drawData = new DrawData(texture2D, Position + vector2, new Rectangle?(rectangle3), drawColor, rotation1, origin, scale1, effect, 0);
            drawData.shader = Mount.currentShader;
            playerDrawData.Add(drawData);
            flag2 = true;
            break;
          }
          break;
        case 50:
          if (drawType == 0)
          {
            Vector2 position = Position + new Vector2(0.0f, (float) (8 - this.PlayerOffset + 20));
            Rectangle rectangle4 = new Rectangle(0, height * this._frameExtra, this._data.textureWidth, height);
            if (flag1)
              rectangle4.Height -= 2;
            drawData = new DrawData(TextureAssets.Extra[207].Value, position, new Rectangle?(rectangle4), drawColor, rotation1, origin, scale1, effect, 0);
            drawData.shader = Mount.currentShader;
            playerDrawData.Add(drawData);
            break;
          }
          break;
      }
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
      switch (this._type)
      {
        case 8:
          if (drawType != 3)
            break;
          Mount.DrillMountData mountSpecificData3 = (Mount.DrillMountData) this._mountSpecificData;
          Rectangle rectangle5 = new Rectangle(0, 0, 1, 1);
          Vector2 vector2_1 = Mount.drillDiodePoint1.RotatedBy((double) mountSpecificData3.diodeRotation);
          Vector2 vector2_2 = Mount.drillDiodePoint2.RotatedBy((double) mountSpecificData3.diodeRotation);
          for (int index1 = 0; index1 < mountSpecificData3.beams.Length; ++index1)
          {
            Mount.DrillBeam beam = mountSpecificData3.beams[index1];
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
                drawData = new DrawData(TextureAssets.MagicPixel.Value, vector2_4 + Position, new Rectangle?(rectangle5), color4, rotation2 - 1.570796f, Vector2.Zero, scale2, SpriteEffects.None, 0);
                drawData.ignorePlayerRotation = true;
                drawData.shader = Mount.currentShader;
                playerDrawData.Add(drawData);
              }
            }
          }
          break;
        case 17:
          if (drawType != 1 || !Mount.ShouldGolfCartEmitLight())
            break;
          rectangle1 = new Rectangle(0, height * 3, this._data.textureWidth, height);
          if (flag1)
            rectangle1.Height -= 2;
          drawColor = Color.White * 1f;
          drawColor.A = (byte) 0;
          drawData = new DrawData(texture1, Position, new Rectangle?(rectangle1), drawColor, rotation1, origin, scale1, effect, 0);
          drawData.shader = Mount.currentShader;
          playerDrawData.Add(drawData);
          break;
        case 23:
          if (drawType != 0)
            break;
          Texture2D texture2D1 = TextureAssets.Extra[114].Value;
          rectangle1 = texture2D1.Frame(2);
          int width = rectangle1.Width;
          rectangle1.Width -= 2;
          double broomTrinketRotation = (double) this.GetWitchBroomTrinketRotation(drawPlayer);
          Position = drawPlayer.Center + this.GetWitchBroomTrinketOriginOffset(drawPlayer) - Main.screenPosition;
          float rotation3 = (float) broomTrinketRotation;
          origin = new Vector2((float) (rectangle1.Width / 2), 0.0f);
          drawData = new DrawData(texture2D1, Position.Floor(), new Rectangle?(rectangle1), drawColor, rotation3, origin, scale1, effect, 0);
          drawData.shader = Mount.currentShader;
          playerDrawData.Add(drawData);
          new Color(new Vector3(0.9f, 0.85f, 0.0f)).A /= (byte) 2;
          float num8 = ((float) ((double) drawPlayer.miscCounter / 75.0 * 6.28318548202515)).ToRotationVector2().X * 1f;
          Color color5 = new Color(80, 70, 40, 0) * (float) ((double) num8 / 8.0 + 0.5) * 0.8f;
          rectangle1.X += width;
          for (int index = 0; index < 4; ++index)
          {
            drawData = new DrawData(texture2D1, (Position + ((float) index * 1.570796f).ToRotationVector2() * num8).Floor(), new Rectangle?(rectangle1), color5, rotation3, origin, scale1, effect, 0);
            drawData.shader = Mount.currentShader;
            playerDrawData.Add(drawData);
          }
          break;
        case 45:
          if (drawType != 0 || (double) shadow != 0.0)
            break;
          if ((double) Math.Abs(drawPlayer.velocity.X) > (double) this.DashSpeed * 0.899999976158142)
          {
            color1 = new Color((int) byte.MaxValue, 220, 220, 200);
            scale1 = 1.1f;
          }
          for (int index = 0; index < 2; ++index)
          {
            Vector2 position = Position + new Vector2((float) Main.rand.Next(-10, 11) * 0.1f, (float) Main.rand.Next(-10, 11) * 0.1f);
            rectangle1 = new Rectangle(0, height * 3, this._data.textureWidth, height);
            if (flag1)
              rectangle1.Height -= 2;
            drawData = new DrawData(texture2, position, new Rectangle?(rectangle1), color1, rotation1, origin, scale1, effect, 0);
            drawData.shader = Mount.currentShader;
            playerDrawData.Add(drawData);
          }
          break;
        case 50:
          if (drawType != 0)
            break;
          drawData = new DrawData(TextureAssets.Extra[205].Value, Position, new Rectangle?(rectangle1), drawColor, rotation1, origin, scale1, effect, 0);
          drawData.shader = Mount.currentShader;
          playerDrawData.Add(drawData);
          Vector2 position1 = Position + new Vector2(0.0f, (float) (8 - this.PlayerOffset + 20));
          Rectangle rectangle6 = new Rectangle(0, height * this._frameExtra, this._data.textureWidth, height);
          if (flag1)
            rectangle6.Height -= 2;
          drawData = new DrawData(TextureAssets.Extra[206].Value, position1, new Rectangle?(rectangle6), drawColor, rotation1, origin, scale1, effect, 0);
          drawData.shader = Mount.currentShader;
          playerDrawData.Add(drawData);
          break;
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
      this.DoSpawnDust(mountedPlayer, true);
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
      if (this._type == m || m <= -1 || m >= MountID.Count || m == 5 && mountedPlayer.wet)
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
      if (this._type == 46 && this._abilityCooldown < 40)
        this._abilityCooldown = 40;
      mountedPlayer.position.Y += (float) mountedPlayer.height;
      for (int index = 0; index < mountedPlayer.shadowPos.Length; ++index)
        mountedPlayer.shadowPos[index].Y += (float) mountedPlayer.height;
      mountedPlayer.height = 42 + this._data.heightBoost;
      mountedPlayer.position.Y -= (float) mountedPlayer.height;
      for (int index = 0; index < mountedPlayer.shadowPos.Length; ++index)
        mountedPlayer.shadowPos[index].Y -= (float) mountedPlayer.height;
      mountedPlayer.ResetAdvancedShadows();
      if (this._type == 7 || this._type == 8)
        mountedPlayer.fullRotationOrigin = new Vector2((float) (mountedPlayer.width / 2), (float) (mountedPlayer.height / 2));
      if (this._type == 8)
        this._mountSpecificData = (object) new Mount.DrillMountData();
      if (this._type == 35)
        this._mountSpecificData = (object) new Mount.ExtraFrameMountData();
      this.DoSpawnDust(mountedPlayer, false);
      if (mountedPlayer.whoAmI != Main.myPlayer)
        return;
      NetMessage.SendData(13, number: mountedPlayer.whoAmI);
    }

    private void DoSpawnDust(Player mountedPlayer, bool isDismounting)
    {
      if (Main.netMode == 2)
        return;
      Color newColor = Color.Transparent;
      if (this._type == 23)
        newColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue);
      for (int index1 = 0; index1 < 100; ++index1)
      {
        if (MountID.Sets.Cart[this._type])
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
          int Type = this._data.spawnDust;
          float Scale = 1f;
          int Alpha = 0;
          if (this._type == 40 || this._type == 41 || this._type == 42)
          {
            Type = Main.rand.Next(2) != 0 ? 16 : 31;
            Scale = 0.9f;
            Alpha = 50;
            if (this._type == 42)
              Type = 31;
            if (this._type == 41)
              Type = 16;
          }
          int index3 = Dust.NewDust(new Vector2(mountedPlayer.position.X - 20f, mountedPlayer.position.Y), mountedPlayer.width + 40, mountedPlayer.height, Type, Alpha: Alpha, newColor: newColor, Scale: Scale);
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
          if (this._type == 40 || this._type == 41 || this._type == 42)
            Main.dust[index3].velocity *= Main.rand.NextFloat();
        }
      }
      if (this._type == 40 || this._type == 41 || this._type == 42)
      {
        for (int index4 = 0; index4 < 5; ++index4)
        {
          int Type = Main.rand.Next(61, 64);
          if (this._type == 41 || this._type == 40 && Main.rand.Next(2) == 0)
            Type = Main.rand.Next(11, 14);
          int index5 = Gore.NewGore(new Vector2(mountedPlayer.position.X + (float) (mountedPlayer.direction * 8), mountedPlayer.position.Y + 20f), Vector2.Zero, Type);
          Main.gore[index5].alpha = 100;
          Main.gore[index5].velocity = Vector2.Transform(new Vector2(1f, 0.0f), Matrix.CreateRotationZ((float) (Main.rand.NextDouble() * 6.28318548202515))) * 1.4f;
        }
      }
      if (this._type != 23)
        return;
      for (int index6 = 0; index6 < 4; ++index6)
      {
        int Type = Main.rand.Next(61, 64);
        int index7 = Gore.NewGore(new Vector2(mountedPlayer.position.X - 20f, mountedPlayer.position.Y), Vector2.Zero, Type);
        Main.gore[index7].alpha = 100;
        Main.gore[index7].velocity = Vector2.Transform(new Vector2(1f, 0.0f), Matrix.CreateRotationZ((float) (Main.rand.NextDouble() * 6.28318548202515)));
      }
    }

    public bool CanMount(int m, Player mountingPlayer) => mountingPlayer.CanFitSpace(Mount.mounts[m].heightBoost);

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

    private class BooleanMountData
    {
      public bool boolean;

      public BooleanMountData() => this.boolean = false;
    }

    private class ExtraFrameMountData
    {
      public int frame;
      public float frameCounter;

      public ExtraFrameMountData()
      {
        this.frame = 0;
        this.frameCounter = 0.0f;
      }
    }

    public class MountDelegatesData
    {
      public Action<Vector2> MinecartDust;
      public Action<Vector2, int, int> MinecartLandingSound;
      public Action<Vector2, int, int> MinecartBumperSound;

      public MountDelegatesData()
      {
        this.MinecartDust = new Action<Vector2>(DelegateMethods.Minecart.Sparks);
        this.MinecartLandingSound = new Action<Vector2, int, int>(DelegateMethods.Minecart.LandingSound);
        this.MinecartBumperSound = new Action<Vector2, int, int>(DelegateMethods.Minecart.BumperSound);
      }
    }

    private class MountData
    {
      public Asset<Texture2D> backTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
      public Asset<Texture2D> backTextureGlow = (Asset<Texture2D>) Asset<Texture2D>.Empty;
      public Asset<Texture2D> backTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
      public Asset<Texture2D> backTextureExtraGlow = (Asset<Texture2D>) Asset<Texture2D>.Empty;
      public Asset<Texture2D> frontTexture = (Asset<Texture2D>) Asset<Texture2D>.Empty;
      public Asset<Texture2D> frontTextureGlow = (Asset<Texture2D>) Asset<Texture2D>.Empty;
      public Asset<Texture2D> frontTextureExtra = (Asset<Texture2D>) Asset<Texture2D>.Empty;
      public Asset<Texture2D> frontTextureExtraGlow = (Asset<Texture2D>) Asset<Texture2D>.Empty;
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
      public Vector3 lightColor = Vector3.One;
      public bool emitsLight;
      public Mount.MountDelegatesData delegations;
    }
  }
}
