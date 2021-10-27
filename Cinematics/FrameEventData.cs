// Decompiled with JetBrains decompiler
// Type: Terraria.Cinematics.FrameEventData
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.Cinematics
{
  public struct FrameEventData
  {
    private int _absoluteFrame;
    private int _start;
    private int _duration;

    public int AbsoluteFrame => this._absoluteFrame;

    public int Start => this._start;

    public int Duration => this._duration;

    public int Frame => this._absoluteFrame - this._start;

    public bool IsFirstFrame => this._start == this._absoluteFrame;

    public bool IsLastFrame => this.Remaining == 0;

    public int Remaining => this._start + this._duration - this._absoluteFrame - 1;

    public FrameEventData(int absoluteFrame, int start, int duration)
    {
      this._absoluteFrame = absoluteFrame;
      this._start = start;
      this._duration = duration;
    }
  }
}
