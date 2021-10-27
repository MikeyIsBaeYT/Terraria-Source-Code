// Decompiled with JetBrains decompiler
// Type: Terraria.Audio.ActiveSound
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Terraria.Audio
{
  public class ActiveSound
  {
    private SoundEffectInstance _sound;
    public readonly bool IsGlobal;
    public Vector2 Position;
    public float Volume;
    private SoundStyle _style;

    public SoundEffectInstance Sound => this._sound;

    public SoundStyle Style => this._style;

    public bool IsPlaying => this.Sound.State == SoundState.Playing;

    public ActiveSound(SoundStyle style, Vector2 position)
    {
      this.Position = position;
      this.Volume = 1f;
      this.IsGlobal = false;
      this._style = style;
      this.Play();
    }

    public ActiveSound(SoundStyle style)
    {
      this.Position = Vector2.Zero;
      this.Volume = 1f;
      this.IsGlobal = true;
      this._style = style;
      this.Play();
    }

    private void Play()
    {
      SoundEffectInstance instance = this._style.GetRandomSound().CreateInstance();
      instance.Pitch += this._style.GetRandomPitch();
      Main.PlaySoundInstance(instance);
      this._sound = instance;
      this.Update();
    }

    public void Stop()
    {
      if (this._sound == null)
        return;
      this._sound.Stop();
    }

    public void Pause()
    {
      if (this._sound == null || this._sound.State != SoundState.Playing)
        return;
      this._sound.Pause();
    }

    public void Resume()
    {
      if (this._sound == null || this._sound.State != SoundState.Paused)
        return;
      this._sound.Resume();
    }

    public void Update()
    {
      if (this._sound == null)
        return;
      Vector2 vector2 = Main.screenPosition + new Vector2((float) (Main.screenWidth / 2), (float) (Main.screenHeight / 2));
      float num1 = 1f;
      if (!this.IsGlobal)
      {
        this.Sound.Pan = MathHelper.Clamp((float) (((double) this.Position.X - (double) vector2.X) / ((double) Main.screenWidth * 0.5)), -1f, 1f);
        num1 = (float) (1.0 - (double) Vector2.Distance(this.Position, vector2) / ((double) Main.screenWidth * 1.5));
      }
      float num2 = num1 * (this._style.Volume * this.Volume);
      switch (this._style.Type)
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
