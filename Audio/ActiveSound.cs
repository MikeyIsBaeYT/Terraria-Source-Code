// Decompiled with JetBrains decompiler
// Type: Terraria.Audio.ActiveSound
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Terraria.Audio
{
  public class ActiveSound
  {
    public readonly bool IsGlobal;
    public Vector2 Position;
    public float Volume;

    public SoundEffectInstance Sound { get; private set; }

    public SoundStyle Style { get; private set; }

    public bool IsPlaying => this.Sound.State == SoundState.Playing;

    public ActiveSound(SoundStyle style, Vector2 position)
    {
      this.Position = position;
      this.Volume = 1f;
      this.IsGlobal = false;
      this.Style = style;
      this.Play();
    }

    public ActiveSound(SoundStyle style)
    {
      this.Position = Vector2.Zero;
      this.Volume = 1f;
      this.IsGlobal = true;
      this.Style = style;
      this.Play();
    }

    private void Play()
    {
      SoundEffectInstance instance = this.Style.GetRandomSound().CreateInstance();
      instance.Pitch += this.Style.GetRandomPitch();
      instance.Play();
      SoundInstanceGarbageCollector.Track(instance);
      this.Sound = instance;
      this.Update();
    }

    public void Stop()
    {
      if (this.Sound == null)
        return;
      this.Sound.Stop();
    }

    public void Pause()
    {
      if (this.Sound == null || this.Sound.State != SoundState.Playing)
        return;
      this.Sound.Pause();
    }

    public void Resume()
    {
      if (this.Sound == null || this.Sound.State != SoundState.Paused)
        return;
      this.Sound.Resume();
    }

    public void Update()
    {
      if (this.Sound == null)
        return;
      Vector2 vector2 = Main.screenPosition + new Vector2((float) (Main.screenWidth / 2), (float) (Main.screenHeight / 2));
      float num1 = 1f;
      if (!this.IsGlobal)
      {
        this.Sound.Pan = MathHelper.Clamp((float) (((double) this.Position.X - (double) vector2.X) / ((double) Main.screenWidth * 0.5)), -1f, 1f);
        num1 = (float) (1.0 - (double) Vector2.Distance(this.Position, vector2) / ((double) Main.screenWidth * 1.5));
      }
      float num2 = num1 * (this.Style.Volume * this.Volume);
      switch (this.Style.Type)
      {
        case SoundType.Sound:
          num2 *= Main.soundVolume;
          break;
        case SoundType.Ambient:
          num2 *= Main.ambientVolume;
          break;
        case SoundType.Music:
          num2 *= Main.musicVolume;
          break;
      }
      this.Sound.Volume = MathHelper.Clamp(num2, 0.0f, 1f);
    }
  }
}
