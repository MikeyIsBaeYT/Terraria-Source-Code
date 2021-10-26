// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.DrawAnimation
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.DataStructures
{
  public class DrawAnimation
  {
    public int Frame;
    public int FrameCount;
    public int TicksPerFrame;
    public int FrameCounter;

    public virtual void Update()
    {
    }

    public virtual Rectangle GetFrame(Texture2D texture, int frameCounterOverride = -1) => texture.Frame();
  }
}
