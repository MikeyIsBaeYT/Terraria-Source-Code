// Decompiled with JetBrains decompiler
// Type: Terraria.Audio.LegacySoundStyle
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework.Audio;
using Terraria.Utilities;

namespace Terraria.Audio
{
  public class LegacySoundStyle : SoundStyle
  {
    private static readonly UnifiedRandom Random = new UnifiedRandom();
    private readonly int _style;
    public readonly int Variations;
    public readonly int SoundId;

    public int Style => this.Variations != 1 ? LegacySoundStyle.Random.Next(this._style, this._style + this.Variations) : this._style;

    public override bool IsTrackable => this.SoundId == 42;

    public LegacySoundStyle(int soundId, int style, SoundType type = SoundType.Sound)
      : base(type)
    {
      this._style = style;
      this.Variations = 1;
      this.SoundId = soundId;
    }

    public LegacySoundStyle(int soundId, int style, int variations, SoundType type = SoundType.Sound)
      : base(type)
    {
      this._style = style;
      this.Variations = variations;
      this.SoundId = soundId;
    }

    private LegacySoundStyle(
      int soundId,
      int style,
      int variations,
      SoundType type,
      float volume,
      float pitchVariance)
      : base(volume, pitchVariance, type)
    {
      this._style = style;
      this.Variations = variations;
      this.SoundId = soundId;
    }

    public LegacySoundStyle WithVolume(float volume) => new LegacySoundStyle(this.SoundId, this._style, this.Variations, this.Type, volume, this.PitchVariance);

    public LegacySoundStyle WithPitchVariance(float pitchVariance) => new LegacySoundStyle(this.SoundId, this._style, this.Variations, this.Type, this.Volume, pitchVariance);

    public LegacySoundStyle AsMusic() => new LegacySoundStyle(this.SoundId, this._style, this.Variations, SoundType.Music, this.Volume, this.PitchVariance);

    public LegacySoundStyle AsAmbient() => new LegacySoundStyle(this.SoundId, this._style, this.Variations, SoundType.Ambient, this.Volume, this.PitchVariance);

    public LegacySoundStyle AsSound() => new LegacySoundStyle(this.SoundId, this._style, this.Variations, SoundType.Sound, this.Volume, this.PitchVariance);

    public bool Includes(int soundId, int style) => this.SoundId == soundId && style >= this._style && style < this._style + this.Variations;

    public override SoundEffect GetRandomSound() => this.IsTrackable ? SoundEngine.GetTrackableSoundByStyleId(this.Style) : (SoundEffect) null;
  }
}
