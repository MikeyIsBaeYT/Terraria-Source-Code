// Decompiled with JetBrains decompiler
// Type: Terraria.Audio.LegacySoundStyle
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework.Audio;
using Terraria.Utilities;

namespace Terraria.Audio
{
  public class LegacySoundStyle : SoundStyle
  {
    private static UnifiedRandom _random = new UnifiedRandom();
    private int _style;
    private int _styleVariations;
    private int _soundId;

    public int Style => this._styleVariations != 1 ? LegacySoundStyle._random.Next(this._style, this._style + this._styleVariations) : this._style;

    public int Variations => this._styleVariations;

    public int SoundId => this._soundId;

    public override bool IsTrackable => this._soundId == 42;

    public LegacySoundStyle(int soundId, int style, SoundType type = SoundType.Sound)
      : base(type)
    {
      this._style = style;
      this._styleVariations = 1;
      this._soundId = soundId;
    }

    public LegacySoundStyle(int soundId, int style, int variations, SoundType type = SoundType.Sound)
      : base(type)
    {
      this._style = style;
      this._styleVariations = variations;
      this._soundId = soundId;
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
      this._styleVariations = variations;
      this._soundId = soundId;
    }

    public LegacySoundStyle WithVolume(float volume) => new LegacySoundStyle(this._soundId, this._style, this._styleVariations, this.Type, volume, this.PitchVariance);

    public LegacySoundStyle WithPitchVariance(float pitchVariance) => new LegacySoundStyle(this._soundId, this._style, this._styleVariations, this.Type, this.Volume, pitchVariance);

    public LegacySoundStyle AsMusic() => new LegacySoundStyle(this._soundId, this._style, this._styleVariations, SoundType.Music, this.Volume, this.PitchVariance);

    public LegacySoundStyle AsAmbient() => new LegacySoundStyle(this._soundId, this._style, this._styleVariations, SoundType.Ambient, this.Volume, this.PitchVariance);

    public LegacySoundStyle AsSound() => new LegacySoundStyle(this._soundId, this._style, this._styleVariations, SoundType.Sound, this.Volume, this.PitchVariance);

    public bool Includes(int soundId, int style) => this._soundId == soundId && style >= this._style && style < this._style + this._styleVariations;

    public override SoundEffect GetRandomSound() => this.IsTrackable ? Main.trackableSounds[this.Style] : (SoundEffect) null;
  }
}
