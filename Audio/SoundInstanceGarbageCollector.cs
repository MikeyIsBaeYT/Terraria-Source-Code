// Decompiled with JetBrains decompiler
// Type: Terraria.Audio.SoundInstanceGarbageCollector
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace Terraria.Audio
{
  public static class SoundInstanceGarbageCollector
  {
    private static readonly List<SoundEffectInstance> _activeSounds = new List<SoundEffectInstance>(128);

    public static void Track(SoundEffectInstance sound)
    {
    }

    public static void Update()
    {
      for (int index = 0; index < SoundInstanceGarbageCollector._activeSounds.Count; ++index)
      {
        if (SoundInstanceGarbageCollector._activeSounds[index] == null)
        {
          SoundInstanceGarbageCollector._activeSounds.RemoveAt(index);
          --index;
        }
        else if (SoundInstanceGarbageCollector._activeSounds[index].State == SoundState.Stopped)
        {
          SoundInstanceGarbageCollector._activeSounds[index].Dispose();
          SoundInstanceGarbageCollector._activeSounds.RemoveAt(index);
          --index;
        }
      }
    }
  }
}
