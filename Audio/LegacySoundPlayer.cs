// Decompiled with JetBrains decompiler
// Type: Terraria.Audio.LegacySoundPlayer
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using ReLogic.Content;
using ReLogic.Utilities;
using System;
using System.IO;
using Terraria.ID;

namespace Terraria.Audio
{
  public class LegacySoundPlayer
  {
    private Asset<SoundEffect>[] _soundDrip = new Asset<SoundEffect>[3];
    private SoundEffectInstance[] _soundInstanceDrip = new SoundEffectInstance[3];
    private Asset<SoundEffect>[] _soundLiquid = new Asset<SoundEffect>[2];
    private SoundEffectInstance[] _soundInstanceLiquid = new SoundEffectInstance[2];
    private Asset<SoundEffect>[] _soundMech = new Asset<SoundEffect>[1];
    private SoundEffectInstance[] _soundInstanceMech = new SoundEffectInstance[1];
    private Asset<SoundEffect>[] _soundDig = new Asset<SoundEffect>[3];
    private SoundEffectInstance[] _soundInstanceDig = new SoundEffectInstance[3];
    private Asset<SoundEffect>[] _soundThunder = new Asset<SoundEffect>[7];
    private SoundEffectInstance[] _soundInstanceThunder = new SoundEffectInstance[7];
    private Asset<SoundEffect>[] _soundResearch = new Asset<SoundEffect>[4];
    private SoundEffectInstance[] _soundInstanceResearch = new SoundEffectInstance[4];
    private Asset<SoundEffect>[] _soundTink = new Asset<SoundEffect>[3];
    private SoundEffectInstance[] _soundInstanceTink = new SoundEffectInstance[3];
    private Asset<SoundEffect>[] _soundCoin = new Asset<SoundEffect>[5];
    private SoundEffectInstance[] _soundInstanceCoin = new SoundEffectInstance[5];
    private Asset<SoundEffect>[] _soundPlayerHit = new Asset<SoundEffect>[3];
    private SoundEffectInstance[] _soundInstancePlayerHit = new SoundEffectInstance[3];
    private Asset<SoundEffect>[] _soundFemaleHit = new Asset<SoundEffect>[3];
    private SoundEffectInstance[] _soundInstanceFemaleHit = new SoundEffectInstance[3];
    private Asset<SoundEffect> _soundPlayerKilled;
    private SoundEffectInstance _soundInstancePlayerKilled;
    private Asset<SoundEffect> _soundGrass;
    private SoundEffectInstance _soundInstanceGrass;
    private Asset<SoundEffect> _soundGrab;
    private SoundEffectInstance _soundInstanceGrab;
    private Asset<SoundEffect> _soundPixie;
    private SoundEffectInstance _soundInstancePixie;
    private Asset<SoundEffect>[] _soundItem = new Asset<SoundEffect>[(int) SoundID.ItemSoundCount];
    private SoundEffectInstance[] _soundInstanceItem = new SoundEffectInstance[(int) SoundID.ItemSoundCount];
    private Asset<SoundEffect>[] _soundNpcHit = new Asset<SoundEffect>[58];
    private SoundEffectInstance[] _soundInstanceNpcHit = new SoundEffectInstance[58];
    private Asset<SoundEffect>[] _soundNpcKilled = new Asset<SoundEffect>[(int) SoundID.NPCDeathCount];
    private SoundEffectInstance[] _soundInstanceNpcKilled = new SoundEffectInstance[(int) SoundID.NPCDeathCount];
    private SoundEffectInstance _soundInstanceMoonlordCry;
    private Asset<SoundEffect> _soundDoorOpen;
    private SoundEffectInstance _soundInstanceDoorOpen;
    private Asset<SoundEffect> _soundDoorClosed;
    private SoundEffectInstance _soundInstanceDoorClosed;
    private Asset<SoundEffect> _soundMenuOpen;
    private SoundEffectInstance _soundInstanceMenuOpen;
    private Asset<SoundEffect> _soundMenuClose;
    private SoundEffectInstance _soundInstanceMenuClose;
    private Asset<SoundEffect> _soundMenuTick;
    private SoundEffectInstance _soundInstanceMenuTick;
    private Asset<SoundEffect> _soundShatter;
    private SoundEffectInstance _soundInstanceShatter;
    private Asset<SoundEffect> _soundCamera;
    private SoundEffectInstance _soundInstanceCamera;
    private Asset<SoundEffect>[] _soundZombie = new Asset<SoundEffect>[118];
    private SoundEffectInstance[] _soundInstanceZombie = new SoundEffectInstance[118];
    private Asset<SoundEffect>[] _soundRoar = new Asset<SoundEffect>[3];
    private SoundEffectInstance[] _soundInstanceRoar = new SoundEffectInstance[3];
    private Asset<SoundEffect>[] _soundSplash = new Asset<SoundEffect>[2];
    private SoundEffectInstance[] _soundInstanceSplash = new SoundEffectInstance[2];
    private Asset<SoundEffect> _soundDoubleJump;
    private SoundEffectInstance _soundInstanceDoubleJump;
    private Asset<SoundEffect> _soundRun;
    private SoundEffectInstance _soundInstanceRun;
    private Asset<SoundEffect> _soundCoins;
    private SoundEffectInstance _soundInstanceCoins;
    private Asset<SoundEffect> _soundUnlock;
    private SoundEffectInstance _soundInstanceUnlock;
    private Asset<SoundEffect> _soundChat;
    private SoundEffectInstance _soundInstanceChat;
    private Asset<SoundEffect> _soundMaxMana;
    private SoundEffectInstance _soundInstanceMaxMana;
    private Asset<SoundEffect> _soundDrown;
    private SoundEffectInstance _soundInstanceDrown;
    private Asset<SoundEffect>[] _trackableSounds;
    private SoundEffectInstance[] _trackableSoundInstances;
    private readonly IServiceProvider _services;

    public LegacySoundPlayer(IServiceProvider services)
    {
      this._services = services;
      this.LoadAll();
    }

