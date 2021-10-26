// Decompiled with JetBrains decompiler
// Type: Terraria.Audio.SoundEngine
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using ReLogic.Utilities;
using System;
using System.IO;

namespace Terraria.Audio
{
  public static class SoundEngine
  {
    private static LegacySoundPlayer _legacyPlayer;
    private static SoundPlayer _player;
    private static bool _areSoundsPaused;

    public static bool IsAudioSupported { get; private set; }

    public static void Initialize() => SoundEngine.IsAudioSupported = SoundEngine.TestAudioSupport();

    public static void Load(IServiceProvider services)
    {
      if (!SoundEngine.IsAudioSupported)
        return;
      SoundEngine._legacyPlayer = new LegacySoundPlayer(services);
      SoundEngine._player = new SoundPlayer();
    }

    public static void Update()
    {
      if (!SoundEngine.IsAudioSupported)
        return;
      SoundInstanceGarbageCollector.Update();
      bool flag = (!Main.hasFocus || Main.gamePaused) && Main.netMode == 0;
      if (!SoundEngine._areSoundsPaused & flag)
        SoundEngine._player.PauseAll();
      else if (SoundEngine._areSoundsPaused && !flag)
        SoundEngine._player.ResumeAll();
      SoundEngine._areSoundsPaused = flag;
      SoundEngine._player.Update();
    }

    public static void PlaySound(int type, Vector2 position, int style = 1) => SoundEngine.PlaySound(type, (int) position.X, (int) position.Y, style);

    public static SoundEffectInstance PlaySound(
      LegacySoundStyle type,
      Vector2 position)
    {
      return SoundEngine.PlaySound(type, (int) position.X, (int) position.Y);
    }

    public static SoundEffectInstance PlaySound(
      LegacySoundStyle type,
      int x = -1,
      int y = -1)
    {
      return type == null ? (SoundEffectInstance) null : SoundEngine.PlaySound(type.SoundId, x, y, type.Style, type.Volume, type.GetRandomPitch());
    }

    public static SoundEffectInstance PlaySound(
      int type,
      int x = -1,
      int y = -1,
      int Style = 1,
      float volumeScale = 1f,
      float pitchOffset = 0.0f)
    {
      return !SoundEngine.IsAudioSupported ? (SoundEffectInstance) null : SoundEngine._legacyPlayer.PlaySound(type, x, y, Style, volumeScale, pitchOffset);
    }

    public static ActiveSound GetActiveSound(SlotId id) => !SoundEngine.IsAudioSupported ? (ActiveSound) null : SoundEngine._player.GetActiveSound(id);

    public static SlotId PlayTrackedSound(SoundStyle style, Vector2 position) => !SoundEngine.IsAudioSupported ? (SlotId) SlotId.Invalid : SoundEngine._player.Play(style, position);

    public static SlotId PlayTrackedSound(SoundStyle style) => !SoundEngine.IsAudioSupported ? (SlotId) SlotId.Invalid : SoundEngine._player.Play(style);

    public static void StopTrackedSounds()
    {
      if (!SoundEngine.IsAudioSupported)
        return;
      SoundEngine._player.StopAll();
    }

    public static SoundEffect GetTrackableSoundByStyleId(int id) => !SoundEngine.IsAudioSupported ? (SoundEffect) null : SoundEngine._legacyPlayer.GetTrackableSoundByStyleId(id);

    public static void StopAmbientSounds()
    {
      if (!SoundEngine.IsAudioSupported || SoundEngine._legacyPlayer == null)
        return;
      SoundEngine._legacyPlayer.StopAmbientSounds();
    }

    public static ActiveSound FindActiveSound(SoundStyle style) => !SoundEngine.IsAudioSupported ? (ActiveSound) null : SoundEngine._player.FindActiveSound(style);

    private static bool TestAudioSupport()
    {
      byte[] buffer = new byte[166]
      {
        (byte) 82,
        (byte) 73,
        (byte) 70,
        (byte) 70,
        (byte) 158,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 87,
        (byte) 65,
        (byte) 86,
        (byte) 69,
        (byte) 102,
        (byte) 109,
        (byte) 116,
        (byte) 32,
        (byte) 16,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 1,
        (byte) 0,
        (byte) 1,
        (byte) 0,
        (byte) 68,
        (byte) 172,
        (byte) 0,
        (byte) 0,
        (byte) 136,
        (byte) 88,
        (byte) 1,
        (byte) 0,
        (byte) 2,
        (byte) 0,
        (byte) 16,
        (byte) 0,
        (byte) 76,
        (byte) 73,
        (byte) 83,
        (byte) 84,
        (byte) 26,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 73,
        (byte) 78,
        (byte) 70,
        (byte) 79,
        (byte) 73,
        (byte) 83,
        (byte) 70,
        (byte) 84,
        (byte) 14,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 76,
        (byte) 97,
        (byte) 118,
        (byte) 102,
        (byte) 53,
        (byte) 54,
        (byte) 46,
        (byte) 52,
        (byte) 48,
        (byte) 46,
        (byte) 49,
        (byte) 48,
        (byte) 49,
        (byte) 0,
        (byte) 100,
        (byte) 97,
        (byte) 116,
        (byte) 97,
        (byte) 88,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 126,
        (byte) 4,
        (byte) 240,
        (byte) 8,
        (byte) 64,
        (byte) 13,
        (byte) 95,
        (byte) 17,
        (byte) 67,
        (byte) 21,
        (byte) 217,
        (byte) 24,
        (byte) 23,
        (byte) 28,
        (byte) 240,
        (byte) 30,
        (byte) 94,
        (byte) 33,
        (byte) 84,
        (byte) 35,
        (byte) 208,
        (byte) 36,
        (byte) 204,
        (byte) 37,
        (byte) 71,
        (byte) 38,
        (byte) 64,
        (byte) 38,
        (byte) 183,
        (byte) 37,
        (byte) 180,
        (byte) 36,
        (byte) 58,
        (byte) 35,
        (byte) 79,
        (byte) 33,
        (byte) 1,
        (byte) 31,
        (byte) 86,
        (byte) 28,
        (byte) 92,
        (byte) 25,
        (byte) 37,
        (byte) 22,
        (byte) 185,
        (byte) 18,
        (byte) 42,
        (byte) 15,
        (byte) 134,
        (byte) 11,
        (byte) 222,
        (byte) 7,
        (byte) 68,
        (byte) 4,
        (byte) 196,
        (byte) 0,
        (byte) 112,
        (byte) 253,
        (byte) 86,
        (byte) 250,
        (byte) 132,
        (byte) 247,
        (byte) 6,
        (byte) 245,
        (byte) 230,
        (byte) 242,
        (byte) 47,
        (byte) 241,
        (byte) 232,
        (byte) 239,
        (byte) 25,
        (byte) 239,
        (byte) 194,
        (byte) 238,
        (byte) 231,
        (byte) 238,
        (byte) 139,
        (byte) 239,
        (byte) 169,
        (byte) 240,
        (byte) 61,
        (byte) 242,
        (byte) 67,
        (byte) 244,
        (byte) 180,
        (byte) 246
      };
      try
      {
        using (MemoryStream memoryStream = new MemoryStream(buffer))
          SoundEffect.FromStream((Stream) memoryStream);
      }
      catch (NoAudioHardwareException ex)
      {
        Console.WriteLine("No audio hardware found. Disabling all audio.");
        return false;
      }
      catch
      {
        return false;
      }
      return true;
    }
  }
}
