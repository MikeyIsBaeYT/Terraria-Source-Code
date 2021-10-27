// Decompiled with JetBrains decompiler
// Type: Terraria.Cinematics.Film
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Terraria.Cinematics
{
  public class Film
  {
    private int _frame;
    private int _frameCount;
    private int _nextSequenceAppendTime;
    private bool _isActive;
    private List<Film.Sequence> _sequences = new List<Film.Sequence>();

    public int Frame => this._frame;

    public int FrameCount => this._frameCount;

    public int AppendPoint => this._nextSequenceAppendTime;

    public bool IsActive => this._isActive;

    public void AddSequence(int start, int duration, FrameEvent frameEvent)
    {
      this._sequences.Add(new Film.Sequence(frameEvent, start, duration));
      this._nextSequenceAppendTime = Math.Max(this._nextSequenceAppendTime, start + duration);
      this._frameCount = Math.Max(this._frameCount, start + duration);
    }

    public void AppendSequence(int duration, FrameEvent frameEvent) => this.AddSequence(this._nextSequenceAppendTime, duration, frameEvent);

    public void AddSequences(int start, int duration, params FrameEvent[] frameEvents)
    {
      foreach (FrameEvent frameEvent in frameEvents)
        this.AddSequence(start, duration, frameEvent);
    }

    public void AppendSequences(int duration, params FrameEvent[] frameEvents)
    {
      int sequenceAppendTime = this._nextSequenceAppendTime;
      foreach (FrameEvent frameEvent in frameEvents)
      {
        this._sequences.Add(new Film.Sequence(frameEvent, sequenceAppendTime, duration));
        this._nextSequenceAppendTime = Math.Max(this._nextSequenceAppendTime, sequenceAppendTime + duration);
        this._frameCount = Math.Max(this._frameCount, sequenceAppendTime + duration);
      }
    }

    public void AppendEmptySequence(int duration) => this.AddSequence(this._nextSequenceAppendTime, duration, new FrameEvent(Film.EmptyFrameEvent));

    public void AppendKeyFrame(FrameEvent frameEvent) => this.AddKeyFrame(this._nextSequenceAppendTime, frameEvent);

    public void AppendKeyFrames(params FrameEvent[] frameEvents)
    {
      int sequenceAppendTime = this._nextSequenceAppendTime;
      foreach (FrameEvent frameEvent in frameEvents)
        this._sequences.Add(new Film.Sequence(frameEvent, sequenceAppendTime, 1));
      this._frameCount = Math.Max(this._frameCount, sequenceAppendTime + 1);
    }

    public void AddKeyFrame(int frame, FrameEvent frameEvent)
    {
      this._sequences.Add(new Film.Sequence(frameEvent, frame, 1));
      this._frameCount = Math.Max(this._frameCount, frame + 1);
    }

    public void AddKeyFrames(int frame, params FrameEvent[] frameEvents)
    {
      foreach (FrameEvent frameEvent in frameEvents)
        this.AddKeyFrame(frame, frameEvent);
    }

    public bool OnUpdate(GameTime gameTime)
    {
      if (this._sequences.Count == 0)
        return false;
      foreach (Film.Sequence sequence in this._sequences)
      {
        int num = this._frame - sequence.Start;
        if (num >= 0 && num < sequence.Duration)
          sequence.Event(new FrameEventData(this._frame, sequence.Start, sequence.Duration));
      }
      return ++this._frame != this._frameCount;
    }

    public virtual void OnBegin() => this._isActive = true;

    public virtual void OnEnd() => this._isActive = false;

    private static void EmptyFrameEvent(FrameEventData evt)
    {
    }

    private class Sequence
    {
      private FrameEvent _frameEvent;
      private int _duration;
      private int _start;

      public FrameEvent Event => this._frameEvent;

      public int Duration => this._duration;

      public int Start => this._start;

      public Sequence(FrameEvent frameEvent, int start, int duration)
      {
        this._frameEvent = frameEvent;
        this._start = start;
        this._duration = duration;
      }
    }
  }
}
