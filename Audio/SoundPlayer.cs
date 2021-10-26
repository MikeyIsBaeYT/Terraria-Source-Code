// Decompiled with JetBrains decompiler
// Type: Terraria.Audio.SoundPlayer
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Utilities;
using System.Collections.Generic;

namespace Terraria.Audio
{
  public class SoundPlayer
  {
    private readonly SlotVector<ActiveSound> _trackedSounds = new SlotVector<ActiveSound>(4096);

    public SlotId Play(SoundStyle style, Vector2 position)
    {
      if (Main.dedServ || style == null || !style.IsTrackable)
        return (SlotId) SlotId.Invalid;
      return (double) Vector2.DistanceSquared(Main.screenPosition + new Vector2((float) (Main.screenWidth / 2), (float) (Main.screenHeight / 2)), position) > 100000000.0 ? (SlotId) SlotId.Invalid : this._trackedSounds.Add(new ActiveSound(style, position));
    }

    public SlotId Play(SoundStyle style) => Main.dedServ || style == null || !style.IsTrackable ? (SlotId) SlotId.Invalid : this._trackedSounds.Add(new ActiveSound(style));

    public ActiveSound GetActiveSound(SlotId id) => !this._trackedSounds.Has(id) ? (ActiveSound) null : this._trackedSounds[id];

    public void PauseAll()
    {
      foreach (SlotVector<ActiveSound>.ItemPair trackedSound in (IEnumerable<SlotVector<ActiveSound>.ItemPair>) this._trackedSounds)
        ((ActiveSound) trackedSound.Value).Pause();
    }

    public void ResumeAll()
    {
      foreach (SlotVector<ActiveSound>.ItemPair trackedSound in (IEnumerable<SlotVector<ActiveSound>.ItemPair>) this._trackedSounds)
        ((ActiveSound) trackedSound.Value).Resume();
    }

    public void StopAll()
    {
      foreach (SlotVector<ActiveSound>.ItemPair trackedSound in (IEnumerable<SlotVector<ActiveSound>.ItemPair>) this._trackedSounds)
        ((ActiveSound) trackedSound.Value).Stop();
      this._trackedSounds.Clear();
    }

    public void Update()
    {
      foreach (SlotVector<ActiveSound>.ItemPair trackedSound in (IEnumerable<SlotVector<ActiveSound>.ItemPair>) this._trackedSounds)
      {
        try
        {
          ((ActiveSound) trackedSound.Value).Update();
          if (!((ActiveSound) trackedSound.Value).IsPlaying)
            this._trackedSounds.Remove((SlotId) trackedSound.Id);
        }
        catch
        {
          this._trackedSounds.Remove((SlotId) trackedSound.Id);
        }
      }
    }

    public ActiveSound FindActiveSound(SoundStyle style)
    {
      foreach (SlotVector<ActiveSound>.ItemPair trackedSound in (IEnumerable<SlotVector<ActiveSound>.ItemPair>) this._trackedSounds)
      {
        if (((ActiveSound) trackedSound.Value).Style == style)
          return (ActiveSound) trackedSound.Value;
      }
      return (ActiveSound) null;
    }
  }
}