    private void LoadAll()
    {
      this._soundMech[0] = this.Load("Sounds/Mech_0");
      this._soundGrab = this.Load("Sounds/Grab");
      this._soundPixie = this.Load("Sounds/Pixie");
      this._soundDig[0] = this.Load("Sounds/Dig_0");
      this._soundDig[1] = this.Load("Sounds/Dig_1");
      this._soundDig[2] = this.Load("Sounds/Dig_2");
      this._soundThunder[0] = this.Load("Sounds/Thunder_0");
      this._soundThunder[1] = this.Load("Sounds/Thunder_1");
      this._soundThunder[2] = this.Load("Sounds/Thunder_2");
      this._soundThunder[3] = this.Load("Sounds/Thunder_3");
      this._soundThunder[4] = this.Load("Sounds/Thunder_4");
      this._soundThunder[5] = this.Load("Sounds/Thunder_5");
      this._soundThunder[6] = this.Load("Sounds/Thunder_6");
      this._soundResearch[0] = this.Load("Sounds/Research_0");
      this._soundResearch[1] = this.Load("Sounds/Research_1");
      this._soundResearch[2] = this.Load("Sounds/Research_2");
      this._soundResearch[3] = this.Load("Sounds/Research_3");
      this._soundTink[0] = this.Load("Sounds/Tink_0");
      this._soundTink[1] = this.Load("Sounds/Tink_1");
      this._soundTink[2] = this.Load("Sounds/Tink_2");
      this._soundPlayerHit[0] = this.Load("Sounds/Player_Hit_0");
      this._soundPlayerHit[1] = this.Load("Sounds/Player_Hit_1");
      this._soundPlayerHit[2] = this.Load("Sounds/Player_Hit_2");
      this._soundFemaleHit[0] = this.Load("Sounds/Female_Hit_0");
      this._soundFemaleHit[1] = this.Load("Sounds/Female_Hit_1");
      this._soundFemaleHit[2] = this.Load("Sounds/Female_Hit_2");
      this._soundPlayerKilled = this.Load("Sounds/Player_Killed");
      this._soundChat = this.Load("Sounds/Chat");
      this._soundGrass = this.Load("Sounds/Grass");
      this._soundDoorOpen = this.Load("Sounds/Door_Opened");
      this._soundDoorClosed = this.Load("Sounds/Door_Closed");
      this._soundMenuTick = this.Load("Sounds/Menu_Tick");
      this._soundMenuOpen = this.Load("Sounds/Menu_Open");
      this._soundMenuClose = this.Load("Sounds/Menu_Close");
      this._soundShatter = this.Load("Sounds/Shatter");
      this._soundCamera = this.Load("Sounds/Camera");
      for (int index = 0; index < this._soundCoin.Length; ++index)
        this._soundCoin[index] = this.Load("Sounds/Coin_" + (object) index);
      for (int index = 0; index < this._soundDrip.Length; ++index)
        this._soundDrip[index] = this.Load("Sounds/Drip_" + (object) index);
      for (int index = 0; index < this._soundZombie.Length; ++index)
        this._soundZombie[index] = this.Load("Sounds/Zombie_" + (object) index);
      for (int index = 0; index < this._soundLiquid.Length; ++index)
        this._soundLiquid[index] = this.Load("Sounds/Liquid_" + (object) index);
      for (int index = 0; index < this._soundRoar.Length; ++index)
        this._soundRoar[index] = this.Load("Sounds/Roar_" + (object) index);
      this._soundSplash[0] = this.Load("Sounds/Splash_0");
      this._soundSplash[1] = this.Load("Sounds/Splash_1");
      this._soundDoubleJump = this.Load("Sounds/Double_Jump");
      this._soundRun = this.Load("Sounds/Run");
      this._soundCoins = this.Load("Sounds/Coins");
      this._soundUnlock = this.Load("Sounds/Unlock");
      this._soundMaxMana = this.Load("Sounds/MaxMana");
      this._soundDrown = this.Load("Sounds/Drown");
      for (int index = 1; index < this._soundItem.Length; ++index)
        this._soundItem[index] = this.Load("Sounds/Item_" + (object) index);
      for (int index = 1; index < this._soundNpcHit.Length; ++index)
        this._soundNpcHit[index] = this.Load("Sounds/NPC_Hit_" + (object) index);
      for (int index = 1; index < this._soundNpcKilled.Length; ++index)
        this._soundNpcKilled[index] = this.Load("Sounds/NPC_Killed_" + (object) index);
      this._trackableSounds = new Asset<SoundEffect>[SoundID.TrackableLegacySoundCount];
      this._trackableSoundInstances = new SoundEffectInstance[this._trackableSounds.Length];
      for (int id = 0; id < this._trackableSounds.Length; ++id)
        this._trackableSounds[id] = this.Load("Sounds/Custom" + Path.DirectorySeparatorChar.ToString() + SoundID.GetTrackableLegacySoundPath(id));
    }

