// Decompiled with JetBrains decompiler
// Type: Terraria.Audio.SoundStyle
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework.Audio;
using Terraria.Utilities;

namespace Terraria.Audio
{
  public abstract class SoundStyle
  {
    private static UnifiedRandom _random = new UnifiedRandom();
    private float _volume;
    private float _pitchVariance;
    private SoundType _type;

    public float Volume => this._volume;

    public float PitchVariance => this._pitchVariance;

    public SoundType Type => this._type;

    public abstract bool IsTrackable { get; }

    public SoundStyle(float volume, float pitchVariance, SoundType type = SoundType.Sound)
    {
      this._volume = volume;
      this._pitchVariance = pitchVariance;
      this._type = type;
    }

    public SoundStyle(SoundType type = SoundType.Sound)
    {
      this._volume = 1f;
      this._pitchVariance = 0.0f;
      this._type = type;
    }

    public float GetRandomPitch() => (float) ((double) SoundStyle._random.NextFloat() * (double) this.PitchVariance - (double) this.PitchVariance * 0.5);

    public abstract SoundEffect GetRandomSound();
  }
}
