// Decompiled with JetBrains decompiler
// Type: Terraria.Audio.CustomSoundStyle
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework.Audio;
using Terraria.Utilities;

namespace Terraria.Audio
{
  public class CustomSoundStyle : SoundStyle
  {
    private static readonly UnifiedRandom Random = new UnifiedRandom();
    private readonly SoundEffect[] _soundEffects;

    public override bool IsTrackable => true;

    public CustomSoundStyle(
      SoundEffect soundEffect,
      SoundType type = SoundType.Sound,
      float volume = 1f,
      float pitchVariance = 0.0f)
      : base(volume, pitchVariance, type)
    {
      this._soundEffects = new SoundEffect[1]{ soundEffect };
    }

    public CustomSoundStyle(
      SoundEffect[] soundEffects,
      SoundType type = SoundType.Sound,
      float volume = 1f,
      float pitchVariance = 0.0f)
      : base(volume, pitchVariance, type)
    {
      this._soundEffects = soundEffects;
    }

    public override SoundEffect GetRandomSound() => this._soundEffects[CustomSoundStyle.Random.Next(this._soundEffects.Length)];
  }
}