    public void CreateAllSoundInstances()
    {
      this._soundInstanceMech[0] = this._soundMech[0].Value.CreateInstance();
      this._soundInstanceGrab = this._soundGrab.Value.CreateInstance();
      this._soundInstancePixie = this._soundGrab.Value.CreateInstance();
      this._soundInstanceDig[0] = this._soundDig[0].Value.CreateInstance();
      this._soundInstanceDig[1] = this._soundDig[1].Value.CreateInstance();
      this._soundInstanceDig[2] = this._soundDig[2].Value.CreateInstance();
      this._soundInstanceTink[0] = this._soundTink[0].Value.CreateInstance();
      this._soundInstanceTink[1] = this._soundTink[1].Value.CreateInstance();
      this._soundInstanceTink[2] = this._soundTink[2].Value.CreateInstance();
      this._soundInstancePlayerHit[0] = this._soundPlayerHit[0].Value.CreateInstance();
      this._soundInstancePlayerHit[1] = this._soundPlayerHit[1].Value.CreateInstance();
      this._soundInstancePlayerHit[2] = this._soundPlayerHit[2].Value.CreateInstance();
      this._soundInstanceFemaleHit[0] = this._soundFemaleHit[0].Value.CreateInstance();
      this._soundInstanceFemaleHit[1] = this._soundFemaleHit[1].Value.CreateInstance();
      this._soundInstanceFemaleHit[2] = this._soundFemaleHit[2].Value.CreateInstance();
      this._soundInstancePlayerKilled = this._soundPlayerKilled.Value.CreateInstance();
      this._soundInstanceChat = this._soundChat.Value.CreateInstance();
      this._soundInstanceGrass = this._soundGrass.Value.CreateInstance();
      this._soundInstanceDoorOpen = this._soundDoorOpen.Value.CreateInstance();
      this._soundInstanceDoorClosed = this._soundDoorClosed.Value.CreateInstance();
      this._soundInstanceMenuTick = this._soundMenuTick.Value.CreateInstance();
      this._soundInstanceMenuOpen = this._soundMenuOpen.Value.CreateInstance();
      this._soundInstanceMenuClose = this._soundMenuClose.Value.CreateInstance();
      this._soundInstanceShatter = this._soundShatter.Value.CreateInstance();
      this._soundInstanceCamera = this._soundCamera.Value.CreateInstance();
      for (int index = 0; index < this._soundThunder.Length; ++index)
        this._soundInstanceThunder[index] = this._soundThunder[index].Value.CreateInstance();
      for (int index = 0; index < this._soundResearch.Length; ++index)
        this._soundInstanceResearch[index] = this._soundResearch[index].Value.CreateInstance();
      for (int index = 0; index < this._soundCoin.Length; ++index)
        this._soundInstanceCoin[index] = this._soundCoin[index].Value.CreateInstance();
      for (int index = 0; index < this._soundDrip.Length; ++index)
        this._soundInstanceDrip[index] = this._soundDrip[index].Value.CreateInstance();
      for (int index = 0; index < this._soundZombie.Length; ++index)
        this._soundInstanceZombie[index] = this._soundZombie[index].Value.CreateInstance();
      for (int index = 0; index < this._soundLiquid.Length; ++index)
        this._soundInstanceLiquid[index] = this._soundLiquid[index].Value.CreateInstance();
      for (int index = 0; index < this._soundRoar.Length; ++index)
        this._soundInstanceRoar[index] = this._soundRoar[index].Value.CreateInstance();
      this._soundInstanceSplash[0] = this._soundRoar[0].Value.CreateInstance();
      this._soundInstanceSplash[1] = this._soundSplash[1].Value.CreateInstance();
      this._soundInstanceDoubleJump = this._soundRoar[0].Value.CreateInstance();
      this._soundInstanceRun = this._soundRun.Value.CreateInstance();
      this._soundInstanceCoins = this._soundCoins.Value.CreateInstance();
      this._soundInstanceUnlock = this._soundUnlock.Value.CreateInstance();
      this._soundInstanceMaxMana = this._soundMaxMana.Value.CreateInstance();
      this._soundInstanceDrown = this._soundDrown.Value.CreateInstance();
      for (int index = 1; index < this._soundItem.Length; ++index)
        this._soundInstanceItem[index] = this._soundItem[index].Value.CreateInstance();
      for (int index = 1; index < this._soundNpcHit.Length; ++index)
        this._soundInstanceNpcHit[index] = this._soundNpcHit[index].Value.CreateInstance();
      for (int index = 1; index < this._soundNpcKilled.Length; ++index)
        this._soundInstanceNpcKilled[index] = this._soundNpcKilled[index].Value.CreateInstance();
      for (int index = 0; index < this._trackableSounds.Length; ++index)
        this._trackableSoundInstances[index] = this._trackableSounds[index].Value.CreateInstance();
      this._soundInstanceMoonlordCry = this._soundNpcKilled[10].Value.CreateInstance();
    }

    private Asset<SoundEffect> Load(string assetName) => XnaExtensions.Get<IAssetRepository>(this._services).Request<SoundEffect>(assetName, (AssetRequestMode) 2);

    public SoundEffectInstance PlaySound(
      int type,
      int x = -1,
      int y = -1,
      int Style = 1,
      float volumeScale = 1f,
      float pitchOffset = 0.0f)
    {
      int index1 = Style;
      try
      {
        if (Main.dedServ || (double) Main.soundVolume == 0.0 && (type < 30 || type > 35))
          return (SoundEffectInstance) null;
        bool flag = false;
        float num1 = 1f;
        float num2 = 0.0f;
        if (x == -1 || y == -1)
        {
          flag = true;
        }
        else
        {
          if (WorldGen.gen || Main.netMode == 2)
            return (SoundEffectInstance) null;
          Vector2 vector2 = new Vector2(Main.screenPosition.X + (float) Main.screenWidth * 0.5f, Main.screenPosition.Y + (float) Main.screenHeight * 0.5f);
          double num3 = (double) Math.Abs((float) x - vector2.X);
          float num4 = Math.Abs((float) y - vector2.Y);
          float num5 = (float) Math.Sqrt(num3 * num3 + (double) num4 * (double) num4);
          int num6 = 2500;
          if ((double) num5 < (double) num6)
          {
            flag = true;
            num2 = type != 43 ? (float) (((double) x - (double) vector2.X) / ((double) Main.screenWidth * 0.5)) : (float) (((double) x - (double) vector2.X) / 900.0);
            num1 = (float) (1.0 - (double) num5 / (double) num6);
          }
        }
        if ((double) num2 < -1.0)
          num2 = -1f;
        if ((double) num2 > 1.0)
          num2 = 1f;
        if ((double) num1 > 1.0)
          num1 = 1f;
        if ((double) num1 <= 0.0 && (type < 34 || type > 35 || type > 39))
          return (SoundEffectInstance) null;
        if (flag)
        {
          float num7;
          if (type >= 30 && type <= 35 || type == 39)
          {
            num7 = num1 * (Main.ambientVolume * (Main.gameInactive ? 0.0f : 1f));
            if (Main.gameMenu)
              num7 = 0.0f;
          }
          else
            num7 = num1 * Main.soundVolume;
          if ((double) num7 > 1.0)
            num7 = 1f;
          if ((double) num7 <= 0.0 && (type < 30 || type > 35) && type != 39)
            return (SoundEffectInstance) null;
          SoundEffectInstance sound = (SoundEffectInstance) null;
          if (type == 0)
          {
            int index2 = Main.rand.Next(3);
            if (this._soundInstanceDig[index2] != null)
              this._soundInstanceDig[index2].Stop();
            this._soundInstanceDig[index2] = this._soundDig[index2].Value.CreateInstance();
            this._soundInstanceDig[index2].Volume = num7;
            this._soundInstanceDig[index2].Pan = num2;
            this._soundInstanceDig[index2].Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            sound = this._soundInstanceDig[index2];
          }
          else if (type == 43)
          {
            int index3 = Main.rand.Next(this._soundThunder.Length);
            for (int index4 = 0; index4 < this._soundThunder.Length && this._soundInstanceThunder[index3] != null && this._soundInstanceThunder[index3].State == SoundState.Playing; ++index4)
              index3 = Main.rand.Next(this._soundThunder.Length);
            if (this._soundInstanceThunder[index3] != null)
              this._soundInstanceThunder[index3].Stop();
            this._soundInstanceThunder[index3] = this._soundThunder[index3].Value.CreateInstance();
            this._soundInstanceThunder[index3].Volume = num7;
            this._soundInstanceThunder[index3].Pan = num2;
            this._soundInstanceThunder[index3].Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            sound = this._soundInstanceThunder[index3];
          }
          else if (type == 63)
          {
            int index5 = Main.rand.Next(1, 4);
            if (this._soundInstanceResearch[index5] != null)
              this._soundInstanceResearch[index5].Stop();
            this._soundInstanceResearch[index5] = this._soundResearch[index5].Value.CreateInstance();
            this._soundInstanceResearch[index5].Volume = num7;
            this._soundInstanceResearch[index5].Pan = num2;
            sound = this._soundInstanceResearch[index5];
          }
          else if (type == 64)
          {
            if (this._soundInstanceResearch[0] != null)
              this._soundInstanceResearch[0].Stop();
            this._soundInstanceResearch[0] = this._soundResearch[0].Value.CreateInstance();
            this._soundInstanceResearch[0].Volume = num7;
            this._soundInstanceResearch[0].Pan = num2;
            sound = this._soundInstanceResearch[0];
          }
          else if (type == 1)
          {
            int index6 = Main.rand.Next(3);
            if (this._soundInstancePlayerHit[index6] != null)
              this._soundInstancePlayerHit[index6].Stop();
            this._soundInstancePlayerHit[index6] = this._soundPlayerHit[index6].Value.CreateInstance();
            this._soundInstancePlayerHit[index6].Volume = num7;
            this._soundInstancePlayerHit[index6].Pan = num2;
            sound = this._soundInstancePlayerHit[index6];
          }
          else if (type == 2)
          {
            if (index1 == 129)
              num7 *= 0.6f;
            if (index1 == 123)
              num7 *= 0.5f;
            if (index1 == 124 || index1 == 125)
              num7 *= 0.65f;
            if (index1 == 116)
              num7 *= 0.5f;
            if (index1 == 1)
            {
              int num8 = Main.rand.Next(3);
              if (num8 == 1)
                index1 = 18;
              if (num8 == 2)
                index1 = 19;
            }
            else if (index1 == 55 || index1 == 53)
            {
              num7 *= 0.75f;
              if (index1 == 55)
                num7 *= 0.75f;
              if (this._soundInstanceItem[index1] != null && this._soundInstanceItem[index1].State == SoundState.Playing)
                return (SoundEffectInstance) null;
            }
            else if (index1 == 37)
              num7 *= 0.5f;
            else if (index1 == 52)
              num7 *= 0.35f;
            else if (index1 == 157)
              num7 *= 0.7f;
            else if (index1 == 158)
              num7 *= 0.8f;
            if (index1 == 159)
            {
              if (this._soundInstanceItem[index1] != null && this._soundInstanceItem[index1].State == SoundState.Playing)
                return (SoundEffectInstance) null;
              num7 *= 0.75f;
            }
            else if (index1 != 9 && index1 != 10 && index1 != 24 && index1 != 26 && index1 != 34 && index1 != 43 && index1 != 103 && index1 != 156 && index1 != 162 && this._soundInstanceItem[index1] != null)
              this._soundInstanceItem[index1].Stop();
            this._soundInstanceItem[index1] = this._soundItem[index1].Value.CreateInstance();
            this._soundInstanceItem[index1].Volume = num7;
            this._soundInstanceItem[index1].Pan = num2;
            switch (index1)
            {
              case 53:
                this._soundInstanceItem[index1].Pitch = (float) Main.rand.Next(-20, -11) * 0.02f;
                break;
              case 55:
                this._soundInstanceItem[index1].Pitch = (float) -Main.rand.Next(-20, -11) * 0.02f;
                break;
              case 132:
                this._soundInstanceItem[index1].Pitch = (float) Main.rand.Next(-20, 21) * (1f / 1000f);
                break;
              case 153:
                this._soundInstanceItem[index1].Pitch = (float) Main.rand.Next(-50, 51) * (3f / 1000f);
                break;
              case 156:
                this._soundInstanceItem[index1].Pitch = (float) Main.rand.Next(-50, 51) * (1f / 500f);
                this._soundInstanceItem[index1].Volume *= 0.6f;
                break;
              default:
                this._soundInstanceItem[index1].Pitch = (float) Main.rand.Next(-6, 7) * 0.01f;
                break;
            }
            if (index1 == 26 || index1 == 35 || index1 == 47)
            {
              this._soundInstanceItem[index1].Volume = num7 * 0.75f;
              this._soundInstanceItem[index1].Pitch = Main.musicPitch;
            }
            if (index1 == 169)
              this._soundInstanceItem[index1].Pitch -= 0.8f;
            sound = this._soundInstanceItem[index1];
          }
          else if (type == 3)
          {
            if (index1 >= 20 && index1 <= 54)
              num7 *= 0.5f;
            if (index1 == 57 && this._soundInstanceNpcHit[index1] != null && this._soundInstanceNpcHit[index1].State == SoundState.Playing)
              return (SoundEffectInstance) null;
            if (index1 == 57)
              num7 *= 0.6f;
            if (index1 == 55 || index1 == 56)
              num7 *= 0.5f;
            if (this._soundInstanceNpcHit[index1] != null)
              this._soundInstanceNpcHit[index1].Stop();
            this._soundInstanceNpcHit[index1] = this._soundNpcHit[index1].Value.CreateInstance();
            this._soundInstanceNpcHit[index1].Volume = num7;
            this._soundInstanceNpcHit[index1].Pan = num2;
            this._soundInstanceNpcHit[index1].Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            sound = this._soundInstanceNpcHit[index1];
          }
          else if (type == 4)
          {
            if (index1 >= 23 && index1 <= 57)
              num7 *= 0.5f;
            if (index1 == 61)
              num7 *= 0.6f;
            if (index1 == 62)
              num7 *= 0.6f;
            if (index1 == 10 && this._soundInstanceNpcKilled[index1] != null && this._soundInstanceNpcKilled[index1].State == SoundState.Playing)
              return (SoundEffectInstance) null;
            this._soundInstanceNpcKilled[index1] = this._soundNpcKilled[index1].Value.CreateInstance();
            this._soundInstanceNpcKilled[index1].Volume = num7;
            this._soundInstanceNpcKilled[index1].Pan = num2;
            this._soundInstanceNpcKilled[index1].Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            sound = this._soundInstanceNpcKilled[index1];
          }
          else if (type == 5)
          {
            if (this._soundInstancePlayerKilled != null)
              this._soundInstancePlayerKilled.Stop();
            this._soundInstancePlayerKilled = this._soundPlayerKilled.Value.CreateInstance();
            this._soundInstancePlayerKilled.Volume = num7;
            this._soundInstancePlayerKilled.Pan = num2;
            sound = this._soundInstancePlayerKilled;
          }
          else if (type == 6)
          {
            if (this._soundInstanceGrass != null)
              this._soundInstanceGrass.Stop();
            this._soundInstanceGrass = this._soundGrass.Value.CreateInstance();
            this._soundInstanceGrass.Volume = num7;
            this._soundInstanceGrass.Pan = num2;
            this._soundInstanceGrass.Pitch = (float) Main.rand.Next(-30, 31) * 0.01f;
            sound = this._soundInstanceGrass;
          }
          else if (type == 7)
          {
            if (this._soundInstanceGrab != null)
              this._soundInstanceGrab.Stop();
            this._soundInstanceGrab = this._soundGrab.Value.CreateInstance();
            this._soundInstanceGrab.Volume = num7;
            this._soundInstanceGrab.Pan = num2;
            this._soundInstanceGrab.Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            sound = this._soundInstanceGrab;
          }
          else if (type == 8)
          {
            if (this._soundInstanceDoorOpen != null)
              this._soundInstanceDoorOpen.Stop();
            this._soundInstanceDoorOpen = this._soundDoorOpen.Value.CreateInstance();
            this._soundInstanceDoorOpen.Volume = num7;
            this._soundInstanceDoorOpen.Pan = num2;
            this._soundInstanceDoorOpen.Pitch = (float) Main.rand.Next(-20, 21) * 0.01f;
            sound = this._soundInstanceDoorOpen;
          }
          else if (type == 9)
          {
            if (this._soundInstanceDoorClosed != null)
              this._soundInstanceDoorClosed.Stop();
            this._soundInstanceDoorClosed = this._soundDoorClosed.Value.CreateInstance();
            this._soundInstanceDoorClosed.Volume = num7;
            this._soundInstanceDoorClosed.Pan = num2;
            this._soundInstanceDoorClosed.Pitch = (float) Main.rand.Next(-20, 21) * 0.01f;
            sound = this._soundInstanceDoorClosed;
          }
          else if (type == 10)
          {
            if (this._soundInstanceMenuOpen != null)
              this._soundInstanceMenuOpen.Stop();
            this._soundInstanceMenuOpen = this._soundMenuOpen.Value.CreateInstance();
            this._soundInstanceMenuOpen.Volume = num7;
            this._soundInstanceMenuOpen.Pan = num2;
            sound = this._soundInstanceMenuOpen;
          }
          else if (type == 11)
          {
            if (this._soundInstanceMenuClose != null)
              this._soundInstanceMenuClose.Stop();
            this._soundInstanceMenuClose = this._soundMenuClose.Value.CreateInstance();
            this._soundInstanceMenuClose.Volume = num7;
            this._soundInstanceMenuClose.Pan = num2;
            sound = this._soundInstanceMenuClose;
          }
          else if (type == 12)
          {
            if (Main.hasFocus)
            {
              if (this._soundInstanceMenuTick != null)
                this._soundInstanceMenuTick.Stop();
              this._soundInstanceMenuTick = this._soundMenuTick.Value.CreateInstance();
              this._soundInstanceMenuTick.Volume = num7;
              this._soundInstanceMenuTick.Pan = num2;
              sound = this._soundInstanceMenuTick;
            }
          }
          else if (type == 13)
          {
            if (this._soundInstanceShatter != null)
              this._soundInstanceShatter.Stop();
            this._soundInstanceShatter = this._soundShatter.Value.CreateInstance();
            this._soundInstanceShatter.Volume = num7;
            this._soundInstanceShatter.Pan = num2;
            sound = this._soundInstanceShatter;
          }
          else if (type == 14)
          {
            switch (Style)
            {
              case 489:
              case 586:
                int index7 = Main.rand.Next(21, 24);
                this._soundInstanceZombie[index7] = this._soundZombie[index7].Value.CreateInstance();
                this._soundInstanceZombie[index7].Volume = num7 * 0.4f;
                this._soundInstanceZombie[index7].Pan = num2;
                sound = this._soundInstanceZombie[index7];
                break;
              case 542:
                int index8 = 7;
                this._soundInstanceZombie[index8] = this._soundZombie[index8].Value.CreateInstance();
                this._soundInstanceZombie[index8].Volume = num7 * 0.4f;
                this._soundInstanceZombie[index8].Pan = num2;
                sound = this._soundInstanceZombie[index8];
                break;
              default:
                int index9 = Main.rand.Next(3);
                this._soundInstanceZombie[index9] = this._soundZombie[index9].Value.CreateInstance();
                this._soundInstanceZombie[index9].Volume = num7 * 0.4f;
                this._soundInstanceZombie[index9].Pan = num2;
                sound = this._soundInstanceZombie[index9];
                break;
            }
          }
          else if (type == 15)
          {
            float num9 = 1f;
            if (index1 == 4)
            {
              index1 = 1;
              num9 = 0.25f;
            }
            if (this._soundInstanceRoar[index1] == null || this._soundInstanceRoar[index1].State == SoundState.Stopped)
            {
              this._soundInstanceRoar[index1] = this._soundRoar[index1].Value.CreateInstance();
              this._soundInstanceRoar[index1].Volume = num7 * num9;
              this._soundInstanceRoar[index1].Pan = num2;
              sound = this._soundInstanceRoar[index1];
            }
          }
          else if (type == 16)
          {
            if (this._soundInstanceDoubleJump != null)
              this._soundInstanceDoubleJump.Stop();
            this._soundInstanceDoubleJump = this._soundDoubleJump.Value.CreateInstance();
            this._soundInstanceDoubleJump.Volume = num7;
            this._soundInstanceDoubleJump.Pan = num2;
            this._soundInstanceDoubleJump.Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            sound = this._soundInstanceDoubleJump;
          }
          else if (type == 17)
          {
            if (this._soundInstanceRun != null)
              this._soundInstanceRun.Stop();
            this._soundInstanceRun = this._soundRun.Value.CreateInstance();
            this._soundInstanceRun.Volume = num7;
            this._soundInstanceRun.Pan = num2;
            this._soundInstanceRun.Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            sound = this._soundInstanceRun;
          }
          else if (type == 18)
          {
            this._soundInstanceCoins = this._soundCoins.Value.CreateInstance();
            this._soundInstanceCoins.Volume = num7;
            this._soundInstanceCoins.Pan = num2;
            sound = this._soundInstanceCoins;
          }
          else if (type == 19)
          {
            if (this._soundInstanceSplash[index1] == null || this._soundInstanceSplash[index1].State == SoundState.Stopped)
            {
              this._soundInstanceSplash[index1] = this._soundSplash[index1].Value.CreateInstance();
              this._soundInstanceSplash[index1].Volume = num7;
              this._soundInstanceSplash[index1].Pan = num2;
              this._soundInstanceSplash[index1].Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
              sound = this._soundInstanceSplash[index1];
            }
          }
          else if (type == 20)
          {
            int index10 = Main.rand.Next(3);
            if (this._soundInstanceFemaleHit[index10] != null)
              this._soundInstanceFemaleHit[index10].Stop();
            this._soundInstanceFemaleHit[index10] = this._soundFemaleHit[index10].Value.CreateInstance();
            this._soundInstanceFemaleHit[index10].Volume = num7;
            this._soundInstanceFemaleHit[index10].Pan = num2;
            sound = this._soundInstanceFemaleHit[index10];
          }
          else if (type == 21)
          {
            int index11 = Main.rand.Next(3);
            if (this._soundInstanceTink[index11] != null)
              this._soundInstanceTink[index11].Stop();
            this._soundInstanceTink[index11] = this._soundTink[index11].Value.CreateInstance();
            this._soundInstanceTink[index11].Volume = num7;
            this._soundInstanceTink[index11].Pan = num2;
            sound = this._soundInstanceTink[index11];
          }
          else if (type == 22)
          {
            if (this._soundInstanceUnlock != null)
              this._soundInstanceUnlock.Stop();
            this._soundInstanceUnlock = this._soundUnlock.Value.CreateInstance();
            this._soundInstanceUnlock.Volume = num7;
            this._soundInstanceUnlock.Pan = num2;
            sound = this._soundInstanceUnlock;
          }
          else if (type == 23)
          {
            if (this._soundInstanceDrown != null)
              this._soundInstanceDrown.Stop();
            this._soundInstanceDrown = this._soundDrown.Value.CreateInstance();
            this._soundInstanceDrown.Volume = num7;
            this._soundInstanceDrown.Pan = num2;
            sound = this._soundInstanceDrown;
          }
          else if (type == 24)
          {
            this._soundInstanceChat = this._soundChat.Value.CreateInstance();
            this._soundInstanceChat.Volume = num7;
            this._soundInstanceChat.Pan = num2;
            sound = this._soundInstanceChat;
          }
          else if (type == 25)
          {
            this._soundInstanceMaxMana = this._soundMaxMana.Value.CreateInstance();
            this._soundInstanceMaxMana.Volume = num7;
            this._soundInstanceMaxMana.Pan = num2;
            sound = this._soundInstanceMaxMana;
          }
          else if (type == 26)
          {
            int index12 = Main.rand.Next(3, 5);
            this._soundInstanceZombie[index12] = this._soundZombie[index12].Value.CreateInstance();
            this._soundInstanceZombie[index12].Volume = num7 * 0.9f;
            this._soundInstanceZombie[index12].Pan = num2;
            this._soundInstanceZombie[index12].Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            sound = this._soundInstanceZombie[index12];
          }
          else if (type == 27)
          {
            if (this._soundInstancePixie != null && this._soundInstancePixie.State == SoundState.Playing)
            {
              this._soundInstancePixie.Volume = num7;
              this._soundInstancePixie.Pan = num2;
              this._soundInstancePixie.Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
              return (SoundEffectInstance) null;
            }
            if (this._soundInstancePixie != null)
              this._soundInstancePixie.Stop();
            this._soundInstancePixie = this._soundPixie.Value.CreateInstance();
            this._soundInstancePixie.Volume = num7;
            this._soundInstancePixie.Pan = num2;
            this._soundInstancePixie.Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            sound = this._soundInstancePixie;
          }
          else if (type == 28)
          {
            if (this._soundInstanceMech[index1] != null && this._soundInstanceMech[index1].State == SoundState.Playing)
              return (SoundEffectInstance) null;
            this._soundInstanceMech[index1] = this._soundMech[index1].Value.CreateInstance();
            this._soundInstanceMech[index1].Volume = num7;
            this._soundInstanceMech[index1].Pan = num2;
            this._soundInstanceMech[index1].Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            sound = this._soundInstanceMech[index1];
          }
          else if (type == 29)
          {
            if (index1 >= 24 && index1 <= 87)
              num7 *= 0.5f;
            if (index1 >= 88 && index1 <= 91)
              num7 *= 0.7f;
            if (index1 >= 93 && index1 <= 99)
              num7 *= 0.4f;
            if (index1 == 92)
              num7 *= 0.5f;
            if (index1 == 103)
              num7 *= 0.4f;
            if (index1 == 104)
              num7 *= 0.55f;
            if (index1 == 100 || index1 == 101)
              num7 *= 0.25f;
            if (index1 == 102)
              num7 *= 0.4f;
            if (this._soundInstanceZombie[index1] != null && this._soundInstanceZombie[index1].State == SoundState.Playing)
              return (SoundEffectInstance) null;
            this._soundInstanceZombie[index1] = this._soundZombie[index1].Value.CreateInstance();
            this._soundInstanceZombie[index1].Volume = num7;
            this._soundInstanceZombie[index1].Pan = num2;
            this._soundInstanceZombie[index1].Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            sound = this._soundInstanceZombie[index1];
          }
          else if (type == 44)
          {
            int index13 = Main.rand.Next(106, 109);
            this._soundInstanceZombie[index13] = this._soundZombie[index13].Value.CreateInstance();
            this._soundInstanceZombie[index13].Volume = num7 * 0.2f;
            this._soundInstanceZombie[index13].Pan = num2;
            this._soundInstanceZombie[index13].Pitch = (float) Main.rand.Next(-70, 1) * 0.01f;
            sound = this._soundInstanceZombie[index13];
          }
          else if (type == 45)
          {
            int index14 = 109;
            if (this._soundInstanceZombie[index14] != null && this._soundInstanceZombie[index14].State == SoundState.Playing)
              return (SoundEffectInstance) null;
            this._soundInstanceZombie[index14] = this._soundZombie[index14].Value.CreateInstance();
            this._soundInstanceZombie[index14].Volume = num7 * 0.3f;
            this._soundInstanceZombie[index14].Pan = num2;
            this._soundInstanceZombie[index14].Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            sound = this._soundInstanceZombie[index14];
          }
          else if (type == 46)
          {
            if (this._soundInstanceZombie[110] != null && this._soundInstanceZombie[110].State == SoundState.Playing || this._soundInstanceZombie[111] != null && this._soundInstanceZombie[111].State == SoundState.Playing)
              return (SoundEffectInstance) null;
            int index15 = Main.rand.Next(110, 112);
            if (Main.rand.Next(300) == 0)
              index15 = Main.rand.Next(3) != 0 ? (Main.rand.Next(2) != 0 ? 112 : 113) : 114;
            this._soundInstanceZombie[index15] = this._soundZombie[index15].Value.CreateInstance();
            this._soundInstanceZombie[index15].Volume = num7 * 0.9f;
            this._soundInstanceZombie[index15].Pan = num2;
            this._soundInstanceZombie[index15].Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            sound = this._soundInstanceZombie[index15];
          }
          else if (type == 45)
          {
            int index16 = 109;
            this._soundInstanceZombie[index16] = this._soundZombie[index16].Value.CreateInstance();
            this._soundInstanceZombie[index16].Volume = num7 * 0.2f;
            this._soundInstanceZombie[index16].Pan = num2;
            this._soundInstanceZombie[index16].Pitch = (float) Main.rand.Next(-70, 1) * 0.01f;
            sound = this._soundInstanceZombie[index16];
          }
          else if (type == 30)
          {
            int index17 = Main.rand.Next(10, 12);
            if (Main.rand.Next(300) == 0)
            {
              index17 = 12;
              if (this._soundInstanceZombie[index17] != null && this._soundInstanceZombie[index17].State == SoundState.Playing)
                return (SoundEffectInstance) null;
            }
            this._soundInstanceZombie[index17] = this._soundZombie[index17].Value.CreateInstance();
            this._soundInstanceZombie[index17].Volume = num7 * 0.75f;
            this._soundInstanceZombie[index17].Pan = num2;
            this._soundInstanceZombie[index17].Pitch = index17 == 12 ? (float) Main.rand.Next(-40, 21) * 0.01f : (float) Main.rand.Next(-70, 1) * 0.01f;
            sound = this._soundInstanceZombie[index17];
          }
          else if (type == 31)
          {
            int index18 = 13;
            this._soundInstanceZombie[index18] = this._soundZombie[index18].Value.CreateInstance();
            this._soundInstanceZombie[index18].Volume = num7 * 0.35f;
            this._soundInstanceZombie[index18].Pan = num2;
            this._soundInstanceZombie[index18].Pitch = (float) Main.rand.Next(-40, 21) * 0.01f;
            sound = this._soundInstanceZombie[index18];
          }
          else if (type == 32)
          {
            if (this._soundInstanceZombie[index1] != null && this._soundInstanceZombie[index1].State == SoundState.Playing)
              return (SoundEffectInstance) null;
            this._soundInstanceZombie[index1] = this._soundZombie[index1].Value.CreateInstance();
            this._soundInstanceZombie[index1].Volume = num7 * 0.15f;
            this._soundInstanceZombie[index1].Pan = num2;
            this._soundInstanceZombie[index1].Pitch = (float) Main.rand.Next(-70, 26) * 0.01f;
            sound = this._soundInstanceZombie[index1];
          }
          else if (type == 33)
          {
            int index19 = 15;
            if (this._soundInstanceZombie[index19] != null && this._soundInstanceZombie[index19].State == SoundState.Playing)
              return (SoundEffectInstance) null;
            this._soundInstanceZombie[index19] = this._soundZombie[index19].Value.CreateInstance();
            this._soundInstanceZombie[index19].Volume = num7 * 0.2f;
            this._soundInstanceZombie[index19].Pan = num2;
            this._soundInstanceZombie[index19].Pitch = (float) Main.rand.Next(-10, 31) * 0.01f;
            sound = this._soundInstanceZombie[index19];
          }
          else if (type >= 47 && type <= 52)
          {
            int index20 = 133 + type - 47;
            for (int index21 = 133; index21 <= 138; ++index21)
            {
              if (this._soundInstanceItem[index21] != null && this._soundInstanceItem[index21].State == SoundState.Playing)
                this._soundInstanceItem[index21].Stop();
            }
            this._soundInstanceItem[index20] = this._soundItem[index20].Value.CreateInstance();
            this._soundInstanceItem[index20].Volume = num7 * 0.45f;
            this._soundInstanceItem[index20].Pan = num2;
            sound = this._soundInstanceItem[index20];
          }
          else if (type >= 53 && type <= 62)
          {
            int index22 = 139 + type - 53;
            if (this._soundInstanceItem[index22] != null && this._soundInstanceItem[index22].State == SoundState.Playing)
              this._soundInstanceItem[index22].Stop();
            this._soundInstanceItem[index22] = this._soundItem[index22].Value.CreateInstance();
            this._soundInstanceItem[index22].Volume = num7 * 0.7f;
            this._soundInstanceItem[index22].Pan = num2;
            sound = this._soundInstanceItem[index22];
          }
          else
          {
            switch (type)
            {
              case 34:
                float num10 = (float) index1 / 50f;
                if ((double) num10 > 1.0)
                  num10 = 1f;
                float num11 = num7 * num10 * 0.2f;
                if ((double) num11 <= 0.0 || x == -1 || y == -1)
                {
                  if (this._soundInstanceLiquid[0] != null && this._soundInstanceLiquid[0].State == SoundState.Playing)
                  {
                    this._soundInstanceLiquid[0].Stop();
                    break;
                  }
                  break;
                }
                if (this._soundInstanceLiquid[0] != null && this._soundInstanceLiquid[0].State == SoundState.Playing)
                {
                  this._soundInstanceLiquid[0].Volume = num11;
                  this._soundInstanceLiquid[0].Pan = num2;
                  this._soundInstanceLiquid[0].Pitch = -0.2f;
                  break;
                }
                this._soundInstanceLiquid[0] = this._soundLiquid[0].Value.CreateInstance();
                this._soundInstanceLiquid[0].Volume = num11;
                this._soundInstanceLiquid[0].Pan = num2;
                sound = this._soundInstanceLiquid[0];
                break;
              case 35:
                float num12 = (float) index1 / 50f;
                if ((double) num12 > 1.0)
                  num12 = 1f;
                float num13 = num7 * num12 * 0.65f;
                if ((double) num13 <= 0.0 || x == -1 || y == -1)
                {
                  if (this._soundInstanceLiquid[1] != null && this._soundInstanceLiquid[1].State == SoundState.Playing)
                  {
                    this._soundInstanceLiquid[1].Stop();
                    break;
                  }
                  break;
                }
                if (this._soundInstanceLiquid[1] != null && this._soundInstanceLiquid[1].State == SoundState.Playing)
                {
                  this._soundInstanceLiquid[1].Volume = num13;
                  this._soundInstanceLiquid[1].Pan = num2;
                  this._soundInstanceLiquid[1].Pitch = -0.0f;
                  break;
                }
                this._soundInstanceLiquid[1] = this._soundLiquid[1].Value.CreateInstance();
                this._soundInstanceLiquid[1].Volume = num13;
                this._soundInstanceLiquid[1].Pan = num2;
                sound = this._soundInstanceLiquid[1];
                break;
              case 36:
                int index23 = Style;
                if (Style == -1)
                  index23 = 0;
                this._soundInstanceRoar[index23] = this._soundRoar[index23].Value.CreateInstance();
                this._soundInstanceRoar[index23].Volume = num7;
                this._soundInstanceRoar[index23].Pan = num2;
                if (Style == -1)
                  this._soundInstanceRoar[index23].Pitch += 0.6f;
                sound = this._soundInstanceRoar[index23];
                break;
              case 37:
                int index24 = Main.rand.Next(57, 59);
                float num14 = num7 * ((float) Style * 0.05f);
                this._soundInstanceItem[index24] = this._soundItem[index24].Value.CreateInstance();
                this._soundInstanceItem[index24].Volume = num14;
                this._soundInstanceItem[index24].Pan = num2;
                this._soundInstanceItem[index24].Pitch = (float) Main.rand.Next(-40, 41) * 0.01f;
                sound = this._soundInstanceItem[index24];
                break;
              case 38:
                int index25 = Main.rand.Next(5);
                this._soundInstanceCoin[index25] = this._soundCoin[index25].Value.CreateInstance();
                this._soundInstanceCoin[index25].Volume = num7;
                this._soundInstanceCoin[index25].Pan = num2;
                this._soundInstanceCoin[index25].Pitch = (float) Main.rand.Next(-40, 41) * (1f / 500f);
                sound = this._soundInstanceCoin[index25];
                break;
              case 39:
                int index26 = Style;
                this._soundInstanceDrip[index26] = this._soundDrip[index26].Value.CreateInstance();
                this._soundInstanceDrip[index26].Volume = num7 * 0.5f;
                this._soundInstanceDrip[index26].Pan = num2;
                this._soundInstanceDrip[index26].Pitch = (float) Main.rand.Next(-30, 31) * 0.01f;
                sound = this._soundInstanceDrip[index26];
                break;
              case 40:
                if (this._soundInstanceCamera != null)
                  this._soundInstanceCamera.Stop();
                this._soundInstanceCamera = this._soundCamera.Value.CreateInstance();
                this._soundInstanceCamera.Volume = num7;
                this._soundInstanceCamera.Pan = num2;
                sound = this._soundInstanceCamera;
                break;
              case 41:
                this._soundInstanceMoonlordCry = this._soundNpcKilled[10].Value.CreateInstance();
                this._soundInstanceMoonlordCry.Volume = (float) (1.0 / (1.0 + (double) (new Vector2((float) x, (float) y) - Main.player[Main.myPlayer].position).Length()));
                this._soundInstanceMoonlordCry.Pan = num2;
                this._soundInstanceMoonlordCry.Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
                sound = this._soundInstanceMoonlordCry;
                break;
              case 42:
                sound = this._trackableSounds[index1].Value.CreateInstance();
                sound.Volume = num7;
                sound.Pan = num2;
                this._trackableSoundInstances[index1] = sound;
                break;
              case 65:
                if (this._soundInstanceZombie[115] != null && this._soundInstanceZombie[115].State == SoundState.Playing || this._soundInstanceZombie[116] != null && this._soundInstanceZombie[116].State == SoundState.Playing || this._soundInstanceZombie[117] != null && this._soundInstanceZombie[117].State == SoundState.Playing)
                  return (SoundEffectInstance) null;
                int index27 = Main.rand.Next(115, 118);
                this._soundInstanceZombie[index27] = this._soundZombie[index27].Value.CreateInstance();
                this._soundInstanceZombie[index27].Volume = num7 * 0.5f;
                this._soundInstanceZombie[index27].Pan = num2;
                sound = this._soundInstanceZombie[index27];
                break;
            }
          }
          if (sound != null)
          {
            sound.Pitch += pitchOffset;
            sound.Volume *= volumeScale;
            sound.Play();
            SoundInstanceGarbageCollector.Track(sound);
          }
          return sound;
        }
      }
      catch
      {
      }
      return (SoundEffectInstance) null;
    }

    public SoundEffect GetTrackableSoundByStyleId(int id) => this._trackableSounds[id].Value;

    public void StopAmbientSounds()
    {
      for (int index = 0; index < this._soundInstanceLiquid.Length; ++index)
      {
        if (this._soundInstanceLiquid[index] != null)
          this._soundInstanceLiquid[index].Stop();
      }
    }
  }
}
